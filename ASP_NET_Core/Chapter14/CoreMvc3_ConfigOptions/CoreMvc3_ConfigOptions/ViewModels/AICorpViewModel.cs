using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMvc3_ConfigOptions.ViewModels
{
    public class AICorpViewModel
    {
        public string Website { get; set; }
        public List<Branch> Branches { get; set; }
    }

    public class Branch
    {
        public string Location { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
    }
}
