using InventoryUI.Models;

namespace InventoryUI.Services
{
    public interface IInventoryService
    {
        Task<IEnumerable<SeedRequestDto>> GetSeedRequests();

        Task<IEnumerable<SeedInventoryDto>> GetSeedInventory();
    }
}
