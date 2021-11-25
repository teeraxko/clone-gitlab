namespace PTB.BTS.BTS2BizPacPresentation.ConnectBizPac
{
    partial class FrmrptCompulsoryExpense
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
            this.crvCompulsory = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvCompulsory
            // 
            this.crvCompulsory.ActiveViewIndex = -1;
            this.crvCompulsory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvCompulsory.DisplayGroupTree = false;
            this.crvCompulsory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvCompulsory.Location = new System.Drawing.Point(0, 0);
            this.crvCompulsory.Name = "crvCompulsory";
            this.crvCompulsory.ShowCloseButton = false;
            this.crvCompulsory.ShowGroupTreeButton = false;
            this.crvCompulsory.Size = new System.Drawing.Size(696, 493);
            this.crvCompulsory.TabIndex = 0;
            // 
            // FrmrptCompulsoryExpense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 493);
            this.Controls.Add(this.crvCompulsory);
            this.Name = "FrmrptCompulsoryExpense";
            this.Text = "FrmrptCompulsoryExpense";
            this.Load += new System.EventHandler(this.FrmrptCompulsoryExpense_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmrptCompulsoryExpense_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvCompulsory;

    }
}