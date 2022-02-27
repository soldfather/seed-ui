using InventoryUI.Models;

namespace InventoryUI.Clients
{
    public class InventoryRequestsClient : IInventoryRequestsClient
    {
        private readonly HttpClient _httpClient;

        public InventoryRequestsClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<InventoryAndRequests?> GetInventoryAndRequests()
        {
            var response = await _httpClient.GetAsync("0077e191-c3ae-47f6-bbbd-3b3b905e4a60");

            response.EnsureSuccessStatusCode();

            if (response.Content == null)
                return null;

            return await response
                            .Content
                            .ReadFromJsonAsync<InventoryAndRequests>();
        }
    }
}
