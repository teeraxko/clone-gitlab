//using System;
//using System.Drawing;
//using System.Collections;
//using System.ComponentModel;
//using System.Windows.Forms;
//using System.Data.SqlClient;

//using SystemFramework.AppMessage;
//using SystemFramework.AppException;

//using Entity.CommonEntity;
//using Entity.VehicleEntities;
//using Entity.ContractEntities;

//using Facade.CommonFacade;
//using Facade.VehicleFacade;
//using Facade.ContractFacade;

//using Presentation.CommonGUI;
//using Presentation.VehicleGUI;

//using ictus.Common.Entity.Time;

//namespace Presentation.ContractGUI
//{
//    public class TMPfrmContract : ChildFormBase, IMDIChildForm, ISaveForm	
//    {	
//        #region Windows Form Designer Gernerated Code
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
//        private System.Windows.Forms.Label label9;
//        private System.Windows.Forms.Label label5;
//        private System.Windows.Forms.Label label4;
//        private System.Windows.Forms.Label label3;
//        private System.Windows.Forms.Label label2;
//        private System.Windows.Forms.Label label1;
//        private System.Windows.Forms.Label label7;
//        private System.Windows.Forms.Label label15;
//        private System.Windows.Forms.Label label22;
//        private System.Windows.Forms.Label label23;
//        private System.Windows.Forms.Label label25;
//        private System.Windows.Forms.Label label26;
//        private System.Windows.Forms.Label label27;
//        private System.Windows.Forms.Label label28;
//        private System.Windows.Forms.Label label29;
//        private System.Windows.Forms.GroupBox gpbDetail;
//        protected System.Windows.Forms.GroupBox gpbAssignment;
//        private System.Windows.Forms.GroupBox gpbContractInfo;
//        private System.Windows.Forms.ComboBox cboContractStatus;
//        private System.Windows.Forms.ComboBox cboContractType;
//        private System.Windows.Forms.ComboBox cboCustomerTHName;
//        private System.Windows.Forms.Button cmdOK;
//        private System.Windows.Forms.Button cmdCancel;
//        private System.Windows.Forms.ComboBox cboKindOfContract;
//        private System.Windows.Forms.Button cmdDelete;
//        private System.Windows.Forms.Button cmdDeleteContract;
//        private System.Windows.Forms.Button cmdCreateContract;
//        private FarPoint.Win.Input.FpInteger fpiUnitHire;
//        protected System.Windows.Forms.DateTimePicker dtpContractEnd;
//        protected System.Windows.Forms.DateTimePicker dtpContractStart;
//        private System.Windows.Forms.ComboBox cboCustomerDept;
//        protected System.Windows.Forms.GroupBox gpbDeleteContract;
//        private System.Windows.Forms.Button cmdAdd;
//        private System.Windows.Forms.TextBox txtContractNoXXX;
//        private System.Windows.Forms.TextBox txtContractNoMM;
//        private System.Windows.Forms.TextBox txtContractNoYY;
//        private System.Windows.Forms.Label label12;
//        private FarPoint.Win.Spread.FpSpread fpsVehicleContract;
//        private FarPoint.Win.Spread.SheetView fpsVehicleContract_Sheet1;
//        private System.Windows.Forms.TextBox txtContractPrefix;
//        private System.Windows.Forms.ContextMenu contextMenu1;
//        private System.Windows.Forms.MenuItem mniAdd;
//        private System.Windows.Forms.MenuItem mniDelete;
//        private System.Windows.Forms.Label label6;
//        private System.Windows.Forms.Label label10;
//        private System.Windows.Forms.TextBox txtRemark;
//        protected System.Windows.Forms.RadioButton rdoMonth;
//        protected System.Windows.Forms.RadioButton rdoDay;
//        private System.Windows.Forms.DateTimePicker dtpCancelDate;
//        private System.Windows.Forms.Label lblCancelDate;
//        private System.Windows.Forms.GroupBox gpbRemark;
//        private System.Windows.Forms.Label label8;
//        private System.Windows.Forms.Label label11;
//        private System.Windows.Forms.Label label13;
//        private System.Windows.Forms.Label label14;
//        private System.Windows.Forms.TextBox txtLeasingDay;
//        private System.Windows.Forms.TextBox txtLeasingMonth;
//        private System.Windows.Forms.TextBox txtLeasingYear;
//        private System.Windows.Forms.TextBox txtCancelReason;
//        private System.Windows.Forms.GroupBox gpbCancelReason;
//        private System.ComponentModel.Container components = null;
		
