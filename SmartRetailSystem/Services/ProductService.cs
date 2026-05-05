using SmartRetailSystem.Models;

namespace SmartRetailSystem.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Laptop", Price = 15000, Stock = 5 },
            new Product { Id = 2, Name = "Phone", Price = 8000, Stock = 10 },
            new Product { Id = 3, Name = "Headphones", Price = 1500, Stock = 20 }
        };

        public List<Product> GetAllProducts() => _products;

        public Product GetById(int id) =>
            _products.FirstOrDefault(p => p.Id == id);
    }
}