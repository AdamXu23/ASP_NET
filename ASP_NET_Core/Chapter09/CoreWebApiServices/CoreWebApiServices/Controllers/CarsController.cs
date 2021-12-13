using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreWebApiServices.Models;
using CoreWebApiServices.Helpers;
using Microsoft.AspNetCore.Cors;

namespace CoreWebApiServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("CorsPolicy")]
    //[DisableCors]
    public class CarsController : ControllerBase
    {
        private readonly List<CarSales> CarSalesNumber;

        public CarsController(IUtility utility)
        {
            CarSalesNumber = new List<CarSales>
            {
                new CarSales { Id = 1, Car = "BMW", Salesdata = utility.GetNumbers(12) },
                new CarSales { Id = 2, Car = "BENZ", Salesdata = utility.GetNumbers(12) },
                new CarSales { Id = 3, Car = "Audi", Salesdata = utility.GetNumbers(12) }
            };
        }

        //URL Pattern : GET : api/cars
        [HttpGet]
        public IEnumerable<CarSales> GetCarSalesData()
        {
            return CarSalesNumber.Where(x => x.Id == 1 || x.Id == 2);
        }

        //URL Pattern : POST : api/cars
        [HttpPost]
        //[DisableCors]
        public IEnumerable<CarSales> GetCarSalesData2()
        {
            return CarSalesNumber.Where(x => x.Id == 2 || x.Id == 3);
        }

        //url pattern : api/cars/1 or api/cars/2
        [HttpGet("{id}"), HttpPost("{id}")]
        public IActionResult GetCarSalesData(int id)
        {
            var car = CarSalesNumber.FirstOrDefault(c => c.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }
    }
}