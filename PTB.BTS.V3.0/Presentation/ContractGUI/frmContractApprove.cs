using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using SystemFramework.AppMessage;
using SystemFramework.AppException;
using SystemFramework.AppConfig;

using ictus.Common.Entity.Time;
using ictus.PIS.PI.Entity;

using Entity.CommonEntity;
using Entity.VehicleEntities;
using Entity.ContractEntities;

using Facade.CommonFacade;
using Facade.ContractFacade;
using Facade.PiFacade;

using Presentation.CommonGUI;
using System.Collections.Generic;

namespace Presentation.ContractGUI
{
    public class frmContractApprove : ChildFormBase, IMDIChildForm
    {
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cboKindOfContract;
        private System.Windows.Forms.ComboBox cboCustomerDept;
        protected System.Windows.Forms.DateTimePicker dtpContractEnd;
        private System.Windows.Forms.DateTimePicker dtpContractStart;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.GroupBox gpbAssignment;
        private System.Windows.Forms.GroupBox gpbApprove;
        private FarPoint.Win.Spread.FpSpread fpsVehicleContract;
        private FarPoint.Win.Spread.SheetView fpsVehicleContract_Sheet1;
        private System.Windows.Forms.Button cmdContractApprove;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox cboContractStatus;
        private System.Windows.Forms.ComboBox cboContractType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCustomerTHName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContractPrefix;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtContractNoXXX;
        private System.Windows.Forms.TextBox txtContractNoMM;
        private System.Windows.Forms.TextBox txtContractNoYY;
        private System.Windows.Forms.GroupBox gpbDetail;
        private System.Windows.Forms.GroupBox gpbContractInfo;
        protected System.Windows.Forms.GroupBox gpbRemark;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label7;
        protected System.Windows.Forms.RadioButton rdoMonth;
        protected System.Windows.Forms.RadioButton rdoDay;
        private System.Windows.Forms.Label label9;
        private FarPoint.Win.Input.FpInteger fpiUnitHire;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpCancelDate;
        private System.Windows.Forms.Label lblCancelDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnCal;
        private System.Windows.Forms.GroupBox gpbServiceCharge;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label21;
        private Presentation.ContractGUI.UCTContractCharge uctContractCharge6;
        private Presentation.ContractGUI.UCTContractCharge uctContractCharge5;
        private Presentation.ContractGUI.UCTContractCharge uctContractCharge4;
        private Presentation.ContractGUI.UCTContractCharge uctContractCharge3;
        private Presentation.ContractGUI.UCTContractCharge uctContractCharge2;
        private System.Windows.Forms.Button btnCal6;
        private System.Windows.Forms.DateTimePicker dtpCCTo6;
        private System.Windows.Forms.DateTimePicker dtpCCForm6;
        private System.Windows.Forms.Button btnCal5;
        private System.Windows.Forms.DateTimePicker dtpCCTo5;
        private System.Windows.Forms.DateTimePicker dtpCCForm5;
        private System.Windows.Forms.Button btnCal4;
        private System.Windows.Forms.DateTimePicker dtpCCTo4;
        private System.Windows.Forms.DateTimePicker dtpCCForm4;
        private System.Windows.Forms.Button btnCal3;
        private System.Windows.Forms.DateTimePicker dtpCCTo3;
        private System.Windows.Forms.DateTimePicker dtpCCForm3;
        private System.Windows.Forms.Button btnCal2;
        private System.Windows.Forms.DateTimePicker dtpCCTo2;
        private System.Windows.Forms.DateTimePicker dtpCCForm2;
        private System.Windows.Forms.Button btnCal1;
        private System.Windows.Forms.DateTimePicker dtpCCTo1;
        private System.Windows.Forms.DateTimePicker dtpCCForm1;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.GroupBox gpbDriverServiceCharge;
        private System.Windows.Forms.Label lblYear6;
        private System.Windows.Forms.Label lblYear5;
        private System.Windows.Forms.Label lblYear4;
        private System.Windows.Forms.Label lblYear3;
        private System.Windows.Forms.Label lblYear2;
        private System.Windows.Forms.Label lblYear1;
        private Presentation.ContractGUI.UCTContractCharge uctContractChargeNotDriver;
        private Presentation.ContractGUI.UCTContractCharge uctContractCharge1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtLeasingDay;
        private System.Windows.Forms.TextBox txtLeasingMonth;
        private System.Windows.Forms.TextBox txtLeasingYear;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox cboVehicleKindContract;

        private System.ComponentModel.Container components = null;

