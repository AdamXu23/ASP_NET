using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoreMvc3_Pillars.Controllers
{
    public class ErrorHandlerController : Controller
    {
        public IActionResult ErrorMessage()
        {
            if (!TempData.ContainsKey("ErrorMessage"))
            {
                return new EmptyResult();
            }

            //TempData.Keep();  //保留全部Key
            TempData.Keep("ErrorMessage");    //保留指定Key

            return View();
        }
    }
}