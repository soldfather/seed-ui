using InventoryUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryUI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ControllerBase
    {

        private readonly ILogger<InventoryController> _logger;
        private readonly IInventoryService _inventoryService;

        public InventoryController(ILogger<InventoryController> logger, IInventoryService inventoryService)
        {
            _logger = logger;
            _inventoryService = inventoryService;
        }

        [HttpGet("requests")]
        public async Task<IActionResult> GetSeedRequests()
        {
            var requests = await _inventoryService.GetSeedRequests();

            return Ok(requests);
        }

        [HttpGet("Seeds")]
        public async Task<IActionResult> GetSeedInventory()
        {
            var seeds = await _inventoryService.GetSeedInventory();

            return Ok(seeds);
        }
    }
}