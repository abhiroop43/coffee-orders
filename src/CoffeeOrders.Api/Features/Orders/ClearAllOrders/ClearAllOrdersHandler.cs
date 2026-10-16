using CoffeeOrders.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CoffeeOrders.Api.Features.Orders.ClearAllOrders;

public sealed class ClearAllOrdersHandler
{
    private ClearAllOrdersHandler() { }

    public static async Task Handler(
        ApplicationDbContext dbContext,
        CancellationToken cancellationToken
    )
    {
        await dbContext.Orders.ExecuteDeleteAsync(cancellationToken);

        // log the deletion activity and the record count deleted
    }
}
