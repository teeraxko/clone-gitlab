//using System;
//using System.Drawing;
//using System.Collections;
//using System.ComponentModel;
//using System.Windows.Forms;
//using System.Data.SqlClient;

//using Entity.VehicleEntities;
//using Entity.CommonEntity;

//using Facade.VehicleFacade;

//using Presentation.CommonGUI;

//using SystemFramework.AppException;
//using SystemFramework.AppMessage;
//using SystemFramework.AppConfig;

//using ictus.Common.Entity;

//namespace Presentation.VehicleGUI
//{
//    public class frmCreateInsuranceTypeOne : ChildFormBase, IMDIChildForm
//    {
//        #region Windows Form Designer generated code
//        private System.Windows.Forms.GroupBox groupBox1;
//        private System.Windows.Forms.Label label6;
//        private System.Windows.Forms.Label label5;
//        private System.Windows.Forms.Label label2;
//        private System.Windows.Forms.Label label1;
//        private System.Windows.Forms.Label label3;
//        private System.Windows.Forms.Label label4;
//        private System.Windows.Forms.GroupBox groupBox2;
//        private System.Windows.Forms.Label label7;
//        private System.Windows.Forms.Label label8;
//        private System.Windows.Forms.Label label9;
//        private System.Windows.Forms.GroupBox groupBox3;
//        private System.Windows.Forms.TextBox txtInsuranceInchargeTe;
//        private System.Windows.Forms.TextBox txtInsuranceInchargeName;
//        private System.Windows.Forms.TextBox txtPolicyNo;
//        private System.Windows.Forms.DateTimePicker dtpStartDate;
//        private System.Windows.Forms.DateTimePicker dtpEndDate;
//        private System.Windows.Forms.DateTimePicker dtpMoveStart;
//        private System.Windows.Forms.DateTimePicker dtpMoveEndDate;
//        private System.Windows.Forms.TextBox txtMovePolicy;
//        private System.Windows.Forms.Button cmdRight;
//        private System.Windows.Forms.Button cmdLeft;
//        private System.Windows.Forms.Button cmdAllRight;
//        private System.Windows.Forms.Button cmdAllLeft;
//        private FarPoint.Win.Spread.FpSpread fpsMovePolicy;
//        private FarPoint.Win.Spread.SheetView fpsMovePolicy_Sheet1;
//        private FarPoint.Win.Spread.FpSpread fpsNewPolicy;
//        private FarPoint.Win.Spread.SheetView fpsNewPolicy_Sheet1;
//        private System.Windows.Forms.Button cmdCalculate;
//        private System.Windows.Forms.Button cmdOK;
//        private System.Windows.Forms.Button cmdCancel;
//        private System.Windows.Forms.ContextMenu contextMenu1;
//        private System.Windows.Forms.ComboBox cmbInsuranceCompCode;
//        private System.Windows.Forms.ContextMenu contextMenu2;
//        private System.Windows.Forms.MenuItem mniSelectAllMove;
//        private System.Windows.Forms.MenuItem mniUnSelectAllMove;
//        private System.Windows.Forms.MenuItem mniSelectAll;
//        private System.Windows.Forms.MenuItem mniUnSelectAll;
//        private System.Windows.Forms.Button btnAddDetail;
//        /// <summary>
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.Container components = null;


