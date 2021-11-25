namespace Presentation.VehicleGUI.VehicleLeasingGUI
{
    partial class FrmrptQuotationReport
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
            this.hidQuotationNo = new System.Windows.Forms.Label();
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
            this.crvPrint.Location = new System.Drawing.Point(7, 8);
            this.crvPrint.Name = "crvPrint";
            this.crvPrint.ShowCloseButton = false;
            this.crvPrint.ShowExportButton = false;
            this.crvPrint.ShowGroupTreeButton = false;
            this.crvPrint.Size = new System.Drawing.Size(752, 432);
            this.crvPrint.TabIndex = 2;
            // 
            // hidQuotationNo
            // 
            this.hidQuotationNo.AutoSize = true;
            this.hidQuotationNo.Location = new System.Drawing.Point(-1, -1);
            this.hidQuotationNo.Name = "hidQuotationNo";
            this.hidQuotationNo.Size = new System.Drawing.Size(35, 13);
            this.hidQuotationNo.TabIndex = 3;
            this.hidQuotationNo.Text = "label1";
            // 
            // FrmrptQuotationReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(766, 449);
            this.Controls.Add(this.hidQuotationNo);
            this.Controls.Add(this.crvPrint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmrptQuotationReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmrptLeasingPurchasing_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvPrint;
        private System.Windows.Forms.Label hidQuotationNo;
    }
}