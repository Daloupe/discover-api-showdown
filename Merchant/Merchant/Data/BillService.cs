using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Merchant.Data
{
    public class BillService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BillService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public static readonly Item[] _items = new[]
        {
            new Item
            {
                Name = "Coke 375ml",
                Price = 2.50m,
            },
            new Item
            {
                Name = "Sausage Roll",
                Price = 4.50m,
            },
            new Item
            {
                Name = "Meat Pie",
                Price = 3.50m,
            }
        };

        public Task<Item[]> GetItems()
        {
            return Task.FromResult(_items);
        }

        public async Task<Guid> CreateBill(List<ItemLine> itemLines)
        {
            var json = JsonSerializer.Serialize(itemLines);
            using var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var response = await client.PostAsync("https://localhost:5001/bill/create", new StringContent(json, Encoding.UTF8, "application/json"));
            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Guid>(responseJson);
        }
    }
}