//        /// <summary>
//        /// Clean up any resources being used.
//        /// </summary>
//        protected override void Dispose( bool disposing )
//        {
//            if( disposing )
//            {
//                if(components != null)
//                {
//                    components.Dispose();
//                }
//            }
//            base.Dispose( disposing );
//        }
//        private void InitializeComponent()
//        {
//            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
//            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
//            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmCreateInsuranceTypeOne));
//            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
//            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
//            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
//            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType2 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
//            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
//            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
//            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
//            FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
//            FarPoint.Win.Spread.CellType.NumberCellType numberCellType5 = new FarPoint.Win.Spread.CellType.NumberCellType();
//            FarPoint.Win.Spread.CellType.NumberCellType numberCellType6 = new FarPoint.Win.Spread.CellType.NumberCellType();
//            FarPoint.Win.Spread.CellType.NumberCellType numberCellType7 = new FarPoint.Win.Spread.CellType.NumberCellType();
//            this.groupBox1 = new System.Windows.Forms.GroupBox();
//            this.btnAddDetail = new System.Windows.Forms.Button();
//            this.label6 = new System.Windows.Forms.Label();
//            this.txtInsuranceInchargeTe = new System.Windows.Forms.TextBox();
//            this.txtInsuranceInchargeName = new System.Windows.Forms.TextBox();
//            this.label5 = new System.Windows.Forms.Label();
//            this.cmbInsuranceCompCode = new System.Windows.Forms.ComboBox();
//            this.txtPolicyNo = new System.Windows.Forms.TextBox();
//            this.label2 = new System.Windows.Forms.Label();
//            this.label1 = new System.Windows.Forms.Label();
//            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
//            this.label3 = new System.Windows.Forms.Label();
//            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
//            this.label4 = new System.Windows.Forms.Label();
//            this.groupBox2 = new System.Windows.Forms.GroupBox();
//            this.dtpMoveStart = new System.Windows.Forms.DateTimePicker();
//            this.label8 = new System.Windows.Forms.Label();
//            this.dtpMoveEndDate = new System.Windows.Forms.DateTimePicker();
//            this.label9 = new System.Windows.Forms.Label();
//            this.txtMovePolicy = new System.Windows.Forms.TextBox();
//            this.label7 = new System.Windows.Forms.Label();
//            this.fpsMovePolicy = new FarPoint.Win.Spread.FpSpread();
//            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
//            this.mniSelectAllMove = new System.Windows.Forms.MenuItem();
//            this.mniUnSelectAllMove = new System.Windows.Forms.MenuItem();
//            this.fpsMovePolicy_Sheet1 = new FarPoint.Win.Spread.SheetView();
//            this.groupBox3 = new System.Windows.Forms.GroupBox();
//            this.cmdCalculate = new System.Windows.Forms.Button();
//            this.fpsNewPolicy = new FarPoint.Win.Spread.FpSpread();
//            this.contextMenu2 = new System.Windows.Forms.ContextMenu();
//            this.mniSelectAll = new System.Windows.Forms.MenuItem();
//            this.mniUnSelectAll = new System.Windows.Forms.MenuItem();
//            this.fpsNewPolicy_Sheet1 = new FarPoint.Win.Spread.SheetView();
//            this.cmdRight = new System.Windows.Forms.Button();
//            this.cmdLeft = new System.Windows.Forms.Button();
//            this.cmdAllRight = new System.Windows.Forms.Button();
//            this.cmdAllLeft = new System.Windows.Forms.Button();
//            this.cmdOK = new System.Windows.Forms.Button();
//            this.cmdCancel = new System.Windows.Forms.Button();
//            this.groupBox1.SuspendLayout();
//            this.groupBox2.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.fpsMovePolicy)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.fpsMovePolicy_Sheet1)).BeginInit();
//            this.groupBox3.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.fpsNewPolicy)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.fpsNewPolicy_Sheet1)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // groupBox1
//            // 
//            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
//                | System.Windows.Forms.AnchorStyles.Right)));
//            this.groupBox1.Controls.Add(this.btnAddDetail);
//            this.groupBox1.Controls.Add(this.label6);
//            this.groupBox1.Controls.Add(this.txtInsuranceInchargeTe);
//            this.groupBox1.Controls.Add(this.txtInsuranceInchargeName);
//            this.groupBox1.Controls.Add(this.label5);
//            this.groupBox1.Controls.Add(this.cmbInsuranceCompCode);
//            this.groupBox1.Controls.Add(this.txtPolicyNo);
//            this.groupBox1.Controls.Add(this.label2);
//            this.groupBox1.Controls.Add(this.label1);
//            this.groupBox1.Controls.Add(this.dtpStartDate);
//            this.groupBox1.Controls.Add(this.label3);
//            this.groupBox1.Controls.Add(this.dtpEndDate);
//            this.groupBox1.Controls.Add(this.label4);
//            this.groupBox1.Location = new System.Drawing.Point(16, 8);
//            this.groupBox1.Name = "groupBox1";
//            this.groupBox1.Size = new System.Drawing.Size(1008, 128);
//            this.groupBox1.TabIndex = 1;
//            this.groupBox1.TabStop = false;
//            this.groupBox1.Text = "กรมธรรม์ประกันภัยชั้นหนึ่ง";
//            // 
//            // btnAddDetail
//            // 
//            this.btnAddDetail.Location = new System.Drawing.Point(784, 88);
//            this.btnAddDetail.Name = "btnAddDetail";
//            this.btnAddDetail.Size = new System.Drawing.Size(96, 23);
//            this.btnAddDetail.TabIndex = 12;
//            this.btnAddDetail.Text = "เพิ่มรถในกรมธรรม์";
//            this.btnAddDetail.Click += new System.EventHandler(this.btnAddDetail_Click);
//            // 
//            // label6
//            // 
//            this.label6.Location = new System.Drawing.Point(408, 88);
//            this.label6.Name = "label6";
//            this.label6.Size = new System.Drawing.Size(56, 23);
//            this.label6.TabIndex = 11;
//            this.label6.Text = "โทรศัพท์";
//            // 
//            // txtInsuranceInchargeTe
//            // 
//            this.txtInsuranceInchargeTe.Location = new System.Drawing.Point(480, 88);
//            this.txtInsuranceInchargeTe.MaxLength = 50;
//            this.txtInsuranceInchargeTe.Name = "txtInsuranceInchargeTe";
//            this.txtInsuranceInchargeTe.Size = new System.Drawing.Size(288, 20);
//            this.txtInsuranceInchargeTe.TabIndex = 6;
//            this.txtInsuranceInchargeTe.Text = "";
//            // 
//            // txtInsuranceInchargeName
//            // 
//            this.txtInsuranceInchargeName.Location = new System.Drawing.Point(112, 88);
//            this.txtInsuranceInchargeName.MaxLength = 60;
//            this.txtInsuranceInchargeName.Name = "txtInsuranceInchargeName";
//            this.txtInsuranceInchargeName.Size = new System.Drawing.Size(280, 20);
//            this.txtInsuranceInchargeName.TabIndex = 5;
//            this.txtInsuranceInchargeName.Text = "";
//            // 
//            // label5
//            // 
//            this.label5.Location = new System.Drawing.Point(16, 88);
//            this.label5.Name = "label5";
//            this.label5.Size = new System.Drawing.Size(64, 23);
//            this.label5.TabIndex = 8;
//            this.label5.Text = "ชื่อเจ้าหน้าที่";
//            // 
//            // cmbInsuranceCompCode
//            // 
//            this.cmbInsuranceCompCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
//            this.cmbInsuranceCompCode.Location = new System.Drawing.Point(112, 56);
//            this.cmbInsuranceCompCode.Name = "cmbInsuranceCompCode";
//            this.cmbInsuranceCompCode.Size = new System.Drawing.Size(280, 21);
//            this.cmbInsuranceCompCode.TabIndex = 3;
//            // 
//            // txtPolicyNo
//            // 
//            this.txtPolicyNo.Location = new System.Drawing.Point(112, 24);
//            this.txtPolicyNo.MaxLength = 20;
//            this.txtPolicyNo.Name = "txtPolicyNo";
//            this.txtPolicyNo.Size = new System.Drawing.Size(176, 20);
//            this.txtPolicyNo.TabIndex = 1;
//            this.txtPolicyNo.Text = "";
//            this.txtPolicyNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPolicyNo_KeyDown);
//            // 
//            // label2
//            // 
//            this.label2.Location = new System.Drawing.Point(16, 56);
//            this.label2.Name = "label2";
//            this.label2.Size = new System.Drawing.Size(88, 23);
//            this.label2.TabIndex = 1;
//            this.label2.Text = "ชื่อบริษัทประกันภัย";
//            // 
//            // label1
//            // 
//            this.label1.Location = new System.Drawing.Point(16, 24);
//            this.label1.Name = "label1";
//            this.label1.Size = new System.Drawing.Size(72, 23);
//            this.label1.TabIndex = 0;
//            this.label1.Text = "เลขที่กรมธรรม์";
//            // 
//            // dtpStartDate
//            // 
//            this.dtpStartDate.CustomFormat = "dd/MM/yyyy";
//            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
//            this.dtpStartDate.Location = new System.Drawing.Point(480, 24);
//            this.dtpStartDate.Name = "dtpStartDate";
//            this.dtpStartDate.Size = new System.Drawing.Size(96, 20);
//            this.dtpStartDate.TabIndex = 2;
//            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
//            // 
//            // label3
//            // 
//            this.label3.Location = new System.Drawing.Point(408, 24);
//            this.label3.Name = "label3";
//            this.label3.Size = new System.Drawing.Size(64, 23);
//            this.label3.TabIndex = 4;
//            this.label3.Text = "วันที่เริ่มต้น";
//            // 
//            // dtpEndDate
//            // 
//            this.dtpEndDate.CustomFormat = "dd/MM/yyyy";
//            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
//            this.dtpEndDate.Location = new System.Drawing.Point(480, 56);
//            this.dtpEndDate.Name = "dtpEndDate";
//            this.dtpEndDate.Size = new System.Drawing.Size(96, 20);
//            this.dtpEndDate.TabIndex = 4;
//            // 
//            // label4
//            // 
//            this.label4.Location = new System.Drawing.Point(408, 56);
//            this.label4.Name = "label4";
//            this.label4.Size = new System.Drawing.Size(56, 23);
//            this.label4.TabIndex = 6;
//            this.label4.Text = "วันที่สิ้นสุด";
//            // 
//            // groupBox2
//            // 
//            this.groupBox2.Controls.Add(this.dtpMoveStart);
//            this.groupBox2.Controls.Add(this.label8);
//            this.groupBox2.Controls.Add(this.dtpMoveEndDate);
//            this.groupBox2.Controls.Add(this.label9);
//            this.groupBox2.Controls.Add(this.txtMovePolicy);
//            this.groupBox2.Controls.Add(this.label7);
//            this.groupBox2.Controls.Add(this.fpsMovePolicy);
//            this.groupBox2.Location = new System.Drawing.Point(16, 136);
//            this.groupBox2.Name = "groupBox2";
//            this.groupBox2.Size = new System.Drawing.Size(304, 424);
//            this.groupBox2.TabIndex = 2;
//            this.groupBox2.TabStop = false;
//            this.groupBox2.Text = "ย้ายจากกรมธรรม์";
//            this.groupBox2.Visible = false;
//            // 
//            // dtpMoveStart
//            // 
//            this.dtpMoveStart.Enabled = false;
//            this.dtpMoveStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
//            this.dtpMoveStart.Location = new System.Drawing.Point(112, 56);
//            this.dtpMoveStart.Name = "dtpMoveStart";
//            this.dtpMoveStart.Size = new System.Drawing.Size(96, 20);
//            this.dtpMoveStart.TabIndex = 8;
//            // 
//            // label8
//            // 
//            this.label8.Location = new System.Drawing.Point(16, 56);
//            this.label8.Name = "label8";
//            this.label8.Size = new System.Drawing.Size(64, 23);
//            this.label8.TabIndex = 8;
//            this.label8.Text = "วันที่เริ่มต้น";
//            // 
//            // dtpMoveEndDate
//            // 
//            this.dtpMoveEndDate.CustomFormat = "dd/MM/yyyy";
//            this.dtpMoveEndDate.Enabled = false;
//            this.dtpMoveEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
//            this.dtpMoveEndDate.Location = new System.Drawing.Point(112, 88);
//            this.dtpMoveEndDate.Name = "dtpMoveEndDate";
//            this.dtpMoveEndDate.Size = new System.Drawing.Size(96, 20);
//            this.dtpMoveEndDate.TabIndex = 9;
//            // 
//            // label9
//            // 
//            this.label9.Location = new System.Drawing.Point(16, 88);
//            this.label9.Name = "label9";
//            this.label9.Size = new System.Drawing.Size(56, 23);
//            this.label9.TabIndex = 10;
//            this.label9.Text = "วันที่สิ้นสุด";
//            // 
//            // txtMovePolicy
//            // 
//            this.txtMovePolicy.Location = new System.Drawing.Point(112, 24);
//            this.txtMovePolicy.MaxLength = 20;
//            this.txtMovePolicy.Name = "txtMovePolicy";
//            this.txtMovePolicy.Size = new System.Drawing.Size(176, 20);
//            this.txtMovePolicy.TabIndex = 7;
//            this.txtMovePolicy.Text = "";
//            this.txtMovePolicy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMovePolicy_KeyDown);
//            this.txtMovePolicy.DoubleClick += new System.EventHandler(this.txtMovePolicy_DoubleClick);
//            // 
//            // label7
//            // 
//            this.label7.Location = new System.Drawing.Point(16, 24);
//            this.label7.Name = "label7";
//            this.label7.Size = new System.Drawing.Size(72, 23);
//            this.label7.TabIndex = 3;
//            this.label7.Text = "เลขที่กรมธรรม์";
//            // 
//            // fpsMovePolicy
//            // 
//            this.fpsMovePolicy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
//            this.fpsMovePolicy.ContextMenu = this.contextMenu1;
//            this.fpsMovePolicy.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
//            this.fpsMovePolicy.Location = new System.Drawing.Point(40, 128);
//            this.fpsMovePolicy.Name = "fpsMovePolicy";
//            this.fpsMovePolicy.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
//                                                                                       this.fpsMovePolicy_Sheet1});
//            this.fpsMovePolicy.Size = new System.Drawing.Size(224, 256);
//            this.fpsMovePolicy.TabIndex = 90;
//            this.fpsMovePolicy.TabStop = false;
//            // 
//            // contextMenu1
//            // 
//            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
//                                                                                         this.mniSelectAllMove,
//                                                                                         this.mniUnSelectAllMove});
//            // 
//            // mniSelectAllMove
//            // 
//            this.mniSelectAllMove.Enabled = false;
//            this.mniSelectAllMove.Index = 0;
//            this.mniSelectAllMove.Text = "เลือกทั้งหมด";
//            this.mniSelectAllMove.Click += new System.EventHandler(this.mniSelectAllMove_Click);
//            // 
//            // mniUnSelectAllMove
//            // 
//            this.mniUnSelectAllMove.Enabled = false;
//            this.mniUnSelectAllMove.Index = 1;
//            this.mniUnSelectAllMove.Text = "ไม่เลือกทังหมด";
//            this.mniUnSelectAllMove.Click += new System.EventHandler(this.mniUnSelectAllMove_Click);
//            // 
//            // fpsMovePolicy_Sheet1
//            // 
//            this.fpsMovePolicy_Sheet1.Reset();
//            // Formulas and custom names must be loaded with R1C1 reference style
//            this.fpsMovePolicy_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
//            this.fpsMovePolicy_Sheet1.ColumnCount = 4;
//            this.fpsMovePolicy_Sheet1.RowCount = 1;
//            this.fpsMovePolicy_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "X";
//            this.fpsMovePolicy_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "ลำดับที่";
//            this.fpsMovePolicy_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ทะเบียนรถ";
//            textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
//            textCellType1.DropDownButton = false;
//            this.fpsMovePolicy_Sheet1.Columns.Get(0).CellType = textCellType1;
//            this.fpsMovePolicy_Sheet1.Columns.Get(0).Visible = false;
//            this.fpsMovePolicy_Sheet1.Columns.Get(1).CellType = checkBoxCellType1;
//            this.fpsMovePolicy_Sheet1.Columns.Get(1).Label = "X";
//            this.fpsMovePolicy_Sheet1.Columns.Get(1).Resizable = false;
//            this.fpsMovePolicy_Sheet1.Columns.Get(1).Width = 19F;
//            this.fpsMovePolicy_Sheet1.Columns.Get(2).AllowAutoSort = true;
//            numberCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
//            numberCellType1.DropDownButton = false;
//            numberCellType1.FixedPoint = false;
//            this.fpsMovePolicy_Sheet1.Columns.Get(2).CellType = numberCellType1;
//            this.fpsMovePolicy_Sheet1.Columns.Get(2).Label = "ลำดับที่";
//            this.fpsMovePolicy_Sheet1.Columns.Get(2).Resizable = false;
//            this.fpsMovePolicy_Sheet1.Columns.Get(3).AllowAutoSort = true;
//            textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
//            textCellType2.DropDownButton = false;
//            textCellType2.ReadOnly = true;
//            this.fpsMovePolicy_Sheet1.Columns.Get(3).CellType = textCellType2;
//            this.fpsMovePolicy_Sheet1.Columns.Get(3).Label = "ทะเบียนรถ";
//            this.fpsMovePolicy_Sheet1.Columns.Get(3).Locked = true;
//            this.fpsMovePolicy_Sheet1.Columns.Get(3).Resizable = false;
//            this.fpsMovePolicy_Sheet1.Columns.Get(3).Width = 82F;
//            this.fpsMovePolicy_Sheet1.RowHeader.Columns.Default.Resizable = false;
//            this.fpsMovePolicy_Sheet1.SheetName = "Sheet1";
//            this.fpsMovePolicy_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
//            // 
//            // groupBox3
//            // 
//            this.groupBox3.Controls.Add(this.cmdCalculate);
//            this.groupBox3.Controls.Add(this.fpsNewPolicy);
//            this.groupBox3.Location = new System.Drawing.Point(368, 136);
//            this.groupBox3.Name = "groupBox3";
//            this.groupBox3.Size = new System.Drawing.Size(656, 424);
//            this.groupBox3.TabIndex = 3;
//            this.groupBox3.TabStop = false;
//            this.groupBox3.Text = "รายการในกรมธรรม์ใหม่";
//            this.groupBox3.Visible = false;
//            // 
//            // cmdCalculate
//            // 
//            this.cmdCalculate.Location = new System.Drawing.Point(512, 392);
//            this.cmdCalculate.Name = "cmdCalculate";
//            this.cmdCalculate.Size = new System.Drawing.Size(96, 23);
//            this.cmdCalculate.TabIndex = 1;
//            this.cmdCalculate.Text = "คำนวณ";
//            this.cmdCalculate.Click += new System.EventHandler(this.cmdCalculate_Click);
//            // 
//            // fpsNewPolicy
//            // 
//            this.fpsNewPolicy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
//            this.fpsNewPolicy.ContextMenu = this.contextMenu2;
//            this.fpsNewPolicy.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
//            this.fpsNewPolicy.Location = new System.Drawing.Point(8, 24);
//            this.fpsNewPolicy.Name = "fpsNewPolicy";
//            this.fpsNewPolicy.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
//                                                                                      this.fpsNewPolicy_Sheet1});
//            this.fpsNewPolicy.Size = new System.Drawing.Size(640, 360);
//            this.fpsNewPolicy.TabIndex = 91;
//            this.fpsNewPolicy.TabStop = false;
//            // 
//            // contextMenu2
//            // 
//            this.contextMenu2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
//                                                                                         this.mniSelectAll,
//                                                                                         this.mniUnSelectAll});
//            // 
//            // mniSelectAll
//            // 
//            this.mniSelectAll.Enabled = false;
//            this.mniSelectAll.Index = 0;
//            this.mniSelectAll.Text = "เลือกทั้งหมด";
//            this.mniSelectAll.Click += new System.EventHandler(this.mniSelectAll_Click);
//            // 
//            // mniUnSelectAll
//            // 
//            this.mniUnSelectAll.Enabled = false;
//            this.mniUnSelectAll.Index = 1;
//            this.mniUnSelectAll.Text = "ไม่เลือกทังหมด";
//            this.mniUnSelectAll.Click += new System.EventHandler(this.mniUnSelectAll_Click);
//            // 
//            // fpsNewPolicy_Sheet1
//            // 
//            this.fpsNewPolicy_Sheet1.Reset();
//            // Formulas and custom names must be loaded with R1C1 reference style
//            this.fpsNewPolicy_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
//            this.fpsNewPolicy_Sheet1.ColumnCount = 9;
//            this.fpsNewPolicy_Sheet1.RowCount = 1;
//            this.fpsNewPolicy_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "X";
//            this.fpsNewPolicy_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "ลำดับที่";
//            this.fpsNewPolicy_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ทะเบียนรถ";
//            this.fpsNewPolicy_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "ทุนประกัน";
//            this.fpsNewPolicy_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "เบี้ยประกัน";
//            this.fpsNewPolicy_Sheet1.ColumnHeader.Cells.Get(0, 6).Text = "ค่าธรรมเนียมอากร";
//            this.fpsNewPolicy_Sheet1.ColumnHeader.Cells.Get(0, 7).Text = "ภาษี";
//            this.fpsNewPolicy_Sheet1.ColumnHeader.Cells.Get(0, 8).Text = "รวมเป็นเงิน";
//            textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
//            textCellType3.DropDownButton = false;
//            this.fpsNewPolicy_Sheet1.Columns.Get(0).CellType = textCellType3;
//            this.fpsNewPolicy_Sheet1.Columns.Get(0).Visible = false;
//            this.fpsNewPolicy_Sheet1.Columns.Get(1).CellType = checkBoxCellType2;
//            this.fpsNewPolicy_Sheet1.Columns.Get(1).Label = "X";
//            this.fpsNewPolicy_Sheet1.Columns.Get(1).Resizable = false;
//            this.fpsNewPolicy_Sheet1.Columns.Get(1).Width = 20F;
//            this.fpsNewPolicy_Sheet1.Columns.Get(2).AllowAutoSort = true;
//            numberCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
//            numberCellType2.DecimalPlaces = 0;
//            numberCellType2.DropDownButton = false;
//            numberCellType2.FixedPoint = false;
//            numberCellType2.MaximumValue = 999;
//            numberCellType2.MinimumValue = 0;
//            this.fpsNewPolicy_Sheet1.Columns.Get(2).CellType = numberCellType2;
//            this.fpsNewPolicy_Sheet1.Columns.Get(2).Label = "ลำดับที่";
//            this.fpsNewPolicy_Sheet1.Columns.Get(2).Resizable = false;
//            this.fpsNewPolicy_Sheet1.Columns.Get(2).Width = 40F;
//            this.fpsNewPolicy_Sheet1.Columns.Get(3).AllowAutoSort = true;
//            this.fpsNewPolicy_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.MistyRose;
//            textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
//            textCellType4.DropDownButton = false;
//            textCellType4.ReadOnly = true;
//            this.fpsNewPolicy_Sheet1.Columns.Get(3).CellType = textCellType4;
//            this.fpsNewPolicy_Sheet1.Columns.Get(3).Label = "ทะเบียนรถ";
//            this.fpsNewPolicy_Sheet1.Columns.Get(3).Locked = false;
//            this.fpsNewPolicy_Sheet1.Columns.Get(3).Resizable = false;
//            this.fpsNewPolicy_Sheet1.Columns.Get(4).AllowAutoSort = true;
//            numberCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
//            numberCellType3.DecimalPlaces = 2;
//            numberCellType3.DecimalSeparator = ".";
//            numberCellType3.DropDownButton = false;
//            numberCellType3.MinimumValue = 0;
//            numberCellType3.Separator = ",";
//            numberCellType3.ShowSeparator = true;
//            this.fpsNewPolicy_Sheet1.Columns.Get(4).CellType = numberCellType3;
//            this.fpsNewPolicy_Sheet1.Columns.Get(4).Label = "ทุนประกัน";
//            this.fpsNewPolicy_Sheet1.Columns.Get(4).Resizable = false;
//            this.fpsNewPolicy_Sheet1.Columns.Get(4).Width = 100F;
//            this.fpsNewPolicy_Sheet1.Columns.Get(5).AllowAutoSort = true;
//            numberCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
//            numberCellType4.DecimalPlaces = 2;
//            numberCellType4.DecimalSeparator = ".";
//            numberCellType4.DropDownButton = false;
//            numberCellType4.MaximumValue = 999999.99;
//            numberCellType4.MinimumValue = 0;
//            numberCellType4.Separator = ",";
//            numberCellType4.ShowSeparator = true;
//            this.fpsNewPolicy_Sheet1.Columns.Get(5).CellType = numberCellType4;
//            this.fpsNewPolicy_Sheet1.Columns.Get(5).Label = "เบี้ยประกัน";
//            this.fpsNewPolicy_Sheet1.Columns.Get(5).Resizable = false;
//            this.fpsNewPolicy_Sheet1.Columns.Get(5).Width = 90F;
//            this.fpsNewPolicy_Sheet1.Columns.Get(6).AllowAutoSort = true;
//            this.fpsNewPolicy_Sheet1.Columns.Get(6).BackColor = System.Drawing.Color.MistyRose;
//            numberCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
//            numberCellType5.DecimalPlaces = 2;
//            numberCellType5.DecimalSeparator = ".";
//            numberCellType5.DropDownButton = false;
//            numberCellType5.MaximumValue = 999999.99;
//            numberCellType5.MinimumValue = 0;
//            numberCellType5.ReadOnly = true;
//            numberCellType5.Separator = ",";
//            numberCellType5.ShowSeparator = true;
//            this.fpsNewPolicy_Sheet1.Columns.Get(6).CellType = numberCellType5;
//            this.fpsNewPolicy_Sheet1.Columns.Get(6).Label = "ค่าธรรมเนียมอากร";
//            this.fpsNewPolicy_Sheet1.Columns.Get(6).Locked = false;
//            this.fpsNewPolicy_Sheet1.Columns.Get(6).Resizable = false;
//            this.fpsNewPolicy_Sheet1.Columns.Get(6).Width = 94F;
//            this.fpsNewPolicy_Sheet1.Columns.Get(7).AllowAutoSort = true;
//            this.fpsNewPolicy_Sheet1.Columns.Get(7).BackColor = System.Drawing.Color.MistyRose;
//            numberCellType6.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
//            numberCellType6.DecimalPlaces = 2;
//            numberCellType6.DecimalSeparator = ".";
//            numberCellType6.DropDownButton = false;
//            numberCellType6.MaximumValue = 99999.99;
//            numberCellType6.MinimumValue = 0;
//            numberCellType6.ReadOnly = true;
//            numberCellType6.Separator = ",";
//            numberCellType6.ShowSeparator = true;
//            this.fpsNewPolicy_Sheet1.Columns.Get(7).CellType = numberCellType6;
//            this.fpsNewPolicy_Sheet1.Columns.Get(7).Label = "ภาษี";
//            this.fpsNewPolicy_Sheet1.Columns.Get(7).Locked = false;
//            this.fpsNewPolicy_Sheet1.Columns.Get(7).Resizable = false;
//            this.fpsNewPolicy_Sheet1.Columns.Get(7).Width = 78F;
//            this.fpsNewPolicy_Sheet1.Columns.Get(8).AllowAutoSort = true;
//            this.fpsNewPolicy_Sheet1.Columns.Get(8).BackColor = System.Drawing.Color.MistyRose;
//            numberCellType7.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
//            numberCellType7.DecimalPlaces = 2;
//            numberCellType7.DecimalSeparator = ".";
//            numberCellType7.DropDownButton = false;
//            numberCellType7.MinimumValue = 0;
//            numberCellType7.ReadOnly = true;
//            numberCellType7.Separator = ",";
//            numberCellType7.ShowSeparator = true;
//            this.fpsNewPolicy_Sheet1.Columns.Get(8).CellType = numberCellType7;
//            this.fpsNewPolicy_Sheet1.Columns.Get(8).Label = "รวมเป็นเงิน";
//            this.fpsNewPolicy_Sheet1.Columns.Get(8).Locked = false;
//            this.fpsNewPolicy_Sheet1.Columns.Get(8).Resizable = false;
//            this.fpsNewPolicy_Sheet1.Columns.Get(8).Width = 100F;
//            this.fpsNewPolicy_Sheet1.RowHeader.Columns.Default.Resizable = false;
//            this.fpsNewPolicy_Sheet1.SheetName = "Sheet1";
//            this.fpsNewPolicy_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
//            // 
//            // cmdRight
//            // 
//            this.cmdRight.Location = new System.Drawing.Point(328, 336);
//            this.cmdRight.Name = "cmdRight";
//            this.cmdRight.Size = new System.Drawing.Size(32, 23);
//            this.cmdRight.TabIndex = 11;
//            this.cmdRight.Text = ">";
//            this.cmdRight.Visible = false;
//            this.cmdRight.Click += new System.EventHandler(this.cmdRight_Click);
//            // 
//            // cmdLeft
//            // 
//            this.cmdLeft.Location = new System.Drawing.Point(328, 360);
//            this.cmdLeft.Name = "cmdLeft";
//            this.cmdLeft.Size = new System.Drawing.Size(32, 23);
//            this.cmdLeft.TabIndex = 12;
//            this.cmdLeft.Text = "<";
//            this.cmdLeft.Visible = false;
//            this.cmdLeft.Click += new System.EventHandler(this.cmdLeft_Click);
//            // 
//            // cmdAllRight
//            // 
//            this.cmdAllRight.Location = new System.Drawing.Point(328, 384);
//            this.cmdAllRight.Name = "cmdAllRight";
//            this.cmdAllRight.Size = new System.Drawing.Size(32, 23);
//            this.cmdAllRight.TabIndex = 13;
//            this.cmdAllRight.Text = ">>";
//            this.cmdAllRight.Visible = false;
//            this.cmdAllRight.Click += new System.EventHandler(this.cmdAllRight_Click);
//            // 
//            // cmdAllLeft
//            // 
//            this.cmdAllLeft.Location = new System.Drawing.Point(328, 408);
//            this.cmdAllLeft.Name = "cmdAllLeft";
//            this.cmdAllLeft.Size = new System.Drawing.Size(32, 23);
//            this.cmdAllLeft.TabIndex = 14;
//            this.cmdAllLeft.Text = "<<";
//            this.cmdAllLeft.Visible = false;
//            this.cmdAllLeft.Click += new System.EventHandler(this.cmdAllLeft_Click);
//            // 
//            // cmdOK
//            // 
//            this.cmdOK.Location = new System.Drawing.Point(437, 584);
//            this.cmdOK.Name = "cmdOK";
//            this.cmdOK.TabIndex = 15;
//            this.cmdOK.Text = "ตกลง";
//            this.cmdOK.Visible = false;
//            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
//            // 
//            // cmdCancel
//            // 
//            this.cmdCancel.Location = new System.Drawing.Point(517, 584);
//            this.cmdCancel.Name = "cmdCancel";
//            this.cmdCancel.TabIndex = 16;
//            this.cmdCancel.Text = "ยกเลิก";
//            this.cmdCancel.Visible = false;
//            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
//            // 
//            // frmCreateInsuranceTypeOne
//            // 
//            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
//            this.ClientSize = new System.Drawing.Size(1030, 630);
//            this.Controls.Add(this.cmdCancel);
//            this.Controls.Add(this.cmdOK);
//            this.Controls.Add(this.cmdAllLeft);
//            this.Controls.Add(this.cmdAllRight);
//            this.Controls.Add(this.cmdLeft);
//            this.Controls.Add(this.cmdRight);
//            this.Controls.Add(this.groupBox3);
//            this.Controls.Add(this.groupBox2);
//            this.Controls.Add(this.groupBox1);
//            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
//            this.Name = "frmCreateInsuranceTypeOne";
//            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
//            //this.Text = "ต่อประกันภัยชั้นหนึ่งตามเลขที่กรมธรรม์เดิม";
//            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
//            this.Load += new System.EventHandler(this.frmCreateInsuranceTypeOne_Load);
//            this.groupBox1.ResumeLayout(false);
//            this.groupBox2.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.fpsMovePolicy)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.fpsMovePolicy_Sheet1)).EndInit();
//            this.groupBox3.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.fpsNewPolicy)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.fpsNewPolicy_Sheet1)).EndInit();
//            this.ResumeLayout(false);

