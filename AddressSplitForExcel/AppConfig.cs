using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressSplitForExcel
{
    public class AppConfig
    {
        public List<string> TempFields { set; get; }

        public List<string> DefaultSelectedFields { set; get; }
        public List<string> DefaultFileFields { set; get; }
    }
}
