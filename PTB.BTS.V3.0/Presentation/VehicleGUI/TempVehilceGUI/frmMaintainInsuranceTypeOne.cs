//using System;
//using System.Drawing;
//using System.Collections;
//using System.ComponentModel;
//using System.Windows.Forms;
//using System.Data.SqlClient;

//using SystemFramework.AppMessage;
//using SystemFramework.AppException;
//using SystemFramework.AppConfig;

//using Entity.CommonEntity;
//using Entity.VehicleEntities;
//using Entity.ContractEntities;

//using Facade.CommonFacade;
//using Facade.VehicleFacade;

//using Presentation.CommonGUI;

//namespace Presentation.VehicleGUI
//{
//    public class frmMaintainInsuranceTypeOne : ChildFormBase, IMDIChildForm ,IDeleteMDIChildForm
//    {
//        #region - Windows Form Designer generated code-
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

//        private System.Windows.Forms.GroupBox groupBox1;
//        private System.Windows.Forms.TextBox txtInsuranceInchargeTel;
//        private System.Windows.Forms.TextBox txtInsuranceInchargeName;
//        private System.Windows.Forms.ComboBox cboInsuranceCompName;
//        private System.Windows.Forms.TextBox txtPolicyNo;
//        private System.Windows.Forms.DateTimePicker dtpStartDate;
//        private System.Windows.Forms.DateTimePicker dtpEndDate;
//        private System.Windows.Forms.ContextMenu contextMenu1;
//        private System.Windows.Forms.MenuItem mniAdd;
//        private System.Windows.Forms.MenuItem mniEdit;
//        private System.Windows.Forms.MenuItem mniDelete;
//        private FarPoint.Win.Spread.FpSpread fpsMaintainInsurance;
//        private FarPoint.Win.Spread.SheetView fpsMaintainInsurance_Sheet1;
//        private System.Windows.Forms.Button cmdShow;
//        private System.Windows.Forms.Button cmdEdit;
//        private System.Windows.Forms.Button cmdAdd;
//        private System.Windows.Forms.Button cmdDelete;
//        private System.Windows.Forms.Label lblInsuranceInchargeTel;
//        private System.Windows.Forms.Label lblInsuranceInchargeName;
//        private System.Windows.Forms.Label lblInsuranceCompName;
//        private System.Windows.Forms.Label lblPolicyNo;
//        private System.Windows.Forms.Label lblStartDate;
//        private System.Windows.Forms.Label lblEndDate;

