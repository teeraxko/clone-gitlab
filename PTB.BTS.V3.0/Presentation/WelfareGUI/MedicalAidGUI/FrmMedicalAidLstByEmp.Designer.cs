namespace PTB.PIS.Welfare.WindowsApp.MedicalAidGUI {
    partial class FrmMedicalAidLstByEmp {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdData = new System.Windows.Forms.DataGridView();
            this.colCreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDisease = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHospital = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdmitDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActualAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAppliedAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAtt = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colInsurancePaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpSelectYear = new System.Windows.Forms.DateTimePicker();
            this.lblSumActual = new System.Windows.Forms.Label();
            this.lblSumApplied = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gpbTotalAmount = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSumEmployee = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSumFamily = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSumCompPaid = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSumInsurance = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSumApplied = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSumActual = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pctEmployee)).BeginInit();
            this.pnlDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.gpbTotalAmount.SuspendLayout();
            this.SuspendLayout();
            // 
            // pctEmployee
            // 
            this.pctEmployee.Location = new System.Drawing.Point(897, 16);
            // 
            // pnlDetail
            // 
            this.pnlDetail.Controls.Add(this.label8);
            this.pnlDetail.Controls.Add(this.gpbTotalAmount);
            this.pnlDetail.Controls.Add(this.label1);
            this.pnlDetail.Controls.Add(this.dtpSelectYear);
            this.pnlDetail.Controls.Add(this.grdData);
            this.pnlDetail.Size = new System.Drawing.Size(1001, 401);
            this.pnlDetail.Controls.SetChildIndex(this.grdData, 0);
            this.pnlDetail.Controls.SetChildIndex(this.dtpSelectYear, 0);
            this.pnlDetail.Controls.SetChildIndex(this.label1, 0);
            this.pnlDetail.Controls.SetChildIndex(this.gpbTotalAmount, 0);
            this.pnlDetail.Controls.SetChildIndex(this.label8, 0);
            // 
            // grdData
            // 
            this.grdData.AllowUserToAddRows = false;
            this.grdData.AllowUserToDeleteRows = false;
            this.grdData.AllowUserToResizeRows = false;
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCreateDate,
            this.colType,
            this.colFor,
            this.colDisease,
            this.colHospital,
            this.colAdmitDate,
            this.colActualAmount,
            this.colAppliedAmount,
            this.colAtt,
            this.colInsurancePaid});
            this.grdData.Location = new System.Drawing.Point(8, 48);
            this.grdData.MultiSelect = false;
            this.grdData.Name = "grdData";
            this.grdData.ReadOnly = true;
            this.grdData.RowHeadersWidth = 23;
            this.grdData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdData.Size = new System.Drawing.Size(988, 113);
            this.grdData.TabIndex = 23;
            this.grdData.Sorted += new System.EventHandler(this.grdData_Sorted);
            this.grdData.DoubleClick += new System.EventHandler(this.grdData_DoubleClick);
            // 
            // colCreateDate
            // 
            this.colCreateDate.HeaderText = "วันที่เบิก";
            this.colCreateDate.Name = "colCreateDate";
            this.colCreateDate.ReadOnly = true;
            this.colCreateDate.Width = 80;
            // 
            // colType
            // 
            this.colType.HeaderText = "ประเภท";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Width = 70;
            // 
            // colFor
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.colFor.DefaultCellStyle = dataGridViewCellStyle5;
            this.colFor.HeaderText = "เพื่อ";
            this.colFor.Name = "colFor";
            this.colFor.ReadOnly = true;
            this.colFor.Width = 70;
            // 
            // colDisease
            // 
            this.colDisease.HeaderText = "โรค";
            this.colDisease.Name = "colDisease";
            this.colDisease.ReadOnly = true;
            this.colDisease.Width = 150;
            // 
            // colHospital
            // 
            this.colHospital.HeaderText = "โรงพยาบาล";
            this.colHospital.Name = "colHospital";
            this.colHospital.ReadOnly = true;
            // 
            // colAdmitDate
            // 
            this.colAdmitDate.HeaderText = "วันที่เข้ารับการรักษา";
            this.colAdmitDate.Name = "colAdmitDate";
            this.colAdmitDate.ReadOnly = true;
            this.colAdmitDate.Width = 120;
            // 
            // colActualAmount
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colActualAmount.DefaultCellStyle = dataGridViewCellStyle6;
            this.colActualAmount.HeaderText = "ค่ารักษาตามจริง";
            this.colActualAmount.Name = "colActualAmount";
            this.colActualAmount.ReadOnly = true;
            // 
            // colAppliedAmount
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colAppliedAmount.DefaultCellStyle = dataGridViewCellStyle7;
            this.colAppliedAmount.HeaderText = "ค่ารักษาตามสิทธิ์";
            this.colAppliedAmount.Name = "colAppliedAmount";
            this.colAppliedAmount.ReadOnly = true;
            // 
            // colAtt
            // 
            this.colAtt.HeaderText = "ใช้ใบส่งตัว";
            this.colAtt.Name = "colAtt";
            this.colAtt.ReadOnly = true;
            this.colAtt.Width = 70;
            // 
            // colInsurancePaid
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.colInsurancePaid.DefaultCellStyle = dataGridViewCellStyle8;
            this.colInsurancePaid.HeaderText = "ประกันสุขภาพจ่าย";
            this.colInsurancePaid.Name = "colInsurancePaid";
            this.colInsurancePaid.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(460, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "สำหรับปี";
            // 
            // dtpSelectYear
            // 
            this.dtpSelectYear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpSelectYear.CustomFormat = "yyyy";
            this.dtpSelectYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSelectYear.Location = new System.Drawing.Point(511, 12);
            this.dtpSelectYear.Name = "dtpSelectYear";
            this.dtpSelectYear.Size = new System.Drawing.Size(54, 20);
            this.dtpSelectYear.TabIndex = 27;
            this.dtpSelectYear.ValueChanged += new System.EventHandler(this.dtpSelectYear_ValueChanged);
            // 
            // lblSumActual
            // 
            this.lblSumActual.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblSumActual.AutoSize = true;
            this.lblSumActual.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblSumActual.Location = new System.Drawing.Point(107, 31);
            this.lblSumActual.Name = "lblSumActual";
            this.lblSumActual.Size = new System.Drawing.Size(138, 13);
            this.lblSumActual.TabIndex = 29;
            this.lblSumActual.Text = "รวมค่ารักษาพยาบาลตามจริง";
            this.lblSumActual.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSumApplied
            // 
            this.lblSumApplied.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblSumApplied.AutoSize = true;
            this.lblSumApplied.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblSumApplied.Location = new System.Drawing.Point(66, 60);
            this.lblSumApplied.Name = "lblSumApplied";
            this.lblSumApplied.Size = new System.Drawing.Size(179, 13);
            this.lblSumApplied.TabIndex = 30;
            this.lblSumApplied.Text = "รวมค่ารักษาพยาบาลที่เบิกได้ตามสิทธิ์";
            this.lblSumApplied.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(130, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "รวมค่ารักษาประกันจ่าย";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(116, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "รวมค่ารักษาสุทธิบริษัทจ่าย";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gpbTotalAmount
            // 
            this.gpbTotalAmount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.gpbTotalAmount.Controls.Add(this.label5);
            this.gpbTotalAmount.Controls.Add(this.txtSumEmployee);
            this.gpbTotalAmount.Controls.Add(this.label10);
            this.gpbTotalAmount.Controls.Add(this.txtSumFamily);
            this.gpbTotalAmount.Controls.Add(this.label13);
            this.gpbTotalAmount.Controls.Add(this.label14);
            this.gpbTotalAmount.Controls.Add(this.label11);
            this.gpbTotalAmount.Controls.Add(this.txtSumCompPaid);
            this.gpbTotalAmount.Controls.Add(this.label9);
            this.gpbTotalAmount.Controls.Add(this.txtSumInsurance);
            this.gpbTotalAmount.Controls.Add(this.label7);
            this.gpbTotalAmount.Controls.Add(this.txtSumApplied);
            this.gpbTotalAmount.Controls.Add(this.label6);
            this.gpbTotalAmount.Controls.Add(this.txtSumActual);
            this.gpbTotalAmount.Controls.Add(this.lblSumActual);
            this.gpbTotalAmount.Controls.Add(this.label3);
            this.gpbTotalAmount.Controls.Add(this.lblSumApplied);
            this.gpbTotalAmount.Controls.Add(this.label2);
            this.gpbTotalAmount.Location = new System.Drawing.Point(625, 169);
            this.gpbTotalAmount.Name = "gpbTotalAmount";
            this.gpbTotalAmount.Size = new System.Drawing.Size(370, 195);
            this.gpbTotalAmount.TabIndex = 33;
            this.gpbTotalAmount.TabStop = false;
            this.gpbTotalAmount.Text = "ค่าใช้จ่าย";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.Location = new System.Drawing.Point(329, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 46;
            this.label5.Text = "บาท";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSumEmployee
            // 
            this.txtSumEmployee.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtSumEmployee.BackColor = System.Drawing.Color.MistyRose;
            this.txtSumEmployee.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtSumEmployee.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtSumEmployee.Location = new System.Drawing.Point(251, 114);
            this.txtSumEmployee.Name = "txtSumEmployee";
            this.txtSumEmployee.Size = new System.Drawing.Size(74, 16);
            this.txtSumEmployee.TabIndex = 45;
            this.txtSumEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label10.Location = new System.Drawing.Point(329, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 13);
            this.label10.TabIndex = 44;
            this.label10.Text = "บาท";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSumFamily
            // 
            this.txtSumFamily.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtSumFamily.BackColor = System.Drawing.Color.MistyRose;
            this.txtSumFamily.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtSumFamily.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtSumFamily.Location = new System.Drawing.Point(251, 85);
            this.txtSumFamily.Name = "txtSumFamily";
            this.txtSumFamily.Size = new System.Drawing.Size(74, 16);
            this.txtSumFamily.TabIndex = 43;
            this.txtSumFamily.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label13.Location = new System.Drawing.Point(62, 87);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(184, 13);
            this.label13.TabIndex = 41;
            this.label13.Text = "ค่ารักษาพยาบาลที่เบิกได้ของครอบครัว";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label14.Location = new System.Drawing.Point(28, 116);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(218, 13);
            this.label14.TabIndex = 42;
            this.label14.Text = "ค่ารักษาพยาบาลที่เบิกได้ตามสิทธิของพนักงาน";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label11.Location = new System.Drawing.Point(329, 172);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 13);
            this.label11.TabIndex = 40;
            this.label11.Text = "บาท";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSumCompPaid
            // 
            this.txtSumCompPaid.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtSumCompPaid.BackColor = System.Drawing.Color.MistyRose;
            this.txtSumCompPaid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtSumCompPaid.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtSumCompPaid.Location = new System.Drawing.Point(251, 170);
            this.txtSumCompPaid.Name = "txtSumCompPaid";
            this.txtSumCompPaid.Size = new System.Drawing.Size(74, 16);
            this.txtSumCompPaid.TabIndex = 39;
            this.txtSumCompPaid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label9.Location = new System.Drawing.Point(329, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "บาท";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSumInsurance
            // 
            this.txtSumInsurance.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtSumInsurance.BackColor = System.Drawing.Color.MistyRose;
            this.txtSumInsurance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtSumInsurance.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtSumInsurance.Location = new System.Drawing.Point(251, 141);
            this.txtSumInsurance.Name = "txtSumInsurance";
            this.txtSumInsurance.Size = new System.Drawing.Size(74, 16);
            this.txtSumInsurance.TabIndex = 37;
            this.txtSumInsurance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.Location = new System.Drawing.Point(329, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "บาท";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSumApplied
            // 
            this.txtSumApplied.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtSumApplied.BackColor = System.Drawing.Color.MistyRose;
            this.txtSumApplied.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtSumApplied.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtSumApplied.Location = new System.Drawing.Point(251, 58);
            this.txtSumApplied.Name = "txtSumApplied";
            this.txtSumApplied.Size = new System.Drawing.Size(74, 16);
            this.txtSumApplied.TabIndex = 35;
            this.txtSumApplied.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.Location = new System.Drawing.Point(329, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "บาท";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSumActual
            // 
            this.txtSumActual.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtSumActual.BackColor = System.Drawing.Color.MistyRose;
            this.txtSumActual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtSumActual.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtSumActual.Location = new System.Drawing.Point(251, 29);
            this.txtSumActual.Name = "txtSumActual";
            this.txtSumActual.Size = new System.Drawing.Size(74, 16);
            this.txtSumActual.TabIndex = 33;
            this.txtSumActual.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label8.Location = new System.Drawing.Point(585, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(179, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Ex. 2017 (1 Apr 2017 - 31 Mar 2018)";
            // 
            // FrmMedicalAidLstByEmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1001, 529);
            this.Name = "FrmMedicalAidLstByEmp";
            this.Controls.SetChildIndex(this.pnlDetail, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pctEmployee)).EndInit();
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.gpbTotalAmount.ResumeLayout(false);
            this.gpbTotalAmount.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpSelectYear;
        private System.Windows.Forms.Label lblSumActual;
        private System.Windows.Forms.Label lblSumApplied;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gpbTotalAmount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label txtSumCompPaid;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label txtSumInsurance;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label txtSumApplied;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label txtSumActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDisease;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHospital;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdmitDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActualAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAppliedAmount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAtt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInsurancePaid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label txtSumEmployee;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label txtSumFamily;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label8;





    }
}
