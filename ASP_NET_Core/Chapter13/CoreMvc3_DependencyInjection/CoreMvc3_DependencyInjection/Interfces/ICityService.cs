using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using CoreMvc3_DependencyInjection.ViewModels;

namespace CoreMvc3_DependencyInjection.Interfces
{
    public interface ICityService
    {
        string ChooseCaption { get; }
        List<CityViewModel> Cities { get; set; }
        List<string> GetCityNames();
        List<SelectListItem> GetCitySelectListIem();
    }
}
