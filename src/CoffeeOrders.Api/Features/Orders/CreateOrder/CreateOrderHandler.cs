using CoffeeOrders.Domain;
using CoffeeOrders.Domain.Constants;
using Mapster;

namespace CoffeeOrders.Api.Features.Orders.CreateOrder;

public sealed class CreateOrderHandler
{
    private CreateOrderHandler() { }

    public static async Task<CreateOrderResponse> Handle(
        CreateOrderCommand command,
        ApplicationDbContext dbContext,
        CancellationToken cancellationToken
    )
    {
        var order = command.Adapt<Order>();
        order.Id = Guid.NewGuid();

        if (string.IsNullOrEmpty(order.Status))
            order.Status = OrderStatus.Preparing;

        dbContext.Orders.Add(order);
        var savedCount = await dbContext.SaveChangesAsync(cancellationToken);

        if (savedCount < 1)
            throw new ArgumentException("Failed to save order");

        var orderDto = order.Adapt<OrderDto>();
        return new CreateOrderResponse(orderDto);
    }
}
