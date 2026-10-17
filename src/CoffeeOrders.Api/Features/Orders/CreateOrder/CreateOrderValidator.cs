using FluentValidation;

namespace CoffeeOrders.Api.Features.Orders.CreateOrder;

public class CreateOrderValidator : AbstractValidator<CreateOrderRequest>
{
    private const string RequiredFieldMessage = "{PropertyName} is required";
    private const string GreaterThanMessage =
        "{PropertyName} must be greater than {ComparisonValue}";

    public CreateOrderValidator()
    {
        RuleFor(x => x.CoffeeId)
            .NotEmpty()
            .WithMessage(RequiredFieldMessage)
            .MustAsync(CoffeeIdExistsAndActiveAsync);

        RuleFor(x => x.OrderName).NotEmpty().MaximumLength(500);
        RuleFor(x => x.Total)
            .NotEmpty()
            .WithMessage(RequiredFieldMessage)
            .GreaterThan(0)
            .WithMessage(GreaterThanMessage);

        RuleFor(x => x.Size).NotEmpty().WithMessage(RequiredFieldMessage).MustAsync(SizeExists);

        RuleFor(x => x.Status).MustAsync(StatusExists);
    }

    private Task<bool> StatusExists(string? orderStatus, CancellationToken arg2)
    {
        throw new NotImplementedException();
    }

    private Task<bool> SizeExists(string? orderSize, CancellationToken arg2)
    {
        throw new NotImplementedException();
    }

    private Task<bool> CoffeeIdExistsAndActiveAsync(Guid? coffeeId, CancellationToken arg2)
    {
        throw new NotImplementedException();
    }
}
