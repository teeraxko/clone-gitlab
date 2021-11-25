namespace Presentation.VehicleGUI.InsuranceTypeOneGUI
{
    partial class FrmCreateInsuranceTypeOne
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
            this.gpbInsuranceTypeOne = new System.Windows.Forms.GroupBox();
            this.btnShowData = new System.Windows.Forms.Button();
            this.cboInsuranceCompany = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboEndDate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dtgInsuranceTypeOne = new System.Windows.Forms.DataGridView();
            this.ctmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mniUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.mniDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddVehicle = new System.Windows.Forms.Button();
            this.EntityKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PolicyNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalVehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InchargeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InchargeTelNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpbInsuranceTypeOne.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgInsuranceTypeOne)).BeginInit();
            this.ctmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbInsuranceTypeOne
            // 
            this.gpbInsuranceTypeOne.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpbInsuranceTypeOne.Controls.Add(this.btnShowData);
            this.gpbInsuranceTypeOne.Controls.Add(this.cboInsuranceCompany);
            this.gpbInsuranceTypeOne.Controls.Add(this.label2);
            this.gpbInsuranceTypeOne.Controls.Add(this.cboEndDate);
            this.gpbInsuranceTypeOne.Controls.Add(this.label1);
            this.gpbInsuranceTypeOne.Location = new System.Drawing.Point(8, 8);
            this.gpbInsuranceTypeOne.Name = "gpbInsuranceTypeOne";
            this.gpbInsuranceTypeOne.Size = new System.Drawing.Size(856, 56);
            this.gpbInsuranceTypeOne.TabIndex = 0;
            this.gpbInsuranceTypeOne.TabStop = false;
            // 
            // btnShowData
            // 
            this.btnShowData.Location = new System.Drawing.Point(576, 17);
            this.btnShowData.Name = "btnShowData";
            this.btnShowData.Size = new System.Drawing.Size(75, 23);
            this.btnShowData.TabIndex = 4;
            this.btnShowData.Text = "ดูข้อมูล";
            this.btnShowData.UseVisualStyleBackColor = true;
            this.btnShowData.Click += new System.EventHandler(this.btnShowData_Click);
            // 
            // cboInsuranceCompany
            // 
            this.cboInsuranceCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInsuranceCompany.FormattingEnabled = true;
            this.cboInsuranceCompany.Location = new System.Drawing.Point(320, 17);
            this.cboInsuranceCompany.Name = "cboInsuranceCompany";
            this.cboInsuranceCompany.Size = new System.Drawing.Size(224, 23);
            this.cboInsuranceCompany.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(248, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "บริษัทประกัน";
            // 
            // cboEndDate
            // 
            this.cboEndDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEndDate.FormattingEnabled = true;
            this.cboEndDate.Location = new System.Drawing.Point(144, 17);
            this.cboEndDate.Name = "cboEndDate";
            this.cboEndDate.Size = new System.Drawing.Size(72, 23);
            this.cboEndDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "ปีที่สิ้นสุดของกรมธรรม์";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAdd.Location = new System.Drawing.Point(320, 315);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "เพิ่ม";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnUpdate.Location = new System.Drawing.Point(401, 315);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "แก้ไข";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDelete.Location = new System.Drawing.Point(482, 315);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "ลบ";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dtgInsuranceTypeOne
            // 
            this.dtgInsuranceTypeOne.AllowUserToAddRows = false;
            this.dtgInsuranceTypeOne.AllowUserToDeleteRows = false;
            this.dtgInsuranceTypeOne.AllowUserToResizeRows = false;
            this.dtgInsuranceTypeOne.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgInsuranceTypeOne.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgInsuranceTypeOne.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EntityKey,
            this.PolicyNo,
            this.StartDate,
            this.EndDate,
            this.TotalVehicle,
            this.InchargeName,
            this.InchargeTelNo});
            this.dtgInsuranceTypeOne.Location = new System.Drawing.Point(11, 72);
            this.dtgInsuranceTypeOne.MultiSelect = false;
            this.dtgInsuranceTypeOne.Name = "dtgInsuranceTypeOne";
            this.dtgInsuranceTypeOne.ReadOnly = true;
            this.dtgInsuranceTypeOne.RowHeadersWidth = 23;
            this.dtgInsuranceTypeOne.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtgInsuranceTypeOne.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgInsuranceTypeOne.Size = new System.Drawing.Size(856, 224);
            this.dtgInsuranceTypeOne.TabIndex = 10;
            this.dtgInsuranceTypeOne.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgInsuranceTypeOne_CellDoubleClick);
            // 
            // ctmMenu
            // 
            this.ctmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniAdd,
            this.mniUpdate,
            this.mniDelete});
            this.ctmMenu.Name = "ctmMenu";
            this.ctmMenu.Size = new System.Drawing.Size(102, 70);
            // 
            // mniAdd
            // 
            this.mniAdd.Name = "mniAdd";
            this.mniAdd.Size = new System.Drawing.Size(101, 22);
            this.mniAdd.Text = "เพิ่ม";
            this.mniAdd.Click += new System.EventHandler(this.mniAdd_Click);
            // 
            // mniUpdate
            // 
            this.mniUpdate.Name = "mniUpdate";
            this.mniUpdate.Size = new System.Drawing.Size(101, 22);
            this.mniUpdate.Text = "แก้ไข";
            this.mniUpdate.Click += new System.EventHandler(this.mniUpdate_Click);
            // 
            // mniDelete
            // 
            this.mniDelete.Name = "mniDelete";
            this.mniDelete.Size = new System.Drawing.Size(101, 22);
            this.mniDelete.Text = "ลบ";
            this.mniDelete.Click += new System.EventHandler(this.mniDelete_Click);
            // 
            // btnAddVehicle
            // 
            this.btnAddVehicle.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAddVehicle.Location = new System.Drawing.Point(736, 315);
            this.btnAddVehicle.Name = "btnAddVehicle";
            this.btnAddVehicle.Size = new System.Drawing.Size(128, 23);
            this.btnAddVehicle.TabIndex = 12;
            this.btnAddVehicle.Text = "เพิ่มรถเข้ากรมธรรม์";
            this.btnAddVehicle.UseVisualStyleBackColor = true;
            this.btnAddVehicle.Click += new System.EventHandler(this.btnAddVehicle_Click);
            // 
            // EntityKey
            // 
            this.EntityKey.HeaderText = "EntityKey";
            this.EntityKey.Name = "EntityKey";
            this.EntityKey.ReadOnly = true;
            this.EntityKey.Visible = false;
            // 
            // PolicyNo
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PolicyNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.PolicyNo.HeaderText = "เลขที่กรมธรรม์";
            this.PolicyNo.Name = "PolicyNo";
            this.PolicyNo.ReadOnly = true;
            this.PolicyNo.Width = 150;
            // 
            // StartDate
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.StartDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.StartDate.HeaderText = "วันที่เริ่มต้น";
            this.StartDate.Name = "StartDate";
            this.StartDate.ReadOnly = true;
            // 
            // EndDate
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.EndDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.EndDate.HeaderText = "วันที่สิ้นสุด";
            this.EndDate.Name = "EndDate";
            this.EndDate.ReadOnly = true;
            // 
            // TotalVehicle
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = "0";
            this.TotalVehicle.DefaultCellStyle = dataGridViewCellStyle5;
            this.TotalVehicle.HeaderText = "จำนวนรถ";
            this.TotalVehicle.Name = "TotalVehicle";
            this.TotalVehicle.ReadOnly = true;
            this.TotalVehicle.Width = 60;
            // 
            // InchargeName
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.InchargeName.DefaultCellStyle = dataGridViewCellStyle6;
            this.InchargeName.HeaderText = "ชื่อเจ้าหน้าที่";
            this.InchargeName.Name = "InchargeName";
            this.InchargeName.ReadOnly = true;
            this.InchargeName.Width = 220;
            // 
            // InchargeTelNo
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.InchargeTelNo.DefaultCellStyle = dataGridViewCellStyle7;
            this.InchargeTelNo.HeaderText = "โทรศัพท์";
            this.InchargeTelNo.Name = "InchargeTelNo";
            this.InchargeTelNo.ReadOnly = true;
            this.InchargeTelNo.Width = 180;
            // 
            // FrmCreateInsuranceTypeOne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(877, 357);
            this.ContextMenuStrip = this.ctmMenu;
            this.Controls.Add(this.dtgInsuranceTypeOne);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnAddVehicle);
            this.Controls.Add(this.gpbInsuranceTypeOne);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmCreateInsuranceTypeOne";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmCreateInsuranceTypeOne_Load);
            this.gpbInsuranceTypeOne.ResumeLayout(false);
            this.gpbInsuranceTypeOne.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgInsuranceTypeOne)).EndInit();
            this.ctmMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbInsuranceTypeOne;
        private System.Windows.Forms.ComboBox cboEndDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboInsuranceCompany;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnShowData;
        private System.Windows.Forms.DataGridView dtgInsuranceTypeOne;
        private System.Windows.Forms.ContextMenuStrip ctmMenu;
        private System.Windows.Forms.ToolStripMenuItem mniAdd;
        private System.Windows.Forms.ToolStripMenuItem mniUpdate;
        private System.Windows.Forms.ToolStripMenuItem mniDelete;
        private System.Windows.Forms.Button btnAddVehicle;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntityKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn PolicyNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalVehicle;
        private System.Windows.Forms.DataGridViewTextBoxColumn InchargeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn InchargeTelNo;
    }
}
