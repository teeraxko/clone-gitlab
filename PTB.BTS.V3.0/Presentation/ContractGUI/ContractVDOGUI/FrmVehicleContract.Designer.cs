namespace Presentation.ContractGUI.ContractVDOGUI
{
    partial class FrmVehicleContract
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
            this.label24 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.btnCal = new System.Windows.Forms.Button();
            this.uctContractCharge1 = new Presentation.ContractGUI.UCTContractCharge();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.gpbLeaseTerm = new System.Windows.Forms.GroupBox();
            this.chkContinueSts = new System.Windows.Forms.CheckBox();
            this.cboKindRental = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.fpiLeaseTerm = new FarPoint.Win.Input.FpInteger();
            this.label17 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.grbServiceCharge.SuspendLayout();
            this.gpbLeaseTerm.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbDeleteContract
            // 
            this.gpbDeleteContract.Location = new System.Drawing.Point(544, 264);
            // 
            // gpbCancelReason
            // 
            this.gpbCancelReason.Location = new System.Drawing.Point(544, 504);
            this.gpbCancelReason.Size = new System.Drawing.Size(256, 56);
            // 
            // gpbAssignment
            // 
            this.gpbAssignment.Location = new System.Drawing.Point(24, 264);
            this.gpbAssignment.Size = new System.Drawing.Size(512, 239);
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
            this.grbServiceCharge.TabIndex = 91;
            this.grbServiceCharge.TabStop = false;
            this.grbServiceCharge.Text = "ค่าบริการ";
            this.grbServiceCharge.Visible = false;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label24.Location = new System.Drawing.Point(672, 16);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(85, 23);
            this.label24.TabIndex = 54;
            this.label24.Text = "เดือนสุดท้าย";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label21.Location = new System.Drawing.Point(568, 16);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(85, 23);
            this.label21.TabIndex = 53;
            this.label21.Text = "เดือนถัดไป";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label20.Location = new System.Drawing.Point(464, 16);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(85, 23);
            this.label20.TabIndex = 52;
            this.label20.Text = "เดือนแรก";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label19.Location = new System.Drawing.Point(360, 16);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(85, 23);
            this.label19.TabIndex = 51;
            this.label19.Text = "อัตราค่าบริการ";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.uctContractCharge1.AbsentDeduct = 0;
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
            // gpbLeaseTerm
            // 
            this.gpbLeaseTerm.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.gpbLeaseTerm.Controls.Add(this.chkContinueSts);
            this.gpbLeaseTerm.Controls.Add(this.cboKindRental);
            this.gpbLeaseTerm.Controls.Add(this.label30);
            this.gpbLeaseTerm.Controls.Add(this.fpiLeaseTerm);
            this.gpbLeaseTerm.Controls.Add(this.label17);
            this.gpbLeaseTerm.Location = new System.Drawing.Point(24, 504);
            this.gpbLeaseTerm.Name = "gpbLeaseTerm";
            this.gpbLeaseTerm.Size = new System.Drawing.Size(512, 56);
            this.gpbLeaseTerm.TabIndex = 92;
            this.gpbLeaseTerm.TabStop = false;
            this.gpbLeaseTerm.Text = "รายละเอียดการเช่า";
            this.gpbLeaseTerm.Controls.SetChildIndex(this.label17, 0);
            this.gpbLeaseTerm.Controls.SetChildIndex(this.fpiLeaseTerm, 0);
            this.gpbLeaseTerm.Controls.SetChildIndex(this.label30, 0);
            this.gpbLeaseTerm.Controls.SetChildIndex(this.cboKindRental, 0);
            this.gpbLeaseTerm.Controls.SetChildIndex(this.chkContinueSts, 0);
            // 
            // chkContinueSts
            // 
            this.chkContinueSts.AutoSize = true;
            this.chkContinueSts.Location = new System.Drawing.Point(400, 22);
            this.chkContinueSts.Name = "chkContinueSts";
            this.chkContinueSts.Size = new System.Drawing.Size(92, 17);
            this.chkContinueSts.TabIndex = 47;
            this.chkContinueSts.Text = "สัญญาต่อเนื่อง";
            this.chkContinueSts.UseVisualStyleBackColor = true;
            // 
            // cboKindRental
            // 
            this.cboKindRental.FormattingEnabled = true;
            this.cboKindRental.Location = new System.Drawing.Point(256, 20);
            this.cboKindRental.Name = "cboKindRental";
            this.cboKindRental.Size = new System.Drawing.Size(112, 21);
            this.cboKindRental.TabIndex = 46;
            this.cboKindRental.SelectedIndexChanged += new System.EventHandler(this.cboKindRental_SelectedIndexChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(179, 24);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(77, 13);
            this.label30.TabIndex = 45;
            this.label30.Text = "รูปแบบการเช่า";
            // 
            // fpiLeaseTerm
            // 
            this.fpiLeaseTerm.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiLeaseTerm.AllowClipboardKeys = true;
            this.fpiLeaseTerm.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiLeaseTerm.Location = new System.Drawing.Point(80, 20);
            this.fpiLeaseTerm.MaxValue = 99;
            this.fpiLeaseTerm.MinValue = 0;
            this.fpiLeaseTerm.Name = "fpiLeaseTerm";
            this.fpiLeaseTerm.Size = new System.Drawing.Size(45, 20);
            this.fpiLeaseTerm.TabIndex = 44;
            this.fpiLeaseTerm.Text = "";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(11, 24);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(69, 13);
            this.label17.TabIndex = 41;
            this.label17.Text = "ระยะเวลาเช่า";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(125, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 13);
            this.label12.TabIndex = 43;
            this.label12.Text = "เดือน";
            // 
            // FrmVehicleContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 651);
            this.Controls.Add(this.grbServiceCharge);
            this.Controls.Add(this.gpbLeaseTerm);
            this.Name = "FrmVehicleContract";
            this.Text = "FrmVehicleContract";
            this.Load += new System.EventHandler(this.FrmVehicleContract_Load);
            this.Controls.SetChildIndex(this.gpbLeaseTerm, 0);
            this.Controls.SetChildIndex(this.grbServiceCharge, 0);
            this.Controls.SetChildIndex(this.gpbCancelReason, 0);
            this.Controls.SetChildIndex(this.gpbDeleteContract, 0);
            this.Controls.SetChildIndex(this.gpbAssignment, 0);
            this.grbServiceCharge.ResumeLayout(false);
            this.gpbLeaseTerm.ResumeLayout(false);
            this.gpbLeaseTerm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbServiceCharge;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnCal;
        private UCTContractCharge uctContractCharge1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox gpbLeaseTerm;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label17;
        protected internal FarPoint.Win.Input.FpInteger fpiLeaseTerm;
        private System.Windows.Forms.ComboBox cboKindRental;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.CheckBox chkContinueSts;
    }
}