namespace CoffeeOrders.Api.Features.Orders.GetOrders;

public sealed record GetOrdersResponse(PaginationResponse<OrderDto> Items);

public class GetOrdersEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/api/orders",
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

                    var query = new GetOrdersQuery(
                        new PaginationRequest(normalizedPageNumber, normalizedPageSize),
                        search
                    );
                    var response = await bus.InvokeAsync<GetOrdersResponse>(
                        query,
                        cancellationToken
                    );

                    return Results.Ok(response);
                }
            )
            .WithName("GetOrders")
            .WithSummary("Get Orders")
            .WithDescription("Get a list of orders")
            .Produces<GetOrdersResponse>();
    }
}
