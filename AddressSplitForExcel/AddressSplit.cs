using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;

namespace AddressSplitForExcel
{
    public partial class AddressSplit : Form
    {
        private DataTable exceldt = null;
        private List<AreaInfo> ProvinceList = new List<AreaInfo>();
        private List<AreaInfo> CityList = new List<AreaInfo>();
        private List<AreaInfo> RegionList = new List<AreaInfo>();

        List<string> nxshort = new List<string>() { "宁夏", "宁夏回族" };
        List<string> nmshort = new List<string>() { "内蒙", "内蒙古" };
        List<string> xjshort = new List<string>() { "新疆", "新疆维吾尔族" };
        List<string> gxshort = new List<string>() { "广西", "广西壮族" };
        List<string> xzshort = new List<string>() { "西藏" };
        public AddressSplit()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel1997-2003|*.xls|Excel|*.xlsx";
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFilepath.Text = ofd.FileName;

                ExcelHelper eh = new ExcelHelper(ofd.FileName);

                List<string> listfields = eh.GetSheetFields("");
                ckFields.Items.Clear();
                ckFields.Items.AddRange(listfields.ToArray());

                exceldt = eh.ExcelToDataTable("", true);
                dgView.DataSource = exceldt;

                //foreach(string field in listfields)
                //{
                //    ckFields.Items.Add
                //}
            }

        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            List<string> fields = new List<string>();
            for (int i = 0; i < ckFields.Items.Count; i++)
            {
                if (ckFields.GetItemChecked(i))
                {
                    fields.Add(ckFields.Items[i].ToString());
                    MessageBox.Show(ckFields.Items[i].ToString());
                }
            }

            MessageBox.Show(fields.Count.ToString());
        }

        private List<string> GetCheckedColumns()
        {

            List<string> fields = new List<string>();
            for (int i = 0; i < ckFields.Items.Count; i++)
            {
                if (ckFields.GetItemChecked(i))
                {
                    fields.Add(ckFields.Items[i].ToString());
                    //MessageBox.Show(ckFields.Items[i].ToString());
                }
            }
            return fields;
        }
        private void btnSplit_Click(object sender, EventArgs e)
        {
            if (exceldt.Rows.Count > 0)
            {
                for (int i = 0; i < exceldt.Rows.Count; i++)
                {
                    var fields = GetCheckedColumns();
                    foreach (var f in fields)
                    {
                        string otheradd = "";
                        var addr = exceldt.Rows[i][f].ToString();
                        var prov = AddressHelper.GetProvince(addr, out otheradd);

                        listbox.Items.Add(prov);
                        listbox.Items.Add(otheradd);

                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Type type = MethodBase.GetCurrentMethod().DeclaringType;

            string _namespace = type.Namespace;

            Assembly _assembly = Assembly.GetExecutingAssembly();

            string rsname = _namespace + ".json1.json";

            Stream stream = _assembly.GetManifestResourceStream(rsname);
            List<RegionInfo> list = new List<RegionInfo>();

            using (StreamReader sr = new StreamReader(stream))
            {
                string json = sr.ReadToEnd();

                richTextBox1.Text = json;
                
                JsonSerializer serializer = new JsonSerializer();

               list = JsonConvert.DeserializeObject<List<RegionInfo>>(json);
            }

            foreach(var p in list)
            {
                //listbox.Items.Add(p.region);

                AreaInfo prov = new AreaInfo();
                prov.Code = p.code;
                prov.ParentCode = "0";                
                if (p.region.EndsWith("自治区")) //自治区
                {
                    prov.AreaLastName = "自治区";
                    prov.AreaFirstName = p.region.Substring(0, p.region.Length - 3);
                    if (prov.AreaFirstName.StartsWith("广西"))
                        prov.AreaShortName = gxshort;
                    else if (prov.AreaFirstName.StartsWith("新疆"))
                        prov.AreaShortName = xjshort;
                    else if (prov.AreaFirstName.StartsWith("宁夏"))
                        prov.AreaShortName = nxshort;
                    else if (prov.AreaFirstName.StartsWith("内蒙"))
                        prov.AreaShortName = nmshort;
                    else if (prov.AreaFirstName.StartsWith("西藏"))
                        prov.AreaShortName = xzshort;
                    else
                        prov.AreaShortName = null;
                }
                else //省 市
                {
                    prov.AreaFirstName = p.region.Substring(0, p.region.Length - 1);
                    prov.AreaLastName = p.region.Substring(p.region.Length - 1, 1);
                    prov.AreaShortName = null;
                }

                ProvinceList.Add(prov);

                listbox.Items.Add(prov.AreaFirstName);
                listbox.Items.Add(prov.AreaLastName);
            }


           // sr.Close();
            stream = null;
        }
    }
}
