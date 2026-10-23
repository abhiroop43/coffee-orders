using CoffeeOrders.Api.Shared.Middleware;
using Mapster;

namespace CoffeeOrders.Api.Features.Orders.CreateOrder;

public sealed record CreateOrderRequest(
    string? OrderName,
    decimal? Total,
    string? Size,
    string? Status,
    Guid? CoffeeId
);

public sealed record CreateOrderResponse(OrderDto Order);

public class CreateOrderEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(
                "/api/orders",
                async (
                    [FromBody] CreateOrderRequest request,
                    IMessageBus bus,
                    CancellationToken cancellationToken
                ) =>
                {
                    var command = request.Adapt<CreateOrderCommand>();

                    var response = await bus.InvokeAsync<CreateOrderResponse>(
                        command,
                        cancellationToken
                    );

                    return Results.Created($"/api/orders/{response.Order.Id}", response);
                }
            )
            .AddEndpointFilter<ValidationMiddleware<CreateOrderRequest>>()
            .WithName("CreateOrder")
            .WithSummary("Create Order")
            .WithDescription("Create a new order")
            .Produces<CreateOrderResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
