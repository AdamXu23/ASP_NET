using Microsoft.AspNetCore.Mvc;

namespace Fundamentals_TEST_2022.Controllers
{
    public class FundamentalsController : Controller
    {
        //private readonly IHostingEnvironment _env;
        private readonly IWebHostEnvironment _env;

        public FundamentalsController(IWebHostEnvironment env)
        {
            _env = env;
        }

        //顯示環境名稱
        public IActionResult EnvironmentName()
        {
            ViewData["EnvName"] = _env.EnvironmentName;
            return View();
        }

        //在View中注入IHostEnvironment
        public IActionResult InjectEnvironment()
        {
            return View();
        }

        //Environment結合Environment Tag Helper
        public IActionResult EnvironmentTagHelper()
        {
            return View();
        }

        //讀取appsettings.json組態設定值
        public IActionResult ReadAppsettings()
        {
            return View();
        }

        //存取DeveloperOptions
        public IActionResult AccessDeveloperOptions()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
