using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AddressSplitForExcel
{
    public partial class PMT : Form
    {
        public PMT()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double rate = double.Parse(txtRate.Text);
            int nper = int.Parse(txtNper.Text);
            double pv = double.Parse(txtPv.Text);


            double rs = (pv * rate * (Math.Pow(1 + rate, nper))) / (Math.Pow(1 + rate, nper) - 1);

            txtResult.Text = rs.ToString();
        }
    }
}
