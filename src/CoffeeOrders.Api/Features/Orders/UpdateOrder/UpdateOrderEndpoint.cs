using CoffeeOrders.Api.Shared.Middleware;
using Mapster;

namespace CoffeeOrders.Api.Features.Orders.UpdateOrder;

public sealed record UpdateOrderRequest(
    Guid? Id,
    string? OrderName,
    decimal? Total,
    string? Size,
    string? Status,
    Guid? CoffeeId
);

public sealed record UpdateOrderResponse(bool Success);

public class UpdateOrderEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut(
                "/api/orders/{orderId:guid}",
                async (
                    [FromRoute] Guid orderId,
                    [FromBody] UpdateOrderRequest request,
                    IMessageBus bus,
                    CancellationToken cancellationToken
                ) =>
                {
                    var requestWithId = request with { Id = orderId };

                    var command = requestWithId.Adapt<UpdateOrderCommand>();
                    var response = await bus.InvokeAsync<UpdateOrderResponse>(
                        command,
                        cancellationToken
                    );

                    return response.Success ? Results.Ok() : Results.BadRequest();
                }
            )
            .AddEndpointFilter<ValidationMiddleware<UpdateOrderRequest>>();
    }
}
