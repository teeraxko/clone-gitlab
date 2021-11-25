﻿namespace Report.GUI.Vehicle
{
    partial class FrmReportLeasingCar
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
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpContractYear = new System.Windows.Forms.DateTimePicker();
            this.dtpQuatationYear = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRetiveData = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.crvReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DisplayMember = "English_Name";
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(112, 24);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(223, 21);
            this.cmbCustomer.TabIndex = 6;
            this.cmbCustomer.ValueMember = "Customer_Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Customer";
            // 
            // dtpContractYear
            // 
            this.dtpContractYear.Checked = false;
            this.dtpContractYear.CustomFormat = "yyyy";
            this.dtpContractYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpContractYear.Location = new System.Drawing.Point(112, 56);
            this.dtpContractYear.Name = "dtpContractYear";
            this.dtpContractYear.ShowCheckBox = true;
            this.dtpContractYear.Size = new System.Drawing.Size(80, 20);
            this.dtpContractYear.TabIndex = 11;
            // 
            // dtpQuatationYear
            // 
            this.dtpQuatationYear.Checked = false;
            this.dtpQuatationYear.CustomFormat = "yyyy";
            this.dtpQuatationYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpQuatationYear.Location = new System.Drawing.Point(112, 88);
            this.dtpQuatationYear.Name = "dtpQuatationYear";
            this.dtpQuatationYear.ShowCheckBox = true;
            this.dtpQuatationYear.Size = new System.Drawing.Size(80, 20);
            this.dtpQuatationYear.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Contract Year";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Quatation Year";
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
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.cmbCustomer);
            this.groupBox1.Controls.Add(this.btnRetiveData);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpContractYear);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpQuatationYear);
            this.groupBox1.Location = new System.Drawing.Point(136, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 124);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selection for Report";
            // 
            // crvReport
            // 
            this.crvReport.ActiveViewIndex = -1;
            this.crvReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReport.DisplayGroupTree = false;
            this.crvReport.Location = new System.Drawing.Point(8, 144);
            this.crvReport.Name = "crvReport";
            this.crvReport.ShowGroupTreeButton = false;
            this.crvReport.ShowRefreshButton = false;
            this.crvReport.Size = new System.Drawing.Size(600, 352);
            this.crvReport.TabIndex = 17;
            // 
            // FrmReportLeasingCar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 511);
            this.Controls.Add(this.crvReport);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmReportLeasingCar";
            this.Text = "Leasing Car Report";
            this.Load += new System.EventHandler(this.FrmReportLeasingCar_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpContractYear;
        private System.Windows.Forms.DateTimePicker dtpQuatationYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRetiveData;
        private System.Windows.Forms.GroupBox groupBox1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReport;
    }
}