//        private System.ComponentModel.Container components = null;
//        private void InitializeComponent()
//        {
//            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
//            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
//            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
//            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
//            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
//            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
//            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
//            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
//            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMaintainInsuranceTypeOne));
//            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
//            this.groupBox1 = new System.Windows.Forms.GroupBox();
//            this.cmdShow = new System.Windows.Forms.Button();
//            this.lblInsuranceInchargeTel = new System.Windows.Forms.Label();
//            this.txtInsuranceInchargeTel = new System.Windows.Forms.TextBox();
//            this.txtInsuranceInchargeName = new System.Windows.Forms.TextBox();
//            this.lblInsuranceInchargeName = new System.Windows.Forms.Label();
//            this.cboInsuranceCompName = new System.Windows.Forms.ComboBox();
//            this.txtPolicyNo = new System.Windows.Forms.TextBox();
//            this.lblInsuranceCompName = new System.Windows.Forms.Label();
//            this.lblPolicyNo = new System.Windows.Forms.Label();
//            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
//            this.lblStartDate = new System.Windows.Forms.Label();
//            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
//            this.lblEndDate = new System.Windows.Forms.Label();
//            this.fpsMaintainInsurance = new FarPoint.Win.Spread.FpSpread();
//            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
//            this.mniAdd = new System.Windows.Forms.MenuItem();
//            this.mniEdit = new System.Windows.Forms.MenuItem();
//            this.mniDelete = new System.Windows.Forms.MenuItem();
//            this.fpsMaintainInsurance_Sheet1 = new FarPoint.Win.Spread.SheetView();
//            this.cmdEdit = new System.Windows.Forms.Button();
//            this.cmdAdd = new System.Windows.Forms.Button();
//            this.cmdDelete = new System.Windows.Forms.Button();
//            this.groupBox1.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.fpsMaintainInsurance)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.fpsMaintainInsurance_Sheet1)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // groupBox1
//            // 
//            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.groupBox1.Controls.Add(this.cmdShow);
//            this.groupBox1.Controls.Add(this.lblInsuranceInchargeTel);
//            this.groupBox1.Controls.Add(this.txtInsuranceInchargeTel);
//            this.groupBox1.Controls.Add(this.txtInsuranceInchargeName);
//            this.groupBox1.Controls.Add(this.lblInsuranceInchargeName);
//            this.groupBox1.Controls.Add(this.cboInsuranceCompName);
//            this.groupBox1.Controls.Add(this.txtPolicyNo);
//            this.groupBox1.Controls.Add(this.lblInsuranceCompName);
//            this.groupBox1.Controls.Add(this.lblPolicyNo);
//            this.groupBox1.Controls.Add(this.dtpStartDate);
//            this.groupBox1.Controls.Add(this.lblStartDate);
//            this.groupBox1.Controls.Add(this.dtpEndDate);
//            this.groupBox1.Controls.Add(this.lblEndDate);
//            this.groupBox1.Location = new System.Drawing.Point(12, 8);
//            this.groupBox1.Name = "groupBox1";
//            this.groupBox1.Size = new System.Drawing.Size(808, 152);
//            this.groupBox1.TabIndex = 0;
//            this.groupBox1.TabStop = false;
//            this.groupBox1.Text = "กรมธรรม์ประกันภัยชั้นหนึ่ง";
//            // 
//            // cmdShow
//            // 
//            this.cmdShow.Location = new System.Drawing.Point(504, 120);
//            this.cmdShow.Name = "cmdShow";
//            this.cmdShow.Size = new System.Drawing.Size(96, 23);
//            this.cmdShow.TabIndex = 7;
//            this.cmdShow.Text = "ดูรายละเอียด";
//            this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
//            // 
//            // lblInsuranceInchargeTel
//            // 
//            this.lblInsuranceInchargeTel.Location = new System.Drawing.Point(432, 88);
//            this.lblInsuranceInchargeTel.Name = "lblInsuranceInchargeTel";
//            this.lblInsuranceInchargeTel.Size = new System.Drawing.Size(56, 23);
//            this.lblInsuranceInchargeTel.TabIndex = 11;
//            this.lblInsuranceInchargeTel.Text = "โทรศัพท์";
//            // 
//            // txtInsuranceInchargeTel
//            // 
//            this.txtInsuranceInchargeTel.Enabled = false;
//            this.txtInsuranceInchargeTel.Location = new System.Drawing.Point(504, 88);
//            this.txtInsuranceInchargeTel.MaxLength = 50;
//            this.txtInsuranceInchargeTel.Name = "txtInsuranceInchargeTel";
//            this.txtInsuranceInchargeTel.Size = new System.Drawing.Size(208, 20);
//            this.txtInsuranceInchargeTel.TabIndex = 6;
//            this.txtInsuranceInchargeTel.Text = "";
//            // 
//            // txtInsuranceInchargeName
//            // 
//            this.txtInsuranceInchargeName.Enabled = false;
//            this.txtInsuranceInchargeName.Location = new System.Drawing.Point(120, 88);
//            this.txtInsuranceInchargeName.MaxLength = 60;
//            this.txtInsuranceInchargeName.Name = "txtInsuranceInchargeName";
//            this.txtInsuranceInchargeName.Size = new System.Drawing.Size(280, 20);
//            this.txtInsuranceInchargeName.TabIndex = 5;
//            this.txtInsuranceInchargeName.Text = "";
//            // 
//            // lblInsuranceInchargeName
//            // 
//            this.lblInsuranceInchargeName.Location = new System.Drawing.Point(24, 88);
//            this.lblInsuranceInchargeName.Name = "lblInsuranceInchargeName";
//            this.lblInsuranceInchargeName.Size = new System.Drawing.Size(64, 23);
//            this.lblInsuranceInchargeName.TabIndex = 8;
//            this.lblInsuranceInchargeName.Text = "ชื่อเจ้าหน้าที่";
//            // 
//            // cboInsuranceCompName
//            // 
//            this.cboInsuranceCompName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
//            this.cboInsuranceCompName.Location = new System.Drawing.Point(120, 56);
//            this.cboInsuranceCompName.Name = "cboInsuranceCompName";
//            this.cboInsuranceCompName.Size = new System.Drawing.Size(280, 21);
//            this.cboInsuranceCompName.TabIndex = 3;
//            // 
//            // txtPolicyNo
//            // 
//            this.txtPolicyNo.Location = new System.Drawing.Point(120, 24);
//            this.txtPolicyNo.MaxLength = 20;
//            this.txtPolicyNo.Name = "txtPolicyNo";
//            this.txtPolicyNo.Size = new System.Drawing.Size(176, 20);
//            this.txtPolicyNo.TabIndex = 1;
//            this.txtPolicyNo.Text = "";
//            this.txtPolicyNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPolicyNo_KeyDown);
//            this.txtPolicyNo.DoubleClick += new System.EventHandler(this.txtPolicyNo_DoubleClick);
//            // 
//            // lblInsuranceCompName
//            // 
//            this.lblInsuranceCompName.Location = new System.Drawing.Point(24, 56);
//            this.lblInsuranceCompName.Name = "lblInsuranceCompName";
//            this.lblInsuranceCompName.Size = new System.Drawing.Size(88, 23);
//            this.lblInsuranceCompName.TabIndex = 1;
//            this.lblInsuranceCompName.Text = "ชื่อบริษัทประกันภัย";
//            // 
//            // lblPolicyNo
//            // 
//            this.lblPolicyNo.Location = new System.Drawing.Point(24, 24);
//            this.lblPolicyNo.Name = "lblPolicyNo";
//            this.lblPolicyNo.Size = new System.Drawing.Size(72, 23);
//            this.lblPolicyNo.TabIndex = 0;
//            this.lblPolicyNo.Text = "เลขที่กรมธรรม์";
//            // 
//            // dtpStartDate
//            // 
//            this.dtpStartDate.CustomFormat = "dd/MM/yyyy";
//            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
//            this.dtpStartDate.Location = new System.Drawing.Point(504, 24);
//            this.dtpStartDate.Name = "dtpStartDate";
//            this.dtpStartDate.Size = new System.Drawing.Size(96, 20);
//            this.dtpStartDate.TabIndex = 2;
//            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
//            // 
//            // lblStartDate
//            // 
//            this.lblStartDate.Location = new System.Drawing.Point(432, 24);
//            this.lblStartDate.Name = "lblStartDate";
//            this.lblStartDate.Size = new System.Drawing.Size(64, 23);
//            this.lblStartDate.TabIndex = 4;
//            this.lblStartDate.Text = "วันที่เริ่มต้น";
//            // 
//            // dtpEndDate
//            // 
//            this.dtpEndDate.CustomFormat = "dd/MM/yyyy";
//            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
//            this.dtpEndDate.Location = new System.Drawing.Point(504, 56);
//            this.dtpEndDate.Name = "dtpEndDate";
//            this.dtpEndDate.Size = new System.Drawing.Size(96, 20);
//            this.dtpEndDate.TabIndex = 4;
//            // 
//            // lblEndDate
//            // 
//            this.lblEndDate.Location = new System.Drawing.Point(432, 56);
//            this.lblEndDate.Name = "lblEndDate";
//            this.lblEndDate.Size = new System.Drawing.Size(56, 23);
//            this.lblEndDate.TabIndex = 6;
//            this.lblEndDate.Text = "วันที่สิ้นสุด";
//            // 
//            // fpsMaintainInsurance
//            // 
//            this.fpsMaintainInsurance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
//            this.fpsMaintainInsurance.ContextMenu = this.contextMenu1;
//            this.fpsMaintainInsurance.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
//            this.fpsMaintainInsurance.Location = new System.Drawing.Point(14, 168);
//            this.fpsMaintainInsurance.Name = "fpsMaintainInsurance";
//            this.fpsMaintainInsurance.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
//                                                                                              this.fpsMaintainInsurance_Sheet1});
//            this.fpsMaintainInsurance.Size = new System.Drawing.Size(806, 192);
//            this.fpsMaintainInsurance.TabIndex = 1;
//            this.fpsMaintainInsurance.TabStop = false;
//            this.fpsMaintainInsurance.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsMaintainInsurance_CellDoubleClick);
//            // 
//            // contextMenu1
//            // 
//            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
//                                                                                         this.mniAdd,
//                                                                                         this.mniEdit,
//                                                                                         this.mniDelete});
//            // 
//            // mniAdd
//            // 
//            this.mniAdd.Index = 0;
//            this.mniAdd.Text = "เพิ่ม";
//            this.mniAdd.Click += new System.EventHandler(this.mniAdd_Click);
//            // 
//            // mniEdit
//            // 
//            this.mniEdit.Index = 1;
//            this.mniEdit.Text = "แก้ไข";
//            this.mniEdit.Click += new System.EventHandler(this.mniEdit_Click);
//            // 
//            // mniDelete
//            // 
//            this.mniDelete.Index = 2;
//            this.mniDelete.Text = "ลบ";
//            this.mniDelete.Click += new System.EventHandler(this.mniDelete_Click);
//            // 
//            // fpsMaintainInsurance_Sheet1
//            // 
//            this.fpsMaintainInsurance_Sheet1.Reset();
//            // Formulas and custom names must be loaded with R1C1 reference style
//            this.fpsMaintainInsurance_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
//            this.fpsMaintainInsurance_Sheet1.ColumnCount = 9;
//            this.fpsMaintainInsurance_Sheet1.RowCount = 1;
//            this.fpsMaintainInsurance_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "ลำดับที่";
//            this.fpsMaintainInsurance_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "ทะเบียนรถ";
//            this.fpsMaintainInsurance_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ยี่ห้อรถ";
//            this.fpsMaintainInsurance_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "รุ่นรถ";
//            this.fpsMaintainInsurance_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "ทุนประกัน";
//            this.fpsMaintainInsurance_Sheet1.ColumnHeader.Cells.Get(0, 6).Text = "เบี้ยประกัน";
//            this.fpsMaintainInsurance_Sheet1.ColumnHeader.Cells.Get(0, 7).Text = "วันที่เข้าร่วม";
//            this.fpsMaintainInsurance_Sheet1.ColumnHeader.Cells.Get(0, 8).Text = "ลูกค้า";
//            textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
//            textCellType1.DropDownButton = false;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(0).CellType = textCellType1;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(0).Visible = false;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(1).AllowAutoSort = true;
//            numberCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
//            numberCellType1.DropDownButton = false;
//            numberCellType1.FixedPoint = false;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(1).CellType = numberCellType1;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(1).Label = "ลำดับที่";
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(1).Locked = false;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(1).Resizable = false;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(2).AllowAutoSort = true;
//            textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
//            textCellType2.DropDownButton = false;
//            textCellType2.ReadOnly = true;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(2).CellType = textCellType2;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(2).Label = "ทะเบียนรถ";
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(2).Locked = false;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(2).Resizable = false;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(2).Width = 80F;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(3).AllowAutoSort = true;
//            textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
//            textCellType3.DropDownButton = false;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(3).CellType = textCellType3;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(3).Label = "ยี่ห้อรถ";
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(3).Locked = false;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(3).Resizable = false;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(3).Width = 100F;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(4).AllowAutoSort = true;
//            textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
//            textCellType4.DropDownButton = false;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(4).CellType = textCellType4;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(4).Label = "รุ่นรถ";
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(4).Locked = false;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(4).Resizable = false;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(4).Width = 180F;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(5).AllowAutoSort = true;
//            numberCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
//            numberCellType2.DecimalPlaces = 2;
//            numberCellType2.DecimalSeparator = ".";
//            numberCellType2.DropDownButton = false;
//            numberCellType2.MinimumValue = 0;
//            numberCellType2.ReadOnly = true;
//            numberCellType2.Separator = ",";
//            numberCellType2.ShowSeparator = true;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(5).CellType = numberCellType2;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(5).Label = "ทุนประกัน";
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(5).Locked = false;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(5).Resizable = false;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(5).Width = 90F;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(6).AllowAutoSort = true;
//            numberCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
//            numberCellType3.DecimalPlaces = 2;
//            numberCellType3.DecimalSeparator = ".";
//            numberCellType3.DropDownButton = false;
//            numberCellType3.MaximumValue = 999999.99;
//            numberCellType3.MinimumValue = 0;
//            numberCellType3.Separator = ",";
//            numberCellType3.ShowSeparator = true;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(6).CellType = numberCellType3;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(6).Label = "เบี้ยประกัน";
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(6).Locked = false;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(6).Resizable = false;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(6).Width = 90F;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(7).AllowAutoSort = true;
//            dateTimeCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
//            dateTimeCellType1.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
//            dateTimeCellType1.DateDefault = new System.DateTime(2006, 4, 28, 11, 33, 32, 0);
//            dateTimeCellType1.DropDownButton = false;
//            dateTimeCellType1.TimeDefault = new System.DateTime(2006, 4, 28, 11, 33, 32, 0);
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(7).CellType = dateTimeCellType1;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(7).Label = "วันที่เข้าร่วม";
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(7).Resizable = false;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(7).Width = 90F;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(8).AllowAutoSort = true;
//            textCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
//            textCellType5.DropDownButton = false;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(8).CellType = textCellType5;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(8).Label = "ลูกค้า";
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(8).Locked = false;
//            this.fpsMaintainInsurance_Sheet1.Columns.Get(8).Resizable = false;
//            this.fpsMaintainInsurance_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
//            this.fpsMaintainInsurance_Sheet1.RowHeader.Columns.Default.Resizable = false;
//            this.fpsMaintainInsurance_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
//            this.fpsMaintainInsurance_Sheet1.SheetName = "Sheet1";
//            this.fpsMaintainInsurance_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
//            // 
//            // cmdEdit
//            // 
//            this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
//            this.cmdEdit.Location = new System.Drawing.Point(380, 370);
//            this.cmdEdit.Name = "cmdEdit";
//            this.cmdEdit.TabIndex = 9;
//            this.cmdEdit.Text = "แก้ไข";
//            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
//            // 
//            // cmdAdd
//            // 
//            this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
//            this.cmdAdd.Location = new System.Drawing.Point(300, 370);
//            this.cmdAdd.Name = "cmdAdd";
//            this.cmdAdd.TabIndex = 8;
//            this.cmdAdd.Text = "เพิ่ม";
//            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
//            // 
//            // cmdDelete
//            // 
//            this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
//            this.cmdDelete.Location = new System.Drawing.Point(460, 370);
//            this.cmdDelete.Name = "cmdDelete";
//            this.cmdDelete.TabIndex = 10;
//            this.cmdDelete.Text = "ลบ";
//            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
//            // 
//            // frmMaintainInsuranceTypeOne
//            // 
//            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
//            this.ClientSize = new System.Drawing.Size(834, 408);
//            this.Controls.Add(this.cmdEdit);
//            this.Controls.Add(this.cmdAdd);
//            this.Controls.Add(this.cmdDelete);
//            this.Controls.Add(this.fpsMaintainInsurance);
//            this.Controls.Add(this.groupBox1);
//            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
//            this.Name = "frmMaintainInsuranceTypeOne";
//            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
//            //this.Text = "ข้อมูลประกันภัยชั้นหนึ่งตามเลขที่กรมธรรม์";
//            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
//            this.Load += new System.EventHandler(this.frmMaintainInsuranceTypeOne_Load);
//            this.groupBox1.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.fpsMaintainInsurance)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.fpsMaintainInsurance_Sheet1)).EndInit();
//            this.ResumeLayout(false);