        private void InitializeComponent()
        {
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.gpbAssignment = new System.Windows.Forms.GroupBox();
            this.fpsVehicleContract = new FarPoint.Win.Spread.FpSpread();
            this.fpsVehicleContract_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.gpbDetail = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.txtLeasingDay = new System.Windows.Forms.TextBox();
            this.txtLeasingMonth = new System.Windows.Forms.TextBox();
            this.txtLeasingYear = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.dtpCancelDate = new System.Windows.Forms.DateTimePicker();
            this.lblCancelDate = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.rdoMonth = new System.Windows.Forms.RadioButton();
            this.rdoDay = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.fpiUnitHire = new FarPoint.Win.Input.FpInteger();
            this.label8 = new System.Windows.Forms.Label();
            this.cboKindOfContract = new System.Windows.Forms.ComboBox();
            this.cboCustomerDept = new System.Windows.Forms.ComboBox();
            this.dtpContractEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpContractStart = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.gpbApprove = new System.Windows.Forms.GroupBox();
            this.cmdContractApprove = new System.Windows.Forms.Button();
            this.txtContractPrefix = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.cboContractStatus = new System.Windows.Forms.ComboBox();
            this.cboContractType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCustomerTHName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gpbContractInfo = new System.Windows.Forms.GroupBox();
            this.cboVehicleKindContract = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtContractNoXXX = new System.Windows.Forms.TextBox();
            this.txtContractNoMM = new System.Windows.Forms.TextBox();
            this.txtContractNoYY = new System.Windows.Forms.TextBox();
            this.gpbRemark = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.gpbServiceCharge = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnCal = new System.Windows.Forms.Button();
            this.uctContractChargeNotDriver = new Presentation.ContractGUI.UCTContractCharge();
            this.gpbDriverServiceCharge = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.uctContractCharge6 = new Presentation.ContractGUI.UCTContractCharge();
            this.uctContractCharge5 = new Presentation.ContractGUI.UCTContractCharge();
            this.uctContractCharge4 = new Presentation.ContractGUI.UCTContractCharge();
            this.uctContractCharge3 = new Presentation.ContractGUI.UCTContractCharge();
            this.uctContractCharge2 = new Presentation.ContractGUI.UCTContractCharge();
            this.uctContractCharge1 = new Presentation.ContractGUI.UCTContractCharge();
            this.lblYear6 = new System.Windows.Forms.Label();
            this.lblYear5 = new System.Windows.Forms.Label();
            this.lblYear4 = new System.Windows.Forms.Label();
            this.lblYear3 = new System.Windows.Forms.Label();
            this.lblYear2 = new System.Windows.Forms.Label();
            this.lblYear1 = new System.Windows.Forms.Label();
            this.btnCal6 = new System.Windows.Forms.Button();
            this.dtpCCTo6 = new System.Windows.Forms.DateTimePicker();
            this.dtpCCForm6 = new System.Windows.Forms.DateTimePicker();
            this.btnCal5 = new System.Windows.Forms.Button();
            this.dtpCCTo5 = new System.Windows.Forms.DateTimePicker();
            this.dtpCCForm5 = new System.Windows.Forms.DateTimePicker();
            this.btnCal4 = new System.Windows.Forms.Button();
            this.dtpCCTo4 = new System.Windows.Forms.DateTimePicker();
            this.dtpCCForm4 = new System.Windows.Forms.DateTimePicker();
            this.btnCal3 = new System.Windows.Forms.Button();
            this.dtpCCTo3 = new System.Windows.Forms.DateTimePicker();
            this.dtpCCForm3 = new System.Windows.Forms.DateTimePicker();
            this.btnCal2 = new System.Windows.Forms.Button();
            this.dtpCCTo2 = new System.Windows.Forms.DateTimePicker();
            this.dtpCCForm2 = new System.Windows.Forms.DateTimePicker();
            this.btnCal1 = new System.Windows.Forms.Button();
            this.dtpCCTo1 = new System.Windows.Forms.DateTimePicker();
            this.dtpCCForm1 = new System.Windows.Forms.DateTimePicker();
            this.label29 = new System.Windows.Forms.Label();
            this.gpbAssignment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpsVehicleContract)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsVehicleContract_Sheet1)).BeginInit();
            this.gpbDetail.SuspendLayout();
            this.gpbApprove.SuspendLayout();
            this.gpbContractInfo.SuspendLayout();
            this.gpbRemark.SuspendLayout();
            this.gpbServiceCharge.SuspendLayout();
            this.gpbDriverServiceCharge.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdCancel.Location = new System.Drawing.Point(364, 576);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(80, 24);
            this.cmdCancel.TabIndex = 15;
            this.cmdCancel.Text = "ปิด";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // gpbAssignment
            // 
            this.gpbAssignment.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gpbAssignment.Controls.Add(this.fpsVehicleContract);
            this.gpbAssignment.Enabled = false;
            this.gpbAssignment.Location = new System.Drawing.Point(16, 264);
            this.gpbAssignment.Name = "gpbAssignment";
            this.gpbAssignment.Size = new System.Drawing.Size(544, 240);
            this.gpbAssignment.TabIndex = 0;
            this.gpbAssignment.TabStop = false;
            this.gpbAssignment.Text = "ระบุรถในสัญญา";
            // 
            // fpsVehicleContract
            // 
            this.fpsVehicleContract.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.fpsVehicleContract.Location = new System.Drawing.Point(11, 16);
            this.fpsVehicleContract.Name = "fpsVehicleContract";
            this.fpsVehicleContract.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																							this.fpsVehicleContract_Sheet1});
            this.fpsVehicleContract.Size = new System.Drawing.Size(522, 216);
            this.fpsVehicleContract.TabIndex = 0;
            this.fpsVehicleContract.TabStop = false;
            // 
            // fpsVehicleContract_Sheet1
            // 
            this.fpsVehicleContract_Sheet1.Reset();
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpsVehicleContract_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpsVehicleContract_Sheet1.ColumnCount = 5;
            this.fpsVehicleContract_Sheet1.RowCount = 0;
            this.fpsVehicleContract_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "ทะเบียนรถ";
            this.fpsVehicleContract_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "ยี่ห้อ";
            this.fpsVehicleContract_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "รุ่นรถ";
            this.fpsVehicleContract_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "ประเภทรถ";
            this.fpsVehicleContract_Sheet1.ColumnHeader.Columns.Default.Resizable = false;
            this.fpsVehicleContract_Sheet1.Columns.Default.Resizable = false;
            textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType1.DropDownButton = false;
            this.fpsVehicleContract_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.fpsVehicleContract_Sheet1.Columns.Get(0).Visible = false;
            textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType2.DropDownButton = false;
            this.fpsVehicleContract_Sheet1.Columns.Get(1).CellType = textCellType2;
            this.fpsVehicleContract_Sheet1.Columns.Get(1).Label = "ทะเบียนรถ";
            this.fpsVehicleContract_Sheet1.Columns.Get(1).Width = 80F;
            this.fpsVehicleContract_Sheet1.Columns.Get(2).AllowAutoSort = true;
            this.fpsVehicleContract_Sheet1.Columns.Get(2).Label = "ยี่ห้อ";
            this.fpsVehicleContract_Sheet1.Columns.Get(2).Width = 75F;
            textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType3.DropDownButton = false;
            this.fpsVehicleContract_Sheet1.Columns.Get(3).CellType = textCellType3;
            this.fpsVehicleContract_Sheet1.Columns.Get(3).Label = "รุ่นรถ";
            this.fpsVehicleContract_Sheet1.Columns.Get(3).Width = 170F;
            this.fpsVehicleContract_Sheet1.Columns.Get(4).Label = "ประเภทรถ";
            this.fpsVehicleContract_Sheet1.Columns.Get(4).Width = 140F;
            this.fpsVehicleContract_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpsVehicleContract_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpsVehicleContract_Sheet1.RowHeader.Rows.Default.Resizable = false;
            this.fpsVehicleContract_Sheet1.Rows.Default.Resizable = false;
            this.fpsVehicleContract_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.fpsVehicleContract_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpsVehicleContract_Sheet1.SheetName = "Sheet1";
            this.fpsVehicleContract_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // gpbDetail
            // 
            this.gpbDetail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gpbDetail.Controls.Add(this.label24);
            this.gpbDetail.Controls.Add(this.label27);
            this.gpbDetail.Controls.Add(this.label28);
            this.gpbDetail.Controls.Add(this.txtLeasingDay);
            this.gpbDetail.Controls.Add(this.txtLeasingMonth);
            this.gpbDetail.Controls.Add(this.txtLeasingYear);
            this.gpbDetail.Controls.Add(this.label30);
            this.gpbDetail.Controls.Add(this.dtpCancelDate);
            this.gpbDetail.Controls.Add(this.lblCancelDate);
            this.gpbDetail.Controls.Add(this.label7);
            this.gpbDetail.Controls.Add(this.rdoMonth);
            this.gpbDetail.Controls.Add(this.rdoDay);
            this.gpbDetail.Controls.Add(this.label9);
            this.gpbDetail.Controls.Add(this.fpiUnitHire);
            this.gpbDetail.Controls.Add(this.label8);
            this.gpbDetail.Controls.Add(this.cboKindOfContract);
            this.gpbDetail.Controls.Add(this.cboCustomerDept);
            this.gpbDetail.Controls.Add(this.dtpContractEnd);
            this.gpbDetail.Controls.Add(this.dtpContractStart);
            this.gpbDetail.Controls.Add(this.label17);
            this.gpbDetail.Controls.Add(this.label18);
            this.gpbDetail.Controls.Add(this.label19);
            this.gpbDetail.Controls.Add(this.label20);
            this.gpbDetail.Enabled = false;
            this.gpbDetail.Location = new System.Drawing.Point(16, 88);
            this.gpbDetail.Name = "gpbDetail";
            this.gpbDetail.Size = new System.Drawing.Size(776, 96);
            this.gpbDetail.TabIndex = 0;
            this.gpbDetail.TabStop = false;
            this.gpbDetail.Text = "รายละเอียด";
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(456, 64);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(24, 23);
            this.label24.TabIndex = 48;
            this.label24.Text = "วัน";
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(392, 64);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(32, 23);
            this.label27.TabIndex = 47;
            this.label27.Text = "เดือน";
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(344, 64);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(16, 23);
            this.label28.TabIndex = 46;
            this.label28.Text = "ปี";
            // 
            // txtLeasingDay
            // 
            this.txtLeasingDay.Enabled = false;
            this.txtLeasingDay.Location = new System.Drawing.Point(424, 64);
            this.txtLeasingDay.Name = "txtLeasingDay";
            this.txtLeasingDay.Size = new System.Drawing.Size(32, 20);
            this.txtLeasingDay.TabIndex = 45;
            this.txtLeasingDay.Text = "";
            this.txtLeasingDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLeasingMonth
            // 
            this.txtLeasingMonth.Enabled = false;
            this.txtLeasingMonth.Location = new System.Drawing.Point(360, 64);
            this.txtLeasingMonth.Name = "txtLeasingMonth";
            this.txtLeasingMonth.Size = new System.Drawing.Size(32, 20);
            this.txtLeasingMonth.TabIndex = 44;
            this.txtLeasingMonth.Text = "";
            this.txtLeasingMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLeasingYear
            // 
            this.txtLeasingYear.Enabled = false;
            this.txtLeasingYear.Location = new System.Drawing.Point(304, 64);
            this.txtLeasingYear.Name = "txtLeasingYear";
            this.txtLeasingYear.Size = new System.Drawing.Size(32, 20);
            this.txtLeasingYear.TabIndex = 43;
            this.txtLeasingYear.Text = "";
            this.txtLeasingYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(216, 64);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(64, 23);
            this.label30.TabIndex = 42;
            this.label30.Text = "ระยะเวลาเช่า";
            // 
            // dtpCancelDate
            // 
            this.dtpCancelDate.CustomFormat = "dd/MM/yyyy";
            this.dtpCancelDate.Enabled = false;
            this.dtpCancelDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCancelDate.Location = new System.Drawing.Point(112, 64);
            this.dtpCancelDate.Name = "dtpCancelDate";
            this.dtpCancelDate.Size = new System.Drawing.Size(88, 20);
            this.dtpCancelDate.TabIndex = 31;
            // 
            // lblCancelDate
            // 
            this.lblCancelDate.Location = new System.Drawing.Point(16, 64);
            this.lblCancelDate.Name = "lblCancelDate";
            this.lblCancelDate.Size = new System.Drawing.Size(80, 23);
            this.lblCancelDate.TabIndex = 30;
            this.lblCancelDate.Text = "วันที่ยกเลิกสัญญา";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(496, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 23);
            this.label7.TabIndex = 29;
            this.label7.Text = "ประเภทการเช่า";
            // 
            // rdoMonth
            // 
            this.rdoMonth.Enabled = false;
            this.rdoMonth.Location = new System.Drawing.Point(640, 64);
            this.rdoMonth.Name = "rdoMonth";
            this.rdoMonth.Size = new System.Drawing.Size(64, 16);
            this.rdoMonth.TabIndex = 28;
            this.rdoMonth.Text = "รายเดือน";
            // 
            // rdoDay
            // 
            this.rdoDay.Enabled = false;
            this.rdoDay.Location = new System.Drawing.Point(584, 64);
            this.rdoDay.Name = "rdoDay";
            this.rdoDay.Size = new System.Drawing.Size(72, 16);
            this.rdoDay.TabIndex = 27;
            this.rdoDay.Text = "รายวัน";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(560, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 23);
            this.label9.TabIndex = 26;
            this.label9.Text = "คน / คัน";
            // 
            // fpiUnitHire
            // 
            this.fpiUnitHire.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
            this.fpiUnitHire.AllowClipboardKeys = true;
            this.fpiUnitHire.AllowNull = true;
            this.fpiUnitHire.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiUnitHire.Enabled = false;
            this.fpiUnitHire.Location = new System.Drawing.Point(496, 40);
            this.fpiUnitHire.MaxValue = 255;
            this.fpiUnitHire.MinValue = 1;
            this.fpiUnitHire.Name = "fpiUnitHire";
            this.fpiUnitHire.NullColor = System.Drawing.Color.Transparent;
            this.fpiUnitHire.Size = new System.Drawing.Size(48, 20);
            this.fpiUnitHire.TabIndex = 25;
            this.fpiUnitHire.Text = "1";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(408, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 23);
            this.label8.TabIndex = 24;
            this.label8.Text = "จำนวน";
            // 
            // cboKindOfContract
            // 
            this.cboKindOfContract.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKindOfContract.Enabled = false;
            this.cboKindOfContract.Location = new System.Drawing.Point(496, 16);
            this.cboKindOfContract.Name = "cboKindOfContract";
            this.cboKindOfContract.Size = new System.Drawing.Size(264, 21);
            this.cboKindOfContract.TabIndex = 8;
            this.cboKindOfContract.SelectedIndexChanged += new System.EventHandler(this.cboKindOfContract_SelectedIndexChanged);
            // 
            // cboCustomerDept
            // 
            this.cboCustomerDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomerDept.Enabled = false;
            this.cboCustomerDept.Location = new System.Drawing.Point(112, 16);
            this.cboCustomerDept.Name = "cboCustomerDept";
            this.cboCustomerDept.Size = new System.Drawing.Size(280, 21);
            this.cboCustomerDept.TabIndex = 7;
            // 
            // dtpContractEnd
            // 
            this.dtpContractEnd.CustomFormat = "dd/MM/yyyy";
            this.dtpContractEnd.Enabled = false;
            this.dtpContractEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpContractEnd.Location = new System.Drawing.Point(304, 40);
            this.dtpContractEnd.Name = "dtpContractEnd";
            this.dtpContractEnd.Size = new System.Drawing.Size(88, 20);
            this.dtpContractEnd.TabIndex = 11;
            this.dtpContractEnd.ValueChanged += new System.EventHandler(this.dtpContractEnd_ValueChanged);
            // 
            // dtpContractStart
            // 
            this.dtpContractStart.CustomFormat = "dd/MM/yyyy";
            this.dtpContractStart.Enabled = false;
            this.dtpContractStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpContractStart.Location = new System.Drawing.Point(112, 40);
            this.dtpContractStart.Name = "dtpContractStart";
            this.dtpContractStart.Size = new System.Drawing.Size(88, 20);
            this.dtpContractStart.TabIndex = 9;
            this.dtpContractStart.ValueChanged += new System.EventHandler(this.dtpContractStart_ValueChanged);
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(216, 40);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 23);
            this.label17.TabIndex = 0;
            this.label17.Text = "วันที่สิ้นสุดสัญญา";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(16, 40);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(88, 23);
            this.label18.TabIndex = 0;
            this.label18.Text = "วันที่เริ่มต้นสัญญา";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(16, 16);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 23);
            this.label19.TabIndex = 0;
            this.label19.Text = "ฝ่ายลูกค้า";
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(408, 16);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(64, 23);
            this.label20.TabIndex = 0;
            this.label20.Text = "ชนิดสัญญา";
            // 
            // gpbApprove
            // 
            this.gpbApprove.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gpbApprove.Controls.Add(this.cmdContractApprove);
            this.gpbApprove.Location = new System.Drawing.Point(560, 424);
            this.gpbApprove.Name = "gpbApprove";
            this.gpbApprove.Size = new System.Drawing.Size(232, 80);
            this.gpbApprove.TabIndex = 0;
            this.gpbApprove.TabStop = false;
            this.gpbApprove.Text = "อนุมัติสัญญา";
            // 
            // cmdContractApprove
            // 
            this.cmdContractApprove.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdContractApprove.Location = new System.Drawing.Point(72, 32);
            this.cmdContractApprove.Name = "cmdContractApprove";
            this.cmdContractApprove.Size = new System.Drawing.Size(89, 23);
            this.cmdContractApprove.TabIndex = 14;
            this.cmdContractApprove.Text = "อนุมัติสัญญา";
            this.cmdContractApprove.Click += new System.EventHandler(this.cmdContractApprove_Click);
            // 
            // txtContractPrefix
            // 
            this.txtContractPrefix.Enabled = false;
            this.txtContractPrefix.Location = new System.Drawing.Point(536, 40);
            this.txtContractPrefix.Name = "txtContractPrefix";
            this.txtContractPrefix.Size = new System.Drawing.Size(24, 20);
            this.txtContractPrefix.TabIndex = 0;
            this.txtContractPrefix.Text = "C";
            this.txtContractPrefix.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
            this.label5.Location = new System.Drawing.Point(560, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(8, 23);
            this.label5.TabIndex = 44;
            this.label5.Text = "-";
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
            this.label25.Location = new System.Drawing.Point(488, 40);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(48, 23);
            this.label25.TabIndex = 0;
            this.label25.Text = "PTB  - ";
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(408, 40);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(64, 23);
            this.label26.TabIndex = 0;
            this.label26.Text = "เลขที่สัญญา";
            // 
            // cboContractStatus
            // 
            this.cboContractStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboContractStatus.ItemHeight = 13;
            this.cboContractStatus.Location = new System.Drawing.Point(96, 40);
            this.cboContractStatus.Name = "cboContractStatus";
            this.cboContractStatus.Size = new System.Drawing.Size(200, 21);
            this.cboContractStatus.TabIndex = 3;
            // 
            // cboContractType
            // 
            this.cboContractType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboContractType.ItemHeight = 13;
            this.cboContractType.Location = new System.Drawing.Point(488, 16);
            this.cboContractType.Name = "cboContractType";
            this.cboContractType.Size = new System.Drawing.Size(264, 21);
            this.cboContractType.TabIndex = 2;            
            this.cboContractType.SelectedIndexChanged += new System.EventHandler(this.cboContractType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(408, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "ประเภทสัญญา";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "สถานะสัญญา";
            // 
            // cboCustomerTHName
            // 
            this.cboCustomerTHName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomerTHName.ItemHeight = 13;
            this.cboCustomerTHName.Location = new System.Drawing.Point(96, 16);
            this.cboCustomerTHName.Name = "cboCustomerTHName";
            this.cboCustomerTHName.Size = new System.Drawing.Size(280, 21);
            this.cboCustomerTHName.TabIndex = 1;
            this.cboCustomerTHName.SelectedIndexChanged += new System.EventHandler(this.cboCustomerTHName_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "ชื่อลูกค้า";
            // 
            // gpbContractInfo
            // 
            this.gpbContractInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gpbContractInfo.Controls.Add(this.cboVehicleKindContract);
            this.gpbContractInfo.Controls.Add(this.label4);
            this.gpbContractInfo.Controls.Add(this.label22);
            this.gpbContractInfo.Controls.Add(this.label23);
            this.gpbContractInfo.Controls.Add(this.txtContractNoXXX);
            this.gpbContractInfo.Controls.Add(this.txtContractNoMM);
            this.gpbContractInfo.Controls.Add(this.txtContractNoYY);
            this.gpbContractInfo.Controls.Add(this.txtContractPrefix);
            this.gpbContractInfo.Controls.Add(this.label5);
            this.gpbContractInfo.Controls.Add(this.label25);
            this.gpbContractInfo.Controls.Add(this.label26);
            this.gpbContractInfo.Controls.Add(this.cboContractStatus);
            this.gpbContractInfo.Controls.Add(this.cboContractType);
            this.gpbContractInfo.Controls.Add(this.label3);
            this.gpbContractInfo.Controls.Add(this.label2);
            this.gpbContractInfo.Controls.Add(this.cboCustomerTHName);
            this.gpbContractInfo.Controls.Add(this.label1);
            this.gpbContractInfo.Location = new System.Drawing.Point(16, 0);
            this.gpbContractInfo.Name = "gpbContractInfo";
            this.gpbContractInfo.Size = new System.Drawing.Size(776, 88);
            this.gpbContractInfo.TabIndex = 0;
            this.gpbContractInfo.TabStop = false;
            this.gpbContractInfo.Text = "เรียกดูสัญญาตามเงื่อนไข";
            // 
            // cboVehicleKindContract
            // 
            this.cboVehicleKindContract.DropDownHeight = 105;
            this.cboVehicleKindContract.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVehicleKindContract.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboVehicleKindContract.FormattingEnabled = true;
            this.cboVehicleKindContract.IntegralHeight = false;
            this.cboVehicleKindContract.Location = new System.Drawing.Point(534, 39);
            this.cboVehicleKindContract.Name = "cboVehicleKindContract";
            this.cboVehicleKindContract.Size = new System.Drawing.Size(34, 21);
            this.cboVehicleKindContract.TabIndex = 52;
            this.cboVehicleKindContract.SelectedIndexChanged += new System.EventHandler(this.cboVehicleKindContract_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(648, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 16);
            this.label4.TabIndex = 51;
            this.label4.Text = "XXX";
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(613, 64);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(32, 16);
            this.label22.TabIndex = 50;
            this.label22.Text = "MM";
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(584, 64);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(24, 16);
            this.label23.TabIndex = 49;
            this.label23.Text = "YY";
            // 
            // txtContractNoXXX
            // 
            this.txtContractNoXXX.Location = new System.Drawing.Point(640, 40);
            this.txtContractNoXXX.MaxLength = 3;
            this.txtContractNoXXX.Name = "txtContractNoXXX";
            this.txtContractNoXXX.Size = new System.Drawing.Size(32, 20);
            this.txtContractNoXXX.TabIndex = 6;
            this.txtContractNoXXX.Text = "";
            this.txtContractNoXXX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtContractNoXXX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContractNoXXX_KeyDown);
            this.txtContractNoXXX.TextChanged += new System.EventHandler(this.txtContractNoXXX_TextChanged);
            this.txtContractNoXXX.DoubleClick += new System.EventHandler(this.txtContractNoXXX_DoubleClick);
            // 
            // txtContractNoMM
            // 
            this.txtContractNoMM.Location = new System.Drawing.Point(608, 40);
            this.txtContractNoMM.MaxLength = 2;
            this.txtContractNoMM.Name = "txtContractNoMM";
            this.txtContractNoMM.Size = new System.Drawing.Size(32, 20);
            this.txtContractNoMM.TabIndex = 5;
            this.txtContractNoMM.Text = "";
            this.txtContractNoMM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtContractNoMM.TextChanged += new System.EventHandler(this.txtContractNoMM_TextChanged);
            // 
            // txtContractNoYY
            // 
            this.txtContractNoYY.Location = new System.Drawing.Point(576, 40);
            this.txtContractNoYY.MaxLength = 2;
            this.txtContractNoYY.Name = "txtContractNoYY";
            this.txtContractNoYY.Size = new System.Drawing.Size(32, 20);
            this.txtContractNoYY.TabIndex = 4;
            this.txtContractNoYY.Text = "";
            this.txtContractNoYY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtContractNoYY.TextChanged += new System.EventHandler(this.txtContractNoYY_TextChanged);
            // 
            // gpbRemark
            // 
            this.gpbRemark.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gpbRemark.Controls.Add(this.label10);
            this.gpbRemark.Controls.Add(this.txtRemark);
            this.gpbRemark.Enabled = false;
            this.gpbRemark.Location = new System.Drawing.Point(16, 504);
            this.gpbRemark.Name = "gpbRemark";
            this.gpbRemark.Size = new System.Drawing.Size(776, 56);
            this.gpbRemark.TabIndex = 80;
            this.gpbRemark.TabStop = false;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(16, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 23);
            this.label10.TabIndex = 77;
            this.label10.Text = "หมายเหตุ";
            // 
            // txtRemark
            // 
            this.txtRemark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemark.Location = new System.Drawing.Point(72, 24);
            this.txtRemark.MaxLength = 60;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(688, 20);
            this.txtRemark.TabIndex = 78;
            this.txtRemark.Text = "";
            // 
            // gpbServiceCharge
            // 
            this.gpbServiceCharge.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gpbServiceCharge.Controls.Add(this.label6);
            this.gpbServiceCharge.Controls.Add(this.label11);
            this.gpbServiceCharge.Controls.Add(this.label16);
            this.gpbServiceCharge.Controls.Add(this.label12);
            this.gpbServiceCharge.Controls.Add(this.btnCal);
            this.gpbServiceCharge.Controls.Add(this.uctContractChargeNotDriver);
            this.gpbServiceCharge.Enabled = false;
            this.gpbServiceCharge.Location = new System.Drawing.Point(16, 184);
            this.gpbServiceCharge.Name = "gpbServiceCharge";
            this.gpbServiceCharge.Size = new System.Drawing.Size(776, 80);
            this.gpbServiceCharge.TabIndex = 122;
            this.gpbServiceCharge.TabStop = false;
            this.gpbServiceCharge.Text = "ค่าบริการ";
            this.gpbServiceCharge.Visible = false;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label6.Location = new System.Drawing.Point(344, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 23);
            this.label6.TabIndex = 81;
            this.label6.Text = "อัตราค่าบริการ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label11.Location = new System.Drawing.Point(560, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 23);
            this.label11.TabIndex = 80;
            this.label11.Text = "เดือนถัดไป";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label16.Location = new System.Drawing.Point(664, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(88, 23);
            this.label16.TabIndex = 79;
            this.label16.Text = "เดือนสุดท้าย";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label12.Location = new System.Drawing.Point(456, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 23);
            this.label12.TabIndex = 78;
            this.label12.Text = "เดือนแรก";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCal
            // 
            this.btnCal.Enabled = false;
            this.btnCal.Location = new System.Drawing.Point(264, 48);
            this.btnCal.Name = "btnCal";
            this.btnCal.Size = new System.Drawing.Size(72, 23);
            this.btnCal.TabIndex = 77;
            this.btnCal.Text = "คำนวณ";
            // 
            // uctContractChargeNotDriver
            // 
            this.uctContractChargeNotDriver.DateForm = new System.DateTime(((long)(0)));
            this.uctContractChargeNotDriver.DateTo = new System.DateTime(((long)(0)));
            this.uctContractChargeNotDriver.FirstMonth = new System.Decimal(new int[] {
																						  0,
																						  0,
																						  0,
																						  0});
            this.uctContractChargeNotDriver.LastMonth = new System.Decimal(new int[] {
																						 0,
																						 0,
																						 0,
																						 0});
            this.uctContractChargeNotDriver.Location = new System.Drawing.Point(336, 40);
            this.uctContractChargeNotDriver.Name = "uctContractChargeNotDriver";
            this.uctContractChargeNotDriver.NextMonth = new System.Decimal(new int[] {
																						 0,
																						 0,
																						 0,
																						 0});
            this.uctContractChargeNotDriver.RateAmount = new System.Decimal(new int[] {
																						  0,
																						  0,
																						  0,
																						  0});
            this.uctContractChargeNotDriver.RateAmountTag = new System.Decimal(new int[] {
																							 1,
																							 0,
																							 0,
																							 -2147483648});
            this.uctContractChargeNotDriver.RateStatusByMonth = false;
            this.uctContractChargeNotDriver.Size = new System.Drawing.Size(424, 32);
            this.uctContractChargeNotDriver.TabIndex = 82;
            this.uctContractChargeNotDriver.UnitChargeEnable = true;
            // 
            // gpbDriverServiceCharge
            // 
            this.gpbDriverServiceCharge.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gpbDriverServiceCharge.Controls.Add(this.label13);
            this.gpbDriverServiceCharge.Controls.Add(this.label14);
            this.gpbDriverServiceCharge.Controls.Add(this.label15);
            this.gpbDriverServiceCharge.Controls.Add(this.label21);
            this.gpbDriverServiceCharge.Controls.Add(this.uctContractCharge6);
            this.gpbDriverServiceCharge.Controls.Add(this.uctContractCharge5);
            this.gpbDriverServiceCharge.Controls.Add(this.uctContractCharge4);
            this.gpbDriverServiceCharge.Controls.Add(this.uctContractCharge3);
            this.gpbDriverServiceCharge.Controls.Add(this.uctContractCharge2);
            this.gpbDriverServiceCharge.Controls.Add(this.uctContractCharge1);
            this.gpbDriverServiceCharge.Controls.Add(this.lblYear6);
            this.gpbDriverServiceCharge.Controls.Add(this.lblYear5);
            this.gpbDriverServiceCharge.Controls.Add(this.lblYear4);
            this.gpbDriverServiceCharge.Controls.Add(this.lblYear3);
            this.gpbDriverServiceCharge.Controls.Add(this.lblYear2);
            this.gpbDriverServiceCharge.Controls.Add(this.lblYear1);
            this.gpbDriverServiceCharge.Controls.Add(this.btnCal6);
            this.gpbDriverServiceCharge.Controls.Add(this.dtpCCTo6);
            this.gpbDriverServiceCharge.Controls.Add(this.dtpCCForm6);
            this.gpbDriverServiceCharge.Controls.Add(this.btnCal5);
            this.gpbDriverServiceCharge.Controls.Add(this.dtpCCTo5);
            this.gpbDriverServiceCharge.Controls.Add(this.dtpCCForm5);
            this.gpbDriverServiceCharge.Controls.Add(this.btnCal4);
            this.gpbDriverServiceCharge.Controls.Add(this.dtpCCTo4);
            this.gpbDriverServiceCharge.Controls.Add(this.dtpCCForm4);
            this.gpbDriverServiceCharge.Controls.Add(this.btnCal3);
            this.gpbDriverServiceCharge.Controls.Add(this.dtpCCTo3);
            this.gpbDriverServiceCharge.Controls.Add(this.dtpCCForm3);
            this.gpbDriverServiceCharge.Controls.Add(this.btnCal2);
            this.gpbDriverServiceCharge.Controls.Add(this.dtpCCTo2);
            this.gpbDriverServiceCharge.Controls.Add(this.dtpCCForm2);
            this.gpbDriverServiceCharge.Controls.Add(this.btnCal1);
            this.gpbDriverServiceCharge.Controls.Add(this.dtpCCTo1);
            this.gpbDriverServiceCharge.Controls.Add(this.dtpCCForm1);
            this.gpbDriverServiceCharge.Controls.Add(this.label29);
            this.gpbDriverServiceCharge.Enabled = false;
            this.gpbDriverServiceCharge.Location = new System.Drawing.Point(16, 184);
            this.gpbDriverServiceCharge.Name = "gpbDriverServiceCharge";
            this.gpbDriverServiceCharge.Size = new System.Drawing.Size(776, 240);
            this.gpbDriverServiceCharge.TabIndex = 123;
            this.gpbDriverServiceCharge.TabStop = false;
            this.gpbDriverServiceCharge.Text = "ค่าบริการ";
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label13.Location = new System.Drawing.Point(664, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 23);
            this.label13.TabIndex = 69;
            this.label13.Text = "เดือนสุดท้าย";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label14.Location = new System.Drawing.Point(560, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 23);
            this.label14.TabIndex = 71;
            this.label14.Text = "เดือนถัดไป";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label15.Location = new System.Drawing.Point(456, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 23);
            this.label15.TabIndex = 67;
            this.label15.Text = "เดือนแรก";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label21.Location = new System.Drawing.Point(344, 16);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(96, 23);
            this.label21.TabIndex = 76;
            this.label21.Text = "อัตราค่าบริการ";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uctContractCharge6
            // 
            this.uctContractCharge6.DateForm = new System.DateTime(((long)(0)));
            this.uctContractCharge6.DateTo = new System.DateTime(((long)(0)));
            this.uctContractCharge6.FirstMonth = new System.Decimal(new int[] {
																				  0,
																				  0,
																				  0,
																				  0});
            this.uctContractCharge6.LastMonth = new System.Decimal(new int[] {
																				 0,
																				 0,
																				 0,
																				 0});
            this.uctContractCharge6.Location = new System.Drawing.Point(336, 200);
            this.uctContractCharge6.Name = "uctContractCharge6";
            this.uctContractCharge6.NextMonth = new System.Decimal(new int[] {
																				 0,
																				 0,
																				 0,
																				 0});
            this.uctContractCharge6.RateAmount = new System.Decimal(new int[] {
																				  0,
																				  0,
																				  0,
																				  0});
            this.uctContractCharge6.RateAmountTag = new System.Decimal(new int[] {
																					 1,
																					 0,
																					 0,
																					 -2147483648});
            this.uctContractCharge6.RateStatusByMonth = false;
            this.uctContractCharge6.Size = new System.Drawing.Size(424, 32);
            this.uctContractCharge6.TabIndex = 125;
            this.uctContractCharge6.UnitChargeEnable = true;
            // 
            // uctContractCharge5
            // 
            this.uctContractCharge5.DateForm = new System.DateTime(((long)(0)));
            this.uctContractCharge5.DateTo = new System.DateTime(((long)(0)));
            this.uctContractCharge5.FirstMonth = new System.Decimal(new int[] {
																				  0,
																				  0,
																				  0,
																				  0});
            this.uctContractCharge5.LastMonth = new System.Decimal(new int[] {
																				 0,
																				 0,
																				 0,
																				 0});
            this.uctContractCharge5.Location = new System.Drawing.Point(336, 168);
            this.uctContractCharge5.Name = "uctContractCharge5";
            this.uctContractCharge5.NextMonth = new System.Decimal(new int[] {
																				 0,
																				 0,
																				 0,
																				 0});
            this.uctContractCharge5.RateAmount = new System.Decimal(new int[] {
																				  0,
																				  0,
																				  0,
																				  0});
            this.uctContractCharge5.RateAmountTag = new System.Decimal(new int[] {
																					 1,
																					 0,
																					 0,
																					 -2147483648});
            this.uctContractCharge5.RateStatusByMonth = false;
            this.uctContractCharge5.Size = new System.Drawing.Size(424, 32);
            this.uctContractCharge5.TabIndex = 124;
            this.uctContractCharge5.UnitChargeEnable = true;
            // 
            // uctContractCharge4
            // 
            this.uctContractCharge4.DateForm = new System.DateTime(((long)(0)));
            this.uctContractCharge4.DateTo = new System.DateTime(((long)(0)));
            this.uctContractCharge4.FirstMonth = new System.Decimal(new int[] {
																				  0,
																				  0,
																				  0,
																				  0});
            this.uctContractCharge4.LastMonth = new System.Decimal(new int[] {
																				 0,
																				 0,
																				 0,
																				 0});
            this.uctContractCharge4.Location = new System.Drawing.Point(336, 136);
            this.uctContractCharge4.Name = "uctContractCharge4";
            this.uctContractCharge4.NextMonth = new System.Decimal(new int[] {
																				 0,
																				 0,
																				 0,
																				 0});
            this.uctContractCharge4.RateAmount = new System.Decimal(new int[] {
																				  0,
																				  0,
																				  0,
																				  0});
            this.uctContractCharge4.RateAmountTag = new System.Decimal(new int[] {
																					 1,
																					 0,
																					 0,
																					 -2147483648});
            this.uctContractCharge4.RateStatusByMonth = false;
            this.uctContractCharge4.Size = new System.Drawing.Size(424, 32);
            this.uctContractCharge4.TabIndex = 123;
            this.uctContractCharge4.UnitChargeEnable = true;
            // 
            // uctContractCharge3
            // 
            this.uctContractCharge3.DateForm = new System.DateTime(((long)(0)));
            this.uctContractCharge3.DateTo = new System.DateTime(((long)(0)));
            this.uctContractCharge3.FirstMonth = new System.Decimal(new int[] {
																				  0,
																				  0,
																				  0,
																				  0});
            this.uctContractCharge3.LastMonth = new System.Decimal(new int[] {
																				 0,
																				 0,
																				 0,
																				 0});
            this.uctContractCharge3.Location = new System.Drawing.Point(336, 104);
            this.uctContractCharge3.Name = "uctContractCharge3";
            this.uctContractCharge3.NextMonth = new System.Decimal(new int[] {
																				 0,
																				 0,
																				 0,
																				 0});
            this.uctContractCharge3.RateAmount = new System.Decimal(new int[] {
																				  0,
																				  0,
																				  0,
																				  0});
            this.uctContractCharge3.RateAmountTag = new System.Decimal(new int[] {
																					 1,
																					 0,
																					 0,
																					 -2147483648});
            this.uctContractCharge3.RateStatusByMonth = false;
            this.uctContractCharge3.Size = new System.Drawing.Size(424, 32);
            this.uctContractCharge3.TabIndex = 122;
            this.uctContractCharge3.UnitChargeEnable = true;
            // 
            // uctContractCharge2
            // 
            this.uctContractCharge2.DateForm = new System.DateTime(((long)(0)));
            this.uctContractCharge2.DateTo = new System.DateTime(((long)(0)));
            this.uctContractCharge2.FirstMonth = new System.Decimal(new int[] {
																				  0,
																				  0,
																				  0,
																				  0});
            this.uctContractCharge2.LastMonth = new System.Decimal(new int[] {
																				 0,
																				 0,
																				 0,
																				 0});
            this.uctContractCharge2.Location = new System.Drawing.Point(336, 72);
            this.uctContractCharge2.Name = "uctContractCharge2";
            this.uctContractCharge2.NextMonth = new System.Decimal(new int[] {
																				 0,
																				 0,
																				 0,
																				 0});
            this.uctContractCharge2.RateAmount = new System.Decimal(new int[] {
																				  0,
																				  0,
																				  0,
																				  0});
            this.uctContractCharge2.RateAmountTag = new System.Decimal(new int[] {
																					 1,
																					 0,
																					 0,
																					 -2147483648});
            this.uctContractCharge2.RateStatusByMonth = false;
            this.uctContractCharge2.Size = new System.Drawing.Size(424, 32);
            this.uctContractCharge2.TabIndex = 121;
            this.uctContractCharge2.UnitChargeEnable = true;
            // 
            // uctContractCharge1
            // 
            this.uctContractCharge1.DateForm = new System.DateTime(((long)(0)));
            this.uctContractCharge1.DateTo = new System.DateTime(((long)(0)));
            this.uctContractCharge1.FirstMonth = new System.Decimal(new int[] {
																				  0,
																				  0,
																				  0,
																				  0});
            this.uctContractCharge1.LastMonth = new System.Decimal(new int[] {
																				 0,
																				 0,
																				 0,
																				 0});
            this.uctContractCharge1.Location = new System.Drawing.Point(336, 40);
            this.uctContractCharge1.Name = "uctContractCharge1";
            this.uctContractCharge1.NextMonth = new System.Decimal(new int[] {
																				 0,
																				 0,
																				 0,
																				 0});
            this.uctContractCharge1.RateAmount = new System.Decimal(new int[] {
																				  0,
																				  0,
																				  0,
																				  0});
            this.uctContractCharge1.RateAmountTag = new System.Decimal(new int[] {
																					 1,
																					 0,
																					 0,
																					 -2147483648});
            this.uctContractCharge1.RateStatusByMonth = false;
            this.uctContractCharge1.Size = new System.Drawing.Size(424, 32);
            this.uctContractCharge1.TabIndex = 120;
            this.uctContractCharge1.UnitChargeEnable = true;
            // 
            // lblYear6
            // 
            this.lblYear6.Location = new System.Drawing.Point(32, 208);
            this.lblYear6.Name = "lblYear6";
            this.lblYear6.Size = new System.Drawing.Size(16, 23);
            this.lblYear6.TabIndex = 118;
            this.lblYear6.Text = "6.";
            // 
            // lblYear5
            // 
            this.lblYear5.Location = new System.Drawing.Point(32, 176);
            this.lblYear5.Name = "lblYear5";
            this.lblYear5.Size = new System.Drawing.Size(16, 23);
            this.lblYear5.TabIndex = 117;
            this.lblYear5.Text = "5.";
            // 
            // lblYear4
            // 
            this.lblYear4.Location = new System.Drawing.Point(32, 144);
            this.lblYear4.Name = "lblYear4";
            this.lblYear4.Size = new System.Drawing.Size(16, 23);
            this.lblYear4.TabIndex = 116;
            this.lblYear4.Text = "4.";
            // 
            // lblYear3
            // 
            this.lblYear3.Location = new System.Drawing.Point(32, 112);
            this.lblYear3.Name = "lblYear3";
            this.lblYear3.Size = new System.Drawing.Size(16, 23);
            this.lblYear3.TabIndex = 115;
            this.lblYear3.Text = "3.";
            // 
            // lblYear2
            // 
            this.lblYear2.Location = new System.Drawing.Point(32, 80);
            this.lblYear2.Name = "lblYear2";
            this.lblYear2.Size = new System.Drawing.Size(16, 23);
            this.lblYear2.TabIndex = 114;
            this.lblYear2.Text = "2.";
            // 
            // lblYear1
            // 
            this.lblYear1.Location = new System.Drawing.Point(32, 48);
            this.lblYear1.Name = "lblYear1";
            this.lblYear1.Size = new System.Drawing.Size(16, 23);
            this.lblYear1.TabIndex = 113;
            this.lblYear1.Text = "1.";
            // 
            // btnCal6
            // 
            this.btnCal6.Enabled = false;
            this.btnCal6.Location = new System.Drawing.Point(56, 208);
            this.btnCal6.Name = "btnCal6";
            this.btnCal6.Size = new System.Drawing.Size(48, 23);
            this.btnCal6.TabIndex = 112;
            this.btnCal6.Text = "คำนวณ";
            // 
            // dtpCCTo6
            // 
            this.dtpCCTo6.CustomFormat = "dd/MM/yyyy";
            this.dtpCCTo6.Enabled = false;
            this.dtpCCTo6.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCCTo6.Location = new System.Drawing.Point(232, 208);
            this.dtpCCTo6.Name = "dtpCCTo6";
            this.dtpCCTo6.Size = new System.Drawing.Size(96, 20);
            this.dtpCCTo6.TabIndex = 111;
            // 
            // dtpCCForm6
            // 
            this.dtpCCForm6.CustomFormat = "dd/MM/yyyy";
            this.dtpCCForm6.Enabled = false;
            this.dtpCCForm6.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCCForm6.Location = new System.Drawing.Point(120, 208);
            this.dtpCCForm6.Name = "dtpCCForm6";
            this.dtpCCForm6.Size = new System.Drawing.Size(96, 20);
            this.dtpCCForm6.TabIndex = 110;
            // 
            // btnCal5
            // 
            this.btnCal5.Enabled = false;
            this.btnCal5.Location = new System.Drawing.Point(56, 176);
            this.btnCal5.Name = "btnCal5";
            this.btnCal5.Size = new System.Drawing.Size(48, 23);
            this.btnCal5.TabIndex = 105;
            this.btnCal5.Text = "คำนวณ";
            // 
            // dtpCCTo5
            // 
            this.dtpCCTo5.CustomFormat = "dd/MM/yyyy";
            this.dtpCCTo5.Enabled = false;
            this.dtpCCTo5.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCCTo5.Location = new System.Drawing.Point(232, 176);
            this.dtpCCTo5.Name = "dtpCCTo5";
            this.dtpCCTo5.Size = new System.Drawing.Size(96, 20);
            this.dtpCCTo5.TabIndex = 104;
            // 
            // dtpCCForm5
            // 
            this.dtpCCForm5.CustomFormat = "dd/MM/yyyy";
            this.dtpCCForm5.Enabled = false;
            this.dtpCCForm5.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCCForm5.Location = new System.Drawing.Point(120, 176);
            this.dtpCCForm5.Name = "dtpCCForm5";
            this.dtpCCForm5.Size = new System.Drawing.Size(96, 20);
            this.dtpCCForm5.TabIndex = 103;
            // 
            // btnCal4
            // 
            this.btnCal4.Enabled = false;
            this.btnCal4.Location = new System.Drawing.Point(56, 144);
            this.btnCal4.Name = "btnCal4";
            this.btnCal4.Size = new System.Drawing.Size(48, 23);
            this.btnCal4.TabIndex = 98;
            this.btnCal4.Text = "คำนวณ";
            // 
            // dtpCCTo4
            // 
            this.dtpCCTo4.CustomFormat = "dd/MM/yyyy";
            this.dtpCCTo4.Enabled = false;
            this.dtpCCTo4.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCCTo4.Location = new System.Drawing.Point(232, 144);
            this.dtpCCTo4.Name = "dtpCCTo4";
            this.dtpCCTo4.Size = new System.Drawing.Size(96, 20);
            this.dtpCCTo4.TabIndex = 97;
            // 
            // dtpCCForm4
            // 
            this.dtpCCForm4.CustomFormat = "dd/MM/yyyy";
            this.dtpCCForm4.Enabled = false;
            this.dtpCCForm4.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCCForm4.Location = new System.Drawing.Point(120, 144);
            this.dtpCCForm4.Name = "dtpCCForm4";
            this.dtpCCForm4.Size = new System.Drawing.Size(96, 20);
            this.dtpCCForm4.TabIndex = 96;
            // 
            // btnCal3
            // 
            this.btnCal3.Enabled = false;
            this.btnCal3.Location = new System.Drawing.Point(56, 112);
            this.btnCal3.Name = "btnCal3";
            this.btnCal3.Size = new System.Drawing.Size(48, 23);
            this.btnCal3.TabIndex = 91;
            this.btnCal3.Text = "คำนวณ";
            // 
            // dtpCCTo3
            // 
            this.dtpCCTo3.CustomFormat = "dd/MM/yyyy";
            this.dtpCCTo3.Enabled = false;
            this.dtpCCTo3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCCTo3.Location = new System.Drawing.Point(232, 112);
            this.dtpCCTo3.Name = "dtpCCTo3";
            this.dtpCCTo3.Size = new System.Drawing.Size(96, 20);
            this.dtpCCTo3.TabIndex = 90;
            // 
            // dtpCCForm3
            // 
            this.dtpCCForm3.CustomFormat = "dd/MM/yyyy";
            this.dtpCCForm3.Enabled = false;
            this.dtpCCForm3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCCForm3.Location = new System.Drawing.Point(120, 112);
            this.dtpCCForm3.Name = "dtpCCForm3";
            this.dtpCCForm3.Size = new System.Drawing.Size(96, 20);
            this.dtpCCForm3.TabIndex = 89;
            // 
            // btnCal2
            // 
            this.btnCal2.Enabled = false;
            this.btnCal2.Location = new System.Drawing.Point(56, 80);
            this.btnCal2.Name = "btnCal2";
            this.btnCal2.Size = new System.Drawing.Size(48, 23);
            this.btnCal2.TabIndex = 84;
            this.btnCal2.Text = "คำนวณ";
            // 
            // dtpCCTo2
            // 
            this.dtpCCTo2.CustomFormat = "dd/MM/yyyy";
            this.dtpCCTo2.Enabled = false;
            this.dtpCCTo2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCCTo2.Location = new System.Drawing.Point(232, 80);
            this.dtpCCTo2.Name = "dtpCCTo2";
            this.dtpCCTo2.Size = new System.Drawing.Size(96, 20);
            this.dtpCCTo2.TabIndex = 83;
            // 
            // dtpCCForm2
            // 
            this.dtpCCForm2.CustomFormat = "dd/MM/yyyy";
            this.dtpCCForm2.Enabled = false;
            this.dtpCCForm2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCCForm2.Location = new System.Drawing.Point(120, 80);
            this.dtpCCForm2.Name = "dtpCCForm2";
            this.dtpCCForm2.Size = new System.Drawing.Size(96, 20);
            this.dtpCCForm2.TabIndex = 82;
            // 
            // btnCal1
            // 
            this.btnCal1.Enabled = false;
            this.btnCal1.Location = new System.Drawing.Point(56, 48);
            this.btnCal1.Name = "btnCal1";
            this.btnCal1.Size = new System.Drawing.Size(48, 23);
            this.btnCal1.TabIndex = 77;
            this.btnCal1.Text = "คำนวณ";
            // 
            // dtpCCTo1
            // 
            this.dtpCCTo1.CustomFormat = "dd/MM/yyyy";
            this.dtpCCTo1.Enabled = false;
            this.dtpCCTo1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCCTo1.Location = new System.Drawing.Point(232, 48);
            this.dtpCCTo1.Name = "dtpCCTo1";
            this.dtpCCTo1.Size = new System.Drawing.Size(96, 20);
            this.dtpCCTo1.TabIndex = 75;
            // 
            // dtpCCForm1
            // 
            this.dtpCCForm1.CustomFormat = "dd/MM/yyyy";
            this.dtpCCForm1.Enabled = false;
            this.dtpCCForm1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCCForm1.Location = new System.Drawing.Point(120, 48);
            this.dtpCCForm1.Name = "dtpCCForm1";
            this.dtpCCForm1.Size = new System.Drawing.Size(96, 20);
            this.dtpCCForm1.TabIndex = 74;
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label29.Location = new System.Drawing.Point(120, 16);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(208, 23);
            this.label29.TabIndex = 73;
            this.label29.Text = "สัญญาระหว่างวันที่";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmContractApprove
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(808, 613);
            this.Controls.Add(this.gpbServiceCharge);
            this.Controls.Add(this.gpbRemark);
            this.Controls.Add(this.gpbApprove);
            this.Controls.Add(this.gpbAssignment);
            this.Controls.Add(this.gpbDetail);
            this.Controls.Add(this.gpbContractInfo);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.gpbDriverServiceCharge);
            this.Name = "frmContractApprove";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //this.Text = "อนุมัติสัญญา";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmContractApprove_Load);
            this.Closed += new System.EventHandler(this.frmContractApprove_Closed);
            this.gpbAssignment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpsVehicleContract)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsVehicleContract_Sheet1)).EndInit();
            this.gpbDetail.ResumeLayout(false);
            this.gpbApprove.ResumeLayout(false);
            this.gpbContractInfo.ResumeLayout(false);
            this.gpbRemark.ResumeLayout(false);
            this.gpbServiceCharge.ResumeLayout(false);
            this.gpbDriverServiceCharge.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
        # region - Private -
        private struct ContractChargeControl
        {
            public Label yearLabel;
            public Button CalculateButton;
            public DateTimePicker FormDateDTP;
            public DateTimePicker ToDateDTP;
            public UCTContractCharge UCTContractCharge;
        }

        private bool isReadonly = true;
        private bool isTextChange = true;
        private frmMain mdiParent;
        private ContractBase objContractBase;
        private VehicleContract objVehicleContract;
        private ContractApproveFacade facadeContractApprove;

        //D21018-BTS Contract Modification        
        private DOCUMENT_TYPE _documentType = DOCUMENT_TYPE.CONTRACT;
        private DOCUMENT_TYPE DocumentType
        {
            set
            {
                _documentType = value;
            }
        }

        # endregion - Private -

        private DocumentNo getContractNo()
        {
            //DocumentNo contractNo = new DocumentNo(DOCUMENT_TYPE.CONTRACT, txtContractNoYY.Text, txtContractNoMM.Text, txtContractNoXXX.Text);

            //D21018 ส่ง document type ตาม dropdown ที่เลือก
            DocumentNo contractNo = new DocumentNo(_documentType, txtContractNoYY.Text, txtContractNoMM.Text, txtContractNoXXX.Text);
            return contractNo;
        }

        private void setContractBase(ContractBase value)
        {
            isTextChange = false;
            objContractBase = value;
            txtContractNoYY.Text = value.ContractNo.Year;
            txtContractNoMM.Text = value.ContractNo.Month;
            txtContractNoXXX.Text = value.ContractNo.No;
            cboCustomerTHName.Text = value.ACustomerDepartment.ACustomer.ToString();
            cboContractType.Text = GUIFunction.GetString(value.AContractType);
            cboContractStatus.Text = GUIFunction.GetString(value.AContractStatus);
            cboCustomerDept.Text = value.ACustomerDepartment.ToString();
            cboKindOfContract.Text = GUIFunction.GetString(value.AKindOfContract.AName.Thai);
            dtpContractStart.Value = value.APeriod.From;
            dtpContractEnd.Value = value.APeriod.To;
            fpiUnitHire.Value = value.UnitHire;

            if (value.RateStatus == RATE_STATUS_TYPE.DAY)
            {
                rdoDay.Checked = true;
            }
            else
            {
                rdoMonth.Checked = true;
            }

            txtRemark.Text = value.Remark;
            isTextChange = true;
        }

        //		============================== Constructor ==============================
        public frmContractApprove()
            : base()
        {
            InitializeComponent();
            objContractBase = new ContractBase();
            facadeContractApprove = new ContractApproveFacade();

            cboCustomerTHName.DataSource = facadeContractApprove.DataSourceCustomerName;
            cboContractType.DataSource = facadeContractApprove.DataSourceContractType;
            cboContractStatus.DataSource = facadeContractApprove.DataSourceContractStatus;
            cboKindOfContract.DataSource = facadeContractApprove.DataSourceKindOfContract; 

            hideGroupBox(false);
            isReadonly = UserProfile.IsReadOnly("miContract", "miContractDocumentApprove");
            this.title = UserProfile.GetFormName("miContract", "miContractDocumentApprove");

            //D21018 set default contract type to สัญญาเช่ารถยนต์
            this.cboContractType.SelectedIndex = 2;

        }
        public override string FormID()
        {
            return UserProfile.GetFormID("miContract", "miContractDocumentApprove");
        }
        //		============================== Private Method ==============================
        #region - Hide & Enable GroupBox -
        private void hideGroupBox(bool enable)
        {
            gpbApprove.Visible = enable;
            gpbDetail.Visible = enable;
            gpbRemark.Visible = enable;
            cmdCancel.Visible = enable;
        }

        private void hideCancelDate(bool enable)
        {
            lblCancelDate.Visible = enable;
            dtpCancelDate.Visible = enable;
        }

        private void enableGPBContractInfo(bool enable)
        {
            gpbContractInfo.Enabled = enable;
        }

        private void hideIsServiceChargeDriver(bool enable)
        {
            gpbDriverServiceCharge.Visible = enable;
            gpbServiceCharge.Visible = !enable;
            gpbAssignment.Visible = !enable;
        }

        private void hideIsServiceChargeVehicle(bool enable)
        {
            gpbDriverServiceCharge.Visible = !enable;
            gpbServiceCharge.Visible = enable;
            gpbAssignment.Visible = enable;
        }

        private void hideIsServiceChargeOther(bool enable)
        {
            gpbDriverServiceCharge.Visible = !enable;
            gpbServiceCharge.Visible = enable;
            gpbAssignment.Visible = !enable;
        }

        private void visibleContractCharge(ContractChargeControl control, bool visible)
        {
            control.yearLabel.Visible = visible;
            control.CalculateButton.Visible = visible;
            control.FormDateDTP.Visible = visible;
            control.ToDateDTP.Visible = visible;
            control.UCTContractCharge.Visible = visible;
        }

        private void clearContractCharge(ContractChargeControl control)
        {
            control.FormDateDTP.Value = DateTime.Today.Date;
            control.ToDateDTP.Value = DateTime.Today.Date;
            control.UCTContractCharge.Clear();
            visibleContractCharge(control, false);
        }
        #endregion - Hide & Enable GroupBox -

        #region - Validate Input Checking -
        private bool validateInputContract()
        {
            if (validatetxtContractNoYY() && validatetxtContractNoMM() && validatetxtContractNoXXX() && validateContractNo())
            { return true; }
            else
            { return false; }
        }

        private bool validatetxtContractNoYY()
        {
            if (txtContractNoYY.Text == "")
            {
                Message(MessageList.Error.E0002, "เลขที่สัญญา");
                txtContractNoYY.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool validatetxtContractNoMM()
        {
            if (txtContractNoMM.Text == "")
            {
                Message(MessageList.Error.E0002, "เลขที่สัญญา");
                txtContractNoMM.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool validatetxtContractNoXXX()
        {
            if (txtContractNoXXX.Text == "")
            {
                Message(MessageList.Error.E0002, "เลขที่สัญญา");
                txtContractNoXXX.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool validateContractNo()
        {
            if (facadeContractApprove.RetriveContract(getContractNo()) != null)
                return true;
            else
            {
                Message(MessageList.Error.E0004, "เลขที่สัญญา");
                txtContractNoYY.Focus();
                return false;
            }
        }

        #endregion - Validate Input Checking -

        #region - Validate Condition Checking -
        private bool checkContractStatus()
        {
            if (objContractBase.AContractStatus.Code != "1")
            {
                Message(MessageList.Error.E0013, "อนุมัติสัญญาได้", "สัญญาฉบับนี้ผ่านการอนุมัติหรือยกเลิกไปแล้ว");
                cmdCancel.Focus();
                return false;
            }
            return true;
        }

        private bool checkVehicle(VehicleContract value)
        {
            if (value != null)
            {
                if (fpsVehicleContract_Sheet1.RowCount != 0)
                {
                    VehicleAssignment vehicleAssignment;
                    Vehicle vehicle;

                    for (int i = 0; i < fpsVehicleContract_Sheet1.RowCount; i++)
                    {
                        vehicleAssignment = new VehicleAssignment();
                        vehicle = new Vehicle();

                        string plateNo = fpsVehicleContract_Sheet1.Cells.Get(i, 1).Text;

                        vehicle = facadeContractApprove.GetVehicleGeneral(int.Parse(fpsVehicleContract_Sheet1.Cells[i, 0].Text));
                        vehicleAssignment.AAssignedVehicle = vehicle;
                        vehicleAssignment.APeriod.From = dtpContractStart.Value.Date;
                        vehicleAssignment.APeriod.To = dtpContractEnd.Value.Date;

                        if (facadeContractApprove.FillExcludeAvailableVehicleSpareAssignment(ref vehicleAssignment))
                        {
                            Message(MessageList.Error.E0013, "อนุมัติรถ " + plateNo, " รถคันนี้ถูกใช้งานในช่วงเวลาดังกล่าว");
                            cmdCancel.Focus();
                            return false;
                        }

                        if (vehicle != null && vehicle.AVehicleStatus.Code != "1")
                        {
                            Message(MessageList.Error.E0013, "อนุมัติรถ " + plateNo + " ได้", "รถคันนี้ไม่อยู่ในสถานะที่พร้อมจะใช้งาน");
                            cmdCancel.Focus();
                            return false;
                        }
                    }

                    vehicleAssignment = null;
                    vehicle = null;
                }
            }
            return true;
        }

        #endregion - Validate Condition Checking -

        private void formContractList()
        {
            frmContractVDOList dialogContractList = new frmContractVDOList();

            if (cboCustomerTHName.Text != "")
            { dialogContractList.ConditionCustomer = (Customer)cboCustomerTHName.SelectedItem; }

            if (cboContractType.Text != "")
            { dialogContractList.ConditionCONTRACT_TYPE = (ContractType)cboContractType.SelectedItem; }

            //D21018 Support set contract type from dropdown
            if (((ContractType)cboContractType.SelectedItem).Code == ContractType.CONTRACT_TYPE_DRIVER)
            {
                dialogContractList.DocumentType = Entity.CommonEntity.DOCUMENT_TYPE.CONTRACT_DRIVER;
                this.DocumentType = dialogContractList.DocumentType;
            }

            if (cboVehicleKindContract.Visible)
            {
                switch (cboVehicleKindContract.Text)
                {
                    case "C":
                        dialogContractList.DocumentType = Entity.CommonEntity.DOCUMENT_TYPE.CONTRACT;
                        break;
                    case "R":
                        dialogContractList.DocumentType = Entity.CommonEntity.DOCUMENT_TYPE.CONTRACT_RENEWAL;
                        break;
                    case "T":
                        dialogContractList.DocumentType = Entity.CommonEntity.DOCUMENT_TYPE.CONTRACT_TEMPORARY;
                        break;
                    default:
                        dialogContractList.DocumentType = Entity.CommonEntity.DOCUMENT_TYPE.CONTRACT;
                        break;
                }
                this.DocumentType = dialogContractList.DocumentType;
            }


            if (cboContractStatus.Text != "")
            { dialogContractList.ConditionContractStatus = (ContractStatus)cboContractStatus.SelectedItem; }

            if (txtContractNoYY.Text != "")
            { dialogContractList.ConditionYY = txtContractNoYY.Text; }

            if (txtContractNoMM.Text != "")
            { dialogContractList.ConditionMM = txtContractNoMM.Text; }

            dialogContractList.ShowDialog();
            if (dialogContractList.Selected)
            {
                setContractBase(dialogContractList.SelectedContract);
                retriveContract();
            }
        }

        private void retriveContract()
        {
            mdiParent.EnableNewCommand(true);
            mdiParent.EnableDeleteCommand(false);
            mdiParent.EnableRefreshCommand(false);
            mdiParent.EnablePrintCommand(false);

            MainMenuNewStatus = true;
            MainMenuDeleteStatus = false;
            MainMenuRefreshStatus = false;
            MainMenuPrintStatus = false;

            try
            {
                objContractBase = facadeContractApprove.RetriveContract(getContractNo());
                setContractBase(objContractBase);

                if (objContractBase.AContractType.Code == ContractType.CONTRACT_TYPE_VEHICLE)
                {
                    hideIsServiceChargeVehicle(true);
                    objVehicleContract = (VehicleContract)objContractBase;

                    if (objVehicleContract != null)
                    {
                        bindForm(objVehicleContract);
                        bindContractCharge(uctContractChargeNotDriver, objVehicleContract.AContractChargeList[0]);
                    }
                    else
                    {
                        fpsVehicleContract_Sheet1.RowCount = 0;
                    }
                }
                else if (objContractBase.AContractType.Code == ContractType.CONTRACT_TYPE_DRIVER)
                {
                    hideIsServiceChargeDriver(true);
                    setUCT(0, objContractBase.AContractChargeList);
                }
                else
                {
                    hideIsServiceChargeOther(true);
                    bindContractCharge(uctContractChargeNotDriver, objContractBase.AContractChargeList[0]);
                }

                if (objContractBase.AContractStatus.Code == "3")
                {
                    hideCancelDate(true);
                    dtpCancelDate.Value = objContractBase.CancelDate;
                }
                else
                {
                    hideCancelDate(false);
                }
                hideGroupBox(true);
                enableGPBContractInfo(false);
            }
            catch (SqlException sqlex)
            { Message(sqlex); }
            catch (AppExceptionBase ex)
            { Message(ex); }
            catch (Exception ex)
            { Message(ex); }
            finally
            {
                if (isReadonly)
                {
                    gpbApprove.Enabled = false;
                }
            }
        }

        private ContractChargeControl getControl(int index)
        {
            ContractChargeControl contractChargeControl = new ContractChargeControl();
            switch (index)
            {
                case 0:
                    {
                        contractChargeControl.yearLabel = lblYear1;
                        contractChargeControl.CalculateButton = btnCal1;
                        contractChargeControl.FormDateDTP = dtpCCForm1;
                        contractChargeControl.ToDateDTP = dtpCCTo1;
                        contractChargeControl.UCTContractCharge = uctContractCharge1;
                        break;
                    }
                case 1:
                    {
                        contractChargeControl.yearLabel = lblYear2;
                        contractChargeControl.CalculateButton = btnCal2;
                        contractChargeControl.FormDateDTP = dtpCCForm2;
                        contractChargeControl.ToDateDTP = dtpCCTo2;
                        contractChargeControl.UCTContractCharge = uctContractCharge2;
                        break;
                    }
                case 2:
                    {
                        contractChargeControl.yearLabel = lblYear3;
                        contractChargeControl.CalculateButton = btnCal3;
                        contractChargeControl.FormDateDTP = dtpCCForm3;
                        contractChargeControl.ToDateDTP = dtpCCTo3;
                        contractChargeControl.UCTContractCharge = uctContractCharge3;
                        break;
                    }
                case 3:
                    {
                        contractChargeControl.yearLabel = lblYear4;
                        contractChargeControl.CalculateButton = btnCal4;
                        contractChargeControl.FormDateDTP = dtpCCForm4;
                        contractChargeControl.ToDateDTP = dtpCCTo4;
                        contractChargeControl.UCTContractCharge = uctContractCharge4;
                        break;
                    }
                case 4:
                    {
                        contractChargeControl.yearLabel = lblYear5;
                        contractChargeControl.CalculateButton = btnCal5;
                        contractChargeControl.FormDateDTP = dtpCCForm5;
                        contractChargeControl.ToDateDTP = dtpCCTo5;
                        contractChargeControl.UCTContractCharge = uctContractCharge5;
                        break;
                    }
                case 5:
                    {
                        contractChargeControl.yearLabel = lblYear6;
                        contractChargeControl.CalculateButton = btnCal6;
                        contractChargeControl.FormDateDTP = dtpCCForm6;
                        contractChargeControl.ToDateDTP = dtpCCTo6;
                        contractChargeControl.UCTContractCharge = uctContractCharge6;
                        break;
                    }
            }
            return contractChargeControl;
        }

        private void bindContractCharge(UCTContractCharge control, ContractCharge value)
        {
            if (value == null)
            {
                control.RateAmount = 0;
                control.FirstMonth = 0;
                control.NextMonth = 0;
                control.LastMonth = 0;
            }
            else
            {
                control.RateAmountTag = value.UnitChargeAmount;
                control.RateAmount = value.UnitChargeAmount;
                control.FirstMonth = value.FirstMonthCharge;
                control.NextMonth = value.MonthlyCharge;
                control.LastMonth = value.LastMonthCharge;

                control.DateForm = value.APeriod.From.Date;
                control.DateTo = value.APeriod.To.Date;
                control.RateStatusByMonth = rdoMonth.Checked;
            }
        }

        private void fillContractCharge(ContractChargeControl control, int index, ContractChargeList value)
        {
            visibleContractCharge(control, true);

            ContractCharge contractCharge = value[index];

            bindContractCharge(control.UCTContractCharge, contractCharge);

            control.FormDateDTP.Value = contractCharge.APeriod.From.Date;
            control.ToDateDTP.Value = contractCharge.APeriod.To.Date;

            contractCharge = null;
        }

        private void setUCT(int index, ContractChargeList value)
        {
            ContractChargeControl control = getControl(index);
            fillContractCharge(control, index, value);

            if (index == value.Count - 1)
            {
                return;
            }
            else
            {
                setUCT(index + 1, value);
            }
        }


        private void clearContractCharge()
        {
            clearContractCharge(getControl(0));
            clearContractCharge(getControl(1));
            clearContractCharge(getControl(2));
            clearContractCharge(getControl(3));
            clearContractCharge(getControl(4));
            clearContractCharge(getControl(5));
        }

        private void clearForm()
        {
            hideGroupBox(false);
            gpbServiceCharge.Visible = false;
            gpbDriverServiceCharge.Visible = false;
            gpbAssignment.Visible = false;
            enableGPBContractInfo(true);
            fpsVehicleContract_Sheet1.RowCount = 0;
            txtContractNoYY.Text = "";
            txtContractNoMM.Text = "";
            txtContractNoXXX.Text = "";
            txtRemark.Text = "";
            clearCombo();
            fpiUnitHire.Value = 1;
            clearContractCharge();
        }

        private void clearCombo()
        {
            //if (cboContractStatus.Items.Count>0)
            //{
            //    cboContractStatus.SelectedIndex = -1;
            //    cboContractStatus.SelectedIndex = -1;
            //    cboContractStatus.Text = "";
            //}	

            //if (cboContractType.Items.Count>0)
            //{
            //    cboContractType.SelectedIndex = -1;
            //    cboContractType.SelectedIndex = -1;
            //    cboContractType.Text = "";
            //}

            //if (cboCustomerDept.Items.Count>0)
            //{
            //    cboCustomerDept.SelectedIndex = -1;
            //    cboCustomerDept.SelectedIndex = -1;
            //    cboCustomerDept.Text = "";
            //}

            if (cboKindOfContract.Items.Count > 0)
            {
                cboKindOfContract.SelectedIndex = -1;
                cboKindOfContract.SelectedIndex = -1;
                cboKindOfContract.Text = "";
            }
        }

        private void bindForm(VehicleContract value)
        {
            fpsVehicleContract_Sheet1.RowCount = value.AVehicleRoleList.Count;

            if (value.AVehicleRoleList != null)
            {
                for (int iRow = 0; iRow < value.AVehicleRoleList.Count; iRow++)
                {
                    bindVehicle(iRow, value.AVehicleRoleList[iRow], value.AVehicleRoleList[iRow].AVehicle);
                }
            }
        }

        private void bindVehicle(int i, VehicleRole aVehicleRole, Vehicle aVehicle)
        {
            fpsVehicleContract_Sheet1.Cells.Get(i, 0).Text = GUIFunction.GetString(aVehicle.EntityKey);
            fpsVehicleContract_Sheet1.Cells.Get(i, 1).Text = GUIFunction.GetString(aVehicle.PlateNumber);
            fpsVehicleContract_Sheet1.Cells.Get(i, 2).Text = GUIFunction.GetString(aVehicle.AModel.ABrand.AName.English);
            fpsVehicleContract_Sheet1.Cells.Get(i, 3).Text = GUIFunction.GetString(aVehicle.AModel.AName.English);
            fpsVehicleContract_Sheet1.Cells.Get(i, 4).Text = GUIFunction.GetString(aVehicleRole.AKindOfVehicle);
        }

        private void updateContract()
        {
            try
            {
                if (checkContractStatus() && checkVehicle(objVehicleContract))
                {
                    DialogResult result = Message(MessageList.Question.Q0009);
                    if (result == DialogResult.Yes)
                    {
                        if (objContractBase.AContractType.Code == ContractType.CONTRACT_TYPE_VEHICLE)
                        {
                            ContractStatus contractStatus = new ContractStatus();
                            contractStatus.Code = "2";

                            objVehicleContract.AContractStatus = contractStatus;

                            if (facadeContractApprove.UpdateContractApprove(objVehicleContract))
                            {
                                InitForm();
                            }
                        }
                        else
                        {
                            ContractStatus contractStatus = new ContractStatus();

                            if (objContractBase.APeriod.To >= DateTime.Today)
                            {
                                contractStatus.Code = "2";
                            }
                            else
                            {
                                contractStatus.Code = "4";
                            }

                            objContractBase.AContractStatus = contractStatus;

                            if (facadeContractApprove.UpdateContract(objContractBase))
                            {
                                InitForm();
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlex)
            { Message(sqlex); }
            catch (AppExceptionBase ex)
            { Message(ex); }
            catch (Exception ex)
            { Message(ex); }
        }

        private void calLeasingPeriod()
        {
            DayMonthYearStructure leasingPeriod = facadeContractApprove.CalAge(dtpContractStart.Value, dtpContractEnd.Value);
            txtLeasingYear.Text = leasingPeriod.Years.ToString();
            txtLeasingMonth.Text = leasingPeriod.Months.ToString();
            txtLeasingDay.Text = leasingPeriod.Days.ToString();
        }

        private void clearLeasingPeriod()
        {
            txtLeasingDay.Text = "0";
            txtLeasingMonth.Text = "0";
            txtLeasingYear.Text = "0";
        }

        #region D21018-BTS Contract Modification
        
        private void ControlPrefix(ContractType contractType)
        {
            if (contractType.Code == ContractType.CONTRACT_TYPE_VEHICLE)
            {
                txtContractPrefix.Text = "C"; //Vehicle
                txtContractPrefix.Visible = false;
                label25.Visible = true;
                cboVehicleKindContract.Text = "C";
                List<string> kindContract = new List<string>() { "C", "R", "T" };
                cboVehicleKindContract.DataSource = kindContract;  
                cboVehicleKindContract.Visible = true;
                this.DocumentType = DOCUMENT_TYPE.CONTRACT;
            }
            else if (contractType.Code == ContractType.CONTRACT_TYPE_DRIVER)
            {
                txtContractPrefix.Text = "D"; //Driver
                txtContractPrefix.Visible = true;
                label25.Visible = true;
                cboVehicleKindContract.Visible = false;
                cboVehicleKindContract.Text = "C";
                this.DocumentType = DOCUMENT_TYPE.CONTRACT_DRIVER;
            }
            else
            {
                txtContractPrefix.Text = "C"; //Other    
                txtContractPrefix.Visible = true;
                label25.Visible = true;
                cboVehicleKindContract.Text = "C";
                cboVehicleKindContract.Visible = false;
                this.DocumentType = DOCUMENT_TYPE.CONTRACT;
            }
        }
        #endregion
        
        //		============================== Base Event ==============================
        public void InitForm()
        {
            clearMainMenuStatus();

            objContractBase = new ContractBase();
            facadeContractApprove = new ContractApproveFacade();
            clearForm();
        }

        public void RefreshForm()
        {
            retriveContract();
        }

        public void PrintForm()
        {
        }

        public void ExitForm()
        {
            //			clearMainMenuStatus();
            Dispose(true);
        }

        //		============================== Event ==============================
        private void frmContractApprove_Load(object sender, System.EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            InitForm();
        }

        private void cboCustomerTHName_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cboCustomerTHName.SelectedIndex != -1)
            {
                Customer customer = (Customer)cboCustomerTHName.SelectedItem;
                cboCustomerDept.DataSource = facadeContractApprove.DataSourceCustomerDept(customer);

                if (cboCustomerDept.Items.Count > 0)
                {
                    cboCustomerDept.SelectedIndex = -1;
                    cboCustomerDept.Text = "";
                }
            }
        }

        private void cmdContractApprove_Click(object sender, System.EventArgs e)
        {
            updateContract();
        }

        private void cmdCancel_Click(object sender, System.EventArgs e)
        {
            ExitForm();
            this.Hide();
        }

        private void txtContractNoYY_TextChanged(object sender, System.EventArgs e)
        {
            if (txtContractNoYY.Text.Length == 2)
            { txtContractNoMM.Focus(); }
        }

        private void txtContractNoMM_TextChanged(object sender, System.EventArgs e)
        {
            if (txtContractNoMM.Text.Length == 2)
            { txtContractNoXXX.Focus(); }
        }

        private void txtContractNoXXX_TextChanged(object sender, System.EventArgs e)
        {
            if (isTextChange)
            {
                if (txtContractNoXXX.Text.Length == 3)
                {
                    if (validateInputContract())
                    { retriveContract(); }
                }
            }
        }

        private void txtContractNoXXX_DoubleClick(object sender, System.EventArgs e)
        {
            formContractList();
        }

        private void txtContractNoXXX_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                if (validateInputContract())
                { retriveContract(); }
            }
        }

        private void frmContractApprove_Closed(object sender, System.EventArgs e)
        {
            ExitForm();
        }

        private void cboKindOfContract_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            KindOfContract kindOfContract;
            if (cboKindOfContract.SelectedIndex != -1)
            {
                kindOfContract = (KindOfContract)cboKindOfContract.SelectedItem;
                if (kindOfContract.Code == "L")
                {
                    rdoMonth.Checked = true;
                }
                else
                {
                    rdoDay.Checked = true;
                }
            }
        }

        private void dtpContractStart_ValueChanged(object sender, System.EventArgs e)
        {
            if (dtpContractStart.Value <= dtpContractEnd.Value)
            {
                calLeasingPeriod();
            }
            else
            {
                clearLeasingPeriod();
            }
        }

        private void dtpContractEnd_ValueChanged(object sender, System.EventArgs e)
        {
            if (dtpContractStart.Value <= dtpContractEnd.Value)
            {
                calLeasingPeriod();
            }
            else
            {
                clearLeasingPeriod();
            }
        }

        private void cboVehicleKindContract_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboContractType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboContractType.SelectedIndex != -1)
            {
                ContractType contractType = (ContractType)cboContractType.SelectedItem;
                ControlPrefix(contractType);
            }
        }
    }
}