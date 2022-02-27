using InventoryUI.Models;

namespace InventoryUI.Clients
{
    public interface IInventoryRequestsClient
    {
        Task<InventoryAndRequests?> GetInventoryAndRequests();
    }
}
