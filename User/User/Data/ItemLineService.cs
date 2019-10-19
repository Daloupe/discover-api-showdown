using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

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
            var response = await _httpClientFactory.CreateClient().GetStringAsync("https://localhost:5001/bill/" + billId);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return JsonSerializer.Deserialize<ItemLine[]>(response, options);
        }

        public async Task<ItemLine[]> ClaimItemLine(Guid userid, Guid itemId)
        {
            throw new NotImplementedException();
            //var response = await _httpClientFactory.CreateClient().SendAsync("https://localhost:5001/bill/" + billId);
            //return JsonSerializer.Deserialize<ItemLine[]>(response);
        }

        public async Task<ItemLine[]> UnclaimItemLine(Guid itemId)
        {
            throw new NotImplementedException();
            //var response = await _httpClientFactory.CreateClient().SendAsync("https://localhost:5001/bill/" + billId);
            //return JsonSerializer.Deserialize<ItemLine[]>(response);
        }
    }
}
