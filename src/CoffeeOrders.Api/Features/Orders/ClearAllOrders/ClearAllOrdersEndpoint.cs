namespace CoffeeOrders.Api.Features.Orders.ClearAllOrders;

public class ClearAllOrdersEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete(
                "/api/orders/clearall",
                async (IMessageBus bus, CancellationToken cancellationToken) =>
                {
                    var command = new ClearAllOrderCommand();
                    await bus.InvokeAsync(command, cancellationToken);

                    return Results.NoContent();
                }
            )
            .WithName("ClearAllOrders")
            .WithSummary("Clear All Orders")
            .WithDescription("Clear All Orders from the history")
            .Produces(StatusCodes.Status204NoContent);
    }
}
