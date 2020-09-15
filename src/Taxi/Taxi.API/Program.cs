using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Taxi.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseUrls("http://0.0.0.0:5000", "https://0.0.0.0:5001")
                        .UseStartup<Startup>();
                });
    }
}
