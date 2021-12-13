using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoreMvc3_Pillars.Models;
using Microsoft.AspNetCore.Http.Features;
using System.IO;

namespace CoreMvc3_Pillars.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            var endpoint = HttpContext.Features.Get<IEndpointFeature>()?.Endpoint;


            var value = HttpContext.Request.RouteValues;

            RouteContext routeContext = new RouteContext(HttpContext);

            var routeData = RoutingHttpContextExtensions.GetRouteData(this.HttpContext);
            
            return View();
        }

        [Route("My/Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ReadJsonFile()
        {
            string pathFile = Directory.GetCurrentDirectory() + "/wwwroot/json/person.json";
            string jsonPerson = System.IO.File.ReadAllText(pathFile);
            
            return View();
        }
    }
}
