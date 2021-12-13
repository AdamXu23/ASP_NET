using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMvc3_DependencyInjection.Services
{
    public class EnumZipcodeService
    {
        public enum Taipei
        {
            中正區 = 100, 大同區 = 103, 中山區 = 104, 松山區 = 105, 大安區 = 106,
            萬華區 = 108, 信義區 = 110, 士林區 = 111, 北投區 = 112, 內湖區 = 114, 南港區 = 115,
            文山區 = 116
        };
        public enum Taoyuan
        {
            中壢區 = 320, 平鎮區 = 324, 龍潭區 = 325, 楊梅區 = 326, 新屋區 = 327,
            觀音區 = 328, 桃園區 = 330, 龜山區 = 333, 八德區 = 334, 大溪區 = 335, 復興區 = 336,
            大園區 = 337, 蘆竹區 = 338
        };
    }
}
