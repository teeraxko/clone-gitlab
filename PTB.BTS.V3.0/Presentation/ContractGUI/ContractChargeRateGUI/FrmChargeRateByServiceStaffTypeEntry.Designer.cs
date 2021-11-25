namespace Presentation.ContractGUI.ContractChargeRateGUI
{
    partial class FrmChargeRateByServiceStaffTypeEntry
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.fpdOTARate = new FarPoint.Win.Input.FpDouble();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.fpiMinLeave = new FarPoint.Win.Input.FpInteger();
            this.fpiTaxi = new FarPoint.Win.Input.FpInteger();
            this.fpiOneDayNear = new FarPoint.Win.Input.FpInteger();
            this.fpiOneDayFar = new FarPoint.Win.Input.FpInteger();
            this.fpiOvernight = new FarPoint.Win.Input.FpInteger();
            this.gpbStaffDetail = new System.Windows.Forms.GroupBox();
            this.chkDriverOnly = new System.Windows.Forms.CheckBox();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.cboServiceStaffType = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.fpiAbsence = new FarPoint.Win.Input.FpInteger();
            this.fpdOTCRate = new FarPoint.Win.Input.FpDouble();
            this.btnOK = new System.Windows.Forms.Button();
            this.fpdOTBRate = new FarPoint.Win.Input.FpDouble();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fpdMinHolidayAmount = new FarPoint.Win.Input.FpDouble();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gpbStaffDetail.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(202, 441);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // fpdOTARate
            // 
            this.fpdOTARate.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdOTARate.AllowClipboardKeys = true;
            this.fpdOTARate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fpdOTARate.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdOTARate.DecimalPlaces = 2;
            this.fpdOTARate.DecimalSeparator = ".";
            this.fpdOTARate.FixedPoint = true;
            this.fpdOTARate.Location = new System.Drawing.Point(211, 26);
            this.fpdOTARate.Name = "fpdOTARate";
            this.fpdOTARate.NumberGroupSeparator = ",";
            this.fpdOTARate.NumberGroupSize = 3;
            this.fpdOTARate.Size = new System.Drawing.Size(104, 20);
            this.fpdOTARate.TabIndex = 4;
            this.fpdOTARate.Text = "";
            this.fpdOTARate.UseSeparator = true;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(135, 233);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "วันลาขั้นต่ำ";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(151, 204);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "ค่า Taxi";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(102, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = " ค่าเดินทางค้างคืน";
            // 
            // fpiMinLeave
            // 
            this.fpiMinLeave.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiMinLeave.AllowClipboardKeys = true;
            this.fpiMinLeave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fpiMinLeave.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiMinLeave.Location = new System.Drawing.Point(211, 229);
            this.fpiMinLeave.MaxValue = 255;
            this.fpiMinLeave.MinValue = 0;
            this.fpiMinLeave.Name = "fpiMinLeave";
            this.fpiMinLeave.Size = new System.Drawing.Size(104, 20);
            this.fpiMinLeave.TabIndex = 13;
            this.fpiMinLeave.Text = "";
            this.fpiMinLeave.UseSeparator = true;
            // 
            // fpiTaxi
            // 
            this.fpiTaxi.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiTaxi.AllowClipboardKeys = true;
            this.fpiTaxi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fpiTaxi.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiTaxi.Location = new System.Drawing.Point(211, 200);
            this.fpiTaxi.MaxValue = 32000;
            this.fpiTaxi.MinValue = 0;
            this.fpiTaxi.Name = "fpiTaxi";
            this.fpiTaxi.Size = new System.Drawing.Size(104, 20);
            this.fpiTaxi.TabIndex = 12;
            this.fpiTaxi.Text = "";
            this.fpiTaxi.UseSeparator = true;
            // 
            // fpiOneDayNear
            // 
            this.fpiOneDayNear.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiOneDayNear.AllowClipboardKeys = true;
            this.fpiOneDayNear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fpiOneDayNear.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiOneDayNear.Location = new System.Drawing.Point(534, 295);
            this.fpiOneDayNear.MaxValue = 32000;
            this.fpiOneDayNear.MinValue = 0;
            this.fpiOneDayNear.Name = "fpiOneDayNear";
            this.fpiOneDayNear.Size = new System.Drawing.Size(104, 20);
            this.fpiOneDayNear.TabIndex = 10;
            this.fpiOneDayNear.Text = "";
            this.fpiOneDayNear.UseSeparator = true;
            this.fpiOneDayNear.Visible = false;
            // 
            // fpiOneDayFar
            // 
            this.fpiOneDayFar.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiOneDayFar.AllowClipboardKeys = true;
            this.fpiOneDayFar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fpiOneDayFar.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiOneDayFar.Location = new System.Drawing.Point(211, 140);
            this.fpiOneDayFar.MaxValue = 32000;
            this.fpiOneDayFar.MinValue = 0;
            this.fpiOneDayFar.Name = "fpiOneDayFar";
            this.fpiOneDayFar.Size = new System.Drawing.Size(104, 20);
            this.fpiOneDayFar.TabIndex = 9;
            this.fpiOneDayFar.Text = "";
            this.fpiOneDayFar.UseSeparator = true;
            // 
            // fpiOvernight
            // 
            this.fpiOvernight.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiOvernight.AllowClipboardKeys = true;
            this.fpiOvernight.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fpiOvernight.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiOvernight.Location = new System.Drawing.Point(211, 171);
            this.fpiOvernight.MaxValue = 32000;
            this.fpiOvernight.MinValue = 0;
            this.fpiOvernight.Name = "fpiOvernight";
            this.fpiOvernight.Size = new System.Drawing.Size(104, 20);
            this.fpiOvernight.TabIndex = 11;
            this.fpiOvernight.Text = "";
            this.fpiOvernight.UseSeparator = true;
            // 
            // gpbStaffDetail
            // 
            this.gpbStaffDetail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpbStaffDetail.Controls.Add(this.chkDriverOnly);
            this.gpbStaffDetail.Controls.Add(this.cboCustomer);
            this.gpbStaffDetail.Controls.Add(this.cboServiceStaffType);
            this.gpbStaffDetail.Controls.Add(this.label12);
            this.gpbStaffDetail.Controls.Add(this.label8);
            this.gpbStaffDetail.Location = new System.Drawing.Point(14, 8);
            this.gpbStaffDetail.Name = "gpbStaffDetail";
            this.gpbStaffDetail.Size = new System.Drawing.Size(368, 120);
            this.gpbStaffDetail.TabIndex = 16;
            this.gpbStaffDetail.TabStop = false;
            this.gpbStaffDetail.Text = "รายละเอียดประเภทพนักงาน";
            // 
            // chkDriverOnly
            // 
            this.chkDriverOnly.AutoSize = true;
            this.chkDriverOnly.Location = new System.Drawing.Point(104, 88);
            this.chkDriverOnly.Name = "chkDriverOnly";
            this.chkDriverOnly.Size = new System.Drawing.Size(78, 17);
            this.chkDriverOnly.TabIndex = 14;
            this.chkDriverOnly.Text = "Driver Only";
            this.chkDriverOnly.UseVisualStyleBackColor = true;
            // 
            // cboCustomer
            // 
            this.cboCustomer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(104, 56);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(248, 21);
            this.cboCustomer.TabIndex = 4;
            // 
            // cboServiceStaffType
            // 
            this.cboServiceStaffType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboServiceStaffType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServiceStaffType.FormattingEnabled = true;
            this.cboServiceStaffType.Location = new System.Drawing.Point(104, 24);
            this.cboServiceStaffType.Name = "cboServiceStaffType";
            this.cboServiceStaffType.Size = new System.Drawing.Size(248, 21);
            this.cboServiceStaffType.TabIndex = 3;
            this.cboServiceStaffType.SelectedIndexChanged += new System.EventHandler(this.cboServiceStaffType_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(63, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "ลูกค้า";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "ประเภทพนักงาน";
            // 
            // fpiAbsence
            // 
            this.fpiAbsence.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiAbsence.AllowClipboardKeys = true;
            this.fpiAbsence.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fpiAbsence.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiAbsence.Location = new System.Drawing.Point(211, 111);
            this.fpiAbsence.MaxValue = 32000;
            this.fpiAbsence.MinValue = 0;
            this.fpiAbsence.Name = "fpiAbsence";
            this.fpiAbsence.Size = new System.Drawing.Size(104, 20);
            this.fpiAbsence.TabIndex = 8;
            this.fpiAbsence.Text = "";
            this.fpiAbsence.UseSeparator = true;
            // 
            // fpdOTCRate
            // 
            this.fpdOTCRate.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdOTCRate.AllowClipboardKeys = true;
            this.fpdOTCRate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fpdOTCRate.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdOTCRate.DecimalPlaces = 2;
            this.fpdOTCRate.DecimalSeparator = ".";
            this.fpdOTCRate.FixedPoint = true;
            this.fpdOTCRate.Location = new System.Drawing.Point(211, 84);
            this.fpdOTCRate.Name = "fpdOTCRate";
            this.fpdOTCRate.NumberGroupSeparator = ",";
            this.fpdOTCRate.NumberGroupSize = 3;
            this.fpdOTCRate.Size = new System.Drawing.Size(104, 20);
            this.fpdOTCRate.TabIndex = 6;
            this.fpdOTCRate.Text = "";
            this.fpdOTCRate.UseSeparator = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Location = new System.Drawing.Point(121, 441);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 18;
            this.btnOK.Text = "ตกลง";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // fpdOTBRate
            // 
            this.fpdOTBRate.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdOTBRate.AllowClipboardKeys = true;
            this.fpdOTBRate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fpdOTBRate.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdOTBRate.DecimalPlaces = 2;
            this.fpdOTBRate.DecimalSeparator = ".";
            this.fpdOTBRate.FixedPoint = true;
            this.fpdOTBRate.Location = new System.Drawing.Point(211, 55);
            this.fpdOTBRate.Name = "fpdOTBRate";
            this.fpdOTBRate.NumberGroupSeparator = ",";
            this.fpdOTBRate.NumberGroupSize = 3;
            this.fpdOTBRate.Size = new System.Drawing.Size(104, 20);
            this.fpdOTBRate.TabIndex = 5;
            this.fpdOTBRate.Text = "";
            this.fpdOTBRate.UseSeparator = true;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(390, 299);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "ค่าเดินทางไป - กลับ (ใกล้)";
            this.label7.Visible = false;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "ค่าเดินทางไป - กลับ (ไกล)";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Absence deduction per day";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.fpdMinHolidayAmount);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.fpiMinLeave);
            this.groupBox2.Controls.Add(this.fpiTaxi);
            this.groupBox2.Controls.Add(this.fpiOneDayFar);
            this.groupBox2.Controls.Add(this.fpiOvernight);
            this.groupBox2.Controls.Add(this.fpiAbsence);
            this.groupBox2.Controls.Add(this.fpdOTCRate);
            this.groupBox2.Controls.Add(this.fpdOTBRate);
            this.groupBox2.Controls.Add(this.fpdOTARate);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(16, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(368, 300);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "รายละเอียดค่าใช้จ่าย";
            // 
            // fpdMinHolidayAmount
            // 
            this.fpdMinHolidayAmount.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdMinHolidayAmount.AllowClipboardKeys = true;
            this.fpdMinHolidayAmount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fpdMinHolidayAmount.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdMinHolidayAmount.DecimalPlaces = 2;
            this.fpdMinHolidayAmount.DecimalSeparator = ".";
            this.fpdMinHolidayAmount.FixedPoint = true;
            this.fpdMinHolidayAmount.Location = new System.Drawing.Point(211, 261);
            this.fpdMinHolidayAmount.Name = "fpdMinHolidayAmount";
            this.fpdMinHolidayAmount.NumberGroupSeparator = ",";
            this.fpdMinHolidayAmount.NumberGroupSize = 3;
            this.fpdMinHolidayAmount.Size = new System.Drawing.Size(104, 20);
            this.fpdMinHolidayAmount.TabIndex = 18;
            this.fpdMinHolidayAmount.Text = "";
            this.fpdMinHolidayAmount.UseSeparator = true;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(117, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "ค่าบริการขั้นต่ำ";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(139, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "OT rate C";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "OT rate B";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "OT rate A";
            // 
            // FrmChargeRateByServiceStaffTypeEntry
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(396, 476);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gpbStaffDetail);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.fpiOneDayNear);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmChargeRateByServiceStaffTypeEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FrmChargeRateByServiceStaffTypeEntry_Load);
            this.gpbStaffDetail.ResumeLayout(false);
            this.gpbStaffDetail.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private FarPoint.Win.Input.FpDouble fpdOTARate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private FarPoint.Win.Input.FpInteger fpiMinLeave;
        private FarPoint.Win.Input.FpInteger fpiTaxi;
        private FarPoint.Win.Input.FpInteger fpiOneDayNear;
        private FarPoint.Win.Input.FpInteger fpiOneDayFar;
        private FarPoint.Win.Input.FpInteger fpiOvernight;
        private System.Windows.Forms.GroupBox gpbStaffDetail;
        private FarPoint.Win.Input.FpInteger fpiAbsence;
        private FarPoint.Win.Input.FpDouble fpdOTCRate;
        private System.Windows.Forms.Button btnOK;
        private FarPoint.Win.Input.FpDouble fpdOTBRate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.ComboBox cboServiceStaffType;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkDriverOnly;
        private System.Windows.Forms.Label label4;
        private FarPoint.Win.Input.FpDouble fpdMinHolidayAmount;
    }
}
