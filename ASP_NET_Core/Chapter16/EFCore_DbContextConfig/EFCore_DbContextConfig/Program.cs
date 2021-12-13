using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using EFCore_DbContextConfig.Models;
using System.Reflection;

namespace EFCore_DbContextConfig
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();

            var host = CreateHostBuilder(args).Build();

            //透過IServiceProvider解析相依性
            /*
            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                try
                {
                    var cardContext = services.GetRequiredService<CardContext>();
                    var config = services.GetService<IConfiguration>();
                    var _config = services.GetRequiredService<IConfiguration>();

                    string conn = _config.GetConnectionString("CardSqlServerDB");
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred.");
                }
            }
            */

            host.Run();
        }

        /*
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        */

        
        public static IHostBuilder CreateHostBuilder(string[] args)
        { 

            var assemblyName = typeof(Startup).GetTypeInfo().Assembly.FullName;

            return Host.CreateDefaultBuilder(args)
                       .ConfigureWebHostDefaults(webBuilder =>
                        {
                          webBuilder.UseStartup(assemblyName);
                        });
        }
        
    }
}