//        private void InitializeComponent()
//        {
//            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
//            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
//            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
//            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
//            this.cmdOK = new System.Windows.Forms.Button();
//            this.cmdCancel = new System.Windows.Forms.Button();
//            this.gpbDetail = new System.Windows.Forms.GroupBox();
//            this.label14 = new System.Windows.Forms.Label();
//            this.label13 = new System.Windows.Forms.Label();
//            this.label11 = new System.Windows.Forms.Label();
//            this.txtLeasingDay = new System.Windows.Forms.TextBox();
//            this.txtLeasingMonth = new System.Windows.Forms.TextBox();
//            this.txtLeasingYear = new System.Windows.Forms.TextBox();
//            this.label8 = new System.Windows.Forms.Label();
//            this.label6 = new System.Windows.Forms.Label();
//            this.rdoMonth = new System.Windows.Forms.RadioButton();
//            this.rdoDay = new System.Windows.Forms.RadioButton();
//            this.dtpCancelDate = new System.Windows.Forms.DateTimePicker();
//            this.lblCancelDate = new System.Windows.Forms.Label();
//            this.label9 = new System.Windows.Forms.Label();
//            this.fpiUnitHire = new FarPoint.Win.Input.FpInteger();
//            this.cboKindOfContract = new System.Windows.Forms.ComboBox();
//            this.cboCustomerDept = new System.Windows.Forms.ComboBox();
//            this.label5 = new System.Windows.Forms.Label();
//            this.dtpContractEnd = new System.Windows.Forms.DateTimePicker();
//            this.dtpContractStart = new System.Windows.Forms.DateTimePicker();
//            this.label4 = new System.Windows.Forms.Label();
//            this.label3 = new System.Windows.Forms.Label();
//            this.label2 = new System.Windows.Forms.Label();
//            this.label1 = new System.Windows.Forms.Label();
//            this.gpbAssignment = new System.Windows.Forms.GroupBox();
//            this.cmdDelete = new System.Windows.Forms.Button();
//            this.cmdAdd = new System.Windows.Forms.Button();
//            this.fpsVehicleContract = new FarPoint.Win.Spread.FpSpread();
//            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
//            this.mniAdd = new System.Windows.Forms.MenuItem();
//            this.mniDelete = new System.Windows.Forms.MenuItem();
//            this.fpsVehicleContract_Sheet1 = new FarPoint.Win.Spread.SheetView();
//            this.cmdDeleteContract = new System.Windows.Forms.Button();
//            this.gpbDeleteContract = new System.Windows.Forms.GroupBox();
//            this.label7 = new System.Windows.Forms.Label();
//            this.gpbContractInfo = new System.Windows.Forms.GroupBox();
//            this.label12 = new System.Windows.Forms.Label();
//            this.txtContractPrefix = new System.Windows.Forms.TextBox();
//            this.label15 = new System.Windows.Forms.Label();
//            this.label22 = new System.Windows.Forms.Label();
//            this.cmdCreateContract = new System.Windows.Forms.Button();
//            this.txtContractNoXXX = new System.Windows.Forms.TextBox();
//            this.txtContractNoMM = new System.Windows.Forms.TextBox();
//            this.txtContractNoYY = new System.Windows.Forms.TextBox();
//            this.label25 = new System.Windows.Forms.Label();
//            this.cboContractStatus = new System.Windows.Forms.ComboBox();
//            this.label26 = new System.Windows.Forms.Label();
//            this.cboContractType = new System.Windows.Forms.ComboBox();
//            this.label27 = new System.Windows.Forms.Label();
//            this.label28 = new System.Windows.Forms.Label();
//            this.cboCustomerTHName = new System.Windows.Forms.ComboBox();
//            this.label29 = new System.Windows.Forms.Label();
//            this.label23 = new System.Windows.Forms.Label();
//            this.label10 = new System.Windows.Forms.Label();
//            this.txtRemark = new System.Windows.Forms.TextBox();
//            this.gpbRemark = new System.Windows.Forms.GroupBox();
//            this.gpbCancelReason = new System.Windows.Forms.GroupBox();
//            this.txtCancelReason = new System.Windows.Forms.TextBox();
//            this.gpbDetail.SuspendLayout();
//            this.gpbAssignment.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.fpsVehicleContract)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.fpsVehicleContract_Sheet1)).BeginInit();
//            this.gpbDeleteContract.SuspendLayout();
//            this.gpbContractInfo.SuspendLayout();
//            this.gpbRemark.SuspendLayout();
//            this.gpbCancelReason.SuspendLayout();
//            this.SuspendLayout();
//            // 
//            // cmdOK
//            // 
//            this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
//            this.cmdOK.Location = new System.Drawing.Point(328, 568);
//            this.cmdOK.Name = "cmdOK";
//            this.cmdOK.Size = new System.Drawing.Size(80, 23);
//            this.cmdOK.TabIndex = 80;
//            this.cmdOK.Text = "ตกลง";
//            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
//            // 
//            // cmdCancel
//            // 
//            this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
//            this.cmdCancel.Location = new System.Drawing.Point(414, 568);
//            this.cmdCancel.Name = "cmdCancel";
//            this.cmdCancel.Size = new System.Drawing.Size(80, 23);
//            this.cmdCancel.TabIndex = 81;
//            this.cmdCancel.Text = "ยกเลิก";
//            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
//            // 
//            // gpbDetail
//            // 
//            this.gpbDetail.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.gpbDetail.Controls.Add(this.label14);
//            this.gpbDetail.Controls.Add(this.label13);
//            this.gpbDetail.Controls.Add(this.label11);
//            this.gpbDetail.Controls.Add(this.txtLeasingDay);
//            this.gpbDetail.Controls.Add(this.txtLeasingMonth);
//            this.gpbDetail.Controls.Add(this.txtLeasingYear);
//            this.gpbDetail.Controls.Add(this.label8);
//            this.gpbDetail.Controls.Add(this.label6);
//            this.gpbDetail.Controls.Add(this.rdoMonth);
//            this.gpbDetail.Controls.Add(this.rdoDay);
//            this.gpbDetail.Controls.Add(this.dtpCancelDate);
//            this.gpbDetail.Controls.Add(this.lblCancelDate);
//            this.gpbDetail.Controls.Add(this.label9);
//            this.gpbDetail.Controls.Add(this.fpiUnitHire);
//            this.gpbDetail.Controls.Add(this.cboKindOfContract);
//            this.gpbDetail.Controls.Add(this.cboCustomerDept);
//            this.gpbDetail.Controls.Add(this.label5);
//            this.gpbDetail.Controls.Add(this.dtpContractEnd);
//            this.gpbDetail.Controls.Add(this.dtpContractStart);
//            this.gpbDetail.Controls.Add(this.label4);
//            this.gpbDetail.Controls.Add(this.label3);
//            this.gpbDetail.Controls.Add(this.label2);
//            this.gpbDetail.Controls.Add(this.label1);
//            this.gpbDetail.Location = new System.Drawing.Point(24, 96);
//            this.gpbDetail.Name = "gpbDetail";
//            this.gpbDetail.Size = new System.Drawing.Size(776, 96);
//            this.gpbDetail.TabIndex = 18;
//            this.gpbDetail.TabStop = false;
//            this.gpbDetail.Text = "รายละเอียด";
//            // 
//            // label14
//            // 
//            this.label14.Location = new System.Drawing.Point(440, 64);
//            this.label14.Name = "label14";
//            this.label14.Size = new System.Drawing.Size(24, 23);
//            this.label14.TabIndex = 41;
//            this.label14.Text = "วัน";
//            // 
//            // label13
//            // 
//            this.label13.Location = new System.Drawing.Point(376, 64);
//            this.label13.Name = "label13";
//            this.label13.Size = new System.Drawing.Size(32, 23);
//            this.label13.TabIndex = 40;
//            this.label13.Text = "เดือน";
//            // 
//            // label11
//            // 
//            this.label11.Location = new System.Drawing.Point(328, 64);
//            this.label11.Name = "label11";
//            this.label11.Size = new System.Drawing.Size(16, 23);
//            this.label11.TabIndex = 39;
//            this.label11.Text = "ปี";
//            // 
//            // txtLeasingDay
//            // 
//            this.txtLeasingDay.Enabled = false;
//            this.txtLeasingDay.Location = new System.Drawing.Point(408, 64);
//            this.txtLeasingDay.Name = "txtLeasingDay";
//            this.txtLeasingDay.Size = new System.Drawing.Size(32, 20);
//            this.txtLeasingDay.TabIndex = 38;
//            this.txtLeasingDay.Text = "";
//            this.txtLeasingDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
//            // 
//            // txtLeasingMonth
//            // 
//            this.txtLeasingMonth.Enabled = false;
//            this.txtLeasingMonth.Location = new System.Drawing.Point(344, 64);
//            this.txtLeasingMonth.Name = "txtLeasingMonth";
//            this.txtLeasingMonth.Size = new System.Drawing.Size(32, 20);
//            this.txtLeasingMonth.TabIndex = 37;
//            this.txtLeasingMonth.Text = "";
//            this.txtLeasingMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
//            // 
//            // txtLeasingYear
//            // 
//            this.txtLeasingYear.Enabled = false;
//            this.txtLeasingYear.Location = new System.Drawing.Point(288, 64);
//            this.txtLeasingYear.Name = "txtLeasingYear";
//            this.txtLeasingYear.Size = new System.Drawing.Size(32, 20);
//            this.txtLeasingYear.TabIndex = 36;
//            this.txtLeasingYear.Text = "";
//            this.txtLeasingYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
//            // 
//            // label8
//            // 
//            this.label8.Location = new System.Drawing.Point(200, 64);
//            this.label8.Name = "label8";
//            this.label8.Size = new System.Drawing.Size(64, 23);
//            this.label8.TabIndex = 35;
//            this.label8.Text = "ระยะเวลาเช่า";
//            // 
//            // label6
//            // 
//            this.label6.Location = new System.Drawing.Point(496, 64);
//            this.label6.Name = "label6";
//            this.label6.Size = new System.Drawing.Size(72, 23);
//            this.label6.TabIndex = 32;
//            this.label6.Text = "ประเภทการเช่า";
//            // 
//            // rdoMonth
//            // 
//            this.rdoMonth.Location = new System.Drawing.Point(640, 64);
//            this.rdoMonth.Name = "rdoMonth";
//            this.rdoMonth.Size = new System.Drawing.Size(64, 16);
//            this.rdoMonth.TabIndex = 34;
//            this.rdoMonth.Text = "รายเดือน";
//            this.rdoMonth.CheckedChanged += new System.EventHandler(this.rdoMonth_CheckedChanged);
//            // 
//            // rdoDay
//            // 
//            this.rdoDay.Location = new System.Drawing.Point(584, 64);
//            this.rdoDay.Name = "rdoDay";
//            this.rdoDay.Size = new System.Drawing.Size(56, 16);
//            this.rdoDay.TabIndex = 33;
//            this.rdoDay.Text = "รายวัน";
//            this.rdoDay.CheckedChanged += new System.EventHandler(this.rdoDay_CheckedChanged);
//            // 
//            // dtpCancelDate
//            // 
//            this.dtpCancelDate.CustomFormat = "dd/MM/yyyy";
//            this.dtpCancelDate.Enabled = false;
//            this.dtpCancelDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
//            this.dtpCancelDate.Location = new System.Drawing.Point(104, 64);
//            this.dtpCancelDate.Name = "dtpCancelDate";
//            this.dtpCancelDate.Size = new System.Drawing.Size(88, 20);
//            this.dtpCancelDate.TabIndex = 31;
//            // 
//            // lblCancelDate
//            // 
//            this.lblCancelDate.Location = new System.Drawing.Point(16, 66);
//            this.lblCancelDate.Name = "lblCancelDate";
//            this.lblCancelDate.Size = new System.Drawing.Size(80, 23);
//            this.lblCancelDate.TabIndex = 30;
//            this.lblCancelDate.Text = "วันที่ยกเลิกสัญญา";
//            // 
//            // label9
//            // 
//            this.label9.Location = new System.Drawing.Point(552, 40);
//            this.label9.Name = "label9";
//            this.label9.Size = new System.Drawing.Size(48, 23);
//            this.label9.TabIndex = 29;
//            this.label9.Text = "คน / คัน";
//            // 
//            // fpiUnitHire
//            // 
//            this.fpiUnitHire.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
//            this.fpiUnitHire.AllowClipboardKeys = true;
//            this.fpiUnitHire.AllowNull = true;
//            this.fpiUnitHire.ButtonMarginColor = System.Drawing.SystemColors.Control;
//            this.fpiUnitHire.Location = new System.Drawing.Point(496, 40);
//            this.fpiUnitHire.MaxValue = 255;
//            this.fpiUnitHire.MinValue = 1;
//            this.fpiUnitHire.Name = "fpiUnitHire";
//            this.fpiUnitHire.NullColor = System.Drawing.Color.Transparent;
//            this.fpiUnitHire.Size = new System.Drawing.Size(40, 20);
//            this.fpiUnitHire.TabIndex = 28;
//            this.fpiUnitHire.Text = "1";
//            this.fpiUnitHire.TextChanged += new System.EventHandler(this.fpiUnitHire_TextChanged);
//            // 
//            // cboKindOfContract
//            // 
//            this.cboKindOfContract.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
//            this.cboKindOfContract.Location = new System.Drawing.Point(496, 16);
//            this.cboKindOfContract.Name = "cboKindOfContract";
//            this.cboKindOfContract.Size = new System.Drawing.Size(264, 21);
//            this.cboKindOfContract.TabIndex = 22;
//            this.cboKindOfContract.SelectedIndexChanged += new System.EventHandler(this.cboKindOfContract_SelectedIndexChanged);
//            // 
//            // cboCustomerDept
//            // 
//            this.cboCustomerDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
//            this.cboCustomerDept.Location = new System.Drawing.Point(104, 16);
//            this.cboCustomerDept.Name = "cboCustomerDept";
//            this.cboCustomerDept.Size = new System.Drawing.Size(272, 21);
//            this.cboCustomerDept.TabIndex = 20;
//            this.cboCustomerDept.SelectedIndexChanged += new System.EventHandler(this.cboCustomerDept_SelectedIndexChanged);
//            // 
//            // label5
//            // 
//            this.label5.Location = new System.Drawing.Point(408, 40);
//            this.label5.Name = "label5";
//            this.label5.Size = new System.Drawing.Size(48, 23);
//            this.label5.TabIndex = 27;
//            this.label5.Text = "จำนวน";
//            // 
//            // dtpContractEnd
//            // 
//            this.dtpContractEnd.CustomFormat = "dd/MM/yyyy";
//            this.dtpContractEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
//            this.dtpContractEnd.Location = new System.Drawing.Point(288, 40);
//            this.dtpContractEnd.Name = "dtpContractEnd";
//            this.dtpContractEnd.Size = new System.Drawing.Size(88, 20);
//            this.dtpContractEnd.TabIndex = 26;
//            this.dtpContractEnd.ValueChanged += new System.EventHandler(this.dtpContractEnd_ValueChanged);
//            // 
//            // dtpContractStart
//            // 
//            this.dtpContractStart.CustomFormat = "dd/MM/yyyy";
//            this.dtpContractStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
//            this.dtpContractStart.Location = new System.Drawing.Point(104, 40);
//            this.dtpContractStart.Name = "dtpContractStart";
//            this.dtpContractStart.Size = new System.Drawing.Size(88, 20);
//            this.dtpContractStart.TabIndex = 24;
//            this.dtpContractStart.ValueChanged += new System.EventHandler(this.dtpContractStart_ValueChanged);
//            // 
//            // label4
//            // 
//            this.label4.Location = new System.Drawing.Point(200, 43);
//            this.label4.Name = "label4";
//            this.label4.Size = new System.Drawing.Size(80, 23);
//            this.label4.TabIndex = 25;
//            this.label4.Text = "วันที่สิ้นสุดสัญญา";
//            // 
//            // label3
//            // 
//            this.label3.Location = new System.Drawing.Point(16, 43);
//            this.label3.Name = "label3";
//            this.label3.Size = new System.Drawing.Size(88, 23);
//            this.label3.TabIndex = 23;
//            this.label3.Text = "วันที่เริ่มต้นสัญญา";
//            // 
//            // label2
//            // 
//            this.label2.Location = new System.Drawing.Point(16, 18);
//            this.label2.Name = "label2";
//            this.label2.Size = new System.Drawing.Size(56, 23);
//            this.label2.TabIndex = 19;
//            this.label2.Text = "ฝ่ายลูกค้า";
//            // 
//            // label1
//            // 
//            this.label1.Location = new System.Drawing.Point(408, 18);
//            this.label1.Name = "label1";
//            this.label1.Size = new System.Drawing.Size(64, 23);
//            this.label1.TabIndex = 21;
//            this.label1.Text = "ชนิดสัญญา";
//            // 
//            // gpbAssignment
//            // 
//            this.gpbAssignment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
//            this.gpbAssignment.Controls.Add(this.cmdDelete);
//            this.gpbAssignment.Controls.Add(this.cmdAdd);
//            this.gpbAssignment.Controls.Add(this.fpsVehicleContract);
//            this.gpbAssignment.Location = new System.Drawing.Point(24, 272);
//            this.gpbAssignment.Name = "gpbAssignment";
//            this.gpbAssignment.Size = new System.Drawing.Size(512, 240);
//            this.gpbAssignment.TabIndex = 70;
//            this.gpbAssignment.TabStop = false;
//            this.gpbAssignment.Text = "ระบุรถในสัญญา";
//            this.gpbAssignment.Visible = false;
//            // 
//            // cmdDelete
//            // 
//            this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
//            this.cmdDelete.Location = new System.Drawing.Point(258, 208);
//            this.cmdDelete.Name = "cmdDelete";
//            this.cmdDelete.TabIndex = 73;
//            this.cmdDelete.Text = "ลบ";
//            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
//            // 
//            // cmdAdd
//            // 
//            this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
//            this.cmdAdd.Location = new System.Drawing.Point(178, 208);
//            this.cmdAdd.Name = "cmdAdd";
//            this.cmdAdd.TabIndex = 72;
//            this.cmdAdd.Text = "เพิ่ม";
//            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
//            // 
//            // fpsVehicleContract
//            // 
//            this.fpsVehicleContract.Anchor = System.Windows.Forms.AnchorStyles.None;
//            this.fpsVehicleContract.ContextMenu = this.contextMenu1;
//            this.fpsVehicleContract.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
//            this.fpsVehicleContract.Location = new System.Drawing.Point(8, 16);
//            this.fpsVehicleContract.Name = "fpsVehicleContract";
//            this.fpsVehicleContract.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
//                                                                                            this.fpsVehicleContract_Sheet1});
//            this.fpsVehicleContract.Size = new System.Drawing.Size(496, 184);
//            this.fpsVehicleContract.TabIndex = 71;
//            this.fpsVehicleContract.TabStop = false;
//            // 
//            // contextMenu1
//            // 
//            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
//                                                                                         this.mniAdd,
//                                                                                         this.mniDelete});
//            // 
//            // mniAdd
//            // 
//            this.mniAdd.Index = 0;
//            this.mniAdd.Text = "เพิ่ม           ";
//            this.mniAdd.Click += new System.EventHandler(this.mniAdd_Click);
//            // 
//            // mniDelete
//            // 
//            this.mniDelete.Index = 1;
//            this.mniDelete.Text = "ลบ           ";
//            this.mniDelete.Click += new System.EventHandler(this.mniDelete_Click);
//            // 
//            // fpsVehicleContract_Sheet1
//            // 
//            this.fpsVehicleContract_Sheet1.Reset();
//            // Formulas and custom names must be loaded with R1C1 reference style
//            this.fpsVehicleContract_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
//            this.fpsVehicleContract_Sheet1.ColumnCount = 5;
//            this.fpsVehicleContract_Sheet1.RowCount = 0;
//            this.fpsVehicleContract_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "ทะเบียนรถ";
//            this.fpsVehicleContract_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "ยี่ห้อ";
//            this.fpsVehicleContract_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "รุ่นรถ";
//            this.fpsVehicleContract_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "ประเภทรถ";
//            this.fpsVehicleContract_Sheet1.ColumnHeader.Columns.Default.Resizable = false;
//            this.fpsVehicleContract_Sheet1.Columns.Default.Resizable = false;
//            textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
//            textCellType1.DropDownButton = false;
//            this.fpsVehicleContract_Sheet1.Columns.Get(0).CellType = textCellType1;
//            this.fpsVehicleContract_Sheet1.Columns.Get(0).Visible = false;
//            textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
//            textCellType2.DropDownButton = false;
//            this.fpsVehicleContract_Sheet1.Columns.Get(1).CellType = textCellType2;
//            this.fpsVehicleContract_Sheet1.Columns.Get(1).Label = "ทะเบียนรถ";
//            this.fpsVehicleContract_Sheet1.Columns.Get(1).Locked = true;
//            this.fpsVehicleContract_Sheet1.Columns.Get(1).Width = 80F;
//            this.fpsVehicleContract_Sheet1.Columns.Get(2).AllowAutoSort = true;
//            this.fpsVehicleContract_Sheet1.Columns.Get(2).Label = "ยี่ห้อ";
//            this.fpsVehicleContract_Sheet1.Columns.Get(3).AllowAutoSort = true;
//            textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
//            textCellType3.DropDownButton = false;
//            this.fpsVehicleContract_Sheet1.Columns.Get(3).CellType = textCellType3;
//            this.fpsVehicleContract_Sheet1.Columns.Get(3).Label = "รุ่นรถ";
//            this.fpsVehicleContract_Sheet1.Columns.Get(3).Locked = true;
//            this.fpsVehicleContract_Sheet1.Columns.Get(3).Width = 140F;
//            this.fpsVehicleContract_Sheet1.Columns.Get(4).CellType = comboBoxCellType1;
//            this.fpsVehicleContract_Sheet1.Columns.Get(4).Label = "ประเภทรถ";
//            this.fpsVehicleContract_Sheet1.Columns.Get(4).Width = 160F;
//            this.fpsVehicleContract_Sheet1.RowHeader.Columns.Default.Resizable = false;
//            this.fpsVehicleContract_Sheet1.RowHeader.Rows.Default.Resizable = false;
//            this.fpsVehicleContract_Sheet1.Rows.Default.Resizable = false;
//            this.fpsVehicleContract_Sheet1.SheetName = "Sheet1";
//            this.fpsVehicleContract_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
//            // 
//            // cmdDeleteContract
//            // 
//            this.cmdDeleteContract.Location = new System.Drawing.Point(100, 40);
//            this.cmdDeleteContract.Name = "cmdDeleteContract";
//            this.cmdDeleteContract.Size = new System.Drawing.Size(64, 24);
//            this.cmdDeleteContract.TabIndex = 76;
//            this.cmdDeleteContract.Text = "ลบสัญญา";
//            this.cmdDeleteContract.Click += new System.EventHandler(this.cmdDeleteContract_Click);
//            // 
//            // gpbDeleteContract
//            // 
//            this.gpbDeleteContract.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.gpbDeleteContract.Controls.Add(this.cmdDeleteContract);
//            this.gpbDeleteContract.Controls.Add(this.label7);
//            this.gpbDeleteContract.Location = new System.Drawing.Point(544, 192);
//            this.gpbDeleteContract.Name = "gpbDeleteContract";
//            this.gpbDeleteContract.Size = new System.Drawing.Size(256, 72);
//            this.gpbDeleteContract.TabIndex = 74;
//            this.gpbDeleteContract.TabStop = false;
//            this.gpbDeleteContract.Text = "ลบสัญญา";
//            // 
//            // label7
//            // 
//            this.label7.Location = new System.Drawing.Point(12, 16);
//            this.label7.Name = "label7";
//            this.label7.Size = new System.Drawing.Size(232, 23);
//            this.label7.TabIndex = 75;
//            this.label7.Text = "*** เมื่อต้องการลบข้อมูลของสัญญานี้ออกจากระบบ ***";
//            // 
//            // gpbContractInfo
//            // 
//            this.gpbContractInfo.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.gpbContractInfo.Controls.Add(this.label12);
//            this.gpbContractInfo.Controls.Add(this.txtContractPrefix);
//            this.gpbContractInfo.Controls.Add(this.label15);
//            this.gpbContractInfo.Controls.Add(this.label22);
//            this.gpbContractInfo.Controls.Add(this.cmdCreateContract);
//            this.gpbContractInfo.Controls.Add(this.txtContractNoXXX);
//            this.gpbContractInfo.Controls.Add(this.txtContractNoMM);
//            this.gpbContractInfo.Controls.Add(this.txtContractNoYY);
//            this.gpbContractInfo.Controls.Add(this.label25);
//            this.gpbContractInfo.Controls.Add(this.cboContractStatus);
//            this.gpbContractInfo.Controls.Add(this.label26);
//            this.gpbContractInfo.Controls.Add(this.cboContractType);
//            this.gpbContractInfo.Controls.Add(this.label27);
//            this.gpbContractInfo.Controls.Add(this.label28);
//            this.gpbContractInfo.Controls.Add(this.cboCustomerTHName);
//            this.gpbContractInfo.Controls.Add(this.label29);
//            this.gpbContractInfo.Controls.Add(this.label23);
//            this.gpbContractInfo.Location = new System.Drawing.Point(24, 8);
//            this.gpbContractInfo.Name = "gpbContractInfo";
//            this.gpbContractInfo.Size = new System.Drawing.Size(776, 88);
//            this.gpbContractInfo.TabIndex = 0;
//            this.gpbContractInfo.TabStop = false;
//            this.gpbContractInfo.Text = "ข้อมูลสัญญา";
//            // 
//            // label12
//            // 
//            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
//            this.label12.Location = new System.Drawing.Point(560, 44);
//            this.label12.Name = "label12";
//            this.label12.Size = new System.Drawing.Size(8, 23);
//            this.label12.TabIndex = 10;
//            this.label12.Text = "-";
//            // 
//            // txtContractPrefix
//            // 
//            this.txtContractPrefix.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.txtContractPrefix.Enabled = false;
//            this.txtContractPrefix.Location = new System.Drawing.Point(536, 40);
//            this.txtContractPrefix.Name = "txtContractPrefix";
//            this.txtContractPrefix.Size = new System.Drawing.Size(24, 20);
//            this.txtContractPrefix.TabIndex = 9;
//            this.txtContractPrefix.TabStop = false;
//            this.txtContractPrefix.Text = "C";
//            this.txtContractPrefix.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
//            // 
//            // label15
//            // 
//            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.label15.Location = new System.Drawing.Point(640, 64);
//            this.label15.Name = "label15";
//            this.label15.Size = new System.Drawing.Size(32, 16);
//            this.label15.TabIndex = 17;
//            this.label15.Text = "XXX";
//            // 
//            // label22
//            // 
//            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.label22.Location = new System.Drawing.Point(608, 64);
//            this.label22.Name = "label22";
//            this.label22.Size = new System.Drawing.Size(24, 16);
//            this.label22.TabIndex = 16;
//            this.label22.Text = "MM";
//            // 
//            // cmdCreateContract
//            // 
//            this.cmdCreateContract.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.cmdCreateContract.Location = new System.Drawing.Point(680, 40);
//            this.cmdCreateContract.Name = "cmdCreateContract";
//            this.cmdCreateContract.Size = new System.Drawing.Size(88, 24);
//            this.cmdCreateContract.TabIndex = 14;
//            this.cmdCreateContract.Text = "สร้างสัญญาใหม่";
//            this.cmdCreateContract.Click += new System.EventHandler(this.cmdCreateContract_Click);
//            // 
//            // txtContractNoXXX
//            // 
//            this.txtContractNoXXX.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.txtContractNoXXX.Location = new System.Drawing.Point(632, 40);
//            this.txtContractNoXXX.MaxLength = 3;
//            this.txtContractNoXXX.Name = "txtContractNoXXX";
//            this.txtContractNoXXX.Size = new System.Drawing.Size(32, 20);
//            this.txtContractNoXXX.TabIndex = 13;
//            this.txtContractNoXXX.Text = "";
//            this.txtContractNoXXX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
//            this.txtContractNoXXX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContractNoXXX_KeyDown);
//            this.txtContractNoXXX.TextChanged += new System.EventHandler(this.txtContractNoXXX_TextChanged);
//            this.txtContractNoXXX.DoubleClick += new System.EventHandler(this.txtContractNoXXX_DoubleClick);
//            // 
//            // txtContractNoMM
//            // 
//            this.txtContractNoMM.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.txtContractNoMM.Location = new System.Drawing.Point(600, 40);
//            this.txtContractNoMM.MaxLength = 2;
//            this.txtContractNoMM.Name = "txtContractNoMM";
//            this.txtContractNoMM.Size = new System.Drawing.Size(32, 20);
//            this.txtContractNoMM.TabIndex = 12;
//            this.txtContractNoMM.Text = "";
//            this.txtContractNoMM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
//            this.txtContractNoMM.TextChanged += new System.EventHandler(this.txtContractNoMM_TextChanged);
//            // 
//            // txtContractNoYY
//            // 
//            this.txtContractNoYY.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.txtContractNoYY.Location = new System.Drawing.Point(568, 40);
//            this.txtContractNoYY.MaxLength = 2;
//            this.txtContractNoYY.Name = "txtContractNoYY";
//            this.txtContractNoYY.Size = new System.Drawing.Size(32, 20);
//            this.txtContractNoYY.TabIndex = 11;
//            this.txtContractNoYY.Text = "";
//            this.txtContractNoYY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
//            this.txtContractNoYY.TextChanged += new System.EventHandler(this.txtContractNoYY_TextChanged);
//            // 
//            // label25
//            // 
//            this.label25.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
//            this.label25.Location = new System.Drawing.Point(488, 44);
//            this.label25.Name = "label25";
//            this.label25.Size = new System.Drawing.Size(48, 23);
//            this.label25.TabIndex = 8;
//            this.label25.Text = "PTB  -";
//            // 
//            // cboContractStatus
//            // 
//            this.cboContractStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.cboContractStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
//            this.cboContractStatus.Location = new System.Drawing.Point(88, 40);
//            this.cboContractStatus.Name = "cboContractStatus";
//            this.cboContractStatus.Size = new System.Drawing.Size(240, 21);
//            this.cboContractStatus.TabIndex = 6;
//            this.cboContractStatus.SelectedIndexChanged += new System.EventHandler(this.cboContractStatus_SelectedIndexChanged);
//            // 
//            // label26
//            // 
//            this.label26.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.label26.Location = new System.Drawing.Point(416, 44);
//            this.label26.Name = "label26";
//            this.label26.Size = new System.Drawing.Size(64, 23);
//            this.label26.TabIndex = 7;
//            this.label26.Text = "เลขที่สัญญา";
//            // 
//            // cboContractType
//            // 
//            this.cboContractType.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.cboContractType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
//            this.cboContractType.Enabled = false;
//            this.cboContractType.Location = new System.Drawing.Point(496, 16);
//            this.cboContractType.Name = "cboContractType";
//            this.cboContractType.Size = new System.Drawing.Size(240, 21);
//            this.cboContractType.TabIndex = 4;
//            this.cboContractType.SelectedIndexChanged += new System.EventHandler(this.cboContractType_SelectedIndexChanged);
//            // 
//            // label27
//            // 
//            this.label27.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.label27.Location = new System.Drawing.Point(416, 18);
//            this.label27.Name = "label27";
//            this.label27.Size = new System.Drawing.Size(72, 23);
//            this.label27.TabIndex = 3;
//            this.label27.Text = "ประเภทสัญญา";
//            // 
//            // label28
//            // 
//            this.label28.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.label28.Location = new System.Drawing.Point(16, 44);
//            this.label28.Name = "label28";
//            this.label28.Size = new System.Drawing.Size(64, 23);
//            this.label28.TabIndex = 5;
//            this.label28.Text = "สถานะสัญญา";
//            // 
//            // cboCustomerTHName
//            // 
//            this.cboCustomerTHName.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.cboCustomerTHName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
//            this.cboCustomerTHName.Location = new System.Drawing.Point(88, 16);
//            this.cboCustomerTHName.Name = "cboCustomerTHName";
//            this.cboCustomerTHName.Size = new System.Drawing.Size(312, 21);
//            this.cboCustomerTHName.TabIndex = 2;
//            this.cboCustomerTHName.SelectedIndexChanged += new System.EventHandler(this.cboCustomerTHName_SelectedIndexChanged);
//            // 
//            // label29
//            // 
//            this.label29.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.label29.Location = new System.Drawing.Point(16, 18);
//            this.label29.Name = "label29";
//            this.label29.Size = new System.Drawing.Size(40, 23);
//            this.label29.TabIndex = 1;
//            this.label29.Text = "ชื่อลูกค้า";
//            // 
//            // label23
//            // 
//            this.label23.Anchor = System.Windows.Forms.AnchorStyles.Top;
//            this.label23.Location = new System.Drawing.Point(576, 64);
//            this.label23.Name = "label23";
//            this.label23.Size = new System.Drawing.Size(24, 16);
//            this.label23.TabIndex = 15;
//            this.label23.Text = "YY";
//            // 
//            // label10
//            // 
//            this.label10.Location = new System.Drawing.Point(16, 15);
//            this.label10.Name = "label10";
//            this.label10.Size = new System.Drawing.Size(48, 23);
//            this.label10.TabIndex = 78;
//            this.label10.Text = "หมายเหตุ";
//            // 
//            // txtRemark
//            // 
//            this.txtRemark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
//            this.txtRemark.Location = new System.Drawing.Point(72, 16);
//            this.txtRemark.MaxLength = 60;
//            this.txtRemark.Name = "txtRemark";
//            this.txtRemark.Size = new System.Drawing.Size(688, 20);
//            this.txtRemark.TabIndex = 79;
//            this.txtRemark.Text = "";
//            this.txtRemark.TextChanged += new System.EventHandler(this.txtRemark_TextChanged);
//            // 
//            // gpbRemark
//            // 
//            this.gpbRemark.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
//            this.gpbRemark.Controls.Add(this.label10);
//            this.gpbRemark.Controls.Add(this.txtRemark);
//            this.gpbRemark.Location = new System.Drawing.Point(23, 512);
//            this.gpbRemark.Name = "gpbRemark";
//            this.gpbRemark.Size = new System.Drawing.Size(776, 48);
//            this.gpbRemark.TabIndex = 77;
//            this.gpbRemark.TabStop = false;
//            // 
//            // gpbCancelReason
//            // 
//            this.gpbCancelReason.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
//            this.gpbCancelReason.Controls.Add(this.txtCancelReason);
//            this.gpbCancelReason.Location = new System.Drawing.Point(544, 432);
//            this.gpbCancelReason.Name = "gpbCancelReason";
//            this.gpbCancelReason.Size = new System.Drawing.Size(256, 80);
//            this.gpbCancelReason.TabIndex = 82;
//            this.gpbCancelReason.TabStop = false;
//            this.gpbCancelReason.Text = "เหตุผลในการยกเลิกสัญญา";
//            // 
//            // txtCancelReason
//            // 
//            this.txtCancelReason.Enabled = false;
//            this.txtCancelReason.Location = new System.Drawing.Point(16, 32);
//            this.txtCancelReason.Name = "txtCancelReason";
//            this.txtCancelReason.Size = new System.Drawing.Size(216, 20);
//            this.txtCancelReason.TabIndex = 0;
//            this.txtCancelReason.Text = "";
//            // 
//            // frmContract
//            // 
//            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
//            this.ClientSize = new System.Drawing.Size(822, 628);
//            this.Controls.Add(this.gpbCancelReason);
//            this.Controls.Add(this.gpbRemark);
//            this.Controls.Add(this.gpbContractInfo);
//            this.Controls.Add(this.gpbDeleteContract);
//            this.Controls.Add(this.cmdCancel);
//            this.Controls.Add(this.gpbDetail);
//            this.Controls.Add(this.gpbAssignment);
//            this.Controls.Add(this.cmdOK);
//            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
//            this.Name = "frmContract";
//            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
//            this.Text = "ข้อมูลเอกสารสัญญา";
//            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
//            this.Load += new System.EventHandler(this.frmContract_Load);
//            this.Closed += new System.EventHandler(this.frmContract_Closed);
//            this.gpbDetail.ResumeLayout(false);
//            this.gpbAssignment.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.fpsVehicleContract)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.fpsVehicleContract_Sheet1)).EndInit();
//            this.gpbDeleteContract.ResumeLayout(false);
//            this.gpbContractInfo.ResumeLayout(false);
//            this.gpbRemark.ResumeLayout(false);
//            this.gpbCancelReason.ResumeLayout(false);
//            this.ResumeLayout(false);

