using System.IO;
using Microsoft.Extensions.Configuration;

namespace HelloWorldConsole
{
    internal class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json");

            Configuration = builder.Build();
        }
    }
}
