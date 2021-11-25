namespace PTB.PIS.Welfare.WindowsApp.MedicalAidGUI {
    partial class FrmMedicalAidLstByHospital {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEditRefDoc = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbRefDocumentNo = new System.Windows.Forms.ComboBox();
            this.btnGetData = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbHospital = new System.Windows.Forms.ComboBox();
            this.dtpPeriod = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gpbTotalAmount = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSumCompPaid = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSumInsurance = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSumApplied = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSumActual = new System.Windows.Forms.Label();
            this.lblSumActual = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSumApplied = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.grdData = new System.Windows.Forms.DataGridView();
            this.colInvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmployee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDisease = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdmitDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActualAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAppliedAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInsurancePaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMenuMData = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gpbTotalAmount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.cMenuMData.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEditRefDoc);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbRefDocumentNo);
            this.groupBox1.Controls.Add(this.btnGetData);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbHospital);
            this.groupBox1.Controls.Add(this.dtpPeriod);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(950, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnEditRefDoc
            // 
            this.btnEditRefDoc.Location = new System.Drawing.Point(715, 19);
            this.btnEditRefDoc.Name = "btnEditRefDoc";
            this.btnEditRefDoc.Size = new System.Drawing.Size(107, 23);
            this.btnEditRefDoc.TabIndex = 3;
            this.btnEditRefDoc.Text = "แก้ไข เลขที่เอกสาร";
            this.btnEditRefDoc.UseVisualStyleBackColor = true;
            this.btnEditRefDoc.Visible = false;
            this.btnEditRefDoc.Click += new System.EventHandler(this.btnEditRefDoc_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(405, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "เลขที่เอกสาร";
            // 
            // cmbRefDocumentNo
            // 
            this.cmbRefDocumentNo.FormattingEnabled = true;
            this.cmbRefDocumentNo.Location = new System.Drawing.Point(477, 20);
            this.cmbRefDocumentNo.Name = "cmbRefDocumentNo";
            this.cmbRefDocumentNo.Size = new System.Drawing.Size(151, 21);
            this.cmbRefDocumentNo.TabIndex = 5;
            this.cmbRefDocumentNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbRefDocumentNo_KeyPress);
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(634, 19);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(75, 23);
            this.btnGetData.TabIndex = 2;
            this.btnGetData.Text = "แสดงข้อมูล";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "โรงพยาบาล";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "เดือน";
            // 
            // cmbHospital
            // 
            this.cmbHospital.FormattingEnabled = true;
            this.cmbHospital.Location = new System.Drawing.Point(226, 20);
            this.cmbHospital.Name = "cmbHospital";
            this.cmbHospital.Size = new System.Drawing.Size(151, 21);
            this.cmbHospital.TabIndex = 1;
            this.cmbHospital.SelectedIndexChanged += new System.EventHandler(this.cmbHospital_SelectedIndexChanged);
            this.cmbHospital.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            this.cmbHospital.Validated += new System.EventHandler(this.cmbHospital_Validated);
            // 
            // dtpPeriod
            // 
            this.dtpPeriod.CustomFormat = "MM/yyyy";
            this.dtpPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriod.Location = new System.Drawing.Point(64, 20);
            this.dtpPeriod.Name = "dtpPeriod";
            this.dtpPeriod.Size = new System.Drawing.Size(69, 20);
            this.dtpPeriod.TabIndex = 0;
            this.dtpPeriod.ValueChanged += new System.EventHandler(this.dtpPeriod_ValueChanged);
            this.dtpPeriod.Validated += new System.EventHandler(this.dtpPeriod_Validated);
            this.dtpPeriod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gpbTotalAmount);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnInsert);
            this.panel1.Controls.Add(this.grdData);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(950, 444);
            this.panel1.TabIndex = 1;
            this.panel1.Visible = false;
            // 
            // gpbTotalAmount
            // 
            this.gpbTotalAmount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.gpbTotalAmount.Controls.Add(this.label11);
            this.gpbTotalAmount.Controls.Add(this.txtSumCompPaid);
            this.gpbTotalAmount.Controls.Add(this.label9);
            this.gpbTotalAmount.Controls.Add(this.txtSumInsurance);
            this.gpbTotalAmount.Controls.Add(this.label7);
            this.gpbTotalAmount.Controls.Add(this.txtSumApplied);
            this.gpbTotalAmount.Controls.Add(this.label6);
            this.gpbTotalAmount.Controls.Add(this.txtSumActual);
            this.gpbTotalAmount.Controls.Add(this.lblSumActual);
            this.gpbTotalAmount.Controls.Add(this.label4);
            this.gpbTotalAmount.Controls.Add(this.lblSumApplied);
            this.gpbTotalAmount.Controls.Add(this.label5);
            this.gpbTotalAmount.Location = new System.Drawing.Point(632, 248);
            this.gpbTotalAmount.Name = "gpbTotalAmount";
            this.gpbTotalAmount.Size = new System.Drawing.Size(304, 136);
            this.gpbTotalAmount.TabIndex = 34;
            this.gpbTotalAmount.TabStop = false;
            this.gpbTotalAmount.Text = "ค่าใช้จ่าย";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label11.Location = new System.Drawing.Point(272, 111);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 13);
            this.label11.TabIndex = 40;
            this.label11.Text = "บาท";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSumCompPaid
            // 
            this.txtSumCompPaid.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtSumCompPaid.BackColor = System.Drawing.Color.MistyRose;
            this.txtSumCompPaid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtSumCompPaid.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtSumCompPaid.Location = new System.Drawing.Point(194, 109);
            this.txtSumCompPaid.Name = "txtSumCompPaid";
            this.txtSumCompPaid.Size = new System.Drawing.Size(74, 16);
            this.txtSumCompPaid.TabIndex = 39;
            this.txtSumCompPaid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label9.Location = new System.Drawing.Point(272, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "บาท";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSumInsurance
            // 
            this.txtSumInsurance.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtSumInsurance.BackColor = System.Drawing.Color.MistyRose;
            this.txtSumInsurance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtSumInsurance.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtSumInsurance.Location = new System.Drawing.Point(194, 80);
            this.txtSumInsurance.Name = "txtSumInsurance";
            this.txtSumInsurance.Size = new System.Drawing.Size(74, 16);
            this.txtSumInsurance.TabIndex = 37;
            this.txtSumInsurance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.Location = new System.Drawing.Point(272, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "บาท";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSumApplied
            // 
            this.txtSumApplied.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtSumApplied.BackColor = System.Drawing.Color.MistyRose;
            this.txtSumApplied.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtSumApplied.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtSumApplied.Location = new System.Drawing.Point(194, 51);
            this.txtSumApplied.Name = "txtSumApplied";
            this.txtSumApplied.Size = new System.Drawing.Size(74, 16);
            this.txtSumApplied.TabIndex = 35;
            this.txtSumApplied.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.Location = new System.Drawing.Point(272, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "บาท";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSumActual
            // 
            this.txtSumActual.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtSumActual.BackColor = System.Drawing.Color.MistyRose;
            this.txtSumActual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtSumActual.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtSumActual.Location = new System.Drawing.Point(194, 22);
            this.txtSumActual.Name = "txtSumActual";
            this.txtSumActual.Size = new System.Drawing.Size(74, 16);
            this.txtSumActual.TabIndex = 33;
            this.txtSumActual.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSumActual
            // 
            this.lblSumActual.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblSumActual.AutoSize = true;
            this.lblSumActual.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblSumActual.Location = new System.Drawing.Point(50, 24);
            this.lblSumActual.Name = "lblSumActual";
            this.lblSumActual.Size = new System.Drawing.Size(138, 13);
            this.lblSumActual.TabIndex = 29;
            this.lblSumActual.Text = "รวมค่ารักษาพยาบาลตามจริง";
            this.lblSumActual.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Location = new System.Drawing.Point(59, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "รวมค่ารักษาสุทธิบริษัทจ่าย";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSumApplied
            // 
            this.lblSumApplied.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblSumApplied.AutoSize = true;
            this.lblSumApplied.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblSumApplied.Location = new System.Drawing.Point(9, 53);
            this.lblSumApplied.Name = "lblSumApplied";
            this.lblSumApplied.Size = new System.Drawing.Size(179, 13);
            this.lblSumApplied.TabIndex = 30;
            this.lblSumApplied.Text = "รวมค่ารักษาพยาบาลที่เบิกได้ตามสิทธิ์";
            this.lblSumApplied.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.Location = new System.Drawing.Point(73, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "รวมค่ารักษาประกันจ่าย";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDelete.Location = new System.Drawing.Point(526, 400);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "ลบ";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnUpdate.Location = new System.Drawing.Point(436, 400);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "แก้ไข";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnInsert.Location = new System.Drawing.Point(350, 400);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 1;
            this.btnInsert.Text = "เพิ่ม";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // grdData
            // 
            this.grdData.AllowUserToAddRows = false;
            this.grdData.AllowUserToDeleteRows = false;
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colInvoiceNo,
            this.colEmployee,
            this.colType,
            this.colDisease,
            this.colAdmitDate,
            this.colActualAmount,
            this.colAppliedAmount,
            this.colInsurancePaid});
            this.grdData.ContextMenuStrip = this.cMenuMData;
            this.grdData.Location = new System.Drawing.Point(8, 16);
            this.grdData.MultiSelect = false;
            this.grdData.Name = "grdData";
            this.grdData.ReadOnly = true;
            this.grdData.RowHeadersWidth = 23;
            this.grdData.RowTemplate.ContextMenuStrip = this.cMenuMData;
            this.grdData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdData.Size = new System.Drawing.Size(932, 224);
            this.grdData.TabIndex = 0;
            this.grdData.Sorted += new System.EventHandler(this.grdData_Sorted);
            this.grdData.DoubleClick += new System.EventHandler(this.grdData_DoubleClick);
            // 
            // colInvoiceNo
            // 
            this.colInvoiceNo.HeaderText = "เลขที่เอกสาร";
            this.colInvoiceNo.Name = "colInvoiceNo";
            this.colInvoiceNo.ReadOnly = true;
            // 
            // colEmployee
            // 
            this.colEmployee.HeaderText = "พนักงาน";
            this.colEmployee.Name = "colEmployee";
            this.colEmployee.ReadOnly = true;
            this.colEmployee.Width = 200;
            // 
            // colType
            // 
            this.colType.HeaderText = "ประเภท";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Width = 70;
            // 
            // colDisease
            // 
            this.colDisease.HeaderText = "โรค";
            this.colDisease.Name = "colDisease";
            this.colDisease.ReadOnly = true;
            // 
            // colAdmitDate
            // 
            this.colAdmitDate.HeaderText = "วันที่เข้ารับการรักษา";
            this.colAdmitDate.Name = "colAdmitDate";
            this.colAdmitDate.ReadOnly = true;
            this.colAdmitDate.Width = 130;
            // 
            // colActualAmount
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colActualAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.colActualAmount.HeaderText = "ค่ารักษาตามจริง";
            this.colActualAmount.Name = "colActualAmount";
            this.colActualAmount.ReadOnly = true;
            // 
            // colAppliedAmount
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colAppliedAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.colAppliedAmount.HeaderText = "ค่ารักษาตามสิทธิ์";
            this.colAppliedAmount.Name = "colAppliedAmount";
            this.colAppliedAmount.ReadOnly = true;
            // 
            // colInsurancePaid
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.colInsurancePaid.DefaultCellStyle = dataGridViewCellStyle4;
            this.colInsurancePaid.HeaderText = "ประกันสุขภาพจ่าย";
            this.colInsurancePaid.Name = "colInsurancePaid";
            this.colInsurancePaid.ReadOnly = true;
            // 
            // cMenuMData
            // 
            this.cMenuMData.AllowMerge = false;
            this.cMenuMData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cMenuMData.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cMenuMData.Name = "cMenuMData";
            this.cMenuMData.ShowImageMargin = false;
            this.cMenuMData.Size = new System.Drawing.Size(77, 70);
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(76, 22);
            this.insertToolStripMenuItem.Text = "เพิ่ม";
            this.insertToolStripMenuItem.Click += new System.EventHandler(this.insertToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(76, 22);
            this.updateToolStripMenuItem.Text = "แก้ไข";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(76, 22);
            this.deleteToolStripMenuItem.Text = "ลบ";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // FrmMedicalAidLstByHospital
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 500);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmMedicalAidLstByHospital";
            this.Text = "ข้อมูลค่ารักษาพยาบาลตามโรงพยาบาล";
            this.Load += new System.EventHandler(this.From_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.gpbTotalAmount.ResumeLayout(false);
            this.gpbTotalAmount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.cMenuMData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbHospital;
        private System.Windows.Forms.DateTimePicker dtpPeriod;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView grdData;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbRefDocumentNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEditRefDoc;
        private System.Windows.Forms.ContextMenuStrip cMenuMData;
        private System.Windows.Forms.GroupBox gpbTotalAmount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label txtSumCompPaid;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label txtSumInsurance;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label txtSumApplied;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label txtSumActual;
        private System.Windows.Forms.Label lblSumActual;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSumApplied;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDisease;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdmitDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActualAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAppliedAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInsurancePaid;
    }
}