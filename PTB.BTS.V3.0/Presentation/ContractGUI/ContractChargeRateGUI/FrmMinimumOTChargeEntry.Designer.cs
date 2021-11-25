namespace Presentation.ContractGUI.ContractChargeRateGUI
{
    partial class FrmMinimumOTChargeEntry
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.fpdAmount = new FarPoint.Win.Input.FpDouble();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkStatus = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fpiHour = new FarPoint.Win.Input.FpInteger();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(133, 150);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Location = new System.Drawing.Point(52, 150);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 15;
            this.btnOK.Text = "ตกลง";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // fpdAmount
            // 
            this.fpdAmount.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdAmount.AllowClipboardKeys = true;
            this.fpdAmount.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdAmount.DecimalPlaces = 2;
            this.fpdAmount.DecimalSeparator = ".";
            this.fpdAmount.FixedPoint = true;
            this.fpdAmount.Location = new System.Drawing.Point(120, 85);
            this.fpdAmount.Name = "fpdAmount";
            this.fpdAmount.NumberGroupSeparator = ",";
            this.fpdAmount.NumberGroupSize = 3;
            this.fpdAmount.Size = new System.Drawing.Size(88, 20);
            this.fpdAmount.TabIndex = 30;
            this.fpdAmount.Text = "";
            this.fpdAmount.UseSeparator = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(36, 88);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "ค่าบริการขั้นต่ำ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkStatus);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.fpiHour);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.fpdAmount);
            this.groupBox1.Location = new System.Drawing.Point(12, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 128);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "รายละเอียด";
            // 
            // chkStatus
            // 
            this.chkStatus.AutoSize = true;
            this.chkStatus.Location = new System.Drawing.Point(120, 24);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Size = new System.Drawing.Size(85, 17);
            this.chkStatus.TabIndex = 34;
            this.chkStatus.Text = "เฉพาะคนขับ";
            this.chkStatus.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "จำนวนชั่วโมงขั้นต่ำ";
            // 
            // fpiHour
            // 
            this.fpiHour.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiHour.AllowClipboardKeys = true;
            this.fpiHour.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiHour.Location = new System.Drawing.Point(120, 56);
            this.fpiHour.MaxValue = 99;
            this.fpiHour.MinValue = 0;
            this.fpiHour.Name = "fpiHour";
            this.fpiHour.Size = new System.Drawing.Size(40, 20);
            this.fpiHour.TabIndex = 32;
            this.fpiHour.Text = "";
            // 
            // FrmMinimumOTChargeEntry
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(261, 190);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmMinimumOTChargeEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FrmMinimumOTChargeEntry_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private FarPoint.Win.Input.FpDouble fpdAmount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private FarPoint.Win.Input.FpInteger fpiHour;
        private System.Windows.Forms.CheckBox chkStatus;
    }
}