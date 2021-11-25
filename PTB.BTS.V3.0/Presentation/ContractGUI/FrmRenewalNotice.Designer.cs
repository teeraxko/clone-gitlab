namespace Presentation.ContractGUI
{
    partial class FrmRenewalNotice
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpEndDateTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnShow = new System.Windows.Forms.Button();
            this.dtpEndDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgView = new System.Windows.Forms.DataGridView();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colContractNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlateNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBrand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTISAuthorize = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.txtTISAuthorize);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpEndDateTo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnShow);
            this.groupBox1.Controls.Add(this.dtpEndDateFrom);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(194, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(495, 88);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Renewal Notice";
            // 
            // dtpEndDateTo
            // 
            this.dtpEndDateTo.CustomFormat = "MM/yyyy";
            this.dtpEndDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDateTo.Location = new System.Drawing.Point(311, 24);
            this.dtpEndDateTo.Name = "dtpEndDateTo";
            this.dtpEndDateTo.Size = new System.Drawing.Size(72, 20);
            this.dtpEndDateTo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "End of Contract To :";
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(400, 50);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(72, 24);
            this.btnShow.TabIndex = 2;
            this.btnShow.Text = "ดูข้อมูล";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // dtpEndDateFrom
            // 
            this.dtpEndDateFrom.CustomFormat = "MM/yyyy";
            this.dtpEndDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDateFrom.Location = new System.Drawing.Point(122, 24);
            this.dtpEndDateFrom.Name = "dtpEndDateFrom";
            this.dtpEndDateFrom.Size = new System.Drawing.Size(72, 20);
            this.dtpEndDateFrom.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "End of Contract From :";
            // 
            // dtgView
            // 
            this.dtgView.AllowUserToAddRows = false;
            this.dtgView.AllowUserToDeleteRows = false;
            this.dtgView.AllowUserToResizeRows = false;
            this.dtgView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelect,
            this.colContractNo,
            this.colStartDate,
            this.colEndDate,
            this.colCustomerName,
            this.colPlateNo,
            this.colBrand,
            this.colModel});
            this.dtgView.Location = new System.Drawing.Point(14, 104);
            this.dtgView.Name = "dtgView";
            this.dtgView.ReadOnly = true;
            this.dtgView.RowHeadersWidth = 23;
            this.dtgView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgView.Size = new System.Drawing.Size(854, 227);
            this.dtgView.TabIndex = 1;
            this.dtgView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgView_CellContentClick);
            // 
            // colSelect
            // 
            this.colSelect.FalseValue = "0";
            this.colSelect.HeaderText = "เลือก";
            this.colSelect.Name = "colSelect";
            this.colSelect.ReadOnly = true;
            this.colSelect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colSelect.TrueValue = "1";
            this.colSelect.Width = 40;
            // 
            // colContractNo
            // 
            this.colContractNo.HeaderText = "เลขที่สัญญา";
            this.colContractNo.Name = "colContractNo";
            this.colContractNo.ReadOnly = true;
            // 
            // colStartDate
            // 
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.colStartDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.colStartDate.HeaderText = "วันที่เริ่มต้นสัญญา";
            this.colStartDate.Name = "colStartDate";
            this.colStartDate.ReadOnly = true;
            this.colStartDate.Width = 115;
            // 
            // colEndDate
            // 
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.colEndDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.colEndDate.HeaderText = "วันที่สิ้นสุดสัญญา";
            this.colEndDate.Name = "colEndDate";
            this.colEndDate.ReadOnly = true;
            this.colEndDate.Width = 110;
            // 
            // colCustomerName
            // 
            this.colCustomerName.HeaderText = "ลูกค้า";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.ReadOnly = true;
            this.colCustomerName.Width = 120;
            // 
            // colPlateNo
            // 
            this.colPlateNo.HeaderText = "ทะเบียนรถ";
            this.colPlateNo.Name = "colPlateNo";
            this.colPlateNo.ReadOnly = true;
            // 
            // colBrand
            // 
            this.colBrand.HeaderText = "ยี่ห้อ";
            this.colBrand.Name = "colBrand";
            this.colBrand.ReadOnly = true;
            this.colBrand.Width = 120;
            // 
            // colModel
            // 
            this.colModel.HeaderText = "รุ่น";
            this.colModel.Name = "colModel";
            this.colModel.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "TIS Authorize Person :";
            // 
            // txtTISAuthorize
            // 
            this.txtTISAuthorize.Location = new System.Drawing.Point(122, 52);
            this.txtTISAuthorize.MaxLength = 150;
            this.txtTISAuthorize.Name = "txtTISAuthorize";
            this.txtTISAuthorize.Size = new System.Drawing.Size(262, 20);
            this.txtTISAuthorize.TabIndex = 6;
            // 
            // FrmRenewalNotice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 343);
            this.Controls.Add(this.dtgView);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmRenewalNotice";
            this.Text = "Renewal Notice";
            this.Load += new System.EventHandler(this.FrmRenewalNotice_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.DateTimePicker dtpEndDateFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgView;
        private System.Windows.Forms.DateTimePicker dtpEndDateTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContractNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlateNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModel;
        private System.Windows.Forms.TextBox txtTISAuthorize;
        private System.Windows.Forms.Label label3;
    }
}