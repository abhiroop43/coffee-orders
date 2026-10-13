using CoffeeOrders.Domain.Common;

namespace CoffeeOrders.Domain;

public class Coffee : Entity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required string SkuCode { get; set; }
    public string? Photo { get; set; }
}
