namespace PTB.PIS.Welfare.ReportApp.GUI.LoanGUI {
    partial class FrmReportLoanConnect {
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.crvMain = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.crvMain2 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(680, 448);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.crvMain);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(672, 422);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "BizPac";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // crvMain
            // 
            this.crvMain.ActiveViewIndex = -1;
            this.crvMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvMain.DisplayGroupTree = false;
            this.crvMain.DisplayStatusBar = false;
            this.crvMain.DisplayToolbar = false;
            this.crvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvMain.Location = new System.Drawing.Point(3, 3);
            this.crvMain.Name = "crvMain";
            this.crvMain.ShowGroupTreeButton = false;
            this.crvMain.ShowRefreshButton = false;
            this.crvMain.Size = new System.Drawing.Size(666, 416);
            this.crvMain.TabIndex = 5;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.crvMain2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(672, 422);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "BBL";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // crvMain2
            // 
            this.crvMain2.ActiveViewIndex = -1;
            this.crvMain2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvMain2.DisplayGroupTree = false;
            this.crvMain2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvMain2.Location = new System.Drawing.Point(3, 3);
            this.crvMain2.Name = "crvMain2";
            this.crvMain2.ShowGroupTreeButton = false;
            this.crvMain2.ShowRefreshButton = false;
            this.crvMain2.Size = new System.Drawing.Size(666, 416);
            this.crvMain2.TabIndex = 5;
            // 
            // FrmReportLoanConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 448);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmReportLoanConnect";
            this.Text = "FrmReportLoanConnect";
            this.Load += new System.EventHandler(this.FrmReportLoanConnect_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvMain;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvMain2;
    }
}