﻿namespace AddressSplitForExcel
{
    partial class AddressSplit
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddressSplit));
            this.openFDialog = new System.Windows.Forms.OpenFileDialog();
            this.txtFilepath = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.dgView = new System.Windows.Forms.DataGridView();
            this.listbox = new System.Windows.Forms.ListBox();
            this.btnSplit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbFields = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnOpenPath = new System.Windows.Forms.Button();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labprocess = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnTempUp = new System.Windows.Forms.Button();
            this.btnTempDown = new System.Windows.Forms.Button();
            this.btnSourceRemoveAll = new System.Windows.Forms.Button();
            this.btnSourceAddAll = new System.Windows.Forms.Button();
            this.btnTempRemoveAll = new System.Windows.Forms.Button();
            this.btnTempAddAll = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbFileFields = new System.Windows.Forms.ListBox();
            this.lbFileSelected = new System.Windows.Forms.ListBox();
            this.lbSelectedFields = new System.Windows.Forms.ListBox();
            this.lbTempFields = new System.Windows.Forms.ListBox();
            this.dgTempView = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmSender = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gpinfo = new System.Windows.Forms.GroupBox();
            this.comSender = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTempView)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.gpinfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFDialog
            // 
            this.openFDialog.FileName = "openFileDialog1";
            this.openFDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // txtFilepath
            // 
            this.txtFilepath.Location = new System.Drawing.Point(79, 32);
            this.txtFilepath.Name = "txtFilepath";
            this.txtFilepath.Size = new System.Drawing.Size(490, 21);
            this.txtFilepath.TabIndex = 0;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(575, 31);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "选择文件";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // dgView
            // 
            this.dgView.AllowUserToAddRows = false;
            this.dgView.AllowUserToDeleteRows = false;
            this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgView.Location = new System.Drawing.Point(3, 17);
            this.dgView.Name = "dgView";
            this.dgView.ReadOnly = true;
            this.dgView.RowTemplate.Height = 23;
            this.dgView.Size = new System.Drawing.Size(895, 289);
            this.dgView.TabIndex = 4;
            // 
            // listbox
            // 
            this.listbox.FormattingEnabled = true;
            this.listbox.ItemHeight = 12;
            this.listbox.Location = new System.Drawing.Point(1240, 148);
            this.listbox.Name = "listbox";
            this.listbox.Size = new System.Drawing.Size(212, 148);
            this.listbox.TabIndex = 5;
            // 
            // btnSplit
            // 
            this.btnSplit.Enabled = false;
            this.btnSplit.Location = new System.Drawing.Point(665, 31);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(104, 23);
            this.btnSplit.TabIndex = 6;
            this.btnSplit.Text = "开始拆分";
            this.btnSplit.UseVisualStyleBackColor = true;
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "Excel文件";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbFields);
            this.groupBox1.Location = new System.Drawing.Point(16, 195);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 575);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择拆分列";
            // 
            // lbFields
            // 
            this.lbFields.FormattingEnabled = true;
            this.lbFields.ItemHeight = 12;
            this.lbFields.Location = new System.Drawing.Point(6, 20);
            this.lbFields.Name = "lbFields";
            this.lbFields.Size = new System.Drawing.Size(173, 544);
            this.lbFields.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "保存路径";
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(575, 61);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "保存到文件";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnOpenPath
            // 
            this.btnOpenPath.Enabled = false;
            this.btnOpenPath.Location = new System.Drawing.Point(665, 61);
            this.btnOpenPath.Name = "btnOpenPath";
            this.btnOpenPath.Size = new System.Drawing.Size(104, 23);
            this.btnOpenPath.TabIndex = 12;
            this.btnOpenPath.Text = "打开文件路径";
            this.btnOpenPath.UseVisualStyleBackColor = true;
            this.btnOpenPath.Click += new System.EventHandler(this.btnOpenPath_Click);
            // 
            // txtSavePath
            // 
            this.txtSavePath.Location = new System.Drawing.Point(79, 62);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.ReadOnly = true;
            this.txtSavePath.Size = new System.Drawing.Size(490, 21);
            this.txtSavePath.TabIndex = 13;
            this.txtSavePath.TextChanged += new System.EventHandler(this.txtSavePath_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgView);
            this.groupBox2.Location = new System.Drawing.Point(616, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(901, 309);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "拆分数据展示";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(786, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(281, 72);
            this.label3.TabIndex = 15;
            this.label3.Text = "使用方法：\r\n1：打开要拆分的Excel文件\r\n2：选择要拆分的地址列\r\n3：配置拆分文件中列与模板文件中列的对应关系\r\n4：点击“开始拆分”按钮，拆分结果显示在" +
    "列表内\r\n5：点击“保存到文件”按钮将拆分结果保存到Excel\r\n";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(79, 91);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(490, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // labprocess
            // 
            this.labprocess.AutoSize = true;
            this.labprocess.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labprocess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labprocess.Location = new System.Drawing.Point(575, 96);
            this.labprocess.Name = "labprocess";
            this.labprocess.Size = new System.Drawing.Size(19, 12);
            this.labprocess.TabIndex = 16;
            this.labprocess.Text = "0%";
            this.labprocess.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "拆分进度";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.btnTempUp);
            this.groupBox3.Controls.Add(this.btnTempDown);
            this.groupBox3.Controls.Add(this.btnSourceRemoveAll);
            this.groupBox3.Controls.Add(this.btnSourceAddAll);
            this.groupBox3.Controls.Add(this.btnTempRemoveAll);
            this.groupBox3.Controls.Add(this.btnTempAddAll);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.lbFileFields);
            this.groupBox3.Controls.Add(this.lbFileSelected);
            this.groupBox3.Controls.Add(this.lbSelectedFields);
            this.groupBox3.Controls.Add(this.lbTempFields);
            this.groupBox3.Location = new System.Drawing.Point(208, 125);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(402, 645);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "数据列对应设置";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(171, 369);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(23, 150);
            this.label14.TabIndex = 8;
            this.label14.Text = "双\r\n击\r\n单\r\n个\r\n列\r\n添\r\n加\r\n或\r\n移\r\n除";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.Blue;
            this.label13.Location = new System.Drawing.Point(230, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 15);
            this.label13.TabIndex = 7;
            this.label13.Text = "模板列选择";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.Color.Blue;
            this.label12.Location = new System.Drawing.Point(35, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 15);
            this.label12.TabIndex = 7;
            this.label12.Text = "文件列选择";
            // 
            // btnTempUp
            // 
            this.btnTempUp.Image = global::AddressSplitForExcel.Properties.Resources.icons8_Sort_Up_20;
            this.btnTempUp.Location = new System.Drawing.Point(357, 36);
            this.btnTempUp.Name = "btnTempUp";
            this.btnTempUp.Size = new System.Drawing.Size(28, 28);
            this.btnTempUp.TabIndex = 6;
            this.btnTempUp.UseVisualStyleBackColor = true;
            this.btnTempUp.Click += new System.EventHandler(this.btnTempUp_Click);
            // 
            // btnTempDown
            // 
            this.btnTempDown.Image = global::AddressSplitForExcel.Properties.Resources.icons8_Sort_Down_20;
            this.btnTempDown.Location = new System.Drawing.Point(357, 70);
            this.btnTempDown.Name = "btnTempDown";
            this.btnTempDown.Size = new System.Drawing.Size(28, 28);
            this.btnTempDown.TabIndex = 6;
            this.btnTempDown.UseVisualStyleBackColor = true;
            this.btnTempDown.Click += new System.EventHandler(this.btnTempDown_Click);
            // 
            // btnSourceRemoveAll
            // 
            this.btnSourceRemoveAll.Image = global::AddressSplitForExcel.Properties.Resources.icons8_Double_Down_20;
            this.btnSourceRemoveAll.Location = new System.Drawing.Point(29, 325);
            this.btnSourceRemoveAll.Name = "btnSourceRemoveAll";
            this.btnSourceRemoveAll.Size = new System.Drawing.Size(39, 35);
            this.btnSourceRemoveAll.TabIndex = 5;
            this.btnSourceRemoveAll.UseVisualStyleBackColor = true;
            this.btnSourceRemoveAll.Click += new System.EventHandler(this.btnSourceRemoveAll_Click);
            // 
            // btnSourceAddAll
            // 
            this.btnSourceAddAll.Image = global::AddressSplitForExcel.Properties.Resources.icons8_Double_Up_20;
            this.btnSourceAddAll.Location = new System.Drawing.Point(74, 325);
            this.btnSourceAddAll.Name = "btnSourceAddAll";
            this.btnSourceAddAll.Size = new System.Drawing.Size(39, 35);
            this.btnSourceAddAll.TabIndex = 5;
            this.btnSourceAddAll.UseVisualStyleBackColor = true;
            this.btnSourceAddAll.Click += new System.EventHandler(this.btnSourceAddAll_Click);
            // 
            // btnTempRemoveAll
            // 
            this.btnTempRemoveAll.Image = global::AddressSplitForExcel.Properties.Resources.icons8_Double_Down_20;
            this.btnTempRemoveAll.Location = new System.Drawing.Point(233, 325);
            this.btnTempRemoveAll.Name = "btnTempRemoveAll";
            this.btnTempRemoveAll.Size = new System.Drawing.Size(39, 35);
            this.btnTempRemoveAll.TabIndex = 5;
            this.btnTempRemoveAll.UseVisualStyleBackColor = true;
            this.btnTempRemoveAll.Click += new System.EventHandler(this.btnTempRemoveAll_Click);
            // 
            // btnTempAddAll
            // 
            this.btnTempAddAll.Image = global::AddressSplitForExcel.Properties.Resources.icons8_Double_Up_20;
            this.btnTempAddAll.Location = new System.Drawing.Point(278, 325);
            this.btnTempAddAll.Name = "btnTempAddAll";
            this.btnTempAddAll.Size = new System.Drawing.Size(39, 35);
            this.btnTempAddAll.TabIndex = 5;
            this.btnTempAddAll.UseVisualStyleBackColor = true;
            this.btnTempAddAll.Click += new System.EventHandler(this.btnTempAddAll_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(156, 173);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(47, 12);
            this.label20.TabIndex = 4;
            this.label20.Text = "-------";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(156, 161);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 12);
            this.label19.TabIndex = 4;
            this.label19.Text = "-------";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(156, 101);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 4;
            this.label10.Text = "-------";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(156, 137);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(47, 12);
            this.label18.TabIndex = 4;
            this.label18.Text = "-------";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(156, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "-------";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(156, 149);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 12);
            this.label17.TabIndex = 4;
            this.label17.Text = "-------";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(156, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "-------";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(156, 125);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 12);
            this.label16.TabIndex = 4;
            this.label16.Text = "-------";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(156, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "-------";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(156, 113);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 12);
            this.label15.TabIndex = 4;
            this.label15.Text = "-------";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(156, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "-------";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(156, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "-------";
            // 
            // lbFileFields
            // 
            this.lbFileFields.FormattingEnabled = true;
            this.lbFileFields.ItemHeight = 12;
            this.lbFileFields.Location = new System.Drawing.Point(7, 366);
            this.lbFileFields.Name = "lbFileFields";
            this.lbFileFields.Size = new System.Drawing.Size(148, 268);
            this.lbFileFields.TabIndex = 3;
            this.lbFileFields.DoubleClick += new System.EventHandler(this.lbFileFields_DoubleClick);
            // 
            // lbFileSelected
            // 
            this.lbFileSelected.FormattingEnabled = true;
            this.lbFileSelected.ItemHeight = 12;
            this.lbFileSelected.Location = new System.Drawing.Point(7, 39);
            this.lbFileSelected.Name = "lbFileSelected";
            this.lbFileSelected.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbFileSelected.Size = new System.Drawing.Size(148, 280);
            this.lbFileSelected.TabIndex = 2;
            this.lbFileSelected.DoubleClick += new System.EventHandler(this.lbFileSelected_DoubleClick);
            // 
            // lbSelectedFields
            // 
            this.lbSelectedFields.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lbSelectedFields.FormattingEnabled = true;
            this.lbSelectedFields.ItemHeight = 12;
            this.lbSelectedFields.Location = new System.Drawing.Point(206, 39);
            this.lbSelectedFields.Name = "lbSelectedFields";
            this.lbSelectedFields.Size = new System.Drawing.Size(145, 280);
            this.lbSelectedFields.TabIndex = 1;
            this.lbSelectedFields.DoubleClick += new System.EventHandler(this.lbSelectedFields_DoubleClick);
            // 
            // lbTempFields
            // 
            this.lbTempFields.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lbTempFields.FormattingEnabled = true;
            this.lbTempFields.ItemHeight = 12;
            this.lbTempFields.Location = new System.Drawing.Point(206, 366);
            this.lbTempFields.Name = "lbTempFields";
            this.lbTempFields.Size = new System.Drawing.Size(145, 268);
            this.lbTempFields.TabIndex = 0;
            this.lbTempFields.DoubleClick += new System.EventHandler(this.lbTempFields_DoubleClick);
            // 
            // dgTempView
            // 
            this.dgTempView.AllowUserToAddRows = false;
            this.dgTempView.AllowUserToDeleteRows = false;
            this.dgTempView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTempView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTempView.Location = new System.Drawing.Point(3, 17);
            this.dgTempView.Name = "dgTempView";
            this.dgTempView.ReadOnly = true;
            this.dgTempView.RowTemplate.Height = 23;
            this.dgTempView.Size = new System.Drawing.Size(895, 309);
            this.dgTempView.TabIndex = 19;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgTempView);
            this.groupBox4.Location = new System.Drawing.Point(616, 441);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(901, 329);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "模板数据展示";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(1123, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(382, 64);
            this.label11.TabIndex = 21;
            this.label11.Text = "数据列对应设置可以将拆分文件中的列数\r\n据生成到模板文件对应的列中。\r\n\r\n列配置一次即可下次打开会载入上次配置的数据。";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSender,
            this.帮助ToolStripMenuItem,
            this.关于AToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1533, 25);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmSender
            // 
            this.tsmSender.Name = "tsmSender";
            this.tsmSender.Size = new System.Drawing.Size(95, 21);
            this.tsmSender.Text = "发件人管理(&S)";
            this.tsmSender.Click += new System.EventHandler(this.tsmSender_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.帮助ToolStripMenuItem.Text = "帮助(&H)";
            // 
            // 关于AToolStripMenuItem
            // 
            this.关于AToolStripMenuItem.Name = "关于AToolStripMenuItem";
            this.关于AToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.关于AToolStripMenuItem.Text = "关于(&A)";
            // 
            // gpinfo
            // 
            this.gpinfo.Controls.Add(this.comSender);
            this.gpinfo.Location = new System.Drawing.Point(16, 126);
            this.gpinfo.Name = "gpinfo";
            this.gpinfo.Size = new System.Drawing.Size(186, 63);
            this.gpinfo.TabIndex = 23;
            this.gpinfo.TabStop = false;
            this.gpinfo.Text = "发件人选择";
            // 
            // comSender
            // 
            this.comSender.FormattingEnabled = true;
            this.comSender.Location = new System.Drawing.Point(7, 22);
            this.comSender.Name = "comSender";
            this.comSender.Size = new System.Drawing.Size(173, 20);
            this.comSender.TabIndex = 0;
            this.comSender.SelectedIndexChanged += new System.EventHandler(this.comSender_SelectedIndexChanged);
            // 
            // AddressSplit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1533, 776);
            this.Controls.Add(this.gpinfo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.labprocess);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtSavePath);
            this.Controls.Add(this.btnOpenPath);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSplit);
            this.Controls.Add(this.listbox);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.txtFilepath);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "AddressSplit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "义鑫邦物流Excel地址拆分 v2.0";
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTempView)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gpinfo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFDialog;
        private System.Windows.Forms.TextBox txtFilepath;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.ListBox listbox;
        private System.Windows.Forms.Button btnSplit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnOpenPath;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labprocess;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lbTempFields;
        private System.Windows.Forms.ListBox lbSelectedFields;
        private System.Windows.Forms.ListBox lbFileFields;
        private System.Windows.Forms.ListBox lbFileSelected;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnTempAddAll;
        private System.Windows.Forms.Button btnTempUp;
        private System.Windows.Forms.Button btnTempDown;
        private System.Windows.Forms.Button btnSourceRemoveAll;
        private System.Windows.Forms.Button btnSourceAddAll;
        private System.Windows.Forms.Button btnTempRemoveAll;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgTempView;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmSender;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于AToolStripMenuItem;
        private System.Windows.Forms.ListBox lbFields;
        private System.Windows.Forms.GroupBox gpinfo;
        private System.Windows.Forms.ComboBox comSender;
    }
}

