namespace AddressSplitForExcel
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
            this.ckFields = new System.Windows.Forms.CheckedListBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.dgView = new System.Windows.Forms.DataGridView();
            this.listbox = new System.Windows.Forms.ListBox();
            this.btnSplit = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
            this.SuspendLayout();
            // 
            // openFDialog
            // 
            this.openFDialog.FileName = "openFileDialog1";
            this.openFDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // txtFilepath
            // 
            this.txtFilepath.Location = new System.Drawing.Point(44, 47);
            this.txtFilepath.Name = "txtFilepath";
            this.txtFilepath.Size = new System.Drawing.Size(548, 21);
            this.txtFilepath.TabIndex = 0;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(609, 47);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "选择文件";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // ckFields
            // 
            this.ckFields.CheckOnClick = true;
            this.ckFields.FormattingEnabled = true;
            this.ckFields.Location = new System.Drawing.Point(44, 92);
            this.ckFields.Name = "ckFields";
            this.ckFields.Size = new System.Drawing.Size(120, 164);
            this.ckFields.TabIndex = 2;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(609, 92);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 3;
            this.btnProcess.Text = "拆分地址";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // dgView
            // 
            this.dgView.AllowUserToAddRows = false;
            this.dgView.AllowUserToDeleteRows = false;
            this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgView.Location = new System.Drawing.Point(44, 278);
            this.dgView.Name = "dgView";
            this.dgView.ReadOnly = true;
            this.dgView.RowTemplate.Height = 23;
            this.dgView.Size = new System.Drawing.Size(640, 150);
            this.dgView.TabIndex = 4;
            // 
            // listbox
            // 
            this.listbox.FormattingEnabled = true;
            this.listbox.ItemHeight = 12;
            this.listbox.Location = new System.Drawing.Point(170, 92);
            this.listbox.Name = "listbox";
            this.listbox.Size = new System.Drawing.Size(422, 172);
            this.listbox.TabIndex = 5;
            // 
            // btnSplit
            // 
            this.btnSplit.Location = new System.Drawing.Point(609, 131);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(75, 23);
            this.btnSplit.TabIndex = 6;
            this.btnSplit.Text = "执行";
            this.btnSplit.UseVisualStyleBackColor = true;
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(693, 168);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(429, 260);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(755, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddressSplit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 480);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnSplit);
            this.Controls.Add(this.listbox);
            this.Controls.Add(this.dgView);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.ckFields);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.txtFilepath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AddressSplit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excel地址拆分";
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFDialog;
        private System.Windows.Forms.TextBox txtFilepath;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.CheckedListBox ckFields;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.ListBox listbox;
        private System.Windows.Forms.Button btnSplit;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
    }
}

