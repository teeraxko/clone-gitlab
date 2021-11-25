namespace Presentation.PiGUI
{
    partial class frmExportEmpData
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
            this.Export = new System.Windows.Forms.Button();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkNewEmp = new System.Windows.Forms.CheckBox();
            this.chkUpdateEmp = new System.Windows.Forms.CheckBox();
            this.chkResignEmp = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Export
            // 
            this.Export.Location = new System.Drawing.Point(533, 182);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(75, 23);
            this.Export.TabIndex = 0;
            this.Export.Text = "Export";
            this.Export.UseVisualStyleBackColor = true;
            this.Export.Click += new System.EventHandler(this.Export_Click);
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFrom.Location = new System.Drawing.Point(309, 34);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(86, 20);
            this.dtpDateFrom.TabIndex = 2;
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTo.Location = new System.Drawing.Point(522, 34);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(86, 20);
            this.dtpDateTo.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(240, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Period From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(496, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "To";
            // 
            // chkNewEmp
            // 
            this.chkNewEmp.AutoSize = true;
            this.chkNewEmp.Checked = true;
            this.chkNewEmp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNewEmp.Location = new System.Drawing.Point(306, 96);
            this.chkNewEmp.Name = "chkNewEmp";
            this.chkNewEmp.Size = new System.Drawing.Size(123, 17);
            this.chkNewEmp.TabIndex = 8;
            this.chkNewEmp.Text = "New Employee Data";
            this.chkNewEmp.UseVisualStyleBackColor = true;
            // 
            // chkUpdateEmp
            // 
            this.chkUpdateEmp.AutoSize = true;
            this.chkUpdateEmp.Checked = true;
            this.chkUpdateEmp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpdateEmp.Location = new System.Drawing.Point(306, 188);
            this.chkUpdateEmp.Name = "chkUpdateEmp";
            this.chkUpdateEmp.Size = new System.Drawing.Size(136, 17);
            this.chkUpdateEmp.TabIndex = 9;
            this.chkUpdateEmp.Text = "Update Employee Data";
            this.chkUpdateEmp.UseVisualStyleBackColor = true;
            // 
            // chkResignEmp
            // 
            this.chkResignEmp.AutoSize = true;
            this.chkResignEmp.Checked = true;
            this.chkResignEmp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkResignEmp.Location = new System.Drawing.Point(306, 142);
            this.chkResignEmp.Name = "chkResignEmp";
            this.chkResignEmp.Size = new System.Drawing.Size(134, 17);
            this.chkResignEmp.TabIndex = 10;
            this.chkResignEmp.Text = "Resign Employee Data";
            this.chkResignEmp.UseVisualStyleBackColor = true;
            // 
            // frmExportEmpData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 517);
            this.Controls.Add(this.chkResignEmp);
            this.Controls.Add(this.chkUpdateEmp);
            this.Controls.Add(this.chkNewEmp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpDateTo);
            this.Controls.Add(this.dtpDateFrom);
            this.Controls.Add(this.Export);
            this.Name = "frmExportEmpData";
            this.Text = "frmExportEmpData";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Export;
        protected System.Windows.Forms.DateTimePicker dtpDateFrom;
        protected System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkNewEmp;
        private System.Windows.Forms.CheckBox chkUpdateEmp;
        private System.Windows.Forms.CheckBox chkResignEmp;
    }
}