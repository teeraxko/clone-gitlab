namespace Presentation.VehicleGUI.VehicleLeasingGUI
{
    partial class FrmPurchaseOrderEntry
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtDiscountAmount = new FarPoint.Win.Input.FpDouble();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDiscountTotal = new FarPoint.Win.Input.FpDouble();
            this.label9 = new System.Windows.Forms.Label();
            this.txtVehiclePrice = new FarPoint.Win.Input.FpDouble();
            this.cboColor = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboModel = new System.Windows.Forms.ComboBox();
            this.cboBrand = new System.Windows.Forms.ComboBox();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblPOStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearchQuotation = new System.Windows.Forms.Button();
            this.rdbNewType = new System.Windows.Forms.RadioButton();
            this.rdbConType = new System.Windows.Forms.RadioButton();
            this.txtUnit = new FarPoint.Win.Input.FpInteger();
            this.label7 = new System.Windows.Forms.Label();
            this.txtQuotationXXX = new System.Windows.Forms.TextBox();
            this.txtQuotationYY = new System.Windows.Forms.TextBox();
            this.txtQuotationMM = new System.Windows.Forms.TextBox();
            this.cboVendor = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpVendorDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtPOXXX = new System.Windows.Forms.TextBox();
            this.txtPOYY = new System.Windows.Forms.TextBox();
            this.txtPOMM = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtDiscountAmount);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtDiscountTotal);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtVehiclePrice);
            this.groupBox3.Controls.Add(this.cboColor);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.cboModel);
            this.groupBox3.Controls.Add(this.cboBrand);
            this.groupBox3.Controls.Add(this.cboCustomer);
            this.groupBox3.Controls.Add(this.label31);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(11, 128);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(604, 172);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Detail of Vehicle";
            // 
            // txtDiscountAmount
            // 
            this.txtDiscountAmount.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.txtDiscountAmount.AllowClipboardKeys = true;
            this.txtDiscountAmount.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.txtDiscountAmount.DecimalPlaces = 2;
            this.txtDiscountAmount.DecimalSeparator = ".";
            this.txtDiscountAmount.Enabled = false;
            this.txtDiscountAmount.FixedPoint = true;
            this.txtDiscountAmount.Location = new System.Drawing.Point(106, 111);
            this.txtDiscountAmount.Name = "txtDiscountAmount";
            this.txtDiscountAmount.NumberGroupSeparator = ",";
            this.txtDiscountAmount.Size = new System.Drawing.Size(93, 20);
            this.txtDiscountAmount.TabIndex = 84;
            this.txtDiscountAmount.Text = "";
            this.txtDiscountAmount.UseSeparator = true;
            this.txtDiscountAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDiscountAmount_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(36, 142);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 17);
            this.label10.TabIndex = 83;
            this.label10.Text = "Net Price";
            this.label10.UseCompatibleTextRendering = true;
            // 
            // txtDiscountTotal
            // 
            this.txtDiscountTotal.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.txtDiscountTotal.AllowClipboardKeys = true;
            this.txtDiscountTotal.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.txtDiscountTotal.DecimalPlaces = 2;
            this.txtDiscountTotal.DecimalSeparator = ".";
            this.txtDiscountTotal.Enabled = false;
            this.txtDiscountTotal.FixedPoint = true;
            this.txtDiscountTotal.Location = new System.Drawing.Point(106, 139);
            this.txtDiscountTotal.Name = "txtDiscountTotal";
            this.txtDiscountTotal.NumberGroupSeparator = ",";
            this.txtDiscountTotal.Size = new System.Drawing.Size(93, 20);
            this.txtDiscountTotal.TabIndex = 82;
            this.txtDiscountTotal.Text = "";
            this.txtDiscountTotal.UseSeparator = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(-2, 113);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 13);
            this.label9.TabIndex = 80;
            this.label9.Text = "Discount RKB && CVIP";
            // 
            // txtVehiclePrice
            // 
            this.txtVehiclePrice.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.txtVehiclePrice.AllowClipboardKeys = true;
            this.txtVehiclePrice.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.txtVehiclePrice.DecimalPlaces = 2;
            this.txtVehiclePrice.DecimalSeparator = ".";
            this.txtVehiclePrice.FixedPoint = true;
            this.txtVehiclePrice.Location = new System.Drawing.Point(106, 82);
            this.txtVehiclePrice.Name = "txtVehiclePrice";
            this.txtVehiclePrice.NumberGroupSeparator = ",";
            this.txtVehiclePrice.Size = new System.Drawing.Size(94, 20);
            this.txtVehiclePrice.TabIndex = 12;
            this.txtVehiclePrice.Text = "";
            this.txtVehiclePrice.UseSeparator = true;
            // 
            // cboColor
            // 
            this.cboColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboColor.FormattingEnabled = true;
            this.cboColor.Location = new System.Drawing.Point(399, 55);
            this.cboColor.Name = "cboColor";
            this.cboColor.Size = new System.Drawing.Size(193, 21);
            this.cboColor.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(363, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 78;
            this.label8.Text = "Color";
            // 
            // cboModel
            // 
            this.cboModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModel.FormattingEnabled = true;
            this.cboModel.Location = new System.Drawing.Point(106, 55);
            this.cboModel.Name = "cboModel";
            this.cboModel.Size = new System.Drawing.Size(241, 21);
            this.cboModel.TabIndex = 10;
            // 
            // cboBrand
            // 
            this.cboBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBrand.FormattingEnabled = true;
            this.cboBrand.Location = new System.Drawing.Point(399, 28);
            this.cboBrand.Name = "cboBrand";
            this.cboBrand.Size = new System.Drawing.Size(193, 21);
            this.cboBrand.TabIndex = 9;
            this.cboBrand.SelectedIndexChanged += new System.EventHandler(this.cboBrand_SelectedIndexChanged);
            // 
            // cboCustomer
            // 
            this.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(106, 28);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(241, 21);
            this.cboCustomer.TabIndex = 8;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(16, 86);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(69, 13);
            this.label31.TabIndex = 73;
            this.label31.Text = "Vehicle Price";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 68;
            this.label1.Text = "Model";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(359, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 65;
            this.label5.Text = "Brand";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 64;
            this.label6.Text = "Customer";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblPOStatus);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Controls.Add(this.txtUnit);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.txtQuotationXXX);
            this.groupBox4.Controls.Add(this.txtQuotationYY);
            this.groupBox4.Controls.Add(this.txtQuotationMM);
            this.groupBox4.Controls.Add(this.cboVendor);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.dtpVendorDate);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.txtPOXXX);
            this.groupBox4.Controls.Add(this.txtPOYY);
            this.groupBox4.Controls.Add(this.txtPOMM);
            this.groupBox4.Location = new System.Drawing.Point(11, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(604, 126);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Purchase Order Detail";
            // 
            // lblPOStatus
            // 
            this.lblPOStatus.AutoSize = true;
            this.lblPOStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPOStatus.ForeColor = System.Drawing.Color.Green;
            this.lblPOStatus.Location = new System.Drawing.Point(544, 24);
            this.lblPOStatus.Name = "lblPOStatus";
            this.lblPOStatus.Size = new System.Drawing.Size(37, 13);
            this.lblPOStatus.TabIndex = 126;
            this.lblPOStatus.Text = "Active";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(504, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 125;
            this.label3.Text = "Status :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearchQuotation);
            this.groupBox1.Controls.Add(this.rdbNewType);
            this.groupBox1.Controls.Add(this.rdbConType);
            this.groupBox1.Location = new System.Drawing.Point(10, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 68);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type of leasing";
            // 
            // btnSearchQuotation
            // 
            this.btnSearchQuotation.ForeColor = System.Drawing.Color.Blue;
            this.btnSearchQuotation.Location = new System.Drawing.Point(112, 16);
            this.btnSearchQuotation.Name = "btnSearchQuotation";
            this.btnSearchQuotation.Size = new System.Drawing.Size(102, 23);
            this.btnSearchQuotation.TabIndex = 3;
            this.btnSearchQuotation.Text = "ค้นหา Quotation";
            this.btnSearchQuotation.UseVisualStyleBackColor = true;
            this.btnSearchQuotation.Click += new System.EventHandler(this.btnSearchQuotation_Click);
            // 
            // rdbNewType
            // 
            this.rdbNewType.AutoSize = true;
            this.rdbNewType.Checked = true;
            this.rdbNewType.Location = new System.Drawing.Point(32, 19);
            this.rdbNewType.Name = "rdbNewType";
            this.rdbNewType.Size = new System.Drawing.Size(47, 17);
            this.rdbNewType.TabIndex = 1;
            this.rdbNewType.TabStop = true;
            this.rdbNewType.Text = "New";
            this.rdbNewType.UseVisualStyleBackColor = true;
            this.rdbNewType.CheckedChanged += new System.EventHandler(this.rdbNewType_CheckedChanged);
            // 
            // rdbConType
            // 
            this.rdbConType.AutoSize = true;
            this.rdbConType.Location = new System.Drawing.Point(32, 42);
            this.rdbConType.Name = "rdbConType";
            this.rdbConType.Size = new System.Drawing.Size(53, 17);
            this.rdbConType.TabIndex = 2;
            this.rdbConType.TabStop = true;
            this.rdbConType.Text = "Spare";
            this.rdbConType.UseVisualStyleBackColor = true;
            this.rdbConType.CheckedChanged += new System.EventHandler(this.rdbConType_CheckedChanged);
            // 
            // txtUnit
            // 
            this.txtUnit.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.txtUnit.AllowClipboardKeys = true;
            this.txtUnit.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.txtUnit.Location = new System.Drawing.Point(536, 62);
            this.txtUnit.MaxValue = 99;
            this.txtUnit.MinValue = 1;
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(53, 20);
            this.txtUnit.TabIndex = 5;
            this.txtUnit.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(224, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 13);
            this.label7.TabIndex = 121;
            this.label7.Text = "Quotation #   PTB-Q-";
            // 
            // txtQuotationXXX
            // 
            this.txtQuotationXXX.Location = new System.Drawing.Point(393, 20);
            this.txtQuotationXXX.Name = "txtQuotationXXX";
            this.txtQuotationXXX.ReadOnly = true;
            this.txtQuotationXXX.Size = new System.Drawing.Size(30, 20);
            this.txtQuotationXXX.TabIndex = 124;
            this.txtQuotationXXX.TabStop = false;
            // 
            // txtQuotationYY
            // 
            this.txtQuotationYY.Location = new System.Drawing.Point(335, 20);
            this.txtQuotationYY.Name = "txtQuotationYY";
            this.txtQuotationYY.ReadOnly = true;
            this.txtQuotationYY.Size = new System.Drawing.Size(30, 20);
            this.txtQuotationYY.TabIndex = 122;
            this.txtQuotationYY.TabStop = false;
            // 
            // txtQuotationMM
            // 
            this.txtQuotationMM.Location = new System.Drawing.Point(364, 20);
            this.txtQuotationMM.Name = "txtQuotationMM";
            this.txtQuotationMM.ReadOnly = true;
            this.txtQuotationMM.Size = new System.Drawing.Size(30, 20);
            this.txtQuotationMM.TabIndex = 123;
            this.txtQuotationMM.TabStop = false;
            // 
            // cboVendor
            // 
            this.cboVendor.DisplayMember = "English_Name";
            this.cboVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVendor.FormattingEnabled = true;
            this.cboVendor.Location = new System.Drawing.Point(333, 89);
            this.cboVendor.Name = "cboVendor";
            this.cboVendor.Size = new System.Drawing.Size(257, 21);
            this.cboVendor.TabIndex = 6;
            this.cboVendor.ValueMember = "Vendor_Code";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(286, 93);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 119;
            this.label13.Text = "Vendor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(454, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 117;
            this.label4.Text = "Unit of Vehicle";
            // 
            // dtpVendorDate
            // 
            this.dtpVendorDate.Checked = false;
            this.dtpVendorDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVendorDate.Location = new System.Drawing.Point(333, 62);
            this.dtpVendorDate.Name = "dtpVendorDate";
            this.dtpVendorDate.ShowCheckBox = true;
            this.dtpVendorDate.Size = new System.Drawing.Size(105, 20);
            this.dtpVendorDate.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 103;
            this.label2.Text = "PO #    PTB-P-";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(261, 66);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(67, 13);
            this.label22.TabIndex = 112;
            this.label22.Text = "Vendor Date";
            // 
            // txtPOXXX
            // 
            this.txtPOXXX.Location = new System.Drawing.Point(164, 20);
            this.txtPOXXX.Name = "txtPOXXX";
            this.txtPOXXX.ReadOnly = true;
            this.txtPOXXX.Size = new System.Drawing.Size(30, 20);
            this.txtPOXXX.TabIndex = 106;
            this.txtPOXXX.TabStop = false;
            // 
            // txtPOYY
            // 
            this.txtPOYY.Location = new System.Drawing.Point(106, 20);
            this.txtPOYY.Name = "txtPOYY";
            this.txtPOYY.ReadOnly = true;
            this.txtPOYY.Size = new System.Drawing.Size(30, 20);
            this.txtPOYY.TabIndex = 104;
            this.txtPOYY.TabStop = false;
            // 
            // txtPOMM
            // 
            this.txtPOMM.Location = new System.Drawing.Point(135, 20);
            this.txtPOMM.Name = "txtPOMM";
            this.txtPOMM.ReadOnly = true;
            this.txtPOMM.Size = new System.Drawing.Size(30, 20);
            this.txtPOMM.TabIndex = 105;
            this.txtPOMM.TabStop = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPrint.Location = new System.Drawing.Point(276, 403);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 15;
            this.btnPrint.Text = "พิมพ์";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.Location = new System.Drawing.Point(357, 403);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.Location = new System.Drawing.Point(195, 403);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "ตกลง";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(7, 306);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(44, 13);
            this.label27.TabIndex = 99;
            this.label27.Text = "Remark";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(57, 306);
            this.txtRemark.MaxLength = 150;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(558, 63);
            this.txtRemark.TabIndex = 13;
            // 
            // FrmPurchaseOrderEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(627, 442);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Name = "FrmPurchaseOrderEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase Order";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DateTimePicker dtpVendorDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtPOXXX;
        private System.Windows.Forms.TextBox txtPOYY;
        private System.Windows.Forms.TextBox txtPOMM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.ComboBox cboVendor;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.ComboBox cboModel;
        private System.Windows.Forms.ComboBox cboBrand;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtQuotationXXX;
        private System.Windows.Forms.TextBox txtQuotationYY;
        private System.Windows.Forms.TextBox txtQuotationMM;
        private System.Windows.Forms.ComboBox cboColor;
        private System.Windows.Forms.Label label8;
        private FarPoint.Win.Input.FpDouble txtVehiclePrice;
        private FarPoint.Win.Input.FpInteger txtUnit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearchQuotation;
        private System.Windows.Forms.RadioButton rdbNewType;
        private System.Windows.Forms.RadioButton rdbConType;
        private System.Windows.Forms.Label lblPOStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private FarPoint.Win.Input.FpDouble txtDiscountTotal;
        private FarPoint.Win.Input.FpDouble txtDiscountAmount;
    }
}