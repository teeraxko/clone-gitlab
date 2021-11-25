using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using Facade.CommonFacade;
using Facade.AttendanceFacade;

using Presentation.CommonGUI;
using Presentation.PiGUI;

using SystemFramework.AppException;
using SystemFramework.AppMessage;
using SystemFramework.AppConfig;

using ictus.PIS.PI.Entity;

namespace Presentation.AttendanceGUI
{
	public class frmEmployeeBenefitAdjustmentEntry : EntryFormBase
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

		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private FarPoint.Win.Input.FpInteger fpiOvernightTripTimes;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private FarPoint.Win.Input.FpInteger fpiExtraTimes;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private FarPoint.Win.Input.FpInteger fpiTaxiTimes;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private FarPoint.Win.Input.FpInteger fpiFoodTimes;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label32;
		private FarPoint.Win.Input.FpInteger fpiOneDayTripFarTimed;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private FarPoint.Win.Input.FpInteger fpiOneDayTripNearTimes;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.TextBox txtEmpNo;
		private System.Windows.Forms.TextBox txtEmpName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.TextBox txtEmpSection;
		private FarPoint.Win.Input.FpInteger fpiOTHour_A;
		private FarPoint.Win.Input.FpInteger fpiOTHour_B;
		private FarPoint.Win.Input.FpInteger fpiOTHour_C;
		private FarPoint.Win.Input.FpInteger fpiOTMin_B;
		private FarPoint.Win.Input.FpInteger fpiOTMin_C;
		private FarPoint.Win.Input.FpInteger fpiOvernightTripBenefit;
		private FarPoint.Win.Input.FpInteger fpiFoodBenefit;
		private FarPoint.Win.Input.FpInteger fpiExtraBenefit;
		private FarPoint.Win.Input.FpInteger fpiTelephonBenefit;
		private FarPoint.Win.Input.FpInteger fpiMiscBenefit;
		private FarPoint.Win.Input.FpInteger fpiExtraAGTMonthTimes;
		private System.Windows.Forms.Label label30;
		private FarPoint.Win.Input.FpInteger fpiExtraAGTMonthBenefit;
		private FarPoint.Win.Input.FpInteger fpiTaxiBenefit;
		private FarPoint.Win.Input.FpInteger fpiOneDayTripNearBenefit;
		private FarPoint.Win.Input.FpInteger fpiOneDayTripFarBenefit;
		private FarPoint.Win.Input.FpInteger fpiOTMin_A;
		private System.Windows.Forms.GroupBox gpbEmployee;
		private FarPoint.Win.Input.FpInteger fpiExtraAGTDay;
		private FarPoint.Win.Input.FpInteger fpiExtraAGTDayBenefit;
		private System.Windows.Forms.GroupBox gpbDetail;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label43;
        private Label label51;
        private Label label50;

		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
            this.gpbDetail = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.fpiMiscBenefit = new FarPoint.Win.Input.FpInteger();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.fpiTelephonBenefit = new FarPoint.Win.Input.FpInteger();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.fpiExtraAGTMonthBenefit = new FarPoint.Win.Input.FpInteger();
            this.label30 = new System.Windows.Forms.Label();
            this.fpiExtraAGTMonthTimes = new FarPoint.Win.Input.FpInteger();
            this.fpiExtraAGTDayBenefit = new FarPoint.Win.Input.FpInteger();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.fpiExtraAGTDay = new FarPoint.Win.Input.FpInteger();
            this.label31 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.fpiOvernightTripBenefit = new FarPoint.Win.Input.FpInteger();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.fpiOvernightTripTimes = new FarPoint.Win.Input.FpInteger();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.fpiExtraBenefit = new FarPoint.Win.Input.FpInteger();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.fpiExtraTimes = new FarPoint.Win.Input.FpInteger();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fpiTaxiBenefit = new FarPoint.Win.Input.FpInteger();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.fpiTaxiTimes = new FarPoint.Win.Input.FpInteger();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.fpiFoodBenefit = new FarPoint.Win.Input.FpInteger();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.fpiFoodTimes = new FarPoint.Win.Input.FpInteger();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.fpiOTMin_C = new FarPoint.Win.Input.FpInteger();
            this.fpiOTMin_B = new FarPoint.Win.Input.FpInteger();
            this.fpiOTMin_A = new FarPoint.Win.Input.FpInteger();
            this.fpiOTHour_C = new FarPoint.Win.Input.FpInteger();
            this.fpiOTHour_B = new FarPoint.Win.Input.FpInteger();
            this.fpiOTHour_A = new FarPoint.Win.Input.FpInteger();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label51 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.fpiOneDayTripFarBenefit = new FarPoint.Win.Input.FpInteger();
            this.fpiOneDayTripNearBenefit = new FarPoint.Win.Input.FpInteger();
            this.label14 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.fpiOneDayTripFarTimed = new FarPoint.Win.Input.FpInteger();
            this.label35 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.fpiOneDayTripNearTimes = new FarPoint.Win.Input.FpInteger();
            this.label15 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.gpbEmployee = new System.Windows.Forms.GroupBox();
            this.label36 = new System.Windows.Forms.Label();
            this.txtEmpSection = new System.Windows.Forms.TextBox();
            this.txtEmpNo = new System.Windows.Forms.TextBox();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gpbDetail.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gpbEmployee.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbDetail
            // 
            this.gpbDetail.Controls.Add(this.groupBox9);
            this.gpbDetail.Controls.Add(this.groupBox8);
            this.gpbDetail.Controls.Add(this.groupBox7);
            this.gpbDetail.Controls.Add(this.groupBox4);
            this.gpbDetail.Controls.Add(this.groupBox6);
            this.gpbDetail.Controls.Add(this.groupBox2);
            this.gpbDetail.Controls.Add(this.groupBox5);
            this.gpbDetail.Controls.Add(this.groupBox1);
            this.gpbDetail.Controls.Add(this.groupBox3);
            this.gpbDetail.Location = new System.Drawing.Point(12, 64);
            this.gpbDetail.Name = "gpbDetail";
            this.gpbDetail.Size = new System.Drawing.Size(836, 328);
            this.gpbDetail.TabIndex = 11;
            this.gpbDetail.TabStop = false;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.fpiMiscBenefit);
            this.groupBox9.Controls.Add(this.label37);
            this.groupBox9.Controls.Add(this.label38);
            this.groupBox9.Location = new System.Drawing.Point(552, 216);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(272, 104);
            this.groupBox9.TabIndex = 10;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = " ค่าอื่น ๆ (Payroll)";
            // 
            // fpiMiscBenefit
            // 
            this.fpiMiscBenefit.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiMiscBenefit.AllowClipboardKeys = true;
            this.fpiMiscBenefit.BackColor = System.Drawing.Color.White;
            this.fpiMiscBenefit.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiMiscBenefit.Location = new System.Drawing.Point(119, 48);
            this.fpiMiscBenefit.MaxValue = 99999;
            this.fpiMiscBenefit.MinValue = -99999;
            this.fpiMiscBenefit.Name = "fpiMiscBenefit";
            this.fpiMiscBenefit.Size = new System.Drawing.Size(64, 20);
            this.fpiMiscBenefit.TabIndex = 28;
            this.fpiMiscBenefit.Text = "";
            this.fpiMiscBenefit.UseSeparator = true;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(191, 48);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(26, 13);
            this.label37.TabIndex = 80;
            this.label37.Text = "บาท";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(55, 48);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(58, 13);
            this.label38.TabIndex = 80;
            this.label38.Text = "จำนวนเงิน";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.fpiTelephonBenefit);
            this.groupBox8.Controls.Add(this.label33);
            this.groupBox8.Controls.Add(this.label34);
            this.groupBox8.Location = new System.Drawing.Point(280, 216);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(272, 104);
            this.groupBox8.TabIndex = 9;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = " ค่าโทรศัพท์  (Non Payroll)";
            // 
            // fpiTelephonBenefit
            // 
            this.fpiTelephonBenefit.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiTelephonBenefit.AllowClipboardKeys = true;
            this.fpiTelephonBenefit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fpiTelephonBenefit.BackColor = System.Drawing.Color.White;
            this.fpiTelephonBenefit.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiTelephonBenefit.Location = new System.Drawing.Point(123, 48);
            this.fpiTelephonBenefit.MaxValue = 99999;
            this.fpiTelephonBenefit.MinValue = -99999;
            this.fpiTelephonBenefit.Name = "fpiTelephonBenefit";
            this.fpiTelephonBenefit.Size = new System.Drawing.Size(64, 20);
            this.fpiTelephonBenefit.TabIndex = 27;
            this.fpiTelephonBenefit.Text = "";
            this.fpiTelephonBenefit.UseSeparator = true;
            // 
            // label33
            // 
            this.label33.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(187, 48);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(26, 13);
            this.label33.TabIndex = 80;
            this.label33.Text = "บาท";
            // 
            // label34
            // 
            this.label34.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(59, 48);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(58, 13);
            this.label34.TabIndex = 80;
            this.label34.Text = "จำนวนเงิน";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.fpiExtraAGTMonthBenefit);
            this.groupBox7.Controls.Add(this.label30);
            this.groupBox7.Controls.Add(this.fpiExtraAGTMonthTimes);
            this.groupBox7.Controls.Add(this.fpiExtraAGTDayBenefit);
            this.groupBox7.Controls.Add(this.label41);
            this.groupBox7.Controls.Add(this.label40);
            this.groupBox7.Controls.Add(this.label28);
            this.groupBox7.Controls.Add(this.label29);
            this.groupBox7.Controls.Add(this.fpiExtraAGTDay);
            this.groupBox7.Controls.Add(this.label31);
            this.groupBox7.Location = new System.Drawing.Point(8, 216);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(272, 104);
            this.groupBox7.TabIndex = 8;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = " ค่าเบี้ยขยัน AGT  (Non Payroll)";
            // 
            // fpiExtraAGTMonthBenefit
            // 
            this.fpiExtraAGTMonthBenefit.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiExtraAGTMonthBenefit.AllowClipboardKeys = true;
            this.fpiExtraAGTMonthBenefit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fpiExtraAGTMonthBenefit.BackColor = System.Drawing.Color.White;
            this.fpiExtraAGTMonthBenefit.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiExtraAGTMonthBenefit.Location = new System.Drawing.Point(167, 64);
            this.fpiExtraAGTMonthBenefit.MaxValue = 99999;
            this.fpiExtraAGTMonthBenefit.MinValue = -99999;
            this.fpiExtraAGTMonthBenefit.Name = "fpiExtraAGTMonthBenefit";
            this.fpiExtraAGTMonthBenefit.Size = new System.Drawing.Size(64, 20);
            this.fpiExtraAGTMonthBenefit.TabIndex = 80;
            this.fpiExtraAGTMonthBenefit.Text = "";
            this.fpiExtraAGTMonthBenefit.UseSeparator = true;
            // 
            // label30
            // 
            this.label30.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(127, 64);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(33, 13);
            this.label30.TabIndex = 80;
            this.label30.Text = "เดือน";
            // 
            // fpiExtraAGTMonthTimes
            // 
            this.fpiExtraAGTMonthTimes.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiExtraAGTMonthTimes.AllowClipboardKeys = true;
            this.fpiExtraAGTMonthTimes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fpiExtraAGTMonthTimes.BackColor = System.Drawing.Color.White;
            this.fpiExtraAGTMonthTimes.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiExtraAGTMonthTimes.Location = new System.Drawing.Point(87, 64);
            this.fpiExtraAGTMonthTimes.MaxValue = 999;
            this.fpiExtraAGTMonthTimes.MinValue = -999;
            this.fpiExtraAGTMonthTimes.Name = "fpiExtraAGTMonthTimes";
            this.fpiExtraAGTMonthTimes.Size = new System.Drawing.Size(40, 20);
            this.fpiExtraAGTMonthTimes.TabIndex = 26;
            this.fpiExtraAGTMonthTimes.Text = "";
            this.fpiExtraAGTMonthTimes.ValueChanged += new System.EventHandler(this.fpiExtraAGTMonthTimes_ValueChanged);
            // 
            // fpiExtraAGTDayBenefit
            // 
            this.fpiExtraAGTDayBenefit.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiExtraAGTDayBenefit.AllowClipboardKeys = true;
            this.fpiExtraAGTDayBenefit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fpiExtraAGTDayBenefit.BackColor = System.Drawing.Color.White;
            this.fpiExtraAGTDayBenefit.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiExtraAGTDayBenefit.Location = new System.Drawing.Point(167, 32);
            this.fpiExtraAGTDayBenefit.MaxValue = 99999;
            this.fpiExtraAGTDayBenefit.MinValue = -99999;
            this.fpiExtraAGTDayBenefit.Name = "fpiExtraAGTDayBenefit";
            this.fpiExtraAGTDayBenefit.Size = new System.Drawing.Size(64, 20);
            this.fpiExtraAGTDayBenefit.TabIndex = 80;
            this.fpiExtraAGTDayBenefit.Text = "";
            this.fpiExtraAGTDayBenefit.UseSeparator = true;
            // 
            // label41
            // 
            this.label41.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(231, 64);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(26, 13);
            this.label41.TabIndex = 80;
            this.label41.Text = "บาท";
            // 
            // label40
            // 
            this.label40.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(15, 64);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(66, 13);
            this.label40.TabIndex = 80;
            this.label40.Text = "จำนวนเดือน";
            // 
            // label28
            // 
            this.label28.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(127, 32);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(21, 13);
            this.label28.TabIndex = 80;
            this.label28.Text = "วัน";
            // 
            // label29
            // 
            this.label29.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(231, 32);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(26, 13);
            this.label29.TabIndex = 80;
            this.label29.Text = "บาท";
            // 
            // fpiExtraAGTDay
            // 
            this.fpiExtraAGTDay.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiExtraAGTDay.AllowClipboardKeys = true;
            this.fpiExtraAGTDay.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fpiExtraAGTDay.BackColor = System.Drawing.Color.White;
            this.fpiExtraAGTDay.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiExtraAGTDay.Location = new System.Drawing.Point(87, 32);
            this.fpiExtraAGTDay.MaxValue = 999;
            this.fpiExtraAGTDay.MinValue = -999;
            this.fpiExtraAGTDay.Name = "fpiExtraAGTDay";
            this.fpiExtraAGTDay.Size = new System.Drawing.Size(40, 20);
            this.fpiExtraAGTDay.TabIndex = 25;
            this.fpiExtraAGTDay.Text = "";
            this.fpiExtraAGTDay.ValueChanged += new System.EventHandler(this.fpiExtraAGTDay_ValueChanged);
            // 
            // label31
            // 
            this.label31.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(15, 32);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(54, 13);
            this.label31.TabIndex = 80;
            this.label31.Text = "จำนวนวัน";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.fpiOvernightTripBenefit);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.fpiOvernightTripTimes);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Location = new System.Drawing.Point(8, 112);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(272, 104);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = " ค่าเดินทางค้างคืน  (Non Payroll)";
            // 
            // fpiOvernightTripBenefit
            // 
            this.fpiOvernightTripBenefit.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiOvernightTripBenefit.AllowClipboardKeys = true;
            this.fpiOvernightTripBenefit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fpiOvernightTripBenefit.BackColor = System.Drawing.Color.White;
            this.fpiOvernightTripBenefit.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiOvernightTripBenefit.Location = new System.Drawing.Point(119, 64);
            this.fpiOvernightTripBenefit.MaxValue = 99999;
            this.fpiOvernightTripBenefit.MinValue = -99999;
            this.fpiOvernightTripBenefit.Name = "fpiOvernightTripBenefit";
            this.fpiOvernightTripBenefit.Size = new System.Drawing.Size(64, 20);
            this.fpiOvernightTripBenefit.TabIndex = 80;
            this.fpiOvernightTripBenefit.Text = "";
            this.fpiOvernightTripBenefit.UseSeparator = true;
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(191, 33);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(25, 13);
            this.label16.TabIndex = 80;
            this.label16.Text = "ครั้ง";
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(191, 65);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(26, 13);
            this.label17.TabIndex = 80;
            this.label17.Text = "บาท";
            // 
            // fpiOvernightTripTimes
            // 
            this.fpiOvernightTripTimes.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiOvernightTripTimes.AllowClipboardKeys = true;
            this.fpiOvernightTripTimes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fpiOvernightTripTimes.BackColor = System.Drawing.Color.White;
            this.fpiOvernightTripTimes.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiOvernightTripTimes.Location = new System.Drawing.Point(119, 33);
            this.fpiOvernightTripTimes.MaxValue = 999;
            this.fpiOvernightTripTimes.MinValue = -999;
            this.fpiOvernightTripTimes.Name = "fpiOvernightTripTimes";
            this.fpiOvernightTripTimes.Size = new System.Drawing.Size(64, 20);
            this.fpiOvernightTripTimes.TabIndex = 22;
            this.fpiOvernightTripTimes.Text = "";
            this.fpiOvernightTripTimes.ValueChanged += new System.EventHandler(this.fpiOvernightTripTimes_ValueChanged);
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(55, 65);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(58, 13);
            this.label18.TabIndex = 80;
            this.label18.Text = "จำนวนเงิน";
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(55, 33);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(58, 13);
            this.label19.TabIndex = 80;
            this.label19.Text = "จำนวนครั้ง";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.fpiExtraBenefit);
            this.groupBox6.Controls.Add(this.label24);
            this.groupBox6.Controls.Add(this.label25);
            this.groupBox6.Controls.Add(this.fpiExtraTimes);
            this.groupBox6.Controls.Add(this.label26);
            this.groupBox6.Controls.Add(this.label27);
            this.groupBox6.Location = new System.Drawing.Point(552, 112);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(272, 104);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "ค่าเบี้ยขยัน  (Payroll)";
            // 
            // fpiExtraBenefit
            // 
            this.fpiExtraBenefit.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiExtraBenefit.AllowClipboardKeys = true;
            this.fpiExtraBenefit.BackColor = System.Drawing.Color.White;
            this.fpiExtraBenefit.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiExtraBenefit.Location = new System.Drawing.Point(116, 64);
            this.fpiExtraBenefit.MaxValue = 99999;
            this.fpiExtraBenefit.MinValue = -99999;
            this.fpiExtraBenefit.Name = "fpiExtraBenefit";
            this.fpiExtraBenefit.Size = new System.Drawing.Size(64, 20);
            this.fpiExtraBenefit.TabIndex = 80;
            this.fpiExtraBenefit.Text = "";
            this.fpiExtraBenefit.UseSeparator = true;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(188, 33);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(33, 13);
            this.label24.TabIndex = 80;
            this.label24.Text = "เดือน";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(188, 65);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(26, 13);
            this.label25.TabIndex = 80;
            this.label25.Text = "บาท";
            // 
            // fpiExtraTimes
            // 
            this.fpiExtraTimes.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiExtraTimes.AllowClipboardKeys = true;
            this.fpiExtraTimes.BackColor = System.Drawing.Color.White;
            this.fpiExtraTimes.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiExtraTimes.Location = new System.Drawing.Point(116, 33);
            this.fpiExtraTimes.MaxValue = 999;
            this.fpiExtraTimes.MinValue = -999;
            this.fpiExtraTimes.Name = "fpiExtraTimes";
            this.fpiExtraTimes.Size = new System.Drawing.Size(64, 20);
            this.fpiExtraTimes.TabIndex = 24;
            this.fpiExtraTimes.Text = "";
            this.fpiExtraTimes.ValueChanged += new System.EventHandler(this.fpiExtraTimes_ValueChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(52, 65);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(58, 13);
            this.label26.TabIndex = 80;
            this.label26.Text = "จำนวนเงิน";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(52, 33);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(47, 13);
            this.label27.TabIndex = 80;
            this.label27.Text = "เบี้ยขยัน";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.fpiTaxiBenefit);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.fpiTaxiTimes);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(280, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 104);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ค่า Taxi  (Non Payroll)";
            // 
            // fpiTaxiBenefit
            // 
            this.fpiTaxiBenefit.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiTaxiBenefit.AllowClipboardKeys = true;
            this.fpiTaxiBenefit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fpiTaxiBenefit.BackColor = System.Drawing.Color.White;
            this.fpiTaxiBenefit.ButtonColor = System.Drawing.Color.White;
            this.fpiTaxiBenefit.ButtonMarginColor = System.Drawing.Color.White;
            this.fpiTaxiBenefit.Location = new System.Drawing.Point(123, 64);
            this.fpiTaxiBenefit.MaxValue = 99999;
            this.fpiTaxiBenefit.MinValue = -99999;
            this.fpiTaxiBenefit.Name = "fpiTaxiBenefit";
            this.fpiTaxiBenefit.NullColor = System.Drawing.Color.White;
            this.fpiTaxiBenefit.Size = new System.Drawing.Size(64, 20);
            this.fpiTaxiBenefit.TabIndex = 80;
            this.fpiTaxiBenefit.Text = "";
            this.fpiTaxiBenefit.UseSeparator = true;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(187, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 13);
            this.label11.TabIndex = 80;
            this.label11.Text = "ครั้ง";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(187, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 13);
            this.label10.TabIndex = 80;
            this.label10.Text = "บาท";
            // 
            // fpiTaxiTimes
            // 
            this.fpiTaxiTimes.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiTaxiTimes.AllowClipboardKeys = true;
            this.fpiTaxiTimes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fpiTaxiTimes.BackColor = System.Drawing.Color.White;
            this.fpiTaxiTimes.ButtonMarginColor = System.Drawing.Color.White;
            this.fpiTaxiTimes.Location = new System.Drawing.Point(123, 32);
            this.fpiTaxiTimes.MaxValue = 999;
            this.fpiTaxiTimes.MinValue = -999;
            this.fpiTaxiTimes.Name = "fpiTaxiTimes";
            this.fpiTaxiTimes.Size = new System.Drawing.Size(64, 20);
            this.fpiTaxiTimes.TabIndex = 19;
            this.fpiTaxiTimes.Text = "";
            this.fpiTaxiTimes.ValueChanged += new System.EventHandler(this.fpiTaxiTimes_ValueChanged);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(59, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 80;
            this.label9.Text = "จำนวนเงิน";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(59, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 80;
            this.label8.Text = "จำนวนครั้ง";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.fpiFoodBenefit);
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Controls.Add(this.fpiFoodTimes);
            this.groupBox5.Controls.Add(this.label22);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Location = new System.Drawing.Point(280, 112);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(272, 104);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = " ค่าอาหาร  (Non Payroll)";
            // 
            // fpiFoodBenefit
            // 
            this.fpiFoodBenefit.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiFoodBenefit.AllowClipboardKeys = true;
            this.fpiFoodBenefit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fpiFoodBenefit.BackColor = System.Drawing.Color.White;
            this.fpiFoodBenefit.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiFoodBenefit.Location = new System.Drawing.Point(119, 64);
            this.fpiFoodBenefit.MaxValue = 99999;
            this.fpiFoodBenefit.MinValue = -99999;
            this.fpiFoodBenefit.Name = "fpiFoodBenefit";
            this.fpiFoodBenefit.Size = new System.Drawing.Size(64, 20);
            this.fpiFoodBenefit.TabIndex = 80;
            this.fpiFoodBenefit.Text = "";
            this.fpiFoodBenefit.UseSeparator = true;
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(191, 33);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(25, 13);
            this.label20.TabIndex = 80;
            this.label20.Text = "ครั้ง";
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(191, 65);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(26, 13);
            this.label21.TabIndex = 80;
            this.label21.Text = "บาท";
            // 
            // fpiFoodTimes
            // 
            this.fpiFoodTimes.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiFoodTimes.AllowClipboardKeys = true;
            this.fpiFoodTimes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fpiFoodTimes.BackColor = System.Drawing.Color.White;
            this.fpiFoodTimes.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiFoodTimes.Location = new System.Drawing.Point(119, 33);
            this.fpiFoodTimes.MaxValue = 999;
            this.fpiFoodTimes.MinValue = -999;
            this.fpiFoodTimes.Name = "fpiFoodTimes";
            this.fpiFoodTimes.Size = new System.Drawing.Size(64, 20);
            this.fpiFoodTimes.TabIndex = 23;
            this.fpiFoodTimes.Text = "";
            this.fpiFoodTimes.ValueChanged += new System.EventHandler(this.fpiFoodTimes_ValueChanged);
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(55, 65);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(58, 13);
            this.label22.TabIndex = 80;
            this.label22.Text = "จำนวนเงิน";
            // 
            // label23
            // 
            this.label23.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(55, 33);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(58, 13);
            this.label23.TabIndex = 80;
            this.label23.Text = "จำนวนครั้ง";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label43);
            this.groupBox1.Controls.Add(this.label42);
            this.groupBox1.Controls.Add(this.label39);
            this.groupBox1.Controls.Add(this.fpiOTMin_C);
            this.groupBox1.Controls.Add(this.fpiOTMin_B);
            this.groupBox1.Controls.Add(this.fpiOTMin_A);
            this.groupBox1.Controls.Add(this.fpiOTHour_C);
            this.groupBox1.Controls.Add(this.fpiOTHour_B);
            this.groupBox1.Controls.Add(this.fpiOTHour_A);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 104);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ค่าล่วงเวลา (Payroll)";
            // 
            // label43
            // 
            this.label43.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(215, 72);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(27, 13);
            this.label43.TabIndex = 83;
            this.label43.Text = "นาที";
            // 
            // label42
            // 
            this.label42.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(215, 48);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(27, 13);
            this.label42.TabIndex = 82;
            this.label42.Text = "นาที";
            // 
            // label39
            // 
            this.label39.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(215, 24);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(27, 13);
            this.label39.TabIndex = 81;
            this.label39.Text = "นาที";
            // 
            // fpiOTMin_C
            // 
            this.fpiOTMin_C.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiOTMin_C.AllowClipboardKeys = true;
            this.fpiOTMin_C.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fpiOTMin_C.BackColor = System.Drawing.Color.White;
            this.fpiOTMin_C.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiOTMin_C.Location = new System.Drawing.Point(183, 72);
            this.fpiOTMin_C.MaxValue = 59;
            this.fpiOTMin_C.MinValue = -59;
            this.fpiOTMin_C.Name = "fpiOTMin_C";
            this.fpiOTMin_C.Size = new System.Drawing.Size(32, 20);
            this.fpiOTMin_C.TabIndex = 18;
            this.fpiOTMin_C.Text = "";
            // 
            // fpiOTMin_B
            // 
            this.fpiOTMin_B.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiOTMin_B.AllowClipboardKeys = true;
            this.fpiOTMin_B.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fpiOTMin_B.BackColor = System.Drawing.Color.White;
            this.fpiOTMin_B.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiOTMin_B.Location = new System.Drawing.Point(183, 48);
            this.fpiOTMin_B.MaxValue = 59;
            this.fpiOTMin_B.MinValue = -59;
            this.fpiOTMin_B.Name = "fpiOTMin_B";
            this.fpiOTMin_B.Size = new System.Drawing.Size(32, 20);
            this.fpiOTMin_B.TabIndex = 16;
            this.fpiOTMin_B.Text = "";
            // 
            // fpiOTMin_A
            // 
            this.fpiOTMin_A.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiOTMin_A.AllowClipboardKeys = true;
            this.fpiOTMin_A.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fpiOTMin_A.BackColor = System.Drawing.Color.White;
            this.fpiOTMin_A.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiOTMin_A.Location = new System.Drawing.Point(183, 24);
            this.fpiOTMin_A.MaxValue = 59;
            this.fpiOTMin_A.MinValue = -59;
            this.fpiOTMin_A.Name = "fpiOTMin_A";
            this.fpiOTMin_A.Size = new System.Drawing.Size(32, 20);
            this.fpiOTMin_A.TabIndex = 14;
            this.fpiOTMin_A.Text = "";
            // 
            // fpiOTHour_C
            // 
            this.fpiOTHour_C.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiOTHour_C.AllowClipboardKeys = true;
            this.fpiOTHour_C.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fpiOTHour_C.BackColor = System.Drawing.Color.White;
            this.fpiOTHour_C.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiOTHour_C.Location = new System.Drawing.Point(80, 72);
            this.fpiOTHour_C.MaxValue = 999;
            this.fpiOTHour_C.MinValue = -999;
            this.fpiOTHour_C.Name = "fpiOTHour_C";
            this.fpiOTHour_C.Size = new System.Drawing.Size(48, 20);
            this.fpiOTHour_C.TabIndex = 17;
            this.fpiOTHour_C.Text = "";
            // 
            // fpiOTHour_B
            // 
            this.fpiOTHour_B.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiOTHour_B.AllowClipboardKeys = true;
            this.fpiOTHour_B.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fpiOTHour_B.BackColor = System.Drawing.Color.White;
            this.fpiOTHour_B.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiOTHour_B.Location = new System.Drawing.Point(80, 48);
            this.fpiOTHour_B.MaxValue = 999;
            this.fpiOTHour_B.MinValue = -999;
            this.fpiOTHour_B.Name = "fpiOTHour_B";
            this.fpiOTHour_B.Size = new System.Drawing.Size(48, 20);
            this.fpiOTHour_B.TabIndex = 15;
            this.fpiOTHour_B.Text = "";
            // 
            // fpiOTHour_A
            // 
            this.fpiOTHour_A.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiOTHour_A.AllowClipboardKeys = true;
            this.fpiOTHour_A.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fpiOTHour_A.BackColor = System.Drawing.Color.White;
            this.fpiOTHour_A.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiOTHour_A.InvalidColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.fpiOTHour_A.Location = new System.Drawing.Point(80, 24);
            this.fpiOTHour_A.MaxValue = 999;
            this.fpiOTHour_A.MinValue = -999;
            this.fpiOTHour_A.Name = "fpiOTHour_A";
            this.fpiOTHour_A.Size = new System.Drawing.Size(48, 20);
            this.fpiOTHour_A.TabIndex = 13;
            this.fpiOTHour_A.Text = "";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(128, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 80;
            this.label7.Text = "ชั่วโมง";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(128, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 80;
            this.label6.Text = "ชั่วโมง";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(128, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 80;
            this.label5.Text = "ชั่วโมง";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 80;
            this.label3.Text = "อัตรา B";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 80;
            this.label2.Text = "อัตรา C";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 80;
            this.label1.Text = "อัตรา A";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label51);
            this.groupBox3.Controls.Add(this.label50);
            this.groupBox3.Controls.Add(this.fpiOneDayTripFarBenefit);
            this.groupBox3.Controls.Add(this.fpiOneDayTripNearBenefit);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label32);
            this.groupBox3.Controls.Add(this.fpiOneDayTripFarTimed);
            this.groupBox3.Controls.Add(this.label35);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.fpiOneDayTripNearTimes);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Location = new System.Drawing.Point(552, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(272, 104);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ค่าเดินทางไป - กลับ  (No Payment)";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(111, 64);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(58, 13);
            this.label51.TabIndex = 82;
            this.label51.Text = "จำนวนเงิน";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(111, 32);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(58, 13);
            this.label50.TabIndex = 81;
            this.label50.Text = "จำนวนเงิน";
            // 
            // fpiOneDayTripFarBenefit
            // 
            this.fpiOneDayTripFarBenefit.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiOneDayTripFarBenefit.AllowClipboardKeys = true;
            this.fpiOneDayTripFarBenefit.BackColor = System.Drawing.Color.White;
            this.fpiOneDayTripFarBenefit.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiOneDayTripFarBenefit.Location = new System.Drawing.Point(175, 60);
            this.fpiOneDayTripFarBenefit.MaxValue = 99999;
            this.fpiOneDayTripFarBenefit.MinValue = -99999;
            this.fpiOneDayTripFarBenefit.Name = "fpiOneDayTripFarBenefit";
            this.fpiOneDayTripFarBenefit.Size = new System.Drawing.Size(64, 20);
            this.fpiOneDayTripFarBenefit.TabIndex = 80;
            this.fpiOneDayTripFarBenefit.Text = "";
            this.fpiOneDayTripFarBenefit.UseSeparator = true;
            // 
            // fpiOneDayTripNearBenefit
            // 
            this.fpiOneDayTripNearBenefit.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiOneDayTripNearBenefit.AllowClipboardKeys = true;
            this.fpiOneDayTripNearBenefit.BackColor = System.Drawing.Color.White;
            this.fpiOneDayTripNearBenefit.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiOneDayTripNearBenefit.Location = new System.Drawing.Point(175, 32);
            this.fpiOneDayTripNearBenefit.MaxValue = 99999;
            this.fpiOneDayTripNearBenefit.MinValue = -99999;
            this.fpiOneDayTripNearBenefit.Name = "fpiOneDayTripNearBenefit";
            this.fpiOneDayTripNearBenefit.Size = new System.Drawing.Size(64, 20);
            this.fpiOneDayTripNearBenefit.TabIndex = 80;
            this.fpiOneDayTripNearBenefit.Text = "";
            this.fpiOneDayTripNearBenefit.UseSeparator = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(79, 64);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(25, 13);
            this.label14.TabIndex = 80;
            this.label14.Text = "ครั้ง";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(239, 64);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(26, 13);
            this.label32.TabIndex = 80;
            this.label32.Text = "บาท";
            // 
            // fpiOneDayTripFarTimed
            // 
            this.fpiOneDayTripFarTimed.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiOneDayTripFarTimed.AllowClipboardKeys = true;
            this.fpiOneDayTripFarTimed.BackColor = System.Drawing.Color.White;
            this.fpiOneDayTripFarTimed.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiOneDayTripFarTimed.Location = new System.Drawing.Point(39, 64);
            this.fpiOneDayTripFarTimed.MaxValue = 999;
            this.fpiOneDayTripFarTimed.MinValue = -999;
            this.fpiOneDayTripFarTimed.Name = "fpiOneDayTripFarTimed";
            this.fpiOneDayTripFarTimed.Size = new System.Drawing.Size(40, 20);
            this.fpiOneDayTripFarTimed.TabIndex = 21;
            this.fpiOneDayTripFarTimed.Text = "";
            this.fpiOneDayTripFarTimed.ValueChanged += new System.EventHandler(this.fpiOneDayTripFarTimed_ValueChanged);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(7, 64);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(26, 13);
            this.label35.TabIndex = 80;
            this.label35.Text = "ไกล";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(79, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(25, 13);
            this.label12.TabIndex = 80;
            this.label12.Text = "ครั้ง";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(239, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 13);
            this.label13.TabIndex = 80;
            this.label13.Text = "บาท";
            // 
            // fpiOneDayTripNearTimes
            // 
            this.fpiOneDayTripNearTimes.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
            this.fpiOneDayTripNearTimes.AllowClipboardKeys = true;
            this.fpiOneDayTripNearTimes.BackColor = System.Drawing.Color.White;
            this.fpiOneDayTripNearTimes.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiOneDayTripNearTimes.Location = new System.Drawing.Point(39, 32);
            this.fpiOneDayTripNearTimes.MaxValue = 999;
            this.fpiOneDayTripNearTimes.MinValue = -999;
            this.fpiOneDayTripNearTimes.Name = "fpiOneDayTripNearTimes";
            this.fpiOneDayTripNearTimes.Size = new System.Drawing.Size(40, 20);
            this.fpiOneDayTripNearTimes.TabIndex = 20;
            this.fpiOneDayTripNearTimes.Text = "";
            this.fpiOneDayTripNearTimes.ValueChanged += new System.EventHandler(this.fpiOneDayTripNearTimes_ValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 32);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(26, 13);
            this.label15.TabIndex = 80;
            this.label15.Text = "ใกล้";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(439, 405);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 29;
            this.cmdCancel.Text = "ยกเลิก";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdOK.Location = new System.Drawing.Point(351, 405);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 28;
            this.cmdOK.Text = "ตกลง";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // gpbEmployee
            // 
            this.gpbEmployee.Controls.Add(this.label36);
            this.gpbEmployee.Controls.Add(this.txtEmpSection);
            this.gpbEmployee.Controls.Add(this.txtEmpNo);
            this.gpbEmployee.Controls.Add(this.txtEmpName);
            this.gpbEmployee.Controls.Add(this.label4);
            this.gpbEmployee.Location = new System.Drawing.Point(14, 0);
            this.gpbEmployee.Name = "gpbEmployee";
            this.gpbEmployee.Size = new System.Drawing.Size(836, 64);
            this.gpbEmployee.TabIndex = 1;
            this.gpbEmployee.TabStop = false;
            this.gpbEmployee.Text = "Employee Detail";
            // 
            // label36
            // 
            this.label36.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(426, 24);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(45, 13);
            this.label36.TabIndex = 80;
            this.label36.Text = "ส่วนงาน";
            // 
            // txtEmpSection
            // 
            this.txtEmpSection.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtEmpSection.Enabled = false;
            this.txtEmpSection.Location = new System.Drawing.Point(482, 24);
            this.txtEmpSection.Name = "txtEmpSection";
            this.txtEmpSection.Size = new System.Drawing.Size(304, 20);
            this.txtEmpSection.TabIndex = 80;
            // 
            // txtEmpNo
            // 
            this.txtEmpNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtEmpNo.Location = new System.Drawing.Point(98, 24);
            this.txtEmpNo.MaxLength = 5;
            this.txtEmpNo.Name = "txtEmpNo";
            this.txtEmpNo.Size = new System.Drawing.Size(56, 20);
            this.txtEmpNo.TabIndex = 12;
            this.txtEmpNo.DoubleClick += new System.EventHandler(this.txtEmpNo_DoubleClick);
            this.txtEmpNo.TextChanged += new System.EventHandler(this.txtEmpNo_TextChanged);
            // 
            // txtEmpName
            // 
            this.txtEmpName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtEmpName.Enabled = false;
            this.txtEmpName.Location = new System.Drawing.Point(162, 24);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(200, 20);
            this.txtEmpName.TabIndex = 80;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 80;
            this.label4.Text = "พนักงาน";
            // 
            // frmEmployeeBenefitAdjustmentEntry
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(864, 442);
            this.Controls.Add(this.gpbEmployee);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.gpbDetail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmEmployeeBenefitAdjustmentEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmEmployeeBenefitAdjustmentEntry_Load);
            this.gpbDetail.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gpbEmployee.ResumeLayout(false);
            this.gpbEmployee.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region - private -
		private bool isReadonly = true;
		private bool isTextChange = true;
		private frmEmployeeBenefitAdjustment parentForm;
		#endregion

//		============================== Property ==============================
		private OtherBenefitRate objOtherBenefitRate
		{
			get{return parentForm.FacadeEmployeeBenefitAdjustment.ObjOtherBenefitRate;}
		}

		private BenefitAdjustment objBenefitAdjustment;
		public BenefitAdjustment ObjBenefitAdjustment
		{
			set
			{
                isTextChange = false;
				objBenefitAdjustment = value;
				fpiExtraAGTDayBenefit.Value = value.AddAGTAmount;
				fpiExtraAGTDay.Value = value.AddAGTDays;
				fpiExtraAGTMonthBenefit.Value = value.ExtraAGTAmount;
				fpiExtraAGTMonthTimes.Value = value.ExtraAGTMonths;
				fpiExtraBenefit.Value = value.ExtraAmount;
				fpiExtraTimes.Value = value.ExtraTimes;
				fpiFoodBenefit.Value = value.FoodAmount;
				fpiFoodTimes.Value = value.FoodTimes;
				fpiMiscBenefit.Value = value.MiscAmount;
				fpiOneDayTripFarBenefit.Value = value.OneDayTripFarAmount;
				fpiOneDayTripFarTimed.Value = value.OneDayTripFarTimes;
				fpiOneDayTripNearBenefit.Value = value.OneDayTripNearAmount;
				fpiOneDayTripNearTimes.Value = value.OneDayTripNearTimes;

				if(value.OTAHour >= 0)
				{
					fpiOTHour_A.Value = Decimal.Floor(value.OTAHour);
				}
				else
				{
					fpiOTHour_A.Value = value.OTAHour;
				}

				if(value.OTBHour >= 0)
				{
					fpiOTHour_B.Value = Decimal.Floor(value.OTBHour);
				}
				else
				{
					fpiOTHour_B.Value = value.OTBHour;
				}

				if(value.OTBHour >= 0)
				{
					fpiOTHour_C.Value = Decimal.Floor(value.OTCHour);
				}
				else
				{
					fpiOTHour_C.Value = value.OTCHour;
				}
				
				fpiOTMin_A.Value = GUIFunction.ConverToMinute(value.OTAHour);
				fpiOTMin_B.Value = GUIFunction.ConverToMinute(value.OTBHour);
				fpiOTMin_C.Value = GUIFunction.ConverToMinute(value.OTCHour);
				fpiOvernightTripBenefit.Value = value.OvernightTripAmount;
				fpiOvernightTripTimes.Value = value.OvernightTripTimes;
				fpiTaxiBenefit.Value = value.TaxiAmount;
				fpiTaxiTimes.Value = value.TaxiTimes;
				fpiTelephonBenefit.Value = value.TelephoneAmount;
                isTextChange = true;
			}
			get
			{
				objBenefitAdjustment = new BenefitAdjustment();
				objBenefitAdjustment.AddAGTAmount = Convert.ToDecimal(fpiExtraAGTDayBenefit.Value);
				objBenefitAdjustment.AddAGTDays = Convert.ToInt32(fpiExtraAGTDay.Value);
				objBenefitAdjustment.ExtraAGTAmount = Convert.ToDecimal(fpiExtraAGTMonthBenefit.Value);
				objBenefitAdjustment.ExtraAGTMonths = Convert.ToInt32(fpiExtraAGTMonthTimes.Value);
				objBenefitAdjustment.ExtraAmount = Convert.ToDecimal(fpiExtraBenefit.Value);
				objBenefitAdjustment.ExtraTimes = Convert.ToInt32(fpiExtraTimes.Value);
				objBenefitAdjustment.FoodAmount = Convert.ToDecimal(fpiFoodBenefit.Value);
				objBenefitAdjustment.FoodTimes = Convert.ToInt32(fpiFoodTimes.Value);
				objBenefitAdjustment.MiscAmount = Convert.ToDecimal(fpiMiscBenefit.Value);
				objBenefitAdjustment.OneDayTripFarAmount = Convert.ToDecimal(fpiOneDayTripFarBenefit.Value);
				objBenefitAdjustment.OneDayTripFarTimes = Convert.ToInt32(fpiOneDayTripFarTimed.Value );
				objBenefitAdjustment.OneDayTripNearAmount = Convert.ToDecimal(fpiOneDayTripNearBenefit.Value);
				objBenefitAdjustment.OneDayTripNearTimes = Convert.ToInt32(fpiOneDayTripNearTimes.Value);
	
				objBenefitAdjustment.OTAHour = convertToDecimal(Convert.ToInt32(fpiOTHour_A.Value), Convert.ToInt32(fpiOTMin_A.Value));
				objBenefitAdjustment.OTBHour = convertToDecimal(Convert.ToInt32(fpiOTHour_B.Value), Convert.ToInt32(fpiOTMin_B.Value)); 
				objBenefitAdjustment.OTCHour = convertToDecimal(Convert.ToInt32(fpiOTHour_C.Value), Convert.ToInt32(fpiOTMin_C.Value)); 
				objBenefitAdjustment.OvernightTripAmount = Convert.ToDecimal(fpiOvernightTripBenefit.Value);
				objBenefitAdjustment.OvernightTripTimes = Convert.ToInt32(fpiOvernightTripTimes.Value);
				objBenefitAdjustment.TaxiAmount = Convert.ToDecimal(fpiTaxiBenefit.Value);
				objBenefitAdjustment.TaxiTimes = Convert.ToInt32(fpiTaxiTimes.Value);
                objBenefitAdjustment.TelephoneAmount = Convert.ToDecimal(fpiTelephonBenefit.Value);

				objBenefitAdjustment.AEmployee = objEmployee;
				return objBenefitAdjustment;
			}
		}

		private Employee objEmployee;
		public Employee ObjEmployee
		{
			set
			{
				isTextChange = false;
				objEmployee = value;
				txtEmpNo.Text = value.EmployeeNo;
				txtEmpName.Text = value.EmployeeName;
				txtEmpSection.Text = value.ASection.AFullName.English;
				isTextChange = true;
			}		
		}

//		============================== Constructor ==============================
		public frmEmployeeBenefitAdjustmentEntry(frmEmployeeBenefitAdjustment parentForm) : base()
		{
			InitializeComponent();
			this.parentForm = parentForm;
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miBenefitAdjustment");
		}

//		============================== private method ==============================
		private decimal convertToDecimal(int hour, int minute)
		{
			if(hour < 0 & minute < 0)
			{
				return decimal.Parse(hour.ToString() + "." + Decimal.Negate(minute).ToString());
			}
			else if(hour >= 0 & minute < 0)
			{
				return Decimal.Negate(decimal.Parse(hour.ToString() + "." + Decimal.Negate(minute).ToString()));
			}
			return GUIFunction.ConverToDecimal(hour, minute); 
		}

		private void formEmployeeList()
		{
			frmEmplist dialogEmplist = new frmEmplist();
			dialogEmplist.ShowDialog();			
			if(dialogEmplist.Selected)
			{
				setForm(dialogEmplist.SelectedEmployee);
			}		
		}

		private void setForm(Employee value)
		{
			clearForm();
			ObjEmployee = value;
			enableKeyfield(false);
            ClearValue();
			fpiOTHour_A.Focus();
		}

		private void setBackColor()
		{
            //fpiExtraAGTDay.Focus();
            //fpiExtraAGTMonthTimes.Focus();
            //fpiExtraTimes.Focus();
            //fpiFoodTimes.Focus();
            //fpiOTHour_A.Focus();
            //fpiOTHour_B.Focus();
            //fpiOTHour_C.Focus();
            //fpiOTMin_A.Focus();
            //fpiOTMin_B.Focus();
            //fpiOTMin_C.Focus();
            //fpiOvernightTripTimes.Focus();
            ////fpiTaxiTimes.Focus();
            ////fpiTaxiBenefit.Focus();
            ////fpiMiscBenefit.Focus();
            ////fpiTelephonBenefit.Focus();
            ////fpiOneDayTripFarBenefit.Focus();
            ////fpiOneDayTripNearBenefit.Focus();
            //fpiOneDayTripNearTimes.Focus();
            //fpiOneDayTripFarTimed.Focus();
            fpiExtraAGTDay.BackColor = Color.White;
            fpiExtraAGTMonthTimes.BackColor = Color.White;
            fpiExtraTimes.BackColor = Color.White;
            fpiFoodTimes.BackColor = Color.White;
            fpiOneDayTripFarTimed.BackColor = Color.White;
            fpiOneDayTripNearTimes.BackColor = Color.White;
            fpiOTHour_A.BackColor = Color.White;
            fpiOTHour_B.BackColor = Color.White;
            fpiOTHour_C.BackColor = Color.White;
            fpiOTMin_A.BackColor = Color.White;
            fpiOTMin_B.BackColor = Color.White;
            fpiOTMin_C.BackColor = Color.White;
            fpiOvernightTripTimes.BackColor = Color.White;
            fpiTaxiTimes.BackColor = Color.White;
            fpiTaxiBenefit.BackColor = Color.White;
            fpiMiscBenefit.BackColor = Color.White;
            fpiTelephonBenefit.BackColor = Color.White;
            fpiOneDayTripFarBenefit.BackColor = Color.White;
            fpiOneDayTripNearBenefit.BackColor = Color.White;
		}

		private void enableKeyfield(bool enable)
		{
			gpbEmployee.Enabled = enable;
			gpbDetail.Enabled = !enable;
		}

        private void ClearValue()
        {
            fpiExtraAGTDayBenefit.Value = 0;
            fpiExtraAGTDay.Value = 0;
            fpiExtraAGTMonthBenefit.Value = 0;
            fpiExtraAGTMonthTimes.Value = 0;
            fpiExtraBenefit.Value = 0;
            fpiExtraTimes.Value = 0;
            fpiFoodBenefit.Value = 0;
            fpiFoodTimes.Value = 0;
            fpiMiscBenefit.Value = 0;
            fpiOneDayTripFarBenefit.Value = 0;
            fpiOneDayTripFarTimed.Value = 0;
            fpiOneDayTripNearBenefit.Value = 0;
            fpiOneDayTripNearTimes.Value = 0;
            fpiOTHour_A.Value = 0;
            fpiOTHour_B.Value = 0;
            fpiOTHour_C.Value = 0;
            fpiOTMin_A.Value = 0;
            fpiOTMin_B.Value = 0;
            fpiOTMin_C.Value = 0;
            fpiOvernightTripBenefit.Value = 0;
            fpiOvernightTripTimes.Value = 0;
            fpiTaxiBenefit.Value = 0;
            fpiTaxiTimes.Value = 0;
            fpiTelephonBenefit.Value = 0;
        }

		private void clearForm()
		{
			
			clearEmployee();
			enableKeyfield(true);
		}

		private void clearEmployee()
		{
			isTextChange = false;
			txtEmpNo.Text = "";
			txtEmpName.Text = "";
			txtEmpSection.Text = "";
			isTextChange = true;
		}

		#region - validate -
		private bool validateForm()
		{
			return validateInputEmployee() && validateField();			
		}

		private bool validateField()
		{
			if(
				Convert.ToInt32(fpiExtraAGTDayBenefit.Value) == 0 &
				Convert.ToInt32(fpiExtraAGTDay.Value) == 0 &
				Convert.ToInt32(fpiExtraAGTMonthBenefit.Value) == 0 &
				Convert.ToInt32(fpiExtraAGTMonthTimes.Value) == 0 &
				Convert.ToInt32(fpiExtraBenefit.Value) == 0 &
				Convert.ToInt32(fpiExtraTimes.Value) == 0 &
				Convert.ToInt32(fpiFoodBenefit.Value) == 0 &
				Convert.ToInt32(fpiFoodTimes.Value) == 0 &
				Convert.ToInt32(fpiMiscBenefit.Value) == 0 &
				Convert.ToInt32(fpiOneDayTripFarBenefit.Value) == 0 &
				Convert.ToInt32(fpiOneDayTripFarTimed.Value) == 0 &
				Convert.ToInt32(fpiOneDayTripNearBenefit.Value) == 0 &
				Convert.ToInt32(fpiOneDayTripNearTimes.Value) == 0 &
				Convert.ToInt32(fpiOTHour_A.Value) == 0 &
				Convert.ToInt32(fpiOTHour_B.Value) == 0 &
				Convert.ToInt32(fpiOTHour_C.Value) == 0 &
				Convert.ToInt32(fpiOTMin_A.Value) == 0 &
				Convert.ToInt32(fpiOTMin_B.Value) == 0 &
				Convert.ToInt32(fpiOTMin_C.Value) == 0 &
				Convert.ToInt32(fpiOvernightTripBenefit.Value) == 0 &
				Convert.ToInt32(fpiOvernightTripTimes.Value) == 0 &
				Convert.ToInt32(fpiTaxiBenefit.Value) == 0 &
				Convert.ToInt32(fpiTaxiTimes.Value) == 0 &
				Convert.ToInt32(fpiTelephonBenefit.Value) == 0
				)
			{
				Message(MessageList.Error.E0002,"ข้อมูล");
				fpiOTHour_A.Focus();
				return false;
			}
			return true;
		}

		private bool validateInputEmployee()
		{
			if(txtEmpNo.Text == "" || txtEmpNo.Text.Length != 5)
			{
				Message(MessageList.Error.E0002, "รหัสพนักงาน" );
				setSelected(txtEmpNo);
				return false;
			}	
			return true;
		}

		private bool validateEmployee(Employee employee)
		{
			if(employee == null)
			{
				Message(MessageList.Error.E0004, "รหัสพนักงาน" );
				setSelected(txtEmpNo);
				return false;
			}
			return true;		
		}

		private bool validateEmployee(string empNo)
		{
			Employee employee = parentForm.FacadeEmployeeBenefitAdjustment.GetEmployee(empNo);
			if(validateEmployee(employee))
			{
				ObjEmployee = employee;
				return true;
			}
			setSelected(txtEmpNo);
			return false;
		}
		#endregion

//		============================== public method ==============================
		public void InitAddAction()
		{
			baseADD();
			enableKeyfield(true);
			clearForm();
			gpbEmployee.Focus();
			txtEmpNo.Focus();
		}

		public void InitEditAction(BenefitAdjustment value)
		{
			baseEDIT();
			clearForm();
			enableKeyfield(false);			
			ObjBenefitAdjustment = value;
			ObjEmployee = value.AEmployee;

			if(isReadonly)
			{
				cmdOK.Enabled = false;
			}
		}

//		============================== Base event ==============================
		private void addEvent()
		{
			try
			{				
				if (validateForm() && validateEmployee(txtEmpNo.Text) && parentForm.AddRow(ObjBenefitAdjustment))
				{
					clearForm();
					txtEmpNo.Focus();
				}
			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(AppExceptionBase ex)
			{
				Message(ex);
				setSelected(txtEmpNo);
			}
			catch(Exception ex)
			{
				Message(ex);
			}		
		}

		private void editEvent()
		{
			try
			{				
				if (validateForm() && parentForm.UpdateRow(ObjBenefitAdjustment))
				{
					this.Hide();
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

//		================================= event ================================
		private void frmEmployeeBenefitAdjustmentEntry_Load(object sender, System.EventArgs e)
		{}

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			switch (action)
			{					
				case ActionType.ADD :
					addEvent();
					break;
				case ActionType.EDIT :
					editEvent();
					break;
			}
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.Hide();
		}

		private void txtEmpNo_DoubleClick(object sender, System.EventArgs e)
		{
			formEmployeeList();
		}

		private void txtEmpNo_TextChanged(object sender, System.EventArgs e)
		{
			if(isTextChange)
			{
				if(txtEmpNo.Text.Length == 5)
				{
					try
					{
						Employee employee = parentForm.FacadeEmployeeBenefitAdjustment.GetEmployee(txtEmpNo.Text);
						if(employee != null)
						{
							setForm(employee);
						}
					}
					catch(SqlException sqlex)
					{
						Message(sqlex);
					}
					catch(AppExceptionBase ex)
					{
						Message(ex);
						setSelected(txtEmpNo);
					}
					catch(Exception ex)
					{
						Message(ex);
					}			
				}
			}
		}

		private void fpiTaxiTimes_ValueChanged(object sender, System.EventArgs e)
		{
            if (isTextChange)
			    fpiTaxiBenefit.Value = Convert.ToInt32(fpiTaxiTimes.Value) * objOtherBenefitRate.TaxiRate;
		}

		private void fpiOneDayTripNearTimes_ValueChanged(object sender, System.EventArgs e)
		{
            if (isTextChange)
			    fpiOneDayTripNearBenefit.Value = Convert.ToInt32(fpiOneDayTripNearTimes.Value) * objOtherBenefitRate.OneDayTripRateNear;
		}

		private void fpiOneDayTripFarTimed_ValueChanged(object sender, System.EventArgs e)
		{
            if (isTextChange)
			    fpiOneDayTripFarBenefit.Value = Convert.ToInt32(fpiOneDayTripFarTimed.Value) * objOtherBenefitRate.OneDayTripRateFar;
		}

		private void fpiOvernightTripTimes_ValueChanged(object sender, System.EventArgs e)
		{
            if (isTextChange)
			    fpiOvernightTripBenefit.Value = Convert.ToInt32(fpiOvernightTripTimes.Value) * objOtherBenefitRate.OvernightTripRate;
		}

		private void fpiFoodTimes_ValueChanged(object sender, System.EventArgs e)
		{
            if (isTextChange)
			    fpiFoodBenefit.Value = Convert.ToInt32(fpiFoodTimes.Value) * objOtherBenefitRate.FoodRate;
		}

		private void fpiExtraTimes_ValueChanged(object sender, System.EventArgs e)
		{
            if (isTextChange)
			    fpiExtraBenefit.Value = Convert.ToInt32(fpiExtraTimes.Value) * objOtherBenefitRate.ExtraRate;
		}

		private void fpiExtraAGTDay_ValueChanged(object sender, System.EventArgs e)
		{
            if (isTextChange)
			    fpiExtraAGTDayBenefit.Value = Convert.ToInt32(fpiExtraAGTDay.Value) * objOtherBenefitRate.DeductionAGTPerDay;
		}

		private void fpiExtraAGTMonthTimes_ValueChanged(object sender, System.EventArgs e)
		{
            if (isTextChange)
			    fpiExtraAGTMonthBenefit.Value = Convert.ToInt32(fpiExtraAGTMonthTimes.Value) * objOtherBenefitRate.ExtraAGTRate;
		}
	}
}
