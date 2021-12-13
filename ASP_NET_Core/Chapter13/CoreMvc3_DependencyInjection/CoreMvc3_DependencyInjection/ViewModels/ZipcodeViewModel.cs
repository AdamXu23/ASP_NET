using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMvc3_DependencyInjection.ViewModels
{
    public class ZipcodeViewModel
    {
        public string CityId { get; set; }
        public string CityName { get; set; }
        public List<District> Districts { get; set; }
    }

    public class District
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Zipcode { get; set; }
    }
}
