using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;
using ictus.Common.Entity.General;
using ictus.Common.Entity.Time;

using Entity.ContractEntities;
using Entity.VehicleEntities;
using Entity.CommonEntity;

using Facade.VehicleFacade;
using Facade.CommonFacade;

using Presentation.ContractGUI;

using SystemFramework.AppException;
using SystemFramework.AppMessage;
using PTB.BTS.BTS2BizPacEntity;

namespace Presentation.VehicleGUI
{
	public class frmVehicleRepairingEntryBase : Presentation.CommonGUI.EntryFormBase
	{
        #region Designer generated code
        private System.Windows.Forms.GroupBox gpbInfo;
        private System.Windows.Forms.TextBox txtDepartmentName;
        private System.Windows.Forms.Label label19;
        protected System.Windows.Forms.TextBox txtEmployeeNo;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker dtpReportDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDocumentNoMM;
        private System.Windows.Forms.TextBox txtDocumentNoYY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDocumentNoXXX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtPlateNo;
        private System.Windows.Forms.Label label25;
        protected System.Windows.Forms.TextBox txtPlatePrefix;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtDriverName;
        protected System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label27;
        protected System.Windows.Forms.TabControl tabVehicleAccident;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button cmdDeletePayment;
        private System.Windows.Forms.Button cmdAddPayment;
        protected FarPoint.Win.Spread.FpSpread fpsPayment;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDetail4;
        private System.Windows.Forms.TextBox txtDetail3;
        private System.Windows.Forms.TextBox txtDetail2;
        private System.Windows.Forms.TextBox txtDetail1;
        private System.Windows.Forms.CheckBox chkClaimnantStatus;
        private System.Windows.Forms.CheckBox chkFrontGlassBrokenStatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.ComboBox cboAccidentPlace;
        private System.Windows.Forms.TextBox txtPoliceName;
        protected System.Windows.Forms.ComboBox cboPoliceStation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpAccidentTime;
        protected System.Windows.Forms.DateTimePicker dtpAccidentDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DateTimePicker dtpPayToInsuranceDate;
        protected System.Windows.Forms.CheckBox chkAccessStatus;
        private System.Windows.Forms.CheckBox chkPayToInsuranceStatus;
        private System.Windows.Forms.CheckBox chkPayToCompanyStatus;
        private System.Windows.Forms.DateTimePicker dtpPayToCompanyDate;
        protected System.Windows.Forms.ComboBox cboPayerType;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox txtContractPrefix;
        private System.Windows.Forms.TextBox txtContractNoXXX;
        private System.Windows.Forms.TextBox txtContractNoMM;
        private System.Windows.Forms.TextBox txtContractNoYY;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button cmdDeleteRepaiList;
        private System.Windows.Forms.Button cmdAddRepairList;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label37;
        protected FarPoint.Win.Spread.SheetView fpsPayment_Sheet1;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdSave;
        protected System.Windows.Forms.TextBox txtDocumentType;
        protected System.Windows.Forms.CheckBox chkPTBDriver;
        protected FarPoint.Win.Input.FpDouble fpdPaid;
        protected System.Windows.Forms.DateTimePicker dtpPaidDate;
        private System.Windows.Forms.Button btnClaculatePaid;
        protected System.Windows.Forms.TabPage tabAccident;
        protected System.Windows.Forms.TabPage tabMaintain;
        private System.Windows.Forms.TextBox txbVehicleType;
        protected System.Windows.Forms.ComboBox cmbGarage;
        private System.Windows.Forms.TextBox txbGarageOfficer;
        private System.Windows.Forms.TextBox txbGarageTel;
        protected System.Windows.Forms.DateTimePicker dtpRepairTo;
        protected System.Windows.Forms.DateTimePicker dtpRepairForm;
        protected FarPoint.Win.Input.FpInteger fpiMileage;
        private System.Windows.Forms.TextBox txbReceiverName;
        private System.Windows.Forms.DateTimePicker dtpTaxDate;
        private FarPoint.Win.Input.FpDouble fpdTotalAmount;
        private FarPoint.Win.Input.FpDouble fpdRepairAmount;
        private FarPoint.Win.Input.FpDouble fpdVat;
        private System.Windows.Forms.CheckBox chkVat;
        private System.Windows.Forms.ContextMenu ctmPayment;
        private System.Windows.Forms.MenuItem mniPaymentAdd;
        private System.Windows.Forms.MenuItem mniPaymentDelete;
        private System.Windows.Forms.ContextMenu ctmRepair;
        private System.Windows.Forms.MenuItem mniRepairAdd;
        private System.Windows.Forms.MenuItem mniRepairDelete;
        private System.Windows.Forms.TextBox txbRemark2;
        private System.Windows.Forms.TextBox txbRemark1;
        private System.Windows.Forms.TextBox txtReportorNo;
        private System.Windows.Forms.TextBox txtReportorName;
        protected System.Windows.Forms.TextBox txbReceiverNo;
        private System.Windows.Forms.GroupBox grbGarage;
        private System.Windows.Forms.Label lblGarage;
        private System.Windows.Forms.ComboBox cboPaymentType;
        private System.Windows.Forms.Label label45;
        private FarPoint.Win.Input.FpInteger fpdDamagePercentage;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private FarPoint.Win.Input.FpDouble fpdExcessPaidAmount;
        private System.Windows.Forms.Label label13;
        private FarPoint.Win.Input.FpDouble fpdExcessRemainAmount;
        protected System.Windows.Forms.CheckBox chkHasRepair;
        private FarPoint.Win.Spread.FpSpread fpsRepairList;
        protected FarPoint.Win.Spread.SheetView fpsRepairList_Sheet1;
        protected System.Windows.Forms.Label lblMileage;
        private System.Windows.Forms.RadioButton rdbRepairReady;
        private System.Windows.Forms.RadioButton rdbRepair;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtTaxNo;
        private System.Windows.Forms.RadioButton rdoTaxStatusNo;
        private System.Windows.Forms.RadioButton rdoTaxStatusYes;
        private System.Windows.Forms.GroupBox gpbTaxStatus;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox txtInsuranceRecieveDate;
        private System.Windows.Forms.TextBox txtConnectionDate;
        private System.Windows.Forms.Label label44;
        protected FarPoint.Win.Input.FpDouble fpdExcessTotalAmount;
        protected FarPoint.Win.Input.FpDouble fpdActualExcessAmount;
        private System.Windows.Forms.CheckBox chkBPManual;
        private System.ComponentModel.IContainer components = null;
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

