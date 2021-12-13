using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using CoreMvc3_Pillars.Models;

namespace CoreMvc3_Pillars
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

            //services.AddControllersWithViews().AddSessionStateTempDataProvider();
            //services.AddSession();
            

            services.AddDbContext<FriendContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("FriendContext")));
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

            //app.UseSession();

            #region Use()
            /*
            app.Use(next => context =>
            {
                var endpoint = context.GetEndpoint();
                if (endpoint is null)
                {
                    return Task.CompletedTask;
                }

                Console.WriteLine($"1.Endpoint端點: {endpoint.DisplayName}");

                if (endpoint is RouteEndpoint routeEndpoint)
                {
                    Console.WriteLine("2.Endpoint端點 has route pattern: " +
                        routeEndpoint.RoutePattern.RawText);
                }

                foreach (var metadata in endpoint.Metadata)
                {
                    Console.WriteLine($"3.Endpoint端點 has metadata: {metadata}");
                }

                //return Task.CompletedTask;
                return next(context);
            });
            */
            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "blog",
                    pattern: "Blogs/{controller=Blog}/{action=ReadArticle}");
            });

            #region snippet_RouteHandler
            var trackPackageRouteHandler = new RouteHandler(context =>
            {
                var routeValues = context.GetRouteData().Values;
                return context.Response.WriteAsync(
                    $"Hello! Route values: {string.Join(", ", routeValues)}");
            });

            var routeBuilder = new RouteBuilder(app, trackPackageRouteHandler);

            routeBuilder.MapRoute(
                "Track Package Route",
                "package/{operation:regex(^track|create$)}/{id:int}");

            routeBuilder.MapGet("hello/{name}", context =>
            {
                var name = context.GetRouteValue("name");
                // The route handler when HTTP GET "hello/<anything>" matches
                // To match HTTP GET "hello/<anything>/<anything>, 
                // use routeBuilder.MapGet("hello/{*name}"
                return context.Response.WriteAsync($"Hi, {name}!");
            });

            var routes = routeBuilder.Build();
            app.UseRouter(routes);
            #endregion

            #region snippet_Dictionary
            app.Run(async (context) =>
            {
                var dictionary = new RouteValueDictionary
                {
                    { "operation", "create" },
                    { "id", 123}
                };

                var vpc = new VirtualPathContext(context, null, dictionary,
                    "Track Package Route");
                var path = routes.GetVirtualPath(vpc).VirtualPath;

                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync("Menu<hr/>");
                await context.Response.WriteAsync(
                    $"<a href='{path}'>Create Package 123</a><br/>");
            });
            #endregion

        }
    }
}
