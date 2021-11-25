namespace Presentation.ContractGUI.ContractChargeRateGUI
{
    partial class FrmCustomerSpecialChargeConditionEntry
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
            this.cboCustDept = new System.Windows.Forms.ComboBox();
            this.label46 = new System.Windows.Forms.Label();
            this.lblCustDept = new System.Windows.Forms.Label();
            this.btnCharge = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmpNo = new System.Windows.Forms.TextBox();
            this.cboContract = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.lblEmpName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblEmpNo = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblContract = new System.Windows.Forms.Label();
            this.gpbSpecialCharge = new System.Windows.Forms.GroupBox();
            this.fpdSpecial = new FarPoint.Win.Input.FpDouble();
            this.fpdTelephone = new FarPoint.Win.Input.FpDouble();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gpbSpecialCharge.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.cboCustDept);
            this.groupBox1.Controls.Add(this.label46);
            this.groupBox1.Controls.Add(this.lblCustDept);
            this.groupBox1.Controls.Add(this.btnCharge);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtEmpNo);
            this.groupBox1.Controls.Add(this.cboContract);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboCustomer);
            this.groupBox1.Controls.Add(this.lblEmpName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblPosition);
            this.groupBox1.Controls.Add(this.lblEmpNo);
            this.groupBox1.Controls.Add(this.lblCustomer);
            this.groupBox1.Controls.Add(this.lblContract);
            this.groupBox1.Location = new System.Drawing.Point(16, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 208);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "รายละเอียดพนักงาน";
            // 
            // cboCustDept
            // 
            this.cboCustDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustDept.FormattingEnabled = true;
            this.cboCustDept.Location = new System.Drawing.Point(96, 144);
            this.cboCustDept.Name = "cboCustDept";
            this.cboCustDept.Size = new System.Drawing.Size(72, 21);
            this.cboCustDept.TabIndex = 26;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(36, 148);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(51, 13);
            this.label46.TabIndex = 27;
            this.label46.Text = "ฝ่ายลูกค้า";
            // 
            // lblCustDept
            // 
            this.lblCustDept.BackColor = System.Drawing.Color.White;
            this.lblCustDept.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCustDept.Location = new System.Drawing.Point(96, 144);
            this.lblCustDept.Name = "lblCustDept";
            this.lblCustDept.Size = new System.Drawing.Size(72, 21);
            this.lblCustDept.TabIndex = 28;
            this.lblCustDept.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCharge
            // 
            this.btnCharge.Location = new System.Drawing.Point(96, 176);
            this.btnCharge.Name = "btnCharge";
            this.btnCharge.Size = new System.Drawing.Size(99, 23);
            this.btnCharge.TabIndex = 4;
            this.btnCharge.Text = "กรอกรายละเอียด";
            this.btnCharge.UseVisualStyleBackColor = true;
            this.btnCharge.Click += new System.EventHandler(this.btnCharge_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "พนักงาน";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "เอกสารสัญญา";
            // 
            // txtEmpNo
            // 
            this.txtEmpNo.Location = new System.Drawing.Point(96, 28);
            this.txtEmpNo.MaxLength = 5;
            this.txtEmpNo.Name = "txtEmpNo";
            this.txtEmpNo.Size = new System.Drawing.Size(56, 20);
            this.txtEmpNo.TabIndex = 1;
            this.txtEmpNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEmpNo.DoubleClick += new System.EventHandler(this.txtEmpNo_DoubleClick);
            this.txtEmpNo.TextChanged += new System.EventHandler(this.txtEmpNo_TextChanged);
            // 
            // cboContract
            // 
            this.cboContract.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboContract.FormattingEnabled = true;
            this.cboContract.Location = new System.Drawing.Point(96, 113);
            this.cboContract.Name = "cboContract";
            this.cboContract.Size = new System.Drawing.Size(152, 21);
            this.cboContract.TabIndex = 3;
            this.cboContract.SelectedIndexChanged += new System.EventHandler(this.cboContract_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "ตำแหน่ง";
            // 
            // cboCustomer
            // 
            this.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(96, 84);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(256, 21);
            this.cboCustomer.TabIndex = 2;
            this.cboCustomer.SelectedIndexChanged += new System.EventHandler(this.cboCustomer_SelectedIndexChanged);
            // 
            // lblEmpName
            // 
            this.lblEmpName.BackColor = System.Drawing.Color.White;
            this.lblEmpName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEmpName.Location = new System.Drawing.Point(160, 28);
            this.lblEmpName.Name = "lblEmpName";
            this.lblEmpName.Size = new System.Drawing.Size(192, 20);
            this.lblEmpName.TabIndex = 11;
            this.lblEmpName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "ลูกค้า";
            // 
            // lblPosition
            // 
            this.lblPosition.BackColor = System.Drawing.Color.White;
            this.lblPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPosition.Location = new System.Drawing.Point(96, 56);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(256, 20);
            this.lblPosition.TabIndex = 12;
            this.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEmpNo
            // 
            this.lblEmpNo.BackColor = System.Drawing.Color.White;
            this.lblEmpNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEmpNo.Location = new System.Drawing.Point(96, 28);
            this.lblEmpNo.Name = "lblEmpNo";
            this.lblEmpNo.Size = new System.Drawing.Size(56, 20);
            this.lblEmpNo.TabIndex = 20;
            this.lblEmpNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCustomer
            // 
            this.lblCustomer.BackColor = System.Drawing.Color.White;
            this.lblCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCustomer.Location = new System.Drawing.Point(96, 84);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(256, 21);
            this.lblCustomer.TabIndex = 21;
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblContract
            // 
            this.lblContract.BackColor = System.Drawing.Color.White;
            this.lblContract.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblContract.Location = new System.Drawing.Point(96, 113);
            this.lblContract.Name = "lblContract";
            this.lblContract.Size = new System.Drawing.Size(152, 21);
            this.lblContract.TabIndex = 22;
            this.lblContract.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gpbSpecialCharge
            // 
            this.gpbSpecialCharge.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpbSpecialCharge.Controls.Add(this.fpdSpecial);
            this.gpbSpecialCharge.Controls.Add(this.fpdTelephone);
            this.gpbSpecialCharge.Controls.Add(this.label18);
            this.gpbSpecialCharge.Controls.Add(this.label17);
            this.gpbSpecialCharge.Controls.Add(this.label16);
            this.gpbSpecialCharge.Controls.Add(this.label12);
            this.gpbSpecialCharge.Enabled = false;
            this.gpbSpecialCharge.Location = new System.Drawing.Point(16, 216);
            this.gpbSpecialCharge.Name = "gpbSpecialCharge";
            this.gpbSpecialCharge.Size = new System.Drawing.Size(368, 88);
            this.gpbSpecialCharge.TabIndex = 92;
            this.gpbSpecialCharge.TabStop = false;
            this.gpbSpecialCharge.Text = "Special Charge";
            // 
            // fpdSpecial
            // 
            this.fpdSpecial.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdSpecial.AllowClipboardKeys = true;
            this.fpdSpecial.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdSpecial.DecimalPlaces = 2;
            this.fpdSpecial.DecimalSeparator = ".";
            this.fpdSpecial.Location = new System.Drawing.Point(96, 56);
            this.fpdSpecial.Name = "fpdSpecial";
            this.fpdSpecial.NumberGroupSeparator = ",";
            this.fpdSpecial.NumberGroupSize = 3;
            this.fpdSpecial.Size = new System.Drawing.Size(88, 20);
            this.fpdSpecial.TabIndex = 8;
            this.fpdSpecial.Text = "";
            this.fpdSpecial.UseSeparator = true;
            // 
            // fpdTelephone
            // 
            this.fpdTelephone.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdTelephone.AllowClipboardKeys = true;
            this.fpdTelephone.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdTelephone.DecimalPlaces = 2;
            this.fpdTelephone.DecimalSeparator = ".";
            this.fpdTelephone.Location = new System.Drawing.Point(96, 24);
            this.fpdTelephone.Name = "fpdTelephone";
            this.fpdTelephone.NumberGroupSeparator = ",";
            this.fpdTelephone.NumberGroupSize = 3;
            this.fpdTelephone.Size = new System.Drawing.Size(88, 20);
            this.fpdTelephone.TabIndex = 7;
            this.fpdTelephone.Text = "";
            this.fpdTelephone.UseSeparator = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(192, 24);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(46, 13);
            this.label18.TabIndex = 6;
            this.label18.Text = "บาท/คน";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(192, 56);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(46, 13);
            this.label17.TabIndex = 5;
            this.label17.Text = "บาท/คน";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(24, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "ค่าโทรศัพท์";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "ค่าใช่จ่ายพิเศษ";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(207, 322);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 94;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Location = new System.Drawing.Point(119, 322);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 93;
            this.btnOK.Text = "ตกลง";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FrmCustomerSpecialChargeConditionEntry
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(400, 356);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gpbSpecialCharge);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmCustomerSpecialChargeConditionEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FrmCustomerSpecialChargeConditionEntry_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpbSpecialCharge.ResumeLayout(false);
            this.gpbSpecialCharge.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCharge;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmpNo;
        private System.Windows.Forms.ComboBox cboContract;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.Label lblEmpName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblEmpNo;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblContract;
        protected internal System.Windows.Forms.GroupBox gpbSpecialCharge;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private FarPoint.Win.Input.FpDouble fpdTelephone;
        private FarPoint.Win.Input.FpDouble fpdSpecial;
        private System.Windows.Forms.ComboBox cboCustDept;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label lblCustDept;
    }
}