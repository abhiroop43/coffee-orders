namespace CoffeeOrders.Api.Dtos;

public sealed record OrderDto(
    Guid Id,
    string OrderName,
    decimal Total,
    string Size,
    string Status,
    Guid CoffeeId,
    CoffeeDto Coffee,
    string CreatedBy,
    DateTime CreatedDate,
    string UpdatedBy,
    DateTime UpdatedDate
);
