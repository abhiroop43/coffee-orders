namespace CoffeeOrders.Api.Dtos;

public sealed record CoffeeDto(
    Guid Id,
    string Name,
    string? Description,
    string SkuCode,
    string? Photo,
    string CreatedBy,
    DateTime CreatedDate,
    string UpdatedBy,
    DateTime UpdatedDate
);