//        }
//        #endregion

//        #region - Constant -
//        #endregion

//        #region - Private - 
//            private bool isReadonly = true;
//            private frmInsuranceTypeOnePolicyList objfrmInsuranceTypeOnePolicyList;
//            private InsuranceTypeOneFacade facadeInsuranceTypeOne;
//            private frmMain mdiParent;
//        #endregion

//        //============================== Property ==============================

//        //============================== Constructor ==============================
//        public frmCreateInsuranceTypeOne()
//        {
//            InitializeComponent();
//            objfrmInsuranceTypeOnePolicyList = new frmInsuranceTypeOnePolicyList();
//            facadeInsuranceTypeOne = new InsuranceTypeOneFacade();
//            cmbInsuranceCompCode.DataSource = facadeInsuranceTypeOne.DataSourceInsuranceCompName;
//            isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleDocumentCreateInsuranceTypeOne");
//            fpsNewPolicy.EditModeReplace = true;
//            this.title = UserProfile.GetFormName("miVehicle", "miVehicleDocumentCreateInsuranceTypeOne");

//        }
//        public override string FormID()
//        {
//            return UserProfile.GetFormID("miVehicle", "miVehicleDocumentCreateInsuranceTypeOne");
//        }

//        //============================== Private Method ==============================
//        #region - Private Method - 
//            private void visibleDetail(bool visible)
//            {
//                groupBox2.Visible = visible;
//                groupBox3.Visible = visible;
//                cmdRight.Visible = visible;
//                cmdLeft.Visible = visible;
//                cmdAllRight.Visible = visible;
//                cmdAllLeft.Visible = visible;
//                cmdOK.Visible = visible;
//                cmdCancel.Visible = visible;
//            }

