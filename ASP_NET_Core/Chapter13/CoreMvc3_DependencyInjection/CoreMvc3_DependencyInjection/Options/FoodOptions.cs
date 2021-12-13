using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMvc3_DependencyInjection.Options
{
    //https://www.hopenglish.com/tims-place-where-breakfast-lunch-and-hugs-are-served-2
    public class FoodOptions
    {
        public FoodOptions()
        {

        }

        //開胃菜/前菜
        public string Appetizer { get; set; }

        //Main course 主菜
        public string MainCourse { get; set; }

        //餐後點心
        public string Dessert { get; set; }

        //Beverage 飲料
        public string Beverage { get; set; }
    }
}
