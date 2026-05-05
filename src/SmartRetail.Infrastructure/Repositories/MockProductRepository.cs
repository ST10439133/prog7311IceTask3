using SmartRetail.Domain.Entities;
using SmartRetail.Domain.Interfaces;
using SmartRetail.Infrastructure.Data;

namespace SmartRetail.Infrastructure.Repositories;

public class MockProductRepository : IProductRepository
{
    private readonly List<Product> _products;

    public MockProductRepository()
    {
        _products = MockDataGenerator.GenerateProducts();
    }

    public Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return Task.FromResult(_products.AsEnumerable());
    }

    public Task<Product?> GetProductByIdAsync(string productId)
    {
        var product = _products.FirstOrDefault(p => p.Id == productId);
        return Task.FromResult(product);
    }
}