using Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using PhoneBook.Data;
using PhoneBook.Data.SeedData;

namespace PhoneBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host =CreateHostBuilder(args).Build();
                
            host.MigrateDbContext<ApplicationDbContext>((ctx, services) =>
            {
                 new ApplicationDbContextSeed(ctx).SeedAsync().Wait();
            });
                
                host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
