using Carter;
using CoffeeOrders.Api.Dtos;
using CoffeeOrders.Api.Shared.Pagination;
using Microsoft.AspNetCore.Mvc;
using Wolverine;

namespace CoffeeOrders.Api.Features.Coffees.GetCoffees;

public sealed record GetCoffeesResponse(PaginationResponse<CoffeeDto> Items);

public class GetCoffeesEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/api/coffee",
                async (
                    [FromQuery] int? pageNumber,
                    [FromQuery] int? pageSize,
                    [FromQuery] string? search,
                    IMessageBus bus,
                    CancellationToken cancellationToken
                ) =>
                {
                    var normalizedPageNumber = Math.Max(pageNumber ?? 1, 1);
                    var normalizedPageSize = Math.Clamp(pageSize ?? 10, 1, 100);

                    var query = new GetCoffeesQuery(
                        new PaginationRequest(normalizedPageNumber, normalizedPageSize),
                        search
                    );

                    var response = await bus.InvokeAsync<GetCoffeesResponse>(
                        query,
                        cancellationToken
                    );

                    return Results.Ok(response);
                }
            )
            .WithName("GetCoffeeList")
            .WithSummary("Get Coffee List")
            .WithDescription("Get a list of Coffees for lookup")
            .Produces<GetCoffeesResponse>();
    }
}
