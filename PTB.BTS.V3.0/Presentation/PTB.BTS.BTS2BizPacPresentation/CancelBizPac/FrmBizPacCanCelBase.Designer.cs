namespace PTB.BTS.BTS2BizPacPresentation.CancelBizPac
{
    partial class FrmBizPacCancelBase
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnDeSelectAll = new System.Windows.Forms.Button();
            this.lblFormName = new System.Windows.Forms.Label();
            this.gpbSelectData = new System.Windows.Forms.GroupBox();
            this.btnShowData = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.gpbSelectCheck = new System.Windows.Forms.GroupBox();
            this.cboSelectCheck = new System.Windows.Forms.ComboBox();
            this.lblSelectName = new System.Windows.Forms.Label();
            this.colEntityKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDocNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaidTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTaxInvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTaxInvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectCheck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBizPacConnect)).BeginInit();
            this.gpbSelectData.SuspendLayout();
            this.gpbSelectCheck.SuspendLayout();
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
            this.colTaxInvoiceDate,
            this.SelectCheck});
            this.dtgBizPacConnect.Location = new System.Drawing.Point(10, 120);
            this.dtgBizPacConnect.Name = "dtgBizPacConnect";
            this.dtgBizPacConnect.RowHeadersWidth = 23;
            this.dtgBizPacConnect.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtgBizPacConnect.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgBizPacConnect.Size = new System.Drawing.Size(1010, 160);
            this.dtgBizPacConnect.TabIndex = 99;
            this.dtgBizPacConnect.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.Location = new System.Drawing.Point(425, 358);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel Connect";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClose.Location = new System.Drawing.Point(531, 358);
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
            this.btnSelectAll.Location = new System.Drawing.Point(12, 358);
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
            this.btnDeSelectAll.Location = new System.Drawing.Point(93, 358);
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
            // gpbSelectData
            // 
            this.gpbSelectData.Controls.Add(this.btnShowData);
            this.gpbSelectData.Controls.Add(this.label3);
            this.gpbSelectData.Controls.Add(this.dtpDateTo);
            this.gpbSelectData.Controls.Add(this.dtpDateFrom);
            this.gpbSelectData.Controls.Add(this.label1);
            this.gpbSelectData.Location = new System.Drawing.Point(16, 56);
            this.gpbSelectData.Name = "gpbSelectData";
            this.gpbSelectData.Size = new System.Drawing.Size(480, 56);
            this.gpbSelectData.TabIndex = 100;
            this.gpbSelectData.TabStop = false;
            this.gpbSelectData.Text = "เงื่อนไขการแสดงข้อมูล";
            // 
            // btnShowData
            // 
            this.btnShowData.Location = new System.Drawing.Point(392, 22);
            this.btnShowData.Name = "btnShowData";
            this.btnShowData.Size = new System.Drawing.Size(75, 23);
            this.btnShowData.TabIndex = 101;
            this.btnShowData.Text = "ดูข้อมูล";
            this.btnShowData.UseVisualStyleBackColor = true;
            this.btnShowData.Click += new System.EventHandler(this.btnShowData_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(249, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "-";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTo.Location = new System.Drawing.Point(272, 23);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(88, 20);
            this.dtpDateTo.TabIndex = 2;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFrom.Location = new System.Drawing.Point(152, 23);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(88, 20);
            this.dtpDateFrom.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ช่วงเวลาการถ่ายโอนข้อมูล";
            // 
            // gpbSelectCheck
            // 
            this.gpbSelectCheck.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.gpbSelectCheck.Controls.Add(this.cboSelectCheck);
            this.gpbSelectCheck.Controls.Add(this.lblSelectName);
            this.gpbSelectCheck.Location = new System.Drawing.Point(8, 288);
            this.gpbSelectCheck.Name = "gpbSelectCheck";
            this.gpbSelectCheck.Size = new System.Drawing.Size(408, 64);
            this.gpbSelectCheck.TabIndex = 111;
            this.gpbSelectCheck.TabStop = false;
            this.gpbSelectCheck.Text = "รูปแบบการเลือกข้อมูล";
            this.gpbSelectCheck.Visible = false;
            // 
            // cboSelectCheck
            // 
            this.cboSelectCheck.FormattingEnabled = true;
            this.cboSelectCheck.Location = new System.Drawing.Point(64, 24);
            this.cboSelectCheck.Name = "cboSelectCheck";
            this.cboSelectCheck.Size = new System.Drawing.Size(328, 21);
            this.cboSelectCheck.TabIndex = 106;
            // 
            // lblSelectName
            // 
            this.lblSelectName.AutoSize = true;
            this.lblSelectName.Location = new System.Drawing.Point(8, 28);
            this.lblSelectName.Name = "lblSelectName";
            this.lblSelectName.Size = new System.Drawing.Size(42, 13);
            this.lblSelectName.TabIndex = 109;
            this.lblSelectName.Text = "BLANK";
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
            // SelectCheck
            // 
            this.SelectCheck.HeaderText = "SelectCheck";
            this.SelectCheck.Name = "SelectCheck";
            this.SelectCheck.ReadOnly = true;
            this.SelectCheck.Visible = false;
            // 
            // FrmBizPacCancelBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1030, 394);
            this.Controls.Add(this.gpbSelectCheck);
            this.Controls.Add(this.gpbSelectData);
            this.Controls.Add(this.lblFormName);
            this.Controls.Add(this.btnDeSelectAll);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dtgBizPacConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmBizPacCancelBase";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmBizPacCancelBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgBizPacConnect)).EndInit();
            this.gpbSelectData.ResumeLayout(false);
            this.gpbSelectData.PerformLayout();
            this.gpbSelectCheck.ResumeLayout(false);
            this.gpbSelectCheck.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClose;
        protected internal System.Windows.Forms.Button btnSelectAll;
        protected internal System.Windows.Forms.Button btnDeSelectAll;
        protected internal System.Windows.Forms.Label lblFormName;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        protected internal System.Windows.Forms.DateTimePicker dtpDateFrom;
        protected internal System.Windows.Forms.GroupBox gpbSelectData;
        protected internal System.Windows.Forms.Button btnShowData;
        protected internal System.Windows.Forms.GroupBox gpbSelectCheck;
        protected internal System.Windows.Forms.ComboBox cboSelectCheck;
        protected internal System.Windows.Forms.Label lblSelectName;
        protected internal System.Windows.Forms.DataGridView dtgBizPacConnect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntityKey;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaidTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTaxInvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTaxInvoiceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SelectCheck;


    }
}
