using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressSplitForExcel
{
    public class RegionInfo
    {
        public string code { set; get; }

        public string region { set; get; }

        public List<RegionInfo> regionEntitys { set; get; }
    }
}
