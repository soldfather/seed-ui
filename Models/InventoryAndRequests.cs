namespace InventoryUI.Models
{
    public class InventoryAndRequests
    {
        public IEnumerable<Seed> Inventory { get; set; }
        public IEnumerable<Request> Requests { get; set; }
    }
}
