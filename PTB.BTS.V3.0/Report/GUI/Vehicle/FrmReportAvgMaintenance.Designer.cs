namespace Report.GUI.Vehicle {
    partial class FrmReportAvgMaintenance {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbContractType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRetiveData = new System.Windows.Forms.Button();
            this.cmbModel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.crv3Years = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.crv4Years = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.crv5Years = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbContractType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnRetiveData);
            this.groupBox1.Controls.Add(this.cmbModel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbBrand);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(721, 41);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(614, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "ปี";
            // 
            // cmbContractType
            // 
            this.cmbContractType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbContractType.FormattingEnabled = true;
            this.cmbContractType.Items.AddRange(new object[] {
            "==ALL==",
            "3",
            "4",
            "5"});
            this.cmbContractType.Location = new System.Drawing.Point(528, 12);
            this.cmbContractType.Name = "cmbContractType";
            this.cmbContractType.Size = new System.Drawing.Size(66, 21);
            this.cmbContractType.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(465, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "ชนิดสัญญา";
            // 
            // btnRetiveData
            // 
            this.btnRetiveData.Location = new System.Drawing.Point(634, 12);
            this.btnRetiveData.Name = "btnRetiveData";
            this.btnRetiveData.Size = new System.Drawing.Size(75, 23);
            this.btnRetiveData.TabIndex = 4;
            this.btnRetiveData.Text = "แสดงข้อมูล";
            this.btnRetiveData.UseVisualStyleBackColor = true;
            this.btnRetiveData.Click += new System.EventHandler(this.btnRetiveData_Click);
            // 
            // cmbModel
            // 
            this.cmbModel.DisplayMember = "Model_English_Name";
            this.cmbModel.FormattingEnabled = true;
            this.cmbModel.Location = new System.Drawing.Point(241, 12);
            this.cmbModel.Name = "cmbModel";
            this.cmbModel.Size = new System.Drawing.Size(209, 21);
            this.cmbModel.TabIndex = 3;
            this.cmbModel.ValueMember = "Model_Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Model";
            // 
            // cmbBrand
            // 
            this.cmbBrand.DisplayMember = "Brand_English_Name";
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(53, 12);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(121, 21);
            this.cmbBrand.TabIndex = 1;
            this.cmbBrand.ValueMember = "Brand_Code";
            this.cmbBrand.SelectedIndexChanged += new System.EventHandler(this.cmbBrand_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Brand";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(721, 425);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.crv3Years);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(713, 399);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "3 years";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // crv3Years
            // 
            this.crv3Years.ActiveViewIndex = -1;
            this.crv3Years.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv3Years.DisplayGroupTree = false;
            this.crv3Years.DisplayStatusBar = false;
            this.crv3Years.DisplayToolbar = false;
            this.crv3Years.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crv3Years.Location = new System.Drawing.Point(3, 3);
            this.crv3Years.Name = "crv3Years";
            this.crv3Years.ShowGroupTreeButton = false;
            this.crv3Years.ShowRefreshButton = false;
            this.crv3Years.Size = new System.Drawing.Size(707, 393);
            this.crv3Years.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.crv4Years);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(713, 399);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "4 years";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // crv4Years
            // 
            this.crv4Years.ActiveViewIndex = -1;
            this.crv4Years.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv4Years.DisplayGroupTree = false;
            this.crv4Years.DisplayStatusBar = false;
            this.crv4Years.DisplayToolbar = false;
            this.crv4Years.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crv4Years.Location = new System.Drawing.Point(3, 3);
            this.crv4Years.Name = "crv4Years";
            this.crv4Years.ShowGroupTreeButton = false;
            this.crv4Years.ShowRefreshButton = false;
            this.crv4Years.Size = new System.Drawing.Size(707, 393);
            this.crv4Years.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.crv5Years);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(713, 399);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "5 years";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // crv5Years
            // 
            this.crv5Years.ActiveViewIndex = -1;
            this.crv5Years.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crv5Years.DisplayGroupTree = false;
            this.crv5Years.DisplayStatusBar = false;
            this.crv5Years.DisplayToolbar = false;
            this.crv5Years.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crv5Years.Location = new System.Drawing.Point(3, 3);
            this.crv5Years.Name = "crv5Years";
            this.crv5Years.ShowGroupTreeButton = false;
            this.crv5Years.ShowRefreshButton = false;
            this.crv5Years.Size = new System.Drawing.Size(707, 393);
            this.crv5Years.TabIndex = 2;
            // 
            // FrmReportAvgMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 466);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmReportAvgMaintenance";
            this.Text = "รายงานวิเคราะห์ค่าซ่อมรถยนต์แต่ละคัน ไม่แยกตามผู้เช่า";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv3Years;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv4Years;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crv5Years;
        private System.Windows.Forms.ComboBox cmbModel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRetiveData;
        private System.Windows.Forms.ComboBox cmbContractType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
    }
}