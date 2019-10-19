using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Merchant.Models;

namespace Merchant
{
    public class DCIClientService
    {
        private readonly string _dciUri = "https://api.discover.com/dci/";

        private readonly string _converterApiPlan = "DCI_CURRENCYCONVERSION_SANDBOX";
        private readonly string _converterUrl = "currencyconversion/v1/";

        private readonly string _tipApiPlan = "DCI_TIPETIQUETTE_SANDBOX";
        private readonly string _tipUrl = "tip/v1/";

        private readonly string _token = "07ebbc11-b96e-4ae5-bb33-a8fdd56678fe";

        public HttpClient Client { get; }

        public DCIClientService(HttpClient client)
        {
            Client = client;

        }

        private void SetHeaders(HttpRequestMessage requestMessage, string apiPlan)
        {
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            requestMessage.Headers.Add("Accept", "application/json");
            requestMessage.Headers.Add("X-DFS-API-PLAN", apiPlan);
        }

        public async Task<TipGuide[]> GetTipGuides()
        {
            // Usings no longer need the squiggly brackets and will dispose when they go out of scope.
            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, _dciUri + _tipUrl + "guide");
            SetHeaders(requestMessage, _tipApiPlan);

            var response = await Client.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();

            // System.Text.Json now exists with its own optimized json serializers.
            return JsonSerializer.Deserialize<TipGuide[]>(json);
        }

        public async Task<Currencies> GetCurrencyConversions()
        {
            // Usings no longer need the squiggly brackets and will dispose when they go out of scope.
            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, _dciUri + _converterUrl + "exchangerates");
            SetHeaders(requestMessage, _converterApiPlan);

            var response = await Client.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();

            // System.Text.Json now exists with its own optimized json serializers.
            return JsonSerializer.Deserialize<Currencies>(json);
        }
    }
}