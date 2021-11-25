namespace PTB.PIS.Welfare.WindowsApp.BizPacGUI {
    partial class FrmMedicalAidNoAttBizPac {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdData = new System.Windows.Forms.DataGridView();
            this.colChk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDisease = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHospital = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdmitDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActualAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAppliedAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlGrid.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.grdData);
            this.pnlGrid.Margin = new System.Windows.Forms.Padding(4);
            this.pnlGrid.Size = new System.Drawing.Size(937, 381);
            // 
            // pnlBtn
            // 
            this.pnlBtn.Location = new System.Drawing.Point(0, 437);
            this.pnlBtn.Margin = new System.Windows.Forms.Padding(4);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpPaymentDate);
            this.groupBox1.Controls.SetChildIndex(this.dtpDateFrom, 0);
            this.groupBox1.Controls.SetChildIndex(this.dtpPaymentDate, 0);
            this.groupBox1.Controls.SetChildIndex(this.label5, 0);
            this.groupBox1.Controls.SetChildIndex(this.dtpDateTo, 0);
            this.groupBox1.Controls.SetChildIndex(this.btnRetiveData, 0);
            // 
            // grdData
            // 
            this.grdData.AllowUserToAddRows = false;
            this.grdData.AllowUserToDeleteRows = false;
            this.grdData.AllowUserToResizeRows = false;
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChk,
            this.colCreateDate,
            this.colEmp,
            this.colType,
            this.colFor,
            this.colDisease,
            this.colHospital,
            this.colAdmitDate,
            this.colActualAmount,
            this.colAppliedAmount});
            this.grdData.Location = new System.Drawing.Point(0, 0);
            this.grdData.MultiSelect = false;
            this.grdData.Name = "grdData";
            this.grdData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdData.RowTemplate.Height = 24;
            this.grdData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdData.Size = new System.Drawing.Size(936, 378);
            this.grdData.TabIndex = 25;
            // 
            // colChk
            // 
            this.colChk.HeaderText = "";
            this.colChk.Name = "colChk";
            this.colChk.Width = 30;
            // 
            // colCreateDate
            // 
            this.colCreateDate.HeaderText = "วันที่เบิก";
            this.colCreateDate.Name = "colCreateDate";
            this.colCreateDate.ReadOnly = true;
            this.colCreateDate.Width = 80;
            // 
            // colEmp
            // 
            this.colEmp.HeaderText = "พนักงาน";
            this.colEmp.Name = "colEmp";
            this.colEmp.ReadOnly = true;
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
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.colFor.DefaultCellStyle = dataGridViewCellStyle7;
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
            this.colAdmitDate.Width = 130;
            // 
            // colActualAmount
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colActualAmount.DefaultCellStyle = dataGridViewCellStyle8;
            this.colActualAmount.HeaderText = "ค่ารักษาตามจริง";
            this.colActualAmount.Name = "colActualAmount";
            this.colActualAmount.ReadOnly = true;
            this.colActualAmount.Width = 120;
            // 
            // colAppliedAmount
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colAppliedAmount.DefaultCellStyle = dataGridViewCellStyle9;
            this.colAppliedAmount.HeaderText = "ค่ารักษาที่ได้ตามสิทธิ์";
            this.colAppliedAmount.Name = "colAppliedAmount";
            this.colAppliedAmount.ReadOnly = true;
            this.colAppliedAmount.Width = 130;
            // 
            // dtpPaymentDate
            // 
            this.dtpPaymentDate.CustomFormat = "dd/MM/yyyy";
            this.dtpPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPaymentDate.Location = new System.Drawing.Point(493, 20);
            this.dtpPaymentDate.Name = "dtpPaymentDate";
            this.dtpPaymentDate.Size = new System.Drawing.Size(86, 20);
            this.dtpPaymentDate.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(409, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "วันที่บันทึกบัญชี";
            // 
            // FrmMedicalAidNoAttBizPac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(937, 487);
            this.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.Name = "FrmMedicalAidNoAttBizPac";
            this.pnlGrid.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdData;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colChk;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDisease;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHospital;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdmitDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActualAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAppliedAmount;
        private System.Windows.Forms.DateTimePicker dtpPaymentDate;
        private System.Windows.Forms.Label label5;

    }
}
