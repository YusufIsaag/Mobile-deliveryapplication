using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Mobile_deliveryapplication.Models;

namespace Mobile_deliveryapplication.Services
{
    public class DeliveryService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "b9e7d970-8d82-4b56-92d8-d18fbb4b68a7";

        public DeliveryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            // Voeg API key header toe aan HttpClient zodat die bij elke request meegaat
            if (!_httpClient.DefaultRequestHeaders.Contains("x-api-key"))
            {
                _httpClient.DefaultRequestHeaders.Add("x-api-key", ApiKey);
            }
        }

        public async Task<List<Bestelling>> GetBestellingenAsync()
        {
            var response = await _httpClient.GetAsync("api/Order");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var bestellingen = JsonSerializer.Deserialize<List<Bestelling>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return bestellingen;
        }

        public async Task StartDeliveryAsync(int orderId)
        {
            var request = CreatePostRequest("api/DeliveryStates/StartDelivery", new { OrderId = orderId });
            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"API-fout: {response.StatusCode} - {error}");
            }
        }

        public async Task UpdateDeliveryStateAsync(int orderId)
        {
            var request = CreatePostRequest("api/DeliveryStates/UpdateDeliveryState", new { OrderId = orderId });
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        public async Task CompleteDeliveryAsync(int orderId)
        {
            var request = CreatePostRequest("api/DeliveryStates/CompleteDelivery", new { OrderId = orderId });
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }

        private HttpRequestMessage CreatePostRequest(string url, object body)
        {
            var json = JsonSerializer.Serialize(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = content
            };
           
            return request;
        }
    }
}