//            private void clearInsurance()
//            {
//                dtpStartDate.Value = DateTime.Today;
//                if(cmbInsuranceCompCode.Items.Count>0)
//                {
//                    cmbInsuranceCompCode.SelectedIndex = 0;
//                }
//                else
//                {
//                    cmbInsuranceCompCode.SelectedIndex = -1;
//                }
//                txtInsuranceInchargeName.Text = "";
//                txtInsuranceInchargeTe.Text = "";

//                clearVehicleList();
//                clearMoveInsurance();
//                visibleDetail(false);
//            }

//            private void clearVehicleList()
//            {
//                fpsNewPolicy_Sheet1.RowCount = 0;
//                cmdCalculate.Enabled = false;
//            }

//            private void bindMoveInsuranceTypeOne()
//            {
//                txtMovePolicy.Text = facadeInsuranceTypeOne.ObjMoveInsuranceTypeOne.PolicyNo;
//                dtpMoveStart.Value = facadeInsuranceTypeOne.ObjMoveInsuranceTypeOne.APeriod.From;
//                dtpMoveEndDate.Value = facadeInsuranceTypeOne.ObjMoveInsuranceTypeOne.APeriod.To;
//            }

//            private void addMoveInsuranceDetail(VehicleInsuranceTypeOne value)
//            {
//                int i = fpsMovePolicy_Sheet1.RowCount++;
//                fpsMovePolicy_Sheet1.Cells[i, 0].Tag = value;
//                fpsMovePolicy_Sheet1.Cells[i, 0].Text = value.AVehicleInfo.VehicleNo.ToString();
//                fpsMovePolicy_Sheet1.Cells[i,1].Value = false;
//                fpsMovePolicy_Sheet1.Cells[i, 2].Text = value.OrderNo.ToString();
//                fpsMovePolicy_Sheet1.Cells[i, 3].Text = value.AVehicleInfo.PlateNumber;
//            }

