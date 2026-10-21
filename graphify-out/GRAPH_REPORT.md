# Graph Report - CoffeeOrders  (2026-10-21)

## Corpus Check
- Corpus is ~3,473 words - fits in a single context window. You may not need a graph.

## Summary
- 284 nodes · 416 edges · 18 communities (16 shown, 2 thin omitted)
- Extraction: 98% EXTRACTED · 2% INFERRED · 0% AMBIGUOUS · INFERRED: 8 edges (avg confidence: 0.82)
- Token cost: 32,260 input · 0 output

## Community Hubs (Navigation)
- DTOs and Migrations
- Order Handlers and Validation
- Domain Entities and Configs
- Infrastructure Namespaces
- Get Coffees Feature
- Solution and NuGet Packages
- DbContext and Audit Interceptor
- Create Order and Middleware
- Launch Settings
- API Composition Root
- Domain Enums
- CI/CD and Deployment
- Clear All Orders Feature
- Exception Types
- Update Order Feature
- Get Order Details Feature
- Delete Order Feature

## God Nodes (most connected - your core abstractions)
1. `Order` - 13 edges
2. `Coffee` - 12 edges
3. `Entity` - 12 edges
4. `ApplicationDbContext` - 12 edges
5. `PaginationResponse` - 8 edges
6. `CreateOrderValidator` - 7 edges
7. `OrderStatus` - 7 edges
8. `CoffeeOrders.Infrastructure` - 7 edges
9. `http` - 6 edges
10. `https` - 6 edges

## Surprising Connections (you probably didn't know these)
- `coffeeorders.api compose service` --semantically_similar_to--> `Azure Web App 'coffeeorders' (Production slot)`  [INFERRED] [semantically similar]
  compose.yaml → .github/workflows/master_coffeeorders.yml
- `CreateOrderValidator` --references--> `CreateOrderRequest`  [EXTRACTED]
  src/CoffeeOrders.Api/Features/Orders/CreateOrder/CreateOrderValidator.cs → src/CoffeeOrders.Api/Features/Orders/CreateOrder/CreateOrderEndpoint.cs
- `Coffee` --inherits--> `Entity`  [EXTRACTED]
  src/CoffeeOrders.Domain/Coffee.cs → src/CoffeeOrders.Domain/Common/Entity.cs
- `ApplicationDbContext` --references--> `Coffee`  [EXTRACTED]
  src/CoffeeOrders.Infrastructure/ApplicationDbContext.cs → src/CoffeeOrders.Domain/Coffee.cs
- `Order` --inherits--> `Entity`  [EXTRACTED]
  src/CoffeeOrders.Domain/Order.cs → src/CoffeeOrders.Domain/Common/Entity.cs

## Import Cycles
- None detected.

## Hyperedges (group relationships)
- **Azure CI/CD build-artifact-deploy pipeline** — _github_workflows_master_coffeeorders_build, _github_workflows_master_coffeeorders_net_app_artifact, _github_workflows_master_coffeeorders_deploy, _github_workflows_master_coffeeorders_azure_web_app_coffeeorders [EXTRACTED 1.00]

## Communities (18 total, 2 thin omitted)

### Community 0 - "DTOs and Migrations"
Cohesion: 0.09
Nodes (15): CoffeeOrders.Api.Dtos, CoffeeDto, OrderDto, CreateOrderCommand, CreateOrderRequest, Entity, CreatedBy, CreatedDate (+7 more)

### Community 1 - "Order Handlers and Validation"
Cohesion: 0.09
Nodes (9): CoffeeOrders.Api.Features.Orders.GetOrders, ClearAllOrdersHandler, CreateOrderResponse, CreateOrderValidator, GetOrdersEndpoint, GetOrdersResponse, GetOrdersHandler, GetOrdersQuery (+1 more)

### Community 2 - "Domain Entities and Configs"
Cohesion: 0.09
Nodes (18): CoffeeOrders.Domain.Common, CoffeeOrders.Infrastructure.Configurations, CoffeeOrders.Domain, CreateOrderHandler, Coffee, Description, Name, Orders (+10 more)

### Community 3 - "Infrastructure Namespaces"
Cohesion: 0.16
Nodes (4): CoffeeOrders.Infrastructure.Migrations, CoffeeOrders.Infrastructure, CoffeeOrders.Infrastructure.Extensions, CoffeeOrders.Infrastructure.Interceptors

### Community 4 - "Get Coffees Feature"
Cohesion: 0.12
Nodes (12): CoffeeOrders.Api.Shared.Pagination, CoffeeOrders.Api.Features.Coffees.GetCoffees, GetCoffeeHandler, GetCoffeesEndpoint, GetCoffeesResponse, GetCoffeesQuery, PaginationRequest, PaginationResponse (+4 more)

