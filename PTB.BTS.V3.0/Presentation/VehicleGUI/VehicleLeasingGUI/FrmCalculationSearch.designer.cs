namespace Presentation.VehicleGUI.VehicleLeasingGUI
{
    partial class FrmCalculationSearch
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
            this.gpbShowData = new System.Windows.Forms.GroupBox();
            this.cboModel = new System.Windows.Forms.ComboBox();
            this.cboBrand = new System.Windows.Forms.ComboBox();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.txtQuotationXXX = new System.Windows.Forms.TextBox();
            this.txtQuotationMM = new System.Windows.Forms.TextBox();
            this.txtQuotationYY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dtgVehicleCalculation = new System.Windows.Forms.DataGridView();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBrand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuotation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIssueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCalculationNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mniUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.mniDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEdit = new System.Windows.Forms.Button();
            this.gpbVehicleDetail = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPlateNoPrefix = new System.Windows.Forms.TextBox();
            this.txtPlateNoRunning = new System.Windows.Forms.TextBox();
            this.gpbCalculationList = new System.Windows.Forms.GroupBox();
            this.gpbShowData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVehicleCalculation)).BeginInit();
            this.ctmMenu.SuspendLayout();
            this.gpbVehicleDetail.SuspendLayout();
            this.gpbCalculationList.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbShowData
            // 
            this.gpbShowData.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpbShowData.Controls.Add(this.cboModel);
            this.gpbShowData.Controls.Add(this.cboBrand);
            this.gpbShowData.Controls.Add(this.cboCustomer);
            this.gpbShowData.Controls.Add(this.txtQuotationXXX);
            this.gpbShowData.Controls.Add(this.txtQuotationMM);
            this.gpbShowData.Controls.Add(this.txtQuotationYY);
            this.gpbShowData.Controls.Add(this.label2);
            this.gpbShowData.Controls.Add(this.btnSearch);
            this.gpbShowData.Controls.Add(this.label9);
            this.gpbShowData.Controls.Add(this.label8);
            this.gpbShowData.Controls.Add(this.label7);
            this.gpbShowData.Location = new System.Drawing.Point(14, 56);
            this.gpbShowData.Name = "gpbShowData";
            this.gpbShowData.Size = new System.Drawing.Size(668, 96);
            this.gpbShowData.TabIndex = 77;
            this.gpbShowData.TabStop = false;
            this.gpbShowData.Text = "Seacrh By Detail of Vehicle";
            // 
            // cboModel
            // 
            this.cboModel.DisplayMember = "Model_English_Name";
            this.cboModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModel.FormattingEnabled = true;
            this.cboModel.Location = new System.Drawing.Point(328, 53);
            this.cboModel.Name = "cboModel";
            this.cboModel.Size = new System.Drawing.Size(213, 21);
            this.cboModel.TabIndex = 11;
            this.cboModel.ValueMember = "Model_Code";
            // 
            // cboBrand
            // 
            this.cboBrand.DisplayMember = "Brand_English_Name";
            this.cboBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBrand.FormattingEnabled = true;
            this.cboBrand.Location = new System.Drawing.Point(88, 53);
            this.cboBrand.Name = "cboBrand";
            this.cboBrand.Size = new System.Drawing.Size(144, 21);
            this.cboBrand.TabIndex = 10;
            this.cboBrand.ValueMember = "Brand_Code";
            this.cboBrand.SelectedIndexChanged += new System.EventHandler(this.cboBrand_SelectedIndexChanged);
            // 
            // cboCustomer
            // 
            this.cboCustomer.DisplayMember = "English_Name";
            this.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(329, 21);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(289, 21);
            this.cboCustomer.TabIndex = 9;
            this.cboCustomer.ValueMember = "Customer_Code";
            // 
            // txtQuotationXXX
            // 
            this.txtQuotationXXX.Location = new System.Drawing.Point(199, 19);
            this.txtQuotationXXX.MaxLength = 3;
            this.txtQuotationXXX.Name = "txtQuotationXXX";
            this.txtQuotationXXX.Size = new System.Drawing.Size(30, 20);
            this.txtQuotationXXX.TabIndex = 8;
            this.txtQuotationXXX.DoubleClick += new System.EventHandler(this.txtQuotationXXX_DoubleClick);
            this.txtQuotationXXX.TextChanged += new System.EventHandler(this.txtQuotationXXX_TextChanged);
            this.txtQuotationXXX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuotationXXX_KeyPress);
            // 
            // txtQuotationMM
            // 
            this.txtQuotationMM.Location = new System.Drawing.Point(170, 19);
            this.txtQuotationMM.MaxLength = 2;
            this.txtQuotationMM.Name = "txtQuotationMM";
            this.txtQuotationMM.Size = new System.Drawing.Size(30, 20);
            this.txtQuotationMM.TabIndex = 7;
            this.txtQuotationMM.DoubleClick += new System.EventHandler(this.txtQuotationMM_DoubleClick);
            this.txtQuotationMM.TextChanged += new System.EventHandler(this.txtQuotationMM_TextChanged);
            this.txtQuotationMM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuotationMM_KeyPress);
            // 
            // txtQuotationYY
            // 
            this.txtQuotationYY.Location = new System.Drawing.Point(141, 19);
            this.txtQuotationYY.MaxLength = 2;
            this.txtQuotationYY.Name = "txtQuotationYY";
            this.txtQuotationYY.Size = new System.Drawing.Size(30, 20);
            this.txtQuotationYY.TabIndex = 6;
            this.txtQuotationYY.DoubleClick += new System.EventHandler(this.txtQuotationYY_DoubleClick);
            this.txtQuotationYY.TextChanged += new System.EventHandler(this.txtQuotationYY_TextChanged);
            this.txtQuotationYY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuotationYY_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 72;
            this.label2.Text = "Quotation #      PTB-Q-";
            // 
            // btnSearch
            // 
            this.btnSearch.ForeColor = System.Drawing.Color.Blue;
            this.btnSearch.Location = new System.Drawing.Point(552, 52);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "ค้นหา";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(285, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 65;
            this.label9.Text = "Model";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(48, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 64;
            this.label8.Text = "Brand";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(272, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 61;
            this.label7.Text = "Customer";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAdd.Location = new System.Drawing.Point(231, 367);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "เพิ่ม";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDelete.Location = new System.Drawing.Point(383, 367);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "ลบ";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dtgVehicleCalculation
            // 
            this.dtgVehicleCalculation.AllowUserToAddRows = false;
            this.dtgVehicleCalculation.AllowUserToDeleteRows = false;
            this.dtgVehicleCalculation.AllowUserToResizeRows = false;
            this.dtgVehicleCalculation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dtgVehicleCalculation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgVehicleCalculation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCustomer,
            this.colBrand,
            this.colModel,
            this.colColor,
            this.colQuotation,
            this.colIssueDate,
            this.colCalculationNo});
            this.dtgVehicleCalculation.ContextMenuStrip = this.ctmMenu;
            this.dtgVehicleCalculation.Location = new System.Drawing.Point(13, 24);
            this.dtgVehicleCalculation.Name = "dtgVehicleCalculation";
            this.dtgVehicleCalculation.ReadOnly = true;
            this.dtgVehicleCalculation.RowHeadersWidth = 23;
            this.dtgVehicleCalculation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgVehicleCalculation.Size = new System.Drawing.Size(643, 172);
            this.dtgVehicleCalculation.TabIndex = 13;
            this.dtgVehicleCalculation.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgVehicleCalculation_CellDoubleClick);
            // 
            // colCustomer
            // 
            this.colCustomer.HeaderText = "Customer";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.ReadOnly = true;
            this.colCustomer.Width = 150;
            // 
            // colBrand
            // 
            this.colBrand.HeaderText = "Brand";
            this.colBrand.Name = "colBrand";
            this.colBrand.ReadOnly = true;
            this.colBrand.Width = 110;
            // 
            // colModel
            // 
            this.colModel.HeaderText = "Model";
            this.colModel.Name = "colModel";
            this.colModel.ReadOnly = true;
            this.colModel.Width = 130;
            // 
            // colColor
            // 
            this.colColor.HeaderText = "Color";
            this.colColor.Name = "colColor";
            this.colColor.ReadOnly = true;
            this.colColor.Visible = false;
            this.colColor.Width = 110;
            // 
            // colQuotation
            // 
            this.colQuotation.HeaderText = "Quotation #";
            this.colQuotation.Name = "colQuotation";
            this.colQuotation.ReadOnly = true;
            // 
            // colIssueDate
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.colIssueDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.colIssueDate.HeaderText = "Issue Date";
            this.colIssueDate.Name = "colIssueDate";
            this.colIssueDate.ReadOnly = true;
            // 
            // colCalculationNo
            // 
            this.colCalculationNo.HeaderText = "CalculationNo";
            this.colCalculationNo.Name = "colCalculationNo";
            this.colCalculationNo.ReadOnly = true;
            this.colCalculationNo.Visible = false;
            // 
            // ctmMenu
            // 
            this.ctmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniAdd,
            this.mniUpdate,
            this.mniDelete});
            this.ctmMenu.Name = "ctmMenu";
            this.ctmMenu.Size = new System.Drawing.Size(103, 70);
            // 
            // mniAdd
            // 
            this.mniAdd.Name = "mniAdd";
            this.mniAdd.Size = new System.Drawing.Size(102, 22);
            this.mniAdd.Text = "เพิ่ม";
            this.mniAdd.Click += new System.EventHandler(this.mniAdd_Click);
            // 
            // mniUpdate
            // 
            this.mniUpdate.Name = "mniUpdate";
            this.mniUpdate.Size = new System.Drawing.Size(102, 22);
            this.mniUpdate.Text = "แก้ไข";
            this.mniUpdate.Click += new System.EventHandler(this.mniUpdate_Click);
            // 
            // mniDelete
            // 
            this.mniDelete.Name = "mniDelete";
            this.mniDelete.Size = new System.Drawing.Size(102, 22);
            this.mniDelete.Text = "ลบ";
            this.mniDelete.Click += new System.EventHandler(this.mniDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnEdit.Location = new System.Drawing.Point(307, 367);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "แก้ไข";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // gpbVehicleDetail
            // 
            this.gpbVehicleDetail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpbVehicleDetail.Controls.Add(this.label16);
            this.gpbVehicleDetail.Controls.Add(this.label15);
            this.gpbVehicleDetail.Controls.Add(this.txtPlateNoPrefix);
            this.gpbVehicleDetail.Controls.Add(this.txtPlateNoRunning);
            this.gpbVehicleDetail.Location = new System.Drawing.Point(14, 7);
            this.gpbVehicleDetail.Name = "gpbVehicleDetail";
            this.gpbVehicleDetail.Size = new System.Drawing.Size(668, 49);
            this.gpbVehicleDetail.TabIndex = 78;
            this.gpbVehicleDetail.TabStop = false;
            this.gpbVehicleDetail.Text = "Search By Vehicle";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(32, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 13);
            this.label16.TabIndex = 80;
            this.label16.Text = "Plate No.";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(144, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(10, 13);
            this.label15.TabIndex = 79;
            this.label15.Text = "-";
            // 
            // txtPlateNoPrefix
            // 
            this.txtPlateNoPrefix.Location = new System.Drawing.Point(99, 20);
            this.txtPlateNoPrefix.MaxLength = 3;
            this.txtPlateNoPrefix.Name = "txtPlateNoPrefix";
            this.txtPlateNoPrefix.Size = new System.Drawing.Size(37, 20);
            this.txtPlateNoPrefix.TabIndex = 77;
            this.txtPlateNoPrefix.DoubleClick += new System.EventHandler(this.txtPlateNoPrefix_DoubleClick);
            this.txtPlateNoPrefix.TextChanged += new System.EventHandler(this.txtPlateNoPrefix_TextChanged);
            // 
            // txtPlateNoRunning
            // 
            this.txtPlateNoRunning.Location = new System.Drawing.Point(160, 20);
            this.txtPlateNoRunning.MaxLength = 4;
            this.txtPlateNoRunning.Name = "txtPlateNoRunning";
            this.txtPlateNoRunning.Size = new System.Drawing.Size(44, 20);
            this.txtPlateNoRunning.TabIndex = 78;
            this.txtPlateNoRunning.DoubleClick += new System.EventHandler(this.txtPlateNoRunning_DoubleClick);
            this.txtPlateNoRunning.TextChanged += new System.EventHandler(this.txtPlateNoRunning_TextChanged);
            this.txtPlateNoRunning.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPlateNoRunning_KeyPress);
            // 
            // gpbCalculationList
            // 
            this.gpbCalculationList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.gpbCalculationList.Controls.Add(this.dtgVehicleCalculation);
            this.gpbCalculationList.Location = new System.Drawing.Point(14, 152);
            this.gpbCalculationList.Name = "gpbCalculationList";
            this.gpbCalculationList.Size = new System.Drawing.Size(668, 208);
            this.gpbCalculationList.TabIndex = 79;
            this.gpbCalculationList.TabStop = false;
            this.gpbCalculationList.Text = "Calculation List";
            // 
            // FrmCalculationSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 401);
            this.Controls.Add(this.gpbCalculationList);
            this.Controls.Add(this.gpbVehicleDetail);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.gpbShowData);
            this.Name = "FrmCalculationSearch";
            this.Text = "Leasing Calculation";
            this.Load += new System.EventHandler(this.FrmCalculationSearch_Load);
            this.gpbShowData.ResumeLayout(false);
            this.gpbShowData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVehicleCalculation)).EndInit();
            this.ctmMenu.ResumeLayout(false);
            this.gpbVehicleDetail.ResumeLayout(false);
            this.gpbVehicleDetail.PerformLayout();
            this.gpbCalculationList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbShowData;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dtgVehicleCalculation;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox txtQuotationXXX;
        private System.Windows.Forms.TextBox txtQuotationMM;
        private System.Windows.Forms.TextBox txtQuotationYY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip ctmMenu;
        private System.Windows.Forms.ToolStripMenuItem mniAdd;
        private System.Windows.Forms.ToolStripMenuItem mniUpdate;
        private System.Windows.Forms.ToolStripMenuItem mniDelete;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.ComboBox cboModel;
        private System.Windows.Forms.ComboBox cboBrand;
        private System.Windows.Forms.GroupBox gpbVehicleDetail;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtPlateNoPrefix;
        private System.Windows.Forms.TextBox txtPlateNoRunning;
        private System.Windows.Forms.GroupBox gpbCalculationList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuotation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIssueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCalculationNo;
    }
}