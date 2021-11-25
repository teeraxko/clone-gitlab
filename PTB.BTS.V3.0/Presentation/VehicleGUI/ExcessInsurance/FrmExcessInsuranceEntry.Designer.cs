namespace Presentation.VehicleGUI.ExcessInsurance
{
    partial class FrmExcessInsuranceEntry
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpAccidentDate = new System.Windows.Forms.DateTimePicker();
            this.txtAccidentNo = new System.Windows.Forms.TextBox();
            this.txtPlateNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoBillGarage = new System.Windows.Forms.RadioButton();
            this.rdoBillInsurance = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.cboInsuranceCompany = new System.Windows.Forms.ComboBox();
            this.fpdExcessTotalAmount = new FarPoint.Win.Input.FpDouble();
            this.dtpReceiptDate = new System.Windows.Forms.DateTimePicker();
            this.txtReceiptNo = new System.Windows.Forms.TextBox();
            this.txtClaimNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.dtpAccidentDate);
            this.groupBox1.Controls.Add(this.txtAccidentNo);
            this.groupBox1.Controls.Add(this.txtPlateNo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(14, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 120);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "รายละเอียดอุบัติเหตุ";
            // 
            // dtpAccidentDate
            // 
            this.dtpAccidentDate.CustomFormat = "dd/MM/yyyy   HH:mm";
            this.dtpAccidentDate.Enabled = false;
            this.dtpAccidentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAccidentDate.Location = new System.Drawing.Point(112, 88);
            this.dtpAccidentDate.Name = "dtpAccidentDate";
            this.dtpAccidentDate.Size = new System.Drawing.Size(120, 20);
            this.dtpAccidentDate.TabIndex = 158;
            this.dtpAccidentDate.TabStop = false;
            // 
            // txtAccidentNo
            // 
            this.txtAccidentNo.Enabled = false;
            this.txtAccidentNo.Location = new System.Drawing.Point(112, 56);
            this.txtAccidentNo.Name = "txtAccidentNo";
            this.txtAccidentNo.Size = new System.Drawing.Size(120, 20);
            this.txtAccidentNo.TabIndex = 157;
            // 
            // txtPlateNo
            // 
            this.txtPlateNo.Enabled = false;
            this.txtPlateNo.Location = new System.Drawing.Point(112, 24);
            this.txtPlateNo.Name = "txtPlateNo";
            this.txtPlateNo.Size = new System.Drawing.Size(88, 20);
            this.txtPlateNo.TabIndex = 156;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(8, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 155;
            this.label2.Text = "วันเวลาเกิดอุบัติเหตุ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(20, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 154;
            this.label1.Text = "หมายเลขอุบัติเหตุ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(50, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 153;
            this.label7.Text = "ทะเบียนรถ";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.rdoBillGarage);
            this.groupBox2.Controls.Add(this.rdoBillInsurance);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cboInsuranceCompany);
            this.groupBox2.Controls.Add(this.fpdExcessTotalAmount);
            this.groupBox2.Controls.Add(this.dtpReceiptDate);
            this.groupBox2.Controls.Add(this.txtReceiptNo);
            this.groupBox2.Controls.Add(this.txtClaimNo);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(14, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(344, 216);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ค่า Excess";
            // 
            // rdoBillGarage
            // 
            this.rdoBillGarage.AutoSize = true;
            this.rdoBillGarage.Location = new System.Drawing.Point(200, 152);
            this.rdoBillGarage.Name = "rdoBillGarage";
            this.rdoBillGarage.Size = new System.Drawing.Size(105, 17);
            this.rdoBillGarage.TabIndex = 170;
            this.rdoBillGarage.Text = "ใบเสร็จจากอู่ซ่อม";
            this.rdoBillGarage.UseVisualStyleBackColor = true;
            // 
            // rdoBillInsurance
            // 
            this.rdoBillInsurance.AutoSize = true;
            this.rdoBillInsurance.Checked = true;
            this.rdoBillInsurance.Location = new System.Drawing.Point(40, 152);
            this.rdoBillInsurance.Name = "rdoBillInsurance";
            this.rdoBillInsurance.Size = new System.Drawing.Size(140, 17);
            this.rdoBillInsurance.TabIndex = 169;
            this.rdoBillInsurance.TabStop = true;
            this.rdoBillInsurance.Text = "ใบเสร็จจากบริษัทประกัน";
            this.rdoBillInsurance.UseVisualStyleBackColor = true;
            this.rdoBillInsurance.CheckedChanged += new System.EventHandler(this.rdoBillInsurance_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.Location = new System.Drawing.Point(28, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 168;
            this.label8.Text = "ชื่อบริษัทประกัน";
            // 
            // cboInsuranceCompany
            // 
            this.cboInsuranceCompany.FormattingEnabled = true;
            this.cboInsuranceCompany.Location = new System.Drawing.Point(112, 184);
            this.cboInsuranceCompany.Name = "cboInsuranceCompany";
            this.cboInsuranceCompany.Size = new System.Drawing.Size(216, 21);
            this.cboInsuranceCompany.TabIndex = 167;
            // 
            // fpdExcessTotalAmount
            // 
            this.fpdExcessTotalAmount.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdExcessTotalAmount.AllowClipboardKeys = true;
            this.fpdExcessTotalAmount.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdExcessTotalAmount.DecimalPlaces = 2;
            this.fpdExcessTotalAmount.DecimalSeparator = ".";
            this.fpdExcessTotalAmount.FixedPoint = true;
            this.fpdExcessTotalAmount.Location = new System.Drawing.Point(112, 120);
            this.fpdExcessTotalAmount.Name = "fpdExcessTotalAmount";
            this.fpdExcessTotalAmount.NumberGroupSeparator = ",";
            this.fpdExcessTotalAmount.NumberGroupSize = 3;
            this.fpdExcessTotalAmount.Size = new System.Drawing.Size(96, 20);
            this.fpdExcessTotalAmount.TabIndex = 165;
            this.fpdExcessTotalAmount.Text = "";
            this.fpdExcessTotalAmount.UseSeparator = true;
            // 
            // dtpReceiptDate
            // 
            this.dtpReceiptDate.Checked = false;
            this.dtpReceiptDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReceiptDate.Location = new System.Drawing.Point(112, 88);
            this.dtpReceiptDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpReceiptDate.Name = "dtpReceiptDate";
            this.dtpReceiptDate.ShowCheckBox = true;
            this.dtpReceiptDate.Size = new System.Drawing.Size(96, 20);
            this.dtpReceiptDate.TabIndex = 164;
            // 
            // txtReceiptNo
            // 
            this.txtReceiptNo.Location = new System.Drawing.Point(112, 56);
            this.txtReceiptNo.MaxLength = 20;
            this.txtReceiptNo.Name = "txtReceiptNo";
            this.txtReceiptNo.Size = new System.Drawing.Size(168, 20);
            this.txtReceiptNo.TabIndex = 161;
            // 
            // txtClaimNo
            // 
            this.txtClaimNo.Location = new System.Drawing.Point(112, 24);
            this.txtClaimNo.MaxLength = 20;
            this.txtClaimNo.Name = "txtClaimNo";
            this.txtClaimNo.Size = new System.Drawing.Size(168, 20);
            this.txtClaimNo.TabIndex = 160;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(53, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 159;
            this.label6.Text = "ค่า Excess";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(45, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 158;
            this.label5.Text = "วันที่ใบเสร็จ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(23, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 157;
            this.label4.Text = "หมายเลขใบเสร็จ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(57, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 156;
            this.label3.Text = "Claim No.";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(189, 356);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Location = new System.Drawing.Point(108, 356);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "ตกลง";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FrmExcessInsuranceEntry
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(373, 392);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmExcessInsuranceEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FrmExcessInsuranceEntry_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAccidentNo;
        private System.Windows.Forms.TextBox txtPlateNo;
        private System.Windows.Forms.DateTimePicker dtpAccidentDate;
        private System.Windows.Forms.TextBox txtReceiptNo;
        private System.Windows.Forms.TextBox txtClaimNo;
        private System.Windows.Forms.DateTimePicker dtpReceiptDate;
        private FarPoint.Win.Input.FpDouble fpdExcessTotalAmount;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboInsuranceCompany;
        private System.Windows.Forms.RadioButton rdoBillGarage;
        private System.Windows.Forms.RadioButton rdoBillInsurance;
    }
}