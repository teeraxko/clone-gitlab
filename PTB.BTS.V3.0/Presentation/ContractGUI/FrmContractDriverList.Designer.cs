namespace Presentation.ContractGUI
{
    partial class FrmContractDriverList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dtgContractList = new System.Windows.Forms.DataGridView();
            this.entityKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contractStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contractNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceStaffType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.periodFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.periodTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kindOfContract = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgContractList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Location = new System.Drawing.Point(410, 468);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "ตกลง";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(498, 468);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dtgContractList
            // 
            this.dtgContractList.AllowUserToAddRows = false;
            this.dtgContractList.AllowUserToDeleteRows = false;
            this.dtgContractList.AllowUserToResizeColumns = false;
            this.dtgContractList.AllowUserToResizeRows = false;
            this.dtgContractList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgContractList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgContractList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgContractList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.entityKey,
            this.contractStatus,
            this.contractNo,
            this.employeeNo,
            this.serviceStaffType,
            this.customerDepartment,
            this.customerName,
            this.periodFrom,
            this.periodTo,
            this.kindOfContract});
            this.dtgContractList.Location = new System.Drawing.Point(13, 8);
            this.dtgContractList.MultiSelect = false;
            this.dtgContractList.Name = "dtgContractList";
            this.dtgContractList.ReadOnly = true;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgContractList.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dtgContractList.RowHeadersWidth = 25;
            this.dtgContractList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtgContractList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtgContractList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgContractList.Size = new System.Drawing.Size(957, 442);
            this.dtgContractList.TabIndex = 1;
            this.dtgContractList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgContractList_CellDoubleClick);
            this.dtgContractList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgContractList_CellContentClick);
            // 
            // entityKey
            // 
            this.entityKey.HeaderText = "entityKey";
            this.entityKey.Name = "entityKey";
            this.entityKey.ReadOnly = true;
            this.entityKey.Visible = false;
            // 
            // contractStatus
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.contractStatus.DefaultCellStyle = dataGridViewCellStyle2;
            this.contractStatus.HeaderText = "สถานะสัญญา";
            this.contractStatus.Name = "contractStatus";
            this.contractStatus.ReadOnly = true;
            this.contractStatus.Width = 70;
            // 
            // contractNo
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.contractNo.DefaultCellStyle = dataGridViewCellStyle3;
            this.contractNo.HeaderText = "เลขที่สัญญา";
            this.contractNo.Name = "contractNo";
            this.contractNo.ReadOnly = true;
            this.contractNo.Width = 90;
            // 
            // employeeNo
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.employeeNo.DefaultCellStyle = dataGridViewCellStyle4;
            this.employeeNo.HeaderText = "พนักงาน";
            this.employeeNo.Name = "employeeNo";
            this.employeeNo.ReadOnly = true;
            this.employeeNo.Width = 170;
            // 
            // serviceStaffType
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.serviceStaffType.DefaultCellStyle = dataGridViewCellStyle5;
            this.serviceStaffType.HeaderText = "ประเภทพนักงาน";
            this.serviceStaffType.Name = "serviceStaffType";
            this.serviceStaffType.ReadOnly = true;
            this.serviceStaffType.Width = 160;
            // 
            // customerDepartment
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.customerDepartment.DefaultCellStyle = dataGridViewCellStyle6;
            this.customerDepartment.HeaderText = "แผนก";
            this.customerDepartment.Name = "customerDepartment";
            this.customerDepartment.ReadOnly = true;
            this.customerDepartment.Width = 60;
            // 
            // customerName
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.customerName.DefaultCellStyle = dataGridViewCellStyle7;
            this.customerName.HeaderText = "ลูกค้า";
            this.customerName.Name = "customerName";
            this.customerName.ReadOnly = true;
            // 
            // periodFrom
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Format = "d";
            dataGridViewCellStyle8.NullValue = null;
            this.periodFrom.DefaultCellStyle = dataGridViewCellStyle8;
            this.periodFrom.HeaderText = "วันที่เริ่มต้น";
            this.periodFrom.Name = "periodFrom";
            this.periodFrom.ReadOnly = true;
            this.periodFrom.Width = 80;
            // 
            // periodTo
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Format = "d";
            dataGridViewCellStyle9.NullValue = null;
            this.periodTo.DefaultCellStyle = dataGridViewCellStyle9;
            this.periodTo.HeaderText = "วันที่สิ้นสุด";
            this.periodTo.Name = "periodTo";
            this.periodTo.ReadOnly = true;
            this.periodTo.Width = 80;
            // 
            // kindOfContract
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.kindOfContract.DefaultCellStyle = dataGridViewCellStyle10;
            this.kindOfContract.HeaderText = "ชนิดสัญญา";
            this.kindOfContract.Name = "kindOfContract";
            this.kindOfContract.ReadOnly = true;
            // 
            // FrmContractDriverList
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(983, 507);
            this.Controls.Add(this.dtgContractList);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FrmContractDriverList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "รายการเอกสารสัญญา";
            this.Load += new System.EventHandler(this.FrmContractDriverList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgContractList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dtgContractList;
        private System.Windows.Forms.DataGridViewTextBoxColumn entityKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn contractStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn contractNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceStaffType;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn periodFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn periodTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn kindOfContract;
    }
}