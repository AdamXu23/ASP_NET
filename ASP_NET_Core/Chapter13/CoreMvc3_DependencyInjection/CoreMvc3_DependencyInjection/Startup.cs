using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using CoreMvc3_DependencyInjection.Interfces;
using CoreMvc3_DependencyInjection.Services;
using CoreMvc3_DependencyInjection.Options;
using CoreMvc3_DependencyInjection.Helpers;

namespace CoreMvc3_DependencyInjection
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //將網銀服務註冊到DI Container
            services.AddTransient<IBankService, FubonBankService>();
            //services.AddTransient<IBankService, EsunBankService>();

            //IZipcodeService
            services.AddSingleton<IZipcodeService, TaiwanZipcodeService>();
            services.AddSingleton<IZipcodeService>(sp => new TaiwanZipcodeService());

            //ICityService
            services.AddSingleton<ICityService, TaiwanCityService>();

            //IDeviceService
            services.AddTransient<IDeviceService, ComputerService>();
            //services.AddSingleton<IDeviceService, MobileService>();

            //Overriding Services
            services.AddScoped<MyHtmlHelper>();
            

            //Options Pattern
            services.Configure<DeviceOptions>(options => Configuration.GetSection("MobileOptions").Bind(options));
            
            services.Configure<FoodOptions>(options => Configuration.GetSection("FoodOptions").Bind(options));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
