using InventoryUI.Clients;
using InventoryUI.Models;

namespace InventoryUI.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRequestsClient _inventoryClient;

        public InventoryService(IInventoryRequestsClient inventoryClient)
        {
            _inventoryClient = inventoryClient;
        }

        public async Task<IEnumerable<SeedRequestDto>> GetSeedRequests()
        {
            var inventoryAndRequests = await _inventoryClient.GetInventoryAndRequests();

            if (inventoryAndRequests == null)
                throw new Exception("Error retrieving inventory and requests.");

            var seedRequests = inventoryAndRequests
                            .Requests
                            .GroupJoin(
                                inventoryAndRequests.Inventory,
                                r => r.InventoryId,
                                i => i.Id,
                                (request, inventory) =>
                                {
                                    var seed = inventory.SingleOrDefault();

                                    var availableKernels = seed == null ? 0 : seed.Kernels;

                                    return new SeedRequestDto
                                    {
                                        RequestId = request.Id,
                                        SeedId = request.InventoryId,
                                        SeedName = seed?.Name == null ? "" : seed.Name,
                                        RequestedKernels = request.RequestedKernels,
                                        AvailableKernels = availableKernels,
                                        SufficientInventory = availableKernels >= request.RequestedKernels
                                    };
                                }
                      );

            return seedRequests;
        }

        public async Task<IEnumerable<SeedInventoryDto>> GetSeedInventory()
        {
            var inventoryAndRequests = await _inventoryClient.GetInventoryAndRequests();

            if (inventoryAndRequests == null)
                throw new Exception("Error retrieving inventory and requests.");

            var seeds = inventoryAndRequests
                            .Inventory
                            .GroupJoin(
                                inventoryAndRequests.Requests,
                                i => i.Id,
                                r => r.InventoryId,
                                (inventory, requests) =>
                                {
                                    var requestedKernels = requests
                                                                .Select(x => x.RequestedKernels)
                                                                .Sum();

                                    return new SeedInventoryDto
                                    {
                                        SeedId = inventory.Id,
                                        SeedName = inventory.Name,
                                        AvailableKernels = inventory.Kernels,
                                        RequestedKernels = requestedKernels,
                                        SufficientInventory = inventory.Kernels >= requestedKernels
                                    };
                                }
                            );

            return seeds;
        }
    }
}
