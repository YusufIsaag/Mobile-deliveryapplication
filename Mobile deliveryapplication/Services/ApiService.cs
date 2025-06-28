using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mobile_deliveryapplication.API
{
    public static class ApiService
    {
        public static void GetDeliveryServices()
        {
            using (var client = new HttpClient())
            {
                var apiKey = "b9e7d970-8d82-4b56-92d8-d18fbb4b68a7";
                var endpoint = new Uri("http://51.137.100.120:5000/api/DeliveryServices");

                // Voeg de ApiKey header toe
                client.DefaultRequestHeaders.Add("ApiKey", "b9e7d970 - 8d82 - 4b56 - 92d8 - d18fbb4b68a7");

                var result = client.GetAsync(endpoint).Result;

                if (result.IsSuccessStatusCode)
                {
                    var json = result.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(json);
                }
                else
                {
                    var error = result.Content.ReadAsStringAsync().Result;
                    Console.WriteLine($"Fout: {result.StatusCode}");
                    Console.WriteLine($"API foutmelding: {error}");
                }
            }
        }
    }
}
