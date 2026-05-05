using SmartRetail.Domain.Entities;

namespace SmartRetail.Domain.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product?> GetProductByIdAsync(string productId);
}