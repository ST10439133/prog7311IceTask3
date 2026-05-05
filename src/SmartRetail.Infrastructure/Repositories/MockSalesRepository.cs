using SmartRetail.Domain.Entities;
using SmartRetail.Domain.Interfaces;
using SmartRetail.Infrastructure.Data;

namespace SmartRetail.Infrastructure.Repositories;

/// <summary>
/// Liskov Substitution Principle (L) - can replace any ISalesRepository implementation
/// </summary>
public class MockSalesRepository : ISalesRepository
{
    private readonly List<Sale> _sales;

    public MockSalesRepository()
    {
        var products = MockDataGenerator.GenerateProducts();
        _sales = MockDataGenerator.GenerateSales(products);
    }

    public Task<IEnumerable<Sale>> GetSalesByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        var result = _sales.Where(s => s.Timestamp >= startDate && s.Timestamp <= endDate);
        return Task.FromResult(result);
    }

    public Task<IEnumerable<Sale>> GetSalesByProductAsync(string productId)
    {
        var result = _sales.Where(s => s.ProductId == productId);
        return Task.FromResult(result);
    }
}