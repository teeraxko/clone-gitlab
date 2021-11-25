//using System;
//using System.Drawing;
//using System.Collections;
//using System.ComponentModel;
//using System.Windows.Forms;
//using System.Data.SqlClient;

//using Entity.VehicleEntities;
//using Entity.ContractEntities;

//using Facade.CommonFacade;

//using Presentation.CommonGUI;
//using Presentation.VehicleGUI;

//using SystemFramework.AppException;
//using SystemFramework.AppMessage;
//using SystemFramework.AppConfig;

//namespace Presentation.VehicleGUI
//{
//    public class frmInsuranceTypeOneEntry : EntryFormBase
//    {
//        #region Windows Form Designer generated code

//        protected override void Dispose( bool disposing )
//        {
//            if( disposing )
//            {
//                if(components != null)
//                {
//                    components.Dispose();
//                }
//            }
//            base.Dispose( disposing );
//        }

//        private System.Windows.Forms.GroupBox groupBox2;
//        private System.Windows.Forms.TextBox txtPlatePrefix;
//        private FarPoint.Win.Input.FpInteger fpiPlateRunningNo;
//        private System.Windows.Forms.Label label8;
//        private System.Windows.Forms.Label label9;
//        private System.Windows.Forms.Label label7;
//        private System.Windows.Forms.Label label10;
//        private System.Windows.Forms.Label label11;
//        private System.Windows.Forms.Label label13;
//        private System.Windows.Forms.Label label14;
//        private System.Windows.Forms.Label label15;
//        private System.Windows.Forms.GroupBox groupBox1;
//        private System.Windows.Forms.Label label2;
//        private System.Windows.Forms.Label label1;
//        private System.Windows.Forms.Label label3;
//        private System.Windows.Forms.Label label4;
//        private System.Windows.Forms.Button cmdCalculate;
//        private FarPoint.Win.Input.FpDouble fpdSumAssured;
//        private FarPoint.Win.Input.FpDouble fpdVatAmount;
//        private FarPoint.Win.Input.FpDouble fpdRevenueStampFee;
//        private FarPoint.Win.Input.FpDouble fpdPremiumAmount;
//        private System.Windows.Forms.DateTimePicker dtpAffiliateDate;
//        private System.Windows.Forms.Button cmdOK;
//        private System.Windows.Forms.Button cmdCancel;
//        private System.Windows.Forms.TextBox txtPolicyNo;
//        private System.Windows.Forms.DateTimePicker dtpStartDate;
//        private System.Windows.Forms.DateTimePicker dtpEndDate;
//        private System.Windows.Forms.ComboBox cmbInsuranceCompany;
//        private FarPoint.Win.Input.FpDouble fpdAmount;
//        private System.Windows.Forms.Label label5;
//        private System.Windows.Forms.Label label6;
//        private System.Windows.Forms.Label label12;
//        private FarPoint.Win.Input.FpInteger fpiOrder;
//        private System.Windows.Forms.TextBox txtCustomer;
//        private System.Windows.Forms.Label label16;
//        private System.Windows.Forms.TextBox txtModel;
//        private System.Windows.Forms.TextBox txtBrand;
		
//        private System.ComponentModel.Container components = null;

