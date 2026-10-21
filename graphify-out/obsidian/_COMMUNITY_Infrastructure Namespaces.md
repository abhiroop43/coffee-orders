---
type: community
members: 25
---

# Infrastructure Namespaces

**Members:** 25 nodes

## Members
- [[20261014080243_InitialCreate.Designer.cs]] - code - src/CoffeeOrders.Infrastructure/Migrations/20261014080243_InitialCreate.Designer.cs
- [[20261014080243_InitialCreate.cs]] - code - src/CoffeeOrders.Infrastructure/Migrations/20261014080243_InitialCreate.cs
- [[20261014081200_ColumnSizes.Designer.cs]] - code - src/CoffeeOrders.Infrastructure/Migrations/20261014081200_ColumnSizes.Designer.cs
- [[20261014081200_ColumnSizes.cs]] - code - src/CoffeeOrders.Infrastructure/Migrations/20261014081200_ColumnSizes.cs
- [[ApplicationDbContext.cs]] - code - src/CoffeeOrders.Infrastructure/ApplicationDbContext.cs
- [[ApplicationDbContextModelSnapshot.cs]] - code - src/CoffeeOrders.Infrastructure/Migrations/ApplicationDbContextModelSnapshot.cs
- [[AuditableEntityInterceptor.cs]] - code - src/CoffeeOrders.Infrastructure/Interceptors/AuditableEntityInterceptor.cs
- [[ClearAllOrdersHandler.cs]] - code - src/CoffeeOrders.Api/Features/Orders/ClearAllOrders/ClearAllOrdersHandler.cs
- [[CoffeeOrders.Infrastructure]] - code - src/CoffeeOrders.Infrastructure/ApplicationDbContext.cs
- [[CoffeeOrders.Infrastructure.Extensions]] - code - src/CoffeeOrders.Infrastructure/Extensions/DatabaseExtensions.cs
- [[CoffeeOrders.Infrastructure.Interceptors]] - code - src/CoffeeOrders.Infrastructure/Interceptors/AuditableEntityInterceptor.cs
- [[CoffeeOrders.Infrastructure.Migrations]] - code - src/CoffeeOrders.Infrastructure/Migrations/20261014080243_InitialCreate.Designer.cs
- [[CoffeeOrders.InfrastructureDependencyInjection.cs]] - code - src/CoffeeOrders.Infrastructure/DependencyInjection.cs
- [[DatabaseExtensions.cs]] - code - src/CoffeeOrders.Infrastructure/Extensions/DatabaseExtensions.cs
- [[microsoft_aspnetcore_builder]] - concept
- [[microsoft_entityframeworkcore]] - concept
- [[microsoft_entityframeworkcore_changetracking]] - concept
- [[microsoft_entityframeworkcore_diagnostics]] - concept
- [[microsoft_entityframeworkcore_infrastructure]] - concept
- [[microsoft_entityframeworkcore_metadata]] - concept
- [[microsoft_entityframeworkcore_migrations]] - concept
- [[microsoft_entityframeworkcore_storage_valueconversion]] - concept
- [[microsoft_extensions_configuration]] - concept
- [[microsoft_extensions_dependencyinjection]] - concept
- [[system]] - concept

## Live Query (requires Dataview plugin)

```dataview
TABLE source_file, type FROM #community/Infrastructure_Namespaces
SORT file.name ASC
```

## Connections to other communities
- 5 edges to [[_COMMUNITY_DTOs and Migrations]]
- 4 edges to [[_COMMUNITY_Domain Entities and Configs]]
- 3 edges to [[_COMMUNITY_Order Handlers and Validation]]
- 3 edges to [[_COMMUNITY_DbContext and Audit Interceptor]]
- 3 edges to [[_COMMUNITY_API Composition Root]]
- 1 edge to [[_COMMUNITY_Clear All Orders Feature]]
- 1 edge to [[_COMMUNITY_Get Coffees Feature]]
- 1 edge to [[_COMMUNITY_Create Order and Middleware]]

## Top bridge nodes
- [[microsoft_entityframeworkcore]] - degree 13, connects to 4 communities
- [[ApplicationDbContext.cs]] - degree 5, connects to 3 communities
- [[AuditableEntityInterceptor.cs]] - degree 6, connects to 2 communities
- [[ClearAllOrdersHandler.cs]] - degree 4, connects to 2 communities
- [[20261014080243_InitialCreate.Designer.cs]] - degree 9, connects to 1 community