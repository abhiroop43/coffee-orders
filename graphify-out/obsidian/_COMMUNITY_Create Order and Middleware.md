---
type: community
members: 16
---

# Create Order and Middleware

**Members:** 16 nodes

## Members
- [[dot-InvokeAsync()]] - code - src/CoffeeOrders.Api/Shared/Middleware/ValidationMiddleware.cs
- [[CoffeeOrders.Api.Features.Orders.CreateOrder]] - code - src/CoffeeOrders.Api/Features/Orders/CreateOrder/CreateOrderCommand.cs
- [[CoffeeOrders.Api.Shared.Middleware]] - code - src/CoffeeOrders.Api/Shared/Middleware/ExceptionHandlingMiddleware.cs
- [[CreateOrderCommand.cs]] - code - src/CoffeeOrders.Api/Features/Orders/CreateOrder/CreateOrderCommand.cs
- [[CreateOrderEndpoint.cs]] - code - src/CoffeeOrders.Api/Features/Orders/CreateOrder/CreateOrderEndpoint.cs
- [[CreateOrderValidator.cs]] - code - src/CoffeeOrders.Api/Features/Orders/CreateOrder/CreateOrderValidator.cs
- [[EndpointFilterDelegate]] - code
- [[EndpointFilterInvocationContext]] - code
- [[ExceptionHandlingMiddleware]] - code - src/CoffeeOrders.Api/Shared/Middleware/ExceptionHandlingMiddleware.cs
- [[ExceptionHandlingMiddleware.cs]] - code - src/CoffeeOrders.Api/Shared/Middleware/ExceptionHandlingMiddleware.cs
- [[IEndpointFilter]] - code
- [[IValidator]] - code
- [[ValidationMiddleware]] - code - src/CoffeeOrders.Api/Shared/Middleware/ValidationMiddleware.cs
- [[ValidationMiddleware.cs]] - code - src/CoffeeOrders.Api/Shared/Middleware/ValidationMiddleware.cs
- [[ValueTask]] - code
- [[fluentvalidation]] - concept

## Live Query (requires Dataview plugin)

```dataview
TABLE source_file, type FROM #community/Create_Order_and_Middleware
SORT file.name ASC
```

## Connections to other communities
- 3 edges to [[_COMMUNITY_DTOs and Migrations]]
- 2 edges to [[_COMMUNITY_Order Handlers and Validation]]
- 1 edge to [[_COMMUNITY_Clear All Orders Feature]]
- 1 edge to [[_COMMUNITY_DbContext and Audit Interceptor]]
- 1 edge to [[_COMMUNITY_Domain Enums]]
- 1 edge to [[_COMMUNITY_Domain Entities and Configs]]
- 1 edge to [[_COMMUNITY_Get Coffees Feature]]
- 1 edge to [[_COMMUNITY_Infrastructure Namespaces]]
- 1 edge to [[_COMMUNITY_API Composition Root]]

## Top bridge nodes
- [[CreateOrderEndpoint.cs]] - degree 6, connects to 4 communities
- [[CreateOrderValidator.cs]] - degree 5, connects to 3 communities
- [[ValidationMiddleware]] - degree 4, connects to 1 community
- [[CoffeeOrders.Api.Features.Orders.CreateOrder]] - degree 4, connects to 1 community
- [[fluentvalidation]] - degree 3, connects to 1 community