//        }
//        #endregion

//        #region - Private - 
//        private bool isReadonly = true;
//        private frmMain mdiParent;
//        private frmInsuranceTypeOneEntry frmEntry;

//        private int SelectedRow
//        {
//            get{return fpsMaintainInsurance_Sheet1.ActiveRowIndex;}
//        }

//        private string SelectedKey
//        {
//            get{return fpsMaintainInsurance_Sheet1.Cells[SelectedRow,0].Text;}
//        }

//        private VehicleInsuranceTypeOne SelectedVehicleInsuranceTypeOne
//        {
//            get{return facadeInsuranceTypeOne.ObjInsuranceTypeOne.AVehicleInsuranceList [SelectedKey];}
//        }
//        #endregion

//        #region - Property - 
//            private InsuranceTypeOneFacade facadeInsuranceTypeOne;
//            public InsuranceTypeOneFacade FacadeInsuranceTypeOne
//            {
//                get{return facadeInsuranceTypeOne;}
//            }
//        #endregion

////		================================= Constructor ================================
//        public frmMaintainInsuranceTypeOne() : base()
//        {
//            InitializeComponent();
//            newObject();
//            cboInsuranceCompName.DataSource = facadeInsuranceTypeOne.DataSourceInsuranceCompName;
//            isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleDocumentMaintainInsuranceTypeOne");
//            this.title = UserProfile.GetFormName("miVehicle", "miVehicleDocumentMaintainInsuranceTypeOne");

