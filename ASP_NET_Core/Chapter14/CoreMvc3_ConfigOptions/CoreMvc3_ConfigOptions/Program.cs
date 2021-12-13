using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CoreMvc3_ConfigOptions
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
                //.UseContentRoot("c:\\content-root")
                .ConfigureHostConfiguration(configHost=> {
                    //設定基底路徑
                    configHost.SetBasePath(Directory.GetCurrentDirectory());
                    //config.SetBasePath(Path.Combine(Directory.GetCurrentDirectory());

                    configHost.AddJsonFile("hostsettings.json", optional: true);
                    configHost.AddEnvironmentVariables(prefix: "PREFIX_");
                    configHost.AddCommandLine(args);

                    //configHost有Properties和Sources兩個屬性,前者是Key(FileProvide)及Value(PhysicalFileProvide),後者是Providers提供者資訊
                    //如果要看見SetBasePath()設定後路徑,可用下面程式抓取
                    //((Microsoft.Extensions.FileProviders.PhysicalFileProvider)configHost.Properties.Values.FirstOrDefault())
                })
                .ConfigureAppConfiguration((hostingContext, configApp) => 
                {
                    //Path.Combine方法設定appsettings.json檔完整路徑
                    configApp.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"), true, true);

                    //改變基底路徑設定
                    configApp.SetBasePath(Directory.GetCurrentDirectory() + "/ConfigFiles/");
                    configApp.AddJsonFile("FutureCorp.json", optional:true, reloadOnChange:true);  //載入自訂JSON組態檔
                    configApp.AddJsonFile("AICorp.json", optional: true, reloadOnChange: true);    //載入自訂JSON組態檔
                    configApp.AddIniFile("Mobile.ini", optional: true, reloadOnChange: true);      //載入自訂INI組態檔
                    configApp.AddXmlFile("Computer.xml", optional: true, reloadOnChange: true);    //載入自訂XML組態檔
                    configApp.AddJsonFile("Device.json", true, true);
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "Configuration");
                    configApp.AddJsonFile(Path.Combine(path, "Food.json"),true, true);
                    configApp.AddInMemoryCollection(dictEmployees);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    //webBuilder.UseWebRoot(@".\WebSite\wwwroot\");
                });
    }
}
