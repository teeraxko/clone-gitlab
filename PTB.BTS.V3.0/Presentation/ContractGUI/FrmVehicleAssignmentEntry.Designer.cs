namespace Presentation.ContractGUI
{
    partial class FrmVehicleAssignmentEntry
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
            this.gpbVehicle = new System.Windows.Forms.GroupBox();
            this.lblPlateNo = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblPlatePrefix = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAssignPlatePrefix = new System.Windows.Forms.TextBox();
            this.fpiAssignRunningNo = new FarPoint.Win.Input.FpInteger();
            this.txtBrandName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gpbDetail = new System.Windows.Forms.GroupBox();
            this.txtDriverName = new System.Windows.Forms.TextBox();
            this.txtDriverNo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cboAssignmentReason = new System.Windows.Forms.ComboBox();
            this.fpiMainRunningNo = new FarPoint.Win.Input.FpInteger();
            this.txtHirerName = new System.Windows.Forms.TextBox();
            this.txtMainPlatePrefix = new System.Windows.Forms.TextBox();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblContractDetail = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtDeptName = new System.Windows.Forms.TextBox();
            this.txtCutsName = new System.Windows.Forms.TextBox();
            this.txtContractNoXXX = new System.Windows.Forms.TextBox();
            this.txtContractNoMM = new System.Windows.Forms.TextBox();
            this.txtContractNoYY = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.gpbVehicle.SuspendLayout();
            this.gpbDetail.SuspendLayout();
            this.lblContractDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbVehicle
            // 
            this.gpbVehicle.Controls.Add(this.lblPlateNo);
            this.gpbVehicle.Controls.Add(this.label14);
            this.gpbVehicle.Controls.Add(this.lblPlatePrefix);
            this.gpbVehicle.Controls.Add(this.label11);
            this.gpbVehicle.Controls.Add(this.txtAssignPlatePrefix);
            this.gpbVehicle.Controls.Add(this.fpiAssignRunningNo);
            this.gpbVehicle.Controls.Add(this.txtBrandName);
            this.gpbVehicle.Controls.Add(this.label2);
            this.gpbVehicle.Controls.Add(this.label1);
            this.gpbVehicle.Location = new System.Drawing.Point(13, 12);
            this.gpbVehicle.Name = "gpbVehicle";
            this.gpbVehicle.Size = new System.Drawing.Size(393, 85);
            this.gpbVehicle.TabIndex = 0;
            this.gpbVehicle.TabStop = false;
            this.gpbVehicle.Text = "ทะเบียนรถ";
            // 
            // lblPlateNo
            // 
            this.lblPlateNo.AutoSize = true;
            this.lblPlateNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPlateNo.Location = new System.Drawing.Point(312, 19);
            this.lblPlateNo.Name = "lblPlateNo";
            this.lblPlateNo.Size = new System.Drawing.Size(60, 26);
            this.lblPlateNo.TabIndex = 8;
            this.lblPlateNo.Text = "9999";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label14.Location = new System.Drawing.Point(296, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(19, 26);
            this.label14.TabIndex = 7;
            this.label14.Text = "-";
            // 
            // lblPlatePrefix
            // 
            this.lblPlatePrefix.AutoSize = true;
            this.lblPlatePrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPlatePrefix.Location = new System.Drawing.Point(248, 19);
            this.lblPlatePrefix.Name = "lblPlatePrefix";
            this.lblPlatePrefix.Size = new System.Drawing.Size(48, 26);
            this.lblPlatePrefix.TabIndex = 6;
            this.lblPlatePrefix.Text = "ฮฮฮ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label11.Location = new System.Drawing.Point(168, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(13, 17);
            this.label11.TabIndex = 5;
            this.label11.Text = "-";
            // 
            // txtAssignPlatePrefix
            // 
            this.txtAssignPlatePrefix.Enabled = false;
            this.txtAssignPlatePrefix.Location = new System.Drawing.Point(128, 24);
            this.txtAssignPlatePrefix.MaxLength = 3;
            this.txtAssignPlatePrefix.Name = "txtAssignPlatePrefix";
            this.txtAssignPlatePrefix.Size = new System.Drawing.Size(36, 20);
            this.txtAssignPlatePrefix.TabIndex = 4;
            this.txtAssignPlatePrefix.TextChanged += new System.EventHandler(this.txtAssignPlatePrefix_TextChanged);
            // 
            // fpiAssignRunningNo
            // 
            this.fpiAssignRunningNo.AllowClipboardKeys = true;
            this.fpiAssignRunningNo.AllowNull = true;
            this.fpiAssignRunningNo.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiAssignRunningNo.Enabled = false;
            this.fpiAssignRunningNo.Location = new System.Drawing.Point(184, 24);
            this.fpiAssignRunningNo.MaxValue = 9999;
            this.fpiAssignRunningNo.MinValue = 0;
            this.fpiAssignRunningNo.Name = "fpiAssignRunningNo";
            this.fpiAssignRunningNo.NullColor = System.Drawing.Color.Transparent;
            this.fpiAssignRunningNo.Size = new System.Drawing.Size(48, 20);
            this.fpiAssignRunningNo.TabIndex = 3;
            this.fpiAssignRunningNo.Text = "";
            this.fpiAssignRunningNo.TextChanged += new System.EventHandler(this.fpiAssignRunningNo_TextChanged);
            // 
            // txtBrandName
            // 
            this.txtBrandName.Enabled = false;
            this.txtBrandName.Location = new System.Drawing.Point(128, 56);
            this.txtBrandName.Name = "txtBrandName";
            this.txtBrandName.Size = new System.Drawing.Size(248, 20);
            this.txtBrandName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "ยี่ห้อรถ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ทะเบียนรถ";
            // 
            // gpbDetail
            // 
            this.gpbDetail.Controls.Add(this.txtDriverName);
            this.gpbDetail.Controls.Add(this.txtDriverNo);
            this.gpbDetail.Controls.Add(this.label13);
            this.gpbDetail.Controls.Add(this.label12);
            this.gpbDetail.Controls.Add(this.cboAssignmentReason);
            this.gpbDetail.Controls.Add(this.fpiMainRunningNo);
            this.gpbDetail.Controls.Add(this.txtHirerName);
            this.gpbDetail.Controls.Add(this.txtMainPlatePrefix);
            this.gpbDetail.Controls.Add(this.dtpToDate);
            this.gpbDetail.Controls.Add(this.dtpFromDate);
            this.gpbDetail.Controls.Add(this.label7);
            this.gpbDetail.Controls.Add(this.label6);
            this.gpbDetail.Controls.Add(this.label5);
            this.gpbDetail.Controls.Add(this.label4);
            this.gpbDetail.Controls.Add(this.label3);
            this.gpbDetail.Location = new System.Drawing.Point(13, 103);
            this.gpbDetail.Name = "gpbDetail";
            this.gpbDetail.Size = new System.Drawing.Size(393, 209);
            this.gpbDetail.TabIndex = 1;
            this.gpbDetail.TabStop = false;
            this.gpbDetail.Text = "รายละเอียดการจ่ายงาน";
            // 
            // txtDriverName
            // 
            this.txtDriverName.Enabled = false;
            this.txtDriverName.Location = new System.Drawing.Point(192, 112);
            this.txtDriverName.Name = "txtDriverName";
            this.txtDriverName.Size = new System.Drawing.Size(184, 20);
            this.txtDriverName.TabIndex = 17;
            // 
            // txtDriverNo
            // 
            this.txtDriverNo.Enabled = false;
            this.txtDriverNo.Location = new System.Drawing.Point(128, 112);
            this.txtDriverNo.Name = "txtDriverNo";
            this.txtDriverNo.Size = new System.Drawing.Size(56, 20);
            this.txtDriverNo.TabIndex = 16;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 115);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "พนักงานขับรถ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label12.Location = new System.Drawing.Point(168, 80);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 17);
            this.label12.TabIndex = 13;
            this.label12.Text = "-";
            // 
            // cboAssignmentReason
            // 
            this.cboAssignmentReason.Location = new System.Drawing.Point(128, 168);
            this.cboAssignmentReason.MaxLength = 50;
            this.cboAssignmentReason.Name = "cboAssignmentReason";
            this.cboAssignmentReason.Size = new System.Drawing.Size(248, 21);
            this.cboAssignmentReason.TabIndex = 12;
            // 
            // fpiMainRunningNo
            // 
            this.fpiMainRunningNo.AllowClipboardKeys = true;
            this.fpiMainRunningNo.AllowNull = true;
            this.fpiMainRunningNo.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiMainRunningNo.Location = new System.Drawing.Point(184, 80);
            this.fpiMainRunningNo.MaxValue = 9999;
            this.fpiMainRunningNo.MinValue = 0;
            this.fpiMainRunningNo.Name = "fpiMainRunningNo";
            this.fpiMainRunningNo.NullColor = System.Drawing.Color.Transparent;
            this.fpiMainRunningNo.Size = new System.Drawing.Size(48, 20);
            this.fpiMainRunningNo.TabIndex = 10;
            this.fpiMainRunningNo.Text = "";
            this.fpiMainRunningNo.DoubleClick += new System.EventHandler(this.fpiMainRunningNo_DoubleClick);
            this.fpiMainRunningNo.TextChanged += new System.EventHandler(this.fpiMainRunningNo_TextChanged);
            // 
            // txtHirerName
            // 
            this.txtHirerName.Location = new System.Drawing.Point(128, 140);
            this.txtHirerName.MaxLength = 60;
            this.txtHirerName.Name = "txtHirerName";
            this.txtHirerName.Size = new System.Drawing.Size(248, 20);
            this.txtHirerName.TabIndex = 11;
            // 
            // txtMainPlatePrefix
            // 
            this.txtMainPlatePrefix.Location = new System.Drawing.Point(128, 80);
            this.txtMainPlatePrefix.MaxLength = 3;
            this.txtMainPlatePrefix.Name = "txtMainPlatePrefix";
            this.txtMainPlatePrefix.Size = new System.Drawing.Size(36, 20);
            this.txtMainPlatePrefix.TabIndex = 9;
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(128, 52);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(96, 20);
            this.dtpToDate.TabIndex = 8;
            this.dtpToDate.Leave += new System.EventHandler(this.dtpToDate_Leave);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(128, 24);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(96, 20);
            this.dtpFromDate.TabIndex = 7;
            this.dtpFromDate.Leave += new System.EventHandler(this.dtpFromDate_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "เหตุผลในการจ่ายงาน";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "ชื่อนายจ้าง";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "แทนรถเลขทะเบียน";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "วันที่สิ้นสุด";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "วันที่เริ่มต้น";
            // 
            // lblContractDetail
            // 
            this.lblContractDetail.Controls.Add(this.label16);
            this.lblContractDetail.Controls.Add(this.txtDeptName);
            this.lblContractDetail.Controls.Add(this.txtCutsName);
            this.lblContractDetail.Controls.Add(this.txtContractNoXXX);
            this.lblContractDetail.Controls.Add(this.txtContractNoMM);
            this.lblContractDetail.Controls.Add(this.txtContractNoYY);
            this.lblContractDetail.Controls.Add(this.label10);
            this.lblContractDetail.Controls.Add(this.label9);
            this.lblContractDetail.Controls.Add(this.label8);
            this.lblContractDetail.Location = new System.Drawing.Point(14, 320);
            this.lblContractDetail.Name = "lblContractDetail";
            this.lblContractDetail.Size = new System.Drawing.Size(392, 110);
            this.lblContractDetail.TabIndex = 1;
            this.lblContractDetail.TabStop = false;
            this.lblContractDetail.Text = "รายละเอียดในสัญญา";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label16.Location = new System.Drawing.Point(128, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(66, 17);
            this.label16.TabIndex = 155;
            this.label16.Text = "PTB - C -";
            // 
            // txtDeptName
            // 
            this.txtDeptName.Enabled = false;
            this.txtDeptName.Location = new System.Drawing.Point(128, 78);
            this.txtDeptName.Name = "txtDeptName";
            this.txtDeptName.Size = new System.Drawing.Size(136, 20);
            this.txtDeptName.TabIndex = 151;
            // 
            // txtCutsName
            // 
            this.txtCutsName.Enabled = false;
            this.txtCutsName.Location = new System.Drawing.Point(128, 48);
            this.txtCutsName.Name = "txtCutsName";
            this.txtCutsName.Size = new System.Drawing.Size(136, 20);
            this.txtCutsName.TabIndex = 150;
            // 
            // txtContractNoXXX
            // 
            this.txtContractNoXXX.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtContractNoXXX.Enabled = false;
            this.txtContractNoXXX.Location = new System.Drawing.Point(271, 22);
            this.txtContractNoXXX.MaxLength = 3;
            this.txtContractNoXXX.Name = "txtContractNoXXX";
            this.txtContractNoXXX.Size = new System.Drawing.Size(32, 20);
            this.txtContractNoXXX.TabIndex = 149;
            this.txtContractNoXXX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtContractNoMM
            // 
            this.txtContractNoMM.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtContractNoMM.Enabled = false;
            this.txtContractNoMM.Location = new System.Drawing.Point(234, 22);
            this.txtContractNoMM.MaxLength = 2;
            this.txtContractNoMM.Name = "txtContractNoMM";
            this.txtContractNoMM.Size = new System.Drawing.Size(32, 20);
            this.txtContractNoMM.TabIndex = 148;
            this.txtContractNoMM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtContractNoYY
            // 
            this.txtContractNoYY.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtContractNoYY.Enabled = false;
            this.txtContractNoYY.Location = new System.Drawing.Point(197, 22);
            this.txtContractNoYY.MaxLength = 2;
            this.txtContractNoYY.Name = "txtContractNoYY";
            this.txtContractNoYY.Size = new System.Drawing.Size(32, 20);
            this.txtContractNoYY.TabIndex = 147;
            this.txtContractNoYY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "ฝ่ายลูกค้า";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "ชื่อลูกค้า";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "เลขที่สัญญาปัจจุบัน";
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdOK.Location = new System.Drawing.Point(128, 440);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 2;
            this.cmdOK.Text = "ตกลง";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(216, 440);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "ยกเลิก";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // FrmVehicleAssignmentEntry
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(419, 473);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.gpbDetail);
            this.Controls.Add(this.lblContractDetail);
            this.Controls.Add(this.gpbVehicle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FrmVehicleAssignmentEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmVehicleAssignmentEntry_Load);
            this.gpbVehicle.ResumeLayout(false);
            this.gpbVehicle.PerformLayout();
            this.gpbDetail.ResumeLayout(false);
            this.gpbDetail.PerformLayout();
            this.lblContractDetail.ResumeLayout(false);
            this.lblContractDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbVehicle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gpbDetail;
        private System.Windows.Forms.GroupBox lblContractDetail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.TextBox txtAssignPlatePrefix;
        private FarPoint.Win.Input.FpInteger fpiAssignRunningNo;
        private System.Windows.Forms.TextBox txtBrandName;
        private System.Windows.Forms.ComboBox cboAssignmentReason;
        private FarPoint.Win.Input.FpInteger fpiMainRunningNo;
        private System.Windows.Forms.TextBox txtHirerName;
        private System.Windows.Forms.TextBox txtMainPlatePrefix;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDeptName;
        private System.Windows.Forms.TextBox txtCutsName;
        private System.Windows.Forms.TextBox txtContractNoXXX;
        private System.Windows.Forms.TextBox txtContractNoMM;
        private System.Windows.Forms.TextBox txtContractNoYY;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblPlateNo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblPlatePrefix;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDriverName;
        private System.Windows.Forms.TextBox txtDriverNo;
    }
}