//            private void addVehicleInsurance(VehicleInsuranceTypeOne value)
//            {
//                cmdCalculate.Enabled = true;
//                int i = fpsNewPolicy_Sheet1.RowCount++;
//                fpsNewPolicy_Sheet1.Cells[i,0].Text = value.EntityKey;
//                fpsNewPolicy_Sheet1.Cells[i,1].Value = false;
//                fpsNewPolicy_Sheet1.Cells[i,2].Text = value.OrderNo.ToString();
//                fpsNewPolicy_Sheet1.Cells[i,3].Text = value.AVehicleInfo.PlateNumber;
//                fpsNewPolicy_Sheet1.Cells[i,4].Value = value.SumAssured;
//                fpsNewPolicy_Sheet1.Cells[i,5].Value = value.PremiumAmount;
//                fpsNewPolicy_Sheet1.Cells[i,6].Value = value.RevenueStampFee;
//                fpsNewPolicy_Sheet1.Cells[i,7].Value = value.VatAmount;
//                fpsNewPolicy_Sheet1.Cells[i,8].Value = value.Amount;
//            }

//            private void deleteVehicleInsurance(VehicleInsuranceTypeOne value)
//            {
//                facadeInsuranceTypeOne.ObjInsuranceTypeOne.AVehicleInsuranceList.Remove(value);
//            }

