namespace PTB.PIS.Welfare.ReportApp.GUI.MedicalAidGUI {
    partial class FrmReportMedicalAid {
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
            this.crvMain = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gpbCondition = new System.Windows.Forms.GroupBox();
            this.chkEmpNo = new System.Windows.Forms.CheckBox();
            this.chkEmployedDate = new System.Windows.Forms.CheckBox();
            this.dtpFromEmploy = new System.Windows.Forms.DateTimePicker();
            this.txtEmployeeNo = new System.Windows.Forms.TextBox();
            this.dtpToEmploy = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRetiveData = new System.Windows.Forms.Button();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.gpbCondition.SuspendLayout();
            this.SuspendLayout();
            // 
            // crvMain
            // 
            this.crvMain.ActiveViewIndex = -1;
            this.crvMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvMain.DisplayGroupTree = false;
            this.crvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvMain.Location = new System.Drawing.Point(0, 168);
            this.crvMain.Name = "crvMain";
            this.crvMain.ShowGroupTreeButton = false;
            this.crvMain.ShowRefreshButton = false;
            this.crvMain.Size = new System.Drawing.Size(940, 426);
            this.crvMain.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gpbCondition);
            this.groupBox1.Controls.Add(this.btnRetiveData);
            this.groupBox1.Controls.Add(this.dtpDateTo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpDateFrom);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(940, 168);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // gpbCondition
            // 
            this.gpbCondition.Controls.Add(this.chkEmpNo);
            this.gpbCondition.Controls.Add(this.chkEmployedDate);
            this.gpbCondition.Controls.Add(this.dtpFromEmploy);
            this.gpbCondition.Controls.Add(this.txtEmployeeNo);
            this.gpbCondition.Controls.Add(this.dtpToEmploy);
            this.gpbCondition.Controls.Add(this.label4);
            this.gpbCondition.Location = new System.Drawing.Point(16, 56);
            this.gpbCondition.Name = "gpbCondition";
            this.gpbCondition.Size = new System.Drawing.Size(376, 104);
            this.gpbCondition.TabIndex = 17;
            this.gpbCondition.TabStop = false;
            this.gpbCondition.Text = "เงื่อนไขพนักงาน";
            // 
            // chkEmpNo
            // 
            this.chkEmpNo.AutoSize = true;
            this.chkEmpNo.Location = new System.Drawing.Point(24, 72);
            this.chkEmpNo.Name = "chkEmpNo";
            this.chkEmpNo.Size = new System.Drawing.Size(86, 17);
            this.chkEmpNo.TabIndex = 18;
            this.chkEmpNo.Text = "รหัสพนักงาน";
            this.chkEmpNo.UseVisualStyleBackColor = true;
            this.chkEmpNo.CheckedChanged += new System.EventHandler(this.chkEmpNo_CheckedChanged);
            // 
            // chkEmployedDate
            // 
            this.chkEmployedDate.AutoSize = true;
            this.chkEmployedDate.Location = new System.Drawing.Point(24, 32);
            this.chkEmployedDate.Name = "chkEmployedDate";
            this.chkEmployedDate.Size = new System.Drawing.Size(83, 17);
            this.chkEmployedDate.TabIndex = 17;
            this.chkEmployedDate.Text = "วันที่เริ่มงาน";
            this.chkEmployedDate.UseVisualStyleBackColor = true;
            this.chkEmployedDate.CheckedChanged += new System.EventHandler(this.chkEmployedDate_CheckedChanged);
            // 
            // dtpFromEmploy
            // 
            this.dtpFromEmploy.CustomFormat = "dd/MM/yyyy";
            this.dtpFromEmploy.Enabled = false;
            this.dtpFromEmploy.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromEmploy.Location = new System.Drawing.Point(112, 30);
            this.dtpFromEmploy.Name = "dtpFromEmploy";
            this.dtpFromEmploy.Size = new System.Drawing.Size(86, 20);
            this.dtpFromEmploy.TabIndex = 12;
            // 
            // txtEmployeeNo
            // 
            this.txtEmployeeNo.Enabled = false;
            this.txtEmployeeNo.Location = new System.Drawing.Point(112, 70);
            this.txtEmployeeNo.MaxLength = 5;
            this.txtEmployeeNo.Name = "txtEmployeeNo";
            this.txtEmployeeNo.Size = new System.Drawing.Size(86, 20);
            this.txtEmployeeNo.TabIndex = 16;
            // 
            // dtpToEmploy
            // 
            this.dtpToEmploy.CustomFormat = "dd/MM/yyyy";
            this.dtpToEmploy.Enabled = false;
            this.dtpToEmploy.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToEmploy.Location = new System.Drawing.Point(240, 30);
            this.dtpToEmploy.Name = "dtpToEmploy";
            this.dtpToEmploy.Size = new System.Drawing.Size(86, 20);
            this.dtpToEmploy.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(208, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "ถึง";
            // 
            // btnRetiveData
            // 
            this.btnRetiveData.Location = new System.Drawing.Point(400, 136);
            this.btnRetiveData.Name = "btnRetiveData";
            this.btnRetiveData.Size = new System.Drawing.Size(80, 23);
            this.btnRetiveData.TabIndex = 10;
            this.btnRetiveData.Text = "แสดงข้อมูล";
            this.btnRetiveData.UseVisualStyleBackColor = true;
            this.btnRetiveData.Click += new System.EventHandler(this.btnRetiveData_Click);
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTo.Location = new System.Drawing.Point(248, 28);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(86, 20);
            this.dtpDateTo.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "ถึง";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "ข้อมูลระหว่างวันที่ : ";
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFrom.Location = new System.Drawing.Point(120, 28);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(86, 20);
            this.dtpDateFrom.TabIndex = 6;
            // 
            // FrmReportMedicalAid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(940, 594);
            this.Controls.Add(this.crvMain);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmReportMedicalAid";
            this.Load += new System.EventHandler(this.FrmReportMedicalAid_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpbCondition.ResumeLayout(false);
            this.gpbCondition.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRetiveData;
        protected System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label label4;
        protected System.Windows.Forms.DateTimePicker dtpToEmploy;
        protected System.Windows.Forms.DateTimePicker dtpFromEmploy;
        private System.Windows.Forms.TextBox txtEmployeeNo;
        private System.Windows.Forms.GroupBox gpbCondition;
        private System.Windows.Forms.CheckBox chkEmpNo;
        private System.Windows.Forms.CheckBox chkEmployedDate;
    }
}
