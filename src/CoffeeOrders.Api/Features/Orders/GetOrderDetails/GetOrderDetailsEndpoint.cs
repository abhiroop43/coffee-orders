namespace CoffeeOrders.Api.Features.Orders.GetOrderDetails;

public sealed record GetOrderDetailsResponse(OrderDto Data);

public class GetOrderDetailsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/api/orders/{orderId:guid}",
                async (
                    [FromRoute] Guid orderId,
                    IMessageBus bus,
                    CancellationToken cancellationToken
                ) =>
                {
                    var query = new GetOrderDetailsQuery(orderId);
                    var response = await bus.InvokeAsync<GetOrderDetailsResponse>(query);

                    return Results.Ok(response);
                }
            )
            .WithName("GetOrderDetails")
            .WithSummary("Get Order Details")
            .WithDescription("Get Order Details using Order Id")
            .Produces<GetOrderDetailsResponse>()
            .ProducesProblem(StatusCodes.Status404NotFound);
    }
}
