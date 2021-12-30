namespace Presentation.ContractGUI
{
    partial class FrmAttachmentList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgAttachmentList = new System.Windows.Forms.DataGridView();
            this.colNo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colAttachmentNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContractType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlateNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKindOfContract = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAttachmentList)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgAttachmentList
            // 
            this.dtgAttachmentList.AllowUserToAddRows = false;
            this.dtgAttachmentList.AllowUserToDeleteRows = false;
            this.dtgAttachmentList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgAttachmentList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgAttachmentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAttachmentList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNo,
            this.colAttachmentNo,
            this.colContractType,
            this.colPlateNo,
            this.colCustomer,
            this.colStartDate,
            this.colEndDate,
            this.colKindOfContract});
            this.dtgAttachmentList.Location = new System.Drawing.Point(12, 12);
            this.dtgAttachmentList.Name = "dtgAttachmentList";
            this.dtgAttachmentList.RowHeadersWidth = 23;
            this.dtgAttachmentList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgAttachmentList.Size = new System.Drawing.Size(880, 245);
            this.dtgAttachmentList.TabIndex = 4;
            // 
            // colNo
            // 
            this.colNo.HeaderText = "เลือก";
            this.colNo.Name = "colNo";
            this.colNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colNo.Width = 35;
            // 
            // colAttachmentNo
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colAttachmentNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.colAttachmentNo.HeaderText = "เลขที่สัญญา";
            this.colAttachmentNo.Name = "colAttachmentNo";
            this.colAttachmentNo.ReadOnly = true;
            this.colAttachmentNo.Width = 90;
            // 
            // colContractType
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colContractType.DefaultCellStyle = dataGridViewCellStyle3;
            this.colContractType.HeaderText = "ประเภทสัญญา";
            this.colContractType.Name = "colContractType";
            this.colContractType.ReadOnly = true;
            this.colContractType.Width = 150;
            // 
            // colPlateNo
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colPlateNo.DefaultCellStyle = dataGridViewCellStyle4;
            this.colPlateNo.HeaderText = "ทะเบียนรถ";
            this.colPlateNo.Name = "colPlateNo";
            this.colPlateNo.ReadOnly = true;
            this.colPlateNo.Width = 110;
            // 
            // colCustomer
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCustomer.DefaultCellStyle = dataGridViewCellStyle5;
            this.colCustomer.HeaderText = "ลูกค้า";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.ReadOnly = true;
            this.colCustomer.Width = 110;
            // 
            // colStartDate
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "d";
            this.colStartDate.DefaultCellStyle = dataGridViewCellStyle6;
            this.colStartDate.HeaderText = "วันที่เริ่มต้นสัญญา";
            this.colStartDate.Name = "colStartDate";
            this.colStartDate.ReadOnly = true;
            this.colStartDate.Width = 120;
            // 
            // colEndDate
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "d";
            this.colEndDate.DefaultCellStyle = dataGridViewCellStyle7;
            this.colEndDate.HeaderText = "วันที่สิ้นสุดสัญญา";
            this.colEndDate.Name = "colEndDate";
            this.colEndDate.ReadOnly = true;
            this.colEndDate.Width = 120;
            // 
            // colKindOfContract
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colKindOfContract.DefaultCellStyle = dataGridViewCellStyle8;
            this.colKindOfContract.HeaderText = "ชนิดสัญญา";
            this.colKindOfContract.Name = "colKindOfContract";
            this.colKindOfContract.ReadOnly = true;
            this.colKindOfContract.Width = 120;
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(12, 272);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(137, 17);
            this.chkSelectAll.TabIndex = 7;
            this.chkSelectAll.Text = "Select All / Deselect All";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExit.Location = new System.Drawing.Point(421, 291);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "ยกเลิก";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnConfirm.Location = new System.Drawing.Point(340, 291);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 8;
            this.btnConfirm.Text = "ตกลง";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // FrmAttachmentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 326);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.dtgAttachmentList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmAttachmentList";
            this.Text = "รายการเอกสารสัญญา";
            this.Load += new System.EventHandler(this.FrmAttachmentList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgAttachmentList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgAttachmentList;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAttachmentNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContractType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlateNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKindOfContract;
    }
}