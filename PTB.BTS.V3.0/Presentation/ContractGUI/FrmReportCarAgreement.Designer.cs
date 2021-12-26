namespace Presentation.ContractGUI
{
    partial class FrmReportCarAgreement
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
            this.gpbOtherDetail = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAccessory = new System.Windows.Forms.TextBox();
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
            this.gpbSearchDetail = new System.Windows.Forms.GroupBox();
            this.txtContractNoXXX = new System.Windows.Forms.TextBox();
            this.txtContractNoMM = new System.Windows.Forms.TextBox();
            this.txtContractNoYY = new System.Windows.Forms.TextBox();
            this.cmbCustomerName = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.crvReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.cboVehicleKindContract = new System.Windows.Forms.ComboBox();
            this.gpbOtherDetail.SuspendLayout();
            this.gpbContractDetail.SuspendLayout();
            this.gpbSearchDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbOtherDetail
            // 
            this.gpbOtherDetail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpbOtherDetail.Controls.Add(this.label1);
            this.gpbOtherDetail.Controls.Add(this.txtAccessory);
            this.gpbOtherDetail.Controls.Add(this.gpbContractDetail);
            this.gpbOtherDetail.Location = new System.Drawing.Point(16, 56);
            this.gpbOtherDetail.Name = "gpbOtherDetail";
            this.gpbOtherDetail.Size = new System.Drawing.Size(768, 144);
            this.gpbOtherDetail.TabIndex = 144;
            this.gpbOtherDetail.TabStop = false;
            this.gpbOtherDetail.Text = "Detail";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 148;
            this.label1.Text = "Car Accessory";
            // 
            // txtAccessory
            // 
            this.txtAccessory.Location = new System.Drawing.Point(104, 108);
            this.txtAccessory.MaxLength = 200;
            this.txtAccessory.Name = "txtAccessory";
            this.txtAccessory.Size = new System.Drawing.Size(392, 20);
            this.txtAccessory.TabIndex = 144;
            this.txtAccessory.Text = "One set of car radio and CD player";
            // 
            // gpbContractDetail
            // 
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
            this.gpbContractDetail.Location = new System.Drawing.Point(8, 24);
            this.gpbContractDetail.Name = "gpbContractDetail";
            this.gpbContractDetail.Size = new System.Drawing.Size(752, 72);
            this.gpbContractDetail.TabIndex = 143;
            this.gpbContractDetail.TabStop = false;
            this.gpbContractDetail.Text = "Detail of Contract";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(304, 40);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(176, 20);
            this.txtCustomerName.TabIndex = 152;
            // 
            // txtContractsts
            // 
            this.txtContractsts.Location = new System.Drawing.Point(96, 40);
            this.txtContractsts.Name = "txtContractsts";
            this.txtContractsts.ReadOnly = true;
            this.txtContractsts.Size = new System.Drawing.Size(120, 20);
            this.txtContractsts.TabIndex = 151;
            // 
            // txtContractType
            // 
            this.txtContractType.Location = new System.Drawing.Point(560, 16);
            this.txtContractType.Name = "txtContractType";
            this.txtContractType.ReadOnly = true;
            this.txtContractType.Size = new System.Drawing.Size(176, 20);
            this.txtContractType.TabIndex = 150;
            // 
            // txtContractEndDate
            // 
            this.txtContractEndDate.Location = new System.Drawing.Point(304, 16);
            this.txtContractEndDate.Name = "txtContractEndDate";
            this.txtContractEndDate.ReadOnly = true;
            this.txtContractEndDate.Size = new System.Drawing.Size(104, 20);
            this.txtContractEndDate.TabIndex = 149;
            // 
            // txtContractStartDate
            // 
            this.txtContractStartDate.Location = new System.Drawing.Point(96, 16);
            this.txtContractStartDate.Name = "txtContractStartDate";
            this.txtContractStartDate.ReadOnly = true;
            this.txtContractStartDate.Size = new System.Drawing.Size(120, 20);
            this.txtContractStartDate.TabIndex = 148;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(248, 44);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 13);
            this.label13.TabIndex = 147;
            this.label13.Text = "Customer";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 13);
            this.label12.TabIndex = 145;
            this.label12.Text = "Contract Status";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(480, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 13);
            this.label11.TabIndex = 143;
            this.label11.Text = "Contract Type";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(248, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 140;
            this.label6.Text = "End Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 139;
            this.label5.Text = "Start Date";
            // 
            // gpbSearchDetail
            // 
            this.gpbSearchDetail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpbSearchDetail.Controls.Add(this.cboVehicleKindContract);
            this.gpbSearchDetail.Controls.Add(this.txtContractNoXXX);
            this.gpbSearchDetail.Controls.Add(this.txtContractNoMM);
            this.gpbSearchDetail.Controls.Add(this.txtContractNoYY);
            this.gpbSearchDetail.Controls.Add(this.cmbCustomerName);
            this.gpbSearchDetail.Controls.Add(this.label14);
            this.gpbSearchDetail.Controls.Add(this.btnPrint);
            this.gpbSearchDetail.Controls.Add(this.btnSearch);
            this.gpbSearchDetail.Controls.Add(this.label10);
            this.gpbSearchDetail.Location = new System.Drawing.Point(16, 8);
            this.gpbSearchDetail.Name = "gpbSearchDetail";
            this.gpbSearchDetail.Size = new System.Drawing.Size(768, 47);
            this.gpbSearchDetail.TabIndex = 141;
            this.gpbSearchDetail.TabStop = false;
            this.gpbSearchDetail.Text = "Contract selection";
            // 
            // txtContractNoXXX
            // 
            this.txtContractNoXXX.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtContractNoXXX.Location = new System.Drawing.Point(524, 17);
            this.txtContractNoXXX.MaxLength = 3;
            this.txtContractNoXXX.Name = "txtContractNoXXX";
            this.txtContractNoXXX.Size = new System.Drawing.Size(38, 20);
            this.txtContractNoXXX.TabIndex = 155;
            this.txtContractNoXXX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtContractNoXXX.DoubleClick += new System.EventHandler(this.txtContractNoXXX_DoubleClick);
            this.txtContractNoXXX.TextChanged += new System.EventHandler(this.txtContractNoXXX_TextChanged);
            // 
            // txtContractNoMM
            // 
            this.txtContractNoMM.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtContractNoMM.Location = new System.Drawing.Point(492, 17);
            this.txtContractNoMM.MaxLength = 2;
            this.txtContractNoMM.Name = "txtContractNoMM";
            this.txtContractNoMM.Size = new System.Drawing.Size(32, 20);
            this.txtContractNoMM.TabIndex = 154;
            this.txtContractNoMM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtContractNoMM.TextChanged += new System.EventHandler(this.txtContractNoMM_TextChanged);
            // 
            // txtContractNoYY
            // 
            this.txtContractNoYY.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtContractNoYY.Location = new System.Drawing.Point(460, 17);
            this.txtContractNoYY.MaxLength = 2;
            this.txtContractNoYY.Name = "txtContractNoYY";
            this.txtContractNoYY.Size = new System.Drawing.Size(32, 20);
            this.txtContractNoYY.TabIndex = 153;
            this.txtContractNoYY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtContractNoYY.TextChanged += new System.EventHandler(this.txtContractNoYY_TextChanged);
            // 
            // cmbCustomerName
            // 
            this.cmbCustomerName.DisplayMember = "English_Name";
            this.cmbCustomerName.FormattingEnabled = true;
            this.cmbCustomerName.Location = new System.Drawing.Point(96, 16);
            this.cmbCustomerName.Name = "cmbCustomerName";
            this.cmbCustomerName.Size = new System.Drawing.Size(200, 21);
            this.cmbCustomerName.TabIndex = 149;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(37, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 13);
            this.label14.TabIndex = 148;
            this.label14.Text = "Customer";
            // 
            // btnPrint
            // 
            this.btnPrint.ForeColor = System.Drawing.Color.Blue;
            this.btnPrint.Location = new System.Drawing.Point(654, 15);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(72, 23);
            this.btnPrint.TabIndex = 142;
            this.btnPrint.Text = "พิมพ์";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.ForeColor = System.Drawing.Color.Blue;
            this.btnSearch.Location = new System.Drawing.Point(574, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(72, 23);
            this.btnSearch.TabIndex = 140;
            this.btnSearch.Text = "ค้นหา";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(328, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(129, 13);
            this.label10.TabIndex = 136;
            this.label10.Text = "Contract # PTB-              -";
            // 
            // crvReport
            // 
            this.crvReport.ActiveViewIndex = -1;
            this.crvReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReport.DisplayGroupTree = false;
            this.crvReport.Location = new System.Drawing.Point(0, 208);
            this.crvReport.Name = "crvReport";
            this.crvReport.ShowGroupTreeButton = false;
            this.crvReport.ShowRefreshButton = false;
            this.crvReport.Size = new System.Drawing.Size(801, 336);
            this.crvReport.TabIndex = 145;
            // 
            // cboVehicleKindContract
            // 
            this.cboVehicleKindContract.DropDownHeight = 105;
            this.cboVehicleKindContract.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVehicleKindContract.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboVehicleKindContract.FormattingEnabled = true;
            this.cboVehicleKindContract.IntegralHeight = false;
            this.cboVehicleKindContract.Location = new System.Drawing.Point(411, 17);
            this.cboVehicleKindContract.Name = "cboVehicleKindContract";
            this.cboVehicleKindContract.Size = new System.Drawing.Size(34, 21);
            this.cboVehicleKindContract.TabIndex = 156;
            this.cboVehicleKindContract.SelectedIndexChanged += new System.EventHandler(this.cboVehicleKindContract_SelectedIndexChanged);
            // 
            // FrmReportCarAgreement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 544);
            this.Controls.Add(this.gpbOtherDetail);
            this.Controls.Add(this.crvReport);
            this.Controls.Add(this.gpbSearchDetail);
            this.Name = "FrmReportCarAgreement";
            this.Text = "Car Agreement";
            this.Load += new System.EventHandler(this.FrmReportCarAgreement_Load);
            this.gpbOtherDetail.ResumeLayout(false);
            this.gpbOtherDetail.PerformLayout();
            this.gpbContractDetail.ResumeLayout(false);
            this.gpbContractDetail.PerformLayout();
            this.gpbSearchDetail.ResumeLayout(false);
            this.gpbSearchDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbOtherDetail;
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
        private System.Windows.Forms.GroupBox gpbSearchDetail;
        private System.Windows.Forms.ComboBox cmbCustomerName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label10;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReport;
        protected internal System.Windows.Forms.TextBox txtContractNoXXX;
        protected internal System.Windows.Forms.TextBox txtContractNoMM;
        protected internal System.Windows.Forms.TextBox txtContractNoYY;
        private System.Windows.Forms.TextBox txtAccessory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboVehicleKindContract;
    }
}