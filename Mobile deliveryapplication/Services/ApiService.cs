using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Mobile_deliveryapplication.Models;

namespace Mobile_deliveryapplication.API
{
    public static class ApiService
    {



        public static async Task<OrderModel?> GetOrderAsync(int orderId)
        {
            using var client = new HttpClient();
            var apiKey = "b9e7d970-8d82-4b56-92d8-d18fbb4b68a7";
            var endpoint = $"http://51.137.100.120:5000/api/Order/{orderId}";

            // Voeg header toe (probeer eerst deze naam, kan anders zijn)
            client.DefaultRequestHeaders.Add("ApiKey", apiKey);

            var response = await client.GetAsync(endpoint);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"API call failed: {response.StatusCode}");
                return null;
            }

            var json = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"API response: {json}");

            try
            {
                var order = JsonSerializer.Deserialize<OrderModel>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return order;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Deserialization error: {ex.Message}");
                return null;
            }
        }





    }


}