//        }
//        public override string FormID()
//        {
//            return UserProfile.GetFormID("miVehicle", "miVehicleDocumentMaintainInsuranceTypeOne");
//        }

//        public void newObject()
//        {
//            frmEntry = new frmInsuranceTypeOneEntry(this);
//            facadeInsuranceTypeOne = new InsuranceTypeOneFacade();
//        }
////		=============================== Private Method ================================	
//        #region - Private - 
//            private void visibleAll(bool value)
//            {
//                visibleInsurance(value);
//                visibleInsuranceDetail(value);
//            }
			
//            private void visibleInsurance(bool value)
//            {
//                lblStartDate.Visible = value;
//                dtpStartDate.Visible = value;
//                lblEndDate.Visible = value;
//                dtpEndDate.Visible = value;
//                lblInsuranceCompName.Visible = value;
//                cboInsuranceCompName.Visible = value;				
//                lblInsuranceInchargeName.Visible = value;
//                txtInsuranceInchargeName.Visible = value;
//                lblInsuranceInchargeTel.Visible = value;
//                txtInsuranceInchargeTel.Visible = value;
//                cmdShow.Visible = value;
//            }

//            private void visibleInsuranceDetail(bool value)
//            {
//                fpsMaintainInsurance.Visible = value;
//                cmdAdd.Visible = value;
//                cmdEdit.Visible = value;
//                cmdDelete.Visible = value;
//            }

