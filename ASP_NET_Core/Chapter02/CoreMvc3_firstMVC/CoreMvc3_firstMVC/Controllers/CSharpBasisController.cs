using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreMvc3_firstMVC.Models;

namespace CoreMvc3_firstMVC.Controllers
{
    public class CSharpBasisController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ObjectInitializerwithNamedType()
        {
            //傳統物件建構語法
            Friend f = new Friend();
            f.Name = "Rose";
            f.Country = "USA";


            //以物件初始設定式建立具名型別物件
            Friend friend = new Friend { Name = "Rose", Country = "USA" };

            return View(friend);
        }

        public ActionResult ObjectInitializerAnonymousType()
        {
            //以物件初始設定式建立匿名型別物件
            var friend = new { Name = "Mary", Country = "Japan" };


            return View(friend);
        }


        public ActionResult CollectionInitializerswithNamedType()
        {
            //集合初始設定式
            List<Friend> friends = new List<Friend>
            {
                new Friend { Name = "Rose", Country = "USA" },
                new Friend { Name = "David", Country = "Japan" },
                new Friend { Name = "John", Country = "USA" },
                new Friend { Name = "Bob", Country = "Italy" },
                new Friend { Name = "Johnson", Country = "Thailand" },
                new Friend { Name = "Cindy", Country = "Japan" },
                new Friend { Name = "Lucy", Country = "Korea" },
                new Friend { Name = "Angel", Country = "Italy" },
                new Friend { Name = "Maya", Country = "Thailand" },
                new Friend { Name = "Max", Country = "Korea" }
            };

            //以LINQ查詢泛型集合
            var friendsQuery = from f in friends
                               where f.Country == "USA" || f.Country == "Korea"
                               select f;

            var queryList = friendsQuery.ToList();

            var Query = from f in friends
                        where f.Country == "USA" || f.Country == "Korea"
                        orderby f.Country, f.Name
                        select new { 姓名 = f.Name, 國家 = f.Country };

            return View(friendsQuery);
        }
    }
}