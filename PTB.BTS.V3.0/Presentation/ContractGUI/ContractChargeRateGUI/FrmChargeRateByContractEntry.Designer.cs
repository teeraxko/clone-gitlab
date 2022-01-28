namespace Presentation.ContractGUI.ContractChargeRateGUI
{
    partial class FrmChargeRateByContractEntry
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fpdMinHolidayAmount = new FarPoint.Win.Input.FpDouble();
            this.label4 = new System.Windows.Forms.Label();
            this.fpiMinLeave = new FarPoint.Win.Input.FpInteger();
            this.fpiTaxi = new FarPoint.Win.Input.FpInteger();
            this.fpiOneDayFar = new FarPoint.Win.Input.FpInteger();
            this.fpiOvernight = new FarPoint.Win.Input.FpInteger();
            this.fpiAbsence = new FarPoint.Win.Input.FpInteger();
            this.fpdOTCRate = new FarPoint.Win.Input.FpDouble();
            this.fpdOTBRate = new FarPoint.Win.Input.FpDouble();
            this.fpdOTARate = new FarPoint.Win.Input.FpDouble();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fpiOneDayNear = new FarPoint.Win.Input.FpInteger();
            this.label7 = new System.Windows.Forms.Label();
            this.gpbContractDetail = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblContractPrefix = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtContractNoXXX = new System.Windows.Forms.TextBox();
            this.txtContractNoMM = new System.Windows.Forms.TextBox();
            this.txtContractNoYY = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.gpbContractDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
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
            this.groupBox2.Location = new System.Drawing.Point(17, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(288, 289);
            this.groupBox2.TabIndex = 1;
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
            this.fpdMinHolidayAmount.Location = new System.Drawing.Point(164, 256);
            this.fpdMinHolidayAmount.Name = "fpdMinHolidayAmount";
            this.fpdMinHolidayAmount.NumberGroupSeparator = ",";
            this.fpdMinHolidayAmount.NumberGroupSize = 3;
            this.fpdMinHolidayAmount.Size = new System.Drawing.Size(104, 20);
            this.fpdMinHolidayAmount.TabIndex = 19;
            this.fpdMinHolidayAmount.Text = "";
            this.fpdMinHolidayAmount.UseSeparator = true;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "ค่าบริการขั้นต่ำ";
            // 
            // fpiMinLeave
            // 
            this.fpiMinLeave.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiMinLeave.AllowClipboardKeys = true;
            this.fpiMinLeave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fpiMinLeave.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiMinLeave.Location = new System.Drawing.Point(164, 224);
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
            this.fpiTaxi.Location = new System.Drawing.Point(164, 195);
            this.fpiTaxi.MaxValue = 32000;
            this.fpiTaxi.MinValue = 0;
            this.fpiTaxi.Name = "fpiTaxi";
            this.fpiTaxi.Size = new System.Drawing.Size(104, 20);
            this.fpiTaxi.TabIndex = 12;
            this.fpiTaxi.Text = "";
            this.fpiTaxi.UseSeparator = true;
            // 
            // fpiOneDayFar
            // 
            this.fpiOneDayFar.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiOneDayFar.AllowClipboardKeys = true;
            this.fpiOneDayFar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fpiOneDayFar.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiOneDayFar.Location = new System.Drawing.Point(164, 140);
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
            this.fpiOvernight.Location = new System.Drawing.Point(164, 166);
            this.fpiOvernight.MaxValue = 32000;
            this.fpiOvernight.MinValue = 0;
            this.fpiOvernight.Name = "fpiOvernight";
            this.fpiOvernight.Size = new System.Drawing.Size(104, 20);
            this.fpiOvernight.TabIndex = 11;
            this.fpiOvernight.Text = "";
            this.fpiOvernight.UseSeparator = true;
            // 
            // fpiAbsence
            // 
            this.fpiAbsence.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiAbsence.AllowClipboardKeys = true;
            this.fpiAbsence.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fpiAbsence.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiAbsence.Location = new System.Drawing.Point(164, 111);
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
            this.fpdOTCRate.Location = new System.Drawing.Point(164, 78);
            this.fpdOTCRate.Name = "fpdOTCRate";
            this.fpdOTCRate.NumberGroupSeparator = ",";
            this.fpdOTCRate.NumberGroupSize = 3;
            this.fpdOTCRate.Size = new System.Drawing.Size(104, 20);
            this.fpdOTCRate.TabIndex = 6;
            this.fpdOTCRate.Text = "";
            this.fpdOTCRate.UseSeparator = true;
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
            this.fpdOTBRate.Location = new System.Drawing.Point(164, 49);
            this.fpdOTBRate.Name = "fpdOTBRate";
            this.fpdOTBRate.NumberGroupSeparator = ",";
            this.fpdOTBRate.NumberGroupSize = 3;
            this.fpdOTBRate.Size = new System.Drawing.Size(104, 20);
            this.fpdOTBRate.TabIndex = 5;
            this.fpdOTBRate.Text = "";
            this.fpdOTBRate.UseSeparator = true;
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
            this.fpdOTARate.Location = new System.Drawing.Point(164, 20);
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
            this.label11.Location = new System.Drawing.Point(88, 228);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "วันลาขั้นต่ำ";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(104, 199);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "ค่า Taxi";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(55, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = " ค่าเดินทางค้างคืน";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "ค่าเดินทางไป - กลับ (ไกล)";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Absence deduction per day";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "OT rate C";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "OT rate B";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "OT rate A";
            // 
            // fpiOneDayNear
            // 
            this.fpiOneDayNear.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiOneDayNear.AllowClipboardKeys = true;
            this.fpiOneDayNear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fpiOneDayNear.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiOneDayNear.Location = new System.Drawing.Point(455, 223);
            this.fpiOneDayNear.MaxValue = 32000;
            this.fpiOneDayNear.MinValue = 0;
            this.fpiOneDayNear.Name = "fpiOneDayNear";
            this.fpiOneDayNear.Size = new System.Drawing.Size(104, 20);
            this.fpiOneDayNear.TabIndex = 10;
            this.fpiOneDayNear.Text = "";
            this.fpiOneDayNear.UseSeparator = true;
            this.fpiOneDayNear.Visible = false;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(311, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "ค่าเดินทางไป - กลับ (ใกล้)";
            this.label7.Visible = false;
            // 
            // gpbContractDetail
            // 
            this.gpbContractDetail.Controls.Add(this.label13);
            this.gpbContractDetail.Controls.Add(this.lblContractPrefix);
            this.gpbContractDetail.Controls.Add(this.label16);
            this.gpbContractDetail.Controls.Add(this.txtContractNoXXX);
            this.gpbContractDetail.Controls.Add(this.txtContractNoMM);
            this.gpbContractDetail.Controls.Add(this.txtContractNoYY);
            this.gpbContractDetail.Controls.Add(this.label8);
            this.gpbContractDetail.Location = new System.Drawing.Point(17, 8);
            this.gpbContractDetail.Name = "gpbContractDetail";
            this.gpbContractDetail.Size = new System.Drawing.Size(288, 56);
            this.gpbContractDetail.TabIndex = 0;
            this.gpbContractDetail.TabStop = false;
            this.gpbContractDetail.Text = "รายละเอียดในสัญญา";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label13.Location = new System.Drawing.Point(138, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 17);
            this.label13.TabIndex = 156;
            this.label13.Text = " -";
            // 
            // lblContractPrefix
            // 
            this.lblContractPrefix.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblContractPrefix.AutoSize = true;
            this.lblContractPrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblContractPrefix.Location = new System.Drawing.Point(123, 23);
            this.lblContractPrefix.Name = "lblContractPrefix";
            this.lblContractPrefix.Size = new System.Drawing.Size(18, 17);
            this.lblContractPrefix.TabIndex = 156;
            this.lblContractPrefix.Text = "D";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label16.Location = new System.Drawing.Point(80, 23);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 17);
            this.label16.TabIndex = 155;
            this.label16.Text = "PTB - ";
            // 
            // txtContractNoXXX
            // 
            this.txtContractNoXXX.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtContractNoXXX.Location = new System.Drawing.Point(231, 22);
            this.txtContractNoXXX.MaxLength = 3;
            this.txtContractNoXXX.Name = "txtContractNoXXX";
            this.txtContractNoXXX.Size = new System.Drawing.Size(32, 20);
            this.txtContractNoXXX.TabIndex = 3;
            this.txtContractNoXXX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtContractNoXXX.DoubleClick += new System.EventHandler(this.txtContractNoXXX_DoubleClick);
            this.txtContractNoXXX.TextChanged += new System.EventHandler(this.txtContractNoXXX_TextChanged);
            this.txtContractNoXXX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContractNoXXX_KeyDown);
            // 
            // txtContractNoMM
            // 
            this.txtContractNoMM.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtContractNoMM.Location = new System.Drawing.Point(197, 22);
            this.txtContractNoMM.MaxLength = 2;
            this.txtContractNoMM.Name = "txtContractNoMM";
            this.txtContractNoMM.Size = new System.Drawing.Size(32, 20);
            this.txtContractNoMM.TabIndex = 2;
            this.txtContractNoMM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtContractNoMM.TextChanged += new System.EventHandler(this.txtContractNoMM_TextChanged);
            // 
            // txtContractNoYY
            // 
            this.txtContractNoYY.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtContractNoYY.Location = new System.Drawing.Point(163, 22);
            this.txtContractNoYY.MaxLength = 2;
            this.txtContractNoYY.Name = "txtContractNoYY";
            this.txtContractNoYY.Size = new System.Drawing.Size(32, 20);
            this.txtContractNoYY.TabIndex = 1;
            this.txtContractNoYY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtContractNoYY.TextChanged += new System.EventHandler(this.txtContractNoYY_TextChanged);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "เลขที่สัญญา";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(174, 367);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Location = new System.Drawing.Point(93, 367);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "ตกลง";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FrmChargeRateByContractEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(322, 402);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gpbContractDetail);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.fpiOneDayNear);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmChargeRateByContractEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FrmChargeRateByContractEntry_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gpbContractDetail.ResumeLayout(false);
            this.gpbContractDetail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gpbContractDetail;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtContractNoXXX;
        private System.Windows.Forms.TextBox txtContractNoMM;
        private System.Windows.Forms.TextBox txtContractNoYY;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private FarPoint.Win.Input.FpDouble fpdOTARate;
        private FarPoint.Win.Input.FpDouble fpdOTCRate;
        private FarPoint.Win.Input.FpDouble fpdOTBRate;
        private FarPoint.Win.Input.FpInteger fpiMinLeave;
        private FarPoint.Win.Input.FpInteger fpiTaxi;
        private FarPoint.Win.Input.FpInteger fpiOneDayNear;
        private FarPoint.Win.Input.FpInteger fpiOneDayFar;
        private FarPoint.Win.Input.FpInteger fpiOvernight;
        private FarPoint.Win.Input.FpInteger fpiAbsence;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label4;
        private FarPoint.Win.Input.FpDouble fpdMinHolidayAmount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblContractPrefix;
    }
}
