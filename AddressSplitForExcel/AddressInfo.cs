using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressSplitForExcel
{
     public class AddressInfo
    {
        public int RowNum { set; get; }

        public string AddrFull { set; get; }

        public string AddrPro { set; get; }

        public string AddrCity { set; get; }

        public string AddrArea { set; get; }

        public string AddrOther { set; get; }
    }
}
