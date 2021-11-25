namespace Presentation.VehicleGUI.ProfitLostGUI
{
    partial class FrmProfitLostEntry
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
            this.gpbVehicleDetail = new System.Windows.Forms.GroupBox();
            this.lblModel = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPlateNo = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblPlatePrefix = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPlatePrefix = new System.Windows.Forms.TextBox();
            this.fpiPlateRunningNo = new FarPoint.Win.Input.FpInteger();
            this.gpbPLDetail = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.fpdRate = new FarPoint.Win.Input.FpDouble();
            this.fpdPmt = new FarPoint.Win.Input.FpDouble();
            this.fpdFV = new FarPoint.Win.Input.FpDouble();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.fpdRentalPrice = new FarPoint.Win.Input.FpDouble();
            this.fpdSellPrice = new FarPoint.Win.Input.FpDouble();
            this.fpdBodyPrice = new FarPoint.Win.Input.FpDouble();
            this.fpiRemain = new FarPoint.Win.Input.FpInteger();
            this.label13 = new System.Windows.Forms.Label();
            this.fpiRentalAge = new FarPoint.Win.Input.FpInteger();
            this.label12 = new System.Windows.Forms.Label();
            this.fpiLeaseTerm = new FarPoint.Win.Input.FpInteger();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.gpbVehicleDetail.SuspendLayout();
            this.gpbPLDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbVehicleDetail
            // 
            this.gpbVehicleDetail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpbVehicleDetail.Controls.Add(this.lblModel);
            this.gpbVehicleDetail.Controls.Add(this.lblBrand);
            this.gpbVehicleDetail.Controls.Add(this.label6);
            this.gpbVehicleDetail.Controls.Add(this.label5);
            this.gpbVehicleDetail.Controls.Add(this.label4);
            this.gpbVehicleDetail.Controls.Add(this.lblPlateNo);
            this.gpbVehicleDetail.Controls.Add(this.label23);
            this.gpbVehicleDetail.Controls.Add(this.lblPlatePrefix);
            this.gpbVehicleDetail.Controls.Add(this.label7);
            this.gpbVehicleDetail.Controls.Add(this.txtPlatePrefix);
            this.gpbVehicleDetail.Controls.Add(this.fpiPlateRunningNo);
            this.gpbVehicleDetail.Location = new System.Drawing.Point(9, 0);
            this.gpbVehicleDetail.Name = "gpbVehicleDetail";
            this.gpbVehicleDetail.Size = new System.Drawing.Size(361, 120);
            this.gpbVehicleDetail.TabIndex = 0;
            this.gpbVehicleDetail.TabStop = false;
            this.gpbVehicleDetail.Text = "ข้อมูลรถ";
            // 
            // lblModel
            // 
            this.lblModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblModel.Location = new System.Drawing.Point(95, 84);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(248, 21);
            this.lblModel.TabIndex = 172;
            this.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBrand
            // 
            this.lblBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblBrand.Location = new System.Drawing.Point(95, 55);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(112, 21);
            this.lblBrand.TabIndex = 171;
            this.lblBrand.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(64, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 170;
            this.label6.Text = "รุ่น";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 168;
            this.label5.Text = "ยี่ห้อ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(135, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 25);
            this.label4.TabIndex = 167;
            this.label4.Text = "-";
            // 
            // lblPlateNo
            // 
            this.lblPlateNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPlateNo.Location = new System.Drawing.Point(271, 24);
            this.lblPlateNo.Name = "lblPlateNo";
            this.lblPlateNo.Size = new System.Drawing.Size(72, 24);
            this.lblPlateNo.TabIndex = 166;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label23.Location = new System.Drawing.Point(255, 24);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(19, 25);
            this.label23.TabIndex = 165;
            this.label23.Text = "-";
            // 
            // lblPlatePrefix
            // 
            this.lblPlatePrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPlatePrefix.Location = new System.Drawing.Point(215, 24);
            this.lblPlatePrefix.Name = "lblPlatePrefix";
            this.lblPlatePrefix.Size = new System.Drawing.Size(40, 24);
            this.lblPlatePrefix.TabIndex = 164;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(26, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 163;
            this.label7.Text = "ทะเบียนรถ";
            // 
            // txtPlatePrefix
            // 
            this.txtPlatePrefix.Location = new System.Drawing.Point(95, 26);
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
            this.fpiPlateRunningNo.Location = new System.Drawing.Point(151, 26);
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
            // gpbPLDetail
            // 
            this.gpbPLDetail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpbPLDetail.Controls.Add(this.label20);
            this.gpbPLDetail.Controls.Add(this.label21);
            this.gpbPLDetail.Controls.Add(this.label22);
            this.gpbPLDetail.Controls.Add(this.fpdRate);
            this.gpbPLDetail.Controls.Add(this.fpdPmt);
            this.gpbPLDetail.Controls.Add(this.fpdFV);
            this.gpbPLDetail.Controls.Add(this.label16);
            this.gpbPLDetail.Controls.Add(this.label15);
            this.gpbPLDetail.Controls.Add(this.label14);
            this.gpbPLDetail.Controls.Add(this.fpdRentalPrice);
            this.gpbPLDetail.Controls.Add(this.fpdSellPrice);
            this.gpbPLDetail.Controls.Add(this.fpdBodyPrice);
            this.gpbPLDetail.Controls.Add(this.fpiRemain);
            this.gpbPLDetail.Controls.Add(this.label13);
            this.gpbPLDetail.Controls.Add(this.fpiRentalAge);
            this.gpbPLDetail.Controls.Add(this.label12);
            this.gpbPLDetail.Controls.Add(this.fpiLeaseTerm);
            this.gpbPLDetail.Controls.Add(this.label11);
            this.gpbPLDetail.Controls.Add(this.label10);
            this.gpbPLDetail.Controls.Add(this.label9);
            this.gpbPLDetail.Controls.Add(this.label8);
            this.gpbPLDetail.Controls.Add(this.label3);
            this.gpbPLDetail.Controls.Add(this.label2);
            this.gpbPLDetail.Controls.Add(this.label1);
            this.gpbPLDetail.Location = new System.Drawing.Point(9, 120);
            this.gpbPLDetail.Name = "gpbPLDetail";
            this.gpbPLDetail.Size = new System.Drawing.Size(361, 312);
            this.gpbPLDetail.TabIndex = 1;
            this.gpbPLDetail.TabStop = false;
            this.gpbPLDetail.Text = "รายละเอียดค่าใช้จ่าย";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label20.Location = new System.Drawing.Point(65, 92);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(20, 13);
            this.label20.TabIndex = 190;
            this.label20.Text = "FV";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label21.Location = new System.Drawing.Point(60, 60);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(25, 13);
            this.label21.TabIndex = 189;
            this.label21.Text = "Pmt";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label22.Location = new System.Drawing.Point(55, 28);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(30, 13);
            this.label22.TabIndex = 188;
            this.label22.Text = "Rate";
            // 
            // fpdRate
            // 
            this.fpdRate.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdRate.AllowClipboardKeys = true;
            this.fpdRate.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdRate.DecimalPlaces = 2;
            this.fpdRate.DecimalSeparator = ".";
            this.fpdRate.Location = new System.Drawing.Point(96, 24);
            this.fpdRate.Name = "fpdRate";
            this.fpdRate.NumberGroupSeparator = ",";
            this.fpdRate.NumberGroupSize = 3;
            this.fpdRate.Size = new System.Drawing.Size(56, 20);
            this.fpdRate.TabIndex = 3;
            this.fpdRate.Text = "";
            this.fpdRate.UseSeparator = true;
            // 
            // fpdPmt
            // 
            this.fpdPmt.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdPmt.AllowClipboardKeys = true;
            this.fpdPmt.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdPmt.DecimalPlaces = 2;
            this.fpdPmt.DecimalSeparator = ".";
            this.fpdPmt.Location = new System.Drawing.Point(96, 56);
            this.fpdPmt.Name = "fpdPmt";
            this.fpdPmt.NumberGroupSeparator = ",";
            this.fpdPmt.NumberGroupSize = 3;
            this.fpdPmt.Size = new System.Drawing.Size(104, 20);
            this.fpdPmt.TabIndex = 4;
            this.fpdPmt.Text = "";
            this.fpdPmt.UseSeparator = true;
            // 
            // fpdFV
            // 
            this.fpdFV.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdFV.AllowClipboardKeys = true;
            this.fpdFV.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdFV.DecimalPlaces = 2;
            this.fpdFV.DecimalSeparator = ".";
            this.fpdFV.Location = new System.Drawing.Point(96, 88);
            this.fpdFV.Name = "fpdFV";
            this.fpdFV.NumberGroupSeparator = ",";
            this.fpdFV.NumberGroupSize = 3;
            this.fpdFV.Size = new System.Drawing.Size(104, 20);
            this.fpdFV.TabIndex = 5;
            this.fpdFV.Text = "";
            this.fpdFV.UseSeparator = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(200, 284);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(26, 13);
            this.label16.TabIndex = 181;
            this.label16.Text = "บาท";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(200, 252);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(26, 13);
            this.label15.TabIndex = 180;
            this.label15.Text = "บาท";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(200, 220);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 13);
            this.label14.TabIndex = 179;
            this.label14.Text = "บาท";
            // 
            // fpdRentalPrice
            // 
            this.fpdRentalPrice.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdRentalPrice.AllowClipboardKeys = true;
            this.fpdRentalPrice.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdRentalPrice.DecimalPlaces = 2;
            this.fpdRentalPrice.DecimalSeparator = ".";
            this.fpdRentalPrice.Location = new System.Drawing.Point(96, 216);
            this.fpdRentalPrice.Name = "fpdRentalPrice";
            this.fpdRentalPrice.NumberGroupSeparator = ",";
            this.fpdRentalPrice.NumberGroupSize = 3;
            this.fpdRentalPrice.Size = new System.Drawing.Size(104, 20);
            this.fpdRentalPrice.TabIndex = 9;
            this.fpdRentalPrice.Text = "";
            this.fpdRentalPrice.UseSeparator = true;
            // 
            // fpdSellPrice
            // 
            this.fpdSellPrice.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdSellPrice.AllowClipboardKeys = true;
            this.fpdSellPrice.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdSellPrice.DecimalPlaces = 2;
            this.fpdSellPrice.DecimalSeparator = ".";
            this.fpdSellPrice.Location = new System.Drawing.Point(96, 248);
            this.fpdSellPrice.Name = "fpdSellPrice";
            this.fpdSellPrice.NumberGroupSeparator = ",";
            this.fpdSellPrice.NumberGroupSize = 3;
            this.fpdSellPrice.Size = new System.Drawing.Size(104, 20);
            this.fpdSellPrice.TabIndex = 10;
            this.fpdSellPrice.Text = "";
            this.fpdSellPrice.UseSeparator = true;
            // 
            // fpdBodyPrice
            // 
            this.fpdBodyPrice.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdBodyPrice.AllowClipboardKeys = true;
            this.fpdBodyPrice.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdBodyPrice.DecimalPlaces = 2;
            this.fpdBodyPrice.DecimalSeparator = ".";
            this.fpdBodyPrice.Location = new System.Drawing.Point(96, 280);
            this.fpdBodyPrice.Name = "fpdBodyPrice";
            this.fpdBodyPrice.NumberGroupSeparator = ",";
            this.fpdBodyPrice.NumberGroupSize = 3;
            this.fpdBodyPrice.Size = new System.Drawing.Size(104, 20);
            this.fpdBodyPrice.TabIndex = 11;
            this.fpdBodyPrice.Text = "";
            this.fpdBodyPrice.UseSeparator = true;
            // 
            // fpiRemain
            // 
            this.fpiRemain.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiRemain.AllowClipboardKeys = true;
            this.fpiRemain.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiRemain.Location = new System.Drawing.Point(96, 184);
            this.fpiRemain.MaxValue = 250;
            this.fpiRemain.MinValue = 0;
            this.fpiRemain.Name = "fpiRemain";
            this.fpiRemain.Size = new System.Drawing.Size(40, 20);
            this.fpiRemain.TabIndex = 8;
            this.fpiRemain.Text = "";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(136, 188);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(33, 13);
            this.label13.TabIndex = 174;
            this.label13.Text = "เดือน";
            // 
            // fpiRentalAge
            // 
            this.fpiRentalAge.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiRentalAge.AllowClipboardKeys = true;
            this.fpiRentalAge.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiRentalAge.Location = new System.Drawing.Point(96, 152);
            this.fpiRentalAge.MaxValue = 250;
            this.fpiRentalAge.MinValue = 0;
            this.fpiRentalAge.Name = "fpiRentalAge";
            this.fpiRentalAge.Size = new System.Drawing.Size(40, 20);
            this.fpiRentalAge.TabIndex = 7;
            this.fpiRentalAge.Text = "";
            this.fpiRentalAge.ValueChanged += new System.EventHandler(this.fpiRentalAge_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(136, 156);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 13);
            this.label12.TabIndex = 172;
            this.label12.Text = "เดือน";
            // 
            // fpiLeaseTerm
            // 
            this.fpiLeaseTerm.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiLeaseTerm.AllowClipboardKeys = true;
            this.fpiLeaseTerm.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiLeaseTerm.Location = new System.Drawing.Point(96, 120);
            this.fpiLeaseTerm.MaxValue = 250;
            this.fpiLeaseTerm.MinValue = 0;
            this.fpiLeaseTerm.Name = "fpiLeaseTerm";
            this.fpiLeaseTerm.Size = new System.Drawing.Size(40, 20);
            this.fpiLeaseTerm.TabIndex = 6;
            this.fpiLeaseTerm.Text = "";
            this.fpiLeaseTerm.ValueChanged += new System.EventHandler(this.fpiLeaseTerm_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(136, 124);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 13);
            this.label11.TabIndex = 170;
            this.label11.Text = "เดือน";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label10.Location = new System.Drawing.Point(42, 284);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 169;
            this.label10.Text = "ราคารถ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label9.Location = new System.Drawing.Point(37, 252);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 168;
            this.label9.Text = "ราคาขาย";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.Location = new System.Drawing.Point(42, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 167;
            this.label8.Text = "Remain";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(25, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 166;
            this.label3.Text = "Rental Age";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(16, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 165;
            this.label2.Text = "ระยะเวลาเช่า";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(48, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 164;
            this.label1.Text = "Rental";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.Location = new System.Drawing.Point(194, 446);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Location = new System.Drawing.Point(110, 446);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "ตกลง";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FrmProfitLostEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(379, 482);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gpbPLDetail);
            this.Controls.Add(this.gpbVehicleDetail);
            this.Name = "FrmProfitLostEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FrmProfitLostEntry_Load);
            this.gpbVehicleDetail.ResumeLayout(false);
            this.gpbVehicleDetail.PerformLayout();
            this.gpbPLDetail.ResumeLayout(false);
            this.gpbPLDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbVehicleDetail;
        private System.Windows.Forms.GroupBox gpbPLDetail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPlateNo;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblPlatePrefix;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPlatePrefix;
        private FarPoint.Win.Input.FpInteger fpiPlateRunningNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private FarPoint.Win.Input.FpInteger fpiRemain;
        private System.Windows.Forms.Label label13;
        private FarPoint.Win.Input.FpInteger fpiRentalAge;
        private System.Windows.Forms.Label label12;
        private FarPoint.Win.Input.FpInteger fpiLeaseTerm;
        private System.Windows.Forms.Label label11;
        private FarPoint.Win.Input.FpDouble fpdRentalPrice;
        private FarPoint.Win.Input.FpDouble fpdSellPrice;
        private FarPoint.Win.Input.FpDouble fpdBodyPrice;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private FarPoint.Win.Input.FpDouble fpdRate;
        private FarPoint.Win.Input.FpDouble fpdPmt;
        private FarPoint.Win.Input.FpDouble fpdFV;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblBrand;

    }
}