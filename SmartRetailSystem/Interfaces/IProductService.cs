using SmartRetailSystem.Models;

namespace SmartRetailSystem.Interfaces
{
    public interface IProductService
    {
        public List<Product> GetAllProducts();
        public Product GetProductById(int id);
    }
}