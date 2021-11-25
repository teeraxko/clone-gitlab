namespace Report.GUI.Contract {
    partial class FrmContractServiceAgreement {
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
            this.cmbWorkingDayPeriod = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.crvMain = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnRetiveData = new System.Windows.Forms.Button();
            this.ปี = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.numCommonCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numFamilyCount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numFamilyRate = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numCommonRate = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCommonCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFamilyCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFamilyRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCommonRate)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbWorkingDayPeriod
            // 
            this.cmbWorkingDayPeriod.FormattingEnabled = true;
            this.cmbWorkingDayPeriod.Items.AddRange(new object[] {
            "Monday - Friday",
            "Monday - Saturday",
            "Monday - Sunday"});
            this.cmbWorkingDayPeriod.Location = new System.Drawing.Point(194, 9);
            this.cmbWorkingDayPeriod.Name = "cmbWorkingDayPeriod";
            this.cmbWorkingDayPeriod.Size = new System.Drawing.Size(165, 21);
            this.cmbWorkingDayPeriod.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "ช่วงวันทำงาน";
            // 
            // crvMain
            // 
            this.crvMain.ActiveViewIndex = -1;
            this.crvMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvMain.DisplayGroupTree = false;
            this.crvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvMain.Location = new System.Drawing.Point(0, 91);
            this.crvMain.Name = "crvMain";
            this.crvMain.ShowGroupTreeButton = false;
            this.crvMain.ShowRefreshButton = false;
            this.crvMain.Size = new System.Drawing.Size(747, 387);
            this.crvMain.TabIndex = 12;
            // 
            // btnRetiveData
            // 
            this.btnRetiveData.Location = new System.Drawing.Point(408, 7);
            this.btnRetiveData.Name = "btnRetiveData";
            this.btnRetiveData.Size = new System.Drawing.Size(75, 23);
            this.btnRetiveData.TabIndex = 10;
            this.btnRetiveData.Text = "แสดงข้อมูล";
            this.btnRetiveData.UseVisualStyleBackColor = true;
            this.btnRetiveData.Click += new System.EventHandler(this.btnRetiveData_Click);
            // 
            // ปี
            // 
            this.ปี.AutoSize = true;
            this.ปี.Location = new System.Drawing.Point(12, 15);
            this.ปี.Name = "ปี";
            this.ปี.Size = new System.Drawing.Size(14, 13);
            this.ปี.TabIndex = 7;
            this.ปี.Text = "ปี";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numFamilyRate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numCommonRate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numFamilyCount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numCommonCount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numYear);
            this.groupBox1.Controls.Add(this.cmbWorkingDayPeriod);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnRetiveData);
            this.groupBox1.Controls.Add(this.ปี);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(747, 91);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // numYear
            // 
            this.numYear.Location = new System.Drawing.Point(32, 10);
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(74, 20);
            this.numYear.TabIndex = 14;
            // 
            // numCommonCount
            // 
            this.numCommonCount.Location = new System.Drawing.Point(155, 36);
            this.numCommonCount.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numCommonCount.Name = "numCommonCount";
            this.numCommonCount.Size = new System.Drawing.Size(54, 20);
            this.numCommonCount.TabIndex = 16;
            this.numCommonCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "จำนวน Common car driver";
            // 
            // numFamilyCount
            // 
            this.numFamilyCount.Location = new System.Drawing.Point(155, 59);
            this.numFamilyCount.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numFamilyCount.Name = "numFamilyCount";
            this.numFamilyCount.Size = new System.Drawing.Size(54, 20);
            this.numFamilyCount.TabIndex = 18;
            this.numFamilyCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "จำนวน Family car driver";
            // 
            // numFamilyRate
            // 
            this.numFamilyRate.DecimalPlaces = 2;
            this.numFamilyRate.Location = new System.Drawing.Point(408, 60);
            this.numFamilyRate.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numFamilyRate.Name = "numFamilyRate";
            this.numFamilyRate.Size = new System.Drawing.Size(74, 20);
            this.numFamilyRate.TabIndex = 22;
            this.numFamilyRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numFamilyRate.ThousandsSeparator = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(262, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Family car driver charge rate";
            // 
            // numCommonRate
            // 
            this.numCommonRate.DecimalPlaces = 2;
            this.numCommonRate.Location = new System.Drawing.Point(408, 36);
            this.numCommonRate.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numCommonRate.Name = "numCommonRate";
            this.numCommonRate.Size = new System.Drawing.Size(74, 20);
            this.numCommonRate.TabIndex = 20;
            this.numCommonRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numCommonRate.ThousandsSeparator = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(250, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Common car driver charge rate";
            // 
            // FrmContractServiceAgreement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 478);
            this.Controls.Add(this.crvMain);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmContractServiceAgreement";
            this.Text = "Service Agreement of Driver";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCommonCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFamilyCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFamilyRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCommonRate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbWorkingDayPeriod;
        private System.Windows.Forms.Label label2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvMain;
        private System.Windows.Forms.Button btnRetiveData;
        private System.Windows.Forms.Label ปี;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.NumericUpDown numFamilyRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numCommonRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numFamilyCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numCommonCount;
        private System.Windows.Forms.Label label1;
    }
}