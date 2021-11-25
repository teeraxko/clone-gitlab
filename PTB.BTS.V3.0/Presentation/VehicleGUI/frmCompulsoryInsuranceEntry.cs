using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using Entity.VehicleEntities;
using Entity.AttendanceEntities;

using Facade.CommonFacade;

using Presentation.CommonGUI;

using SystemFramework.AppException;
using SystemFramework.AppMessage;
using SystemFramework.AppConfig;
using ictus.Common.Entity.General;

namespace Presentation.VehicleGUI
{
	public class frmCompulsoryInsuranceEntry : EntryFormBase
	{
		#region Windows Form Designer generated code
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtBrandName;
		private System.Windows.Forms.TextBox txtPlatePrefix;
		private FarPoint.Win.Input.FpInteger fpiPlateRunningNo;
		private System.Windows.Forms.ComboBox cmbInsuranceCompany;
		private System.Windows.Forms.Button btnCalculate;
		private FarPoint.Win.Input.FpDouble fpdAmount;
		private FarPoint.Win.Input.FpDouble fpdVAT;
		private FarPoint.Win.Input.FpDouble fpdRevenueStamp;
		private FarPoint.Win.Input.FpDouble fpdPremiumAmount;
		private System.Windows.Forms.DateTimePicker dtpEndDate;
		private System.Windows.Forms.DateTimePicker dtpStartDate;
		private System.Windows.Forms.TextBox txtPolicyPrefix;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Label lblPlateNo;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label lblPlatePrefix;
        private TextBox txtPolicyEndorsement;
        private TextBox txtPolicyNo;
        private Label label15;
        private Label label14;
        private DateTimePicker dtpTaxDate;
        private TextBox txtTaxInvoiceNo;
        private Button btnGenTaxNo;
		private System.ComponentModel.Container components = null;
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPlateNo = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblPlatePrefix = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtBrandName = new System.Windows.Forms.TextBox();
            this.txtPlatePrefix = new System.Windows.Forms.TextBox();
            this.fpiPlateRunningNo = new FarPoint.Win.Input.FpInteger();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGenTaxNo = new System.Windows.Forms.Button();
            this.dtpTaxDate = new System.Windows.Forms.DateTimePicker();
            this.txtTaxInvoiceNo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPolicyEndorsement = new System.Windows.Forms.TextBox();
            this.txtPolicyNo = new System.Windows.Forms.TextBox();
            this.cmbInsuranceCompany = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.fpdAmount = new FarPoint.Win.Input.FpDouble();
            this.fpdVAT = new FarPoint.Win.Input.FpDouble();
            this.fpdRevenueStamp = new FarPoint.Win.Input.FpDouble();
            this.fpdPremiumAmount = new FarPoint.Win.Input.FpDouble();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.txtPolicyPrefix = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPlateNo);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.lblPlatePrefix);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtBrandName);
            this.groupBox1.Controls.Add(this.txtPlatePrefix);
            this.groupBox1.Controls.Add(this.fpiPlateRunningNo);
            this.groupBox1.Location = new System.Drawing.Point(13, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(405, 88);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ข้อมูลรถ";
            // 
            // lblPlateNo
            // 
            this.lblPlateNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPlateNo.Location = new System.Drawing.Point(320, 22);
            this.lblPlateNo.Name = "lblPlateNo";
            this.lblPlateNo.Size = new System.Drawing.Size(72, 24);
            this.lblPlateNo.TabIndex = 120;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label23.Location = new System.Drawing.Point(296, 22);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(19, 25);
            this.label23.TabIndex = 119;
            this.label23.Text = "-";
            // 
            // lblPlatePrefix
            // 
            this.lblPlatePrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPlatePrefix.Location = new System.Drawing.Point(256, 22);
            this.lblPlatePrefix.Name = "lblPlatePrefix";
            this.lblPlatePrefix.Size = new System.Drawing.Size(40, 24);
            this.lblPlatePrefix.TabIndex = 118;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 116;
            this.label3.Text = "ยี่ห้อรถ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(168, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 17);
            this.label2.TabIndex = 115;
            this.label2.Text = "-";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label13.Location = new System.Drawing.Point(16, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 13);
            this.label13.TabIndex = 112;
            this.label13.Text = "ทะเบียนรถ";
            // 
            // txtBrandName
            // 
            this.txtBrandName.Enabled = false;
            this.txtBrandName.Location = new System.Drawing.Point(128, 56);
            this.txtBrandName.Name = "txtBrandName";
            this.txtBrandName.Size = new System.Drawing.Size(264, 20);
            this.txtBrandName.TabIndex = 3;
            // 
            // txtPlatePrefix
            // 
            this.txtPlatePrefix.Enabled = false;
            this.txtPlatePrefix.Location = new System.Drawing.Point(128, 24);
            this.txtPlatePrefix.MaxLength = 3;
            this.txtPlatePrefix.Name = "txtPlatePrefix";
            this.txtPlatePrefix.Size = new System.Drawing.Size(40, 20);
            this.txtPlatePrefix.TabIndex = 1;
            this.txtPlatePrefix.TextChanged += new System.EventHandler(this.txtPlatePrefix_TextChanged);
            // 
            // fpiPlateRunningNo
            // 
            this.fpiPlateRunningNo.AllowClipboardKeys = true;
            this.fpiPlateRunningNo.AllowNull = true;
            this.fpiPlateRunningNo.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiPlateRunningNo.Enabled = false;
            this.fpiPlateRunningNo.Location = new System.Drawing.Point(181, 24);
            this.fpiPlateRunningNo.MaxValue = 9999;
            this.fpiPlateRunningNo.MinValue = 0;
            this.fpiPlateRunningNo.Name = "fpiPlateRunningNo";
            this.fpiPlateRunningNo.NullColor = System.Drawing.Color.Transparent;
            this.fpiPlateRunningNo.Size = new System.Drawing.Size(48, 20);
            this.fpiPlateRunningNo.TabIndex = 2;
            this.fpiPlateRunningNo.Text = "";
            this.fpiPlateRunningNo.TextChanged += new System.EventHandler(this.fpiPlateRunningNo_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnGenTaxNo);
            this.groupBox2.Controls.Add(this.dtpTaxDate);
            this.groupBox2.Controls.Add(this.txtTaxInvoiceNo);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtPolicyEndorsement);
            this.groupBox2.Controls.Add(this.txtPolicyNo);
            this.groupBox2.Controls.Add(this.cmbInsuranceCompany);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.btnCalculate);
            this.groupBox2.Controls.Add(this.fpdAmount);
            this.groupBox2.Controls.Add(this.fpdVAT);
            this.groupBox2.Controls.Add(this.fpdRevenueStamp);
            this.groupBox2.Controls.Add(this.fpdPremiumAmount);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dtpEndDate);
            this.groupBox2.Controls.Add(this.dtpStartDate);
            this.groupBox2.Controls.Add(this.txtPolicyPrefix);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(13, 96);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(404, 344);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ข้อมูล พ.ร.บ.";
            // 
            // btnGenTaxNo
            // 
            this.btnGenTaxNo.Location = new System.Drawing.Point(296, 56);
            this.btnGenTaxNo.Name = "btnGenTaxNo";
            this.btnGenTaxNo.Size = new System.Drawing.Size(101, 23);
            this.btnGenTaxNo.TabIndex = 120;
            this.btnGenTaxNo.Text = "สร้างใบกำกับภาษี";
            this.btnGenTaxNo.Visible = false;
            this.btnGenTaxNo.Click += new System.EventHandler(this.btnGenTaxNo_Click);
            // 
            // dtpTaxDate
            // 
            this.dtpTaxDate.Checked = false;
            this.dtpTaxDate.CustomFormat = "dd/MM/yyyy";
            this.dtpTaxDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTaxDate.Location = new System.Drawing.Point(128, 88);
            this.dtpTaxDate.Name = "dtpTaxDate";
            this.dtpTaxDate.ShowCheckBox = true;
            this.dtpTaxDate.Size = new System.Drawing.Size(96, 20);
            this.dtpTaxDate.TabIndex = 6;
            // 
            // txtTaxInvoiceNo
            // 
            this.txtTaxInvoiceNo.Location = new System.Drawing.Point(128, 56);
            this.txtTaxInvoiceNo.MaxLength = 20;
            this.txtTaxInvoiceNo.Name = "txtTaxInvoiceNo";
            this.txtTaxInvoiceNo.Size = new System.Drawing.Size(136, 20);
            this.txtTaxInvoiceNo.TabIndex = 5;
            this.txtTaxInvoiceNo.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 56);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(90, 13);
            this.label15.TabIndex = 119;
            this.label15.Text = "เลขที่ใบกำกับภาษี";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 88);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 13);
            this.label14.TabIndex = 118;
            this.label14.Text = "วันที่ใบกำกับภาษี";
            // 
            // txtPolicyEndorsement
            // 
            this.txtPolicyEndorsement.Location = new System.Drawing.Point(373, 80);
            this.txtPolicyEndorsement.MaxLength = 2;
            this.txtPolicyEndorsement.Name = "txtPolicyEndorsement";
            this.txtPolicyEndorsement.Size = new System.Drawing.Size(24, 20);
            this.txtPolicyEndorsement.TabIndex = 0;
            this.txtPolicyEndorsement.TabStop = false;
            this.txtPolicyEndorsement.Visible = false;
            // 
            // txtPolicyNo
            // 
            this.txtPolicyNo.Location = new System.Drawing.Point(320, 80);
            this.txtPolicyNo.MaxLength = 6;
            this.txtPolicyNo.Name = "txtPolicyNo";
            this.txtPolicyNo.Size = new System.Drawing.Size(48, 20);
            this.txtPolicyNo.TabIndex = 4;
            this.txtPolicyNo.Visible = false;
            this.txtPolicyNo.Leave += new System.EventHandler(this.txtPolicyNo_Leave);
            // 
            // cmbInsuranceCompany
            // 
            this.cmbInsuranceCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInsuranceCompany.Location = new System.Drawing.Point(128, 120);
            this.cmbInsuranceCompany.Name = "cmbInsuranceCompany";
            this.cmbInsuranceCompany.Size = new System.Drawing.Size(264, 21);
            this.cmbInsuranceCompany.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 120);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "ชื่อบริษัทประกันภัย";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(280, 312);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(80, 23);
            this.btnCalculate.TabIndex = 14;
            this.btnCalculate.Text = "คำนวณ";
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // fpdAmount
            // 
            this.fpdAmount.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdAmount.AllowClipboardKeys = true;
            this.fpdAmount.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdAmount.DecimalPlaces = 2;
            this.fpdAmount.DecimalSeparator = ".";
            this.fpdAmount.Enabled = false;
            this.fpdAmount.FixedPoint = true;
            this.fpdAmount.Location = new System.Drawing.Point(128, 312);
            this.fpdAmount.Name = "fpdAmount";
            this.fpdAmount.NumberGroupSeparator = ",";
            this.fpdAmount.NumberGroupSize = 3;
            this.fpdAmount.Size = new System.Drawing.Size(136, 20);
            this.fpdAmount.TabIndex = 13;
            this.fpdAmount.Text = "";
            this.fpdAmount.UseSeparator = true;
            // 
            // fpdVAT
            // 
            this.fpdVAT.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdVAT.AllowClipboardKeys = true;
            this.fpdVAT.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdVAT.DecimalPlaces = 2;
            this.fpdVAT.DecimalSeparator = ".";
            this.fpdVAT.Enabled = false;
            this.fpdVAT.FixedPoint = true;
            this.fpdVAT.Location = new System.Drawing.Point(128, 280);
            this.fpdVAT.Name = "fpdVAT";
            this.fpdVAT.NumberGroupSeparator = ",";
            this.fpdVAT.NumberGroupSize = 3;
            this.fpdVAT.Size = new System.Drawing.Size(136, 20);
            this.fpdVAT.TabIndex = 12;
            this.fpdVAT.Text = "";
            this.fpdVAT.UseSeparator = true;
            // 
            // fpdRevenueStamp
            // 
            this.fpdRevenueStamp.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdRevenueStamp.AllowClipboardKeys = true;
            this.fpdRevenueStamp.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdRevenueStamp.DecimalPlaces = 2;
            this.fpdRevenueStamp.DecimalSeparator = ".";
            this.fpdRevenueStamp.Enabled = false;
            this.fpdRevenueStamp.FixedPoint = true;
            this.fpdRevenueStamp.Location = new System.Drawing.Point(128, 248);
            this.fpdRevenueStamp.Name = "fpdRevenueStamp";
            this.fpdRevenueStamp.NumberGroupSeparator = ",";
            this.fpdRevenueStamp.NumberGroupSize = 3;
            this.fpdRevenueStamp.Size = new System.Drawing.Size(136, 20);
            this.fpdRevenueStamp.TabIndex = 11;
            this.fpdRevenueStamp.Text = "";
            this.fpdRevenueStamp.UseSeparator = true;
            // 
            // fpdPremiumAmount
            // 
            this.fpdPremiumAmount.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdPremiumAmount.AllowClipboardKeys = true;
            this.fpdPremiumAmount.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdPremiumAmount.DecimalPlaces = 2;
            this.fpdPremiumAmount.DecimalSeparator = ".";
            this.fpdPremiumAmount.FixedPoint = true;
            this.fpdPremiumAmount.Location = new System.Drawing.Point(128, 216);
            this.fpdPremiumAmount.Name = "fpdPremiumAmount";
            this.fpdPremiumAmount.NumberGroupSeparator = ",";
            this.fpdPremiumAmount.NumberGroupSize = 3;
            this.fpdPremiumAmount.Size = new System.Drawing.Size(136, 20);
            this.fpdPremiumAmount.TabIndex = 10;
            this.fpdPremiumAmount.Text = "";
            this.fpdPremiumAmount.UseSeparator = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 312);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "รวมเป็นเงิน";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 280);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "ภาษี";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 248);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "ค่าธรรมเนียมอากร";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "ค่าพ.ร.บ.";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MM/yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(128, 184);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(96, 20);
            this.dtpEndDate.TabIndex = 9;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MM/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(128, 152);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(96, 20);
            this.dtpStartDate.TabIndex = 8;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // txtPolicyPrefix
            // 
            this.txtPolicyPrefix.Location = new System.Drawing.Point(128, 24);
            this.txtPolicyPrefix.MaxLength = 25;
            this.txtPolicyPrefix.Name = "txtPolicyPrefix";
            this.txtPolicyPrefix.Size = new System.Drawing.Size(264, 20);
            this.txtPolicyPrefix.TabIndex = 0;
            this.txtPolicyPrefix.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "วันที่สิ้นสุด";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "วันที่เริ่มต้น";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "เลขที่พ.ร.บ.";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(218, 449);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Location = new System.Drawing.Point(138, 449);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 15;
            this.btnOK.Text = "ตกลง";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmCompulsoryInsuranceEntry
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(430, 481);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmCompulsoryInsuranceEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "พ.ร.บ.";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmCompulsoryInsuranceEntry_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region - Private - 
		private bool isReadonly = true;
		private frmCompulsoryInsuranceByPlate parentForm;
        private CompulsoryDocNoBase compulsoryBase;
		#endregion

		//============================== Property ==============================
        #region Property
        private Vehicle oVehicle;
        public Vehicle Vehicle
        {
            set
            {
                oVehicle = value;
                txtPlatePrefix.Text = value.PlatePrefix;
                fpiPlateRunningNo.Text = value.PlateRunningNo;
                txtBrandName.Text = value.AModel.ABrand.AName.English;
            }
        }

        private CompulsoryInsurance compulsoryInsurance;
        public CompulsoryInsurance CompulsoryInsurance
        {
            set
            {
                compulsoryInsurance = value;
                setCompulsoryInsurance(value);
            }
            get
            {
                compulsoryInsurance.PolicyNo = txtPolicyPrefix.Text.Trim();
                compulsoryInsurance.TaxInvoiceNo = txtTaxInvoiceNo.Text;
                compulsoryInsurance.TaxInvoiceDate = dtpTaxDate.Value;
                compulsoryInsurance.AVehicle = oVehicle;
                compulsoryInsurance.AInsuranceCompany = (InsuranceCompany)cmbInsuranceCompany.SelectedItem;
                compulsoryInsurance.VatAmount = Decimal.Parse(fpdVAT.Text);
                compulsoryInsurance.RevenueStampFee = Decimal.Parse(fpdRevenueStamp.Text);
                compulsoryInsurance.PremiumAmount = Decimal.Parse(fpdPremiumAmount.Text);
                compulsoryInsurance.APeriod.From = dtpStartDate.Value;
                compulsoryInsurance.APeriod.To = dtpEndDate.Value;
                return compulsoryInsurance;
            }
        }


        //User request to chage text format : Woranai 2009-07-20
        //private string getTaxInvoiceNo()
        //{
        //    if (txtPolicyNo.Text.Trim() == "")
        //        return "";
        //    return compulsoryBase.GetTaxInvoiceNo(txtPolicyPrefix.Text.Trim(), txtPolicyNo.Text.Trim(), txtPolicyEndorsement.Text.Trim());
        //}
        //private string getCompulsoryNo()
        //{
        //    return compulsoryBase.GetCompulsoryNo(txtPolicyPrefix.Text.Trim(), txtPolicyNo.Text.Trim(), txtPolicyEndorsement.Text.Trim());
        //} 
        #endregion

        #region Constructor
        public frmCompulsoryInsuranceEntry(frmCompulsoryInsuranceByPlate value)
        {
            InitializeComponent();
            parentForm = value;
            cmbInsuranceCompany.DataSource = parentForm.facadeCompulsoryInsuranceByPlate.DataSourceInsuranceCompany;
            dtpStartDate.Value = DateTime.Today;
            fpdPremiumAmount.MaxValue = 99999.99;
            fpdPremiumAmount.MinValue = 0;
            fpdRevenueStamp.MaxValue = 99999.99;
            fpdRevenueStamp.MinValue = 0;
            compulsoryBase = ObjectCreater.CreateCompulsoryDocNo();
            isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleDocumentCompulsoryPlate");
        } 
        #endregion		
		
        #region Private Method
        private void clearForm()
        {
            txtPlatePrefix.Text = "";
            fpiPlateRunningNo.Text = "";
            txtBrandName.Text = "";

            //User request to chage text format : Woranai 2009-07-20
            //txtPolicyPrefix.Text = compulsoryBase.DefaultFullPrefix;
            //txtPolicyNo.Text = "";
            //txtPolicyEndorsement.Text = compulsoryBase.DefaultEndorsement;

            txtPolicyPrefix.Text = string.Empty;
            txtTaxInvoiceNo.Text = "";
            dtpTaxDate.Value = DateTime.Today;
            dtpTaxDate.Checked = false;

            cmbInsuranceCompany.SelectedIndex = 0;
            fpdAmount.Value = 0;
            fpdVAT.Value = 0;
            fpdRevenueStamp.Value = 0;
            fpdPremiumAmount.Value = 0;
            dtpStartDate.Value = DateTime.Today;

            txtPolicyPrefix.Focus();
        }

        private void enableKeyField(bool enable)
        {
            txtPolicyPrefix.Enabled = enable;

            //User request to chage text format : Woranai 2009-07-20
            //txtPolicyNo.Enabled = enable;
            //txtPolicyEndorsement.Enabled = enable;
        }

        private void setCompulsoryInsurance(CompulsoryInsurance value)
        {
            CompulsoryFragment frag = compulsoryBase.GetCompulsoryFragment(value.PolicyNo);

            //User request to chage text format : Woranai 2009-07-20
            //txtPolicyPrefix.Text = frag.Prefix.ToString();
            //txtPolicyNo.Text = frag.Number.ToString();
            //txtPolicyEndorsement.Text = frag.Endorsement.ToString();

            txtPolicyPrefix.Text = value.PolicyNo;
            txtTaxInvoiceNo.Text = value.TaxInvoiceNo;

            if (value.TaxInvoiceDate == NullConstant.DATETIME)
            {
                dtpTaxDate.Value = DateTime.Today;
                dtpTaxDate.Checked = false;
            }
            else
            {
                dtpTaxDate.Value = value.TaxInvoiceDate;
                dtpTaxDate.Checked = true;
            }

            cmbInsuranceCompany.Text = value.AInsuranceCompany.AName.Thai;
            fpdAmount.Text = GUIFunction.GetString(value.CompulsoryInsuranceAmount);
            fpdVAT.Text = GUIFunction.GetString(value.VatAmount);
            fpdRevenueStamp.Text = GUIFunction.GetString(value.RevenueStampFee);
            fpdPremiumAmount.Text = GUIFunction.GetString(value.PremiumAmount);
            dtpStartDate.Value = value.APeriod.From;
            dtpEndDate.Value = value.APeriod.To;
        }

        private bool validateAdd()
        {
            if (txtPolicyPrefix.Text == "")
            {
                Message(MessageList.Error.E0002, "เลขที่ พ.ร.บ.");
                txtPolicyPrefix.Focus();
                return false;
            }

            //User request to chage text format : Woranai 2009-07-20
            //if (parentForm.facadeCompulsoryInsuranceByPlate.CheckPolicyNo(getCompulsoryNo()))

            if (parentForm.facadeCompulsoryInsuranceByPlate.CheckPolicyNo(txtPolicyPrefix.Text.Trim()))
            {
                Message(MessageList.Error.E0003);
                txtPolicyPrefix.Focus();
                return false;
            }
            return validateUpdate();
        }

        private bool validateVehicle(Vehicle value)
        {
            if (value.AVehicleStatus.Code == "5" || value.AVehicleStatus.Code == "6")
            {
                Message(MessageList.Error.E0014, "ต่อ พ.ร.บ. สำหรับรถที่สิ้นสุดการใช้งานแล้วได้");
                return false;
            }
            return true;
        }

        private bool validateUpdate()
        {
            if (txtTaxInvoiceNo.Text == "")
            {
                Message(MessageList.Error.E0002, "เลขที่ใบกำกับภาษี");
                txtTaxInvoiceNo.Focus();
                return false;
            }
            if (!dtpTaxDate.Checked)
            {
                Message(MessageList.Error.E0005, "วันที่ใบกำกับภาษี");
                dtpTaxDate.Focus();
                return false;
            }
            if (cmbInsuranceCompany.SelectedIndex == -1)
            {
                Message(MessageList.Error.E0005, "บริษัทประกันภัย");
                cmbInsuranceCompany.Focus();
                return false;
            }
            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                Message(MessageList.Error.E0011, "วันที่เริ่มต้น", "วันที่สิ้นสุด");
                dtpStartDate.Focus();
                return false;
            }

            #region Validate Period
            //TimePeriod timePeriod = new TimePeriod();
            //timePeriod.From = dtpStartDate.Value;
            //timePeriod.To = dtpEndDate.Value;
            //TimePeriod compulsoryTimePeriod;

            //CompulsoryInsuranceList compulsoryInsuranceList = parentForm.facadeCompulsoryInsuranceByPlate.CompulsoryInsuranceList;

            //for(int i=0; i<compulsoryInsuranceList.Count; i++)
            //{
            //    if(action == ActionType.EDIT && compulsoryInsuranceList[i].PolicyNo == getCompulsoryNo())
            //    {
            //        continue;
            //    }
            //    compulsoryTimePeriod = compulsoryInsuranceList[i].APeriod;
            //    if(compulsoryTimePeriod.To > timePeriod.From && compulsoryTimePeriod.From < timePeriod.To)
            //    {
            //        Message(MessageList.Error.E0014, "ระบุวันที่พ.ร.บ.ในช่วงเวลาดังกล่าวได้");
            //        dtpStartDate.Focus();
            //        timePeriod = null;
            //        return false;
            //    }
            //}
            //timePeriod = null; 
            #endregion

            if (decimal.Parse(fpdPremiumAmount.Text) == 0m)
            {
                Message(MessageList.Error.E0002, "ค่า พ.ร.บ.");
                fpdPremiumAmount.Focus();
                return false;
            }

            string temp = fpdPremiumAmount.Tag.ToString();
            if (decimal.Parse(temp) != decimal.Parse(fpdPremiumAmount.Text))
            {
                Message(MessageList.Error.E0017, "กรุณากดปุ่มคำนวณ");
                btnCalculate.Focus();
                return false;
            }

            #region Validate Calculate
            //			CompulsoryInsurance compulsoryInsurance = new CompulsoryInsurance();
            //			compulsoryInsurance.PremiumAmount = decimal.Parse(fpdPremiumAmount.Text);
            //			parentForm.facadeCompulsoryInsuranceByPlate.CalculateTotalPremium(compulsoryInsurance);
            //			decimal tempDecimal = decimal.Parse(fpdPremiumAmount.Text);
            //			if(getDecimal(fpdRevenueStamp.Text) != decimal.Round(compulsoryInsurance.RevenueStampFee,2))
            //			{
            //				Message(MessageList.Error.E0017, "กรุณากดปุ่มคำนวณ");
            //				btnCalculate.Focus();
            //				compulsoryInsurance = null;
            //				return false;
            //			}
            //			if(getDecimal(fpdVAT.Text) != decimal.Round(compulsoryInsurance.VatAmount,2))
            //			{
            //				Message(MessageList.Error.E0017, "กรุณากดปุ่มคำนวณ");
            //				btnCalculate.Focus();
            //				compulsoryInsurance = null;
            //				return false;
            //			}
            //			if(getDecimal(fpdAmount.Text) != decimal.Round(compulsoryInsurance.CompulsoryInsuranceAmount,2))
            //			{
            //				Message(MessageList.Error.E0017, "กรุณากดปุ่มคำนวณ");
            //				btnCalculate.Focus();
            //				compulsoryInsurance = null;
            //				return false;
            //			}
            //			compulsoryInsurance = null; 
            #endregion

            return true;
        }
        #endregion

        #region Public Method
        public void InitAddAction(Vehicle value)
        {
            fpdPremiumAmount.Tag = 0;
            this.title = "พ.ร.บ.";
            clearForm();
            baseADD();
            enableKeyField(true);
            this.Vehicle = value;

            CompulsoryInsurance latestCompulsoryInsurance = parentForm.facadeCompulsoryInsuranceByPlate.GetLatestCompulsoryInsurance(value);

            if (latestCompulsoryInsurance == null)
            {
                dtpStartDate.Value = value.RegisterDate;
            }
            else
            {
                fpdPremiumAmount.Value = latestCompulsoryInsurance.PremiumAmount;
                dtpStartDate.Value = latestCompulsoryInsurance.APeriod.To;
            }
            latestCompulsoryInsurance = null;
        }

        public void InitEditAction(CompulsoryInsurance value)
        {
            fpdPremiumAmount.Tag = value.PremiumAmount;
            this.title = "พ.ร.บ.";
            clearForm();
            baseEDIT();
            enableKeyField(false);
            setCompulsoryInsurance(value);

            if (isReadonly)
            {
                btnOK.Enabled = false;
            }
        } 
        #endregion

        #region Form Event
        private void AddEvent()
        {
            try
            {
                if (validateAdd() && validateVehicle(oVehicle))
                {
                    compulsoryInsurance = new CompulsoryInsurance();
                    if (parentForm.AddRow(CompulsoryInsurance))
                    {
                        compulsoryInsurance = null;
                        this.Close();
                    }
                    else
                    {
                        compulsoryInsurance = null;
                    }
                }
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
            }
            catch (Exception ex)
            {
                Message(ex);
            }
        }

        private void EditEvent()
        {
            try
            {
                if (validateUpdate())
                {
                    compulsoryInsurance = new CompulsoryInsurance();
                    parentForm.UpdateRow(CompulsoryInsurance);
                    compulsoryInsurance = null;
                    this.Close();
                }
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
            }
            catch (Exception ex)
            {
                Message(ex);
            }
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            switch (action)
            {
                case ActionType.ADD:
                    AddEvent();
                    break;
                case ActionType.EDIT:
                    EditEvent();
                    break;
            }
        }

        private void txtPlatePrefix_TextChanged(object sender, System.EventArgs e)
        {
            lblPlatePrefix.Text = txtPlatePrefix.Text;
        }

        private void fpiPlateRunningNo_TextChanged(object sender, System.EventArgs e)
        {
            lblPlateNo.Text = fpiPlateRunningNo.Text;
        }

        private void btnCalculate_Click(object sender, System.EventArgs e)
        {
            CompulsoryInsurance compulsoryInsurance = new CompulsoryInsurance();
            compulsoryInsurance.PremiumAmount = decimal.Parse(fpdPremiumAmount.Text);
            parentForm.facadeCompulsoryInsuranceByPlate.CalculateTotalPremium(compulsoryInsurance);

            fpdPremiumAmount.Tag = compulsoryInsurance.PremiumAmount;
            fpdVAT.Value = compulsoryInsurance.VatAmount;
            fpdRevenueStamp.Value = compulsoryInsurance.RevenueStampFee;
            fpdAmount.Value = decimal.Parse(fpdPremiumAmount.Text) + decimal.Parse(fpdVAT.Text) + decimal.Parse(fpdRevenueStamp.Text);
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void frmCompulsoryInsuranceEntry_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            switch (action)
            {
                case ActionType.ADD:
                    {
                        txtPolicyPrefix.Focus();
                        break;
                    }
                case ActionType.EDIT:
                    {
                        dtpTaxDate.Focus();
                        break;
                    }
            }
        }

        private void dtpStartDate_ValueChanged(object sender, System.EventArgs e)
        {
            dtpEndDate.Value = dtpStartDate.Value.AddYears(1);
        }

        private void txtPolicyNo_Leave(object sender, EventArgs e)
        {
            //User request to chage text format : Woranai 2009-07-20
            //txtTaxInvoiceNo.Text = getTaxInvoiceNo();
        }

        private void btnGenTaxNo_Click(object sender, EventArgs e)
        {
            //User request to chage text format : Woranai 2009-07-20
            //txtTaxInvoiceNo.Text = getTaxInvoiceNo();
        } 
        #endregion
	}
}