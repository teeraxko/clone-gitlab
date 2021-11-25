namespace Presentation.CommonGUI {
    partial class FrmTestReport {
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
            this.crvProvince = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvProvince
            // 
            this.crvProvince.ActiveViewIndex = -1;
            this.crvProvince.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvProvince.DisplayGroupTree = false;
            this.crvProvince.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvProvince.Location = new System.Drawing.Point(0, 0);
            this.crvProvince.Name = "crvProvince";
            this.crvProvince.Size = new System.Drawing.Size(792, 573);
            this.crvProvince.TabIndex = 0;
            // 
            // FrmTestReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.crvProvince);
            this.Name = "FrmTestReport";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "FrmTestReport";
            this.Load += new System.EventHandler(this.FrmTestReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvProvince;
    }
}