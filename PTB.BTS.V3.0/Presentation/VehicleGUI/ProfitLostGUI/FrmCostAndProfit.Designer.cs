namespace Presentation.VehicleGUI.ProfitLostGUI
{
    partial class FrmCostAndProfit
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
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuotationNoXXX = new System.Windows.Forms.TextBox();
            this.txtQuotationNoMM = new System.Windows.Forms.TextBox();
            this.txtQuotationNoYY = new System.Windows.Forms.TextBox();
            this.gpbQuotationDetail = new System.Windows.Forms.GroupBox();
            this.fpdDepreciation = new FarPoint.Win.Input.FpDouble();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.fpdInterestRate = new FarPoint.Win.Input.FpDouble();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fpdPercentRateOfReturn = new FarPoint.Win.Input.FpDouble();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.fpiLeaseTerm = new FarPoint.Win.Input.FpInteger();
            this.label23 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.fpdPercentResidual = new FarPoint.Win.Input.FpDouble();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.fpdBodyPrice = new FarPoint.Win.Input.FpDouble();
            this.label31 = new System.Windows.Forms.Label();
            this.gpbOtherDetail = new System.Windows.Forms.GroupBox();
            this.fpdMaintenance = new FarPoint.Win.Input.FpDouble();
            this.fpdRegister = new FarPoint.Win.Input.FpDouble();
            this.fpdInsurancePremium = new FarPoint.Win.Input.FpDouble();
            this.fpdCapitalInsurance = new FarPoint.Win.Input.FpDouble();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.fpdMonthlyRound = new FarPoint.Win.Input.FpDouble();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.label43 = new System.Windows.Forms.Label();
            this.gpbCalculate = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gpbQuotationDetail.SuspendLayout();
            this.gpbOtherDetail.SuspendLayout();
            this.gpbCalculate.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPrint.Location = new System.Drawing.Point(207, 302);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "พิมพ์";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClose.Location = new System.Drawing.Point(295, 302);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "ปิด";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label13.Location = new System.Drawing.Point(288, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 16);
            this.label13.TabIndex = 23;
            this.label13.Text = "PTB  - Q -";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(208, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Quotation No.";
            // 
            // txtQuotationNoXXX
            // 
            this.txtQuotationNoXXX.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtQuotationNoXXX.Location = new System.Drawing.Point(417, 21);
            this.txtQuotationNoXXX.MaxLength = 3;
            this.txtQuotationNoXXX.Name = "txtQuotationNoXXX";
            this.txtQuotationNoXXX.Size = new System.Drawing.Size(32, 20);
            this.txtQuotationNoXXX.TabIndex = 26;
            this.txtQuotationNoXXX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtQuotationNoXXX.DoubleClick += new System.EventHandler(this.txtQuotationNoXXX_DoubleClick);
            this.txtQuotationNoXXX.TextChanged += new System.EventHandler(this.txtQuotationNoXXX_TextChanged);
            this.txtQuotationNoXXX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuotationNoXXX_KeyDown);
            // 
            // txtQuotationNoMM
            // 
            this.txtQuotationNoMM.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtQuotationNoMM.Location = new System.Drawing.Point(385, 21);
            this.txtQuotationNoMM.MaxLength = 2;
            this.txtQuotationNoMM.Name = "txtQuotationNoMM";
            this.txtQuotationNoMM.Size = new System.Drawing.Size(32, 20);
            this.txtQuotationNoMM.TabIndex = 25;
            this.txtQuotationNoMM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtQuotationNoMM.TextChanged += new System.EventHandler(this.txtQuotationNoMM_TextChanged);
            // 
            // txtQuotationNoYY
            // 
            this.txtQuotationNoYY.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtQuotationNoYY.Location = new System.Drawing.Point(353, 21);
            this.txtQuotationNoYY.MaxLength = 2;
            this.txtQuotationNoYY.Name = "txtQuotationNoYY";
            this.txtQuotationNoYY.Size = new System.Drawing.Size(32, 20);
            this.txtQuotationNoYY.TabIndex = 24;
            this.txtQuotationNoYY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtQuotationNoYY.TextChanged += new System.EventHandler(this.txtQuotationNoYY_TextChanged);
            // 
            // gpbQuotationDetail
            // 
            this.gpbQuotationDetail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpbQuotationDetail.Controls.Add(this.fpdDepreciation);
            this.gpbQuotationDetail.Controls.Add(this.label5);
            this.gpbQuotationDetail.Controls.Add(this.label6);
            this.gpbQuotationDetail.Controls.Add(this.fpdInterestRate);
            this.gpbQuotationDetail.Controls.Add(this.label2);
            this.gpbQuotationDetail.Controls.Add(this.label3);
            this.gpbQuotationDetail.Controls.Add(this.fpdPercentRateOfReturn);
            this.gpbQuotationDetail.Controls.Add(this.label29);
            this.gpbQuotationDetail.Controls.Add(this.label30);
            this.gpbQuotationDetail.Controls.Add(this.fpiLeaseTerm);
            this.gpbQuotationDetail.Controls.Add(this.label23);
            this.gpbQuotationDetail.Controls.Add(this.label4);
            this.gpbQuotationDetail.Controls.Add(this.fpdPercentResidual);
            this.gpbQuotationDetail.Controls.Add(this.label24);
            this.gpbQuotationDetail.Controls.Add(this.label25);
            this.gpbQuotationDetail.Controls.Add(this.fpdBodyPrice);
            this.gpbQuotationDetail.Controls.Add(this.label31);
            this.gpbQuotationDetail.Location = new System.Drawing.Point(14, 64);
            this.gpbQuotationDetail.Name = "gpbQuotationDetail";
            this.gpbQuotationDetail.Size = new System.Drawing.Size(240, 224);
            this.gpbQuotationDetail.TabIndex = 27;
            this.gpbQuotationDetail.TabStop = false;
            this.gpbQuotationDetail.Text = "Quotation Detail";
            // 
            // fpdDepreciation
            // 
            this.fpdDepreciation.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdDepreciation.AllowClipboardKeys = true;
            this.fpdDepreciation.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdDepreciation.DecimalPlaces = 2;
            this.fpdDepreciation.DecimalSeparator = ".";
            this.fpdDepreciation.Location = new System.Drawing.Point(116, 189);
            this.fpdDepreciation.Name = "fpdDepreciation";
            this.fpdDepreciation.Size = new System.Drawing.Size(48, 20);
            this.fpdDepreciation.TabIndex = 55;
            this.fpdDepreciation.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(164, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "%";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 53;
            this.label6.Text = "Depreciation Rate";
            // 
            // fpdInterestRate
            // 
            this.fpdInterestRate.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdInterestRate.AllowClipboardKeys = true;
            this.fpdInterestRate.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdInterestRate.DecimalPlaces = 2;
            this.fpdInterestRate.DecimalSeparator = ".";
            this.fpdInterestRate.Location = new System.Drawing.Point(116, 156);
            this.fpdInterestRate.Name = "fpdInterestRate";
            this.fpdInterestRate.Size = new System.Drawing.Size(48, 20);
            this.fpdInterestRate.TabIndex = 52;
            this.fpdInterestRate.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 51;
            this.label2.Text = "%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "Interest Rate";
            // 
            // fpdPercentRateOfReturn
            // 
            this.fpdPercentRateOfReturn.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdPercentRateOfReturn.AllowClipboardKeys = true;
            this.fpdPercentRateOfReturn.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdPercentRateOfReturn.DecimalPlaces = 2;
            this.fpdPercentRateOfReturn.DecimalSeparator = ".";
            this.fpdPercentRateOfReturn.Location = new System.Drawing.Point(116, 123);
            this.fpdPercentRateOfReturn.Name = "fpdPercentRateOfReturn";
            this.fpdPercentRateOfReturn.Size = new System.Drawing.Size(48, 20);
            this.fpdPercentRateOfReturn.TabIndex = 49;
            this.fpdPercentRateOfReturn.Text = "";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(164, 127);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(15, 13);
            this.label29.TabIndex = 48;
            this.label29.Text = "%";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(36, 127);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(77, 13);
            this.label30.TabIndex = 47;
            this.label30.Text = "Rate of Return";
            // 
            // fpiLeaseTerm
            // 
            this.fpiLeaseTerm.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiLeaseTerm.AllowClipboardKeys = true;
            this.fpiLeaseTerm.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiLeaseTerm.Location = new System.Drawing.Point(116, 90);
            this.fpiLeaseTerm.MaxValue = 250;
            this.fpiLeaseTerm.MinValue = 0;
            this.fpiLeaseTerm.Name = "fpiLeaseTerm";
            this.fpiLeaseTerm.Size = new System.Drawing.Size(48, 20);
            this.fpiLeaseTerm.TabIndex = 46;
            this.fpiLeaseTerm.Text = "";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(164, 94);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(33, 13);
            this.label23.TabIndex = 45;
            this.label23.Text = "เดือน";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "ระยะเวลาเช่า";
            // 
            // fpdPercentResidual
            // 
            this.fpdPercentResidual.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdPercentResidual.AllowClipboardKeys = true;
            this.fpdPercentResidual.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdPercentResidual.DecimalPlaces = 2;
            this.fpdPercentResidual.DecimalSeparator = ".";
            this.fpdPercentResidual.Location = new System.Drawing.Point(116, 57);
            this.fpdPercentResidual.Name = "fpdPercentResidual";
            this.fpdPercentResidual.Size = new System.Drawing.Size(48, 20);
            this.fpdPercentResidual.TabIndex = 43;
            this.fpdPercentResidual.Text = "";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(164, 61);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(15, 13);
            this.label24.TabIndex = 42;
            this.label24.Text = "%";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(35, 61);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(78, 13);
            this.label25.TabIndex = 41;
            this.label25.Text = "Residual Value";
            // 
            // fpdBodyPrice
            // 
            this.fpdBodyPrice.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdBodyPrice.AllowClipboardKeys = true;
            this.fpdBodyPrice.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdBodyPrice.DecimalPlaces = 2;
            this.fpdBodyPrice.DecimalSeparator = ".";
            this.fpdBodyPrice.Location = new System.Drawing.Point(116, 24);
            this.fpdBodyPrice.Name = "fpdBodyPrice";
            this.fpdBodyPrice.NumberGroupSeparator = ",";
            this.fpdBodyPrice.NumberGroupSize = 3;
            this.fpdBodyPrice.Size = new System.Drawing.Size(104, 20);
            this.fpdBodyPrice.TabIndex = 40;
            this.fpdBodyPrice.Text = "";
            this.fpdBodyPrice.UseSeparator = true;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(70, 28);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(43, 13);
            this.label31.TabIndex = 38;
            this.label31.Text = "ราคารถ";
            // 
            // gpbOtherDetail
            // 
            this.gpbOtherDetail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpbOtherDetail.Controls.Add(this.fpdMaintenance);
            this.gpbOtherDetail.Controls.Add(this.fpdRegister);
            this.gpbOtherDetail.Controls.Add(this.fpdInsurancePremium);
            this.gpbOtherDetail.Controls.Add(this.fpdCapitalInsurance);
            this.gpbOtherDetail.Controls.Add(this.label41);
            this.gpbOtherDetail.Controls.Add(this.label40);
            this.gpbOtherDetail.Controls.Add(this.label39);
            this.gpbOtherDetail.Controls.Add(this.label38);
            this.gpbOtherDetail.Controls.Add(this.label37);
            this.gpbOtherDetail.Location = new System.Drawing.Point(258, 64);
            this.gpbOtherDetail.Name = "gpbOtherDetail";
            this.gpbOtherDetail.Size = new System.Drawing.Size(304, 160);
            this.gpbOtherDetail.TabIndex = 28;
            this.gpbOtherDetail.TabStop = false;
            this.gpbOtherDetail.Text = "Other Detail";
            // 
            // fpdMaintenance
            // 
            this.fpdMaintenance.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdMaintenance.AllowClipboardKeys = true;
            this.fpdMaintenance.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdMaintenance.DecimalPlaces = 2;
            this.fpdMaintenance.DecimalSeparator = ".";
            this.fpdMaintenance.Location = new System.Drawing.Point(137, 124);
            this.fpdMaintenance.Name = "fpdMaintenance";
            this.fpdMaintenance.NumberGroupSeparator = ",";
            this.fpdMaintenance.NumberGroupSize = 3;
            this.fpdMaintenance.Size = new System.Drawing.Size(104, 20);
            this.fpdMaintenance.TabIndex = 57;
            this.fpdMaintenance.Text = "";
            this.fpdMaintenance.UseSeparator = true;
            // 
            // fpdRegister
            // 
            this.fpdRegister.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdRegister.AllowClipboardKeys = true;
            this.fpdRegister.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdRegister.DecimalPlaces = 2;
            this.fpdRegister.DecimalSeparator = ".";
            this.fpdRegister.Location = new System.Drawing.Point(137, 92);
            this.fpdRegister.Name = "fpdRegister";
            this.fpdRegister.NumberGroupSeparator = ",";
            this.fpdRegister.NumberGroupSize = 3;
            this.fpdRegister.Size = new System.Drawing.Size(104, 20);
            this.fpdRegister.TabIndex = 56;
            this.fpdRegister.Text = "";
            this.fpdRegister.UseSeparator = true;
            // 
            // fpdInsurancePremium
            // 
            this.fpdInsurancePremium.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdInsurancePremium.AllowClipboardKeys = true;
            this.fpdInsurancePremium.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdInsurancePremium.DecimalPlaces = 2;
            this.fpdInsurancePremium.DecimalSeparator = ".";
            this.fpdInsurancePremium.Location = new System.Drawing.Point(137, 60);
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
            this.fpdCapitalInsurance.Location = new System.Drawing.Point(137, 28);
            this.fpdCapitalInsurance.Name = "fpdCapitalInsurance";
            this.fpdCapitalInsurance.NumberGroupSeparator = ",";
            this.fpdCapitalInsurance.NumberGroupSize = 3;
            this.fpdCapitalInsurance.Size = new System.Drawing.Size(104, 20);
            this.fpdCapitalInsurance.TabIndex = 54;
            this.fpdCapitalInsurance.Text = "";
            this.fpdCapitalInsurance.UseSeparator = true;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(249, 128);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(46, 13);
            this.label41.TabIndex = 50;
            this.label41.Text = "ต่อเดือน";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(10, 128);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(119, 13);
            this.label40.TabIndex = 49;
            this.label40.Text = "Maintenance Spare Car";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(41, 96);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(88, 13);
            this.label39.TabIndex = 48;
            this.label39.Text = "Tax and Register";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(32, 64);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(97, 13);
            this.label38.TabIndex = 47;
            this.label38.Text = "Insurance Premium";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(40, 32);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(89, 13);
            this.label37.TabIndex = 46;
            this.label37.Text = "Capital Insurance";
            // 
            // fpdMonthlyRound
            // 
            this.fpdMonthlyRound.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdMonthlyRound.AllowClipboardKeys = true;
            this.fpdMonthlyRound.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdMonthlyRound.DecimalPlaces = 2;
            this.fpdMonthlyRound.DecimalSeparator = ".";
            this.fpdMonthlyRound.Location = new System.Drawing.Point(87, 24);
            this.fpdMonthlyRound.Name = "fpdMonthlyRound";
            this.fpdMonthlyRound.NumberGroupSeparator = ",";
            this.fpdMonthlyRound.NumberGroupSize = 3;
            this.fpdMonthlyRound.Size = new System.Drawing.Size(104, 20);
            this.fpdMonthlyRound.TabIndex = 59;
            this.fpdMonthlyRound.Text = "";
            this.fpdMonthlyRound.UseSeparator = true;
            // 
            // btnCalculate
            // 
            this.btnCalculate.ForeColor = System.Drawing.Color.Blue;
            this.btnCalculate.Location = new System.Drawing.Point(200, 23);
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
            this.label43.Location = new System.Drawing.Point(40, 28);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(36, 13);
            this.label43.TabIndex = 52;
            this.label43.Text = "ค่าเช่า";
            // 
            // gpbCalculate
            // 
            this.gpbCalculate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpbCalculate.Controls.Add(this.fpdMonthlyRound);
            this.gpbCalculate.Controls.Add(this.label43);
            this.gpbCalculate.Controls.Add(this.btnCalculate);
            this.gpbCalculate.Location = new System.Drawing.Point(258, 224);
            this.gpbCalculate.Name = "gpbCalculate";
            this.gpbCalculate.Size = new System.Drawing.Size(304, 64);
            this.gpbCalculate.TabIndex = 29;
            this.gpbCalculate.TabStop = false;
            this.gpbCalculate.Text = "คำนวณค่าเช่า";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Quotation ตั้งแต่ปี";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(116, 21);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(56, 20);
            this.dtpFromDate.TabIndex = 31;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.txtQuotationNoYY);
            this.groupBox1.Controls.Add(this.txtQuotationNoMM);
            this.groupBox1.Controls.Add(this.txtQuotationNoXXX);
            this.groupBox1.Location = new System.Drawing.Point(14, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(548, 56);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quotation";
            // 
            // FrmCostAndProfit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 342);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gpbCalculate);
            this.Controls.Add(this.gpbOtherDetail);
            this.Controls.Add(this.gpbQuotationDetail);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmCostAndProfit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FrmCostAndProfit_Load);
            this.gpbQuotationDetail.ResumeLayout(false);
            this.gpbQuotationDetail.PerformLayout();
            this.gpbOtherDetail.ResumeLayout(false);
            this.gpbOtherDetail.PerformLayout();
            this.gpbCalculate.ResumeLayout(false);
            this.gpbCalculate.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        protected internal System.Windows.Forms.TextBox txtQuotationNoXXX;
        protected internal System.Windows.Forms.TextBox txtQuotationNoMM;
        protected internal System.Windows.Forms.TextBox txtQuotationNoYY;
        private System.Windows.Forms.GroupBox gpbQuotationDetail;
        private System.Windows.Forms.GroupBox gpbOtherDetail;
        private FarPoint.Win.Input.FpDouble fpdMaintenance;
        private FarPoint.Win.Input.FpDouble fpdRegister;
        private FarPoint.Win.Input.FpDouble fpdInsurancePremium;
        private FarPoint.Win.Input.FpDouble fpdCapitalInsurance;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label37;
        private FarPoint.Win.Input.FpDouble fpdMonthlyRound;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.GroupBox gpbCalculate;
        private FarPoint.Win.Input.FpDouble fpdBodyPrice;
        private System.Windows.Forms.Label label31;
        private FarPoint.Win.Input.FpDouble fpdPercentResidual;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private FarPoint.Win.Input.FpInteger fpiLeaseTerm;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label4;
        private FarPoint.Win.Input.FpDouble fpdDepreciation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private FarPoint.Win.Input.FpDouble fpdInterestRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private FarPoint.Win.Input.FpDouble fpdPercentRateOfReturn;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}