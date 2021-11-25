namespace PTB.BTS.BTS2BizPacPresentation.ConnectBizPac
{
    partial class FrmrptInsuranceExpense
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
            this.tbControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.crvInsurance = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.crvExpense = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tbControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbControl
            // 
            this.tbControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbControl.Controls.Add(this.tabPage1);
            this.tbControl.Controls.Add(this.tabPage2);
            this.tbControl.Location = new System.Drawing.Point(8, 16);
            this.tbControl.Name = "tbControl";
            this.tbControl.SelectedIndex = 0;
            this.tbControl.Size = new System.Drawing.Size(624, 480);
            this.tbControl.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.crvInsurance);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(616, 454);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Insurance Type I";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // crvInsurance
            // 
            this.crvInsurance.ActiveViewIndex = -1;
            this.crvInsurance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvInsurance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvInsurance.DisplayGroupTree = false;
            this.crvInsurance.DisplayStatusBar = false;
            this.crvInsurance.DisplayToolbar = false;
            this.crvInsurance.Location = new System.Drawing.Point(8, 8);
            this.crvInsurance.Name = "crvInsurance";
            this.crvInsurance.ShowCloseButton = false;
            this.crvInsurance.ShowGroupTreeButton = false;
            this.crvInsurance.Size = new System.Drawing.Size(600, 440);
            this.crvInsurance.TabIndex = 6;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.crvExpense);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(616, 454);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Insurance Type I Expense";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // crvExpense
            // 
            this.crvExpense.ActiveViewIndex = -1;
            this.crvExpense.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvExpense.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvExpense.DisplayGroupTree = false;
            this.crvExpense.DisplayStatusBar = false;
            this.crvExpense.DisplayToolbar = false;
            this.crvExpense.Location = new System.Drawing.Point(8, 7);
            this.crvExpense.Name = "crvExpense";
            this.crvExpense.ShowCloseButton = false;
            this.crvExpense.ShowGroupTreeButton = false;
            this.crvExpense.Size = new System.Drawing.Size(600, 440);
            this.crvExpense.TabIndex = 7;
            // 
            // FrmrptInsuranceExpense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 501);
            this.Controls.Add(this.tbControl);
            this.Name = "FrmrptInsuranceExpense";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmrptInsuranceExpense_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmrptInsuranceExpense_FormClosed);
            this.tbControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbControl;
        private System.Windows.Forms.TabPage tabPage1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvInsurance;
        private System.Windows.Forms.TabPage tabPage2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvExpense;


    }
}