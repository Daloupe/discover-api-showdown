using System;
using System.Linq;
using System.Net.Http;
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
            return await _httpClientFactory
                .CreateClient()
                .GetStringAsync("https://localhost:5001/bill/" + billId)
                .Deserialize<ItemLine[]>();
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