//        }
//        #endregion

//        #region - Constant -

//        #endregion

//        #region - Private - 
//        private bool addMode = false;
//        private bool updateMode = false;
//        private bool isReadonly = true;
//        private bool isTextChange = true;
////		private bool isCheckQuestion = false;
//        private frmMain mdiParent;
//        protected ContractBase objContractBase;	
//        private ContractFacade facadeContract;
//        private DocumentNo contractNo;
//        private Vehicle objVehicle;
//        private DriverContract objDriverContract;
//        private VehicleContract objVehicleContract;
//        private ServiceStaffContract objServiceStaffContract;
			
//        private int SelectedRow
//        {
//            get{return fpsVehicleContract_Sheet1.ActiveRowIndex;}
//        }

//        private int SelectedKey
//        {
//            get{return Convert.ToInt32(fpsVehicleContract_Sheet1.Cells[SelectedRow,0].Text);}
//        }

//        private Vehicle SelectedVehicle()
//        {
//            objVehicle = facadeContract.GetVehicleGeneral(SelectedKey);
//            return objVehicle;	
//        }
//        #endregion

//        //		============================== Property ==============================
//        private DocumentNo getContractNo()
//        {
//            contractNo = new DocumentNo(DOCUMENT_TYPE.CONTRACT, txtContractNoYY.Text, txtContractNoMM.Text, txtContractNoXXX.Text);
//            return contractNo;
//        }

