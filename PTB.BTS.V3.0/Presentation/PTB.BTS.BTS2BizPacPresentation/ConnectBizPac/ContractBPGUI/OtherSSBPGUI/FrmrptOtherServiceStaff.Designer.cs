namespace PTB.BTS.BTS2BizPacPresentation.ConnectBizPac
{
    partial class FrmrptOtherServiceStaff
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.tbpSummary = new System.Windows.Forms.TabPage();
            this.crvSummary = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tbpTIS = new System.Windows.Forms.TabPage();
            this.crvTIS = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tbpDetail = new System.Windows.Forms.TabPage();
            this.crvDetail = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.tabControl1.SuspendLayout();
            this.tbpSummary.SuspendLayout();
            this.tbpTIS.SuspendLayout();
            this.tbpDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tbpSummary);
            this.tabControl1.Controls.Add(this.tbpTIS);
            this.tabControl1.Controls.Add(this.tbpDetail);
            this.tabControl1.Location = new System.Drawing.Point(8, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(688, 472);
            this.tabControl1.TabIndex = 0;
            // 
            // tbpSummary
            // 
            this.tbpSummary.Controls.Add(this.crvSummary);
            this.tbpSummary.Location = new System.Drawing.Point(4, 22);
            this.tbpSummary.Name = "tbpSummary";
            this.tbpSummary.Padding = new System.Windows.Forms.Padding(3);
            this.tbpSummary.Size = new System.Drawing.Size(680, 446);
            this.tbpSummary.TabIndex = 0;
            this.tbpSummary.Text = "สรุป";
            this.tbpSummary.UseVisualStyleBackColor = true;
            // 
            // crvSummary
            // 
            this.crvSummary.ActiveViewIndex = -1;
            this.crvSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvSummary.DisplayGroupTree = false;
            this.crvSummary.DisplayStatusBar = false;
            this.crvSummary.DisplayToolbar = false;
            this.crvSummary.Location = new System.Drawing.Point(8, 8);
            this.crvSummary.Name = "crvSummary";
            this.crvSummary.ShowCloseButton = false;
            this.crvSummary.ShowGroupTreeButton = false;
            this.crvSummary.Size = new System.Drawing.Size(664, 432);
            this.crvSummary.TabIndex = 0;
            // 
            // tbpTIS
            // 
            this.tbpTIS.Controls.Add(this.crvTIS);
            this.tbpTIS.Location = new System.Drawing.Point(4, 22);
            this.tbpTIS.Name = "tbpTIS";
            this.tbpTIS.Size = new System.Drawing.Size(680, 446);
            this.tbpTIS.TabIndex = 2;
            this.tbpTIS.Text = "TIS";
            this.tbpTIS.UseVisualStyleBackColor = true;
            // 
            // crvTIS
            // 
            this.crvTIS.ActiveViewIndex = -1;
            this.crvTIS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvTIS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvTIS.DisplayGroupTree = false;
            this.crvTIS.DisplayStatusBar = false;
            this.crvTIS.DisplayToolbar = false;
            this.crvTIS.Location = new System.Drawing.Point(8, 7);
            this.crvTIS.Name = "crvTIS";
            this.crvTIS.ShowCloseButton = false;
            this.crvTIS.ShowGroupTreeButton = false;
            this.crvTIS.Size = new System.Drawing.Size(664, 432);
            this.crvTIS.TabIndex = 1;
            // 
            // tbpDetail
            // 
            this.tbpDetail.Controls.Add(this.crvDetail);
            this.tbpDetail.Location = new System.Drawing.Point(4, 22);
            this.tbpDetail.Name = "tbpDetail";
            this.tbpDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tbpDetail.Size = new System.Drawing.Size(680, 446);
            this.tbpDetail.TabIndex = 1;
            this.tbpDetail.Text = "อื่นๆ";
            this.tbpDetail.UseVisualStyleBackColor = true;
            // 
            // crvDetail
            // 
            this.crvDetail.ActiveViewIndex = -1;
            this.crvDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvDetail.DisplayGroupTree = false;
            this.crvDetail.DisplayStatusBar = false;
            this.crvDetail.DisplayToolbar = false;
            this.crvDetail.Location = new System.Drawing.Point(8, 7);
            this.crvDetail.Name = "crvDetail";
            this.crvDetail.ShowCloseButton = false;
            this.crvDetail.ShowGroupTreeButton = false;
            this.crvDetail.Size = new System.Drawing.Size(664, 432);
            this.crvDetail.TabIndex = 1;
            // 
            // FrmrptOtherServiceStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 493);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmrptOtherServiceStaff";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmrptOtherServiceStaff_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmrptOtherServiceStaff_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.tbpSummary.ResumeLayout(false);
            this.tbpTIS.ResumeLayout(false);
            this.tbpDetail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbpSummary;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvSummary;
        private System.Windows.Forms.TabPage tbpDetail;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvDetail;
        private System.Windows.Forms.TabPage tbpTIS;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvTIS;
    }
}