using CoffeeOrders.Domain.Common;
using CoffeeOrders.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CoffeeOrders.Infrastructure.Interceptors;

public class AuditableEntityInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result
    )
    {
        UpdateEntities(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = new()
    )
    {
        UpdateEntities(eventData.Context);
        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private static void UpdateEntities(DbContext? dbContext)
    {
        if (dbContext == null)
            return;

        foreach (var entry in dbContext.ChangeTracker.Entries<Entity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedDate = DateTime.UtcNow;
                entry.Entity.CreatedBy = "System";
            }

            if (
                entry.State != EntityState.Added
                && entry.State != EntityState.Modified
                && !entry.HasChangedOwnEntities()
            )
            {
                continue;
            }

            entry.Entity.UpdatedDate = DateTime.UtcNow;
            entry.Entity.UpdatedBy = "System";
        }
    }
}
