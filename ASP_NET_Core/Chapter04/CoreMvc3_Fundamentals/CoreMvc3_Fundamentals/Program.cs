using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.AzureAppServices;
using System.IO;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace CoreMvc3_Fundamentals
{
    public class Program
    {
        public static Dictionary<string, string> dictEmployees { get; } = new Dictionary<string, string>
        {
                {"Asia:employees:1", "Mary"},
                {"Asia:employees:2", "John"},
                {"Asia:employees:3", "Kevin"},
                {"Asia:employees:4", "David"},
                {"Asia:employees:5", "Rose"}
        };

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                //.UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureHostConfiguration(configHost =>
                {
                    //設定基底路徑
                    configHost.SetBasePath(Directory.GetCurrentDirectory());

                    //configHost有Properties和Sources兩個屬性,前者是Key(FileProvide)及Value(PhysicalFileProvide),後者是Providers提供者資訊
                    //如想看見SetBasePath()設定後路徑,可用下面程式抓取
                    string contentRoot = ((Microsoft.Extensions.FileProviders.PhysicalFileProvider)configHost.Properties.Values.FirstOrDefault()).Root;

                    configHost.AddJsonFile("hostsettings.json", optional: true);
                    configHost.AddEnvironmentVariables(prefix: "PREFIX_");
                    configHost.AddCommandLine(args);

                })
                .ConfigureAppConfiguration((hostingContext, configApp) =>
                {
                    //configApp.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"), true, true);

                    //設定組能檔完整路徑
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "ConfigFiles");
                    configApp.AddJsonFile(Path.Combine(path, "FutureCorp.json"), optional: true, reloadOnChange: true);  //載入自訂JSON組態檔
                    configApp.AddIniFile(Path.Combine(path, "Mobile.ini"), true, true);      //載入自訂INI組態檔
                    configApp.AddXmlFile(Path.Combine(path, "Computer.xml"), true, true);    //載入自訂XML組態檔
                    configApp.AddJsonFile(Path.Combine(path, "Device.json"), true, true);   //載入自訂JSON組態檔

                    path = Path.Combine(Directory.GetCurrentDirectory(), "Configuration");
                    configApp.AddJsonFile(Path.Combine(path, "Food.json"), true, true);
                    configApp.AddInMemoryCollection(dictEmployees);
                })
                .ConfigureLogging(loggingBuilder =>
                {
                    loggingBuilder.ClearProviders();
                    loggingBuilder.AddConsole();
                    loggingBuilder.AddDebug();
                    loggingBuilder.AddEventSourceLogger();
                    loggingBuilder.AddEventLog();
                    loggingBuilder.AddTraceSource(new SourceSwitch("loggingSwitch", "Verbose"), new TextWriterTraceListener("LoggingService.txt"));
                    loggingBuilder.AddAzureWebAppDiagnostics();
                    loggingBuilder.AddApplicationInsights();
                })
                .ConfigureLogging(logging => logging.AddAzureWebAppDiagnostics())
                    .ConfigureServices(serviceCollection => serviceCollection
                        .Configure<AzureFileLoggerOptions>(options =>
                        {
                            options.FileName = "azure-diagnostics-";
                            options.FileSizeLimit = 50 * 1024;
                            options.RetainedFileCountLimit = 5;
                        }).Configure<AzureBlobLoggerOptions>(options =>
                        {
                            options.BlobName = "log.txt";
                        })
                    )
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseWebRoot(Directory.GetCurrentDirectory() + "/publicshare/");
                });
        /*
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                //.UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureLogging(loggingBuilder => {
                    loggingBuilder.ClearProviders();
                    loggingBuilder.AddConsole();
                    loggingBuilder.AddDebug();
                    loggingBuilder.AddEventSourceLogger();
                    loggingBuilder.AddEventLog();
                    loggingBuilder.AddTraceSource(new SourceSwitch("loggingSwitch","Verbose"), new TextWriterTraceListener("LoggingService.txt"));
                    loggingBuilder.AddAzureWebAppDiagnostics();
                    loggingBuilder.AddApplicationInsights();
                })
                .ConfigureLogging(logging => logging.AddAzureWebAppDiagnostics())
                    .ConfigureServices(serviceCollection => serviceCollection
                        .Configure<AzureFileLoggerOptions>(options =>
                        {
                            options.FileName = "azure-diagnostics-";
                            options.FileSizeLimit = 50 * 1024;
                            options.RetainedFileCountLimit = 5;
                        }).Configure<AzureBlobLoggerOptions>(options =>
                        {
                            options.BlobName = "log.txt";
                        })
                    )
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    //webBuilder.UseWebRoot(Directory.GetCurrentDirectory() + "/publicshare/");
                });
           */
    }
}