//        private void InitializeComponent()
//        {
//            this.groupBox2 = new System.Windows.Forms.GroupBox();
//            this.txtCustomer = new System.Windows.Forms.TextBox();
//            this.label16 = new System.Windows.Forms.Label();
//            this.fpiOrder = new FarPoint.Win.Input.FpInteger();
//            this.label12 = new System.Windows.Forms.Label();
//            this.txtModel = new System.Windows.Forms.TextBox();
//            this.label6 = new System.Windows.Forms.Label();
//            this.txtBrand = new System.Windows.Forms.TextBox();
//            this.label5 = new System.Windows.Forms.Label();
//            this.cmdCalculate = new System.Windows.Forms.Button();
//            this.fpdSumAssured = new FarPoint.Win.Input.FpDouble();
//            this.fpdVatAmount = new FarPoint.Win.Input.FpDouble();
//            this.fpdRevenueStampFee = new FarPoint.Win.Input.FpDouble();
//            this.fpdPremiumAmount = new FarPoint.Win.Input.FpDouble();
//            this.fpdAmount = new FarPoint.Win.Input.FpDouble();
//            this.dtpAffiliateDate = new System.Windows.Forms.DateTimePicker();
//            this.label15 = new System.Windows.Forms.Label();
//            this.label14 = new System.Windows.Forms.Label();
//            this.label13 = new System.Windows.Forms.Label();
//            this.label11 = new System.Windows.Forms.Label();
//            this.label10 = new System.Windows.Forms.Label();
//            this.label7 = new System.Windows.Forms.Label();
//            this.txtPlatePrefix = new System.Windows.Forms.TextBox();
//            this.fpiPlateRunningNo = new FarPoint.Win.Input.FpInteger();
//            this.label8 = new System.Windows.Forms.Label();
//            this.label9 = new System.Windows.Forms.Label();
//            this.cmdOK = new System.Windows.Forms.Button();
//            this.cmdCancel = new System.Windows.Forms.Button();
//            this.groupBox1 = new System.Windows.Forms.GroupBox();
//            this.cmbInsuranceCompany = new System.Windows.Forms.ComboBox();
//            this.txtPolicyNo = new System.Windows.Forms.TextBox();
//            this.label2 = new System.Windows.Forms.Label();
//            this.label1 = new System.Windows.Forms.Label();
//            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
//            this.label3 = new System.Windows.Forms.Label();
//            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
//            this.label4 = new System.Windows.Forms.Label();
//            this.groupBox2.SuspendLayout();
//            this.groupBox1.SuspendLayout();
//            this.SuspendLayout();
//            // 
//            // groupBox2
//            // 
//            this.groupBox2.Controls.Add(this.txtCustomer);
//            this.groupBox2.Controls.Add(this.label16);
//            this.groupBox2.Controls.Add(this.fpiOrder);
//            this.groupBox2.Controls.Add(this.label12);
//            this.groupBox2.Controls.Add(this.txtModel);
//            this.groupBox2.Controls.Add(this.label6);
//            this.groupBox2.Controls.Add(this.txtBrand);
//            this.groupBox2.Controls.Add(this.label5);
//            this.groupBox2.Controls.Add(this.cmdCalculate);
//            this.groupBox2.Controls.Add(this.fpdSumAssured);
//            this.groupBox2.Controls.Add(this.fpdVatAmount);
//            this.groupBox2.Controls.Add(this.fpdRevenueStampFee);
//            this.groupBox2.Controls.Add(this.fpdPremiumAmount);
//            this.groupBox2.Controls.Add(this.fpdAmount);
//            this.groupBox2.Controls.Add(this.dtpAffiliateDate);
//            this.groupBox2.Controls.Add(this.label15);
//            this.groupBox2.Controls.Add(this.label14);
//            this.groupBox2.Controls.Add(this.label13);
//            this.groupBox2.Controls.Add(this.label11);
//            this.groupBox2.Controls.Add(this.label10);
//            this.groupBox2.Controls.Add(this.label7);
//            this.groupBox2.Controls.Add(this.txtPlatePrefix);
//            this.groupBox2.Controls.Add(this.fpiPlateRunningNo);
//            this.groupBox2.Controls.Add(this.label8);
//            this.groupBox2.Controls.Add(this.label9);
//            this.groupBox2.Location = new System.Drawing.Point(8, 96);
//            this.groupBox2.Name = "groupBox2";
//            this.groupBox2.Size = new System.Drawing.Size(720, 192);
//            this.groupBox2.TabIndex = 2;
//            this.groupBox2.TabStop = false;
//            this.groupBox2.Text = "รถที่เข้าร่วม";
//            // 
//            // txtCustomer
//            // 
//            this.txtCustomer.Enabled = false;
//            this.txtCustomer.Location = new System.Drawing.Point(88, 152);
//            this.txtCustomer.MaxLength = 20;
//            this.txtCustomer.Name = "txtCustomer";
//            this.txtCustomer.Size = new System.Drawing.Size(72, 20);
//            this.txtCustomer.TabIndex = 128;
//            this.txtCustomer.Text = "";
//            // 
//            // label16
//            // 
//            this.label16.Location = new System.Drawing.Point(16, 152);
//            this.label16.Name = "label16";
//            this.label16.Size = new System.Drawing.Size(32, 23);
//            this.label16.TabIndex = 127;
//            this.label16.Text = "ลูกค้า";
//            // 
//            // fpiOrder
//            // 
//            this.fpiOrder.AllowClipboardKeys = true;
//            this.fpiOrder.ButtonMarginColor = System.Drawing.SystemColors.Control;
//            this.fpiOrder.Location = new System.Drawing.Point(88, 24);
//            this.fpiOrder.MaxValue = 999;
//            this.fpiOrder.MinValue = 0;
//            this.fpiOrder.Name = "fpiOrder";
//            this.fpiOrder.Size = new System.Drawing.Size(56, 20);
//            this.fpiOrder.TabIndex = 1;
//            this.fpiOrder.Text = "";
//            // 
//            // label12
//            // 
//            this.label12.Location = new System.Drawing.Point(16, 24);
//            this.label12.Name = "label12";
//            this.label12.Size = new System.Drawing.Size(40, 23);
//            this.label12.TabIndex = 126;
//            this.label12.Text = "ลำดับที่";
//            // 
//            // txtModel
//            // 
//            this.txtModel.Enabled = false;
//            this.txtModel.Location = new System.Drawing.Point(88, 120);
//            this.txtModel.Name = "txtModel";
//            this.txtModel.Size = new System.Drawing.Size(280, 20);
//            this.txtModel.TabIndex = 5;
//            this.txtModel.Text = "";
//            // 
//            // label6
//            // 
//            this.label6.Location = new System.Drawing.Point(16, 120);
//            this.label6.Name = "label6";
//            this.label6.Size = new System.Drawing.Size(40, 23);
//            this.label6.TabIndex = 125;
//            this.label6.Text = "รุ่นรถ";
//            // 
//            // txtBrand
//            // 
//            this.txtBrand.Enabled = false;
//            this.txtBrand.Location = new System.Drawing.Point(88, 88);
//            this.txtBrand.Name = "txtBrand";
//            this.txtBrand.Size = new System.Drawing.Size(280, 20);
//            this.txtBrand.TabIndex = 4;
//            this.txtBrand.Text = "";
//            // 
//            // label5
//            // 
//            this.label5.Location = new System.Drawing.Point(16, 88);
//            this.label5.Name = "label5";
//            this.label5.Size = new System.Drawing.Size(32, 23);
//            this.label5.TabIndex = 123;
//            this.label5.Text = "ยี่ห้อ";
//            // 
//            // cmdCalculate
//            // 
//            this.cmdCalculate.Location = new System.Drawing.Point(632, 152);
//            this.cmdCalculate.Name = "cmdCalculate";
//            this.cmdCalculate.Size = new System.Drawing.Size(72, 23);
//            this.cmdCalculate.TabIndex = 12;
//            this.cmdCalculate.Text = "คำนวณ";
//            this.cmdCalculate.Click += new System.EventHandler(this.cmdCalculate_Click);
//            // 
//            // fpdSumAssured
//            // 
//            this.fpdSumAssured.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
//            this.fpdSumAssured.AllowClipboardKeys = true;
//            this.fpdSumAssured.ButtonMarginColor = System.Drawing.SystemColors.Control;
//            this.fpdSumAssured.DecimalPlaces = 2;
//            this.fpdSumAssured.DecimalSeparator = ".";
//            this.fpdSumAssured.FixedPoint = true;
//            this.fpdSumAssured.Location = new System.Drawing.Point(480, 24);
//            this.fpdSumAssured.Name = "fpdSumAssured";
//            this.fpdSumAssured.NumberGroupSeparator = ",";
//            this.fpdSumAssured.NumberGroupSize = 3;
//            this.fpdSumAssured.Size = new System.Drawing.Size(136, 20);
//            this.fpdSumAssured.TabIndex = 7;
//            this.fpdSumAssured.Text = "";
//            this.fpdSumAssured.UseSeparator = true;
//            // 
//            // fpdVatAmount
//            // 
//            this.fpdVatAmount.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
//            this.fpdVatAmount.AllowClipboardKeys = true;
//            this.fpdVatAmount.ButtonMarginColor = System.Drawing.SystemColors.Control;
//            this.fpdVatAmount.DecimalPlaces = 2;
//            this.fpdVatAmount.DecimalSeparator = ".";
//            this.fpdVatAmount.Enabled = false;
//            this.fpdVatAmount.FixedPoint = true;
//            this.fpdVatAmount.Location = new System.Drawing.Point(480, 120);
//            this.fpdVatAmount.Name = "fpdVatAmount";
//            this.fpdVatAmount.NumberGroupSeparator = ",";
//            this.fpdVatAmount.NumberGroupSize = 3;
//            this.fpdVatAmount.Size = new System.Drawing.Size(136, 20);
//            this.fpdVatAmount.TabIndex = 10;
//            this.fpdVatAmount.Text = "";
//            this.fpdVatAmount.UseSeparator = true;
//            // 
//            // fpdRevenueStampFee
//            // 
//            this.fpdRevenueStampFee.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
//            this.fpdRevenueStampFee.AllowClipboardKeys = true;
//            this.fpdRevenueStampFee.ButtonMarginColor = System.Drawing.SystemColors.Control;
//            this.fpdRevenueStampFee.DecimalPlaces = 2;
//            this.fpdRevenueStampFee.DecimalSeparator = ".";
//            this.fpdRevenueStampFee.Enabled = false;
//            this.fpdRevenueStampFee.FixedPoint = true;
//            this.fpdRevenueStampFee.Location = new System.Drawing.Point(480, 88);
//            this.fpdRevenueStampFee.Name = "fpdRevenueStampFee";
//            this.fpdRevenueStampFee.NumberGroupSeparator = ",";
//            this.fpdRevenueStampFee.NumberGroupSize = 3;
//            this.fpdRevenueStampFee.Size = new System.Drawing.Size(136, 20);
//            this.fpdRevenueStampFee.TabIndex = 9;
//            this.fpdRevenueStampFee.Text = "";
//            this.fpdRevenueStampFee.UseSeparator = true;
//            // 
//            // fpdPremiumAmount
//            // 
//            this.fpdPremiumAmount.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
//            this.fpdPremiumAmount.AllowClipboardKeys = true;
//            this.fpdPremiumAmount.ButtonMarginColor = System.Drawing.SystemColors.Control;
//            this.fpdPremiumAmount.DecimalPlaces = 2;
//            this.fpdPremiumAmount.DecimalSeparator = ".";
//            this.fpdPremiumAmount.FixedPoint = true;
//            this.fpdPremiumAmount.Location = new System.Drawing.Point(480, 56);
//            this.fpdPremiumAmount.Name = "fpdPremiumAmount";
//            this.fpdPremiumAmount.NumberGroupSeparator = ",";
//            this.fpdPremiumAmount.NumberGroupSize = 3;
//            this.fpdPremiumAmount.Size = new System.Drawing.Size(136, 20);
//            this.fpdPremiumAmount.TabIndex = 8;
//            this.fpdPremiumAmount.Text = "";
//            this.fpdPremiumAmount.UseSeparator = true;
//            this.fpdPremiumAmount.TextChanged += new System.EventHandler(this.fpdPremiumAmount_TextChanged);
//            // 
//            // fpdAmount
//            // 
//            this.fpdAmount.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
//            this.fpdAmount.AllowClipboardKeys = true;
//            this.fpdAmount.ButtonMarginColor = System.Drawing.SystemColors.Control;
//            this.fpdAmount.DecimalPlaces = 2;
//            this.fpdAmount.DecimalSeparator = ".";
//            this.fpdAmount.Enabled = false;
//            this.fpdAmount.FixedPoint = true;
//            this.fpdAmount.Location = new System.Drawing.Point(480, 152);
//            this.fpdAmount.Name = "fpdAmount";
//            this.fpdAmount.NumberGroupSeparator = ",";
//            this.fpdAmount.NumberGroupSize = 3;
//            this.fpdAmount.Size = new System.Drawing.Size(136, 20);
//            this.fpdAmount.TabIndex = 11;
//            this.fpdAmount.Text = "";
//            this.fpdAmount.UseSeparator = true;
//            // 
//            // dtpAffiliateDate
//            // 
//            this.dtpAffiliateDate.CustomFormat = "dd/MM/yyyy";
//            this.dtpAffiliateDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
//            this.dtpAffiliateDate.Location = new System.Drawing.Point(272, 152);
//            this.dtpAffiliateDate.Name = "dtpAffiliateDate";
//            this.dtpAffiliateDate.Size = new System.Drawing.Size(96, 20);
//            this.dtpAffiliateDate.TabIndex = 6;
//            // 
//            // label15
//            // 
//            this.label15.Location = new System.Drawing.Point(384, 152);
//            this.label15.Name = "label15";
//            this.label15.Size = new System.Drawing.Size(64, 23);
//            this.label15.TabIndex = 122;
//            this.label15.Text = "รวมเป็นเงิน";
//            // 
//            // label14
//            // 
//            this.label14.Location = new System.Drawing.Point(384, 120);
//            this.label14.Name = "label14";
//            this.label14.Size = new System.Drawing.Size(64, 23);
//            this.label14.TabIndex = 121;
//            this.label14.Text = "ภาษี";
//            // 
//            // label13
//            // 
//            this.label13.Location = new System.Drawing.Point(384, 88);
//            this.label13.Name = "label13";
//            this.label13.Size = new System.Drawing.Size(88, 23);
//            this.label13.TabIndex = 120;
//            this.label13.Text = "ค่าธรรมเนียมอากร";
//            // 
//            // label11
//            // 
//            this.label11.Location = new System.Drawing.Point(384, 56);
//            this.label11.Name = "label11";
//            this.label11.Size = new System.Drawing.Size(56, 23);
//            this.label11.TabIndex = 119;
//            this.label11.Text = "เบี้ยประกัน";
//            // 
//            // label10
//            // 
//            this.label10.Location = new System.Drawing.Point(384, 24);
//            this.label10.Name = "label10";
//            this.label10.Size = new System.Drawing.Size(64, 23);
//            this.label10.TabIndex = 118;
//            this.label10.Text = "ทุนประกัน";
//            // 
//            // label7
//            // 
//            this.label7.Location = new System.Drawing.Point(200, 152);
//            this.label7.Name = "label7";
//            this.label7.Size = new System.Drawing.Size(64, 23);
//            this.label7.TabIndex = 117;
//            this.label7.Text = "วันที่เข้าร่วม";
//            // 
//            // txtPlatePrefix
//            // 
//            this.txtPlatePrefix.Location = new System.Drawing.Point(88, 56);
//            this.txtPlatePrefix.MaxLength = 2;
//            this.txtPlatePrefix.Name = "txtPlatePrefix";
//            this.txtPlatePrefix.Size = new System.Drawing.Size(40, 20);
//            this.txtPlatePrefix.TabIndex = 2;
//            this.txtPlatePrefix.Text = "";
//            this.txtPlatePrefix.TextChanged += new System.EventHandler(this.txtPlatePrefix_TextChanged);
//            // 
//            // fpiPlateRunningNo
//            // 
//            this.fpiPlateRunningNo.AllowClipboardKeys = true;
//            this.fpiPlateRunningNo.AllowNull = true;
//            this.fpiPlateRunningNo.ButtonMarginColor = System.Drawing.SystemColors.Control;
//            this.fpiPlateRunningNo.Location = new System.Drawing.Point(152, 56);
//            this.fpiPlateRunningNo.MaxValue = 9999;
//            this.fpiPlateRunningNo.MinValue = 0;
//            this.fpiPlateRunningNo.Name = "fpiPlateRunningNo";
//            this.fpiPlateRunningNo.NullColor = System.Drawing.Color.Transparent;
//            this.fpiPlateRunningNo.Size = new System.Drawing.Size(56, 20);
//            this.fpiPlateRunningNo.TabIndex = 3;
//            this.fpiPlateRunningNo.Text = "";
//            this.fpiPlateRunningNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpiPlateRunningNo_KeyDown);
//            this.fpiPlateRunningNo.DoubleClick += new System.EventHandler(this.fpiPlateRunningNo_DoubleClick);
//            this.fpiPlateRunningNo.TextChanged += new System.EventHandler(this.fpiPlateRunningNo_TextChanged);
//            // 
//            // label8
//            // 
//            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
//            this.label8.Location = new System.Drawing.Point(136, 56);
//            this.label8.Name = "label8";
//            this.label8.Size = new System.Drawing.Size(8, 16);
//            this.label8.TabIndex = 115;
//            this.label8.Text = "-";
//            // 
//            // label9
//            // 
//            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
//            this.label9.Location = new System.Drawing.Point(16, 56);
//            this.label9.Name = "label9";
//            this.label9.Size = new System.Drawing.Size(56, 23);
//            this.label9.TabIndex = 112;
//            this.label9.Text = "ทะเบียนรถ";
//            // 
//            // cmdOK
//            // 
//            this.cmdOK.Location = new System.Drawing.Point(288, 304);
//            this.cmdOK.Name = "cmdOK";
//            this.cmdOK.TabIndex = 13;
//            this.cmdOK.Text = "ตกลง";
//            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
//            // 
//            // cmdCancel
//            // 
//            this.cmdCancel.Location = new System.Drawing.Point(368, 304);
//            this.cmdCancel.Name = "cmdCancel";
//            this.cmdCancel.TabIndex = 14;
//            this.cmdCancel.Text = "ยกเลิก";
//            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
//            // 
//            // groupBox1
//            // 
//            this.groupBox1.Controls.Add(this.cmbInsuranceCompany);
//            this.groupBox1.Controls.Add(this.txtPolicyNo);
//            this.groupBox1.Controls.Add(this.label2);
//            this.groupBox1.Controls.Add(this.label1);
//            this.groupBox1.Controls.Add(this.dtpStartDate);
//            this.groupBox1.Controls.Add(this.label3);
//            this.groupBox1.Controls.Add(this.dtpEndDate);
//            this.groupBox1.Controls.Add(this.label4);
//            this.groupBox1.Enabled = false;
//            this.groupBox1.Location = new System.Drawing.Point(8, 8);
//            this.groupBox1.Name = "groupBox1";
//            this.groupBox1.Size = new System.Drawing.Size(720, 88);
//            this.groupBox1.TabIndex = 5;
//            this.groupBox1.TabStop = false;
//            this.groupBox1.Text = "กรมธรรม์ประกันภัยชั้นหนึ่ง";
//            // 
//            // cmbInsuranceCompany
//            // 
//            this.cmbInsuranceCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
//            this.cmbInsuranceCompany.Enabled = false;
//            this.cmbInsuranceCompany.Location = new System.Drawing.Point(120, 56);
//            this.cmbInsuranceCompany.Name = "cmbInsuranceCompany";
//            this.cmbInsuranceCompany.Size = new System.Drawing.Size(280, 21);
//            this.cmbInsuranceCompany.TabIndex = 14;
//            // 
//            // txtPolicyNo
//            // 
//            this.txtPolicyNo.Enabled = false;
//            this.txtPolicyNo.Location = new System.Drawing.Point(120, 24);
//            this.txtPolicyNo.MaxLength = 20;
//            this.txtPolicyNo.Name = "txtPolicyNo";
//            this.txtPolicyNo.Size = new System.Drawing.Size(136, 20);
//            this.txtPolicyNo.TabIndex = 12;
//            this.txtPolicyNo.Text = "";
//            // 
//            // label2
//            // 
//            this.label2.Location = new System.Drawing.Point(16, 56);
//            this.label2.Name = "label2";
//            this.label2.Size = new System.Drawing.Size(88, 23);
//            this.label2.TabIndex = 1;
//            this.label2.Text = "ชื่อบริษัทประกันภัย";
//            // 
//            // label1
//            // 
//            this.label1.Location = new System.Drawing.Point(16, 24);
//            this.label1.Name = "label1";
//            this.label1.Size = new System.Drawing.Size(72, 23);
//            this.label1.TabIndex = 0;
//            this.label1.Text = "เลขที่กรมธรรม์";
//            // 
//            // dtpStartDate
//            // 
//            this.dtpStartDate.CustomFormat = "dd/MM/yyyy";
//            this.dtpStartDate.Enabled = false;
//            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
//            this.dtpStartDate.Location = new System.Drawing.Point(520, 24);
//            this.dtpStartDate.Name = "dtpStartDate";
//            this.dtpStartDate.Size = new System.Drawing.Size(96, 20);
//            this.dtpStartDate.TabIndex = 13;
//            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
//            // 
//            // label3
//            // 
//            this.label3.Location = new System.Drawing.Point(432, 24);
//            this.label3.Name = "label3";
//            this.label3.Size = new System.Drawing.Size(64, 23);
//            this.label3.TabIndex = 4;
//            this.label3.Text = "วันที่เริ่มต้น";
//            // 
//            // dtpEndDate
//            // 
//            this.dtpEndDate.CustomFormat = "dd/MM/yyyy";
//            this.dtpEndDate.Enabled = false;
//            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
//            this.dtpEndDate.Location = new System.Drawing.Point(520, 56);
//            this.dtpEndDate.Name = "dtpEndDate";
//            this.dtpEndDate.Size = new System.Drawing.Size(96, 20);
//            this.dtpEndDate.TabIndex = 15;
//            // 
//            // label4
//            // 
//            this.label4.Location = new System.Drawing.Point(432, 56);
//            this.label4.Name = "label4";
//            this.label4.Size = new System.Drawing.Size(56, 23);
//            this.label4.TabIndex = 6;
//            this.label4.Text = "วันที่สิ้นสุด";
//            // 
//            // frmInsuranceTypeOneEntry
//            // 
//            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
//            this.ClientSize = new System.Drawing.Size(738, 342);
//            this.Controls.Add(this.groupBox1);
//            this.Controls.Add(this.cmdCancel);
//            this.Controls.Add(this.cmdOK);
//            this.Controls.Add(this.groupBox2);
//            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
//            this.Name = "frmInsuranceTypeOneEntry";
//            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
//            this.Load += new System.EventHandler(this.frmInsuranceTypeOneEntry_Load);
//            this.groupBox2.ResumeLayout(false);
//            this.groupBox1.ResumeLayout(false);
//            this.ResumeLayout(false);

