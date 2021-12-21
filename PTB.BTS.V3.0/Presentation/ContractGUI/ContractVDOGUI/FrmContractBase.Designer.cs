namespace Presentation.ContractGUI.ContractVDOGUI
{
    partial class FrmContractBase
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
            this.label15 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.cmdCreateContract = new System.Windows.Forms.Button();
            this.txtContractNoXXX = new System.Windows.Forms.TextBox();
            this.txtContractNoMM = new System.Windows.Forms.TextBox();
            this.txtContractNoYY = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.gpbDeleteContract = new System.Windows.Forms.GroupBox();
            this.cmdDeleteContract = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.gpbAssignment = new System.Windows.Forms.GroupBox();
            this.lblPONo = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dtgVehicleContract = new System.Windows.Forms.DataGridView();
            this.EntityKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlateNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KindOfVehicle = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.contextMenu1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mniDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.gpbContractInfo = new System.Windows.Forms.GroupBox();
            this.cboVehicleKindContract = new System.Windows.Forms.ComboBox();
            this.lblContractPrefix = new System.Windows.Forms.Label();
            this.cboContractStatus = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.cboContractType = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.cboCustomerTHName = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.gpbRemark = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.gpbCancelReason = new System.Windows.Forms.GroupBox();
            this.txtCancelReason = new System.Windows.Forms.TextBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.gpbDetail = new System.Windows.Forms.GroupBox();
            this.btnAssignedDepartment = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtLeasingDay = new System.Windows.Forms.TextBox();
            this.txtLeasingMonth = new System.Windows.Forms.TextBox();
            this.txtLeasingYear = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rdoMonth = new System.Windows.Forms.RadioButton();
            this.rdoDay = new System.Windows.Forms.RadioButton();
            this.dtpCancelDate = new System.Windows.Forms.DateTimePicker();
            this.lblCancelDate = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.fpiUnitHire = new FarPoint.Win.Input.FpInteger();
            this.cboKindOfContract = new System.Windows.Forms.ComboBox();
            this.cboCustomerDept = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpContractEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpContractStart = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.ttpToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.gpbDeleteContract.SuspendLayout();
            this.gpbAssignment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVehicleContract)).BeginInit();
            this.contextMenu1.SuspendLayout();
            this.gpbContractInfo.SuspendLayout();
            this.gpbRemark.SuspendLayout();
            this.gpbCancelReason.SuspendLayout();
            this.gpbDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(650, 64);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(28, 13);
            this.label15.TabIndex = 17;
            this.label15.Text = "XXX";
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(620, 64);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(25, 13);
            this.label22.TabIndex = 16;
            this.label22.Text = "MM";
            // 
            // cmdCreateContract
            // 
            this.cmdCreateContract.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmdCreateContract.Location = new System.Drawing.Point(686, 58);
            this.cmdCreateContract.Name = "cmdCreateContract";
            this.cmdCreateContract.Size = new System.Drawing.Size(89, 24);
            this.cmdCreateContract.TabIndex = 14;
            this.cmdCreateContract.Text = "สร้างสัญญาใหม่";
            this.cmdCreateContract.Click += new System.EventHandler(this.cmdCreateContract_Click);
            // 
            // txtContractNoXXX
            // 
            this.txtContractNoXXX.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtContractNoXXX.Location = new System.Drawing.Point(648, 40);
            this.txtContractNoXXX.MaxLength = 3;
            this.txtContractNoXXX.Name = "txtContractNoXXX";
            this.txtContractNoXXX.Size = new System.Drawing.Size(32, 20);
            this.txtContractNoXXX.TabIndex = 13;
            this.txtContractNoXXX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtContractNoXXX.DoubleClick += new System.EventHandler(this.txtContractNoXXX_DoubleClick);
            this.txtContractNoXXX.TextChanged += new System.EventHandler(this.txtContractNoXXX_TextChanged);
            this.txtContractNoXXX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContractNoXXX_KeyDown);
            // 
            // txtContractNoMM
            // 
            this.txtContractNoMM.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtContractNoMM.Location = new System.Drawing.Point(616, 40);
            this.txtContractNoMM.MaxLength = 2;
            this.txtContractNoMM.Name = "txtContractNoMM";
            this.txtContractNoMM.Size = new System.Drawing.Size(32, 20);
            this.txtContractNoMM.TabIndex = 12;
            this.txtContractNoMM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtContractNoMM.TextChanged += new System.EventHandler(this.txtContractNoMM_TextChanged);
            // 
            // txtContractNoYY
            // 
            this.txtContractNoYY.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtContractNoYY.Location = new System.Drawing.Point(584, 40);
            this.txtContractNoYY.MaxLength = 2;
            this.txtContractNoYY.Name = "txtContractNoYY";
            this.txtContractNoYY.Size = new System.Drawing.Size(32, 20);
            this.txtContractNoYY.TabIndex = 11;
            this.txtContractNoYY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtContractNoYY.TextChanged += new System.EventHandler(this.txtContractNoYY_TextChanged);
            // 
            // label25
            // 
            this.label25.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label25.Location = new System.Drawing.Point(496, 44);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(54, 13);
            this.label25.TabIndex = 8;
            this.label25.Text = "PTB  - D -";
            // 
            // gpbDeleteContract
            // 
            this.gpbDeleteContract.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpbDeleteContract.Controls.Add(this.cmdDeleteContract);
            this.gpbDeleteContract.Controls.Add(this.label7);
            this.gpbDeleteContract.Location = new System.Drawing.Point(545, 184);
            this.gpbDeleteContract.Name = "gpbDeleteContract";
            this.gpbDeleteContract.Size = new System.Drawing.Size(256, 72);
            this.gpbDeleteContract.TabIndex = 86;
            this.gpbDeleteContract.TabStop = false;
            this.gpbDeleteContract.Text = "ลบสัญญา";
            // 
            // cmdDeleteContract
            // 
            this.cmdDeleteContract.Location = new System.Drawing.Point(100, 40);
            this.cmdDeleteContract.Name = "cmdDeleteContract";
            this.cmdDeleteContract.Size = new System.Drawing.Size(64, 24);
            this.cmdDeleteContract.TabIndex = 76;
            this.cmdDeleteContract.Text = "ลบสัญญา";
            this.cmdDeleteContract.Click += new System.EventHandler(this.cmdDeleteContract_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(245, 13);
            this.label7.TabIndex = 75;
            this.label7.Text = "*** เมื่อต้องการลบข้อมูลของสัญญานี้ออกจากระบบ ***";
            // 
            // gpbAssignment
            // 
            this.gpbAssignment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.gpbAssignment.Controls.Add(this.lblPONo);
            this.gpbAssignment.Controls.Add(this.label12);
            this.gpbAssignment.Controls.Add(this.dtgVehicleContract);
            this.gpbAssignment.Controls.Add(this.cmdDelete);
            this.gpbAssignment.Controls.Add(this.cmdAdd);
            this.gpbAssignment.Location = new System.Drawing.Point(25, 256);
            this.gpbAssignment.Name = "gpbAssignment";
            this.gpbAssignment.Size = new System.Drawing.Size(512, 248);
            this.gpbAssignment.TabIndex = 85;
            this.gpbAssignment.TabStop = false;
            this.gpbAssignment.Text = "ระบุรถในสัญญา";
            this.gpbAssignment.Visible = false;
            // 
            // lblPONo
            // 
            this.lblPONo.AutoSize = true;
            this.lblPONo.Location = new System.Drawing.Point(96, 24);
            this.lblPONo.Name = "lblPONo";
            this.lblPONo.Size = new System.Drawing.Size(33, 13);
            this.lblPONo.TabIndex = 76;
            this.lblPONo.Text = "None";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 13);
            this.label12.TabIndex = 75;
            this.label12.Text = "Purchase No. :";
            // 
            // dtgVehicleContract
            // 
            this.dtgVehicleContract.AllowUserToAddRows = false;
            this.dtgVehicleContract.AllowUserToDeleteRows = false;
            this.dtgVehicleContract.AllowUserToResizeRows = false;
            this.dtgVehicleContract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dtgVehicleContract.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgVehicleContract.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgVehicleContract.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EntityKey,
            this.PlateNo,
            this.Brand,
            this.Model,
            this.KindOfVehicle});
            this.dtgVehicleContract.ContextMenuStrip = this.contextMenu1;
            this.dtgVehicleContract.Location = new System.Drawing.Point(15, 48);
            this.dtgVehicleContract.Name = "dtgVehicleContract";
            this.dtgVehicleContract.RowHeadersWidth = 23;
            this.dtgVehicleContract.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgVehicleContract.Size = new System.Drawing.Size(481, 152);
            this.dtgVehicleContract.TabIndex = 74;
            this.dtgVehicleContract.TabStop = false;
            // 
            // EntityKey
            // 
            this.EntityKey.HeaderText = "EntityKey";
            this.EntityKey.Name = "EntityKey";
            this.EntityKey.ReadOnly = true;
            this.EntityKey.Visible = false;
            // 
            // PlateNo
            // 
            this.PlateNo.HeaderText = "ทะเบียนรถ";
            this.PlateNo.Name = "PlateNo";
            this.PlateNo.ReadOnly = true;
            this.PlateNo.Width = 80;
            // 
            // Brand
            // 
            this.Brand.HeaderText = "ยี่ห้อ";
            this.Brand.Name = "Brand";
            this.Brand.ReadOnly = true;
            this.Brand.Width = 80;
            // 
            // Model
            // 
            this.Model.HeaderText = "รุ่นรถ";
            this.Model.Name = "Model";
            this.Model.ReadOnly = true;
            this.Model.Width = 130;
            // 
            // KindOfVehicle
            // 
            this.KindOfVehicle.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.KindOfVehicle.HeaderText = "ประเภทรถ";
            this.KindOfVehicle.Name = "KindOfVehicle";
            this.KindOfVehicle.Width = 140;
            // 
            // contextMenu1
            // 
            this.contextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniAdd,
            this.mniDelete});
            this.contextMenu1.Name = "contextMenu1";
            this.contextMenu1.ShowImageMargin = false;
            this.contextMenu1.ShowItemToolTips = false;
            this.contextMenu1.Size = new System.Drawing.Size(68, 48);
            // 
            // mniAdd
            // 
            this.mniAdd.Name = "mniAdd";
            this.mniAdd.Size = new System.Drawing.Size(67, 22);
            this.mniAdd.Text = "เพิ่ม";
            this.mniAdd.Click += new System.EventHandler(this.mniAdd_Click);
            // 
            // mniDelete
            // 
            this.mniDelete.Name = "mniDelete";
            this.mniDelete.Size = new System.Drawing.Size(67, 22);
            this.mniDelete.Text = "ลบ";
            this.mniDelete.Click += new System.EventHandler(this.mniDelete_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdDelete.Location = new System.Drawing.Point(258, 208);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(75, 23);
            this.cmdDelete.TabIndex = 73;
            this.cmdDelete.Text = "ลบ";
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdAdd.Location = new System.Drawing.Point(178, 208);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(75, 23);
            this.cmdAdd.TabIndex = 72;
            this.cmdAdd.Text = "เพิ่ม";
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // gpbContractInfo
            // 
            this.gpbContractInfo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpbContractInfo.Controls.Add(this.cboVehicleKindContract);
            this.gpbContractInfo.Controls.Add(this.lblContractPrefix);
            this.gpbContractInfo.Controls.Add(this.label15);
            this.gpbContractInfo.Controls.Add(this.label22);
            this.gpbContractInfo.Controls.Add(this.cmdCreateContract);
            this.gpbContractInfo.Controls.Add(this.txtContractNoXXX);
            this.gpbContractInfo.Controls.Add(this.txtContractNoMM);
            this.gpbContractInfo.Controls.Add(this.txtContractNoYY);
            this.gpbContractInfo.Controls.Add(this.label25);
            this.gpbContractInfo.Controls.Add(this.cboContractStatus);
            this.gpbContractInfo.Controls.Add(this.label26);
            this.gpbContractInfo.Controls.Add(this.cboContractType);
            this.gpbContractInfo.Controls.Add(this.label27);
            this.gpbContractInfo.Controls.Add(this.label28);
            this.gpbContractInfo.Controls.Add(this.cboCustomerTHName);
            this.gpbContractInfo.Controls.Add(this.label29);
            this.gpbContractInfo.Controls.Add(this.label23);
            this.gpbContractInfo.Location = new System.Drawing.Point(24, 0);
            this.gpbContractInfo.Name = "gpbContractInfo";
            this.gpbContractInfo.Size = new System.Drawing.Size(777, 88);
            this.gpbContractInfo.TabIndex = 83;
            this.gpbContractInfo.TabStop = false;
            this.gpbContractInfo.Text = "ข้อมูลสัญญา";
            // 
            // cboVehicleKindContract
            // 
            this.cboVehicleKindContract.DropDownHeight = 105;
            this.cboVehicleKindContract.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboVehicleKindContract.FormattingEnabled = true;
            this.cboVehicleKindContract.IntegralHeight = false;
            this.cboVehicleKindContract.Location = new System.Drawing.Point(533, 41);
            this.cboVehicleKindContract.Name = "cboVehicleKindContract";
            this.cboVehicleKindContract.Size = new System.Drawing.Size(34, 21);
            this.cboVehicleKindContract.TabIndex = 19;
            this.cboVehicleKindContract.Text = "C";
            // 
            // lblContractPrefix
            // 
            this.lblContractPrefix.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblContractPrefix.AutoSize = true;
            this.lblContractPrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblContractPrefix.Location = new System.Drawing.Point(493, 44);
            this.lblContractPrefix.Name = "lblContractPrefix";
            this.lblContractPrefix.Size = new System.Drawing.Size(85, 13);
            this.lblContractPrefix.TabIndex = 18;
            this.lblContractPrefix.Text = "PTB  -               -";
            // 
            // cboContractStatus
            // 
            this.cboContractStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboContractStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboContractStatus.Location = new System.Drawing.Point(88, 40);
            this.cboContractStatus.Name = "cboContractStatus";
            this.cboContractStatus.Size = new System.Drawing.Size(240, 21);
            this.cboContractStatus.TabIndex = 6;
            this.cboContractStatus.SelectedIndexChanged += new System.EventHandler(this.cboContractStatus_SelectedIndexChanged);
            // 
            // label26
            // 
            this.label26.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(416, 44);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(60, 13);
            this.label26.TabIndex = 7;
            this.label26.Text = "เลขที่สัญญา";
            // 
            // cboContractType
            // 
            this.cboContractType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboContractType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboContractType.Enabled = false;
            this.cboContractType.Location = new System.Drawing.Point(496, 16);
            this.cboContractType.Name = "cboContractType";
            this.cboContractType.Size = new System.Drawing.Size(240, 21);
            this.cboContractType.TabIndex = 4;
            this.cboContractType.SelectedIndexChanged += new System.EventHandler(this.cboContractType_SelectedIndexChanged);
            // 
            // label27
            // 
            this.label27.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(416, 18);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(73, 13);
            this.label27.TabIndex = 3;
            this.label27.Text = "ประเภทสัญญา";
            // 
            // label28
            // 
            this.label28.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(16, 44);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(67, 13);
            this.label28.TabIndex = 5;
            this.label28.Text = "สถานะสัญญา";
            // 
            // cboCustomerTHName
            // 
            this.cboCustomerTHName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboCustomerTHName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomerTHName.Location = new System.Drawing.Point(88, 16);
            this.cboCustomerTHName.Name = "cboCustomerTHName";
            this.cboCustomerTHName.Size = new System.Drawing.Size(312, 21);
            this.cboCustomerTHName.TabIndex = 2;
            this.cboCustomerTHName.SelectedIndexChanged += new System.EventHandler(this.cboCustomerTHName_SelectedIndexChanged);
            // 
            // label29
            // 
            this.label29.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(16, 18);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(45, 13);
            this.label29.TabIndex = 1;
            this.label29.Text = "ชื่อลูกค้า";
            // 
            // label23
            // 
            this.label23.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(590, 64);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(21, 13);
            this.label23.TabIndex = 15;
            this.label23.Text = "YY";
            // 
            // gpbRemark
            // 
            this.gpbRemark.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.gpbRemark.Controls.Add(this.label10);
            this.gpbRemark.Controls.Add(this.txtRemark);
            this.gpbRemark.Location = new System.Drawing.Point(24, 560);
            this.gpbRemark.Name = "gpbRemark";
            this.gpbRemark.Size = new System.Drawing.Size(776, 48);
            this.gpbRemark.TabIndex = 87;
            this.gpbRemark.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 78;
            this.label10.Text = "หมายเหตุ";
            // 
            // txtRemark
            // 
            this.txtRemark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemark.Location = new System.Drawing.Point(72, 16);
            this.txtRemark.MaxLength = 60;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(688, 20);
            this.txtRemark.TabIndex = 79;
            this.txtRemark.TextChanged += new System.EventHandler(this.txtRemark_TextChanged);
            // 
            // gpbCancelReason
            // 
            this.gpbCancelReason.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.gpbCancelReason.Controls.Add(this.txtCancelReason);
            this.gpbCancelReason.Location = new System.Drawing.Point(545, 445);
            this.gpbCancelReason.Name = "gpbCancelReason";
            this.gpbCancelReason.Size = new System.Drawing.Size(256, 59);
            this.gpbCancelReason.TabIndex = 90;
            this.gpbCancelReason.TabStop = false;
            this.gpbCancelReason.Text = "เหตุผลในการยกเลิกสัญญา";
            // 
            // txtCancelReason
            // 
            this.txtCancelReason.Enabled = false;
            this.txtCancelReason.Location = new System.Drawing.Point(16, 24);
            this.txtCancelReason.Name = "txtCancelReason";
            this.txtCancelReason.Size = new System.Drawing.Size(216, 20);
            this.txtCancelReason.TabIndex = 0;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdCancel.Location = new System.Drawing.Point(415, 616);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(80, 23);
            this.cmdCancel.TabIndex = 89;
            this.cmdCancel.Text = "ยกเลิก";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // gpbDetail
            // 
            this.gpbDetail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpbDetail.Controls.Add(this.btnAssignedDepartment);
            this.gpbDetail.Controls.Add(this.label14);
            this.gpbDetail.Controls.Add(this.label13);
            this.gpbDetail.Controls.Add(this.label11);
            this.gpbDetail.Controls.Add(this.txtLeasingDay);
            this.gpbDetail.Controls.Add(this.txtLeasingMonth);
            this.gpbDetail.Controls.Add(this.txtLeasingYear);
            this.gpbDetail.Controls.Add(this.label8);
            this.gpbDetail.Controls.Add(this.label6);
            this.gpbDetail.Controls.Add(this.rdoMonth);
            this.gpbDetail.Controls.Add(this.rdoDay);
            this.gpbDetail.Controls.Add(this.dtpCancelDate);
            this.gpbDetail.Controls.Add(this.lblCancelDate);
            this.gpbDetail.Controls.Add(this.label9);
            this.gpbDetail.Controls.Add(this.fpiUnitHire);
            this.gpbDetail.Controls.Add(this.cboKindOfContract);
            this.gpbDetail.Controls.Add(this.cboCustomerDept);
            this.gpbDetail.Controls.Add(this.label5);
            this.gpbDetail.Controls.Add(this.dtpContractEnd);
            this.gpbDetail.Controls.Add(this.dtpContractStart);
            this.gpbDetail.Controls.Add(this.label4);
            this.gpbDetail.Controls.Add(this.label3);
            this.gpbDetail.Controls.Add(this.label2);
            this.gpbDetail.Controls.Add(this.label1);
            this.gpbDetail.Location = new System.Drawing.Point(25, 88);
            this.gpbDetail.Name = "gpbDetail";
            this.gpbDetail.Size = new System.Drawing.Size(776, 96);
            this.gpbDetail.TabIndex = 84;
            this.gpbDetail.TabStop = false;
            this.gpbDetail.Text = "รายละเอียด";
            // 
            // btnAssignedDepartment
            // 
            this.btnAssignedDepartment.Location = new System.Drawing.Point(288, 16);
            this.btnAssignedDepartment.Name = "btnAssignedDepartment";
            this.btnAssignedDepartment.Size = new System.Drawing.Size(56, 21);
            this.btnAssignedDepartment.TabIndex = 42;
            this.btnAssignedDepartment.Text = "ระบุฝ่าย";
            this.ttpToolTip.SetToolTip(this.btnAssignedDepartment, "ระบุฝ่ายลูกค้าในสัญญา");
            this.btnAssignedDepartment.UseVisualStyleBackColor = true;
            this.btnAssignedDepartment.Click += new System.EventHandler(this.btnAssignedDepartment_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(440, 68);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 13);
            this.label14.TabIndex = 41;
            this.label14.Text = "วัน";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(375, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(33, 13);
            this.label13.TabIndex = 40;
            this.label13.Text = "เดือน";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(320, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 13);
            this.label11.TabIndex = 39;
            this.label11.Text = "ปี";
            // 
            // txtLeasingDay
            // 
            this.txtLeasingDay.Enabled = false;
            this.txtLeasingDay.Location = new System.Drawing.Point(408, 64);
            this.txtLeasingDay.Name = "txtLeasingDay";
            this.txtLeasingDay.Size = new System.Drawing.Size(32, 20);
            this.txtLeasingDay.TabIndex = 38;
            this.txtLeasingDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLeasingMonth
            // 
            this.txtLeasingMonth.Enabled = false;
            this.txtLeasingMonth.Location = new System.Drawing.Point(343, 64);
            this.txtLeasingMonth.Name = "txtLeasingMonth";
            this.txtLeasingMonth.Size = new System.Drawing.Size(32, 20);
            this.txtLeasingMonth.TabIndex = 37;
            this.txtLeasingMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLeasingYear
            // 
            this.txtLeasingYear.Enabled = false;
            this.txtLeasingYear.Location = new System.Drawing.Point(288, 64);
            this.txtLeasingYear.Name = "txtLeasingYear";
            this.txtLeasingYear.Size = new System.Drawing.Size(32, 20);
            this.txtLeasingYear.TabIndex = 36;
            this.txtLeasingYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(200, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "ระยะเวลาเช่า";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(496, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "ประเภทการเช่า";
            // 
            // rdoMonth
            // 
            this.rdoMonth.AutoSize = true;
            this.rdoMonth.Location = new System.Drawing.Point(640, 64);
            this.rdoMonth.Name = "rdoMonth";
            this.rdoMonth.Size = new System.Drawing.Size(69, 17);
            this.rdoMonth.TabIndex = 34;
            this.rdoMonth.Text = "รายเดือน";
            this.rdoMonth.CheckedChanged += new System.EventHandler(this.rdoMonth_CheckedChanged);
            // 
            // rdoDay
            // 
            this.rdoDay.AutoSize = true;
            this.rdoDay.Location = new System.Drawing.Point(584, 64);
            this.rdoDay.Name = "rdoDay";
            this.rdoDay.Size = new System.Drawing.Size(57, 17);
            this.rdoDay.TabIndex = 33;
            this.rdoDay.Text = "รายวัน";
            this.rdoDay.CheckedChanged += new System.EventHandler(this.rdoDay_CheckedChanged);
            // 
            // dtpCancelDate
            // 
            this.dtpCancelDate.CustomFormat = "dd/MM/yyyy";
            this.dtpCancelDate.Enabled = false;
            this.dtpCancelDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCancelDate.Location = new System.Drawing.Point(104, 64);
            this.dtpCancelDate.Name = "dtpCancelDate";
            this.dtpCancelDate.Size = new System.Drawing.Size(88, 20);
            this.dtpCancelDate.TabIndex = 31;
            // 
            // lblCancelDate
            // 
            this.lblCancelDate.AutoSize = true;
            this.lblCancelDate.Location = new System.Drawing.Point(16, 66);
            this.lblCancelDate.Name = "lblCancelDate";
            this.lblCancelDate.Size = new System.Drawing.Size(89, 13);
            this.lblCancelDate.TabIndex = 30;
            this.lblCancelDate.Text = "วันที่ยกเลิกสัญญา";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(552, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "คน / คัน";
            // 
            // fpiUnitHire
            // 
            this.fpiUnitHire.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
            this.fpiUnitHire.AllowClipboardKeys = true;
            this.fpiUnitHire.AllowNull = true;
            this.fpiUnitHire.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiUnitHire.Location = new System.Drawing.Point(496, 40);
            this.fpiUnitHire.MaxValue = 255;
            this.fpiUnitHire.MinValue = 1;
            this.fpiUnitHire.Name = "fpiUnitHire";
            this.fpiUnitHire.NullColor = System.Drawing.Color.Transparent;
            this.fpiUnitHire.Size = new System.Drawing.Size(40, 20);
            this.fpiUnitHire.TabIndex = 28;
            this.fpiUnitHire.Text = "1";
            this.fpiUnitHire.TextChanged += new System.EventHandler(this.fpiUnitHire_TextChanged);
            // 
            // cboKindOfContract
            // 
            this.cboKindOfContract.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKindOfContract.Location = new System.Drawing.Point(496, 16);
            this.cboKindOfContract.Name = "cboKindOfContract";
            this.cboKindOfContract.Size = new System.Drawing.Size(264, 21);
            this.cboKindOfContract.TabIndex = 22;
            this.cboKindOfContract.SelectedIndexChanged += new System.EventHandler(this.cboKindOfContract_SelectedIndexChanged);
            // 
            // cboCustomerDept
            // 
            this.cboCustomerDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomerDept.Location = new System.Drawing.Point(104, 16);
            this.cboCustomerDept.Name = "cboCustomerDept";
            this.cboCustomerDept.Size = new System.Drawing.Size(176, 21);
            this.cboCustomerDept.TabIndex = 20;
            this.cboCustomerDept.SelectedIndexChanged += new System.EventHandler(this.cboCustomerDept_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(408, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "จำนวน";
            // 
            // dtpContractEnd
            // 
            this.dtpContractEnd.CustomFormat = "dd/MM/yyyy";
            this.dtpContractEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpContractEnd.Location = new System.Drawing.Point(288, 40);
            this.dtpContractEnd.Name = "dtpContractEnd";
            this.dtpContractEnd.Size = new System.Drawing.Size(88, 20);
            this.dtpContractEnd.TabIndex = 26;
            this.dtpContractEnd.ValueChanged += new System.EventHandler(this.dtpContractEnd_ValueChanged);
            // 
            // dtpContractStart
            // 
            this.dtpContractStart.CustomFormat = "dd/MM/yyyy";
            this.dtpContractStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpContractStart.Location = new System.Drawing.Point(104, 40);
            this.dtpContractStart.Name = "dtpContractStart";
            this.dtpContractStart.Size = new System.Drawing.Size(88, 20);
            this.dtpContractStart.TabIndex = 24;
            this.dtpContractStart.ValueChanged += new System.EventHandler(this.dtpContractStart_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(200, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "วันที่สิ้นสุดสัญญา";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "วันที่เริ่มต้นสัญญา";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "ฝ่ายลูกค้า";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(408, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "ชนิดสัญญา";
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdOK.Location = new System.Drawing.Point(329, 616);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(80, 23);
            this.cmdOK.TabIndex = 88;
            this.cmdOK.Text = "ตกลง";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // ttpToolTip
            // 
            this.ttpToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpToolTip.ToolTipTitle = "คำอธิบาย";
            // 
            // FrmContractBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 651);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.gpbDeleteContract);
            this.Controls.Add(this.gpbAssignment);
            this.Controls.Add(this.gpbContractInfo);
            this.Controls.Add(this.gpbRemark);
            this.Controls.Add(this.gpbCancelReason);
            this.Controls.Add(this.gpbDetail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmContractBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmContractBase_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmContractBase_FormClosing);
            this.gpbDeleteContract.ResumeLayout(false);
            this.gpbDeleteContract.PerformLayout();
            this.gpbAssignment.ResumeLayout(false);
            this.gpbAssignment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVehicleContract)).EndInit();
            this.contextMenu1.ResumeLayout(false);
            this.gpbContractInfo.ResumeLayout(false);
            this.gpbContractInfo.PerformLayout();
            this.gpbRemark.ResumeLayout(false);
            this.gpbRemark.PerformLayout();
            this.gpbCancelReason.ResumeLayout(false);
            this.gpbCancelReason.PerformLayout();
            this.gpbDetail.ResumeLayout(false);
            this.gpbDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button cmdCreateContract;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button cmdDeleteContract;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.GroupBox gpbContractInfo;
        private System.Windows.Forms.ComboBox cboContractStatus;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox cboContractType;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.TextBox txtCancelReason;
        private System.Windows.Forms.GroupBox gpbDetail;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtLeasingDay;
        private System.Windows.Forms.TextBox txtLeasingMonth;
        private System.Windows.Forms.TextBox txtLeasingYear;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        protected System.Windows.Forms.RadioButton rdoMonth;
        protected System.Windows.Forms.RadioButton rdoDay;
        private System.Windows.Forms.DateTimePicker dtpCancelDate;
        private System.Windows.Forms.Label lblCancelDate;
        private System.Windows.Forms.Label label9;
        private FarPoint.Win.Input.FpInteger fpiUnitHire;
        private System.Windows.Forms.ComboBox cboKindOfContract;
        private System.Windows.Forms.ComboBox cboCustomerDept;
        private System.Windows.Forms.Label label5;
        protected System.Windows.Forms.DateTimePicker dtpContractEnd;
        protected System.Windows.Forms.DateTimePicker dtpContractStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenu1;
        private System.Windows.Forms.ToolStripMenuItem mniAdd;
        private System.Windows.Forms.ToolStripMenuItem mniDelete;
        protected internal System.Windows.Forms.DataGridView dtgVehicleContract;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntityKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlateNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn Model;
        private System.Windows.Forms.DataGridViewComboBoxColumn KindOfVehicle;
        protected internal System.Windows.Forms.GroupBox gpbDeleteContract;
        protected internal System.Windows.Forms.GroupBox gpbCancelReason;
        private System.Windows.Forms.GroupBox gpbRemark;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        protected System.Windows.Forms.GroupBox gpbAssignment;
        protected internal System.Windows.Forms.TextBox txtContractNoXXX;
        protected internal System.Windows.Forms.TextBox txtContractNoMM;
        protected internal System.Windows.Forms.TextBox txtContractNoYY;
        protected System.Windows.Forms.ComboBox cboCustomerTHName;
        private System.Windows.Forms.Button btnAssignedDepartment;
        private System.Windows.Forms.ToolTip ttpToolTip;
        private System.Windows.Forms.Label lblPONo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblContractPrefix;
        private System.Windows.Forms.ComboBox cboVehicleKindContract;
    }
}