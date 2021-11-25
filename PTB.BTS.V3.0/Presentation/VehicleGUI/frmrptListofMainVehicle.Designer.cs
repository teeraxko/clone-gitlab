namespace Presentation.VehicleGUI
{
    partial class frmrptListofMainVehicle
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.crvPrint1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.crvPrint2 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
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
            this.tabControl1.Location = new System.Drawing.Point(8, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(640, 464);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.crvPrint1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(632, 438);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "รถยนต์ให้เช่าปกติ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.crvPrint2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(632, 438);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "รถ Spare และ รถเช่าชั่วคราว";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // crvPrint1
            // 
            this.crvPrint1.ActiveViewIndex = -1;
            this.crvPrint1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvPrint1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvPrint1.DisplayGroupTree = false;
            this.crvPrint1.Location = new System.Drawing.Point(8, 8);
            this.crvPrint1.Name = "crvPrint1";
            this.crvPrint1.ShowCloseButton = false;
            this.crvPrint1.ShowGroupTreeButton = false;
            this.crvPrint1.Size = new System.Drawing.Size(616, 424);
            this.crvPrint1.TabIndex = 2;
            // 
            // crvPrint2
            // 
            this.crvPrint2.ActiveViewIndex = -1;
            this.crvPrint2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvPrint2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvPrint2.DisplayGroupTree = false;
            this.crvPrint2.DisplayStatusBar = false;
            this.crvPrint2.DisplayToolbar = false;
            this.crvPrint2.Location = new System.Drawing.Point(8, 8);
            this.crvPrint2.Name = "crvPrint2";
            this.crvPrint2.ShowCloseButton = false;
            this.crvPrint2.ShowGroupTreeButton = false;
            this.crvPrint2.Size = new System.Drawing.Size(608, 416);
            this.crvPrint2.TabIndex = 1;
            // 
            // frmrptListofMainVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 498);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmrptListofMainVehicle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmrptListofMainVehicle_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvPrint1;
        private System.Windows.Forms.TabPage tabPage2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvPrint2;

    }
}