//        }
//        #endregion

//        #region - Constant -
//        #endregion

//        #region - Private - 
//            private bool isReadonly = true;
//            private frmMaintainInsuranceTypeOne parentForm;
//            public bool MustCalculate = true;
//        #endregion

//        //============================== Property ==============================
//        private InsuranceTypeOne objInsuranceTypeOne;
//        public InsuranceTypeOne ObjInsuranceTypeOne
//        {
//            set
//            {
//                objInsuranceTypeOne = value;
//                txtPolicyNo.Text = value.PolicyNo;
//                cmbInsuranceCompany.SelectedText = value.AInsuranceCompany.AName.Thai;
//                dtpStartDate.Value = value.APeriod.From;
//                dtpEndDate.Value = value.APeriod.To;
//            }
//        }
		
//        private VehicleInsuranceTypeOne objVehicleInsuranceTypeOne;
//        public VehicleInsuranceTypeOne ObjVehicleInsuranceTypeOne
//        {
//            set
//            {
//                objVehicleInsuranceTypeOne = value;
//                txtPlatePrefix.Text = value.AVehicleInfo.PlatePrefix;
//                fpiPlateRunningNo.Value = value.AVehicleInfo.PlateRunningNo;
//                fpiOrder.Value = objVehicleInsuranceTypeOne.OrderNo;
//                fpiOrder.Tag = objVehicleInsuranceTypeOne.OrderNo;
//                txtBrand.Text = value.AVehicleInfo.AModel.ABrand.AName.English;
//                txtModel.Text = value.AVehicleInfo.AModel.AName.English;
//                fpdSumAssured.Value = value.SumAssured;
//                dtpAffiliateDate.Value = value.AffiliateDate;
//                fpdPremiumAmount.Value = value.PremiumAmount;
//                fpdRevenueStampFee.Value = value.RevenueStampFee;
//                fpdVatAmount.Value = value.VatAmount;
//                fpdAmount.Value = value.Amount;

