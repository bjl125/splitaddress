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
        private DataTable resultDT = null;
        private List<AreaInfo> ProvinceList = new List<AreaInfo>();
        private List<AreaInfo> CityList = new List<AreaInfo>();
        private List<AreaInfo> RegionList = new List<AreaInfo>();
        private List<AddressInfo> AddrList = new List<AddressInfo>();

        List<string> nxshort = new List<string>() { "宁夏回族", "宁夏" };
        List<string> nmshort = new List<string>() { "内蒙古", "内蒙" };
        List<string> xjshort = new List<string>() { "新疆维吾尔族", "新疆" };
        List<string> gxshort = new List<string>() { "广西壮族", "广西" };
        List<string> xzshort = new List<string>() { "西藏" };
        public AddressSplit()
        {
            InitializeComponent();
            InitConfig();
            GenerateAreainfoList();
            richTextBox1.Text = ConfigHelper.GetLocalConfigJson();
        }

        public AppConfig AppConfigInfo { set; get; }
        /// <summary>
        /// 初始化配置信息
        /// </summary>
        public void InitConfig()
        {
            AppConfig config = ConfigHelper.GetAppConfig();
            this.AppConfigInfo = config;
            foreach (string field in config.TempFields)
            {
                lbTempFields.Items.Add(field);
            }
            //默认选择
            foreach (string field in config.DefaultSelectedFields)
            {
                lbSelectedFields.Items.Add(field);
                if (lbTempFields.Items.Contains(field))
                {
                    lbTempFields.Items.Remove(field);
                }
            }
        }

        public void UpdateConfigInfo()
        {
            this.AppConfigInfo.DefaultFileFields.Clear();
            this.AppConfigInfo.DefaultSelectedFields.Clear();

            foreach (var field in lbFileSelected.Items)
            {
                this.AppConfigInfo.DefaultFileFields.Add(field.ToString());
            }
            foreach(var field in lbSelectedFields.Items)
            {
                this.AppConfigInfo.DefaultSelectedFields.Add(field.ToString());
            }
        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel|*.xlsx|Excel97-2003|*.xls";
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFilepath.Text = ofd.FileName;

                ExcelHelper eh = new ExcelHelper(ofd.FileName);

                List<string> listfields = eh.GetSheetFields("");
                ckFields.Items.Clear();
                ckFields.Items.AddRange(listfields.ToArray());

                //设置可选择列
                lbFileFields.Items.Clear();
                lbFileFields.Items.AddRange(listfields.ToArray());

                var f = "";
                foreach (var s in listfields)
                {
                    f += "\"" + s + "\",";
                }
                richTextBox1.Text = f;

                exceldt = eh.ExcelToDataTable("", true);
                dgView.DataSource = exceldt;

                //foreach(string field in listfields)
                //{
                //    ckFields.Items.Add
                //}

                btnSplit.Enabled = true;
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
            var fields = GetCheckedColumns();
            if (fields.Count > 0)
            {
                //设置已选择的文件列配置
                UpdateConfigInfo();

                if (exceldt.Rows.Count > 0)
                {
                    btnSplit.Enabled = false;
                    progressBar1.Maximum = exceldt.Rows.Count;
                    for (int i = 0; i < exceldt.Rows.Count; i++)
                    {
                        progressBar1.Value = i + 1;
                        labprocess.Text = i.ToString();
                        foreach (var f in fields)
                        {
                            AddressInfo ad = new AddressInfo();

                            //string otheradd = "";
                            var addr = exceldt.Rows[i][f].ToString();
                            // var prov = AddressHelper.GetProvince(addr, out otheradd);
                            ad = AddressHelper.GetSplitAddress(addr, ProvinceList, CityList, RegionList);
                            ad.RowNum = i;

                            AddrList.Add(ad);

                            //listbox.Items.Add(ad.AddrPro);
                            // listbox.Items.Add(ad.AddrOther);

                        }
                    }

                    resultDT = GenerateDatatableForExcel(exceldt, AddrList);

                    dgView.DataSource = resultDT;

                    if (resultDT != null)
                    {
                        btnSave.Enabled = true;
                        //保存配置项
                        ConfigHelper.SaveConfigToFile(this.AppConfigInfo);
                    }
                }
                btnSplit.Enabled = true;

            }
            else
            {
                MessageBox.Show("请选择要拆分的列！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private DataTable GenerateDatatableForExcel(DataTable dt, List<AddressInfo> addrlist)
        {
            DataTable data = dt.Copy();

            DataColumn dcp = new DataColumn("买家收货省（必填）");
            DataColumn dcs = new DataColumn("买家收货市（必填）");
            DataColumn dcq = new DataColumn("买家收货区（必填）");
            DataColumn dco = new DataColumn("买家收货地址（必填）");

            if (!data.Columns.Contains("买家收货省（必填）"))
            {
                data.Columns.Add(dcp);
            }
            if (!data.Columns.Contains("买家收货市（必填）"))
            {
                data.Columns.Add(dcs);
            }
            if (!data.Columns.Contains("买家收货区（必填）"))
            {
                data.Columns.Add(dcq);
            }
            if (!data.Columns.Contains("买家收货地址（必填）"))
            {
                data.Columns.Add(dco);
            }

            foreach (var addr in addrlist)
            {
                data.Rows[addr.RowNum]["买家收货省（必填）"] = addr.AddrPro;
                data.Rows[addr.RowNum]["买家收货市（必填）"] = addr.AddrCity;
                data.Rows[addr.RowNum]["买家收货区（必填）"] = addr.AddrArea;
                data.Rows[addr.RowNum]["买家收货地址（必填）"] = addr.AddrOther;
            }

            return data;

        }
        private void GenerateAreainfoList()
        {
            Type type = MethodBase.GetCurrentMethod().DeclaringType;

            string _namespace = type.Namespace;

            Assembly _assembly = Assembly.GetExecutingAssembly();

            string rsname = _namespace + ".citys.json";

            Stream stream = _assembly.GetManifestResourceStream(rsname);
            List<RegionInfo> list = new List<RegionInfo>();

            using (StreamReader sr = new StreamReader(stream))
            {
                string json = sr.ReadToEnd();

                //richTextBox1.Text = json;

                JsonSerializer serializer = new JsonSerializer();

                list = JsonConvert.DeserializeObject<List<RegionInfo>>(json);
            }

            foreach (var p in list)
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
                        prov.AreaShortName = new List<string>();
                }
                else //省 市
                {
                    prov.AreaFirstName = p.region.Substring(0, p.region.Length - 1);
                    prov.AreaLastName = p.region.Substring(p.region.Length - 1, 1);
                    prov.AreaShortName = new List<string>();
                }

                ProvinceList.Add(prov);

                //整理省级市
                foreach (var c in p.regionEntitys)
                {
                    AreaInfo city = new AreaInfo();
                    city.Code = c.code;
                    city.ParentCode = p.code;
                    if (c.region.EndsWith("自治州"))
                    {
                        city.AreaFirstName = c.region.Substring(0, c.region.Length - 3);
                        city.AreaLastName = "自治州";

                        CityList.Add(city);
                    }
                    else if (c.region.EndsWith("地区"))
                    {
                        city.AreaFirstName = c.region.Substring(0, c.region.Length - 2);
                        city.AreaLastName = "地区";
                        CityList.Add(city);
                    }
                    else if (c.region.EndsWith("市") || c.region.EndsWith("盟")
                        || c.region.EndsWith("县"))
                    {
                        city.AreaFirstName = c.region.Substring(0, c.region.Length - 1);
                        city.AreaLastName = c.region.Substring(c.region.Length - 1, 1);
                        if (city.AreaFirstName.Length <= 1)
                        {
                            continue;
                        }
                        CityList.Add(city);
                    }
                    else
                    {
                        //listbox.Items.Add(p.region + c.region);

                    }


                    //整理区县
                    if (c.regionEntitys != null)
                    {
                        foreach (var r in c.regionEntitys)
                        {
                            if (r.region == "市辖区")
                                continue;

                            AreaInfo region = new AreaInfo();
                            region.Code = r.code;
                            region.ParentCode = c.code;
                            region.AreaFirstName = r.region;

                            //自治县  县 林区 区 市 旗 自治旗
                            if (r.region.EndsWith("自治县"))
                            {
                                region.AreaFirstName = r.region.Substring(0, r.region.Length - 3);
                                region.AreaLastName = "自治县";
                                RegionList.Add(region);
                                continue;
                            }
                            else if (r.region.EndsWith("自治旗"))
                            {
                                region.AreaFirstName = r.region.Substring(0, r.region.Length - 3);
                                region.AreaLastName = "自治旗";
                                RegionList.Add(region);
                                continue;
                            }
                            else if (r.region.EndsWith("旗"))
                            {
                                region.AreaFirstName = r.region.Substring(0, r.region.Length - 1);
                                region.AreaLastName = "旗";
                                RegionList.Add(region);
                                continue;
                            }
                            else if (r.region.EndsWith("县"))
                            {
                                region.AreaFirstName = r.region.Substring(0, r.region.Length - 1);
                                region.AreaLastName = "县";
                                RegionList.Add(region);
                                continue;
                            }
                            else if (r.region.EndsWith("区"))
                            {
                                region.AreaFirstName = r.region.Substring(0, r.region.Length - 1);
                                region.AreaLastName = "区";
                                RegionList.Add(region);
                                continue;
                            }
                            else if (r.region.EndsWith("市"))
                            {
                                region.AreaFirstName = r.region.Substring(0, r.region.Length - 1);
                                region.AreaLastName = "市";
                                RegionList.Add(region);
                                continue;
                            }
                            else
                            {
                                region.AreaFirstName = r.region.Substring(0, r.region.Length - 1);
                                RegionList.Add(region);
                            }
                        }
                    }

                }


                // listbox.Items.Add(prov.AreaFirstName);
                //listbox.Items.Add(prov.AreaLastName);
            }

            //foreach (var c in RegionList)
            //{
            //    listbox.Items.Add(c.ParentCode + "-" + c.Code + "-" + c.AreaFirstName);
            //}
            // sr.Close();
            stream = null;
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

                //richTextBox1.Text = json;

                JsonSerializer serializer = new JsonSerializer();

                list = JsonConvert.DeserializeObject<List<RegionInfo>>(json);
            }

            foreach (var p in list)
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

                // listbox.Items.Add(prov.AreaFirstName);
                // listbox.Items.Add(prov.AreaLastName);
            }


            // sr.Close();
            stream = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel|*.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                txtSavePath.Text = sfd.FileName;

                if (resultDT != null)
                {
                    ExcelHelper eh = new ExcelHelper(txtSavePath.Text);
                    var r = eh.SaveTableToExcel(txtSavePath.Text, resultDT, "sheet1", true);
                    if (r)
                    {
                        MessageBox.Show("保存成功");
                    }
                }

            }

        }

        private void txtSavePath_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtSavePath.Text))
                btnOpenPath.Enabled = true;
        }

        private void btnOpenPath_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Explorer.exe", txtSavePath.Text.Substring(0, txtSavePath.Text.LastIndexOf("\\") + 1));
        }

        private void lbSelectedFields_DoubleClick(object sender, EventArgs e)
        {
            var listbox = (ListBox)sender;
            string selecteditem = listbox.SelectedItem.ToString();
            lbTempFields.Items.Add(selecteditem);
            listbox.Items.RemoveAt(listbox.SelectedIndex);
        }

        private void lbTempFields_DoubleClick(object sender, EventArgs e)
        {

            var listbox = (ListBox)sender;
            string selecteditem = listbox.SelectedItem.ToString();
            lbSelectedFields.Items.Add(selecteditem);
            listbox.Items.RemoveAt(listbox.SelectedIndex);
        }

        private void lbFileFields_DoubleClick(object sender, EventArgs e)
        {

            var listbox = (ListBox)sender;
            string selecteditem = listbox.SelectedItem.ToString();
            lbFileSelected.Items.Add(selecteditem);
            listbox.Items.RemoveAt(listbox.SelectedIndex);
        }

        private void lbFileSelected_DoubleClick(object sender, EventArgs e)
        {

            var listbox = (ListBox)sender;
            string selecteditem = listbox.SelectedItem.ToString();
            lbFileFields.Items.Add(selecteditem);
            listbox.Items.RemoveAt(listbox.SelectedIndex);
        }

        private void btnTempRemoveAll_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(lbSelectedFields, lbTempFields);
        }

        private void btnTempAddAll_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(lbTempFields, lbSelectedFields);
        }

        private void btnSourceRemoveAll_Click(object sender, EventArgs e)
        {

            MoveSelectedItems(lbFileSelected, lbFileFields);
        }

        private void btnSourceAddAll_Click(object sender, EventArgs e)
        {

            MoveSelectedItems(lbFileFields, lbFileSelected);
        }

        private void MoveSelectedItems(ListBox source, ListBox des)
        {
            var listbox = (ListBox)source;
            des.Items.AddRange(listbox.Items);
            listbox.Items.Clear();
        }
        /// <summary>
        /// 移动items排序
        /// </summary>
        /// <param name="listbox">Listbox</param>
        /// <param name="upordown">UP Dwon 标记：1为Up,0为Down</param>
        public void MoveUpDownItems(ListBox listbox, int upordown, object sender)
        {
            //上移
            if (upordown == 1)
            {
                if (listbox.SelectedIndex > 0)
                {
                    int index = listbox.SelectedIndex;
                    var temp = listbox.Items[index - 1];
                    listbox.Items[index - 1] = listbox.SelectedItem;
                    listbox.Items[index] = temp;
                    listbox.SelectedIndex = index - 1;
                }
            }
            else if (upordown == 0)
            {
                if (listbox.SelectedIndex < listbox.Items.Count - 1)
                {
                    int index = listbox.SelectedIndex;
                    var temp = listbox.Items[index + 1];
                    listbox.Items[index + 1] = listbox.SelectedItem;
                    listbox.Items[index] = temp;
                    listbox.SelectedIndex = index + 1;
                }
            }
        }

        private void btnTempUp_Click(object sender, EventArgs e)
        {
            MoveUpDownItems(lbSelectedFields, 1, sender);
        }

        private void btnTempDown_Click(object sender, EventArgs e)
        {
            MoveUpDownItems(lbSelectedFields, 0, sender);
        }
    }
}
