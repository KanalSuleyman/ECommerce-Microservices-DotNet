using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data.Extensions;

internal class InitialData
{
    public static IEnumerable<Customer> Customers =>
        new List<Customer>
        {
            Customer.Create(CustomerId.Of(new Guid("5e3d53b4-dde0-4192-b109-968ca49761da")), "Suleyman Kanal",
                "mail@mail.com"),
            Customer.Create(CustomerId.Of(new Guid("b1c3d4e5-f6a7-8b9c-d0e1-f2a3b4c5d6e7")), "John Doe",
                "mail2@mail.com")
        };

    public static IEnumerable<Product> Products =>
        new List<Product>
        {
            Product.Create(ProductId.Of(new Guid("a0e6b5c3-1d2f-48e0-9a4c-5b6d7a8e9f01")), "Rustic Console Table",
                320.00M),
            Product.Create(ProductId.Of(new Guid("a7b6c5d4-e3f2-4a1b-9c8d-7e6f5d4c3b2a")), "Outdoor Patio Set",
                450.00M),
            Product.Create(ProductId.Of(new Guid("c3b2e1d0-a9f8-4c7b-8e6d-5a4f3b2c1d0e")), "Industrial Shelving Unit",
                280.00M),
            Product.Create(ProductId.Of(new Guid("4b6d8f0a-2c4e-6b8d-0f2a-4c6e8b0d2f4a")), "Two-Drawer Nightstand",
                160.00M)
        };

    public static IEnumerable<Order> OrderWithItems
    {
        get
        {
            var address1 = Address.Of("Suleyman", "Kanal", "mail@mail.com", "Odunpazarı", "Turkey", "Eskişehir",
                "26000");
            var address2 = Address.Of("John", "Doe", "johndoe@email.com", "Tepebaşı", "Turkey", "Eskişehir", "26100");

            var payment1 = Payment.Of("SuleymanDebit", "1234-5678-9012-3456", "12/25", "123", 1);
            var payment2 = Payment.Of("JohnCredit", "9876-5432-1098-7654", "11/24", "456", 2);

            var order1 = Order.Create(
                OrderId.Of(new Guid("d1e2f3a4-b5c6-7d8e-9f0a-b1c2d3e4f5a6")),
                CustomerId.Of(new Guid("5e3d53b4-dde0-4192-b109-968ca49761da")),
                OrderName.Of("ORD_1"),
                address1,
                address1,
                payment1
            );
            order1.AddOrderItem(ProductId.Of(new Guid("a0e6b5c3-1d2f-48e0-9a4c-5b6d7a8e9f01")), 2, 320.00M);
            order1.AddOrderItem(ProductId.Of(new Guid("a7b6c5d4-e3f2-4a1b-9c8d-7e6f5d4c3b2a")), 1, 450.00M);

            var order2 = Order.Create(
                OrderId.Of(new Guid("f6a7b8c9-d0e1-2f3a-4b5c-6d7e8f9a0b1c")),
                CustomerId.Of(new Guid("b1c3d4e5-f6a7-8b9c-d0e1-f2a3b4c5d6e7")),
                OrderName.Of("ORD_2"),
                address2,
                address2,
                payment2
            );
            order2.AddOrderItem(ProductId.Of(new Guid("c3b2e1d0-a9f8-4c7b-8e6d-5a4f3b2c1d0e")), 3, 280.00M);
            order2.AddOrderItem(ProductId.Of(new Guid("4b6d8f0a-2c4e-6b8d-0f2a-4c6e8b0d2f4a")), 1, 160.00M);

            return new List<Order> { order1, order2 };
        }
    }

}