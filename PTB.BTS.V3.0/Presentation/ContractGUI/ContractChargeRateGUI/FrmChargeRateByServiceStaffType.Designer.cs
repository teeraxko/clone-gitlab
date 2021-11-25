namespace Presentation.ContractGUI.ContractChargeRateGUI
{
    partial class FrmChargeRateByServiceStaffType
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.mniAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mniUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.dtgChargeRateServiceStaff = new System.Windows.Forms.DataGridView();
            this.ctmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.EntityKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DriverStatus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.OTARate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OTBRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OTCRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AbsenceDeduction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DayFar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OvernightRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxiRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinLeaveDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgChargeRateServiceStaff)).BeginInit();
            this.ctmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDelete.Location = new System.Drawing.Point(559, 212);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(74, 23);
            this.btnDelete.TabIndex = 22;
            this.btnDelete.Text = "ลบ";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnUpdate.Location = new System.Drawing.Point(478, 212);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 21;
            this.btnUpdate.Text = "แก้ไข";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAdd.Location = new System.Drawing.Point(397, 212);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(76, 23);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Text = "เพิ่ม";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // mniAdd
            // 
            this.mniAdd.Name = "mniAdd";
            this.mniAdd.Size = new System.Drawing.Size(77, 22);
            this.mniAdd.Text = "เพิ่ม";
            this.mniAdd.Click += new System.EventHandler(this.mniAdd_Click);
            // 
            // mniUpdate
            // 
            this.mniUpdate.Name = "mniUpdate";
            this.mniUpdate.Size = new System.Drawing.Size(77, 22);
            this.mniUpdate.Text = "แก้ไข";
            this.mniUpdate.Click += new System.EventHandler(this.mniUpdate_Click);
            // 
            // dtgChargeRateServiceStaff
            // 
            this.dtgChargeRateServiceStaff.AllowUserToAddRows = false;
            this.dtgChargeRateServiceStaff.AllowUserToDeleteRows = false;
            this.dtgChargeRateServiceStaff.AllowUserToResizeColumns = false;
            this.dtgChargeRateServiceStaff.AllowUserToResizeRows = false;
            this.dtgChargeRateServiceStaff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgChargeRateServiceStaff.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgChargeRateServiceStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgChargeRateServiceStaff.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EntityKey,
            this.ContractNo,
            this.CustomerName,
            this.DriverStatus,
            this.OTARate,
            this.OTBRate,
            this.OTCRate,
            this.AbsenceDeduction,
            this.DayFar,
            this.OvernightRate,
            this.TaxiRate,
            this.MinLeaveDays,
            this.Column1});
            this.dtgChargeRateServiceStaff.ContextMenuStrip = this.ctmMenu;
            this.dtgChargeRateServiceStaff.Location = new System.Drawing.Point(14, 8);
            this.dtgChargeRateServiceStaff.MultiSelect = false;
            this.dtgChargeRateServiceStaff.Name = "dtgChargeRateServiceStaff";
            this.dtgChargeRateServiceStaff.ReadOnly = true;
            this.dtgChargeRateServiceStaff.RowHeadersWidth = 23;
            this.dtgChargeRateServiceStaff.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtgChargeRateServiceStaff.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgChargeRateServiceStaff.Size = new System.Drawing.Size(1002, 188);
            this.dtgChargeRateServiceStaff.TabIndex = 19;
            this.dtgChargeRateServiceStaff.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgChargeRateServiceStaff_CellDoubleClick);
            // 
            // ctmMenu
            // 
            this.ctmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniAdd,
            this.mniUpdate,
            this.mniDelete});
            this.ctmMenu.Name = "ctmMenu";
            this.ctmMenu.ShowImageMargin = false;
            this.ctmMenu.Size = new System.Drawing.Size(78, 70);
            // 
            // mniDelete
            // 
            this.mniDelete.Name = "mniDelete";
            this.mniDelete.Size = new System.Drawing.Size(77, 22);
            this.mniDelete.Text = "ลบ";
            this.mniDelete.Click += new System.EventHandler(this.mniDelete_Click);
            // 
            // EntityKey
            // 
            this.EntityKey.HeaderText = "EntityKey";
            this.EntityKey.Name = "EntityKey";
            this.EntityKey.ReadOnly = true;
            this.EntityKey.Visible = false;
            // 
            // ContractNo
            // 
            this.ContractNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ContractNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.ContractNo.HeaderText = "ประเภทพนักงาน";
            this.ContractNo.Name = "ContractNo";
            this.ContractNo.ReadOnly = true;
            this.ContractNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ContractNo.Width = 110;
            // 
            // CustomerName
            // 
            this.CustomerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CustomerName.HeaderText = "ลูกค้า";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            this.CustomerName.Width = 57;
            // 
            // DriverStatus
            // 
            this.DriverStatus.HeaderText = "เฉพาะคนขับรถ";
            this.DriverStatus.Name = "DriverStatus";
            this.DriverStatus.ReadOnly = true;
            this.DriverStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DriverStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // OTARate
            // 
            this.OTARate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.OTARate.DefaultCellStyle = dataGridViewCellStyle3;
            this.OTARate.HeaderText = "OTA";
            this.OTARate.Name = "OTARate";
            this.OTARate.ReadOnly = true;
            this.OTARate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.OTARate.Width = 55;
            // 
            // OTBRate
            // 
            this.OTBRate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.OTBRate.DefaultCellStyle = dataGridViewCellStyle4;
            this.OTBRate.HeaderText = "OTB";
            this.OTBRate.Name = "OTBRate";
            this.OTBRate.ReadOnly = true;
            this.OTBRate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.OTBRate.Width = 56;
            // 
            // OTCRate
            // 
            this.OTCRate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0";
            this.OTCRate.DefaultCellStyle = dataGridViewCellStyle5;
            this.OTCRate.HeaderText = "OTC";
            this.OTCRate.Name = "OTCRate";
            this.OTCRate.ReadOnly = true;
            this.OTCRate.Width = 56;
            // 
            // AbsenceDeduction
            // 
            this.AbsenceDeduction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = "0";
            this.AbsenceDeduction.DefaultCellStyle = dataGridViewCellStyle6;
            this.AbsenceDeduction.HeaderText = "AbsenceDeduc";
            this.AbsenceDeduction.Name = "AbsenceDeduction";
            this.AbsenceDeduction.ReadOnly = true;
            this.AbsenceDeduction.Width = 115;
            // 
            // DayFar
            // 
            this.DayFar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = "0";
            this.DayFar.DefaultCellStyle = dataGridViewCellStyle7;
            this.DayFar.HeaderText = "DayFar";
            this.DayFar.Name = "DayFar";
            this.DayFar.ReadOnly = true;
            this.DayFar.Width = 71;
            // 
            // OvernightRate
            // 
            this.OvernightRate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.NullValue = "0";
            this.OvernightRate.DefaultCellStyle = dataGridViewCellStyle8;
            this.OvernightRate.HeaderText = "Overnight";
            this.OvernightRate.Name = "OvernightRate";
            this.OvernightRate.ReadOnly = true;
            this.OvernightRate.Width = 84;
            // 
            // TaxiRate
            // 
            this.TaxiRate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N0";
            dataGridViewCellStyle9.NullValue = "0";
            this.TaxiRate.DefaultCellStyle = dataGridViewCellStyle9;
            this.TaxiRate.HeaderText = "TaxiRate";
            this.TaxiRate.Name = "TaxiRate";
            this.TaxiRate.ReadOnly = true;
            this.TaxiRate.Width = 81;
            // 
            // MinLeaveDays
            // 
            this.MinLeaveDays.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N0";
            dataGridViewCellStyle10.NullValue = "0";
            this.MinLeaveDays.DefaultCellStyle = dataGridViewCellStyle10;
            this.MinLeaveDays.HeaderText = "MinLeave";
            this.MinLeaveDays.Name = "MinLeaveDays";
            this.MinLeaveDays.ReadOnly = true;
            this.MinLeaveDays.Width = 86;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            dataGridViewCellStyle11.NullValue = "0";
            this.Column1.DefaultCellStyle = dataGridViewCellStyle11;
            this.Column1.HeaderText = "MinHoliday";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 94;
            // 
            // FrmChargeRateByServiceStaffType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1030, 247);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dtgChargeRateServiceStaff);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmChargeRateByServiceStaffType";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmChargeRateByServiceStaffType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgChargeRateServiceStaff)).EndInit();
            this.ctmMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ToolStripMenuItem mniAdd;
        private System.Windows.Forms.ToolStripMenuItem mniUpdate;
        private System.Windows.Forms.DataGridView dtgChargeRateServiceStaff;
        private System.Windows.Forms.ContextMenuStrip ctmMenu;
        private System.Windows.Forms.ToolStripMenuItem mniDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntityKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DriverStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn OTARate;
        private System.Windows.Forms.DataGridViewTextBoxColumn OTBRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn OTCRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AbsenceDeduction;
        private System.Windows.Forms.DataGridViewTextBoxColumn DayFar;
        private System.Windows.Forms.DataGridViewTextBoxColumn OvernightRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxiRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinLeaveDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}
