using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressSplitForExcel
{
    public static class AddressHelper
    {
        public static string GetProvince(string add,out string otheradd)
        {
            string prov = string.Empty;
            if (!String.IsNullOrEmpty(add))
            {
                if (add.IndexOf("省", 0) > 0)
                {
                    prov = add.Substring(0, add.IndexOf("省", 0)+1);
                    otheradd = add.Substring(prov.Length , add.Length - prov.Length);
                    return prov;
                }
                else
                {
                    otheradd = add;
                    return prov;
                }
            }
            else
            {
                otheradd = "";
                return "";

            }
        }
    }
}
