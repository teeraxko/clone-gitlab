namespace PTB.PIS.Welfare.ReportApp.GUI.ConnectBizPacGUI {
    partial class FrmConnectBizPac {
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
            this.crvMain = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvMain
            // 
            this.crvMain.ActiveViewIndex = -1;
            this.crvMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvMain.DisplayGroupTree = false;
            this.crvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvMain.Location = new System.Drawing.Point(0, 0);
            this.crvMain.Name = "crvMain";
            this.crvMain.ShowGroupTreeButton = false;
            this.crvMain.ShowRefreshButton = false;
            this.crvMain.Size = new System.Drawing.Size(615, 480);
            this.crvMain.TabIndex = 5;
            // 
            // FrmConnectBizPac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(615, 480);
            this.Controls.Add(this.crvMain);
            this.Name = "FrmConnectBizPac";
            this.Load += new System.EventHandler(this.FrmConnectBizPac_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvMain;



    }
}