//            private void enableInsurance(bool value)
//            {
//                cboInsuranceCompName.Enabled = value;
//                dtpStartDate.Enabled = value;
//                dtpEndDate.Enabled = value;
//                txtInsuranceInchargeName.Enabled = value;
//                txtInsuranceInchargeTel.Enabled = value;
//                cmdShow.Enabled = value;
//            }

//            private void enableAmendDetail(bool value)
//            {
//                cmdEdit.Enabled = value;
//                cmdDelete.Enabled = value;
//                mniEdit.Enabled = value;
//                mniDelete.Enabled = value;
//            }

//            private void clearAll()
//            {
//                clearInsurance();
//                clearInsuranceDetail();
//            }

//            private void clearInsurance()
//            {
//                dtpStartDate.Value = DateTime.Today;
//                if(cboInsuranceCompName.Items.Count>0)
//                {
//                    cboInsuranceCompName.SelectedIndex = 0;
//                }				
//                txtInsuranceInchargeName.Text = "";
//                txtInsuranceInchargeTel.Text = "";
//            }

//            private void clearInsuranceDetail()
//            {
//                fpsMaintainInsurance_Sheet1.RowCount = 0;
//            }	
//        #endregion

//        #region - validate - 
//            private bool validateHeader()
//            {
//                if(dtpStartDate.Value > dtpEndDate.Value)
//                {
//                    Message(MessageList.Error.E0011,"วันที่เริ่มต้น", "วันที่สิ้นสุด");
//                    dtpEndDate.Focus();
//                    return false;
//                }

//                if (cboInsuranceCompName.SelectedIndex == -1)
//                {
//                    Message(MessageList.Error.E0003,"ชื่อบริษัทประกันภัย");
//                    cboInsuranceCompName.Focus();
//                    return false;
//                }

//                if (txtInsuranceInchargeName.Text == "")
//                {
//                    Message(MessageList.Error.E0002,"ชื่อเจ้าหน้าที่");
//                    txtInsuranceInchargeName.Focus();
//                    return false;
//                }
//                return true;
//            }