//        private DriverContract getDriverContract()
//        {
//            objDriverContract = new DriverContract(facadeContract.GetCompany());
//            objDriverContract.ContractNo = getContractNo();
//            objDriverContract.AContractType = (ContractType)cboContractType.SelectedItem;
//            objDriverContract.AContractStatus = (ContractStatus)cboContractStatus.SelectedItem;
//            objDriverContract.AKindOfContract = (KindOfContract)cboKindOfContract.SelectedItem;
//            objDriverContract.APeriod.From = dtpContractStart.Value.Date;
//            objDriverContract.APeriod.To = dtpContractEnd.Value.Date;
//            objDriverContract.ACustomerDepartment.ACustomer = (Customer)cboCustomerTHName.SelectedItem;
//            objDriverContract.ACustomerDepartment = (CustomerDepartment)cboCustomerDept.SelectedItem;
//            objDriverContract.UnitHire =  Convert.ToInt32(fpiUnitHire.Value);
//            objDriverContract.ACancelReason.Name = "";

//            if(rdoDay.Checked)
//            {
//                objDriverContract.RateStatus = RATE_STATUS_TYPE.DAY;
//            }
//            else
//            {
//                objDriverContract.RateStatus = RATE_STATUS_TYPE.MONTH;
//            }

//            objDriverContract.Remark = txtRemark.Text;
//            addContractCharge(objDriverContract);	
//            return objDriverContract;
//        }

