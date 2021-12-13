using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFCore_DbContextConfig.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore;

namespace EFCore_DbContextConfig.Controllers
{
    public class CardsController : Controller
    {
        private readonly IConfiguration _config;
        private readonly CardContext _context;
        public CardsController(CardContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        //在DI Container註冊CardContext服務時,需用DBContextOptions指定Provider&資料庫連線,才能用此方式注入
        //使用Controller類別層DI注入的CardContext實例
        public async Task<IActionResult> CardListByDI()
        {
            List<Card> cards = await _context.Cards.AsNoTracking().ToListAsync();

            return View(cards);
        }

        public async Task<IActionResult> CardContextByIServiceProvider([FromServices] IServiceProvider sp)
        {
            var _context = sp.GetService<CardContext>();
            //var _context = sp.GetRequiredService<CardContext>();

            List<Card> cards = await _context.Cards.AsNoTracking().ToListAsync();

            return View(cards);
        }


        //在DI Container註冊CardContext服務時,不需用DBContextOptions指定Provider&資料庫連線
        //以DbContextOptionsBuilder建立選項,然後傳入到CardContext
        public async Task<IActionResult> CardListByOptionsBuilder()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CardContext>();
            //設定:1.SQL Server Provider , 2.資料庫連線
            optionsBuilder.UseSqlServer(_config.GetConnectionString("CardSqlServerDB"));

            List<Card> cards = new List<Card>();
            //將DbContextOptionsBuilder傳入到CardContext建構函式
            
            using (CardContext ctx = new CardContext(optionsBuilder.Options))
            {
                cards = await ctx.Cards.AsNoTracking().ToListAsync();
            }

            return View(cards);
        }

        //在DI Container註冊CardContext服務時,但不需用DbContextOptions指定Provider&資料庫連線,
        //而是在DbContext的OnConfiguring()方法中,用DbContextOptionsBuilder指定Provider&資料庫連線
        //透過[FromService]在方法層級注入CardContext實例
        public async Task<IActionResult> CardListByOnConfiguring([FromServices] CardContext ctx)
        {
            List<Card> cards = await ctx.Cards.AsNoTracking().ToListAsync();

            return View(cards);
        }

        //在DI Container註冊CardContext服務時,需用DBContextOptions指定Provider&資料庫連線,才能用此方式注入
        //透過[FromService]在方法層級注入IServiceProvider實例
        public IActionResult GetIConfigurationByIServiceProvider([FromServices]IServiceProvider sp)
        {
            var configuration = sp.GetService<IConfiguration>();

            string conn = configuration.GetConnectionString("CardSqlServerDB");

            return View();
        }

        //透過[FromService]在方法層級注入IServiceScope實例
        //在DI Container註冊CardContext服務時,需用DBContextOptions指定Provider&資料庫連線,才能用此方式注入
        public IActionResult GetIConfigurationByIServiceScope([FromServices] IServiceScope scope)
        {
            var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();

            string conn = config.GetConnectionString("CardSqlServerDB");

            return View();
        }
    }
}