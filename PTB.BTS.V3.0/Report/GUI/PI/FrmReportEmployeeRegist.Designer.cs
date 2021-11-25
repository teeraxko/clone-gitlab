namespace Report.GUI.PI
{
    partial class FrmReportEmployeeRegist
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
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(646, 429);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.crvMain);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(638, 403);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ทะเบียนลูกจ้าง";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // crvMain
            // 
            this.crvMain.ActiveViewIndex = -1;
            this.crvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvMain.DisplayGroupTree = false;
            this.crvMain.DisplayStatusBar = false;
            this.crvMain.DisplayToolbar = false;
            this.crvMain.Location = new System.Drawing.Point(3, 3);
            this.crvMain.Name = "crvMain";
            this.crvMain.ShowCloseButton = false;
            this.crvMain.ShowGroupTreeButton = false;
            this.crvMain.Size = new System.Drawing.Size(632, 397);
            this.crvMain.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.crvMain2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(638, 403);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ทะเบียนลูกจ้าง(พ้นสภาพ)";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // crvMain2
            // 
            this.crvMain2.ActiveViewIndex = -1;
            this.crvMain2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvMain2.DisplayGroupTree = false;
            this.crvMain2.DisplayStatusBar = false;
            this.crvMain2.DisplayToolbar = false;
            this.crvMain2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvMain2.Location = new System.Drawing.Point(3, 3);
            this.crvMain2.Name = "crvMain2";
            this.crvMain2.ShowCloseButton = false;
            this.crvMain2.ShowGroupTreeButton = false;
            this.crvMain2.Size = new System.Drawing.Size(632, 397);
            this.crvMain2.TabIndex = 1;
            // 
            // FrmReportEmployeeRegist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 453);
            this.Controls.Add(this.tabControl1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmReportEmployeeRegist";
            this.Text = "FrmReportEmployeeRegist";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvMain;
        private System.Windows.Forms.TabPage tabPage2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvMain2;
    }
}