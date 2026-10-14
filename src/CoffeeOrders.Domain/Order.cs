using CoffeeOrders.Domain.Common;
using CoffeeOrders.Domain.Constants;

namespace CoffeeOrders.Domain;

public class Order : Entity
{
    public required string OrderName { get; set; }
    public required decimal Total { get; set; }
    public required string Size { get; set; }
    public string Status { get; set; } = OrderStatus.Preparing;
    public Guid CoffeeId { get; set; }
}