////				if(value.AVehicle.ACurrentContract != null)
////					txtCustomer.Text = value.AVehicle.ACurrentContract.ACustomer.ShortName;
////				else
////					txtCustomer.Text = "";

//                ContractBase contractBase = parentForm.FacadeInsuranceTypeOne.GetCurrentVehicleContract(value.AVehicleInfo);
//                if(contractBase != null)
//                    txtCustomer.Text = contractBase.ACustomer.ShortName;
//                else
//                    txtCustomer.Text = "";
//            }
//            get
//            {
//                objVehicleInsuranceTypeOne.PolicyNo = txtPolicyNo.Text;
//                objVehicleInsuranceTypeOne.AVehicleInfo.PlatePrefix = txtPlatePrefix.Text;
//                objVehicleInsuranceTypeOne.AVehicleInfo.PlateRunningNo = fpiPlateRunningNo.Text;
//                objVehicleInsuranceTypeOne.OrderNo = (int)fpiOrder.Value;
//                objVehicleInsuranceTypeOne.SumAssured = getDecimal(fpdSumAssured.Text);				
//                objVehicleInsuranceTypeOne.AffiliateDate = dtpAffiliateDate.Value;
//                objVehicleInsuranceTypeOne.PremiumAmount = getDecimal(fpdPremiumAmount.Text);
//                objVehicleInsuranceTypeOne.RevenueStampFee = getDecimal(fpdRevenueStampFee.Text);
//                objVehicleInsuranceTypeOne.VatAmount = getDecimal(fpdVatAmount.Text);
//                return objVehicleInsuranceTypeOne;
//            }
//        }

