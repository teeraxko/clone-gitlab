namespace Report.GUI.Vehicle
{
    partial class FrmReportDiscountCar
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
            this.dtpMonthly = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRetiveData = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQuotation = new System.Windows.Forms.TextBox();
            this.txtPO = new System.Windows.Forms.TextBox();
            this.crvReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpMonthly
            // 
            this.dtpMonthly.Checked = false;
            this.dtpMonthly.CustomFormat = "yyyy";
            this.dtpMonthly.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMonthly.Location = new System.Drawing.Point(71, 28);
            this.dtpMonthly.Name = "dtpMonthly";
            this.dtpMonthly.ShowCheckBox = true;
            this.dtpMonthly.Size = new System.Drawing.Size(100, 20);
            this.dtpMonthly.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Monthly";
            // 
            // btnRetiveData
            // 
            this.btnRetiveData.Location = new System.Drawing.Point(186, 25);
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
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtQuotation);
            this.groupBox1.Controls.Add(this.txtPO);
            this.groupBox1.Controls.Add(this.btnRetiveData);
            this.groupBox1.Controls.Add(this.dtpMonthly);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(627, 124);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selection for Report";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Quotation";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "PO.";
            // 
            // txtQuotation
            // 
            this.txtQuotation.Location = new System.Drawing.Point(71, 81);
            this.txtQuotation.Name = "txtQuotation";
            this.txtQuotation.Size = new System.Drawing.Size(100, 20);
            this.txtQuotation.TabIndex = 17;
            // 
            // txtPO
            // 
            this.txtPO.Location = new System.Drawing.Point(71, 55);
            this.txtPO.Name = "txtPO";
            this.txtPO.Size = new System.Drawing.Size(100, 20);
            this.txtPO.TabIndex = 16;
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
            this.crvReport.Size = new System.Drawing.Size(629, 433);
            this.crvReport.TabIndex = 17;
            // 
            // FrmReportDiscountCar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 592);
            this.Controls.Add(this.crvReport);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmReportDiscountCar";
            this.Text = "Discount Car Report";
            this.Load += new System.EventHandler(this.FrmReportDiscountCar_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpMonthly;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRetiveData;
        private System.Windows.Forms.GroupBox groupBox1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReport;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQuotation;
        private System.Windows.Forms.TextBox txtPO;
    }
}