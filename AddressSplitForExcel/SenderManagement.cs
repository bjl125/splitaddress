using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AddressSplitForExcel.Entity;

namespace AddressSplitForExcel
{
    public partial class SenderManagement : Form
    {
        public SenderManagement()
        {
            InitializeComponent();
            try
            {
                var dbe = new SQLiteDbContext();


                using (var db = new SQLiteContext())
                {
                    var senders = db.SenderAddressInfo.Where(s => s.ID == 1);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