//        private VehicleContract getNewVehicleContract()
//        {
//            objVehicleContract.ContractNo = getContractNo();
//            objVehicleContract.AContractType = (ContractType)cboContractType.SelectedItem;
//            objVehicleContract.AContractStatus =(ContractStatus)cboContractStatus.SelectedItem;
//            objVehicleContract.AKindOfContract = (KindOfContract)cboKindOfContract.SelectedItem;
//            objVehicleContract.APeriod.From = dtpContractStart.Value.Date;
//            objVehicleContract.APeriod.To = dtpContractEnd.Value.Date;
//            objVehicleContract.ACustomerDepartment.ACustomer = (Customer)cboCustomerTHName.SelectedItem;
//            objVehicleContract.ACustomerDepartment = (CustomerDepartment)cboCustomerDept.SelectedItem;
//            objVehicleContract.UnitHire =  Convert.ToInt32(fpiUnitHire.Value);
//            objVehicleContract.ACancelReason.Name = "";

//            if(rdoDay.Checked)
//            {
//                objVehicleContract.RateStatus = RATE_STATUS_TYPE.DAY;
//            }
//            else
//            {
//                objVehicleContract.RateStatus = RATE_STATUS_TYPE.MONTH;
//            }

//            objVehicleContract.Remark = txtRemark.Text;
			
//            for(int i=0; i < objVehicleContract.AVehicleRoleList.Count; i++)
//            {
//                string temp = fpsVehicleContract_Sheet1.Cells.Get(i,4).Text;
//                objVehicleContract.AVehicleRoleList[i].AKindOfVehicle = facadeContract.ObjKindOfVehicleList[temp];
//                objVehicleContract.AVehicleRoleList[i].AVehicle.AKindOfVehicle = facadeContract.ObjKindOfVehicleList[temp];
//            }
		
//            addContractCharge(objVehicleContract);

//            return objVehicleContract;
//        }

//        private VehicleContract getVehicleContract()
//        {
//            objVehicleContract = (VehicleContract)facadeContract.RetriveContract(getContractNo());
//            objVehicleContract.ContractNo = getContractNo();
//            objVehicleContract.AContractType = (ContractType)cboContractType.SelectedItem;
//            objVehicleContract.AContractStatus = (ContractStatus)cboContractStatus.SelectedItem;
//            objVehicleContract.AKindOfContract = (KindOfContract)cboKindOfContract.SelectedItem;
//            objVehicleContract.APeriod.From = dtpContractStart.Value.Date;
//            objVehicleContract.APeriod.To = dtpContractEnd.Value.Date;
//            objVehicleContract.ACustomerDepartment.ACustomer = (Customer)cboCustomerTHName.SelectedItem;
//            objVehicleContract.ACustomerDepartment = (CustomerDepartment)cboCustomerDept.SelectedItem;
//            objVehicleContract.UnitHire =  Convert.ToInt32(fpiUnitHire.Value);
//            objVehicleContract.ACancelReason.Name = "";

//            if(rdoDay.Checked)
//            {
//                objVehicleContract.RateStatus = RATE_STATUS_TYPE.DAY;
//            }
//            else
//            {
//                objVehicleContract.RateStatus = RATE_STATUS_TYPE.MONTH;
//            }

//            objVehicleContract.Remark = txtRemark.Text;
//            addContractCharge(objVehicleContract);	
//            return objVehicleContract;
//        }

//        private ServiceStaffContract getServiceStaffContract()
//        {
//            objServiceStaffContract = new ServiceStaffContract(facadeContract.GetCompany());
//            objServiceStaffContract.ContractNo = getContractNo();
//            objServiceStaffContract.AContractType = (ContractType)cboContractType.SelectedItem;
//            objServiceStaffContract.AContractStatus = (ContractStatus)cboContractStatus.SelectedItem;
//            objServiceStaffContract.AKindOfContract = (KindOfContract)cboKindOfContract.SelectedItem;
//            objServiceStaffContract.APeriod.From = dtpContractStart.Value.Date;
//            objServiceStaffContract.APeriod.To = dtpContractEnd.Value.Date;
//            objServiceStaffContract.ACustomerDepartment.ACustomer = (Customer)cboCustomerTHName.SelectedItem;
//            objServiceStaffContract.ACustomerDepartment = (CustomerDepartment)cboCustomerDept.SelectedItem;
//            objServiceStaffContract.UnitHire =  Convert.ToInt32(fpiUnitHire.Value);
//            objServiceStaffContract.ACancelReason.Name = "";

//            if(rdoDay.Checked)
//            {
//                objServiceStaffContract.RateStatus = RATE_STATUS_TYPE.DAY;
//            }
//            else
//            {
//                objServiceStaffContract.RateStatus = RATE_STATUS_TYPE.MONTH;
//            }

//            objServiceStaffContract.Remark = txtRemark.Text;
//            addContractCharge(objServiceStaffContract);	
//            return objServiceStaffContract;
//        }
			
//        protected virtual void setContractBase(ContractBase value)
//        {	
//            isTextChange = false;
//            txtContractNoYY.Text = value.ContractNo.Year;
//            txtContractNoMM.Text = value.ContractNo.Month;
//            txtContractNoXXX.Text = value.ContractNo.No;	
//            cboCustomerTHName.Text = value.ACustomerDepartment.ACustomer.ToString();
//            cboContractType.Text = GUIFunction.GetString(value.AContractType);
//            cboContractStatus.Text = GUIFunction.GetString(value.AContractStatus);
//            cboCustomerDept.Text = value.ACustomerDepartment.ToString();
//            cboKindOfContract.Text = GUIFunction.GetString(value.AKindOfContract.AName.Thai);
//            dtpContractStart.Value = value.APeriod.From;
//            dtpContractEnd.Value = value.APeriod.To;
//            fpiUnitHire.Value = value.UnitHire;

//            if(value.RateStatus == RATE_STATUS_TYPE.DAY)
//            {
//                rdoDay.Checked = true;
//            }
//            else
//            {
//                rdoMonth.Checked = true;
//            }
			
//            txtRemark.Text = value.Remark;
//            isTextChange = true;
//        }

//        protected void bindContractCharge(UCTContractCharge control, ContractCharge value)
//        {
//            if(value==null)
//            {
//                control.RateAmount = 0;
//                control.FirstMonth = 0;
//                control.NextMonth = 0;
//                control.LastMonth = 0;	
//            }
//            else
//            {
//                control.RateAmountTag = value.UnitChargeAmount;
//                control.RateAmount = value.UnitChargeAmount;
//                control.FirstMonth = value.FirstMonthCharge;
//                control.NextMonth = value.MonthlyCharge;
//                control.LastMonth = value.LastMonthCharge;
		
//                control.DateForm = value.APeriod.From.Date;
//                control.DateTo = value.APeriod.To.Date;
//                control.RateStatusByMonth = rdoMonth.Checked;
//            }
//        }

//        protected ContractCharge getContractCharge(UCTContractCharge control)
//        {
//            ContractCharge contractCharge = new ContractCharge();
//            contractCharge.UnitChargeAmount = control.RateAmount;
//            contractCharge.FirstMonthCharge = control.FirstMonth;
//            contractCharge.MonthlyCharge = control.NextMonth;
//            contractCharge.LastMonthCharge = control.LastMonth;
//            contractCharge.APeriod.From = control.DateForm;
//            contractCharge.APeriod.To = control.DateTo;
//            return contractCharge;
//        }

//        //		============================== Constructor ==============================
//        public TMPfrmContract(): base()
//        {	
//            InitializeComponent();

//            hideGroupBox(false);
//            hideCancelDate(false);			
//            cmdOK.Enabled = false;			
//        }

//        //		============================== Private Method ==============================
//        private void formContractList()
//        {
//            ContractType contractType = (ContractType)cboContractType.SelectedItem;

//            if (contractType.Code.Equals("D"))
//            {
//                FrmContractDriverList dialogContractList = new FrmContractDriverList();

//                if (cboCustomerTHName.Text != "")
//                    dialogContractList.ConditionCustomer = (Customer)cboCustomerTHName.SelectedItem;

//                dialogContractList.ConditionCONTRACT_TYPE = contractType;
//                dialogContractList.IsContractDriverList = true;

//                if (cboContractStatus.Text != "")
//                    dialogContractList.ConditionContractStatus = (ContractStatus)cboContractStatus.SelectedItem;
//                if (txtContractNoYY.Text != "")
//                    dialogContractList.ConditionYY = txtContractNoYY.Text;
//                if (txtContractNoMM.Text != "")
//                    dialogContractList.ConditionMM = txtContractNoMM.Text;
//                if (txtContractNoXXX.Text != "")
//                    dialogContractList.ConditionXXX = txtContractNoXXX.Text;
//                dialogContractList.ShowDialog();
//                if (dialogContractList.Selected)
//                    retriveContract(dialogContractList.SelectedContract);

//                dialogContractList = null;
//            }
//            else 
//            {
//                frmContractVDOList dialogContractList = new frmContractVDOList();
//                dialogContractList.ConditionCONTRACT_TYPE = contractType;
//                if (cboCustomerTHName.Text != "")
//                    dialogContractList.ConditionCustomer = (Customer)cboCustomerTHName.SelectedItem;
//                if (cboContractType.Text != "")
//                {
//                    switch (contractType.Code)
//                    {
//                        case "V":
//                            dialogContractList.IsContractVehicleList = true;
//                            break;
//                        case "O":
//                            dialogContractList.IsContractServiceStaffList = true;
//                            break;
//                    }
//                }
//                if (cboContractStatus.Text != "")
//                    dialogContractList.ConditionContractStatus = (ContractStatus)cboContractStatus.SelectedItem;
//                if (txtContractNoYY.Text != "")
//                    dialogContractList.ConditionYY = txtContractNoYY.Text;
//                if (txtContractNoMM.Text != "")
//                    dialogContractList.ConditionMM = txtContractNoMM.Text;
//                if (txtContractNoXXX.Text != "")
//                    dialogContractList.ConditionXXX = txtContractNoXXX.Text;
//                dialogContractList.ShowDialog();
//                if (dialogContractList.Selected)
//                    retriveContract(dialogContractList.SelectedContract);

//                dialogContractList = null;
//            }
//        }

//        private void bindForm(VehicleContract value)
//        {
//            fpsVehicleContract_Sheet1.RowCount = value.AVehicleRoleList.Count; 

//            if (value.AVehicleRoleList.Count > 0)
//            {
//                enableDeleteButton(true);
//                for(int iRow=0; iRow<value.AVehicleRoleList.Count; iRow++)
//                {
//                    bindVehicle(iRow, value.AVehicleRoleList[iRow]);
//                }
//            }
//            else
//            {enableDeleteButton(false);}
//            visibleChild(true);
//        }

