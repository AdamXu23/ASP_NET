using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreMvc3_DependencyInjection.Interfces;
using Microsoft.Extensions.Logging;
using CoreMvc3_DependencyInjection.ViewModels;
using Microsoft.Extensions.Options;
using CoreMvc3_DependencyInjection.Options;

namespace CoreMvc3_DependencyInjection.Controllers
{
    public class ViewInjectionController : Controller
    {
        private readonly ILogger _logger;
        private readonly IDeviceService _deviceService;
        public ViewInjectionController(ILogger<ViewInjectionController> logger, IDeviceService deviceService)
        {
            _logger = logger;
            _deviceService = deviceService;
        }

        public IActionResult Index()
        {
            return View();
        }


        //Zip Code查詢
        public IActionResult InjectZipcodeService()
        {
            return View();
        }

        public IActionResult InjectCityService()
        {
            return View();
        }

        public IActionResult InjectConfiguration()
        {
            return View();
        }

        public IActionResult InjectDeviceData()
        {
            //直接初始化,並指定設定值
            /*
            SpecOptions selection = new SpecOptions
            {
                Ram = "16G",
                Cpu = "AMD",
                Gpu = "NVIDIA",
                Storage = "Micron"
            };
            */

            /*
            DeviceOptions specOptions = null;

            設定預設選項值
            switch (_deviceService.DeviceType)
            {
                case "Computer":
                    specOptions = new DeviceOptions { Ram = "16G", Cpu = "AMD", Gpu = "NVIDIA", Storage = "Micron" };
                    break;
                case "Mobile":
                    specOptions = new DeviceOptions { Ram = "8G", Cpu = "Qualcomm", Gpu = "KryoTM 360", Storage = "256GB" };
                    break;
            }
            */

            DeviceOptions deviceValues(string type) => 
            type switch
            {
                "Computer" => new DeviceOptions { Ram = "16G", Cpu = "AMD", Gpu = "NVIDIA", Storage = "Micron" },
                "Mobile" => new DeviceOptions { Ram = "8G", Cpu = "Qualcomm", Gpu = "KryoTM 360", Storage = "256GB" },
                _ => null
            };

            DeviceOptions specOptions = deviceValues(_deviceService.DeviceType);

            return View(specOptions);
        }

        public IActionResult InjectLogger()
        {
            _logger.LogDebug("在Action中做Logging記錄");
            return View();
        }
    }
}