### Community 5 - "Solution and NuGet Packages"
Cohesion: 0.10
Nodes (17): Carter (10.0.0), FluentValidation.DependencyInjectionExtensions (12.2.0), Mapster (10.0.13), Microsoft.AspNetCore.OpenApi (10.0.13), Microsoft.EntityFrameworkCore (10.0.12), Microsoft.EntityFrameworkCore.Design (10.0.13), Microsoft.EntityFrameworkCore.SqlServer (10.0.12), Scalar.AspNetCore (2.18.0) (+9 more)

### Community 6 - "DbContext and Audit Interceptor"
Cohesion: 0.15
Nodes (5): ApplicationDbContext, Coffees, Orders, DependencyInjection, AuditableEntityInterceptor

### Community 7 - "Create Order and Middleware"
Cohesion: 0.13
Nodes (4): CoffeeOrders.Api.Features.Orders.CreateOrder, CoffeeOrders.Api.Shared.Middleware, ExceptionHandlingMiddleware, ValidationMiddleware

### Community 8 - "Launch Settings"
Cohesion: 0.13
Nodes (15): ASPNETCORE_ENVIRONMENT, applicationUrl, commandName, dotnetRunMessages, environmentVariables, launchBrowser, applicationUrl, commandName (+7 more)

### Community 10 - "Domain Enums"
Cohesion: 0.14
Nodes (12): CoffeeOrders.Domain.Constants, CoffeeSize, Large, Medium, Small, OrderStatus, Cancelled, Completed (+4 more)

### Community 11 - "CI/CD and Deployment"
Cohesion: 0.32
Nodes (8): Build and deploy ASP.Net Core app to Azure Web App - coffeeorders (workflow), Azure Web App 'coffeeorders' (Production slot), build job (dotnet 10.x build & publish), deploy job (azure/webapps-deploy@v3), .net-app build artifact, Docker Compose configuration, coffeeorders.api compose service, src/CoffeeOrders.Api/Dockerfile

### Community 12 - "Clear All Orders Feature"
Cohesion: 0.29
Nodes (4): CoffeeOrders.Api.Features.Orders.ClearAllOrders, ClearAllOrderCommand, ClearAllOrdersEndpoint, CreateOrderEndpoint

### Community 13 - "Exception Types"
Cohesion: 0.29
Nodes (4): CoffeeOrders.Api.Shared.Exceptions, BadRequestException, InternalServerErrorException, NotFoundException

### Community 14 - "Update Order Feature"
Cohesion: 0.29
Nodes (4): CoffeeOrders.Api.Features.Orders.UpdateOrder, UpdateOrderCommand, UpdateOrderEndpoint, UpdateOrderHandler

### Community 15 - "Get Order Details Feature"
Cohesion: 0.29
Nodes (4): CoffeeOrders.Api.Features.Orders.GetOrderDetails, GetOrderDetailsEndpoint, GetOrderDetailsHandler, GetOrderDetailsQuery

### Community 16 - "Delete Order Feature"
Cohesion: 0.29
Nodes (4): CoffeeOrders.Api.Features.Orders.DeleteOrder, DeleteOrderCommand, DeleteOrderEndpoint, DeleteOrderHandler

## Knowledge Gaps
- **50 isolated node(s):** `net10.0`, `Carter (10.0.0)`, `FluentValidation.DependencyInjectionExtensions (12.2.0)`, `Mapster (10.0.13)`, `Microsoft.AspNetCore.OpenApi (10.0.13)` (+45 more)
  These have ≤1 connection - possible missing edges. (Counts symbols only; 100 node(s) total have ≤1 connection when file, concept and rationale nodes are included.)
- **2 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `Order` connect `Domain Entities and Configs` to `DTOs and Migrations`, `Order Handlers and Validation`, `DbContext and Audit Interceptor`?**
  _High betweenness centrality (0.093) - this node is a cross-community bridge._
- **What connects `net10.0`, `Carter (10.0.0)`, `FluentValidation.DependencyInjectionExtensions (12.2.0)` to the rest of the system?**
  _50 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `DTOs and Migrations` be split into smaller, more focused modules?**
  _Cohesion score 0.09274193548387097 - nodes in this community are weakly interconnected._
- **Why does `ApplicationDbContext` connect `DbContext and Audit Interceptor` to `DTOs and Migrations`, `Order Handlers and Validation`, `Domain Entities and Configs`, `Infrastructure Namespaces`?**
  _High betweenness centrality (0.086) - this node is a cross-community bridge._
- **Should `Order Handlers and Validation` be split into smaller, more focused modules?**
  _Cohesion score 0.09425287356321839 - nodes in this community are weakly interconnected._
- **Why does `CoffeeOrders.Domain.Constants` connect `Domain Enums` to `Domain Entities and Configs`, `Create Order and Middleware`?**
  _High betweenness centrality (0.067) - this node is a cross-community bridge._
- **Should `Domain Entities and Configs` be split into smaller, more focused modules?**
  _Cohesion score 0.0896551724137931 - nodes in this community are weakly interconnected._