using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using MyBlog.Application.Interfaces;

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.API.HostedService
{
    public class StartupMigrationTask : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<StartupMigrationTask> _logger;

        public StartupMigrationTask(IServiceProvider serviceProvider, ILogger<StartupMigrationTask> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<IMyBlogDbContext>();
                    var remainingMigrations = await context.Database.GetPendingMigrationsAsync();
                    if (remainingMigrations.ToList().Count > 0)
                    {
                        _logger.LogWarning("Executing migrations.", remainingMigrations);
                        await context.Database.MigrateAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception while migrating database.");
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
