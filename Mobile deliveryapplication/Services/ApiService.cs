using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_deliveryapplication.API
{
    public static class ApiService
    {
        
            static void Main(string[] args)
            {
                using (var client = new HttpClient())
                {
                    var apiKey = "b9e7d970-8d82-4b56-92d8-d18fbb4b68a7";
                    var endpoint = new Uri($"http://51.137.100.120:5000/api/DeliveryServices/{apiKey}");

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
    }
}

