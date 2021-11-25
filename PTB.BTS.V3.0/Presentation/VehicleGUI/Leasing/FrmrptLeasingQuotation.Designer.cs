namespace Presentation.VehicleGUI.Leasing
{
    partial class FrmrptLeasingQuotation
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabLeasingQuotation = new System.Windows.Forms.TabPage();
            this.crvQuotation = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabQuotationCalculation = new System.Windows.Forms.TabPage();
            this.crvLeasing = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabControl1.SuspendLayout();
            this.tabLeasingQuotation.SuspendLayout();
            this.tabQuotationCalculation.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabLeasingQuotation);
            this.tabControl1.Controls.Add(this.tabQuotationCalculation);
            this.tabControl1.Location = new System.Drawing.Point(8, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(698, 501);
            this.tabControl1.TabIndex = 1;
            // 
            // tabLeasingQuotation
            // 
            this.tabLeasingQuotation.Controls.Add(this.crvQuotation);
            this.tabLeasingQuotation.Location = new System.Drawing.Point(4, 22);
            this.tabLeasingQuotation.Name = "tabLeasingQuotation";
            this.tabLeasingQuotation.Padding = new System.Windows.Forms.Padding(3);
            this.tabLeasingQuotation.Size = new System.Drawing.Size(690, 475);
            this.tabLeasingQuotation.TabIndex = 0;
            this.tabLeasingQuotation.Text = "Car Leasing Quotation";
            this.tabLeasingQuotation.UseVisualStyleBackColor = true;
            // 
            // crvQuotation
            // 
            this.crvQuotation.ActiveViewIndex = -1;
            this.crvQuotation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvQuotation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvQuotation.DisplayGroupTree = false;
            this.crvQuotation.DisplayStatusBar = false;
            this.crvQuotation.Location = new System.Drawing.Point(8, 8);
            this.crvQuotation.Name = "crvQuotation";
            this.crvQuotation.ShowCloseButton = false;
            this.crvQuotation.ShowGroupTreeButton = false;
            this.crvQuotation.Size = new System.Drawing.Size(672, 456);
            this.crvQuotation.TabIndex = 0;
            // 
            // tabQuotationCalculation
            // 
            this.tabQuotationCalculation.Controls.Add(this.crvLeasing);
            this.tabQuotationCalculation.Location = new System.Drawing.Point(4, 22);
            this.tabQuotationCalculation.Name = "tabQuotationCalculation";
            this.tabQuotationCalculation.Size = new System.Drawing.Size(690, 475);
            this.tabQuotationCalculation.TabIndex = 2;
            this.tabQuotationCalculation.Text = "Calculation Of Leasing";
            this.tabQuotationCalculation.UseVisualStyleBackColor = true;
            // 
            // crvLeasing
            // 
            this.crvLeasing.ActiveViewIndex = -1;
            this.crvLeasing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvLeasing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvLeasing.DisplayGroupTree = false;
            this.crvLeasing.DisplayStatusBar = false;
            this.crvLeasing.DisplayToolbar = false;
            this.crvLeasing.Location = new System.Drawing.Point(9, 9);
            this.crvLeasing.Name = "crvLeasing";
            this.crvLeasing.ShowCloseButton = false;
            this.crvLeasing.ShowGroupTreeButton = false;
            this.crvLeasing.Size = new System.Drawing.Size(672, 456);
            this.crvLeasing.TabIndex = 1;
            // 
            // FrmrptLeasingQuotation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 512);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmrptLeasingQuotation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmrptLeasingQuotation_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabLeasingQuotation.ResumeLayout(false);
            this.tabQuotationCalculation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabLeasingQuotation;
        private System.Windows.Forms.TabPage tabQuotationCalculation;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvQuotation;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvLeasing;

    }
}