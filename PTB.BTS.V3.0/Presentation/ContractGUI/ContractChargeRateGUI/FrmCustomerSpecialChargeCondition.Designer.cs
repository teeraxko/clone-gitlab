namespace Presentation.ContractGUI.ContractChargeRateGUI
{
    partial class FrmCustomerSpecialChargeCondition
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dtgSpecialAdjust = new System.Windows.Forms.DataGridView();
            this.ctmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mniUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.mniDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.colEntityKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmployee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContractNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpecialAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSpecialAdjust)).BeginInit();
            this.ctmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDelete.Location = new System.Drawing.Point(527, 410);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(74, 23);
            this.btnDelete.TabIndex = 25;
            this.btnDelete.Text = "ลบ";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnUpdate.Location = new System.Drawing.Point(446, 410);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 24;
            this.btnUpdate.Text = "แก้ไข";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAdd.Location = new System.Drawing.Point(365, 410);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(76, 23);
            this.btnAdd.TabIndex = 23;
            this.btnAdd.Text = "เพิ่ม";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dtgSpecialAdjust
            // 
            this.dtgSpecialAdjust.AllowUserToAddRows = false;
            this.dtgSpecialAdjust.AllowUserToDeleteRows = false;
            this.dtgSpecialAdjust.AllowUserToResizeRows = false;
            this.dtgSpecialAdjust.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgSpecialAdjust.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgSpecialAdjust.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEntityKey,
            this.colEmployee,
            this.colPosition,
            this.colContractNo,
            this.colStartDate,
            this.colEndDate,
            this.colCustomer,
            this.colTelAmount,
            this.colSpecialAmount});
            this.dtgSpecialAdjust.ContextMenuStrip = this.ctmMenu;
            this.dtgSpecialAdjust.Location = new System.Drawing.Point(13, 8);
            this.dtgSpecialAdjust.MultiSelect = false;
            this.dtgSpecialAdjust.Name = "dtgSpecialAdjust";
            this.dtgSpecialAdjust.RowHeadersWidth = 23;
            this.dtgSpecialAdjust.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSpecialAdjust.Size = new System.Drawing.Size(941, 386);
            this.dtgSpecialAdjust.TabIndex = 22;
            this.dtgSpecialAdjust.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgSpecialAdjust_CellDoubleClick);
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
            // colEntityKey
            // 
            this.colEntityKey.HeaderText = "EntityKey";
            this.colEntityKey.Name = "colEntityKey";
            this.colEntityKey.ReadOnly = true;
            this.colEntityKey.Visible = false;
            // 
            // colEmployee
            // 
            this.colEmployee.HeaderText = "พนักงาน";
            this.colEmployee.Name = "colEmployee";
            this.colEmployee.ReadOnly = true;
            this.colEmployee.Width = 200;
            // 
            // colPosition
            // 
            this.colPosition.HeaderText = "ตำแหน่ง";
            this.colPosition.Name = "colPosition";
            this.colPosition.ReadOnly = true;
            // 
            // colContractNo
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colContractNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.colContractNo.HeaderText = "เลขที่สัญญา";
            this.colContractNo.Name = "colContractNo";
            this.colContractNo.ReadOnly = true;
            // 
            // colStartDate
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.colStartDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.colStartDate.HeaderText = "วันที่เริ่มต้น";
            this.colStartDate.Name = "colStartDate";
            this.colStartDate.ReadOnly = true;
            // 
            // colEndDate
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.colEndDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.colEndDate.HeaderText = "วันที่สิ้นสุด";
            this.colEndDate.Name = "colEndDate";
            this.colEndDate.ReadOnly = true;
            // 
            // colCustomer
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCustomer.DefaultCellStyle = dataGridViewCellStyle5;
            this.colCustomer.HeaderText = "ลูกค้า";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.ReadOnly = true;
            this.colCustomer.Width = 70;
            // 
            // colTelAmount
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.colTelAmount.DefaultCellStyle = dataGridViewCellStyle6;
            this.colTelAmount.HeaderText = "ค่าโทรศัพท์";
            this.colTelAmount.Name = "colTelAmount";
            this.colTelAmount.ReadOnly = true;
            this.colTelAmount.Width = 110;
            // 
            // colSpecialAmount
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.colSpecialAmount.DefaultCellStyle = dataGridViewCellStyle7;
            this.colSpecialAmount.HeaderText = "ค่าใช่จ่ายพิเศษ";
            this.colSpecialAmount.Name = "colSpecialAmount";
            this.colSpecialAmount.ReadOnly = true;
            this.colSpecialAmount.Width = 110;
            // 
            // FrmCustomerSpecialChargeCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 445);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dtgSpecialAdjust);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmCustomerSpecialChargeCondition";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmCustomerSpecialChargeCondition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSpecialAdjust)).EndInit();
            this.ctmMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dtgSpecialAdjust;
        private System.Windows.Forms.ContextMenuStrip ctmMenu;
        private System.Windows.Forms.ToolStripMenuItem mniAdd;
        private System.Windows.Forms.ToolStripMenuItem mniUpdate;
        private System.Windows.Forms.ToolStripMenuItem mniDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntityKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContractNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpecialAmount;
    }
}