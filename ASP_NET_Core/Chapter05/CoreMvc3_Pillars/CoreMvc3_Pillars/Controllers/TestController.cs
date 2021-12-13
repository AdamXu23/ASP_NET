using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoreMvc3_Pillars.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();

            //return View("Views/Home/Index.cshtml");
            //return View("Views/Results/Index.cshtml");

            //return View("~/Views/Home/Index.cshtml");
            //return View("~/Views/Results/Index.cshtml");
        }

        public IActionResult About()
        {
            return View();
        }

        public ViewResult ShowMessage()
        {
            //return View("Massage"); //指定錯誤的檢視名稱

            return View("Message");  //這是正確名稱
        }
    }
}