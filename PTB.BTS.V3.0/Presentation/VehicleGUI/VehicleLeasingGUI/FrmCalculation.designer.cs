namespace BTS_Prototype
{
    partial class FrmCalculation
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
            this.label30 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQuotationNo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.gpbQuotationDetail = new System.Windows.Forms.GroupBox();
            this.fpdModifyPrice = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.fpdBodyPrice = new System.Windows.Forms.TextBox();
            this.fpdPercentRateOfReturn = new System.Windows.Forms.TextBox();
            this.fpiLeaseTerm = new System.Windows.Forms.TextBox();
            this.fpdPercentResidual = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.gpbCalculate = new System.Windows.Forms.GroupBox();
            this.fpdRound = new System.Windows.Forms.TextBox();
            this.fpdMonthlyCharge = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.label43 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.gpbOtherDetail = new System.Windows.Forms.GroupBox();
            this.fpdMaintenance = new System.Windows.Forms.TextBox();
            this.fpdRegister = new System.Windows.Forms.TextBox();
            this.fpdInsurancePremium = new System.Windows.Forms.TextBox();
            this.fpdCapitalInsurance = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fpdDepreciation = new System.Windows.Forms.TextBox();
            this.fpdInterestRate = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbColor = new System.Windows.Forms.ComboBox();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbModel = new System.Windows.Forms.ComboBox();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gpbQuotationDetail.SuspendLayout();
            this.gpbCalculate.SuspendLayout();
            this.gpbOtherDetail.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(3, 130);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(77, 13);
            this.label30.TabIndex = 47;
            this.label30.Text = "Rate of Return";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "Lease Term";
            // 
            // txtQuotationNo
            // 
            this.txtQuotationNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtQuotationNo.Enabled = false;
            this.txtQuotationNo.Location = new System.Drawing.Point(141, 14);
            this.txtQuotationNo.MaxLength = 2;
            this.txtQuotationNo.Name = "txtQuotationNo";
            this.txtQuotationNo.Size = new System.Drawing.Size(47, 20);
            this.txtQuotationNo.TabIndex = 23;
            this.txtQuotationNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtQuotationNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(680, 44);
            this.groupBox1.TabIndex = 69;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quotation";
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
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(152, 104);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(36, 13);
            this.label23.TabIndex = 45;
            this.label23.Text = "month";
            // 
            // gpbQuotationDetail
            // 
            this.gpbQuotationDetail.Controls.Add(this.fpdModifyPrice);
            this.gpbQuotationDetail.Controls.Add(this.label12);
            this.gpbQuotationDetail.Controls.Add(this.fpdBodyPrice);
            this.gpbQuotationDetail.Controls.Add(this.fpdPercentRateOfReturn);
            this.gpbQuotationDetail.Controls.Add(this.fpiLeaseTerm);
            this.gpbQuotationDetail.Controls.Add(this.fpdPercentResidual);
            this.gpbQuotationDetail.Controls.Add(this.label30);
            this.gpbQuotationDetail.Controls.Add(this.label4);
            this.gpbQuotationDetail.Controls.Add(this.label23);
            this.gpbQuotationDetail.Controls.Add(this.label29);
            this.gpbQuotationDetail.Controls.Add(this.label25);
            this.gpbQuotationDetail.Controls.Add(this.label24);
            this.gpbQuotationDetail.Controls.Add(this.label31);
            this.gpbQuotationDetail.Location = new System.Drawing.Point(7, 203);
            this.gpbQuotationDetail.Name = "gpbQuotationDetail";
            this.gpbQuotationDetail.Size = new System.Drawing.Size(324, 156);
            this.gpbQuotationDetail.TabIndex = 70;
            this.gpbQuotationDetail.TabStop = false;
            this.gpbQuotationDetail.Text = "Leasing Detail";
            // 
            // fpdModifyPrice
            // 
            this.fpdModifyPrice.Location = new System.Drawing.Point(98, 49);
            this.fpdModifyPrice.Name = "fpdModifyPrice";
            this.fpdModifyPrice.Size = new System.Drawing.Size(104, 20);
            this.fpdModifyPrice.TabIndex = 66;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 65;
            this.label12.Text = "Modify Price";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // fpdBodyPrice
            // 
            this.fpdBodyPrice.Location = new System.Drawing.Point(98, 23);
            this.fpdBodyPrice.Name = "fpdBodyPrice";
            this.fpdBodyPrice.Size = new System.Drawing.Size(104, 20);
            this.fpdBodyPrice.TabIndex = 61;
            // 
            // fpdPercentRateOfReturn
            // 
            this.fpdPercentRateOfReturn.Location = new System.Drawing.Point(98, 130);
            this.fpdPercentRateOfReturn.MaxLength = 5;
            this.fpdPercentRateOfReturn.Name = "fpdPercentRateOfReturn";
            this.fpdPercentRateOfReturn.Size = new System.Drawing.Size(48, 20);
            this.fpdPercentRateOfReturn.TabIndex = 64;
            // 
            // fpiLeaseTerm
            // 
            this.fpiLeaseTerm.Location = new System.Drawing.Point(98, 104);
            this.fpiLeaseTerm.MaxLength = 3;
            this.fpiLeaseTerm.Name = "fpiLeaseTerm";
            this.fpiLeaseTerm.Size = new System.Drawing.Size(48, 20);
            this.fpiLeaseTerm.TabIndex = 63;
            // 
            // fpdPercentResidual
            // 
            this.fpdPercentResidual.Location = new System.Drawing.Point(98, 75);
            this.fpdPercentResidual.MaxLength = 5;
            this.fpdPercentResidual.Name = "fpdPercentResidual";
            this.fpdPercentResidual.Size = new System.Drawing.Size(48, 20);
            this.fpdPercentResidual.TabIndex = 62;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(152, 130);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(15, 13);
            this.label29.TabIndex = 48;
            this.label29.Text = "%";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(4, 78);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(78, 13);
            this.label25.TabIndex = 41;
            this.label25.Text = "Residual Value";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(152, 78);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(15, 13);
            this.label24.TabIndex = 42;
            this.label24.Text = "%";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(25, 26);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(58, 13);
            this.label31.TabIndex = 38;
            this.label31.Text = "Body Price";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(337, 378);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 75;
            this.btnClose.Text = "ปิด";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 53;
            this.label6.Text = "Depreciation";
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
            // gpbCalculate
            // 
            this.gpbCalculate.Controls.Add(this.fpdRound);
            this.gpbCalculate.Controls.Add(this.fpdMonthlyCharge);
            this.gpbCalculate.Controls.Add(this.label10);
            this.gpbCalculate.Controls.Add(this.btnCalculate);
            this.gpbCalculate.Controls.Add(this.label43);
            this.gpbCalculate.Location = new System.Drawing.Point(337, 281);
            this.gpbCalculate.Name = "gpbCalculate";
            this.gpbCalculate.Size = new System.Drawing.Size(349, 79);
            this.gpbCalculate.TabIndex = 72;
            this.gpbCalculate.TabStop = false;
            this.gpbCalculate.Text = "Calculation of leasing";
            // 
            // fpdRound
            // 
            this.fpdRound.Location = new System.Drawing.Point(154, 48);
            this.fpdRound.Name = "fpdRound";
            this.fpdRound.Size = new System.Drawing.Size(104, 20);
            this.fpdRound.TabIndex = 64;
            // 
            // fpdMonthlyCharge
            // 
            this.fpdMonthlyCharge.Enabled = false;
            this.fpdMonthlyCharge.Location = new System.Drawing.Point(154, 20);
            this.fpdMonthlyCharge.Name = "fpdMonthlyCharge";
            this.fpdMonthlyCharge.Size = new System.Drawing.Size(104, 20);
            this.fpdMonthlyCharge.TabIndex = 63;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(64, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 61;
            this.label10.Text = "Rounded to";
            // 
            // btnCalculate
            // 
            this.btnCalculate.ForeColor = System.Drawing.Color.Blue;
            this.btnCalculate.Location = new System.Drawing.Point(264, 46);
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
            this.label43.Location = new System.Drawing.Point(46, 23);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(81, 13);
            this.label43.TabIndex = 52;
            this.label43.Text = "Monthly Charge";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 51;
            this.label2.Text = "%";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "Interest Rate";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(38, 22);
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
            this.gpbOtherDetail.Location = new System.Drawing.Point(337, 64);
            this.gpbOtherDetail.Name = "gpbOtherDetail";
            this.gpbOtherDetail.Size = new System.Drawing.Size(349, 133);
            this.gpbOtherDetail.TabIndex = 71;
            this.gpbOtherDetail.TabStop = false;
            this.gpbOtherDetail.Text = "Vehicle Cost";
            // 
            // fpdMaintenance
            // 
            this.fpdMaintenance.Location = new System.Drawing.Point(154, 99);
            this.fpdMaintenance.Name = "fpdMaintenance";
            this.fpdMaintenance.Size = new System.Drawing.Size(104, 20);
            this.fpdMaintenance.TabIndex = 66;
            // 
            // fpdRegister
            // 
            this.fpdRegister.Location = new System.Drawing.Point(154, 72);
            this.fpdRegister.Name = "fpdRegister";
            this.fpdRegister.Size = new System.Drawing.Size(104, 20);
            this.fpdRegister.TabIndex = 65;
            // 
            // fpdInsurancePremium
            // 
            this.fpdInsurancePremium.Location = new System.Drawing.Point(154, 44);
            this.fpdInsurancePremium.Name = "fpdInsurancePremium";
            this.fpdInsurancePremium.Size = new System.Drawing.Size(104, 20);
            this.fpdInsurancePremium.TabIndex = 64;
            // 
            // fpdCapitalInsurance
            // 
            this.fpdCapitalInsurance.Location = new System.Drawing.Point(154, 18);
            this.fpdCapitalInsurance.Name = "fpdCapitalInsurance";
            this.fpdCapitalInsurance.Size = new System.Drawing.Size(104, 20);
            this.fpdCapitalInsurance.TabIndex = 63;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(39, 75);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(88, 13);
            this.label39.TabIndex = 48;
            this.label39.Text = "Tax and Register";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(216, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "%";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.fpdDepreciation);
            this.groupBox2.Controls.Add(this.fpdInterestRate);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(337, 203);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(349, 72);
            this.groupBox2.TabIndex = 73;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Interest and Depreciation";
            // 
            // fpdDepreciation
            // 
            this.fpdDepreciation.Location = new System.Drawing.Point(154, 49);
            this.fpdDepreciation.MaxLength = 5;
            this.fpdDepreciation.Name = "fpdDepreciation";
            this.fpdDepreciation.Size = new System.Drawing.Size(48, 20);
            this.fpdDepreciation.TabIndex = 64;
            // 
            // fpdInterestRate
            // 
            this.fpdInterestRate.Location = new System.Drawing.Point(154, 20);
            this.fpdInterestRate.MaxLength = 5;
            this.fpdInterestRate.Name = "fpdInterestRate";
            this.fpdInterestRate.Size = new System.Drawing.Size(48, 20);
            this.fpdInterestRate.TabIndex = 63;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.cmbColor);
            this.groupBox3.Controls.Add(this.cmbCustomer);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.cmbModel);
            this.groupBox3.Controls.Add(this.cmbBrand);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(7, 64);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(324, 133);
            this.groupBox3.TabIndex = 76;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Detail of Vehicle";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(48, 107);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 68;
            this.label11.Text = "Color";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // cmbColor
            // 
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.Location = new System.Drawing.Point(98, 104);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(123, 21);
            this.cmbColor.TabIndex = 67;
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(98, 19);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(121, 21);
            this.cmbCustomer.TabIndex = 66;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(46, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 65;
            this.label9.Text = "Model";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(48, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 64;
            this.label8.Text = "Brand";
            // 
            // cmbModel
            // 
            this.cmbModel.FormattingEnabled = true;
            this.cmbModel.Location = new System.Drawing.Point(98, 76);
            this.cmbModel.Name = "cmbModel";
            this.cmbModel.Size = new System.Drawing.Size(123, 21);
            this.cmbModel.TabIndex = 63;
            // 
            // cmbBrand
            // 
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(98, 47);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(123, 21);
            this.cmbBrand.TabIndex = 62;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 61;
            this.label7.Text = "Customer";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(256, 378);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 77;
            this.btnSave.Text = "บันทึก";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // FrmCalculation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 423);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gpbQuotationDetail);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gpbCalculate);
            this.Controls.Add(this.gpbOtherDetail);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmCalculation";
            this.Text = "Leasing Calculation";
            this.Load += new System.EventHandler(this.FrmCalculation_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpbQuotationDetail.ResumeLayout(false);
            this.gpbQuotationDetail.PerformLayout();
            this.gpbCalculate.ResumeLayout(false);
            this.gpbCalculate.PerformLayout();
            this.gpbOtherDetail.ResumeLayout(false);
            this.gpbOtherDetail.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label4;
        protected internal System.Windows.Forms.TextBox txtQuotationNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.GroupBox gpbQuotationDetail;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.GroupBox gpbCalculate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.GroupBox gpbOtherDetail;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox fpdBodyPrice;
        private System.Windows.Forms.TextBox fpdPercentRateOfReturn;
        private System.Windows.Forms.TextBox fpiLeaseTerm;
        private System.Windows.Forms.TextBox fpdPercentResidual;
        private System.Windows.Forms.TextBox fpdMaintenance;
        private System.Windows.Forms.TextBox fpdRegister;
        private System.Windows.Forms.TextBox fpdInsurancePremium;
        private System.Windows.Forms.TextBox fpdCapitalInsurance;
        private System.Windows.Forms.TextBox fpdDepreciation;
        private System.Windows.Forms.TextBox fpdInterestRate;
        private System.Windows.Forms.TextBox fpdRound;
        private System.Windows.Forms.TextBox fpdMonthlyCharge;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbColor;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbModel;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox fpdModifyPrice;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnSave;
    }
}