//            private bool mustUpdate()
//            {
//                if(txtPolicyNo.Text != facadeInsuranceTypeOne.ObjInsuranceTypeOne.PolicyNo)
//                {
//                    return true;
//                }
//                if(cboInsuranceCompName.Text != facadeInsuranceTypeOne.ObjInsuranceTypeOne.AInsuranceCompany.AName.Thai)
//                {
//                    return true;
//                }
//                if(dtpStartDate.Value != facadeInsuranceTypeOne.ObjInsuranceTypeOne.APeriod.From)
//                {
//                    return true;
//                }
//                if(dtpEndDate.Value != facadeInsuranceTypeOne.ObjInsuranceTypeOne.APeriod.To)
//                {
//                    return true;
//                }
//                if(txtInsuranceInchargeName.Text != facadeInsuranceTypeOne.ObjInsuranceTypeOne.InsuranceInchargeName)
//                {
//                    return true;
//                }
//                if(txtInsuranceInchargeTel.Text	!= facadeInsuranceTypeOne.ObjInsuranceTypeOne.InsuranceInchargeTelNo)
//                {
//                    return true;
//                }
//                return false;
//            }
//        #endregion

//        private void getInsuranceTypeOne()
//        {
//            facadeInsuranceTypeOne.ObjInsuranceTypeOne.PolicyNo					= txtPolicyNo.Text;
//            facadeInsuranceTypeOne.ObjInsuranceTypeOne.AInsuranceCompany		= (InsuranceCompany)cboInsuranceCompName.SelectedItem;
//            facadeInsuranceTypeOne.ObjInsuranceTypeOne.APeriod.From				= dtpStartDate.Value;
//            facadeInsuranceTypeOne.ObjInsuranceTypeOne.APeriod.To				= dtpEndDate.Value;
//            facadeInsuranceTypeOne.ObjInsuranceTypeOne.InsuranceInchargeName	= txtInsuranceInchargeName.Text;
//            facadeInsuranceTypeOne.ObjInsuranceTypeOne.InsuranceInchargeTelNo	= txtInsuranceInchargeTel.Text;
//        }

//        private void setInsuranceTypeOne()
//        {	
//            txtPolicyNo.Text				= facadeInsuranceTypeOne.ObjInsuranceTypeOne.PolicyNo;
//            cboInsuranceCompName.Text		= facadeInsuranceTypeOne.ObjInsuranceTypeOne.AInsuranceCompany.AName.Thai;
//            dtpStartDate.Value				= facadeInsuranceTypeOne.ObjInsuranceTypeOne.APeriod.From;
//            dtpEndDate.Value				= facadeInsuranceTypeOne.ObjInsuranceTypeOne.APeriod.To;
//            txtInsuranceInchargeName.Text	= facadeInsuranceTypeOne.ObjInsuranceTypeOne.InsuranceInchargeName;
//            txtInsuranceInchargeTel.Text	= facadeInsuranceTypeOne.ObjInsuranceTypeOne.InsuranceInchargeTelNo;
//        }

//        private void bindVehicleInsuranceTypeOne(int row, VehicleInsuranceTypeOne value)
//        {
//            fpsMaintainInsurance_Sheet1.Cells[row,0].Text = value.EntityKey;
//            fpsMaintainInsurance_Sheet1.Cells[row,1].Text = value.OrderNo.ToString();
//            fpsMaintainInsurance_Sheet1.Cells[row,2].Text = value.AVehicleInfo.PlateNumber;
//            fpsMaintainInsurance_Sheet1.Cells[row,3].Text = value.AVehicleInfo.AModel.ABrand.AName.English;
//            fpsMaintainInsurance_Sheet1.Cells[row,4].Text = value.AVehicleInfo.AModel.AName.English;
//            fpsMaintainInsurance_Sheet1.Cells[row,5].Text = GUIFunction.GetString(value.SumAssured);
//            fpsMaintainInsurance_Sheet1.Cells[row,6].Text = GUIFunction.GetString(value.PremiumAmount);
//            fpsMaintainInsurance_Sheet1.Cells[row,7].Text = GUIFunction.GetString(value.AffiliateDate);

//            ContractBase contractBase = facadeInsuranceTypeOne.GetCurrentVehicleContract(value.AVehicleInfo);
//            if (contractBase != null)
//            {
//                fpsMaintainInsurance_Sheet1.Cells[row,8].Text = contractBase.ACustomer.ShortName;
//            }
//            else
//            {
//                fpsMaintainInsurance_Sheet1.Cells[row,8].Text = "";
//            }
//            contractBase = null;
//        }

//        private void bindVehicleInsuranceList()
//        {
//            VehicleInsuranceList vehicleInsuranceList = facadeInsuranceTypeOne.ObjInsuranceTypeOne.AVehicleInsuranceList;
//            fpsMaintainInsurance_Sheet1.RowCount = vehicleInsuranceList.Count;
//            for(int i=0; i<vehicleInsuranceList.Count; i++)
//            {
//                bindVehicleInsuranceTypeOne(i, vehicleInsuranceList[i]);
//            }
//            if(fpsMaintainInsurance_Sheet1.RowCount == 0)
//            {
//                enableAmendDetail(false);
//            }
//            else
//            {
//                mdiParent.RefreshMasterCount();
//                enableAmendDetail(true);
//            }
//            vehicleInsuranceList = null;
//        }

