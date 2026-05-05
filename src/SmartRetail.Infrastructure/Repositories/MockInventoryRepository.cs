using SmartRetail.Domain.Entities;
using SmartRetail.Domain.Interfaces;
using SmartRetail.Infrastructure.Data;

namespace SmartRetail.Infrastructure.Repositories;

public class MockInventoryRepository : IInventoryRepository
{
    private readonly List<InventoryItem> _inventory;

    public MockInventoryRepository()
    {
        var products = MockDataGenerator.GenerateProducts();
        _inventory = MockDataGenerator.GenerateInventory(products);
    }

    public Task<IEnumerable<InventoryItem>> GetCurrentInventoryAsync()
    {
        return Task.FromResult(_inventory.AsEnumerable());
    }
}