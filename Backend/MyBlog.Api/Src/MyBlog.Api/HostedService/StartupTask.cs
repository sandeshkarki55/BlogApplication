using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using MyBlog.Application.Interfaces;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.API.HostedService
{
    public class StartupTask : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public StartupTask(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<IMyBlogDbContext>();
                await context.Database.MigrateAsync();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
