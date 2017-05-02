using System;
using System.Net.Http;
using System.Threading.Tasks;
using HelloWorldModels;
using Newtonsoft.Json;

namespace HelloWorldConsole
{
    class Program
    {

        static void Main(string[] args)
        {
            var startup = new Startup();
            var baseUrl = startup.Configuration["HelloWorldSource:URL"] ?? @"http://localhost:60671";
            var controllerPath = startup.Configuration["HelloWorldSource:HelloWorld"] ?? @"api/WorldMessage";
            var uri = new Uri(new Uri(baseUrl), controllerPath);
            int delay;
            int.TryParse(startup.Configuration["Delay"] ?? "2000", out delay);

            Task.Delay(2000);
            // Initialize and call an HttpClient to get the "Hello World!" message
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(uri);
                response.Wait();
                if (response.Result.IsSuccessStatusCode)
                {
                    var result = response.Result.Content.ReadAsStringAsync()?.Result;
                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        var message = JsonConvert.DeserializeObject<HelloWorldMessage>(result);
                        Console.WriteLine(message.Message);
                    }
                }
            }

            Console.ReadKey();
        }
    }
}