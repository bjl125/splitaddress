using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressSplitForExcel
{
    public static class AddressHelper
    {
        public static AddressInfo GetSplitAddress(string addr, List<AreaInfo> provs, List<AreaInfo> citys, List<AreaInfo> regions)
        {
            AddressInfo adinfo = new AddressInfo();
            string otherAddr = string.Empty;
            string prov = GetProvince(addr, out otherAddr, provs);
            string city = string.Empty;

            adinfo.AddrPro = prov;

            if (prov.StartsWith("北京") ||
                        prov.StartsWith("上海") ||
                        prov.StartsWith("天津") ||
                        prov.StartsWith("重庆"))
            {
                city = prov.IndexOf("市", 0) > 0 ? prov : prov + "市";
            }
            else
            {
                city = GetCity(otherAddr, out otherAddr, citys);
            }
            adinfo.AddrCity = city;
            adinfo.AddrOther = otherAddr;
            return adinfo;
        }
        public static string GetCity(string add, out string otheradd, List<AreaInfo> citys)
        {
            string city = string.Empty;
            if (!String.IsNullOrEmpty(add))
            {
                if (add.IndexOf("自治州") > 0 && add.IndexOf("自治州") < 9)
                {
                    city = add.Substring(0, add.IndexOf("自治州", 0) + 3);
                }
                else if (add.IndexOf("地区")>0 && add.IndexOf("地区")<=4)
                {
                    city = add.Substring(0, add.IndexOf("地区", 0) + 2);
                }
                else if(add.IndexOf("市",0)>0 && add.IndexOf("市", 0) < 5)
                {
                    city = add.Substring(0, add.IndexOf("市", 0) + 1);
                }
                else if (add.IndexOf("盟", 0) > 0 && add.IndexOf("盟", 0) < 5)
                {
                    city = add.Substring(0, add.IndexOf("盟", 0) + 1);
                }
                //else if (add.IndexOf("县", 0) > 0 && add.IndexOf("县", 0) < 5)
                //{
                //    city = add.Substring(0, add.IndexOf("县", 0) + 1);
                //}
                else
                {
                    foreach(var c in citys)
                    {
                        if (add.StartsWith(c.AreaFirstName))
                            city = c.AreaFirstName;
                    }
                }
                if (!String.IsNullOrWhiteSpace(city))
                {
                    otheradd = add.Substring(city.Length, add.Length - city.Length);
                    return city;

                }
                else
                {
                    otheradd = add;
                    return city;
                }
            }
            else
            {
                otheradd = "";
                return city;
            }
        }
        public static string GetProvince(string add, out string otheradd, List<AreaInfo> proviences)
        {
            string prov = string.Empty;
            if (!String.IsNullOrEmpty(add))
            {
                if (add.IndexOf("省", 0) > 0)
                {
                    prov = add.Substring(0, add.IndexOf("省", 0) + 1);
                }
                else if (add.IndexOf("市", 0) > 0 && add.IndexOf("市", 0) < 4)
                {
                    if (add.StartsWith("北京") ||
                        add.StartsWith("上海") ||
                        add.StartsWith("天津") ||
                        add.StartsWith("重庆"))
                    {
                        prov = add.Substring(0, add.IndexOf("市", 0) + 1);
                    }
                }
                else if (add.IndexOf("自治区", 0) > 0 && add.IndexOf("自治区", 0) < 6)
                {
                    prov = add.Substring(0, add.IndexOf("自治区", 0) + 3);
                }
                else
                {
                    foreach (var p in proviences)
                    {
                        if (add.StartsWith(p.AreaFirstName))
                            prov = p.AreaFirstName;
                        else
                        {
                            foreach (var shortname in p.AreaShortName)
                            {
                                if (add.StartsWith(shortname))
                                {
                                    prov = shortname;
                                    break;
                                }
                            }

                        }
                    }
                }

                if (!String.IsNullOrWhiteSpace(prov))
                {
                    otheradd = add.Substring(prov.Length, add.Length - prov.Length);
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
