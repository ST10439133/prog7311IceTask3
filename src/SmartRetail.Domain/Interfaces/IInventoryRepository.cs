using SmartRetail.Domain.Entities;

namespace SmartRetail.Domain.Interfaces;

public interface IInventoryRepository
{
    Task<IEnumerable<InventoryItem>> GetCurrentInventoryAsync();
}