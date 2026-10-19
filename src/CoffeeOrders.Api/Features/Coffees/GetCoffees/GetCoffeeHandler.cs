using Mapster;
using Microsoft.EntityFrameworkCore;

namespace CoffeeOrders.Api.Features.Coffees.GetCoffees;

public sealed class GetCoffeeHandler
{
    private GetCoffeeHandler() { }

    public static async Task<GetCoffeesResponse> Handle(
        GetCoffeesQuery query,
        ApplicationDbContext dbContext,
        CancellationToken cancellationToken
    )
    {
        const int minSearchLength = 3;
        var searchTerm = query.Search?.Trim();

        if (searchTerm?.Length < minSearchLength)
        {
            searchTerm = null;
        }

        var coffeesQuery = dbContext.Coffees.AsNoTracking().AsQueryable();

        if (!string.IsNullOrEmpty(searchTerm))
        {
            coffeesQuery = coffeesQuery.Where(c =>
                EF.Functions.Like(c.Name, $"%{searchTerm}%")
                || (c.Description != null && EF.Functions.Like(c.Description, $"%{searchTerm}%"))
            );
        }

        var totalCount = await coffeesQuery.LongCountAsync(cancellationToken);
        var pageIndex = query.PaginationRequest.PageNumber - 1;
        var pageSize = query.PaginationRequest.PageSize;

        var coffeeList = await coffeesQuery
            .OrderByDescending(x => x.UpdatedDate)
            .ThenBy(x => x.Id)
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ProjectToType<CoffeeDto>()
            .ToListAsync(cancellationToken);

        var result = new PaginationResponse<CoffeeDto>(
            query.PaginationRequest.PageNumber,
            query.PaginationRequest.PageSize,
            totalCount,
            coffeeList
        );

        return new GetCoffeesResponse(result);
    }
}
