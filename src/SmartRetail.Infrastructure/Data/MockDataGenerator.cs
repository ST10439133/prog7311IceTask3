using SmartRetail.Domain.Entities;

namespace SmartRetail.Infrastructure.Data;

public static class MockDataGenerator
{
    private static readonly Random _random = new();

    public static List<Product> GenerateProducts()
    {
        return new List<Product>
        {
            new() { Id = "P001", Name = "Wireless Headphones", Category = "Electronics", Price = 79.99m, RfidTag = "RFID001" },
            new() { Id = "P002", Name = "Smart Watch", Category = "Electronics", Price = 199.99m, RfidTag = "RFID002" },
            new() { Id = "P003", Name = "Running Shoes", Category = "Apparel", Price = 89.99m, RfidTag = "RFID003" },
            new() { Id = "P004", Name = "Coffee Maker", Category = "Home", Price = 49.99m, RfidTag = "RFID004" },
            new() { Id = "P005", Name = "Backpack", Category = "Accessories", Price = 39.99m, RfidTag = "RFID005" },
            new() { Id = "P006", Name = "Phone Charger", Category = "Electronics", Price = 19.99m, RfidTag = "RFID006" },
            new() { Id = "P007", Name = "Yoga Mat", Category = "Sports", Price = 29.99m, RfidTag = "RFID007" },
            new() { Id = "P008", Name = "Desk Lamp", Category = "Home", Price = 34.99m, RfidTag = "RFID008" }
        };
    }

    public static List<Sale> GenerateSales(List<Product> products, int daysBack = 30)
    {
        var sales = new List<Sale>();
        var saleId = 1;
        var now = DateTime.Now;

        for (int day = 0; day < daysBack; day++)
        {
            var date = now.AddDays(-day).Date;
            var numTransactions = _random.Next(10, 51);

            for (int i = 0; i < numTransactions; i++)
            {
                var product = products[_random.Next(products.Count)];
                var quantity = _random.Next(1, 4);
                var hour = _random.Next(9, 22);
                var minute = _random.Next(0, 60);

                sales.Add(new Sale
                {
                    Id = $"SALE{saleId:D5}",
                    ProductId = product.Id,
                    Quantity = quantity,
                    UnitPrice = product.Price,
                    Timestamp = date.AddHours(hour).AddMinutes(minute),
                    TotalAmount = product.Price * quantity
                });
                saleId++;
            }
        }

        return sales;
    }

    public static List<InventoryItem> GenerateInventory(List<Product> products)
    {
        return products.Select(product => new InventoryItem
        {
            ProductId = product.Id,
            QuantityOnHand = _random.Next(5, 151),
            ReorderThreshold = _random.Next(10, 31),
            LastUpdated = DateTime.Now
        }).ToList();
    }
}