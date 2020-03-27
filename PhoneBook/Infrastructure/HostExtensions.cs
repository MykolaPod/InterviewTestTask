using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure
{
    public static class HostExtensions
    {
        public static IHost MigrateDbContext<TContext>(this IHost webHost, Action<TContext, IServiceProvider> seeder = default) where TContext : DbContext
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<TContext>();
                try
                {
                    context.Database.EnsureDeleted();
                    context.Database.Migrate();
                    if (seeder != default)
                    {
                        seeder(context, services);
                    }
                    
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return webHost;
        }
    }
}