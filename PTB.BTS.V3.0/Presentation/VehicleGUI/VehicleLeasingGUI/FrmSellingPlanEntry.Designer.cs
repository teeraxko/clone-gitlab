namespace Presentation.VehicleGUI.VehicleLeasingGUI
{
    partial class FrmSellingPlanEntry
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
            this.lblModel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPlateNo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fpdSellingPrice = new FarPoint.Win.Input.FpDouble();
            this.fpdActaulBV = new FarPoint.Win.Input.FpDouble();
            this.cboBidder = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpBVDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpSellingDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblModel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblBrand);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblPlateNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 112);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vehicle Detail";
            // 
            // lblModel
            // 
            this.lblModel.BackColor = System.Drawing.Color.MistyRose;
            this.lblModel.Location = new System.Drawing.Point(88, 80);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(200, 20);
            this.lblModel.TabIndex = 5;
            this.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "รุ่น";
            // 
            // lblBrand
            // 
            this.lblBrand.BackColor = System.Drawing.Color.MistyRose;
            this.lblBrand.Location = new System.Drawing.Point(88, 50);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(80, 20);
            this.lblBrand.TabIndex = 3;
            this.lblBrand.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "ยี่ห้อ";
            // 
            // lblPlateNo
            // 
            this.lblPlateNo.BackColor = System.Drawing.Color.MistyRose;
            this.lblPlateNo.Location = new System.Drawing.Point(88, 20);
            this.lblPlateNo.Name = "lblPlateNo";
            this.lblPlateNo.Size = new System.Drawing.Size(56, 20);
            this.lblPlateNo.TabIndex = 1;
            this.lblPlateNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ทะเบียนรถ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.fpdSellingPrice);
            this.groupBox2.Controls.Add(this.fpdActaulBV);
            this.groupBox2.Controls.Add(this.cboBidder);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dtpBVDate);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtpSellingDate);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(8, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(304, 165);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selling Detail";
            // 
            // fpdSellingPrice
            // 
            this.fpdSellingPrice.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdSellingPrice.AllowClipboardKeys = true;
            this.fpdSellingPrice.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdSellingPrice.DecimalPlaces = 2;
            this.fpdSellingPrice.DecimalSeparator = ".";
            this.fpdSellingPrice.Location = new System.Drawing.Point(88, 75);
            this.fpdSellingPrice.Name = "fpdSellingPrice";
            this.fpdSellingPrice.Size = new System.Drawing.Size(112, 20);
            this.fpdSellingPrice.TabIndex = 13;
            this.fpdSellingPrice.Text = "";
            this.fpdSellingPrice.UseSeparator = true;
            // 
            // fpdActaulBV
            // 
            this.fpdActaulBV.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdActaulBV.AllowClipboardKeys = true;
            this.fpdActaulBV.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdActaulBV.DecimalPlaces = 2;
            this.fpdActaulBV.DecimalSeparator = ".";
            this.fpdActaulBV.Location = new System.Drawing.Point(88, 21);
            this.fpdActaulBV.Name = "fpdActaulBV";
            this.fpdActaulBV.Size = new System.Drawing.Size(112, 20);
            this.fpdActaulBV.TabIndex = 12;
            this.fpdActaulBV.Text = "";
            this.fpdActaulBV.UseSeparator = true;
            // 
            // cboBidder
            // 
            this.cboBidder.DisplayMember = "BidderName";
            this.cboBidder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBidder.FormattingEnabled = true;
            this.cboBidder.Location = new System.Drawing.Point(88, 129);
            this.cboBidder.Name = "cboBidder";
            this.cboBidder.Size = new System.Drawing.Size(200, 21);
            this.cboBidder.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Bidder";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Actaul BV";
            // 
            // dtpBVDate
            // 
            this.dtpBVDate.Checked = false;
            this.dtpBVDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBVDate.Location = new System.Drawing.Point(88, 48);
            this.dtpBVDate.Name = "dtpBVDate";
            this.dtpBVDate.ShowCheckBox = true;
            this.dtpBVDate.Size = new System.Drawing.Size(112, 20);
            this.dtpBVDate.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Actaul BV Date";
            // 
            // dtpSellingDate
            // 
            this.dtpSellingDate.Checked = false;
            this.dtpSellingDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSellingDate.Location = new System.Drawing.Point(88, 102);
            this.dtpSellingDate.Name = "dtpSellingDate";
            this.dtpSellingDate.ShowCheckBox = true;
            this.dtpSellingDate.Size = new System.Drawing.Size(112, 20);
            this.dtpSellingDate.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Selling Price";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Selling Date";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(165, 296);
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
            this.btnOK.Location = new System.Drawing.Point(81, 296);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "ตกลง";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FrmSellingPlanEntry
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(321, 328);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmSellingPlanEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FrmVehicleSellingPlanEntry_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPlateNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpSellingDate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DateTimePicker dtpBVDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboBidder;
        private FarPoint.Win.Input.FpDouble fpdSellingPrice;
        private FarPoint.Win.Input.FpDouble fpdActaulBV;
    }
}