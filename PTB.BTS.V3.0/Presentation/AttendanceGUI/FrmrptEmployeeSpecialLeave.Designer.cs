namespace Presentation.AttendanceGUI
{
    partial class FrmrptEmployeeSpecialLeave
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtpForMonth = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdShow = new System.Windows.Forms.Button();
            this.crvPrint = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(16, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 22;
            this.label1.Text = "ข้อมูลเดือน";
            // 
            // dtpForMonth
            // 
            this.dtpForMonth.CustomFormat = "MM/yyyy";
            this.dtpForMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpForMonth.Location = new System.Drawing.Point(80, 17);
            this.dtpForMonth.Name = "dtpForMonth";
            this.dtpForMonth.Size = new System.Drawing.Size(72, 20);
            this.dtpForMonth.TabIndex = 21;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpForMonth);
            this.groupBox1.Controls.Add(this.cmdShow);
            this.groupBox1.Location = new System.Drawing.Point(8, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(720, 48);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // cmdShow
            // 
            this.cmdShow.Location = new System.Drawing.Point(160, 16);
            this.cmdShow.Name = "cmdShow";
            this.cmdShow.Size = new System.Drawing.Size(80, 23);
            this.cmdShow.TabIndex = 9;
            this.cmdShow.Text = "ส่งข้อมูล";
            this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
            // 
            // crvPrint
            // 
            this.crvPrint.ActiveViewIndex = -1;
            this.crvPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvPrint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvPrint.DisplayGroupTree = false;
            this.crvPrint.Location = new System.Drawing.Point(0, 48);
            this.crvPrint.Name = "crvPrint";
            this.crvPrint.ShowCloseButton = false;
            this.crvPrint.ShowGroupTreeButton = false;
            this.crvPrint.Size = new System.Drawing.Size(736, 422);
            this.crvPrint.TabIndex = 20;
            // 
            // FrmrptEmployeeSpecialLeave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 470);
            this.Controls.Add(this.crvPrint);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmrptEmployeeSpecialLeave";
            this.Text = "FrmrptEmployeeSpecialLeave";
            this.Load += new System.EventHandler(this.FrmrptEmployeeSpecialLeave_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmrptEmployeeSpecialLeave_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpForMonth;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdShow;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvPrint;
    }
}