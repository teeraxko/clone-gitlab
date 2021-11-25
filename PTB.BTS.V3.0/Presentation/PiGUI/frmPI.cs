using System;
using System.Collections;
using System.Windows.Forms;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;
using ictus.Common.Entity.General;

using Entity.CommonEntity;

using Facade.PiFacade;
using Facade.CommonFacade;

using Presentation.CommonGUI;
using Presentation.PiGUI.UserControl;

using SystemFramework.AppException;
using SystemFramework.AppMessage;
using SystemFramework.AppConfig;
using Entity.Constants;


namespace Presentation.PiGUI
{
	public class frmPI : EntryFormBase, IMDIChildForm, ISaveForm, IDeleteMDIChildForm
	{
		#region Windows Form Designer generated code
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
					pctEmployee.Image = null;
				}
			}
			base.Dispose( disposing );
		}

		private System.ComponentModel.Container components = null;
		protected System.Windows.Forms.TabControl tabControl1;
		protected System.Windows.Forms.GroupBox groupBox1;
		protected System.Windows.Forms.Label label1;
		protected System.Windows.Forms.Label label3;
		protected System.Windows.Forms.Label label4;
		protected System.Windows.Forms.GroupBox groupBox2;
		protected System.Windows.Forms.GroupBox groupBox3;
		protected System.Windows.Forms.Label label7;
		protected System.Windows.Forms.GroupBox groupBox4;
		protected System.Windows.Forms.Label label18;
		protected System.Windows.Forms.Label label17;
		protected System.Windows.Forms.Label label16;
		protected System.Windows.Forms.Label label15;
		protected System.Windows.Forms.Label label12;
		protected System.Windows.Forms.Label label11;
		protected System.Windows.Forms.Label label10;
		protected System.Windows.Forms.Label label9;
		protected System.Windows.Forms.Label label19;
		protected System.Windows.Forms.Label label20;
		protected System.Windows.Forms.Label label21;
		protected System.Windows.Forms.Label label14;
		protected System.Windows.Forms.Label label8;
		protected System.Windows.Forms.Label label26;
		protected System.Windows.Forms.Label label27;
		protected System.Windows.Forms.Label label28;
		protected System.Windows.Forms.Label label31;
		protected System.Windows.Forms.Label label32;
		protected System.Windows.Forms.Label label34;
		protected System.Windows.Forms.Label label35;
		protected System.Windows.Forms.Label label30;
		protected System.Windows.Forms.Label label36;
		protected System.Windows.Forms.Label label37;
		protected System.Windows.Forms.Label label38;
		protected System.Windows.Forms.Label label39;
		protected System.Windows.Forms.Label label40;
		protected System.Windows.Forms.Label label41;
		protected System.Windows.Forms.Label label43;
		protected System.Windows.Forms.Label label44;
		protected System.Windows.Forms.Label label45;
		protected System.Windows.Forms.Label label47;
        protected System.Windows.Forms.Label label48;
		protected System.Windows.Forms.GroupBox groupBox5;
		protected System.Windows.Forms.GroupBox groupBox6;
		protected System.Windows.Forms.GroupBox groupBox10;
		protected System.Windows.Forms.GroupBox groupBox8;
		protected System.Windows.Forms.GroupBox groupBox12;
		protected System.Windows.Forms.GroupBox groupBox13;
		protected System.Windows.Forms.GroupBox groupBox7;
		protected System.Windows.Forms.Label label114;
		protected System.Windows.Forms.Label label115;
		protected System.Windows.Forms.Label label116;
		protected System.Windows.Forms.GroupBox groupBox15;
		protected System.Windows.Forms.GroupBox groupBox16;
		protected System.Windows.Forms.GroupBox groupBox17;
		protected System.Windows.Forms.GroupBox groupBox18;
		protected System.Windows.Forms.TextBox txtEngSurName;
		protected System.Windows.Forms.TextBox txtThaiSurName;
		protected System.Windows.Forms.ComboBox cboEngPrefix;
		protected System.Windows.Forms.TextBox txtEngName;
		protected System.Windows.Forms.ComboBox cboThaiPrefix;
		protected System.Windows.Forms.TextBox txtThaiName;
		protected System.Windows.Forms.ComboBox cboTitle;
		protected System.Windows.Forms.ComboBox cboWorkingStatus;
		protected System.Windows.Forms.DateTimePicker dtpDriverLicenseExpireDate;
		protected System.Windows.Forms.TextBox txtDriverLicenseNo;
		protected System.Windows.Forms.ComboBox cboMilitaryStatus;
		protected System.Windows.Forms.DateTimePicker dtpIDCardExpireDate;
		protected System.Windows.Forms.TextBox txtTaxIDNo;
		protected System.Windows.Forms.TextBox txtIDCardNo;
		protected System.Windows.Forms.ComboBox cboRace;
		protected System.Windows.Forms.ComboBox cboReligion;
		protected System.Windows.Forms.ComboBox cboGender;
		protected System.Windows.Forms.ComboBox cboMaritalStatus;
		protected System.Windows.Forms.TextBox txtTerminationReason;
		protected System.Windows.Forms.ComboBox cboKindOfStaff;
		protected System.Windows.Forms.Button cmdCopy;
		protected FarPoint.Win.Spread.FpSpread fpsEducation;
		protected FarPoint.Win.Spread.SheetView fpsEducation_Sheet1;
		protected System.Windows.Forms.ComboBox cboSPrefix;
		protected System.Windows.Forms.TextBox txtSSurName;
		protected System.Windows.Forms.ComboBox cboSOccupation;
		protected System.Windows.Forms.TextBox txtSName;
		protected System.Windows.Forms.TextBox txtSTaxIDNo;
		protected System.Windows.Forms.TextBox txtBankAccount;
		protected System.Windows.Forms.ComboBox cboBank;
		protected FarPoint.Win.Input.FpDouble fpdRegular;
		protected FarPoint.Win.Input.FpDouble fpdSpecialAllowance;
		protected FarPoint.Win.Input.FpDouble fpdPositionAllowance;
		protected System.Windows.Forms.ComboBox cboKindOfOT;
		protected System.Windows.Forms.CheckBox chkSAlive;
		protected FarPoint.Win.Spread.FpSpread fpsSpecialAllowance;
		protected FarPoint.Win.Spread.SheetView fpsSpecialAllowance_Sheet1;
		protected System.Windows.Forms.PictureBox pctEmployee;
		protected System.Windows.Forms.DateTimePicker dtpTerminationDate;
		protected System.Windows.Forms.ComboBox cboSection;
		protected System.Windows.Forms.ComboBox cboPostion;
		protected System.Windows.Forms.Label label5;
		protected System.Windows.Forms.ComboBox cboPosition;
		protected System.Windows.Forms.Label label6;
		protected System.Windows.Forms.ComboBox cboSection1;
		protected System.Windows.Forms.ComboBox cboDepartment;
		protected System.Windows.Forms.TabPage tabgerneral;
		protected System.Windows.Forms.TabPage tabaddress;
		protected System.Windows.Forms.TabPage tabexperience;
		protected System.Windows.Forms.TabPage tabpersoncontact;
		protected System.Windows.Forms.TabPage tabfamily;
		protected System.Windows.Forms.TabPage tabincome;
		protected System.Windows.Forms.CheckBox chkSMedicalApply;
		protected System.Windows.Forms.TextBox txtSecurityNo;
		protected FarPoint.Win.Spread.FpSpread fpsWorkingBackGround;
		protected FarPoint.Win.Spread.SheetView fpsWorkingBackGround_Sheet1;
		protected System.Windows.Forms.GroupBox groupBox14;
		public Presentation.PiGUI.UserControl.UCTParent uctParent1;
		public Presentation.PiGUI.UserControl.UCTParent uctParent2;
		public Presentation.PiGUI.UserControl.UCTAddress UCTCurrentAddress;
		public Presentation.PiGUI.UserControl.UCTAddress UCTRegisterAddress;
		public Presentation.PiGUI.UserControl.UCTParent UCTFather;
		public Presentation.PiGUI.UserControl.UCTParent UCTMother;
		public Presentation.PiGUI.UserControl.UCTPerson UCTGuaruntor;
		public Presentation.PiGUI.UserControl.UCTPerson UCTReference;
		public Presentation.PiGUI.UserControl.UCTAddress UCTHAddress;
		public Presentation.PiGUI.UserControl.UCTAddress UCTOAddress;
		protected System.Windows.Forms.ContextMenu education;
		protected System.Windows.Forms.ContextMenu workingbackground;
		protected System.Windows.Forms.ContextMenu children;
		protected System.Windows.Forms.ContextMenu specialallowance;
		public Presentation.PiGUI.UserControl.UCTAge uctAge3;
		protected FarPoint.Win.Spread.FpSpread fpsChildren;
		protected FarPoint.Win.Spread.SheetView fpsChildren_Sheet1;
		protected System.Windows.Forms.MenuItem mniAddEducation;
		protected System.Windows.Forms.MenuItem mniDeleteEducation;
		protected System.Windows.Forms.MenuItem mniAddworkbackground;
		protected System.Windows.Forms.MenuItem mniDeleteworkbackground;
		protected System.Windows.Forms.MenuItem mniAddchildren;
		protected System.Windows.Forms.MenuItem mniDeletechildren;
		protected System.Windows.Forms.MenuItem mniAddSpecialAllowance;
		protected System.Windows.Forms.MenuItem mniDeleteSpecialAllowance;
		protected FarPoint.Win.Input.FpDouble fpdBasicSalary;
		protected System.Windows.Forms.ComboBox cboBloodGroup;
		protected System.Windows.Forms.ComboBox cboNationality;
		protected System.Windows.Forms.TextBox txtEmployeeNo;
		protected System.Windows.Forms.Button cmdCancel;
		protected System.Windows.Forms.Button cmdOK;
		protected System.Windows.Forms.Label label100;
		protected System.Windows.Forms.DateTimePicker dtpRetireDate;
		protected System.Windows.Forms.DateTimePicker dtpBirthdate;
		private System.Windows.Forms.TextBox txtAgeYear;
		private System.Windows.Forms.TextBox txtAgeMonth;
		protected System.Windows.Forms.Label lblMonth;
		protected System.Windows.Forms.Label lblYear;
		protected System.Windows.Forms.Label lbAge;
		private System.Windows.Forms.TextBox txtHireMonth;
		protected System.Windows.Forms.Label label13;
		protected System.Windows.Forms.Label label22;
		private System.Windows.Forms.TextBox txtHireYear;
		protected System.Windows.Forms.Label label23;
		protected System.Windows.Forms.DateTimePicker dtpHireDate;
		private System.Windows.Forms.CheckBox chkDriver;
		protected System.Windows.Forms.ComboBox cboDriverLicenseType;
		protected System.Windows.Forms.Label label33;
		protected System.Windows.Forms.Label label2;
		private Label lblPF01;
        private DateTimePicker dtpPFFrom;
        private DateTimePicker dtpPFTo;
        private GroupBox gpbPF;
        private Label lblPF02;
        private Label lblPFAge;
        private Label lblPFAgeYear;
        private Label lblPFAgeMonth;
        private Label lblPFAgeDay;
        private TextBox txtPFAgeYear;
        private TextBox txtPFAgeMonth;
        private TextBox txtPFAgeDay;
        private FarPoint.Win.Input.FpDouble fpdDiffRetiring;
        private Label lblDiffRetiring;
        private FarPoint.Win.Input.FpDouble fpdEarning;
        private Label lblEarninig;
        private FarPoint.Win.Input.FpDouble fpdMatchingFund;
        private Label lblMatchingFund;
        private FarPoint.Win.Input.FpDouble fpdLSP;
        private Label lblLSP;
        private Label lblMatchingBaht;
        private Label lblEarningBaht;
        private Label lblDiffRetiringBaht;
        private Label lblLSPBaht;
        protected System.Windows.Forms.ComboBox cboHospital;

		protected void InitializeComponent()
		{
			FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
			FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType2 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
			FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType3 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
			FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType4 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
			FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
			FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
			FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
			FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType5 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
			FarPoint.Win.Spread.CellType.NumberCellType numberCellType5 = new FarPoint.Win.Spread.CellType.NumberCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.NumberCellType numberCellType6 = new FarPoint.Win.Spread.CellType.NumberCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType6 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType7 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
			FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPI));
			FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
			FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType2 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
			FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType8 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
			FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType9 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
			FarPoint.Win.Spread.CellType.NumberCellType numberCellType7 = new FarPoint.Win.Spread.CellType.NumberCellType();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabgerneral = new System.Windows.Forms.TabPage();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.gpbPF = new System.Windows.Forms.GroupBox();
            this.lblPF02 = new System.Windows.Forms.Label();
            this.dtpPFFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPF01 = new System.Windows.Forms.Label();
            this.dtpPFTo = new System.Windows.Forms.DateTimePicker();
            this.lblPFAge = new System.Windows.Forms.Label();
            this.lblPFAgeDay = new System.Windows.Forms.Label();
            this.lblPFAgeMonth = new System.Windows.Forms.Label();
            this.lblPFAgeYear = new System.Windows.Forms.Label();
            this.txtPFAgeYear = new System.Windows.Forms.TextBox();
            this.txtPFAgeMonth = new System.Windows.Forms.TextBox();
            this.txtPFAgeDay = new System.Windows.Forms.TextBox();
			this.cboDriverLicenseType = new System.Windows.Forms.ComboBox();
			this.label33 = new System.Windows.Forms.Label();
			this.chkDriver = new System.Windows.Forms.CheckBox();
			this.txtAgeMonth = new System.Windows.Forms.TextBox();
			this.lblMonth = new System.Windows.Forms.Label();
			this.lblYear = new System.Windows.Forms.Label();
			this.txtAgeYear = new System.Windows.Forms.TextBox();
			this.lbAge = new System.Windows.Forms.Label();
			this.dtpBirthdate = new System.Windows.Forms.DateTimePicker();
			this.cboBloodGroup = new System.Windows.Forms.ComboBox();
			this.dtpDriverLicenseExpireDate = new System.Windows.Forms.DateTimePicker();
			this.label34 = new System.Windows.Forms.Label();
			this.txtDriverLicenseNo = new System.Windows.Forms.TextBox();
			this.label32 = new System.Windows.Forms.Label();
			this.cboMilitaryStatus = new System.Windows.Forms.ComboBox();
			this.label28 = new System.Windows.Forms.Label();
			this.dtpIDCardExpireDate = new System.Windows.Forms.DateTimePicker();
			this.txtSecurityNo = new System.Windows.Forms.TextBox();
			this.txtTaxIDNo = new System.Windows.Forms.TextBox();
			this.txtIDCardNo = new System.Windows.Forms.TextBox();
			this.cboNationality = new System.Windows.Forms.ComboBox();
			this.cboRace = new System.Windows.Forms.ComboBox();
			this.cboReligion = new System.Windows.Forms.ComboBox();
			this.cboGender = new System.Windows.Forms.ComboBox();
			this.cboMaritalStatus = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.txtHireMonth = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.txtHireYear = new System.Windows.Forms.TextBox();
			this.label23 = new System.Windows.Forms.Label();
			this.dtpHireDate = new System.Windows.Forms.DateTimePicker();
			this.dtpRetireDate = new System.Windows.Forms.DateTimePicker();
			this.label100 = new System.Windows.Forms.Label();
			this.txtTerminationReason = new System.Windows.Forms.TextBox();
			this.label35 = new System.Windows.Forms.Label();
			this.cboKindOfOT = new System.Windows.Forms.ComboBox();
			this.label31 = new System.Windows.Forms.Label();
			this.dtpTerminationDate = new System.Windows.Forms.DateTimePicker();
			this.label27 = new System.Windows.Forms.Label();
			this.cboKindOfStaff = new System.Windows.Forms.ComboBox();
			this.label26 = new System.Windows.Forms.Label();
			this.cboTitle = new System.Windows.Forms.ComboBox();
			this.cboSection = new System.Windows.Forms.ComboBox();
			this.cboWorkingStatus = new System.Windows.Forms.ComboBox();
			this.cboPosition = new System.Windows.Forms.ComboBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.cboDepartment = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tabexperience = new System.Windows.Forms.TabPage();
			this.groupBox17 = new System.Windows.Forms.GroupBox();
			this.fpsEducation = new FarPoint.Win.Spread.FpSpread();
			this.education = new System.Windows.Forms.ContextMenu();
			this.mniAddEducation = new System.Windows.Forms.MenuItem();
			this.mniDeleteEducation = new System.Windows.Forms.MenuItem();
			this.fpsEducation_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.groupBox18 = new System.Windows.Forms.GroupBox();
			this.fpsWorkingBackGround = new FarPoint.Win.Spread.FpSpread();
			this.workingbackground = new System.Windows.Forms.ContextMenu();
			this.mniAddworkbackground = new System.Windows.Forms.MenuItem();
			this.mniDeleteworkbackground = new System.Windows.Forms.MenuItem();
			this.fpsWorkingBackGround_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.tabaddress = new System.Windows.Forms.TabPage();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.UCTCurrentAddress = new Presentation.PiGUI.UserControl.UCTAddress();
			this.cmdCopy = new System.Windows.Forms.Button();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.UCTRegisterAddress = new Presentation.PiGUI.UserControl.UCTAddress();
			this.tabpersoncontact = new System.Windows.Forms.TabPage();
			this.groupBox13 = new System.Windows.Forms.GroupBox();
			this.UCTGuaruntor = new Presentation.PiGUI.UserControl.UCTPerson();
			this.groupBox12 = new System.Windows.Forms.GroupBox();
			this.UCTReference = new Presentation.PiGUI.UserControl.UCTPerson();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.UCTFather = new Presentation.PiGUI.UserControl.UCTParent();
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.UCTMother = new Presentation.PiGUI.UserControl.UCTParent();
			this.tabfamily = new System.Windows.Forms.TabPage();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.uctAge3 = new Presentation.PiGUI.UserControl.UCTAge();
			this.groupBox16 = new System.Windows.Forms.GroupBox();
			this.fpsChildren = new FarPoint.Win.Spread.FpSpread();
			this.children = new System.Windows.Forms.ContextMenu();
			this.mniAddchildren = new System.Windows.Forms.MenuItem();
			this.mniDeletechildren = new System.Windows.Forms.MenuItem();
			this.fpsChildren_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.chkSMedicalApply = new System.Windows.Forms.CheckBox();
			this.chkSAlive = new System.Windows.Forms.CheckBox();
			this.groupBox14 = new System.Windows.Forms.GroupBox();
			this.UCTHAddress = new Presentation.PiGUI.UserControl.UCTAddress();
			this.groupBox15 = new System.Windows.Forms.GroupBox();
			this.UCTOAddress = new Presentation.PiGUI.UserControl.UCTAddress();
			this.cboSPrefix = new System.Windows.Forms.ComboBox();
			this.txtSSurName = new System.Windows.Forms.TextBox();
			this.label114 = new System.Windows.Forms.Label();
			this.cboSOccupation = new System.Windows.Forms.ComboBox();
			this.label115 = new System.Windows.Forms.Label();
			this.txtSName = new System.Windows.Forms.TextBox();
			this.label116 = new System.Windows.Forms.Label();
			this.tabincome = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblMatchingBaht = new System.Windows.Forms.Label();
            this.lblEarningBaht = new System.Windows.Forms.Label();
            this.lblDiffRetiringBaht = new System.Windows.Forms.Label();
            this.lblLSPBaht = new System.Windows.Forms.Label();
            this.fpdDiffRetiring = new FarPoint.Win.Input.FpDouble();
            this.lblDiffRetiring = new System.Windows.Forms.Label();
            this.fpdEarning = new FarPoint.Win.Input.FpDouble();
            this.lblEarninig = new System.Windows.Forms.Label();
            this.fpdMatchingFund = new FarPoint.Win.Input.FpDouble();
            this.lblMatchingFund = new System.Windows.Forms.Label();
            this.fpdLSP = new FarPoint.Win.Input.FpDouble();
            this.lblLSP = new System.Windows.Forms.Label();
			this.txtSTaxIDNo = new System.Windows.Forms.TextBox();
			this.label47 = new System.Windows.Forms.Label();
			this.label45 = new System.Windows.Forms.Label();
			this.label44 = new System.Windows.Forms.Label();
			this.label43 = new System.Windows.Forms.Label();
			this.label41 = new System.Windows.Forms.Label();
			this.txtBankAccount = new System.Windows.Forms.TextBox();
			this.cboBank = new System.Windows.Forms.ComboBox();
			this.fpdRegular = new FarPoint.Win.Input.FpDouble();
			this.fpdSpecialAllowance = new FarPoint.Win.Input.FpDouble();
			this.fpdPositionAllowance = new FarPoint.Win.Input.FpDouble();
			this.label40 = new System.Windows.Forms.Label();
			this.label39 = new System.Windows.Forms.Label();
			this.label38 = new System.Windows.Forms.Label();
			this.label37 = new System.Windows.Forms.Label();
			this.label36 = new System.Windows.Forms.Label();
			this.fpsSpecialAllowance = new FarPoint.Win.Spread.FpSpread();
			this.specialallowance = new System.Windows.Forms.ContextMenu();
			this.mniAddSpecialAllowance = new System.Windows.Forms.MenuItem();
			this.mniDeleteSpecialAllowance = new System.Windows.Forms.MenuItem();
			this.fpsSpecialAllowance_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.fpdBasicSalary = new FarPoint.Win.Input.FpDouble();
			this.label30 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtEngSurName = new System.Windows.Forms.TextBox();
			this.txtThaiSurName = new System.Windows.Forms.TextBox();
			this.cboEngPrefix = new System.Windows.Forms.ComboBox();
			this.txtEngName = new System.Windows.Forms.TextBox();
			this.cboThaiPrefix = new System.Windows.Forms.ComboBox();
			this.txtThaiName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtEmployeeNo = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.pctEmployee = new System.Windows.Forms.PictureBox();
			this.cboPostion = new System.Windows.Forms.ComboBox();
			this.cboSection1 = new System.Windows.Forms.ComboBox();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
            this.label48 = new System.Windows.Forms.Label();
            this.cboHospital = new System.Windows.Forms.ComboBox();
			this.tabControl1.SuspendLayout();
			this.tabgerneral.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.gpbPF.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.tabexperience.SuspendLayout();
			this.groupBox17.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fpsEducation)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsEducation_Sheet1)).BeginInit();
			this.groupBox18.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fpsWorkingBackGround)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsWorkingBackGround_Sheet1)).BeginInit();
			this.tabaddress.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.tabpersoncontact.SuspendLayout();
			this.groupBox13.SuspendLayout();
			this.groupBox12.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.groupBox10.SuspendLayout();
			this.tabfamily.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupBox16.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fpsChildren)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsChildren_Sheet1)).BeginInit();
			this.groupBox14.SuspendLayout();
			this.groupBox15.SuspendLayout();
			this.tabincome.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fpsSpecialAllowance)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsSpecialAllowance_Sheet1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabgerneral);
			this.tabControl1.Controls.Add(this.tabfamily);
			this.tabControl1.Controls.Add(this.tabexperience);
			this.tabControl1.Controls.Add(this.tabaddress);
			this.tabControl1.Controls.Add(this.tabpersoncontact);
			this.tabControl1.Controls.Add(this.tabincome);
			this.tabControl1.Location = new System.Drawing.Point(16, 104);
			this.tabControl1.Multiline = true;
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(960, 480);
			this.tabControl1.TabIndex = 6;
			// 
			// tabgerneral
			// 
			this.tabgerneral.Controls.Add(this.groupBox4);
			this.tabgerneral.Controls.Add(this.groupBox3);
			this.tabgerneral.Location = new System.Drawing.Point(4, 22);
			this.tabgerneral.Name = "tabgerneral";
			this.tabgerneral.Size = new System.Drawing.Size(952, 454);
			this.tabgerneral.TabIndex = 5;
			this.tabgerneral.Text = "ทั่วไป";
			// 
			// groupBox4
			// 
            this.groupBox4.Controls.Add(this.gpbPF);
			this.groupBox4.Controls.Add(this.cboDriverLicenseType);
			this.groupBox4.Controls.Add(this.label33);
			this.groupBox4.Controls.Add(this.chkDriver);
			this.groupBox4.Controls.Add(this.txtAgeMonth);
			this.groupBox4.Controls.Add(this.lblMonth);
			this.groupBox4.Controls.Add(this.lblYear);
			this.groupBox4.Controls.Add(this.txtAgeYear);
			this.groupBox4.Controls.Add(this.lbAge);
			this.groupBox4.Controls.Add(this.dtpBirthdate);
			this.groupBox4.Controls.Add(this.cboBloodGroup);
			this.groupBox4.Controls.Add(this.dtpDriverLicenseExpireDate);
			this.groupBox4.Controls.Add(this.label34);
			this.groupBox4.Controls.Add(this.txtDriverLicenseNo);
			this.groupBox4.Controls.Add(this.label32);
			this.groupBox4.Controls.Add(this.cboMilitaryStatus);
			this.groupBox4.Controls.Add(this.label28);
			this.groupBox4.Controls.Add(this.dtpIDCardExpireDate);
			this.groupBox4.Controls.Add(this.txtSecurityNo);
			this.groupBox4.Controls.Add(this.txtTaxIDNo);
			this.groupBox4.Controls.Add(this.txtIDCardNo);
			this.groupBox4.Controls.Add(this.cboNationality);
			this.groupBox4.Controls.Add(this.cboRace);
			this.groupBox4.Controls.Add(this.cboReligion);
			this.groupBox4.Controls.Add(this.cboGender);
			this.groupBox4.Controls.Add(this.cboMaritalStatus);
			this.groupBox4.Controls.Add(this.label8);
			this.groupBox4.Controls.Add(this.label20);
			this.groupBox4.Controls.Add(this.label19);
			this.groupBox4.Controls.Add(this.label18);
			this.groupBox4.Controls.Add(this.label17);
			this.groupBox4.Controls.Add(this.label16);
			this.groupBox4.Controls.Add(this.label15);
			this.groupBox4.Controls.Add(this.label12);
			this.groupBox4.Controls.Add(this.label11);
			this.groupBox4.Controls.Add(this.label10);
			this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label48);
            this.groupBox4.Controls.Add(this.cboHospital);
			this.groupBox4.Location = new System.Drawing.Point(8, 192);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(936, 256);
			this.groupBox4.TabIndex = 2;
			this.groupBox4.TabStop = false;
			// 
            // gpbPF
            // 
            this.gpbPF.Controls.Add(this.lblPF02);
            this.gpbPF.Controls.Add(this.dtpPFFrom);
            this.gpbPF.Controls.Add(this.lblPF01);
            this.gpbPF.Controls.Add(this.dtpPFTo);
            this.gpbPF.Controls.Add(this.lblPFAge);
            this.gpbPF.Controls.Add(this.lblPFAgeDay);
            this.gpbPF.Controls.Add(this.lblPFAgeMonth);
            this.gpbPF.Controls.Add(this.lblPFAgeYear);
            this.gpbPF.Controls.Add(this.txtPFAgeYear);
            this.gpbPF.Controls.Add(this.txtPFAgeMonth);
            this.gpbPF.Controls.Add(this.txtPFAgeDay);
            this.gpbPF.Location = new System.Drawing.Point(8, 200);
            this.gpbPF.Name = "gpbPF";
            this.gpbPF.Size = new System.Drawing.Size(544, 48);
            this.gpbPF.TabIndex = 66;
            this.gpbPF.TabStop = false;
            this.gpbPF.Text = "กองทุนสำรองเลี้ยงชีพ";
            // 
            // lblPF02
            // 
            this.lblPF02.AutoSize = true;
            this.lblPF02.Location = new System.Drawing.Point(232, 24);
            this.lblPF02.Name = "lblPF02";
            this.lblPF02.Size = new System.Drawing.Size(10, 13);
            this.lblPF02.TabIndex = 66;
            this.lblPF02.Text = "-";
            // 
            // dtpPFFrom
            // 
            this.dtpPFFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpPFFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPFFrom.Location = new System.Drawing.Point(120, 19);
            this.dtpPFFrom.Name = "dtpPFFrom";
            this.dtpPFFrom.ShowCheckBox = true;
            this.dtpPFFrom.Size = new System.Drawing.Size(104, 20);
            this.dtpPFFrom.TabIndex = 63;
            this.dtpPFFrom.ValueChanged += new EventHandler(this.dtpPF_Changed);
            // 
            // lblPF01
            // 
            this.lblPF01.AutoSize = true;
            this.lblPF01.Location = new System.Drawing.Point(8, 23);
            this.lblPF01.Name = "lblPF01";
            this.lblPF01.Size = new System.Drawing.Size(99, 13);
            this.lblPF01.TabIndex = 64;
            this.lblPF01.Text = "วันที่เข้า-ออกกองทุน";
            // 
            // dtpPFTo
            // 
            this.dtpPFTo.CustomFormat = "dd/MM/yyyy";
            this.dtpPFTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPFTo.Location = new System.Drawing.Point(248, 19);
            this.dtpPFTo.Name = "dtpPFTo";
            this.dtpPFTo.ShowCheckBox = true;
            this.dtpPFTo.Size = new System.Drawing.Size(104, 20);
            this.dtpPFTo.TabIndex = 65;
            this.dtpPFTo.ValueChanged += new EventHandler(this.dtpPF_Changed);
            // 
            // lblPFAge
            // 
            this.lblPFAge.AutoSize = true;
            this.lblPFAge.Location = new System.Drawing.Point(368, 23);
            this.lblPFAge.Name = "lblPFAge";
            this.lblPFAge.Size = new System.Drawing.Size(25, 13);
            this.lblPFAge.TabIndex = 67;
            this.lblPFAge.Text = "อายุ";
            // 
            // lblPFAgeDay
            // 
            this.lblPFAgeDay.AutoSize = true;
            this.lblPFAgeDay.Location = new System.Drawing.Point(520, 23);
            this.lblPFAgeDay.Name = "lblPFAgeDay";
            this.lblPFAgeDay.Size = new System.Drawing.Size(21, 13);
            this.lblPFAgeDay.TabIndex = 68;
            this.lblPFAgeDay.Text = "วัน";
            // 
            // lblPFAgeMonth
            // 
            this.lblPFAgeMonth.AutoSize = true;
            this.lblPFAgeMonth.Location = new System.Drawing.Point(463, 23);
            this.lblPFAgeMonth.Name = "lblPFAgeMonth";
            this.lblPFAgeMonth.Size = new System.Drawing.Size(33, 13);
            this.lblPFAgeMonth.TabIndex = 69;
            this.lblPFAgeMonth.Text = "เดือน";
            // 
            // lblPFAgeYear
            // 
            this.lblPFAgeYear.AutoSize = true;
            this.lblPFAgeYear.Location = new System.Drawing.Point(417, 23);
            this.lblPFAgeYear.Name = "lblPFAgeYear";
            this.lblPFAgeYear.Size = new System.Drawing.Size(14, 13);
            this.lblPFAgeYear.TabIndex = 70;
            this.lblPFAgeYear.Text = "ปี";
            // 
            // txtPFAgeYear
            // 
            this.txtPFAgeYear.Location = new System.Drawing.Point(393, 19);
            this.txtPFAgeYear.Enabled = false;
            this.txtPFAgeYear.Name = "txtPFAgeYear";
            this.txtPFAgeYear.Size = new System.Drawing.Size(24, 20);
            this.txtPFAgeYear.TabIndex = 71;
            // 
            // txtPFAgeMonth
            // 
            this.txtPFAgeMonth.Location = new System.Drawing.Point(439, 19);
            this.txtPFAgeMonth.Enabled = false;
            this.txtPFAgeMonth.Name = "txtPFAgeMonth";
            this.txtPFAgeMonth.Size = new System.Drawing.Size(24, 20);
            this.txtPFAgeMonth.TabIndex = 72;
            // 
            // txtPFAgeDay
            // 
            this.txtPFAgeDay.Location = new System.Drawing.Point(496, 19);
            this.txtPFAgeDay.Enabled = false;
            this.txtPFAgeDay.Name = "txtPFAgeDay";
            this.txtPFAgeDay.Size = new System.Drawing.Size(24, 20);
            this.txtPFAgeDay.TabIndex = 73;
            // 
			// cboDriverLicenseType
			// 
			this.cboDriverLicenseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboDriverLicenseType.Location = new System.Drawing.Point(784, 144);
			this.cboDriverLicenseType.MaxLength = 1;
			this.cboDriverLicenseType.Name = "cboDriverLicenseType";
			this.cboDriverLicenseType.Size = new System.Drawing.Size(104, 21);
			this.cboDriverLicenseType.TabIndex = 61;
            this.cboDriverLicenseType.SelectedIndexChanged += new System.EventHandler(this.controlEmployee_Changed);
			// 
			// label33
			// 
			this.label33.AutoSize = true;
			this.label33.Location = new System.Drawing.Point(728, 144);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(38, 16);
			this.label33.TabIndex = 62;
			this.label33.Text = "ประเภท";
			// 
			// chkDriver
			// 
			this.chkDriver.Location = new System.Drawing.Point(312, 144);
			this.chkDriver.Name = "chkDriver";
			this.chkDriver.TabIndex = 60;
			this.chkDriver.Text = "ใบขับขี่ตลอดชีพ";
			this.chkDriver.CheckedChanged += new System.EventHandler(this.chkDriver_CheckedChanged);
			// 
			// txtAgeMonth
			// 
			this.txtAgeMonth.BackColor = System.Drawing.SystemColors.Control;
			this.txtAgeMonth.ForeColor = System.Drawing.SystemColors.ControlDark;
			this.txtAgeMonth.Location = new System.Drawing.Point(364, 16);
			this.txtAgeMonth.Name = "txtAgeMonth";
			this.txtAgeMonth.Size = new System.Drawing.Size(40, 20);
			this.txtAgeMonth.TabIndex = 59;
			this.txtAgeMonth.Text = "0";
			this.txtAgeMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblMonth
			// 
			this.lblMonth.AutoSize = true;
			this.lblMonth.Location = new System.Drawing.Point(416, 16);
			this.lblMonth.Name = "lblMonth";
			this.lblMonth.Size = new System.Drawing.Size(27, 16);
			this.lblMonth.TabIndex = 58;
			this.lblMonth.Text = "เดือน";
			// 
			// lblYear
			// 
			this.lblYear.AutoSize = true;
			this.lblYear.Location = new System.Drawing.Point(344, 16);
			this.lblYear.Name = "lblYear";
			this.lblYear.Size = new System.Drawing.Size(11, 16);
			this.lblYear.TabIndex = 57;
			this.lblYear.Text = "ปี";
			// 
			// txtAgeYear
			// 
			this.txtAgeYear.BackColor = System.Drawing.SystemColors.Control;
			this.txtAgeYear.ForeColor = System.Drawing.SystemColors.ControlDark;
			this.txtAgeYear.Location = new System.Drawing.Point(296, 16);
			this.txtAgeYear.Name = "txtAgeYear";
			this.txtAgeYear.Size = new System.Drawing.Size(40, 20);
			this.txtAgeYear.TabIndex = 56;
			this.txtAgeYear.Text = "0";
			this.txtAgeYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lbAge
			// 
			this.lbAge.AutoSize = true;
			this.lbAge.Location = new System.Drawing.Point(248, 16);
			this.lbAge.Name = "lbAge";
			this.lbAge.Size = new System.Drawing.Size(21, 16);
			this.lbAge.TabIndex = 55;
			this.lbAge.Text = "อายุ";
			// 
			// dtpBirthdate
			// 
			this.dtpBirthdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpBirthdate.Location = new System.Drawing.Point(128, 16);
			this.dtpBirthdate.Name = "dtpBirthdate";
			this.dtpBirthdate.Size = new System.Drawing.Size(96, 20);
			this.dtpBirthdate.TabIndex = 19;
			this.dtpBirthdate.ValueChanged += new System.EventHandler(this.dtpBirthdate_ValueChanged);
			// 
			// cboBloodGroup
			// 
			this.cboBloodGroup.Location = new System.Drawing.Point(784, 16);
			this.cboBloodGroup.MaxLength = 10;
			this.cboBloodGroup.Name = "cboBloodGroup";
			this.cboBloodGroup.Size = new System.Drawing.Size(104, 21);
			this.cboBloodGroup.TabIndex = 21;
            this.cboBloodGroup.TextChanged += new System.EventHandler(this.controlEmployee_Changed);
            this.cboBloodGroup.SelectedIndexChanged += new System.EventHandler(this.controlEmployee_Changed);
			// 
			// dtpDriverLicenseExpireDate
			// 
			this.dtpDriverLicenseExpireDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpDriverLicenseExpireDate.Location = new System.Drawing.Point(568, 144);
			this.dtpDriverLicenseExpireDate.Name = "dtpDriverLicenseExpireDate";
			this.dtpDriverLicenseExpireDate.Size = new System.Drawing.Size(96, 20);
			this.dtpDriverLicenseExpireDate.TabIndex = 30;
            this.dtpDriverLicenseExpireDate.ValueChanged += new System.EventHandler(this.controlEmployee_Changed);
			// 
			// label34
			// 
			this.label34.AutoSize = true;
			this.label34.Location = new System.Drawing.Point(472, 144);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(53, 16);
			this.label34.TabIndex = 51;
			this.label34.Text = "วันหมดอายุ";
			// 
			// txtDriverLicenseNo
			// 
			this.txtDriverLicenseNo.Location = new System.Drawing.Point(128, 144);
			this.txtDriverLicenseNo.MaxLength = 10;
			this.txtDriverLicenseNo.Name = "txtDriverLicenseNo";
			this.txtDriverLicenseNo.Size = new System.Drawing.Size(152, 20);
			this.txtDriverLicenseNo.TabIndex = 29;
			this.txtDriverLicenseNo.Text = "";
			this.txtDriverLicenseNo.TextChanged += new System.EventHandler(this.txtDriverLicenseNo_TextChanged);
			// 
			// label32
			// 
			this.label32.Location = new System.Drawing.Point(16, 144);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(88, 23);
			this.label32.TabIndex = 47;
			this.label32.Text = "เลขที่ใบขับขี่";
			// 
			// cboMilitaryStatus
			// 
			this.cboMilitaryStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboMilitaryStatus.Location = new System.Drawing.Point(568, 80);
			this.cboMilitaryStatus.MaxLength = 50;
			this.cboMilitaryStatus.Name = "cboMilitaryStatus";
			this.cboMilitaryStatus.Size = new System.Drawing.Size(152, 21);
			this.cboMilitaryStatus.TabIndex = 26;
            this.cboMilitaryStatus.SelectedIndexChanged += new System.EventHandler(this.controlEmployee_Changed);
			// 
			// label28
			// 
			this.label28.Location = new System.Drawing.Point(472, 80);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(88, 16);
			this.label28.TabIndex = 45;
			this.label28.Text = "สถานภาพทหาร";
			// 
			// dtpIDCardExpireDate
			// 
			this.dtpIDCardExpireDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpIDCardExpireDate.Location = new System.Drawing.Point(568, 112);
			this.dtpIDCardExpireDate.Name = "dtpIDCardExpireDate";
			this.dtpIDCardExpireDate.Size = new System.Drawing.Size(96, 20);
			this.dtpIDCardExpireDate.TabIndex = 28;
            this.dtpIDCardExpireDate.ValueChanged += new System.EventHandler(this.controlEmployee_Changed);
			// 
			// txtSecurityNo
			// 
			this.txtSecurityNo.Location = new System.Drawing.Point(415, 176);
			this.txtSecurityNo.MaxLength = 13;
			this.txtSecurityNo.Name = "txtSecurityNo";
			this.txtSecurityNo.Size = new System.Drawing.Size(105, 20);
			this.txtSecurityNo.TabIndex = 33;
			this.txtSecurityNo.Text = "";
            this.txtSecurityNo.TextChanged += new System.EventHandler(this.controlEmployee_Changed);
			// 
			// txtTaxIDNo
			// 
			this.txtTaxIDNo.Location = new System.Drawing.Point(128, 176);
			this.txtTaxIDNo.MaxLength = 13;
			this.txtTaxIDNo.Name = "txtTaxIDNo";
			this.txtTaxIDNo.Size = new System.Drawing.Size(152, 20);
			this.txtTaxIDNo.TabIndex = 32;
			this.txtTaxIDNo.Text = "";
            this.txtTaxIDNo.TextChanged += new System.EventHandler(this.controlEmployee_Changed);
			// 
			// txtIDCardNo
			// 
			this.txtIDCardNo.Location = new System.Drawing.Point(128, 112);
			this.txtIDCardNo.MaxLength = 13;
			this.txtIDCardNo.Name = "txtIDCardNo";
			this.txtIDCardNo.Size = new System.Drawing.Size(152, 20);
			this.txtIDCardNo.TabIndex = 27;
			this.txtIDCardNo.Text = "";
			this.txtIDCardNo.TextChanged += new System.EventHandler(this.txtIDCardNo_TextChanged);
			// 
			// cboNationality
			// 
			this.cboNationality.Location = new System.Drawing.Point(568, 48);
			this.cboNationality.MaxLength = 50;
			this.cboNationality.Name = "cboNationality";
			this.cboNationality.Size = new System.Drawing.Size(104, 21);
			this.cboNationality.TabIndex = 23;
            this.cboNationality.TextChanged += new System.EventHandler(this.controlEmployee_Changed);
            this.cboNationality.SelectedIndexChanged += new System.EventHandler(this.controlEmployee_Changed);
			// 
			// cboRace
			// 
			this.cboRace.Location = new System.Drawing.Point(128, 48);
			this.cboRace.MaxLength = 50;
			this.cboRace.Name = "cboRace";
			this.cboRace.Size = new System.Drawing.Size(96, 21);
			this.cboRace.TabIndex = 22;
            this.cboRace.TextChanged += new System.EventHandler(this.controlEmployee_Changed);
            this.cboRace.SelectedIndexChanged += new System.EventHandler(this.controlEmployee_Changed);
			// 
			// cboReligion
			// 
			this.cboReligion.Location = new System.Drawing.Point(784, 48);
			this.cboReligion.MaxLength = 50;
			this.cboReligion.Name = "cboReligion";
			this.cboReligion.Size = new System.Drawing.Size(104, 21);
			this.cboReligion.TabIndex = 24;
            this.cboReligion.TextChanged += new System.EventHandler(this.controlEmployee_Changed);
            this.cboReligion.SelectedIndexChanged += new System.EventHandler(this.controlEmployee_Changed);
			// 
			// cboGender
			// 
			this.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboGender.Location = new System.Drawing.Point(568, 16);
			this.cboGender.MaxLength = 1;
			this.cboGender.Name = "cboGender";
			this.cboGender.Size = new System.Drawing.Size(104, 21);
			this.cboGender.TabIndex = 20;
            this.cboGender.SelectedIndexChanged += new System.EventHandler(this.controlEmployee_Changed);
			// 
			// cboMaritalStatus
			// 
			this.cboMaritalStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboMaritalStatus.Location = new System.Drawing.Point(128, 80);
			this.cboMaritalStatus.MaxLength = 50;
			this.cboMaritalStatus.Name = "cboMaritalStatus";
			this.cboMaritalStatus.Size = new System.Drawing.Size(152, 21);
			this.cboMaritalStatus.TabIndex = 25;
            this.cboMaritalStatus.SelectedIndexChanged += new System.EventHandler(this.controlEmployee_Changed);
            // 
            // cboHospital
            // 
            this.cboHospital.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHospital.Location = new System.Drawing.Point(663, 176);
            this.cboHospital.MaxLength = 50;
            this.cboHospital.Name = "cboHospital";
            this.cboHospital.Size = new System.Drawing.Size(255, 21);
            this.cboHospital.TabIndex = 34;
            this.cboHospital.SelectedIndexChanged += new System.EventHandler(this.controlEmployee_Changed);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(16, 80);
			this.label8.Name = "label8";
			this.label8.TabIndex = 28;
			this.label8.Text = "สถานภาพสมรส";
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(472, 112);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(64, 16);
			this.label20.TabIndex = 27;
			this.label20.Text = "วันหมดอายุ";
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(472, 16);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(32, 23);
			this.label19.TabIndex = 26;
			this.label19.Text = "เพศ";
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(16, 176);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(104, 23);
			this.label18.TabIndex = 25;
			this.label18.Text = "เลขที่ผู้เสียภาษีอากร";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(16, 112);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(104, 23);
			this.label17.TabIndex = 24;
			this.label17.Text = "เลขที่บัตรประชาชน";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(312, 176);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(96, 16);
			this.label16.TabIndex = 23;
			this.label16.Text = "เลขที่ประกันสังคม";
            // 
            // label48
            // 
            this.label48.Location = new System.Drawing.Point(568, 176);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(96, 16);
            this.label48.TabIndex = 23;
            this.label48.Text = "รพ.ประกันสังคม";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(728, 16);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(56, 23);
			this.label15.TabIndex = 22;
			this.label15.Text = "หมู่โลหิต";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(16, 48);
			this.label12.Name = "label12";
			this.label12.TabIndex = 19;
			this.label12.Text = "เชื้อชาติ";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(472, 48);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(80, 16);
			this.label11.TabIndex = 18;
			this.label11.Text = "สัญชาติ";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(728, 48);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(33, 16);
			this.label10.TabIndex = 17;
			this.label10.Text = "ศาสนา";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(16, 16);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(32, 16);
			this.label9.TabIndex = 16;
			this.label9.Text = "วันเกิด";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.txtHireMonth);
			this.groupBox3.Controls.Add(this.label13);
			this.groupBox3.Controls.Add(this.label22);
			this.groupBox3.Controls.Add(this.txtHireYear);
			this.groupBox3.Controls.Add(this.label23);
			this.groupBox3.Controls.Add(this.dtpHireDate);
			this.groupBox3.Controls.Add(this.dtpRetireDate);
			this.groupBox3.Controls.Add(this.label100);
			this.groupBox3.Controls.Add(this.txtTerminationReason);
			this.groupBox3.Controls.Add(this.label35);
			this.groupBox3.Controls.Add(this.cboKindOfOT);
			this.groupBox3.Controls.Add(this.label31);
			this.groupBox3.Controls.Add(this.dtpTerminationDate);
			this.groupBox3.Controls.Add(this.label27);
			this.groupBox3.Controls.Add(this.cboKindOfStaff);
			this.groupBox3.Controls.Add(this.label26);
			this.groupBox3.Controls.Add(this.cboTitle);
			this.groupBox3.Controls.Add(this.cboSection);
			this.groupBox3.Controls.Add(this.cboWorkingStatus);
			this.groupBox3.Controls.Add(this.cboPosition);
			this.groupBox3.Controls.Add(this.label14);
			this.groupBox3.Controls.Add(this.label21);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.cboDepartment);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Location = new System.Drawing.Point(8, 8);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(936, 184);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			// 
			// txtHireMonth
			// 
			this.txtHireMonth.BackColor = System.Drawing.SystemColors.Control;
			this.txtHireMonth.ForeColor = System.Drawing.SystemColors.ControlDark;
			this.txtHireMonth.Location = new System.Drawing.Point(368, 144);
			this.txtHireMonth.Name = "txtHireMonth";
			this.txtHireMonth.Size = new System.Drawing.Size(40, 20);
			this.txtHireMonth.TabIndex = 65;
			this.txtHireMonth.Text = "0";
			this.txtHireMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(416, 144);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(27, 16);
			this.label13.TabIndex = 64;
			this.label13.Text = "เดือน";
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(344, 144);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(11, 16);
			this.label22.TabIndex = 63;
			this.label22.Text = "ปี";
			// 
			// txtHireYear
			// 
			this.txtHireYear.BackColor = System.Drawing.SystemColors.Control;
			this.txtHireYear.ForeColor = System.Drawing.SystemColors.ControlDark;
			this.txtHireYear.Location = new System.Drawing.Point(296, 144);
			this.txtHireYear.Name = "txtHireYear";
			this.txtHireYear.Size = new System.Drawing.Size(40, 20);
			this.txtHireYear.TabIndex = 62;
			this.txtHireYear.Text = "0";
			this.txtHireYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(248, 144);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(37, 16);
			this.label23.TabIndex = 61;
			this.label23.Text = "อายุงาน";
			// 
			// dtpHireDate
			// 
			this.dtpHireDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpHireDate.Location = new System.Drawing.Point(128, 144);
			this.dtpHireDate.Name = "dtpHireDate";
			this.dtpHireDate.Size = new System.Drawing.Size(96, 20);
			this.dtpHireDate.TabIndex = 60;
			this.dtpHireDate.ValueChanged += new System.EventHandler(this.dtpHireDate_ValueChanged);
			// 
			// dtpRetireDate
			// 
			this.dtpRetireDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpRetireDate.Location = new System.Drawing.Point(616, 144);
			this.dtpRetireDate.Name = "dtpRetireDate";
			this.dtpRetireDate.Size = new System.Drawing.Size(96, 20);
			this.dtpRetireDate.TabIndex = 50;
			// 
			// label100
			// 
			this.label100.AutoSize = true;
			this.label100.Location = new System.Drawing.Point(528, 144);
			this.label100.Name = "label100";
			this.label100.Size = new System.Drawing.Size(64, 16);
			this.label100.TabIndex = 49;
			this.label100.Text = "วันเกษียณอายุ";
			// 
			// txtTerminationReason
			// 
			this.txtTerminationReason.Location = new System.Drawing.Point(616, 112);
			this.txtTerminationReason.MaxLength = 50;
			this.txtTerminationReason.Name = "txtTerminationReason";
			this.txtTerminationReason.Size = new System.Drawing.Size(304, 20);
			this.txtTerminationReason.TabIndex = 17;
			this.txtTerminationReason.Text = "";
            this.txtTerminationReason.TextChanged += new System.EventHandler(this.controlEmployee_Changed);
			// 
			// label35
			// 
			this.label35.Location = new System.Drawing.Point(560, 112);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(48, 23);
			this.label35.TabIndex = 46;
			this.label35.Text = "สาเหตุ";
			// 
			// cboKindOfOT
			// 
			this.cboKindOfOT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboKindOfOT.Location = new System.Drawing.Point(616, 80);
			this.cboKindOfOT.MaxLength = 1;
			this.cboKindOfOT.Name = "cboKindOfOT";
			this.cboKindOfOT.Size = new System.Drawing.Size(168, 21);
			this.cboKindOfOT.TabIndex = 14;
            this.cboKindOfOT.SelectedIndexChanged += new System.EventHandler(this.controlEmployee_Changed);
			// 
			// label31
			// 
			this.label31.Location = new System.Drawing.Point(504, 80);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(104, 23);
			this.label31.TabIndex = 44;
			this.label31.Text = "ประเภทค่าล่วงเวลา";
			// 
			// dtpTerminationDate
			// 
			this.dtpTerminationDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpTerminationDate.Location = new System.Drawing.Point(408, 112);
			this.dtpTerminationDate.Name = "dtpTerminationDate";
			this.dtpTerminationDate.Size = new System.Drawing.Size(96, 20);
			this.dtpTerminationDate.TabIndex = 16;
            this.dtpTerminationDate.ValueChanged += new System.EventHandler(this.controlEmployee_Changed);
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(312, 112);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(96, 23);
			this.label27.TabIndex = 38;
			this.label27.Text = "วันที่มีผลบังคับใช้";
			// 
			// cboKindOfStaff
			// 
			this.cboKindOfStaff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboKindOfStaff.Location = new System.Drawing.Point(128, 80);
			this.cboKindOfStaff.MaxLength = 50;
			this.cboKindOfStaff.Name = "cboKindOfStaff";
			this.cboKindOfStaff.Size = new System.Drawing.Size(152, 21);
			this.cboKindOfStaff.TabIndex = 12;
            this.cboKindOfStaff.SelectedIndexChanged += new System.EventHandler(this.controlEmployee_Changed);
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(16, 80);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(96, 23);
			this.label26.TabIndex = 35;
			this.label26.Text = "ประเภทพนักงาน";
			// 
			// cboTitle
			// 
			this.cboTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboTitle.Location = new System.Drawing.Point(616, 48);
			this.cboTitle.MaxLength = 50;
			this.cboTitle.Name = "cboTitle";
			this.cboTitle.Size = new System.Drawing.Size(304, 21);
			this.cboTitle.TabIndex = 11;
            this.cboTitle.SelectedIndexChanged += new System.EventHandler(this.controlEmployee_Changed);
			// 
			// cboSection
			// 
			this.cboSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboSection.DropDownWidth = 304;
			this.cboSection.Location = new System.Drawing.Point(616, 16);
			this.cboSection.MaxLength = 50;
			this.cboSection.Name = "cboSection";
			this.cboSection.Size = new System.Drawing.Size(304, 21);
			this.cboSection.TabIndex = 9;
            this.cboSection.SelectedIndexChanged += new System.EventHandler(this.controlEmployee_Changed);
			// 
			// cboWorkingStatus
			// 
			this.cboWorkingStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboWorkingStatus.Location = new System.Drawing.Point(128, 112);
			this.cboWorkingStatus.MaxLength = 50;
			this.cboWorkingStatus.Name = "cboWorkingStatus";
			this.cboWorkingStatus.Size = new System.Drawing.Size(152, 21);
			this.cboWorkingStatus.TabIndex = 15;
			this.cboWorkingStatus.SelectedIndexChanged += new System.EventHandler(this.cboWorkingStatus_SelectedIndexChanged);
			// 
			// cboPosition
			// 
			this.cboPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cboPosition.ItemHeight = 13;
			this.cboPosition.Location = new System.Drawing.Point(128, 48);
			this.cboPosition.MaxLength = 50;
			this.cboPosition.Name = "cboPosition";
			this.cboPosition.Size = new System.Drawing.Size(336, 21);
			this.cboPosition.TabIndex = 10;
			this.cboPosition.SelectedIndexChanged += new System.EventHandler(this.cboPosition_SelectedIndexChanged);
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(16, 112);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(112, 23);
			this.label14.TabIndex = 22;
			this.label14.Text = "สถานภาพการทำงาน";
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(16, 144);
			this.label21.Name = "label21";
			this.label21.TabIndex = 16;
			this.label21.Text = "วันเริ่มงาน";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(504, 48);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(88, 23);
			this.label7.TabIndex = 3;
			this.label7.Text = "ตำแหน่ง (Title)";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label6.Location = new System.Drawing.Point(504, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 23);
			this.label6.TabIndex = 2;
			this.label6.Text = "ส่วนงาน";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label5.Location = new System.Drawing.Point(16, 48);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(112, 23);
			this.label5.TabIndex = 1;
			this.label5.Text = "ตำแหน่ง (Position)";
			// 
			// cboDepartment
			// 
			this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cboDepartment.ItemHeight = 13;
			this.cboDepartment.Location = new System.Drawing.Point(128, 16);
			this.cboDepartment.MaxLength = 50;
			this.cboDepartment.Name = "cboDepartment";
			this.cboDepartment.Size = new System.Drawing.Size(336, 21);
			this.cboDepartment.TabIndex = 8;
			this.cboDepartment.SelectedIndexChanged += new System.EventHandler(this.cboDepartment_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label2.Location = new System.Drawing.Point(16, 16);
			this.label2.Name = "label2";
			this.label2.TabIndex = 0;
			this.label2.Text = "ฝ่ายต้นสังกัด";
			// 
			// tabexperience
			// 
			this.tabexperience.Controls.Add(this.groupBox17);
			this.tabexperience.Controls.Add(this.groupBox18);
			this.tabexperience.Location = new System.Drawing.Point(4, 22);
			this.tabexperience.Name = "tabexperience";
			this.tabexperience.Size = new System.Drawing.Size(952, 454);
			this.tabexperience.TabIndex = 3;
			this.tabexperience.Text = "ประวัติการศึกษา - การทำงาน";
			// 
			// groupBox17
			// 
			this.groupBox17.Controls.Add(this.fpsEducation);
			this.groupBox17.Location = new System.Drawing.Point(8, 8);
			this.groupBox17.Name = "groupBox17";
			this.groupBox17.Size = new System.Drawing.Size(960, 184);
			this.groupBox17.TabIndex = 0;
			this.groupBox17.TabStop = false;
			this.groupBox17.Text = "ประวัติการศึกษา";
			// 
			// fpsEducation
			// 
			this.fpsEducation.ContextMenu = this.education;
			this.fpsEducation.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsEducation.Location = new System.Drawing.Point(16, 24);
			this.fpsEducation.Name = "fpsEducation";
			this.fpsEducation.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																					  this.fpsEducation_Sheet1});
			this.fpsEducation.Size = new System.Drawing.Size(912, 144);
			this.fpsEducation.TabIndex = 36;
			this.fpsEducation.Change += new FarPoint.Win.Spread.ChangeEventHandler(this.fpsEducation_Change);
			// 
			// education
			// 
			this.education.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mniAddEducation,
																					  this.mniDeleteEducation});
			// 
			// mniAddEducation
			// 
			this.mniAddEducation.Index = 0;
			this.mniAddEducation.Text = "เพิ่ม";
			this.mniAddEducation.Click += new System.EventHandler(this.mniAddEducation_Click);
			// 
			// mniDeleteEducation
			// 
			this.mniDeleteEducation.Index = 1;
			this.mniDeleteEducation.Text = "ลบ";
			this.mniDeleteEducation.Click += new System.EventHandler(this.mniDeleteEducation_Click);
			// 
			// fpsEducation_Sheet1
			// 
			this.fpsEducation_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsEducation_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsEducation_Sheet1.ColumnCount = 8;
			this.fpsEducation_Sheet1.RowCount = 0;
			this.fpsEducation_Sheet1.ColumnHeader.Cells.Get(0, 0).Text = "สถาบันการศึกษา";
			this.fpsEducation_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "ระดับการศึกษา";
			this.fpsEducation_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "คณะ";
			this.fpsEducation_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "วิชาเอก";
			this.fpsEducation_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "ปีที่เข้ารับการศึกษา";
			this.fpsEducation_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "ปีที่สำเร็จการศึกษา";
			this.fpsEducation_Sheet1.ColumnHeader.Cells.Get(0, 6).Text = "เกรดเฉลี่ย";
			this.fpsEducation_Sheet1.ColumnHeader.Cells.Get(0, 7).Text = "สถานะวุฒิการศึกษา";
			this.fpsEducation_Sheet1.ColumnHeader.Rows.Get(0).Height = 34F;
			this.fpsEducation_Sheet1.Columns.Get(0).AllowAutoSort = true;
			comboBoxCellType1.Editable = true;
			this.fpsEducation_Sheet1.Columns.Get(0).CellType = comboBoxCellType1;
			this.fpsEducation_Sheet1.Columns.Get(0).Label = "สถาบันการศึกษา";
			this.fpsEducation_Sheet1.Columns.Get(0).Width = 159F;
			this.fpsEducation_Sheet1.Columns.Get(1).AllowAutoSort = true;
			comboBoxCellType2.Editable = true;
			this.fpsEducation_Sheet1.Columns.Get(1).CellType = comboBoxCellType2;
			this.fpsEducation_Sheet1.Columns.Get(1).Label = "ระดับการศึกษา";
			this.fpsEducation_Sheet1.Columns.Get(1).Resizable = false;
			this.fpsEducation_Sheet1.Columns.Get(1).Width = 102F;
			this.fpsEducation_Sheet1.Columns.Get(2).AllowAutoSort = true;
			comboBoxCellType3.Editable = true;
			this.fpsEducation_Sheet1.Columns.Get(2).CellType = comboBoxCellType3;
			this.fpsEducation_Sheet1.Columns.Get(2).Label = "คณะ";
			this.fpsEducation_Sheet1.Columns.Get(2).Resizable = false;
			this.fpsEducation_Sheet1.Columns.Get(2).Width = 118F;
			this.fpsEducation_Sheet1.Columns.Get(3).AllowAutoSort = true;
			comboBoxCellType4.Editable = true;
			this.fpsEducation_Sheet1.Columns.Get(3).CellType = comboBoxCellType4;
			this.fpsEducation_Sheet1.Columns.Get(3).Label = "วิชาเอก";
			this.fpsEducation_Sheet1.Columns.Get(3).Resizable = false;
			this.fpsEducation_Sheet1.Columns.Get(3).Width = 106F;
			this.fpsEducation_Sheet1.Columns.Get(4).AllowAutoSort = true;
			numberCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			numberCellType1.DecimalPlaces = 0;
			numberCellType1.DropDownButton = false;
			numberCellType1.MaximumValue = 9999;
			numberCellType1.MinimumValue = 0;
			this.fpsEducation_Sheet1.Columns.Get(4).CellType = numberCellType1;
			this.fpsEducation_Sheet1.Columns.Get(4).Label = "ปีที่เข้ารับการศึกษา";
			this.fpsEducation_Sheet1.Columns.Get(4).Resizable = false;
			this.fpsEducation_Sheet1.Columns.Get(4).Width = 61F;
			this.fpsEducation_Sheet1.Columns.Get(5).AllowAutoSort = true;
			numberCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			numberCellType2.DecimalPlaces = 0;
			numberCellType2.DropDownButton = false;
			numberCellType2.MaximumValue = 9999;
			numberCellType2.MinimumValue = 0;
			this.fpsEducation_Sheet1.Columns.Get(5).CellType = numberCellType2;
			this.fpsEducation_Sheet1.Columns.Get(5).Label = "ปีที่สำเร็จการศึกษา";
			this.fpsEducation_Sheet1.Columns.Get(5).Resizable = false;
			this.fpsEducation_Sheet1.Columns.Get(6).AllowAutoSort = true;
			numberCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			numberCellType3.DecimalPlaces = 2;
			numberCellType3.DecimalSeparator = ".";
			numberCellType3.DropDownButton = false;
			numberCellType3.MaximumValue = 4;
			numberCellType3.MinimumValue = 0;
			this.fpsEducation_Sheet1.Columns.Get(6).CellType = numberCellType3;
			this.fpsEducation_Sheet1.Columns.Get(6).Label = "เกรดเฉลี่ย";
			this.fpsEducation_Sheet1.Columns.Get(6).Resizable = false;
			this.fpsEducation_Sheet1.Columns.Get(7).AllowAutoSort = true;
			comboBoxCellType5.Editable = true;
			this.fpsEducation_Sheet1.Columns.Get(7).CellType = comboBoxCellType5;
			this.fpsEducation_Sheet1.Columns.Get(7).Label = "สถานะวุฒิการศึกษา";
			this.fpsEducation_Sheet1.Columns.Get(7).Resizable = false;
			this.fpsEducation_Sheet1.Columns.Get(7).Width = 188F;
			this.fpsEducation_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsEducation_Sheet1.SheetName = "Sheet1";
			this.fpsEducation_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// groupBox18
			// 
			this.groupBox18.Controls.Add(this.fpsWorkingBackGround);
			this.groupBox18.Location = new System.Drawing.Point(8, 192);
			this.groupBox18.Name = "groupBox18";
			this.groupBox18.Size = new System.Drawing.Size(960, 192);
			this.groupBox18.TabIndex = 1;
			this.groupBox18.TabStop = false;
			this.groupBox18.Text = "ประวัติการทำงาน";
			// 
			// fpsWorkingBackGround
			// 
			this.fpsWorkingBackGround.ContextMenu = this.workingbackground;
			this.fpsWorkingBackGround.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsWorkingBackGround.Location = new System.Drawing.Point(16, 24);
			this.fpsWorkingBackGround.Name = "fpsWorkingBackGround";
			this.fpsWorkingBackGround.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																							  this.fpsWorkingBackGround_Sheet1});
			this.fpsWorkingBackGround.Size = new System.Drawing.Size(912, 144);
			this.fpsWorkingBackGround.TabIndex = 37;
			this.fpsWorkingBackGround.Change += new FarPoint.Win.Spread.ChangeEventHandler(this.fpsWorkingBackGround_Change);
			// 
			// workingbackground
			// 
			this.workingbackground.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							  this.mniAddworkbackground,
																							  this.mniDeleteworkbackground});
			// 
			// mniAddworkbackground
			// 
			this.mniAddworkbackground.Index = 0;
			this.mniAddworkbackground.Text = "เพิ่ม";
			this.mniAddworkbackground.Click += new System.EventHandler(this.mniAddworkbackground_Click);
			// 
			// mniDeleteworkbackground
			// 
			this.mniDeleteworkbackground.Index = 1;
			this.mniDeleteworkbackground.Text = "ลบ";
			this.mniDeleteworkbackground.Click += new System.EventHandler(this.mniDeleteworkbackground_Click);
			// 
			// fpsWorkingBackGround_Sheet1
			// 
			this.fpsWorkingBackGround_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsWorkingBackGround_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsWorkingBackGround_Sheet1.ColumnCount = 6;
			this.fpsWorkingBackGround_Sheet1.RowCount = 0;
			this.fpsWorkingBackGround_Sheet1.ColumnHeader.Cells.Get(0, 0).Text = "บริษัท";
			this.fpsWorkingBackGround_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "ปีที่เริ่มงาน";
			this.fpsWorkingBackGround_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "ปีที่สิ้นสุด";
			this.fpsWorkingBackGround_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ตำแหน่ง";
			this.fpsWorkingBackGround_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "เงินเดือนสุดท้าย";
			this.fpsWorkingBackGround_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "สาเหตุที่ออกจากงาน";
			this.fpsWorkingBackGround_Sheet1.Columns.Get(0).AllowAutoSort = true;
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			textCellType1.MaxLength = 50;
			this.fpsWorkingBackGround_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsWorkingBackGround_Sheet1.Columns.Get(0).Label = "บริษัท";
			this.fpsWorkingBackGround_Sheet1.Columns.Get(0).Resizable = false;
			this.fpsWorkingBackGround_Sheet1.Columns.Get(0).Width = 202F;
			this.fpsWorkingBackGround_Sheet1.Columns.Get(1).AllowAutoSort = true;
			numberCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			numberCellType4.DecimalPlaces = 0;
			numberCellType4.DecimalSeparator = ".";
			numberCellType4.DropDownButton = false;
			numberCellType4.MaximumValue = 9999;
			numberCellType4.MinimumValue = 0;
			this.fpsWorkingBackGround_Sheet1.Columns.Get(1).CellType = numberCellType4;
			this.fpsWorkingBackGround_Sheet1.Columns.Get(1).Label = "ปีที่เริ่มงาน";
			this.fpsWorkingBackGround_Sheet1.Columns.Get(1).ShowSortIndicator = false;
			this.fpsWorkingBackGround_Sheet1.Columns.Get(1).Width = 67F;
			this.fpsWorkingBackGround_Sheet1.Columns.Get(2).AllowAutoSort = true;
			numberCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			numberCellType5.DecimalPlaces = 0;
			numberCellType5.DecimalSeparator = ".";
			numberCellType5.DropDownButton = false;
			numberCellType5.MaximumValue = 9999;
			numberCellType5.MinimumValue = 0;
			this.fpsWorkingBackGround_Sheet1.Columns.Get(2).CellType = numberCellType5;
			this.fpsWorkingBackGround_Sheet1.Columns.Get(2).Label = "ปีที่สิ้นสุด";
			this.fpsWorkingBackGround_Sheet1.Columns.Get(2).ShowSortIndicator = false;
			this.fpsWorkingBackGround_Sheet1.Columns.Get(2).Width = 58F;
			this.fpsWorkingBackGround_Sheet1.Columns.Get(3).AllowAutoSort = true;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			textCellType2.MaxLength = 50;
			this.fpsWorkingBackGround_Sheet1.Columns.Get(3).CellType = textCellType2;
			this.fpsWorkingBackGround_Sheet1.Columns.Get(3).Label = "ตำแหน่ง";
			this.fpsWorkingBackGround_Sheet1.Columns.Get(3).ShowSortIndicator = false;
			this.fpsWorkingBackGround_Sheet1.Columns.Get(3).Width = 207F;
			this.fpsWorkingBackGround_Sheet1.Columns.Get(4).AllowAutoSort = true;
			numberCellType6.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			numberCellType6.DecimalPlaces = 2;
			numberCellType6.DecimalSeparator = ".";
			numberCellType6.DropDownButton = false;
			numberCellType6.MaximumValue = 999999.99;
			numberCellType6.Separator = ",";
			numberCellType6.ShowSeparator = true;
			this.fpsWorkingBackGround_Sheet1.Columns.Get(4).CellType = numberCellType6;
			this.fpsWorkingBackGround_Sheet1.Columns.Get(4).Label = "เงินเดือนสุดท้าย";
			this.fpsWorkingBackGround_Sheet1.Columns.Get(4).ShowSortIndicator = false;
			this.fpsWorkingBackGround_Sheet1.Columns.Get(4).Width = 87F;
			this.fpsWorkingBackGround_Sheet1.Columns.Get(5).AllowAutoSort = true;
			textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType3.DropDownButton = false;
			textCellType3.MaxLength = 50;
			this.fpsWorkingBackGround_Sheet1.Columns.Get(5).CellType = textCellType3;
			this.fpsWorkingBackGround_Sheet1.Columns.Get(5).Label = "สาเหตุที่ออกจากงาน";
			this.fpsWorkingBackGround_Sheet1.Columns.Get(5).Resizable = false;
			this.fpsWorkingBackGround_Sheet1.Columns.Get(5).Width = 227F;
			this.fpsWorkingBackGround_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsWorkingBackGround_Sheet1.SheetName = "Sheet1";
			this.fpsWorkingBackGround_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// tabaddress
			// 
			this.tabaddress.Controls.Add(this.groupBox6);
			this.tabaddress.Controls.Add(this.groupBox5);
			this.tabaddress.Location = new System.Drawing.Point(4, 22);
			this.tabaddress.Name = "tabaddress";
			this.tabaddress.Size = new System.Drawing.Size(952, 454);
			this.tabaddress.TabIndex = 1;
			this.tabaddress.Text = "ที่อยู่";
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.UCTCurrentAddress);
			this.groupBox6.Controls.Add(this.cmdCopy);
			this.groupBox6.Location = new System.Drawing.Point(16, 112);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(928, 144);
			this.groupBox6.TabIndex = 1;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "ที่อยู่ที่ติดต่อได้";
			// 
			// UCTCurrentAddress
			// 
			this.UCTCurrentAddress.AddressLine = "";
			this.UCTCurrentAddress.District = "";
			this.UCTCurrentAddress.FaxNo = "";
			this.UCTCurrentAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.UCTCurrentAddress.Location = new System.Drawing.Point(2, 16);
			this.UCTCurrentAddress.Name = "UCTCurrentAddress";
			this.UCTCurrentAddress.PostalCode = "0";
			this.UCTCurrentAddress.Province = "";
			this.UCTCurrentAddress.Size = new System.Drawing.Size(920, 72);
			this.UCTCurrentAddress.Street = "";
			this.UCTCurrentAddress.SubDistrict = "";
			this.UCTCurrentAddress.TabIndex = 36;
			this.UCTCurrentAddress.Telephone = "";
			// 
			// cmdCopy
			// 
			this.cmdCopy.Location = new System.Drawing.Point(352, 96);
			this.cmdCopy.Name = "cmdCopy";
			this.cmdCopy.Size = new System.Drawing.Size(208, 32);
			this.cmdCopy.TabIndex = 35;
			this.cmdCopy.Text = "คัดลอกจากที่อยู่ตามบัตรประชาชน";
			this.cmdCopy.Click += new System.EventHandler(this.cmdCopy_Click);
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.UCTRegisterAddress);
			this.groupBox5.Location = new System.Drawing.Point(16, 8);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(928, 104);
			this.groupBox5.TabIndex = 0;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "ที่อยู่ตามบัตรประชาชน";
			// 
			// UCTRegisterAddress
			// 
			this.UCTRegisterAddress.AddressLine = "";
			this.UCTRegisterAddress.District = "";
			this.UCTRegisterAddress.FaxNo = "";
			this.UCTRegisterAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.UCTRegisterAddress.Location = new System.Drawing.Point(2, 24);
			this.UCTRegisterAddress.Name = "UCTRegisterAddress";
			this.UCTRegisterAddress.PostalCode = "0";
			this.UCTRegisterAddress.Province = "";
			this.UCTRegisterAddress.Size = new System.Drawing.Size(920, 72);
			this.UCTRegisterAddress.Street = "";
			this.UCTRegisterAddress.SubDistrict = "";
			this.UCTRegisterAddress.TabIndex = 34;
			this.UCTRegisterAddress.Telephone = "";
			// 
			// tabpersoncontact
			// 
			this.tabpersoncontact.Controls.Add(this.groupBox13);
			this.tabpersoncontact.Controls.Add(this.groupBox12);
			this.tabpersoncontact.Controls.Add(this.groupBox8);
			this.tabpersoncontact.Controls.Add(this.groupBox10);
			this.tabpersoncontact.Location = new System.Drawing.Point(4, 22);
			this.tabpersoncontact.Name = "tabpersoncontact";
			this.tabpersoncontact.Size = new System.Drawing.Size(952, 454);
			this.tabpersoncontact.TabIndex = 2;
			this.tabpersoncontact.Text = "บุคคลที่ติดต่อได้";
			// 
			// groupBox13
			// 
			this.groupBox13.Controls.Add(this.UCTGuaruntor);
			this.groupBox13.Location = new System.Drawing.Point(8, 296);
			this.groupBox13.Name = "groupBox13";
			this.groupBox13.Size = new System.Drawing.Size(936, 152);
			this.groupBox13.TabIndex = 5;
			this.groupBox13.TabStop = false;
			this.groupBox13.Text = "ผู้ค้ำประกัน";
			// 
			// UCTGuaruntor
			// 
			this.UCTGuaruntor.Birthdate = new System.DateTime(1899, 12, 30, 0, 0, 0, 0);
			this.UCTGuaruntor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.UCTGuaruntor.Gender = "";
			this.UCTGuaruntor.Location = new System.Drawing.Point(10, 16);
			this.UCTGuaruntor.Name = "UCTGuaruntor";
			this.UCTGuaruntor.Occupation = "";
			this.UCTGuaruntor.RelationShip = "";
			this.UCTGuaruntor.Size = new System.Drawing.Size(920, 128);
			this.UCTGuaruntor.TabIndex = 41;
			this.UCTGuaruntor.ThaiName = "";
			// 
			// groupBox12
			// 
			this.groupBox12.Controls.Add(this.UCTReference);
			this.groupBox12.Location = new System.Drawing.Point(8, 136);
			this.groupBox12.Name = "groupBox12";
			this.groupBox12.Size = new System.Drawing.Size(936, 152);
			this.groupBox12.TabIndex = 4;
			this.groupBox12.TabStop = false;
			this.groupBox12.Text = "บุคคลอ้างอิง";
			// 
			// UCTReference
			// 
			this.UCTReference.Birthdate = new System.DateTime(1899, 12, 30, 0, 0, 0, 0);
			this.UCTReference.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.UCTReference.Gender = "";
			this.UCTReference.Location = new System.Drawing.Point(8, 16);
			this.UCTReference.Name = "UCTReference";
			this.UCTReference.Occupation = "";
			this.UCTReference.RelationShip = "";
			this.UCTReference.Size = new System.Drawing.Size(920, 128);
			this.UCTReference.TabIndex = 40;
			this.UCTReference.ThaiName = "";
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.UCTFather);
			this.groupBox8.Location = new System.Drawing.Point(8, 8);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(456, 120);
			this.groupBox8.TabIndex = 2;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "บิดา";
			// 
			// UCTFather
			// 
			this.UCTFather.Alive = false;
			this.UCTFather.Birthdate = new System.DateTime(1899, 12, 30, 0, 0, 0, 0);
			this.UCTFather.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.UCTFather.Location = new System.Drawing.Point(6, 16);
			this.UCTFather.Name = "UCTFather";
			this.UCTFather.Occupation = "";
			this.UCTFather.Prefix = "";
			this.UCTFather.Size = new System.Drawing.Size(424, 96);
			this.UCTFather.SurName = "";
			this.UCTFather.TabIndex = 38;
			this.UCTFather.ThaiName = "";
			// 
			// groupBox10
			// 
			this.groupBox10.Controls.Add(this.UCTMother);
			this.groupBox10.Location = new System.Drawing.Point(472, 8);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new System.Drawing.Size(472, 120);
			this.groupBox10.TabIndex = 3;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "มารดา";
			// 
			// UCTMother
			// 
			this.UCTMother.Alive = false;
			this.UCTMother.Birthdate = new System.DateTime(1899, 12, 30, 0, 0, 0, 0);
			this.UCTMother.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.UCTMother.Location = new System.Drawing.Point(32, 16);
			this.UCTMother.Name = "UCTMother";
			this.UCTMother.Occupation = "";
			this.UCTMother.Prefix = "";
			this.UCTMother.Size = new System.Drawing.Size(424, 96);
			this.UCTMother.SurName = "";
			this.UCTMother.TabIndex = 39;
			this.UCTMother.ThaiName = "";
			// 
			// tabfamily
			// 
			this.tabfamily.Controls.Add(this.groupBox7);
			this.tabfamily.Location = new System.Drawing.Point(4, 22);
			this.tabfamily.Name = "tabfamily";
			this.tabfamily.Size = new System.Drawing.Size(952, 454);
			this.tabfamily.TabIndex = 0;
			this.tabfamily.Text = "ครอบครัว";
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.uctAge3);
			this.groupBox7.Controls.Add(this.groupBox16);
			this.groupBox7.Controls.Add(this.chkSMedicalApply);
			this.groupBox7.Controls.Add(this.chkSAlive);
			this.groupBox7.Controls.Add(this.groupBox14);
			this.groupBox7.Controls.Add(this.groupBox15);
			this.groupBox7.Controls.Add(this.cboSPrefix);
			this.groupBox7.Controls.Add(this.txtSSurName);
			this.groupBox7.Controls.Add(this.label114);
			this.groupBox7.Controls.Add(this.cboSOccupation);
			this.groupBox7.Controls.Add(this.label115);
			this.groupBox7.Controls.Add(this.txtSName);
			this.groupBox7.Controls.Add(this.label116);
			this.groupBox7.Location = new System.Drawing.Point(8, 8);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(942, 440);
			this.groupBox7.TabIndex = 4;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "คู่สมรส";
			// 
			// uctAge3
			// 
			this.uctAge3.Agemonth = "0";
			this.uctAge3.Ageyear = "0";
			this.uctAge3.Birthday = new System.DateTime(1899, 12, 30, 0, 0, 0, 0);
			this.uctAge3.label = "label";
			this.uctAge3.Location = new System.Drawing.Point(72, 56);
			this.uctAge3.Name = "uctAge3";
			this.uctAge3.Size = new System.Drawing.Size(336, 24);
			this.uctAge3.TabIndex = 46;
			// 
			// groupBox16
			// 
			this.groupBox16.Controls.Add(this.fpsChildren);
			this.groupBox16.Location = new System.Drawing.Point(8, 296);
			this.groupBox16.Name = "groupBox16";
			this.groupBox16.Size = new System.Drawing.Size(928, 128);
			this.groupBox16.TabIndex = 200;
			this.groupBox16.TabStop = false;
			this.groupBox16.Text = "บุตร - ธิดา";
			// 
			// fpsChildren
			// 
			this.fpsChildren.ContextMenu = this.children;
			this.fpsChildren.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsChildren.Location = new System.Drawing.Point(24, 24);
			this.fpsChildren.Name = "fpsChildren";
			this.fpsChildren.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																					 this.fpsChildren_Sheet1});
			this.fpsChildren.Size = new System.Drawing.Size(888, 96);
			this.fpsChildren.TabIndex = 200;
			this.fpsChildren.Change += new FarPoint.Win.Spread.ChangeEventHandler(this.fpsChildren_Change);
			this.fpsChildren.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.fpsChildren_EditChange);
			// 
			// children
			// 
			this.children.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.mniAddchildren,
																					 this.mniDeletechildren});
			// 
			// mniAddchildren
			// 
			this.mniAddchildren.Index = 0;
			this.mniAddchildren.Text = "เพิ่ม";
			this.mniAddchildren.Click += new System.EventHandler(this.mniAddchildren_Click);
			// 
			// mniDeletechildren
			// 
			this.mniDeletechildren.Index = 1;
			this.mniDeletechildren.Text = "ลบ";
			this.mniDeletechildren.Click += new System.EventHandler(this.mniDeletechildren_Click);
			// 
			// fpsChildren_Sheet1
			// 
			this.fpsChildren_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsChildren_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsChildren_Sheet1.ColumnCount = 9;
			this.fpsChildren_Sheet1.RowCount = 1;
			this.fpsChildren_Sheet1.ColumnHeader.Cells.Get(0, 0).Text = "คำนำหน้าชื่อ";
			this.fpsChildren_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "ชื่อ";
			this.fpsChildren_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "สกุล";
			this.fpsChildren_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "เพศ";
			this.fpsChildren_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "วันเกิด";
			this.fpsChildren_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "อายุ";
			this.fpsChildren_Sheet1.ColumnHeader.Cells.Get(0, 6).Text = "ยังมีชีวิต";
			this.fpsChildren_Sheet1.ColumnHeader.Cells.Get(0, 7).Text = "ค่ารักษาพยาบาล";
			this.fpsChildren_Sheet1.ColumnHeader.Cells.Get(0, 8).Text = "อาชีพ";
			this.fpsChildren_Sheet1.ColumnHeader.Rows.Get(0).Height = 32F;
			this.fpsChildren_Sheet1.Columns.Get(0).AllowAutoSort = true;
			comboBoxCellType6.Editable = true;
			this.fpsChildren_Sheet1.Columns.Get(0).CellType = comboBoxCellType6;
			this.fpsChildren_Sheet1.Columns.Get(0).Label = "คำนำหน้าชื่อ";
			this.fpsChildren_Sheet1.Columns.Get(0).Resizable = false;
			this.fpsChildren_Sheet1.Columns.Get(0).Width = 69F;
			this.fpsChildren_Sheet1.Columns.Get(1).AllowAutoSort = true;
			textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType4.DropDownButton = false;
			textCellType4.MaxLength = 50;
			this.fpsChildren_Sheet1.Columns.Get(1).CellType = textCellType4;
			this.fpsChildren_Sheet1.Columns.Get(1).Label = "ชื่อ";
			this.fpsChildren_Sheet1.Columns.Get(1).Resizable = false;
			this.fpsChildren_Sheet1.Columns.Get(1).Width = 128F;
			this.fpsChildren_Sheet1.Columns.Get(2).AllowAutoSort = true;
			textCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType5.DropDownButton = false;
			textCellType5.MaxLength = 50;
			this.fpsChildren_Sheet1.Columns.Get(2).CellType = textCellType5;
			this.fpsChildren_Sheet1.Columns.Get(2).Label = "สกุล";
			this.fpsChildren_Sheet1.Columns.Get(2).Resizable = false;
			this.fpsChildren_Sheet1.Columns.Get(2).Width = 128F;
			this.fpsChildren_Sheet1.Columns.Get(3).AllowAutoSort = true;
			comboBoxCellType7.Editable = true;
			this.fpsChildren_Sheet1.Columns.Get(3).CellType = comboBoxCellType7;
			this.fpsChildren_Sheet1.Columns.Get(3).Label = "เพศ";
			this.fpsChildren_Sheet1.Columns.Get(3).Resizable = false;
			this.fpsChildren_Sheet1.Columns.Get(3).Width = 69F;
			this.fpsChildren_Sheet1.Columns.Get(4).AllowAutoSort = true;
			dateTimeCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			dateTimeCellType1.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
			dateTimeCellType1.DateDefault = new System.DateTime(2005, 10, 17, 9, 2, 43, 0);
			dateTimeCellType1.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
			dateTimeCellType1.DropDownButton = false;
			dateTimeCellType1.TimeDefault = new System.DateTime(2005, 10, 17, 9, 2, 43, 0);
			dateTimeCellType1.UserDefinedFormat = "dd/MM/yyyy";
			this.fpsChildren_Sheet1.Columns.Get(4).CellType = dateTimeCellType1;
			this.fpsChildren_Sheet1.Columns.Get(4).Label = "วันเกิด";
			this.fpsChildren_Sheet1.Columns.Get(4).Resizable = false;
			this.fpsChildren_Sheet1.Columns.Get(4).Width = 76F;
			this.fpsChildren_Sheet1.Columns.Get(5).AllowAutoSort = true;
			textCellType6.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType6.DropDownButton = false;
			textCellType6.ReadOnly = true;
			this.fpsChildren_Sheet1.Columns.Get(5).CellType = textCellType6;
			this.fpsChildren_Sheet1.Columns.Get(5).Label = "อายุ";
			this.fpsChildren_Sheet1.Columns.Get(5).Resizable = false;
			this.fpsChildren_Sheet1.Columns.Get(5).Width = 36F;
			this.fpsChildren_Sheet1.Columns.Get(6).CellType = checkBoxCellType1;
			this.fpsChildren_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsChildren_Sheet1.Columns.Get(6).Label = "ยังมีชีวิต";
			this.fpsChildren_Sheet1.Columns.Get(6).Resizable = false;
			this.fpsChildren_Sheet1.Columns.Get(7).AllowAutoSort = true;
			this.fpsChildren_Sheet1.Columns.Get(7).CellType = checkBoxCellType2;
			this.fpsChildren_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsChildren_Sheet1.Columns.Get(7).Label = "ค่ารักษาพยาบาล";
			this.fpsChildren_Sheet1.Columns.Get(7).Resizable = false;
			this.fpsChildren_Sheet1.Columns.Get(7).Width = 83F;
			this.fpsChildren_Sheet1.Columns.Get(8).AllowAutoSort = true;
			comboBoxCellType8.Editable = true;
			this.fpsChildren_Sheet1.Columns.Get(8).CellType = comboBoxCellType8;
			this.fpsChildren_Sheet1.Columns.Get(8).Label = "อาชีพ";
			this.fpsChildren_Sheet1.Columns.Get(8).Resizable = false;
			this.fpsChildren_Sheet1.Columns.Get(8).Width = 177F;
			this.fpsChildren_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsChildren_Sheet1.SheetName = "Sheet1";
			this.fpsChildren_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// chkSMedicalApply
			// 
			this.chkSMedicalApply.Location = new System.Drawing.Point(744, 56);
			this.chkSMedicalApply.Name = "chkSMedicalApply";
			this.chkSMedicalApply.Size = new System.Drawing.Size(168, 24);
			this.chkSMedicalApply.TabIndex = 48;
			this.chkSMedicalApply.Text = "  มีสิทธิ์เบิกค่ารักษาพยาบาล";
			this.chkSMedicalApply.CheckedChanged += new System.EventHandler(this.controlSpouse_Changed);
			// 
			// chkSAlive
			// 
			this.chkSAlive.Checked = true;
			this.chkSAlive.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkSAlive.Location = new System.Drawing.Point(744, 24);
			this.chkSAlive.Name = "chkSAlive";
			this.chkSAlive.Size = new System.Drawing.Size(88, 24);
			this.chkSAlive.TabIndex = 47;
			this.chkSAlive.Text = "  ยังมีชีวิตอยู่";
			this.chkSAlive.CheckedChanged += new System.EventHandler(this.controlSpouse_Changed);
			// 
			// groupBox14
			// 
			this.groupBox14.Controls.Add(this.UCTHAddress);
			this.groupBox14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.groupBox14.Location = new System.Drawing.Point(8, 88);
			this.groupBox14.Name = "groupBox14";
			this.groupBox14.Size = new System.Drawing.Size(928, 96);
			this.groupBox14.TabIndex = 49;
			this.groupBox14.TabStop = false;
			this.groupBox14.Text = "สถานที่ติดต่อ ( ที่บ้าน )";
			// 
			// UCTHAddress
			// 
			this.UCTHAddress.AddressLine = "";
			this.UCTHAddress.District = "";
			this.UCTHAddress.FaxNo = "";
			this.UCTHAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.UCTHAddress.Location = new System.Drawing.Point(2, 16);
			this.UCTHAddress.Name = "UCTHAddress";
			this.UCTHAddress.PostalCode = "0";
			this.UCTHAddress.Province = "";
			this.UCTHAddress.Size = new System.Drawing.Size(920, 72);
			this.UCTHAddress.Street = "";
			this.UCTHAddress.SubDistrict = "";
			this.UCTHAddress.TabIndex = 49;
			this.UCTHAddress.Telephone = "";
			// 
			// groupBox15
			// 
			this.groupBox15.Controls.Add(this.UCTOAddress);
			this.groupBox15.Location = new System.Drawing.Point(8, 192);
			this.groupBox15.Name = "groupBox15";
			this.groupBox15.Size = new System.Drawing.Size(928, 96);
			this.groupBox15.TabIndex = 50;
			this.groupBox15.TabStop = false;
			this.groupBox15.Text = "สถานที่ติดต่อ ( ที่ทำงาน )";
			// 
			// UCTOAddress
			// 
			this.UCTOAddress.AddressLine = "";
			this.UCTOAddress.District = "";
			this.UCTOAddress.FaxNo = "";
			this.UCTOAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.UCTOAddress.Location = new System.Drawing.Point(2, 16);
			this.UCTOAddress.Name = "UCTOAddress";
			this.UCTOAddress.PostalCode = "0";
			this.UCTOAddress.Province = "";
			this.UCTOAddress.Size = new System.Drawing.Size(912, 72);
			this.UCTOAddress.Street = "";
			this.UCTOAddress.SubDistrict = "";
			this.UCTOAddress.TabIndex = 50;
			this.UCTOAddress.Telephone = "";
			// 
			// cboSPrefix
			// 
			this.cboSPrefix.Location = new System.Drawing.Point(80, 24);
			this.cboSPrefix.MaxLength = 10;
			this.cboSPrefix.Name = "cboSPrefix";
			this.cboSPrefix.Size = new System.Drawing.Size(88, 21);
			this.cboSPrefix.TabIndex = 42;
            this.cboSPrefix.TextChanged += new System.EventHandler(this.controlSpouse_Changed);
            this.cboSPrefix.SelectedIndexChanged += new System.EventHandler(this.controlSpouse_Changed);
			// 
			// txtSSurName
			// 
			this.txtSSurName.Location = new System.Drawing.Point(336, 24);
			this.txtSSurName.MaxLength = 50;
			this.txtSSurName.Name = "txtSSurName";
			this.txtSSurName.Size = new System.Drawing.Size(136, 20);
			this.txtSSurName.TabIndex = 44;
			this.txtSSurName.Text = "";
            this.txtSSurName.TextChanged += new System.EventHandler(this.controlSpouse_Changed);
			// 
			// label114
			// 
			this.label114.Location = new System.Drawing.Point(16, 56);
			this.label114.Name = "label114";
			this.label114.Size = new System.Drawing.Size(40, 23);
			this.label114.TabIndex = 38;
			this.label114.Text = "วันเกิด";
			// 
			// cboSOccupation
			// 
			this.cboSOccupation.Location = new System.Drawing.Point(520, 24);
			this.cboSOccupation.MaxLength = 50;
			this.cboSOccupation.Name = "cboSOccupation";
			this.cboSOccupation.Size = new System.Drawing.Size(160, 21);
			this.cboSOccupation.TabIndex = 45;
			this.cboSOccupation.TextChanged += new System.EventHandler(this.cboSOccupation_TextChanged);
            this.cboSOccupation.SelectedIndexChanged += new System.EventHandler(this.controlSpouse_Changed);
			// 
			// label115
			// 
			this.label115.Location = new System.Drawing.Point(480, 24);
			this.label115.Name = "label115";
			this.label115.Size = new System.Drawing.Size(40, 23);
			this.label115.TabIndex = 36;
			this.label115.Text = "อาชีพ";
			// 
			// txtSName
			// 
			this.txtSName.Location = new System.Drawing.Point(192, 24);
			this.txtSName.MaxLength = 50;
			this.txtSName.Name = "txtSName";
			this.txtSName.Size = new System.Drawing.Size(128, 20);
			this.txtSName.TabIndex = 43;
			this.txtSName.Text = "";
            this.txtSName.TextChanged += new System.EventHandler(this.controlSpouse_Changed);
			// 
			// label116
			// 
			this.label116.Location = new System.Drawing.Point(16, 24);
			this.label116.Name = "label116";
			this.label116.Size = new System.Drawing.Size(56, 23);
			this.label116.TabIndex = 33;
			this.label116.Text = "ชื่อ - สกุล";
			// 
			// tabincome
			// 
			this.tabincome.Controls.Add(this.groupBox2);
			this.tabincome.Location = new System.Drawing.Point(4, 22);
			this.tabincome.Name = "tabincome";
			this.tabincome.Size = new System.Drawing.Size(952, 454);
			this.tabincome.TabIndex = 4;
			this.tabincome.Text = "รายได้";
			// 
			// groupBox2
			// 
            this.groupBox2.Controls.Add(this.lblMatchingBaht);
            this.groupBox2.Controls.Add(this.lblEarningBaht);
            this.groupBox2.Controls.Add(this.lblDiffRetiringBaht);
            this.groupBox2.Controls.Add(this.lblLSPBaht);
            this.groupBox2.Controls.Add(this.fpdDiffRetiring);
            this.groupBox2.Controls.Add(this.lblDiffRetiring);
            this.groupBox2.Controls.Add(this.fpdEarning);
            this.groupBox2.Controls.Add(this.lblEarninig);
            this.groupBox2.Controls.Add(this.fpdMatchingFund);
            this.groupBox2.Controls.Add(this.lblMatchingFund);
            this.groupBox2.Controls.Add(this.fpdLSP);
            this.groupBox2.Controls.Add(this.lblLSP);
			this.groupBox2.Controls.Add(this.txtSTaxIDNo);
			this.groupBox2.Controls.Add(this.label47);
			this.groupBox2.Controls.Add(this.label45);
			this.groupBox2.Controls.Add(this.label44);
			this.groupBox2.Controls.Add(this.label43);
			this.groupBox2.Controls.Add(this.label41);
			this.groupBox2.Controls.Add(this.txtBankAccount);
			this.groupBox2.Controls.Add(this.cboBank);
			this.groupBox2.Controls.Add(this.fpdRegular);
			this.groupBox2.Controls.Add(this.fpdSpecialAllowance);
			this.groupBox2.Controls.Add(this.fpdPositionAllowance);
			this.groupBox2.Controls.Add(this.label40);
			this.groupBox2.Controls.Add(this.label39);
			this.groupBox2.Controls.Add(this.label38);
			this.groupBox2.Controls.Add(this.label37);
			this.groupBox2.Controls.Add(this.label36);
			this.groupBox2.Controls.Add(this.fpsSpecialAllowance);
			this.groupBox2.Controls.Add(this.fpdBasicSalary);
			this.groupBox2.Controls.Add(this.label30);
			this.groupBox2.Location = new System.Drawing.Point(8, 8);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(936, 440);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
            // 
            // lblSubsidyBaht
            // 
            this.lblMatchingBaht.Location = new System.Drawing.Point(768, 168);
            this.lblMatchingBaht.Name = "lblMatchingBaht";
            this.lblMatchingBaht.Size = new System.Drawing.Size(40, 23);
            this.lblMatchingBaht.TabIndex = 71;
            this.lblMatchingBaht.Text = "บาท";
            this.lblMatchingBaht.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBenefitBaht
            // 
            this.lblEarningBaht.Location = new System.Drawing.Point(768, 200);
            this.lblEarningBaht.Name = "lblEarningBaht";
            this.lblEarningBaht.Size = new System.Drawing.Size(40, 23);
            this.lblEarningBaht.TabIndex = 70;
            this.lblEarningBaht.Text = "บาท";
            this.lblEarningBaht.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRetirementBaht
            // 
            this.lblDiffRetiringBaht.Location = new System.Drawing.Point(768, 232);
            this.lblDiffRetiringBaht.Name = "lblDiffRetiringBaht";
            this.lblDiffRetiringBaht.Size = new System.Drawing.Size(40, 23);
            this.lblDiffRetiringBaht.TabIndex = 69;
            this.lblDiffRetiringBaht.Text = "บาท";
            this.lblDiffRetiringBaht.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLSPBaht
            // 
            this.lblLSPBaht.Location = new System.Drawing.Point(768, 136);
            this.lblLSPBaht.Name = "lblLSPBaht";
            this.lblLSPBaht.Size = new System.Drawing.Size(40, 23);
            this.lblLSPBaht.TabIndex = 68;
            this.lblLSPBaht.Text = "บาท";
            this.lblLSPBaht.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fpdRetirement
            // 
            this.fpdDiffRetiring.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdDiffRetiring.AllowClipboardKeys = true;
            this.fpdDiffRetiring.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdDiffRetiring.DecimalPlaces = 2;
            this.fpdDiffRetiring.DecimalSeparator = ".";
            this.fpdDiffRetiring.FixedPoint = true;
            this.fpdDiffRetiring.Location = new System.Drawing.Point(664, 233);
            this.fpdDiffRetiring.Name = "fpdDiffRetiring";
            this.fpdDiffRetiring.NumberGroupSeparator = ",";
            this.fpdDiffRetiring.Size = new System.Drawing.Size(88, 20);
            this.fpdDiffRetiring.TabIndex = 67;
            this.fpdDiffRetiring.Text = "";
            this.fpdDiffRetiring.UseSeparator = true;
            this.fpdDiffRetiring.TextChanged += new System.EventHandler(this.controlSalary_Changed);
            // 
            // lblRetirement
            // 
            this.lblDiffRetiring.Location = new System.Drawing.Point(488, 232);
            this.lblDiffRetiring.Name = "lblDiffRetiring";
            this.lblDiffRetiring.Size = new System.Drawing.Size(160, 23);
            this.lblDiffRetiring.TabIndex = 66;
            this.lblDiffRetiring.Text = "ส่วนต่างเงินบำเหน็จ";
            this.lblDiffRetiring.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fpdBenefit
            // 
            this.fpdEarning.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdEarning.AllowClipboardKeys = true;
            this.fpdEarning.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdEarning.DecimalPlaces = 2;
            this.fpdEarning.DecimalSeparator = ".";
            this.fpdEarning.FixedPoint = true;
            this.fpdEarning.Location = new System.Drawing.Point(664, 201);
            this.fpdEarning.Name = "fpdEarning";
            this.fpdEarning.NumberGroupSeparator = ",";
            this.fpdEarning.Size = new System.Drawing.Size(88, 20);
            this.fpdEarning.TabIndex = 65;
            this.fpdEarning.Text = "";
            this.fpdEarning.UseSeparator = true;
            this.fpdEarning.TextChanged += new System.EventHandler(this.controlSalary_Changed);
            // 
            // lblBenefit
            // 
            this.lblEarninig.Location = new System.Drawing.Point(488, 200);
            this.lblEarninig.Name = "lblEarninig";
            this.lblEarninig.Size = new System.Drawing.Size(160, 23);
            this.lblEarninig.TabIndex = 64;
            this.lblEarninig.Text = "ผลประโยชน์ PF";
            this.lblEarninig.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fpdSubsidy
            // 
            this.fpdMatchingFund.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdMatchingFund.AllowClipboardKeys = true;
            this.fpdMatchingFund.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdMatchingFund.DecimalPlaces = 2;
            this.fpdMatchingFund.DecimalSeparator = ".";
            this.fpdMatchingFund.FixedPoint = true;
            this.fpdMatchingFund.Location = new System.Drawing.Point(664, 169);
            this.fpdMatchingFund.Name = "fpdMatchingFund";
            this.fpdMatchingFund.NumberGroupSeparator = ",";
            this.fpdMatchingFund.Size = new System.Drawing.Size(88, 20);
            this.fpdMatchingFund.TabIndex = 63;
            this.fpdMatchingFund.Text = "";
            this.fpdMatchingFund.UseSeparator = true;
            this.fpdMatchingFund.TextChanged += new System.EventHandler(this.controlSalary_Changed);
            // 
            // lblSubsidy
            // 
            this.lblMatchingFund.Location = new System.Drawing.Point(488, 168);
            this.lblMatchingFund.Name = "lblMatchingFund";
            this.lblMatchingFund.Size = new System.Drawing.Size(160, 23);
            this.lblMatchingFund.TabIndex = 62;
            this.lblMatchingFund.Text = "เงินสมทบ PF";
            this.lblMatchingFund.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fpdLSP
            // 
            this.fpdLSP.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdLSP.AllowClipboardKeys = true;
            this.fpdLSP.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdLSP.DecimalPlaces = 2;
            this.fpdLSP.DecimalSeparator = ".";
            this.fpdLSP.FixedPoint = true;
            this.fpdLSP.Location = new System.Drawing.Point(664, 137);
            this.fpdLSP.Name = "fpdLSP";
            this.fpdLSP.NumberGroupSeparator = ",";
            this.fpdLSP.Size = new System.Drawing.Size(88, 20);
            this.fpdLSP.TabIndex = 61;
            this.fpdLSP.Text = "";
            this.fpdLSP.UseSeparator = true;
            this.fpdLSP.TextChanged += new System.EventHandler(this.controlSalary_Changed);
            // 
            // lblLSP
            // 
            this.lblLSP.Location = new System.Drawing.Point(488, 136);
            this.lblLSP.Name = "lblLSP";
            this.lblLSP.Size = new System.Drawing.Size(160, 23);
            this.lblLSP.TabIndex = 60;
            this.lblLSP.Text = "เงินชดเชยตามกฏหมายแรงงาน";
            this.lblLSP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSTaxIDNo
            // 
            this.txtSTaxIDNo.Enabled = false;
            this.txtSTaxIDNo.Location = new System.Drawing.Point(664, 81);
            this.txtSTaxIDNo.MaxLength = 13;
            this.txtSTaxIDNo.Name = "txtSTaxIDNo";
            this.txtSTaxIDNo.Size = new System.Drawing.Size(152, 20);
            this.txtSTaxIDNo.TabIndex = 57;
            this.txtSTaxIDNo.TextChanged += new System.EventHandler(this.controlEmployee_Changed);
            // 
            // label47
            // 
            this.label47.Location = new System.Drawing.Point(544, 80);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(104, 23);
            this.label47.TabIndex = 40;
            this.label47.Text = "เลขที่ผู้เสียภาษีอากร";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label45
            // 
            this.label45.Location = new System.Drawing.Point(360, 16);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(40, 23);
            this.label45.TabIndex = 17;
            this.label45.Text = "บาท";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label44
            // 
            this.label44.Location = new System.Drawing.Point(360, 48);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(40, 23);
            this.label44.TabIndex = 16;
            this.label44.Text = "บาท";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label43
            // 
            this.label43.Location = new System.Drawing.Point(360, 80);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(40, 23);
            this.label43.TabIndex = 15;
            this.label43.Text = "บาท";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label41
            // 
            this.label41.Location = new System.Drawing.Point(360, 288);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(40, 23);
            this.label41.TabIndex = 13;
            this.label41.Text = "บาท";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtBankAccount
			// 
			this.txtBankAccount.Location = new System.Drawing.Point(664, 48);
			this.txtBankAccount.MaxLength = 10;
			this.txtBankAccount.Name = "txtBankAccount";
			this.txtBankAccount.Size = new System.Drawing.Size(152, 20);
			this.txtBankAccount.TabIndex = 56;
			this.txtBankAccount.Text = "";
            this.txtBankAccount.TextChanged += new System.EventHandler(this.controlSalary_Changed);
			// 
			// cboBank
			// 
			this.cboBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboBank.Location = new System.Drawing.Point(664, 16);
			this.cboBank.MaxLength = 50;
			this.cboBank.Name = "cboBank";
			this.cboBank.Size = new System.Drawing.Size(208, 21);
			this.cboBank.TabIndex = 55;
            this.cboBank.TextChanged += new System.EventHandler(this.controlSalary_Changed);
            // 
            // fpdRegular
            // 
            this.fpdRegular.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdRegular.AllowClipboardKeys = true;
            this.fpdRegular.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdRegular.DecimalPlaces = 2;
            this.fpdRegular.DecimalSeparator = ".";
            this.fpdRegular.Enabled = false;
            this.fpdRegular.FixedPoint = true;
            this.fpdRegular.Location = new System.Drawing.Point(256, 288);
            this.fpdRegular.Name = "fpdRegular";
            this.fpdRegular.NumberGroupSeparator = ",";
            this.fpdRegular.Size = new System.Drawing.Size(88, 20);
            this.fpdRegular.TabIndex = 59;
            this.fpdRegular.Text = "";
            this.fpdRegular.UseSeparator = true;
            this.fpdRegular.TextChanged += new System.EventHandler(this.controlSalary_Changed);
			// 
			// fpdSpecialAllowance
			// 
			this.fpdSpecialAllowance.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
			this.fpdSpecialAllowance.AllowClipboardKeys = true;
			this.fpdSpecialAllowance.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.fpdSpecialAllowance.DecimalPlaces = 2;
			this.fpdSpecialAllowance.DecimalSeparator = ".";
			this.fpdSpecialAllowance.FixedPoint = true;
			this.fpdSpecialAllowance.Location = new System.Drawing.Point(256, 80);
			this.fpdSpecialAllowance.Name = "fpdSpecialAllowance";
			this.fpdSpecialAllowance.NumberGroupSeparator = ",";
			this.fpdSpecialAllowance.Size = new System.Drawing.Size(88, 20);
			this.fpdSpecialAllowance.TabIndex = 54;
			this.fpdSpecialAllowance.Text = "";
			this.fpdSpecialAllowance.UseSeparator = true;
			this.fpdSpecialAllowance.TextChanged += new System.EventHandler(this.fpdSpecialAllowance_TextChanged);
			// 
			// fpdPositionAllowance
			// 
			this.fpdPositionAllowance.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
			this.fpdPositionAllowance.AllowClipboardKeys = true;
			this.fpdPositionAllowance.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.fpdPositionAllowance.DecimalPlaces = 2;
			this.fpdPositionAllowance.DecimalSeparator = ".";
			this.fpdPositionAllowance.Enabled = false;
			this.fpdPositionAllowance.FixedPoint = true;
			this.fpdPositionAllowance.Location = new System.Drawing.Point(256, 48);
			this.fpdPositionAllowance.Name = "fpdPositionAllowance";
			this.fpdPositionAllowance.NumberGroupSeparator = ",";
			this.fpdPositionAllowance.Size = new System.Drawing.Size(88, 20);
			this.fpdPositionAllowance.TabIndex = 53;
			this.fpdPositionAllowance.Text = "";
			this.fpdPositionAllowance.UseSeparator = true;
			this.fpdPositionAllowance.TextChanged += new System.EventHandler(this.fpdPositionAllowance_TextChanged);
            // 
            // label40
            // 
            this.label40.Location = new System.Drawing.Point(64, 288);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(176, 23);
            this.label40.TabIndex = 7;
            this.label40.Text = "เงินได้รวมต่อเดือน  ( Regular )";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label39
            // 
            this.label39.Location = new System.Drawing.Point(552, 16);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(96, 23);
            this.label39.TabIndex = 6;
            this.label39.Text = "ธนาคาร";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label38
            // 
            this.label38.Location = new System.Drawing.Point(552, 48);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(96, 23);
            this.label38.TabIndex = 5;
            this.label38.Text = "เลขที่บัญชี";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label37
            // 
            this.label37.Location = new System.Drawing.Point(32, 80);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(208, 23);
            this.label37.TabIndex = 4;
            this.label37.Text = "เงินได้พิเศษ  ( Special Allowance )";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(24, 48);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(216, 23);
            this.label36.TabIndex = 3;
            this.label36.Text = "เงินประจำตำแหน่ง ( Position Allowance )";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// fpsSpecialAllowance
			// 
			this.fpsSpecialAllowance.ContextMenu = this.specialallowance;
			this.fpsSpecialAllowance.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsSpecialAllowance.Location = new System.Drawing.Point(24, 128);
			this.fpsSpecialAllowance.Name = "fpsSpecialAllowance";
			this.fpsSpecialAllowance.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																							 this.fpsSpecialAllowance_Sheet1});
			this.fpsSpecialAllowance.Size = new System.Drawing.Size(368, 136);
			this.fpsSpecialAllowance.TabIndex = 58;
			this.fpsSpecialAllowance.Change += new FarPoint.Win.Spread.ChangeEventHandler(this.fpsSpecialAllowance_Change);
			this.fpsSpecialAllowance.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.fpsSpecialAllowance_EditChange);
			// 
			// specialallowance
			// 
			this.specialallowance.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							 this.mniAddSpecialAllowance,
																							 this.mniDeleteSpecialAllowance});
			// 
			// mniAddSpecialAllowance
			// 
			this.mniAddSpecialAllowance.Index = 0;
			this.mniAddSpecialAllowance.Text = "เพิ่ม";
			this.mniAddSpecialAllowance.Click += new System.EventHandler(this.mniAddSpecialAllowance_Click);
			// 
			// mniDeleteSpecialAllowance
			// 
			this.mniDeleteSpecialAllowance.Index = 1;
			this.mniDeleteSpecialAllowance.Text = "ลบ";
			this.mniDeleteSpecialAllowance.Click += new System.EventHandler(this.mniDeleteSpecialAllowance_Click);
			// 
			// fpsSpecialAllowance_Sheet1
			// 
			this.fpsSpecialAllowance_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsSpecialAllowance_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsSpecialAllowance_Sheet1.ColumnCount = 2;
			this.fpsSpecialAllowance_Sheet1.RowCount = 0;
			this.fpsSpecialAllowance_Sheet1.ColumnHeader.Cells.Get(0, 0).Text = "หมวดเงินได้พิเศษ";
			this.fpsSpecialAllowance_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "จำนวนเงิน";
			this.fpsSpecialAllowance_Sheet1.Columns.Get(0).AllowAutoSort = true;
			comboBoxCellType9.Editable = true;
			comboBoxCellType9.MaxDrop = 10;
			comboBoxCellType9.MaxLength = 100;
			this.fpsSpecialAllowance_Sheet1.Columns.Get(0).CellType = comboBoxCellType9;
			this.fpsSpecialAllowance_Sheet1.Columns.Get(0).Label = "หมวดเงินได้พิเศษ";
			this.fpsSpecialAllowance_Sheet1.Columns.Get(0).Resizable = false;
			this.fpsSpecialAllowance_Sheet1.Columns.Get(0).Width = 235F;
			this.fpsSpecialAllowance_Sheet1.Columns.Get(1).AllowAutoSort = true;
			numberCellType7.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			numberCellType7.DecimalPlaces = 2;
			numberCellType7.DecimalSeparator = ".";
			numberCellType7.DropDownButton = false;
			numberCellType7.MaximumValue = 1000000;
			numberCellType7.MinimumValue = 0;
			numberCellType7.Separator = ",";
			numberCellType7.ShowSeparator = true;
			this.fpsSpecialAllowance_Sheet1.Columns.Get(1).CellType = numberCellType7;
			this.fpsSpecialAllowance_Sheet1.Columns.Get(1).Label = "จำนวนเงิน";
			this.fpsSpecialAllowance_Sheet1.Columns.Get(1).Resizable = false;
			this.fpsSpecialAllowance_Sheet1.Columns.Get(1).Width = 72F;
			this.fpsSpecialAllowance_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsSpecialAllowance_Sheet1.SheetName = "Sheet1";
			this.fpsSpecialAllowance_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // fpdBasicSalary
            // 
            this.fpdBasicSalary.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpdBasicSalary.AllowClipboardKeys = true;
            this.fpdBasicSalary.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpdBasicSalary.DecimalPlaces = 2;
            this.fpdBasicSalary.DecimalSeparator = ".";
            this.fpdBasicSalary.FixedPoint = true;
            this.fpdBasicSalary.Location = new System.Drawing.Point(256, 16);
            this.fpdBasicSalary.Name = "fpdBasicSalary";
            this.fpdBasicSalary.NumberGroupSeparator = ",";
            this.fpdBasicSalary.Size = new System.Drawing.Size(88, 20);
            this.fpdBasicSalary.TabIndex = 52;
            this.fpdBasicSalary.Text = "";
            this.fpdBasicSalary.UseSeparator = true;
            this.fpdBasicSalary.TextChanged += new System.EventHandler(this.fpdBasicSalary_TextChanged);
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(48, 16);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(192, 23);
            this.label30.TabIndex = 0;
            this.label30.Text = "เงินเดือน ( Basic Salary )";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtEngSurName);
			this.groupBox1.Controls.Add(this.txtThaiSurName);
			this.groupBox1.Controls.Add(this.cboEngPrefix);
			this.groupBox1.Controls.Add(this.txtEngName);
			this.groupBox1.Controls.Add(this.cboThaiPrefix);
			this.groupBox1.Controls.Add(this.txtThaiName);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtEmployeeNo);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(16, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(824, 80);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// txtEngSurName
			// 
			this.txtEngSurName.Location = new System.Drawing.Point(616, 48);
			this.txtEngSurName.MaxLength = 50;
			this.txtEngSurName.Name = "txtEngSurName";
			this.txtEngSurName.Size = new System.Drawing.Size(200, 20);
			this.txtEngSurName.TabIndex = 7;
			this.txtEngSurName.Text = "";
            this.txtEngSurName.TextChanged += new System.EventHandler(this.controlEmployee_Changed);
			// 
			// txtThaiSurName
			// 
			this.txtThaiSurName.Location = new System.Drawing.Point(616, 16);
			this.txtThaiSurName.MaxLength = 50;
			this.txtThaiSurName.Name = "txtThaiSurName";
			this.txtThaiSurName.Size = new System.Drawing.Size(200, 20);
			this.txtThaiSurName.TabIndex = 4;
			this.txtThaiSurName.Text = "";
            this.txtThaiSurName.TextChanged += new System.EventHandler(this.controlEmployee_Changed);
			// 
			// cboEngPrefix
			// 
			this.cboEngPrefix.Location = new System.Drawing.Point(312, 48);
			this.cboEngPrefix.MaxLength = 10;
			this.cboEngPrefix.Name = "cboEngPrefix";
			this.cboEngPrefix.Size = new System.Drawing.Size(80, 21);
			this.cboEngPrefix.TabIndex = 5;
            this.cboEngPrefix.TextChanged += new System.EventHandler(this.controlEmployee_Changed);
            this.cboEngPrefix.SelectedIndexChanged += new System.EventHandler(this.controlEmployee_Changed);
			// 
			// txtEngName
			// 
			this.txtEngName.Location = new System.Drawing.Point(424, 48);
			this.txtEngName.MaxLength = 50;
			this.txtEngName.Name = "txtEngName";
			this.txtEngName.Size = new System.Drawing.Size(168, 20);
			this.txtEngName.TabIndex = 6;
			this.txtEngName.Text = "";
            this.txtEngName.TextChanged += new System.EventHandler(this.controlEmployee_Changed);
			// 
			// cboThaiPrefix
			// 
			this.cboThaiPrefix.Location = new System.Drawing.Point(312, 16);
			this.cboThaiPrefix.MaxLength = 10;
			this.cboThaiPrefix.Name = "cboThaiPrefix";
			this.cboThaiPrefix.Size = new System.Drawing.Size(80, 21);
			this.cboThaiPrefix.TabIndex = 2;
            this.cboThaiPrefix.TextChanged += new System.EventHandler(this.controlEmployee_Changed);
            this.cboThaiPrefix.SelectedIndexChanged += new System.EventHandler(this.controlEmployee_Changed);
			// 
			// txtThaiName
			// 
			this.txtThaiName.Location = new System.Drawing.Point(424, 16);
			this.txtThaiName.MaxLength = 50;
			this.txtThaiName.Name = "txtThaiName";
			this.txtThaiName.Size = new System.Drawing.Size(168, 20);
			this.txtThaiName.TabIndex = 3;
			this.txtThaiName.Text = "";
            this.txtThaiName.TextChanged += new System.EventHandler(this.controlEmployee_Changed);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(184, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(120, 23);
			this.label4.TabIndex = 4;
			this.label4.Text = "ชื่อ - สกุล ภาษาอังกฤษ";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(184, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 23);
			this.label3.TabIndex = 3;
			this.label3.Text = "ชื่อ - สกุล ภาษาไทย";
			// 
			// txtEmployeeNo
			// 
			this.txtEmployeeNo.AllowDrop = true;
			this.txtEmployeeNo.Location = new System.Drawing.Point(112, 16);
			this.txtEmployeeNo.MaxLength = 5;
			this.txtEmployeeNo.Name = "txtEmployeeNo";
			this.txtEmployeeNo.Size = new System.Drawing.Size(64, 20);
			this.txtEmployeeNo.TabIndex = 1;
			this.txtEmployeeNo.Text = "";
			this.txtEmployeeNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmployeeNo_KeyDown);
			this.txtEmployeeNo.TextChanged += new System.EventHandler(this.txtEmployeeNo_TextChanged);
			this.txtEmployeeNo.DoubleClick += new System.EventHandler(this.txtEmployeeNo_DoubleClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "รหัสพนักงาน";
			// 
			// pctEmployee
			// 
			this.pctEmployee.Location = new System.Drawing.Point(880, 8);
			this.pctEmployee.Name = "pctEmployee";
			this.pctEmployee.Size = new System.Drawing.Size(88, 104);
			this.pctEmployee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pctEmployee.TabIndex = 2;
			this.pctEmployee.TabStop = false;
			// 
			// cboPostion
			// 
			this.cboPostion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPostion.Location = new System.Drawing.Point(688, 16);
			this.cboPostion.MaxLength = 50;
			this.cboPostion.Name = "cboPostion";
			this.cboPostion.Size = new System.Drawing.Size(112, 21);
			this.cboPostion.TabIndex = 16;
			// 
			// cboSection1
			// 
			this.cboSection1.Location = new System.Drawing.Point(648, 64);
			this.cboSection1.Name = "cboSection1";
			this.cboSection1.Size = new System.Drawing.Size(144, 21);
			this.cboSection1.TabIndex = 0;
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(499, 592);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 7;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.Location = new System.Drawing.Point(419, 592);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 8;
			this.cmdOK.Text = "บันทึก";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// frmPI
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(992, 630);
			this.Controls.Add(this.pctEmployee);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.MaximizeBox = true;
			this.Name = "frmPI";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmPI_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabgerneral.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.gpbPF.ResumeLayout(false);
            this.gpbPF.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.tabexperience.ResumeLayout(false);
			this.groupBox17.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fpsEducation)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsEducation_Sheet1)).EndInit();
			this.groupBox18.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fpsWorkingBackGround)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsWorkingBackGround_Sheet1)).EndInit();
			this.tabaddress.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.tabpersoncontact.ResumeLayout(false);
			this.groupBox13.ResumeLayout(false);
			this.groupBox12.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			this.groupBox10.ResumeLayout(false);
			this.tabfamily.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.groupBox16.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fpsChildren)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsChildren_Sheet1)).EndInit();
			this.groupBox14.ResumeLayout(false);
			this.groupBox15.ResumeLayout(false);
			this.tabincome.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fpsSpecialAllowance)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsSpecialAllowance_Sheet1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - Selected Farpoint - 
		#region - Private Education - 
		private int SelectedRowEducation
		{
			get
			{
				return fpsEducation_Sheet1.ActiveRowIndex;
			}
		}

		private string SelectedKeyEducation
		{
			get
			{
				return fpsEducation_Sheet1.Cells[SelectedRowEducation,0].Text;
			}
		}

		private Education SelectedEducation
		{
			get
			{
				return facadePI.EmployeeEducation[SelectedKeyEducation];
			}
		}
		#endregion

		#region - Private Workbackground - 
		private int SelectedRowWorkbackground
		{
			get
			{
				return fpsWorkingBackGround_Sheet1.ActiveRowIndex;
			}
		}

		private string SelectedKeyWorkbackground
		{
			get
			{
				return fpsWorkingBackGround_Sheet1.Cells[SelectedRowWorkbackground,0].Text;
			}
		}

		private WorkBackground SelectedWorkBackground
		{
			get
			{
				return facadePI.EmployeeWorkBackground[SelectedKeyWorkbackground];
			}
		}
		#endregion

		#region - Private Children - 
		private int SelectedRowChildren
		{
			get
			{
				return fpsChildren_Sheet1.ActiveRowIndex;
			}
		}

		private string SelectedKeyChildren
		{
			get
			{
				return fpsChildren_Sheet1.Cells[SelectedRowChildren,0].Text;
			}
		}

		private EmployeeChildren SelectedChildren
		{
			get
			{
				return facadePI.EmployeeChildrenList[SelectedKeyChildren];
			}
		}
		#endregion

		#region - Private SpecialAllowance - 
		private int SelectedRowSpecialAllowance
		{
			get
			{
				return fpsSpecialAllowance_Sheet1.ActiveRowIndex;
			}
		}

		private string SelectedKeySpecialAllowance
		{
			get
			{
				return fpsSpecialAllowance_Sheet1.Cells[SelectedRowSpecialAllowance,0].Text;
			}
		}

		private SpecialAllowance SelectedSpecialAllowance
		{
			get
			{
				return facadePI.EmployeeSpecialAllowance[SelectedKeySpecialAllowance];
			}
		}
		#endregion
		#endregion

		#region - private -
		protected PIFacade facadePI;
		protected bool visibleOK;
		protected frmMain mdiParent;
		private FormerFacade facadeFormer;
		private bool isReadonly = true;
		private bool isHireDateChange = false;
		private string DriverLicenseNo;
		#endregion

        #region Protected Method
        protected virtual void Title()
        {
            this.Text = UserProfile.GetFormName("miPI", "miPIEmployeePI");
        }
        protected virtual void TitleEdit()
        {
            this.Text = "แก้ไข" + UserProfile.GetFormName("miPI", "miPIEmployeePI");
        }

        protected virtual void BaseNew()
        {
            facadePI = new PIFacade();
            setDataSource();
            visibleOK = true;
        }

        protected virtual void setDataSource()
        {
            setDataSourceAddress(UCTCurrentAddress);
            setDataSourceAddress(UCTRegisterAddress);
            UCTCurrentAddress.HasMobile = true;
            UCTRegisterAddress.HasMobile = true;

            setDataSourceParent(UCTFather);
            setDataSourceParent(UCTMother);
            setDataSourcePerson(UCTReference);
            setDataSourcePerson(UCTGuaruntor);
            setDataSourceAddress(UCTHAddress);
            setDataSourceAddress(UCTOAddress);

            //employee
            cboThaiPrefix.DataSource = facadePI.DataSourcePrefix;
            cboEngPrefix.DataSource = facadePI.DataSourcePrefix;

            //ทั่วไป1
            cboDepartment.Items.Clear();
            setDataSource(cboDepartment, facadePI.DataSourceDepartment);
            cboPosition.Items.Clear();
            setDataSource(cboPosition, facadePI.DataSourcePosition);
            cboTitle.Items.Clear();
            setDataSource(cboTitle, facadePI.DataSourceTitle);
            cboKindOfStaff.Items.Clear();
            setDataSource(cboKindOfStaff, facadePI.DataSourceKinddOfStaff);
            cboKindOfOT.Items.Clear();
            setDataSource(cboKindOfOT, facadePI.DataSourceKindOfOT);
            cboGender.Items.Clear();
            setDataSource(cboGender, facadePI.DataSourceGender);
            cboWorkingStatus.Items.Clear();
            setDataSource(cboWorkingStatus, facadePI.DataSourceWorkingStatus);

            cboNationality.DataSource = facadePI.DataSourceNationality;
            cboReligion.DataSource = facadePI.DataSourceReligion;
            cboBloodGroup.DataSource = facadePI.DataSourceBloodGroup;
            cboRace.DataSource = facadePI.DataSourceRace;

            cboMaritalStatus.Items.Clear();
            setDataSource(cboMaritalStatus, facadePI.DataSourceMaritalStatus);
            cboMilitaryStatus.Items.Clear();
            setDataSource(cboMilitaryStatus, facadePI.DataSourceMilitaryStatus);
            cboSPrefix.Items.Clear();
            setDataSource(cboSPrefix, facadePI.DataSourcePrefix);
            cboSOccupation.Items.Clear();
            setDataSource(cboSOccupation, facadePI.DataSourceOccupation);
            cboDriverLicenseType.Items.Clear();
            setDataSource(cboDriverLicenseType, facadePI.DataSourceDriverLicenseType);
            cboBank.Items.Clear();
            setDataSource(cboBank, facadePI.DataSourceBank);
            cboHospital.Items.Clear();
            setDataSource(cboHospital, facadePI.DataSourceSSHospital);

            fpsEducation_Sheet1.Columns[0].CellType = facadePI.DataSourceInstitute;
            fpsEducation_Sheet1.Columns[1].CellType = facadePI.DataSourceEducationlevel;
            fpsEducation_Sheet1.Columns[2].CellType = facadePI.DataSourceFaculty;
            fpsEducation_Sheet1.Columns[3].CellType = facadePI.DataSourceMajor;
            fpsEducation_Sheet1.Columns[7].CellType = facadePI.DataSourceEducationStatus;

            fpsChildren_Sheet1.Columns[0].CellType = facadePI.DataSourcePrefixSpouse;
            fpsChildren_Sheet1.Columns[3].CellType = facadePI.DataSourceGenderSpouse;
            fpsChildren_Sheet1.Columns[8].CellType = facadePI.DataSourceOccupationSpouse;

            fpsSpecialAllowance_Sheet1.Columns[0].CellType = facadePI.DataSourceSpecialAllowance;
        }
        #endregion

        #region Constructor
        public frmPI()
            : base()
        {
            InitializeComponent();
            facadeFormer = new FormerFacade();
            BaseNew();
            isReadonly = UserProfile.IsReadOnly("miPI", "miPIEmployeePI");
        } 
        #endregion

		#region - private method -
		#region - bind farpoint -
		private void bindEducation(int row,Education aEducation)
		{
			//			fpsEducation_Sheet1.Cells[row,0].Text = aEducation.EntityKey;
			fpsEducation_Sheet1.Cells[row,0].Text = aEducation.AInstitute.AName.Thai;
			fpsEducation_Sheet1.Cells[row,1].Text = aEducation.AEducationLevel.AName.Thai;
			fpsEducation_Sheet1.Cells[row,2].Text = aEducation.AFaculty.AName.Thai;
			fpsEducation_Sheet1.Cells[row,3].Text = aEducation.AMajor.AName.Thai;
			fpsEducation_Sheet1.Cells[row,4].Text = GUIFunction.GetString(aEducation.YearIn);
			fpsEducation_Sheet1.Cells[row,5].Text = GUIFunction.GetString(aEducation.YearGraduate);
			fpsEducation_Sheet1.Cells[row,6].Text = GUIFunction.GetString(aEducation.Gpa);
			fpsEducation_Sheet1.Cells[row,7].Text = GUIFunction.GetString(aEducation.Status);
		}

		private void bindfpsEducation()
		{
			if (facadePI.EmployeeEducation != null)
			{
				int iRow = facadePI.EmployeeEducation.Count;
				fpsEducation_Sheet1.RowCount = iRow;
				for(int i=0; i<iRow; i++)
				{
					bindEducation(i,facadePI.EmployeeEducation[i]);
				}				
			}
		}
		private void bindWorkBackground(int row,WorkBackground aWorkBackground)
		{
			//			fpsWorkingBackGround_Sheet1.Cells[row,0].Text = aWorkBackground.EntityKey;
			fpsWorkingBackGround_Sheet1.Cells[row,0].Text = aWorkBackground.ACompany.Thai;
			fpsWorkingBackGround_Sheet1.Cells[row,1].Text = GUIFunction.GetString(aWorkBackground.FromYear);
			fpsWorkingBackGround_Sheet1.Cells[row,2].Text = GUIFunction.GetString(aWorkBackground.ToYear);
			fpsWorkingBackGround_Sheet1.Cells[row,3].Text = aWorkBackground.PositionName;
			fpsWorkingBackGround_Sheet1.Cells[row,4].Text = GUIFunction.GetString(aWorkBackground.LatestSalary);
			fpsWorkingBackGround_Sheet1.Cells[row,5].Text = aWorkBackground.ResignReason;
		}
		private void bindfpsWorkBackground()
		{
			if (facadePI.EmployeeWorkBackground != null)
			{
				int iRow = facadePI.EmployeeWorkBackground.Count;
				fpsWorkingBackGround_Sheet1.RowCount = iRow;
				for(int i=0; i<iRow; i++)
				{
					bindWorkBackground(i,facadePI.EmployeeWorkBackground[i]);
				}				
			}
		}
		private void bindChildren(int row,EmployeeChildren aEmployeeChildren)
		{
			fpsChildren_Sheet1.Cells[row,0].Text = aEmployeeChildren.APrefix.Thai;
			fpsChildren_Sheet1.Cells[row,1].Text = aEmployeeChildren.AName.Thai;
			fpsChildren_Sheet1.Cells[row,2].Text = aEmployeeChildren.ASurname.Thai;
			fpsChildren_Sheet1.Cells[row,3].Text = GUIFunction.GetString(aEmployeeChildren.Gender);
            fpsChildren_Sheet1.Cells[row, 4].Value = aEmployeeChildren.BirthDate.Date;

            string age = facadePI.CalculateAgeDecimal(aEmployeeChildren.BirthDate);
			fpsChildren_Sheet1.Cells[row,5].Text = age;

			fpsChildren_Sheet1.Cells[row,6].Value = aEmployeeChildren.Alive;
			fpsChildren_Sheet1.Cells[row,7].Value = aEmployeeChildren.ApplyMedical;
			fpsChildren_Sheet1.Cells[row,8].Text = aEmployeeChildren.AOccupation.Name;
		}
		private void bindfpsChildren()
		{
			if (facadePI.EmployeeChildrenList != null)
			{
				int iRow = facadePI.EmployeeChildrenList.Count;
				fpsChildren_Sheet1.RowCount = iRow;
				for(int i=0; i<iRow; i++)
				{
					bindChildren(i,facadePI.EmployeeChildrenList[i]);
				}				
			}
		}
		private void bindSpecialallowance(int row,SpecialAllowance aSpecialAllowance)
		{
			//			fpsSpecialAllowance_Sheet1.Cells[row,0].Text = aSpecialAllowance.EntityKey;
			fpsSpecialAllowance_Sheet1.Cells[row,0].Text = aSpecialAllowance.AName.Thai;
			fpsSpecialAllowance_Sheet1.Cells[row,1].Text = GUIFunction.GetString(aSpecialAllowance.Amount);
		}
		private void bindfpsSpecialallowance()
		{
			if (facadePI.EmployeeSpecialAllowance != null)
			{
				int iRow = facadePI.EmployeeSpecialAllowance.Count;
				fpsSpecialAllowance_Sheet1.RowCount = iRow;
				for(int i=0; i<iRow; i++)
				{
					bindSpecialallowance(i,facadePI.EmployeeSpecialAllowance[i]);
				}				
			}
		}
		#endregion

		#region - set UCT -
		private void setDataSource(ComboBox control, ArrayList dataSource)
		{
			for(int i=0; i<dataSource.Count; i++)
			{
				control.Items.Add(dataSource[i]);
			}
		}
				
		private void setDataSource(ComboBox control, string[] dataSource)
		{
			for(int i=0; i<dataSource.Length; i++)
			{
				control.Items.Add(dataSource[i]);
			}
		}
		
		private Address getUCTAddress(UCTAddress control)
		{
			Address address = new Address();
			address.AddressLine = control.AddressLine;
			address.StreetName.Name = control.Street;
			address.Tambon.Name = control.SubDistrict;
			address.District.Name = control.District;
			address.Province.Name = control.Province;
			address.PostalCode = control.PostalCode;
			address.AContactInfo.Telephone = control.Telephone;
			address.AContactInfo.Fax = control.FaxNo;
            address.AContactInfo.Mobile = control.Mobile;
			return address;
		}

		private void setUCTAddress(UCTAddress control, Address value)
		{
			control.AddressLine = value.AddressLine ;
			control.Street = value.StreetName.Name;
			control.SubDistrict = value.Tambon.Name;
			control.District = value.District.Name;
			control.Province = value.Province.Name;
			control.PostalCode = value.PostalCode;
			control.Telephone = value.AContactInfo.Telephone;
			control.FaxNo = value.AContactInfo.Fax;
            control.Mobile = value.AContactInfo.Mobile;
		}

		private void setDataSourceAddress(UCTAddress control)
		{
			control.StreetDatasource = facadePI.DataSourceStreet;
			control.SubDistrictDatasource = facadePI.DataSourceSubDistrict;
			control.DistrictDatasource = facadePI.DataSourceDistrict;
			control.ProvinceDatasource = facadePI.DataSourceProvince;
		}

		private void getUCTParent(UCTParent control, EmployeeParentBase aEmployeeParentBase)
		{
			aEmployeeParentBase.APrefix.Thai = control.Prefix;
			aEmployeeParentBase.AName.Thai = control.ThaiName;
			aEmployeeParentBase.ASurname.Thai = control.SurName;
			aEmployeeParentBase.AOccupation.Name = control.Occupation;
			aEmployeeParentBase.Alive = control.Alive;
			aEmployeeParentBase.BirthDate = control.Birthdate;
			//			if(control.Birthdate == NullConstant.DATETIME)
			//			{
			//				aEmployeeParentBase.BirthDate = NullConstant.DATETIME;
			//			}
			//			else
			//			{
			//				aEmployeeParentBase.BirthDate = control.Birthdate;
			//			}
		}

		private void setUCTParent(UCTParent control, EmployeeParentBase value)
		{
			control.Prefix = value.APrefix.Thai ;
			control.ThaiName = value.AName.Thai;
			control.SurName = value.ASurname.Thai;
			control.Occupation = value.AOccupation.Name;
			control.Alive = value.Alive;			
			if(value.BirthDate == NullConstant.DATETIME)
			{
				control.Birthdate = DateTime.Today;
				control.BirthDateChecked(false);
			}
			else
			{
				control.Birthdate = value.BirthDate;
				control.BirthDateChecked(true);
			}
		}

		private void setDataSourceParent(UCTParent control)
		{
			control.PrefixDatasource = facadePI.DataSourcePrefix;
			control.OccupationDatasource = facadePI.DataSourceOccupation;
		}

		private ReferencePerson getUCTPerson(UCTPerson control)
		{
			ReferencePerson person = new ReferencePerson();
			person.AName.Thai = control.ThaiName; 
			person.AOccupation.Name = control.Occupation;
			person.ARelationship.Name = control.RelationShip;
			person.BirthDate = control.Birthdate;
			person.Gender = CTFunction.GetGenderType(control.Gender);
			person.ACurrentAddress = getUCTAddress(control.uctAddress1);
			//			if(control.Birthdate == NullConstant.DATETIME)
			//			{
			//				person.BirthDate = NullConstant.DATETIME;
			//			}
			//			else
			//			{
			//				person.BirthDate = control.Birthdate;
			//			}
			return person;
		}

		private void setUCTPerson(UCTPerson control, ReferencePerson value)
		{
			control.ThaiName = value.AName.Thai;
			control.Occupation = value.AOccupation.Name;
			control.RelationShip = value.ARelationship.Name;
			control.Birthdate = value.BirthDate;
			control.Gender = CTFunction.GetString(value.Gender);
			setUCTAddress(control.uctAddress1, value.ACurrentAddress);

			if(value.BirthDate == NullConstant.DATETIME)
			{
				control.Birthdate = DateTime.Today;
				control.BirthDateChecked(false);
			}
			else
			{
				control.Birthdate = value.BirthDate;
				control.BirthDateChecked(true);
			}
		}
		private void setDataSourcePerson(UCTPerson control)
		{
			control.OccupationDatasource = facadePI.DataSourceOccupation;
			control.RelationShipDatasource = facadePI.DataSourceRelationShip;
			control.GenderDatasource = facadePI.DataSourceGender;
			setDataSourceAddress(control.uctAddress1);
		}
		
		#endregion

		protected virtual void nullException(EmpNotFoundException ex)
		{
			ex = null;
		}

		private void CalculateSpecialAllowance()
		{
			double a = (double)fpdBasicSalary.Value;
			double b = (double)fpdPositionAllowance.Value;
			double c = (double)fpdSpecialAllowance.Value;
			fpdRegular.Text = Convert.ToString(a + b +c );
			facadePI.SalaryChange = true;
			
		}

		private void CalculateSpecialAllowanceAddRow()
		{
			try
			{				
				decimal result = 0;
				int iRow = fpsSpecialAllowance_Sheet1.RowCount;
				for(int i = 0; i < iRow;i++)
				{
					result += Convert.ToDecimal(fpsSpecialAllowance_Sheet1.Cells[i,1].Text);
					fpdSpecialAllowance.Text = Convert.ToString(result);
				}	
				
					
			}
			catch(Exception ex)
			{
				Message(ex);
			}
		}
		
        private void CalculateSpecialAllowanceDeleteRow()
		{
			try
			{		
				if(fpsSpecialAllowance_Sheet1.Cells[0, 0].Text != "")
				{
					decimal result = Convert.ToDecimal(fpdSpecialAllowance.Text);
					result -= Convert.ToDecimal(fpsSpecialAllowance_Sheet1.Cells[fpsSpecialAllowance_Sheet1.ActiveRowIndex,1].Text);
					fpdSpecialAllowance.Text = Convert.ToString(result);
				}
			}
			catch(Exception ex)
			{
				Message(ex);
			}
		}
        
        public void calculateDate()
		{
			int currentday = DateTime.Today.Day;
			int currentmonth = DateTime.Today.Month;
			int currentyear = DateTime.Today.Year;

			DateTime hiredate = dtpBirthdate.Value;
			int dayhire = hiredate.Day;
			int monthhire = hiredate.Month;
			int yearhire = hiredate.Year;

			int diffyear = currentyear-yearhire;
			int diffmonth = currentmonth-monthhire;
			int diffday = currentday-dayhire;
			if(diffday < 0)
			{
				diffmonth = diffmonth -1;
			}
			if(diffmonth < 0)
			{
				diffyear = diffyear - 1;
				diffmonth = diffmonth + 12;
			}
			txtAgeYear.Text = Convert.ToString(diffyear);
			txtAgeMonth.Text = Convert.ToString(diffmonth);

		}		
        
        public void calculateHire()
		{
			int currentday = DateTime.Today.Day;
			int currentmonth = DateTime.Today.Month;
			int currentyear = DateTime.Today.Year;

			DateTime hiredate = dtpHireDate.Value;
			int dayhire = hiredate.Day;
			int monthhire = hiredate.Month;
			int yearhire = hiredate.Year;

			int diffyear = currentyear-yearhire;
			int diffmonth = currentmonth-monthhire;
			int diffday = currentday-dayhire;
			if(diffday < 0)
			{
				diffmonth = diffmonth -1;
			}
			if(diffmonth < 0)
			{
				diffyear = diffyear - 1;
				diffmonth = diffmonth + 12;
			}
			txtHireYear.Text = Convert.ToString(diffyear);
			txtHireMonth.Text = Convert.ToString(diffmonth);

		}

		private void setPermission()
		{	
			if(isReadonly)
			{
				cmdOK.Enabled = false;
			}		
		}

        private void getForm()
        {
            getEmployee();
            getEmployeeAddress();
            getParent();
            getReferencePerson();
            getGuarantor();
            getSpouse();
            getEducation();
            getWorkBackground();
            getChildren();
            getSalary();
            getSpecialAllowance();
        }

        /// <summary>
        /// Calculate retirement date for staff
        /// </summary>
        /// <param name="dateTime"></param>
        private void calculateRetireDate(DateTime birthDate)
        {
            //General retire date
            int retireYear = 55;

            //GM retire date
            if (cboPosition.SelectedIndex > -1 
                && ((Position)cboPosition.SelectedItem).PositionCode == PositionCodeValue.GM)
            {
                retireYear = 58;
            }

            dtpRetireDate.Value = new DateTime(birthDate.AddYears(retireYear).Year, birthDate.AddYears(retireYear).Month, DateTime.DaysInMonth(birthDate.AddYears(retireYear).Year, birthDate.AddYears(retireYear).Month));
        }
		#endregion

		#region - Get Form -
		private void getEmployee()
		{
			facadePI.EmployeeInfo.EmployeeNo = txtEmployeeNo.Text;
			// Job Information
			if(cboSection.SelectedIndex == -1)
			{
				facadePI.EmployeeInfo.ASection.ADepartment = (Department)cboDepartment.SelectedItem;
			}
			else
			{
				facadePI.EmployeeInfo.ASection = (Section)cboSection.SelectedItem;
			}
			if(cboTitle.SelectedIndex == -1)
			{
				facadePI.EmployeeInfo.ATitle.Clear();
			}
			else
			{
				facadePI.EmployeeInfo.ATitle = (Title)cboTitle.SelectedItem;
			}
			if(cboPosition.SelectedIndex == -1)
			{
				facadePI.EmployeeInfo.APosition.Clear();
			}
			else
			{
				facadePI.EmployeeInfo.APosition = (Position)cboPosition.SelectedItem;
			}
			if(cboWorkingStatus.SelectedIndex == -1)
			{
				facadePI.EmployeeInfo.AWorkingStatus.Clear();
			}
			else
			{
				facadePI.EmployeeInfo.AWorkingStatus = (WorkingStatus)cboWorkingStatus.SelectedItem;
			}
			//				facadePI.EmployeeInfo.ShiftNo = CTFunction.GetShiftType(cboShiftNo.Text);
			facadePI.EmployeeInfo.KindOfOT = CTFunction.GetKindOfOTType(cboKindOfOT.Text);
			if(cboKindOfStaff.SelectedIndex == -1)
			{
				facadePI.EmployeeInfo.AKindOfStaff.Clear();
			}
			else
			{
				facadePI.EmployeeInfo.AKindOfStaff = (KindOfStaff)cboKindOfStaff.SelectedItem;
			}
			WorkingStatus workingStatus = (WorkingStatus)cboWorkingStatus.SelectedItem;
			if(workingStatus.Code.Equals("06") || workingStatus.Code.Equals("07") || workingStatus.Code.Equals("08") || workingStatus.Code.Equals("10"))
			{
				facadePI.EmployeeInfo.TerminationDate = Convert.ToDateTime(dtpTerminationDate.Text);
			}
			else
			{		
				facadePI.EmployeeInfo.TerminationDate = NullConstant.DATETIME;
			}
			facadePI.EmployeeInfo.TerminationReason = txtTerminationReason.Text;

			// Personal Information
			facadePI.EmployeeInfo.APrefix.Thai = cboThaiPrefix.Text;
			facadePI.EmployeeInfo.APrefix.English = cboEngPrefix.Text;
			facadePI.EmployeeInfo.AName.Thai = txtThaiName.Text;
			facadePI.EmployeeInfo.AName.English = txtEngName.Text;
			facadePI.EmployeeInfo.ASurname.Thai = txtThaiSurName.Text;
			facadePI.EmployeeInfo.ASurname.English = txtEngSurName.Text;
			facadePI.EmployeeInfo.Gender = CTFunction.GetGenderType(cboGender.Text);
			facadePI.EmployeeInfo.Nationality.Name = cboNationality.Text;
			facadePI.EmployeeInfo.Race.Name = cboRace.Text;
			facadePI.EmployeeInfo.BloodGrop.Name = cboBloodGroup.Text;

			if(cboMaritalStatus.SelectedIndex == -1)
			{
				facadePI.EmployeeInfo.MaritalStatus.Clear();
			}
			else
			{
				facadePI.EmployeeInfo.MaritalStatus = (MaritalStatus)cboMaritalStatus.SelectedItem;
			}

			if(cboMilitaryStatus.SelectedIndex == -1)
			{
				facadePI.EmployeeInfo.MilitaryStatus.Clear();
			}
			else
			{
				facadePI.EmployeeInfo.MilitaryStatus = (MilitaryStatus)cboMilitaryStatus.SelectedItem;
			}

			facadePI.EmployeeInfo.Religion.Name = cboReligion.Text;
			facadePI.EmployeeInfo.DriverLicenseNo = txtDriverLicenseNo.Text;
			facadePI.EmployeeInfo.DriverLicenseType = CTFunction.GetDriverLicenseType(cboDriverLicenseType.Text);
			facadePI.EmployeeInfo.SocialSecurityNo = txtSecurityNo.Text;
			facadePI.EmployeeInfo.TaxIDNo = txtTaxIDNo.Text;
			facadePI.EmployeeInfo.IdCardNo = txtIDCardNo.Text;			
			facadePI.EmployeeInfo.IdCardExpireDate = Convert.ToDateTime(dtpIDCardExpireDate.Text);

			if (txtDriverLicenseNo.Text == "")
			{
				facadePI.EmployeeInfo.DriverLicenseExpireDate = NullConstant.DATETIME;
			}
			else
			{				
				facadePI.EmployeeInfo.DriverLicenseExpireDate = Convert.ToDateTime(dtpDriverLicenseExpireDate.Text);
			}

			facadePI.EmployeeInfo.HireDate = dtpHireDate.Value;				
			facadePI.EmployeeInfo.BirthDate = dtpBirthdate.Value;

            if (cboHospital.SelectedIndex == -1)
            {
                facadePI.EmployeeInfo.SSHospital.Clear();
            }
            else
            {
                facadePI.EmployeeInfo.SSHospital = (SSHospital)cboHospital.SelectedItem;
            }

            if (dtpPFFrom.Checked)
            {
                facadePI.EmployeeInfo.PFFromDate = dtpPFFrom.Value;
            }
            else
            {
                facadePI.EmployeeInfo.PFFromDate = null;
            }

            if (dtpPFTo.Checked)
            {
                facadePI.EmployeeInfo.PFToDate = dtpPFTo.Value;
            }
            else
            {
                facadePI.EmployeeInfo.PFToDate = null;
            }
		}

		private void getEmployeeAddress()
		{
			if(UCTRegisterAddress.HasChangeAddress())
			{
				facadePI.RegisterAddress = getUCTAddress(UCTRegisterAddress);
				facadePI.EmployeeAddressChange = true;
			}
			if(UCTCurrentAddress.HasChangeAddress())
			{
				facadePI.CurrentAddress = getUCTAddress(UCTCurrentAddress);
				facadePI.EmployeeAddressChange = true;
			}			
		}

		private void getParent()
		{
			if(UCTFather.HasChangeParent())
			{
				getUCTParent(UCTFather, facadePI.EmployeeFather);
				facadePI.EmployeeParentChange = true;
			}

			if(UCTMother.HasChangeParent())
			{
				getUCTParent(UCTMother, facadePI.EmployeeMother);
				facadePI.EmployeeParentChange = true;
			}	
		}

		private void getReferencePerson()
		{
			if(UCTReference.HasChangeParent())
			{
				//					if((!validateReferenceName())||(!validateReferenceGender()))
				//					{
				//						facadePI.ReferencePerson = getUCTPerson(UCTReference);
				//						facadePI.ReferencePersonChange = false;
				//					}
				//					else
				//					{
				facadePI.ReferencePerson = getUCTPerson(UCTReference);
				facadePI.ReferencePersonChange = true;
				//					}
			}
		}

		private void getGuarantor()
		{
			if(UCTGuaruntor.HasChangeParent())
			{
				//					if((!validateGuarantorName())||(!validateGuarantorGender()))
				//					{
				//						facadePI.Guarantor = getUCTPerson(UCTGuaruntor);
				//						facadePI.GuarantorChange = false;
				//					}
				//					else
				//					{
				facadePI.Guarantor = getUCTPerson(UCTGuaruntor);
				facadePI.GuarantorChange = true;
				//					}
			}
		}

		private void getSpouse()
		{
			//				if(facadePI.EmployeeSpouseChange)
			//				{
			facadePI.EmployeeSpouse.APrefix.Thai = cboSPrefix.Text;
			facadePI.EmployeeSpouse.AName.Thai = txtSName.Text;
			facadePI.EmployeeSpouse.ASurname.Thai = txtSSurName.Text;
			//					facadePI.EmployeeSpouse.Gender = CTFunction.GetGenderType(cboSGender.Text);
			facadePI.EmployeeSpouse.Alive = chkSAlive.Checked;
			facadePI.EmployeeSpouse.ApplyMedical = chkSMedicalApply.Checked;
			//					if(cboSOccupation.SelectedIndex == -1)
			//					{
			//						facadePI.EmployeeSpouse.AOccupation.Clear();
			//					}
			//					else
			//					{
			facadePI.EmployeeSpouse.AOccupation.Name = cboSOccupation.Text;
			//					}
			if(uctAge3.HasChangeAge())
			{
				//						if (uctAge3.Birthday == DateTime.Today)
				//						{
				//							facadePI.EmployeeSpouse.BirthDate = NullConstant.DATETIME;
				//						}
				//						else
				//						{				
				//							facadePI.EmployeeSpouse.BirthDate = uctAge3.Birthday;
				//						}
				facadePI.EmployeeSpouse.BirthDate = uctAge3.Birthday;
				facadePI.EmployeeSpouseChange = true;
			}

            if (uctAge3.Birthday == NullConstant.DATETIME)
            {
                facadePI.EmployeeSpouse.BirthDate = NullConstant.DATETIME;
            }

			if(UCTHAddress.HasChangeAddress())
			{
				facadePI.EmployeeSpouse.AHomeAddress =  getUCTAddress(UCTHAddress);
				facadePI.EmployeeSpouseChange = true;
			}
			if(UCTOAddress.HasChangeAddress())
			{
				facadePI.EmployeeSpouse.AOfficeAddress = getUCTAddress(UCTOAddress);
				facadePI.EmployeeSpouseChange = true;
			}	
		}

		private void getEducation()
		{
			if(facadePI.EmployeeEducationChange)
			{
				facadePI.EmployeeEducation.Clear();
				Education education;
				int rowEducation = fpsEducation_Sheet1.RowCount;
				string temp;
				for(int i=0; i<rowEducation; i++)
				{
					education = new Education();
				
					temp = fpsEducation_Sheet1.Cells[i,0].Text;
					education.AInstitute = facadePI.InstituteList[temp];
				
					temp = fpsEducation_Sheet1.Cells[i,1].Text;
					education.AEducationLevel = facadePI.EducationLevelList[temp];
				
					temp = fpsEducation_Sheet1.Cells[i,2].Text;
					education.AFaculty = facadePI.FacultyList[temp];
				
					temp = fpsEducation_Sheet1.Cells[i,3].Text;
					education.AMajor = facadePI.MajorList[temp];
				
					education.YearIn = Convert.ToInt16(fpsEducation_Sheet1.Cells[i,4].Text);
					education.YearGraduate = Convert.ToInt16(fpsEducation_Sheet1.Cells[i,5].Text);
					education.Gpa = Convert.ToDecimal(fpsEducation_Sheet1.Cells[i,6].Text);
					education.Status  = CTFunction.GetEducationStatusType(fpsEducation_Sheet1.Cells[i,7].Text);
							
					facadePI.EmployeeEducation.Add(education);
				}
			}
		}

		private void getWorkBackground()
		{
			if(facadePI.EmployeeWorkBackgroundChange)
			{
				facadePI.EmployeeWorkBackground.Clear();
				WorkBackground workBackground;
				int rowWorkBackground = fpsWorkingBackGround_Sheet1.RowCount;
				for(int i=0; i<rowWorkBackground; i++)
				{
					workBackground = new WorkBackground();
					workBackground.ACompany.Thai = fpsWorkingBackGround_Sheet1.Cells[i,0].Text;
					workBackground.FromYear = Convert.ToInt16(fpsWorkingBackGround_Sheet1.Cells[i,1].Text);
					workBackground.ToYear = Convert.ToInt16(fpsWorkingBackGround_Sheet1.Cells[i,2].Text);
					workBackground.PositionName = fpsWorkingBackGround_Sheet1.Cells[i,3].Text;
					workBackground.LatestSalary = Convert.ToDecimal(fpsWorkingBackGround_Sheet1.Cells[i,4].Text);
					workBackground.ResignReason = fpsWorkingBackGround_Sheet1.Cells[i,5].Text;
					facadePI.EmployeeWorkBackground.Add(workBackground);
				}
			}
		}

		private void getChildren()
		{
			if(facadePI.EmployeeChildrenListChange)
			{
				facadePI.EmployeeChildrenList.Clear();
				EmployeeChildren employeeChildren;
				int rowChildren = fpsChildren_Sheet1.RowCount;
				for(int i=0; i<rowChildren; i++)
				{
					employeeChildren = new EmployeeChildren();
					employeeChildren.APrefix.Thai = fpsChildren_Sheet1.Cells[i,0].Text;
					employeeChildren.AName.Thai = fpsChildren_Sheet1.Cells[i,1].Text;
					employeeChildren.ASurname.Thai = fpsChildren_Sheet1.Cells[i,2].Text;
					employeeChildren.Gender = CTFunction.GetGenderType(fpsChildren_Sheet1.Cells[i,3].Text);
					employeeChildren.BirthDate = Convert.ToDateTime(fpsChildren_Sheet1.Cells[i,4].Text);
					employeeChildren.Alive = Convert.ToBoolean(fpsChildren_Sheet1.Cells[i,6].Text);
					employeeChildren.ApplyMedical = Convert.ToBoolean(fpsChildren_Sheet1.Cells[i,7].Text);
					employeeChildren.AOccupation.Name = fpsChildren_Sheet1.Cells[i,8].Text;
					facadePI.EmployeeChildrenList.Add(employeeChildren);
				}
			}
		}

		private void getSalary()
		{
			if(facadePI.SalaryChange)
			{
				facadePI.Salary.Basic = Convert.ToDecimal(GUIFunction.GetString(fpdBasicSalary.Text));
				facadePI.Salary.PositionAllowance = Convert.ToDecimal(GUIFunction.GetString(fpdPositionAllowance.Text));
				facadePI.Salary.SpecialAllowance = Convert.ToDecimal(GUIFunction.GetString(fpdSpecialAllowance.Text));
				facadePI.Salary.ABankDeposit.ABank = (Bank)cboBank.SelectedItem;
				facadePI.Salary.ABankDeposit.AccountNo = txtBankAccount.Text;
				facadePI.Salary.Regular = Convert.ToDecimal(GUIFunction.GetString(fpdRegular.Text));
                facadePI.Salary.LSPAmount = Convert.ToDecimal(fpdLSP.Value);
                facadePI.Salary.MatchingFund = Convert.ToDecimal(fpdMatchingFund.Value);
                facadePI.Salary.Earning = Convert.ToDecimal(fpdEarning.Value);
                facadePI.Salary.DiffRetiringAllowance = Convert.ToDecimal(fpdDiffRetiring.Value);
			}
		}

		private void getSpecialAllowance()
		{
			if(facadePI.EmployeeSpecialAllowanceChange)
			{
				facadePI.EmployeeSpecialAllowance.Clear();
				SpecialAllowance AspecialAllowance;
				string temp;
				int rowSpecialAllowance = fpsSpecialAllowance_Sheet1.RowCount;
				for(int i=0; i<rowSpecialAllowance; i++)
				{
					AspecialAllowance = new SpecialAllowance();

					temp = fpsSpecialAllowance_Sheet1.Cells[i,0].Text;
					AspecialAllowance = facadePI.SpecialAllowanceList[temp];

					AspecialAllowance.Amount = Convert.ToDecimal(fpsSpecialAllowance_Sheet1.Cells[i,1].Text);
					facadePI.EmployeeSpecialAllowance.Add(AspecialAllowance);
				}
			}
		}
		#endregion		

		#region -set Form-
		private void setForm()
		{
			permissionForSalary(facadePI.EmployeeInfo);

			try
			{
				System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(ApplicationProfile.PHOTO_PATH);
				System.IO.FileInfo[] files = dirInfo.GetFiles(facadePI.EmployeeInfo.EmployeeNo + ".*");
				if (files != null && files.Length == 1)
				{
                    //Old function use file always : woranai 2009/04/27
                    //pctEmployee.Image = System.Drawing.Image.FromFile(files[0].FullName);
                    pctEmployee.Load(files[0].FullName);
				}
				else
				{
					pctEmployee.Image = null;
				}
				dirInfo = null;
				files = null;			
			}
			catch
			{
				pctEmployee.Image = null;
			}
			
			//employee
			cboThaiPrefix.Text = facadePI.EmployeeInfo.APrefix.Thai;
			cboEngPrefix.Text = facadePI.EmployeeInfo.APrefix.English;
			txtThaiName.Text = facadePI.EmployeeInfo.AName.Thai;
			txtThaiSurName.Text = facadePI.EmployeeInfo.ASurname.Thai;
			txtEngName.Text = facadePI.EmployeeInfo.AName.English;
			txtEngSurName.Text = facadePI.EmployeeInfo.ASurname.English;

			//ทั่วไป1
			cboDepartment.Text = facadePI.EmployeeInfo.ASection.ADepartment.ToString();
			cboSection.Text = facadePI.EmployeeInfo.ASection.ToString();
			cboPosition.Text = facadePI.EmployeeInfo.APosition.ToString();
			cboTitle.Text = facadePI.EmployeeInfo.ATitle.AName.Thai;
			cboKindOfStaff.Text = facadePI.EmployeeInfo.AKindOfStaff.AName.Thai;
			cboKindOfOT.Text = GUIFunction.GetString(facadePI.EmployeeInfo.KindOfOT);
			cboWorkingStatus.Text = facadePI.EmployeeInfo.AWorkingStatus.AName.Thai;

			if(facadePI.EmployeeInfo.TerminationDate != NullConstant.DATETIME)
			{
				dtpTerminationDate.Text = GUIFunction.GetString(facadePI.EmployeeInfo.TerminationDate);
			}
			else
			{
				dtpTerminationDate.Text = Convert.ToString(DateTime.Today);
			}

			txtTerminationReason.Text = facadePI.EmployeeInfo.TerminationReason;
			cboGender.Text = GUIFunction.GetString(facadePI.EmployeeInfo.Gender);
			cboBloodGroup.Text = facadePI.EmployeeInfo.BloodGrop.Name;
			cboRace.Text = facadePI.EmployeeInfo.Race.Name;
			cboNationality.Text = facadePI.EmployeeInfo.Nationality.Name;
			cboReligion.Text = facadePI.EmployeeInfo.Religion.Name;
			cboMaritalStatus.Text = facadePI.EmployeeInfo.MaritalStatus.AName.Thai;
			cboMilitaryStatus.Text = facadePI.EmployeeInfo.MilitaryStatus.AName.Thai;
			txtIDCardNo.Text = facadePI.EmployeeInfo.IdCardNo;
			dtpIDCardExpireDate.Text = Convert.ToString(facadePI.EmployeeInfo.IdCardExpireDate);
			DriverLicenseNo = facadePI.EmployeeInfo.DriverLicenseNo;
			txtDriverLicenseNo.Text = facadePI.EmployeeInfo.DriverLicenseNo;
			dtpDriverLicenseExpireDate.Value = DateTime.Today;

            if (facadePI.EmployeeInfo.DriverLicenseExpireDate == DateTime.Today && facadePI.EmployeeInfo.DriverLicenseNo != "")
            {
                chkDriver.Checked = true;
                dtpDriverLicenseExpireDate.Text = Convert.ToString(DateTime.Today);
            }
            else if (facadePI.EmployeeInfo.DriverLicenseExpireDate != NullConstant.DATETIME)
            {
                chkDriver.Checked = false;
                dtpDriverLicenseExpireDate.Show();
                label34.Show();
                dtpDriverLicenseExpireDate.Text = Convert.ToString(facadePI.EmployeeInfo.DriverLicenseExpireDate);
            }
            else
            {
                chkDriver.Checked = true;
                dtpDriverLicenseExpireDate.Value = NullConstant.DATETIME;

            }

			cboDriverLicenseType.Text = GUIFunction.GetString(facadePI.EmployeeInfo.DriverLicenseType);
			txtTaxIDNo.Text = facadePI.EmployeeInfo.TaxIDNo;
			txtSecurityNo.Text = facadePI.EmployeeInfo.SocialSecurityNo;

            if (facadePI.EmployeeInfo.SSHospital == null)
            {
                cboHospital.Text = "";
            }
            else
            {
                cboHospital.Text = facadePI.EmployeeInfo.SSHospital.AName.Thai;
            }

			setUCTAddress(UCTRegisterAddress,facadePI.RegisterAddress);

			setUCTAddress(UCTCurrentAddress,facadePI.CurrentAddress);

			setUCTParent(UCTFather,facadePI.EmployeeFather);

			setUCTParent(UCTMother,facadePI.EmployeeMother);

			setUCTPerson(UCTReference,facadePI.ReferencePerson);

			setUCTPerson(UCTGuaruntor,facadePI.Guarantor);

			if(facadePI.EmployeeInfo.HireDate == NullConstant.DATETIME)
			{
				dtpHireDate.Value = NullConstant.DATETIME;
			}
			else
			{
				dtpHireDate.Value = facadePI.EmployeeInfo.HireDate;
			}

			if(facadePI.EmployeeInfo.BirthDate != NullConstant.DATETIME)
			{
				dtpBirthdate.Value = facadePI.EmployeeInfo.BirthDate;
			}
			else
			{
				dtpBirthdate.Value = DateTime.Today;
			}

            if (facadePI.EmployeeInfo.PFFromDate.HasValue)
            {
                dtpPFFrom.Checked = true;
                dtpPFFrom.Value = facadePI.EmployeeInfo.PFFromDate.Value.Date;
            }
            else
            {
                dtpPFFrom.Checked = false;
            }

            if (facadePI.EmployeeInfo.PFToDate.HasValue)
            {
                dtpPFTo.Checked = true;
                dtpPFTo.Value = facadePI.EmployeeInfo.PFToDate.Value.Date;
            }
            else
            {
                dtpPFTo.Checked = false;
            }

            if (facadePI.EmployeeInfo.PFFromDate.HasValue && facadePI.EmployeeInfo.PFToDate.HasValue)
            {
                Age age = facadePI.CalculateAge(dtpPFFrom.Value.Date, dtpPFTo.Value.Date);

                txtPFAgeYear.Text = age.Year.ToString();
                txtPFAgeMonth.Text = age.Month.ToString();
                txtPFAgeDay.Text = age.Day.ToString();                
            }

			//Spouse
			if(facadePI.EmployeeSpouse != null)
			{
				cboSPrefix.Text  = facadePI.EmployeeSpouse.APrefix.Thai;
				txtSName.Text = facadePI.EmployeeSpouse.AName.Thai;
				txtSSurName.Text = facadePI.EmployeeSpouse.ASurname.Thai;
				cboSOccupation.Text = facadePI.EmployeeSpouse.AOccupation.Name;
				if(facadePI.EmployeeSpouse.BirthDate == NullConstant.DATETIME)
				{
					uctAge3.Birthday = DateTime.Today;
					uctAge3.DTPChecked(false);
				}
				else
				{
					uctAge3.Birthday = facadePI.EmployeeSpouse.BirthDate;
					uctAge3.DTPChecked(true);
				}

				//อายุ
				chkSAlive.Checked = facadePI.EmployeeSpouse.Alive;
				chkSMedicalApply.Checked = facadePI.EmployeeSpouse.ApplyMedical;
				setUCTAddress(UCTHAddress,facadePI.EmployeeSpouse.AHomeAddress);
				setUCTAddress(UCTOAddress,facadePI.EmployeeSpouse.AOfficeAddress);

			}

			//Salary
			if(facadePI.Salary != null)
			{
				fpdBasicSalary.Text = GUIFunction.GetString(facadePI.Salary.Basic);
				fpdPositionAllowance.Text = GUIFunction.GetString(facadePI.Salary.PositionAllowance);
				fpdSpecialAllowance.Text = GUIFunction.GetString(facadePI.Salary.SpecialAllowance);
				cboBank.Text = facadePI.Salary.ABankDeposit.ABank.AName.Thai;
				txtBankAccount.Text = facadePI.Salary.ABankDeposit.AccountNo;
				fpdRegular.Text = GUIFunction.GetString(facadePI.Salary.Regular);
                fpdLSP.Value = facadePI.Salary.LSPAmount;
                fpdMatchingFund.Value = facadePI.Salary.MatchingFund;
                fpdEarning.Value = facadePI.Salary.Earning;
                fpdDiffRetiring.Value = facadePI.Salary.DiffRetiringAllowance;
			}

			txtSTaxIDNo.Text = facadePI.EmployeeInfo.TaxIDNo;
			//เงินเดือน

			//farpoint
			bindfpsSpecialallowance();
			bindfpsWorkBackground();
			bindfpsEducation();
			bindfpsChildren();

			facadePI.ClearAllList();
       
			uctAge3.SetChangeAll(false);
			UCTCurrentAddress.SetChangeAll(false);
			UCTRegisterAddress.SetChangeAll(false);
			UCTFather.SetChangeAll(false);
			UCTGuaruntor.SetChangeAll(false);
			UCTHAddress.SetChangeAll(false);
			UCTMother.SetChangeAll(false);
			UCTOAddress.SetChangeAll(false);
			UCTReference.SetChangeAll(false);

			facadePI.changeAll(false);

			//facadePI
		}

		#endregion

		#region - clearForm -
		private void enableKeyField(bool enable)
		{
		}

		private void hideGroupbox()
		{
			label3.Hide();
			label4.Hide();
			cboThaiPrefix.Hide();
			cboEngPrefix.Hide();
			txtThaiName.Hide();
			txtEngName.Hide();
			txtThaiSurName.Hide();
			txtEngSurName.Hide();
		}
		private void showGroupbox()
		{
			label3.Show();
			label4.Show();
			cboThaiPrefix.Show();
			cboEngPrefix.Show();
			txtThaiName.Show();
			txtEngName.Show();
			txtThaiSurName.Show();
			txtEngSurName.Show();
		}
		private void clearForm()
		{
			pctEmployee.Image = null;
			txtEmployeeNo.Enabled = true;
			cboThaiPrefix.SelectedIndex = -1 ;
			cboEngPrefix.SelectedIndex = -1;
			cboDepartment.SelectedIndex = -1;
			cboSection.SelectedIndex = -1;
			cboPosition.SelectedIndex = -1;
			cboKindOfStaff.SelectedIndex = -1;
			cboKindOfOT.SelectedIndex = -1;
			cboWorkingStatus.SelectedIndex = -1;
			cboGender.SelectedIndex = -1;
			cboRace.SelectedIndex = -1;
			cboNationality.SelectedIndex = -1;
			cboReligion.SelectedIndex = -1;
			cboDriverLicenseType.SelectedIndex = -1;
			cboSPrefix.SelectedIndex = -1;
			cboSOccupation.SelectedIndex = -1;
			cboBloodGroup.SelectedIndex = -1;
            dtpPFFrom.Checked = false;
            dtpPFFrom.Value = DateTime.Today;
            dtpPFTo.Checked = false;
            dtpPFTo.Value = DateTime.Today;
            txtPFAgeDay.Text = "0";
            txtPFAgeMonth.Text = "0";
            txtPFAgeYear.Text = "0";

			cboThaiPrefix.Text = "";
			cboEngPrefix.Text = "";
			cboDepartment.Text = "";
			cboSection.Text = "";
			cboPosition.Text = "";
			cboTitle.Text = "";
			cboKindOfStaff.Text = "";
			cboKindOfOT.Text = "";
			cboWorkingStatus.Text = "";
			cboGender.Text = "";
			cboRace.Text = "";
			cboNationality.Text = "";
			cboReligion.Text = "";
			cboMaritalStatus.Text = "โสด";
			cboMilitaryStatus.Text = "";
			cboDriverLicenseType.Text = "";
			cboDriverLicenseType.Hide();
			label33.Hide();
			label34.Hide();
			cboSPrefix.Text = "";
			cboSOccupation.Text = "";
            cboHospital.Text = "";

			UCTCurrentAddress.Clear();
			UCTRegisterAddress.Clear();
			UCTFather.Clear();
			UCTMother.Clear();
			UCTReference.Clear();
			UCTGuaruntor.Clear();
			UCTHAddress.Clear();
			UCTOAddress.Clear();
			uctAge3.Clear();

			txtThaiName.Text = "";
			txtThaiSurName.Text = "";
			txtEngName.Text = "";
			txtEngSurName.Text = "";
			txtTerminationReason.Text = "";
			cboBloodGroup.Text = "";
			txtIDCardNo.Text = "";
			txtDriverLicenseNo.Text = "";
			txtTaxIDNo.Text = "";
			txtSecurityNo.Text = "";
			txtSName.Text = "";
			txtSSurName.Text = "";
			cboMilitaryStatus.Text = "";
			cboBank.Text = "";
			txtBankAccount.Text = "";
			txtTaxIDNo.Text = "";
			fpdBasicSalary.Text = "0";
			fpdPositionAllowance.Text = "0";
			fpdSpecialAllowance.Text = "0";
			fpdSpecialAllowance.Enabled = false;

			chkDriver.Checked = false;
			chkDriver.Hide();

			dtpDriverLicenseExpireDate.Value = DateTime.Today;
			dtpDriverLicenseExpireDate.Hide();

			dtpIDCardExpireDate.Value = DateTime.Today;
			dtpIDCardExpireDate.Hide();
			label20.Hide();

			dtpTerminationDate.Value = DateTime.Today;
			dtpBirthdate.Value = DateTime.Today;
			dtpHireDate.Value = DateTime.Today;
			
			fpsChildren_Sheet1.RowCount = 0;
			fpsEducation_Sheet1.RowCount = 0;
			fpsSpecialAllowance_Sheet1.RowCount = 0;
			fpsWorkingBackGround_Sheet1.RowCount = 0;

			chkSMedicalApply.Checked = false;
			chkSAlive.Checked = true;

			label100.Enabled = false;
			dtpRetireDate.Enabled = false;
		}

		#endregion

		#region   -validation -
		private bool validateForm()
		{
            return validatePrefix() && validateThaiName() && validateThaiSurname() && validateEmgPrefix()
                && validateEngName()
                && validateEngSurname() && validateDepartment() && validateSection() && validatePosition() && validateKindOfStaff()
                && validateKindOfOT() && validateWorkingStatus() && validateHireDate() && MaxDateBirthday()
                && validateGender() && validateIDCardNo() && validateDriverLicenseExpireDate()
                && validateDriverLicenseType() && validatePFDate() && validateAddress() && validate16()
                && validateSubDistrict()
                && validate18() && validate19() && validate20() && checkDuplicateEducation()
                && checkDuplicateYearGraduate() && validate21() && checkDuplicateEducationStatus()
                && checkValidateEducationStatus() && checkDuplicateWorkBackground()
                && checkValidateWorkBackground() && validateWorkBackGround() && MaxDateBirthdayFather()
                && MaxDateBirthdayMother() && validateReferenceName() && MaxDateBirthdayReference()
                && validateReferenceGender() && validateGuarantorName() && MaxDateBirthdayGuaruntor()
                && validateGuarantorGender() && MaxDateBirthdaySpouse() && checkDuplicateChildren()
                && MaxDateBirthdayChildren() && checkValidateChildren() && checkDuplicateSpecialAllowance()
                && checkValidateSpecialAllowance() && validate23();
		}

		private bool validatePrefix()
		{
			if (cboThaiPrefix.Text == "")
			{
				Message(MessageList.Error.E0002, "คำนำหน้าภาษาไทย");
				cboThaiPrefix.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}

		private bool validateThaiName()
		{
			if (txtThaiName.Text == "")
			{
				Message(MessageList.Error.E0002, "ชื่อภาษาไทย");
				txtThaiName.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}

		private bool validateThaiSurname()
		{
			if (txtThaiSurName.Text == "")
			{
				Message(MessageList.Error.E0002, "นามสกุลภาษาไทย");
				txtThaiSurName.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}

		private bool validateEmgPrefix()
		{
			if (cboEngPrefix.Text == "")
			{
				Message(MessageList.Error.E0002, "คำนำหน้าภาษาอังกฤษ");
				cboEngPrefix.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}

		private bool validateEngName()
		{
			if (txtEngName.Text == "")
			{
				Message(MessageList.Error.E0002, "ชื่อภาษาอังกฤษ");
				txtEngName.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}

		private bool validateEngSurname()
		{
			if (txtEngSurName.Text == "")
			{
				Message(MessageList.Error.E0002, "นามสกุลภาษาอังกฤษ");
				txtEngSurName.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}

		private bool validateDepartment()
		{
			if (cboDepartment.Text == "")
			{
				Message(MessageList.Error.E0002, "ฝ่ายต้นสังกัด");
				tabControl1.SelectedIndex = 0;
				cboDepartment.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}

		private bool validateSection()
		{
			if (cboSection.Text == "")
			{
				Message(MessageList.Error.E0002, "ส่วนงาน");
				tabControl1.SelectedIndex = 0;
				cboSection.Focus();

				return false;
			}
			return true;
		}

		private bool validatePosition()
		{
			if (cboPosition.Text == "")
			{
				Message(MessageList.Error.E0002, "ตำแหน่ง(Position)");
				tabControl1.SelectedIndex = 0;
				cboPosition.Focus();

				return false;
			}
			return true;
		}

		private bool validateKindOfStaff()
		{
			if (cboKindOfStaff.Text == "")
			{
				Message(MessageList.Error.E0002, "ประเภทพนักงาน");
				tabControl1.SelectedIndex = 0;
				cboKindOfStaff.Focus();

				return false;
			}
			return true;
		}

		private bool validateKindOfOT()
		{
			if (cboKindOfOT.Text == "")
			{
				Message(MessageList.Error.E0002, "ประเภทค่าล่วงเวลา");
				tabControl1.SelectedIndex = 0;
				cboKindOfOT.Focus();

				return false;
			}
	    	return true;
		}

		private bool validateWorkingStatus()
		{
			if (cboWorkingStatus.Text == "")
			{
				Message(MessageList.Error.E0002, "สถานภาพการทำงาน");
				tabControl1.SelectedIndex = 0;
				cboWorkingStatus.Focus();

				return false;
			}
            return true;
		}

		private bool validateHireDate()
		{
			if(dtpHireDate.Value == NullConstant.DATETIME)
			{
				Message(MessageList.Error.E0002, "วันที่เริ่มงาน");
				tabControl1.SelectedIndex = 0;
				dtpHireDate.Focus();
				return false;
			}
            return true;
		}

		private bool MaxDateBirthday()
		{
			if(dtpBirthdate.Value > DateTime.Today)
			{
				Message(MessageList.Error.E0001, "วันเกิด","วันที่ปัจจุบัน");
				tabControl1.SelectedIndex = 0;
				dtpBirthdate.Focus();
				return false;
			}
            return true;
		}

		private bool validateGender()
		{
			if (cboGender.Text == "")
			{
				Message(MessageList.Error.E0002, "เพศ");
				tabControl1.SelectedIndex = 0;
				cboGender.Focus();

				return false;
			}
            return true;
		}

		private bool validateIDCardNo()
		{
			if (txtIDCardNo.Text == "")
			{
				Message(MessageList.Error.E0002, "เลขที่บัตรประชาชน");
				tabControl1.SelectedIndex = 0;
				txtIDCardNo.Focus();

				return false;
			}
            return true;
		}

		private bool validateDriverLicenseExpireDate()
		{
			if ((txtDriverLicenseNo.Text != "") && (dtpDriverLicenseExpireDate.Value == DateTime.Today)&& (!chkDriver.Checked))
			{
				Message(MessageList.Error.E0002, "วันหมดอายุใบขับขี่");
				tabControl1.SelectedIndex = 0;
				dtpDriverLicenseExpireDate.Focus();

				return false;
			}
            return true;
		}

		private bool validateDriverLicenseType()
		{
			if((txtDriverLicenseNo.Text !="")&& (cboDriverLicenseType.Text == " "))
			{
				Message(MessageList.Error.E0002, "ประเภท");
				tabControl1.SelectedIndex = 0;
				cboDriverLicenseType.Focus();
				return false;
			}
            return true;
		}

        private bool validatePFDate()
        {
            if (dtpPFFrom.Checked && dtpPFTo.Checked)
            {
                if (dtpPFFrom.Value.Date >= dtpPFTo.Value.Date)
                {
                    Message(MessageList.Error.E0001, "วันที่เข้ากองทุน", "วันที่ออกจากกองทุน");
                    tabControl1.SelectedIndex = 0;
                    dtpPFFrom.Focus();
                    return false;
                }
            }
            return true;
        }

		private bool validateAddress()
		{
			if (UCTRegisterAddress.AddressLine == "")
			{
				Message(MessageList.Error.E0002, "ที่อยู่");
				tabControl1.SelectedIndex = 3;
				UCTRegisterAddress.Focus();
				return false;
			}
            return true;
		}

		private bool validate16()
		{
			if (UCTRegisterAddress.Street == "")
			{
				Message(MessageList.Error.E0002, "ถนน");
				tabControl1.SelectedIndex = 3;
				UCTRegisterAddress.Focus();
				return false;
			}
            return true;
		}

		private bool validateSubDistrict()
		{
			if (UCTRegisterAddress.SubDistrict == "")
			{
				Message(MessageList.Error.E0002, "แขวง");
				tabControl1.SelectedIndex = 3;
				UCTRegisterAddress.Focus();
				return false;
			}
            return true;
		}

		private bool validate18()
		{
			if (UCTRegisterAddress.District == "")
			{
				Message(MessageList.Error.E0002, "เขต");
				tabControl1.SelectedIndex = 3;
				UCTRegisterAddress.Focus();
				return false;
			}
            return true;
		}

		private bool validate19()
		{
			if (UCTRegisterAddress.Province == "")
			{
				Message(MessageList.Error.E0002, "จังหวัด");
				tabControl1.SelectedIndex = 3;
				UCTRegisterAddress.Focus();
				return false;
			}
            return true;
		}

		private bool validate20()
		{
			if (UCTRegisterAddress.PostalCode == "")
			{
				Message(MessageList.Error.E0002, "รหัสไปรษณีย์");
				tabControl1.SelectedIndex = 3;
				UCTRegisterAddress.Focus();
				return false;
			}
            return true;
		}
		
		private bool checkDuplicateEducation()
		{
			bool result = true;
			string temp;
			CommonCollection tempList = new CommonCollection();
	
			for(int i=0; i<fpsEducation_Sheet1.RowCount; i++)
			{
				temp = fpsEducation_Sheet1.Cells[i, 0].Text+fpsEducation_Sheet1.Cells[i, 1].Text+fpsEducation_Sheet1.Cells[i, 2].Text+fpsEducation_Sheet1.Cells[i, 3].Text;
				if(tempList.Contain(temp))
				{
					Message(MessageList.Error.E0010);
					tabControl1.SelectedIndex = 2;
					result = false;
				}
				else
				{
					tempList.Add(temp, temp);
				}
			}
			return result;
		}

		private bool checkDuplicateYearGraduate()
		{
			bool result = true;
			string temp;
			CommonCollection tempList = new CommonCollection();
	
			for(int i=0; i<fpsEducation_Sheet1.RowCount; i++)
			{
				temp = fpsEducation_Sheet1.Cells[i, 5].Text;
				if(tempList.Contain(temp))
				{
					Message(MessageList.Error.E0010);
					tabControl1.SelectedIndex = 2;
					result = false;
				}
				else
				{
					tempList.Add(temp, temp);
				}
			}
			return result;
		}

		private bool validate21()
		{
			if(fpsEducation_Sheet1.RowCount != 0)
			{
				for(int i=0; i<fpsEducation_Sheet1.RowCount; i++)
				{
					if(Convert.ToDouble(fpsEducation_Sheet1.Cells[i,4].Text) > Convert.ToDouble(fpsEducation_Sheet1.Cells[i,5].Text))
					{
						Message(MessageList.Error.E0001, "ปีที่เข้ารับการศึกษา" , "ปีที่สำเร็จการศึกษา");
						tabControl1.SelectedIndex = 2;
						fpsEducation.Focus();

						return false;
					}
				}
			}
			return true;
		}
		
		private bool checkValidateEducationStatus()
		{
			for(int i=0; i<fpsEducation_Sheet1.RowCount; i++)
			{
				if(fpsEducation_Sheet1.Cells[i, 0].Text == "")
				{
					Message(MessageList.Error.E0005,"สถาบันการศึกษา");
					tabControl1.SelectedIndex = 2;
					return false;
				}
				if(fpsEducation_Sheet1.Cells[i, 1].Text == "")
				{
					Message(MessageList.Error.E0005,"ระดับการศึกษา");
					tabControl1.SelectedIndex = 2;
					return false;
				}
				if((fpsEducation_Sheet1.Cells[i, 4].Text == "0")||(fpsEducation_Sheet1.Cells[i, 4].Text.Length < 4))
				{
					Message(MessageList.Error.E0002,"ปีที่เข้ารับการศึกษา");
					tabControl1.SelectedIndex = 2;
					return false;
				}
				if((fpsEducation_Sheet1.Cells[i, 5].Text == "0")||(fpsEducation_Sheet1.Cells[i, 5].Text.Length < 4))
				{
					Message(MessageList.Error.E0002,"ปีที่สำเร็จการศึกษา");
					tabControl1.SelectedIndex = 2;
					return false;
				}
				if((fpsEducation_Sheet1.Cells[i, 6].Text == ""))
				{
					Message(MessageList.Error.E0002,"เกรดเฉลี่ย");
					tabControl1.SelectedIndex = 2;
					return false;
				}
				if(fpsEducation_Sheet1.Cells[i, 7].Text == "")
				{
					Message(MessageList.Error.E0002,"สถานะวุฒิการศีกษา");
					tabControl1.SelectedIndex = 2;
					return false;
				}
			}
			return true;
		}

		private bool checkDuplicateEducationStatus()
		{
			bool result = true;
			int irow = 0;
			CommonCollection tempList = new CommonCollection();
			for(int i=0; i<fpsEducation_Sheet1.RowCount; i++)
			{
				if(fpsEducation_Sheet1.Cells[i, 7].Text == "วุฒิที่ใช้สมัครงาน")
				{
					irow += 1;
				}
					
				if(irow > 1)
				{
					Message(MessageList.Error.E0010);
					tabControl1.SelectedIndex = 2;
					result = false;
				}
				else
				{
					result = true;
				}
			}
			return result;
		}

		private bool checkDuplicateWorkBackground()
		{
			bool result = true;
			string temp;
			CommonCollection tempList = new CommonCollection();
	
			for(int i=0; i<fpsWorkingBackGround_Sheet1.RowCount; i++)
			{
				temp = fpsWorkingBackGround_Sheet1.Cells[i, 0].Text+fpsWorkingBackGround_Sheet1.Cells[i, 1].Text+fpsWorkingBackGround_Sheet1.Cells[i, 2].Text;
				if(tempList.Contain(temp))
				{
					Message(MessageList.Error.E0010);
					tabControl1.SelectedIndex = 2;
					result = false;
				}
				else
				{
					tempList.Add(temp, temp);
				}
			}
			return result;
		}

		private bool checkValidateWorkBackground()
		{
			for(int i=0; i<fpsWorkingBackGround_Sheet1.RowCount; i++)
			{
				if (fpsWorkingBackGround_Sheet1.Cells[i, 0].Text == "")
				{
					Message(MessageList.Error.E0002,"ชื่อบริษัท");
					tabControl1.SelectedIndex = 2;
					return false;
				}
				if(fpsWorkingBackGround_Sheet1.Cells[i, 1].Text == "")
				{
					Message(MessageList.Error.E0002,"ปีที่เริ่มงาน");
					tabControl1.SelectedIndex = 2;
					return false;
				}
				if(fpsWorkingBackGround_Sheet1.Cells[i, 2].Text == "")
				{
					Message(MessageList.Error.E0002,"ปีทีสิ้นสุด");
					tabControl1.SelectedIndex = 2;
					return false;
				}
			}
			return true;
		}

		private bool validateWorkBackGround()
		{
			for(int i=0; i<fpsWorkingBackGround_Sheet1.RowCount; i++)
			{
				if(Convert.ToDouble(fpsWorkingBackGround_Sheet1.Cells[i,1].Text) > Convert.ToDouble(fpsWorkingBackGround_Sheet1.Cells[i,2].Text))
				{
					Message(MessageList.Error.E0001,  "ปีที่เริ่มงาน" , "ปีที่สิ้นสุด");
					tabControl1.SelectedIndex = 2;
					fpsEducation.Focus();

					return false;
				}
				if(fpsWorkingBackGround_Sheet1.Cells[i,4].Text == "")
				{
					Message(MessageList.Error.E0002,  "เงินเดือนสุดท้าย");
					tabControl1.SelectedIndex = 2;
					fpsEducation.Focus();

					return false;
				}
				
			}
			return true;
		}

		private bool MaxDateBirthdayFather()
		{
			if(UCTFather.Birthdate > DateTime.Today)
			{
				Message(MessageList.Error.E0001, "วันเกิดบิดา","วันที่ปัจจุบัน");
				tabControl1.SelectedIndex = 3;
				UCTFather.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}

		private bool MaxDateBirthdayMother()
		{
			if(UCTMother.Birthdate > DateTime.Today)
			{
				Message(MessageList.Error.E0001, "วันเกิดมารดา","วันที่ปัจจุบัน");
				tabControl1.SelectedIndex = 3;
				UCTMother.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}

		private bool checkDuplicateChildren()
		{
			bool result = true;
			string temp;
			CommonCollection tempList = new CommonCollection();
	
			for(int i=0; i<fpsChildren_Sheet1.RowCount; i++)
			{
				temp = fpsChildren_Sheet1.Cells[i, 1].Text+fpsChildren_Sheet1.Cells[i,4].Text;
				if(tempList.Contain(temp))
				{
					Message(MessageList.Error.E0010);
					tabControl1.SelectedIndex = 4;
					result = false;
				}
				else
				{
					tempList.Add(temp, temp);
				}
			}
			return result;
		}

		private bool checkValidateChildren()
		{
			for(int i=0; i<fpsChildren_Sheet1.RowCount; i++)
			{
				if (fpsChildren_Sheet1.Cells[i, 1].Text == "")
				{
					Message(MessageList.Error.E0002,"ชื่อบุตร-ธิดา");
					tabControl1.SelectedIndex = 4;
					return false;
				}
				if(fpsChildren_Sheet1.Cells[i, 3].Text == "")
				{
					Message(MessageList.Error.E0002,"เพศบุตร-ธิดา");
					tabControl1.SelectedIndex = 4;
					return false;
				}
				if(fpsChildren_Sheet1.Cells[i, 4].Text == "")
				{
					Message(MessageList.Error.E0002,"อายุบุตร-ธิดา");
					tabControl1.SelectedIndex = 4;
					return false;
				}
			}
			return true;
		}
		
		private bool checkDuplicateSpecialAllowance()
		{
			bool result = true;
			string temp;
			CommonCollection tempList = new CommonCollection();
	
			for(int i=0; i<fpsSpecialAllowance_Sheet1.RowCount; i++)
			{
				temp = fpsSpecialAllowance_Sheet1.Cells[i, 0].Text;
				if(tempList.Contain(temp))
				{
					Message(MessageList.Error.E0010);
					tabControl1.SelectedIndex = 5;
					result = false;
				}
				else
				{
					tempList.Add(temp, temp);
				}
			}
			return result;
		}

		private bool checkValidateSpecialAllowance()
		{
			for(int i=0; i<fpsSpecialAllowance_Sheet1.RowCount; i++)
			{
				if(fpsSpecialAllowance_Sheet1.Cells[i, 0].Text == "")
				{
					Message(MessageList.Error.E0002,"หมวดเงินได้พิเศษ");
					tabControl1.SelectedIndex = 5;
					return false;
				}
			}
			return true;
		}

		private bool validate23()
		{
			if (fpdBasicSalary.Text == "")
			{
				Message(MessageList.Error.E0002, "เงินเดือน");
				tabControl1.SelectedIndex = 5;
				fpdBasicSalary.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}

		private bool validateReferenceName()
		{
			if(UCTReference.HasChangeParent())
			{
				if (UCTReference.ThaiName == "")
				{
					Message(MessageList.Error.E0002, "ชื่อบุคคลอ้างอิง");
					tabControl1.SelectedIndex = 4;
					UCTReference.Focus();
					return false;
				}
				else
				{
					return true;
				}
			}
			else
			{
				return true;
			}
		}

		private bool validateReferenceGender()
		{
			if(UCTReference.HasChangeParent())
			{
				if (UCTReference.Gender == "")
				{
					Message(MessageList.Error.E0002, "เพศบุคคลอ้างอิง");
					tabControl1.SelectedIndex = 4;
					UCTReference.Focus();
					return false;
				}
				else
				{
					return true;
				}
			}
			else
			{
				return true;
			}
		}

		private bool validateGuarantorName()
		{
			if(UCTGuaruntor.HasChangeParent())
			{
				if (UCTGuaruntor.ThaiName == "")
				{
					Message(MessageList.Error.E0002, "ชื่อผู้ค้ำประกัน");
					tabControl1.SelectedIndex = 4;
					UCTGuaruntor.Focus();
					return false;
				}
				else
				{
					return true;
				}

			}
			else
			{
				return true;
			}

		}

		private bool validateGuarantorGender()
		{
			if(UCTGuaruntor.HasChangeParent())
			{
				if (UCTGuaruntor.Gender == "")
				{
					Message(MessageList.Error.E0002, "เพศผู้ค้ำประกัน");
					tabControl1.SelectedIndex = 4;
					UCTGuaruntor.Focus();
					return false;
				}
				else
				{
					return true;
				}
			}
			else
			{
				return true;
			}
		}

		private bool MaxDateBirthdayReference()
		{
			if(UCTReference.Birthdate > DateTime.Today)
			{
				Message(MessageList.Error.E0001, "วันเกิดบุคคลอ้างอิง","วันที่ปัจจุบัน");
				tabControl1.SelectedIndex = 4;
				UCTReference.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}

		private bool MaxDateBirthdayGuaruntor()
		{
			if(UCTGuaruntor.Birthdate > DateTime.Today)
			{
				Message(MessageList.Error.E0001, "วันเกิดบุคคลค้ำประกัน","วันที่ปัจจุบัน");
				tabControl1.SelectedIndex = 4;
				UCTGuaruntor.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}

		private bool MaxDateBirthdaySpouse()
		{
			if(uctAge3.Birthday > DateTime.Today)
			{
				Message(MessageList.Error.E0001, "วันเกิดคู่สมรส","วันที่ปัจจุบัน");
				tabControl1.SelectedIndex = 4;
				uctAge3.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}

		private bool MaxDateBirthdayChildren()
		{
			for(int i=0; i<fpsChildren_Sheet1.RowCount; i++)
			{
				if (Convert.ToDateTime(fpsChildren_Sheet1.Cells[i, 4].Text) > DateTime.Today)
				{
					Message(MessageList.Error.E0001,"วันเกิดบุตร-ธิดา","วันที่ปัจจุบัน");
					tabControl1.SelectedIndex = 4;
					fpsChildren.Focus();
					return false;
				}
			}
			return true;
		}

		private bool ValidateCalLeave()
		{
			DateTime hiredate = dtpHireDate.Value;
			if(!facadePI.CheckAnnualLeaveControl(hiredate))
			{
				Message(MessageList.Error.E0014,"คำนวณวันลาพักร้อนได้");
				tabControl1.SelectedIndex = 0;
				dtpHireDate.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}

		private bool CheckAnnualLeaveDay()
		{
			if(facadePI.CheckAnnualLeaveDay(facadePI.EmployeeInfo))
			{
				Message(MessageList.Error.E0014,"ลบพนักงานที่ระบุ");
				tabControl1.SelectedIndex = 0;
				cboDepartment.Focus();
				return true;
			}
			else
			{
				return false;
			}
		}

		private bool CheckServiceStaffAssignment()
		{
			if(facadePI.EmployeeInfo.APosition.APositionType.Type == "S")
			{
				if(facadePI.CheckServiceStaffAssignment(facadePI.EmployeeInfo))
				{
					Message(MessageList.Error.E0014,"ลบพนักงานที่ระบุ");
					tabControl1.SelectedIndex = 0;
					cboDepartment.Focus();
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}

        /// <summary>
        /// If children over 19 year old and get medical aid, the system will warning to user : Woranai 2009/08/07
        /// </summary>
        private bool CheckChildrenAge()
        {
            if (fpsChildren_Sheet1.RowCount > 0)
            {
                for (int i = 0; i < fpsChildren_Sheet1.RowCount; i++)
                {
                    bool applyMedical = Convert.ToBoolean(fpsChildren_Sheet1.Cells[i, 7].Value);
                    DateTime birthDate = Convert.ToDateTime(fpsChildren_Sheet1.Cells[i, 4].Value);

                    if (applyMedical && birthDate.AddYears(19) <= DateTime.Today)
                    {
                        Message(MessageList.Error.E0058, "แก้ไขสถานะการเบิกค่ารักษาพยาบาลของลูก เนื่องจากอายุของลูกเกินสิทธิ์แล้ว");
                        tabControl1.SelectedIndex = 1;
                        return false;
                    }
                }
            }

            return true;            
        }

        private void SetMaxMinSalary()
        {
            fpdBasicSalary.MaxValue = 1000000.00;
            fpdBasicSalary.MinValue = 0;
            fpdRegular.MaxValue = 9000000.00;
            fpdRegular.MinValue = 0;
            fpdLSP.MaxValue = 9999999.99;
            fpdLSP.MinValue = 0;
            fpdMatchingFund.MaxValue = 9999999.99;
            fpdMatchingFund.MinValue = 0;
            fpdEarning.MaxValue = 999999.99;
            fpdEarning.MinValue = 0;
            fpdDiffRetiring.MaxValue = 9999999.99;
            fpdDiffRetiring.MinValue = 0;
        }
		#endregion

		#region   -setactive farpoint -
		private void CheckActive()
		{
			if(fpsEducation_Sheet1.RowCount > 0)
			{
				mniDeleteEducation.Enabled = true;
			}
			else
			{
				mniDeleteEducation.Enabled = false;
			}
			if(fpsChildren_Sheet1.RowCount > 0)
			{
				mniDeletechildren.Enabled = true;
			}
			else
			{
				mniDeletechildren.Enabled = false;
			}
			if(fpsSpecialAllowance_Sheet1.RowCount > 0)
			{
				mniDeleteSpecialAllowance.Enabled = true;
			}
			else
			{
				mniDeleteSpecialAllowance.Enabled = false;
			}
			if(fpsWorkingBackGround_Sheet1.RowCount > 0)
			{
				mniDeleteworkbackground.Enabled = true;
			}
			else
			{
				mniDeleteworkbackground.Enabled = false;
			}
		}

        /// <summary>
        /// Grant permission for access salary
        /// </summary>
        private bool hasPermissionForSalary
        {
            get
            {
                return UserProfile.UserID.ToLower().Trim() == "yaowalki" ||
                UserProfile.UserID.ToLower().Trim() == "nuanchti" ||
                UserProfile.UserID.ToLower().Trim() == "pinnicsu" ||
                UserProfile.UserID.ToLower().Trim() == "piyanada" ||
                UserProfile.UserID.ToLower().Trim() == "suchitph" ||
                UserProfile.UserID.ToLower().Trim() == "wisarnpo" ||
                UserProfile.UserID.ToLower().Trim() == "supotelu" ||
                UserProfile.UserID.ToLower().Trim() == "asc";
            }
        }

        private void permissionForSalary()
        {
            if (hasPermissionForSalary)
            {
            }
            else
            {
                tabControl1.TabPages.Remove(tabincome);
                tabControl1.SelectedTab = tabgerneral;
            }
        }

        private void permissionForSalary(Employee value)
        {
            if (hasPermissionForSalary)
            { }
            else
            {
                if (UserProfile.UserID.ToLower().Trim() == "kingkasa")
                {
                    if (value.APosition.PositionCode == "28" || value.APosition.PositionCode == "27")
                    {
                        tabControl1.TabPages.Add(tabincome);
                        tabControl1.SelectedTab = tabgerneral;
                    }
                    else
                    {
                        tabControl1.TabPages.Remove(tabincome);
                        tabControl1.SelectedTab = tabgerneral;
                    }
                }
                else
                {
                    tabControl1.TabPages.Remove(tabincome);
                    tabControl1.SelectedTab = tabgerneral;
                }
            }
        }

        private void WorkingStatusChange()
        {
            if (facadePI.EmployeeInfo.AWorkingStatus.Code.Equals("06") || facadePI.EmployeeInfo.AWorkingStatus.Code.Equals("07") || facadePI.EmployeeInfo.AWorkingStatus.Code.Equals("08") || facadePI.EmployeeInfo.AWorkingStatus.Code.Equals("10"))
            {
                dtpTerminationDate.Visible = true;
                txtTerminationReason.Visible = true;
                label27.Visible = true;
                label35.Visible = true;
            }
            else
            {
                dtpTerminationDate.Visible = false;
                dtpTerminationDate.Value = DateTime.Today;
                txtTerminationReason.Visible = false;
                txtTerminationReason.Text = "";
                label27.Visible = false;
                label35.Visible = false;
            }
        }

		#endregion        

        #region Base Event
        public void InitForm()
        {
            mdiParent.EnableNewCommand(false);
            mdiParent.EnableDeleteCommand(false);
            mdiParent.EnableRefreshCommand(false);
            mdiParent.EnablePrintCommand(false);
            clearMainMenuStatus();

            facadePI.ReNew();
            clearForm();
            Title();
            hideGroupbox();
            txtEmployeeNo.Text = "";
            txtEmployeeNo.Focus();
            dtpTerminationDate.Visible = false;
            txtTerminationReason.Visible = false;
            label35.Visible = false;
            label27.Visible = false;
            tabControl1.Visible = false;
            cmdOK.Visible = false;
            cmdCancel.Visible = false;
            IsMustQuestion = false;
        }

        public virtual void RefreshForm()
        {
            try
            {
                facadePI.EmployeeInfo.EmployeeNo = txtEmployeeNo.Text;

                if (facadePI.Display())
                {
                    clearForm();
                    showGroupbox();
                    setDataSource();
                    tabControl1.Visible = true;
                    cmdOK.Visible = visibleOK;
                    cmdCancel.Visible = visibleOK;
                    SetMaxMinSalary();

                    mdiParent.EnableNewCommand(true);
                    mdiParent.EnableDeleteCommand(true);
                    mdiParent.EnableRefreshCommand(true);
                    mdiParent.EnablePrintCommand(true);
                    MainMenuNewStatus = true;
                    MainMenuDeleteStatus = true;
                    MainMenuRefreshStatus = true;
                    MainMenuPrintStatus = true;

                    baseEDIT();
                    clearForm();
                    TitleEdit();
                    txtEmployeeNo.Enabled = false;
                    chkSAlive.Checked = true;
                    chkSMedicalApply.Checked = false;

                    setForm();
                    WorkingStatusChange();

                    uctAge3.SetChangeAll(false);
                    UCTCurrentAddress.SetChangeAll(false);
                    UCTRegisterAddress.SetChangeAll(false);
                    UCTFather.SetChangeAll(false);
                    UCTGuaruntor.SetChangeAll(false);
                    UCTHAddress.SetChangeAll(false);
                    UCTMother.SetChangeAll(false);
                    UCTOAddress.SetChangeAll(false);
                    UCTReference.SetChangeAll(false);

                    IsMustQuestion = false;
                    facadePI.changeAll(false);
                    CheckActive();
                    enableKeyField(false);
                    isHireDateChange = false;

                    CheckChildrenAge();
                }
            }
            catch (EmpNotFoundException empNot)
            {
                try
                {
                    Employee employee = new Employee();
                    facadeFormer.EmployeeInfo.EmployeeNo = txtEmployeeNo.Text;
                    if (facadeFormer.Display())
                    {
                        Message(MessageList.Error.E0013, "ใช้รหัสพนักงานนี้ได้", "มีการใช้รหัสพนักงานนี้แล้ว");
                        InitForm();
                    }
                }
                catch (EmpNotFoundException FormerempNot)
                {
                    clearForm();
                    showGroupbox();
                    setDataSource();
                    tabControl1.Visible = true;
                    cmdOK.Visible = visibleOK;
                    cmdCancel.Visible = visibleOK;
                    SetMaxMinSalary();

                    mdiParent.EnableNewCommand(true);
                    mdiParent.EnableDeleteCommand(false);
                    mdiParent.EnableRefreshCommand(true);
                    mdiParent.EnablePrintCommand(true);
                    MainMenuNewStatus = true;
                    MainMenuDeleteStatus = false;
                    MainMenuRefreshStatus = true;
                    MainMenuPrintStatus = true;

                    baseADD();
                    clearForm();
                    cmdOK.Enabled = false;
                    this.Text = "เพิ่ม" + UserProfile.GetFormName("miPI", "miPIEmployeePI");
                    IsMustQuestion = false;
                    txtEmployeeNo.Enabled = false;
                    cmdOK.Enabled = false;
                    enableKeyField(true);

                    uctAge3.SetChangeAll(false);
                    UCTCurrentAddress.SetChangeAll(false);
                    UCTRegisterAddress.SetChangeAll(false);
                    UCTFather.SetChangeAll(false);
                    UCTGuaruntor.SetChangeAll(false);
                    UCTHAddress.SetChangeAll(false);
                    UCTMother.SetChangeAll(false);
                    UCTOAddress.SetChangeAll(false);
                    UCTReference.SetChangeAll(false);

                    facadePI.changeAll(false);
                    CheckActive();

                    FormerempNot.ToString();
                }
                nullException(empNot);
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (Exception ex)
            {
                Message(ex);
            }

            if (isReadonly)
            {
                mdiParent.EnableDeleteCommand(false);
                MainMenuDeleteStatus = false;
            }
        }

        private void AddEvent()
        {
            try
            {
                if (validateForm())
                {
                    if (ValidateCalLeave())
                    {
                        getForm();
                        facadePI.Insert();
                        enableKeyField(true);
                        Message(MessageList.Information.I0001);
                        RefreshForm();
                        IsMustQuestion = false;
                    }
                }

            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (Exception ex)
            {
                Message(ex);
            }
        }

        private void EditEvent()
        {
            try
            {
                bool result = true;

                if (validateForm())
                {
                    if (isHireDateChange)
                    {
                        result = ValidateCalLeave();
                    }

                    if (result)
                    {
                        getForm();
                        if (facadePI.Update())
                        {
                            Message(MessageList.Information.I0001);
                            RefreshForm();
                        }
                        else
                        {
                            Message(MessageList.Error.E0014, "ปรับปรุงข้อมูลพนักงานคนนี้ได้");
                        }
                        IsMustQuestion = false;
                    }
                }
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (Exception ex)
            {
                Message(ex);
            }
        }

        public void DeleteForm()
        {
            try
            {
                if (Message(MessageList.Question.Q0001) == DialogResult.Yes)
                {
                    if (!CheckAnnualLeaveDay())
                    {
                        if (!CheckServiceStaffAssignment())
                        {
                            getForm();
                            facadePI.Delete();
                            enableKeyField(true);
                            IsMustQuestion = false;
                            InitForm();
                        }
                    }
                }
            }
            catch (AppExceptionBase ex)
            {
                Message(ex);
            }
            catch (Exception ex)
            {
                Message(ex);
            }
        }

        public void PrintForm()
        {
            frmListofPIData objfrm = new frmListofPIData();
            objfrm.SelectedEmpNo = txtEmployeeNo.Text;
            objfrm.Show();
        }

        public void ExitForm()
        {
            this.Hide();
        } 
        #endregion

        #region Form Event
        private void txtEmployeeNo_TextChanged(object sender, System.EventArgs e)
        {
            if (txtEmployeeNo.Text.Length == 5)
            {
                RefreshForm();
            }
        }

        private void cmdCopy_Click(object sender, System.EventArgs e)
        {
            Address address = getUCTAddress(UCTRegisterAddress);
            setUCTAddress(UCTCurrentAddress, address);
        }

        private void cmdCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult result = Message(MessageList.Question.Q0003);
            if (result == DialogResult.Yes)
            {
                switch (action)
                {
                    case ActionType.ADD:
                        AddEvent();
                        break;
                    case ActionType.EDIT:
                        EditEvent();
                        break;
                }
                this.Hide();
            }
            else if (result == DialogResult.No)
            { this.Hide(); }

            else if (result == DialogResult.Cancel)
            { this.Show(); }
        }

        private void cmdOK_Click(object sender, System.EventArgs e)
        {
            switch (action)
            {
                case ActionType.ADD:
                    AddEvent();
                    break;
                case ActionType.EDIT:
                    EditEvent();
                    break;
            }
        }

        private void frmPI_Load(object sender, System.EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            InitForm();
            IsMustQuestion = false;

            permissionForSalary();
        }

        private void cboDepartment_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cboDepartment.SelectedIndex != -1)
            {
                Department department = (Department)cboDepartment.SelectedItem;
                cboSection.DataSource = facadePI.DataSourceSection(department);
                cboSection.SelectedIndex = -1;
            }

            this.controlEmployee_Changed(sender, e);
        }

        private void dtpBirthdate_ValueChanged(object sender, System.EventArgs e)
        {
            IsMustQuestion = true;
            calculateDate();
            facadePI.EmployeeChange = true;
            cmdOK.Enabled = true;
            setPermission();

            calculateRetireDate(dtpBirthdate.Value);            
        }

        private void dtpHireDate_ValueChanged(object sender, System.EventArgs e)
        {
            IsMustQuestion = true;
            calculateHire();
            facadePI.EmployeeChange = true;
            cmdOK.Enabled = true;
            setPermission();

            if (dtpHireDate.Value.Month == facadePI.EmployeeInfo.HireDate.Month && dtpHireDate.Value.Year == facadePI.EmployeeInfo.HireDate.Year)
            {
                isHireDateChange = false;
            }
            else
            {
                isHireDateChange = true;
            }
        }

        protected virtual void mniAddEducation_Click(object sender, System.EventArgs e)
        {
            fpsEducation.ActiveSheet.Rows.Add(SelectedRowEducation, 1);
            if (fpsEducation_Sheet1.RowCount > 0)
            {
                fpsEducation_Sheet1.Cells[0, 4].Text = "0";
                fpsEducation_Sheet1.Cells[0, 5].Text = "0";
                fpsEducation_Sheet1.Cells[0, 6].Text = "0.00";

                mniDeleteEducation.Enabled = true;
            }
            IsMustQuestion = true;
        }

        private void mniDeleteEducation_Click(object sender, System.EventArgs e)
        {
            fpsEducation.ActiveSheet.Rows.Remove(SelectedRowEducation, 1);
            if (fpsEducation_Sheet1.RowCount == 0)
            {
                mniDeleteEducation.Enabled = false;
            }
            IsMustQuestion = true;
            facadePI.EmployeeEducationChange = true;
            cmdOK.Enabled = true;
            setPermission();
        }

        private void mniAddworkbackground_Click(object sender, System.EventArgs e)
        {
            fpsWorkingBackGround.ActiveSheet.Rows.Add(SelectedRowWorkbackground, 1);
            if (fpsWorkingBackGround_Sheet1.RowCount > 0)
            {
                mniDeleteworkbackground.Enabled = true;
            }
            IsMustQuestion = true;
        }

        private void mniDeleteworkbackground_Click(object sender, System.EventArgs e)
        {
            fpsWorkingBackGround.ActiveSheet.Rows.Remove(SelectedRowWorkbackground, 1);
            if (fpsWorkingBackGround_Sheet1.RowCount == 0)
            {
                mniDeleteworkbackground.Enabled = false;
            }
            IsMustQuestion = true;
            facadePI.EmployeeWorkBackgroundChange = true;
            cmdOK.Enabled = true;
            setPermission();
        }

        private void mniAddchildren_Click(object sender, System.EventArgs e)
        {
            fpsChildren.ActiveSheet.Rows.Add(SelectedRowChildren, 1);
            if (fpsChildren_Sheet1.RowCount > 0)
            {
                mniDeletechildren.Enabled = true;
                fpsChildren_Sheet1.Cells[0, 4].Value = DateTime.Today;

                DateTime birtdate = Convert.ToDateTime(fpsChildren_Sheet1.Cells[0, 4].Value);
                string age = facadePI.CalculateAgeDecimal(birtdate);
                fpsChildren_Sheet1.Cells[0, 5].Text = age;

                fpsChildren_Sheet1.Cells[0, 6].Text = "true";
                fpsChildren_Sheet1.Cells[0, 7].Text = "true";
            }
            IsMustQuestion = true;
        }

        private void mniDeletechildren_Click(object sender, System.EventArgs e)
        {
            fpsChildren.ActiveSheet.Rows.Remove(SelectedRowChildren, 1);
            if (fpsChildren_Sheet1.RowCount == 0)
            {
                mniDeletechildren.Enabled = false;
            }
            IsMustQuestion = true;
            facadePI.EmployeeChildrenListChange = true;
            cmdOK.Enabled = true;
            setPermission();
        }

        private void mniAddSpecialAllowance_Click(object sender, System.EventArgs e)
        {
            fpsSpecialAllowance.ActiveSheet.Rows.Add(SelectedRowSpecialAllowance, 1);
            if (fpsSpecialAllowance_Sheet1.RowCount > 0)
            {
                mniDeleteSpecialAllowance.Enabled = true;
            }
            IsMustQuestion = true;
        }

        private void mniDeleteSpecialAllowance_Click(object sender, System.EventArgs e)
        {
            if (fpsSpecialAllowance_Sheet1.RowCount > 0)
            {
                CalculateSpecialAllowanceDeleteRow();
                fpsSpecialAllowance.ActiveSheet.Rows.Remove(SelectedRowSpecialAllowance, 1);
                IsMustQuestion = true;
                facadePI.EmployeeSpecialAllowanceChange = true;
                cmdOK.Enabled = true;
                setPermission();
            }
            else
            {
                mniDeleteSpecialAllowance.Enabled = false;
            }
        }

        private void txtIDCardNo_TextChanged(object sender, System.EventArgs e)
        {
            txtTaxIDNo.Text = txtIDCardNo.Text;
            txtSecurityNo.Text = txtIDCardNo.Text;
            txtSTaxIDNo.Text = txtIDCardNo.Text;
            if (txtIDCardNo.Text == "")
            {
                label20.Hide();
                dtpIDCardExpireDate.Hide();
            }
            else
            {
                label20.Show();
                dtpIDCardExpireDate.Show();
            }

            this.controlEmployee_Changed(sender, e);
        }

        private void cboWorkingStatus_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cboWorkingStatus.SelectedIndex != -1)
            {
                WorkingStatus workingStatus = (WorkingStatus)cboWorkingStatus.SelectedItem;
                if (workingStatus.Code == "06" || workingStatus.Code == "07" || workingStatus.Code == "08" || workingStatus.Code == "10")
                {
                    dtpTerminationDate.Visible = true;
                    txtTerminationReason.Visible = true;
                    label27.Visible = true;
                    label35.Visible = true;
                }
                else
                {
                    dtpTerminationDate.Visible = false;
                    dtpTerminationDate.Value = DateTime.Today;
                    txtTerminationReason.Visible = false;
                    txtTerminationReason.Text = "";
                    label27.Visible = false;
                    label35.Visible = false;
                }
            }

            this.controlEmployee_Changed(sender, e);
        }

        private void cboPosition_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cboPosition.SelectedIndex != -1)
            {
                Position position = (Position)cboPosition.SelectedItem;
                fpdPositionAllowance.Text = Convert.ToString(position.Allowance);
            }
            IsMustQuestion = true;
            facadePI.EmployeeChange = true;
            cmdOK.Enabled = true;
            setPermission();
        }

        protected virtual void txtDriverLicenseNo_TextChanged(object sender, System.EventArgs e)
        {
            if (txtDriverLicenseNo.Text == "")
            {
                label34.Hide();
                label33.Hide();
                dtpDriverLicenseExpireDate.Hide();
                cboDriverLicenseType.Hide();
                chkDriver.Hide();
                cboDriverLicenseType.SelectedIndex = -1;
            }
            else
            {
                chkDriver.Show();
                label33.Show();
                cboDriverLicenseType.Show();

                if (DriverLicenseNo == "")
                {
                    chkDriver.Checked = true;

                }

            }
            IsMustQuestion = true;
            facadePI.EmployeeChange = true;
            cmdOK.Enabled = true;
            setPermission();
            DriverLicenseNo = txtDriverLicenseNo.Text;

        }

        private void chkDriver_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkDriver.Checked)
            {
                dtpDriverLicenseExpireDate.Value = NullConstant.DATETIME;
                dtpDriverLicenseExpireDate.Hide();
                label34.Hide();
            }
            else
            {
                if (facadePI.EmployeeInfo.DriverLicenseExpireDate != NullConstant.DATETIME)
                {
                    dtpDriverLicenseExpireDate.Value = facadePI.EmployeeInfo.DriverLicenseExpireDate;
                }
                else
                {
                    dtpDriverLicenseExpireDate.Value = DateTime.Today;
                }
                dtpDriverLicenseExpireDate.Show();
                label34.Show();
            }
            IsMustQuestion = true;
            facadePI.EmployeeChange = true;
            cmdOK.Enabled = true;
            setPermission();
        }

        private void fpdPositionAllowance_TextChanged(object sender, System.EventArgs e)
        {
            IsMustQuestion = true;
            CalculateSpecialAllowance();
            cmdOK.Enabled = true;
            setPermission();
        }

        private void fpdSpecialAllowance_TextChanged(object sender, System.EventArgs e)
        {
            IsMustQuestion = true;
            if (fpdSpecialAllowance.Text == "0.00")
            {
                mniDeleteSpecialAllowance.Enabled = false;
            }
            CalculateSpecialAllowance();
            cmdOK.Enabled = true;
            setPermission();
        }

        private void fpsChildren_Change(object sender, FarPoint.Win.Spread.ChangeEventArgs e)
        {
            if (e.Column == 0)
            {
                checkDuplicateChildren();
            }

            try
            {
                if (e.Column == 4)
                {
                    DateTime birtdate = Convert.ToDateTime(fpsChildren_Sheet1.Cells[e.Row, 4].Text);
                    string age = facadePI.CalculateAgeDecimal(birtdate);
                    fpsChildren_Sheet1.Cells[e.Row, 5].Text = age;
                }
            }
            catch
            {
                Message(MessageList.Error.E0023);
            }

            IsMustQuestion = true;
            facadePI.EmployeeChildrenListChange = true;
            cmdOK.Enabled = true;
            setPermission();
        }

        private void fpsEducation_Change(object sender, FarPoint.Win.Spread.ChangeEventArgs e)
        {
            if (e.Column == 0)
            {
                checkDuplicateEducation();
            }
            IsMustQuestion = true;
            facadePI.EmployeeEducationChange = true;
            cmdOK.Enabled = true;
            setPermission();
        }

        private void fpsWorkingBackGround_Change(object sender, FarPoint.Win.Spread.ChangeEventArgs e)
        {
            if (e.Column == 0)
            {
                checkDuplicateWorkBackground();
            }
            IsMustQuestion = true;
            facadePI.EmployeeWorkBackgroundChange = true;
            cmdOK.Enabled = true;
            setPermission();
        }

        protected virtual void txtEmployeeNo_DoubleClick(object sender, System.EventArgs e)
        {
            frmEmplist dialogEmplist = new frmEmplist();
            dialogEmplist.ConditionEmployeeNo = txtEmployeeNo.Text;

            dialogEmplist.ShowDialog();
            if (dialogEmplist.Selected)
            {
                txtEmployeeNo.Text = dialogEmplist.SelectedEmployee.EmployeeNo;
            }
        }

        private void fpdBasicSalary_TextChanged(object sender, System.EventArgs e)
        {
            CalculateSpecialAllowance();
        }

        private void cboSOccupation_TextChanged(object sender, System.EventArgs e)
        {
            IsMustQuestion = true;
            facadePI.EmployeeSpouseChange = true;
            cmdOK.Enabled = true;
            setPermission();
        }

        private void fpsSpecialAllowance_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            string temp;

            if (fpsSpecialAllowance_Sheet1.ActiveColumnIndex == 0)
            {
                temp = fpsSpecialAllowance_Sheet1.Cells[fpsSpecialAllowance_Sheet1.ActiveRowIndex, 0].Text;
                SpecialAllowance specialAllowance = facadePI.SpecialAllowanceList[temp];
                fpsSpecialAllowance_Sheet1.Cells[fpsSpecialAllowance_Sheet1.ActiveRowIndex, 1].Text = Convert.ToString(specialAllowance.Amount);
                CalculateSpecialAllowanceAddRow();
                IsMustQuestion = true;
                facadePI.EmployeeSpecialAllowanceChange = true;
                cmdOK.Enabled = true;
                setPermission();
            }
        }

        private void fpsChildren_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (fpsChildren_Sheet1.Cells[e.Row, 4].Text != "")
            {
                DateTime birtdate = Convert.ToDateTime(fpsChildren_Sheet1.Cells[e.Row, 4].Text);
                string age = facadePI.CalculateAgeDecimal(birtdate);
                fpsChildren_Sheet1.Cells[e.Row, 5].Text = age;
            }
            else
            {
                fpsChildren_Sheet1.Cells[e.Row, 4].Value = DateTime.Today;
            }
        }

        private void fpsSpecialAllowance_Change(object sender, FarPoint.Win.Spread.ChangeEventArgs e)
        {
            if (fpsSpecialAllowance_Sheet1.ActiveColumnIndex == 1)
            {
                CalculateSpecialAllowanceAddRow();
                IsMustQuestion = true;
                facadePI.EmployeeSpecialAllowanceChange = true;
                cmdOK.Enabled = true;
                setPermission();
            }
        }

        private void txtEmployeeNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                if (txtEmployeeNo.Text.Length == 5)
                {
                    RefreshForm();
                }
            }
        }

        private void controlEmployee_Changed(object sender, System.EventArgs e)
        {
            IsMustQuestion = true;
            facadePI.EmployeeChange = true;
            cmdOK.Enabled = true;
            setPermission();
        }

        private void controlSalary_Changed(object sender, System.EventArgs e)
        {
            IsMustQuestion = true;
            facadePI.SalaryChange = true;
            cmdOK.Enabled = true;
            setPermission();
        }

        private void controlSpouse_Changed(object sender, System.EventArgs e)
        {
            IsMustQuestion = true;
            facadePI.EmployeeSpouseChange = true;
            cmdOK.Enabled = true;
            setPermission();
        }

        private void dtpPF_Changed(object sender, System.EventArgs e)
        {
            IsMustQuestion = true;
            facadePI.EmployeeChange = true;
            cmdOK.Enabled = true;
            setPermission();

            if (dtpPFFrom.Checked && dtpPFTo.Checked && dtpPFFrom.Value.Date < dtpPFTo.Value.Date)
            {
                Age age = facadePI.CalculateAge(dtpPFFrom.Value.Date, dtpPFTo.Value.Date);

                txtPFAgeYear.Text = age.Year.ToString();
                txtPFAgeMonth.Text = age.Month.ToString();
                txtPFAgeDay.Text = age.Day.ToString();
            }
        }
        #endregion

		#region ISaveForm Members

		public bool SaveForm()
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
			return true;
		}

		#endregion

        #region IMDIChildForm Members

        public int MasterCount()
        {
            return 0;
        }

        public virtual string FormID()
        {
            return UserProfile.GetFormID("miPI", "miPIEmployeePI");
        }

        #endregion
    }
}
