using CoffeeOrders.Api.Shared.Pagination;

namespace CoffeeOrders.Api.Features.Coffees.GetCoffees;

public sealed record GetCoffeesQuery(PaginationRequest PaginationRequest, string? Search);
