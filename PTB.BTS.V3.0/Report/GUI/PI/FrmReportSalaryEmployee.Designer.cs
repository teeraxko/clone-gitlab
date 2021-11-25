namespace Report.GUI.PI {
    partial class FrmReportSalaryEmployee {
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
            this.btnRetiveData = new System.Windows.Forms.Button();
            this.crvMain = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numSalaryTo = new System.Windows.Forms.NumericUpDown();
            this.rbtnSpecTo = new System.Windows.Forms.RadioButton();
            this.rbtnNoSpecTo = new System.Windows.Forms.RadioButton();
            this.grpSalaryFrom = new System.Windows.Forms.GroupBox();
            this.numSalaryFrom = new System.Windows.Forms.NumericUpDown();
            this.rbtnSpecFrom = new System.Windows.Forms.RadioButton();
            this.rbtnNoSpecFrom = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSalaryTo)).BeginInit();
            this.grpSalaryFrom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSalaryFrom)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRetiveData
            // 
            this.btnRetiveData.Location = new System.Drawing.Point(296, 19);
            this.btnRetiveData.Name = "btnRetiveData";
            this.btnRetiveData.Size = new System.Drawing.Size(75, 23);
            this.btnRetiveData.TabIndex = 2;
            this.btnRetiveData.Text = "แสดงข้อมูล";
            this.btnRetiveData.UseVisualStyleBackColor = true;
            this.btnRetiveData.Click += new System.EventHandler(this.btnRetiveData_Click);
            // 
            // crvMain
            // 
            this.crvMain.ActiveViewIndex = -1;
            this.crvMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvMain.DisplayGroupTree = false;
            this.crvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvMain.Location = new System.Drawing.Point(0, 90);
            this.crvMain.Name = "crvMain";
            this.crvMain.ShowGroupTreeButton = false;
            this.crvMain.ShowRefreshButton = false;
            this.crvMain.Size = new System.Drawing.Size(618, 393);
            this.crvMain.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.grpSalaryFrom);
            this.groupBox1.Controls.Add(this.btnRetiveData);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(618, 90);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numSalaryTo);
            this.groupBox2.Controls.Add(this.rbtnSpecTo);
            this.groupBox2.Controls.Add(this.rbtnNoSpecTo);
            this.groupBox2.Location = new System.Drawing.Point(154, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(136, 67);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ข้อมูลเงินเดือนไม่เกิน";
            // 
            // numSalaryTo
            // 
            this.numSalaryTo.DecimalPlaces = 2;
            this.numSalaryTo.Enabled = false;
            this.numSalaryTo.Location = new System.Drawing.Point(26, 40);
            this.numSalaryTo.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numSalaryTo.Name = "numSalaryTo";
            this.numSalaryTo.Size = new System.Drawing.Size(98, 20);
            this.numSalaryTo.TabIndex = 1;
            this.numSalaryTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSalaryTo.ThousandsSeparator = true;
            // 
            // rbtnSpecTo
            // 
            this.rbtnSpecTo.AutoSize = true;
            this.rbtnSpecTo.Location = new System.Drawing.Point(6, 42);
            this.rbtnSpecTo.Name = "rbtnSpecTo";
            this.rbtnSpecTo.Size = new System.Drawing.Size(14, 13);
            this.rbtnSpecTo.TabIndex = 1;
            this.rbtnSpecTo.UseVisualStyleBackColor = true;
            // 
            // rbtnNoSpecTo
            // 
            this.rbtnNoSpecTo.AutoSize = true;
            this.rbtnNoSpecTo.Checked = true;
            this.rbtnNoSpecTo.Location = new System.Drawing.Point(6, 19);
            this.rbtnNoSpecTo.Name = "rbtnNoSpecTo";
            this.rbtnNoSpecTo.Size = new System.Drawing.Size(56, 17);
            this.rbtnNoSpecTo.TabIndex = 0;
            this.rbtnNoSpecTo.TabStop = true;
            this.rbtnNoSpecTo.Text = "ไม่ระบุ";
            this.rbtnNoSpecTo.UseVisualStyleBackColor = true;
            this.rbtnNoSpecTo.CheckedChanged += new System.EventHandler(this.rbtnNoSpecTo_CheckedChanged);
            // 
            // grpSalaryFrom
            // 
            this.grpSalaryFrom.Controls.Add(this.numSalaryFrom);
            this.grpSalaryFrom.Controls.Add(this.rbtnSpecFrom);
            this.grpSalaryFrom.Controls.Add(this.rbtnNoSpecFrom);
            this.grpSalaryFrom.Location = new System.Drawing.Point(12, 12);
            this.grpSalaryFrom.Name = "grpSalaryFrom";
            this.grpSalaryFrom.Size = new System.Drawing.Size(136, 67);
            this.grpSalaryFrom.TabIndex = 0;
            this.grpSalaryFrom.TabStop = false;
            this.grpSalaryFrom.Text = "ข้อมูลเงินเดือนตั้งแต่";
            // 
            // numSalaryFrom
            // 
            this.numSalaryFrom.DecimalPlaces = 2;
            this.numSalaryFrom.Enabled = false;
            this.numSalaryFrom.Location = new System.Drawing.Point(26, 40);
            this.numSalaryFrom.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numSalaryFrom.Name = "numSalaryFrom";
            this.numSalaryFrom.Size = new System.Drawing.Size(98, 20);
            this.numSalaryFrom.TabIndex = 1;
            this.numSalaryFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSalaryFrom.ThousandsSeparator = true;
            // 
            // rbtnSpecFrom
            // 
            this.rbtnSpecFrom.AutoSize = true;
            this.rbtnSpecFrom.Location = new System.Drawing.Point(6, 42);
            this.rbtnSpecFrom.Name = "rbtnSpecFrom";
            this.rbtnSpecFrom.Size = new System.Drawing.Size(14, 13);
            this.rbtnSpecFrom.TabIndex = 1;
            this.rbtnSpecFrom.UseVisualStyleBackColor = true;
            // 
            // rbtnNoSpecFrom
            // 
            this.rbtnNoSpecFrom.AutoSize = true;
            this.rbtnNoSpecFrom.Checked = true;
            this.rbtnNoSpecFrom.Location = new System.Drawing.Point(6, 19);
            this.rbtnNoSpecFrom.Name = "rbtnNoSpecFrom";
            this.rbtnNoSpecFrom.Size = new System.Drawing.Size(56, 17);
            this.rbtnNoSpecFrom.TabIndex = 0;
            this.rbtnNoSpecFrom.TabStop = true;
            this.rbtnNoSpecFrom.Text = "ไม่ระบุ";
            this.rbtnNoSpecFrom.UseVisualStyleBackColor = true;
            this.rbtnNoSpecFrom.CheckedChanged += new System.EventHandler(this.rbtnNoSpecFrom_CheckedChanged);
            // 
            // FrmReportSalaryEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 483);
            this.Controls.Add(this.crvMain);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmReportSalaryEmployee";
            this.Text = "FrmReportSalaryEmployee";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSalaryTo)).EndInit();
            this.grpSalaryFrom.ResumeLayout(false);
            this.grpSalaryFrom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSalaryFrom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRetiveData;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpSalaryFrom;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numSalaryTo;
        private System.Windows.Forms.RadioButton rbtnSpecTo;
        private System.Windows.Forms.RadioButton rbtnNoSpecTo;
        private System.Windows.Forms.NumericUpDown numSalaryFrom;
        private System.Windows.Forms.RadioButton rbtnSpecFrom;
        private System.Windows.Forms.RadioButton rbtnNoSpecFrom;
    }
}