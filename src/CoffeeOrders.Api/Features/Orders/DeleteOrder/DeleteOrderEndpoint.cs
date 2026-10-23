namespace CoffeeOrders.Api.Features.Orders.DeleteOrder;

public sealed record DeleteOrderResponse(bool Success);

public class DeleteOrderEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete(
                "/api/orders/{orderId:guid}",
                async (
                    [FromRoute] Guid orderId,
                    IMessageBus bus,
                    CancellationToken cancellationToken
                ) =>
                {
                    var command = new DeleteOrderCommand(orderId);

                    var response = await bus.InvokeAsync<DeleteOrderResponse>(command);

                    return response.Success
                        ? Results.NoContent()
                        : Results.BadRequest("Failed to delete order");
                }
            )
            .WithName("DeleteOrder")
            .WithSummary("Delete Order")
            .WithDescription("Delete an existing order")
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound);
    }
}
