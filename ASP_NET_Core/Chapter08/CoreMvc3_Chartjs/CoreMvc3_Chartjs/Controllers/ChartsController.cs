using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreMvc3_Chartjs.Models;
using System.Text.Json;

namespace CoreMvc3_Chartjs.Controllers
{
    public class ChartsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //氣溫長條圖
        public IActionResult LineTemperature()
        {
            return View();
        }

        public IActionResult LineTemperatureData()
        {
            //1.Label
            string[] Months = { "1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月" };
            //以ViewBag將資料傳給View
            ViewBag.MonthsLabel = Months;

            //2.List集合包含台北,台中及高雄三個地方的氣溫資料
            List<Location> Locations = new List<Location>
            {
                new Location{
                    City="台北",
                    Temperature = new double[] { 16.1, 16.5, 18.5, 21.9, 25.2, 27.7, 29.6, 29.2, 27.4, 24.5, 21.5, 17.9 }
                },
                new Location{
                    City="台中",
                    Temperature = new double[] { 16.6, 17.3, 19.6, 23.1, 26.0, 27.6, 28.6, 28.3, 27.4, 25.2, 21.9, 18.1 }
                },
                new Location{
                    City="高雄",
                    Temperature = new double[] { 19.3, 20.3, 22.6, 25.4, 27.5, 28.5, 29.2, 28.7, 28.1, 26.7, 24.0, 20.6 }
                }
            };

            string jsonLocations = JsonSerializer.Serialize(Locations, null);

            /*使用JsonSerializerOptions選項設定
            var options = new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase, //The default is Pascal.
                WriteIndented = true
            };

            string jsonLocations = JsonSerializer.Serialize(Locations, options);
            */

            return View(Locations);
        }

        //Bar長條圖投票數統計
        public IActionResult BarTravel()
        {
            return View();
        }

        public IActionResult BarTravelData()
        {
            string[] countries = { "美國", "日本", "泰國", "琉球", "紐西蘭", "澳洲" };
            int[] votes = { 8, 22, 13, 15, 17, 21 };

            ViewBag.Countries = countries;
            ViewBag.Votes = votes;

            return View();
        }

        //車種雷達圖比較
        public IActionResult RadarCar()
        {
            return View();
        }

        public IActionResult RadarCarData()
        {
            string[] scopeLabels = { "新潮", "價格", "維修", "性能", "油耗", "配備" };
            int[] suvScores = { 90, 70, 80, 88, 50, 65 };
            int[] sedanScores = { 64, 82, 85, 76, 93, 58 };

            ViewBag.ScopeLabels = scopeLabels;
            ViewBag.SuvScores = suvScores;
            ViewBag.SedanScores = sedanScores;

            return View();
        }

        //圓餅圖
        public IActionResult PieSales()
        {
            return View();
        }

        public IActionResult PieSalesData()
        {
            string[] productLabels = { "3C電子", "食品", "服飾", "保養品", "鞋子", "家電" };
            double[] productData = { 39.1, 8.7, 15, 14, 8, 15.2 };
            string[] countryLabels = { "中國", "日本", "韓國", "越南", "泰國", "新加坡" };
            double[] countryData = { 45, 11, 14, 8, 10, 12 };

            ViewBag.ProductLabes = productLabels;
            ViewBag.ProductData = productData;
            ViewBag.CountryLabels = countryLabels;
            ViewBag.CountryData = countryData;

            return View();
        }

    }
}