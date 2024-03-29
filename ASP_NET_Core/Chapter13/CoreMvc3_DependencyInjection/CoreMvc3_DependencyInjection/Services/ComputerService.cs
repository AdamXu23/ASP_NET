﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreMvc3_DependencyInjection.Interfces;

namespace CoreMvc3_DependencyInjection.Services
{
    public class ComputerService : IDeviceService
    {
        public string DeviceType { get; } = "Computer";
        public string ChooseCaption { get; } = "請選擇Computer電腦配備";

        public List<string> GetDramList()
        {
            return new List<string> { "4GB", "8GB", "16GB", "32GB" };
        }
        public List<string> GetCpuList()
        {
            return new List<string> { "INTEL", "AMD" };
        }
        
        public List<string> GetGpuList()
        {
            return new List<string> { "NVIDIA", "AMD" };
        }

        public List<string> GetSsdList()
        {
            return new List<string> { "三星", "INETL", "Micron" };
        }
    }
}
