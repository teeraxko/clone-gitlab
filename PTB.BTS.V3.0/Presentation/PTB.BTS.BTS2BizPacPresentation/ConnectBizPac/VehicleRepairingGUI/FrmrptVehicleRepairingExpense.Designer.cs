namespace PTB.BTS.BTS2BizPacPresentation.ConnectBizPac
{
    partial class FrmrptVehicleRepairingExpense
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
            this.crvRepairing = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvRepairing
            // 
            this.crvRepairing.ActiveViewIndex = -1;
            this.crvRepairing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvRepairing.DisplayGroupTree = false;
            this.crvRepairing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvRepairing.Location = new System.Drawing.Point(0, 0);
            this.crvRepairing.Name = "crvRepairing";
            this.crvRepairing.ShowCloseButton = false;
            this.crvRepairing.ShowGroupTreeButton = false;
            this.crvRepairing.Size = new System.Drawing.Size(663, 494);
            this.crvRepairing.TabIndex = 2;
            // 
            // FrmrptVehicleRepairingExpense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 494);
            this.Controls.Add(this.crvRepairing);
            this.Name = "FrmrptVehicleRepairingExpense";
            this.Load += new System.EventHandler(this.FrmRepairingExpense_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmrptVehicleRepairingExpense_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvRepairing;
    }
}