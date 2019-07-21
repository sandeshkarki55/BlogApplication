using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.ApplicationInsights;
using System.Threading.Tasks;

namespace MyBlog.API
{
#pragma warning disable CS1591
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseApplicationInsights()
                .UseStartup<Startup>()
            .ConfigureLogging(builder =>
            {
                builder.AddApplicationInsights();
                builder.AddFilter<ApplicationInsightsLoggerProvider>("", LogLevel.Information);
            });
    }
#pragma warning restore CS1591
}
