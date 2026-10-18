using System.Reflection;
using FluentValidation;

namespace CoffeeOrders.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(
        this IServiceCollection services,
        ConfigureHostBuilder hostBuilder
    )
    {
        // Add services to the container.
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        services.AddOpenApi();
        services.AddProblemDetails();

        services.AddCarter(configurator: configurator =>
        {
            configurator.WithDefaultValidatorLifetime(ServiceLifetime.Scoped);
        });

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), ServiceLifetime.Scoped);

        hostBuilder.UseWolverine(opts =>
        {
            opts.UseEntityFrameworkCoreTransactions();
        });

        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
            app.MapOpenApi();

        app.UseHttpsRedirection();

        app.MapCarter();
        return app;
    }
}