//            private void displayVehicleInsurance()
//            {
//                fpsNewPolicy_Sheet1.RowCount = 0;
//                cmdCalculate.Enabled = false;
//                VehicleInsuranceList vehicleInsuranceList = facadeInsuranceTypeOne.ObjInsuranceTypeOne.AVehicleInsuranceList;
//                for(int i=0; i<vehicleInsuranceList.Count; i++)
//                {
//                    addVehicleInsurance(vehicleInsuranceList[i]);
//                }
//                vehicleInsuranceList = null;

//                if(fpsNewPolicy_Sheet1.RowCount == 0)
//                {
//                    mniSelectAll.Enabled = false;
//                    mniUnSelectAll.Enabled = false;					
//                }
//                else
//                {
//                    mniSelectAll.Enabled = true;
//                    mniUnSelectAll.Enabled = true;
//                }
//            }

//            private void clearMoveInsurance()
//            {
//                txtMovePolicy.Text = "";
//                dtpMoveStart.Value = DateTime.Today;
//                dtpMoveEndDate.Value = DateTime.Today;
//                fpsMovePolicy_Sheet1.RowCount = 0;
//            }

//            private void enableInsurance(bool enabled)
//            {
//                dtpStartDate.Enabled = enabled;
//                dtpEndDate.Enabled = enabled;
//                cmbInsuranceCompCode.Enabled = enabled;
//                txtInsuranceInchargeName.Enabled = enabled;
//                txtInsuranceInchargeTe.Enabled = enabled;
//                btnAddDetail.Enabled = enabled;
//            }

//            private void setModeAddStep1(bool value)
//            {
//                txtPolicyNo.Enabled = ! value;
//                mdiParent.EnableNewCommand(value);
//                MainMenuNewStatus = value;
//                enableInsurance(value);
//                if(!value)
//                {
//                    clearInsurance();
//                }
//            }

//            private void setModeAdd(bool value)
//            {
//                cmdOK.Enabled =  value;
//                visibleDetail(value);

//                cmdOK.Visible = value;
//                cmdCancel.Visible = value;
//            }

//            private void enableMove(bool enable)
//            {
//                fpsMovePolicy.Enabled = enable;
//                cmdRight.Enabled = enable;
//                cmdLeft.Enabled = enable;
//                cmdAllRight.Enabled = enable;
//                cmdAllLeft.Enabled = enable;
//            }

//            private void selectAll(FarPoint.Win.Spread.SheetView sheet, bool selected)
//            {
//                for(int i=0; i<sheet.RowCount; i++)
//                {
//                    sheet.Cells[i,1].Value = selected;
//                }
//            }

//        #endregion

//        //============================== Public Method ==============================
		
//        //============================== Base Event ==============================
//        public void InitForm()
//        {
//            clearMainMenuStatus();
//            baseInitMenuMDIParent(mdiParent);

//            txtPolicyNo.Text = "";
//            dtpStartDate.Value = DateTime.Today;
//            setModeAddStep1(false);

//            mniSelectAll.Enabled = false;
//            mniUnSelectAll.Enabled = false;	
//            mniSelectAllMove.Enabled = false;
//            mniUnSelectAllMove.Enabled = false;

//            txtPolicyNo.Focus();

//            if(isReadonly)
//            {
//                txtPolicyNo.Enabled = false;
//            }
//        }

//        public void RefreshForm()
//        {
//            try
//            {
//                if(facadeInsuranceTypeOne.DisplayInsuranceTypeOne(txtPolicyNo.Text))
//                {
//                    Message(MessageList.Error.E0003);					
//                    setSelected(txtPolicyNo);
//                }
//                else
//                {
//                    setModeAddStep1(true);
//                    dtpStartDate.Focus();
//                }
//            }
//            catch(SqlException sqlex)
//            {
//                Message(sqlex);
//            }
//            catch(AppExceptionBase ex)
//            {
//                Message(ex);
//            }
//            catch(Exception ex)
//            {
//                Message(ex);
//            }
//            finally
//            {}



//        }

//        public void PrintForm()
//        {
//        }

//        public void ExitForm()
//        {
//            this.Close();
//        }
		
//        private void callList()
//        {
//            try
//            {
//                objfrmInsuranceTypeOnePolicyList.ConditionPolicyCode = txtMovePolicy.Text;
//                objfrmInsuranceTypeOnePolicyList.ConditionIsExpire = true;
//                objfrmInsuranceTypeOnePolicyList.ConditionExpireDate = dtpStartDate.Value;
//                objfrmInsuranceTypeOnePolicyList.ShowDialog();
//                if(objfrmInsuranceTypeOnePolicyList.Selected)
//                {
//                    txtMovePolicy.Text = objfrmInsuranceTypeOnePolicyList.SelectedInsuranceTypeOnePolicy.PolicyNo;
//                    getMoveInsurance();
//                    enableMove(true);
//                    displayMoveInsuranceDetail();
//                }
//            }
//            catch(SqlException sqlex)
//            {
//                Message(sqlex);
//            }
//            catch(AppExceptionBase ex)
//            {
//                Message(ex);
//            }
//            catch(Exception ex)
//            {
//                Message(ex);
//            }
//            finally
//            {}
//        }

//        private bool getMoveInsurance()
//        {
//            try
//            {
//                if(facadeInsuranceTypeOne.DisplayMoveInsuranceTypeOne(txtMovePolicy.Text))
//                {
//                    bindMoveInsuranceTypeOne();
//                    return true;
//                }
//            }
//            catch(SqlException sqlex)
//            {
//                Message(sqlex);
//            }
//            catch(AppExceptionBase ex)
//            {
//                Message(ex);
//            }
//            catch(Exception ex)
//            {
//                Message(ex);
//            }
//            finally
//            {}
//            return false;
//        }

