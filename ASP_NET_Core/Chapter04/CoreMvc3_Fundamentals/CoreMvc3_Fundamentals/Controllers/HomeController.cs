using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoreMvc3_Fundamentals.Models;
using Microsoft.AspNetCore.Hosting;

namespace CoreMvc3_Fundamentals.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _env;
        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public IActionResult Index()
        {
            EventId eventId = new EventId(1234, "我的記錄資訊");
            _logger.LogTrace(eventId, "Logging - LogTrace()記錄資訊- Home/Index被呼叫");

            //以上亦可寫成以下一行
            _logger.LogDebug(1234, "Logging - LogDebug()記錄資訊- Home/Index被呼叫");

            _logger.LogWarning(1234, "Logging - LogWarning()記錄資訊- Home/Index被呼叫");

            return View();
        }

        public IActionResult LogMethods()
        {
            _logger.LogDebug(1234, "目前環境是:" + _env.EnvironmentName);
            _logger.LogCritical(1234, "用LogCritical方法記錄資訊");
            _logger.LogError(1234, "用LogError方法記錄資訊");
            _logger.LogWarning(1234, "用LogWarning方法記錄資訊");
            _logger.LogInformation(1234, "用LogInformation方法記錄資訊");
            _logger.LogDebug(1234, "用LogDebug方法記錄資訊");
            _logger.LogTrace(1234, "用LogTrace方法記錄資訊");

            return new EmptyResult();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
