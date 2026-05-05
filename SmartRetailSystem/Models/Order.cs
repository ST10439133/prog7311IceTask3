namespace SmartRetailSystem.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<CartItem> Items { get; set; } = new();
        public DateTime OrderDate { get; set; } = DateTime.Now;
    }
}
