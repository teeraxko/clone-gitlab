namespace Report.GUI.Vehicle
{
    partial class FrmReportApplicationSelling
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpSellingFrom = new System.Windows.Forms.DateTimePicker();
            this.cmdBrand = new System.Windows.Forms.ComboBox();
            this.btnRetiveData = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpSellingTo = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
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
            this.crvReport.Location = new System.Drawing.Point(16, 144);
            this.crvReport.Name = "crvReport";
            this.crvReport.ShowGroupTreeButton = false;
            this.crvReport.ShowRefreshButton = false;
            this.crvReport.Size = new System.Drawing.Size(632, 344);
            this.crvReport.TabIndex = 21;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpSellingFrom);
            this.groupBox1.Controls.Add(this.cmdBrand);
            this.groupBox1.Controls.Add(this.btnRetiveData);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpSellingTo);
            this.groupBox1.Location = new System.Drawing.Point(160, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 120);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selection for Report";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Selling Date From";
            // 
            // dtpSellingFrom
            // 
            this.dtpSellingFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpSellingFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSellingFrom.Location = new System.Drawing.Point(112, 56);
            this.dtpSellingFrom.Name = "dtpSellingFrom";
            this.dtpSellingFrom.Size = new System.Drawing.Size(112, 20);
            this.dtpSellingFrom.TabIndex = 17;
            // 
            // cmdBrand
            // 
            this.cmdBrand.DisplayMember = "Brand_English_Name";
            this.cmdBrand.FormattingEnabled = true;
            this.cmdBrand.Location = new System.Drawing.Point(112, 24);
            this.cmdBrand.Name = "cmdBrand";
            this.cmdBrand.Size = new System.Drawing.Size(223, 21);
            this.cmdBrand.TabIndex = 16;
            this.cmdBrand.ValueMember = "Brand_Code";
            // 
            // btnRetiveData
            // 
            this.btnRetiveData.Location = new System.Drawing.Point(264, 88);
            this.btnRetiveData.Name = "btnRetiveData";
            this.btnRetiveData.Size = new System.Drawing.Size(75, 23);
            this.btnRetiveData.TabIndex = 15;
            this.btnRetiveData.Text = "ดูข้อมูล";
            this.btnRetiveData.UseVisualStyleBackColor = true;
            this.btnRetiveData.Click += new System.EventHandler(this.btnRetiveData_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Selling Date To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Brand";
            // 
            // dtpSellingTo
            // 
            this.dtpSellingTo.CustomFormat = "dd/MM/yyyy";
            this.dtpSellingTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSellingTo.Location = new System.Drawing.Point(112, 88);
            this.dtpSellingTo.Name = "dtpSellingTo";
            this.dtpSellingTo.Size = new System.Drawing.Size(112, 20);
            this.dtpSellingTo.TabIndex = 12;
            // 
            // FrmReportApplicationSelling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 504);
            this.Controls.Add(this.crvReport);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmReportApplicationSelling";
            this.Text = "Application for Selling Vehicle Report";
            this.Load += new System.EventHandler(this.FrmReportApplicationSelling_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpSellingFrom;
        private System.Windows.Forms.ComboBox cmdBrand;
        private System.Windows.Forms.Button btnRetiveData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpSellingTo;
    }
}