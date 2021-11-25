namespace Presentation.VehicleGUI.VehicleLeasingGUI
{
    partial class FrmPOSearchQuotation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCencel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboModel = new System.Windows.Forms.ComboBox();
            this.cboBrand = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQuotationXXX = new System.Windows.Forms.TextBox();
            this.txtQuotationMM = new System.Windows.Forms.TextBox();
            this.txtQuotationYY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.dtgQuotation = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contract = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniOK = new System.Windows.Forms.ToolStripMenuItem();
            this.mniCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgQuotation)).BeginInit();
            this.ctmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCencel
            // 
            this.btnCencel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCencel.Location = new System.Drawing.Point(390, 366);
            this.btnCencel.Name = "btnCencel";
            this.btnCencel.Size = new System.Drawing.Size(75, 23);
            this.btnCencel.TabIndex = 12;
            this.btnCencel.Text = "ยกเลิก";
            this.btnCencel.UseVisualStyleBackColor = true;
            this.btnCencel.Click += new System.EventHandler(this.btnCencel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.cboCustomer);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboModel);
            this.groupBox1.Controls.Add(this.cboBrand);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtQuotationXXX);
            this.groupBox1.Controls.Add(this.txtQuotationMM);
            this.groupBox1.Controls.Add(this.txtQuotationYY);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(206, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Quotation";
            // 
            // cboCustomer
            // 
            this.cboCustomer.DisplayMember = "English_Name";
            this.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(80, 41);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(214, 21);
            this.cboCustomer.TabIndex = 5;
            this.cboCustomer.ValueMember = "Customer_Code";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 68;
            this.label7.Text = "Customer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 66;
            this.label4.Text = "Model";
            // 
            // cboModel
            // 
            this.cboModel.DisplayMember = "Model_English_Name";
            this.cboModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModel.FormattingEnabled = true;
            this.cboModel.Location = new System.Drawing.Point(80, 96);
            this.cboModel.Name = "cboModel";
            this.cboModel.Size = new System.Drawing.Size(214, 21);
            this.cboModel.TabIndex = 7;
            this.cboModel.ValueMember = "Model_Code";
            // 
            // cboBrand
            // 
            this.cboBrand.DisplayMember = "Brand_English_Name";
            this.cboBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBrand.FormattingEnabled = true;
            this.cboBrand.Location = new System.Drawing.Point(80, 69);
            this.cboBrand.Name = "cboBrand";
            this.cboBrand.Size = new System.Drawing.Size(214, 21);
            this.cboBrand.TabIndex = 6;
            this.cboBrand.ValueMember = "Brand_Code";
            this.cboBrand.SelectedIndexChanged += new System.EventHandler(this.cmbBrand_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Brand";
            // 
            // txtQuotationXXX
            // 
            this.txtQuotationXXX.Location = new System.Drawing.Point(263, 17);
            this.txtQuotationXXX.Name = "txtQuotationXXX";
            this.txtQuotationXXX.Size = new System.Drawing.Size(30, 20);
            this.txtQuotationXXX.TabIndex = 4;
            this.txtQuotationXXX.DoubleClick += new System.EventHandler(this.fpiQuotationXXX_DoubleClick);
            this.txtQuotationXXX.TextChanged += new System.EventHandler(this.fpiQuotationXXX_TextChanged);
            // 
            // txtQuotationMM
            // 
            this.txtQuotationMM.Location = new System.Drawing.Point(234, 17);
            this.txtQuotationMM.Name = "txtQuotationMM";
            this.txtQuotationMM.Size = new System.Drawing.Size(30, 20);
            this.txtQuotationMM.TabIndex = 3;
            this.txtQuotationMM.DoubleClick += new System.EventHandler(this.fpiQuotationMM_DoubleClick);
            this.txtQuotationMM.TextChanged += new System.EventHandler(this.fpiQuotationMM_TextChanged);
            // 
            // txtQuotationYY
            // 
            this.txtQuotationYY.Location = new System.Drawing.Point(205, 17);
            this.txtQuotationYY.Name = "txtQuotationYY";
            this.txtQuotationYY.Size = new System.Drawing.Size(30, 20);
            this.txtQuotationYY.TabIndex = 2;
            this.txtQuotationYY.DoubleClick += new System.EventHandler(this.fpiQuotationYY_DoubleClick);
            this.txtQuotationYY.TextChanged += new System.EventHandler(this.fpiQuotationYY_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Quotation #                           PTB-Q-";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(301, 123);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "ค้นหา";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quotation Date";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Location = new System.Drawing.Point(309, 366);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "ตกลง";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dtgQuotation
            // 
            this.dtgQuotation.AllowUserToAddRows = false;
            this.dtgQuotation.AllowUserToDeleteRows = false;
            this.dtgQuotation.AllowUserToResizeRows = false;
            this.dtgQuotation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgQuotation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgQuotation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgQuotation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column3,
            this.Contract});
            this.dtgQuotation.ContextMenuStrip = this.ctmMenu;
            this.dtgQuotation.Location = new System.Drawing.Point(15, 168);
            this.dtgQuotation.MultiSelect = false;
            this.dtgQuotation.Name = "dtgQuotation";
            this.dtgQuotation.ReadOnly = true;
            this.dtgQuotation.RowHeadersWidth = 23;
            this.dtgQuotation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgQuotation.Size = new System.Drawing.Size(760, 182);
            this.dtgQuotation.TabIndex = 10;
            this.dtgQuotation.TabStop = false;
            this.dtgQuotation.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgQuotation_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "EntityKey";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Quotation #";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 90;
            // 
            // Column4
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column4.HeaderText = "Customer";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Brand";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 110;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Model";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 120;
            // 
            // Column7
            // 
            this.Column7.FalseValue = "N";
            this.Column7.HeaderText = "Accepted";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column7.TrueValue = "Y";
            this.Column7.Width = 70;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "PO #";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column3
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = null;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column3.HeaderText = "Issue Date";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 80;
            // 
            // Contract
            // 
            this.Contract.HeaderText = "Contract";
            this.Contract.Name = "Contract";
            this.Contract.ReadOnly = true;
            this.Contract.Visible = false;
            // 
            // ctmMenu
            // 
            this.ctmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniOK,
            this.mniCancel});
            this.ctmMenu.Name = "ctmMenu";
            this.ctmMenu.Size = new System.Drawing.Size(108, 48);
            // 
            // mniOK
            // 
            this.mniOK.Name = "mniOK";
            this.mniOK.Size = new System.Drawing.Size(107, 22);
            this.mniOK.Text = "ตกลง";
            this.mniOK.Click += new System.EventHandler(this.mniOK_Click);
            // 
            // mniCancel
            // 
            this.mniCancel.Name = "mniCancel";
            this.mniCancel.Size = new System.Drawing.Size(107, 22);
            this.mniCancel.Text = "ยกเลิก";
            this.mniCancel.Click += new System.EventHandler(this.mniCancel_Click);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Checked = false;
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(162, 124);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.ShowCheckBox = true;
            this.dtpFromDate.Size = new System.Drawing.Size(131, 20);
            this.dtpFromDate.TabIndex = 69;
            // 
            // FrmPOSearchQuotation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(790, 397);
            this.Controls.Add(this.btnCencel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dtgQuotation);
            this.Name = "FrmPOSearchQuotation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quotation";
            this.Load += new System.EventHandler(this.frmQuotationList_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgQuotation)).EndInit();
            this.ctmMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DataGridView dtgQuotation;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboModel;
        private System.Windows.Forms.ComboBox cboBrand;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQuotationXXX;
        private System.Windows.Forms.TextBox txtQuotationMM;
        private System.Windows.Forms.TextBox txtQuotationYY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCencel;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contract;
        private System.Windows.Forms.ContextMenuStrip ctmMenu;
        private System.Windows.Forms.ToolStripMenuItem mniOK;
        private System.Windows.Forms.ToolStripMenuItem mniCancel;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
    }
}