namespace InventoryUI.Models
{
    public class SeedInventoryDto
    {
        public int SeedId { get; set; }
        public string? SeedName { get; set; }
        public int AvailableKernels { get; set; }
        public int RequestedKernels { get; set; }
        public bool SufficientInventory { get; set; }
    }
}
