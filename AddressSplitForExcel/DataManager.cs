using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AddressSplitForExcel.Entity;
using AddressSplitForExcel.Extension;

namespace AddressSplitForExcel
{
    public class DataManager
    {
        public bool SaveSender(SenderInfo sender)
        {
            return true;
        }

        public List<SenderInfo> GetSenders()
        {
            List<SenderInfo> list = new List<SenderInfo>();
            string jsonstr = ConfigHelper.GetLocalSenderJson();
            if (!string.IsNullOrWhiteSpace(jsonstr))
            {
                list = JsonConvert.DeserializeObject<List<SenderInfo>>(jsonstr);
            }

            return list;
        }

        public void SaveSenders(List<SenderInfo> list)
        {
            string senderstr = JsonConvert.SerializeObject(list);

            ConfigHelper.SaveSenderJsonStringToLocal(senderstr);
        }
    }
}
