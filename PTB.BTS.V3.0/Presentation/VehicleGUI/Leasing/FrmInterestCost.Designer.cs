namespace Presentation.VehicleGUI.Leasing
{
    partial class FrmInterestCost
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
            this.gpbInterestCost = new System.Windows.Forms.GroupBox();
            this.fpdPercentRateOfReturn = new FarPoint.Win.Input.FpDouble();
            this.fpdBodyPrice = new FarPoint.Win.Input.FpDouble();
            this.fpiLeaseTerm = new FarPoint.Win.Input.FpInteger();
            this.label31 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fpdPercentResidual = new FarPoint.Win.Input.FpDouble();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPlateNo = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblPlatePrefix = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPlatePrefix = new System.Windows.Forms.TextBox();
            this.fpiPlateRunningNo = new FarPoint.Win.Input.FpInteger();
            this.crvPrint = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.gpbInterestCost.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPrint.Location = new System.Drawing.Point(552, 56);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "พิมพ์";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // gpbInterestCost
            // 
            this.gpbInterestCost.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpbInterestCost.Controls.Add(this.fpdPercentRateOfReturn);
            this.gpbInterestCost.Controls.Add(this.fpdBodyPrice);
            this.gpbInterestCost.Controls.Add(this.fpiLeaseTerm);
            this.gpbInterestCost.Controls.Add(this.label31);
            this.gpbInterestCost.Controls.Add(this.label1);
            this.gpbInterestCost.Controls.Add(this.fpdPercentResidual);
            this.gpbInterestCost.Controls.Add(this.label29);
            this.gpbInterestCost.Controls.Add(this.label30);
            this.gpbInterestCost.Controls.Add(this.label24);
            this.gpbInterestCost.Controls.Add(this.label25);
            this.gpbInterestCost.Controls.Add(this.label2);
            this.gpbInterestCost.Controls.Add(this.label4);
            this.gpbInterestCost.Controls.Add(this.lblPlateNo);
            this.gpbInterestCost.Controls.Add(this.label23);
            this.gpbInterestCost.Controls.Add(this.lblPlatePrefix);
            this.gpbInterestCost.Controls.Add(this.label7);
            this.gpbInterestCost.Controls.Add(this.txtPlatePrefix);
            this.gpbInterestCost.Controls.Add(this.fpiPlateRunningNo);
            this.gpbInterestCost.Controls.Add(this.btnPrint);
            this.gpbInterestCost.Location = new System.Drawing.Point(91, 8);
            this.gpbInterestCost.Name = "gpbInterestCost";
            this.gpbInterestCost.Size = new System.Drawing.Size(634, 88);
            this.gpbInterestCost.TabIndex = 0;
            this.gpbInterestCost.TabStop = false;
            this.gpbInterestCost.Text = "ข้อมูล Interest Cost";
            // 
            // fpdPercentRateOfReturn
            // 
            this.fpdPercentRateOfReturn.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdPercentRateOfReturn.AllowClipboardKeys = true;
            this.fpdPercentRateOfReturn.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdPercentRateOfReturn.DecimalPlaces = 2;
            this.fpdPercentRateOfReturn.DecimalSeparator = ".";
            this.fpdPercentRateOfReturn.Location = new System.Drawing.Point(456, 56);
            this.fpdPercentRateOfReturn.Name = "fpdPercentRateOfReturn";
            this.fpdPercentRateOfReturn.Size = new System.Drawing.Size(56, 20);
            this.fpdPercentRateOfReturn.TabIndex = 4;
            this.fpdPercentRateOfReturn.Text = "";
            // 
            // fpdBodyPrice
            // 
            this.fpdBodyPrice.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdBodyPrice.AllowClipboardKeys = true;
            this.fpdBodyPrice.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdBodyPrice.DecimalPlaces = 2;
            this.fpdBodyPrice.DecimalSeparator = ".";
            this.fpdBodyPrice.Location = new System.Drawing.Point(80, 56);
            this.fpdBodyPrice.Name = "fpdBodyPrice";
            this.fpdBodyPrice.NumberGroupSeparator = ",";
            this.fpdBodyPrice.NumberGroupSize = 3;
            this.fpdBodyPrice.Size = new System.Drawing.Size(104, 20);
            this.fpdBodyPrice.TabIndex = 1;
            this.fpdBodyPrice.Text = "";
            this.fpdBodyPrice.UseSeparator = true;
            // 
            // fpiLeaseTerm
            // 
            this.fpiLeaseTerm.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiLeaseTerm.AllowClipboardKeys = true;
            this.fpiLeaseTerm.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiLeaseTerm.Location = new System.Drawing.Point(456, 24);
            this.fpiLeaseTerm.MaxValue = 250;
            this.fpiLeaseTerm.MinValue = 0;
            this.fpiLeaseTerm.Name = "fpiLeaseTerm";
            this.fpiLeaseTerm.Size = new System.Drawing.Size(56, 20);
            this.fpiLeaseTerm.TabIndex = 2;
            this.fpiLeaseTerm.Text = "";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(31, 60);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(43, 13);
            this.label31.TabIndex = 173;
            this.label31.Text = "ราคารถ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(512, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 175;
            this.label1.Text = "เดือน";
            // 
            // fpdPercentResidual
            // 
            this.fpdPercentResidual.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdPercentResidual.AllowClipboardKeys = true;
            this.fpdPercentResidual.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdPercentResidual.DecimalPlaces = 2;
            this.fpdPercentResidual.DecimalSeparator = ".";
            this.fpdPercentResidual.Location = new System.Drawing.Point(283, 56);
            this.fpdPercentResidual.Name = "fpdPercentResidual";
            this.fpdPercentResidual.Size = new System.Drawing.Size(56, 20);
            this.fpdPercentResidual.TabIndex = 3;
            this.fpdPercentResidual.Text = "";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(512, 60);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(15, 13);
            this.label29.TabIndex = 172;
            this.label29.Text = "%";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(371, 60);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(77, 13);
            this.label30.TabIndex = 171;
            this.label30.Text = "Rate of Return";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(339, 60);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(15, 13);
            this.label24.TabIndex = 169;
            this.label24.Text = "%";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(197, 60);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(78, 13);
            this.label25.TabIndex = 168;
            this.label25.Text = "Residual Value";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(379, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 170;
            this.label2.Text = "ระยะเวลาเช่า";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(120, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 25);
            this.label4.TabIndex = 167;
            this.label4.Text = "-";
            // 
            // lblPlateNo
            // 
            this.lblPlateNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPlateNo.Location = new System.Drawing.Point(256, 20);
            this.lblPlateNo.Name = "lblPlateNo";
            this.lblPlateNo.Size = new System.Drawing.Size(72, 24);
            this.lblPlateNo.TabIndex = 166;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label23.Location = new System.Drawing.Point(240, 20);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(19, 25);
            this.label23.TabIndex = 165;
            this.label23.Text = "-";
            // 
            // lblPlatePrefix
            // 
            this.lblPlatePrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPlatePrefix.Location = new System.Drawing.Point(200, 20);
            this.lblPlatePrefix.Name = "lblPlatePrefix";
            this.lblPlatePrefix.Size = new System.Drawing.Size(40, 24);
            this.lblPlatePrefix.TabIndex = 164;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(16, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 163;
            this.label7.Text = "ทะเบียนรถ";
            // 
            // txtPlatePrefix
            // 
            this.txtPlatePrefix.Location = new System.Drawing.Point(80, 22);
            this.txtPlatePrefix.MaxLength = 3;
            this.txtPlatePrefix.Name = "txtPlatePrefix";
            this.txtPlatePrefix.Size = new System.Drawing.Size(40, 20);
            this.txtPlatePrefix.TabIndex = 6;
            this.txtPlatePrefix.TextChanged += new System.EventHandler(this.txtPlatePrefix_TextChanged);
            // 
            // fpiPlateRunningNo
            // 
            this.fpiPlateRunningNo.AllowClipboardKeys = true;
            this.fpiPlateRunningNo.AllowNull = true;
            this.fpiPlateRunningNo.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiPlateRunningNo.Location = new System.Drawing.Point(136, 22);
            this.fpiPlateRunningNo.MaxValue = 9999;
            this.fpiPlateRunningNo.MinValue = 0;
            this.fpiPlateRunningNo.Name = "fpiPlateRunningNo";
            this.fpiPlateRunningNo.NullColor = System.Drawing.Color.Transparent;
            this.fpiPlateRunningNo.Size = new System.Drawing.Size(48, 20);
            this.fpiPlateRunningNo.TabIndex = 7;
            this.fpiPlateRunningNo.Text = "";
            this.fpiPlateRunningNo.DoubleClick += new System.EventHandler(this.fpiPlateRunningNo_DoubleClick);
            this.fpiPlateRunningNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpiPlateRunningNo_KeyDown);
            this.fpiPlateRunningNo.TextChanged += new System.EventHandler(this.fpiPlateRunningNo_TextChanged);
            // 
            // crvPrint
            // 
            this.crvPrint.ActiveViewIndex = -1;
            this.crvPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvPrint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvPrint.DisplayGroupTree = false;
            this.crvPrint.Location = new System.Drawing.Point(0, 104);
            this.crvPrint.Name = "crvPrint";
            this.crvPrint.ShowCloseButton = false;
            this.crvPrint.ShowExportButton = false;
            this.crvPrint.ShowGroupTreeButton = false;
            this.crvPrint.Size = new System.Drawing.Size(817, 267);
            this.crvPrint.TabIndex = 3;
            this.crvPrint.TabStop = false;
            // 
            // FrmInterestCost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 371);
            this.Controls.Add(this.crvPrint);
            this.Controls.Add(this.gpbInterestCost);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmInterestCost";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmInterestCost_Load);
            this.gpbInterestCost.ResumeLayout(false);
            this.gpbInterestCost.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.GroupBox gpbInterestCost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPlateNo;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblPlatePrefix;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPlatePrefix;
        private FarPoint.Win.Input.FpInteger fpiPlateRunningNo;
        private FarPoint.Win.Input.FpDouble fpdPercentRateOfReturn;
        private FarPoint.Win.Input.FpDouble fpdBodyPrice;
        private FarPoint.Win.Input.FpInteger fpiLeaseTerm;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label1;
        private FarPoint.Win.Input.FpDouble fpdPercentResidual;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvPrint;
    }
}