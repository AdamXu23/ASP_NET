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
    public class OptionsController : Controller
    {
        private readonly FoodOptions _foodOptions;
        private readonly DeviceOptions _deviceOptions;
        public OptionsController(IOptionsMonitor<FoodOptions> foodOptions, IOptionsMonitor<DeviceOptions> deviceOptions)
        {
            //Option使用前,必須在DI Container中註冊
            //利用Options Pattern從Configuration組態檔中讀入
            _foodOptions = foodOptions.CurrentValue;
            _deviceOptions = deviceOptions.CurrentValue;
        }

        public IActionResult FoodWithOptions()
        {
            return View(_foodOptions);
        }

        //Select Tag Helper with Options Pattern
        public IActionResult SelectDeviceOptions()
        {
            return View(_deviceOptions);
        }

        [HttpPost]
        public IActionResult SelectDeviceOptions(DeviceOptions deviceOptions)
        {
            return View("DeviceOptionsResult", deviceOptions);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}