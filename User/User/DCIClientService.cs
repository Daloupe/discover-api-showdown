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
        private readonly string _dciUri = "https://api.discover.com/dci/";

        private readonly string _converterApiPlan = "DCI_CURRENCYCONVERSION_SANDBOX";
        private readonly string _converterUrl = "currencyconversion/v1/";

        private readonly string _tipApiPlan = "DCI_TIPETIQUETTE_SANDBOX";
        private readonly string _tipUrl = "tip/v1/";

        private readonly string _converterToken = "b4a52794-66c2-4f02-addc-0cbe45317d20";

        public HttpClient Client { get; }

        public DCIClientService(HttpClient client)
        {
            Client = client;

        }

        private void SetHeaders(HttpRequestMessage requestMessage, string token, string apiPlan)
        {
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            requestMessage.Headers.Add("Accept", "application/json");
            requestMessage.Headers.Add("X-DFS-API-PLAN", apiPlan);
        }
        public async Task<Currencies> GetCurrencyConversions()
        {
            // Usings no longer need the squiggly brackets and will dispose when they go out of scope.
            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, _dciUri + _converterUrl + "exchangerates");
            SetHeaders(requestMessage, _converterToken, _converterApiPlan);

            var response = await Client.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();

            // System.Text.Json now exists with its own optimized json serializers.
            return JsonSerializer.Deserialize<Currencies>(json);
        }
    }
}