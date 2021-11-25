namespace Presentation.VehicleGUI
{
    partial class FrmModelEntry
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
            this.cboVendor = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboBreakType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEngModelName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboModelType = new System.Windows.Forms.ComboBox();
            this.cboGearType = new System.Windows.Forms.ComboBox();
            this.cboGasolineType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBrandCode = new System.Windows.Forms.TextBox();
            this.txtThaiModelName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBrandName = new System.Windows.Forms.TextBox();
            this.txtModelCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fpiEngineCC = new FarPoint.Win.Input.FpInteger();
            this.fpiNoOfSeat = new FarPoint.Win.Input.FpInteger();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboVendor);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cboBreakType);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtEngModelName);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cboModelType);
            this.groupBox1.Controls.Add(this.cboGearType);
            this.groupBox1.Controls.Add(this.cboGasolineType);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtBrandCode);
            this.groupBox1.Controls.Add(this.txtThaiModelName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtBrandName);
            this.groupBox1.Controls.Add(this.txtModelCode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.fpiEngineCC);
            this.groupBox1.Controls.Add(this.fpiNoOfSeat);
            this.groupBox1.Location = new System.Drawing.Point(12, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 280);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cboVendor
            // 
            this.cboVendor.FormattingEnabled = true;
            this.cboVendor.Location = new System.Drawing.Point(112, 248);
            this.cboVendor.Name = "cboVendor";
            this.cboVendor.Size = new System.Drawing.Size(336, 21);
            this.cboVendor.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(40, 248);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "ชื่อผู้จำหน่าย";
            // 
            // cboBreakType
            // 
            this.cboBreakType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBreakType.Location = new System.Drawing.Point(112, 184);
            this.cboBreakType.Name = "cboBreakType";
            this.cboBreakType.Size = new System.Drawing.Size(104, 21);
            this.cboBreakType.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(37, 184);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "ประเภทเบรค";
            // 
            // txtEngModelName
            // 
            this.txtEngModelName.Location = new System.Drawing.Point(112, 120);
            this.txtEngModelName.MaxLength = 50;
            this.txtEngModelName.Name = "txtEngModelName";
            this.txtEngModelName.Size = new System.Drawing.Size(336, 20);
            this.txtEngModelName.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "ชื่อรุ่น(ภาษาอังกฤษ)";
            // 
            // cboModelType
            // 
            this.cboModelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModelType.Items.AddRange(new object[] {
            ""});
            this.cboModelType.Location = new System.Drawing.Point(112, 152);
            this.cboModelType.Name = "cboModelType";
            this.cboModelType.Size = new System.Drawing.Size(104, 21);
            this.cboModelType.TabIndex = 6;
            // 
            // cboGearType
            // 
            this.cboGearType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGearType.Location = new System.Drawing.Point(328, 152);
            this.cboGearType.Name = "cboGearType";
            this.cboGearType.Size = new System.Drawing.Size(121, 21);
            this.cboGearType.TabIndex = 7;
            // 
            // cboGasolineType
            // 
            this.cboGasolineType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGasolineType.Location = new System.Drawing.Point(328, 184);
            this.cboGasolineType.Name = "cboGasolineType";
            this.cboGasolineType.Size = new System.Drawing.Size(121, 21);
            this.cboGasolineType.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(256, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "จำนวนที่นั่ง";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(48, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "ประเภทรุ่น";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(232, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "ประเภทเชื้อเพลิง";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(248, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "ประเภทเกียร์";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "ซีซี.";
            // 
            // txtBrandCode
            // 
            this.txtBrandCode.Enabled = false;
            this.txtBrandCode.Location = new System.Drawing.Point(112, 24);
            this.txtBrandCode.MaxLength = 2;
            this.txtBrandCode.Name = "txtBrandCode";
            this.txtBrandCode.Size = new System.Drawing.Size(64, 20);
            this.txtBrandCode.TabIndex = 1;
            // 
            // txtThaiModelName
            // 
            this.txtThaiModelName.Location = new System.Drawing.Point(112, 88);
            this.txtThaiModelName.MaxLength = 50;
            this.txtThaiModelName.Name = "txtThaiModelName";
            this.txtThaiModelName.Size = new System.Drawing.Size(336, 20);
            this.txtThaiModelName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "รหัสรุ่น";
            // 
            // txtBrandName
            // 
            this.txtBrandName.Enabled = false;
            this.txtBrandName.Location = new System.Drawing.Point(184, 24);
            this.txtBrandName.MaxLength = 50;
            this.txtBrandName.Name = "txtBrandName";
            this.txtBrandName.Size = new System.Drawing.Size(264, 20);
            this.txtBrandName.TabIndex = 2;
            // 
            // txtModelCode
            // 
            this.txtModelCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtModelCode.Location = new System.Drawing.Point(112, 56);
            this.txtModelCode.MaxLength = 5;
            this.txtModelCode.Name = "txtModelCode";
            this.txtModelCode.Size = new System.Drawing.Size(64, 20);
            this.txtModelCode.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "ชื่อรุ่น(ภาษาไทย)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "ยี่ห้อรถ";
            // 
            // fpiEngineCC
            // 
            this.fpiEngineCC.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiEngineCC.AllowClipboardKeys = true;
            this.fpiEngineCC.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiEngineCC.Location = new System.Drawing.Point(112, 216);
            this.fpiEngineCC.MaxValue = 99999;
            this.fpiEngineCC.MinValue = 0;
            this.fpiEngineCC.Name = "fpiEngineCC";
            this.fpiEngineCC.Size = new System.Drawing.Size(104, 20);
            this.fpiEngineCC.TabIndex = 10;
            this.fpiEngineCC.Text = "";
            // 
            // fpiNoOfSeat
            // 
            this.fpiNoOfSeat.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiNoOfSeat.AllowClipboardKeys = true;
            this.fpiNoOfSeat.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiNoOfSeat.Location = new System.Drawing.Point(328, 216);
            this.fpiNoOfSeat.MaxValue = 255;
            this.fpiNoOfSeat.MinValue = 0;
            this.fpiNoOfSeat.Name = "fpiNoOfSeat";
            this.fpiNoOfSeat.Size = new System.Drawing.Size(120, 20);
            this.fpiNoOfSeat.TabIndex = 11;
            this.fpiNoOfSeat.Text = "";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(247, 292);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Location = new System.Drawing.Point(167, 292);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 13;
            this.btnOK.Text = "ตกลง";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FrmModelEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 327);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmModelEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FrmModelEntry_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboBreakType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEngModelName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboModelType;
        private System.Windows.Forms.ComboBox cboGearType;
        private System.Windows.Forms.ComboBox cboGasolineType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBrandCode;
        private System.Windows.Forms.TextBox txtThaiModelName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBrandName;
        private System.Windows.Forms.TextBox txtModelCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private FarPoint.Win.Input.FpInteger fpiEngineCC;
        private FarPoint.Win.Input.FpInteger fpiNoOfSeat;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cboVendor;
        private System.Windows.Forms.Label label11;
    }
}