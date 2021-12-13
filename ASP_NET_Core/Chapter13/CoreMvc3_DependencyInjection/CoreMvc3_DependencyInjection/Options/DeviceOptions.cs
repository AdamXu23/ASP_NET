using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMvc3_DependencyInjection.Options
{
    public class DeviceOptions
    {
        public string Ram { get; set; }
        public string Cpu { get; set; }
        public string Gpu { get; set; }
        public string Storage { get; set; }
    }
}
