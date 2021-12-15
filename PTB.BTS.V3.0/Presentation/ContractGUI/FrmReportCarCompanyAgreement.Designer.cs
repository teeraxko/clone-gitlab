namespace Presentation.ContractGUI
{
    partial class FrmReportCarCompanyAgreement
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
            this.gpbContractSearch = new System.Windows.Forms.GroupBox();
            this.dtpContractDate = new System.Windows.Forms.DateTimePicker();
            this.cboCustomerName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnContractPrint = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.crvReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.gpbContractSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbContractSearch
            // 
            this.gpbContractSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpbContractSearch.Controls.Add(this.dtpContractDate);
            this.gpbContractSearch.Controls.Add(this.cboCustomerName);
            this.gpbContractSearch.Controls.Add(this.label1);
            this.gpbContractSearch.Controls.Add(this.btnContractPrint);
            this.gpbContractSearch.Controls.Add(this.label2);
            this.gpbContractSearch.Location = new System.Drawing.Point(199, 22);
            this.gpbContractSearch.Name = "gpbContractSearch";
            this.gpbContractSearch.Size = new System.Drawing.Size(412, 88);
            this.gpbContractSearch.TabIndex = 141;
            this.gpbContractSearch.TabStop = false;
            this.gpbContractSearch.Text = "Contract selection";
            // 
            // dtpContractDate
            // 
            this.dtpContractDate.CustomFormat = "dd/MM/yyyy";
            this.dtpContractDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpContractDate.Location = new System.Drawing.Point(96, 54);
            this.dtpContractDate.Name = "dtpContractDate";
            this.dtpContractDate.Size = new System.Drawing.Size(102, 20);
            this.dtpContractDate.TabIndex = 150;
            // 
            // cboCustomerName
            // 
            this.cboCustomerName.DisplayMember = "English_Name";
            this.cboCustomerName.FormattingEnabled = true;
            this.cboCustomerName.Location = new System.Drawing.Point(94, 20);
            this.cboCustomerName.Name = "cboCustomerName";
            this.cboCustomerName.Size = new System.Drawing.Size(200, 21);
            this.cboCustomerName.TabIndex = 149;
            this.cboCustomerName.SelectedIndexChanged += new System.EventHandler(this.cboCustomerName_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 148;
            this.label1.Text = "Customer";
            // 
            // btnContractPrint
            // 
            this.btnContractPrint.ForeColor = System.Drawing.Color.Blue;
            this.btnContractPrint.Location = new System.Drawing.Point(318, 18);
            this.btnContractPrint.Name = "btnContractPrint";
            this.btnContractPrint.Size = new System.Drawing.Size(72, 23);
            this.btnContractPrint.TabIndex = 142;
            this.btnContractPrint.Text = "พิมพ์";
            this.btnContractPrint.UseVisualStyleBackColor = true;
            this.btnContractPrint.Click += new System.EventHandler(this.btnContractPrint_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 136;
            this.label2.Text = "วันที่มีผล";
            // 
            // crvReport
            // 
            this.crvReport.ActiveViewIndex = -1;
            this.crvReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReport.DisplayGroupTree = false;
            this.crvReport.Location = new System.Drawing.Point(0, 130);
            this.crvReport.Name = "crvReport";
            this.crvReport.ShowGroupTreeButton = false;
            this.crvReport.ShowRefreshButton = false;
            this.crvReport.Size = new System.Drawing.Size(801, 415);
            this.crvReport.TabIndex = 145;
            // 
            // FrmReportCarCompanyAgreement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 544);
            this.Controls.Add(this.crvReport);
            this.Controls.Add(this.gpbContractSearch);
            this.Name = "FrmReportCarCompanyAgreement";
            this.Text = "Car Agreement (Company)";
            this.Load += new System.EventHandler(this.FrmReportCarCompanyAgreement_Load);
            this.gpbContractSearch.ResumeLayout(false);
            this.gpbContractSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbContractSearch;
        private System.Windows.Forms.ComboBox cboCustomerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnContractPrint;
        private System.Windows.Forms.Label label2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReport;
        private System.Windows.Forms.DateTimePicker dtpContractDate;
    }
}