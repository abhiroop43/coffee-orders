using CoffeeOrders.Api;
using CoffeeOrders.Infrastructure;
using CoffeeOrders.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureServices(builder.Configuration).AddApiServices();

var app = builder.Build();

app.UseApiServices();

if (app.Environment.IsDevelopment())
    await app.InitializeDatabaseAsync();

await app.RunAsync();