//        private void displayMoveInsuranceDetail()
//        {
//            VehicleInsuranceList vehicleInsuranceList;
//            fpsMovePolicy_Sheet1.RowCount = 0;
//            try
//            {				
//                vehicleInsuranceList = facadeInsuranceTypeOne.ObjMoveInsuranceTypeOne.AVehicleInsuranceList;
//                for(int i=0; i<vehicleInsuranceList.Count; i++)
//                {
//                    vehicleInsuranceList[i].RevenueStampFee = 0;
//                    vehicleInsuranceList[i].VatAmount = 0;

//                    if(! facadeInsuranceTypeOne.ObjInsuranceTypeOne.AVehicleInsuranceList.Contain(vehicleInsuranceList[i]))
//                    {						
//                        addMoveInsuranceDetail(vehicleInsuranceList[i]);
//                    }
//                }
//                if(fpsMovePolicy_Sheet1.RowCount == 0)
//                {
//                    mniSelectAllMove.Enabled = false;
//                    mniUnSelectAllMove.Enabled = false;
//                }
//                else
//                {
//                    mniSelectAllMove.Enabled = true;
//                    mniUnSelectAllMove.Enabled = true;
//                }
//            }
//            catch(SqlException sqlex)
//            {
//                Message(sqlex);
//            }
//            catch(AppExceptionBase ex)
//            {
//                Message(ex);
//            }
//            catch(Exception ex)
//            {
//                Message(ex);
//            }
//            finally
//            {
//                vehicleInsuranceList = null;
//            }			
//        }

//        private void MovePolicyEnter()
//        {
//            if(txtMovePolicy.Text == "")
//            {
//                Message(MessageList.Error.E0002, "เลขที่กรมธรรม์");
//                clearMoveInsurance();
//                enableMove(false);
//            }
//            else
//            {
//                if(getMoveInsurance())
//                {
//                    if(facadeInsuranceTypeOne.ObjMoveInsuranceTypeOne.APeriod.To > dtpStartDate.Value)
//                    {
//                        Message(MessageList.Error.E0001, "วันที่สิ้นสุดของกรมธรรม์ที่เลือก", "วันที่เริ่มต้นของกรรมธรรม์ใบใหม่");
//                        clearMoveInsurance();
//                        enableMove(false);
//                    }
//                    else
//                    {
//                        enableMove(true);
//                        displayMoveInsuranceDetail();
//                    }
//                }
//                else
//                {
//                    Message(MessageList.Error.E0004, "เลขที่กรมธรรม์");
//                    clearMoveInsurance();
//                    enableMove(false);
//                }
//            }
//        }

//        public void calculateInsuranceTypeOne()
//        {
//            VehicleInsuranceList vehicleInsuranceList = facadeInsuranceTypeOne.ObjInsuranceTypeOne.AVehicleInsuranceList;
//            VehicleInsuranceTypeOne vehicleInsuranceTypeOne;
//            try
//            {
//                for(int i=0; i<vehicleInsuranceList.Count; i++)
//                {
//                    vehicleInsuranceTypeOne = vehicleInsuranceList[i];
//                    if(fpsNewPolicy_Sheet1.Cells[i,4].Text.Trim() == "")
//                    {
//                        vehicleInsuranceTypeOne.SumAssured = 0;
//                    }
//                    else
//                    {
//                        vehicleInsuranceTypeOne.SumAssured = decimal.Parse(fpsNewPolicy_Sheet1.Cells[i,4].Text);
//                    }
//                    if(fpsNewPolicy_Sheet1.Cells[i,5].Text.Trim() == "")
//                    {
//                        vehicleInsuranceTypeOne.PremiumAmount = 0;
//                    }
//                    else
//                    {
//                        vehicleInsuranceTypeOne.PremiumAmount = decimal.Parse(fpsNewPolicy_Sheet1.Cells[i,5].Text);
//                    }
//                    facadeInsuranceTypeOne.CalculateTotalPremium(vehicleInsuranceTypeOne);
//                    fpsNewPolicy_Sheet1.Cells[i,6].Value = vehicleInsuranceTypeOne.RevenueStampFee;
//                    fpsNewPolicy_Sheet1.Cells[i,7].Value = vehicleInsuranceTypeOne.VatAmount;
//                    fpsNewPolicy_Sheet1.Cells[i,8].Value = vehicleInsuranceTypeOne.Amount;
//                }
//            }
//            catch(SqlException sqlex)
//            {
//                Message(sqlex);
//            }
//            catch(AppExceptionBase ex)
//            {
//                Message(ex);
//            }
//            catch(Exception ex)
//            {
//                Message(ex);
//            }
//            finally
//            {
//                vehicleInsuranceList = null;
//                vehicleInsuranceTypeOne = null;
//            }	
//        }

//        public bool validHeader()
//        {
//            if(dtpStartDate.Value > dtpEndDate.Value)
//            {
//                Message(MessageList.Error.E0011, "วันที่เริ่มต้น", "วันที่สิ้นสุด");
//                dtpEndDate.Focus();
//                return false;
//            }

//            if(cmbInsuranceCompCode.SelectedIndex == -1)
//            {
//                Message(MessageList.Error.E0005, "บริษัทประกันภัย");
//                cmbInsuranceCompCode.Focus();
//                return false;
//            }

//            if(txtInsuranceInchargeName.Text == "")
//            {
//                Message(MessageList.Error.E0002, "ชื่อเจ้าหน้าที่");
//                txtInsuranceInchargeName.Focus();
//                return false;
//            }		
//            return true;
//        }

//        public bool validInsuranceTypeOne()
//        {
//            string key;
//            if(fpsNewPolicy_Sheet1.RowCount == 0)
//            {
//                Message(MessageList.Error.E0034);
//                return false;
//            }

//            CommonCollection collection = new CommonCollection();
//            for(int i=0; i<fpsNewPolicy_Sheet1.RowCount; i++)
//            {
//                key = fpsNewPolicy_Sheet1.Cells[i,2].Text;
//                if(collection.Contain(key))
//                {
//                    collection = null;
//                    Message(MessageList.Error.E0035);
//                    return false;
//                }
//                collection.Add(key, i);
//            }
//            collection = null;

//            VehicleInsuranceTypeOne vehicleInsuranceTypeOne;
//            for(int i=0; i<fpsNewPolicy_Sheet1.RowCount; i++)
//            {
//                if(fpsNewPolicy_Sheet1.Cells[i,4].Text.Trim() == "" || decimal.Parse(fpsNewPolicy_Sheet1.Cells[i,4].Text.Trim()) == 0m)
//                {
//                    Message(MessageList.Error.E0002, "ทุนประกัน");
//                    return false;
//                }

//                if(fpsNewPolicy_Sheet1.Cells[i,5].Text.Trim() == "" || decimal.Parse(fpsNewPolicy_Sheet1.Cells[i,5].Text.Trim()) == 0m)
//                {
//                    Message(MessageList.Error.E0002, "เบี้ยประกัน");
//                    return false;
//                }

//                key = fpsNewPolicy_Sheet1.Cells[i,0].Text;				
//                vehicleInsuranceTypeOne = facadeInsuranceTypeOne.ObjInsuranceTypeOne.AVehicleInsuranceList[key];
//                vehicleInsuranceTypeOne.PolicyNo = txtPolicyNo.Text;
//                vehicleInsuranceTypeOne.AffiliateDate = dtpStartDate.Value;
//                vehicleInsuranceTypeOne.OrderNo = Int16.Parse(fpsNewPolicy_Sheet1.Cells[i,2].Text);
//                vehicleInsuranceTypeOne.SumAssured = decimal.Parse(fpsNewPolicy_Sheet1.Cells[i,4].Text);
//                vehicleInsuranceTypeOne.PremiumAmount = decimal.Parse(fpsNewPolicy_Sheet1.Cells[i,5].Text);
//                facadeInsuranceTypeOne.CalculateTotalPremium(vehicleInsuranceTypeOne);		
				
