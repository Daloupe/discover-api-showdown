using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace User.Data
{
    public class ItemLineService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ItemLineService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ItemLine[]> GetItemLines(Guid billId)
        {
            using var client = _httpClientFactory.CreateClient();
            return await client
                .GetStringAsync("https://localhost:5001/bill/" + billId)
                .Deserialize<ItemLine[]>();
        }

        public async Task<ItemLine[]> ClaimItemLine(Guid userid, Guid itemId)
        {
            var json = JsonSerializer.Serialize(new ClaimItem
            {
                UserId = userid,
                ItemId = itemId,
            });
            using var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var response = await client.PostAsync("https://localhost:5001/bill/claim-item", new StringContent(json, Encoding.UTF8, "application/json"));
            return await response.Content.ReadAsStringAsync().Deserialize<ItemLine[]>();
        }

        public async Task<ItemLine[]> UnclaimItemLine(Guid userid, Guid itemId)
        {
            var json = JsonSerializer.Serialize(new ClaimItem
            {
                UserId = userid,
                ItemId = itemId,
            });
            using var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var response = await client.PostAsync("https://localhost:5001/bill/unclaim-item", new StringContent(json, Encoding.UTF8, "application/json"));
            return await response.Content.ReadAsStringAsync().Deserialize<ItemLine[]>();
        }
    }
}