//        private void bindVehicle(int i,VehicleRole value)
//        {
//            fpsVehicleContract_Sheet1.Cells.Get(i,0).Text = GUIFunction.GetString(value.EntityKey);
//            fpsVehicleContract_Sheet1.Cells.Get(i,1).Text = GUIFunction.GetString(value.AVehicle.PlateNumber);
//            fpsVehicleContract_Sheet1.Cells.Get(i,2).Text = GUIFunction.GetString(value.AVehicle.AModel.ABrand.AName.English);
//            fpsVehicleContract_Sheet1.Cells.Get(i,3).Text = GUIFunction.GetString(value.AVehicle.AModel.AName.English);
//            fpsVehicleContract_Sheet1.Cells.Get(i,4).Text = GUIFunction.GetString(value.AVehicle.AKindOfVehicle);
//        }

//        private void retriveRunningNo()
//        {
//            isTextChange = false;
//            contractNo = facadeContract.RetriveContractRunningNo();
//            txtContractNoYY.Text = contractNo.Year;
//            txtContractNoMM.Text = contractNo.Month;
//            txtContractNoXXX.Text = contractNo.No;	
//            cboContractStatus.Text = CTFunction.GetString("1");
//            isTextChange = true;
//        }

//        private void retriveContract(ContractBase value)
//        {
//            updateCase();
//            setContractBase(value);
//            hideGroupBox(true);
//            enableGroupBox(true);	

//            if(value.AContractType.Code == "V")
//            {
//                hideVehicleAssign(true);
//                cmdOK.Enabled = true;

//                if(getVehicleContract()!= null)
//                {
//                    bindForm((VehicleContract)value);
//                }
//                else
//                {
//                    fpsVehicleContract_Sheet1.RowCount = 0;
//                }
//            }
//            else
//            {
//                hideVehicleAssign(false);
//                cmdOK.Enabled = true;
//            }

//            if(value.AContractStatus.Code != "1")
//            {
//                if(value.AContractStatus.Code == "2" && value.AContractType.Code == "D")
//                {
//                    gpbDeleteContract.Enabled = false;
//                    gpbContractInfo.Enabled = false;
//                    gpbAssignment.Enabled = false;
//                    gpbDetail.Enabled = false;
//                    gpbRemark.Enabled = false;
//                }
//                else
//                {
//                    gpbDeleteContract.Enabled = false;
//                    gpbContractInfo.Enabled = false;
//                    gpbAssignment.Enabled = false;
//                    gpbDetail.Enabled = false; 
//                    gpbRemark.Enabled = false; 
//                    cmdOK.Enabled = false;
//                    enableCalculate(false);
//                    enableContractCharge(false); 
//                }				
//            }

//            if(value.AContractStatus.Code == "3")
//            {
//                hideCancelDate(true); 
//                dtpCancelDate.Value = value.CancelDate;
//                gpbCancelReason.Visible = true;
//                txtCancelReason.Text = value.ACancelReason.Name;
//            }
//            else
//            {
//                hideCancelDate(false);
//                gpbCancelReason.Visible = false;
//            }
//            visibleChild(true);
//            IsMustQuestion = false;

//            if(isReadonly)
//            {
//                cmdDeleteContract.Enabled = false;
//                cmdDelete.Enabled = false;
//                cmdAdd.Enabled = false;
//                cmdOK.Enabled = false;
//                IsMustQuestion = false;
//            }
//        }

//        private void calLeasingPeriod()
//        {
//            DayMonthYearStructure leasingPeriod = facadeContract.CalAge(dtpContractStart.Value, dtpContractEnd.Value);
//            txtLeasingYear.Text = leasingPeriod.Years.ToString();
//            txtLeasingMonth.Text = leasingPeriod.Months.ToString();
//            txtLeasingDay.Text = leasingPeriod.Days.ToString();
//        }

//        private void setIsMustQuestion()
//        {
//            if(!cmdCreateContract.Enabled)
//            {
//                if (isReadonly)
//                    IsMustQuestion = false;
//                else
//                    IsMustQuestion = true;
//            }			
//        }

//        #region - protected virtual -
//        protected virtual void enableCalculate(bool enable)
//        {}

//        protected virtual void enableContractCharge(bool enable)
//        {}
			
//        protected virtual void addContractCharge(ContractBase value)
//        {}

//        protected virtual void visibleChild(bool visible)
//        {}

//        protected virtual bool validateContractCharge()
//        {
//            return true;
//        }

//        protected virtual void ClearContractCharge()
//        {}
//        #endregion

////		====================== Mode Add & Update & Delete Contract ================//
//        private bool modeAddContract()
//        {
//            bool result = false;

//            try
//            {
//                ContractType contractType = (ContractType)cboContractType.SelectedItem;

//                if(contractType.Code == "V")
//                {
//                    if(facadeContract.ModeInsertContract(getNewVehicleContract()))
//                    {
//                        result = true;
//                        clearForm();
//                    }
//                }
//                else if(contractType.Code == "D")
//                {
//                    if(facadeContract.ModeInsertContract(getDriverContract()))	
//                    {
//                        result = true;
//                        clearForm();
//                    }
//                }
//                else if(contractType.Code == "O")
//                {
//                    if(facadeContract.ModeInsertContract(getServiceStaffContract()))
//                    {
//                        result = true;
//                        clearForm();
//                    }
//                }
//            }
//            catch(SqlException sqlex)
//            {
//                Message(sqlex);
//                visibleChild(false);
//            }			
//            catch(AppExceptionBase ex)
//            {
//                Message(ex);
//                visibleChild(false);
//            }
//            catch(Exception ex)
//            {
//                Message(ex);
//                visibleChild(false);
//            }	

//            return result;
//        }

//        private bool modeUpdateContract()
//        {
//            bool result = false;

//            try
//            {
//                objContractBase = facadeContract.RetriveContract(getContractNo());		
//                ContractType contractType = (ContractType)cboContractType.SelectedItem;
//                if(contractType.Code == "V")
//                {
//                    if(facadeContract.ModeUpdateContract(getNewVehicleContract()))
//                    {
//                        result = true;
//                        clearForm();
//                    }
//                }
//                else if(contractType.Code == "D")
//                {
//                    if(objContractBase.AContractType.Code == "V")
//                    {
//                        if(facadeContract.ModeUpdateContractChangeVehicleContract(objContractBase))
//                        {
//                            if(facadeContract.ModeUpdateContract(getDriverContract()))	
//                            {
//                                result = true;
//                                clearForm();
//                            }
//                        }
//                    }
//                    else
//                    {
//                        if(facadeContract.ModeUpdateContract(getDriverContract()))	
//                        {
//                            result = true;
//                            clearForm();
//                        }
//                    }
//                }
//                else if(contractType.Code == "O")	
//                {
//                    if(objContractBase.AContractType.Code == "V")
//                    {
//                        if(facadeContract.ModeUpdateContractChangeVehicleContract(objContractBase))
//                        {
//                            if(facadeContract.ModeUpdateContract(getServiceStaffContract()))
//                            {
//                                result = true;
//                                clearForm();
//                            }
//                        }
//                    }
//                    else
//                    {
//                        if(facadeContract.ModeUpdateContract(getServiceStaffContract()))
//                        {
//                            result = true;
//                            clearForm();
//                        }
//                    }
//                }
//            }
//            catch(SqlException sqlex)
//            {Message(sqlex);}
//            catch(AppExceptionBase ex)
//            {Message(ex);}
//            catch(Exception ex)
//            {Message(ex);}
		
//            return result;
//        }

//        private bool modeDeleteContract()
//        {
//            bool result = false;

//            try
//            {
//                ContractType contractType = (ContractType)cboContractType.SelectedItem;
//                if(contractType.Code == "V")
//                {
//                    if(facadeContract.ModeDeleteContract(getVehicleContract()))
//                    {
//                        result = true;
//                        clearForm();
//                    }
//                }
//                else if(contractType.Code == "D")
//                {
//                    if(facadeContract.ModeDeleteContract(getDriverContract()))	
//                    {
//                        result = true;
//                        clearForm();
//                    }
//                }
//                else if(contractType.Code == "O")
//                {
//                    if(facadeContract.ModeDeleteContract(getServiceStaffContract()))
//                    {
//                        result = true;
//                        clearForm();
//                    }
//                }
//            }
//            catch(SqlException sqlex)
//            {Message(sqlex);}
//            catch(AppExceptionBase ex)
//            {Message(ex);}
//            catch(Exception ex)
//            {Message(ex);}	
	
//            return result;
//        }

//        //		====================== Add & Update & Delete Mode/Vehicle ================
//        #region - Add & Update Mode -
//        protected virtual void addCase()
//        {
//            mdiParent.EnableNewCommand(true);
//            mdiParent.EnableDeleteCommand(false);
//            mdiParent.EnableRefreshCommand(false);
//            mdiParent.EnablePrintCommand(false);

//            MainMenuNewStatus = true;
//            MainMenuDeleteStatus = false;
//            MainMenuRefreshStatus = false;
//            MainMenuPrintStatus = false;

//            addMode = true;
//            hideGroupBox(true);
//            gpbContractInfo.Enabled = true;
//            enableContractControl(false);
//            gpbDetail.Enabled = true;
//            gpbDeleteContract.Enabled = false;	
//            cmdOK.Enabled = true;
//            cmdCreateContract.Enabled = false;
//            cboCustomerTHName.Focus();
//            cboContractStatus.SelectedIndex = 0;
//            cboKindOfContract.SelectedIndex = 0;
//            fpiUnitHire.Value = 1;
//            fpiUnitHire.BackColor = System.Drawing.Color.White;

//            if(cboContractType.SelectedIndex != -1)
//            {
//                ContractType contractType = (ContractType)cboContractType.SelectedItem;
//                if(contractType.Code == "V")
//                {
//                    hideVehicleAssign(true);
//                    enableDeleteButton(false);
//                }
//                else
//                {
//                    hideVehicleAssign(false);
//                }
//                contractType = null;
//            }
//            enableCalculate(true);
//            enableContractCharge(true);
//            IsMustQuestion = false;
//        }

//        private void updateCase()
//        {
//            mdiParent.EnableNewCommand(true);
//            mdiParent.EnableDeleteCommand(false);
//            mdiParent.EnableRefreshCommand(false);
//            mdiParent.EnablePrintCommand(false);

//            MainMenuNewStatus = true;
//            MainMenuDeleteStatus = false;
//            MainMenuRefreshStatus = false;
//            MainMenuPrintStatus = false;

//            updateMode = true;
//            gpbContractInfo.Enabled = true;
//            enableContractControl(false);
//            gpbDeleteContract.Enabled = true;
//            cmdOK.Enabled = true;
//            cmdCreateContract.Enabled = false;
//            enableCalculate(true);
//            enableContractCharge(true);
//            setIsMustQuestion();			
//        }
		
//        protected void selectContract(string contractType)
//        {
//            cboContractType.DataSource = facadeContract.DataSourceContractTypeList(contractType);
//            cboContractType.Enabled = false;
//        }

//        protected void setPermission(bool value)
//        {
//            isReadonly = value;
//        }

//        #endregion - Add & Update Mode -

//        #region - Add & Delete Vehicle -
//        private void addVehicle()
//        {
//            FrmVehicleList dialogVehicleList = new FrmVehicleList();
//            VehicleRole objVehicleRole = new VehicleRole();

//            dialogVehicleList.IsVehicleAvailable = true;

