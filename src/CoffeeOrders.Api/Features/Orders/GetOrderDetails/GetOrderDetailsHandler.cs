using Mapster;
using Microsoft.EntityFrameworkCore;

namespace CoffeeOrders.Api.Features.Orders.GetOrderDetails;

public sealed class GetOrderDetailsHandler
{
    private GetOrderDetailsHandler() { }

    public static async Task<GetOrderDetailsResponse> Handle(
        GetOrderDetailsQuery query,
        ApplicationDbContext dbContext,
        CancellationToken cancellationToken
    )
    {
        var order = await dbContext
            .Orders.AsNoTracking()
            .Where(x => x.Id == query.OrderId && x.IsActive)
            .ProjectToType<OrderDto>()
            .FirstOrDefaultAsync(cancellationToken);

        if (order == null)
            // to be replaced with custom exception
            throw new ArgumentException("No order found with this Id");

        var dto = order.Adapt<OrderDto>();

        return new GetOrderDetailsResponse(dto);
    }
}
