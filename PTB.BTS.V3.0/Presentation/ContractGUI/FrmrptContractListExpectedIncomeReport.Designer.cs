namespace Presentation.ContractGUI
{
    partial class FrmrptContractListExpectedIncomeReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.crvReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.gpbSearchDetail = new System.Windows.Forms.GroupBox();
            this.chkExpectedIncome = new System.Windows.Forms.CheckBox();
            this.cboContractType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.gpbSearchDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // crvReport
            // 
            this.crvReport.ActiveViewIndex = -1;
            this.crvReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReport.DisplayGroupTree = false;
            this.crvReport.Location = new System.Drawing.Point(0, 100);
            this.crvReport.Name = "crvReport";
            this.crvReport.ShowGroupTreeButton = false;
            this.crvReport.ShowRefreshButton = false;
            this.crvReport.Size = new System.Drawing.Size(801, 442);
            this.crvReport.TabIndex = 145;
            // 
            // gpbSearchDetail
            // 
            this.gpbSearchDetail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpbSearchDetail.Controls.Add(this.chkExpectedIncome);
            this.gpbSearchDetail.Controls.Add(this.cboContractType);
            this.gpbSearchDetail.Controls.Add(this.label2);
            this.gpbSearchDetail.Controls.Add(this.dtpToDate);
            this.gpbSearchDetail.Controls.Add(this.dtpFromDate);
            this.gpbSearchDetail.Controls.Add(this.label1);
            this.gpbSearchDetail.Controls.Add(this.label14);
            this.gpbSearchDetail.Controls.Add(this.btnPrint);
            this.gpbSearchDetail.Location = new System.Drawing.Point(16, 8);
            this.gpbSearchDetail.Name = "gpbSearchDetail";
            this.gpbSearchDetail.Size = new System.Drawing.Size(768, 79);
            this.gpbSearchDetail.TabIndex = 141;
            this.gpbSearchDetail.TabStop = false;
            this.gpbSearchDetail.Text = "Condition";
            // 
            // chkExpectedIncome
            // 
            this.chkExpectedIncome.AutoSize = true;
            this.chkExpectedIncome.Location = new System.Drawing.Point(89, 49);
            this.chkExpectedIncome.Name = "chkExpectedIncome";
            this.chkExpectedIncome.Size = new System.Drawing.Size(109, 17);
            this.chkExpectedIncome.TabIndex = 153;
            this.chkExpectedIncome.Text = "สรุปรายได้แต่ละปี";
            this.chkExpectedIncome.UseVisualStyleBackColor = true;
            this.chkExpectedIncome.CheckedChanged += new System.EventHandler(this.chkExpectedIncome_CheckedChanged);
            // 
            // cboContractType
            // 
            this.cboContractType.DisplayMember = "value";
            this.cboContractType.FormattingEnabled = true;
            this.cboContractType.Location = new System.Drawing.Point(414, 23);
            this.cboContractType.Name = "cboContractType";
            this.cboContractType.Size = new System.Drawing.Size(121, 21);
            this.cboContractType.TabIndex = 152;
            this.cboContractType.ValueMember = "key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(335, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 151;
            this.label2.Text = "ประเภทสัญญา";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(207, 23);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(96, 20);
            this.dtpToDate.TabIndex = 150;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(89, 23);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(96, 20);
            this.dtpFromDate.TabIndex = 149;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(191, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 148;
            this.label1.Text = "-";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(37, 27);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(46, 13);
            this.label14.TabIndex = 148;
            this.label14.Text = "ช่วงวันที่";
            // 
            // btnPrint
            // 
            this.btnPrint.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPrint.Location = new System.Drawing.Point(651, 22);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(72, 23);
            this.btnPrint.TabIndex = 142;
            this.btnPrint.Text = "ดูข้อมูล";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // FrmrptContractListExpectedIncomeReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 544);
            this.Controls.Add(this.crvReport);
            this.Controls.Add(this.gpbSearchDetail);
            this.Name = "FrmrptContractListExpectedIncomeReport";
            this.Text = "Car Agreement";
            this.Load += new System.EventHandler(this.FrmContractListExpectedIncomeReport_Load);
            this.gpbSearchDetail.ResumeLayout(false);
            this.gpbSearchDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbSearchDetail;
        private System.Windows.Forms.Button btnPrint;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReport;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboContractType;
        private System.Windows.Forms.CheckBox chkExpectedIncome;
    }
}