//            dialogVehicleList.ShowDialog();
//            if(dialogVehicleList.Selected)
//            {
//                objVehicle = dialogVehicleList.SelectedVehicle;
//                objVehicleRole.AVehicle = objVehicle;
//                if(checkConditionDuplicateVehicle(objVehicle))
//                {
//                    objVehicleContract.AVehicleRoleList.Add(objVehicleRole);
//                    bindForm(objVehicleContract);
//                }
//            }
//        }

//        private void deleteVehicle()
//        {
//            try
//            {
//                VehicleRole objVehicleRole = new VehicleRole();
//                if (Message(MessageList.Question.Q0001) == DialogResult.Yes)
//                {
//                    objVehicleRole.AVehicle = SelectedVehicle();
//                    objVehicleContract.AVehicleRoleList.Remove(objVehicleRole);
//                    bindForm(objVehicleContract);
//                }
//            }
//            catch(SqlException sqlex)
//            {Message(sqlex);}
//            catch(AppExceptionBase ex)
//            {Message(ex);}
//            catch(Exception ex)
//            {Message(ex);}		
//        }
//        #endregion - Add & Delete Vehicle -

//        //		======================== Hide & Enable Control =========================
//        #region - Hide & Enable Control -
//        private void hideGroupBox(bool enable)
//        {
//            gpbAssignment.Visible =	enable;
//            gpbDetail.Visible = enable;
//            gpbDeleteContract.Visible = enable;
//            gpbRemark.Visible = enable;
//            cmdOK.Visible = enable;
//            cmdCancel.Visible = enable;
//        }

//        private void hideCancelDate(bool enable)
//        {
//            lblCancelDate.Visible = enable;
//            dtpCancelDate.Visible = enable;
//        }

//        private void hideVehicleAssign(bool enable)
//        {
//            gpbAssignment.Enabled = enable;
//            gpbAssignment.Visible = enable;
//        }

//        private void enableGroupBox(bool enable)
//        {
//            gpbAssignment.Enabled =	enable;
//            gpbDetail.Enabled = enable;
//            gpbDeleteContract.Enabled = enable;
//        }

//        private void enableContractControl(bool enable)
//        {
//            cboContractStatus.Enabled = enable;
//            txtContractNoYY.Enabled = enable;
//            txtContractNoMM.Enabled = enable;
//            txtContractNoXXX.Enabled = enable;
//        }

//        private void enableDeleteButton(bool enable)
//        {
//            cmdDelete.Enabled = enable;
//            mniDelete.Enabled = enable;
//        }

//        private void enableRadio(bool enable)
//        {
//            rdoDay.Enabled = enable;
//            rdoMonth.Enabled = enable;
//        }

//        protected void initCombo()
//        {
//            objVehicleContract = new VehicleContract(facadeContract.GetCompany());
//            cboCustomerTHName.DataSource  = facadeContract.DataSourceCustomerName;
//            cboContractStatus.DataSource  = facadeContract.DataSourceContractStatus;
//            cboKindOfContract.DataSource = facadeContract.DataSourceKindOfContract;				

//            if (cboContractStatus.Items.Count>0)
//            {
//                cboContractStatus.SelectedIndex = -1;
//                cboContractStatus.SelectedIndex = -1;
//                cboContractStatus.Text = "";
//            }
//        }
//        #endregion - Hide & Enable Control -

//        //		========================== Validate Checking ===========================
//        #region - Validate Input ContractNo -
//        private bool validateInputContractNo()
//        {
//            return	validatetxtContractNoYY() && 
//                    validatetxtContractNoMM() && 
//                    validatetxtContractNoXXX() && 
//                    validateContractNo();
//        }

//        private bool validatetxtContractNoYY()
//        {
//            if(txtContractNoYY.Text == "")
//            {
//                Message(MessageList.Error.E0002, "เลขที่สัญญา");
//                txtContractNoYY.Focus();
//                return false;
//            }
//            return true;
//        }

//        private bool validatetxtContractNoMM()
//        {
//            if(txtContractNoMM.Text == "")
//            {
//                Message(MessageList.Error.E0002, "เลขที่สัญญา");
//                txtContractNoMM.Focus();
//                return false;
//            }
//            return true;
//        }

//        private bool validatetxtContractNoXXX()
//        {
//            if(txtContractNoXXX.Text == "")
//            {
//                Message(MessageList.Error.E0002, "เลขที่สัญญา");
//                txtContractNoXXX.Focus();
//                return false;
//            }
//            return true;
//        }

//        private bool validateContractNo()
//        {
//            bool result = true;
//            ContractBase tempContract = facadeContract.RetriveContract(getContractNo());
//            if(tempContract == null)
//            {
//                Message(MessageList.Error.E0004, "เลขที่สัญญา");
//                txtContractNoYY.Focus();
//                result = false;
//            }
//            else
//            {
//                result = true;
//            }

//            if(result)
//            {
//                ContractType tempContractType = new ContractType();
//                tempContractType = (ContractType)cboContractType.SelectedItem;
//                if(tempContract.AContractType.Code != tempContractType.Code)
//                {
//                    Message(MessageList.Error.E0004, "เลขที่สัญญา");
//                    txtContractNoYY.Focus();
//                    result = false;
//                }
//                else
//                {
//                    result = true;
//                }
//                tempContractType = null;
//            }
//            tempContract = null;
//            return result;
//        }
//        #endregion - Validate Input ContractNo -
		
//        #region - Validate Input Checking -
//        private bool validateInputChecking()
//        {
//            return	validateCustomerTHName() && 
//                validateContractType() && 
//                validateContractStatus() && 
//                validateKindOfContract() && 
//                validateStartEndDate() &&
//                validateUnitHire() &&
//                validateContractCharge();
//        }

//        private bool validateCustomerTHName()
//        {
//            if(cboCustomerTHName.Text == "")
//            {
//                Message(MessageList.Error.E0005, "ชื่อลูกค้า");
//                cboCustomerTHName.Focus();
//                return false; 
//            }
//            return true;
//        }

//        private bool validateContractType()
//        {
//            if(cboContractType.Text == "")
//            {
//                Message(MessageList.Error.E0005, "ประเภทสัญญา");
//                cboContractType.Focus();
//                return false; 
//            }
//            return true;
//        }

//        private bool validateContractStatus()
//        {
//            if(cboContractStatus.Text == "")
//            {
//                Message(MessageList.Error.E0005, "สถานะสัญญา");
//                cboContractStatus.Focus();
//                return false;
//            }
//            return true;
//        }
		
//        private bool validateKindOfContract()
//        {
//            if(cboKindOfContract.Text == "")
//            {
//                Message(MessageList.Error.E0005, "ชนิดสัญญา");
//                cboKindOfContract.Focus();
//                return false; 
//            }
//            return true;
//        }
//        private bool validateStartEndDate()
//        {
//            if(dtpContractStart.Value.Date > dtpContractEnd.Value.Date)
//            {
//                Message(MessageList.Error.E0011,"วันที่เริ่มต้นสัญญา","วันที่สิ้นสุดสัญญา");
//                dtpContractStart.Focus();
//                return false; 
//            }
//            return true;
//        }

//        private bool validateUnitHire()
//        {
//            if(Convert.ToInt32(fpiUnitHire.Text) == 0)
//            {
//                Message(MessageList.Error.E0002,"จำนวน");
//                fpiUnitHire.Focus();
//                return false; 
//            }
//            return true;
//        }		
//        #endregion - Validate Input Checking -
		
//        #region - Validate Condition Checking -			
//        private bool checkConditionAmountVehicleContract()
//        {
//            ContractType contractType = (ContractType)cboContractType.SelectedItem;
//            if(contractType.Code == "V" && Convert.ToInt32(fpiUnitHire.Text) != objVehicleContract.AVehicleRoleList.Count)
//            {
//                Message(MessageList.Error.E0015, "จำนวนรถในสัญญาไม่ถูกต้อง");
//                return false;
//            }
//            return true;
//        }

//        private bool checkConditionDuplicateVehicle(Vehicle objVehicle)
//        {
//            if(objVehicleContract != null)
//            {
//                if(objVehicleContract.AVehicleRoleList.Contain(objVehicle))
//                {
//                    Message(MessageList.Error.E0010);
//                    return false;
//                }
//                else
//                    return true;
//            }
//            return true;
//        }

//        private bool checkConditionVehicleAssignment(VehicleContract aVehicleContract)
//        {
//            if(this.fpsVehicleContract_Sheet1.RowCount != 0)
//            {
//                VehicleAssignment vehicleAssignment;
//                Vehicle vehicle;

//                for(int i=0; i< fpsVehicleContract_Sheet1.RowCount; i++)
//                {
//                    vehicleAssignment = new VehicleAssignment();
//                    vehicle = new Vehicle();

//                    string strVehicleNo = fpsVehicleContract_Sheet1.Cells.Get(i,1).Text;
//                    vehicle.VehicleNo = int.Parse(fpsVehicleContract_Sheet1.Cells[i,0].Text);						
//                    vehicleAssignment.AAssignedVehicle = vehicle;
//                    vehicleAssignment.APeriod.From = dtpContractStart.Value.Date;
//                    vehicleAssignment.APeriod.To = dtpContractEnd.Value.Date;

//                    if (facadeContract.FillExcludeAvailableVehicleSpareAssignment(ref vehicleAssignment))
//                    {
//                        Message(MessageList.Error.E0013,"ระบุรถ " + strVehicleNo + " ในสัญญาได้","รถคันนี้ถูกใช้งานในช่วงเวลาดังกล่าว");
//                        return false;
//                    }
//                }
				
//                vehicleAssignment = null;
//                vehicle = null;
//            }
//            return true;
//        }

//        private bool checkConditionKindOfVehicle()
//        {
//            if(this.fpsVehicleContract_Sheet1.RowCount != 0)
//            {
//                for(int i=0; i < this.fpsVehicleContract_Sheet1.RowCount; i++)
//                {
//                    if(fpsVehicleContract_Sheet1.Cells.Get(i,4).Text == "")
//                    {
//                        Message(MessageList.Error.E0005, "ประเภทรถ");
//                        return false;
//                    }
//                }
//            }
//            return true;
//        }

//        private bool checkConditionSpareKindOfVehicle()
//        {
//            if(this.fpsVehicleContract_Sheet1.RowCount != 0)
//            {
//                KindOfVehicle kindOfVehicle;
//                for(int i=0; i < fpsVehicleContract_Sheet1.RowCount; i++)
//                {
//                    string temp = fpsVehicleContract_Sheet1.Cells.Get(i,4).Text;
//                    kindOfVehicle = facadeContract.ObjKindOfVehicleList[temp];

//                    if(kindOfVehicle.Code == "Z")
//                    {
//                        Message(MessageList.Error.E0029, "ประเภทรถ");
//                        return false;
//                    }
//                }
//            }
//            return true;
//        }

//        private bool checkVehicleActive()
//        {
//            if(this.fpsVehicleContract_Sheet1.RowCount != 0)
//            {
//                Vehicle vehicle;

