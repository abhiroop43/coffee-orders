using CoffeeOrders.Domain.Common;

namespace CoffeeOrders.Domain;

public class Order : Entity
{
    public required string OrderName { get; set; }
    public required decimal Total { get; set; }
    public required string Size { get; set; }
    public required string Status { get; set; }
}
