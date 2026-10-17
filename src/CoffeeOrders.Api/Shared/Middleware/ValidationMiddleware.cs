using FluentValidation;

namespace CoffeeOrders.Api.Shared.Middleware;

public class ValidationMiddleware<T> : IEndpointFilter
    where T : notnull
{
    public async ValueTask<object?> InvokeAsync(
        EndpointFilterInvocationContext context,
        EndpointFilterDelegate next
    )
    {
        var validator = context.HttpContext.RequestServices.GetService<IValidator<T>>();

        if (validator is null)
        {
            return await next(context);
        }

        var request = context.Arguments.OfType<T>().FirstOrDefault();

        if (request is null)
        {
            return await next(context);
        }

        var validationResult = await validator.ValidateAsync(
            request,
            context.HttpContext.RequestAborted
        );

        if (validationResult.IsValid)
            return await next(context);

        var errors = validationResult
            .Errors.GroupBy(err => err.PropertyName)
            .ToDictionary(
                group => group.Key,
                group => group.Select(err => err.ErrorMessage).ToArray()
            );

        return Results.ValidationProblem(errors);
    }
}
