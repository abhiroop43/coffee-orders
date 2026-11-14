using CoffeeOrders.Api.Shared.Exceptions;
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
        var currentOrder = await dbContext.Orders.FindAsync([command.Id], cancellationToken) ?? throw new ArgumentException("Order not found");
        command.Adapt(currentOrder);
        var savedRecords = await dbContext.SaveChangesAsync(cancellationToken);
        if (savedRecords < 1)
        {
            throw new BadRequestException("Unable to update order. Please check the input or contact the administrator.");
        }

        return new UpdateOrderResponse(currentOrder.Adapt<OrderDto>());
    }
}
