using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressSplitForExcel.Entity
{
    public partial class SenderInfo
    {
        public string ID { get; set; }
        public string Sender { get; set; }
        public string Mobile { get; set; }
        public string Provience { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Address { get; set; }
    }
}
