namespace PTB.BTS.BTS2BizPacPresentation.ConnectBizPac
{
    partial class FrmBizPacRepairingConnectBase
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
            this.cboGarage = new System.Windows.Forms.ComboBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.gpbSelect = new System.Windows.Forms.GroupBox();
            this.gpbConnectDate = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpConnectDate = new System.Windows.Forms.DateTimePicker();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBizPacConnect)).BeginInit();
            this.gpbSelect.SuspendLayout();
            this.gpbConnectDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFormName
            // 
            this.lblFormName.Anchor = System.Windows.Forms.AnchorStyles.Top;
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
            this.btnDeSelectAll.Location = new System.Drawing.Point(88, 56);
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
            this.btnClose.Location = new System.Drawing.Point(521, 344);
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
            this.btnConnect.Location = new System.Drawing.Point(433, 344);
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
            this.dtgBizPacConnect.Location = new System.Drawing.Point(9, 120);
            this.dtgBizPacConnect.Name = "dtgBizPacConnect";
            this.dtgBizPacConnect.RowHeadersWidth = 23;
            this.dtgBizPacConnect.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtgBizPacConnect.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgBizPacConnect.Size = new System.Drawing.Size(1010, 149);
            this.dtgBizPacConnect.TabIndex = 105;
            this.dtgBizPacConnect.TabStop = false;
            this.dtgBizPacConnect.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBizPacConnect_CellValueChanged);
            this.dtgBizPacConnect.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtgBizPacConnect_CurrentCellDirtyStateChanged);
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
            // cboGarage
            // 
            this.cboGarage.FormattingEnabled = true;
            this.cboGarage.Location = new System.Drawing.Point(72, 24);
            this.cboGarage.Name = "cboGarage";
            this.cboGarage.Size = new System.Drawing.Size(320, 21);
            this.cboGarage.TabIndex = 106;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(8, 28);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(63, 13);
            this.lblCustomer.TabIndex = 109;
            this.lblCustomer.Text = "ชื่อศูนย์ซ่อม";
            // 
            // gpbSelect
            // 
            this.gpbSelect.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.gpbSelect.Controls.Add(this.cboGarage);
            this.gpbSelect.Controls.Add(this.lblCustomer);
            this.gpbSelect.Controls.Add(this.btnSelectAll);
            this.gpbSelect.Controls.Add(this.btnDeSelectAll);
            this.gpbSelect.Location = new System.Drawing.Point(8, 277);
            this.gpbSelect.Name = "gpbSelect";
            this.gpbSelect.Size = new System.Drawing.Size(400, 90);
            this.gpbSelect.TabIndex = 110;
            this.gpbSelect.TabStop = false;
            this.gpbSelect.Text = "รูปแบบการเลือกข้อมูล";
            // 
            // gpbConnectDate
            // 
            this.gpbConnectDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpbConnectDate.Controls.Add(this.label1);
            this.gpbConnectDate.Controls.Add(this.dtpConnectDate);
            this.gpbConnectDate.Location = new System.Drawing.Point(8, 56);
            this.gpbConnectDate.Name = "gpbConnectDate";
            this.gpbConnectDate.Size = new System.Drawing.Size(256, 56);
            this.gpbConnectDate.TabIndex = 111;
            this.gpbConnectDate.TabStop = false;
            this.gpbConnectDate.Text = "รายละเอียดการถ่ายโอนข้อมูล";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "วันที่ถ่ายโอนข้อมูล";
            // 
            // dtpConnectDate
            // 
            this.dtpConnectDate.Checked = false;
            this.dtpConnectDate.CustomFormat = "dd/MM/yyyy";
            this.dtpConnectDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpConnectDate.Location = new System.Drawing.Point(120, 20);
            this.dtpConnectDate.Name = "dtpConnectDate";
            this.dtpConnectDate.ShowCheckBox = true;
            this.dtpConnectDate.Size = new System.Drawing.Size(104, 20);
            this.dtpConnectDate.TabIndex = 2;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTotalAmount.BackColor = System.Drawing.Color.MistyRose;
            this.lblTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Black;
            this.lblTotalAmount.Location = new System.Drawing.Point(691, 272);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(80, 16);
            this.lblTotalAmount.TabIndex = 112;
            this.lblTotalAmount.Text = "0.00";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(561, 274);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 113;
            this.label2.Text = "Total Selected Amount :";
            // 
            // FrmBizPacRepairingConnectBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1028, 381);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.gpbConnectDate);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.gpbSelect);
            this.Controls.Add(this.lblFormName);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dtgBizPacConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmBizPacRepairingConnectBase";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmBizPacRepairingConnectBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgBizPacConnect)).EndInit();
            this.gpbSelect.ResumeLayout(false);
            this.gpbSelect.PerformLayout();
            this.gpbConnectDate.ResumeLayout(false);
            this.gpbConnectDate.PerformLayout();
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
        protected internal System.Windows.Forms.ComboBox cboGarage;
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
        private System.Windows.Forms.GroupBox gpbConnectDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpConnectDate;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label2;
    }
}
