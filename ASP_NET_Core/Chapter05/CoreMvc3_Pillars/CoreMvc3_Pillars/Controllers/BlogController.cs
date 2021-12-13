using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoreMvc3_Pillars.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ReadArticle()
        {
            return View();
        }


        public string GetName()
        {
            return "Kevin";
        }

        public string GetName(int Id)
        {
            return $"{Id}'s name is Kevin";
        }

    }
}