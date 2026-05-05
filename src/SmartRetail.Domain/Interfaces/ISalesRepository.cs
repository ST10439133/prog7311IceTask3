using SmartRetail.Domain.Entities;

namespace SmartRetail.Domain.Interfaces;

/// <summary>
/// Interface Segregation Principle (I) - small, focused interface
/// Dependency Inversion Principle (D) - API depends on this abstraction
/// </summary>
public interface ISalesRepository
{
    Task<IEnumerable<Sale>> GetSalesByDateRangeAsync(DateTime startDate, DateTime endDate);
    Task<IEnumerable<Sale>> GetSalesByProductAsync(string productId);
}