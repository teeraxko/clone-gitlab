namespace Presentation.ContractGUI.ContractVDOGUI
{
    partial class FrmDepartmentAssignment
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDepartment = new System.Windows.Forms.DataGridView();
            this.colFrom_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTo_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHirer_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepartmentCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mniUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.mniDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gpbDeptAssign = new System.Windows.Forms.GroupBox();
            this.txtHirerName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancelEntryDate = new System.Windows.Forms.Button();
            this.btnSaveEntryData = new System.Windows.Forms.Button();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAssignModeTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gpbDetail = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartment)).BeginInit();
            this.ctmMenu.SuspendLayout();
            this.gpbDeptAssign.SuspendLayout();
            this.gpbDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDepartment
            // 
            this.dgvDepartment.AllowUserToAddRows = false;
            this.dgvDepartment.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDepartment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDepartment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFrom_Date,
            this.colTo_Date,
            this.colDepartment,
            this.colHirer_Name,
            this.DepartmentCode});
            this.dgvDepartment.ContextMenuStrip = this.ctmMenu;
            this.dgvDepartment.Location = new System.Drawing.Point(16, 19);
            this.dgvDepartment.MultiSelect = false;
            this.dgvDepartment.Name = "dgvDepartment";
            this.dgvDepartment.ReadOnly = true;
            this.dgvDepartment.RowHeadersWidth = 23;
            this.dgvDepartment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDepartment.Size = new System.Drawing.Size(440, 168);
            this.dgvDepartment.TabIndex = 0;
            this.dgvDepartment.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDepartment_CellDoubleClick);
            // 
            // colFrom_Date
            // 
            this.colFrom_Date.DataPropertyName = "From_Date";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = null;
            this.colFrom_Date.DefaultCellStyle = dataGridViewCellStyle2;
            this.colFrom_Date.HeaderText = "วันที่เริ่มต้น";
            this.colFrom_Date.Name = "colFrom_Date";
            this.colFrom_Date.ReadOnly = true;
            this.colFrom_Date.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colFrom_Date.Width = 90;
            // 
            // colTo_Date
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTo_Date.DefaultCellStyle = dataGridViewCellStyle3;
            this.colTo_Date.HeaderText = "วันที่สิ้นสุด";
            this.colTo_Date.Name = "colTo_Date";
            this.colTo_Date.ReadOnly = true;
            this.colTo_Date.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colTo_Date.Width = 90;
            // 
            // colDepartment
            // 
            this.colDepartment.HeaderText = "ฝ่ายลูกค้า";
            this.colDepartment.Name = "colDepartment";
            this.colDepartment.ReadOnly = true;
            this.colDepartment.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDepartment.Width = 80;
            // 
            // colHirer_Name
            // 
            this.colHirer_Name.HeaderText = "ผู้ใช้";
            this.colHirer_Name.Name = "colHirer_Name";
            this.colHirer_Name.ReadOnly = true;
            this.colHirer_Name.Width = 130;
            // 
            // DepartmentCode
            // 
            this.DepartmentCode.HeaderText = "DepartmentCode";
            this.DepartmentCode.Name = "DepartmentCode";
            this.DepartmentCode.ReadOnly = true;
            this.DepartmentCode.Visible = false;
            // 
            // ctmMenu
            // 
            this.ctmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniAdd,
            this.mniUpdate,
            this.mniDelete});
            this.ctmMenu.Name = "ctmMenu";
            this.ctmMenu.ShowImageMargin = false;
            this.ctmMenu.Size = new System.Drawing.Size(77, 70);
            // 
            // mniAdd
            // 
            this.mniAdd.Name = "mniAdd";
            this.mniAdd.Size = new System.Drawing.Size(76, 22);
            this.mniAdd.Text = "เพิ่ม";
            this.mniAdd.Click += new System.EventHandler(this.mniAdd_Click);
            // 
            // mniUpdate
            // 
            this.mniUpdate.Name = "mniUpdate";
            this.mniUpdate.Size = new System.Drawing.Size(76, 22);
            this.mniUpdate.Text = "แก้ไข";
            this.mniUpdate.Click += new System.EventHandler(this.mniUpdate_Click);
            // 
            // mniDelete
            // 
            this.mniDelete.Name = "mniDelete";
            this.mniDelete.Size = new System.Drawing.Size(76, 22);
            this.mniDelete.Text = "ลบ";
            this.mniDelete.Click += new System.EventHandler(this.mniDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClose.Location = new System.Drawing.Point(381, 229);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "ปิด";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.Location = new System.Drawing.Point(301, 229);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "บันทึก";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gpbDeptAssign
            // 
            this.gpbDeptAssign.Controls.Add(this.txtHirerName);
            this.gpbDeptAssign.Controls.Add(this.label5);
            this.gpbDeptAssign.Controls.Add(this.btnCancelEntryDate);
            this.gpbDeptAssign.Controls.Add(this.btnSaveEntryData);
            this.gpbDeptAssign.Controls.Add(this.dtpTo);
            this.gpbDeptAssign.Controls.Add(this.dtpFrom);
            this.gpbDeptAssign.Controls.Add(this.cboDepartment);
            this.gpbDeptAssign.Controls.Add(this.label3);
            this.gpbDeptAssign.Controls.Add(this.label2);
            this.gpbDeptAssign.Controls.Add(this.lblAssignModeTitle);
            this.gpbDeptAssign.Controls.Add(this.label1);
            this.gpbDeptAssign.Location = new System.Drawing.Point(488, 8);
            this.gpbDeptAssign.Name = "gpbDeptAssign";
            this.gpbDeptAssign.Size = new System.Drawing.Size(256, 208);
            this.gpbDeptAssign.TabIndex = 5;
            this.gpbDeptAssign.TabStop = false;
            this.gpbDeptAssign.Text = "รายละเอียดการกำหนดฝ่ายลูกค้า";
            // 
            // txtHirerName
            // 
            this.txtHirerName.Location = new System.Drawing.Point(74, 133);
            this.txtHirerName.Name = "txtHirerName";
            this.txtHirerName.Size = new System.Drawing.Size(177, 20);
            this.txtHirerName.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "ผู้ใช้ :";
            // 
            // btnCancelEntryDate
            // 
            this.btnCancelEntryDate.Location = new System.Drawing.Point(133, 179);
            this.btnCancelEntryDate.Name = "btnCancelEntryDate";
            this.btnCancelEntryDate.Size = new System.Drawing.Size(56, 23);
            this.btnCancelEntryDate.TabIndex = 28;
            this.btnCancelEntryDate.Text = "ยกเลิก";
            this.btnCancelEntryDate.UseVisualStyleBackColor = true;
            this.btnCancelEntryDate.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveEntryData
            // 
            this.btnSaveEntryData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveEntryData.Location = new System.Drawing.Point(69, 179);
            this.btnSaveEntryData.Name = "btnSaveEntryData";
            this.btnSaveEntryData.Size = new System.Drawing.Size(56, 23);
            this.btnSaveEntryData.TabIndex = 27;
            this.btnSaveEntryData.Text = "ตกลง";
            this.btnSaveEntryData.UseVisualStyleBackColor = true;
            this.btnSaveEntryData.Click += new System.EventHandler(this.btnSaveEntryData_Click);
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd/MM/yyyy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(74, 80);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(104, 20);
            this.dtpTo.TabIndex = 26;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(74, 54);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(104, 20);
            this.dtpFrom.TabIndex = 25;
            // 
            // cboDepartment
            // 
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(74, 106);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(104, 21);
            this.cboDepartment.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "วันที่สิ้นสุด :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "วันที่เริ่มต้น :";
            // 
            // lblAssignModeTitle
            // 
            this.lblAssignModeTitle.AutoSize = true;
            this.lblAssignModeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblAssignModeTitle.Location = new System.Drawing.Point(9, 23);
            this.lblAssignModeTitle.Name = "lblAssignModeTitle";
            this.lblAssignModeTitle.Size = new System.Drawing.Size(104, 13);
            this.lblAssignModeTitle.TabIndex = 0;
            this.lblAssignModeTitle.Text = "เพิ่มฝ่ายลูกค้าใหม่";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ฝ่ายลูกค้า :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(16, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "*คลิ๊กขวาเพื่อทำการเพิ่ม แก้ไข ลบ ข้อมูล";
            // 
            // gpbDetail
            // 
            this.gpbDetail.Controls.Add(this.dgvDepartment);
            this.gpbDetail.Controls.Add(this.label4);
            this.gpbDetail.Location = new System.Drawing.Point(8, 8);
            this.gpbDetail.Name = "gpbDetail";
            this.gpbDetail.Size = new System.Drawing.Size(472, 208);
            this.gpbDetail.TabIndex = 7;
            this.gpbDetail.TabStop = false;
            this.gpbDetail.Text = "ข้อมูลฝ่ายลูกค้า";
            // 
            // FrmDepartmentAssignment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 266);
            this.Controls.Add(this.gpbDetail);
            this.Controls.Add(this.gpbDeptAssign);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Name = "FrmDepartmentAssignment";
            this.Text = "กำหนดฝ่ายลูกค้า";
            this.Load += new System.EventHandler(this.FrmDepartmentAssignment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartment)).EndInit();
            this.ctmMenu.ResumeLayout(false);
            this.gpbDeptAssign.ResumeLayout(false);
            this.gpbDeptAssign.PerformLayout();
            this.gpbDetail.ResumeLayout(false);
            this.gpbDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gpbDeptAssign;
        protected System.Windows.Forms.DateTimePicker dtpTo;
        protected System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancelEntryDate;
        private System.Windows.Forms.Button btnSaveEntryData;
        private System.Windows.Forms.ContextMenuStrip ctmMenu;
        private System.Windows.Forms.ToolStripMenuItem mniAdd;
        private System.Windows.Forms.ToolStripMenuItem mniUpdate;
        private System.Windows.Forms.ToolStripMenuItem mniDelete;
        private System.Windows.Forms.GroupBox gpbDetail;
        private System.Windows.Forms.TextBox txtHirerName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvDepartment;
        private System.Windows.Forms.Label lblAssignModeTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFrom_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTo_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHirer_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepartmentCode;
    }
}