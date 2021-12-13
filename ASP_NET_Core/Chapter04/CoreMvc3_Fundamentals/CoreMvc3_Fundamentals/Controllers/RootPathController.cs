using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;

namespace CoreMvc3_Fundamentals.Controllers
{
    public class RootPathController : Controller
    {
        private readonly IWebHostEnvironment _env;
        public RootPathController(IWebHostEnvironment env)
        {
            _env = env;
        }

        //Content Root Path
        public IActionResult ContentRootPath()
        {
            ViewData["ContentRootPath"] = _env.ContentRootPath;
            return View();
        }

        //Web Root Path
        public IActionResult WebRootPath()
        {
            ViewData["WebRootPath"] = _env.WebRootPath;

            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}