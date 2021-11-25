namespace Report.GUI.Vehicle
{
    partial class FrmReportVehicleSelling
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpSellingFrom = new System.Windows.Forms.DateTimePicker();
            this.cmdBrand = new System.Windows.Forms.ComboBox();
            this.btnRetiveData = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpSellingTo = new System.Windows.Forms.DateTimePicker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.crvVehicle = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.crvApplication = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
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
            this.groupBox1.Location = new System.Drawing.Point(184, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 120);
            this.groupBox1.TabIndex = 18;
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
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(8, 136);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(696, 352);
            this.tabControl1.TabIndex = 20;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.crvVehicle);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(688, 326);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Vehicle Selling";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.crvApplication);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(688, 326);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Application Selling";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // crvVehicle
            // 
            this.crvVehicle.ActiveViewIndex = -1;
            this.crvVehicle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvVehicle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvVehicle.DisplayGroupTree = false;
            this.crvVehicle.DisplayStatusBar = false;
            this.crvVehicle.DisplayToolbar = false;
            this.crvVehicle.Location = new System.Drawing.Point(8, 8);
            this.crvVehicle.Name = "crvVehicle";
            this.crvVehicle.ShowGroupTreeButton = false;
            this.crvVehicle.ShowRefreshButton = false;
            this.crvVehicle.Size = new System.Drawing.Size(672, 304);
            this.crvVehicle.TabIndex = 20;
            // 
            // crvApplication
            // 
            this.crvApplication.ActiveViewIndex = -1;
            this.crvApplication.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvApplication.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvApplication.DisplayGroupTree = false;
            this.crvApplication.Location = new System.Drawing.Point(8, 11);
            this.crvApplication.Name = "crvApplication";
            this.crvApplication.ShowGroupTreeButton = false;
            this.crvApplication.ShowRefreshButton = false;
            this.crvApplication.Size = new System.Drawing.Size(672, 304);
            this.crvApplication.TabIndex = 21;
            // 
            // FrmReportVehicleSelling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 501);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmReportVehicleSelling";
            this.Text = "Vehicle Selling Report";
            this.Load += new System.EventHandler(this.FrmReportVehicleSelling_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmdBrand;
        private System.Windows.Forms.Button btnRetiveData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpSellingTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpSellingFrom;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvVehicle;
        private System.Windows.Forms.TabPage tabPage2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvApplication;
    }
}