//        //============================== Constructor ==============================
//        public frmInsuranceTypeOneEntry(frmMaintainInsuranceTypeOne value)
//        {
//            InitializeComponent();
//            parentForm = value;
//            this.title = "รถในกรมธรรม์ประกันภัยชั้นหนึ่ง";
//            isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleDocumentMaintainInsuranceTypeOne");
//        }
		
//        //============================== Private Method ==============================
//        private void clearForm()
//        {
//            txtPlatePrefix.Text = "";
//            fpiPlateRunningNo.Value = "";
//            fpiOrder.Value = 0;
//            txtBrand.Text = "";
//            txtModel.Text = "";
//            txtCustomer.Text = "";
//            fpdSumAssured.Value = 0;
//            dtpAffiliateDate.Value = dtpStartDate.Value;
//            fpdPremiumAmount.Value = 0;
//            fpdRevenueStampFee.Value = 0;
//            fpdVatAmount.Value = 0;
//            fpdAmount.Value = 0;
//            fpiOrder.Focus();
//        }

//        private decimal getDecimal(string value)
//        {
//            return decimal.Parse(value);
//        }

//        private bool validateOutInsurance()
//        {
//            if(action==ActionType.ADD && parentForm.FacadeInsuranceTypeOne.CheckOutInsurance(objVehicleInsuranceTypeOne.AVehicleInfo, dtpStartDate.Value, dtpEndDate.Value))
//            {
//                Message(MessageList.Error.E0013, "เพิ่มรถคันนี้ได้", "รถคันนี้มีประกันกับกรมธรรม์ฉบับอื่นในช่วงเวลานี้แล้ว");
//                fpiPlateRunningNo.Focus();
//                return false;
//            }
//            else
//            {
//                return true;
//            }
//        }

