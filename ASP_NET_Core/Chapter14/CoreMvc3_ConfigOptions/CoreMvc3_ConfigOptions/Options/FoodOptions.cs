﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMvc3_ConfigOptions.Options
{
    public class FoodOptions
    {
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
