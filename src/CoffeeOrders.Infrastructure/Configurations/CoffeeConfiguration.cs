using CoffeeOrders.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeeOrders.Infrastructure.Configurations;

public class CoffeeConfiguration : IEntityTypeConfiguration<Coffee>
{
    public void Configure(EntityTypeBuilder<Coffee> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

        builder.Property(x => x.SkuCode).IsRequired().HasMaxLength(10).IsFixedLength();

        builder.Property(x => x.Description).HasMaxLength(1000);

        builder
            .HasMany(x => x.Orders)
            .WithOne()
            .HasForeignKey(o => o.CoffeeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.CreatedBy).HasMaxLength(500);
        builder.Property(x => x.UpdatedBy).HasMaxLength(500);
    }
}
