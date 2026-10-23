using Microsoft.EntityFrameworkCore;

namespace CoffeeOrders.Api.Features.Orders.DeleteOrder;

public sealed class DeleteOrderHandler
{
    private DeleteOrderHandler() { }

    public static async Task<DeleteOrderResponse> Handle(
        DeleteOrderCommand command,
        ApplicationDbContext dbContext,
        CancellationToken cancellationToken
    )
    {
        var order = await dbContext.Orders.FirstOrDefaultAsync(
            x => x.Id == command.OrderId && x.IsActive,
            cancellationToken
        );

        if (order == null)
            // replace with custom exception
            throw new ArgumentException("Order with Id not found");

        order.IsActive = false;
        var savedRecords = await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteOrderResponse(savedRecords > 0);
    }
}