//        private void showDetail()
//        {
//            visibleInsuranceDetail(true);
//            enableInsurance(false);
//            if(facadeInsuranceTypeOne.ObjInsuranceTypeOne.AVehicleInsuranceList.Count == 0)
//            {
//                enableAmendDetail(false);
//            }
//            else
//            {
//                bindVehicleInsuranceList();
//            }
//        }

////		=============================== Public Method =================================
//        public bool AddRow(VehicleInsuranceTypeOne value)
//        {
//            bool result = false;
//            try
//            {
//                if (facadeInsuranceTypeOne.InsertInsuranceTypeOne(value))
//                {
//                    int index = fpsMaintainInsurance_Sheet1.RowCount++;
//                    bindVehicleInsuranceTypeOne(index, value);
//                    enableAmendDetail(true);
//                    mdiParent.RefreshMasterCount();
//                    result = true;
//                }
//                else
//                {				
//                    result = false;
//                }
//            }
//            catch(SqlException ex)
//            {
//                Message(ex);
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
//            return result;
//        }

//        public bool UpdateRow(VehicleInsuranceTypeOne value)
//        {
//            bool result = false;
//            try
//            {
//                if (facadeInsuranceTypeOne.UpdateInsuranceTypeOne(value))
//                {
//                    bindVehicleInsuranceTypeOne(SelectedRow, value);				
//                    result = true;
//                }
//                else
//                {				
//                    result = false;
//                }
//            }
//            catch(SqlException ex)
//            {
//                Message(ex);
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
//            return result;
//        }
//        public override int MasterCount()
//        {
//            return facadeInsuranceTypeOne.ObjInsuranceTypeOne.AVehicleInsuranceList.Count;
//        }

////		================================= Base Event ==================================
//        public void InitForm()
//        {
//            baseInitMenuMDIParent(mdiParent);
//            txtPolicyNo.Enabled = true;
//            txtPolicyNo.Text = "";
//            visibleAll(false);
//            newObject();
//            mdiParent.RefreshMasterCount();
//        }

//        public void RefreshForm()
//        {
//            visibleInsurance(true);
//            mdiParent.EnableNewCommand(true);
//            txtPolicyNo.Enabled = false;
//            try
//            {
//                if(facadeInsuranceTypeOne.DisplayInsuranceTypeOne(txtPolicyNo.Text))
//                {
//                    action = ActionType.EDIT;
//                    mdiParent.EnableDeleteCommand(true);
//                    txtPolicyNo.Enabled = false;
//                    enableInsurance(true);
//                    if(facadeInsuranceTypeOne.ObjInsuranceTypeOne.AVehicleInsuranceList.Count>0)
//                    {
//                        dtpStartDate.Enabled = false;
//                        dtpEndDate.Enabled = false;					
//                    }
//                    else
//                    {
//                        dtpStartDate.Enabled = true;
//                        dtpEndDate.Enabled = true;		
//                    }
//                    setInsuranceTypeOne();
//                }
//                else
//                {
//                    action = ActionType.ADD;
//                    enableInsurance(true);
//                    clearAll();
//                }
//            }
//            catch(SqlException ex)
//            {
//                Message(ex);
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


//            if(isReadonly)
//            {
//                if(action == ActionType.ADD)
//                {
//                    cmdShow.Enabled = false;
//                }
//                else 
//                {
//                    cboInsuranceCompName.Enabled = false;
//                    txtInsuranceInchargeName.Enabled = false;
//                    txtInsuranceInchargeTel.Enabled = false;
//                    mdiParent.EnableDeleteCommand(false);
//                }
//            }			
//        }

//        public void PrintForm()
//        {
//        }

//        public void ExitForm()
//        {
//            baseInitMenuMDIParent(mdiParent);
//            this.Close();
//        }

//        public void updateHeader()
//        {
//            fpsMaintainInsurance_Sheet1.RowCount = 0;
//            enableAmendDetail(false);
//            try
//            {				
//                if(mustUpdate())
//                {
//                    getInsuranceTypeOne();
//                    if(validateHeader() && facadeInsuranceTypeOne.UpdateInsuranceTypeOne())
//                    {
//                        showDetail();						
//                    }
//                }
//                else
//                {
//                    showDetail();
//                }
//            }
//            catch(SqlException ex)
//            {
//                Message(ex);
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

//            if(isReadonly)
//            {
//                cmdAdd.Enabled = false;
//                mniAdd.Enabled = false;
//                cmdDelete.Enabled = false;
//                mniDelete.Enabled = false;
//                mdiParent.EnableDeleteCommand(false);
//            }
//        }

