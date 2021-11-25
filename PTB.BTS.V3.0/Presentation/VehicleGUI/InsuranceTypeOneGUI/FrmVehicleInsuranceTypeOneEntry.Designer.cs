namespace Presentation.VehicleGUI.InsuranceTypeOneGUI
{
    partial class FrmVehicleInsuranceTypeOneEntry
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
            this.gpbPolicy = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.txtPolicyNo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.gpbVehicleInsurance = new System.Windows.Forms.GroupBox();
            this.txtChassisNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEngineNo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.fpiOrderNo = new FarPoint.Win.Input.FpInteger();
            this.label4 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.lblPlateNo = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblPlatePrefix = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPlatePrefix = new System.Windows.Forms.TextBox();
            this.fpiPlateRunningNo = new FarPoint.Win.Input.FpInteger();
            this.fpdSumAssured = new FarPoint.Win.Input.FpDouble();
            this.fpdVatPercent = new FarPoint.Win.Input.FpDouble();
            this.fpdVatAmount = new FarPoint.Win.Input.FpDouble();
            this.fpdRevenueStampFee = new FarPoint.Win.Input.FpDouble();
            this.fpdPremiumAmount = new FarPoint.Win.Input.FpDouble();
            this.fpdTotalAmount = new FarPoint.Win.Input.FpDouble();
            this.btnCalAmount = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpAffiliateDate = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.gpbPolicy.SuspendLayout();
            this.gpbVehicleInsurance.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbPolicy
            // 
            this.gpbPolicy.Controls.Add(this.label1);
            this.gpbPolicy.Controls.Add(this.label2);
            this.gpbPolicy.Controls.Add(this.dtpEndDate);
            this.gpbPolicy.Controls.Add(this.dtpStartDate);
            this.gpbPolicy.Controls.Add(this.txtPolicyNo);
            this.gpbPolicy.Controls.Add(this.label11);
            this.gpbPolicy.Location = new System.Drawing.Point(14, 0);
            this.gpbPolicy.Name = "gpbPolicy";
            this.gpbPolicy.Size = new System.Drawing.Size(387, 80);
            this.gpbPolicy.TabIndex = 99;
            this.gpbPolicy.TabStop = false;
            this.gpbPolicy.Text = "ข้อมูลกรมธรรม์";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(224, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 100;
            this.label1.Text = "วันหมดอายุ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 103;
            this.label2.Text = "วันเริ่มประกัน";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Enabled = false;
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(285, 45);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(92, 21);
            this.dtpEndDate.TabIndex = 102;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Enabled = false;
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(120, 45);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(90, 21);
            this.dtpStartDate.TabIndex = 101;
            // 
            // txtPolicyNo
            // 
            this.txtPolicyNo.Enabled = false;
            this.txtPolicyNo.Location = new System.Drawing.Point(120, 20);
            this.txtPolicyNo.Name = "txtPolicyNo";
            this.txtPolicyNo.Size = new System.Drawing.Size(256, 21);
            this.txtPolicyNo.TabIndex = 48;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(33, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 15);
            this.label11.TabIndex = 21;
            this.label11.Text = "เลขที่กรมธรรม์";
            // 
            // gpbVehicleInsurance
            // 
            this.gpbVehicleInsurance.Controls.Add(this.txtChassisNo);
            this.gpbVehicleInsurance.Controls.Add(this.label9);
            this.gpbVehicleInsurance.Controls.Add(this.txtEngineNo);
            this.gpbVehicleInsurance.Controls.Add(this.label10);
            this.gpbVehicleInsurance.Controls.Add(this.fpiOrderNo);
            this.gpbVehicleInsurance.Controls.Add(this.label4);
            this.gpbVehicleInsurance.Controls.Add(this.txtModel);
            this.gpbVehicleInsurance.Controls.Add(this.label5);
            this.gpbVehicleInsurance.Controls.Add(this.label6);
            this.gpbVehicleInsurance.Controls.Add(this.txtBrand);
            this.gpbVehicleInsurance.Controls.Add(this.lblPlateNo);
            this.gpbVehicleInsurance.Controls.Add(this.label23);
            this.gpbVehicleInsurance.Controls.Add(this.lblPlatePrefix);
            this.gpbVehicleInsurance.Controls.Add(this.label7);
            this.gpbVehicleInsurance.Controls.Add(this.txtPlatePrefix);
            this.gpbVehicleInsurance.Controls.Add(this.fpiPlateRunningNo);
            this.gpbVehicleInsurance.Controls.Add(this.fpdSumAssured);
            this.gpbVehicleInsurance.Controls.Add(this.fpdVatPercent);
            this.gpbVehicleInsurance.Controls.Add(this.fpdVatAmount);
            this.gpbVehicleInsurance.Controls.Add(this.fpdRevenueStampFee);
            this.gpbVehicleInsurance.Controls.Add(this.fpdPremiumAmount);
            this.gpbVehicleInsurance.Controls.Add(this.fpdTotalAmount);
            this.gpbVehicleInsurance.Controls.Add(this.btnCalAmount);
            this.gpbVehicleInsurance.Controls.Add(this.label14);
            this.gpbVehicleInsurance.Controls.Add(this.label19);
            this.gpbVehicleInsurance.Controls.Add(this.label15);
            this.gpbVehicleInsurance.Controls.Add(this.label18);
            this.gpbVehicleInsurance.Controls.Add(this.label16);
            this.gpbVehicleInsurance.Controls.Add(this.label17);
            this.gpbVehicleInsurance.Controls.Add(this.label8);
            this.gpbVehicleInsurance.Controls.Add(this.dtpAffiliateDate);
            this.gpbVehicleInsurance.Controls.Add(this.label13);
            this.gpbVehicleInsurance.Controls.Add(this.label3);
            this.gpbVehicleInsurance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gpbVehicleInsurance.Location = new System.Drawing.Point(14, 80);
            this.gpbVehicleInsurance.Name = "gpbVehicleInsurance";
            this.gpbVehicleInsurance.Size = new System.Drawing.Size(387, 384);
            this.gpbVehicleInsurance.TabIndex = 0;
            this.gpbVehicleInsurance.TabStop = false;
            this.gpbVehicleInsurance.Text = "ข้อมูลรถในกรมธรรม์";
            // 
            // txtChassisNo
            // 
            this.txtChassisNo.Enabled = false;
            this.txtChassisNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtChassisNo.Location = new System.Drawing.Point(120, 171);
            this.txtChassisNo.MaxLength = 20;
            this.txtChassisNo.Name = "txtChassisNo";
            this.txtChassisNo.Size = new System.Drawing.Size(160, 20);
            this.txtChassisNo.TabIndex = 165;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label9.Location = new System.Drawing.Point(34, 174);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 163;
            this.label9.Text = "หมายเลขตัวถัง";
            // 
            // txtEngineNo
            // 
            this.txtEngineNo.Enabled = false;
            this.txtEngineNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtEngineNo.Location = new System.Drawing.Point(120, 141);
            this.txtEngineNo.MaxLength = 20;
            this.txtEngineNo.Name = "txtEngineNo";
            this.txtEngineNo.Size = new System.Drawing.Size(160, 20);
            this.txtEngineNo.TabIndex = 164;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label10.Location = new System.Drawing.Point(8, 144);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 13);
            this.label10.TabIndex = 162;
            this.label10.Text = "หมายเลขเครื่องยนต์";
            // 
            // fpiOrderNo
            // 
            this.fpiOrderNo.AllowClipboardKeys = true;
            this.fpiOrderNo.AllowNull = true;
            this.fpiOrderNo.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiOrderNo.Location = new System.Drawing.Point(120, 24);
            this.fpiOrderNo.MaxValue = 999;
            this.fpiOrderNo.MinValue = 0;
            this.fpiOrderNo.Name = "fpiOrderNo";
            this.fpiOrderNo.NullColor = System.Drawing.Color.Transparent;
            this.fpiOrderNo.Size = new System.Drawing.Size(40, 20);
            this.fpiOrderNo.TabIndex = 161;
            this.fpiOrderNo.TabStop = false;
            this.fpiOrderNo.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(160, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 25);
            this.label4.TabIndex = 160;
            this.label4.Text = "-";
            // 
            // txtModel
            // 
            this.txtModel.Enabled = false;
            this.txtModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtModel.Location = new System.Drawing.Point(120, 112);
            this.txtModel.MaxLength = 50;
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(248, 20);
            this.txtModel.TabIndex = 159;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(76, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 158;
            this.label5.Text = "รุ่นรถ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(70, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 157;
            this.label6.Text = "ยี่ห้อรถ";
            // 
            // txtBrand
            // 
            this.txtBrand.Enabled = false;
            this.txtBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtBrand.Location = new System.Drawing.Point(120, 83);
            this.txtBrand.MaxLength = 50;
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(248, 20);
            this.txtBrand.TabIndex = 156;
            // 
            // lblPlateNo
            // 
            this.lblPlateNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPlateNo.Location = new System.Drawing.Point(296, 51);
            this.lblPlateNo.Name = "lblPlateNo";
            this.lblPlateNo.Size = new System.Drawing.Size(72, 24);
            this.lblPlateNo.TabIndex = 155;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label23.Location = new System.Drawing.Point(280, 51);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(19, 25);
            this.label23.TabIndex = 154;
            this.label23.Text = "-";
            // 
            // lblPlatePrefix
            // 
            this.lblPlatePrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPlatePrefix.Location = new System.Drawing.Point(240, 51);
            this.lblPlatePrefix.Name = "lblPlatePrefix";
            this.lblPlatePrefix.Size = new System.Drawing.Size(40, 24);
            this.lblPlatePrefix.TabIndex = 153;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(51, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 152;
            this.label7.Text = "ทะเบียนรถ";
            // 
            // txtPlatePrefix
            // 
            this.txtPlatePrefix.Location = new System.Drawing.Point(120, 53);
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
            this.fpiPlateRunningNo.Location = new System.Drawing.Point(176, 53);
            this.fpiPlateRunningNo.MaxValue = 9999;
            this.fpiPlateRunningNo.MinValue = 0;
            this.fpiPlateRunningNo.Name = "fpiPlateRunningNo";
            this.fpiPlateRunningNo.NullColor = System.Drawing.Color.Transparent;
            this.fpiPlateRunningNo.Size = new System.Drawing.Size(48, 20);
            this.fpiPlateRunningNo.TabIndex = 2;
            this.fpiPlateRunningNo.Text = "";
            this.fpiPlateRunningNo.DoubleClick += new System.EventHandler(this.fpiPlateRunningNo_DoubleClick);
            this.fpiPlateRunningNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpiPlateRunningNo_KeyDown);
            this.fpiPlateRunningNo.TextChanged += new System.EventHandler(this.fpiPlateRunningNo_TextChanged);
            // 
            // fpdSumAssured
            // 
            this.fpdSumAssured.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdSumAssured.AllowClipboardKeys = true;
            this.fpdSumAssured.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdSumAssured.DecimalPlaces = 2;
            this.fpdSumAssured.DecimalSeparator = ".";
            this.fpdSumAssured.FixedPoint = true;
            this.fpdSumAssured.Location = new System.Drawing.Point(120, 231);
            this.fpdSumAssured.Name = "fpdSumAssured";
            this.fpdSumAssured.NumberGroupSeparator = ",";
            this.fpdSumAssured.NumberGroupSize = 3;
            this.fpdSumAssured.Size = new System.Drawing.Size(101, 20);
            this.fpdSumAssured.TabIndex = 4;
            this.fpdSumAssured.Text = "";
            this.fpdSumAssured.UseSeparator = true;
            // 
            // fpdVatPercent
            // 
            this.fpdVatPercent.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdVatPercent.AllowClipboardKeys = true;
            this.fpdVatPercent.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdVatPercent.DecimalPlaces = 2;
            this.fpdVatPercent.DecimalSeparator = ".";
            this.fpdVatPercent.FixedPoint = true;
            this.fpdVatPercent.Location = new System.Drawing.Point(272, 318);
            this.fpdVatPercent.Name = "fpdVatPercent";
            this.fpdVatPercent.NumberGroupSize = 0;
            this.fpdVatPercent.Size = new System.Drawing.Size(48, 20);
            this.fpdVatPercent.TabIndex = 78;
            this.fpdVatPercent.TabStop = false;
            this.fpdVatPercent.Text = "";
            this.fpdVatPercent.UseSeparator = true;
            // 
            // fpdVatAmount
            // 
            this.fpdVatAmount.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdVatAmount.AllowClipboardKeys = true;
            this.fpdVatAmount.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdVatAmount.DecimalPlaces = 2;
            this.fpdVatAmount.DecimalSeparator = ".";
            this.fpdVatAmount.FixedPoint = true;
            this.fpdVatAmount.Location = new System.Drawing.Point(120, 318);
            this.fpdVatAmount.Name = "fpdVatAmount";
            this.fpdVatAmount.NumberGroupSeparator = ",";
            this.fpdVatAmount.NumberGroupSize = 3;
            this.fpdVatAmount.Size = new System.Drawing.Size(101, 20);
            this.fpdVatAmount.TabIndex = 69;
            this.fpdVatAmount.TabStop = false;
            this.fpdVatAmount.Text = "";
            this.fpdVatAmount.UseSeparator = true;
            // 
            // fpdRevenueStampFee
            // 
            this.fpdRevenueStampFee.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdRevenueStampFee.AllowClipboardKeys = true;
            this.fpdRevenueStampFee.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdRevenueStampFee.DecimalPlaces = 2;
            this.fpdRevenueStampFee.DecimalSeparator = ".";
            this.fpdRevenueStampFee.FixedPoint = true;
            this.fpdRevenueStampFee.Location = new System.Drawing.Point(120, 289);
            this.fpdRevenueStampFee.Name = "fpdRevenueStampFee";
            this.fpdRevenueStampFee.NumberGroupSeparator = ",";
            this.fpdRevenueStampFee.NumberGroupSize = 3;
            this.fpdRevenueStampFee.Size = new System.Drawing.Size(101, 20);
            this.fpdRevenueStampFee.TabIndex = 68;
            this.fpdRevenueStampFee.TabStop = false;
            this.fpdRevenueStampFee.Text = "";
            this.fpdRevenueStampFee.UseSeparator = true;
            // 
            // fpdPremiumAmount
            // 
            this.fpdPremiumAmount.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdPremiumAmount.AllowClipboardKeys = true;
            this.fpdPremiumAmount.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdPremiumAmount.DecimalPlaces = 2;
            this.fpdPremiumAmount.DecimalSeparator = ".";
            this.fpdPremiumAmount.FixedPoint = true;
            this.fpdPremiumAmount.Location = new System.Drawing.Point(120, 260);
            this.fpdPremiumAmount.Name = "fpdPremiumAmount";
            this.fpdPremiumAmount.NumberGroupSeparator = ",";
            this.fpdPremiumAmount.NumberGroupSize = 3;
            this.fpdPremiumAmount.Size = new System.Drawing.Size(101, 20);
            this.fpdPremiumAmount.TabIndex = 5;
            this.fpdPremiumAmount.Text = "";
            this.fpdPremiumAmount.UseSeparator = true;
            // 
            // fpdTotalAmount
            // 
            this.fpdTotalAmount.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdTotalAmount.AllowClipboardKeys = true;
            this.fpdTotalAmount.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdTotalAmount.DecimalPlaces = 2;
            this.fpdTotalAmount.DecimalSeparator = ".";
            this.fpdTotalAmount.Enabled = false;
            this.fpdTotalAmount.FixedPoint = true;
            this.fpdTotalAmount.Location = new System.Drawing.Point(120, 347);
            this.fpdTotalAmount.Name = "fpdTotalAmount";
            this.fpdTotalAmount.NumberGroupSeparator = ",";
            this.fpdTotalAmount.NumberGroupSize = 3;
            this.fpdTotalAmount.Size = new System.Drawing.Size(101, 20);
            this.fpdTotalAmount.TabIndex = 77;
            this.fpdTotalAmount.Text = "";
            this.fpdTotalAmount.UseSeparator = true;
            // 
            // btnCalAmount
            // 
            this.btnCalAmount.Location = new System.Drawing.Point(240, 259);
            this.btnCalAmount.Name = "btnCalAmount";
            this.btnCalAmount.Size = new System.Drawing.Size(75, 23);
            this.btnCalAmount.TabIndex = 6;
            this.btnCalAmount.Text = "คำนวณ";
            this.btnCalAmount.UseVisualStyleBackColor = true;
            this.btnCalAmount.Click += new System.EventHandler(this.btnCalAmount_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(37, 263);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 13);
            this.label14.TabIndex = 71;
            this.label14.Text = "เบี้ยประกันภัย";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(46, 350);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(64, 13);
            this.label19.TabIndex = 76;
            this.label19.Text = "รวมเป็นเงิน";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(44, 292);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(66, 13);
            this.label15.TabIndex = 72;
            this.label15.Text = "อากรแสตมป์";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(328, 321);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(15, 13);
            this.label18.TabIndex = 75;
            this.label18.Text = "%";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(38, 321);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 13);
            this.label16.TabIndex = 73;
            this.label16.Text = "ภาษีมูลค่าเพิ่ม";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(239, 321);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(28, 13);
            this.label17.TabIndex = 74;
            this.label17.Text = "VAT";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(46, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 64;
            this.label8.Text = "วันที่เข้าร่วม";
            // 
            // dtpAffiliateDate
            // 
            this.dtpAffiliateDate.Checked = false;
            this.dtpAffiliateDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAffiliateDate.Location = new System.Drawing.Point(120, 201);
            this.dtpAffiliateDate.Name = "dtpAffiliateDate";
            this.dtpAffiliateDate.ShowCheckBox = true;
            this.dtpAffiliateDate.Size = new System.Drawing.Size(104, 20);
            this.dtpAffiliateDate.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(55, 234);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 41;
            this.label13.Text = "ทุนประกัน";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "ลำดับ";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(210, 480);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Location = new System.Drawing.Point(129, 480);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "ตกลง";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FrmVehicleInsuranceTypeOneEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(414, 520);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gpbVehicleInsurance);
            this.Controls.Add(this.gpbPolicy);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmVehicleInsuranceTypeOneEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FrmVehicleInsuranceTypeOneEntry_Load);
            this.gpbPolicy.ResumeLayout(false);
            this.gpbPolicy.PerformLayout();
            this.gpbVehicleInsurance.ResumeLayout(false);
            this.gpbVehicleInsurance.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbPolicy;
        private System.Windows.Forms.TextBox txtPolicyNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox gpbVehicleInsurance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpAffiliateDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private FarPoint.Win.Input.FpDouble fpdVatPercent;
        private FarPoint.Win.Input.FpDouble fpdVatAmount;
        private FarPoint.Win.Input.FpDouble fpdRevenueStampFee;
        private FarPoint.Win.Input.FpDouble fpdPremiumAmount;
        private FarPoint.Win.Input.FpDouble fpdTotalAmount;
        private System.Windows.Forms.Button btnCalAmount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private FarPoint.Win.Input.FpDouble fpdSumAssured;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private FarPoint.Win.Input.FpInteger fpiOrderNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.Label lblPlateNo;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblPlatePrefix;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPlatePrefix;
        private FarPoint.Win.Input.FpInteger fpiPlateRunningNo;
        private System.Windows.Forms.TextBox txtChassisNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEngineNo;
        private System.Windows.Forms.Label label10;
    }
}
