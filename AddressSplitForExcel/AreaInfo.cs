using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressSplitForExcel
{
    public class AreaInfo
    {
        public string Code { set; get; }

        public string ParentCode { set; get; }

        public string AreaLastName { set; get; }

        public string AreaFirstName { set; get; }

        public List<string> AreaShortName { set; get; }
    }
}
