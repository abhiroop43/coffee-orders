using CoffeeOrders.Domain;
using CoffeeOrders.Domain.Constants;
using Mapster;
using Microsoft.EntityFrameworkCore;

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
        var newOrder = command.Adapt<Order>();
        newOrder.Id = Guid.NewGuid();

        if (string.IsNullOrEmpty(newOrder.Status))
            newOrder.Status = OrderStatus.Preparing;

        dbContext.Orders.Add(newOrder);
        var savedCount = await dbContext.SaveChangesAsync(cancellationToken);

        if (savedCount < 1)
            throw new ArgumentException("Failed to save order");

        var order = await dbContext
            .Orders.AsNoTracking()
            .Where(x => x.Id == newOrder.Id && x.IsActive)
            .ProjectToType<OrderDto>()
            .FirstOrDefaultAsync(cancellationToken);

        var orderDto = order.Adapt<OrderDto>();
        return new CreateOrderResponse(orderDto!);
    }
}
