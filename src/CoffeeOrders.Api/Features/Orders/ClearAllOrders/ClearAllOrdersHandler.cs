using CoffeeOrders.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CoffeeOrders.Api.Features.Orders.ClearAllOrders;

public sealed class ClearAllOrdersHandler
{
    private ClearAllOrdersHandler() { }

    public static async Task Handle(
        ClearAllOrderCommand _,
        ApplicationDbContext dbContext,
        ILogger<ClearAllOrdersHandler> logger,
        CancellationToken cancellationToken
    )
    {
        var deletedCount = await dbContext.Orders.ExecuteDeleteAsync(cancellationToken);

        logger.LogInformation("Deleted {Count} orders", deletedCount);
    }
}
