namespace Presentation.VehicleGUI.VehicleLeasingGUI
{
    partial class FrmPurchaseOrderList
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
            this.txtPOXXX = new System.Windows.Forms.TextBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.txtPOMM = new System.Windows.Forms.TextBox();
            this.txtPOYY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gpbShowData = new System.Windows.Forms.GroupBox();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtgPO = new System.Windows.Forms.DataGridView();
            this.ctmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mniEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mniCancelPO = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCancelPO = new System.Windows.Forms.Button();
            this.gpbPODetail = new System.Windows.Forms.GroupBox();
            this.colKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIssueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBrand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContract = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpbShowData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPO)).BeginInit();
            this.ctmMenu.SuspendLayout();
            this.gpbPODetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPOXXX
            // 
            this.txtPOXXX.Location = new System.Drawing.Point(206, 32);
            this.txtPOXXX.MaxLength = 3;
            this.txtPOXXX.Name = "txtPOXXX";
            this.txtPOXXX.Size = new System.Drawing.Size(30, 20);
            this.txtPOXXX.TabIndex = 3;
            this.txtPOXXX.DoubleClick += new System.EventHandler(this.txtPOXXX_DoubleClick);
            this.txtPOXXX.TextChanged += new System.EventHandler(this.txtPOXXX_TextChanged);
            this.txtPOXXX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPOXXX_KeyPress);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnEdit.Location = new System.Drawing.Point(396, 392);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "แก้ไข";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // txtPOMM
            // 
            this.txtPOMM.Location = new System.Drawing.Point(177, 32);
            this.txtPOMM.MaxLength = 2;
            this.txtPOMM.Name = "txtPOMM";
            this.txtPOMM.Size = new System.Drawing.Size(30, 20);
            this.txtPOMM.TabIndex = 2;
            this.txtPOMM.DoubleClick += new System.EventHandler(this.txtPOMM_DoubleClick);
            this.txtPOMM.TextChanged += new System.EventHandler(this.txtPOMM_TextChanged);
            this.txtPOMM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPOMM_KeyPress);
            // 
            // txtPOYY
            // 
            this.txtPOYY.Location = new System.Drawing.Point(148, 32);
            this.txtPOYY.MaxLength = 2;
            this.txtPOYY.Name = "txtPOYY";
            this.txtPOYY.Size = new System.Drawing.Size(30, 20);
            this.txtPOYY.TabIndex = 1;
            this.txtPOYY.DoubleClick += new System.EventHandler(this.txtPOYY_DoubleClick);
            this.txtPOYY.TextChanged += new System.EventHandler(this.txtPOYY_TextChanged);
            this.txtPOYY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPOYY_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "PO #                  PTB-P-";
            // 
            // btnSearch
            // 
            this.btnSearch.ForeColor = System.Drawing.Color.Blue;
            this.btnSearch.Location = new System.Drawing.Point(243, 57);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "ค้นหา";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "PO  From Date";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAdd.Location = new System.Drawing.Point(315, 392);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "เพิ่ม";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gpbShowData
            // 
            this.gpbShowData.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpbShowData.Controls.Add(this.txtPOXXX);
            this.gpbShowData.Controls.Add(this.txtPOMM);
            this.gpbShowData.Controls.Add(this.txtPOYY);
            this.gpbShowData.Controls.Add(this.label2);
            this.gpbShowData.Controls.Add(this.btnSearch);
            this.gpbShowData.Controls.Add(this.label1);
            this.gpbShowData.Controls.Add(this.dtpFromDate);
            this.gpbShowData.Location = new System.Drawing.Point(264, 8);
            this.gpbShowData.Name = "gpbShowData";
            this.gpbShowData.Size = new System.Drawing.Size(333, 93);
            this.gpbShowData.TabIndex = 0;
            this.gpbShowData.TabStop = false;
            this.gpbShowData.Text = "Search Purchase Order";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Checked = false;
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(105, 58);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.ShowCheckBox = true;
            this.dtpFromDate.Size = new System.Drawing.Size(103, 20);
            this.dtpFromDate.TabIndex = 4;
            // 
            // dtgPO
            // 
            this.dtgPO.AllowUserToAddRows = false;
            this.dtgPO.AllowUserToDeleteRows = false;
            this.dtgPO.AllowUserToResizeRows = false;
            this.dtgPO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgPO.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgPO.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colKey,
            this.colPO,
            this.colIssueDate,
            this.colBrand,
            this.colModel,
            this.colVendor,
            this.colContract,
            this.colQT});
            this.dtgPO.ContextMenuStrip = this.ctmMenu;
            this.dtgPO.Location = new System.Drawing.Point(16, 24);
            this.dtgPO.MultiSelect = false;
            this.dtgPO.Name = "dtgPO";
            this.dtgPO.ReadOnly = true;
            this.dtgPO.RowHeadersWidth = 23;
            this.dtgPO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPO.Size = new System.Drawing.Size(803, 232);
            this.dtgPO.TabIndex = 6;
            this.dtgPO.TabStop = false;
            this.dtgPO.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPO_CellDoubleClick);
            // 
            // ctmMenu
            // 
            this.ctmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniAdd,
            this.mniEdit,
            this.mniCancelPO});
            this.ctmMenu.Name = "ctmMenu";
            this.ctmMenu.Size = new System.Drawing.Size(123, 70);
            // 
            // mniAdd
            // 
            this.mniAdd.Name = "mniAdd";
            this.mniAdd.Size = new System.Drawing.Size(122, 22);
            this.mniAdd.Text = "เพิ่ม";
            this.mniAdd.Click += new System.EventHandler(this.mniAdd_Click);
            // 
            // mniEdit
            // 
            this.mniEdit.Name = "mniEdit";
            this.mniEdit.Size = new System.Drawing.Size(122, 22);
            this.mniEdit.Text = "แก้ไข";
            this.mniEdit.Click += new System.EventHandler(this.mniEdit_Click);
            // 
            // mniCancelPO
            // 
            this.mniCancelPO.Name = "mniCancelPO";
            this.mniCancelPO.Size = new System.Drawing.Size(122, 22);
            this.mniCancelPO.Text = "ยกเลิก PO";
            this.mniCancelPO.Click += new System.EventHandler(this.mniCancelPO_Click);
            // 
            // btnCancelPO
            // 
            this.btnCancelPO.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancelPO.ForeColor = System.Drawing.Color.Red;
            this.btnCancelPO.Location = new System.Drawing.Point(477, 392);
            this.btnCancelPO.Name = "btnCancelPO";
            this.btnCancelPO.Size = new System.Drawing.Size(75, 23);
            this.btnCancelPO.TabIndex = 9;
            this.btnCancelPO.Text = "ยกเลิก PO";
            this.btnCancelPO.UseVisualStyleBackColor = true;
            this.btnCancelPO.Click += new System.EventHandler(this.btnCancelPO_Click);
            // 
            // gpbPODetail
            // 
            this.gpbPODetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.gpbPODetail.Controls.Add(this.dtgPO);
            this.gpbPODetail.Location = new System.Drawing.Point(12, 104);
            this.gpbPODetail.Name = "gpbPODetail";
            this.gpbPODetail.Size = new System.Drawing.Size(834, 272);
            this.gpbPODetail.TabIndex = 10;
            this.gpbPODetail.TabStop = false;
            this.gpbPODetail.Text = "PO Detail";
            // 
            // colKey
            // 
            this.colKey.HeaderText = "EntityKey";
            this.colKey.Name = "colKey";
            this.colKey.ReadOnly = true;
            this.colKey.Visible = false;
            // 
            // colPO
            // 
            this.colPO.HeaderText = "PO #";
            this.colPO.Name = "colPO";
            this.colPO.ReadOnly = true;
            // 
            // colIssueDate
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.colIssueDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.colIssueDate.HeaderText = "Issue Date";
            this.colIssueDate.Name = "colIssueDate";
            this.colIssueDate.ReadOnly = true;
            this.colIssueDate.Width = 90;
            // 
            // colBrand
            // 
            this.colBrand.HeaderText = "Brand";
            this.colBrand.Name = "colBrand";
            this.colBrand.ReadOnly = true;
            // 
            // colModel
            // 
            this.colModel.HeaderText = "Model";
            this.colModel.Name = "colModel";
            this.colModel.ReadOnly = true;
            this.colModel.Width = 200;
            // 
            // colVendor
            // 
            this.colVendor.HeaderText = "Vendor";
            this.colVendor.Name = "colVendor";
            this.colVendor.ReadOnly = true;
            this.colVendor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colContract
            // 
            this.colContract.HeaderText = "Contract #";
            this.colContract.Name = "colContract";
            this.colContract.ReadOnly = true;
            this.colContract.Width = 160;
            // 
            // colQT
            // 
            this.colQT.HeaderText = "Quotation#";
            this.colQT.Name = "colQT";
            this.colQT.ReadOnly = true;
            this.colQT.Visible = false;
            // 
            // FrmPurchaseOrderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 427);
            this.Controls.Add(this.gpbPODetail);
            this.Controls.Add(this.btnCancelPO);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gpbShowData);
            this.Name = "FrmPurchaseOrderList";
            this.Text = "Purchase Order List";
            this.Load += new System.EventHandler(this.FrmPurchaseOrderList_Load);
            this.gpbShowData.ResumeLayout(false);
            this.gpbShowData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPO)).EndInit();
            this.ctmMenu.ResumeLayout(false);
            this.gpbPODetail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtPOXXX;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox txtPOMM;
        private System.Windows.Forms.TextBox txtPOYY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox gpbShowData;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DataGridView dtgPO;
        private System.Windows.Forms.Button btnCancelPO;
        private System.Windows.Forms.ContextMenuStrip ctmMenu;
        private System.Windows.Forms.ToolStripMenuItem mniAdd;
        private System.Windows.Forms.ToolStripMenuItem mniEdit;
        private System.Windows.Forms.ToolStripMenuItem mniCancelPO;
        private System.Windows.Forms.GroupBox gpbPODetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIssueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContract;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQT;
    }
}