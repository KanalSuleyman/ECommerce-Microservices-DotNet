using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Infrastructure.Data.Extensions;

public static class DatabaseExtensions
{
    public static async Task InitializeDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        context.Database.MigrateAsync().GetAwaiter().GetResult();

        await SeedAsync(context);
    }

    public static async Task SeedAsync(ApplicationDbContext context)
    {
        await SeedCustomersAsync(context);
        await SeedProductsAsync(context);
        await SeedOrdersAndOrderItemsAsync(context);
    }

    public static async Task SeedCustomersAsync(ApplicationDbContext context)
    {
        if (!context.Customers.Any())
        {
            await context.Customers.AddRangeAsync(InitialData.Customers);
            await context.SaveChangesAsync();
        }
    }

    public static async Task SeedProductsAsync(ApplicationDbContext context)
    {
        if (!context.Products.Any())
        {
            await context.Products.AddRangeAsync(InitialData.Products);
            await context.SaveChangesAsync();
        }
    }

    public static async Task SeedOrdersAndOrderItemsAsync(ApplicationDbContext context)
    {
        if (!context.Orders.Any())
        {
            await context.Orders.AddRangeAsync(InitialData.OrderWithItems);
            await context.SaveChangesAsync();
        }
    }
}