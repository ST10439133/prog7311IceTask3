namespace SmartRetail.Domain.Entities;

public class InventoryItem
{
    public string ProductId { get; set; } = string.Empty;
    public int QuantityOnHand { get; set; }
    public int ReorderThreshold { get; set; }
    public DateTime LastUpdated { get; set; }//DateTime
}