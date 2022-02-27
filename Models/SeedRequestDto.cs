namespace InventoryUI.Models
{
    public class SeedRequestDto
    {
        public int RequestId { get; set; }
        public int SeedId { get; set; }
        public string? SeedName { get; set; }
        public int RequestedKernels { get; set; }
        public int AvailableKernels { get; set; }
        public bool SufficientInventory { get; set; }
    }
}
