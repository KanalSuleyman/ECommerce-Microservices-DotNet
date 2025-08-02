using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data;

public class DiscountContext(DbContextOptions<DiscountContext> options) : DbContext(options)
{
    public DbSet<Coupon> Coupons { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coupon>().HasData(
            new Coupon
            {
                Id = 1,
                ProductName = "Wood Dining Table",
                Description = "Dining table made of walnut tree",
                Amount = 150
            },
            new Coupon
            {
                Id = 2,
                ProductName = "White Wardrobe",
                Description = "Wardrobe with circular mirror",
                Amount = 100
            }
        );
    }
}