        private void InitializeComponent()
        {
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType2 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Picture picture1 = new FarPoint.Win.Picture(null, FarPoint.Win.RenderStyle.StretchAndScale, System.Drawing.Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Top);
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmVehicleRepairingEntryBase));
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType3 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType4 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            this.gpbInfo = new System.Windows.Forms.GroupBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtDocumentType = new System.Windows.Forms.TextBox();
            this.txtReportorNo = new System.Windows.Forms.TextBox();
            this.txtDepartmentName = new System.Windows.Forms.TextBox();
            this.txtEmployeeNo = new System.Windows.Forms.TextBox();
            this.txtReportorName = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.dtpReportDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDocumentNoMM = new System.Windows.Forms.TextBox();
            this.txtDocumentNoYY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDocumentNoXXX = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtPlateNo = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtPlatePrefix = new System.Windows.Forms.TextBox();
            this.txtDriverName = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.txbVehicleType = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.txtContractPrefix = new System.Windows.Forms.TextBox();
            this.txtContractNoXXX = new System.Windows.Forms.TextBox();
            this.txtContractNoMM = new System.Windows.Forms.TextBox();
            this.txtContractNoYY = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.fpiMileage = new FarPoint.Win.Input.FpInteger();
            this.lblMileage = new System.Windows.Forms.Label();
            this.chkPTBDriver = new System.Windows.Forms.CheckBox();
            this.tabVehicleAccident = new System.Windows.Forms.TabControl();
            this.tabAccident = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.fpdPaid = new FarPoint.Win.Input.FpDouble();
            this.dtpPaidDate = new System.Windows.Forms.DateTimePicker();
            this.cmdDeletePayment = new System.Windows.Forms.Button();
            this.cmdAddPayment = new System.Windows.Forms.Button();
            this.fpsPayment = new FarPoint.Win.Spread.FpSpread();
            this.ctmPayment = new System.Windows.Forms.ContextMenu();
            this.mniPaymentAdd = new System.Windows.Forms.MenuItem();
            this.mniPaymentDelete = new System.Windows.Forms.MenuItem();
            this.fpsPayment_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnClaculatePaid = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fpdDamagePercentage = new FarPoint.Win.Input.FpInteger();
            this.txtDetail4 = new System.Windows.Forms.TextBox();
            this.txtDetail3 = new System.Windows.Forms.TextBox();
            this.txtDetail2 = new System.Windows.Forms.TextBox();
            this.txtDetail1 = new System.Windows.Forms.TextBox();
            this.chkClaimnantStatus = new System.Windows.Forms.CheckBox();
            this.chkFrontGlassBrokenStatus = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboAccidentPlace = new System.Windows.Forms.ComboBox();
            this.txtPoliceName = new System.Windows.Forms.TextBox();
            this.cboPoliceStation = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpAccidentTime = new System.Windows.Forms.DateTimePicker();
            this.dtpAccidentDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.fpdActualExcessAmount = new FarPoint.Win.Input.FpDouble();
            this.txtConnectionDate = new System.Windows.Forms.TextBox();
            this.txtInsuranceRecieveDate = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.chkHasRepair = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.fpdExcessPaidAmount = new FarPoint.Win.Input.FpDouble();
            this.label13 = new System.Windows.Forms.Label();
            this.fpdExcessRemainAmount = new FarPoint.Win.Input.FpDouble();
            this.dtpPayToInsuranceDate = new System.Windows.Forms.DateTimePicker();
            this.chkPayToInsuranceStatus = new System.Windows.Forms.CheckBox();
            this.chkPayToCompanyStatus = new System.Windows.Forms.CheckBox();
            this.dtpPayToCompanyDate = new System.Windows.Forms.DateTimePicker();
            this.cboPayerType = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.chkAccessStatus = new System.Windows.Forms.CheckBox();
            this.label44 = new System.Windows.Forms.Label();
            this.fpdExcessTotalAmount = new FarPoint.Win.Input.FpDouble();
            this.label10 = new System.Windows.Forms.Label();
            this.tabMaintain = new System.Windows.Forms.TabPage();
            this.label32 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.gpbTaxStatus = new System.Windows.Forms.GroupBox();
            this.rdoTaxStatusNo = new System.Windows.Forms.RadioButton();
            this.rdoTaxStatusYes = new System.Windows.Forms.RadioButton();
            this.label16 = new System.Windows.Forms.Label();
            this.dtpTaxDate = new System.Windows.Forms.DateTimePicker();
            this.txtTaxNo = new System.Windows.Forms.TextBox();
            this.cboPaymentType = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.fpdTotalAmount = new FarPoint.Win.Input.FpDouble();
            this.fpdRepairAmount = new FarPoint.Win.Input.FpDouble();
            this.label31 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.fpdVat = new FarPoint.Win.Input.FpDouble();
            this.chkVat = new System.Windows.Forms.CheckBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cmdDeleteRepaiList = new System.Windows.Forms.Button();
            this.cmdAddRepairList = new System.Windows.Forms.Button();
            this.fpsRepairList = new FarPoint.Win.Spread.FpSpread();
            this.ctmRepair = new System.Windows.Forms.ContextMenu();
            this.mniRepairAdd = new System.Windows.Forms.MenuItem();
            this.mniRepairDelete = new System.Windows.Forms.MenuItem();
            this.fpsRepairList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.txbRemark2 = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.rdbRepair = new System.Windows.Forms.RadioButton();
            this.rdbRepairReady = new System.Windows.Forms.RadioButton();
            this.txbReceiverName = new System.Windows.Forms.TextBox();
            this.dtpRepairTo = new System.Windows.Forms.DateTimePicker();
            this.dtpRepairForm = new System.Windows.Forms.DateTimePicker();
            this.txbReceiverNo = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.grbGarage = new System.Windows.Forms.GroupBox();
            this.txbGarageTel = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txbGarageOfficer = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cmbGarage = new System.Windows.Forms.ComboBox();
            this.lblGarage = new System.Windows.Forms.Label();
            this.txbRemark1 = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.chkBPManual = new System.Windows.Forms.CheckBox();
            this.gpbInfo.SuspendLayout();
            this.tabVehicleAccident.SuspendLayout();
            this.tabAccident.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpsPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsPayment_Sheet1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabMaintain.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.gpbTaxStatus.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpsRepairList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsRepairList_Sheet1)).BeginInit();
            this.groupBox9.SuspendLayout();
            this.grbGarage.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbInfo
            // 
            this.gpbInfo.Controls.Add(this.txtCustomerName);
            this.gpbInfo.Controls.Add(this.txtDocumentType);
            this.gpbInfo.Controls.Add(this.txtReportorNo);
            this.gpbInfo.Controls.Add(this.txtDepartmentName);
            this.gpbInfo.Controls.Add(this.txtEmployeeNo);
            this.gpbInfo.Controls.Add(this.txtReportorName);
            this.gpbInfo.Controls.Add(this.label18);
            this.gpbInfo.Controls.Add(this.dtpReportDate);
            this.gpbInfo.Controls.Add(this.label6);
            this.gpbInfo.Controls.Add(this.txtDocumentNoMM);
            this.gpbInfo.Controls.Add(this.txtDocumentNoYY);
            this.gpbInfo.Controls.Add(this.label2);
            this.gpbInfo.Controls.Add(this.txtDocumentNoXXX);
            this.gpbInfo.Controls.Add(this.label3);
            this.gpbInfo.Controls.Add(this.label1);
            this.gpbInfo.Controls.Add(this.txtBrand);
            this.gpbInfo.Controls.Add(this.label28);
            this.gpbInfo.Controls.Add(this.txtPlateNo);
            this.gpbInfo.Controls.Add(this.label25);
            this.gpbInfo.Controls.Add(this.txtPlatePrefix);
            this.gpbInfo.Controls.Add(this.txtDriverName);
            this.gpbInfo.Controls.Add(this.txtUserName);
            this.gpbInfo.Controls.Add(this.label29);
            this.gpbInfo.Controls.Add(this.label27);
            this.gpbInfo.Controls.Add(this.label26);
            this.gpbInfo.Controls.Add(this.label20);
            this.gpbInfo.Controls.Add(this.label45);
            this.gpbInfo.Controls.Add(this.txbVehicleType);
            this.gpbInfo.Controls.Add(this.label43);
            this.gpbInfo.Controls.Add(this.label40);
            this.gpbInfo.Controls.Add(this.txtContractPrefix);
            this.gpbInfo.Controls.Add(this.txtContractNoXXX);
            this.gpbInfo.Controls.Add(this.txtContractNoMM);
            this.gpbInfo.Controls.Add(this.txtContractNoYY);
            this.gpbInfo.Controls.Add(this.label41);
            this.gpbInfo.Controls.Add(this.label39);
            this.gpbInfo.Controls.Add(this.label19);
            this.gpbInfo.Controls.Add(this.fpiMileage);
            this.gpbInfo.Controls.Add(this.lblMileage);
            this.gpbInfo.Controls.Add(this.chkPTBDriver);
            this.gpbInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
            this.gpbInfo.Location = new System.Drawing.Point(8, 8);
            this.gpbInfo.Name = "gpbInfo";
            this.gpbInfo.Size = new System.Drawing.Size(1000, 120);
            this.gpbInfo.TabIndex = 3;
            this.gpbInfo.TabStop = false;
            this.gpbInfo.Text = "ข้อมูลทั่วไป";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Enabled = false;
            this.txtCustomerName.Location = new System.Drawing.Point(72, 64);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(256, 20);
            this.txtCustomerName.TabIndex = 16;
            this.txtCustomerName.TabStop = false;
            this.txtCustomerName.Text = "";
            // 
            // txtDocumentType
            // 
            this.txtDocumentType.Enabled = false;
            this.txtDocumentType.Location = new System.Drawing.Point(120, 16);
            this.txtDocumentType.Name = "txtDocumentType";
            this.txtDocumentType.Size = new System.Drawing.Size(24, 20);
            this.txtDocumentType.TabIndex = 1;
            this.txtDocumentType.TabStop = false;
            this.txtDocumentType.Text = "";
            // 
            // txtReportorNo
            // 
            this.txtReportorNo.Location = new System.Drawing.Point(736, 40);
            this.txtReportorNo.MaxLength = 5;
            this.txtReportorNo.Name = "txtReportorNo";
            this.txtReportorNo.Size = new System.Drawing.Size(64, 20);
            this.txtReportorNo.TabIndex = 14;
            this.txtReportorNo.Text = "";
            this.txtReportorNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReportorNo_KeyDown);
            this.txtReportorNo.TextChanged += new System.EventHandler(this.txtReportorNo_TextChanged);
            this.txtReportorNo.DoubleClick += new System.EventHandler(this.txtReportorNo_DoubleClick);
            // 
            // txtDepartmentName
            // 
            this.txtDepartmentName.Enabled = false;
            this.txtDepartmentName.Location = new System.Drawing.Point(416, 64);
            this.txtDepartmentName.Name = "txtDepartmentName";
            this.txtDepartmentName.Size = new System.Drawing.Size(184, 20);
            this.txtDepartmentName.TabIndex = 17;
            this.txtDepartmentName.TabStop = false;
            this.txtDepartmentName.Text = "";
            // 
            // txtEmployeeNo
            // 
            this.txtEmployeeNo.Enabled = false;
            this.txtEmployeeNo.Location = new System.Drawing.Point(256, 88);
            this.txtEmployeeNo.MaxLength = 5;
            this.txtEmployeeNo.Name = "txtEmployeeNo";
            this.txtEmployeeNo.Size = new System.Drawing.Size(56, 20);
            this.txtEmployeeNo.TabIndex = 20;
            this.txtEmployeeNo.Text = "";
            this.txtEmployeeNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmployeeNo_KeyDown);
            this.txtEmployeeNo.TextChanged += new System.EventHandler(this.txtEmployeeNo_TextChanged);
            this.txtEmployeeNo.DoubleClick += new System.EventHandler(this.txtEmployeeNo_DoubleClick);
            // 
            // txtReportorName
            // 
            this.txtReportorName.Location = new System.Drawing.Point(800, 40);
            this.txtReportorName.MaxLength = 100;
            this.txtReportorName.Name = "txtReportorName";
            this.txtReportorName.ReadOnly = true;
            this.txtReportorName.Size = new System.Drawing.Size(192, 20);
            this.txtReportorName.TabIndex = 15;
            this.txtReportorName.TabStop = false;
            this.txtReportorName.Text = "";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(608, 40);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(120, 16);
            this.label18.TabIndex = 9;
            this.label18.Text = "ผู้เขียนรายงาน/ผู้ส่งรถซ่อม";
            // 
            // dtpReportDate
            // 
            this.dtpReportDate.CustomFormat = "dd/MM/yyyy";
            this.dtpReportDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReportDate.Location = new System.Drawing.Point(816, 16);
            this.dtpReportDate.Name = "dtpReportDate";
            this.dtpReportDate.Size = new System.Drawing.Size(96, 20);
            this.dtpReportDate.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(728, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "วันที่เขียนรายงาน";
            // 
            // txtDocumentNoMM
            // 
            this.txtDocumentNoMM.Enabled = false;
            this.txtDocumentNoMM.Location = new System.Drawing.Point(184, 16);
            this.txtDocumentNoMM.Name = "txtDocumentNoMM";
            this.txtDocumentNoMM.Size = new System.Drawing.Size(24, 20);
            this.txtDocumentNoMM.TabIndex = 3;
            this.txtDocumentNoMM.TabStop = false;
            this.txtDocumentNoMM.Text = "";
            // 
            // txtDocumentNoYY
            // 
            this.txtDocumentNoYY.Enabled = false;
            this.txtDocumentNoYY.Location = new System.Drawing.Point(152, 16);
            this.txtDocumentNoYY.Name = "txtDocumentNoYY";
            this.txtDocumentNoYY.Size = new System.Drawing.Size(24, 20);
            this.txtDocumentNoYY.TabIndex = 2;
            this.txtDocumentNoYY.TabStop = false;
            this.txtDocumentNoYY.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
            this.label2.Location = new System.Drawing.Point(80, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "PTB - ";
            // 
            // txtDocumentNoXXX
            // 
            this.txtDocumentNoXXX.Enabled = false;
            this.txtDocumentNoXXX.Location = new System.Drawing.Point(216, 16);
            this.txtDocumentNoXXX.Name = "txtDocumentNoXXX";
            this.txtDocumentNoXXX.Size = new System.Drawing.Size(32, 20);
            this.txtDocumentNoXXX.TabIndex = 4;
            this.txtDocumentNoXXX.TabStop = false;
            this.txtDocumentNoXXX.Text = "";
            // 
            // label3
            // 
            this.label3.Enabled = false;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
            this.label3.Location = new System.Drawing.Point(144, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(8, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "เลขที่เอกสาร";
            // 
            // txtBrand
            // 
            this.txtBrand.Enabled = false;
            this.txtBrand.Location = new System.Drawing.Point(488, 16);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(216, 20);
            this.txtBrand.TabIndex = 7;
            this.txtBrand.TabStop = false;
            this.txtBrand.Text = "";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(448, 18);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(35, 16);
            this.label28.TabIndex = 29;
            this.label28.Text = "ยี่ห้อรถ";
            // 
            // txtPlateNo
            // 
            this.txtPlateNo.Enabled = false;
            this.txtPlateNo.Location = new System.Drawing.Point(368, 16);
            this.txtPlateNo.Name = "txtPlateNo";
            this.txtPlateNo.Size = new System.Drawing.Size(56, 20);
            this.txtPlateNo.TabIndex = 6;
            this.txtPlateNo.TabStop = false;
            this.txtPlateNo.Text = "";
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
            this.label25.Location = new System.Drawing.Point(360, 16);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(8, 23);
            this.label25.TabIndex = 27;
            this.label25.Text = "-";
            // 
            // txtPlatePrefix
            // 
            this.txtPlatePrefix.Enabled = false;
            this.txtPlatePrefix.Location = new System.Drawing.Point(328, 16);
            this.txtPlatePrefix.Name = "txtPlatePrefix";
            this.txtPlatePrefix.Size = new System.Drawing.Size(32, 20);
            this.txtPlatePrefix.TabIndex = 5;
            this.txtPlatePrefix.TabStop = false;
            this.txtPlatePrefix.Text = "";
            // 
            // txtDriverName
            // 
            this.txtDriverName.Location = new System.Drawing.Point(416, 88);
            this.txtDriverName.MaxLength = 100;
            this.txtDriverName.Name = "txtDriverName";
            this.txtDriverName.Size = new System.Drawing.Size(248, 20);
            this.txtDriverName.TabIndex = 21;
            this.txtDriverName.Text = "";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(736, 64);
            this.txtUserName.MaxLength = 60;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(256, 20);
            this.txtUserName.TabIndex = 18;
            this.txtUserName.Text = "";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(672, 64);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(47, 16);
            this.label29.TabIndex = 33;
            this.label29.Text = "ชื่อผู้ใช้รถ";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(8, 64);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(40, 16);
            this.label27.TabIndex = 31;
            this.label27.Text = "ชื่อลูกค้า";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(272, 18);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(51, 16);
            this.label26.TabIndex = 25;
            this.label26.Text = "ทะเบียนรถ";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(328, 90);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(81, 16);
            this.label20.TabIndex = 38;
            this.label20.Text = "ชื่อพนักงานขับรถ";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(384, 64);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(22, 16);
            this.label45.TabIndex = 48;
            this.label45.Text = "ฝ่าย";
            // 
            // txbVehicleType
            // 
            this.txbVehicleType.Enabled = false;
            this.txbVehicleType.Location = new System.Drawing.Point(72, 40);
            this.txbVehicleType.Name = "txbVehicleType";
            this.txbVehicleType.Size = new System.Drawing.Size(256, 20);
            this.txbVehicleType.TabIndex = 9;
            this.txbVehicleType.Text = "";
            // 
            // label43
            // 
            this.label43.Location = new System.Drawing.Point(8, 40);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(64, 23);
            this.label43.TabIndex = 17;
            this.label43.Text = "ประเภทรถ";
            // 
            // label40
            // 
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
            this.label40.Location = new System.Drawing.Point(480, 40);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(8, 23);
            this.label40.TabIndex = 54;
            this.label40.Text = "-";
            // 
            // txtContractPrefix
            // 
            this.txtContractPrefix.Enabled = false;
            this.txtContractPrefix.Location = new System.Drawing.Point(456, 40);
            this.txtContractPrefix.Name = "txtContractPrefix";
            this.txtContractPrefix.Size = new System.Drawing.Size(24, 20);
            this.txtContractPrefix.TabIndex = 10;
            this.txtContractPrefix.Text = "C";
            // 
            // txtContractNoXXX
            // 
            this.txtContractNoXXX.Enabled = false;
            this.txtContractNoXXX.Location = new System.Drawing.Point(552, 40);
            this.txtContractNoXXX.MaxLength = 3;
            this.txtContractNoXXX.Name = "txtContractNoXXX";
            this.txtContractNoXXX.Size = new System.Drawing.Size(32, 20);
            this.txtContractNoXXX.TabIndex = 13;
            this.txtContractNoXXX.Text = "";
            // 
            // txtContractNoMM
            // 
            this.txtContractNoMM.Enabled = false;
            this.txtContractNoMM.Location = new System.Drawing.Point(520, 40);
            this.txtContractNoMM.MaxLength = 2;
            this.txtContractNoMM.Name = "txtContractNoMM";
            this.txtContractNoMM.Size = new System.Drawing.Size(32, 20);
            this.txtContractNoMM.TabIndex = 12;
            this.txtContractNoMM.Text = "";
            // 
            // txtContractNoYY
            // 
            this.txtContractNoYY.Enabled = false;
            this.txtContractNoYY.Location = new System.Drawing.Point(488, 40);
            this.txtContractNoYY.MaxLength = 2;
            this.txtContractNoYY.Name = "txtContractNoYY";
            this.txtContractNoYY.Size = new System.Drawing.Size(32, 20);
            this.txtContractNoYY.TabIndex = 11;
            this.txtContractNoYY.Text = "";
            // 
            // label41
            // 
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
            this.label41.Location = new System.Drawing.Point(416, 40);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(40, 23);
            this.label41.TabIndex = 52;
            this.label41.Text = "PTB -";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(352, 40);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(54, 16);
            this.label39.TabIndex = 48;
            this.label39.Text = "เลขที่สัญญา";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(184, 90);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(61, 16);
            this.label19.TabIndex = 40;
            this.label19.Text = "รหัสพนักงาน";
            // 
            // fpiMileage
            // 
            this.fpiMileage.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiMileage.AllowClipboardKeys = true;
            this.fpiMileage.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiMileage.Location = new System.Drawing.Point(736, 88);
            this.fpiMileage.MinValue = 0;
            this.fpiMileage.Name = "fpiMileage";
            this.fpiMileage.Size = new System.Drawing.Size(120, 20);
            this.fpiMileage.TabIndex = 22;
            this.fpiMileage.Text = "";
            this.fpiMileage.UseSeparator = true;
            // 
            // lblMileage
            // 
            this.lblMileage.Location = new System.Drawing.Point(688, 87);
            this.lblMileage.Name = "lblMileage";
            this.lblMileage.Size = new System.Drawing.Size(48, 23);
            this.lblMileage.TabIndex = 13;
            this.lblMileage.Text = "เลขไมล์";
            // 
            // chkPTBDriver
            // 
            this.chkPTBDriver.Location = new System.Drawing.Point(8, 82);
            this.chkPTBDriver.Name = "chkPTBDriver";
            this.chkPTBDriver.Size = new System.Drawing.Size(136, 32);
            this.chkPTBDriver.TabIndex = 19;
            this.chkPTBDriver.Text = "พนักงานขับรถ PTB";
            this.chkPTBDriver.CheckedChanged += new System.EventHandler(this.chkPTBDriver_CheckedChanged);
            // 
            // tabVehicleAccident
            // 
            this.tabVehicleAccident.Controls.Add(this.tabAccident);
            this.tabVehicleAccident.Controls.Add(this.tabMaintain);
            this.tabVehicleAccident.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
            this.tabVehicleAccident.Location = new System.Drawing.Point(8, 136);
            this.tabVehicleAccident.Name = "tabVehicleAccident";
            this.tabVehicleAccident.SelectedIndex = 0;
            this.tabVehicleAccident.Size = new System.Drawing.Size(1016, 456);
            this.tabVehicleAccident.TabIndex = 6;
            this.tabVehicleAccident.SelectedIndexChanged += new System.EventHandler(this.tabVehicleAccident_SelectedIndexChanged);
            // 
            // tabAccident
            // 
            this.tabAccident.Controls.Add(this.groupBox7);
            this.tabAccident.Controls.Add(this.groupBox2);
            this.tabAccident.Controls.Add(this.groupBox1);
            this.tabAccident.Controls.Add(this.groupBox6);
            this.tabAccident.Location = new System.Drawing.Point(4, 25);
            this.tabAccident.Name = "tabAccident";
            this.tabAccident.Size = new System.Drawing.Size(1008, 427);
            this.tabAccident.TabIndex = 0;
            this.tabAccident.Text = "ข้อมูลอุบัติเหตุ";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.fpdPaid);
            this.groupBox7.Controls.Add(this.dtpPaidDate);
            this.groupBox7.Controls.Add(this.cmdDeletePayment);
            this.groupBox7.Controls.Add(this.cmdAddPayment);
            this.groupBox7.Controls.Add(this.fpsPayment);
            this.groupBox7.Controls.Add(this.label17);
            this.groupBox7.Controls.Add(this.label15);
            this.groupBox7.Controls.Add(this.btnClaculatePaid);
            this.groupBox7.Location = new System.Drawing.Point(620, 96);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(376, 320);
            this.groupBox7.TabIndex = 43;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "ค่าชำระรายเดือน";
            // 
            // fpdPaid
            // 
            this.fpdPaid.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdPaid.AllowClipboardKeys = true;
            this.fpdPaid.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdPaid.DecimalPlaces = 2;
            this.fpdPaid.DecimalSeparator = ".";
            this.fpdPaid.FixedPoint = true;
            this.fpdPaid.Location = new System.Drawing.Point(96, 24);
            this.fpdPaid.Name = "fpdPaid";
            this.fpdPaid.Size = new System.Drawing.Size(80, 22);
            this.fpdPaid.TabIndex = 45;
            this.fpdPaid.Text = "";
            this.fpdPaid.UseSeparator = true;
            // 
            // dtpPaidDate
            // 
            this.dtpPaidDate.CustomFormat = "MM/yyyy";
            this.dtpPaidDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPaidDate.Location = new System.Drawing.Point(288, 24);
            this.dtpPaidDate.Name = "dtpPaidDate";
            this.dtpPaidDate.Size = new System.Drawing.Size(80, 23);
            this.dtpPaidDate.TabIndex = 46;
            // 
            // cmdDeletePayment
            // 
            this.cmdDeletePayment.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdDeletePayment.Enabled = false;
            this.cmdDeletePayment.Location = new System.Drawing.Point(192, 280);
            this.cmdDeletePayment.Name = "cmdDeletePayment";
            this.cmdDeletePayment.TabIndex = 49;
            this.cmdDeletePayment.Text = "ลบ";
            this.cmdDeletePayment.Click += new System.EventHandler(this.cmdDeletePayment_Click);
            // 
            // cmdAddPayment
            // 
            this.cmdAddPayment.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdAddPayment.Location = new System.Drawing.Point(112, 280);
            this.cmdAddPayment.Name = "cmdAddPayment";
            this.cmdAddPayment.TabIndex = 48;
            this.cmdAddPayment.Text = "เพิ่ม";
            this.cmdAddPayment.Click += new System.EventHandler(this.cmdAddPayment_Click);
            // 
            // fpsPayment
            // 
            this.fpsPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.fpsPayment.ContextMenu = this.ctmPayment;
            this.fpsPayment.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.fpsPayment.Location = new System.Drawing.Point(24, 94);
            this.fpsPayment.Name = "fpsPayment";
            this.fpsPayment.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																					this.fpsPayment_Sheet1});
            this.fpsPayment.Size = new System.Drawing.Size(336, 174);
            this.fpsPayment.TabIndex = 44;
            this.fpsPayment.TabStop = false;
            this.fpsPayment.Change += new FarPoint.Win.Spread.ChangeEventHandler(this.fpsPayment_Change);
            this.fpsPayment.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.fpsPayment_EditChange);
            // 
            // ctmPayment
            // 
            this.ctmPayment.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.mniPaymentAdd,
																					   this.mniPaymentDelete});
            // 
            // mniPaymentAdd
            // 
            this.mniPaymentAdd.Index = 0;
            this.mniPaymentAdd.Text = "เพิ่ม";
            this.mniPaymentAdd.Click += new System.EventHandler(this.mniPaymentAdd_Click);
            // 
            // mniPaymentDelete
            // 
            this.mniPaymentDelete.Enabled = false;
            this.mniPaymentDelete.Index = 1;
            this.mniPaymentDelete.Text = "ลบ";
            this.mniPaymentDelete.Click += new System.EventHandler(this.mniPaymentDelete_Click);
            // 
            // fpsPayment_Sheet1
            // 
            this.fpsPayment_Sheet1.Reset();
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpsPayment_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpsPayment_Sheet1.ColumnCount = 5;
            this.fpsPayment_Sheet1.RowCount = 0;
            this.fpsPayment_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "ปี";
            this.fpsPayment_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "เดือน";
            this.fpsPayment_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "จำนวนเงิน";
            this.fpsPayment_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "จ่ายแล้ว";
            textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType1.DropDownButton = false;
            this.fpsPayment_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.fpsPayment_Sheet1.Columns.Get(0).Visible = false;
            this.fpsPayment_Sheet1.Columns.Get(1).AllowAutoSort = true;
            this.fpsPayment_Sheet1.Columns.Get(1).CellType = comboBoxCellType1;
            this.fpsPayment_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsPayment_Sheet1.Columns.Get(1).Label = "ปี";
            this.fpsPayment_Sheet1.Columns.Get(1).Resizable = false;
            this.fpsPayment_Sheet1.Columns.Get(1).Width = 70F;
            this.fpsPayment_Sheet1.Columns.Get(2).AllowAutoSort = true;
            this.fpsPayment_Sheet1.Columns.Get(2).CellType = comboBoxCellType2;
            this.fpsPayment_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsPayment_Sheet1.Columns.Get(2).Label = "เดือน";
            this.fpsPayment_Sheet1.Columns.Get(2).Resizable = false;
            this.fpsPayment_Sheet1.Columns.Get(3).AllowAutoSort = true;
            numberCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            numberCellType1.DecimalPlaces = 2;
            numberCellType1.DecimalSeparator = ".";
            numberCellType1.DropDownButton = false;
            numberCellType1.Separator = ",";
            numberCellType1.ShowSeparator = true;
            this.fpsPayment_Sheet1.Columns.Get(3).CellType = numberCellType1;
            this.fpsPayment_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.fpsPayment_Sheet1.Columns.Get(3).Label = "จำนวนเงิน";
            this.fpsPayment_Sheet1.Columns.Get(3).Resizable = false;
            this.fpsPayment_Sheet1.Columns.Get(3).Width = 90F;
            this.fpsPayment_Sheet1.Columns.Get(4).AllowAutoSort = true;
            picture1.AlignHorz = FarPoint.Win.HorizontalAlignment.Center;
            picture1.Style = FarPoint.Win.RenderStyle.StretchAndScale;
            picture1.TransparencyColor = System.Drawing.Color.Empty;
            picture1.TransparencyTolerance = 0;
            checkBoxCellType1.BackgroundImage = picture1;
            this.fpsPayment_Sheet1.Columns.Get(4).CellType = checkBoxCellType1;
            this.fpsPayment_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsPayment_Sheet1.Columns.Get(4).Label = "จ่ายแล้ว";
            this.fpsPayment_Sheet1.Columns.Get(4).Locked = true;
            this.fpsPayment_Sheet1.Columns.Get(4).Resizable = false;
            this.fpsPayment_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpsPayment_Sheet1.SheetName = "Sheet1";
            this.fpsPayment_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(32, 24);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(61, 19);
            this.label17.TabIndex = 43;
            this.label17.Text = "หักเดือนละ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(192, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(91, 19);
            this.label15.TabIndex = 45;
            this.label15.Text = "เดือนที่เริ่มต้นหัก";
            // 
            // btnClaculatePaid
            // 
            this.btnClaculatePaid.Location = new System.Drawing.Point(118, 56);
            this.btnClaculatePaid.Name = "btnClaculatePaid";
            this.btnClaculatePaid.Size = new System.Drawing.Size(140, 23);
            this.btnClaculatePaid.TabIndex = 47;
            this.btnClaculatePaid.Text = "คำนวณค่าชำระรายเดือน";
            this.btnClaculatePaid.Click += new System.EventHandler(this.btnClaculatePaid_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.fpdDamagePercentage);
            this.groupBox2.Controls.Add(this.txtDetail4);
            this.groupBox2.Controls.Add(this.txtDetail3);
            this.groupBox2.Controls.Add(this.txtDetail2);
            this.groupBox2.Controls.Add(this.txtDetail1);
            this.groupBox2.Controls.Add(this.chkClaimnantStatus);
            this.groupBox2.Controls.Add(this.chkFrontGlassBrokenStatus);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(12, 96);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(592, 160);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "รายงานอุบัติเหตุโดยย่อจากผู้ขับรถ";
            // 
            // fpdDamagePercentage
            // 
            this.fpdDamagePercentage.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdDamagePercentage.AllowClipboardKeys = true;
            this.fpdDamagePercentage.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdDamagePercentage.Location = new System.Drawing.Point(88, 128);
            this.fpdDamagePercentage.MaxValue = 100;
            this.fpdDamagePercentage.MinValue = 0;
            this.fpdDamagePercentage.Name = "fpdDamagePercentage";
            this.fpdDamagePercentage.Size = new System.Drawing.Size(40, 22);
            this.fpdDamagePercentage.TabIndex = 32;
            this.fpdDamagePercentage.Text = "";
            // 
            // txtDetail4
            // 
            this.txtDetail4.Location = new System.Drawing.Point(16, 96);
            this.txtDetail4.MaxLength = 100;
            this.txtDetail4.Name = "txtDetail4";
            this.txtDetail4.Size = new System.Drawing.Size(552, 23);
            this.txtDetail4.TabIndex = 31;
            this.txtDetail4.Text = "";
            // 
            // txtDetail3
            // 
            this.txtDetail3.Location = new System.Drawing.Point(16, 72);
            this.txtDetail3.MaxLength = 100;
            this.txtDetail3.Name = "txtDetail3";
            this.txtDetail3.Size = new System.Drawing.Size(552, 23);
            this.txtDetail3.TabIndex = 30;
            this.txtDetail3.Text = "";
            // 
            // txtDetail2
            // 
            this.txtDetail2.Location = new System.Drawing.Point(16, 48);
            this.txtDetail2.MaxLength = 100;
            this.txtDetail2.Name = "txtDetail2";
            this.txtDetail2.Size = new System.Drawing.Size(552, 23);
            this.txtDetail2.TabIndex = 29;
            this.txtDetail2.Text = "";
            // 
            // txtDetail1
            // 
            this.txtDetail1.Location = new System.Drawing.Point(16, 24);
            this.txtDetail1.MaxLength = 100;
            this.txtDetail1.Name = "txtDetail1";
            this.txtDetail1.Size = new System.Drawing.Size(552, 23);
            this.txtDetail1.TabIndex = 28;
            this.txtDetail1.Text = "";
            // 
            // chkClaimnantStatus
            // 
            this.chkClaimnantStatus.Location = new System.Drawing.Point(176, 128);
            this.chkClaimnantStatus.Name = "chkClaimnantStatus";
            this.chkClaimnantStatus.Size = new System.Drawing.Size(88, 24);
            this.chkClaimnantStatus.TabIndex = 33;
            this.chkClaimnantStatus.Text = "ชนมีคู่กรณี";
            // 
            // chkFrontGlassBrokenStatus
            // 
            this.chkFrontGlassBrokenStatus.Location = new System.Drawing.Point(272, 128);
            this.chkFrontGlassBrokenStatus.Name = "chkFrontGlassBrokenStatus";
            this.chkFrontGlassBrokenStatus.TabIndex = 34;
            this.chkFrontGlassBrokenStatus.Text = "กระจกหน้าแตก";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(136, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 23);
            this.label9.TabIndex = 36;
            this.label9.Text = "%";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 131);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 19);
            this.label12.TabIndex = 34;
            this.label12.Text = "ความเสียหาย";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboAccidentPlace);
            this.groupBox1.Controls.Add(this.txtPoliceName);
            this.groupBox1.Controls.Add(this.cboPoliceStation);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpAccidentTime);
            this.groupBox1.Controls.Add(this.dtpAccidentDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(16, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(976, 88);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ข้อมูลการเกิดอุบัติเหตุ";
            // 
            // cboAccidentPlace
            // 
            this.cboAccidentPlace.Location = new System.Drawing.Point(96, 56);
            this.cboAccidentPlace.MaxLength = 60;
            this.cboAccidentPlace.Name = "cboAccidentPlace";
            this.cboAccidentPlace.Size = new System.Drawing.Size(472, 24);
            this.cboAccidentPlace.TabIndex = 26;
            this.cboAccidentPlace.TextChanged += new System.EventHandler(this.cboAccidentPlace_TextChanged);
            // 
            // txtPoliceName
            // 
            this.txtPoliceName.Location = new System.Drawing.Point(672, 56);
            this.txtPoliceName.MaxLength = 60;
            this.txtPoliceName.Name = "txtPoliceName";
            this.txtPoliceName.Size = new System.Drawing.Size(256, 23);
            this.txtPoliceName.TabIndex = 27;
            this.txtPoliceName.Text = "";
            // 
            // cboPoliceStation
            // 
            this.cboPoliceStation.Location = new System.Drawing.Point(672, 24);
            this.cboPoliceStation.MaxLength = 50;
            this.cboPoliceStation.Name = "cboPoliceStation";
            this.cboPoliceStation.Size = new System.Drawing.Size(256, 24);
            this.cboPoliceStation.TabIndex = 25;
            this.cboPoliceStation.TextChanged += new System.EventHandler(this.cboPoliceStation_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(608, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 19);
            this.label8.TabIndex = 15;
            this.label8.Text = "สถานีตำรวจ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(608, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 19);
            this.label7.TabIndex = 14;
            this.label7.Text = "ชื่อร้อยเวร";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "สถานที่เกิดเหตุ";
            // 
            // dtpAccidentTime
            // 
            this.dtpAccidentTime.CustomFormat = "HH:mm";
            this.dtpAccidentTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAccidentTime.Location = new System.Drawing.Point(192, 24);
            this.dtpAccidentTime.Name = "dtpAccidentTime";
            this.dtpAccidentTime.ShowUpDown = true;
            this.dtpAccidentTime.Size = new System.Drawing.Size(64, 23);
            this.dtpAccidentTime.TabIndex = 24;
            // 
            // dtpAccidentDate
            // 
            this.dtpAccidentDate.CustomFormat = "dd/MM/yyyy";
            this.dtpAccidentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAccidentDate.Location = new System.Drawing.Point(96, 24);
            this.dtpAccidentDate.Name = "dtpAccidentDate";
            this.dtpAccidentDate.Size = new System.Drawing.Size(96, 23);
            this.dtpAccidentDate.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "วัน/เวลาที่เกิดเหตุ";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.fpdActualExcessAmount);
            this.groupBox6.Controls.Add(this.txtConnectionDate);
            this.groupBox6.Controls.Add(this.txtInsuranceRecieveDate);
            this.groupBox6.Controls.Add(this.label42);
            this.groupBox6.Controls.Add(this.label38);
            this.groupBox6.Controls.Add(this.chkHasRepair);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.fpdExcessPaidAmount);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.fpdExcessRemainAmount);
            this.groupBox6.Controls.Add(this.dtpPayToInsuranceDate);
            this.groupBox6.Controls.Add(this.chkPayToInsuranceStatus);
            this.groupBox6.Controls.Add(this.chkPayToCompanyStatus);
            this.groupBox6.Controls.Add(this.dtpPayToCompanyDate);
            this.groupBox6.Controls.Add(this.cboPayerType);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.chkAccessStatus);
            this.groupBox6.Controls.Add(this.label44);
            this.groupBox6.Controls.Add(this.fpdExcessTotalAmount);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Location = new System.Drawing.Point(12, 256);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(592, 160);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "ค่า Excess";
            // 
            // fpdActualExcessAmount
            // 
            this.fpdActualExcessAmount.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdActualExcessAmount.AllowClipboardKeys = true;
            this.fpdActualExcessAmount.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdActualExcessAmount.DecimalPlaces = 2;
            this.fpdActualExcessAmount.DecimalSeparator = ".";
            this.fpdActualExcessAmount.Enabled = false;
            this.fpdActualExcessAmount.FixedPoint = true;
            this.fpdActualExcessAmount.Location = new System.Drawing.Point(208, 120);
            this.fpdActualExcessAmount.Name = "fpdActualExcessAmount";
            this.fpdActualExcessAmount.Size = new System.Drawing.Size(100, 22);
            this.fpdActualExcessAmount.TabIndex = 51;
            this.fpdActualExcessAmount.Text = "";
            this.fpdActualExcessAmount.UseSeparator = true;
            // 
            // txtConnectionDate
            // 
            this.txtConnectionDate.Enabled = false;
            this.txtConnectionDate.Location = new System.Drawing.Point(208, 88);
            this.txtConnectionDate.Name = "txtConnectionDate";
            this.txtConnectionDate.TabIndex = 57;
            this.txtConnectionDate.Text = "";
            // 
            // txtInsuranceRecieveDate
            // 
            this.txtInsuranceRecieveDate.Enabled = false;
            this.txtInsuranceRecieveDate.Location = new System.Drawing.Point(208, 56);
            this.txtInsuranceRecieveDate.Name = "txtInsuranceRecieveDate";
            this.txtInsuranceRecieveDate.TabIndex = 56;
            this.txtInsuranceRecieveDate.Text = "";
            this.txtInsuranceRecieveDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(16, 88);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(180, 19);
            this.label42.TabIndex = 53;
            this.label42.Text = "วันที่การโอนย้ายข้อมูลค่า Excess";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(16, 56);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(121, 19);
            this.label38.TabIndex = 52;
            this.label38.Text = "วันที่บันทึกค่า Excess";
            // 
            // chkHasRepair
            // 
            this.chkHasRepair.Location = new System.Drawing.Point(400, 24);
            this.chkHasRepair.Name = "chkHasRepair";
            this.chkHasRepair.Size = new System.Drawing.Size(80, 24);
            this.chkHasRepair.TabIndex = 51;
            this.chkHasRepair.Text = "มีการซ่อม";
            this.chkHasRepair.CheckedChanged += new System.EventHandler(this.chkHasRepair_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(432, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 19);
            this.label11.TabIndex = 46;
            this.label11.Text = "จ่ายแล้ว";
            // 
            // fpdExcessPaidAmount
            // 
            this.fpdExcessPaidAmount.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdExcessPaidAmount.AllowClipboardKeys = true;
            this.fpdExcessPaidAmount.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdExcessPaidAmount.DecimalPlaces = 2;
            this.fpdExcessPaidAmount.DecimalSeparator = ".";
            this.fpdExcessPaidAmount.Enabled = false;
            this.fpdExcessPaidAmount.FixedPoint = true;
            this.fpdExcessPaidAmount.Location = new System.Drawing.Point(480, 104);
            this.fpdExcessPaidAmount.Name = "fpdExcessPaidAmount";
            this.fpdExcessPaidAmount.Size = new System.Drawing.Size(96, 22);
            this.fpdExcessPaidAmount.TabIndex = 49;
            this.fpdExcessPaidAmount.Text = "";
            this.fpdExcessPaidAmount.UseSeparator = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(432, 128);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 19);
            this.label13.TabIndex = 47;
            this.label13.Text = "คงเหลือ";
            // 
            // fpdExcessRemainAmount
            // 
            this.fpdExcessRemainAmount.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdExcessRemainAmount.AllowClipboardKeys = true;
            this.fpdExcessRemainAmount.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdExcessRemainAmount.DecimalPlaces = 2;
            this.fpdExcessRemainAmount.DecimalSeparator = ".";
            this.fpdExcessRemainAmount.Enabled = false;
            this.fpdExcessRemainAmount.FixedPoint = true;
            this.fpdExcessRemainAmount.Location = new System.Drawing.Point(480, 128);
            this.fpdExcessRemainAmount.Name = "fpdExcessRemainAmount";
            this.fpdExcessRemainAmount.Size = new System.Drawing.Size(96, 22);
            this.fpdExcessRemainAmount.TabIndex = 50;
            this.fpdExcessRemainAmount.Text = "";
            this.fpdExcessRemainAmount.UseSeparator = true;
            // 
            // dtpPayToInsuranceDate
            // 
            this.dtpPayToInsuranceDate.Checked = false;
            this.dtpPayToInsuranceDate.CustomFormat = "dd/MM/yyyy";
            this.dtpPayToInsuranceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPayToInsuranceDate.Location = new System.Drawing.Point(280, 128);
            this.dtpPayToInsuranceDate.Name = "dtpPayToInsuranceDate";
            this.dtpPayToInsuranceDate.Size = new System.Drawing.Size(96, 23);
            this.dtpPayToInsuranceDate.TabIndex = 39;
            this.dtpPayToInsuranceDate.Visible = false;
            // 
            // chkPayToInsuranceStatus
            // 
            this.chkPayToInsuranceStatus.Location = new System.Drawing.Point(256, 128);
            this.chkPayToInsuranceStatus.Name = "chkPayToInsuranceStatus";
            this.chkPayToInsuranceStatus.Size = new System.Drawing.Size(16, 24);
            this.chkPayToInsuranceStatus.TabIndex = 38;
            this.chkPayToInsuranceStatus.Visible = false;
            this.chkPayToInsuranceStatus.CheckedChanged += new System.EventHandler(this.chkPayToInsuranceStatus_CheckedChanged);
            // 
            // chkPayToCompanyStatus
            // 
            this.chkPayToCompanyStatus.Location = new System.Drawing.Point(256, 112);
            this.chkPayToCompanyStatus.Name = "chkPayToCompanyStatus";
            this.chkPayToCompanyStatus.Size = new System.Drawing.Size(16, 24);
            this.chkPayToCompanyStatus.TabIndex = 36;
            this.chkPayToCompanyStatus.Visible = false;
            this.chkPayToCompanyStatus.CheckedChanged += new System.EventHandler(this.chkPayToCompanyStatus_CheckedChanged);
            // 
            // dtpPayToCompanyDate
            // 
            this.dtpPayToCompanyDate.Checked = false;
            this.dtpPayToCompanyDate.CustomFormat = "dd/MM/yyyy";
            this.dtpPayToCompanyDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPayToCompanyDate.Location = new System.Drawing.Point(280, 112);
            this.dtpPayToCompanyDate.Name = "dtpPayToCompanyDate";
            this.dtpPayToCompanyDate.Size = new System.Drawing.Size(96, 23);
            this.dtpPayToCompanyDate.TabIndex = 37;
            this.dtpPayToCompanyDate.Visible = false;
            // 
            // cboPayerType
            // 
            this.cboPayerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPayerType.Location = new System.Drawing.Point(136, 24);
            this.cboPayerType.Name = "cboPayerType";
            this.cboPayerType.Size = new System.Drawing.Size(176, 24);
            this.cboPayerType.TabIndex = 35;
            this.cboPayerType.TextChanged += new System.EventHandler(this.cboPayerType_TextChanged);
            this.cboPayerType.SelectedIndexChanged += new System.EventHandler(this.cboPayerType_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(118, 19);
            this.label14.TabIndex = 37;
            this.label14.Text = "ผู้รับผิดชอบค่าเสียหาย";
            // 
            // chkAccessStatus
            // 
            this.chkAccessStatus.Location = new System.Drawing.Point(400, 48);
            this.chkAccessStatus.Name = "chkAccessStatus";
            this.chkAccessStatus.TabIndex = 41;
            this.chkAccessStatus.Text = "มีค่า Excess";
            this.chkAccessStatus.CheckedChanged += new System.EventHandler(this.chkAccessStatus_CheckedChanged);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(64, 120);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(145, 19);
            this.label44.TabIndex = 50;
            this.label44.Text = "ค่า Excess เป็นจำนวนเงิน";
            // 
            // fpdExcessTotalAmount
            // 
            this.fpdExcessTotalAmount.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdExcessTotalAmount.AllowClipboardKeys = true;
            this.fpdExcessTotalAmount.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdExcessTotalAmount.DecimalPlaces = 2;
            this.fpdExcessTotalAmount.DecimalSeparator = ".";
            this.fpdExcessTotalAmount.FixedPoint = true;
            this.fpdExcessTotalAmount.Location = new System.Drawing.Point(480, 80);
            this.fpdExcessTotalAmount.Name = "fpdExcessTotalAmount";
            this.fpdExcessTotalAmount.Size = new System.Drawing.Size(96, 22);
            this.fpdExcessTotalAmount.TabIndex = 48;
            this.fpdExcessTotalAmount.Text = "";
            this.fpdExcessTotalAmount.UseSeparator = true;
            this.fpdExcessTotalAmount.TextChanged += new System.EventHandler(this.fpdExcessTotalAmount_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(400, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 19);
            this.label10.TabIndex = 45;
            this.label10.Text = "เป็นจำนวนเงิน";
            // 
            // tabMaintain
            // 
            this.tabMaintain.Controls.Add(this.label32);
            this.tabMaintain.Controls.Add(this.groupBox10);
            this.tabMaintain.Controls.Add(this.groupBox5);
            this.tabMaintain.Controls.Add(this.txbRemark2);
            this.tabMaintain.Controls.Add(this.groupBox9);
            this.tabMaintain.Controls.Add(this.grbGarage);
            this.tabMaintain.Controls.Add(this.txbRemark1);
            this.tabMaintain.Controls.Add(this.label37);
            this.tabMaintain.Location = new System.Drawing.Point(4, 25);
            this.tabMaintain.Name = "tabMaintain";
            this.tabMaintain.Size = new System.Drawing.Size(1008, 427);
            this.tabMaintain.TabIndex = 1;
            this.tabMaintain.Text = "ข้อมูลการซ่อม";
            this.tabMaintain.Visible = false;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(16, 386);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(150, 19);
            this.label32.TabIndex = 68;
            this.label32.Text = "ชื่อศูนย์ซ่อมสำหรับบิลเงินสด";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.gpbTaxStatus);
            this.groupBox10.Controls.Add(this.label16);
            this.groupBox10.Controls.Add(this.dtpTaxDate);
            this.groupBox10.Controls.Add(this.txtTaxNo);
            this.groupBox10.Controls.Add(this.cboPaymentType);
            this.groupBox10.Controls.Add(this.label30);
            this.groupBox10.Controls.Add(this.fpdTotalAmount);
            this.groupBox10.Controls.Add(this.fpdRepairAmount);
            this.groupBox10.Controls.Add(this.label31);
            this.groupBox10.Controls.Add(this.label33);
            this.groupBox10.Controls.Add(this.fpdVat);
            this.groupBox10.Controls.Add(this.chkVat);
            this.groupBox10.Controls.Add(this.label35);
            this.groupBox10.Controls.Add(this.label34);
            this.groupBox10.Controls.Add(this.chkBPManual);
            this.groupBox10.Location = new System.Drawing.Point(704, 112);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(296, 296);
            this.groupBox10.TabIndex = 55;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "การชำระเงิน";
            // 
            // gpbTaxStatus
            // 
            this.gpbTaxStatus.Controls.Add(this.rdoTaxStatusNo);
            this.gpbTaxStatus.Controls.Add(this.rdoTaxStatusYes);
            this.gpbTaxStatus.Location = new System.Drawing.Point(96, 48);
            this.gpbTaxStatus.Name = "gpbTaxStatus";
            this.gpbTaxStatus.Size = new System.Drawing.Size(192, 48);
            this.gpbTaxStatus.TabIndex = 68;
            this.gpbTaxStatus.TabStop = false;
            this.gpbTaxStatus.Text = "ใบเสร็จรับเงินพร้อมใบกำกับภาษี";
            // 
            // rdoTaxStatusNo
            // 
            this.rdoTaxStatusNo.Location = new System.Drawing.Point(104, 16);
            this.rdoTaxStatusNo.Name = "rdoTaxStatusNo";
            this.rdoTaxStatusNo.Size = new System.Drawing.Size(48, 24);
            this.rdoTaxStatusNo.TabIndex = 1;
            this.rdoTaxStatusNo.Text = "ไม่มี";
            // 
            // rdoTaxStatusYes
            // 
            this.rdoTaxStatusYes.Location = new System.Drawing.Point(40, 16);
            this.rdoTaxStatusYes.Name = "rdoTaxStatusYes";
            this.rdoTaxStatusYes.Size = new System.Drawing.Size(32, 24);
            this.rdoTaxStatusYes.TabIndex = 0;
            this.rdoTaxStatusYes.Text = "มี";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(104, 200);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(32, 19);
            this.label16.TabIndex = 67;
            this.label16.Text = "VAT";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpTaxDate
            // 
            this.dtpTaxDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTaxDate.Checked = false;
            this.dtpTaxDate.CustomFormat = "dd/MM/yyyy";
            this.dtpTaxDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTaxDate.Location = new System.Drawing.Point(144, 136);
            this.dtpTaxDate.Name = "dtpTaxDate";
            this.dtpTaxDate.Size = new System.Drawing.Size(104, 23);
            this.dtpTaxDate.TabIndex = 60;
            // 
            // txtTaxNo
            // 
            this.txtTaxNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTaxNo.Location = new System.Drawing.Point(144, 104);
            this.txtTaxNo.MaxLength = 15;
            this.txtTaxNo.Name = "txtTaxNo";
            this.txtTaxNo.Size = new System.Drawing.Size(144, 23);
            this.txtTaxNo.TabIndex = 59;
            this.txtTaxNo.Text = "";
            // 
            // cboPaymentType
            // 
            this.cboPaymentType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaymentType.Location = new System.Drawing.Point(184, 24);
            this.cboPaymentType.Name = "cboPaymentType";
            this.cboPaymentType.Size = new System.Drawing.Size(104, 24);
            this.cboPaymentType.TabIndex = 61;
            // 
            // label30
            // 
            this.label30.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(64, 27);
            this.label30.Name = "label30";
            this.label30.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label30.Size = new System.Drawing.Size(110, 19);
            this.label30.TabIndex = 0;
            this.label30.Text = "ประเภทการชำระเงิน";
            // 
            // fpdTotalAmount
            // 
            this.fpdTotalAmount.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdTotalAmount.AllowClipboardKeys = true;
            this.fpdTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fpdTotalAmount.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdTotalAmount.DecimalPlaces = 2;
            this.fpdTotalAmount.DecimalSeparator = ".";
            this.fpdTotalAmount.FixedPoint = true;
            this.fpdTotalAmount.Location = new System.Drawing.Point(144, 232);
            this.fpdTotalAmount.Name = "fpdTotalAmount";
            this.fpdTotalAmount.Size = new System.Drawing.Size(104, 22);
            this.fpdTotalAmount.TabIndex = 65;
            this.fpdTotalAmount.Text = "";
            this.fpdTotalAmount.UseSeparator = true;
            this.fpdTotalAmount.TextChanged += new System.EventHandler(this.fpdTotalAmount_TextChanged);
            // 
            // fpdRepairAmount
            // 
            this.fpdRepairAmount.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdRepairAmount.AllowClipboardKeys = true;
            this.fpdRepairAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fpdRepairAmount.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdRepairAmount.DecimalPlaces = 2;
            this.fpdRepairAmount.DecimalSeparator = ".";
            this.fpdRepairAmount.Enabled = false;
            this.fpdRepairAmount.FixedPoint = true;
            this.fpdRepairAmount.Location = new System.Drawing.Point(144, 168);
            this.fpdRepairAmount.Name = "fpdRepairAmount";
            this.fpdRepairAmount.Size = new System.Drawing.Size(104, 22);
            this.fpdRepairAmount.TabIndex = 62;
            this.fpdRepairAmount.Text = "";
            this.fpdRepairAmount.UseSeparator = true;
            // 
            // label31
            // 
            this.label31.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(96, 168);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(42, 19);
            this.label31.TabIndex = 2;
            this.label31.Text = "ค่าซ่อม";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label33
            // 
            this.label33.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(72, 232);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(65, 19);
            this.label33.TabIndex = 7;
            this.label33.Text = "รวมเป็นเงิน";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fpdVat
            // 
            this.fpdVat.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdVat.AllowClipboardKeys = true;
            this.fpdVat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fpdVat.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdVat.DecimalPlaces = 2;
            this.fpdVat.DecimalSeparator = ".";
            this.fpdVat.Enabled = true;
            this.fpdVat.FixedPoint = true;
            this.fpdVat.Location = new System.Drawing.Point(144, 200);
            this.fpdVat.Name = "fpdVat";
            this.fpdVat.Size = new System.Drawing.Size(104, 22);
            this.fpdVat.TabIndex = 64;
            this.fpdVat.Text = "";
            this.fpdVat.UseSeparator = true;
            // 
            // chkVat
            // 
            this.chkVat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkVat.Location = new System.Drawing.Point(24, 72);
            this.chkVat.Name = "chkVat";
            this.chkVat.Size = new System.Drawing.Size(80, 24);
            this.chkVat.TabIndex = 63;
            this.chkVat.Text = "มีใบวางบิล";
            this.chkVat.CheckedChanged += new System.EventHandler(this.chkVat_CheckedChanged);
            // 
            // label35
            // 
            this.label35.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(24, 136);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(115, 19);
            this.label35.TabIndex = 9;
            this.label35.Text = "วันที่ออกใบกำกับภาษี";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label34
            // 
            this.label34.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label34.Location = new System.Drawing.Point(8, 104);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(152, 19);
            this.label34.TabIndex = 8;
            this.label34.Text = "ใบกำกับภาษี/ใบเสร็จรับเงิน";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cmdDeleteRepaiList);
            this.groupBox5.Controls.Add(this.cmdAddRepairList);
            this.groupBox5.Controls.Add(this.fpsRepairList);
            this.groupBox5.Location = new System.Drawing.Point(8, 112);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(688, 232);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "รายการซ่อม";
            // 
            // cmdDeleteRepaiList
            // 
            this.cmdDeleteRepaiList.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdDeleteRepaiList.Location = new System.Drawing.Point(352, 192);
            this.cmdDeleteRepaiList.Name = "cmdDeleteRepaiList";
            this.cmdDeleteRepaiList.TabIndex = 58;
            this.cmdDeleteRepaiList.Text = "ลบ";
            this.cmdDeleteRepaiList.Click += new System.EventHandler(this.cmdDeleteRepaiList_Click);
            // 
            // cmdAddRepairList
            // 
            this.cmdAddRepairList.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdAddRepairList.Location = new System.Drawing.Point(272, 192);
            this.cmdAddRepairList.Name = "cmdAddRepairList";
            this.cmdAddRepairList.TabIndex = 57;
            this.cmdAddRepairList.Text = "เพิ่ม";
            this.cmdAddRepairList.Click += new System.EventHandler(this.cmdAddRepairList_Click);
            // 
            // fpsRepairList
            // 
            this.fpsRepairList.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fpsRepairList.ContextMenu = this.ctmRepair;
            this.fpsRepairList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.fpsRepairList.Location = new System.Drawing.Point(24, 30);
            this.fpsRepairList.Name = "fpsRepairList";
            this.fpsRepairList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																					   this.fpsRepairList_Sheet1});
            this.fpsRepairList.Size = new System.Drawing.Size(640, 152);
            this.fpsRepairList.TabIndex = 59;
            this.fpsRepairList.TabStop = false;
            // 
            // ctmRepair
            // 
            this.ctmRepair.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mniRepairAdd,
																					  this.mniRepairDelete});
            // 
            // mniRepairAdd
            // 
            this.mniRepairAdd.Index = 0;
            this.mniRepairAdd.Text = "เพิ่ม";
            this.mniRepairAdd.Click += new System.EventHandler(this.mniRepairAdd_Click);
            // 
            // mniRepairDelete
            // 
            this.mniRepairDelete.Enabled = false;
            this.mniRepairDelete.Index = 1;
            this.mniRepairDelete.Text = "ลบ";
            this.mniRepairDelete.Click += new System.EventHandler(this.mniRepairDelete_Click);
            // 
            // fpsRepairList_Sheet1
            // 
            this.fpsRepairList_Sheet1.Reset();
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpsRepairList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpsRepairList_Sheet1.ColumnCount = 4;
            this.fpsRepairList_Sheet1.RowCount = 0;
            this.fpsRepairList_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "อะไหล่";
            this.fpsRepairList_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "รายละเอียด";
            this.fpsRepairList_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "สถานะค่าใช้จ่าย";
            this.fpsRepairList_Sheet1.ColumnHeader.Columns.Default.Resizable = true;
            this.fpsRepairList_Sheet1.Columns.Default.Resizable = true;
            textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType2.DropDownButton = false;
            this.fpsRepairList_Sheet1.Columns.Get(0).CellType = textCellType2;
            this.fpsRepairList_Sheet1.Columns.Get(0).Visible = false;
            this.fpsRepairList_Sheet1.Columns.Get(0).Resizable = true;
            this.fpsRepairList_Sheet1.Columns.Get(1).AllowAutoSort = true;
            this.fpsRepairList_Sheet1.Columns.Get(1).CellType = comboBoxCellType3;
            this.fpsRepairList_Sheet1.Columns.Get(1).Label = "อะไหล่";
            this.fpsRepairList_Sheet1.Columns.Get(1).Width = 245F;
            this.fpsRepairList_Sheet1.Columns.Get(1).Resizable = true;
            this.fpsRepairList_Sheet1.Columns.Get(2).AllowAutoSort = true;
            textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType3.DropDownButton = false;
            this.fpsRepairList_Sheet1.Columns.Get(2).CellType = textCellType3;
            this.fpsRepairList_Sheet1.Columns.Get(2).Label = "รายละเอียด";
            this.fpsRepairList_Sheet1.Columns.Get(2).Width = 225F;
            this.fpsRepairList_Sheet1.Columns.Get(2).Resizable = true;
            this.fpsRepairList_Sheet1.Columns.Get(3).AllowAutoSort = true;
            this.fpsRepairList_Sheet1.Columns.Get(3).CellType = comboBoxCellType4;
            this.fpsRepairList_Sheet1.Columns.Get(3).Label = "สถานะค่าใช้จ่าย";
            this.fpsRepairList_Sheet1.Columns.Get(3).Width = 114F;
            this.fpsRepairList_Sheet1.Columns.Get(3).Resizable = true;
            this.fpsRepairList_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.fpsRepairList_Sheet1.RowHeader.Rows.Default.Resizable = true;
            this.fpsRepairList_Sheet1.Rows.Default.Resizable = true;
            this.fpsRepairList_Sheet1.SheetName = "Sheet1";
            this.fpsRepairList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // txbRemark2
            // 
            this.txbRemark2.Location = new System.Drawing.Point(168, 384);
            this.txbRemark2.Name = "txbRemark2";
            this.txbRemark2.Size = new System.Drawing.Size(528, 23);
            this.txbRemark2.TabIndex = 67;
            this.txbRemark2.Text = "";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.rdbRepair);
            this.groupBox9.Controls.Add(this.rdbRepairReady);
            this.groupBox9.Controls.Add(this.txbReceiverName);
            this.groupBox9.Controls.Add(this.dtpRepairTo);
            this.groupBox9.Controls.Add(this.dtpRepairForm);
            this.groupBox9.Controls.Add(this.txbReceiverNo);
            this.groupBox9.Controls.Add(this.label36);
            this.groupBox9.Controls.Add(this.label24);
            this.groupBox9.Controls.Add(this.label23);
            this.groupBox9.Location = new System.Drawing.Point(24, 64);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(960, 48);
            this.groupBox9.TabIndex = 1;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "ระยะเวลาซ่อม";
            // 
            // rdbRepair
            // 
            this.rdbRepair.Checked = true;
            this.rdbRepair.Location = new System.Drawing.Point(472, 15);
            this.rdbRepair.Name = "rdbRepair";
            this.rdbRepair.TabIndex = 58;
            this.rdbRepair.TabStop = true;
            this.rdbRepair.Text = "ซ่อมยังไม่เสร็จ";
            // 
            // rdbRepairReady
            // 
            this.rdbRepairReady.Location = new System.Drawing.Point(392, 15);
            this.rdbRepairReady.Name = "rdbRepairReady";
            this.rdbRepairReady.Size = new System.Drawing.Size(72, 24);
            this.rdbRepairReady.TabIndex = 57;
            this.rdbRepairReady.Text = "ซ่อมเสร็จ";
            // 
            // txbReceiverName
            // 
            this.txbReceiverName.Enabled = false;
            this.txbReceiverName.Location = new System.Drawing.Point(760, 16);
            this.txbReceiverName.Name = "txbReceiverName";
            this.txbReceiverName.Size = new System.Drawing.Size(192, 23);
            this.txbReceiverName.TabIndex = 56;
            this.txbReceiverName.Text = "";
            // 
            // dtpRepairTo
            // 
            this.dtpRepairTo.CustomFormat = "dd/MM/yyyy";
            this.dtpRepairTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRepairTo.Location = new System.Drawing.Point(240, 16);
            this.dtpRepairTo.Name = "dtpRepairTo";
            this.dtpRepairTo.Size = new System.Drawing.Size(88, 23);
            this.dtpRepairTo.TabIndex = 54;
            this.dtpRepairTo.ValueChanged += new System.EventHandler(this.dtpRepairTo_ValueChanged);
            // 
            // dtpRepairForm
            // 
            this.dtpRepairForm.CustomFormat = "dd/MM/yyyy";
            this.dtpRepairForm.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRepairForm.Location = new System.Drawing.Point(80, 16);
            this.dtpRepairForm.Name = "dtpRepairForm";
            this.dtpRepairForm.Size = new System.Drawing.Size(88, 23);
            this.dtpRepairForm.TabIndex = 53;
            // 
            // txbReceiverNo
            // 
            this.txbReceiverNo.Location = new System.Drawing.Point(696, 16);
            this.txbReceiverNo.MaxLength = 5;
            this.txbReceiverNo.Name = "txbReceiverNo";
            this.txbReceiverNo.Size = new System.Drawing.Size(64, 23);
            this.txbReceiverNo.TabIndex = 55;
            this.txbReceiverNo.Text = "";
            this.txbReceiverNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbReceiverNo_KeyDown);
            this.txbReceiverNo.TextChanged += new System.EventHandler(this.txbReceiverNo_TextChanged);
            this.txbReceiverNo.DoubleClick += new System.EventHandler(this.txbReceiverNo_DoubleClick);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(640, 18);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(65, 19);
            this.label36.TabIndex = 11;
            this.label36.Text = "ผู้รับรถซ่อม";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(200, 18);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(33, 19);
            this.label24.TabIndex = 1;
            this.label24.Text = "จนถึง";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(40, 18);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(34, 19);
            this.label23.TabIndex = 0;
            this.label23.Text = "ตั้งแต่";
            // 
            // grbGarage
            // 
            this.grbGarage.Controls.Add(this.txbGarageTel);
            this.grbGarage.Controls.Add(this.label22);
            this.grbGarage.Controls.Add(this.txbGarageOfficer);
            this.grbGarage.Controls.Add(this.label21);
            this.grbGarage.Controls.Add(this.cmbGarage);
            this.grbGarage.Controls.Add(this.lblGarage);
            this.grbGarage.Location = new System.Drawing.Point(24, 8);
            this.grbGarage.Name = "grbGarage";
            this.grbGarage.Size = new System.Drawing.Size(960, 56);
            this.grbGarage.TabIndex = 0;
            this.grbGarage.TabStop = false;
            this.grbGarage.Text = "ศูนย์บริการ";
            // 
            // txbGarageTel
            // 
            this.txbGarageTel.Location = new System.Drawing.Point(808, 24);
            this.txbGarageTel.Name = "txbGarageTel";
            this.txbGarageTel.Size = new System.Drawing.Size(144, 23);
            this.txbGarageTel.TabIndex = 52;
            this.txbGarageTel.Text = "";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(736, 26);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(61, 19);
            this.label22.TabIndex = 4;
            this.label22.Text = "เบอร์ติดต่อ";
            // 
            // txbGarageOfficer
            // 
            this.txbGarageOfficer.Location = new System.Drawing.Point(560, 24);
            this.txbGarageOfficer.Name = "txbGarageOfficer";
            this.txbGarageOfficer.Size = new System.Drawing.Size(168, 23);
            this.txbGarageOfficer.TabIndex = 51;
            this.txbGarageOfficer.Text = "";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(480, 26);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(67, 19);
            this.label21.TabIndex = 2;
            this.label21.Text = "ชื่อเจ้าหน้าที่";
            // 
            // cmbGarage
            // 
            this.cmbGarage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGarage.Location = new System.Drawing.Point(80, 23);
            this.cmbGarage.Name = "cmbGarage";
            this.cmbGarage.Size = new System.Drawing.Size(392, 24);
            this.cmbGarage.TabIndex = 50;
            this.cmbGarage.TextChanged += new System.EventHandler(this.cmbGarage_TextChanged);
            this.cmbGarage.SelectedIndexChanged += new System.EventHandler(this.cmbGarage_SelectedIndexChanged);
            // 
            // lblGarage
            // 
            this.lblGarage.AutoSize = true;
            this.lblGarage.Location = new System.Drawing.Point(8, 26);
            this.lblGarage.Name = "lblGarage";
            this.lblGarage.Size = new System.Drawing.Size(78, 19);
            this.lblGarage.TabIndex = 0;
            this.lblGarage.Text = "ชื่อศูนย์บริการ";
            // 
            // txbRemark1
            // 
            this.txbRemark1.Location = new System.Drawing.Point(88, 352);
            this.txbRemark1.Name = "txbRemark1";
            this.txbRemark1.Size = new System.Drawing.Size(608, 23);
            this.txbRemark1.TabIndex = 66;
            this.txbRemark1.Text = "";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(16, 352);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(54, 19);
            this.label37.TabIndex = 13;
            this.label37.Text = "หมายเหตุ";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(511, 600);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.TabIndex = 69;
            this.cmdCancel.Text = "ยกเลิก";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(431, 600);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.TabIndex = 68;
            this.cmdSave.Text = "บันทึก";
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // chkBPManual
            // 
            this.chkBPManual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBPManual.Location = new System.Drawing.Point(24, 264);
            this.chkBPManual.Name = "chkBPManual";
            this.chkBPManual.Size = new System.Drawing.Size(152, 24);
            this.chkBPManual.TabIndex = 69;
            this.chkBPManual.Text = "BizPac Manual Input";
            // 
            // frmVehicleRepairingEntryBase
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1030, 632);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.gpbInfo);
            this.Controls.Add(this.tabVehicleAccident);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmVehicleRepairingEntryBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmVehicleRepairingEntryBase_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmVehicleRepairingEntryBase_Paint);
            this.gpbInfo.ResumeLayout(false);
            this.tabVehicleAccident.ResumeLayout(false);
            this.tabAccident.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpsPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsPayment_Sheet1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.tabMaintain.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.gpbTaxStatus.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpsRepairList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsRepairList_Sheet1)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.grbGarage.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

		#region - Constant -
		private enum empListType
		{
			REPORTER,
			EMPLOYEE,
			RECEIVER,
		}

		protected enum PROGRAM_TYPE 
		{
			ACCIDENT,
			MAINTAIN,
		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		protected bool maintainStatus = false;
		private frmServiceStaffList formEmplist;			
		protected string strGarage = "";
		protected DocumentNo documentNo;
        protected RepairingInfoBase objRepairing;
		protected PROGRAM_TYPE programType;
		#endregion

		#region - Property - 
			protected frmVehicleRepairingBase formParent;
			public frmVehicleRepairingBase FormParent
			{
				get
				{
					return formParent;
				}
				set
				{
					formParent = value;
				}
			}			
		#endregion

		//==============================  Constructor ==============================
		public frmVehicleRepairingEntryBase() : base()
		{
			InitializeComponent();
			Text = "อุบัติเหตุ";

			fpdPaid.MaxValue = 99999.99;
			fpdPaid.MinValue = 0;

			fpdExcessTotalAmount.MaxValue = 99999.99;
			fpdExcessTotalAmount.MinValue = 0;

			fpdExcessPaidAmount.MaxValue = 99999.99;
			fpdExcessPaidAmount.MinValue = 0;

			fpdExcessRemainAmount.MaxValue = 99999.99;
			fpdExcessRemainAmount.MinValue = 0;	
		
			fpdRepairAmount.MaxValue = 9999999.99;
			fpdRepairAmount.MinValue = 0;

			fpdVat.MaxValue = 999999.99;
			fpdVat.MinValue = 0;

			fpdTotalAmount.MaxValue = 9999999.99;
			fpdTotalAmount.MinValue = 0;
		}

		#region - Private Method -
		protected void setFpsRepairList()
		{
			if(programType == PROGRAM_TYPE.MAINTAIN)
			{
				fpsRepairList_Sheet1.Columns[3].Remove();
				fpsRepairList_Sheet1.Columns[1].Width = 290;
				fpsRepairList_Sheet1.Columns[2].Width = 290;
			}		
		}

		#region - Headere -
			private void bindReportor(Employee value)
			{
				txtReportorNo.Tag = value;
				txtReportorNo.Text = value.EmployeeNo;
				txtReportorName.Text = value.EmployeeName;
			}

			private void bindDriver(Employee value)
			{
				txtEmployeeNo.Tag = value;
				txtEmployeeNo.Text = value.EmployeeNo;
				txtDriverName.Text = value.EmployeeName;
			}

			private void bindReceiver(Employee value)
			{
				txbReceiverNo.Tag = value;
				txbReceiverNo.Text = value.EmployeeNo;
				txbReceiverName.Text = value.EmployeeName;
			}

			protected void enableHeader(bool value)
			{

			}

		#endregion

		#region - Accident -
			private void clearAccident()
			{
				clearAccidentInfo();
				clearAccidentDriverReport();
				clearAccidentDamages();
				clearMonthPayment();
			}
	
			private void clearAccidentInfo()
			{
				dtpAccidentDate.Value = DateTime.Today;
				dtpAccidentTime.Value = DateTime.Now;
				cboAccidentPlace.Text = "";
				cboPoliceStation.Text = "";
				txtPoliceName.Text = "";
			}

			private void clearAccidentDriverReport()
			{
				txtDetail1.Text = "";
				txtDetail2.Text = "";
				txtDetail3.Text = "";
				txtDetail4.Text = "";
				fpdDamagePercentage.Value = 0;
				chkClaimnantStatus.Checked = false;
				chkFrontGlassBrokenStatus.Checked = false;
			}

			private void clearAccidentDamages()
			{
				cboPayerType.SelectedIndex = -1;
				chkPayToCompanyStatus.Checked = false;
				dtpPayToCompanyDate.Checked = false;
				chkPayToInsuranceStatus.Checked = false;
				dtpPayToInsuranceDate.Checked = false;
				chkHasRepair.Checked = false;
				enableMaintain(false);
				chkAccessStatus.Checked = false;
				enableExcess(false);
			}

			private void enableExcess(bool value)
			{
				fpdExcessTotalAmount.Enabled = value;
                fpdExcessPaidAmount.Enabled = value;
                fpdExcessRemainAmount.Enabled = value;
                if (!value)
                {
                    fpdExcessTotalAmount.Value = 0;
                    fpdExcessPaidAmount.Value = 0;
                    fpdExcessRemainAmount.Value = 0;
                }
			}

			private void enableMonthPayment(bool value)
			{
				fpdPaid.Enabled = value;
				dtpPaidDate.Enabled = value;

				btnClaculatePaid.Enabled = value;

				fpsPayment.Enabled = value;

				cmdAddPayment.Enabled = value;
				mniPaymentAdd.Enabled = value;

				if(value && fpsPayment_Sheet1.RowCount>0)
				{
					cmdDeletePayment.Enabled = value;
					mniPaymentDelete.Enabled = value;
				}

				if(!value)
				{
					cmdDeletePayment.Enabled = value;
					mniPaymentDelete.Enabled = value;
				}
			}

			private void clearMonthPayment()
			{
				fpdPaid.Value = 0;
				dtpPaidDate.Value = DateTime.Today;
				fpsPayment_Sheet1.RowCount = 0;
				bindCmdPayment();
			}

			protected virtual void bindPayment()
			{
			}

			protected void bindCmdPayment()
			{
				if(fpsPayment_Sheet1.RowCount == 0)
				{
					cmdDeletePayment.Enabled = false;
					mniPaymentDelete.Enabled = false;

					chkPayToCompanyStatus.Checked = false;
				}
				else
				{
					cmdDeletePayment.Enabled = true;
					mniPaymentDelete.Enabled = true;
				}
			}

			private void enablePayer(bool enable)
			{
				if(!enable)
				{
					chkPayToCompanyStatus.Checked = false;
				}
				chkPayToCompanyStatus.Enabled = enable;
				
				dtpPayToCompanyDate.Enabled = chkPayToCompanyStatus.Checked;
				dtpPayToInsuranceDate.Enabled = chkPayToInsuranceStatus.Checked;
			}

			private void setHasExcess()
			{
				if(fpsPayment_Sheet1.RowCount>0)
				{
					chkPTBDriver.Checked = true;
					cboPayerType.Text = GUIFunction.GetString(PAYER_TYPE.EMPLOYEE);
					chkAccessStatus.Checked = true;
				}			
			}

			private bool enableExcessForDriver()
			{
				cboPayerType.Enabled = chkAccessStatus.Checked;				
				chkPayToInsuranceStatus.Enabled = chkAccessStatus.Checked;

				if(chkAccessStatus.Checked)
				{					
					switch(CTFunction.GetPayerType(cboPayerType.Text))
					{
						case PAYER_TYPE.CUSTOMER :
						{
							enablePayer(true);
							enableMonthPayment(false);
							if(fpsPayment_Sheet1.RowCount>0)
							{
								setHasExcess();
								return false;
							}
							break;
						}
						case PAYER_TYPE.PTB :
						{
							enablePayer(false);
							enableMonthPayment(false);
							if(fpsPayment_Sheet1.RowCount>0)
							{
								setHasExcess();
								return false;
							}
							break;
						}
						case PAYER_TYPE.EMPLOYEE :
						{
							enablePayer(true);
							if(chkPTBDriver.Checked)
							{					
								enableMonthPayment(true);
							}
							else
							{
								if(fpsPayment_Sheet1.RowCount==0)
								{
									enableMonthPayment(false);
								}
								else
								{
									setHasExcess();
									return false;
								}
							}
							break;
						}
                        case PAYER_TYPE.RESIGN:
                        {
                            enablePayer(false);
                            enableMonthPayment(false);
                            if (fpsPayment_Sheet1.RowCount > 0)
                            {
                                setHasExcess();
                                return false;
                            }
                            break;
                        }
					}

					enableExcess(chkAccessStatus.Checked);
				}
				else
				{
					enablePayer(false);

					chkPayToCompanyStatus.Checked = false;
					chkPayToInsuranceStatus.Checked = false;

					enableExcess(false);
					enableMonthPayment(false);
				}
				return true;
			}

			protected virtual void calculatePayment()
			{
			}

			protected virtual void addPaymentRow()
			{
				fpsPayment.Focus();
				fpsPayment_Sheet1.ActiveRowIndex = fpsPayment_Sheet1.RowCount - 1;
			}

			protected virtual void deletePaymentRow()
			{
			}

			private void calculateAmountBeforeVat(VAT value, bool VATStatus)
			{
				VATRate vatRate;
				if(VATStatus)
				{
					vatRate = FormParent.FacadeRepairing.GetVATRate();
				}
				else
				{
					vatRate = new VATRate();
					vatRate.Rate = 0;
				}
				value.AmountBeforeVAT = value.TotalAmount * (100/(100 + vatRate.Rate));
				value.VatAmount = value.TotalAmount - value.AmountBeforeVAT;
				vatRate = null;
			}
		#endregion

		#region - Maintain -
			protected void enableMaintain(bool value)
			{
				cmbGarage.Enabled = value;
				txbGarageOfficer.Enabled = value;
				txbGarageTel.Enabled = value;

				dtpRepairForm.Enabled = value;
				dtpRepairTo.Enabled = value;

				cboPaymentType.Enabled = value;
				fpdTotalAmount.Enabled = value;				

				fpsRepairList.Enabled = value;
				cmdAddRepairList.Enabled = value;
				mniRepairAdd.Enabled = value;
				if(!value)
				{
					cmdDeleteRepaiList.Enabled = value;
					mniRepairDelete.Enabled = value;
				}

				rdbRepairReady.Enabled = value;
				rdbRepair.Enabled = value;

				txbRemark1.Enabled = value;
				txbRemark2.Enabled = value;
			}

			private void clearMaintain()
			{
				cmbGarage.Text = "";
				txbGarageOfficer.Text = "";
				txbGarageTel.Text = "";

				dtpRepairForm.Value = DateTime.Today;
				dtpRepairTo.Value = DateTime.Today;
				
				txbReceiverNo.Text = "";
				txbReceiverName.Text = "";

				cboPaymentType.SelectedIndex  = 1;
				fpdRepairAmount.Value = 0;
				fpdVat.Value = 0;
				chkVat.Checked = true;
				fpdTotalAmount.Value = 0;
                clearVat();

				fpsRepairList_Sheet1.RowCount = 0;
				cmdDeleteRepaiList.Enabled = false;
				mniRepairDelete.Enabled = false;

				txbRemark1.Text = "";
				txbRemark2.Text = "";

                chkBPManual.Checked = false;
                chkBPManual.Tag = null;
			}

			private void bindRepair()
			{
				if(fpsRepairList_Sheet1.RowCount == 0)
				{
					cmdDeleteRepaiList.Enabled = false;
					mniRepairDelete.Enabled = false;
				}
				else
				{
					cmdDeleteRepaiList.Enabled = true;
					mniRepairDelete.Enabled = true;
				}				
			}

			protected void addRepairRow()
			{
				fpsRepairList_Sheet1.RowCount++;
				bindRepair();
				fpsRepairList.Focus();
				fpsRepairList_Sheet1.ActiveRowIndex = fpsRepairList_Sheet1.RowCount - 1;
			}

			protected void deleteRepairRow()
			{
				if (Message(MessageList.Question.Q0001) == DialogResult.Yes)
				{
					objRepairing.ARepairSparePartsList.Remove(fpsRepairList_Sheet1.Cells[fpsRepairList_Sheet1.ActiveRow.Index, 0].Text);
					fpsRepairList_Sheet1.ActiveRow.Remove();
				}
				bindRepair();
			}

			protected void calculateVAT()
			{
				VAT vat = new VAT();
				vat.TotalAmount = decimal.Parse(fpdTotalAmount.Text);
				calculateAmountBeforeVat(vat, chkVat.Checked);
				fpdRepairAmount.Value = vat.AmountBeforeVAT;
				fpdVat.Value = vat.VatAmount;
			}

        protected void enableVatStatus()
        {
            enableVatStatus(chkVat.Checked);
        }

        protected void enableVatStatus(bool enable)
        {
            //txtTaxNo.Enabled = enable;
            //dtpTaxDate.Enabled = enable;
            gpbTaxStatus.Enabled = enable;            
        }

        protected void enablechkVat(bool enable)
        {
            chkVat.Enabled = enable;
        }

        protected void clearVat()
        {
            //txtTaxNo.Text = "";
            //dtpTaxDate.Value = DateTime.Today;
            rdoTaxStatusYes.Checked = false;
            rdoTaxStatusNo.Checked = false;
        }
		#endregion

		protected virtual void  initDataSource()
		{
			cboAccidentPlace.DataSource = FormParent.FacadeRepairing.DataSourceAccidentPlace;
			cboPoliceStation.DataSource = FormParent.FacadeRepairing.DataSourcePoliceStation;
			cboPayerType.DataSource = FormParent.FacadeRepairing.DataSourcePayer;
			cboPaymentType.DataSource = FormParent.FacadeRepairing.DataSourcePayment;
			fpsRepairList_Sheet1.Columns[1].CellType = FormParent.FacadeRepairing.DataSourceSparepart;
			
			cmbGarage.DataSource = FormParent.FacadeRepairing.DataSourceGarage;
			formEmplist = new frmServiceStaffList();
		}

		protected void clearCombo()
		{
			cboAccidentPlace.SelectedIndex = -1;
			cboPoliceStation.SelectedIndex = -1;
			cboPayerType.SelectedIndex = -1;
			cboPaymentType.Text = "เช็ค";
			cmbGarage.SelectedIndex = -1;		
		}
		#endregion

		#region - Validate -
			protected virtual int getMaxMileage()
			{
				return 0;
			}

			private bool validateHeader()
			{
				if(txtReportorNo.Text.Trim() == "")
				{
					Message(MessageList.Error.E0002, "รหัสผู้เขียนรายงาน/ผู้ส่งซ่อม");
					txtReportorNo.Focus();
					return false;
				}
                
				if(! getEmployee(empListType.REPORTER, txtReportorNo))
				{
					txtReportorNo.Focus();
					return false;
				}

				if(chkPTBDriver.Checked)
				{
					if(txtEmployeeNo.Text.Trim() == "")
					{
						Message(MessageList.Error.E0002, "รหัสพนักงาน");
						txtEmployeeNo.Focus();
						return false;
					}

					if(! getEmployee(empListType.EMPLOYEE, txtEmployeeNo))
					{
						txtEmployeeNo.Focus();
						return false;
					}
				}

				if(txtDriverName.Text.Trim()=="")
				{
					Message(MessageList.Error.E0002, "ชื่อพนักงานขับรถ");
					txtDriverName.Focus();
					return false;
				}

				if(txtUserName.Text.Trim() == "")
				{
					Message(MessageList.Error.E0002, "ชื่อผู้ใช้รถ");
					txtUserName.Focus();
					return false;
				}

				if(txbReceiverNo.Text.Trim() == "")
				{
					Message(MessageList.Error.E0002, "ผู้รับรถ");
					tabVehicleAccident.SelectedTab = tabMaintain;
					txbReceiverNo.Focus();
					return false;
				}

                if (!FormParent.FacadeRepairing.ValidateServiceStaft(txbReceiverNo.Text))
				{
					Message(MessageList.Error.E0004, "รหัสผู้รับรถซ่อม");
					txbReceiverNo.Focus();
					return false;
				}

				return true;
			}

			protected virtual bool validateAccident()
			{
				return true;
			}

			protected virtual bool validateMaintain()
			{
				if(cmbGarage.SelectedIndex == -1)
				{
					Message(MessageList.Error.E0005, "ชื่อ" + strGarage);
					tabVehicleAccident.SelectedTab = tabMaintain;
					cmbGarage.Focus();
					return false;
				}

                Garage garage = (Garage)cmbGarage.SelectedItem;
                if (garage != null)
                {
                    if ((garage.Code == BizPacFixData.BIZPAC_DUMMY_GARAGE_VAT & txbRemark2.Text.Trim() == "") || (garage.Code == BizPacFixData.BIZPAC_DUMMY_GARAGE_NONVAT & txbRemark2.Text.Trim() == ""))
                    {
                        Message(MessageList.Error.E0002, "ชื่อศูนย์ซ่อมสำหรับบิลเงินสด");
                        tabVehicleAccident.SelectedTab = tabMaintain;
                        txbRemark2.Focus();
                        return false;
                    }
                }
                garage = null;


				if(dtpRepairForm.Value.Date > dtpRepairTo.Value.Date)
				{
					Message(MessageList.Error.E0011, "วันที่ตั้งแต่", "วันที่จนถึง");
					tabVehicleAccident.SelectedTab = tabMaintain;
					dtpRepairTo.Focus();
					return false;
				}

                //VehicleMaintenance vehicleMaintenance = new VehicleMaintenance(formParent.FacadeRepairing.GetCompany());
                //if (formParent.FacadeRepairing.FillVehicleRepairingHistory(vehicleMaintenance, formParent.ObjVehicleInfo))
                //{
                //    for (int i = 0; i < vehicleMaintenance.Count; i++)
                //    {
                //        Maintenance maintenance = (Maintenance)vehicleMaintenance[i];

                //        if (maintenance.RepairingNo != documentNo.ToString())
                //        {
                //            if (maintenance.RepairPeriod.To.Date >= dtpRepairForm.Value.Date & maintenance.RepairPeriod.From.Date <= dtpRepairTo.Value.Date)
                //            {
                //                if (maintenance.Garage.Code == ((Garage)cmbGarage.SelectedItem).Code)
                //                {
                //                    Message(MessageList.Error.E0013, "บันทึกการซ่อมได้", "มีระยะเวลาการซ่อมอยู่ในช่วงระยะเวลาที่เลือก");
                //                    tabVehicleAccident.SelectedTab = tabMaintain;
                //                    dtpRepairForm.Focus();
                //                    return false;
                //                }
                //            }
                //        }
                //    }
                //}

				if(fpsRepairList_Sheet1.RowCount==0)
				{
					Message(MessageList.Error.E0036);
					tabVehicleAccident.SelectedTab = tabMaintain;
					return false;
				}

				SparePartsList sparePartsList = new SparePartsList(formParent.FacadeRepairing.GetCompany());
				SpareParts spareParts;
				for(int i=0; i<fpsRepairList_Sheet1.RowCount; i++)
				{
					if(fpsRepairList_Sheet1.Cells[i, 1].Text == "")
					{
						Message(MessageList.Error.E0005, "อะไหล่");
						return false;
					}

					if(programType == PROGRAM_TYPE.ACCIDENT)
					{
						if(fpsRepairList_Sheet1.Cells[i, 3].Text == "")
						{
							Message(MessageList.Error.E0005, "สถานะค่าใช้จ่าย");
							return false;
						}
					}

					
					spareParts = new SpareParts();
					spareParts.Code = fpsRepairList_Sheet1.Cells[i, 1].Text;
					if(sparePartsList.Contain(spareParts))
					{
						Message(MessageList.Error.E0039);
						sparePartsList = null;
						spareParts = null;
						return false;
					}
					else
					{
						sparePartsList.Add(spareParts);
					}
				}
				sparePartsList = null;
				spareParts = null;

                if (chkVat.Checked)
                {
                    if (!rdoTaxStatusYes.Checked & !rdoTaxStatusNo.Checked)
                    {
                        Message(MessageList.Error.E0005, "สถานะใบเสร็จรับเงินพร้อมใบกำกับภาษี");
                        return false;
                    }
                    if (txtTaxNo.Text.Trim() == "")
                    {
                        Message(MessageList.Error.E0002, "เลขที่ใบกำกับภาษี/ใบเสร็จรับเงิน");
                        txtTaxNo.Focus();
                        return false;
                    }
                }

                if (txtTaxNo.Text.Trim() != string.Empty)
                {
                    if (Convert.ToDecimal(fpdTotalAmount.Value) <= 0)
                    {
                        Message(MessageList.Error.E0002, "รวมเป็นเงินค่าซ่อม");
                        tabVehicleAccident.SelectedTab = tabMaintain;
                        fpdTotalAmount.Focus();
                        return false;
                    }

                    VehicleMaintenance vehicleMaintenance = new VehicleMaintenance(FormParent.FacadeRepairing.GetCompany());
                    string docNo = string.Empty;

                    if (action == ActionType.EDIT)
                    {
                        docNo = ((DocumentNo)txtDocumentType.Tag).ToString();
                    }

                    if (FormParent.FacadeRepairing.FillVehicleRepairingHistory(vehicleMaintenance, docNo, txtTaxNo.Text.Trim()))
                    {
                        garage = (Garage)cmbGarage.SelectedItem;
                        foreach (RepairingInfoBase entity in vehicleMaintenance)
                        {
                            if (entity.Garage.BizPacExpenseCode.Trim() == garage.BizPacExpenseCode.Trim())
                            {
                                Message(MessageList.Error.E0028);
                                tabVehicleAccident.SelectedTab = tabMaintain;
                                txtTaxNo.Focus();
                                return false;
                            }
                        }

                        Message(MessageList.Error.E0028);
                        tabVehicleAccident.SelectedTab = tabMaintain;
                        txtTaxNo.Focus();
                        return false;
                    }

                    vehicleMaintenance = null;
                    garage = null;
                    //else
                    //{
                    //    DocumentNo tempDocumentNo = (DocumentNo)txtDocumentType.Tag;
                    //    string taxNo = FormParent.FacadeRepairing.ValidateTaxNo(txtTaxNo.Text, (Garage)cmbGarage.SelectedItem).Trim();
                    //    if (taxNo != "" && taxNo != tempDocumentNo.ToString())
                    //    {
                    //        Message(MessageList.Error.E0028);
                    //        tabVehicleAccident.SelectedTab = tabMaintain;
                    //        txtTaxNo.Focus();
                    //        return false;
                    //    }
                    //}
                }


//				if(!chkAccessStatus.Checked && fpsPayment_Sheet1.RowCount>0)
//				{
//					if (Message(MessageList.Question.Q0004, "ข้อมูลค่าชำระรายเดือนของพนักงานด้วย") != DialogResult.Yes)
//					{
//						return false;
//					}
//				}

//				if(!chkHasRepair.Checked)
//				{
//					if (Message(MessageList.Question.Q0004, "ข้อมูลการซ่อมของรถที่เกิดอุบัติเหตุคันนี้ด้วย") != DialogResult.Yes)
//					{
//						return false;
//					}
//				}

				return true;
			}
		#endregion

		#region - Set Object -
		private void setHeader(DocumentNo documentNo, VehicleInfo vehicleInfo)
		{
			txtDocumentType.Text = CTFunction.GetString(documentNo.DocumentType);
			txtDocumentNoYY.Text = documentNo.Year.ToString();
			txtDocumentNoMM.Text = documentNo.Month.ToString();
			txtDocumentNoXXX.Text = documentNo.No.ToString();

			txtPlatePrefix.Tag = vehicleInfo;
			txtPlatePrefix.Text = vehicleInfo.PlatePrefix;
			txtPlateNo.Text = vehicleInfo.PlateRunningNo;
			txtBrand.Text = vehicleInfo.AModel.ABrand.AName.English;

			dtpReportDate.Value = DateTime.Today;

			txtReportorNo.Text = "";
			txtReportorName.Text = "";

			chkPTBDriver.Checked = false;

			txtEmployeeNo.Text = "";
			txtDriverName.Text = "";

			VehicleContract vehicleContract = formParent.FacadeRepairing.GetCurrentVehicleContract(vehicleInfo);
			if(action == ActionType.ADD)
			{
				if(vehicleContract == null || vehicleContract.AVehicleRoleList[vehicleInfo.EntityKey] == null)
				{
					txtUserName.Text = "";
				}
				else
				{
					txtUserName.Text = vehicleContract.AVehicleRoleList[vehicleInfo.EntityKey].AHirer.Name;
				}			
			}
			txbVehicleType.Tag = vehicleInfo.AKindOfVehicle;
			txbVehicleType.Text = vehicleInfo.AKindOfVehicle.AName.Thai;
			if(vehicleContract != null)
			{
				txtContractNoYY.Text = vehicleContract.ContractNo.Year.ToString();
				txtContractNoMM.Text = vehicleContract.ContractNo.Month.ToString();
				txtContractNoXXX.Text = vehicleContract.ContractNo.No.ToString();
				txtContractNoXXX.Tag = vehicleContract;
			}
			fpiMileage.Value = 0;
		}

		protected virtual void getVehicleAssignment(VehicleInfo value)
		{
		}

		protected void setContact(RepairingInfoBase value)
		{
			if(value.AVehicleContract == null)
			{
				txtContractNoYY.Text = "";
				txtContractNoMM.Text = "";
				txtContractNoXXX.Text = "";
				txtContractNoXXX.Tag = null;

				txtCustomerName.Text = "";
				txtCustomerName.Tag = null;
				
				txtDepartmentName.Text = "";
				txtDepartmentName.Tag = null;
				return;
			}
			else
			{
				txtContractNoYY.Text = value.AVehicleContract.ContractNo.Year.ToString();
				txtContractNoMM.Text = value.AVehicleContract.ContractNo.Month.ToString();
				txtContractNoXXX.Text = value.AVehicleContract.ContractNo.No.ToString();
				txtContractNoXXX.Tag = value.AVehicleContract;

				if(txtUserName.Text.Trim()=="")
				{
					txtUserName.Text = value.AHirer.Name;
				}				
			}

			if(value.AVehicleContract.ACustomerDepartment.ACustomer != null)
			{
				txtCustomerName.Text = value.AVehicleContract.ACustomer.AName.Thai;
				txtCustomerName.Tag = value.AVehicleContract.ACustomer;
			}

			if(value.AVehicleContract.ACustomerDepartment != null)
			{
				txtDepartmentName.Text = value.AVehicleContract.ACustomerDepartment.AName.Thai;
				txtDepartmentName.Tag = value.AVehicleContract.ACustomerDepartment;
			}
		}

		protected virtual void setHeader()
		{		
		}

		private void setHeader(RepairingInfoBase value)
		{
			setHeader();
			documentNo = new DocumentNo(value.RepairingNo);
			txtDocumentType.Tag = documentNo;
			txtDocumentType.Text = CTFunction.GetString(documentNo.DocumentType);
			txtDocumentNoYY.Text = documentNo.Year.ToString();
			txtDocumentNoMM.Text = documentNo.Month.ToString();
			txtDocumentNoXXX.Text = documentNo.No.ToString();

			txtPlatePrefix.Tag = value.VehicleInfo;
			txtPlatePrefix.Text = value.VehicleInfo.PlatePrefix;
			txtPlateNo.Text = value.VehicleInfo.PlateRunningNo;
			txtBrand.Text = value.VehicleInfo.AModel.ABrand.AName.English;

			dtpReportDate.Value = objRepairing.ReportDate;
			setContact(objRepairing);

			fpiMileage.Value = objRepairing.Mileage;

			txtReportorNo.Tag = objRepairing.AReporter;
			txtReportorNo.Text = objRepairing.AReporter.EmployeeNo;
			txtReportorName.Text = objRepairing.AReporter.EmployeeName;
			
			txtPlatePrefix.Tag = objRepairing.VehicleInfo;
			txbVehicleType.Tag = objRepairing.KindOfVehicle;
			txbVehicleType.Text = objRepairing.KindOfVehicle.AName.Thai;

			txtContractNoXXX.Tag = objRepairing.AVehicleContract;
			txtCustomerName.Tag = objRepairing.ACustomer;
			txtDepartmentName.Tag = objRepairing.ACustomerDepartment;

			txtUserName.Text = objRepairing.AHirer.Name;
			txtEmployeeNo.Tag = objRepairing.ADriver;

			if(objRepairing.ADriver == null)
			{
				chkPTBDriver.Checked = false;
				txtDriverName.Text = objRepairing.DriverName;
			}
			else
			{
				if(objRepairing.ADriver.EmployeeNo.Trim() == "")
				{
					chkPTBDriver.Checked = false;
				}
				else
				{
					chkPTBDriver.Checked = true;
				}				
				txtEmployeeNo.Text = objRepairing.ADriver.EmployeeNo;
				txtDriverName.Text = objRepairing.ADriver.EmployeeName;
			}
			txbReceiverNo.Tag = objRepairing.AReceiver;
			txbReceiverNo.Text = objRepairing.AReceiver.EmployeeNo;
			txbReceiverName.Text = objRepairing.AReceiver.EmployeeName;
		}

        protected virtual void setAccident(RepairingInfoBase value)
		{
			Accident accident = (Accident)value;
			dtpAccidentDate.Value = accident.HappenTime;
			dtpAccidentTime.Value = accident.HappenTime;
			txtDetail1.Text = accident.DetailOfAccident1;
			txtDetail2.Text = accident.DetailOfAccident2;
			txtDetail3.Text = accident.DetailOfAccident3;
			txtDetail4.Text = accident.DetailOfAccident4;
			cboAccidentPlace.Text = accident.AccidentPlace.Name;
			cboPoliceStation.Text = accident.APoliceStation.Name;
			txtPoliceName.Text = accident.PolicemanName;
			chkClaimnantStatus.Checked = accident.HasClaimnant;
			chkFrontGlassBrokenStatus.Checked = accident.FrontGlassBroken;
			chkAccessStatus.Checked = accident.HasExcess;
			fpdDamagePercentage.Value = accident.DamagePercentage;
			cboPayerType.Text = CTFunction.GetString(accident.APayer);
			chkPayToInsuranceStatus.Checked = accident.PaidToInsurance;
			if(accident.PaidToInsuranceDate == NullConstant.DATETIME)
			{
				dtpPayToInsuranceDate.Value = DateTime.Today;
			}
			else
			{
				dtpPayToInsuranceDate.Value = accident.PaidToInsuranceDate;
			}
			chkPayToCompanyStatus.Checked = accident.PaidToCompanyStatus;
			if(accident.PaidToCompanyDate == NullConstant.DATETIME)
			{
				dtpPayToCompanyDate.Value = DateTime.Today;
			}
			else
			{
				dtpPayToCompanyDate.Value = accident.PaidToCompanyDate;
			}			
			
			fpsPayment_Sheet1.RowCount = accident.ADriverExcessDeduction.Count;

            decimal totalAmount = decimal.Zero;
            decimal paidAmount = decimal.Zero;

			if(accident.ADriverExcessDeduction.Count>0)
			{
				for(int i=0; i<accident.ADriverExcessDeduction.Count; i++)
				{
					fpsPayment_Sheet1.Cells[i,0].Text = accident.ADriverExcessDeduction[i].EntityKey;
					fpsPayment_Sheet1.Cells[i,1].Text = accident.ADriverExcessDeduction[i].AForMonth.Year.ToString();
					fpsPayment_Sheet1.Cells[i,2].Text = accident.ADriverExcessDeduction[i].AForMonth.Month.ToString();
					fpsPayment_Sheet1.Cells[i,3].Text = accident.ADriverExcessDeduction[i].Amount.ToString();
					fpsPayment_Sheet1.Cells[i,4].Value = accident.ADriverExcessDeduction[i].IsPaid;
					
					if(accident.ADriverExcessDeduction[i].IsPaid)
					{
						fpsPayment_Sheet1.Cells[i,1].Locked = true;
						fpsPayment_Sheet1.Cells[i,2].Locked = true;
						fpsPayment_Sheet1.Cells[i,3].Locked = true;

                        paidAmount += accident.ADriverExcessDeduction[i].Amount;
					}
                    totalAmount += accident.ADriverExcessDeduction[i].Amount;
				}
				cmdDeletePayment.Enabled = true;
				mniPaymentDelete.Enabled = true;
			}
			else
			{
				cmdDeletePayment.Enabled = false;
				mniPaymentDelete.Enabled = false;
			}

            if (accident.InsuranceReceiptDate == NullConstant.DATETIME)
            {
                txtInsuranceRecieveDate.Text = "";
            }
            else 
            {
                txtInsuranceRecieveDate.Text = accident.InsuranceReceiptDate.ToShortDateString();            
            }

            if (accident.PayToInsuranceBizPacConnectionDate == NullConstant.DATETIME)
            {
                txtConnectionDate.Text = "";
            }
            else
            {
                txtConnectionDate.Text = accident.PayToInsuranceBizPacConnectionDate.ToShortDateString();
            }

            fpdActualExcessAmount.Value = accident.ActualExcessAmount;
            fpdExcessTotalAmount.Value = accident.ExcessTotalAmount;
            fpdExcessPaidAmount.Value = accident.ExcessPaidAmount;
            fpdExcessRemainAmount.Value = accident.ExcessRemainAmount;

			accident = null;
		}

        protected virtual void enableExcessForDriverPaid(RepairingInfoBase value)
		{
			Accident accident = (Accident)value;
			if(accident.ADriverExcessDeduction.Count>0)
			{
				for(int i=0; i<accident.ADriverExcessDeduction.Count; i++)
				{
					if(accident.ADriverExcessDeduction[i].IsPaid)
					{
						chkAccessStatus.Enabled = false;
						cboPayerType.Enabled = false;
						chkPTBDriver.Enabled = false;
						txtEmployeeNo.Enabled = false;

						accident = null;
						return;
					}
				}
			}
			accident = null;
		}

        protected virtual void setMaintenance(RepairingInfoBase value)
		{
			fpiMileage.Value = value.Mileage;
			if(value.Garage != null && value.Garage.Code.Trim() != "")
			{
				cmbGarage.Text = value.Garage.AName.Thai;				
			}
			else
			{
				cmbGarage.SelectedIndex = -1;
				cmbGarageIndex = -1;
			}
			txbGarageOfficer.Text = value.GarageInchargeName;
			txbGarageTel.Text = value.GarageTelNo;
			if(value.RepairPeriod.From != NullConstant.DATETIME)
			{
				dtpRepairForm.Value = value.RepairPeriod.From;
			}
			if(value.RepairPeriod.To != NullConstant.DATETIME)
			{
				dtpRepairTo.Value = value.RepairPeriod.To;
			}

			if(value.VehicleInfo.AVehicleStatus.Code == "1")
			{
				rdbRepairReady.Checked = true;
			}
			else
			{
                if (value.RepairPeriod.To != NullConstant.DATETIME)
                {
                    if (value.RepairPeriod.To < DateTime.Today)
                    {
                        rdbRepairReady.Checked = true;
                    }
                    else
                    {
                        rdbRepair.Checked = true;
                    }
                }
                else
                {
                    rdbRepair.Checked = true;                
                }
			}


			if(value.RepairingPaymentType != null)
			{
				cboPaymentType.Text = value.RepairingPaymentType.AName.Thai;
			}
			chkVat.Checked = (bool)(value.VatStatus.Code == "1");

            if (value.TaxInvoiceStatus == TAX_INVOICE_STATUS_TYPE.YES)
            {
                rdoTaxStatusYes.Checked = true;
            }
            else if (value.TaxInvoiceStatus == TAX_INVOICE_STATUS_TYPE.NO)
            {
                rdoTaxStatusNo.Checked = true;
            }
            else
            {
                rdoTaxStatusNo.Checked = false;
                rdoTaxStatusYes.Checked = false;
            }

			fpdRepairAmount.Value = value.MaintenanceAmount;
			fpdVat.Value = value.VatAmount;
			fpdTotalAmount.Value = value.TotalAmount;
			txtTaxNo.Text = value.TaxInvoiceNo;
			if(value.TaxInvoiceDate == NullConstant.DATETIME)
			{
				dtpTaxDate.Checked = false;
			}
			else
			{
				dtpTaxDate.Value = value.TaxInvoiceDate;
				dtpTaxDate.Checked = true;
			}


			txbReceiverNo.Tag = value.AReceiver;
			txbRemark1.Text = value.Remark1 ;
			txbRemark2.Text = value.Remark2;
			
			fpsRepairList_Sheet1.RowCount = value.ARepairSparePartsList.Count;
			if(value.ARepairSparePartsList.Count>0)
			{
				for(int i=0; i<value.ARepairSparePartsList.Count; i++)
				{
					fpsRepairList_Sheet1.Cells[i, 1].Text = value.ARepairSparePartsList[i].ASpareParts.AName.Thai;
					fpsRepairList_Sheet1.Cells[i, 2].Text = value.ARepairSparePartsList[i].Description;
					if(programType == PROGRAM_TYPE.ACCIDENT)
					{
						fpsRepairList_Sheet1.Cells[i, 3].Value = CTFunction.GetString(value.ARepairSparePartsList[i].ExpenseStatus);
					}
				}
				cmdDeleteRepaiList.Enabled = true;
				mniRepairDelete.Enabled = true;
			}
			else
			{
				cmdDeleteRepaiList.Enabled = false;
				mniRepairDelete.Enabled = false;
			}

            chkBPManual.Tag = value.BPRefNo;
            if (value.BPRefNo != BizPacFixData.BIZPAC_DUMMY_REF_NO & value.BPRefNo != "")
            {
                chkBPManual.Checked = false;
                chkBPManual.Enabled = false;
            }
            else
            {
                chkBPManual.Checked = !(value.BPRefNo == "");
                chkBPManual.Enabled = true;
            }
		}
		#endregion

		#region - Get Object -
			protected virtual void fillHeader()
			{
				objRepairing.RepairingNo = documentNo.ToString();
				objRepairing.ReportDate = dtpReportDate.Value;
				objRepairing.AReporter = (Employee)txtReportorNo.Tag ;
				objRepairing.VehicleInfo = (VehicleInfo)txtPlatePrefix.Tag;
				objRepairing.KindOfVehicle = (KindOfVehicle)txbVehicleType.Tag;
				if(txtContractNoXXX.Tag!=null)
				{
					objRepairing.AVehicleContract = (VehicleContract)txtContractNoXXX.Tag;
				}
				if(txtCustomerName.Tag==null)
				{
					objRepairing.ACustomer = new Customer(Customer.DUMMYCODE);
				}
				else
				{
					objRepairing.ACustomer = (Customer)txtCustomerName.Tag;
				}
				if(txtDepartmentName.Tag==null)
				{
					objRepairing.ACustomerDepartment = new CustomerDepartment();
					objRepairing.ACustomerDepartment.ACustomer = objRepairing.ACustomer;
					objRepairing.ACustomerDepartment.Code = "ZZZ";
				}
				else
				{
					objRepairing.ACustomerDepartment = (CustomerDepartment)txtDepartmentName.Tag;
				}
				if(objRepairing.AHirer==null)
				{
					objRepairing.AHirer = new Hirer();
				}
				objRepairing.AHirer.Name = txtUserName.Text;			
				objRepairing.DriverName = txtDriverName.Text;
				if(chkPTBDriver.Checked)
				{
					objRepairing.ADriver = (Employee)txtEmployeeNo.Tag;
				}
				else
				{
					objRepairing.ADriver = new Employee(FormParent.FacadeRepairing.GetCompany());
					objRepairing.ADriver.AName.Thai = txtDriverName.Text;
				}
				objRepairing.Mileage = Convert.ToInt32(fpiMileage.Value);
			}

			protected virtual void fillAccident()
			{
				Accident accident = (Accident)objRepairing;
				accident.HappenTime = getDateTime(dtpAccidentDate.Value, dtpAccidentTime.Value);
				accident.DetailOfAccident1 = txtDetail1.Text;
				accident.DetailOfAccident2 = txtDetail2.Text;
				accident.DetailOfAccident3 = txtDetail3.Text;
				accident.DetailOfAccident4 = txtDetail4.Text;
				accident.AccidentPlace.Name = cboAccidentPlace.Text;
				accident.APoliceStation.Name = cboPoliceStation.Text;
				accident.PolicemanName = txtPoliceName.Text;
				accident.HasClaimnant = chkClaimnantStatus.Checked;
				accident.FrontGlassBroken = chkFrontGlassBrokenStatus.Checked;
				accident.HasExcess = chkAccessStatus.Checked;

                if (chkAccessStatus.Checked)
                {
                    accident.ExcessTotalAmount = decimal.Parse(fpdExcessTotalAmount.Text);
                    accident.ExcessPaidAmount = decimal.Parse(fpdExcessPaidAmount.Text);
                    accident.ExcessRemainAmount = decimal.Parse(fpdExcessRemainAmount.Text);
                }
                else
                {
                    accident.ExcessTotalAmount = 0m;
                    accident.ExcessPaidAmount = 0m;
                    accident.ExcessRemainAmount = 0m;
                }

				accident.DamagePercentage = decimal.Parse(fpdDamagePercentage.Text);
				accident.APayer = CTFunction.GetPayerType(cboPayerType.Text);
				if(chkPayToInsuranceStatus.Checked)
				{
					accident.PaidToInsurance = true;
					accident.PaidToInsuranceDate = dtpPayToInsuranceDate.Value.Date;
				}
				else
				{
					accident.PaidToInsurance = false;
					accident.PaidToInsuranceDate = NullConstant.DATETIME;	
				}

				if(chkPayToCompanyStatus.Checked)
				{
					accident.PaidToCompanyStatus = true;
					accident.PaidToCompanyDate = dtpPayToCompanyDate.Value.Date;		
				}
				else
				{
					if(accident.APayer == PAYER_TYPE.PTB)
					{
						accident.PaidToCompanyStatus = true;
						accident.PaidToCompanyDate = dtpPayToInsuranceDate.Value.Date;
					}
					else
					{
						accident.PaidToCompanyStatus = false;
						accident.PaidToCompanyDate = NullConstant.DATETIME;						
					}
				}
				
				accident.ADriverExcessDeduction.AAccident = accident;
				accident.ADriverExcessDeduction.ADriver = (Employee)txtEmployeeNo.Tag;
				accident.ADriverExcessDeduction.Clear();
				if(chkAccessStatus.Checked)
				{
					ExcessDeduction excessDeduction;
					for(int i=0; i<fpsPayment_Sheet1.RowCount; i++)
					{
						excessDeduction = new ExcessDeduction();
						int year = int.Parse(fpsPayment_Sheet1.Cells[i,1].Text);
						int month = int.Parse(fpsPayment_Sheet1.Cells[i,2].Text);
						excessDeduction.AForMonth = new YearMonth(year, month);
						excessDeduction.Amount = decimal.Parse(fpsPayment_Sheet1.Cells[i,3].Text);
						excessDeduction.IsPaid = (bool)fpsPayment_Sheet1.Cells[i,4].Value;
						excessDeduction.PaymentDate = NullConstant.DATETIME;
						accident.ADriverExcessDeduction.Add(excessDeduction);
					}
					excessDeduction = null;
				}
			}

			private DateTime getDateTime(DateTime date, DateTime time)
			{
				return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, 0);
			}

			protected virtual void fillMaintenance()
			{
				objRepairing.Garage = (Garage)cmbGarage.SelectedItem;
				objRepairing.GarageInchargeName = txbGarageOfficer.Text;
				objRepairing.GarageTelNo = txbGarageTel.Text;
				if(chkHasRepair.Checked)
				{
					objRepairing.RepairPeriod.From = dtpRepairForm.Value.Date;
					objRepairing.RepairPeriod.To = dtpRepairTo.Value.Date;
					
					if(rdbRepairReady.Checked)
					{
						objRepairing.RepairFinishStatus = true;
					}
					else
					{
						objRepairing.RepairFinishStatus = false;
					}
				}
				else
				{
					objRepairing.RepairPeriod.From = NullConstant.DATETIME;
					objRepairing.RepairPeriod.To = NullConstant.DATETIME;
				}

                //- VAT -
				objRepairing.RepairingPaymentType = (PaymentType)cboPaymentType.SelectedItem;
				if(chkVat.Checked)
				{
					objRepairing.VatStatus.Code = "1";

                    if (rdoTaxStatusYes.Checked)
                    {
                        objRepairing.TaxInvoiceStatus = TAX_INVOICE_STATUS_TYPE.YES;
                    }
                    else 
                    {
                        objRepairing.TaxInvoiceStatus = TAX_INVOICE_STATUS_TYPE.NO;                    
                    }
				}
				else
				{
					objRepairing.VatStatus.Code = "0";
                    objRepairing.TaxInvoiceStatus = TAX_INVOICE_STATUS_TYPE.BLANK;
				}

                objRepairing.TaxInvoiceNo = txtTaxNo.Text.Trim();

                if (txtTaxNo.Text.Trim() == "")
                {
                    objRepairing.TaxInvoiceDate = NullConstant.DATETIME;
                }
                else 
                {
                    objRepairing.TaxInvoiceDate = dtpTaxDate.Value.Date;
                }
				objRepairing.MaintenanceAmount = decimal.Parse(fpdRepairAmount.Text);
				objRepairing.VatAmount = decimal.Parse(fpdVat.Text);
				objRepairing.TotalAmount = decimal.Parse(fpdTotalAmount.Text);
				
				objRepairing.AReceiver = (Employee)txbReceiverNo.Tag;
				objRepairing.Remark1 = txbRemark1.Text;
				objRepairing.Remark2 = txbRemark2.Text;
				
				objRepairing.ARepairSparePartsList.Clear();
				RepairingSpareParts repairSpareParts;
				for(int i=0; i<fpsRepairList_Sheet1.RowCount; i++)
				{
					repairSpareParts = new RepairingSpareParts();
					repairSpareParts.ASpareParts = formParent.FacadeRepairing.GetSpareParts(fpsRepairList_Sheet1.Cells[i, 1].Text);
					repairSpareParts.Description = fpsRepairList_Sheet1.Cells[i, 2].Text;
					if(programType == PROGRAM_TYPE.ACCIDENT)
					{
						repairSpareParts.ExpenseStatus = CTFunction.GetExpenseStatusType(fpsRepairList_Sheet1.Cells[i, 3].Text);
					}
					else
					{
						repairSpareParts.ExpenseStatus = EXPENSE_STATUS_TYPE.INSURANCE_COMPANY;
					}

					objRepairing.ARepairSparePartsList.Add(repairSpareParts);
				}

                if (chkBPManual.Enabled)
                {
                    if (chkBPManual.Checked)
                    {
                        objRepairing.BPRefNo = BizPacFixData.BIZPAC_DUMMY_REF_NO;
                    }
                    else
                    {
                        objRepairing.BPRefNo = "";
                    }
                }
                else
                {
                    objRepairing.BPRefNo = (string)chkBPManual.Tag;
                }
			}

			protected virtual void fillObjRepairing()
			{			
			}
		#endregion

		//============================== Public Method ==============================
		public virtual void InitAddAction(VehicleInfo value)
		{			
			baseADD();
			initDataSource();
			documentNo = formParent.FacadeRepairing.GetDocumentNo();
			setHeader(documentNo, value);
			enableMaintain(false);
			bindRepair();
			enableExcessForDriver();
			enableMonthPayment(false);

			cboAccidentPlaceText = "";
			cboPoliceStationText = "";
			cboPayerTypeIndex = -1;
			cmbGarageIndex = -1;

			cboPaymentType.SelectedIndex  = 1;
			chkVat.Checked = false;
            enableVatStatus(false);
		}

        public virtual void InitEditAction(RepairingInfoBase value)
		{
			baseEDIT();
			initDataSource();

			objRepairing = value;
			setHeader(value);
			this.setAccident(value);
			setMaintenance(value);
			enableHeader(false);
			enableExcessForDriver();
			if(value.ARepairSparePartsList.Count>0)
			{
				enableMaintain(true);
                chkVat.Enabled = true;
                enableVatStatus(chkVat.Checked);
			}
			else
			{
				enableMaintain(false);
                enableVatStatus(false);
                chkVat.Enabled = false;
			}
			enableExcessForDriverPaid(value);

			if(isReadonly)
			{
				cmdSave.Enabled = false;
			}
		}

		protected void setPermission(bool value)
		{
			isReadonly = value;
		}

		//============================== Base Event ==============================
		private void AddEvent()
		{
			try
			{
				if(validateHeader() && validateAccident() && validateMaintain())
				{
					fillObjRepairing();
					if(FormParent.AddRow(objRepairing))
					{
						this.Close();
					}
				}
			}
			catch(TransactionException ex)
			{
				Message(ex);
			}
			catch(AppExceptionBase ex)
			{
				Message(ex);
			}
			catch(SqlException ex)
			{
				Message(ex);
			}
			catch(Exception ex)
			{
				Message(ex);
			}
		}

		private void EditEvent()
		{
			try
			{
				if(validateHeader() && validateAccident() && validateMaintain())
				{
					fillObjRepairing();
					if(FormParent.EditRow(objRepairing))
					{
						this.Close();
					}
				}
			}
			catch(TransactionException ex)
			{
				Message(ex);
			}
			catch(AppExceptionBase ex)
			{
				Message(ex);
			}
			catch(SqlException ex)
			{
				Message(ex);
			}
			catch(Exception ex)
			{
				Message(ex);
			}
		}

		private void checkPayToCompany()
		{
			if(fpsPayment_Sheet1.RowCount>0)
			{
				int maxYear = 0;
				int maxMonth = 0;

				int tempYear = 0;
				int tempMonth = 0;

				for(int i=0; i<fpsPayment_Sheet1.RowCount; i++)
				{
					if(fpsPayment_Sheet1.Cells[i, 1].Text != "" && fpsPayment_Sheet1.Cells[i, 1].Text != "")
					{
						tempYear = Convert.ToInt32(fpsPayment_Sheet1.Cells[i, 1].Value);
						tempMonth = Convert.ToInt32(fpsPayment_Sheet1.Cells[i, 2].Value);

						if(maxYear < tempYear)
						{
							maxYear = tempYear;
							maxMonth = tempMonth;
						}
						else
						{
							if(maxMonth < tempMonth)
							{
								maxMonth = tempMonth;
							}
						}
					}
				}

				if(maxYear>0 && maxMonth>0)
				{
					DateTime tempDateTime = new DateTime(maxYear, maxMonth, 21); 
					chkPayToCompanyStatus.Checked = true;
					dtpPayToCompanyDate.Value = tempDateTime;
					//					dtpPayToInsuranceDate.Value = tempDateTime;	
				}
			}		
		}

		#region - EmpList -
		private void bindEmployee(empListType value, Employee employee)
		{
			switch(value)
			{
				case empListType.REPORTER : 
				{
					bindReportor(employee);
					break;
				}
				case empListType.EMPLOYEE :
				{
					bindDriver(employee);
					break;
				}
				case empListType.RECEIVER :
				{
					bindReceiver(employee);
					break;
				}
			}
		}

		private void callEmpList(empListType value, string employeeNo)
		{
			try
			{
//				formEmplist.ConditionPositionType.Type = "S";
//				formEmplist.ConditionEmployeeNo = employeeNo;
				formEmplist.ShowDialog();

				if(formEmplist.Selected)
				{
					bindEmployee(value, formEmplist.SelectedServiceStaff);
				}
			}
			catch(SqlException ex)
			{
				Message(ex);
			}
			catch(AppExceptionBase ex)
			{
				Message(ex);
			}
			catch(Exception ex)
			{
				Message(ex);
			}
			finally
			{}
		}

		private bool getEmployee(empListType value, TextBox control)
		{
			try
			{
				if(control.Tag == null)
				{
					Employee employee = FormParent.FacadeRepairing.GetEmployee(control.Text);
					if(employee == null)
					{
						Message(MessageList.Error.E0004, "รหัสพนักงาน");
						control.Focus();
						return false;
					}
					else
					{
						bindEmployee(value, employee);
					}
					employee = null;
				}
				else
				{
					if(((Employee)control.Tag).EmployeeNo == control.Text)
					{
						bindEmployee(value, (Employee)control.Tag);
					}
					else
					{
						Employee employee = FormParent.FacadeRepairing.GetEmployee(control.Text);
						if(employee == null)
						{
							Message(MessageList.Error.E0004, "รหัสพนักงาน");
							control.Focus();
							return false;
						}
						else
						{
							bindEmployee(value, employee);
						}
						employee = null;
					}				
				}
				return true;
			}
			catch(SqlException ex)
			{
				Message(ex);
			}
			catch(AppExceptionBase ex)
			{
				Message(ex);
			}
			catch(Exception ex)
			{
				Message(ex);
			}
			finally
			{}
			return false;
		}

		#endregion

		//==============================     event     ==============================
		private void frmVehicleRepairingEntryBase_Load(object sender, System.EventArgs e)
		{
			grbGarage.Text = strGarage;
			lblGarage.Text = "ชื่อ" + strGarage;
		}

		private void cmdSave_Click(object sender, System.EventArgs e)
		{
			switch (action)
			{
				case ActionType.ADD :
					AddEvent();
					break;
				case ActionType.EDIT :
					EditEvent();
					break;
			}
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		#region - Header -
			#region - Reportor -
			private void txtReportorNo_DoubleClick(object sender, System.EventArgs e)
			{
				callEmpList(empListType.REPORTER, txtReportorNo.Text);
				txbReceiverNo.Tag = (Employee)txtReportorNo.Tag;
				txbReceiverNo.Text = txtReportorNo.Text;
			}

			private void txtReportorNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
			{
				if(txtReportorNo.Text.Trim()=="")
				{
					return;
				}
				if(e.KeyCode == Keys.Enter)
				{
					if(getEmployee(empListType.REPORTER, txtReportorNo))
					{
						txbReceiverNo.Tag = (Employee)txtReportorNo.Tag;
						txbReceiverNo.Text = txtReportorNo.Text;
					}
				}
			}

			private void txtReportorNo_TextChanged(object sender, System.EventArgs e)
			{
				if(txtReportorNo.TextLength == txtReportorNo.MaxLength)
				{
					if(getEmployee(empListType.REPORTER, txtReportorNo))
					{
						txbReceiverNo.Tag = (Employee)txtReportorNo.Tag;
						txbReceiverNo.Text = txtReportorNo.Text;
					}
				}
				else
				{
					txtReportorName.Text = "";
				}
			}
			#endregion

			#region - Driver -
			private void txtEmployeeNo_DoubleClick(object sender, System.EventArgs e)
			{
				callEmpList(empListType.EMPLOYEE, txtEmployeeNo.Text);
			}

			private void txtEmployeeNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
			{
				if(txtEmployeeNo.Text.Trim()=="")
				{
					return;
				}
				if(e.KeyCode == Keys.Enter)
				{
					getEmployee(empListType.EMPLOYEE, txtEmployeeNo);
				}
			}

			private void txtEmployeeNo_TextChanged(object sender, System.EventArgs e)
			{
				if(txtEmployeeNo.TextLength == txtEmployeeNo.MaxLength)
				{
					getEmployee(empListType.EMPLOYEE, txtEmployeeNo);
				}
				else
				{
					txtDriverName.Text = "";
				}
			}

			private void chkPTBDriver_CheckedChanged(object sender, System.EventArgs e)
			{
				if(enableExcessForDriver())
				{
					if(!chkPTBDriver.Checked)
					{
						txtEmployeeNo.Text = "";
						txtDriverName.Text = "";
					}

					txtEmployeeNo.Enabled = chkPTBDriver.Checked;
					txtDriverName.Enabled = !chkPTBDriver.Checked;			
				}
				else
				{
					Message(MessageList.Error.E0020);
				}
				if(chkPTBDriver.Checked)
				{
					txtEmployeeNo.Focus();
				}
			}
			#endregion
		#endregion

		#region - Accident -
			private void chkPayToCompanyStatus_CheckedChanged(object sender, System.EventArgs e)
			{
				dtpPayToCompanyDate.Enabled = chkPayToCompanyStatus.Checked;
				if(chkPayToCompanyStatus.Checked)
				{
				}
				else
				{
					dtpPayToCompanyDate.Value = DateTime.Today;
				}

				if(fpsPayment_Sheet1.RowCount==0)
				{
					if(chkPayToCompanyStatus.Checked)
					{
						fpdExcessPaidAmount.Text = fpdExcessTotalAmount.Text;
					}
					else
					{
						fpdExcessPaidAmount.Value = 0;
					}
					calculateRemain();
				}
			}

			private void chkPayToInsuranceStatus_CheckedChanged(object sender, System.EventArgs e)
			{
				dtpPayToInsuranceDate.Enabled = chkPayToInsuranceStatus.Checked;
				if(chkPayToInsuranceStatus.Checked)
				{
					dtpPayToInsuranceDate.Value = DateTime.Today;
				}
				if(chkPayToInsuranceStatus.Checked && CTFunction.GetPayerType(cboPayerType.Text)==PAYER_TYPE.PTB)
				{
					fpdExcessPaidAmount.Value = fpdExcessTotalAmount.Value;
				}
				else
				{
					fpdExcessPaidAmount.Value = 0;
				}
				calculateRemain();
			}

			private void chkAccessStatus_CheckedChanged(object sender, System.EventArgs e)
			{
				if(!enableExcessForDriver())
				{
					Message(MessageList.Error.E0022);
				}
				if(!chkAccessStatus.Checked && fpsPayment_Sheet1.RowCount>0)
				{
					if (Message(MessageList.Question.Q0007) == DialogResult.Yes)
					{
					}
					else
					{
						chkAccessStatus.Checked =true;					
					}
				}
			}

			private void cboPayerType_SelectedIndexChanged(object sender, System.EventArgs e)
			{
				if(!enableExcessForDriver())
				{
					Message(MessageList.Error.E0020);
				}
			}

			private void btnClaculatePaid_Click(object sender, System.EventArgs e)
			{
				calculatePayment();
				checkPayToCompany();
			}

			private void cmdAddPayment_Click(object sender, System.EventArgs e)
			{
				addPaymentRow();
				checkPayToCompany();
			}

			private void mniPaymentAdd_Click(object sender, System.EventArgs e)
			{
				addPaymentRow();
				checkPayToCompany();
			}

			private void cmdDeletePayment_Click(object sender, System.EventArgs e)
			{
				deletePaymentRow();
				checkPayToCompany();
			}

			private void mniPaymentDelete_Click(object sender, System.EventArgs e)
			{
				deletePaymentRow();
				checkPayToCompany();
			}

			private void chkHasRepair_CheckedChanged(object sender, System.EventArgs e)
			{
				enableMaintain(chkHasRepair.Checked);
                enableVatStatus();
                chkVat.Enabled = chkHasRepair.Checked;

				if(!chkHasRepair.Checked && fpsRepairList_Sheet1.RowCount>0)
				{
					if (Message(MessageList.Question.Q0006) == DialogResult.Yes)
					{
					}
					else
					{
						chkHasRepair.Checked =true;					
					}
				}
			}



			private void fpsPayment_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
			{
				checkPayToCompany();
			}
			
		private void calculateRemain()
		{
			fpdExcessRemainAmount.Value = Convert.ToDecimal(fpdExcessTotalAmount.Value) - Convert.ToDecimal(fpdExcessPaidAmount.Value);
		}

		private void cboAccidentPlace_TextChanged(object sender, System.EventArgs e)
		{
			cboAccidentPlaceText = cboAccidentPlace.Text;
		}

		private void cboPoliceStation_TextChanged(object sender, System.EventArgs e)
		{
			cboPoliceStationText = cboPoliceStation.Text;
		}

		private void cboPayerType_TextChanged(object sender, System.EventArgs e)
		{
			cboPayerTypeIndex = cboPayerType.SelectedIndex;		
		}

		private void fpdExcessTotalAmount_TextChanged(object sender, System.EventArgs e)
		{
			if(chkPayToCompanyStatus.Checked)
			{
				fpdExcessPaidAmount.Value = fpdExcessTotalAmount.Value;
			}
			if(chkPayToInsuranceStatus.Checked && CTFunction.GetPayerType(cboPayerType.Text)==PAYER_TYPE.PTB)
			{
				fpdExcessPaidAmount.Value = fpdExcessTotalAmount.Value;
			}	
			calculateRemain();
		}

		private void fpsPayment_Change(object sender, FarPoint.Win.Spread.ChangeEventArgs e)
		{
			if(e.Column == 4)
			{
				bool locked = (bool)fpsPayment_Sheet1.Cells[e.Row,4].Value;
				fpsPayment_Sheet1.Cells[e.Row,1].Locked = locked;
				fpsPayment_Sheet1.Cells[e.Row,2].Locked = locked;
				fpsPayment_Sheet1.Cells[e.Row,3].Locked = locked;
			}

			if(e.Column == 1 || e.Column == 2)
			{
				string selectedYear = fpsPayment_Sheet1.Cells[e.Row, 1].Text;
				string selectedMonth = fpsPayment_Sheet1.Cells[e.Row, 2].Text;

				for(int i=0; i<fpsPayment_Sheet1.RowCount; i++)
				{
					if(e.Row != i)
					{
						if(selectedYear==fpsPayment_Sheet1.Cells[i, 1].Text && selectedMonth==fpsPayment_Sheet1.Cells[i, 2].Text)
						{
							Message(MessageList.Error.E0038);
							return;
						}
					}
				}
			}
		}

		#endregion

		#region - Maintain -
		private void cmdAddRepairList_Click(object sender, System.EventArgs e)
		{
			addRepairRow();
		}

		private void mniRepairAdd_Click(object sender, System.EventArgs e)
		{
			addRepairRow();
		}

		private void cmdDeleteRepaiList_Click(object sender, System.EventArgs e)
		{
			deleteRepairRow();
		}

		private void mniRepairDelete_Click(object sender, System.EventArgs e)
		{
			deleteRepairRow();
		}

		private void txbReceiverNo_DoubleClick(object sender, System.EventArgs e)
		{
			callEmpList(empListType.RECEIVER, txbReceiverNo.Text);
		}

		private void txbReceiverNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(txbReceiverNo.Text.Trim()=="")
			{
				return;
			}
			if(e.KeyCode == Keys.Enter)
			{
				getEmployee(empListType.RECEIVER, txbReceiverNo);
			}
		}

		private void txbReceiverNo_TextChanged(object sender, System.EventArgs e)
		{
			if(txbReceiverNo.TextLength == txbReceiverNo.MaxLength)
			{
				getEmployee(empListType.RECEIVER, txbReceiverNo);
			}
			else
			{
				txbReceiverName.Text = "";
			}
		}

		private void chkVat_CheckedChanged(object sender, System.EventArgs e)
		{
			calculateVAT();

            if (chkVat.Checked)
            {
                enableVatStatus(true);
            }
            else 
            {
                enableVatStatus(false);
                clearVat();
            }
		}

		private void fpdTotalAmount_TextChanged(object sender, System.EventArgs e)
		{
			calculateVAT();
		}

		private void cmbGarage_TextChanged(object sender, System.EventArgs e)
		{
			cmbGarageIndex = cmbGarage.SelectedIndex;
		}

		private void cmbGarage_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			cmbGarageIndex = cmbGarage.SelectedIndex;

            Garage garage = (Garage)cmbGarage.SelectedItem;
            if (garage != null)
            {
                if (garage.Code == BizPacFixData.BIZPAC_DUMMY_GARAGE_VAT)
                {
                    chkVat.Checked = true;
                    gpbTaxStatus.Enabled = true;
                    rdoTaxStatusYes.Checked = true;
                }
                else if (garage.Code == BizPacFixData.BIZPAC_DUMMY_GARAGE_NONVAT)
                {
                    chkVat.Checked = true;
                    gpbTaxStatus.Enabled = true;
                    rdoTaxStatusNo.Checked = true;
                }
            }
		}
		#endregion

		#region - Paint -
			private void frmVehicleRepairingEntryBase_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
			{
				setCombo();
			}

			protected string cboAccidentPlaceText = "";
			protected string cboPoliceStationText = "";
			protected int cboPayerTypeIndex = -1;
			protected int cmbGarageIndex = -1;

			protected void setCombo()
			{
				cboAccidentPlace.Text = cboAccidentPlaceText;
				cboPoliceStation.Text = cboPoliceStationText;
				cmbGarage.SelectedIndex = cmbGarageIndex;
			}

			private void tabVehicleAccident_SelectedIndexChanged(object sender, System.EventArgs e)
			{
				setCombo();
			}
		#endregion

		private void dtpRepairTo_ValueChanged(object sender, System.EventArgs e)
		{
            //if(dtpRepairTo.Value.Date == DateTime.Today.Date)
            //{
            //    rdbRepairReady.Visible = true;
            //    rdbRepair.Visible = true;
            //}
            //else
            //{
            //    rdbRepairReady.Visible = false;
            //    rdbRepair.Visible = false;
            //}
		}
	}
}