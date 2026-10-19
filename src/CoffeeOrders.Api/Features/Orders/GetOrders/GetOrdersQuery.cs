namespace CoffeeOrders.Api.Features.Orders.GetOrders;

public sealed record GetOrdersQuery(PaginationRequest PaginationRequest, string? Search);
