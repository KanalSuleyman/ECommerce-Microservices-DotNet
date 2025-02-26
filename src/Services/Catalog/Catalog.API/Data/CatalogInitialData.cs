using Marten.Schema;

namespace Catalog.API.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        await using var session = store.LightweightSession();

        if (await session.Query<Product>().AnyAsync(cancellation))
            return;

        session.Store(GetPreConfiguredProducts());
        await session.SaveChangesAsync(cancellation);
    }

    private static IEnumerable<Product> GetPreConfiguredProducts() =>
        new List<Product>
        {
            new()
            {
                Id = new Guid("a531d722-4f64-468e-94d1-5d163a4fbc3b"),
                Name = "Wooden Dining Table",
                Description = "A spacious dining table made from solid oak wood, perfect for family gatherings.",
                ImageFile = "dining_table.jpg",
                Price = 450.00M,
                Category = new List<string> { "Dining Room", "Tables" }
            },
            new()
            {
                Id = new Guid("c22d2856-9f85-4c5f-bf70-4f9a36e0900f"),
                Name = "Leather Sofa",
                Description = "A luxurious leather sofa that combines comfort and style, available in various colors.",
                ImageFile = "leather_sofa.jpg",
                Price = 1200.00M,
                Category = new List<string> { "Living Room", "Sofas" }
            },
            new()
            {
                Id = new Guid("0f02f59d-2338-4789-b3cd-82ccf589c71a"),
                Name = "Coffee Table",
                Description =
                    "A modern coffee table made from reclaimed wood with metal accents, ideal for any living space.",
                ImageFile = "coffee_table.jpg",
                Price = 250.00M,
                Category = new List<string> { "Living Room", "Tables" }
            },
            new()
            {
                Id = new Guid("deab4a76-91fe-40b2-a92a-37ec846d1e3f"),
                Name = "Storage Cabinet",
                Description = "A stylish storage cabinet with ample space for organizing your home essentials.",
                ImageFile = "storage_cabinet.jpg",
                Price = 350.00M,
                Category = new List<string> { "Living Room", "Storage" }
            },
            new()
            {
                Id = new Guid("4a5fbbf3-40b8-4ea9-bdb1-fd4d8d6f99ac"),
                Name = "Office Desk",
                Description = "An ergonomic office desk designed for productivity with adjustable height options.",
                ImageFile = "office_desk.jpg",
                Price = 400.00M,
                Category = new List<string> { "Office", "Desks" }
            },
            new()
            {
                Id = new Guid("8f5c1b99-1d28-409b-8e87-1f74a51e3f13"),
                Name = "Adjustable Bar Stool",
                Description = "A sleek adjustable bar stool with comfortable padding and a contemporary design.",
                ImageFile = "bar_stool.jpg",
                Price = 120.00M,
                Category = new List<string> { "Kitchen", "Stools" }
            },
            new()
            {
                Id = new Guid("b97c4329-532f-4f01-b56e-8fd20f315d8f"),
                Name = "King Size Bed",
                Description =
                    "A luxurious king-size bed with a solid wooden frame and plush mattress for ultimate comfort.",
                ImageFile = "king_bed.jpg",
                Price = 900.00M,
                Category = new List<string> { "Bedroom", "Beds" }
            },
            new()
            {
                Id = new Guid("68cfdcf9-9f59-4ccf-8db7-273bd2698105"),
                Name = "Bookshelf",
                Description = "A versatile wooden bookshelf with multiple shelves for displaying books or decor.",
                ImageFile = "bookshelf.jpg",
                Price = 180.00M,
                Category = new List<string> { "Living Room", "Storage" }
            },
            new()
            {
                Id = new Guid("6b77b4d0-44bc-48b1-b229-55d45a401541"),
                Name = "Modern Armchair",
                Description =
                    "A contemporary armchair with soft upholstery and sturdy wooden legs, perfect for any living space.",
                ImageFile = "armchair.jpg",
                Price = 300.00M,
                Category = new List<string> { "Living Room", "Chairs" }
            }
        };
    
}