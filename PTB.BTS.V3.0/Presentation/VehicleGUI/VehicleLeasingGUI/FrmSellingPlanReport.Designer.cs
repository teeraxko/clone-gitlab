namespace Presentation.VehicleGUI.VehicleLeasingGUI
{
    partial class FrmSellingPlanReport
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
            this.tab1 = new System.Windows.Forms.TabPage();
            this.crvDepreciation = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tab2 = new System.Windows.Forms.TabPage();
            this.crvQuotation = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabControl1.SuspendLayout();
            this.tab1.SuspendLayout();
            this.tab2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tab1);
            this.tabControl1.Controls.Add(this.tab2);
            this.tabControl1.Location = new System.Drawing.Point(8, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(584, 424);
            this.tabControl1.TabIndex = 0;
            // 
            // tab1
            // 
            this.tab1.Controls.Add(this.crvDepreciation);
            this.tab1.Location = new System.Drawing.Point(4, 22);
            this.tab1.Name = "tab1";
            this.tab1.Padding = new System.Windows.Forms.Padding(3);
            this.tab1.Size = new System.Drawing.Size(576, 398);
            this.tab1.TabIndex = 0;
            this.tab1.Text = "Depreciation";
            this.tab1.UseVisualStyleBackColor = true;
            // 
            // crvDepreciation
            // 
            this.crvDepreciation.ActiveViewIndex = -1;
            this.crvDepreciation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvDepreciation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvDepreciation.DisplayGroupTree = false;
            this.crvDepreciation.DisplayStatusBar = false;
            this.crvDepreciation.DisplayToolbar = false;
            this.crvDepreciation.Location = new System.Drawing.Point(8, 8);
            this.crvDepreciation.Name = "crvDepreciation";
            this.crvDepreciation.ShowCloseButton = false;
            this.crvDepreciation.ShowGroupTreeButton = false;
            this.crvDepreciation.Size = new System.Drawing.Size(565, 387);
            this.crvDepreciation.TabIndex = 0;
            // 
            // tab2
            // 
            this.tab2.Controls.Add(this.crvQuotation);
            this.tab2.Location = new System.Drawing.Point(4, 22);
            this.tab2.Name = "tab2";
            this.tab2.Padding = new System.Windows.Forms.Padding(3);
            this.tab2.Size = new System.Drawing.Size(576, 398);
            this.tab2.TabIndex = 1;
            this.tab2.Text = "Quotation";
            this.tab2.UseVisualStyleBackColor = true;
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
            this.crvQuotation.DisplayToolbar = false;
            this.crvQuotation.Location = new System.Drawing.Point(6, 6);
            this.crvQuotation.Name = "crvQuotation";
            this.crvQuotation.ShowCloseButton = false;
            this.crvQuotation.ShowGroupTreeButton = false;
            this.crvQuotation.Size = new System.Drawing.Size(565, 387);
            this.crvQuotation.TabIndex = 1;
            // 
            // FrmSellingPlanReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 446);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmSellingPlanReport";
            this.Text = "Selling Plan Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl1.ResumeLayout(false);
            this.tab1.ResumeLayout(false);
            this.tab2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvDepreciation;
        private System.Windows.Forms.TabPage tab2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvQuotation;
    }
}