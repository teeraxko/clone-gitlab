namespace Presentation.VehicleGUI.VehicleLeasingGUI
{
    partial class FrmrptCalculationReport
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
            this.tbLeasing = new System.Windows.Forms.TabPage();
            this.crvLeasing = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tbCostAndProfit = new System.Windows.Forms.TabPage();
            this.crvCost = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tbInterest = new System.Windows.Forms.TabPage();
            this.crvInterest = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabControl1.SuspendLayout();
            this.tbLeasing.SuspendLayout();
            this.tbCostAndProfit.SuspendLayout();
            this.tbInterest.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tbLeasing);
            this.tabControl1.Controls.Add(this.tbCostAndProfit);
            this.tabControl1.Controls.Add(this.tbInterest);
            this.tabControl1.Location = new System.Drawing.Point(7, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(674, 443);
            this.tabControl1.TabIndex = 0;
            // 
            // tbLeasing
            // 
            this.tbLeasing.Controls.Add(this.crvLeasing);
            this.tbLeasing.Location = new System.Drawing.Point(4, 23);
            this.tbLeasing.Name = "tbLeasing";
            this.tbLeasing.Padding = new System.Windows.Forms.Padding(3);
            this.tbLeasing.Size = new System.Drawing.Size(666, 416);
            this.tbLeasing.TabIndex = 0;
            this.tbLeasing.Text = "CALCUALATION OF LEASING";
            this.tbLeasing.UseVisualStyleBackColor = true;
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
            this.crvLeasing.Location = new System.Drawing.Point(13, 8);
            this.crvLeasing.Name = "crvLeasing";
            this.crvLeasing.ShowCloseButton = false;
            this.crvLeasing.ShowGroupTreeButton = false;
            this.crvLeasing.Size = new System.Drawing.Size(640, 400);
            this.crvLeasing.TabIndex = 0;
            // 
            // tbCostAndProfit
            // 
            this.tbCostAndProfit.Controls.Add(this.crvCost);
            this.tbCostAndProfit.Location = new System.Drawing.Point(4, 23);
            this.tbCostAndProfit.Name = "tbCostAndProfit";
            this.tbCostAndProfit.Padding = new System.Windows.Forms.Padding(3);
            this.tbCostAndProfit.Size = new System.Drawing.Size(666, 416);
            this.tbCostAndProfit.TabIndex = 1;
            this.tbCostAndProfit.Text = "COST AND PROFIT CALCULATION";
            this.tbCostAndProfit.UseVisualStyleBackColor = true;
            // 
            // crvCost
            // 
            this.crvCost.ActiveViewIndex = -1;
            this.crvCost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvCost.DisplayGroupTree = false;
            this.crvCost.DisplayStatusBar = false;
            this.crvCost.DisplayToolbar = false;
            this.crvCost.Location = new System.Drawing.Point(13, 8);
            this.crvCost.Name = "crvCost";
            this.crvCost.ShowCloseButton = false;
            this.crvCost.ShowGroupTreeButton = false;
            this.crvCost.Size = new System.Drawing.Size(640, 400);
            this.crvCost.TabIndex = 1;
            // 
            // tbInterest
            // 
            this.tbInterest.Controls.Add(this.crvInterest);
            this.tbInterest.Location = new System.Drawing.Point(4, 23);
            this.tbInterest.Name = "tbInterest";
            this.tbInterest.Size = new System.Drawing.Size(666, 416);
            this.tbInterest.TabIndex = 2;
            this.tbInterest.Text = "INTEREST COST";
            this.tbInterest.UseVisualStyleBackColor = true;
            // 
            // crvInterest
            // 
            this.crvInterest.ActiveViewIndex = -1;
            this.crvInterest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvInterest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvInterest.DisplayGroupTree = false;
            this.crvInterest.DisplayStatusBar = false;
            this.crvInterest.DisplayToolbar = false;
            this.crvInterest.Location = new System.Drawing.Point(13, 8);
            this.crvInterest.Name = "crvInterest";
            this.crvInterest.ShowCloseButton = false;
            this.crvInterest.ShowGroupTreeButton = false;
            this.crvInterest.Size = new System.Drawing.Size(640, 400);
            this.crvInterest.TabIndex = 1;
            // 
            // FrmrptCalculationReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(695, 468);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmrptCalculationReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmrptCostAndProfit_Load);
            this.tabControl1.ResumeLayout(false);
            this.tbLeasing.ResumeLayout(false);
            this.tbCostAndProfit.ResumeLayout(false);
            this.tbInterest.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbLeasing;
        private System.Windows.Forms.TabPage tbCostAndProfit;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvLeasing;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvCost;
        private System.Windows.Forms.TabPage tbInterest;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvInterest;
    }
}