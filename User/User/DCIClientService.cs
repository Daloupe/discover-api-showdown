using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using User.Models;

namespace User
{
    public class DCIClientService
    {
        private readonly string _converterApiPlan = "DCI_CURRENCYCONVERSION_SANDBOX";
        private readonly string _converterUrl = "currencyconversion/v1/";

        private readonly string _tipApiPlan = "DCI_TIPETIQUETTE_SANDBOX";
        private readonly string _tipUrl = "tip/v1/";

        private string token = "6795d6d4-9a9d-4217-a915-bb6023c141d7";

        public HttpClient Client { get; }

        public DCIClientService(HttpClient client)
        {
            Client = client;

        }

        //public async Task<IEnumerable<DCIClientService>> PostOauth()
        //{
        //    using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, "/auth/oauth/v2/token?grant_type=Client&scope=DCI_CURRENCYCONVERSION DCI_TIP"))
        //    {
        //        requestMessage.Headers.Add("Authorization","");
        //        requestMessage.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
        //        requestMessage.Headers.Add("Cache-Control", "no-cache");

        //        var response = await Client.SendAsync(requestMessage);
        //    }
        //}

        public async Task<IEnumerable<Currency>> GetCurrencyConversions()
        {
            // Usings no longer need the squiggly brackets and will dispose when they g out of scope.
            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, "exchangerates");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            
            var response = await Client.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();

            // System.Text.Json now exists with its own optimized json serializers.
            return JsonSerializer.Deserialize<IEnumerable<Currency>>(json);
        }
    }
}