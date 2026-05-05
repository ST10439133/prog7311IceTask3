using SmartRetailSystem.Interfaces;
using SmartRetailSystem.Models;

namespace SmartRetailSystem.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products;

        public ProductService()
        {
            _products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Price = 15000, Stock = 10 },
                new Product { Id = 2, Name = "Phone", Price = 8000, Stock = 20 }
            };
        }

        public List<Product> GetAllProducts()
        {
            return _products;
        }

        public Product GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }
    }
}