//                for(int i=0; i< fpsVehicleContract_Sheet1.RowCount; i++)
//                {
//                    string strVehicleNo = fpsVehicleContract_Sheet1.Cells.Get(i,1).Text;
//                    vehicle = new Vehicle();
//                    vehicle.VehicleNo = int.Parse(fpsVehicleContract_Sheet1.Cells[i,0].Text);					

//                    if(!facadeContract.FillVehicleActive(vehicle))
//                    {
//                        Message(MessageList.Error.E0013,"ระบุรถ " + strVehicleNo + " ในสัญญาได้", "รถคันนี้ไม่อยู่ในสถานะพร้อมใช้งาน");
//                        return false;					
//                    }
//                }
//                vehicle = null;
//            }
//            return true;
		
		
//        }
//        #endregion - Validate Condition Checking -

//        //		============================ Clear Screen ===========================	
//        private void clearForm()
//        {
//            addMode = false;
//            updateMode = false;
//            cmdOK.Enabled = false;
//            cmdCreateContract.Enabled = true;
//            gpbRemark.Enabled = true;
//            hideGroupBox(false);
//            hideCancelDate(false);
//            gpbContractInfo.Enabled = true;
//            enableContractControl(true);
//            gpbCancelReason.Visible = false;
//            ClearContractCharge();
//            fpsVehicleContract_Sheet1.RowCount = 0;
//            txtContractNoYY.Text = "";
//            txtContractNoMM.Text = "";
//            txtContractNoXXX.Text = "";
//            txtRemark.Text = "";
//            dtpContractStart.Value = DateTime.Today.Date;
//            dtpContractEnd.Value = DateTime.Today.Date;
//            fpiUnitHire.Value = 0;
//            fpiUnitHire.MaxValue = 255;
//            fpiUnitHire.MinValue = 0;
			
//            if (cboContractStatus.Items.Count>0)
//            {
//                cboContractStatus.SelectedIndex = -1;
//                cboContractStatus.SelectedIndex = -1;
//                cboContractStatus.Text = "";
//            }
//            if(cboCustomerDept.Items.Count>0)
//            {
//                cboCustomerDept.SelectedIndex = -1;
//                cboCustomerDept.SelectedIndex = -1;
//                cboCustomerDept.Text = "";
//            }

//            if(objVehicleContract != null)
//            {objVehicleContract.AVehicleRoleList.Clear();}

//            visibleChild(false); 
//            IsMustQuestion = false;
//        }

//        private void clearLeasingPeriod()
//        {
//            txtLeasingDay.Text = "0";
//            txtLeasingMonth.Text = "0";
//            txtLeasingYear.Text = "0";
//        }

//        //		============================== Base Event ==============================
//        public void InitForm()
//        {
//            mdiParent = (frmMain)this.MdiParent;
//            clearMainMenuStatus();

//            facadeContract = new ContractFacade(); 
//            fpsVehicleContract_Sheet1.Columns[4].CellType = facadeContract.DataSourceKindOfVehicle;
//            clearForm();

//            if(isReadonly)
//            {
//                cmdCreateContract.Enabled = false;
//            }
//        }

//        public void RefreshForm()
//        {
//            retriveContract(facadeContract.RetriveContract(getContractNo()));
//        }

//        public void PrintForm()
//        {
//        }

//        public void ExitForm()
//        {
//            IsMustQuestion = false;
//            Dispose(true);
//        }


////		============================== Event ==============================
//        private void frmContract_Load(object sender, System.EventArgs e)
//        {}

//        private void cboCustomerTHName_SelectedIndexChanged(object sender, System.EventArgs e)
//        {
//            setIsMustQuestion();
//            if(cboCustomerTHName.SelectedIndex != -1)
//            {
//                Customer customer = (Customer)cboCustomerTHName.SelectedItem;
//                cboCustomerDept.DataSource = facadeContract.DataSourceCustomerDept(customer);
//                cboCustomerDept.Text = "";
//            }
//        }

//        private void cboContractType_SelectedIndexChanged(object sender, System.EventArgs e)
//        {
//        }

//        private void txtContractNoXXX_DoubleClick(object sender, System.EventArgs e)
//        {
//            formContractList();
//        }

//        private void txtContractNoYY_TextChanged(object sender, System.EventArgs e)
//        {
//            if(txtContractNoYY.Text.Length == 2)
//                txtContractNoMM.Focus();
//        }

//        private void txtContractNoMM_TextChanged(object sender, System.EventArgs e)
//        {		
//            if(txtContractNoMM.Text.Length == 2)
//                txtContractNoXXX.Focus();
//        }

//        private void txtContractNoXXX_TextChanged(object sender, System.EventArgs e)
//        {
//            if(isTextChange)
//            {
//                if(!addMode)
//                {
//                    if(txtContractNoXXX.Text.Length == 3)
//                    {
//                        if(validateInputContractNo())
//                        {retriveContract(facadeContract.RetriveContract(getContractNo()));}
//                    }
//                }
//            }
//        }	
	
//        private void txtContractNoXXX_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
//        {
//            if(e.KeyCode == System.Windows.Forms.Keys.Enter)	
//                if(!addMode)
//                    if(validateInputContractNo())
//                        retriveContract(facadeContract.RetriveContract(getContractNo()));
//        }

//        private void cmdCreateContract_Click(object sender, System.EventArgs e)
//        {
//            addCase();
//            retriveRunningNo();
//            fpiUnitHire.BackColor = System.Drawing.Color.White;			
//        }

//        private void cmdDeleteContract_Click(object sender, System.EventArgs e)
//        {
//            if (Message(MessageList.Question.Q0002,"ลบสัญญา","คืนข้อมูล","ลบสัญญา") == DialogResult.Yes)
//            {modeDeleteContract();}
//        }

//        private void cmdAdd_Click(object sender, System.EventArgs e)
//        {
//            addVehicle();
//        }

//        private void cmdDelete_Click(object sender, System.EventArgs e)
//        {
//            deleteVehicle();
//        }

//        private void mniAdd_Click(object sender, System.EventArgs e)
//        {
//            addVehicle();
//        }

//        private void mniDelete_Click(object sender, System.EventArgs e)
//        {
//            deleteVehicle();
//        }

//        private void cmdOK_Click(object sender, System.EventArgs e)
//        {
//            if(validateInputChecking())
//            {
//                if(	checkConditionAmountVehicleContract() && 
//                    checkConditionVehicleAssignment(objVehicleContract)&&
//                    checkConditionKindOfVehicle()&& 
//                    checkConditionSpareKindOfVehicle())
//                {
//                    if(addMode && checkVehicleActive())
//                    {
//                        if(modeAddContract())
//                        {
//                            InitForm();
//                        }
//                    }
//                    else if(updateMode)
//                    {
//                        if(modeUpdateContract())
//                        {
//                            InitForm();
//                        }
//                    }
//                }
//            }	
//        }

//        private void cmdCancel_Click(object sender, System.EventArgs e)
//        {
//            if(IsMustQuestion && !isReadonly)
//            {
//                DialogResult result = Message(MessageList.Question.Q0003);
//                if (result == DialogResult.Yes)
//                {
//                    if(validateInputChecking())
//                    {
//                        if(	checkConditionAmountVehicleContract() &&
//                            checkConditionVehicleAssignment(objVehicleContract)&&
//                            checkConditionKindOfVehicle()&& 
//                            checkConditionSpareKindOfVehicle())
//                        {
//                            if(addMode && checkVehicleActive())
//                            {
//                                if(modeAddContract())
//                                {
//                                    ExitForm();
//                                    this.Hide();
//                                }
//                            }
//                            else if(updateMode)
//                            {
//                                if(modeUpdateContract())
//                                {
//                                    ExitForm();
//                                    this.Hide();
//                                }
//                            }
//                        }
//                    }					
//                }
//                else if (result == DialogResult.No)
//                {
//                    ExitForm();
//                    this.Hide();
//                }
//                else if (result == DialogResult.Cancel)
//                {this.Show();}
//            }
//            else
//            {
//                ExitForm();
//                this.Hide();
//            }
//        }
		
//        private void cboKindOfContract_SelectedIndexChanged(object sender, System.EventArgs e)
//        {
//            setIsMustQuestion();
//            KindOfContract kindOfContract;
//            if(cboKindOfContract.SelectedIndex != -1)
//            {
//                kindOfContract = (KindOfContract)cboKindOfContract.SelectedItem;
//                if(kindOfContract.Code == "L")
//                {
//                    rdoMonth.Checked = true;
//                    enableRadio(false);
//                }
//                else
//                {
//                    rdoDay.Checked = true;
//                    enableRadio(true);
//                }						
//            }
//        }

//        private void dtpContractStart_ValueChanged(object sender, System.EventArgs e)
//        {
//            setIsMustQuestion();
//            if(dtpContractStart.Value <= dtpContractEnd.Value)
//            {
//                calLeasingPeriod();
//            }
//            else
//            {
//                clearLeasingPeriod();
//            }
//        }

//        private void dtpContractEnd_ValueChanged(object sender, System.EventArgs e)
//        {
//            setIsMustQuestion();
//            if(dtpContractStart.Value <= dtpContractEnd.Value)
//            {
//                calLeasingPeriod();
//            }
//            else
//            {
//                clearLeasingPeriod();
//            }
//        }

//        private void cboCustomerDept_SelectedIndexChanged(object sender, System.EventArgs e)
//        {
//            setIsMustQuestion();
//        }

//        private void fpdTotalChargeAmt_TextChanged(object sender, System.EventArgs e)
//        {
//            setIsMustQuestion();
//        }

//        private void cboContractStatus_SelectedIndexChanged(object sender, System.EventArgs e)
//        {
//            if(updateMode)
//            {setIsMustQuestion();}
//        }

//        private void fpiUnitHire_TextChanged(object sender, System.EventArgs e)
//        {
//            setIsMustQuestion();
//        }
		
//        private void rdoDay_CheckedChanged(object sender, System.EventArgs e)
//        {
//            setIsMustQuestion();
//        }

//        private void rdoMonth_CheckedChanged(object sender, System.EventArgs e)
//        {
//            setIsMustQuestion();
//        }

//        private void frmContract_Closed(object sender, System.EventArgs e)
//        {
//            ExitForm();
//        }

//        private void txtRemark_TextChanged(object sender, System.EventArgs e)
//        {
//            setIsMustQuestion();
//        }

//        #region ISaveForm Members
//        public bool SaveForm()
//        {
//            if(!cmdCreateContract.Enabled && validateInputChecking())
//            {
//                if(	checkConditionAmountVehicleContract() &&
//                    checkConditionVehicleAssignment(objVehicleContract)&&
//                    checkConditionKindOfVehicle()&& 
//                    checkConditionSpareKindOfVehicle())
//                {
//                    if(addMode && checkVehicleActive())
//                    {
//                        if(modeAddContract())
//                        {
//                            InitForm();
//                            return true;
//                        }
//                    }
//                    if(updateMode)
//                    {
//                        if(modeUpdateContract())
//                        {
//                            InitForm();
//                            return true;
//                        }
//                    }
//                }
//            }	
//            return false;
//        }
//        #endregion
//    }
//}