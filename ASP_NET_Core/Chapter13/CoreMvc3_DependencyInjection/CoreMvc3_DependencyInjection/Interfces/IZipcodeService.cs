using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreMvc3_DependencyInjection.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreMvc3_DependencyInjection.Interfces
{
    public interface IZipcodeService
    {
        string Caption { get; }
        List<ZipcodeViewModel> Cities { get; set; }
        string QueryZipcode(string cityName, string districtName);
    }
}
