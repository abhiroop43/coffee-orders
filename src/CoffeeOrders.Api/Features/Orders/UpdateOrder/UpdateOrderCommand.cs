namespace CoffeeOrders.Api.Features.Orders.UpdateOrder;

public sealed record UpdateOrderCommand(
    Guid Id,
    string OrderName,
    decimal Total,
    string Size,
    string? Status,
    Guid CoffeeId
);
