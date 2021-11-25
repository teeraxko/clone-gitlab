namespace PTB.PIS.Welfare.WindowsApp.LoanGUI {
    partial class FrmLoanApplicationEnt {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpOffsetDate = new System.Windows.Forms.DateTimePicker();
            this.chkOffset = new System.Windows.Forms.CheckBox();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.txtPeriod = new FarPoint.Win.Input.FpInteger();
            this.txtInterest = new FarPoint.Win.Input.FpDouble();
            this.txtCapitalAmount = new FarPoint.Win.Input.FpDouble();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpAppliedDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPurpose = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grdData = new System.Windows.Forms.DataGridView();
            this.colForYearMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIntAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInterest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaymentStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblPaid = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCalculate);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.dtpOffsetDate);
            this.groupBox1.Controls.Add(this.chkOffset);
            this.groupBox1.Controls.Add(this.lblEndDate);
            this.groupBox1.Controls.Add(this.txtPeriod);
            this.groupBox1.Controls.Add(this.txtInterest);
            this.groupBox1.Controls.Add(this.txtCapitalAmount);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dtpStartDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpAppliedDate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbPurpose);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(543, 145);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCalculate.Location = new System.Drawing.Point(94, 116);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(146, 23);
            this.btnCalculate.TabIndex = 8;
            this.btnCalculate.Text = "คำนวนตารางการผ่อนชำระ";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(211, 94);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 13);
            this.label14.TabIndex = 45;
            this.label14.Text = "วันที่ Offset";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpOffsetDate
            // 
            this.dtpOffsetDate.CustomFormat = "dd/MM/yyyy";
            this.dtpOffsetDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOffsetDate.Location = new System.Drawing.Point(278, 90);
            this.dtpOffsetDate.Name = "dtpOffsetDate";
            this.dtpOffsetDate.Size = new System.Drawing.Size(93, 20);
            this.dtpOffsetDate.TabIndex = 7;
            // 
            // chkOffset
            // 
            this.chkOffset.AutoSize = true;
            this.chkOffset.Location = new System.Drawing.Point(83, 93);
            this.chkOffset.Name = "chkOffset";
            this.chkOffset.Size = new System.Drawing.Size(54, 17);
            this.chkOffset.TabIndex = 6;
            this.chkOffset.Text = "Offset";
            this.chkOffset.UseVisualStyleBackColor = true;
            this.chkOffset.CheckedChanged += new System.EventHandler(this.chkOffset_CheckedChanged);
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(460, 68);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(0, 13);
            this.lblEndDate.TabIndex = 42;
            // 
            // txtPeriod
            // 
            this.txtPeriod.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.txtPeriod.AllowClipboardKeys = true;
            this.txtPeriod.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.txtPeriod.Location = new System.Drawing.Point(278, 64);
            this.txtPeriod.MaxValue = 60;
            this.txtPeriod.MinValue = 1;
            this.txtPeriod.Name = "txtPeriod";
            this.txtPeriod.Size = new System.Drawing.Size(76, 20);
            this.txtPeriod.TabIndex = 5;
            this.txtPeriod.Text = "0";
            this.txtPeriod.ValueChanged += new System.EventHandler(this.txtPeriod_ValueChanged);
            // 
            // txtInterest
            // 
            this.txtInterest.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.txtInterest.AllowClipboardKeys = true;
            this.txtInterest.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.txtInterest.DecimalPlaces = 2;
            this.txtInterest.DecimalSeparator = ".";
            this.txtInterest.FixedPoint = true;
            this.txtInterest.Location = new System.Drawing.Point(278, 38);
            this.txtInterest.Name = "txtInterest";
            this.txtInterest.NumberGroupSeparator = ",";
            this.txtInterest.Size = new System.Drawing.Size(76, 20);
            this.txtInterest.TabIndex = 3;
            this.txtInterest.Text = "0.00";
            this.txtInterest.UseSeparator = true;
            // 
            // txtCapitalAmount
            // 
            this.txtCapitalAmount.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.txtCapitalAmount.AllowClipboardKeys = true;
            this.txtCapitalAmount.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.txtCapitalAmount.DecimalPlaces = 2;
            this.txtCapitalAmount.DecimalSeparator = ".";
            this.txtCapitalAmount.FixedPoint = true;
            this.txtCapitalAmount.Location = new System.Drawing.Point(83, 38);
            this.txtCapitalAmount.Name = "txtCapitalAmount";
            this.txtCapitalAmount.NumberGroupSeparator = ",";
            this.txtCapitalAmount.Size = new System.Drawing.Size(121, 20);
            this.txtCapitalAmount.TabIndex = 2;
            this.txtCapitalAmount.Text = "0.00";
            this.txtCapitalAmount.UseSeparator = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(373, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "สิ้นสุด (เดือน/ปี)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "MM/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(83, 64);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(66, 20);
            this.dtpStartDate.TabIndex = 4;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "เริ่ม(เดือน/ปี)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpAppliedDate
            // 
            this.dtpAppliedDate.CustomFormat = "dd/MM/yyyy";
            this.dtpAppliedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAppliedDate.Location = new System.Drawing.Point(83, 12);
            this.dtpAppliedDate.Name = "dtpAppliedDate";
            this.dtpAppliedDate.Size = new System.Drawing.Size(120, 20);
            this.dtpAppliedDate.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(185, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "ระยะเวลา (เดือน)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "วันที่ยื่นขอกู้ :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbPurpose
            // 
            this.cmbPurpose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPurpose.FormattingEnabled = true;
            this.cmbPurpose.Items.AddRange(new object[] {
            "==เลือกรายการ==",
            "ซ่อมแซมที่อยู่อาศัย"});
            this.cmbPurpose.Location = new System.Drawing.Point(278, 12);
            this.cmbPurpose.Name = "cmbPurpose";
            this.cmbPurpose.Size = new System.Drawing.Size(235, 21);
            this.cmbPurpose.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(246, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 13);
            this.label12.TabIndex = 33;
            this.label12.Text = "เพื่อ";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(209, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "ดอกเบี้ย (%)";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "เงินต้น (บาท)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupBox2.Controls.Add(this.grdData);
            this.groupBox2.Location = new System.Drawing.Point(5, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(532, 279);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // grdData
            // 
            this.grdData.AllowUserToAddRows = false;
            this.grdData.AllowUserToDeleteRows = false;
            this.grdData.AllowUserToResizeColumns = false;
            this.grdData.AllowUserToResizeRows = false;
            this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colForYearMonth,
            this.colIntAmount,
            this.colInterest,
            this.colTotalAmount,
            this.colPaymentStatus});
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.Location = new System.Drawing.Point(3, 16);
            this.grdData.MultiSelect = false;
            this.grdData.Name = "grdData";
            this.grdData.ReadOnly = true;
            this.grdData.RowHeadersWidth = 50;
            this.grdData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdData.Size = new System.Drawing.Size(526, 260);
            this.grdData.TabIndex = 5;
            // 
            // colForYearMonth
            // 
            this.colForYearMonth.HeaderText = "เดือน/ปี";
            this.colForYearMonth.Name = "colForYearMonth";
            this.colForYearMonth.ReadOnly = true;
            this.colForYearMonth.Width = 70;
            // 
            // colIntAmount
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colIntAmount.DefaultCellStyle = dataGridViewCellStyle1;
            this.colIntAmount.HeaderText = "เงินต้น";
            this.colIntAmount.Name = "colIntAmount";
            this.colIntAmount.ReadOnly = true;
            // 
            // colInterest
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colInterest.DefaultCellStyle = dataGridViewCellStyle2;
            this.colInterest.HeaderText = "ดอกเบี้ย";
            this.colInterest.Name = "colInterest";
            this.colInterest.ReadOnly = true;
            this.colInterest.Width = 70;
            // 
            // colTotalAmount
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colTotalAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.colTotalAmount.HeaderText = "รวม";
            this.colTotalAmount.Name = "colTotalAmount";
            this.colTotalAmount.ReadOnly = true;
            // 
            // colPaymentStatus
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colPaymentStatus.DefaultCellStyle = dataGridViewCellStyle4;
            this.colPaymentStatus.HeaderText = "สถานะ";
            this.colPaymentStatus.Name = "colPaymentStatus";
            this.colPaymentStatus.ReadOnly = true;
            this.colPaymentStatus.Width = 120;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 427);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "จำนวนเงินทั้งหมดที่ต้องผ่อนชำระ";
            this.label2.Visible = false;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTotal.Location = new System.Drawing.Point(189, 427);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 13);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "xxxxxxx";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotal.Visible = false;
            // 
            // lblPaid
            // 
            this.lblPaid.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblPaid.Location = new System.Drawing.Point(189, 447);
            this.lblPaid.Name = "lblPaid";
            this.lblPaid.Size = new System.Drawing.Size(100, 13);
            this.lblPaid.TabIndex = 5;
            this.lblPaid.Text = "xxxxxxx";
            this.lblPaid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPaid.Visible = false;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(93, 447);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "จำนวนที่ชำระแล้ว";
            this.label10.Visible = false;
            // 
            // lblBalance
            // 
            this.lblBalance.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblBalance.Location = new System.Drawing.Point(189, 467);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(100, 13);
            this.lblBalance.TabIndex = 7;
            this.lblBalance.Text = "xxxxxxx";
            this.lblBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblBalance.Visible = false;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(89, 467);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 13);
            this.label13.TabIndex = 6;
            this.label13.Text = "จำนวนเงินคงเหลือ";
            this.label13.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.Location = new System.Drawing.Point(276, 494);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Location = new System.Drawing.Point(192, 494);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "ตกลง";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FrmLoanApplicationEnt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 529);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblPaid);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MinimizeBox = false;
            this.Name = "FrmLoanApplicationEnt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmLoanApplicationEnt";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmLoanApplicationEnt_FormClosed);
            this.Load += new System.EventHandler(this.FrmLoanApplicationEnt_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpAppliedDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPurpose;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView grdData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblPaid;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private FarPoint.Win.Input.FpDouble txtInterest;
        private FarPoint.Win.Input.FpDouble txtCapitalAmount;
        private FarPoint.Win.Input.FpInteger txtPeriod;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtpOffsetDate;
        private System.Windows.Forms.CheckBox chkOffset;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colForYearMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIntAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInterest;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaymentStatus;
    }
}