//                if(vehicleInsuranceTypeOne.RevenueStampFee != decimal.Parse(fpsNewPolicy_Sheet1.Cells[i,6].Text.Trim()))
//                {
//                    Message(MessageList.Error.E0017);
//                    cmdCalculate.Focus();
//                    return false;
//                }

//                if(vehicleInsuranceTypeOne.VatAmount != decimal.Parse(fpsNewPolicy_Sheet1.Cells[i,7].Text.Trim()))
//                {
//                    Message(MessageList.Error.E0017);
//                    cmdCalculate.Focus();
//                    return false;
//                }

//                string vehicleStatus = vehicleInsuranceTypeOne.AVehicleInfo.AVehicleStatus.Code;
//                if(vehicleStatus == "5" || vehicleStatus == "6")
//                {
//                    Message(MessageList.Error.E0013, "ต่อประกันภัยสำหรับรถ "+vehicleInsuranceTypeOne.AVehicleInfo.PlateNumber+" ได้", "รถได้สิ้นสุดการใช้งานแล้ว");
//                    cmdCancel.Focus();
//                    return false;
//                }
//            }
//            key = null;
//            vehicleInsuranceTypeOne = null;

//            return true;
//        }
		
//        public void createInsuranceTypeOne()
//        {
//            try
//            {
//                if(validInsuranceTypeOne())
//                {
//                    facadeInsuranceTypeOne.ObjInsuranceTypeOne.AInsuranceCompany = (InsuranceCompany)cmbInsuranceCompCode.SelectedItem;
//                    facadeInsuranceTypeOne.ObjInsuranceTypeOne.InsuranceInchargeName = txtInsuranceInchargeName.Text;
//                    facadeInsuranceTypeOne.ObjInsuranceTypeOne.InsuranceInchargeTelNo = txtInsuranceInchargeTe.Text;
//                    facadeInsuranceTypeOne.ObjInsuranceTypeOne.APeriod.From = dtpStartDate.Value;
//                    facadeInsuranceTypeOne.ObjInsuranceTypeOne.APeriod.To = dtpEndDate.Value;
//                    if(facadeInsuranceTypeOne.InsertInsuranceTypeOne())
//                    {
//                        InitForm();
//                    }
//                }
//            }
//            catch(SqlException sqlex)
//            {
//                Message(sqlex);
//            }
//            catch(AppExceptionBase ex)
//            {
//                Message(ex);
//            }
//            catch(Exception ex)
//            {
//                Message(ex);
//            }
//            finally
//            {
//            }	
//        }
//        //============================== event ==============================
//        private void frmCreateInsuranceTypeOne_Load(object sender, System.EventArgs e)
//        {
//            mdiParent = (frmMain)this.MdiParent;
//            InitForm();
//        }

//        private void txtPolicyNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
//        {
//            if(e.KeyCode == Keys.Enter)
//            {
//                RefreshForm();
//            }
//        }

//        private void cmdCancel_Click(object sender, System.EventArgs e)
//        {
//            ExitForm();
//        }

//        private void dtpStartDate_ValueChanged(object sender, System.EventArgs e)
//        {
//            dtpEndDate.Value = dtpStartDate.Value.AddYears(1);
//        }

//        private void txtMovePolicy_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
//        {
//            if(e.KeyCode == Keys.Enter)
//            {
//                MovePolicyEnter();
//            }
//        }

//        private void txtMovePolicy_DoubleClick(object sender, System.EventArgs e)
//        {
//            callList();						
//        }

//        private void mniSelectAllMove_Click(object sender, System.EventArgs e)
//        {
//            selectAll(fpsMovePolicy_Sheet1, true);
//        }

//        private void mniUnSelectAllMove_Click(object sender, System.EventArgs e)
//        {
//            selectAll(fpsMovePolicy_Sheet1, false);
//        }

//        private void mniSelectAll_Click(object sender, System.EventArgs e)
//        {
//            selectAll(fpsNewPolicy_Sheet1, true);
//        }

//        private void mniUnSelectAll_Click(object sender, System.EventArgs e)
//        {
//            selectAll(fpsNewPolicy_Sheet1, false);
//        }
		
//        private void cmdRight_Click(object sender, System.EventArgs e)
//        {
//            bool mustRefresh = false;
//            for(int i=0; i<fpsMovePolicy_Sheet1.RowCount; i++)
//            {
//                if((bool)fpsMovePolicy_Sheet1.Cells[i,1].Value)
//                {
//                    mustRefresh = true;
//                    facadeInsuranceTypeOne.ObjInsuranceTypeOne.AVehicleInsuranceList.Add((VehicleInsuranceTypeOne)fpsMovePolicy_Sheet1.Cells[i,0].Tag);
//                }
//            }
//            if(mustRefresh)
//            {
//                displayMoveInsuranceDetail();
//                displayVehicleInsurance();			
//            }
//        }

//        private void cmdLeft_Click(object sender, System.EventArgs e)
//        {
//            bool mustRefresh = false;
//            VehicleInsuranceTypeOne vehicleInsurance;
//            for(int i=0; i<fpsNewPolicy_Sheet1.RowCount; i++)
//            {
//                if((bool)fpsNewPolicy_Sheet1.Cells[i,1].Value)
//                {
//                    mustRefresh = true;
//                    vehicleInsurance = facadeInsuranceTypeOne.ObjInsuranceTypeOne.AVehicleInsuranceList[fpsNewPolicy_Sheet1.Cells[i,0].Text];
//                    deleteVehicleInsurance(vehicleInsurance);
//                    if(facadeInsuranceTypeOne.ObjMoveInsuranceTypeOne.AVehicleInsuranceList.Contain(vehicleInsurance))
//                    {
//                        addMoveInsuranceDetail(vehicleInsurance);
//                    }
//                }
//            }
//            if(mustRefresh)
//            {
//                displayMoveInsuranceDetail();
//                displayVehicleInsurance();
//            }
//            vehicleInsurance = null;
//        }

//        private void cmdAllRight_Click(object sender, System.EventArgs e)
//        {
//            for(int i=0; i<fpsMovePolicy_Sheet1.RowCount; i++)
//            {
//                facadeInsuranceTypeOne.ObjInsuranceTypeOne.AVehicleInsuranceList.Add((VehicleInsuranceTypeOne)fpsMovePolicy_Sheet1.Cells[i,0].Tag);
//            }
//            displayMoveInsuranceDetail();
//            displayVehicleInsurance();
//        }

//        private void cmdAllLeft_Click(object sender, System.EventArgs e)
//        {
//            VehicleInsuranceTypeOne vehicleInsurance;
//            for(int i=0; i<fpsNewPolicy_Sheet1.RowCount; i++)
//            {
//                vehicleInsurance = facadeInsuranceTypeOne.ObjInsuranceTypeOne.AVehicleInsuranceList[fpsNewPolicy_Sheet1.Cells[i,0].Text];
//                deleteVehicleInsurance(vehicleInsurance);
//                if(facadeInsuranceTypeOne.ObjMoveInsuranceTypeOne.AVehicleInsuranceList.Contain(vehicleInsurance))
//                {
//                    addMoveInsuranceDetail(vehicleInsurance);					
//                }				
//            }
//            displayMoveInsuranceDetail();
//            displayVehicleInsurance();
//            vehicleInsurance = null;
//        }

//        private void cmdCalculate_Click(object sender, System.EventArgs e)
//        {
//            calculateInsuranceTypeOne();
//        }

//        private void cmdOK_Click(object sender, System.EventArgs e)
//        {
//            createInsuranceTypeOne();
//        }

//        private void btnAddDetail_Click(object sender, System.EventArgs e)
//        {
//            if(validHeader())
//            {
//                setModeAdd(true);
//                enableInsurance(false);
//                txtPolicyNo.Enabled = false;
//                btnAddDetail.Enabled = false;
//                MainMenuNewStatus = true;	
//                mdiParent.EnableNewCommand(true);
//            }
//        }
//    }
//}