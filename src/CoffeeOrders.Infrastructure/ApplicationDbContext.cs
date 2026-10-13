using System.Reflection;
using CoffeeOrders.Domain;
using Microsoft.EntityFrameworkCore;

namespace CoffeeOrders.Infrastructure;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
{
    private const string DefaultSchema = "CoffeeOrders";
    public DbSet<Coffee> Coffees => Set<Coffee>();
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.HasDefaultSchema(DefaultSchema);
        base.OnModelCreating(modelBuilder);
    }
}