//        private bool validateVehicle()
//        {
//            if(action==ActionType.ADD && txtPlatePrefix.Text=="")
//            {
//                Message(MessageList.Error.E0002, "ทะเบียนรถ");
//                txtPlatePrefix.Focus();
//                return false;
//            }

//            if(action==ActionType.ADD && fpiPlateRunningNo.Text=="")
//            {
//                Message(MessageList.Error.E0002, "ทะเบียนรถ");
//                fpiPlateRunningNo.Focus();
//                return false;
//            }

//            if(action==ActionType.ADD && objVehicleInsuranceTypeOne.AVehicleInfo != null && objVehicleInsuranceTypeOne.AVehicleInfo.PlatePrefix == txtPlatePrefix.Text && objVehicleInsuranceTypeOne.AVehicleInfo.PlateRunningNo == fpiPlateRunningNo.Text)
//            {
//            }
//            else
//            {
//                objVehicleInsuranceTypeOne.AVehicleInfo = parentForm.FacadeInsuranceTypeOne.GetVehicleInfo(txtPlatePrefix.Text, fpiPlateRunningNo.Text);
//                if(objVehicleInsuranceTypeOne.AVehicleInfo == null)
//                {
//                    Message(MessageList.Error.E0004, "ทะเบียนรถ");
//                    fpiPlateRunningNo.Focus();
//                    return false;
//                }
//            }

