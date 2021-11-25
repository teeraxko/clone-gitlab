namespace Presentation.ContractGUI.ContractVDOGUI
{
    partial class FrmOtherSSContract
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
            this.grbServiceCharge = new System.Windows.Forms.GroupBox();
            this.btnCal = new System.Windows.Forms.Button();
            this.uctContractCharge1 = new Presentation.ContractGUI.UCTContractCharge();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.grbServiceCharge.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbDeleteContract
            // 
            this.gpbDeleteContract.Location = new System.Drawing.Point(24, 264);
            // 
            // gpbAssignment
            // 
            this.gpbAssignment.Location = new System.Drawing.Point(288, 272);
            this.gpbAssignment.Size = new System.Drawing.Size(512, 261);
            // 
            // gpbCancelReason
            // 
            this.gpbCancelReason.Location = new System.Drawing.Point(545, 466);
            // 
            // grbServiceCharge
            // 
            this.grbServiceCharge.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.grbServiceCharge.Controls.Add(this.label24);
            this.grbServiceCharge.Controls.Add(this.label21);
            this.grbServiceCharge.Controls.Add(this.label20);
            this.grbServiceCharge.Controls.Add(this.label19);
            this.grbServiceCharge.Controls.Add(this.btnCal);
            this.grbServiceCharge.Controls.Add(this.uctContractCharge1);
            this.grbServiceCharge.Location = new System.Drawing.Point(24, 184);
            this.grbServiceCharge.Name = "grbServiceCharge";
            this.grbServiceCharge.Size = new System.Drawing.Size(776, 80);
            this.grbServiceCharge.TabIndex = 40;
            this.grbServiceCharge.TabStop = false;
            this.grbServiceCharge.Text = "ค่าบริการ";
            this.grbServiceCharge.Visible = false;
            // 
            // btnCal
            // 
            this.btnCal.Enabled = false;
            this.btnCal.Location = new System.Drawing.Point(272, 44);
            this.btnCal.Name = "btnCal";
            this.btnCal.Size = new System.Drawing.Size(72, 23);
            this.btnCal.TabIndex = 49;
            this.btnCal.Text = "คำนวณ";
            this.btnCal.Click += new System.EventHandler(this.btnCal_Click);
            // 
            // uctContractCharge1
            // 
            this.uctContractCharge1.DateForm = new System.DateTime(((long)(0)));
            this.uctContractCharge1.DateTo = new System.DateTime(((long)(0)));
            this.uctContractCharge1.FirstMonth = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uctContractCharge1.LastMonth = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uctContractCharge1.Location = new System.Drawing.Point(344, 36);
            this.uctContractCharge1.Name = "uctContractCharge1";
            this.uctContractCharge1.NextMonth = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uctContractCharge1.RateAmount = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uctContractCharge1.RateAmountTag = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.uctContractCharge1.RateStatusByMonth = false;
            this.uctContractCharge1.Size = new System.Drawing.Size(424, 32);
            this.uctContractCharge1.TabIndex = 50;
            this.uctContractCharge1.UnitChargeEnable = true;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label18.Location = new System.Drawing.Point(568, 12);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(88, 23);
            this.label18.TabIndex = 47;
            this.label18.Text = "เดือนถัดไป";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label16.Location = new System.Drawing.Point(672, 12);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(88, 23);
            this.label16.TabIndex = 48;
            this.label16.Text = "เดือนสุดท้าย";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label24.Location = new System.Drawing.Point(672, 16);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(85, 23);
            this.label24.TabIndex = 58;
            this.label24.Text = "เดือนสุดท้าย";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label21.Location = new System.Drawing.Point(568, 16);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(85, 23);
            this.label21.TabIndex = 57;
            this.label21.Text = "เดือนถัดไป";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label20.Location = new System.Drawing.Point(464, 16);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(85, 23);
            this.label20.TabIndex = 56;
            this.label20.Text = "เดือนแรก";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label19.Location = new System.Drawing.Point(360, 16);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(85, 23);
            this.label19.TabIndex = 55;
            this.label19.Text = "อัตราค่าบริการ";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmOtherSSContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 651);
            this.Controls.Add(this.grbServiceCharge);
            this.Name = "FrmOtherSSContract";
            this.Text = "FrmOtherStaffContract";
            this.Load += new System.EventHandler(this.FrmOtherSSContract_Load);
            this.Controls.SetChildIndex(this.gpbCancelReason, 0);
            this.Controls.SetChildIndex(this.gpbDeleteContract, 0);
            this.Controls.SetChildIndex(this.gpbAssignment, 0);
            this.Controls.SetChildIndex(this.grbServiceCharge, 0);
            this.grbServiceCharge.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbServiceCharge;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnCal;
        private UCTContractCharge uctContractCharge1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
    }
}