//        public void addHeader()
//        {
//            try
//            {
//                if(validateHeader())
//                {
//                    getInsuranceTypeOne();
//                    if(facadeInsuranceTypeOne.InsertInsuranceTypeOne())
//                    {
//                        visibleInsuranceDetail(true);
//                        mdiParent.EnableDeleteCommand(true);
//                        enableInsurance(false);
//                        enableAmendDetail(false);
//                    }
//                }
//            }
//            catch(SqlException ex)
//            {
//                Message(ex);
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

//        public void AddEvent()
//        {
//            try
//            {
//                frmEntry = new frmInsuranceTypeOneEntry(this);
//                frmEntry.InitAddAction();
//                frmEntry.ObjInsuranceTypeOne = facadeInsuranceTypeOne.ObjInsuranceTypeOne;
//                frmEntry.ShowDialog();
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

//        public void EditEvent()
//        {
//            try
//            {
//                VehicleInsuranceTypeOne vehicleInsuranceTypeOne = SelectedVehicleInsuranceTypeOne;
//                if(vehicleInsuranceTypeOne != null)
//                {
//                    frmEntry = new frmInsuranceTypeOneEntry(this);
//                    frmEntry.InitEditAction();
//                    frmEntry.ObjInsuranceTypeOne = facadeInsuranceTypeOne.ObjInsuranceTypeOne;
//                    frmEntry.ObjVehicleInsuranceTypeOne = vehicleInsuranceTypeOne;
//                    frmEntry.MustCalculate = false;
//                    frmEntry.ShowDialog();					
//                }
//                vehicleInsuranceTypeOne = null;
//            }
//            catch(SqlException ex)
//            {
//                Message(ex);
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

//        public void DeleteForm()
//        {
//            try
//            {
//                if (Message(MessageList.Question.Q0001) == DialogResult.Yes)
//                {
//                    if(facadeInsuranceTypeOne.DeleteInsuranceTypeOne())
//                    {
//                        InitForm();
//                    }
//                }
//            }
//            catch(SqlException ex)
//            {
//                Message(ex);
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

//        public void DeleteEvent()
//        {
//            try
//            {
//                if (Message(MessageList.Question.Q0001) == DialogResult.Yes)
//                {
//                    if (facadeInsuranceTypeOne.DeleteInsuranceTypeOne(SelectedVehicleInsuranceTypeOne))
//                    {
//                        fpsMaintainInsurance_Sheet1.Rows.Remove(SelectedRow,1);		
//                    }
//                    if(fpsMaintainInsurance_Sheet1.RowCount == 0)
//                    {
//                        enableAmendDetail(false);
//                    }
//                }
//            }
//            catch(SqlException ex)
//            {
//                Message(ex);
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

////		==================================== Event ====================================
//        private void frmMaintainInsuranceTypeOne_Load(object sender, System.EventArgs e)
//        {
//            mdiParent = (frmMain)this.MdiParent;
//            InitForm();
//            enableAmendDetail(false);
//        }

//        private void txtPolicyNo_DoubleClick(object sender, System.EventArgs e)
//        {
//            frmInsuranceTypeOnePolicyList dialognsuranceTypeOnePolicyList = new frmInsuranceTypeOnePolicyList();
//            dialognsuranceTypeOnePolicyList.ConditionPolicyCode = txtPolicyNo.Text;
//            dialognsuranceTypeOnePolicyList.ShowDialog();			
//            if(dialognsuranceTypeOnePolicyList.Selected)
//            {
//                txtPolicyNo.Text = dialognsuranceTypeOnePolicyList.SelectedInsuranceTypeOnePolicy.PolicyNo;
//                RefreshForm();
//            }
//            dialognsuranceTypeOnePolicyList = null;
//        }

//        private void txtPolicyNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
//        {
//            if(e.KeyCode == Keys.Enter)
//            {
//                if(txtPolicyNo.Text.Trim() != "")
//                {
//                    RefreshForm();				
//                }
//            }
//        }

//        private void cmdShow_Click(object sender, System.EventArgs e)
//        {
//            switch (action)
//            {					
//                case ActionType.ADD :
//                    addHeader();
//                    break;
//                case ActionType.EDIT :
//                    updateHeader();
//                    break;
//            }
//        }

//        private void dtpStartDate_ValueChanged(object sender, System.EventArgs e)
//        {
//            dtpEndDate.Value = dtpStartDate.Value.AddYears(1);	
//        }

//        private void cmdAdd_Click(object sender, System.EventArgs e)
//        {
//            AddEvent();
//        }

//        private void mniAdd_Click(object sender, System.EventArgs e)
//        {
//            AddEvent();
//        }

//        private void cmdEdit_Click(object sender, System.EventArgs e)
//        {			
//            EditEvent();
//        }

//        private void mniEdit_Click(object sender, System.EventArgs e)
//        {
//            EditEvent();
//        }

//        private void mniDelete_Click(object sender, System.EventArgs e)
//        {
//            DeleteEvent();
//        }

//        private void cmdDelete_Click(object sender, System.EventArgs e)
//        {
//            DeleteEvent();
//        }

//        private void fpsMaintainInsurance_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
//        {			
//            if(!e.ColumnHeader)
//            {
//                EditEvent();
//            }
//        }
//    }
//}
