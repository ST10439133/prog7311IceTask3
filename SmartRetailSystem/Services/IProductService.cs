using SmartRetailSystem.Models;

namespace SmartRetailSystem.Services
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetById(int id);
    }
}