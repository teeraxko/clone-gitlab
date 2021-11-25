namespace Presentation.VehicleGUI.ProfitCalculationGUI
{
    partial class FrmProfitCalculation
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
            this.fpdInterestRate = new FarPoint.Win.Input.FpDouble();
            this.fpdInsurancePremium = new FarPoint.Win.Input.FpDouble();
            this.fpdCapitalInsurance = new FarPoint.Win.Input.FpDouble();
            this.fpdDepreciation = new FarPoint.Win.Input.FpDouble();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fpdRegister = new FarPoint.Win.Input.FpDouble();
            this.btnClose = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.fpdMaintenance = new FarPoint.Win.Input.FpDouble();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.label43 = new System.Windows.Forms.Label();
            this.fpdMonthlyRound = new FarPoint.Win.Input.FpDouble();
            this.btnPrint = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gpbOtherDetail = new System.Windows.Forms.GroupBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.gpbCalculate = new System.Windows.Forms.GroupBox();
            this.gpbQuotationDetail = new System.Windows.Forms.GroupBox();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbModel = new System.Windows.Forms.ComboBox();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.fpdBodyPrice = new FarPoint.Win.Input.FpDouble();
            this.label7 = new System.Windows.Forms.Label();
            this.fpdPercentResidual = new FarPoint.Win.Input.FpDouble();
            this.label30 = new System.Windows.Forms.Label();
            this.fpdPercentRateOfReturn = new FarPoint.Win.Input.FpDouble();
            this.label4 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.fpiLeaseTerm = new FarPoint.Win.Input.FpInteger();
            this.label29 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtQuotationNoXXX = new System.Windows.Forms.TextBox();
            this.txtQuotationNoMM = new System.Windows.Forms.TextBox();
            this.txtQuotationNoYY = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtMonthlyCharge = new FarPoint.Win.Input.FpDouble();
            this.groupBox2.SuspendLayout();
            this.gpbOtherDetail.SuspendLayout();
            this.gpbCalculate.SuspendLayout();
            this.gpbQuotationDetail.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fpdInterestRate
            // 
            this.fpdInterestRate.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdInterestRate.AllowClipboardKeys = true;
            this.fpdInterestRate.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdInterestRate.DecimalPlaces = 2;
            this.fpdInterestRate.DecimalSeparator = ".";
            this.fpdInterestRate.FixedPoint = true;
            this.fpdInterestRate.Location = new System.Drawing.Point(155, 20);
            this.fpdInterestRate.Name = "fpdInterestRate";
            this.fpdInterestRate.Size = new System.Drawing.Size(48, 20);
            this.fpdInterestRate.TabIndex = 52;
            this.fpdInterestRate.Text = "";
            // 
            // fpdInsurancePremium
            // 
            this.fpdInsurancePremium.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdInsurancePremium.AllowClipboardKeys = true;
            this.fpdInsurancePremium.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdInsurancePremium.DecimalPlaces = 2;
            this.fpdInsurancePremium.DecimalSeparator = ".";
            this.fpdInsurancePremium.FixedPoint = true;
            this.fpdInsurancePremium.Location = new System.Drawing.Point(151, 46);
            this.fpdInsurancePremium.Name = "fpdInsurancePremium";
            this.fpdInsurancePremium.NumberGroupSeparator = ",";
            this.fpdInsurancePremium.NumberGroupSize = 3;
            this.fpdInsurancePremium.Size = new System.Drawing.Size(104, 20);
            this.fpdInsurancePremium.TabIndex = 55;
            this.fpdInsurancePremium.Text = "";
            this.fpdInsurancePremium.UseSeparator = true;
            // 
            // fpdCapitalInsurance
            // 
            this.fpdCapitalInsurance.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdCapitalInsurance.AllowClipboardKeys = true;
            this.fpdCapitalInsurance.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdCapitalInsurance.DecimalPlaces = 2;
            this.fpdCapitalInsurance.DecimalSeparator = ".";
            this.fpdCapitalInsurance.FixedPoint = true;
            this.fpdCapitalInsurance.Location = new System.Drawing.Point(151, 20);
            this.fpdCapitalInsurance.Name = "fpdCapitalInsurance";
            this.fpdCapitalInsurance.NumberGroupSeparator = ",";
            this.fpdCapitalInsurance.NumberGroupSize = 3;
            this.fpdCapitalInsurance.Size = new System.Drawing.Size(104, 20);
            this.fpdCapitalInsurance.TabIndex = 54;
            this.fpdCapitalInsurance.Text = "";
            this.fpdCapitalInsurance.UseSeparator = true;
            // 
            // fpdDepreciation
            // 
            this.fpdDepreciation.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdDepreciation.AllowClipboardKeys = true;
            this.fpdDepreciation.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdDepreciation.DecimalPlaces = 2;
            this.fpdDepreciation.DecimalSeparator = ".";
            this.fpdDepreciation.Location = new System.Drawing.Point(155, 46);
            this.fpdDepreciation.Name = "fpdDepreciation";
            this.fpdDepreciation.Size = new System.Drawing.Size(48, 20);
            this.fpdDepreciation.TabIndex = 55;
            this.fpdDepreciation.Text = "";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(8, 101);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(119, 13);
            this.label40.TabIndex = 49;
            this.label40.Text = "Maintenance Spare Car";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(261, 101);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(41, 13);
            this.label41.TabIndex = 50;
            this.label41.Text = "/month";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 51;
            this.label2.Text = "%";
            // 
            // fpdRegister
            // 
            this.fpdRegister.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdRegister.AllowClipboardKeys = true;
            this.fpdRegister.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdRegister.DecimalPlaces = 2;
            this.fpdRegister.DecimalSeparator = ".";
            this.fpdRegister.FixedPoint = true;
            this.fpdRegister.Location = new System.Drawing.Point(151, 72);
            this.fpdRegister.Name = "fpdRegister";
            this.fpdRegister.NumberGroupSeparator = ",";
            this.fpdRegister.NumberGroupSize = 3;
            this.fpdRegister.Size = new System.Drawing.Size(104, 20);
            this.fpdRegister.TabIndex = 56;
            this.fpdRegister.Text = "";
            this.fpdRegister.UseSeparator = true;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(350, 377);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 67;
            this.btnClose.Text = "ปิด";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(74, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 53;
            this.label6.Text = "Depreciation";
            // 
            // fpdMaintenance
            // 
            this.fpdMaintenance.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdMaintenance.AllowClipboardKeys = true;
            this.fpdMaintenance.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdMaintenance.DecimalPlaces = 2;
            this.fpdMaintenance.DecimalSeparator = ".";
            this.fpdMaintenance.FixedPoint = true;
            this.fpdMaintenance.Location = new System.Drawing.Point(151, 98);
            this.fpdMaintenance.Name = "fpdMaintenance";
            this.fpdMaintenance.NumberGroupSeparator = ",";
            this.fpdMaintenance.NumberGroupSize = 3;
            this.fpdMaintenance.Size = new System.Drawing.Size(104, 20);
            this.fpdMaintenance.TabIndex = 57;
            this.fpdMaintenance.Text = "";
            this.fpdMaintenance.UseSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "Interest Rate";
            // 
            // btnCalculate
            // 
            this.btnCalculate.ForeColor = System.Drawing.Color.Blue;
            this.btnCalculate.Location = new System.Drawing.Point(262, 46);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 53;
            this.btnCalculate.Text = "คำนวณ";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(54, 23);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(81, 13);
            this.label43.TabIndex = 52;
            this.label43.Text = "Monthly Charge";
            // 
            // fpdMonthlyRound
            // 
            this.fpdMonthlyRound.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdMonthlyRound.AllowClipboardKeys = true;
            this.fpdMonthlyRound.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdMonthlyRound.DecimalPlaces = 2;
            this.fpdMonthlyRound.DecimalSeparator = ".";
            this.fpdMonthlyRound.FixedPoint = true;
            this.fpdMonthlyRound.Location = new System.Drawing.Point(149, 47);
            this.fpdMonthlyRound.Name = "fpdMonthlyRound";
            this.fpdMonthlyRound.NumberGroupSeparator = ",";
            this.fpdMonthlyRound.NumberGroupSize = 3;
            this.fpdMonthlyRound.Size = new System.Drawing.Size(104, 20);
            this.fpdMonthlyRound.TabIndex = 59;
            this.fpdMonthlyRound.Text = "";
            this.fpdMonthlyRound.UseSeparator = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(269, 377);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 66;
            this.btnPrint.Text = "พิมพ์";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.fpdInterestRate);
            this.groupBox2.Controls.Add(this.fpdDepreciation);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(7, 281);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(679, 76);
            this.groupBox2.TabIndex = 65;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Interest and Depreciation";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(209, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "%";
            // 
            // gpbOtherDetail
            // 
            this.gpbOtherDetail.Controls.Add(this.fpdMaintenance);
            this.gpbOtherDetail.Controls.Add(this.fpdRegister);
            this.gpbOtherDetail.Controls.Add(this.fpdInsurancePremium);
            this.gpbOtherDetail.Controls.Add(this.fpdCapitalInsurance);
            this.gpbOtherDetail.Controls.Add(this.label41);
            this.gpbOtherDetail.Controls.Add(this.label40);
            this.gpbOtherDetail.Controls.Add(this.label37);
            this.gpbOtherDetail.Controls.Add(this.label38);
            this.gpbOtherDetail.Controls.Add(this.label39);
            this.gpbOtherDetail.Location = new System.Drawing.Point(337, 62);
            this.gpbOtherDetail.Name = "gpbOtherDetail";
            this.gpbOtherDetail.Size = new System.Drawing.Size(349, 125);
            this.gpbOtherDetail.TabIndex = 63;
            this.gpbOtherDetail.TabStop = false;
            this.gpbOtherDetail.Text = "Vehicle Cost";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(43, 22);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(89, 13);
            this.label37.TabIndex = 46;
            this.label37.Text = "Capital Insurance";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(30, 49);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(97, 13);
            this.label38.TabIndex = 47;
            this.label38.Text = "Insurance Premium";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(45, 75);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(88, 13);
            this.label39.TabIndex = 48;
            this.label39.Text = "Tax and Register";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(72, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 61;
            this.label10.Text = "Rounded to";
            // 
            // gpbCalculate
            // 
            this.gpbCalculate.Controls.Add(this.txtMonthlyCharge);
            this.gpbCalculate.Controls.Add(this.label10);
            this.gpbCalculate.Controls.Add(this.btnCalculate);
            this.gpbCalculate.Controls.Add(this.label43);
            this.gpbCalculate.Controls.Add(this.fpdMonthlyRound);
            this.gpbCalculate.Location = new System.Drawing.Point(339, 193);
            this.gpbCalculate.Name = "gpbCalculate";
            this.gpbCalculate.Size = new System.Drawing.Size(347, 82);
            this.gpbCalculate.TabIndex = 64;
            this.gpbCalculate.TabStop = false;
            this.gpbCalculate.Text = "Calculation of leasing";
            // 
            // gpbQuotationDetail
            // 
            this.gpbQuotationDetail.Controls.Add(this.cmbCustomer);
            this.gpbQuotationDetail.Controls.Add(this.label9);
            this.gpbQuotationDetail.Controls.Add(this.label8);
            this.gpbQuotationDetail.Controls.Add(this.cmbModel);
            this.gpbQuotationDetail.Controls.Add(this.cmbBrand);
            this.gpbQuotationDetail.Controls.Add(this.fpdBodyPrice);
            this.gpbQuotationDetail.Controls.Add(this.label7);
            this.gpbQuotationDetail.Controls.Add(this.fpdPercentResidual);
            this.gpbQuotationDetail.Controls.Add(this.label30);
            this.gpbQuotationDetail.Controls.Add(this.fpdPercentRateOfReturn);
            this.gpbQuotationDetail.Controls.Add(this.label4);
            this.gpbQuotationDetail.Controls.Add(this.label23);
            this.gpbQuotationDetail.Controls.Add(this.fpiLeaseTerm);
            this.gpbQuotationDetail.Controls.Add(this.label29);
            this.gpbQuotationDetail.Controls.Add(this.label25);
            this.gpbQuotationDetail.Controls.Add(this.label24);
            this.gpbQuotationDetail.Controls.Add(this.label31);
            this.gpbQuotationDetail.Location = new System.Drawing.Point(6, 62);
            this.gpbQuotationDetail.Name = "gpbQuotationDetail";
            this.gpbQuotationDetail.Size = new System.Drawing.Size(325, 213);
            this.gpbQuotationDetail.TabIndex = 62;
            this.gpbQuotationDetail.TabStop = false;
            this.gpbQuotationDetail.Text = "Leasing Detail";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(155, 19);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(121, 21);
            this.cmbCustomer.TabIndex = 60;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(109, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 59;
            this.label9.Text = "Model";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(109, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 58;
            this.label8.Text = "Brand";
            // 
            // cmbModel
            // 
            this.cmbModel.FormattingEnabled = true;
            this.cmbModel.Location = new System.Drawing.Point(155, 76);
            this.cmbModel.Name = "cmbModel";
            this.cmbModel.Size = new System.Drawing.Size(123, 21);
            this.cmbModel.TabIndex = 57;
            // 
            // cmbBrand
            // 
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(155, 47);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(123, 21);
            this.cmbBrand.TabIndex = 56;
            this.cmbBrand.SelectedIndexChanged += new System.EventHandler(this.cmbBrand_SelectedIndexChanged);
            // 
            // fpdBodyPrice
            // 
            this.fpdBodyPrice.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdBodyPrice.AllowClipboardKeys = true;
            this.fpdBodyPrice.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdBodyPrice.DecimalPlaces = 2;
            this.fpdBodyPrice.DecimalSeparator = ".";
            this.fpdBodyPrice.FixedPoint = true;
            this.fpdBodyPrice.Location = new System.Drawing.Point(155, 105);
            this.fpdBodyPrice.Name = "fpdBodyPrice";
            this.fpdBodyPrice.NumberGroupSeparator = ",";
            this.fpdBodyPrice.NumberGroupSize = 3;
            this.fpdBodyPrice.Size = new System.Drawing.Size(104, 20);
            this.fpdBodyPrice.TabIndex = 40;
            this.fpdBodyPrice.Text = "";
            this.fpdBodyPrice.UseSeparator = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(89, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Customer";
            // 
            // fpdPercentResidual
            // 
            this.fpdPercentResidual.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdPercentResidual.AllowClipboardKeys = true;
            this.fpdPercentResidual.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdPercentResidual.DecimalPlaces = 2;
            this.fpdPercentResidual.DecimalSeparator = ".";
            this.fpdPercentResidual.Location = new System.Drawing.Point(155, 131);
            this.fpdPercentResidual.Name = "fpdPercentResidual";
            this.fpdPercentResidual.Size = new System.Drawing.Size(48, 20);
            this.fpdPercentResidual.TabIndex = 43;
            this.fpdPercentResidual.Text = "";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(63, 186);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(77, 13);
            this.label30.TabIndex = 47;
            this.label30.Text = "Rate of Return";
            // 
            // fpdPercentRateOfReturn
            // 
            this.fpdPercentRateOfReturn.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdPercentRateOfReturn.AllowClipboardKeys = true;
            this.fpdPercentRateOfReturn.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdPercentRateOfReturn.DecimalPlaces = 2;
            this.fpdPercentRateOfReturn.DecimalSeparator = ".";
            this.fpdPercentRateOfReturn.FixedPoint = true;
            this.fpdPercentRateOfReturn.Location = new System.Drawing.Point(155, 183);
            this.fpdPercentRateOfReturn.Name = "fpdPercentRateOfReturn";
            this.fpdPercentRateOfReturn.Size = new System.Drawing.Size(48, 20);
            this.fpdPercentRateOfReturn.TabIndex = 49;
            this.fpdPercentRateOfReturn.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(80, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "Lease term";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(209, 160);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(36, 13);
            this.label23.TabIndex = 45;
            this.label23.Text = "month";
            // 
            // fpiLeaseTerm
            // 
            this.fpiLeaseTerm.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiLeaseTerm.AllowClipboardKeys = true;
            this.fpiLeaseTerm.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiLeaseTerm.Location = new System.Drawing.Point(155, 157);
            this.fpiLeaseTerm.MaxValue = 250;
            this.fpiLeaseTerm.MinValue = 0;
            this.fpiLeaseTerm.Name = "fpiLeaseTerm";
            this.fpiLeaseTerm.Size = new System.Drawing.Size(48, 20);
            this.fpiLeaseTerm.TabIndex = 46;
            this.fpiLeaseTerm.Text = "";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(209, 186);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(15, 13);
            this.label29.TabIndex = 48;
            this.label29.Text = "%";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(59, 134);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(78, 13);
            this.label25.TabIndex = 41;
            this.label25.Text = "Residual Value";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(209, 134);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(15, 13);
            this.label24.TabIndex = 42;
            this.label24.Text = "%";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(72, 108);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(68, 13);
            this.label31.TabIndex = 38;
            this.label31.Text = "Vehicle price";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtQuotationNoXXX);
            this.groupBox1.Controls.Add(this.txtQuotationNoMM);
            this.groupBox1.Controls.Add(this.txtQuotationNoYY);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(680, 44);
            this.groupBox1.TabIndex = 61;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quotation";
            // 
            // txtQuotationNoXXX
            // 
            this.txtQuotationNoXXX.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtQuotationNoXXX.Location = new System.Drawing.Point(220, 14);
            this.txtQuotationNoXXX.MaxLength = 3;
            this.txtQuotationNoXXX.Name = "txtQuotationNoXXX";
            this.txtQuotationNoXXX.Size = new System.Drawing.Size(32, 20);
            this.txtQuotationNoXXX.TabIndex = 25;
            this.txtQuotationNoXXX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtQuotationNoXXX.TextChanged += new System.EventHandler(this.txtQuotationNoXXX_TextChanged);
            this.txtQuotationNoXXX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuotationNoXXX_KeyDown);
            // 
            // txtQuotationNoMM
            // 
            this.txtQuotationNoMM.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtQuotationNoMM.Location = new System.Drawing.Point(188, 14);
            this.txtQuotationNoMM.MaxLength = 2;
            this.txtQuotationNoMM.Name = "txtQuotationNoMM";
            this.txtQuotationNoMM.Size = new System.Drawing.Size(32, 20);
            this.txtQuotationNoMM.TabIndex = 24;
            this.txtQuotationNoMM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtQuotationNoMM.TextChanged += new System.EventHandler(this.txtQuotationNoMM_TextChanged);
            this.txtQuotationNoMM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuotationNoMM_KeyDown);
            // 
            // txtQuotationNoYY
            // 
            this.txtQuotationNoYY.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtQuotationNoYY.Location = new System.Drawing.Point(156, 14);
            this.txtQuotationNoYY.MaxLength = 2;
            this.txtQuotationNoYY.Name = "txtQuotationNoYY";
            this.txtQuotationNoYY.Size = new System.Drawing.Size(32, 20);
            this.txtQuotationNoYY.TabIndex = 23;
            this.txtQuotationNoYY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtQuotationNoYY.TextChanged += new System.EventHandler(this.txtQuotationNoYY_TextChanged);
            this.txtQuotationNoYY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuotationNoYY_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Quotation No. : PTB  - Q -";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(538, 377);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 68;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtMonthlyCharge
            // 
            this.txtMonthlyCharge.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.txtMonthlyCharge.AllowClipboardKeys = true;
            this.txtMonthlyCharge.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.txtMonthlyCharge.DecimalPlaces = 2;
            this.txtMonthlyCharge.DecimalSeparator = ".";
            this.txtMonthlyCharge.FixedPoint = true;
            this.txtMonthlyCharge.Location = new System.Drawing.Point(149, 19);
            this.txtMonthlyCharge.Name = "txtMonthlyCharge";
            this.txtMonthlyCharge.NumberGroupSeparator = ",";
            this.txtMonthlyCharge.NumberGroupSize = 3;
            this.txtMonthlyCharge.Size = new System.Drawing.Size(104, 20);
            this.txtMonthlyCharge.TabIndex = 60;
            this.txtMonthlyCharge.Text = "";
            this.txtMonthlyCharge.UseSeparator = true;
            // 
            // FrmProfitCalculation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(692, 416);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gpbOtherDetail);
            this.Controls.Add(this.gpbCalculate);
            this.Controls.Add(this.gpbQuotationDetail);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmProfitCalculation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FrmProfitCalculation_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gpbOtherDetail.ResumeLayout(false);
            this.gpbOtherDetail.PerformLayout();
            this.gpbCalculate.ResumeLayout(false);
            this.gpbCalculate.PerformLayout();
            this.gpbQuotationDetail.ResumeLayout(false);
            this.gpbQuotationDetail.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FarPoint.Win.Input.FpDouble fpdInterestRate;
        private FarPoint.Win.Input.FpDouble fpdInsurancePremium;
        private FarPoint.Win.Input.FpDouble fpdCapitalInsurance;
        private FarPoint.Win.Input.FpDouble fpdDepreciation;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label2;
        private FarPoint.Win.Input.FpDouble fpdRegister;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label6;
        private FarPoint.Win.Input.FpDouble fpdMaintenance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label label43;
        private FarPoint.Win.Input.FpDouble fpdMonthlyRound;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gpbOtherDetail;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox gpbCalculate;
        private System.Windows.Forms.GroupBox gpbQuotationDetail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbModel;
        private System.Windows.Forms.ComboBox cmbBrand;
        private FarPoint.Win.Input.FpDouble fpdBodyPrice;
        private System.Windows.Forms.Label label7;
        private FarPoint.Win.Input.FpDouble fpdPercentResidual;
        private System.Windows.Forms.Label label30;
        private FarPoint.Win.Input.FpDouble fpdPercentRateOfReturn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label23;
        private FarPoint.Win.Input.FpInteger fpiLeaseTerm;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        protected internal System.Windows.Forms.TextBox txtQuotationNoXXX;
        protected internal System.Windows.Forms.TextBox txtQuotationNoMM;
        protected internal System.Windows.Forms.TextBox txtQuotationNoYY;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Button button1;
        private FarPoint.Win.Input.FpDouble txtMonthlyCharge;
    }
}
