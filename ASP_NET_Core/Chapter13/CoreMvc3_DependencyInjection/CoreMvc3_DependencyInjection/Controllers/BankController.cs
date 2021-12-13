using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreMvc3_DependencyInjection.Interfces;

namespace CoreMvc3_DependencyInjection.Controllers
{
    public class BankController : Controller
    {
        private readonly IBankService _bankService;

        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Balance()
        {
            return View(_bankService);
        }

        public IActionResult InjectAction([FromServices] IBankService myBankService)
        {
            return View(myBankService);
        }

        //Inject in View
        public IActionResult InjectView()
        {
            return View();
        }
    }
}