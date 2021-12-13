using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreMvc3_DependencyInjection.Interfces;
using CoreMvc3_DependencyInjection.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreMvc3_DependencyInjection.Services
{
    public class TaiwanCityService : ICityService
    {
        public string ChooseCaption { get; } = "請選擇縣市";

        public List<CityViewModel> Cities { get; set; }

        public TaiwanCityService()
        {
            Cities = new List<CityViewModel>
            {
                new CityViewModel { CityId="01", CityName="基隆市" },
                new CityViewModel { CityId="02", CityName="臺北市" },
                new CityViewModel { CityId="03", CityName="新北市" },
                new CityViewModel { CityId="04", CityName="桃園市" },
                new CityViewModel { CityId="05", CityName="新竹市" },
                new CityViewModel { CityId="06", CityName="新竹縣" },
                new CityViewModel { CityId="07", CityName="苗栗縣" },
                new CityViewModel { CityId="08", CityName="台中市" },
                new CityViewModel { CityId="09", CityName="彰化縣" },
                new CityViewModel { CityId="10", CityName="南投縣" },
                new CityViewModel { CityId="11", CityName="雲林縣" },
                new CityViewModel { CityId="12", CityName="嘉義市" },
                new CityViewModel { CityId="13", CityName="嘉義縣" },
                new CityViewModel { CityId="14", CityName="臺南市" },
                new CityViewModel { CityId="15", CityName="高雄市" },
                new CityViewModel { CityId="16", CityName="屏東縣" },
                new CityViewModel { CityId="17", CityName="台東縣" },
                new CityViewModel { CityId="18", CityName="花蓮縣" },
                new CityViewModel { CityId="19", CityName="宜蘭縣" },
                new CityViewModel { CityId="20", CityName="澎湖縣" },
                new CityViewModel { CityId="21", CityName="金門縣" },
                new CityViewModel { CityId="22", CityName="連江縣" }
            };
        }

        public List<string> GetCityNames()
        {
            List<string> cityNames = Cities.Select(c => c.CityName).ToList<string>();
            
            return cityNames;
        }

        public List<SelectListItem> GetCitySelectListIem()
        {
            List<SelectListItem> cityItem = Cities.Select(c => new SelectListItem { Text = c.CityName, Value = c.CityId }).ToList();

            return cityItem;
        }
    }
}
