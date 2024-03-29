﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CoreMvc3_ConfigOptions.Controllers
{
    public class ConfigController : Controller
    {
        //Configuration相依性注入設定
        private readonly IConfiguration _config;
        public ConfigController(IConfiguration config)
        {
            _config = config;
        }


        //在Controller讀取Configuration
        public IActionResult ReadConfig()
        {
            ViewData["Website"] = _config["Company:Website"];
            ViewData["Taipei_Name"] = _config["Company:Branches:Taipei:Name"];
            ViewData["Taipei_Tel"] = _config["Company:Branches:Taipei:Tel"];
 
            return View();
        }

        //在View直接注入IConfiguration相依性物件
        public IActionResult InjectConfigView()
        {
            return View();
        }

        //讀取FutureCorp.json組態檔的設定值
        public IActionResult ReadJsonConfig()
        {
            ViewData["Website"] = _config["FutureCorp:Website"];
            ViewData["USA_Name"] = _config["FutureCorp:Branches:USA:Name"];
            ViewData["USA_Tel"] = _config["FutureCorp:Branches:USA:Tel"];

            return View();
        }

        //讀取Mobile.ini組態檔的設定值
        public IActionResult ReadIniConfig()
        {
            ViewData["CPU_Name"] = _config["CPU:Name"];
            ViewData["CPU_Designer"] = _config["CPU:Designer"];
            ViewData["CPU_Manufacturer"] = _config["CPU:Manufacturer"];
            ViewData["iPhone11Pro_storage"] = _config["Spec:iPhone11Pro:storage"];

            return View();
        }

        //讀取Computer.xml組態檔的設定值
        public IActionResult ReadXmlConfig()
        {
            ViewData["CPU_Intel"] = _config["cpu:intel"];
            ViewData["CPU_AMD"] = _config["cpu:amd"];
            ViewData["DRAM_Kingston"] = _config["dram:kingston"];
            ViewData["SSD_Samsung"] = _config["ssd:samsung"];

            return View();
        }

        //用GetValue<T>方法讀取組態值
        public IActionResult GetValue()
        {
            ViewData["CPU_SPARC"] = _config["cpu:sparc"];
            ViewData["CPU_ARM"] = _config.GetValue<string>("cpu:arm", "找不到指定資料");
            
            return View();
        }

        //用GetSection()方法取得組態的sub-section
        public IActionResult GetSection()
        {
            var corp = _config.GetSection("FutureCorp");
            var website = _config.GetSection("FutureCorp:Website");
            var branches = _config.GetSection("FutureCorp:Branches");
            var usa = _config.GetSection("FutureCorp:Branches:USA");
            var usa_name = _config.GetSection("FutureCorp:Branches:USA:Name");

            var corp_children = corp.GetChildren();
            var website_children = website.GetChildren();
            var branches_children = branches.GetChildren();
            var usa_children = usa.GetChildren();
            var usa_name_children = usa_name.GetChildren();

            var corp_Enumerable = corp.AsEnumerable();
            var website_Enumerable = website.AsEnumerable();
            var branches_Enumerable = branches.AsEnumerable();
            var usa_Enumerable = usa.AsEnumerable();
            var usa_name_Enumerable = usa_name.AsEnumerable();

            return View();
        }

        public IActionResult ListConfig()
        {
            var branches_Enumerable = _config.GetSection("FutureCorp:Branches").AsEnumerable();
            var branches_List = _config.GetSection("FutureCorp:Branches").AsEnumerable().ToList();

            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}