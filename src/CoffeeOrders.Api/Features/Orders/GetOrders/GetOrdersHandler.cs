using Mapster;
using Microsoft.EntityFrameworkCore;

namespace CoffeeOrders.Api.Features.Orders.GetOrders;

public sealed class GetOrdersHandler
{
    private GetOrdersHandler() { }

    public static async Task<GetOrdersResponse> Handle(
        GetOrdersQuery query,
        ApplicationDbContext dbContext,
        CancellationToken cancellationToken
    )
    {
        const int minSearchLength = 3;

        var searchTerm = query.Search?.Trim();

        if (searchTerm?.Length < minSearchLength)
            searchTerm = null;

        var ordersQuery = dbContext.Orders.AsNoTracking().AsQueryable().Where(o => o.IsActive);

        if (!string.IsNullOrWhiteSpace(searchTerm))
            ordersQuery = ordersQuery.Where(order =>
                EF.Functions.Like(order.OrderName, $"%{searchTerm}%")
            );

        var totalCount = await ordersQuery.LongCountAsync(cancellationToken);
        var pageIndex = query.PaginationRequest.PageNumber - 1;
        var pageSize = query.PaginationRequest.PageSize;

        var orders = await ordersQuery
            .OrderByDescending(o => o.UpdatedDate)
            .ThenBy(o => o.Id)
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ProjectToType<OrderDto>()
            .ToListAsync(cancellationToken);

        var result = new PaginationResponse<OrderDto>(
            query.PaginationRequest.PageNumber,
            query.PaginationRequest.PageSize,
            totalCount,
            orders
        );

        return new GetOrdersResponse(result);
    }
}
