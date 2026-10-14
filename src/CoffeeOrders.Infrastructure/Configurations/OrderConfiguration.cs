using CoffeeOrders.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeOrders.Infrastructure.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CoffeeId).IsRequired();

        builder.Property(x => x.Total).IsRequired();
        builder.Property(x => x.Size).IsRequired();

        builder.Property(x => x.OrderName).IsRequired().HasMaxLength(500);
        builder.Property(x => x.Status).IsRequired().HasMaxLength(25);

        builder.Property(x => x.CreatedBy).HasMaxLength(500);
        builder.Property(x => x.UpdatedBy).HasMaxLength(500);
    }
}
