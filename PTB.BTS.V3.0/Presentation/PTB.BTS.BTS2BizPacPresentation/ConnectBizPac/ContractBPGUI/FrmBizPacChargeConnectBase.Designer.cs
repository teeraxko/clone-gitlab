namespace PTB.BTS.BTS2BizPacPresentation.ConnectBizPac
{
    partial class FrmBizPacChargeConnectBase
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
            this.lblFormName = new System.Windows.Forms.Label();
            this.btnDeSelectAll = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.dtgBizPacConnect = new System.Windows.Forms.DataGridView();
            this.colEntityKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDocNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaidTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTaxInvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTaxInvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.gpbSelect = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBizPacConnect)).BeginInit();
            this.gpbSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFormName
            // 
            this.lblFormName.AutoSize = true;
            this.lblFormName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblFormName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFormName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblFormName.ForeColor = System.Drawing.Color.Red;
            this.lblFormName.Location = new System.Drawing.Point(15, 13);
            this.lblFormName.Name = "lblFormName";
            this.lblFormName.Size = new System.Drawing.Size(137, 37);
            this.lblFormName.TabIndex = 104;
            this.lblFormName.Text = "Form name";
            this.lblFormName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFormName.UseCompatibleTextRendering = true;
            // 
            // btnDeSelectAll
            // 
            this.btnDeSelectAll.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDeSelectAll.Location = new System.Drawing.Point(89, 56);
            this.btnDeSelectAll.Name = "btnDeSelectAll";
            this.btnDeSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnDeSelectAll.TabIndex = 103;
            this.btnDeSelectAll.Text = "Deselect";
            this.btnDeSelectAll.UseVisualStyleBackColor = true;
            this.btnDeSelectAll.Click += new System.EventHandler(this.btnDeSelectAll_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSelectAll.Location = new System.Drawing.Point(8, 56);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll.TabIndex = 102;
            this.btnSelectAll.Text = "Select";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClose.Location = new System.Drawing.Point(521, 270);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 101;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnConnect.Location = new System.Drawing.Point(433, 270);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 100;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
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
            this.colTaxInvoiceDate,
            this.CustomerCode,
            this.CheckValue});
            this.dtgBizPacConnect.Location = new System.Drawing.Point(9, 72);
            this.dtgBizPacConnect.Name = "dtgBizPacConnect";
            this.dtgBizPacConnect.RowHeadersWidth = 23;
            this.dtgBizPacConnect.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtgBizPacConnect.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgBizPacConnect.Size = new System.Drawing.Size(1010, 123);
            this.dtgBizPacConnect.TabIndex = 105;
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
            // CustomerCode
            // 
            this.CustomerCode.HeaderText = "CustomerCode";
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.ReadOnly = true;
            this.CustomerCode.Visible = false;
            // 
            // CheckValue
            // 
            this.CheckValue.HeaderText = "CheckValue";
            this.CheckValue.Name = "CheckValue";
            this.CheckValue.ReadOnly = true;
            this.CheckValue.Visible = false;
            // 
            // cboCustomer
            // 
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(56, 24);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(296, 21);
            this.cboCustomer.TabIndex = 106;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(8, 28);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(45, 13);
            this.lblCustomer.TabIndex = 109;
            this.lblCustomer.Text = "ชื่อลูกค้า";
            // 
            // gpbSelect
            // 
            this.gpbSelect.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.gpbSelect.Controls.Add(this.cboCustomer);
            this.gpbSelect.Controls.Add(this.lblCustomer);
            this.gpbSelect.Controls.Add(this.btnSelectAll);
            this.gpbSelect.Controls.Add(this.btnDeSelectAll);
            this.gpbSelect.Location = new System.Drawing.Point(8, 203);
            this.gpbSelect.Name = "gpbSelect";
            this.gpbSelect.Size = new System.Drawing.Size(360, 90);
            this.gpbSelect.TabIndex = 110;
            this.gpbSelect.TabStop = false;
            this.gpbSelect.Text = "รูปแบบการเลือกข้อมูล";
            // 
            // FrmBizPacChargeConnectBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1028, 307);
            this.Controls.Add(this.gpbSelect);
            this.Controls.Add(this.lblFormName);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.dtgBizPacConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmBizPacChargeConnectBase";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmBizPacChargeConnectBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgBizPacConnect)).EndInit();
            this.gpbSelect.ResumeLayout(false);
            this.gpbSelect.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected internal System.Windows.Forms.Label lblFormName;
        protected internal System.Windows.Forms.Button btnDeSelectAll;
        protected internal System.Windows.Forms.Button btnSelectAll;
        protected internal System.Windows.Forms.Button btnClose;
        protected internal System.Windows.Forms.Button btnConnect;
        protected internal System.Windows.Forms.DataGridView dtgBizPacConnect;
        protected internal System.Windows.Forms.ComboBox cboCustomer;
        protected internal System.Windows.Forms.Label lblCustomer;
        protected internal System.Windows.Forms.GroupBox gpbSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntityKey;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaidTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTaxInvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTaxInvoiceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckValue;
    }
}
