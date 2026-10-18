using CoffeeOrders.Domain.Constants;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CoffeeOrders.Api.Features.Orders.CreateOrder;

public class CreateOrderValidator : AbstractValidator<CreateOrderRequest>
{
    private const string RequiredFieldMessage = "{PropertyName} is required";

    private const string GreaterThanMessage =
        "{PropertyName} must be greater than {ComparisonValue}";

    private readonly ApplicationDbContext _dbContext;

    public CreateOrderValidator(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;

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

        RuleFor(x => x.Size)
            .NotEmpty()
            .WithMessage(RequiredFieldMessage)
            .Must(SizeExists)
            .WithMessage("Invalid order size provided");

        RuleFor(x => x.Status).Must(StatusExists).WithMessage("Invalid order status provided");
    }

    private static bool StatusExists(string? orderStatus)
    {
        if (string.IsNullOrWhiteSpace(orderStatus))
            return false;
        orderStatus = orderStatus.ToUpperInvariant();

        return orderStatus == OrderStatus.Preparing
            || orderStatus == OrderStatus.Serving
            || orderStatus == OrderStatus.Completed
            || orderStatus == OrderStatus.Cancelled
            || orderStatus == OrderStatus.Refunded;
    }

    private static bool SizeExists(string? orderSize)
    {
        if (string.IsNullOrWhiteSpace(orderSize))
            return false;
        orderSize = orderSize.ToUpperInvariant();

        return orderSize == CoffeeSize.Small
            || orderSize == CoffeeSize.Medium
            || orderSize == CoffeeSize.Large;
    }

    private async Task<bool> CoffeeIdExistsAndActiveAsync(
        Guid? coffeeId,
        CancellationToken cancellationToken
    )
    {
        var coffeeExists = await _dbContext
            .Coffees.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == coffeeId && x.IsActive, cancellationToken);
        return coffeeExists != null;
    }
}
