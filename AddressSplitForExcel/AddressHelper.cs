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
            string region = string.Empty;

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
                var cityadd = GetCity(otherAddr, out otherAddr, provs, citys);
                city = cityadd.AddrCity;
                //若省为空，将城市的省赋值
                if (String.IsNullOrEmpty(prov))
                {
                    adinfo.AddrPro = cityadd.AddrPro;
                }
            }
            //拆分区
            //var regionInfo = GetRegion(otherAddr, out otherAddr, provs, citys, regions);

            adinfo.AddrCity = city;
            adinfo.AddrArea = region;
            adinfo.AddrOther = otherAddr;
            return adinfo;
        }

        public static AddressInfo GetRegion(string add, out string otheradd, List<AreaInfo> proviences, List<AreaInfo> citys, List<AreaInfo> regions)
        {
            string region = string.Empty;
            string parentcode = string.Empty;
            AddressInfo addrinfo = new AddressInfo();
            if (!String.IsNullOrEmpty(add))
            {
                if (add.IndexOf("自治县") > 0 && add.IndexOf("自治县") < 9)
                {
                    region = add.Substring(0, add.IndexOf("自治州", 0) + 3);
                }
                else if (add.IndexOf("自治旗") > 0 && add.IndexOf("自治旗") <= 7)
                {
                    region = add.Substring(0, add.IndexOf("地区", 0) + 2);
                }
                else if (add.IndexOf("市", 0) > 0 && add.IndexOf("市", 0) < 5)
                {
                    region = add.Substring(0, add.IndexOf("市", 0) + 1);
                }
                else if (add.IndexOf("区", 0) > 0 && add.IndexOf("区", 0) < 5)
                {                    
                    region = add.Substring(0, add.IndexOf("区", 0) + 1);
                    //排除小区
                    if (region.EndsWith("小区"))
                        region = string.Empty;
                }
                else if (add.IndexOf("旗", 0) > 0 && add.IndexOf("旗", 0) < 5)
                {
                    region = add.Substring(0, add.IndexOf("旗", 0) + 1);
                }
                else if (add.IndexOf("县", 0) > 0 && add.IndexOf("县", 0) < 5)
                {
                    region = add.Substring(0, add.IndexOf("县", 0) + 1);
                }
                
                //为空重新查找
                if(String.IsNullOrEmpty(region))
                {
                    var addrregion = (from r in regions
                                      where add.StartsWith(r.AreaFirstName)
                                      select r).FirstOrDefault() ;
                    
                    if(addrregion != null)
                    {
                        parentcode = addrregion.ParentCode;
                        region = addrregion.AreaFirstName;
                    }

                    //foreach (var r in regions)
                    //{
                    //    if (add.StartsWith(r.AreaFirstName))
                    //    {
                    //        parentcode = r.ParentCode;
                    //        region = r.AreaFirstName;
                    //        break;
                    //    }
                    //}
                }
                if (!String.IsNullOrWhiteSpace(region))
                {
                    //查找省市
                    if (!String.IsNullOrEmpty(parentcode))
                    {
                        var ad = (from c in citys
                                  from p in proviences
                                  where c.ParentCode == p.Code && c.Code == parentcode
                                  select new
                                  {
                                      provname = p.AreaFirstName + p.AreaLastName,
                                      cityname = c.AreaFirstName + c.AreaLastName
                                  }).FirstOrDefault();
                        if (ad != null)
                        {
                            addrinfo.AddrPro = ad.provname;
                            addrinfo.AddrCity = ad.cityname;
                        }
                    }
                    else
                    {
                        var ad = (from r in regions
                                  from c in citys
                                  from p in proviences
                                  where r.ParentCode == c.Code && c.ParentCode == p.Code && region.StartsWith(r.AreaFirstName)
                                  select new
                                  {
                                      provname = p.AreaFirstName + p.AreaLastName,
                                      cityname = c.AreaFirstName + c.AreaLastName
                                  }).FirstOrDefault();
                        if (ad != null)
                        {
                            addrinfo.AddrPro = ad.provname;
                            addrinfo.AddrCity = ad.cityname;
                        }

                    }
                    otheradd = add.Substring(region.Length, add.Length - region.Length);
                    addrinfo.AddrArea = region;
                    return addrinfo;

                }
                else
                {
                    otheradd = add;

                    return addrinfo;
                }
            }
            else
            {
                otheradd = "";
                return addrinfo;
            }
        }
        public static AddressInfo GetCity(string add, out string otheradd, List<AreaInfo> proviences, List<AreaInfo> citys)
        {
            string city = string.Empty;
            string parentcode = string.Empty;
            AddressInfo addrinfo = new AddressInfo();
            if (!String.IsNullOrEmpty(add))
            {
                if (add.IndexOf("自治州") > 0 && add.IndexOf("自治州") < 9)
                {
                    city = add.Substring(0, add.IndexOf("自治州", 0) + 3);
                }
                else if (add.IndexOf("地区") > 0 && add.IndexOf("地区") <= 4)
                {
                    city = add.Substring(0, add.IndexOf("地区", 0) + 2);
                }
                else if (add.IndexOf("市", 0) > 0 && add.IndexOf("市", 0) < 5)
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
                    foreach (var c in citys)
                    {
                        if (add.StartsWith(c.AreaFirstName))
                        {
                            parentcode = c.ParentCode;
                            city = c.AreaFirstName;
                            break;
                        }
                    }
                }
                if (!String.IsNullOrWhiteSpace(city))
                {
                    //查找省
                    if (!String.IsNullOrEmpty(parentcode))
                    {
                        var prov = proviences.Where(p => p.Code == parentcode).FirstOrDefault();
                        if (prov != null)
                        {
                            addrinfo.AddrPro = prov.AreaFirstName + prov.AreaLastName;
                        }
                    }
                    else
                    {
                        var prov = (from c in citys
                                    from p in proviences
                                    where c.ParentCode == p.Code && city.StartsWith(c.AreaFirstName)
                                    select p).FirstOrDefault();
                        if (prov != null)
                        {
                            addrinfo.AddrPro = prov.AreaFirstName + prov.AreaLastName;
                        }

                    }
                    otheradd = add.Substring(city.Length, add.Length - city.Length);
                    addrinfo.AddrCity = city;
                    return addrinfo;

                }
                else
                {
                    otheradd = add;

                    return addrinfo;
                }
            }
            else
            {
                otheradd = "";
                return addrinfo;
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
