using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion(
            oi => oi.Value,
            dbId => OrderItemId.Of(dbId));

        builder.HasOne<Product>().WithMany().HasForeignKey(oi => oi.ProductId);

        builder.Property(oi => oi.Price).IsRequired();
        builder.Property(oi => oi.Quantity).IsRequired();
    }
}