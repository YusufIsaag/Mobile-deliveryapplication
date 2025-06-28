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

        public static void GetDeliveryServices()

        {
            using (var client = new HttpClient())
                {
                    var apiKey = "b9e7d970-8d82-4b56-92d8-d18fbb4b68a7";
                    var endpoint = new Uri($"http://51.137.100.120:5000/api/DeliveryServices/b9e7d970-8d82-4b56-92d8-d18fbb4b68a7\r\n");

                    var result = client.GetAsync(endpoint).Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var json = result.Content.ReadAsStringAsync().Result;
                        Console.WriteLine(json);
                    }
                    else
                    {
                        Console.WriteLine($"Fout: {result.StatusCode}");
                    }
                }
            }
        public static async Task<DeliveryModel> GetDeliveryHistoryAsync()
        {
            using (var client = new HttpClient())
            {
                var apiKey = "b9e7d970-8d82-4b56-92d8-d18fbb4b68a7";
                var endpoint = $"http://51.137.100.120:5000/api/DeliveryServices/{apiKey}";

                var response = await client.GetAsync(endpoint);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var delivery = JsonSerializer.Deserialize<DeliveryModel>(json);
                    return delivery ?? new DeliveryModel();
                }
                else
                {
                    return new DeliveryModel();
                }
            }
        }
    }

}
