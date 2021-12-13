using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using CoreMvc3_ConfigOptions.ViewModels;
using CoreMvc3_ConfigOptions.Interface;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using CoreMvc3_ConfigOptions.Options;

namespace CoreMvc3_ConfigOptions.Controllers
{

    public class BindController : Controller
    {
        private readonly IConfiguration _config;

        public BindController(IConfiguration config)
        {
            _config = config;
        }

        //將組態資料繫結至類別
        public IActionResult BindToClass()
        {
            //1.使用Bind方法繫結
            var deviceVM = new DeviceViewModel();
            _config.GetSection("MobileOptions").Bind(deviceVM);

            //2.使用Get<T>()方法繫結
            var device = _config.GetSection("MobileOptions").Get<DeviceViewModel>();

            return View("SelectedDevice", deviceVM);
        }

        //將組態資料繫結至Object Graph
        public IActionResult BindToObjectGraph()
        {
            //1.使用Bind方法繫結
            var AICorpVM = new AICorpViewModel();
            _config.GetSection("AICorp").Bind(AICorpVM);

            //2.使用Get<T>()方法繫結
            var aiCorp = _config.GetSection("AICorp").Get<AICorpViewModel>();

            //將Object Graph物件序列化成JSON字串, 交予前端顯示
           ViewData["jsonAICorp"] = JsonConvert.SerializeObject(aiCorp);

            return View(aiCorp);
        }

        //將組態繫結至類別的陣列屬性
        public IActionResult BindToArray()
        {
            var arrayEmps = new EmployeeViewModel();

            //1.使用Bind方法繫結
            _config.GetSection("Asia").Bind(arrayEmps);

            //2.使用Get<T>()方法繫結
            var arrayEmployees = _config.GetSection("Asia").Get<EmployeeViewModel>();

            return View(arrayEmps);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}