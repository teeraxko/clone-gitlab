namespace Presentation.VehicleGUI.ProfitLostGUI
{
    partial class FrmrptProfitLost
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
            this.crvPrint = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvPrint
            // 
            this.crvPrint.ActiveViewIndex = -1;
            this.crvPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvPrint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvPrint.DisplayGroupTree = false;
            this.crvPrint.Location = new System.Drawing.Point(8, 8);
            this.crvPrint.Name = "crvPrint";
            this.crvPrint.ShowCloseButton = false;
            this.crvPrint.ShowExportButton = false;
            this.crvPrint.ShowGroupTreeButton = false;
            this.crvPrint.Size = new System.Drawing.Size(752, 488);
            this.crvPrint.TabIndex = 3;
            // 
            // FrmrptProfitLost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 507);
            this.Controls.Add(this.crvPrint);
            this.Name = "FrmrptProfitLost";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmrptProfitLost_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvPrint;

    }
}