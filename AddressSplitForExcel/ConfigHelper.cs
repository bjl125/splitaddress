using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;

namespace AddressSplitForExcel
{
    public static class ConfigHelper
    {
        public static string GetJsonStringFromFile(string filename)
        {
            StreamReader sr = new StreamReader(filename, false);
            string configStr = sr.ReadToEnd();
            sr.Close();
            return configStr;
        }

        public static string GetLocalConfigJson()
        {

            string fullfilename = Application.StartupPath + "\\config.json";
            string configStr = GetJsonStringFromFile(fullfilename);
            return configStr;
        }

        public static void SaveJsonStringToFile(string filename, string json)
        {
            StreamWriter sw = new StreamWriter(filename, false);
            sw.WriteLine(json);
            sw.Close();

        }

        public static void SaveJsonStringToLocal(string json)
        {
            string filename = Application.StartupPath + "\\config.json";
            StreamWriter sw = new StreamWriter(filename, false);
            sw.WriteLine(json);
            sw.Close();

        }
        public static AppConfig GetAppConfig()
        {
            string configStr = GetLocalConfigJson();
            AppConfig config = JsonConvert.DeserializeObject<AppConfig>(configStr);

            return config;
        }

        public static void SaveConfigToFile(AppConfig config)
        {
            string configStr = JsonConvert.SerializeObject(config);
            SaveJsonStringToLocal(configStr);
        }
    }
}
