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
        private DataManager dataManager = new DataManager();
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
            if (Senders.Count > 0)
            {
                dgSenders.AutoGenerateColumns = false;
                dgSenders.DataSource = Senders;
                dgSenders.Refresh();
            }
            //DataTable table = Senders.ToTable<SenderInfo>();
        }
        private void BindSenders()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = Senders;

            //dgSenders.AutoGenerateColumns = false;
            dgSenders.DataSource = bs;
            dgSenders.Refresh();
            //DataTable table = Senders.ToTable<SenderInfo>();
        }

        private void dgSenders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dgSenders.Rows[e.RowIndex].Cells["ID"].Value.ToString();
            txtAddress.Text = dgSenders.Rows[e.RowIndex].Cells["Address"].Value.ToString();
            txtSender.Text= dgSenders.Rows[e.RowIndex].Cells["Sender"].Value.ToString();
            txtMobile.Text= dgSenders.Rows[e.RowIndex].Cells["Mobile"].Value.ToString();
            txtProvience.Text= dgSenders.Rows[e.RowIndex].Cells["Provience"].Value.ToString(); 
            txtCity.Text= dgSenders.Rows[e.RowIndex].Cells["City"].Value.ToString();
            txtRegion.Text= dgSenders.Rows[e.RowIndex].Cells["Region"].Value.ToString();

            btnUpdate.Enabled = true;
        }

        private SenderInfo GetEditSender()
        {
            SenderInfo sender = new SenderInfo();
            sender.ID = Guid.NewGuid().ToString();
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
                //DataManager dm = new DataManager();

                dataManager.SaveSenders(Senders);
                LoadSenders();
                btnUpdate.Enabled = false;
                txtID.Text = "";
            }
            else
            {
                MessageBox.Show("发件人信息不能有空值！");
            }
        }

        private void dgSenders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
                if (dgv.Columns[e.ColumnIndex].GetType() == typeof(DataGridViewLinkColumn))
                {
                    string name = dgv.Rows[e.RowIndex].Cells["Sender"].Value.ToString();
                    string mobile = dgv.Rows[e.RowIndex].Cells["Mobile"].Value.ToString();

                    var sen = Senders.Where(s => s.Sender == name && s.Mobile == mobile).FirstOrDefault();

                    Senders.Remove(sen);
                    dataManager.SaveSenders(Senders);
                    BindSenders();

                }

            }
            catch (Exception ex)
            {

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var newSender = GetEditSender();
            newSender.ID = txtID.Text;
            //更新
            SenderInfo updateSender = Senders.Where(s => s.ID == newSender.ID).FirstOrDefault();

            updateSender.Mobile = newSender.Mobile;
            updateSender.Sender = newSender.Sender;
            updateSender.Provience = newSender.Provience;
            updateSender.City = newSender.City;
            updateSender.Region = newSender.Region;
            updateSender.Address = newSender.Address;

            //绑定
            dataManager.SaveSenders(Senders);
            BindSenders();

            txtID.Text = "";
            btnUpdate.Enabled = false;
        }
    }
}
