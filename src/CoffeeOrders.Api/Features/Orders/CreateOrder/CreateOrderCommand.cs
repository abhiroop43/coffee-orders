namespace CoffeeOrders.Api.Features.Orders.CreateOrder;

public sealed record CreateOrderCommand(
    string OrderName,
    decimal Total,
    string Size,
    string? Status,
    Guid CoffeeId
);
