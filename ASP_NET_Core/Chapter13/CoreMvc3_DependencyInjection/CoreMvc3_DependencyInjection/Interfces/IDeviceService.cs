using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMvc3_DependencyInjection.Interfces
{
    public interface IDeviceService 
    {
        string DeviceType { get; }
        string ChooseCaption { get; }
        List<string> GetDramList();
        List<string> GetCpuList();
        List<string> GetGpuList();
        List<string> GetSsdList();
    }
}
