namespace Presentation.ContractGUI
{
    partial class FrmReportDriverAgreement
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
            this.gpbTISDetail = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numFamilyRate = new System.Windows.Forms.NumericUpDown();
            this.txtCommonDriver = new System.Windows.Forms.TextBox();
            this.numCommonRate = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFamilyDriver = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.gpbContractDetail = new System.Windows.Forms.GroupBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtContractsts = new System.Windows.Forms.TextBox();
            this.txtContractType = new System.Windows.Forms.TextBox();
            this.txtContractEndDate = new System.Windows.Forms.TextBox();
            this.txtContractStartDate = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gpbOtherDetail = new System.Windows.Forms.GroupBox();
            this.cboToDay = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboFromDay = new System.Windows.Forms.ComboBox();
            this.rtbRemark = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gpbSearch = new System.Windows.Forms.GroupBox();
            this.txtContractNoXXX = new System.Windows.Forms.TextBox();
            this.txtContractNoMM = new System.Windows.Forms.TextBox();
            this.txtContractNoYY = new System.Windows.Forms.TextBox();
            this.cmbCustomerName = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.crvReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.gpbTISDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFamilyRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCommonRate)).BeginInit();
            this.gpbContractDetail.SuspendLayout();
            this.gpbOtherDetail.SuspendLayout();
            this.gpbSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbTISDetail
            // 
            this.gpbTISDetail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpbTISDetail.Controls.Add(this.label1);
            this.gpbTISDetail.Controls.Add(this.numFamilyRate);
            this.gpbTISDetail.Controls.Add(this.txtCommonDriver);
            this.gpbTISDetail.Controls.Add(this.numCommonRate);
            this.gpbTISDetail.Controls.Add(this.label7);
            this.gpbTISDetail.Controls.Add(this.label2);
            this.gpbTISDetail.Controls.Add(this.txtFamilyDriver);
            this.gpbTISDetail.Controls.Add(this.label8);
            this.gpbTISDetail.Location = new System.Drawing.Point(108, 128);
            this.gpbTISDetail.Name = "gpbTISDetail";
            this.gpbTISDetail.Size = new System.Drawing.Size(704, 48);
            this.gpbTISDetail.TabIndex = 1;
            this.gpbTISDetail.TabStop = false;
            this.gpbTISDetail.Text = "TIS Agreement Detail";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 121;
            this.label1.Text = "# of Common driver";
            // 
            // numFamilyRate
            // 
            this.numFamilyRate.DecimalPlaces = 2;
            this.numFamilyRate.Location = new System.Drawing.Point(594, 20);
            this.numFamilyRate.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            131072});
            this.numFamilyRate.Name = "numFamilyRate";
            this.numFamilyRate.Size = new System.Drawing.Size(72, 20);
            this.numFamilyRate.TabIndex = 3;
            this.numFamilyRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCommonDriver
            // 
            this.txtCommonDriver.Location = new System.Drawing.Point(114, 20);
            this.txtCommonDriver.Name = "txtCommonDriver";
            this.txtCommonDriver.Size = new System.Drawing.Size(64, 20);
            this.txtCommonDriver.TabIndex = 0;
            this.txtCommonDriver.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCommonDriver.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCommonDriver_KeyPress);
            // 
            // numCommonRate
            // 
            this.numCommonRate.DecimalPlaces = 2;
            this.numCommonRate.Location = new System.Drawing.Point(258, 20);
            this.numCommonRate.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            131072});
            this.numCommonRate.Name = "numCommonRate";
            this.numCommonRate.Size = new System.Drawing.Size(72, 20);
            this.numCommonRate.TabIndex = 1;
            this.numCommonRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(183, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 132;
            this.label7.Text = "Common rate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(356, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 134;
            this.label2.Text = "# of Family driver";
            // 
            // txtFamilyDriver
            // 
            this.txtFamilyDriver.Location = new System.Drawing.Point(450, 20);
            this.txtFamilyDriver.Name = "txtFamilyDriver";
            this.txtFamilyDriver.Size = new System.Drawing.Size(64, 20);
            this.txtFamilyDriver.TabIndex = 2;
            this.txtFamilyDriver.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFamilyDriver.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFamilyDriver_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(531, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 136;
            this.label8.Text = "Family rate";
            // 
            // gpbContractDetail
            // 
            this.gpbContractDetail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpbContractDetail.Controls.Add(this.txtCustomerName);
            this.gpbContractDetail.Controls.Add(this.txtContractsts);
            this.gpbContractDetail.Controls.Add(this.txtContractType);
            this.gpbContractDetail.Controls.Add(this.txtContractEndDate);
            this.gpbContractDetail.Controls.Add(this.txtContractStartDate);
            this.gpbContractDetail.Controls.Add(this.label13);
            this.gpbContractDetail.Controls.Add(this.label12);
            this.gpbContractDetail.Controls.Add(this.label11);
            this.gpbContractDetail.Controls.Add(this.label6);
            this.gpbContractDetail.Controls.Add(this.label5);
            this.gpbContractDetail.Location = new System.Drawing.Point(108, 56);
            this.gpbContractDetail.Name = "gpbContractDetail";
            this.gpbContractDetail.Size = new System.Drawing.Size(704, 72);
            this.gpbContractDetail.TabIndex = 3;
            this.gpbContractDetail.TabStop = false;
            this.gpbContractDetail.Text = "Detail of Contract";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(328, 40);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(149, 20);
            this.txtCustomerName.TabIndex = 152;
            // 
            // txtContractsts
            // 
            this.txtContractsts.Location = new System.Drawing.Point(112, 40);
            this.txtContractsts.Name = "txtContractsts";
            this.txtContractsts.ReadOnly = true;
            this.txtContractsts.Size = new System.Drawing.Size(149, 20);
            this.txtContractsts.TabIndex = 151;
            // 
            // txtContractType
            // 
            this.txtContractType.Location = new System.Drawing.Point(536, 16);
            this.txtContractType.Name = "txtContractType";
            this.txtContractType.ReadOnly = true;
            this.txtContractType.Size = new System.Drawing.Size(149, 20);
            this.txtContractType.TabIndex = 150;
            // 
            // txtContractEndDate
            // 
            this.txtContractEndDate.Location = new System.Drawing.Point(328, 16);
            this.txtContractEndDate.Name = "txtContractEndDate";
            this.txtContractEndDate.ReadOnly = true;
            this.txtContractEndDate.Size = new System.Drawing.Size(96, 20);
            this.txtContractEndDate.TabIndex = 149;
            // 
            // txtContractStartDate
            // 
            this.txtContractStartDate.Location = new System.Drawing.Point(112, 16);
            this.txtContractStartDate.Name = "txtContractStartDate";
            this.txtContractStartDate.ReadOnly = true;
            this.txtContractStartDate.Size = new System.Drawing.Size(88, 20);
            this.txtContractStartDate.TabIndex = 148;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(272, 44);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 13);
            this.label13.TabIndex = 147;
            this.label13.Text = "Customer";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(25, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 13);
            this.label12.TabIndex = 145;
            this.label12.Text = "Contract Status";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(456, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 13);
            this.label11.TabIndex = 143;
            this.label11.Text = "Contract Type";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(272, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 140;
            this.label6.Text = "End Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 139;
            this.label5.Text = "Start Date";
            // 
            // gpbOtherDetail
            // 
            this.gpbOtherDetail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpbOtherDetail.Controls.Add(this.cboToDay);
            this.gpbOtherDetail.Controls.Add(this.label4);
            this.gpbOtherDetail.Controls.Add(this.cboFromDay);
            this.gpbOtherDetail.Controls.Add(this.rtbRemark);
            this.gpbOtherDetail.Controls.Add(this.label9);
            this.gpbOtherDetail.Controls.Add(this.label3);
            this.gpbOtherDetail.Location = new System.Drawing.Point(108, 176);
            this.gpbOtherDetail.Name = "gpbOtherDetail";
            this.gpbOtherDetail.Size = new System.Drawing.Size(704, 48);
            this.gpbOtherDetail.TabIndex = 2;
            this.gpbOtherDetail.TabStop = false;
            this.gpbOtherDetail.Text = "Fill in Agreement";
            // 
            // cboToDay
            // 
            this.cboToDay.FormattingEnabled = true;
            this.cboToDay.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.cboToDay.Location = new System.Drawing.Point(216, 20);
            this.cboToDay.Name = "cboToDay";
            this.cboToDay.Size = new System.Drawing.Size(88, 21);
            this.cboToDay.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(192, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 145;
            this.label4.Text = "- To";
            // 
            // cboFromDay
            // 
            this.cboFromDay.FormattingEnabled = true;
            this.cboFromDay.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.cboFromDay.Location = new System.Drawing.Point(104, 20);
            this.cboFromDay.Name = "cboFromDay";
            this.cboFromDay.Size = new System.Drawing.Size(88, 21);
            this.cboFromDay.TabIndex = 0;
            // 
            // rtbRemark
            // 
            this.rtbRemark.Location = new System.Drawing.Point(368, 20);
            this.rtbRemark.MaxLength = 200;
            this.rtbRemark.Name = "rtbRemark";
            this.rtbRemark.Size = new System.Drawing.Size(328, 20);
            this.rtbRemark.TabIndex = 2;
            this.rtbRemark.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(320, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 142;
            this.label9.Text = "Remark";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 138;
            this.label3.Text = "Working Day From";
            // 
            // gpbSearch
            // 
            this.gpbSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpbSearch.Controls.Add(this.txtContractNoXXX);
            this.gpbSearch.Controls.Add(this.txtContractNoMM);
            this.gpbSearch.Controls.Add(this.txtContractNoYY);
            this.gpbSearch.Controls.Add(this.cmbCustomerName);
            this.gpbSearch.Controls.Add(this.label14);
            this.gpbSearch.Controls.Add(this.btnPrint);
            this.gpbSearch.Controls.Add(this.btnSearch);
            this.gpbSearch.Controls.Add(this.label10);
            this.gpbSearch.Location = new System.Drawing.Point(108, 8);
            this.gpbSearch.Name = "gpbSearch";
            this.gpbSearch.Size = new System.Drawing.Size(704, 47);
            this.gpbSearch.TabIndex = 0;
            this.gpbSearch.TabStop = false;
            this.gpbSearch.Text = "Contract selection";
            // 
            // txtContractNoXXX
            // 
            this.txtContractNoXXX.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtContractNoXXX.Location = new System.Drawing.Point(488, 16);
            this.txtContractNoXXX.MaxLength = 3;
            this.txtContractNoXXX.Name = "txtContractNoXXX";
            this.txtContractNoXXX.Size = new System.Drawing.Size(38, 20);
            this.txtContractNoXXX.TabIndex = 3;
            this.txtContractNoXXX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtContractNoXXX.DoubleClick += new System.EventHandler(this.txtContractNoXXX_DoubleClick);
            this.txtContractNoXXX.TextChanged += new System.EventHandler(this.txtContractNoXXX_TextChanged);
            // 
            // txtContractNoMM
            // 
            this.txtContractNoMM.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtContractNoMM.Location = new System.Drawing.Point(456, 16);
            this.txtContractNoMM.MaxLength = 2;
            this.txtContractNoMM.Name = "txtContractNoMM";
            this.txtContractNoMM.Size = new System.Drawing.Size(32, 20);
            this.txtContractNoMM.TabIndex = 2;
            this.txtContractNoMM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtContractNoMM.TextChanged += new System.EventHandler(this.txtContractNoMM_TextChanged);
            // 
            // txtContractNoYY
            // 
            this.txtContractNoYY.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtContractNoYY.Location = new System.Drawing.Point(424, 16);
            this.txtContractNoYY.MaxLength = 2;
            this.txtContractNoYY.Name = "txtContractNoYY";
            this.txtContractNoYY.Size = new System.Drawing.Size(32, 20);
            this.txtContractNoYY.TabIndex = 1;
            this.txtContractNoYY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtContractNoYY.TextChanged += new System.EventHandler(this.txtContractNoYY_TextChanged);
            // 
            // cmbCustomerName
            // 
            this.cmbCustomerName.DisplayMember = "English_Name";
            this.cmbCustomerName.FormattingEnabled = true;
            this.cmbCustomerName.Location = new System.Drawing.Point(112, 16);
            this.cmbCustomerName.Name = "cmbCustomerName";
            this.cmbCustomerName.Size = new System.Drawing.Size(204, 21);
            this.cmbCustomerName.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(54, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 13);
            this.label14.TabIndex = 148;
            this.label14.Text = "Customer";
            // 
            // btnPrint
            // 
            this.btnPrint.ForeColor = System.Drawing.Color.Blue;
            this.btnPrint.Location = new System.Drawing.Point(616, 15);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "พิมพ์";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.ForeColor = System.Drawing.Color.Blue;
            this.btnSearch.Location = new System.Drawing.Point(536, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "ค้นหา";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(325, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 13);
            this.label10.TabIndex = 136;
            this.label10.Text = "Contract # PTB-D-";
            // 
            // crvReport
            // 
            this.crvReport.ActiveViewIndex = -1;
            this.crvReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReport.DisplayGroupTree = false;
            this.crvReport.Location = new System.Drawing.Point(0, 232);
            this.crvReport.Name = "crvReport";
            this.crvReport.ShowGroupTreeButton = false;
            this.crvReport.ShowRefreshButton = false;
            this.crvReport.Size = new System.Drawing.Size(920, 178);
            this.crvReport.TabIndex = 143;
            // 
            // FrmReportDriverAgreement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 410);
            this.Controls.Add(this.gpbSearch);
            this.Controls.Add(this.gpbContractDetail);
            this.Controls.Add(this.gpbTISDetail);
            this.Controls.Add(this.crvReport);
            this.Controls.Add(this.gpbOtherDetail);
            this.Name = "FrmReportDriverAgreement";
            this.Text = "Driver Agreement";
            this.Load += new System.EventHandler(this.FrmReportDriverAgreement_Load);
            this.gpbTISDetail.ResumeLayout(false);
            this.gpbTISDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFamilyRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCommonRate)).EndInit();
            this.gpbContractDetail.ResumeLayout(false);
            this.gpbContractDetail.PerformLayout();
            this.gpbOtherDetail.ResumeLayout(false);
            this.gpbOtherDetail.PerformLayout();
            this.gpbSearch.ResumeLayout(false);
            this.gpbSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbContractDetail;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtContractsts;
        private System.Windows.Forms.TextBox txtContractType;
        private System.Windows.Forms.TextBox txtContractEndDate;
        private System.Windows.Forms.TextBox txtContractStartDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gpbOtherDetail;
        private System.Windows.Forms.NumericUpDown numFamilyRate;
        private System.Windows.Forms.NumericUpDown numCommonRate;
        private System.Windows.Forms.RichTextBox rtbRemark;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFamilyDriver;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCommonDriver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gpbSearch;
        protected internal System.Windows.Forms.TextBox txtContractNoXXX;
        protected internal System.Windows.Forms.TextBox txtContractNoMM;
        protected internal System.Windows.Forms.TextBox txtContractNoYY;
        private System.Windows.Forms.ComboBox cmbCustomerName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label10;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReport;
        private System.Windows.Forms.GroupBox gpbTISDetail;
        private System.Windows.Forms.ComboBox cboToDay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboFromDay;
    }
}