namespace PTB.BTS.BTS2BizPacPresentation
{
    partial class FrmBizPacConnectBase
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
            this.dtgBizPacConnect = new System.Windows.Forms.DataGridView();
            this.colEntityKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDocNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaidTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTaxInvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTaxInvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnDeSelectAll = new System.Windows.Forms.Button();
            this.lblFormName = new System.Windows.Forms.Label();
            this.gpbConnectDate = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDocDate = new System.Windows.Forms.DateTimePicker();
            this.gpbDateDetail = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDateDetail = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBizPacConnect)).BeginInit();
            this.gpbConnectDate.SuspendLayout();
            this.gpbDateDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgBizPacConnect
            // 
            this.dtgBizPacConnect.AllowUserToAddRows = false;
            this.dtgBizPacConnect.AllowUserToDeleteRows = false;
            this.dtgBizPacConnect.AllowUserToResizeRows = false;
            this.dtgBizPacConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgBizPacConnect.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgBizPacConnect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgBizPacConnect.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEntityKey,
            this.colStatus,
            this.colDocNo,
            this.colPaidTo,
            this.colRemark,
            this.colAmount,
            this.colTaxInvoiceNo,
            this.colTaxInvoiceDate});
            this.dtgBizPacConnect.Location = new System.Drawing.Point(10, 128);
            this.dtgBizPacConnect.Name = "dtgBizPacConnect";
            this.dtgBizPacConnect.RowHeadersWidth = 23;
            this.dtgBizPacConnect.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtgBizPacConnect.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgBizPacConnect.Size = new System.Drawing.Size(1010, 112);
            this.dtgBizPacConnect.TabIndex = 99;
            this.dtgBizPacConnect.TabStop = false;
            // 
            // colEntityKey
            // 
            this.colEntityKey.HeaderText = "EntityKey";
            this.colEntityKey.Name = "colEntityKey";
            this.colEntityKey.ReadOnly = true;
            this.colEntityKey.Visible = false;
            // 
            // colStatus
            // 
            this.colStatus.FalseValue = "0";
            this.colStatus.HeaderText = "";
            this.colStatus.IndeterminateValue = "0";
            this.colStatus.Name = "colStatus";
            this.colStatus.TrueValue = "1";
            this.colStatus.Width = 30;
            // 
            // colDocNo
            // 
            this.colDocNo.HeaderText = "DocNo";
            this.colDocNo.Name = "colDocNo";
            this.colDocNo.ReadOnly = true;
            this.colDocNo.Width = 140;
            // 
            // colPaidTo
            // 
            this.colPaidTo.HeaderText = "PaidTo";
            this.colPaidTo.Name = "colPaidTo";
            this.colPaidTo.ReadOnly = true;
            this.colPaidTo.Width = 240;
            // 
            // colRemark
            // 
            this.colRemark.HeaderText = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.ReadOnly = true;
            this.colRemark.Width = 260;
            // 
            // colAmount
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.colAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.colAmount.HeaderText = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Width = 70;
            // 
            // colTaxInvoiceNo
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTaxInvoiceNo.DefaultCellStyle = dataGridViewCellStyle3;
            this.colTaxInvoiceNo.HeaderText = "TaxInvoiceNo";
            this.colTaxInvoiceNo.Name = "colTaxInvoiceNo";
            this.colTaxInvoiceNo.ReadOnly = true;
            this.colTaxInvoiceNo.Width = 110;
            // 
            // colTaxInvoiceDate
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTaxInvoiceDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.colTaxInvoiceDate.HeaderText = "TaxInvoiceDate";
            this.colTaxInvoiceDate.Name = "colTaxInvoiceDate";
            this.colTaxInvoiceDate.ReadOnly = true;
            this.colTaxInvoiceDate.Width = 110;
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnConnect.Location = new System.Drawing.Point(434, 257);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClose.Location = new System.Drawing.Point(522, 257);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSelectAll.Location = new System.Drawing.Point(12, 257);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll.TabIndex = 3;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnDeSelectAll
            // 
            this.btnDeSelectAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDeSelectAll.Location = new System.Drawing.Point(93, 257);
            this.btnDeSelectAll.Name = "btnDeSelectAll";
            this.btnDeSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnDeSelectAll.TabIndex = 4;
            this.btnDeSelectAll.Text = "Deselect All";
            this.btnDeSelectAll.UseVisualStyleBackColor = true;
            this.btnDeSelectAll.Click += new System.EventHandler(this.btnDeSelectAll_Click);
            // 
            // lblFormName
            // 
            this.lblFormName.AutoSize = true;
            this.lblFormName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblFormName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFormName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblFormName.ForeColor = System.Drawing.Color.Red;
            this.lblFormName.Location = new System.Drawing.Point(16, 16);
            this.lblFormName.Name = "lblFormName";
            this.lblFormName.Size = new System.Drawing.Size(137, 37);
            this.lblFormName.TabIndex = 5;
            this.lblFormName.Text = "Form name";
            this.lblFormName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFormName.UseCompatibleTextRendering = true;
            // 
            // gpbConnectDate
            // 
            this.gpbConnectDate.Controls.Add(this.label1);
            this.gpbConnectDate.Controls.Add(this.dtpDocDate);
            this.gpbConnectDate.Location = new System.Drawing.Point(16, 64);
            this.gpbConnectDate.Name = "gpbConnectDate";
            this.gpbConnectDate.Size = new System.Drawing.Size(232, 56);
            this.gpbConnectDate.TabIndex = 112;
            this.gpbConnectDate.TabStop = false;
            this.gpbConnectDate.Text = "��������´�ѹ���ѹ�֡�ѭ��";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "�ѹ���ѹ�֡�ѭ��";
            // 
            // dtpDocDate
            // 
            this.dtpDocDate.Checked = false;
            this.dtpDocDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDocDate.Location = new System.Drawing.Point(108, 20);
            this.dtpDocDate.Name = "dtpDocDate";
            this.dtpDocDate.ShowCheckBox = true;
            this.dtpDocDate.Size = new System.Drawing.Size(104, 20);
            this.dtpDocDate.TabIndex = 2;
            this.dtpDocDate.ValueChanged += new System.EventHandler(this.dtpDocDate_ValueChanged);
            // 
            // gpbDateDetail
            // 
            this.gpbDateDetail.Controls.Add(this.label2);
            this.gpbDateDetail.Controls.Add(this.dtpDateDetail);
            this.gpbDateDetail.Location = new System.Drawing.Point(256, 64);
            this.gpbDateDetail.Name = "gpbDateDetail";
            this.gpbDateDetail.Size = new System.Drawing.Size(272, 56);
            this.gpbDateDetail.TabIndex = 113;
            this.gpbDateDetail.TabStop = false;
            this.gpbDateDetail.Text = "��������´�ѹ�������͹������";
            this.gpbDateDetail.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "��������´�ѹ�������͹";
            // 
            // dtpDateDetail
            // 
            this.dtpDateDetail.Checked = false;
            this.dtpDateDetail.CustomFormat = "dd/MM/yyyy";
            this.dtpDateDetail.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateDetail.Location = new System.Drawing.Point(144, 20);
            this.dtpDateDetail.Name = "dtpDateDetail";
            this.dtpDateDetail.ShowCheckBox = true;
            this.dtpDateDetail.Size = new System.Drawing.Size(104, 20);
            this.dtpDateDetail.TabIndex = 2;
            // 
            // FrmBizPacConnectBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1030, 293);
            this.Controls.Add(this.gpbDateDetail);
            this.Controls.Add(this.gpbConnectDate);
            this.Controls.Add(this.lblFormName);
            this.Controls.Add(this.btnDeSelectAll);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.dtgBizPacConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmBizPacConnectBase";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmBizPacConnectBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgBizPacConnect)).EndInit();
            this.gpbConnectDate.ResumeLayout(false);
            this.gpbConnectDate.PerformLayout();
            this.gpbDateDetail.ResumeLayout(false);
            this.gpbDateDetail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.DataGridView dtgBizPacConnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnClose;
        protected internal System.Windows.Forms.Button btnSelectAll;
        protected internal System.Windows.Forms.Button btnDeSelectAll;
        protected internal System.Windows.Forms.Label lblFormName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntityKey;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaidTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTaxInvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTaxInvoiceDate;
        private System.Windows.Forms.GroupBox gpbConnectDate;
        private System.Windows.Forms.Label label1;
        protected internal System.Windows.Forms.DateTimePicker dtpDocDate;
        private System.Windows.Forms.Label label2;
        protected internal System.Windows.Forms.DateTimePicker dtpDateDetail;
        protected internal System.Windows.Forms.GroupBox gpbDateDetail;


    }
}
