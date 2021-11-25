using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using Entity.CommonEntity;
using Entity.VehicleEntities;
using Entity.ContractEntities;
using Entity.VehicleEntities.VehicleLeasing;

using Facade.CommonFacade;
using Facade.VehicleFacade;
using Facade.VehicleFacade.VehicleLeasingFacade;

using Presentation.CommonGUI;
using Presentation.VehicleGUI;

using SystemFramework.AppException;
using SystemFramework.AppMessage;
using SystemFramework.AppConfig;

using ictus.Common.Entity.General;
using ictus.Common.Entity.Time;

namespace Presentation.VehicleGUI
{
	public class frmVehicle : EntryFormBase, IMDIChildForm, ISaveForm
	{
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.ComboBox cboProvince;
		private System.Windows.Forms.ComboBox cboPlateStatus;
		private System.Windows.Forms.DateTimePicker txtRegisterDate;
		private System.Windows.Forms.DateTimePicker txtLatestMileageUpdateDate;
		private System.Windows.Forms.ComboBox cboColor;
		private System.Windows.Forms.ComboBox cboBrand;
		private System.Windows.Forms.TextBox txtChassisNo;
		private System.Windows.Forms.TextBox txtEngineNo;
		private System.Windows.Forms.ComboBox cboVehicleVat;
		private System.Windows.Forms.DateTimePicker txtBuyDate;
		private System.Windows.Forms.ComboBox cboVendor;
		private System.Windows.Forms.ComboBox cboVehiclests;
		private System.Windows.Forms.ComboBox cboModel;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Button cmdSave;
		private System.Windows.Forms.Button cmdDelete;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.TextBox txtPlateOfPrefix;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.TextBox txtPolicyNoInsuranceTypeOne;
		private System.Windows.Forms.TextBox txtPolicyNoCompulsory;
		private System.Windows.Forms.CheckBox chkSecondHand;
		private FarPoint.Win.Input.FpInteger txtLatestMileage;
		private System.Windows.Forms.TextBox txtStartDateCompulsory;
		private System.Windows.Forms.TextBox txtStartDateInsuranceTypeOne;
		private System.Windows.Forms.TextBox txtEndDateInsuranceTypeOne;
		private System.Windows.Forms.TextBox txtEndDateCompulsory;
		private System.Windows.Forms.TextBox txtStartDateVehicleTax;
		private System.Windows.Forms.TextBox txtEndDateVehicleTax;
		private System.Windows.Forms.ComboBox cboKindOfVehicle;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.TextBox txtNewPlatePrefix;
		private System.Windows.Forms.Label lblPlatePrefix;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label lblPlateNo;
		private System.Windows.Forms.Label lbRemark;
		private System.Windows.Forms.TextBox txtRemark;
		private System.Windows.Forms.Label lblTerminateDate;
		private System.Windows.Forms.DateTimePicker dtpTerminateDate;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.TextBox txtthisContractNo;
		private System.Windows.Forms.TextBox txtCompanyCust;
		private System.Windows.Forms.TextBox txtDepertmentCust;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.NumericUpDown fpdVehicleAmount;
		private System.Windows.Forms.NumericUpDown fpdOptionAmount;
		private System.Windows.Forms.NumericUpDown fpdOperationFee;
		private System.Windows.Forms.TextBox fpdInsuranceAmount;
		private System.Windows.Forms.TextBox fpdCompulsoryAmount;
		private System.Windows.Forms.TextBox fpdSumAssured;
		private System.Windows.Forms.TextBox fpdVehicleTaxAmount;
		private System.Windows.Forms.TextBox fpiRegisterYear;
		private System.Windows.Forms.TextBox fpiRegisterMonth;
		private System.Windows.Forms.TextBox fpiBuyYear;
		private System.Windows.Forms.TextBox fpiBuyMonth;
		private System.Windows.Forms.TextBox fpiOrderNo;
		private FarPoint.Win.Input.FpInteger fpiPlateRunningNo;
		private FarPoint.Win.Input.FpInteger fpiNewPlateRunningNo;
        private GroupBox groupBox9;
        private TextBox txtPOXXX;
        private TextBox txtPOMM;
        private TextBox txtPOYY;
        private Label label46;
        private GroupBox groupBox10;
        private Label label49;
        private Label label51;
        private TextBox txtVendorDate;
        private TextBox txtPODate;
        private Label lblVehicleNo;
		private System.ComponentModel.Container components = null;
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fpiNewPlateRunningNo = new FarPoint.Win.Input.FpInteger();
            this.fpiRegisterMonth = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtNewPlatePrefix = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboProvince = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboPlateStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtRegisterDate = new System.Windows.Forms.DateTimePicker();
            this.fpiRegisterYear = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtLatestMileage = new FarPoint.Win.Input.FpInteger();
            this.cboColor = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboModel = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboBrand = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtChassisNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEngineNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtLatestMileageUpdateDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.fpiBuyMonth = new System.Windows.Forms.TextBox();
            this.fpiBuyYear = new System.Windows.Forms.TextBox();
            this.fpdOperationFee = new System.Windows.Forms.NumericUpDown();
            this.fpdOptionAmount = new System.Windows.Forms.NumericUpDown();
            this.fpdVehicleAmount = new System.Windows.Forms.NumericUpDown();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cboVehicleVat = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtBuyDate = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.cboVendor = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.chkSecondHand = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cboVehiclests = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dtpTerminateDate = new System.Windows.Forms.DateTimePicker();
            this.lblTerminateDate = new System.Windows.Forms.Label();
            this.cboKindOfVehicle = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.fpiPlateRunningNo = new FarPoint.Win.Input.FpInteger();
            this.txtDepertmentCust = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.txtCompanyCust = new System.Windows.Forms.TextBox();
            this.txtthisContractNo = new System.Windows.Forms.TextBox();
            this.lblPlateNo = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblPlatePrefix = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txtPlateOfPrefix = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.fpdSumAssured = new System.Windows.Forms.TextBox();
            this.fpdInsuranceAmount = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.txtEndDateInsuranceTypeOne = new System.Windows.Forms.TextBox();
            this.txtStartDateInsuranceTypeOne = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.txtPolicyNoInsuranceTypeOne = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fpiOrderNo = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPolicyNoCompulsory = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.fpdCompulsoryAmount = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.txtEndDateCompulsory = new System.Windows.Forms.TextBox();
            this.txtStartDateCompulsory = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label45 = new System.Windows.Forms.Label();
            this.txtEndDateVehicleTax = new System.Windows.Forms.TextBox();
            this.txtStartDateVehicleTax = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.fpdVehicleTaxAmount = new System.Windows.Forms.TextBox();
            this.lbRemark = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.txtPOXXX = new System.Windows.Forms.TextBox();
            this.txtPOMM = new System.Windows.Forms.TextBox();
            this.txtPOYY = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.lblVehicleNo = new System.Windows.Forms.Label();
            this.txtVendorDate = new System.Windows.Forms.TextBox();
            this.txtPODate = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpdOperationFee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpdOptionAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpdVehicleAmount)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fpiNewPlateRunningNo);
            this.groupBox1.Controls.Add(this.fpiRegisterMonth);
            this.groupBox1.Controls.Add(this.label34);
            this.groupBox1.Controls.Add(this.label33);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.txtNewPlatePrefix);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboProvince);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboPlateStatus);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtRegisterDate);
            this.groupBox1.Controls.Add(this.fpiRegisterYear);
            this.groupBox1.Location = new System.Drawing.Point(16, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(984, 68);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "รายละเอียดทะเบียนรถ";
            // 
            // fpiNewPlateRunningNo
            // 
            this.fpiNewPlateRunningNo.AllowClipboardKeys = true;
            this.fpiNewPlateRunningNo.AllowNull = true;
            this.fpiNewPlateRunningNo.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiNewPlateRunningNo.Location = new System.Drawing.Point(184, 19);
            this.fpiNewPlateRunningNo.MaxValue = 9999;
            this.fpiNewPlateRunningNo.MinValue = 0;
            this.fpiNewPlateRunningNo.Name = "fpiNewPlateRunningNo";
            this.fpiNewPlateRunningNo.NullColor = System.Drawing.Color.Transparent;
            this.fpiNewPlateRunningNo.Size = new System.Drawing.Size(56, 20);
            this.fpiNewPlateRunningNo.TabIndex = 26;
            this.fpiNewPlateRunningNo.Text = "";
            this.fpiNewPlateRunningNo.TextChanged += new System.EventHandler(this.fpiNewPlateRunningNo_TextChanged);
            // 
            // fpiRegisterMonth
            // 
            this.fpiRegisterMonth.BackColor = System.Drawing.SystemColors.Control;
            this.fpiRegisterMonth.Enabled = false;
            this.fpiRegisterMonth.Location = new System.Drawing.Point(728, 39);
            this.fpiRegisterMonth.Name = "fpiRegisterMonth";
            this.fpiRegisterMonth.Size = new System.Drawing.Size(40, 20);
            this.fpiRegisterMonth.TabIndex = 23;
            this.fpiRegisterMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Enabled = false;
            this.label34.Location = new System.Drawing.Point(704, 43);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(14, 13);
            this.label34.TabIndex = 25;
            this.label34.Text = "ปี";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Enabled = false;
            this.label33.Location = new System.Drawing.Point(768, 43);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(33, 13);
            this.label33.TabIndex = 24;
            this.label33.Text = "เดือน";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Enabled = false;
            this.label24.Location = new System.Drawing.Point(624, 43);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(38, 13);
            this.label24.TabIndex = 21;
            this.label24.Text = "อายุรถ";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label22.Location = new System.Drawing.Point(167, 21);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(12, 16);
            this.label22.TabIndex = 20;
            this.label22.Text = "-";
            // 
            // txtNewPlatePrefix
            // 
            this.txtNewPlatePrefix.Location = new System.Drawing.Point(120, 19);
            this.txtNewPlatePrefix.MaxLength = 3;
            this.txtNewPlatePrefix.Name = "txtNewPlatePrefix";
            this.txtNewPlatePrefix.Size = new System.Drawing.Size(40, 20);
            this.txtNewPlatePrefix.TabIndex = 3;
            this.txtNewPlatePrefix.TextChanged += new System.EventHandler(this.txtNewPlatePrefix_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "เลขทะเบียนรถ";
            // 
            // cboProvince
            // 
            this.cboProvince.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboProvince.Location = new System.Drawing.Point(120, 40);
            this.cboProvince.MaxLength = 50;
            this.cboProvince.Name = "cboProvince";
            this.cboProvince.Size = new System.Drawing.Size(216, 21);
            this.cboProvince.TabIndex = 5;
            this.cboProvince.SelectedIndexChanged += new System.EventHandler(this.cboProvince_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(387, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "สถานะป้ายทะเบียน";
            // 
            // cboPlateStatus
            // 
            this.cboPlateStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlateStatus.Location = new System.Drawing.Point(488, 19);
            this.cboPlateStatus.Name = "cboPlateStatus";
            this.cboPlateStatus.Size = new System.Drawing.Size(96, 21);
            this.cboPlateStatus.TabIndex = 6;
            this.cboPlateStatus.SelectedIndexChanged += new System.EventHandler(this.cboPlateStatus_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "จังหวัด";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(403, 43);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 13);
            this.label15.TabIndex = 4;
            this.label15.Text = "วันที่จดทะเบียน";
            // 
            // txtRegisterDate
            // 
            this.txtRegisterDate.CustomFormat = "dd/MM/yyy";
            this.txtRegisterDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtRegisterDate.Location = new System.Drawing.Point(488, 40);
            this.txtRegisterDate.Name = "txtRegisterDate";
            this.txtRegisterDate.Size = new System.Drawing.Size(96, 20);
            this.txtRegisterDate.TabIndex = 7;
            this.txtRegisterDate.ValueChanged += new System.EventHandler(this.txtRegisterDate_ValueChanged);
            // 
            // fpiRegisterYear
            // 
            this.fpiRegisterYear.BackColor = System.Drawing.SystemColors.Control;
            this.fpiRegisterYear.Enabled = false;
            this.fpiRegisterYear.Location = new System.Drawing.Point(664, 39);
            this.fpiRegisterYear.Name = "fpiRegisterYear";
            this.fpiRegisterYear.Size = new System.Drawing.Size(40, 20);
            this.fpiRegisterYear.TabIndex = 22;
            this.fpiRegisterYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtLatestMileage);
            this.groupBox2.Controls.Add(this.cboColor);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cboModel);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cboBrand);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtChassisNo);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtEngineNo);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtLatestMileageUpdateDate);
            this.groupBox2.Location = new System.Drawing.Point(16, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(984, 87);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ตัวรถ";
            // 
            // txtLatestMileage
            // 
            this.txtLatestMileage.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.txtLatestMileage.AllowClipboardKeys = true;
            this.txtLatestMileage.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.txtLatestMileage.Location = new System.Drawing.Point(520, 58);
            this.txtLatestMileage.MaxValue = 999999;
            this.txtLatestMileage.MinValue = 0;
            this.txtLatestMileage.Name = "txtLatestMileage";
            this.txtLatestMileage.Size = new System.Drawing.Size(120, 20);
            this.txtLatestMileage.TabIndex = 13;
            this.txtLatestMileage.Text = "";
            this.txtLatestMileage.UseSeparator = true;
            this.txtLatestMileage.Click += new System.EventHandler(this.txtLatestMileage_Click);
            // 
            // cboColor
            // 
            this.cboColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboColor.Location = new System.Drawing.Point(120, 58);
            this.cboColor.MaxLength = 50;
            this.cboColor.Name = "cboColor";
            this.cboColor.Size = new System.Drawing.Size(272, 21);
            this.cboColor.TabIndex = 10;
            this.cboColor.SelectedIndexChanged += new System.EventHandler(this.cboColor_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(105, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "สี";
            // 
            // cboModel
            // 
            this.cboModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModel.Location = new System.Drawing.Point(120, 37);
            this.cboModel.MaxLength = 50;
            this.cboModel.Name = "cboModel";
            this.cboModel.Size = new System.Drawing.Size(272, 21);
            this.cboModel.TabIndex = 9;
            this.cboModel.SelectedIndexChanged += new System.EventHandler(this.cboModel_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(84, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "รุ่นรถ";
            // 
            // cboBrand
            // 
            this.cboBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBrand.Location = new System.Drawing.Point(120, 16);
            this.cboBrand.MaxLength = 50;
            this.cboBrand.Name = "cboBrand";
            this.cboBrand.Size = new System.Drawing.Size(272, 21);
            this.cboBrand.TabIndex = 8;
            this.cboBrand.SelectedIndexChanged += new System.EventHandler(this.cboBrand_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(78, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "ยี่ห้อรถ";
            // 
            // txtChassisNo
            // 
            this.txtChassisNo.Location = new System.Drawing.Point(520, 37);
            this.txtChassisNo.MaxLength = 20;
            this.txtChassisNo.Name = "txtChassisNo";
            this.txtChassisNo.Size = new System.Drawing.Size(160, 20);
            this.txtChassisNo.TabIndex = 12;
            this.txtChassisNo.TextChanged += new System.EventHandler(this.txtChassisNo_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(440, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "หมายเลขตัวถัง";
            // 
            // txtEngineNo
            // 
            this.txtEngineNo.Location = new System.Drawing.Point(520, 16);
            this.txtEngineNo.MaxLength = 20;
            this.txtEngineNo.Name = "txtEngineNo";
            this.txtEngineNo.Size = new System.Drawing.Size(160, 20);
            this.txtEngineNo.TabIndex = 11;
            this.txtEngineNo.TextChanged += new System.EventHandler(this.txtEngineNo_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(414, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "หมายเลขเครื่องยนต์";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(472, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "เลขไมล์";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(664, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "วันที่บันทึกเลขไมล์";
            // 
            // txtLatestMileageUpdateDate
            // 
            this.txtLatestMileageUpdateDate.CustomFormat = "dd/MM/yyy";
            this.txtLatestMileageUpdateDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtLatestMileageUpdateDate.Location = new System.Drawing.Point(760, 58);
            this.txtLatestMileageUpdateDate.Name = "txtLatestMileageUpdateDate";
            this.txtLatestMileageUpdateDate.Size = new System.Drawing.Size(96, 20);
            this.txtLatestMileageUpdateDate.TabIndex = 14;
            this.txtLatestMileageUpdateDate.ValueChanged += new System.EventHandler(this.txtLatestMileageUpdateDate_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.fpiBuyMonth);
            this.groupBox3.Controls.Add(this.fpiBuyYear);
            this.groupBox3.Controls.Add(this.fpdOperationFee);
            this.groupBox3.Controls.Add(this.fpdOptionAmount);
            this.groupBox3.Controls.Add(this.fpdVehicleAmount);
            this.groupBox3.Controls.Add(this.label35);
            this.groupBox3.Controls.Add(this.label36);
            this.groupBox3.Controls.Add(this.label37);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.cboVehicleVat);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.txtBuyDate);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.cboVendor);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.chkSecondHand);
            this.groupBox3.Location = new System.Drawing.Point(16, 264);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(984, 91);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "การซื้อรถ";
            // 
            // fpiBuyMonth
            // 
            this.fpiBuyMonth.BackColor = System.Drawing.SystemColors.Control;
            this.fpiBuyMonth.Enabled = false;
            this.fpiBuyMonth.Location = new System.Drawing.Point(848, 19);
            this.fpiBuyMonth.Name = "fpiBuyMonth";
            this.fpiBuyMonth.Size = new System.Drawing.Size(40, 20);
            this.fpiBuyMonth.TabIndex = 28;
            this.fpiBuyMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // fpiBuyYear
            // 
            this.fpiBuyYear.BackColor = System.Drawing.SystemColors.Control;
            this.fpiBuyYear.Enabled = false;
            this.fpiBuyYear.Location = new System.Drawing.Point(784, 19);
            this.fpiBuyYear.Name = "fpiBuyYear";
            this.fpiBuyYear.Size = new System.Drawing.Size(40, 20);
            this.fpiBuyYear.TabIndex = 31;
            this.fpiBuyYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // fpdOperationFee
            // 
            this.fpdOperationFee.DecimalPlaces = 2;
            this.fpdOperationFee.Location = new System.Drawing.Point(120, 60);
            this.fpdOperationFee.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            131072});
            this.fpdOperationFee.Name = "fpdOperationFee";
            this.fpdOperationFee.Size = new System.Drawing.Size(120, 20);
            this.fpdOperationFee.TabIndex = 19;
            this.fpdOperationFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.fpdOperationFee.ThousandsSeparator = true;
            this.fpdOperationFee.Leave += new System.EventHandler(this.fpdOperationFee_Leave);
            // 
            // fpdOptionAmount
            // 
            this.fpdOptionAmount.DecimalPlaces = 2;
            this.fpdOptionAmount.Location = new System.Drawing.Point(488, 40);
            this.fpdOptionAmount.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            131072});
            this.fpdOptionAmount.Name = "fpdOptionAmount";
            this.fpdOptionAmount.Size = new System.Drawing.Size(120, 20);
            this.fpdOptionAmount.TabIndex = 18;
            this.fpdOptionAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.fpdOptionAmount.ThousandsSeparator = true;
            this.fpdOptionAmount.Leave += new System.EventHandler(this.fpdOptionAmount_Leave);
            // 
            // fpdVehicleAmount
            // 
            this.fpdVehicleAmount.DecimalPlaces = 2;
            this.fpdVehicleAmount.Location = new System.Drawing.Point(120, 40);
            this.fpdVehicleAmount.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            131072});
            this.fpdVehicleAmount.Name = "fpdVehicleAmount";
            this.fpdVehicleAmount.Size = new System.Drawing.Size(120, 20);
            this.fpdVehicleAmount.TabIndex = 17;
            this.fpdVehicleAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.fpdVehicleAmount.ThousandsSeparator = true;
            this.fpdVehicleAmount.Leave += new System.EventHandler(this.fpdVehicleAmount_Leave);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Enabled = false;
            this.label35.Location = new System.Drawing.Point(824, 23);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(14, 13);
            this.label35.TabIndex = 30;
            this.label35.Text = "ปี";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Enabled = false;
            this.label36.Location = new System.Drawing.Point(888, 23);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(33, 13);
            this.label36.TabIndex = 29;
            this.label36.Text = "เดือน";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Enabled = false;
            this.label37.Location = new System.Drawing.Point(672, 23);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(109, 13);
            this.label37.TabIndex = 26;
            this.label37.Text = "ระยะเวลาที่ครอบครอง";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(412, 64);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(71, 13);
            this.label19.TabIndex = 13;
            this.label19.Text = "สถานะภาษีรถ";
            // 
            // cboVehicleVat
            // 
            this.cboVehicleVat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVehicleVat.Location = new System.Drawing.Point(488, 60);
            this.cboVehicleVat.MaxLength = 50;
            this.cboVehicleVat.Name = "cboVehicleVat";
            this.cboVehicleVat.Size = new System.Drawing.Size(216, 21);
            this.cboVehicleVat.TabIndex = 20;
            this.cboVehicleVat.SelectedIndexChanged += new System.EventHandler(this.cboVehicleVat_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(48, 64);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(70, 13);
            this.label18.TabIndex = 11;
            this.label18.Text = "ค่าดำเนินการ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(394, 44);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 13);
            this.label17.TabIndex = 9;
            this.label17.Text = "ราคาอุปกรณ์เสริม";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(75, 44);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(43, 13);
            this.label16.TabIndex = 8;
            this.label16.Text = "ราคารถ";
            // 
            // txtBuyDate
            // 
            this.txtBuyDate.CustomFormat = "dd/MM/yyy";
            this.txtBuyDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtBuyDate.Location = new System.Drawing.Point(488, 19);
            this.txtBuyDate.Name = "txtBuyDate";
            this.txtBuyDate.Size = new System.Drawing.Size(96, 20);
            this.txtBuyDate.TabIndex = 16;
            this.txtBuyDate.ValueChanged += new System.EventHandler(this.txtBuyDate_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(444, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "วันที่ซื้อ";
            // 
            // cboVendor
            // 
            this.cboVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVendor.Location = new System.Drawing.Point(120, 19);
            this.cboVendor.MaxLength = 50;
            this.cboVendor.Name = "cboVendor";
            this.cboVendor.Size = new System.Drawing.Size(272, 21);
            this.cboVendor.TabIndex = 15;
            this.cboVendor.SelectedIndexChanged += new System.EventHandler(this.cboVendor_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(66, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "ผู้จำหน่าย";
            // 
            // chkSecondHand
            // 
            this.chkSecondHand.AutoSize = true;
            this.chkSecondHand.Location = new System.Drawing.Point(736, 62);
            this.chkSecondHand.Name = "chkSecondHand";
            this.chkSecondHand.Size = new System.Drawing.Size(69, 17);
            this.chkSecondHand.TabIndex = 21;
            this.chkSecondHand.Text = "รถมือสอง";
            this.chkSecondHand.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkSecondHand.CheckedChanged += new System.EventHandler(this.chkSecondHand_CheckedChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(432, 17);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(51, 13);
            this.label20.TabIndex = 14;
            this.label20.Text = "สถานะรถ";
            // 
            // cboVehiclests
            // 
            this.cboVehiclests.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVehiclests.Location = new System.Drawing.Point(488, 13);
            this.cboVehiclests.MaxLength = 50;
            this.cboVehiclests.Name = "cboVehiclests";
            this.cboVehiclests.Size = new System.Drawing.Size(216, 21);
            this.cboVehiclests.TabIndex = 23;
            this.cboVehiclests.SelectedIndexChanged += new System.EventHandler(this.cboVehiclests_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dtpTerminateDate);
            this.groupBox4.Controls.Add(this.lblTerminateDate);
            this.groupBox4.Controls.Add(this.cboKindOfVehicle);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.cboVehiclests);
            this.groupBox4.Location = new System.Drawing.Point(16, 360);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(984, 43);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "อื่น ๆ";
            // 
            // dtpTerminateDate
            // 
            this.dtpTerminateDate.CustomFormat = "dd/MM/yyy";
            this.dtpTerminateDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTerminateDate.Location = new System.Drawing.Point(840, 13);
            this.dtpTerminateDate.Name = "dtpTerminateDate";
            this.dtpTerminateDate.Size = new System.Drawing.Size(96, 20);
            this.dtpTerminateDate.TabIndex = 25;
            // 
            // lblTerminateDate
            // 
            this.lblTerminateDate.AutoSize = true;
            this.lblTerminateDate.Location = new System.Drawing.Point(736, 17);
            this.lblTerminateDate.Name = "lblTerminateDate";
            this.lblTerminateDate.Size = new System.Drawing.Size(104, 13);
            this.lblTerminateDate.TabIndex = 24;
            this.lblTerminateDate.Text = "วันที่สิ้นสุดการใช้งาน";
            // 
            // cboKindOfVehicle
            // 
            this.cboKindOfVehicle.Enabled = false;
            this.cboKindOfVehicle.Location = new System.Drawing.Point(120, 13);
            this.cboKindOfVehicle.Name = "cboKindOfVehicle";
            this.cboKindOfVehicle.Size = new System.Drawing.Size(272, 21);
            this.cboKindOfVehicle.TabIndex = 22;
            this.cboKindOfVehicle.SelectedIndexChanged += new System.EventHandler(this.cboKindOfVehicle_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(61, 17);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(57, 13);
            this.label21.TabIndex = 0;
            this.label21.Text = "ประเภทรถ";
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(428, 560);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 25;
            this.cmdSave.Text = "ตกลง";
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdDelete.ForeColor = System.Drawing.Color.Red;
            this.cmdDelete.Location = new System.Drawing.Point(920, 560);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(75, 23);
            this.cmdDelete.TabIndex = 27;
            this.cmdDelete.Text = "ลบ";
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.fpiPlateRunningNo);
            this.groupBox5.Controls.Add(this.txtDepertmentCust);
            this.groupBox5.Controls.Add(this.label42);
            this.groupBox5.Controls.Add(this.txtCompanyCust);
            this.groupBox5.Controls.Add(this.txtthisContractNo);
            this.groupBox5.Controls.Add(this.lblPlateNo);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Controls.Add(this.lblPlatePrefix);
            this.groupBox5.Controls.Add(this.label25);
            this.groupBox5.Controls.Add(this.txtPlateOfPrefix);
            this.groupBox5.Controls.Add(this.label26);
            this.groupBox5.Controls.Add(this.label43);
            this.groupBox5.Controls.Add(this.label44);
            this.groupBox5.Location = new System.Drawing.Point(14, 56);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(984, 45);
            this.groupBox5.TabIndex = 22;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "ทะเบียนรถ";
            // 
            // fpiPlateRunningNo
            // 
            this.fpiPlateRunningNo.AllowClipboardKeys = true;
            this.fpiPlateRunningNo.AllowNull = true;
            this.fpiPlateRunningNo.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiPlateRunningNo.Location = new System.Drawing.Point(184, 15);
            this.fpiPlateRunningNo.MaxValue = 9999;
            this.fpiPlateRunningNo.MinValue = 0;
            this.fpiPlateRunningNo.Name = "fpiPlateRunningNo";
            this.fpiPlateRunningNo.NullColor = System.Drawing.Color.Transparent;
            this.fpiPlateRunningNo.Size = new System.Drawing.Size(56, 20);
            this.fpiPlateRunningNo.TabIndex = 2;
            this.fpiPlateRunningNo.Text = "";
            this.fpiPlateRunningNo.DoubleClick += new System.EventHandler(this.fpiPlateRunningNo_DoubleClick);
            this.fpiPlateRunningNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpiPlateRunningNo_KeyDown);
            this.fpiPlateRunningNo.TextChanged += new System.EventHandler(this.fpiPlateRunningNo_TextChanged);
            // 
            // txtDepertmentCust
            // 
            this.txtDepertmentCust.Enabled = false;
            this.txtDepertmentCust.Location = new System.Drawing.Point(848, 15);
            this.txtDepertmentCust.Name = "txtDepertmentCust";
            this.txtDepertmentCust.Size = new System.Drawing.Size(120, 20);
            this.txtDepertmentCust.TabIndex = 31;
            this.txtDepertmentCust.TabStop = false;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Enabled = false;
            this.label42.Location = new System.Drawing.Point(816, 19);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(26, 13);
            this.label42.TabIndex = 30;
            this.label42.Text = "ฝ่าย";
            // 
            // txtCompanyCust
            // 
            this.txtCompanyCust.Enabled = false;
            this.txtCompanyCust.Location = new System.Drawing.Point(680, 15);
            this.txtCompanyCust.Name = "txtCompanyCust";
            this.txtCompanyCust.Size = new System.Drawing.Size(120, 20);
            this.txtCompanyCust.TabIndex = 29;
            this.txtCompanyCust.TabStop = false;
            // 
            // txtthisContractNo
            // 
            this.txtthisContractNo.Enabled = false;
            this.txtthisContractNo.Location = new System.Drawing.Point(488, 15);
            this.txtthisContractNo.Name = "txtthisContractNo";
            this.txtthisContractNo.Size = new System.Drawing.Size(120, 20);
            this.txtthisContractNo.TabIndex = 27;
            this.txtthisContractNo.TabStop = false;
            // 
            // lblPlateNo
            // 
            this.lblPlateNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPlateNo.Location = new System.Drawing.Point(320, 13);
            this.lblPlateNo.Name = "lblPlateNo";
            this.lblPlateNo.Size = new System.Drawing.Size(72, 24);
            this.lblPlateNo.TabIndex = 15;
            this.lblPlateNo.Text = "1001";
            this.lblPlateNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label23.Location = new System.Drawing.Point(300, 13);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(16, 24);
            this.label23.TabIndex = 14;
            this.label23.Text = "-";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlatePrefix
            // 
            this.lblPlatePrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPlatePrefix.Location = new System.Drawing.Point(248, 13);
            this.lblPlatePrefix.Name = "lblPlatePrefix";
            this.lblPlatePrefix.Size = new System.Drawing.Size(56, 24);
            this.lblPlatePrefix.TabIndex = 13;
            this.lblPlatePrefix.Text = "กท";
            this.lblPlatePrefix.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label25.Location = new System.Drawing.Point(168, 17);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(12, 16);
            this.label25.TabIndex = 12;
            this.label25.Text = "-";
            // 
            // txtPlateOfPrefix
            // 
            this.txtPlateOfPrefix.Location = new System.Drawing.Point(120, 15);
            this.txtPlateOfPrefix.MaxLength = 3;
            this.txtPlateOfPrefix.Name = "txtPlateOfPrefix";
            this.txtPlateOfPrefix.Size = new System.Drawing.Size(40, 20);
            this.txtPlateOfPrefix.TabIndex = 1;
            this.txtPlateOfPrefix.TextChanged += new System.EventHandler(this.txtPlateOfPrefix_TextChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(42, 19);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(76, 13);
            this.label26.TabIndex = 10;
            this.label26.Text = "เลขทะเบียนรถ";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Enabled = false;
            this.label43.Location = new System.Drawing.Point(622, 19);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(60, 13);
            this.label43.TabIndex = 28;
            this.label43.Text = "บริษัทลูกค้า";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Enabled = false;
            this.label44.Location = new System.Drawing.Point(389, 19);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(94, 13);
            this.label44.TabIndex = 26;
            this.label44.Text = "เลขที่สัญญาปัจจุบัน";
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(508, 560);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 26;
            this.cmdCancel.Text = "ยกเลิก";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.fpdSumAssured);
            this.groupBox6.Controls.Add(this.fpdInsuranceAmount);
            this.groupBox6.Controls.Add(this.label40);
            this.groupBox6.Controls.Add(this.label39);
            this.groupBox6.Controls.Add(this.label38);
            this.groupBox6.Controls.Add(this.txtEndDateInsuranceTypeOne);
            this.groupBox6.Controls.Add(this.txtStartDateInsuranceTypeOne);
            this.groupBox6.Controls.Add(this.label29);
            this.groupBox6.Controls.Add(this.label28);
            this.groupBox6.Controls.Add(this.txtPolicyNoInsuranceTypeOne);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.fpiOrderNo);
            this.groupBox6.Enabled = false;
            this.groupBox6.Location = new System.Drawing.Point(16, 406);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(492, 106);
            this.groupBox6.TabIndex = 24;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "ประกันภัย";
            // 
            // fpdSumAssured
            // 
            this.fpdSumAssured.Location = new System.Drawing.Point(352, 61);
            this.fpdSumAssured.Name = "fpdSumAssured";
            this.fpdSumAssured.Size = new System.Drawing.Size(100, 20);
            this.fpdSumAssured.TabIndex = 105;
            this.fpdSumAssured.Text = "0";
            this.fpdSumAssured.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // fpdInsuranceAmount
            // 
            this.fpdInsuranceAmount.Location = new System.Drawing.Point(352, 21);
            this.fpdInsuranceAmount.Name = "fpdInsuranceAmount";
            this.fpdInsuranceAmount.Size = new System.Drawing.Size(72, 20);
            this.fpdInsuranceAmount.TabIndex = 100;
            this.fpdInsuranceAmount.Text = "0";
            this.fpdInsuranceAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(280, 25);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(71, 13);
            this.label40.TabIndex = 106;
            this.label40.Text = "ค่าเบี้ยประกัน";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(296, 65);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(55, 13);
            this.label39.TabIndex = 102;
            this.label39.Text = "ทุนประกัน";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(79, 65);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(39, 13);
            this.label38.TabIndex = 100;
            this.label38.Text = "ลำดับที่";
            // 
            // txtEndDateInsuranceTypeOne
            // 
            this.txtEndDateInsuranceTypeOne.Location = new System.Drawing.Point(352, 41);
            this.txtEndDateInsuranceTypeOne.Name = "txtEndDateInsuranceTypeOne";
            this.txtEndDateInsuranceTypeOne.Size = new System.Drawing.Size(100, 20);
            this.txtEndDateInsuranceTypeOne.TabIndex = 11;
            this.txtEndDateInsuranceTypeOne.TabStop = false;
            // 
            // txtStartDateInsuranceTypeOne
            // 
            this.txtStartDateInsuranceTypeOne.Location = new System.Drawing.Point(120, 41);
            this.txtStartDateInsuranceTypeOne.Name = "txtStartDateInsuranceTypeOne";
            this.txtStartDateInsuranceTypeOne.Size = new System.Drawing.Size(100, 20);
            this.txtStartDateInsuranceTypeOne.TabIndex = 10;
            this.txtStartDateInsuranceTypeOne.TabStop = false;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(296, 45);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(55, 13);
            this.label29.TabIndex = 9;
            this.label29.Text = "วันที่สิ้นสุด";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(57, 45);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(61, 13);
            this.label28.TabIndex = 6;
            this.label28.Text = "วันที่เริ่มต้น";
            // 
            // txtPolicyNoInsuranceTypeOne
            // 
            this.txtPolicyNoInsuranceTypeOne.Enabled = false;
            this.txtPolicyNoInsuranceTypeOne.Location = new System.Drawing.Point(120, 21);
            this.txtPolicyNoInsuranceTypeOne.Name = "txtPolicyNoInsuranceTypeOne";
            this.txtPolicyNoInsuranceTypeOne.Size = new System.Drawing.Size(144, 20);
            this.txtPolicyNoInsuranceTypeOne.TabIndex = 99;
            this.txtPolicyNoInsuranceTypeOne.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "เลขที่กรมธรรม์";
            // 
            // fpiOrderNo
            // 
            this.fpiOrderNo.BackColor = System.Drawing.SystemColors.Control;
            this.fpiOrderNo.Enabled = false;
            this.fpiOrderNo.Location = new System.Drawing.Point(120, 61);
            this.fpiOrderNo.Name = "fpiOrderNo";
            this.fpiOrderNo.Size = new System.Drawing.Size(56, 20);
            this.fpiOrderNo.TabIndex = 104;
            this.fpiOrderNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "เลขที่พ.ร.บ.";
            // 
            // txtPolicyNoCompulsory
            // 
            this.txtPolicyNoCompulsory.Enabled = false;
            this.txtPolicyNoCompulsory.Location = new System.Drawing.Point(80, 16);
            this.txtPolicyNoCompulsory.Name = "txtPolicyNoCompulsory";
            this.txtPolicyNoCompulsory.Size = new System.Drawing.Size(136, 20);
            this.txtPolicyNoCompulsory.TabIndex = 4;
            this.txtPolicyNoCompulsory.TabStop = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.fpdCompulsoryAmount);
            this.groupBox7.Controls.Add(this.label41);
            this.groupBox7.Controls.Add(this.txtEndDateCompulsory);
            this.groupBox7.Controls.Add(this.txtStartDateCompulsory);
            this.groupBox7.Controls.Add(this.label30);
            this.groupBox7.Controls.Add(this.label31);
            this.groupBox7.Controls.Add(this.txtPolicyNoCompulsory);
            this.groupBox7.Controls.Add(this.label14);
            this.groupBox7.Enabled = false;
            this.groupBox7.Location = new System.Drawing.Point(508, 406);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(492, 62);
            this.groupBox7.TabIndex = 25;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "พ.ร.บ.";
            // 
            // fpdCompulsoryAmount
            // 
            this.fpdCompulsoryAmount.Location = new System.Drawing.Point(280, 16);
            this.fpdCompulsoryAmount.Name = "fpdCompulsoryAmount";
            this.fpdCompulsoryAmount.Size = new System.Drawing.Size(72, 20);
            this.fpdCompulsoryAmount.TabIndex = 109;
            this.fpdCompulsoryAmount.Text = "0";
            this.fpdCompulsoryAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(232, 20);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(49, 13);
            this.label41.TabIndex = 108;
            this.label41.Text = "ค่าพ.ร.บ.";
            // 
            // txtEndDateCompulsory
            // 
            this.txtEndDateCompulsory.Location = new System.Drawing.Point(280, 36);
            this.txtEndDateCompulsory.Name = "txtEndDateCompulsory";
            this.txtEndDateCompulsory.Size = new System.Drawing.Size(80, 20);
            this.txtEndDateCompulsory.TabIndex = 15;
            this.txtEndDateCompulsory.TabStop = false;
            // 
            // txtStartDateCompulsory
            // 
            this.txtStartDateCompulsory.Location = new System.Drawing.Point(80, 36);
            this.txtStartDateCompulsory.Name = "txtStartDateCompulsory";
            this.txtStartDateCompulsory.Size = new System.Drawing.Size(80, 20);
            this.txtStartDateCompulsory.TabIndex = 14;
            this.txtStartDateCompulsory.TabStop = false;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(224, 40);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(55, 13);
            this.label30.TabIndex = 13;
            this.label30.Text = "วันที่สิ้นสุด";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(16, 40);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(61, 13);
            this.label31.TabIndex = 10;
            this.label31.Text = "วันที่เริ่มต้น";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label45);
            this.groupBox8.Controls.Add(this.txtEndDateVehicleTax);
            this.groupBox8.Controls.Add(this.txtStartDateVehicleTax);
            this.groupBox8.Controls.Add(this.label32);
            this.groupBox8.Controls.Add(this.label27);
            this.groupBox8.Controls.Add(this.fpdVehicleTaxAmount);
            this.groupBox8.Enabled = false;
            this.groupBox8.Location = new System.Drawing.Point(508, 464);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(492, 48);
            this.groupBox8.TabIndex = 26;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "ภาษีรถยนต์";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(344, 20);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(39, 13);
            this.label45.TabIndex = 110;
            this.label45.Text = "ค่าภาษี";
            // 
            // txtEndDateVehicleTax
            // 
            this.txtEndDateVehicleTax.Location = new System.Drawing.Point(248, 16);
            this.txtEndDateVehicleTax.Name = "txtEndDateVehicleTax";
            this.txtEndDateVehicleTax.Size = new System.Drawing.Size(80, 20);
            this.txtEndDateVehicleTax.TabIndex = 13;
            this.txtEndDateVehicleTax.TabStop = false;
            // 
            // txtStartDateVehicleTax
            // 
            this.txtStartDateVehicleTax.Location = new System.Drawing.Point(80, 16);
            this.txtStartDateVehicleTax.Name = "txtStartDateVehicleTax";
            this.txtStartDateVehicleTax.Size = new System.Drawing.Size(80, 20);
            this.txtStartDateVehicleTax.TabIndex = 12;
            this.txtStartDateVehicleTax.TabStop = false;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(184, 20);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(55, 13);
            this.label32.TabIndex = 11;
            this.label32.Text = "วันที่สิ้นสุด";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(16, 20);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(61, 13);
            this.label27.TabIndex = 8;
            this.label27.Text = "วันที่เริ่มต้น";
            // 
            // fpdVehicleTaxAmount
            // 
            this.fpdVehicleTaxAmount.Location = new System.Drawing.Point(392, 16);
            this.fpdVehicleTaxAmount.Name = "fpdVehicleTaxAmount";
            this.fpdVehicleTaxAmount.Size = new System.Drawing.Size(72, 20);
            this.fpdVehicleTaxAmount.TabIndex = 111;
            this.fpdVehicleTaxAmount.Text = "0";
            this.fpdVehicleTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbRemark
            // 
            this.lbRemark.AutoSize = true;
            this.lbRemark.Location = new System.Drawing.Point(24, 528);
            this.lbRemark.Name = "lbRemark";
            this.lbRemark.Size = new System.Drawing.Size(52, 13);
            this.lbRemark.TabIndex = 27;
            this.lbRemark.Text = "หมายเหตุ";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(88, 524);
            this.txtRemark.MaxLength = 60;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(904, 20);
            this.txtRemark.TabIndex = 24;
            this.txtRemark.TextChanged += new System.EventHandler(this.txtRemark_TextChanged);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.txtPOXXX);
            this.groupBox9.Controls.Add(this.txtPOMM);
            this.groupBox9.Controls.Add(this.txtPOYY);
            this.groupBox9.Controls.Add(this.label46);
            this.groupBox9.Location = new System.Drawing.Point(14, 8);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(222, 45);
            this.groupBox9.TabIndex = 32;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Purchase Order";
            // 
            // txtPOXXX
            // 
            this.txtPOXXX.Location = new System.Drawing.Point(177, 17);
            this.txtPOXXX.MaxLength = 3;
            this.txtPOXXX.Name = "txtPOXXX";
            this.txtPOXXX.Size = new System.Drawing.Size(30, 20);
            this.txtPOXXX.TabIndex = 18;
            this.txtPOXXX.DoubleClick += new System.EventHandler(this.txtPOXXX_DoubleClick);
            this.txtPOXXX.TextChanged += new System.EventHandler(this.txtPOXXX_TextChanged);
            this.txtPOXXX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPOXXX_KeyPress);
            // 
            // txtPOMM
            // 
            this.txtPOMM.Location = new System.Drawing.Point(148, 17);
            this.txtPOMM.MaxLength = 2;
            this.txtPOMM.Name = "txtPOMM";
            this.txtPOMM.Size = new System.Drawing.Size(30, 20);
            this.txtPOMM.TabIndex = 17;
            this.txtPOMM.DoubleClick += new System.EventHandler(this.txtPOMM_DoubleClick);
            this.txtPOMM.TextChanged += new System.EventHandler(this.txtPOMM_TextChanged);
            this.txtPOMM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPOMM_KeyPress);
            // 
            // txtPOYY
            // 
            this.txtPOYY.Location = new System.Drawing.Point(119, 17);
            this.txtPOYY.MaxLength = 2;
            this.txtPOYY.Name = "txtPOYY";
            this.txtPOYY.Size = new System.Drawing.Size(30, 20);
            this.txtPOYY.TabIndex = 16;
            this.txtPOYY.DoubleClick += new System.EventHandler(this.txtPOYY_DoubleClick);
            this.txtPOYY.TextChanged += new System.EventHandler(this.txtPOYY_TextChanged);
            this.txtPOYY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPOYY_KeyPress);
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(16, 21);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(102, 13);
            this.label46.TabIndex = 15;
            this.label46.Text = "PO #            PTB-P-";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.lblVehicleNo);
            this.groupBox10.Controls.Add(this.txtVendorDate);
            this.groupBox10.Controls.Add(this.txtPODate);
            this.groupBox10.Controls.Add(this.label49);
            this.groupBox10.Controls.Add(this.label51);
            this.groupBox10.Location = new System.Drawing.Point(241, 8);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(757, 45);
            this.groupBox10.TabIndex = 128;
            this.groupBox10.TabStop = false;
            // 
            // lblVehicleNo
            // 
            this.lblVehicleNo.AutoSize = true;
            this.lblVehicleNo.Location = new System.Drawing.Point(416, 21);
            this.lblVehicleNo.Name = "lblVehicleNo";
            this.lblVehicleNo.Size = new System.Drawing.Size(59, 13);
            this.lblVehicleNo.TabIndex = 134;
            this.lblVehicleNo.Text = "Vehicle No";
            this.lblVehicleNo.Visible = false;
            // 
            // txtVendorDate
            // 
            this.txtVendorDate.Enabled = false;
            this.txtVendorDate.Location = new System.Drawing.Point(282, 17);
            this.txtVendorDate.Name = "txtVendorDate";
            this.txtVendorDate.Size = new System.Drawing.Size(120, 20);
            this.txtVendorDate.TabIndex = 133;
            this.txtVendorDate.TabStop = false;
            // 
            // txtPODate
            // 
            this.txtPODate.Enabled = false;
            this.txtPODate.Location = new System.Drawing.Point(72, 17);
            this.txtPODate.Name = "txtPODate";
            this.txtPODate.Size = new System.Drawing.Size(120, 20);
            this.txtPODate.TabIndex = 132;
            this.txtPODate.TabStop = false;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(212, 21);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(67, 13);
            this.label49.TabIndex = 131;
            this.label49.Text = "Vendor Date";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(16, 21);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(51, 13);
            this.label51.TabIndex = 127;
            this.label51.Text = "PO  Date";
            // 
            // frmVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1010, 592);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.lbRemark);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.Name = "frmVehicle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVehicle_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpdOperationFee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpdOptionAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpdVehicleAmount)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region - private -
		private bool isReadonly = true;
		private VehicleFacade facadeVehicle;
		private KindOfVehicle kindOfVehicle;
		private VehicleInfo objVehicleInfo;
		private CompulsoryInsurance objCompulsoryInsurance;
		private VehicleTax objVehicleTax;
		private InsuranceTypeOne objInsuranceTypeOne;
		private frmMain mdiParent;
		private VehicleInsuranceTypeOne objVehicleInsuranceTypeOne;

		bool addMode = false;
		bool updateMode = false;

        private const string VEHICLE_PURCHASE_NO = "PTB-P-";
		
		#endregion

		//		============================== Property ==============================
		public VehicleInfo getVehicle()
		{
			objVehicleInfo.PlatePrefix = txtNewPlatePrefix.Text;                    
			objVehicleInfo.PlateRunningNo = fpiNewPlateRunningNo.Text;
			objVehicleInfo.PlateProvince.Name = cboProvince.Text;
			objVehicleInfo.PlateStatus = CTFunction.GetPlatestatusType(cboPlateStatus.Text);
			objVehicleInfo.RegisterDate = txtRegisterDate.Value.Date;

			objVehicleInfo.EngineNo = txtEngineNo.Text;
			objVehicleInfo.ChassisNo = txtChassisNo.Text;
			objVehicleInfo.AModel = (Model)cboModel.SelectedItem;
			objVehicleInfo.AColor = (Entity.VehicleEntities.Color)cboColor.SelectedItem;
			objVehicleInfo.LatestMileage = Convert.ToInt32(txtLatestMileage.Value);
			objVehicleInfo.LatestMileageUpdateDate = txtLatestMileageUpdateDate.Value.Date;
			objVehicleInfo.AVendor= (Vendor)cboVendor.SelectedItem;
			objVehicleInfo.BuyDate = txtBuyDate.Value.Date;
			objVehicleInfo.VehicleAmount = Convert.ToDecimal(fpdVehicleAmount.Value);
			objVehicleInfo.OptionAmount = Convert.ToDecimal(fpdOptionAmount.Value);
			objVehicleInfo.OperationFee = Convert.ToDecimal(fpdOperationFee.Value);
			objVehicleInfo.VatStatus = (VehicleVatStatus)cboVehicleVat.SelectedItem;
			objVehicleInfo.AKindOfVehicle = (KindOfVehicle)cboKindOfVehicle.SelectedItem;
			if(chkSecondHand.Checked)
			{
				objVehicleInfo.IsSecondHand = SECOND_HAND_STATUS_TYPE.SECOND_HAND_YES;
			}
			else
			{
				objVehicleInfo.IsSecondHand = SECOND_HAND_STATUS_TYPE.SECOND_HAND_NO;;
			}
			objVehicleInfo.AVehicleStatus= (VehicleStatus) cboVehiclests.SelectedItem;

			VehicleStatus vehicleStatus = (VehicleStatus)cboVehiclests.SelectedItem;
			if(vehicleStatus.Code == "4" || vehicleStatus.Code == "5" || vehicleStatus.Code == "6"  )
			{
				objVehicleInfo.TerminationDate = dtpTerminateDate.Value.Date;
			}
			else
			{
				objVehicleInfo.TerminationDate = NullConstant.DATETIME;
			}

			objVehicleInfo.Remark = txtRemark.Text;
			return objVehicleInfo;
		}

		public void setVehicle(VehicleInfo value)
		{
			txtNewPlatePrefix.Text = value.PlatePrefix;
			fpiNewPlateRunningNo.Text = value.PlateRunningNo;
			lblPlatePrefix.Text = value.PlatePrefix;
			lblPlateNo.Text =  value.PlateRunningNo;
			cboProvince.Text = value.PlateProvince.Name;
			cboPlateStatus.Text = GUIFunction.GetString(value.PlateStatus);
			txtRegisterDate.Value = value.RegisterDate;

			ContractBase contractBase = facadeVehicle.GetCurrentVehicleContract(value);
			if (contractBase != null && contractBase.AContractStatus.Code.Equals("2"))
			{
				txtthisContractNo.Text = contractBase.ContractNo.ToString();
				txtCompanyCust.Text = contractBase.ACustomer.ShortName;
				txtDepertmentCust.Text = contractBase.ACustomerDepartment.ShortName;			
			}
			contractBase = null;

			YearMonth yearMonth1 = facadeVehicle.CalculateAge(value.RegisterDate);
			fpiRegisterYear.Text = Convert.ToString(yearMonth1.Year);
			fpiRegisterMonth.Text = Convert.ToString(yearMonth1.Month);

			txtEngineNo.Text = value.EngineNo;
			txtChassisNo.Text = value.ChassisNo;
			cboBrand.Text = value.AModel.ABrand.AName.English;
			cboModel.Text = value.AModel.AName.English;
			cboColor.Text = value.AColor.AName.English;
			txtLatestMileage.Text = GUIFunction.GetString(value.LatestMileage);
			txtLatestMileageUpdateDate.Value = value.LatestMileageUpdateDate;
			cboVendor.Text = value.AVendor.ADescription.Thai;
			txtBuyDate.Value = value.BuyDate;

			YearMonth yearMonth2 = facadeVehicle.CalculateAge(value.BuyDate);
			fpiBuyYear.Text = Convert.ToString(yearMonth2.Year);
			fpiBuyMonth.Text = Convert.ToString(yearMonth2.Month);

			fpdVehicleAmount.Value = value.VehicleAmount;
			fpdOptionAmount.Value = value.OptionAmount;
			fpdOperationFee.Value = value.OperationFee;
			cboVehicleVat.Text = value.VatStatus.AName.Thai;
			cboKindOfVehicle.Text = value.AKindOfVehicle.AName.English;
			if(objVehicleInfo.IsSecondHand == SECOND_HAND_STATUS_TYPE.SECOND_HAND_YES)
			{
				chkSecondHand.Checked = true;
			}
			else
			{
				chkSecondHand.Checked = false;
			}
			if(value.AVehicleStatus.Code == "2" || value.AVehicleStatus.Code == "3")
			{
				cboVehiclests.DataSource = facadeVehicle.DataSourceVehicleStatusAll;
				cboVehiclests.Text = value.AVehicleStatus.AName.Thai;
				cboVehiclests.Enabled = false;
			}
			else
			{
				cboVehiclests.DataSource = facadeVehicle.DataSourceVehicleStatus;
				cboVehiclests.Text = value.AVehicleStatus.AName.Thai;
				cboVehiclests.Enabled = true;
			}
			if(value.TerminationDate == NullConstant.DATETIME)
			{
				dtpTerminateDate.Value = DateTime.Today;
			}
			else
			{
				dtpTerminateDate.Value = value.TerminationDate;
			}
			txtRemark.Text = value.Remark;
		}

		public void setInsuranceTypeOne(InsuranceTypeOne value)
		{
			txtPolicyNoInsuranceTypeOne.Text = value.PolicyNo;

			if(value.APeriod.From != NullConstant.DATETIME)
			{
				txtStartDateInsuranceTypeOne.Text = value.APeriod.From.ToShortDateString();
			}
			else
			{
				txtStartDateInsuranceTypeOne.Text = "";
			}

			if(value.APeriod.From != NullConstant.DATETIME)
			{
				txtEndDateInsuranceTypeOne.Text = value.APeriod.To.ToShortDateString();
			}
			else
			{
				txtEndDateInsuranceTypeOne.Text = "";
			}
		}

		public void setVehicleInsuranceTypeOne(VehicleInsuranceTypeOne value)
		{
			if (value.PremiumAmount != NullConstant.DECIMAL)
				fpdInsuranceAmount.Text = Convert.ToString(value.PremiumAmount);
			else
				fpdInsuranceAmount.Text = "0";

			fpiOrderNo.Text = Convert.ToString(value.OrderNo);
			fpdSumAssured.Text = Convert.ToString(value.SumAssured);
		}

		public void setCompulsoryInsurance(CompulsoryInsurance value)
		{
			txtPolicyNoCompulsory.Text = value.PolicyNo;

			if (value.PremiumAmount != NullConstant.DECIMAL)
				fpdCompulsoryAmount.Text = Convert.ToString(value.PremiumAmount);
			else
				fpdCompulsoryAmount.Text = "0";

			if(value.APeriod.From != NullConstant.DATETIME)
			{
				txtStartDateCompulsory.Text = value.APeriod.From.ToShortDateString();
			}
			else
			{
				txtStartDateCompulsory.Text = "";
			}

			if(value.APeriod.To != NullConstant.DATETIME)
			{
				txtEndDateCompulsory.Text = value.APeriod.To.ToShortDateString();
			}
			else
			{
				txtEndDateCompulsory.Text = "";
			}
		}

		public void setVehicleTax(VehicleTax value)
		{
			if (objVehicleTax.TaxAmount != NullConstant.DECIMAL)
				fpdVehicleTaxAmount.Text = Convert.ToString(value.TaxAmount);
			else
				fpdVehicleTaxAmount.Text = "0";

			if(value.APeriod.From != NullConstant.DATETIME)
			{
				txtStartDateVehicleTax.Text = value.APeriod.From.ToShortDateString();
			}
			else
			{
				txtStartDateVehicleTax.Text = "";
			}
			if(value.APeriod.To != NullConstant.DATETIME)
			{
				txtEndDateVehicleTax.Text = value.APeriod.To.ToShortDateString();
			}
			else
			{
				txtEndDateVehicleTax.Text = "";
			}
		}

        public void setVehicleVendor()
        {
            cboVendor.DataSource = facadeVehicle.DataSourceVendor;
            cboVendor.SelectedIndex = -1;
        }

		//		==============================Constructor ==============================
		public frmVehicle():base()
		{
			InitializeComponent();
			facadeVehicle = new VehicleFacade();
			objVehicleTax = new VehicleTax();	
			objVehicleInfo = new VehicleInfo();
			objCompulsoryInsurance = new CompulsoryInsurance();
			objInsuranceTypeOne = new InsuranceTypeOne(facadeVehicle.GetCompany());
			objVehicleInsuranceTypeOne = new VehicleInsuranceTypeOne();
			isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleVehicleVehicle");

			try
			{
				cboProvince.DataSource = facadeVehicle.DataSourceProvince;
				cboPlateStatus.DataSource = facadeVehicle.DataSourcePlateStatus;
				cboBrand.DataSource = facadeVehicle.DataSourceBrand;
				cboColor.DataSource = facadeVehicle.DataSourceColor;
				cboKindOfVehicle.DataSource = facadeVehicle.DataSourceKindOfVehicle;
				cboVehicleVat.DataSource = facadeVehicle.DataSourceVehicleVatStatus;
				cboVendor.DataSource = facadeVehicle.DataSourceVendor;
				cboVehiclests.DataSource = facadeVehicle.DataSourceVehicleStatus;

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
			{
			}
		}

        public int MasterCount()
        {
			return 0;
		}

        public string FormID()
        {
            return UserProfile.GetFormID("miVehicle", "miVehicleVehicleVehicle");
        }

//		============================== private method ==============================
		private void clearkey()
		{
			txtPlateOfPrefix.Text = "";
			fpiPlateRunningNo.Text = "";

            txtPOYY.Text = "";
            txtPOMM.Text = "";
            txtPOXXX.Text = "";
		}

		private void clearForm()
		{
			cboProvince.Text = "กรุงเทพมหานคร";
			cboPlateStatus.SelectedIndex = 1;
			txtRegisterDate.Value  = DateTime.Today;

			txtthisContractNo.Text = "";
			txtCompanyCust.Text = "";
			txtDepertmentCust.Text  = "";

			txtEngineNo.Text = "";
			txtChassisNo.Text = "";
			cboBrand.SelectedIndex = -1;
			cboModel.SelectedIndex = -1;
			cboColor.SelectedIndex = -1;
			txtLatestMileage.Text = "0";
			txtLatestMileageUpdateDate.Value = DateTime.Today;
			cboVendor.SelectedIndex = -1;
			txtBuyDate.Value = DateTime.Today;
			fpdVehicleAmount.Text = "0";
			fpdOptionAmount.Text = "0";
			fpdOperationFee.Text = "0";
			cboVehicleVat.SelectedIndex = 0;
			cboKindOfVehicle.Text = "";
			cboVehiclests.SelectedIndex = 0;
			chkSecondHand.Checked = false;
			txtRemark.Text  = "";
			addMode = false;
			updateMode = false;

			lblTerminateDate.Visible = false;
		}

		private void clearInsuranceTypeOne()
		{
			txtPolicyNoInsuranceTypeOne.Text = "";
			fpdInsuranceAmount.Text = "0";
			txtStartDateInsuranceTypeOne.Text = "";
			txtEndDateInsuranceTypeOne.Text = "";
		}

		private void clearVehicleInsuranceTypeOne()
		{
			fpiOrderNo.Text = "";
			fpdSumAssured.Text = "";
		}

		private void clearCompulsory()
		{
			txtPolicyNoCompulsory.Text = "";
			fpdCompulsoryAmount.Text = "0";
			txtStartDateCompulsory.Text = "";
			txtEndDateCompulsory.Text = "";
		}

		private void clearVehicleTax()
		{
			fpdVehicleTaxAmount.Text = "0";
			txtEndDateVehicleTax.Text = "";
			txtStartDateVehicleTax.Text = "";
		}

		private void hideForm()
		{
			groupBox1.Hide();
			groupBox2.Hide();
			groupBox3.Hide();
			groupBox4.Hide();
			groupBox5.Enabled= true;
			cmdSave.Hide();
			cmdDelete.Hide();
			cmdCancel.Hide();
			groupBox6.Hide();
			groupBox7.Hide();
			groupBox8.Hide();
			cmdSave.Enabled = false;
			txtPlateOfPrefix.Focus();
			lbRemark.Hide();
			txtRemark.Hide();
			label44.Hide();
			label43.Hide();
			label42.Hide();
			txtthisContractNo.Hide();
			txtCompanyCust.Hide();
			txtDepertmentCust.Hide();

            groupBox9.Enabled = true;
            groupBox10.Hide();

		}

		private void showForm()
		{
			groupBox1.Show();
			groupBox2.Show();
			groupBox3.Show();
			groupBox4.Show();
			groupBox5.Enabled = false;
			cboKindOfVehicle.Enabled = false;
			cmdSave.Show();
			cmdDelete.Show();
			cmdCancel.Show();
			groupBox6.Show();
			groupBox7.Show();
			groupBox8.Show();
			cmdSave.Enabled = true;
			lbRemark.Show();
			txtRemark.Show();
			label44.Show();
			label43.Show();
			label42.Show();
			txtthisContractNo.Show();
			txtCompanyCust.Show();
			txtDepertmentCust.Show();

            groupBox9.Enabled = false;
            groupBox10.Show();

		}

		private bool ValidateForm()
		{
			return validatePrefix() && validatePlateNo() && validate3() && validate4() && validate5() && validate6() && validate7() && validate8()&& validate9() && validate11() && validate12() && validate15()&& validate16();
		}

		#region - validate -
		private bool validate1()
		{
			if (txtPlateOfPrefix.Text.Trim() == "")
			{
				Message(MessageList.Error.E0002, "เลขทะเบียนรถ" );
				txtPlateOfPrefix.Text = "";
				txtPlateOfPrefix.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool validate2()
		{
			if (fpiPlateRunningNo.Text.Trim() == "")
			{
				Message(MessageList.Error.E0002, "เลขทะเบียนรถ" );
				fpiPlateRunningNo.Text = "";
				fpiPlateRunningNo.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool validatePrefix()
		{
			if (txtNewPlatePrefix.Text.Trim() == "")
			{
				Message(MessageList.Error.E0002, "เลขทะเบียนรถ" );
				txtNewPlatePrefix.Text = "";
				txtNewPlatePrefix.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool validatePlateNo()
		{
			if (fpiNewPlateRunningNo.Text.Trim() == "")
			{
				Message(MessageList.Error.E0002, "เลขทะเบียนรถ" );
				fpiNewPlateRunningNo.Text = "";
				fpiNewPlateRunningNo.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool validate3()
		{
			if (cboProvince.Text == "")
			{
				Message(MessageList.Error.E0002, "จังหวัด" );
				cboProvince.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool validate4()
		{
			if (cboPlateStatus.Text == "")
			{
				Message(MessageList.Error.E0005, "สถานะป้ายทะเบียน" );
				cboPlateStatus.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool validate5()
		{
			if (cboBrand.Text == "")
			{
				Message(MessageList.Error.E0005, "ยี่ห้อรถ" );
				cboBrand.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool validate6()
		{
			if (txtEngineNo.Text == "")
			{
				Message(MessageList.Error.E0002, "หมายเลขเครื่องยนต์" );
				txtEngineNo.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool validate7()
		{
			if (cboModel.Text == "")
			{
				Message(MessageList.Error.E0005, "รุ่นรถ" );
				cboModel.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool validate8()
		{
			if (txtChassisNo.Text == "")
			{
				Message(MessageList.Error.E0002, "หมายเลขตัวถัง" );
				txtChassisNo.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		
		
		private bool validate9()
		{
			if (cboColor.Text == "")
			{
				Message(MessageList.Error.E0005, "สี" );
				cboColor.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		
		private bool validate11()
		{
			if (cboVendor.Text == "")
			{
				Message(MessageList.Error.E0005, "ผู้จำหน่าย" );
				cboVendor.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}

		private bool validate12()
		{
			if (fpdVehicleAmount.Text == "0.00")
			{
				Message(MessageList.Error.E0002, "ราคารถ" );
				fpdVehicleAmount.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
	
		private bool validate15()
		{
			if (cboVehicleVat.Text == "")
			{
				Message(MessageList.Error.E0005, "สถานะภาษีรถ" );
				cboVehicleVat.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}

		private bool validate16()
		{
			if (cboVehiclests.Text == "")
			{
				Message(MessageList.Error.E0005, "สถานะรถ" );
				cboVehiclests.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}
		#endregion
		
//		============================== Base event ==============================
        public void InitForm()
		{
			
			mdiParent.EnableNewCommand(false);
			mdiParent.EnableDeleteCommand(false);
			mdiParent.EnableRefreshCommand(false);
			mdiParent.EnablePrintCommand(false);
			clearMainMenuStatus();

			clearkey();
			clearForm();
			lblPlatePrefix.Text = "";
			lblPlateNo.Text = "";
			hideForm();
			clearCompulsory();
			clearInsuranceTypeOne();
			clearVehicleTax();

			IsMustQuestion = false;			
		}

        public void RefreshForm()
		{
			try
			{
				    objVehicleInfo = new VehicleInfo();
				objVehicleInfo.PlatePrefix = txtPlateOfPrefix.Text;                    
				objVehicleInfo.PlateRunningNo = fpiPlateRunningNo.Text;
                //add by Thawatchai B. 28/11/08
                if(lblVehicleNo.Text != "Vehicle No")
                    objVehicleInfo.VehicleNo = Convert.ToInt32(lblVehicleNo.Text);
                //end add
				txtNewPlatePrefix.Text = txtPlateOfPrefix.Text;
				fpiNewPlateRunningNo.Text = fpiPlateRunningNo.Text;
				lblPlatePrefix.Text = txtPlateOfPrefix.Text;
				lblPlateNo.Text = fpiPlateRunningNo.Text;

					if (facadeVehicle.DisplayVehicleInfo(ref objVehicleInfo))
					{
						mdiParent.EnableNewCommand(true);
						mdiParent.EnableDeleteCommand(false);
						mdiParent.EnableRefreshCommand(false);
						mdiParent.EnablePrintCommand(false);
						MainMenuNewStatus = true;
						MainMenuDeleteStatus = false;
						MainMenuRefreshStatus = false;
						MainMenuPrintStatus = false;


						baseEDIT();
						this.Text = "แก้ไข" + UserProfile.GetFormName("miVehicle", "miVehicleVehicleVehicle");
						clearForm();
						clearCompulsory();
						clearInsuranceTypeOne();
						clearVehicleTax();
						setVehicle(objVehicleInfo);
						txtNewPlatePrefix.Focus();

						IsMustQuestion = false;

						txtLatestMileage.Enabled = false;
						txtLatestMileageUpdateDate.Enabled = false;
						label1.Enabled = true;
						txtNewPlatePrefix.Enabled = true;
						fpiNewPlateRunningNo.Enabled = true;
						cmdDelete.Enabled = true;
						showForm();

						switch(objVehicleInfo.AVehicleStatus.Code)
						{
							case "2":
							case "3":
							{
								cboVehiclests.Enabled = false;
								break;
							}
								
							default:
							{
								cboVehiclests.Enabled = true;
                                break;
							}
						}

						objCompulsoryInsurance = new CompulsoryInsurance();
						objCompulsoryInsurance.AVehicle = objVehicleInfo;
						if (facadeVehicle.FillCurrentCompulsoryInsurance(ref objCompulsoryInsurance))
						{
							setCompulsoryInsurance(objCompulsoryInsurance);
						}
						else
						{
							clearCompulsory();
						}

						objInsuranceTypeOne = facadeVehicle.GetLatestInsuranceTypeOne(objVehicleInfo);
						if (objInsuranceTypeOne != null)
						{
							setInsuranceTypeOne(objInsuranceTypeOne);
						}
						else
						{
							clearInsuranceTypeOne();
						}
						objVehicleInsuranceTypeOne = facadeVehicle.GetInsuranceTypeOneDetail(objVehicleInfo, txtPolicyNoInsuranceTypeOne.Text);
						if(objVehicleInsuranceTypeOne != null)
						{
							setVehicleInsuranceTypeOne(objVehicleInsuranceTypeOne);
						}
						else
						{
							clearVehicleInsuranceTypeOne();
						}

						objVehicleTax = new VehicleTax();
						Vehicle vehicle = new Vehicle();
						vehicle.VehicleNo = objVehicleInfo.VehicleNo;
						objVehicleTax.AVehicle = vehicle;
						if (facadeVehicle.FillCurrentVehicleTax(ref objVehicleTax))
						{
							setVehicleTax(objVehicleTax);
						}
						else
						{
							clearVehicleTax();
						}
						vehicle = null;
					}
					else
					{
                        //baseADD();

						mdiParent.EnableNewCommand(true);
						mdiParent.EnableDeleteCommand(false);
						mdiParent.EnableRefreshCommand(false);
						mdiParent.EnablePrintCommand(false);
						MainMenuNewStatus = true;
						MainMenuDeleteStatus = false;
						MainMenuRefreshStatus = false;
						MainMenuPrintStatus = false;

                        this.Text = "เพิ่ม" + UserProfile.GetFormName("miVehicle", "miVehicleVehicleVehicle");
						cboProvince.Text = "กรุงเทพมหานคร";
						showForm();
						clearForm();
						clearCompulsory();
						clearInsuranceTypeOne();
						clearVehicleTax();
						cboProvince.Focus();

						IsMustQuestion = false;

						kindOfVehicle = facadeVehicle.FillKindOfVehicleZ();
						cboKindOfVehicle.Text = kindOfVehicle.AName.English;
						cmdDelete.Enabled = false;
						txtLatestMileage.Enabled = true;
						txtLatestMileageUpdateDate.Enabled = true;
						label1.Enabled = false;
						txtNewPlatePrefix.Enabled = false;
						fpiNewPlateRunningNo.Enabled = false;
					}

			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(AppExceptionBase ex)
			{
				Message(ex);
			}
			catch(Exception ex)
			{
				Message(ex);
			}

			if(isReadonly)
			{
				cmdSave.Enabled = false;
				cmdDelete.Enabled = false;
			}
		}

        public void PrintForm()
		{
			
		}

        public void ExitForm()
		{
			this.Hide();
			IsMustQuestion = false;
		}

		private bool AddEvent()
		{
			try
			{
				if(ValidateForm())
				{
					if(facadeVehicle.InsertVehicle(getVehicle()))
					{
						InitForm();
						IsMustQuestion = false;
						return true;
					}
					else
					{
						Message(MessageList.Error.E0003);
					}
				}
			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(AppExceptionBase ex)
			{
				Message(ex);
			}
			catch(Exception ex)
			{
				Message(ex);
			}		
			return false;
		}

		private bool EditEvent()
		{
			
			try
			{
				if(ValidateForm())
				{
					if(facadeVehicle.UpdateVehicleInfo(getVehicle()))
					{
						InitForm();
						IsMustQuestion = false;
						return true;
					}
					else
					{
						Message(MessageList.Error.E0003);
						fpiNewPlateRunningNo.Focus();
					}
				}
			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(AppExceptionBase ex)
			{
				Message(ex);
			}
			catch(Exception ex)
			{
				Message(ex);
			}		
			return false;
		}

		private void DeleteEvent()
		{
			try
			{
				if(facadeVehicle.DeleteVehicle(getVehicle()))
				{
					InitForm();
				}
			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(AppExceptionBase ex)
			{
				Message(ex);
			}
			catch(Exception ex)
			{
				Message(ex);
			}	
			
		}

		private void isCommon()
		{
			if (isReadonly)
				IsMustQuestion = false;
			else
				IsMustQuestion = true;

			switch (action)
			{					
				case ActionType.ADD :
					addMode = true;
					break;
				case ActionType.EDIT :
					updateMode = true;
					break;
			}
		}

        private void purchaseNoChange()
        {
            if (txtPOYY.Text.Length == 2 && txtPOMM.Text.Length == 2 && txtPOXXX.Text.Length == 3)
            {
                //RefreshForm();
            }
            else
            {
                if (txtPOYY.Text.Length == 2)
                {
                    if (txtPOMM.Text.Length == 2)
                    {
                        txtPOXXX.Focus();
                    }
                    else
                    {
                        txtPOMM.Focus();
                    }
                }
                else
                {
                    txtPOYY.Focus();
                }
            }
        }

//		============================== event ==============================
		private void cboBrand_SelectedIndexChanged(object sender, System.EventArgs e)
		{			
			if (isReadonly)
				IsMustQuestion = false;
			else
				IsMustQuestion = true;

			if(cboBrand.SelectedIndex != -1)
			{
				Brand brand = (Brand)cboBrand.SelectedItem;
				cboModel.DataSource = facadeVehicle.DataSourceModel(brand);
			}
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			if(IsMustQuestion && !isReadonly)
			{
				DialogResult result = Message(MessageList.Question.Q0003);
				if (result == DialogResult.Yes)
				{
					if(ValidateForm())
					{

						if(addMode)
						{
							if(AddEvent())
								InitForm();
						}
						if(updateMode)
						{
							if(EditEvent())
								InitForm();
						}
						
					}
				}
				else if (result == DialogResult.No)
				{
					this.Hide();
				}
				else if (result == DialogResult.Cancel)
				{
					this.Show();
				}
			}
			else
			{
				this.Hide();
			}
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

		private void cmdDelete_Click(object sender, System.EventArgs e)
		{
			if (Message(MessageList.Question.Q0001) == DialogResult.Yes)
			{
				DeleteEvent();
			}

		}

		private void frmVehicle_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
			IsMustQuestion = false;

			if(action == ActionType.ADD)
			{
				clearForm();
			}
			else
			{
				setVehicle(objVehicleInfo);                
			}

            this.WindowState = FormWindowState.Maximized;
		}

		private void txtPlateOfPrefix_TextChanged(object sender, System.EventArgs e)
		{
			lblPlatePrefix.Text = txtPlateOfPrefix.Text;
            if (txtPlateOfPrefix.Text.Length == txtPlateOfPrefix.MaxLength)
			{
				fpiPlateRunningNo.Focus();
			}
		}

		private void fpiPlateRunningNo_DoubleClick(object sender, System.EventArgs e)
		{
            FrmVehicleList dialogVehicleList = new FrmVehicleList();
			dialogVehicleList.ConditionPlateRunningNo = fpiPlateRunningNo.Text;
			dialogVehicleList.ConditionPlatePrefix = txtPlateOfPrefix.Text;
			dialogVehicleList.ShowDialog();			
			if(dialogVehicleList.Selected)
			{
				setVehicle(facadeVehicle.GetVehicleInfo(dialogVehicleList.SelectedVehicle.VehicleNo));
				txtPlateOfPrefix.Text = dialogVehicleList.SelectedVehicle.PlatePrefix;
				fpiPlateRunningNo.Text = dialogVehicleList.SelectedVehicle.PlateRunningNo;
				RefreshForm();
			}
		}

		private void fpiPlateRunningNo_TextChanged(object sender, System.EventArgs e)
	{
			lblPlateNo.Text = fpiPlateRunningNo.Text;
			if(fpiPlateRunningNo.Text.Length == 4)
			{
				if(validate1())
				{
					if(validate2())
					{
						RefreshForm();
					}
				}
			}
		}

		private void fpiPlateRunningNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == System.Windows.Forms.Keys.Enter)
			{
				if(validate1())
				{
					if(validate2())
					{
						RefreshForm();
					}
				}
			}
		}

		private void txtNewPlatePrefix_TextChanged(object sender, System.EventArgs e)
		{
			isCommon();
		}
		
		private void fpiNewPlateRunningNo_TextChanged(object sender, System.EventArgs e)
		{
			isCommon();
		}

		private void cboProvince_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			isCommon();
		}

		private void cboPlateStatus_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
			isCommon();
		}

		private void txtRegisterDate_ValueChanged(object sender, System.EventArgs e)
		{
			YearMonth yearMonth = facadeVehicle.CalculateAge(txtRegisterDate.Value);
			fpiRegisterYear.Text = Convert.ToString(yearMonth.Year);
			fpiRegisterMonth.Text = Convert.ToString(yearMonth.Month);

			isCommon();
		}

		private void txtEngineNo_TextChanged(object sender, System.EventArgs e)
		{
			isCommon();
		}

		private void cboModel_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			isCommon();
		}

		private void fpdOptionAmount_Leave(object sender, System.EventArgs e)
		{
			try
			{
				Convert.ToDecimal(fpdOptionAmount.Value);
			}
			catch(Exception exc)
			{
				
				throw exc;
			}
			isCommon();
		}

		private void txtChassisNo_TextChanged(object sender, System.EventArgs e)
		{
			isCommon();
		}

		private void cboColor_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			isCommon();
		}

		private void txtLatestMileage_Click(object sender, System.EventArgs e)
		{
			isCommon();
		}

		private void txtLatestMileageUpdateDate_ValueChanged(object sender, System.EventArgs e)
		{
			isCommon();
		}

		private void cboVendor_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			isCommon();
		}

		private void txtBuyDate_ValueChanged(object sender, System.EventArgs e)
		{
			YearMonth yearMonth = facadeVehicle.CalculateAge(txtBuyDate.Value);
			fpiBuyYear.Text = Convert.ToString(yearMonth.Year);
			fpiBuyMonth.Text = Convert.ToString(yearMonth.Month);

			isCommon();
		}

		private void chkSecondHand_CheckedChanged(object sender, System.EventArgs e)
		{
			isCommon();
		}

		private void fpdVehicleAmount_Click(object sender, System.EventArgs e)
		{
			isCommon();
		}

		private void fpdVehicleAmount_Leave(object sender, System.EventArgs e)
		{
			try
			{
				Convert.ToDecimal(fpdVehicleAmount.Value);
			}
			catch(Exception exc)
			{
				
				throw exc;
			}
			isCommon();
		}
		
		private void fpdOptionAmount_Click(object sender, System.EventArgs e)
		{
			isCommon();
		}

		private void fpdOperationFee_Click(object sender, System.EventArgs e)
		{
			isCommon();
		}

		private void fpdOperationFee_Leave(object sender, System.EventArgs e)
		{
			try
			{
				Convert.ToDecimal(fpdOperationFee.Value);
			}
			catch(Exception exc)
			{
				
				throw exc;
			}
			isCommon();
		}

		private void cboVehicleVat_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			isCommon();
		}

		private void cboKindOfVehicle_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			isCommon();
		}

		private void cboVehiclests_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			VehicleStatus vehicleStatus = (VehicleStatus)cboVehiclests.SelectedItem;
			if(vehicleStatus.Code == "4" || vehicleStatus.Code == "5" || vehicleStatus.Code == "6"  )
			{
				lblTerminateDate.Visible = true;
				dtpTerminateDate.Visible = true;
				dtpTerminateDate.Focus();
			}
			else
			{
				lblTerminateDate.Visible = false;
				dtpTerminateDate.Visible = false;
			}
			isCommon();
		}
		
        private void txtRemark_TextChanged(object sender, System.EventArgs e)
		{
			isCommon();
		}

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

        /// <summary>
        /// Event : Double click for selecting avaliable PO
        ///     then select Vehicle that concern it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPOXXX_DoubleClick(object sender, EventArgs e)
        {
            VehiclePurchasing vehiclePurchasing = new VehiclePurchasing();
            string poYY, poMM, poXXX;
            poYY = (txtPOYY.Text == "" ? "" : txtPOYY.Text);
            poMM = (txtPOMM.Text == "" ? "" : txtPOMM.Text);
            poXXX = (txtPOXXX.Text == "" ? "" : txtPOXXX.Text);
            vehiclePurchasing.PurchasNo = new DocumentNo(DOCUMENT_TYPE.PURCHASING_VEHICLE, poYY, poMM, poXXX);

            FrmVehiclePOList frmVehiclePOList = new FrmVehiclePOList();
            frmVehiclePOList.IsPOAvailable = true;
            frmVehiclePOList.InitForm(vehiclePurchasing);
            frmVehiclePOList.ShowDialog();

            if (frmVehiclePOList.Selected)
            {
                using (VehiclePurchasingFacade facade = new VehiclePurchasingFacade())
                {
                    vehiclePurchasing = facade.SearchPurchaseOrderByPurchaseNo(frmVehiclePOList.SelectedVehiclePurchasing.Purchasing.PurchasNo.ToString());
                }
                txtPOYY.Text = vehiclePurchasing.PurchasNo.Year;
                txtPOMM.Text = vehiclePurchasing.PurchasNo.Month;
                txtPOXXX.Text = vehiclePurchasing.PurchasNo.No;
                txtPODate.Text = vehiclePurchasing.IssueDate.Day + "/" + vehiclePurchasing.IssueDate.Month + "/" + vehiclePurchasing.IssueDate.Year;
                txtVendorDate.Text = vehiclePurchasing.VendorQuotationDate.Value.Day + "/" + vehiclePurchasing.VendorQuotationDate.Value.Month + "/" + vehiclePurchasing.VendorQuotationDate.Value.Year;

                FrmVehicleList dialogVehicleList = new FrmVehicleList();
                dialogVehicleList.ConditionPurchaseNo = vehiclePurchasing.PurchasNo.ToString();
                dialogVehicleList.IsVehiclePO = true;
                dialogVehicleList.ShowDialog();
                if (dialogVehicleList.Selected)
                {
                    lblVehicleNo.Text = dialogVehicleList.SelectedVehicle.VehicleNo.ToString();
                    setVehicle(facadeVehicle.GetVehicleInfo(dialogVehicleList.SelectedVehicle.VehicleNo));
                    txtPlateOfPrefix.Text = dialogVehicleList.SelectedVehicle.PlatePrefix;
                    fpiPlateRunningNo.Text = dialogVehicleList.SelectedVehicle.PlateRunningNo;

                    RefreshForm();
                }
            }
        }

        /// <summary>
        /// Event : Double click for selecting avaliable PO
        ///     then select Vehicle that concern it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPOMM_DoubleClick(object sender, EventArgs e)
        {
            VehiclePurchasing vehiclePurchasing = new VehiclePurchasing();
            string poYY, poMM, poXXX;
            poYY = (txtPOYY.Text == "" ? "" : txtPOYY.Text);
            poMM = (txtPOMM.Text == "" ? "" : txtPOMM.Text);
            poXXX = (txtPOXXX.Text == "" ? "" : txtPOXXX.Text);
            vehiclePurchasing.PurchasNo = new DocumentNo(DOCUMENT_TYPE.PURCHASING_VEHICLE, poYY, poMM, poXXX);

            FrmVehiclePOList frmVehiclePOList = new FrmVehiclePOList();
            frmVehiclePOList.IsPOAvailable = true;
            frmVehiclePOList.InitForm(vehiclePurchasing);
            frmVehiclePOList.ShowDialog();

            if (frmVehiclePOList.Selected)
            {
                using (VehiclePurchasingFacade facade = new VehiclePurchasingFacade())
                {
                    vehiclePurchasing = facade.SearchPurchaseOrderByPurchaseNo(frmVehiclePOList.SelectedVehiclePurchasing.Purchasing.PurchasNo.ToString());
                }
                txtPOYY.Text = vehiclePurchasing.PurchasNo.Year;
                txtPOMM.Text = vehiclePurchasing.PurchasNo.Month;
                txtPOXXX.Text = vehiclePurchasing.PurchasNo.No;
                txtPODate.Text = vehiclePurchasing.IssueDate.Day + "/" + vehiclePurchasing.IssueDate.Month + "/" + vehiclePurchasing.IssueDate.Year;
                txtVendorDate.Text = vehiclePurchasing.VendorQuotationDate.Value.Day + "/" + vehiclePurchasing.VendorQuotationDate.Value.Month + "/" + vehiclePurchasing.VendorQuotationDate.Value.Year;

                FrmVehicleList dialogVehicleList = new FrmVehicleList();
                dialogVehicleList.ConditionPurchaseNo = vehiclePurchasing.PurchasNo.ToString();
                dialogVehicleList.IsVehiclePO = true;
                dialogVehicleList.ShowDialog();
                if (dialogVehicleList.Selected)
                {
                    lblVehicleNo.Text = dialogVehicleList.SelectedVehicle.VehicleNo.ToString();
                    setVehicle(facadeVehicle.GetVehicleInfo(dialogVehicleList.SelectedVehicle.VehicleNo));
                    txtPlateOfPrefix.Text = dialogVehicleList.SelectedVehicle.PlatePrefix;
                    fpiPlateRunningNo.Text = dialogVehicleList.SelectedVehicle.PlateRunningNo;

                    RefreshForm();
                }
            }
        }

        /// <summary>
        /// Event : Double click for selecting avaliable PO
        ///     then select Vehicle that concern it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPOYY_DoubleClick(object sender, EventArgs e)
        {
            VehiclePurchasing vehiclePurchasing = new VehiclePurchasing();
            string poYY, poMM, poXXX;
            poYY = (txtPOYY.Text == "" ? "" : txtPOYY.Text);
            poMM = (txtPOMM.Text == "" ? "" : txtPOMM.Text);
            poXXX = (txtPOXXX.Text == "" ? "" : txtPOXXX.Text);
            vehiclePurchasing.PurchasNo = new DocumentNo(DOCUMENT_TYPE.PURCHASING_VEHICLE, poYY, poMM, poXXX);

            FrmVehiclePOList frmVehiclePOList = new FrmVehiclePOList();
            frmVehiclePOList.IsPOAvailable = true;
            frmVehiclePOList.InitForm(vehiclePurchasing);
            frmVehiclePOList.ShowDialog();

            if (frmVehiclePOList.Selected)
            {
                using (VehiclePurchasingFacade facade = new VehiclePurchasingFacade())
                {
                    vehiclePurchasing = facade.SearchPurchaseOrderByPurchaseNo(frmVehiclePOList.SelectedVehiclePurchasing.Purchasing.PurchasNo.ToString());
                }
                txtPOYY.Text = vehiclePurchasing.PurchasNo.Year;
                txtPOMM.Text = vehiclePurchasing.PurchasNo.Month;
                txtPOXXX.Text = vehiclePurchasing.PurchasNo.No;
                txtPODate.Text = vehiclePurchasing.IssueDate.Day + "/" + vehiclePurchasing.IssueDate.Month + "/" + vehiclePurchasing.IssueDate.Year;
                txtVendorDate.Text = vehiclePurchasing.VendorQuotationDate.Value.Day + "/" + vehiclePurchasing.VendorQuotationDate.Value.Month + "/" + vehiclePurchasing.VendorQuotationDate.Value.Year;

                FrmVehicleList dialogVehicleList = new FrmVehicleList();
                dialogVehicleList.ConditionPurchaseNo = vehiclePurchasing.PurchasNo.ToString();
                dialogVehicleList.IsVehiclePO = true;
                dialogVehicleList.ShowDialog();
                if (dialogVehicleList.Selected)
                {
                    lblVehicleNo.Text = dialogVehicleList.SelectedVehicle.VehicleNo.ToString();
                    setVehicle(facadeVehicle.GetVehicleInfo(dialogVehicleList.SelectedVehicle.VehicleNo));
                    txtPlateOfPrefix.Text = dialogVehicleList.SelectedVehicle.PlatePrefix;
                    fpiPlateRunningNo.Text = dialogVehicleList.SelectedVehicle.PlateRunningNo;

                    RefreshForm();
                }
            }
        }

        private void txtPOYY_TextChanged(object sender, EventArgs e)
        {
            purchaseNoChange();
        }

        private void txtPOMM_TextChanged(object sender, EventArgs e)
        {
            purchaseNoChange();
        }

        private void txtPOXXX_TextChanged(object sender, EventArgs e)
        {
            purchaseNoChange();
        }

        private void txtPOYY_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!IsNumericChar(e.KeyChar))
            {
                e.KeyChar = (Char)Keys.None; //char = '\0'
            }
        }

        private void txtPOMM_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!IsNumericChar(e.KeyChar))
            {
                e.KeyChar = (Char)Keys.None; //char = '\0'
            }
        }

        private void txtPOXXX_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!IsNumericChar(e.KeyChar))
            {
                e.KeyChar = (Char)Keys.None; //char = '\0'
            }
        }

        public bool IsNumericChar(char value)
        {
            switch (value)
            {
                case '0': return true;
                case '1': return true;
                case '2': return true;
                case '3': return true;
                case '4': return true;
                case '5': return true;
                case '6': return true;
                case '7': return true;
                case '8': return true;
                case '9': return true;
                case '\b': return true;
            }
            return false;
        }

    }
}