//            string vehicleStatus = objVehicleInsuranceTypeOne.AVehicleInfo.AVehicleStatus.Code;
//            if(action==ActionType.ADD && (vehicleStatus == "4" || vehicleStatus == "5" || vehicleStatus == "6"))
//            {
//                Message(MessageList.Error.E0014, "เพิ่มรถที่สิ้นสุดการใช้งานแล้วได้");
//                fpiPlateRunningNo.Focus();
//                return false;	
//            }

//            if(action==ActionType.ADD && parentForm.FacadeInsuranceTypeOne.CheckDuplicate(objVehicleInsuranceTypeOne))
//            {
//                Message(MessageList.Error.E0003);
//                fpiPlateRunningNo.Focus();
//                return false;
//            }
//            return true;
//        }

//        private void fillVehicle()
//        {
//            if(validateVehicle() && validateOutInsurance())
//            {
//                txtBrand.Text = objVehicleInsuranceTypeOne.AVehicleInfo.AModel.ABrand.AName.English;
//                txtModel.Text = objVehicleInsuranceTypeOne.AVehicleInfo.AModel.AName.English;

//                ContractBase contractBase = parentForm.FacadeInsuranceTypeOne.GetCurrentVehicleContract(objVehicleInsuranceTypeOne.AVehicleInfo);
//                if (contractBase != null)
//                    txtCustomer.Text = contractBase.ACustomer.ShortName;
//                else
//                    txtCustomer.Text = "";
//                contractBase = null;
//            }
//            else
//            {
//                txtBrand.Text = "";
//                txtModel.Text = "";
//                txtCustomer.Text = "";
//            }
//        }

//        private bool validateVehicleInsurance()
//        {
//            if(fpiOrder.Text == "0" || fpiOrder.Text.Trim() == "")
//            {
//                Message(MessageList.Error.E0002, "ลำดับที่");
//                fpiOrder.Focus();
//                return false;
//            }

//            if(action == ActionType.ADD)
//            {
//                if(!parentForm.FacadeInsuranceTypeOne.ValidOrder(int.Parse(fpiOrder.Text)))
//                {
//                    Message(MessageList.Error.E0003);
//                    fpiOrder.Focus();
//                    return false;
//                }
//            }
//            else
//            {
//                if(fpiOrder.Tag.ToString() !=  fpiOrder.Text && !parentForm.FacadeInsuranceTypeOne.ValidOrder(int.Parse(fpiOrder.Text)))
//                {
//                    Message(MessageList.Error.E0003);
//                    fpiOrder.Focus();
//                    return false;
//                }
//            }

//            if(!validateVehicle())
//            {
//                return false;
//            }

//            if(action==ActionType.ADD && !validateOutInsurance())
//            {
//                return false;
//            }

//            if(dtpAffiliateDate.Value<dtpStartDate.Value || dtpAffiliateDate.Value>dtpEndDate.Value)
//            {
//                Message(MessageList.Error.E0005, "วันที่เข้าร่วมที่อยู่ในขอบเขตของกรมธรรม์");
//                dtpAffiliateDate.Focus();
//                return false;
//            }

//            if(decimal.Parse(fpdSumAssured.Text)==0m)
//            {
//                Message(MessageList.Error.E0002, "ทุนประกัน");
//                fpdSumAssured.Focus();
//                return false;
//            }

//            if(decimal.Parse(fpdPremiumAmount.Text)==0m)
//            {
//                Message(MessageList.Error.E0002, "เบี้ยประกัน");
//                fpdPremiumAmount.Focus();
//                return false;
//            }

//            if(MustCalculate)
//            {
//                Message(MessageList.Error.E0017, "กรุณากดปุ่มคำนวณ");
//                cmdCalculate.Focus();
//                return false;
//            }

//            return true;
//        }

//        //============================== Public Method ==============================
//        public void InitAddAction()
//        {
//            baseADD();
//            clearForm();
//            MustCalculate = true;
//            txtPlatePrefix.Enabled = true;
//            fpiPlateRunningNo.Enabled = true;
//        }

//        public void InitEditAction()
//        {
//            baseEDIT();
//            clearForm();
//            txtPlatePrefix.Enabled = false;
//            fpiPlateRunningNo.Enabled = false;

//            if(isReadonly)
//            {
//                cmdOK.Enabled = false;	
//                cmdCalculate.Enabled = false;
//            }
//        }

//        //============================== Base Event ==============================
//        private void AddEvent()
//        {
//            try
//            {
//                if(validateVehicleInsurance())
//                {
//                    fpiOrder.Focus();
//                    if(parentForm.AddRow(ObjVehicleInsuranceTypeOne))
//                    {
//                        this.Close();
//                    }
//                }
//            }
//            catch(AppExceptionBase ex)
//            {
//                Message(ex);
//            }
//            catch(SqlException sqlex)
//            {
//                Message(sqlex);
//            }
//            catch(Exception ex)
//            {
//                Message(ex);
//            }
//        }

//        private void EditEvent()
//        {
//            try
//            {
//                if(validateVehicleInsurance())
//                {
//                    fpiOrder.Focus();
//                    if(parentForm.UpdateRow(ObjVehicleInsuranceTypeOne))
//                    {
//                        this.Close();
//                    }
//                }
//            }
//            catch(AppExceptionBase ex)
//            {
//                Message(ex);
//            }
//            catch(SqlException sqlex)
//            {
//                Message(sqlex);
//            }
//            catch(Exception ex)
//            {
//                Message(ex);
//            }
//        }

