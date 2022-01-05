namespace Presentation.ContractGUI
{
    partial class FrmContractAttachmentList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvAttachmentList = new System.Windows.Forms.DataGridView();
            this.colEntityKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAttachmentNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKindOfContract = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttachmentList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAttachmentList
            // 
            this.dgvAttachmentList.AllowUserToAddRows = false;
            this.dgvAttachmentList.AllowUserToDeleteRows = false;
            this.dgvAttachmentList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAttachmentList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvAttachmentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttachmentList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEntityKey,
            this.colAttachmentNo,
            this.colCustomer,
            this.colKindOfContract});
            this.dgvAttachmentList.Location = new System.Drawing.Point(12, 12);
            this.dgvAttachmentList.MultiSelect = false;
            this.dgvAttachmentList.Name = "dgvAttachmentList";
            this.dgvAttachmentList.RowHeadersWidth = 23;
            this.dgvAttachmentList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAttachmentList.Size = new System.Drawing.Size(533, 300);
            this.dgvAttachmentList.TabIndex = 4;
            this.dgvAttachmentList.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvAttachmentList_RowStateChanged);
            // 
            // colEntityKey
            // 
            this.colEntityKey.HeaderText = "EntityKey";
            this.colEntityKey.Name = "colEntityKey";
            this.colEntityKey.Visible = false;
            // 
            // colAttachmentNo
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colAttachmentNo.DefaultCellStyle = dataGridViewCellStyle6;
            this.colAttachmentNo.HeaderText = "เลขที่เอกสารแนบ";
            this.colAttachmentNo.Name = "colAttachmentNo";
            this.colAttachmentNo.ReadOnly = true;
            this.colAttachmentNo.Width = 150;
            // 
            // colCustomer
            // 
            this.colCustomer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCustomer.DefaultCellStyle = dataGridViewCellStyle7;
            this.colCustomer.HeaderText = "ลูกค้า";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.ReadOnly = true;
            // 
            // colKindOfContract
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colKindOfContract.DefaultCellStyle = dataGridViewCellStyle8;
            this.colKindOfContract.HeaderText = "ชนิดรถ";
            this.colKindOfContract.Name = "colKindOfContract";
            this.colKindOfContract.ReadOnly = true;
            this.colKindOfContract.Width = 120;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExit.Location = new System.Drawing.Point(272, 318);
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
            this.btnConfirm.Location = new System.Drawing.Point(191, 318);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 8;
            this.btnConfirm.Text = "ตกลง";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // FrmContractAttachmentList
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(557, 353);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.dgvAttachmentList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmContractAttachmentList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "รายการเอกสารสัญญา";
            this.Load += new System.EventHandler(this.FrmContractAttachmentList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttachmentList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAttachmentList;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntityKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAttachmentNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKindOfContract;
    }
}