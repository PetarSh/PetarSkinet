using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Structura.Data;
using Microsoft.EntityFrameworkCore;

namespace Structura
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host=CreateHostBuilder(args).Build();
            using(var scope=host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactoy = services.GetRequiredService<ILoggerFactory>();

                try
                {
                    var context = services.GetRequiredService<StoreContext>();
                    await context.Database.MigrateAsync();
                    await StoreContextSeed.SeedAsync(context,loggerFactoy);
                }
                catch(Exception ex)
                {
                    var logger = loggerFactoy.CreateLogger<Program>();
                    logger.LogError(ex,"Greska pri migracija");
                }
            }
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
