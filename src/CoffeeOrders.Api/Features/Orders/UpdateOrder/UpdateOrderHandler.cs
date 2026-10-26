using Mapster;

namespace CoffeeOrders.Api.Features.Orders.UpdateOrder;

public sealed class UpdateOrderHandler
{
    private UpdateOrderHandler() { }

    public static async Task<UpdateOrderResponse> Handle(
        UpdateOrderCommand command,
        ApplicationDbContext dbContext,
        CancellationToken cancellationToken
    )
    {
        var currentOrder = await dbContext.Orders.FindAsync([command.Id], cancellationToken);
        if (currentOrder is null)
            throw new ArgumentException("Order not found");

        command.Adapt(currentOrder);
        await dbContext.SaveChangesAsync(cancellationToken);
        return new UpdateOrderResponse(true);
    }
}
