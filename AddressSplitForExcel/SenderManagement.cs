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
using AddressSplitForExcel.Extension;

namespace AddressSplitForExcel
{
    public partial class SenderManagement : Form
    {
        private List<SenderInfo> Senders = new List<SenderInfo>();
        public SenderManagement()
        {
            InitializeComponent();

            LoadSenders();
           
            //try
            //{
            //    var dbe = new SQLiteContext();


            //    using (var db = new SQLiteContexts("configdb"))
            //    {
            //        var senders = db.SenderAddressInfo.Where(s => s.ID == 1);
            //    }
            //}
            //catch (Exception ex)
            //{

            //    throw ex;
            //}
        }

        private void LoadSenders()
        {
            DataManager dm = new DataManager();

            Senders = dm.GetSenders();

            //DataTable table = Senders.ToTable<SenderInfo>();
            dgSenders.AutoGenerateColumns = false;
            dgSenders.DataSource = Senders;
        }

        private void dgSenders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(dgSenders.Rows[e.RowIndex].Cells[1].Value.ToString());
        }

        private SenderInfo GetEditSender()
        {
            SenderInfo sender = new SenderInfo();
            sender.Sender = txtSender.Text.Trim();
            sender.Mobile = txtMobile.Text.Trim();
            sender.Provience = txtProvience.Text.Trim();
            sender.City = txtCity.Text.Trim();
            sender.Region = txtRegion.Text.Trim();
            sender.Address = txtAddress.Text.Trim();

            return sender;
        }

        private void SetEditSender(SenderInfo sender)
        {
            txtAddress.Text = sender.Address;
            txtCity.Text = sender.City;
            txtSender.Text = sender.Sender;
            txtProvience.Text = sender.Provience;
            txtRegion.Text = sender.Region;
            txtMobile.Text = sender.Mobile;

        }

        private bool ValidateSender()
        {
            if (String.IsNullOrWhiteSpace(txtAddress.Text))
                return false;
            if (String.IsNullOrWhiteSpace(txtCity.Text))
                return false;
            if (String.IsNullOrWhiteSpace(txtMobile.Text))
                return false;
            if (String.IsNullOrWhiteSpace(txtProvience.Text))
                return false;
            if (String.IsNullOrWhiteSpace(txtRegion.Text))
                return false;
            if (String.IsNullOrWhiteSpace(txtSender.Text))
                return false;
            return true;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateSender())
            {
                var model = GetEditSender();


                Senders.Add(model);
                //保存
                DataManager dm = new DataManager();

                dm.SaveSenders(Senders);
                LoadSenders();
            }
            else
            {
                MessageBox.Show("发件人信息不能有空值！");
            }
        }
    }
}
