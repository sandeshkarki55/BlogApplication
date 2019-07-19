using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;

namespace MyBlog.API
{
#pragma warning disable CS1591
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateWebHostBuilder(args).Build().RunAsync();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
#pragma warning restore CS1591
}
