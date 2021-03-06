using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CoreWebApiServices.Helpers
{
    public class Utility : IUtility
    {
        private readonly IConfiguration _config;
        public Utility(IConfiguration config)
        {
            _config = config;
        }

        //產生整數陣列,依傳入參數num決定產生多少個陣列元素
        public int[] GetNumbers(int num)
        {
            int[] Nums = new int[num];
            Random rdn = new Random(Guid.NewGuid().GetHashCode());
            //Array.Clear(Nums, 0, 12);
            for (int i = 0; i < num; i++)
            {
                Nums[i] = rdn.Next(1, 500);
            }

            //或可簡化成一行
            var array = Enumerable.Range(1, num).Select(x => rdn.Next(1, 500)).ToArray();

            rdn = null;
            return array;
        }
    }
}