//        //============================== event ==============================
//        private void frmInsuranceTypeOneEntry_Load(object sender, System.EventArgs e)
//        {
//            cmbInsuranceCompany.DataSource = parentForm.FacadeInsuranceTypeOne.DataSourceInsuranceCompName;
//            objInsuranceTypeOne = new InsuranceTypeOne(parentForm.FacadeInsuranceTypeOne.GetCompany());
//            objVehicleInsuranceTypeOne = new VehicleInsuranceTypeOne();
//            fpdSumAssured.MaxValue = 9999999.99;
//            fpdSumAssured.MinValue = 0;
//            fpdPremiumAmount.MaxValue = 999999.99;
//            fpdPremiumAmount.MinValue = 0;
//            fpdRevenueStampFee.MaxValue = 999999.99;
//            fpdRevenueStampFee.MinValue = 0;
//            fpdVatAmount.MaxValue = 99999.99;
//            fpdVatAmount.MinValue = 0;
//        }

//        private void fpiPlateRunningNo_DoubleClick(object sender, System.EventArgs e)
//        {
//            FrmVehicleList objfrmVehicleList = new FrmVehicleList();
//            objfrmVehicleList.ConditionPlatePrefix = txtPlatePrefix.Text;
//            objfrmVehicleList.ConditionPlateRunningNo = fpiPlateRunningNo.Text;
//            objfrmVehicleList.VehicleOutInsurance = true;
//            objfrmVehicleList.ConditionStartDate = dtpStartDate.Value;
//            objfrmVehicleList.ConditionEndDate = dtpEndDate.Value;
//            objfrmVehicleList.ShowDialog();
//            if(objfrmVehicleList.Selected)
//            {
//                objVehicleInsuranceTypeOne.AVehicleInfo = parentForm.FacadeInsuranceTypeOne.GetVehicleInfo(objfrmVehicleList.SelectedVehicle.VehicleNo);

//                ContractBase contractBase = parentForm.FacadeInsuranceTypeOne.GetCurrentVehicleContract(objVehicleInsuranceTypeOne.AVehicleInfo);
//                if (contractBase != null)
//                    txtCustomer.Text = contractBase.ACustomer.ShortName;
//                else
//                    txtCustomer.Text = "";
//                contractBase = null;

//                fpiPlateRunningNo.Text = objVehicleInsuranceTypeOne.AVehicleInfo.PlateRunningNo;
//                txtPlatePrefix.Text = objVehicleInsuranceTypeOne.AVehicleInfo.PlatePrefix;				
//                txtBrand.Text = objVehicleInsuranceTypeOne.AVehicleInfo.AModel.ABrand.AName.English;
//                txtModel.Text = objVehicleInsuranceTypeOne.AVehicleInfo.AModel.AName.English;
//                fpiOrder.Focus();
//                fpiPlateRunningNo.Focus();
//            }
			
//            objfrmVehicleList = null;
//        }

//        private void cmdCancel_Click(object sender, System.EventArgs e)
//        {
//            this.Close();
//        }

//        private void cmdCalculate_Click(object sender, System.EventArgs e)
//        {
//            try
//            {
//                objVehicleInsuranceTypeOne.PremiumAmount = decimal.Parse(fpdPremiumAmount.Text);
//                parentForm.FacadeInsuranceTypeOne.CalculateTotalPremium(objVehicleInsuranceTypeOne);
//                fpdRevenueStampFee.Value = objVehicleInsuranceTypeOne.RevenueStampFee;
//                fpdVatAmount.Value = objVehicleInsuranceTypeOne.VatAmount;
//                fpdAmount.Value = objVehicleInsuranceTypeOne.Amount;
//                MustCalculate = false;
//            }
//            catch(AppExceptionBase ex)
//            {
//                Message(ex);
//            }
//            catch(SqlException sqlex)
//            {
//                Message(sqlex);
//            }
//            catch(Exception ex)
//            {
//                Message(ex);
//            }
//        }

//        private void fpdPremiumAmount_TextChanged(object sender, System.EventArgs e)
//        {
//            if(fpdPremiumAmount.Text != "")
//            {
//                if( objVehicleInsuranceTypeOne.PremiumAmount == getDecimal(fpdPremiumAmount.Text))
//                {
//                    MustCalculate = false;
//                }
//                else
//                {
//                    MustCalculate = true;
//                }
//            }
//            else
//            {
//                fpdPremiumAmount.Value = 0.00;
//            }
//        }

//        private void cmdOK_Click(object sender, System.EventArgs e)
//        {
//            switch (action)
//            {
//                case ActionType.ADD :
//                    AddEvent();
//                    break;
//                case ActionType.EDIT :
//                    EditEvent();
//                    break;
//            }
//        }

//        private void txtPlatePrefix_TextChanged(object sender, System.EventArgs e)
//        {
//            if(txtPlatePrefix.Text.Length == 2)
//            {
//                fpiPlateRunningNo.Focus();
//            }
//        }

//        private void dtpStartDate_ValueChanged(object sender, System.EventArgs e)
//        {
//            dtpAffiliateDate.Value = dtpStartDate.Value;
//        }

//        private void fpiPlateRunningNo_TextChanged(object sender, System.EventArgs e)
//        {
//            if(fpiPlateRunningNo.Text.Length == 4 && txtPlatePrefix.Text.Length == 2)
//            {
//                fillVehicle();
//            }
//        }

//        private void fpiPlateRunningNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
//        {
//            if(e.KeyCode == Keys.Enter)
//            {
//                fillVehicle();
//            }
//        }
//    }
//}