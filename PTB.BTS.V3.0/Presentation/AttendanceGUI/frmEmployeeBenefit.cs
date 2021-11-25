using System;
using System.Data.SqlClient;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using FarPoint.Win.Spread.CellType;

using Entity.AttendanceEntities;
using Entity.AttendanceEntities.BenefitEntities;
using Entity.CommonEntity;
using Entity.ContractEntities;

using Facade.AttendanceFacade;
using Facade.CommonFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;
using SystemFramework.AppException;
using SystemFramework.AppMessage;

using ictus.Common.Entity.Time;
using ictus.Common.Entity.General;

namespace Presentation.AttendanceGUI
{
	public class frmEmployeeBenefit : Presentation.AttendanceGUI.frmEmployeeAttendanceBase
	{
		#region Designer generated code
		private System.Windows.Forms.DateTimePicker dtpForMonth;
		private System.Windows.Forms.Label lblForMonth;
		private System.Windows.Forms.GroupBox grbTotal;
		private System.Windows.Forms.Label lblFoodAmount;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblRateA;
		private System.Windows.Forms.Label lblRateB;
		private System.Windows.Forms.Label lblRateC;
		private System.Windows.Forms.Label lblTaxiTimes;
		private System.Windows.Forms.Label lblTaxiCharge;
		private System.Windows.Forms.Label lblFood;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label lblTotalDays;
		private System.Windows.Forms.Label lblTotalAmount;
		private System.Windows.Forms.Label lblOneDayTimes;
		private System.Windows.Forms.Label lblOneDayAmount;
		private System.Windows.Forms.Button btnCalOT;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.TabControl tabBenefit;
		private System.Windows.Forms.TabPage tabOT;
		private FarPoint.Win.Spread.FpSpread fpsOvertime;
		private System.Windows.Forms.TabPage tabOvernight;
		private FarPoint.Win.Spread.FpSpread fpsOvernightTrip;
		private System.Windows.Forms.TabPage tabOneDayTrip;
		private FarPoint.Win.Spread.FpSpread fpsOneDayTrip;
		private FarPoint.Win.Spread.SheetView fpsOvertime_Sheet1;
		private FarPoint.Win.Spread.SheetView fpsOvernightTrip_Sheet1;
		private FarPoint.Win.Spread.SheetView fpsOneDayTrip_Sheet1;
		private System.Windows.Forms.Button btnReLoad;
		private System.Windows.Forms.ContextMenu ctmOverNight;
		private System.Windows.Forms.MenuItem mniAdd;
		private System.Windows.Forms.MenuItem mniDelete;
		private System.Windows.Forms.ContextMenu ctmOneDay;
		private System.Windows.Forms.MenuItem mniAddOne;
		private System.Windows.Forms.MenuItem mniDeleteOne;
		private System.ComponentModel.IContainer components = null;

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		private void InitializeComponent()
		{
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmEmployeeBenefit));
			FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType2 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
			FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType3 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
			FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType4 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
			FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType5 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
			FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType6 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
			FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType7 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
			FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType8 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
			FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
			FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
			FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
			FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
			FarPoint.Win.Spread.CellType.NumberCellType numberCellType5 = new FarPoint.Win.Spread.CellType.NumberCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType9 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
			FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType10 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.NumberCellType numberCellType6 = new FarPoint.Win.Spread.CellType.NumberCellType();
			FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
			FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType11 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType7 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType8 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType12 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
			FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType2 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
			FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType3 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
			FarPoint.Win.Spread.CellType.NumberCellType numberCellType7 = new FarPoint.Win.Spread.CellType.NumberCellType();
			FarPoint.Win.Spread.CellType.NumberCellType numberCellType8 = new FarPoint.Win.Spread.CellType.NumberCellType();
			FarPoint.Win.Spread.CellType.NumberCellType numberCellType9 = new FarPoint.Win.Spread.CellType.NumberCellType();
			this.dtpForMonth = new System.Windows.Forms.DateTimePicker();
			this.lblForMonth = new System.Windows.Forms.Label();
			this.grbTotal = new System.Windows.Forms.GroupBox();
			this.btnReLoad = new System.Windows.Forms.Button();
			this.lblFoodAmount = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lblRateA = new System.Windows.Forms.Label();
			this.lblRateB = new System.Windows.Forms.Label();
			this.lblRateC = new System.Windows.Forms.Label();
			this.lblTaxiTimes = new System.Windows.Forms.Label();
			this.lblTaxiCharge = new System.Windows.Forms.Label();
			this.lblFood = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.lblTotalDays = new System.Windows.Forms.Label();
			this.lblTotalAmount = new System.Windows.Forms.Label();
			this.lblOneDayTimes = new System.Windows.Forms.Label();
			this.lblOneDayAmount = new System.Windows.Forms.Label();
			this.btnCalOT = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.tabBenefit = new System.Windows.Forms.TabControl();
			this.tabOT = new System.Windows.Forms.TabPage();
			this.fpsOvertime = new FarPoint.Win.Spread.FpSpread();
			this.fpsOvertime_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.tabOvernight = new System.Windows.Forms.TabPage();
			this.fpsOvernightTrip = new FarPoint.Win.Spread.FpSpread();
			this.ctmOverNight = new System.Windows.Forms.ContextMenu();
			this.mniAdd = new System.Windows.Forms.MenuItem();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			this.fpsOvernightTrip_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.tabOneDayTrip = new System.Windows.Forms.TabPage();
			this.fpsOneDayTrip = new FarPoint.Win.Spread.FpSpread();
			this.ctmOneDay = new System.Windows.Forms.ContextMenu();
			this.mniAddOne = new System.Windows.Forms.MenuItem();
			this.mniDeleteOne = new System.Windows.Forms.MenuItem();
			this.fpsOneDayTrip_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.grbTotal.SuspendLayout();
			this.tabBenefit.SuspendLayout();
			this.tabOT.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fpsOvertime)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsOvertime_Sheet1)).BeginInit();
			this.tabOvernight.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fpsOvernightTrip)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsOvernightTrip_Sheet1)).BeginInit();
			this.tabOneDayTrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fpsOneDayTrip)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsOneDayTrip_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// dtpForMonth
			// 
			this.dtpForMonth.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.dtpForMonth.CustomFormat = "MM/yyyy";
			this.dtpForMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpForMonth.Location = new System.Drawing.Point(480, 104);
			this.dtpForMonth.Name = "dtpForMonth";
			this.dtpForMonth.Size = new System.Drawing.Size(80, 20);
			this.dtpForMonth.TabIndex = 103;
			this.dtpForMonth.Value = new System.DateTime(2006, 1, 1, 0, 0, 0, 0);
			this.dtpForMonth.ValueChanged += new System.EventHandler(this.dtpForMonth_ValueChanged);
			// 
			// lblForMonth
			// 
			this.lblForMonth.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblForMonth.AutoSize = true;
			this.lblForMonth.Location = new System.Drawing.Point(416, 106);
			this.lblForMonth.Name = "lblForMonth";
			this.lblForMonth.Size = new System.Drawing.Size(58, 16);
			this.lblForMonth.TabIndex = 104;
			this.lblForMonth.Text = "สำหรับเดือน";
			// 
			// grbTotal
			// 
			this.grbTotal.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.grbTotal.Controls.Add(this.btnReLoad);
			this.grbTotal.Controls.Add(this.lblFoodAmount);
			this.grbTotal.Controls.Add(this.label1);
			this.grbTotal.Controls.Add(this.label17);
			this.grbTotal.Controls.Add(this.label16);
			this.grbTotal.Controls.Add(this.label2);
			this.grbTotal.Controls.Add(this.label15);
			this.grbTotal.Controls.Add(this.label14);
			this.grbTotal.Controls.Add(this.label13);
			this.grbTotal.Controls.Add(this.label11);
			this.grbTotal.Controls.Add(this.label10);
			this.grbTotal.Controls.Add(this.label9);
			this.grbTotal.Controls.Add(this.label8);
			this.grbTotal.Controls.Add(this.label7);
			this.grbTotal.Controls.Add(this.label6);
			this.grbTotal.Controls.Add(this.label5);
			this.grbTotal.Controls.Add(this.label4);
			this.grbTotal.Controls.Add(this.lblRateA);
			this.grbTotal.Controls.Add(this.lblRateB);
			this.grbTotal.Controls.Add(this.lblRateC);
			this.grbTotal.Controls.Add(this.lblTaxiTimes);
			this.grbTotal.Controls.Add(this.lblTaxiCharge);
			this.grbTotal.Controls.Add(this.lblFood);
			this.grbTotal.Controls.Add(this.label12);
			this.grbTotal.Controls.Add(this.lblTotalDays);
			this.grbTotal.Controls.Add(this.lblTotalAmount);
			this.grbTotal.Controls.Add(this.lblOneDayTimes);
			this.grbTotal.Controls.Add(this.lblOneDayAmount);
			this.grbTotal.Controls.Add(this.btnCalOT);
			this.grbTotal.Location = new System.Drawing.Point(16, 304);
			this.grbTotal.Name = "grbTotal";
			this.grbTotal.Size = new System.Drawing.Size(944, 96);
			this.grbTotal.TabIndex = 109;
			this.grbTotal.TabStop = false;
			this.grbTotal.Visible = false;
			// 
			// btnReLoad
			// 
			this.btnReLoad.Location = new System.Drawing.Point(264, 64);
			this.btnReLoad.Name = "btnReLoad";
			this.btnReLoad.Size = new System.Drawing.Size(96, 23);
			this.btnReLoad.TabIndex = 146;
			this.btnReLoad.Text = "ดึงเวลาทำงานใหม่";
			this.btnReLoad.Click += new System.EventHandler(this.btnReLoad_Click);
			// 
			// lblFoodAmount
			// 
			this.lblFoodAmount.Location = new System.Drawing.Point(320, 40);
			this.lblFoodAmount.Name = "lblFoodAmount";
			this.lblFoodAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.lblFoodAmount.Size = new System.Drawing.Size(112, 23);
			this.lblFoodAmount.TabIndex = 145;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(432, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(21, 16);
			this.label1.TabIndex = 144;
			this.label1.Text = "ครั้ง";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(792, 40);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(23, 16);
			this.label17.TabIndex = 143;
			this.label17.Text = "บาท";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(792, 16);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(26, 16);
			this.label16.TabIndex = 142;
			this.label16.Text = "เที่ยว";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(632, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(85, 16);
			this.label2.TabIndex = 141;
			this.label2.Text = "ค่าเดินทางไป-กลับ";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(584, 40);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(23, 16);
			this.label15.TabIndex = 140;
			this.label15.Text = "บาท";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(584, 16);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(18, 16);
			this.label14.TabIndex = 139;
			this.label14.Text = "คืน";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(496, 16);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(34, 16);
			this.label13.TabIndex = 138;
			this.label13.Text = "ค้างคืน";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(320, 16);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(44, 16);
			this.label11.TabIndex = 137;
			this.label11.Text = "ค่าอาหาร";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(248, 40);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(23, 16);
			this.label10.TabIndex = 135;
			this.label10.Text = "บาท";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(248, 16);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(26, 16);
			this.label9.TabIndex = 134;
			this.label9.Text = "เที่ยว";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(144, 16);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(42, 16);
			this.label8.TabIndex = 133;
			this.label8.Text = "ค่าแท็กซี่";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(56, 64);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(13, 16);
			this.label7.TabIndex = 132;
			this.label7.Text = "C";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(56, 40);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(12, 16);
			this.label6.TabIndex = 131;
			this.label6.Text = "B";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(56, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(12, 16);
			this.label5.TabIndex = 130;
			this.label5.Text = "A";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(8, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 16);
			this.label4.TabIndex = 129;
			this.label4.Text = "ล่วงเวลา";
			// 
			// lblRateA
			// 
			this.lblRateA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.lblRateA.Location = new System.Drawing.Point(80, 16);
			this.lblRateA.Name = "lblRateA";
			this.lblRateA.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.lblRateA.Size = new System.Drawing.Size(40, 23);
			this.lblRateA.TabIndex = 119;
			// 
			// lblRateB
			// 
			this.lblRateB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.lblRateB.Location = new System.Drawing.Point(80, 40);
			this.lblRateB.Name = "lblRateB";
			this.lblRateB.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.lblRateB.Size = new System.Drawing.Size(40, 23);
			this.lblRateB.TabIndex = 121;
			// 
			// lblRateC
			// 
			this.lblRateC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.lblRateC.Location = new System.Drawing.Point(80, 64);
			this.lblRateC.Name = "lblRateC";
			this.lblRateC.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.lblRateC.Size = new System.Drawing.Size(40, 23);
			this.lblRateC.TabIndex = 122;
			// 
			// lblTaxiTimes
			// 
			this.lblTaxiTimes.Location = new System.Drawing.Point(192, 16);
			this.lblTaxiTimes.Name = "lblTaxiTimes";
			this.lblTaxiTimes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.lblTaxiTimes.Size = new System.Drawing.Size(56, 23);
			this.lblTaxiTimes.TabIndex = 124;
			// 
			// lblTaxiCharge
			// 
			this.lblTaxiCharge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.lblTaxiCharge.Location = new System.Drawing.Point(144, 40);
			this.lblTaxiCharge.Name = "lblTaxiCharge";
			this.lblTaxiCharge.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.lblTaxiCharge.Size = new System.Drawing.Size(104, 23);
			this.lblTaxiCharge.TabIndex = 127;
			// 
			// lblFood
			// 
			this.lblFood.Location = new System.Drawing.Point(376, 16);
			this.lblFood.Name = "lblFood";
			this.lblFood.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.lblFood.Size = new System.Drawing.Size(56, 23);
			this.lblFood.TabIndex = 128;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(432, 40);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(23, 16);
			this.label12.TabIndex = 136;
			this.label12.Text = "บาท";
			// 
			// lblTotalDays
			// 
			this.lblTotalDays.BackColor = System.Drawing.SystemColors.Control;
			this.lblTotalDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.lblTotalDays.Location = new System.Drawing.Point(536, 16);
			this.lblTotalDays.Name = "lblTotalDays";
			this.lblTotalDays.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.lblTotalDays.Size = new System.Drawing.Size(48, 23);
			this.lblTotalDays.TabIndex = 120;
			// 
			// lblTotalAmount
			// 
			this.lblTotalAmount.BackColor = System.Drawing.SystemColors.Control;
			this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.lblTotalAmount.Location = new System.Drawing.Point(496, 40);
			this.lblTotalAmount.Name = "lblTotalAmount";
			this.lblTotalAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.lblTotalAmount.Size = new System.Drawing.Size(88, 23);
			this.lblTotalAmount.TabIndex = 123;
			// 
			// lblOneDayTimes
			// 
			this.lblOneDayTimes.BackColor = System.Drawing.SystemColors.Control;
			this.lblOneDayTimes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.lblOneDayTimes.Location = new System.Drawing.Point(728, 16);
			this.lblOneDayTimes.Name = "lblOneDayTimes";
			this.lblOneDayTimes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.lblOneDayTimes.Size = new System.Drawing.Size(56, 23);
			this.lblOneDayTimes.TabIndex = 125;
			// 
			// lblOneDayAmount
			// 
			this.lblOneDayAmount.BackColor = System.Drawing.SystemColors.Control;
			this.lblOneDayAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.lblOneDayAmount.Location = new System.Drawing.Point(640, 40);
			this.lblOneDayAmount.Name = "lblOneDayAmount";
			this.lblOneDayAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.lblOneDayAmount.Size = new System.Drawing.Size(144, 23);
			this.lblOneDayAmount.TabIndex = 126;
			// 
			// btnCalOT
			// 
			this.btnCalOT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.btnCalOT.Location = new System.Drawing.Point(144, 64);
			this.btnCalOT.Name = "btnCalOT";
			this.btnCalOT.Size = new System.Drawing.Size(112, 24);
			this.btnCalOT.TabIndex = 2;
			this.btnCalOT.Text = "คำนวณใหม่ทั้งหมด";
			this.btnCalOT.Click += new System.EventHandler(this.btnCalOT_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnCancel.Location = new System.Drawing.Point(491, 408);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 108;
			this.btnCancel.Text = "ยกเลิก";
			this.btnCancel.Visible = false;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnOK.Location = new System.Drawing.Point(411, 408);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 107;
			this.btnOK.Text = "ตกลง";
			this.btnOK.Visible = false;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// tabBenefit
			// 
			this.tabBenefit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.tabBenefit.Controls.Add(this.tabOT);
			this.tabBenefit.Controls.Add(this.tabOvernight);
			this.tabBenefit.Controls.Add(this.tabOneDayTrip);
			this.tabBenefit.Location = new System.Drawing.Point(16, 144);
			this.tabBenefit.Name = "tabBenefit";
			this.tabBenefit.SelectedIndex = 0;
			this.tabBenefit.Size = new System.Drawing.Size(944, 160);
			this.tabBenefit.TabIndex = 106;
			this.tabBenefit.Visible = false;
			this.tabBenefit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tabBenefit_KeyUp);
			// 
			// tabOT
			// 
			this.tabOT.Controls.Add(this.fpsOvertime);
			this.tabOT.Location = new System.Drawing.Point(4, 22);
			this.tabOT.Name = "tabOT";
			this.tabOT.Size = new System.Drawing.Size(936, 134);
			this.tabOT.TabIndex = 0;
			this.tabOT.Text = "ค่าล่วงเวลา, ค่า Taxi  และค่าอาหาร";
			// 
			// fpsOvertime
			// 
			this.fpsOvertime.AllowDragFill = true;
			this.fpsOvertime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsOvertime.EditModePermanent = true;
			this.fpsOvertime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.fpsOvertime.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsOvertime.Location = new System.Drawing.Point(8, 8);
			this.fpsOvertime.Name = "fpsOvertime";
			this.fpsOvertime.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
			this.fpsOvertime.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																					 this.fpsOvertime_Sheet1});
			this.fpsOvertime.Size = new System.Drawing.Size(920, 120);
			this.fpsOvertime.TabIndex = 1;
			this.fpsOvertime.TabStop = false;
			this.fpsOvertime.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsOvertime_CellDoubleClick);
			this.fpsOvertime.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fpsOvertime_KeyUp);
			// 
			// fpsOvertime_Sheet1
			// 
			this.fpsOvertime_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsOvertime_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsOvertime_Sheet1.ColumnCount = 16;
			this.fpsOvertime_Sheet1.ColumnHeader.RowCount = 3;
			this.fpsOvertime_Sheet1.RowCount = 0;
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(0, 0).RowSpan = 3;
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(0, 0).Text = "วันที่";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(0, 1).ColumnSpan = 8;
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "เวลาปฏิบัติหน้าที่  Working Time";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(0, 9).ColumnSpan = 3;
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(0, 9).Text = "ล่วงเวลา Overtime Rate";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(0, 12).RowSpan = 3;
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(0, 12).Text = "ค่าแท็กซี่ Taxi Charge (Times)";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(0, 13).RowSpan = 3;
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(0, 13).Text = "ค่าอาหาร Food Charge (Amount)";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(0, 14).RowSpan = 3;
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(0, 14).Text = "Service Staff Type";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(0, 15).RowSpan = 3;
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(0, 15).Text = "ลูกค้า";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(1, 1).ColumnSpan = 2;
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(1, 1).Text = "ก่อนเวลา Before Hours";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(1, 3).ColumnSpan = 2;
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(1, 3).Text = "ระหว่างเวลา During Hours";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(1, 5).ColumnSpan = 2;
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(1, 5).Text = "เวลาพัก Lunch Time";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(1, 7).ColumnSpan = 2;
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(1, 7).Text = "หลังเวลา After Hours";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(1, 8).Text = "หลังเวลา Work After Hours";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(1, 9).RowSpan = 2;
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(1, 9).Text = "A";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(1, 10).RowSpan = 2;
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(1, 10).Text = "B";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(1, 11).RowSpan = 2;
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(1, 11).Text = "C";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(2, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(2, 1).Text = "From";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(2, 2).Text = "To";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(2, 3).Text = "From";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(2, 4).Text = "To";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(2, 5).Text = "From";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(2, 6).Text = "To";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(2, 7).Text = "From";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(2, 8).Text = "To";
			this.fpsOvertime_Sheet1.ColumnHeader.Columns.Default.Resizable = false;
			this.fpsOvertime_Sheet1.Columns.Default.Resizable = false;
			this.fpsOvertime_Sheet1.Columns.Get(0).BackColor = System.Drawing.Color.MistyRose;
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			textCellType1.ReadOnly = true;
			this.fpsOvertime_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsOvertime_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsOvertime_Sheet1.Columns.Get(0).Locked = true;
			this.fpsOvertime_Sheet1.Columns.Get(0).Width = 40F;
			dateTimeCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			dateTimeCellType1.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
			dateTimeCellType1.DateDefault = new System.DateTime(2500, 1, 1, 0, 0, 0, 0);
			dateTimeCellType1.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
			dateTimeCellType1.DropDownButton = false;
			dateTimeCellType1.MaximumTime = System.TimeSpan.Parse("23:59:59");
			dateTimeCellType1.TimeDefault = new System.DateTime(2500, 1, 1, 0, 0, 0, 0);
			dateTimeCellType1.UserDefinedFormat = "HH:mm";
			this.fpsOvertime_Sheet1.Columns.Get(1).CellType = dateTimeCellType1;
			this.fpsOvertime_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsOvertime_Sheet1.Columns.Get(1).Label = "From";
			this.fpsOvertime_Sheet1.Columns.Get(1).Locked = false;
			dateTimeCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			dateTimeCellType2.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
			dateTimeCellType2.DateDefault = new System.DateTime(2500, 1, 1, 0, 0, 0, 0);
			dateTimeCellType2.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
			dateTimeCellType2.DropDownButton = false;
			dateTimeCellType2.MaximumTime = System.TimeSpan.Parse("23:59:59");
			dateTimeCellType2.TimeDefault = new System.DateTime(2500, 1, 1, 0, 0, 0, 0);
			dateTimeCellType2.UserDefinedFormat = "HH:mm";
			this.fpsOvertime_Sheet1.Columns.Get(2).CellType = dateTimeCellType2;
			this.fpsOvertime_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsOvertime_Sheet1.Columns.Get(2).Label = "To";
			this.fpsOvertime_Sheet1.Columns.Get(2).Locked = false;
			this.fpsOvertime_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.MistyRose;
			dateTimeCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			dateTimeCellType3.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
			dateTimeCellType3.DateDefault = new System.DateTime(2500, 1, 1, 0, 0, 0, 0);
			dateTimeCellType3.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
			dateTimeCellType3.DropDownButton = false;
			dateTimeCellType3.MaximumTime = System.TimeSpan.Parse("23:59:59");
			dateTimeCellType3.TimeDefault = new System.DateTime(2500, 1, 1, 0, 0, 0, 0);
			dateTimeCellType3.UserDefinedFormat = "HH:mm";
			this.fpsOvertime_Sheet1.Columns.Get(3).CellType = dateTimeCellType3;
			this.fpsOvertime_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsOvertime_Sheet1.Columns.Get(3).Label = "From";
			this.fpsOvertime_Sheet1.Columns.Get(3).Locked = true;
			this.fpsOvertime_Sheet1.Columns.Get(3).Width = 67F;
			this.fpsOvertime_Sheet1.Columns.Get(4).BackColor = System.Drawing.Color.MistyRose;
			dateTimeCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			dateTimeCellType4.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
			dateTimeCellType4.DateDefault = new System.DateTime(2500, 1, 1, 0, 0, 0, 0);
			dateTimeCellType4.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
			dateTimeCellType4.DropDownButton = false;
			dateTimeCellType4.MaximumTime = System.TimeSpan.Parse("23:59:59");
			dateTimeCellType4.TimeDefault = new System.DateTime(2500, 1, 1, 0, 0, 0, 0);
			dateTimeCellType4.UserDefinedFormat = "HH:mm";
			this.fpsOvertime_Sheet1.Columns.Get(4).CellType = dateTimeCellType4;
			this.fpsOvertime_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsOvertime_Sheet1.Columns.Get(4).Label = "To";
			this.fpsOvertime_Sheet1.Columns.Get(4).Locked = true;
			this.fpsOvertime_Sheet1.Columns.Get(4).Width = 67F;
			dateTimeCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			dateTimeCellType5.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
			dateTimeCellType5.DateDefault = new System.DateTime(2500, 1, 1, 0, 0, 0, 0);
			dateTimeCellType5.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
			dateTimeCellType5.DropDownButton = false;
			dateTimeCellType5.MaximumTime = System.TimeSpan.Parse("23:59:59");
			dateTimeCellType5.TimeDefault = new System.DateTime(2500, 1, 1, 0, 0, 0, 0);
			dateTimeCellType5.UserDefinedFormat = "HH:mm";
			this.fpsOvertime_Sheet1.Columns.Get(5).CellType = dateTimeCellType5;
			this.fpsOvertime_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsOvertime_Sheet1.Columns.Get(5).Label = "From";
			this.fpsOvertime_Sheet1.Columns.Get(5).Locked = false;
			this.fpsOvertime_Sheet1.Columns.Get(5).Width = 55F;
			dateTimeCellType6.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			dateTimeCellType6.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
			dateTimeCellType6.DateDefault = new System.DateTime(2500, 1, 1, 0, 0, 0, 0);
			dateTimeCellType6.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
			dateTimeCellType6.DropDownButton = false;
			dateTimeCellType6.MaximumTime = System.TimeSpan.Parse("23:59:59");
			dateTimeCellType6.TimeDefault = new System.DateTime(2500, 1, 1, 0, 0, 0, 0);
			dateTimeCellType6.UserDefinedFormat = "HH:mm";
			this.fpsOvertime_Sheet1.Columns.Get(6).CellType = dateTimeCellType6;
			this.fpsOvertime_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsOvertime_Sheet1.Columns.Get(6).Label = "To";
			this.fpsOvertime_Sheet1.Columns.Get(6).Width = 55F;
			dateTimeCellType7.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			dateTimeCellType7.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
			dateTimeCellType7.DateDefault = new System.DateTime(2500, 1, 1, 0, 0, 0, 0);
			dateTimeCellType7.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
			dateTimeCellType7.DropDownButton = false;
			dateTimeCellType7.MaximumTime = System.TimeSpan.Parse("23:59:59");
			dateTimeCellType7.TimeDefault = new System.DateTime(2500, 1, 1, 0, 0, 0, 0);
			dateTimeCellType7.UserDefinedFormat = "HH:mm";
			this.fpsOvertime_Sheet1.Columns.Get(7).CellType = dateTimeCellType7;
			this.fpsOvertime_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsOvertime_Sheet1.Columns.Get(7).Label = "From";
			this.fpsOvertime_Sheet1.Columns.Get(7).Width = 55F;
			dateTimeCellType8.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			dateTimeCellType8.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
			dateTimeCellType8.DateDefault = new System.DateTime(2500, 1, 1, 0, 0, 0, 0);
			dateTimeCellType8.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
			dateTimeCellType8.DropDownButton = false;
			dateTimeCellType8.MaximumTime = System.TimeSpan.Parse("23:59:59");
			dateTimeCellType8.TimeDefault = new System.DateTime(2500, 1, 1, 0, 0, 0, 0);
			dateTimeCellType8.UserDefinedFormat = "HH:mm";
			this.fpsOvertime_Sheet1.Columns.Get(8).CellType = dateTimeCellType8;
			this.fpsOvertime_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsOvertime_Sheet1.Columns.Get(8).Label = "To";
			this.fpsOvertime_Sheet1.Columns.Get(8).Width = 55F;
			this.fpsOvertime_Sheet1.Columns.Get(9).BackColor = System.Drawing.Color.MistyRose;
			numberCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			numberCellType1.DecimalPlaces = 2;
			numberCellType1.DecimalSeparator = ".";
			numberCellType1.DropDownButton = false;
			numberCellType1.ReadOnly = true;
			this.fpsOvertime_Sheet1.Columns.Get(9).CellType = numberCellType1;
			this.fpsOvertime_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
			this.fpsOvertime_Sheet1.Columns.Get(9).Locked = true;
			this.fpsOvertime_Sheet1.Columns.Get(9).Width = 40F;
			this.fpsOvertime_Sheet1.Columns.Get(10).BackColor = System.Drawing.Color.MistyRose;
			numberCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			numberCellType2.DecimalPlaces = 2;
			numberCellType2.DecimalSeparator = ".";
			numberCellType2.DropDownButton = false;
			numberCellType2.ReadOnly = true;
			this.fpsOvertime_Sheet1.Columns.Get(10).CellType = numberCellType2;
			this.fpsOvertime_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
			this.fpsOvertime_Sheet1.Columns.Get(10).Locked = true;
			this.fpsOvertime_Sheet1.Columns.Get(10).Width = 40F;
			this.fpsOvertime_Sheet1.Columns.Get(11).BackColor = System.Drawing.Color.MistyRose;
			numberCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			numberCellType3.DecimalPlaces = 2;
			numberCellType3.DecimalSeparator = ".";
			numberCellType3.DropDownButton = false;
			numberCellType3.ReadOnly = true;
			this.fpsOvertime_Sheet1.Columns.Get(11).CellType = numberCellType3;
			this.fpsOvertime_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
			this.fpsOvertime_Sheet1.Columns.Get(11).Locked = true;
			this.fpsOvertime_Sheet1.Columns.Get(11).Width = 40F;
			this.fpsOvertime_Sheet1.Columns.Get(12).BackColor = System.Drawing.Color.MistyRose;
			numberCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			numberCellType4.DecimalPlaces = 2;
			numberCellType4.DecimalSeparator = ".";
			numberCellType4.DropDownButton = false;
			numberCellType4.FixedPoint = false;
			numberCellType4.MinimumValue = 0;
			numberCellType4.Separator = ",";
			numberCellType4.ShowSeparator = true;
			this.fpsOvertime_Sheet1.Columns.Get(12).CellType = numberCellType4;
			this.fpsOvertime_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsOvertime_Sheet1.Columns.Get(12).Locked = true;
			this.fpsOvertime_Sheet1.Columns.Get(12).Width = 55F;
			this.fpsOvertime_Sheet1.Columns.Get(13).BackColor = System.Drawing.Color.MistyRose;
			numberCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			numberCellType5.DecimalPlaces = 2;
			numberCellType5.DecimalSeparator = ".";
			numberCellType5.DropDownButton = false;
			numberCellType5.FixedPoint = false;
			numberCellType5.MinimumValue = 0;
			numberCellType5.Separator = ",";
			numberCellType5.ShowSeparator = true;
			this.fpsOvertime_Sheet1.Columns.Get(13).CellType = numberCellType5;
			this.fpsOvertime_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsOvertime_Sheet1.Columns.Get(13).Locked = true;
			this.fpsOvertime_Sheet1.Columns.Get(13).Width = 55F;
			this.fpsOvertime_Sheet1.Columns.Get(14).BackColor = System.Drawing.Color.MistyRose;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			this.fpsOvertime_Sheet1.Columns.Get(14).CellType = textCellType2;
			this.fpsOvertime_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
			this.fpsOvertime_Sheet1.Columns.Get(14).Locked = true;
			this.fpsOvertime_Sheet1.Columns.Get(15).BackColor = System.Drawing.Color.MistyRose;
			textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType3.DropDownButton = false;
			this.fpsOvertime_Sheet1.Columns.Get(15).CellType = textCellType3;
			this.fpsOvertime_Sheet1.Columns.Get(15).Locked = true;
			this.fpsOvertime_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsOvertime_Sheet1.RowHeader.Rows.Default.Resizable = false;
			this.fpsOvertime_Sheet1.Rows.Default.Resizable = false;
			this.fpsOvertime_Sheet1.SheetName = "Sheet1";
			this.fpsOvertime_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// tabOvernight
			// 
			this.tabOvernight.Controls.Add(this.fpsOvernightTrip);
			this.tabOvernight.Location = new System.Drawing.Point(4, 22);
			this.tabOvernight.Name = "tabOvernight";
			this.tabOvernight.Size = new System.Drawing.Size(936, 134);
			this.tabOvernight.TabIndex = 1;
			this.tabOvernight.Text = "ค่าค้างคืน";
			this.tabOvernight.Visible = false;
			// 
			// fpsOvernightTrip
			// 
			this.fpsOvernightTrip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsOvernightTrip.ContextMenu = this.ctmOverNight;
			this.fpsOvernightTrip.EditModePermanent = true;
			this.fpsOvernightTrip.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsOvernightTrip.Location = new System.Drawing.Point(8, 8);
			this.fpsOvernightTrip.Name = "fpsOvernightTrip";
			this.fpsOvernightTrip.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																						  this.fpsOvernightTrip_Sheet1});
			this.fpsOvernightTrip.Size = new System.Drawing.Size(920, 120);
			this.fpsOvernightTrip.TabIndex = 1;
			this.fpsOvernightTrip.TabStop = false;
			this.fpsOvernightTrip.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
			this.fpsOvernightTrip.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsOvernightTrip_CellDoubleClick);
			// 
			// ctmOverNight
			// 
			this.ctmOverNight.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.mniAdd,
																						 this.mniDelete});
			// 
			// mniAdd
			// 
			this.mniAdd.Index = 0;
			this.mniAdd.Text = "เพิ่ม";
			this.mniAdd.Click += new System.EventHandler(this.mniAdd_Click);
			// 
			// mniDelete
			// 
			this.mniDelete.Enabled = false;
			this.mniDelete.Index = 1;
			this.mniDelete.Text = "ลบ";
			this.mniDelete.Click += new System.EventHandler(this.mniDelete_Click);
			// 
			// fpsOvernightTrip_Sheet1
			// 
			this.fpsOvernightTrip_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsOvernightTrip_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsOvernightTrip_Sheet1.ColumnCount = 11;
			this.fpsOvernightTrip_Sheet1.ColumnHeader.RowCount = 2;
			this.fpsOvernightTrip_Sheet1.RowCount = 0;
			this.fpsOvernightTrip_Sheet1.ColumnHeader.Cells.Get(0, 0).ColumnSpan = 2;
			this.fpsOvernightTrip_Sheet1.ColumnHeader.Cells.Get(0, 0).Text = "วันที่";
			this.fpsOvernightTrip_Sheet1.ColumnHeader.Cells.Get(0, 2).RowSpan = 2;
			this.fpsOvernightTrip_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "ลูกค้า";
			this.fpsOvernightTrip_Sheet1.ColumnHeader.Cells.Get(0, 3).RowSpan = 2;
			this.fpsOvernightTrip_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ฝ่ายลูกค้า";
			this.fpsOvernightTrip_Sheet1.ColumnHeader.Cells.Get(0, 4).RowSpan = 2;
			this.fpsOvernightTrip_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "สถานที่";
			this.fpsOvernightTrip_Sheet1.ColumnHeader.Cells.Get(0, 5).RowSpan = 2;
			this.fpsOvernightTrip_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "จำนวนคืน";
			this.fpsOvernightTrip_Sheet1.ColumnHeader.Cells.Get(0, 6).RowSpan = 2;
			this.fpsOvernightTrip_Sheet1.ColumnHeader.Cells.Get(0, 6).Text = "จำนวนเงิน";
			this.fpsOvernightTrip_Sheet1.ColumnHeader.Cells.Get(0, 7).RowSpan = 2;
			this.fpsOvernightTrip_Sheet1.ColumnHeader.Cells.Get(0, 7).Text = "จ่ายล่วงหน้า";
			this.fpsOvernightTrip_Sheet1.ColumnHeader.Cells.Get(0, 8).RowSpan = 2;
			this.fpsOvernightTrip_Sheet1.ColumnHeader.Cells.Get(0, 8).Text = "จ่ายเมื่อ";
			this.fpsOvernightTrip_Sheet1.ColumnHeader.Cells.Get(1, 0).Text = "ตั้งแต่";
			this.fpsOvernightTrip_Sheet1.ColumnHeader.Cells.Get(1, 1).Text = "จนถึง";
			dateTimeCellType9.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			dateTimeCellType9.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
			dateTimeCellType9.DateDefault = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
			dateTimeCellType9.DropDownButton = false;
			dateTimeCellType9.TimeDefault = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
			this.fpsOvernightTrip_Sheet1.Columns.Get(0).CellType = dateTimeCellType9;
			this.fpsOvernightTrip_Sheet1.Columns.Get(0).Label = "ตั้งแต่";
			this.fpsOvernightTrip_Sheet1.Columns.Get(0).Resizable = false;
			this.fpsOvernightTrip_Sheet1.Columns.Get(0).Width = 70F;
			dateTimeCellType10.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			dateTimeCellType10.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
			dateTimeCellType10.DateDefault = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
			dateTimeCellType10.DropDownButton = false;
			dateTimeCellType10.TimeDefault = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
			this.fpsOvernightTrip_Sheet1.Columns.Get(1).CellType = dateTimeCellType10;
			this.fpsOvernightTrip_Sheet1.Columns.Get(1).Label = "จนถึง";
			this.fpsOvernightTrip_Sheet1.Columns.Get(1).Resizable = false;
			this.fpsOvernightTrip_Sheet1.Columns.Get(1).Width = 70F;
			this.fpsOvernightTrip_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.MistyRose;
			textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType4.DropDownButton = false;
			textCellType4.ReadOnly = true;
			this.fpsOvernightTrip_Sheet1.Columns.Get(2).CellType = textCellType4;
			this.fpsOvernightTrip_Sheet1.Columns.Get(2).Locked = true;
			this.fpsOvernightTrip_Sheet1.Columns.Get(2).Resizable = false;
			this.fpsOvernightTrip_Sheet1.Columns.Get(2).Width = 150F;
			this.fpsOvernightTrip_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.MistyRose;
			textCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType5.DropDownButton = false;
			textCellType5.ReadOnly = true;
			this.fpsOvernightTrip_Sheet1.Columns.Get(3).CellType = textCellType5;
			this.fpsOvernightTrip_Sheet1.Columns.Get(3).Locked = true;
			this.fpsOvernightTrip_Sheet1.Columns.Get(3).Resizable = false;
			this.fpsOvernightTrip_Sheet1.Columns.Get(3).Width = 130F;
			this.fpsOvernightTrip_Sheet1.Columns.Get(4).CellType = comboBoxCellType1;
			this.fpsOvernightTrip_Sheet1.Columns.Get(4).Resizable = false;
			this.fpsOvernightTrip_Sheet1.Columns.Get(4).Width = 200F;
			this.fpsOvernightTrip_Sheet1.Columns.Get(5).BackColor = System.Drawing.Color.MistyRose;
			textCellType6.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType6.DropDownButton = false;
			textCellType6.ReadOnly = true;
			this.fpsOvernightTrip_Sheet1.Columns.Get(5).CellType = textCellType6;
			this.fpsOvernightTrip_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsOvernightTrip_Sheet1.Columns.Get(5).Locked = true;
			this.fpsOvernightTrip_Sheet1.Columns.Get(5).Resizable = false;
			this.fpsOvernightTrip_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
			this.fpsOvernightTrip_Sheet1.Columns.Get(5).Width = 50F;
			this.fpsOvernightTrip_Sheet1.Columns.Get(6).BackColor = System.Drawing.Color.MistyRose;
			numberCellType6.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			numberCellType6.DecimalPlaces = 2;
			numberCellType6.DecimalSeparator = ".";
			numberCellType6.DropDownButton = false;
			numberCellType6.ReadOnly = true;
			numberCellType6.Separator = ",";
			numberCellType6.ShowSeparator = true;
			this.fpsOvernightTrip_Sheet1.Columns.Get(6).CellType = numberCellType6;
			this.fpsOvernightTrip_Sheet1.Columns.Get(6).Locked = true;
			this.fpsOvernightTrip_Sheet1.Columns.Get(6).Resizable = false;
			this.fpsOvernightTrip_Sheet1.Columns.Get(6).Width = 70F;
			this.fpsOvernightTrip_Sheet1.Columns.Get(7).CellType = checkBoxCellType1;
			this.fpsOvernightTrip_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsOvernightTrip_Sheet1.Columns.Get(7).Resizable = false;
			this.fpsOvernightTrip_Sheet1.Columns.Get(7).Width = 50F;
			dateTimeCellType11.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			dateTimeCellType11.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
			dateTimeCellType11.DateDefault = new System.DateTime(1457, 1, 1, 0, 0, 0, 0);
			dateTimeCellType11.DropDownButton = false;
			dateTimeCellType11.TimeDefault = new System.DateTime(1457, 1, 1, 0, 0, 0, 0);
			this.fpsOvernightTrip_Sheet1.Columns.Get(8).CellType = dateTimeCellType11;
			this.fpsOvernightTrip_Sheet1.Columns.Get(8).Resizable = false;
			this.fpsOvernightTrip_Sheet1.Columns.Get(8).Width = 70F;
			textCellType7.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType7.DropDownButton = false;
			this.fpsOvernightTrip_Sheet1.Columns.Get(9).CellType = textCellType7;
			this.fpsOvernightTrip_Sheet1.Columns.Get(9).Visible = false;
			textCellType8.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType8.DropDownButton = false;
			this.fpsOvernightTrip_Sheet1.Columns.Get(10).CellType = textCellType8;
			this.fpsOvernightTrip_Sheet1.Columns.Get(10).Visible = false;
			this.fpsOvernightTrip_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsOvernightTrip_Sheet1.SheetName = "Sheet1";
			this.fpsOvernightTrip_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// tabOneDayTrip
			// 
			this.tabOneDayTrip.Controls.Add(this.fpsOneDayTrip);
			this.tabOneDayTrip.Location = new System.Drawing.Point(4, 22);
			this.tabOneDayTrip.Name = "tabOneDayTrip";
			this.tabOneDayTrip.Size = new System.Drawing.Size(936, 134);
			this.tabOneDayTrip.TabIndex = 2;
			this.tabOneDayTrip.Text = " ค่าเดินทาง ไป - กลับ";
			this.tabOneDayTrip.Visible = false;
			// 
			// fpsOneDayTrip
			// 
			this.fpsOneDayTrip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsOneDayTrip.ContextMenu = this.ctmOneDay;
			this.fpsOneDayTrip.EditModePermanent = true;
			this.fpsOneDayTrip.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsOneDayTrip.Location = new System.Drawing.Point(76, 8);
			this.fpsOneDayTrip.Name = "fpsOneDayTrip";
			this.fpsOneDayTrip.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																					   this.fpsOneDayTrip_Sheet1});
			this.fpsOneDayTrip.Size = new System.Drawing.Size(784, 120);
			this.fpsOneDayTrip.TabIndex = 1;
			this.fpsOneDayTrip.TabStop = false;
			this.fpsOneDayTrip.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
			this.fpsOneDayTrip.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsOneDayTrip_CellDoubleClick);
			this.fpsOneDayTrip.ComboCloseUp += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.fpsOneDayTrip_ComboCloseUp);
			this.fpsOneDayTrip.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fpsOneDayTrip_KeyUp);
			// 
			// ctmOneDay
			// 
			this.ctmOneDay.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mniAddOne,
																					  this.mniDeleteOne});
			// 
			// mniAddOne
			// 
			this.mniAddOne.Index = 0;
			this.mniAddOne.Text = "เพิ่ม";
			this.mniAddOne.Click += new System.EventHandler(this.mniAddOne_Click);
			// 
			// mniDeleteOne
			// 
			this.mniDeleteOne.Enabled = false;
			this.mniDeleteOne.Index = 1;
			this.mniDeleteOne.Text = "ลบ";
			this.mniDeleteOne.Click += new System.EventHandler(this.mniDeleteOne_Click);
			// 
			// fpsOneDayTrip_Sheet1
			// 
			this.fpsOneDayTrip_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsOneDayTrip_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsOneDayTrip_Sheet1.ColumnCount = 6;
			this.fpsOneDayTrip_Sheet1.RowCount = 0;
			this.fpsOneDayTrip_Sheet1.ColumnHeader.Cells.Get(0, 0).Text = "วันที่";
			this.fpsOneDayTrip_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "สถานที่";
			this.fpsOneDayTrip_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "ระยะทาง";
			this.fpsOneDayTrip_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "อัตรา";
			this.fpsOneDayTrip_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "จำนวนเที่ยว";
			this.fpsOneDayTrip_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "จำนวนเงิน";
			this.fpsOneDayTrip_Sheet1.ColumnHeader.Rows.Get(0).Height = 33F;
			dateTimeCellType12.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			dateTimeCellType12.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
			dateTimeCellType12.DateDefault = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
			dateTimeCellType12.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined;
			dateTimeCellType12.DropDownButton = false;
			dateTimeCellType12.TimeDefault = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
			dateTimeCellType12.UserDefinedFormat = "dd";
			this.fpsOneDayTrip_Sheet1.Columns.Get(0).CellType = dateTimeCellType12;
			this.fpsOneDayTrip_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsOneDayTrip_Sheet1.Columns.Get(0).Label = "วันที่";
			this.fpsOneDayTrip_Sheet1.Columns.Get(0).Resizable = false;
			this.fpsOneDayTrip_Sheet1.Columns.Get(0).Width = 70F;
			this.fpsOneDayTrip_Sheet1.Columns.Get(1).CellType = comboBoxCellType2;
			this.fpsOneDayTrip_Sheet1.Columns.Get(1).Label = "สถานที่";
			this.fpsOneDayTrip_Sheet1.Columns.Get(1).Resizable = false;
			this.fpsOneDayTrip_Sheet1.Columns.Get(1).Width = 300F;

            comboBoxCellType3.Items = new string[] {"ใกล้","ไกล"};

            comboBoxCellType3.Editable = false;

			this.fpsOneDayTrip_Sheet1.Columns.Get(2).CellType = comboBoxCellType3;
			this.fpsOneDayTrip_Sheet1.Columns.Get(2).Label = "ระยะทาง";
			this.fpsOneDayTrip_Sheet1.Columns.Get(2).Resizable = false;
			this.fpsOneDayTrip_Sheet1.Columns.Get(2).Width = 120F;
			this.fpsOneDayTrip_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.MistyRose;
            this.fpsOneDayTrip_Sheet1.Columns.Get(2).Locked = true;
			numberCellType7.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			numberCellType7.DecimalPlaces = 2;
			numberCellType7.DecimalSeparator = ".";
			numberCellType7.DropDownButton = false;
			numberCellType7.ReadOnly = true;
			numberCellType7.Separator = ",";
			numberCellType7.ShowSeparator = true;
			this.fpsOneDayTrip_Sheet1.Columns.Get(3).CellType = numberCellType7;
			this.fpsOneDayTrip_Sheet1.Columns.Get(3).Label = "อัตรา";
			this.fpsOneDayTrip_Sheet1.Columns.Get(3).Locked = true;
			this.fpsOneDayTrip_Sheet1.Columns.Get(3).Resizable = false;
			this.fpsOneDayTrip_Sheet1.Columns.Get(3).Width = 80F;
			numberCellType8.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			numberCellType8.DropDownButton = false;
			numberCellType8.FixedPoint = false;
			numberCellType8.LeadingZero = FarPoint.Win.Spread.CellType.LeadingZero.No;
			numberCellType8.MaximumValue = 50;
			numberCellType8.MinimumValue = 0;
			numberCellType8.Separator = ",";
			this.fpsOneDayTrip_Sheet1.Columns.Get(4).CellType = numberCellType8;
			this.fpsOneDayTrip_Sheet1.Columns.Get(4).Label = "จำนวนเที่ยว";
			this.fpsOneDayTrip_Sheet1.Columns.Get(4).Resizable = false;
			this.fpsOneDayTrip_Sheet1.Columns.Get(4).Width = 80F;
			this.fpsOneDayTrip_Sheet1.Columns.Get(5).BackColor = System.Drawing.Color.MistyRose;
			numberCellType9.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			numberCellType9.DecimalPlaces = 2;
			numberCellType9.DecimalSeparator = ".";
			numberCellType9.DropDownButton = false;
			numberCellType9.ReadOnly = true;
			numberCellType9.Separator = ",";
			numberCellType9.ShowSeparator = true;
			this.fpsOneDayTrip_Sheet1.Columns.Get(5).CellType = numberCellType9;
			this.fpsOneDayTrip_Sheet1.Columns.Get(5).Label = "จำนวนเงิน";
			this.fpsOneDayTrip_Sheet1.Columns.Get(5).Locked = true;
			this.fpsOneDayTrip_Sheet1.Columns.Get(5).Resizable = false;
			this.fpsOneDayTrip_Sheet1.Columns.Get(5).Width = 80F;
			this.fpsOneDayTrip_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsOneDayTrip_Sheet1.SheetName = "Sheet1";
			this.fpsOneDayTrip_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// frmEmployeeBenefit
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(976, 465);
			this.Controls.Add(this.tabBenefit);
			this.Controls.Add(this.dtpForMonth);
			this.Controls.Add(this.lblForMonth);
			this.Controls.Add(this.grbTotal);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Name = "frmEmployeeBenefit";
			this.Load += new System.EventHandler(this.frmEmployeeBenefit_Load);
			this.Controls.SetChildIndex(this.btnOK, 0);
			this.Controls.SetChildIndex(this.btnCancel, 0);
			this.Controls.SetChildIndex(this.grbTotal, 0);
			this.Controls.SetChildIndex(this.lblForMonth, 0);
			this.Controls.SetChildIndex(this.dtpForMonth, 0);
			this.Controls.SetChildIndex(this.tabBenefit, 0);
			this.grbTotal.ResumeLayout(false);
			this.tabBenefit.ResumeLayout(false);
			this.tabOT.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fpsOvertime)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsOvertime_Sheet1)).EndInit();
			this.tabOvernight.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fpsOvernightTrip)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsOvernightTrip_Sheet1)).EndInit();
			this.tabOneDayTrip.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fpsOneDayTrip)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsOneDayTrip_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region - Property -
			private bool isReadonly = true;
			private EmployeeBenefitFacade facadeEmployeeBenefit;
			private frmMain mdiParent;

			private EmployeeBenefit employeeBenefit
			{
				get{return facadeEmployeeBenefit.EmployeeBenefit;}
			}
		#endregion

		//==============================  Constructor  ==============================
		public frmEmployeeBenefit()
		{
			InitializeComponent();
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miAttendanceEmployeeBenefit");
            this.title = UserProfile.GetFormName("miAttendance", "miAttendanceEmployeeBenefit");


			YearMonth yearMonth = new YearMonth(DateTime.Today);
			dtpForMonth.Value = yearMonth.MinDateOfMonth;
		}
        public override string FormID()
        {
            return UserProfile.GetFormID("miAttendance", "miAttendanceEmployeeBenefit");
        }


		#region - Override -
		public override void InitForm()
		{
			base.InitForm();
			IsMustQuestion = false;

			mdiParent = (frmMain)this.MdiParent;
			facadeEmployeeAttendance = new EmployeeBenefitFacade();
			facadeEmployeeBenefit = (EmployeeBenefitFacade)facadeEmployeeAttendance;
			
			initLocation();

			MainMenuNewStatus = false;
			MainMenuRefreshStatus = false;
			mdiParent.EnableNewCommand(false);
			mdiParent.EnableRefreshCommand(false);

			addRowOverNight();
			addRowOneDayTrip();
		}

		public override void ExitForm()
		{
			base.ExitForm();
		}

		protected override void visibleForm(bool value)
		{
			base.visibleForm(value);
			lblForMonth.Visible = value;
			dtpForMonth.Visible = value;
			tabBenefit.Visible = value;
			grbTotal.Visible = value;
		}

		protected override void visibleButton(bool value)
		{
			btnOK.Visible = value;
			btnCancel.Visible = value;
		}
		#endregion

		//==============================  private methord   ==============================
		#region - private methord -
			private string getDateTimeString(DateTime value)
			{
				if(value == NullConstant.DATETIME)
				{
					return "";
				}
				else
				{
					return value.ToShortTimeString();
				}
			}

			private DateTime getDateTime(string value)
			{
				if(value.Trim()=="")
				{
					return NullConstant.DATETIME;
				}
				else
				{
					return DateTime.Parse(value);
				}
			}

			private DateTime getDateTime(string value, DateTime date)
			{
				if(value.Trim()=="")
				{
					return NullConstant.DATETIME;
				}
				else
				{
					DateTime temp = DateTime.Parse(value);
					return new DateTime(date.Year, date.Month, date.Day, temp.Hour, temp.Minute, temp.Second);
				}
			}

			private decimal getDecimal(string value)
			{
				if(value.Trim()=="")
				{
					return 0;
				}
				else
				{
					return Convert.ToDecimal(value);
				}
			}
		#endregion

		#region - init Combo -
			private void initLocation()
			{
				fpsOvernightTrip_Sheet1.Columns[4].CellType = facadeEmployeeBenefit.DataSourceTripLocation;
				fpsOneDayTrip_Sheet1.Columns[1].CellType = facadeEmployeeBenefit.DataSourceTripLocation;
			}
		#endregion

		#region - OT -
//			fpsOvertime_Sheet1
			#region - Move Presentation -
			private void moveOnfpsOvertime(int currentRow, int currentColumn)
			{
				fpsOvertime.Focus();
				switch(currentColumn)
				{
					case 0 :
					case 1 :
					case 2 :
					case 3 :
					case 4 :
					case 5 :
					case 6 :
					case 7 :
					{
						fpsOvertime_Sheet1.ActiveColumnIndex = 8;
						break;
					}
					case 8 :
					case 9 :
					case 10 :
					case 11 :
					case 12 :
					{
						fpsOvertime_Sheet1.ActiveColumnIndex = 1;
						if(fpsOvertime_Sheet1.RowCount>currentRow+1)
						{
							fpsOvertime_Sheet1.ActiveRowIndex = currentRow+1;
						}
						else
						{
							fpsOvertime_Sheet1.ActiveRowIndex = 0;
						}
						break;
					}
				}
			}
			#endregion

			#region - OT -
				private void setEnableOTrow(int index, int column, bool enable)
				{
					if(enable)
					{
						fpsOvertime_Sheet1.Cells[index, column].BackColor = System.Drawing.Color.White;
						fpsOvertime_Sheet1.Cells[index, column].Locked = false;	
					}
					else
					{
						fpsOvertime_Sheet1.Cells[index, column].BackColor = System.Drawing.Color.MistyRose;
						fpsOvertime_Sheet1.Cells[index, column].Locked = true;	
					}
				}

				private void enableOTrow(int index, bool enable)
				{
					setEnableOTrow(index, 1, enable);
					setEnableOTrow(index, 2, enable);
					setEnableOTrow(index, 5, enable);
					setEnableOTrow(index, 6, enable);
					setEnableOTrow(index, 7, enable);
					setEnableOTrow(index, 8, enable);
				}

				private void bindOT()
				{
					WorkInfo workInfo;
					BenefitOTHour overtimeHour;
					fpsOvertime_Sheet1.RowCount = employeeBenefit.WorkInfoList.Count;
					for(int i=0; i<employeeBenefit.WorkInfoList.Count; i++)
					{						
						workInfo = employeeBenefit.WorkInfoList[i];
						if(workInfo.DayType==WORKINGDAY_TYPE.HOLIDAY)
						{
							fpsOvertime_Sheet1.Cells[i, 0].Text = "Holiday";
						}
						else
						{
							fpsOvertime_Sheet1.Cells[i, 0].Text = workInfo.BenefitDate.Day.ToString();
						}

						fpsOvertime_Sheet1.Cells[i, 3].Text = getDateTimeString(workInfo.WorkingTime.From);
						fpsOvertime_Sheet1.Cells[i, 4].Text = getDateTimeString(workInfo.WorkingTime.To);

						fpsOvertime_Sheet1.Cells[i,14].Text = workInfo.AssignServiceStaffType.ADescription.English;
						fpsOvertime_Sheet1.Cells[i,15].Text = workInfo.AssignCustomer.ShortName;
						if(workInfo.AssignCustomerDepartment != null &&  workInfo.AssignCustomerDepartment.ShortName.Trim() != "")
						{
							fpsOvertime_Sheet1.Cells[i,15].Text += "(" + workInfo.AssignCustomerDepartment.ShortName + ")";
						}
							
						if(employeeBenefit.BenefitOTHourList.Contain(workInfo.BenefitDate))
						{
							overtimeHour = employeeBenefit.BenefitOTHourList[workInfo.BenefitDate];
							fpsOvertime_Sheet1.Cells[i, 1].Text = getDateTimeString(overtimeHour.BeforeTime.From);
//							if(overtimeHour.BeforeTime.To!=workInfo.WorkingTime.From)
							if(overtimeHour.BeforeTime.To==NullConstant.TIME)
							{
								fpsOvertime_Sheet1.Cells[i, 2].Text = "";
							}
							else
							{
								fpsOvertime_Sheet1.Cells[i, 2].Text = getDateTimeString(overtimeHour.BeforeTime.To);
							}

							fpsOvertime_Sheet1.Cells[i, 5].Text = getDateTimeString(overtimeHour.BreakTime.From);
							fpsOvertime_Sheet1.Cells[i, 6].Text = getDateTimeString(overtimeHour.BreakTime.To);

//							if(overtimeHour.AfterTime.From!=workInfo.WorkingTime.To)
							if(overtimeHour.AfterTime.From==NullConstant.TIME)
							{
								fpsOvertime_Sheet1.Cells[i, 7].Text = "";
							}
							else
							{
								fpsOvertime_Sheet1.Cells[i, 7].Text = getDateTimeString(overtimeHour.AfterTime.From);
							}
							fpsOvertime_Sheet1.Cells[i, 8].Text = getDateTimeString(overtimeHour.AfterTime.To);

							if(overtimeHour.OTRate.OtAHour==0m || overtimeHour.OTRate.OtAHour==NullConstant.DECIMAL)
							{
								fpsOvertime_Sheet1.Cells[i, 9].Text = "";
							}
							else
							{
								fpsOvertime_Sheet1.Cells[i, 9].Text = overtimeHour.OTRate.OtAHour.ToString();
							}
							if(overtimeHour.OTRate.OtBHour==0m || overtimeHour.OTRate.OtBHour==NullConstant.DECIMAL)
							{
								fpsOvertime_Sheet1.Cells[i,10].Text = "";
							}
							else
							{
								fpsOvertime_Sheet1.Cells[i,10].Text = overtimeHour.OTRate.OtBHour.ToString();
							}
							if(overtimeHour.OTRate.OtCHour==0m || overtimeHour.OTRate.OtCHour==NullConstant.DECIMAL)
							{
								fpsOvertime_Sheet1.Cells[i,11].Text = "";
							}
							else
							{
								fpsOvertime_Sheet1.Cells[i,11].Text = overtimeHour.OTRate.OtCHour.ToString();
							}
						}
						else
						{
							fpsOvertime_Sheet1.Cells[i, 1].Text = "";
							fpsOvertime_Sheet1.Cells[i, 2].Text = "";

							fpsOvertime_Sheet1.Cells[i, 5].Text = "";
							fpsOvertime_Sheet1.Cells[i, 6].Text = "";

							fpsOvertime_Sheet1.Cells[i, 7].Text = "";
							fpsOvertime_Sheet1.Cells[i, 8].Text = "";

							fpsOvertime_Sheet1.Cells[i, 9].Text = "";
							fpsOvertime_Sheet1.Cells[i,10].Text = "";
							fpsOvertime_Sheet1.Cells[i,11].Text = "";
						}

						if(employeeBenefit.BenefitTaxiList.Contain(workInfo.BenefitDate))
						{
							fpsOvertime_Sheet1.Cells[i,12].Text = employeeBenefit.BenefitTaxiList[workInfo.BenefitDate].Times.ToString();
						}
						else
						{
							fpsOvertime_Sheet1.Cells[i,12].Text = "";
						}

						if(employeeBenefit.BenefitFoodList.Contain(workInfo.BenefitDate))
						{
							fpsOvertime_Sheet1.Cells[i,13].Text = employeeBenefit.BenefitFoodList[workInfo.BenefitDate].Times.ToString();
						}
						else
						{
							fpsOvertime_Sheet1.Cells[i,13].Text = "";
						}

						enableOTrow(i, workInfo.ValidOTStatus);
						if(!workInfo.ValidOTStatus)
						{
							fpsOvertime_Sheet1.Cells[i,14].Text = workInfo.Remark;
						}
					}
					workInfo = null;
					overtimeHour = null;				
				}

				private void displayTotalOT()
				{
					if(employeeBenefit.BenefitOTHourList.TotalOTRate.OtAHour != NullConstant.DECIMAL)
					{
						lblRateA.Text = employeeBenefit.BenefitOTHourList.TotalOTRate.OtAHour.ToString("N");
					}
					else
					{
						lblRateA.Text = "";
					}

					if(employeeBenefit.BenefitOTHourList.TotalOTRate.OtBHour != NullConstant.DECIMAL)
					{
						lblRateB.Text = employeeBenefit.BenefitOTHourList.TotalOTRate.OtBHour.ToString("N");
					}
					else
					{
						lblRateB.Text = "";
					}

					if(employeeBenefit.BenefitOTHourList.TotalOTRate.OtCHour != NullConstant.DECIMAL)
					{
						lblRateC.Text = employeeBenefit.BenefitOTHourList.TotalOTRate.OtCHour.ToString("N");
					}
					else
					{
						lblRateC.Text = "";
					}
				}

				private void displayTotalFood()
				{
					lblFood.Text = employeeBenefit.BenefitFoodList.TotalTimes.ToString();
					lblFoodAmount.Text = employeeBenefit.BenefitFoodList.TotalAmount.ToString("N");
				}

				private void displayTotalTaxi()
				{
					lblTaxiTimes.Text =  employeeBenefit.BenefitTaxiList.TotalTimes.ToString();
					lblTaxiCharge.Text = employeeBenefit.BenefitTaxiList.TotalAmount.ToString("N");
				}

				private void displayTotalOneDay()
				{
					lblOneDayTimes.Text = employeeBenefit.OneDayTripBenefit.TotalTimes.ToString();
					lblOneDayAmount.Text = employeeBenefit.OneDayTripBenefit.TotalAmount.ToString("N");
				}

				private void displayTotalOverNight()
				{
					lblTotalDays.Text = employeeBenefit.OvernightTripBenefit.CurrentMonth.TotalTimes.ToString();
					lblTotalAmount.Text = employeeBenefit.OvernightTripBenefit.CurrentMonth.TotalAmount.ToString("N");
				}

				private bool hasOT(int row)
				{
					if(fpsOvertime_Sheet1.Cells[row, 1].Text!="")
					{
						return true;
					}

					if(fpsOvertime_Sheet1.Cells[row, 2].Text!="")
					{
						return true;
					}

					if(fpsOvertime_Sheet1.Cells[row, 5].Text!="")
					{
						return true;
					}

					if(fpsOvertime_Sheet1.Cells[row, 6].Text!="")
					{
						return true;
					}

					if(fpsOvertime_Sheet1.Cells[row, 7].Text!="")
					{
						return true;
					}

					if(fpsOvertime_Sheet1.Cells[row, 8].Text!="")
					{
						return true;
					}
						
					return false;
				}

				private void fillOTHour(BenefitOTHour overtimeHour, int i)
				{
					overtimeHour.BeforeTime.From = getDateTime(fpsOvertime_Sheet1.Cells[i, 1].Text, overtimeHour.BenefitDate);
					overtimeHour.BeforeTime.To = getDateTime(fpsOvertime_Sheet1.Cells[i, 2].Text, overtimeHour.BenefitDate);

					overtimeHour.BreakTime.From = getDateTime(fpsOvertime_Sheet1.Cells[i, 5].Text, overtimeHour.BenefitDate);
					overtimeHour.BreakTime.To = getDateTime(fpsOvertime_Sheet1.Cells[i, 6].Text, overtimeHour.BenefitDate);

					overtimeHour.AfterTime.From = getDateTime(fpsOvertime_Sheet1.Cells[i, 7].Text, overtimeHour.BenefitDate);
					overtimeHour.AfterTime.To = getDateTime(fpsOvertime_Sheet1.Cells[i, 8].Text, overtimeHour.BenefitDate);

					if(fpsOvertime_Sheet1.Cells[i, 1].Text!="" && fpsOvertime_Sheet1.Cells[i, 8].Text!="")
					{
						if(overtimeHour.BeforeTime.From > overtimeHour.AfterTime.To)
						{
							overtimeHour.AfterTime.To = overtimeHour.AfterTime.To.AddDays(1);
						}
					}

					overtimeHour.OTRate.OtAHour = getDecimal(fpsOvertime_Sheet1.Cells[i, 9].Text);
					overtimeHour.OTRate.OtBHour = getDecimal(fpsOvertime_Sheet1.Cells[i,10].Text);
					overtimeHour.OTRate.OtCHour = getDecimal(fpsOvertime_Sheet1.Cells[i,11].Text);
				
				}

				private void fillOTHour()
				{
					DateTime date;
					BenefitOTHour overtimeHour;
					BenefitOTHourList temp = new BenefitOTHourList(employeeBenefit.BenefitOTHourList.Employee, employeeBenefit.BenefitOTHourList.ForMonth);
					for(int i=0; i<employeeBenefit.BenefitOTHourList.Count; i++)
					{
						temp.Add(employeeBenefit.BenefitOTHourList[i]);
					}
					employeeBenefit.BenefitOTHourList.Clear();
					for(int i=0; i<fpsOvertime_Sheet1.RowCount; i++)
					{
						date = new DateTime(facadeEmployeeBenefit.EmployeeBenefit.ForMonth.Year, facadeEmployeeBenefit.EmployeeBenefit.ForMonth.Month, i+1);
						if(temp.Contain(date))
						{
							overtimeHour = temp[date];
						}
						else
						{
							overtimeHour = new BenefitOTHour(employeeBenefit.WorkInfoList[i].BenefitDate);
						}
						fillOTHour(overtimeHour, i);
						employeeBenefit.BenefitOTHourList.Add(overtimeHour);
					}
					overtimeHour = null;
					temp = null;
				}
			#endregion
		#endregion

		#region - Over Night -
			#region - Move Presentation -
			private void addRowOverNight()
			{
				int row = fpsOvernightTrip_Sheet1.RowCount++;

				YearMonth yearMonth = new YearMonth(dtpForMonth.Value);

				DateTimeCellType dateTimeCellTypeForm = (DateTimeCellType)fpsOvernightTrip_Sheet1.Columns.Get(0).CellType;
				dateTimeCellTypeForm.DateDefault = yearMonth.MinDateOfMonth;
				
				DateTimeCellType dateTimeCellTypeTo = (DateTimeCellType)fpsOvernightTrip_Sheet1.Columns.Get(1).CellType;
				dateTimeCellTypeTo.DateDefault = yearMonth.MinDateOfMonth;

				DateTimeCellType dateTimeCellTypePay = (DateTimeCellType)fpsOvernightTrip_Sheet1.Columns.Get(8).CellType;
				dateTimeCellTypePay.DateDefault = yearMonth.MinDateOfMonth;
				
				dateTimeCellTypeForm = null;
				dateTimeCellTypeTo = null;
				dateTimeCellTypePay = null;
				
				mniDelete.Enabled = true;
			}

			private void moveOnfpsOvernightTrip(int currentRow, int currentColumn)
			{
				fpsOvernightTrip.Focus();
				switch(currentColumn)
				{
					case 0 :
					{
						fpsOvernightTrip_Sheet1.ActiveColumnIndex = 1;
						break;
					}
					case 1 :
					case 2 :
					case 3 :
					{
						fpsOvernightTrip_Sheet1.ActiveColumnIndex = 4;
						break;
					}
					case 4 :
					case 5 :
					case 6 :
					{
						fpsOvernightTrip_Sheet1.ActiveColumnIndex = 7;
						break;
					}
					case 7 :
					{
						fpsOvernightTrip_Sheet1.ActiveColumnIndex = 8;
						break;
					}
					case 8 :
					{
						fpsOvernightTrip_Sheet1.ActiveColumnIndex = 0;
						if(fpsOvernightTrip_Sheet1.RowCount>currentRow+1)
						{
							fpsOvernightTrip_Sheet1.ActiveRowIndex = currentRow+1;
						}
						else
						{
							fpsOvernightTrip_Sheet1.ActiveRowIndex = 0;
						}
						break;
					}
				}
			}
			#endregion

			#region - Fill -	
			private void fillOvernightTrip()
			{
				BenefitOvernightTrip overnightTrip;
				BenefitOvernightTripList overnightTripList = facadeEmployeeBenefit.EmployeeBenefit.OvernightTripBenefit.CurrentMonth;
				overnightTripList.Clear();

				for(int i=0; i<fpsOvernightTrip_Sheet1.RowCount; i++)
				{
					if(fpsOvernightTrip_Sheet1.Cells[i, 0].Text.Trim()!="" && fpsOvernightTrip_Sheet1.Cells[i, 1].Text.Trim() != "")
					{
						overnightTrip = new BenefitOvernightTrip();
						overnightTrip.From = getDateTime(fpsOvernightTrip_Sheet1.Cells[i, 0].Text);
						overnightTrip.To = getDateTime(fpsOvernightTrip_Sheet1.Cells[i, 1].Text);
						overnightTrip.Location.Name = fpsOvernightTrip_Sheet1.Cells[i, 4].Text;
						
						overnightTrip.AdvancePaymentStatus = Convert.ToBoolean(fpsOvernightTrip_Sheet1.Cells[i, 7].Value);
						if(overnightTrip.AdvancePaymentStatus)
						{
							overnightTrip.BenefitPayment.PaymentStatus = PAYMENT_STATUS_TYPE.YES;
							overnightTrip.BenefitPayment.PaymentDate = getDateTime(fpsOvernightTrip_Sheet1.Cells[i, 8].Text);
						}
						else
						{
							overnightTrip.Amount = employeeBenefit.OtherBenefitRate.OvernightTripRate;
							overnightTrip.BenefitPayment.PaymentStatus = PAYMENT_STATUS_TYPE.NO; 
						}
						overnightTrip.Customer = new Customer(fpsOvernightTrip_Sheet1.Cells[i, 9].Text);
						overnightTrip.CustomerDepartment = new CustomerDepartment(fpsOvernightTrip_Sheet1.Cells[i, 10].Text, overnightTrip.Customer);
						overnightTripList.Add(overnightTrip);					
					}
				}

				overnightTripList = null;
				overnightTrip = null;
			}

			private void bindOverNight(int row, BenefitOvernightTrip value)
			{
				fpsOvernightTrip_Sheet1.Cells[row, 0].Value = value.From;
				fpsOvernightTrip_Sheet1.Cells[row, 1].Value = value.To;
				fpsOvernightTrip_Sheet1.Cells[row, 2].Text = value.Customer.ShortName;
				fpsOvernightTrip_Sheet1.Cells[row, 3].Text = value.CustomerDepartment.ShortName;
				fpsOvernightTrip_Sheet1.Cells[row, 9].Text = value.Customer.Code;
				fpsOvernightTrip_Sheet1.Cells[row, 10].Text = value.CustomerDepartment.Code;
				fpsOvernightTrip_Sheet1.Cells[row, 4].Text = value.Location.Name;
				fpsOvernightTrip_Sheet1.Cells[row, 5].Text = value.Times.ToString();
				if(value.TotalAmount<=0)
				{
					fpsOvernightTrip_Sheet1.Cells[row, 6].Text = "";
				}
				else
				{
					fpsOvernightTrip_Sheet1.Cells[row, 6].Text = GUIFunction.GetString(value.TotalAmount);
				}
				fpsOvernightTrip_Sheet1.Cells[row, 7].Value = value.AdvancePaymentStatus;
				if(value.BenefitPayment.PaymentDate == NullConstant.DATETIME)
				{
					fpsOvernightTrip_Sheet1.Cells[row, 8].Text = "";
				}
				else
				{
					fpsOvernightTrip_Sheet1.Cells[row, 8].Value = value.BenefitPayment.PaymentDate;
				}
			}

			private void bindOverNight()
			{
				int startRow = 0;
				BenefitOvernightTripList overnightTripList = facadeEmployeeBenefit.EmployeeBenefit.OvernightTripBenefit.CurrentMonth;
				fpsOvernightTrip_Sheet1.RowCount = overnightTripList.Count;
				for(int i=startRow; i<overnightTripList.Count + startRow; i++)
				{
					bindOverNight(i, overnightTripList[i]);
				}
				overnightTripList = null;
				if(fpsOvernightTrip_Sheet1.RowCount==0)
				{
					mniDelete.Enabled = false;
				}
				else
				{
					mniDelete.Enabled = true;
				}
			}
			#endregion

			#region - Validate -
				private bool validOverLap(BenefitOvernightTrip value, int row, BenefitOvernightTripList overnightTripList)
				{
					BenefitOvernightTrip overnightTrip;
					for(int i=0; i<overnightTripList.Count; i++)
					{
						overnightTrip = overnightTripList[i];
						if(overnightTrip != value)
						{
							if(value.From<=overnightTrip.From && value.To<=overnightTrip.From)
							{
								continue;
							}

							if(value.From>=overnightTrip.To && value.To>=overnightTrip.To)
							{
								continue;
							}

							Message(MessageList.Error.E0013, "คำนวณค่าค้างคืน", "มีช่วงเวลาค้างคืน บางช่วงซ้ำซ้อนกัน");
							fpsOvernightTrip.Focus();
							fpsOvernightTrip_Sheet1.ActiveRowIndex = row;
							fpsOvernightTrip_Sheet1.ActiveColumnIndex = 1;
							overnightTrip = null;
							return false;
						}
						overnightTrip = null;
					}
					
					return true;
				}

				private bool validOverNight(BenefitOvernightTrip value, int row)
				{
					if(value.From.Month != employeeBenefit.ForMonth.Month && value.To.Month != employeeBenefit.ForMonth.Month)
					{
						Message(MessageList.Error.E0013, "คำนวณค่าค้างคืน", "เดือนที่ใส่ไม่ถูกต้อง");
						fpsOvernightTrip.Focus();
						fpsOvernightTrip_Sheet1.ActiveRowIndex = row;
						fpsOvernightTrip_Sheet1.ActiveColumnIndex = 1;
						return false;
					}

					if(value.From >= value.To)
					{
						Message(MessageList.Error.E0025, "วันที่จนถึง", "วันที่ตั้งแต่");
						fpsOvernightTrip.Focus();
						fpsOvernightTrip_Sheet1.ActiveRowIndex = row;
						fpsOvernightTrip_Sheet1.ActiveColumnIndex = 1;
						return false;
					}

					if(validOverLap(value, row, employeeBenefit.OvernightTripBenefit.CurrentMonth))
					{
						if(value.From.Month != employeeBenefit.ForMonth.Month)
						{
							if(!validOverLap(value, row, employeeBenefit.OvernightTripBenefit.PreviousMonth))
							{
								return false;
							}	
						}
						if(value.To.Month != employeeBenefit.ForMonth.Month)
						{
							if(!validOverLap(value, row, employeeBenefit.OvernightTripBenefit.NextMonth))
							{
								return false;
							}	
						}
					}
					else
					{
						return false;
					}

					if(value.BenefitPayment.PaymentStatus==PAYMENT_STATUS_TYPE.YES &&  value.BenefitPayment.PaymentDate==NullConstant.DATETIME)
					{
						Message(MessageList.Error.E0002, "วันที่จ่ายล่วงหน้า");
						fpsOvernightTrip.Focus();
						fpsOvernightTrip_Sheet1.ActiveRowIndex = row;
						fpsOvernightTrip_Sheet1.ActiveColumnIndex = 8;
						return false;
					}

					return true;
				}

				private bool validOverNight()
				{
					BenefitOvernightTripList overnightTripList = employeeBenefit.OvernightTripBenefit.CurrentMonth;
					for(int i=0; i<overnightTripList.Count; i++)
					{
						if(!validOverNight(overnightTripList[i], i))
						{
							overnightTripList = null;
							return false;
						}
					}
					overnightTripList = null;
					return true;
				}
			#endregion
		#endregion

		#region - One Day -
			#region - Move Presentation -
				private void addRowOneDayTrip()
				{
					fpsOneDayTrip_Sheet1.RowCount++;

					YearMonth yearMonth = new YearMonth(dtpForMonth.Value);

					DateTimeCellType dateTimeCellType = (DateTimeCellType)fpsOneDayTrip_Sheet1.Columns.Get(0).CellType;
					dateTimeCellType.DateDefault = yearMonth.MinDateOfMonth;
					dateTimeCellType = null;

					fpsOneDayTrip_Sheet1.Cells[fpsOneDayTrip_Sheet1.RowCount-1, 2].Text = "ไกล";
					fpsOneDayTrip_Sheet1.Cells[fpsOneDayTrip_Sheet1.RowCount-1, 4].Text = "1";
					mniDeleteOne.Enabled = true;
				}

				private void moveOnfpsOneDayTrip(int currentRow, int currentColumn)
				{
					fpsOneDayTrip.Focus();
					switch(currentColumn)
					{
						case 0 :
						{
							if(fpsOneDayTrip_Sheet1.RowCount>currentRow+1)
							{
								fpsOneDayTrip_Sheet1.ActiveRowIndex = currentRow+1;
							}
							else
							{
								fpsOneDayTrip_Sheet1.ActiveRowIndex = 0;
							}
							break;
						}
						case 1 :
						case 2 :
						case 3 :
						{
							fpsOneDayTrip_Sheet1.ActiveColumnIndex = 4;
							break;
						}
						case 4 :
						case 5 :
						{
							fpsOneDayTrip_Sheet1.ActiveColumnIndex = 0;
							if(fpsOneDayTrip_Sheet1.RowCount>currentRow+1)
							{
								fpsOneDayTrip_Sheet1.ActiveRowIndex = currentRow+1;
							}
							else
							{
								fpsOneDayTrip_Sheet1.ActiveRowIndex = 0;
							}
							break;
						}
					}
				}
			#endregion

			#region - Validate -
				private bool validOneDay(OneDayTripBenefit value, int row)
				{
					if(value.BenefitDate == NullConstant.DATETIME)
					{
						Message(MessageList.Error.E0002, "วันที่เดินทาง");
						fpsOneDayTrip.Focus();
						fpsOneDayTrip_Sheet1.ActiveRowIndex = row;
						fpsOneDayTrip_Sheet1.ActiveColumnIndex = 0;
						return false;
					}

					if(value.Times<=0)
					{
						Message(MessageList.Error.E0018, "จำนวนเที่ยว", "1");
						fpsOneDayTrip.Focus();
						fpsOneDayTrip_Sheet1.ActiveRowIndex = row;
						fpsOneDayTrip_Sheet1.ActiveColumnIndex = 4;
						return false;
					}

					EmployeeOneDayTripBenefit oneDayTripList = employeeBenefit.OneDayTripBenefit;
					for(int i=0; i<oneDayTripList.Count; i++)
					{
						if(value != oneDayTripList[i])
						{
							if(value.BenefitDate == oneDayTripList[i].BenefitDate)
							{
								Message(MessageList.Error.E0013, "คำนวณค่าเดินทางไปกลับ", "มีบางวันซ้ำซ้อนกัน");
								fpsOneDayTrip.Focus();
								fpsOneDayTrip_Sheet1.ActiveRowIndex = row;
								fpsOneDayTrip_Sheet1.ActiveColumnIndex = 0;
								oneDayTripList = null;
								return false;
							}
						}
					}

					BenefitOvernightTripList overnightTripList = employeeBenefit.OvernightTripBenefit.CurrentMonth;
					for(int i=0; i<overnightTripList.Count; i++)
					{
						if(overnightTripList[i].From<value.BenefitDate && value.BenefitDate<overnightTripList[i].To)
						{
							Message(MessageList.Error.E0013, "คำนวณค่าเดินทางไปกลับ", "มีบางวันอยู่ภายในช่วงเวลาค้างคืน");
							fpsOneDayTrip.Focus();
							fpsOneDayTrip_Sheet1.ActiveRowIndex = row;
							fpsOneDayTrip_Sheet1.ActiveColumnIndex = 0;
							overnightTripList = null;
							return false;
						}
					}

					oneDayTripList = null;
					overnightTripList = null;

					return true;
				}

                private bool validOneDay(OneDayTripBenefit value, ictus.PIS.PI.Entity.Employee employee, int row)
                {
                    TimeCard timeCard = facadeEmployeeBenefit.GetEmployeeTimeCard(employee, value.BenefitDate);
                    if (timeCard != null)
                    {
                        string[] attStatus = new string[] { "A1", "P1", "S1", "S2" };

                        foreach (string status in attStatus)
                        {
                            if (timeCard.AAfterBreakStatus.Code == status || timeCard.ABeforeBreakStatus.Code == status)
                            {
                                Message(MessageList.Error.E0013, "คำนวณค่าเดินทางไปกลับ", "มีบางวันอยู่ภายในช่วงเวลาการลา");
                                fpsOneDayTrip.Focus();
                                fpsOneDayTrip_Sheet1.ActiveRowIndex = row;
                                fpsOneDayTrip_Sheet1.ActiveColumnIndex = 0;
                                return false;
                            }
                        }                        
                    }
                    timeCard = null;
                    return true;
                }

				private bool validOneDay()
				{
					EmployeeOneDayTripBenefit oneDayTripList = employeeBenefit.OneDayTripBenefit;
					for(int i=0; i<oneDayTripList.Count; i++)
					{
						if(!validOneDay(oneDayTripList[i], i))
						{
							oneDayTripList = null;
							return false;
						}

                        if (!validOneDay(oneDayTripList[i], oneDayTripList.Employee, i))
                        {
                            oneDayTripList = null;
                            return false;
                        }
					}
					oneDayTripList = null;
					return true;
				}
			#endregion

			#region - Fill -
			private void fillOneDayTrip()
			{
				OneDayTripBenefit oneDayTripBenefit;
				EmployeeOneDayTripBenefit employeeOneDayTripBenefit = facadeEmployeeBenefit.EmployeeBenefit.OneDayTripBenefit;
				employeeOneDayTripBenefit.Clear();
				for(int i=0; i<fpsOneDayTrip_Sheet1.RowCount; i++)
				{
					YearMonth yearMonth = new YearMonth(dtpForMonth.Value);
					
					int day;
					DateTime tripDate;

					if(fpsOneDayTrip_Sheet1.Cells[i, 0].Text.Trim() == "")
					{
						continue;
//						tripDate = NullConstant.DATETIME;
					}
					else
					{
						day = Convert.ToInt32(fpsOneDayTrip_Sheet1.Cells[i, 0].Text);
						if(day>yearMonth.MaxDateOfMonth.Day)
						{
							tripDate = NullConstant.DATETIME;
						}
						else
						{
							tripDate = yearMonth.GetDate(day);
						}
					}

					oneDayTripBenefit = new OneDayTripBenefit();
					oneDayTripBenefit.BenefitDate = tripDate;
					oneDayTripBenefit.AOneDayTrip.APeriod.From = tripDate;
					oneDayTripBenefit.AOneDayTrip.APeriod.To = tripDate;
					oneDayTripBenefit.AOneDayTrip.ATripLocation.Name = fpsOneDayTrip_Sheet1.Cells[i, 1].Text;
					if(oneDayTripBenefit.ABenefitPayment.PaymentStatus == PAYMENT_STATUS_TYPE.NULL)
					{
						oneDayTripBenefit.ABenefitPayment.PaymentStatus = PAYMENT_STATUS_TYPE.NO;
						oneDayTripBenefit.ABenefitPayment.PaymentDate = NullConstant.DATETIME;					
					}
					switch(fpsOneDayTrip_Sheet1.Cells[i, 2].Text)
					{
						case "ใกล้" :
						{
							oneDayTripBenefit.Distance = DISTANCE_TYPE.NEAR;
							break;
						}
						case "ไกล" :
						{
							oneDayTripBenefit.Distance = DISTANCE_TYPE.FAR;
							break;
						}
					}
					oneDayTripBenefit.BenefitAmount = getDecimal(fpsOneDayTrip_Sheet1.Cells[i, 3].Text);
					if(fpsOneDayTrip_Sheet1.Cells[i, 4].Text.Trim()=="")
					{
						oneDayTripBenefit.Times = 0;
					}
					else
					{
						oneDayTripBenefit.Times = Convert.ToByte(fpsOneDayTrip_Sheet1.Cells[i, 4].Text);
					}
					oneDayTripBenefit.TotalAmount = getDecimal(fpsOneDayTrip_Sheet1.Cells[i, 5].Text);;
					employeeOneDayTripBenefit.Add(oneDayTripBenefit);
				}
				employeeOneDayTripBenefit = null;
				oneDayTripBenefit = null;
			}

			private void bindOneDayTrip(OneDayTripBenefit value, int row)
			{
				fpsOneDayTrip_Sheet1.Cells[row, 0].Value = value.BenefitDate;
				fpsOneDayTrip_Sheet1.Cells[row, 1].Text = value.AOneDayTrip.ATripLocation.Name;
				switch(value.Distance)
				{
					case DISTANCE_TYPE.FAR :
					{
						fpsOneDayTrip_Sheet1.Cells[row, 2].Text = "ไกล";
						break;
					}
					case DISTANCE_TYPE.NEAR :
					{
						fpsOneDayTrip_Sheet1.Cells[row, 2].Text = "ใกล้";
						break;
					}
				}
				if(value.BenefitAmount<=0)
				{
					fpsOneDayTrip_Sheet1.Cells[row, 3].Text = "";
				}
				else
				{
					fpsOneDayTrip_Sheet1.Cells[row, 3].Text = value.BenefitAmount.ToString();
				}

				if(value.Times<=0)
				{
					fpsOneDayTrip_Sheet1.Cells[row, 4].Text = "";
				}
				else
				{
					fpsOneDayTrip_Sheet1.Cells[row, 4].Text = value.Times.ToString();
				}
				
				if(value.TotalAmount<=0)
				{
					fpsOneDayTrip_Sheet1.Cells[row, 5].Text = "";
				}
				else
				{
					fpsOneDayTrip_Sheet1.Cells[row, 5].Text = value.TotalAmount.ToString();
				}
			}

			private void bindOneDayTrip(EmployeeOneDayTripBenefit value)
			{
				fpsOneDayTrip_Sheet1.RowCount = value.Count;
				for(int i=0; i<value.Count; i++)
				{
					bindOneDayTrip(value[i], i);
				}
				if(value.Count>0)
				{
					mniDeleteOne.Enabled = true;
				}
				else
				{
					mniDeleteOne.Enabled = false;
				}					
			}
			#endregion
		#endregion

		#region - Benefit -
			private void display()
			{
				bindOT();
				bindOneDayTrip(facadeEmployeeBenefit.EmployeeBenefit.OneDayTripBenefit);
				bindOverNight();
				displayTotalOT();
				displayTotalFood();
				displayTotalTaxi();
				displayTotalOneDay();
				displayTotalOverNight();
			}

			private void fillBenefit()
			{
				fillOTHour();
				fillOneDayTrip();
				fillOvernightTrip();
			}

			private bool valid()
			{
				bool result = true;
				result = result && validOverNight();
				result = result && validOneDay();
				return result;
			}

			private bool validUpdate()
			{
				BenefitOvernightTrip benefitOvernightTrip;
				for(int i=0; i<fpsOvernightTrip_Sheet1.RowCount; i++)
				{
//					if(fpsOvernightTrip_Sheet1.Cells[i, 2].Text.Trim()=="")
//					{
//						Message(MessageList.Error.E0017);
//						btnCalOT.Focus();
//						return false;
//					}

					benefitOvernightTrip = new BenefitOvernightTrip();
					benefitOvernightTrip.From = getDateTime(fpsOvernightTrip_Sheet1.Cells[i, 0].Text);
					benefitOvernightTrip.To = getDateTime(fpsOvernightTrip_Sheet1.Cells[i, 1].Text);
					if(facadeEmployeeBenefit.FillCustomer(benefitOvernightTrip))
					{
//						if(benefitOvernightTrip.Customer.Code != fpsOvernightTrip_Sheet1.Cells[i, 9].Text || benefitOvernightTrip.CustomerDepartment.Code != fpsOvernightTrip_Sheet1.Cells[i,10].Text)
//						{
//							Message(MessageList.Error.E0017);
//							return false;						
//						}
					}
					else
					{
						Message(MessageList.Error.E0004, "ข้อมูลลูกค้า");
						return false;
					}
				}
				return true;
			}
			
			private void enableCommand(bool enable)
			{
				btnOK.Enabled = enable;
				btnCalOT.Enabled = enable;
				btnReLoad.Enabled = enable;

				mdiParent.EnablePrintCommand(enable);
			}
		#endregion

		//==============================  Base Event   ==============================
		public override void RefreshForm()
		{
			try
			{
				if(facadeEmployeeBenefit != null)
				{
					base.RefreshForm();
					if(facadeEmployeeBenefit.ExistingEmployee)
					{
						if(facadeEmployeeBenefit.FillEmployeeBenefit(dtpForMonth.Value))
						{
							enableCommand(true);
						}
						else
						{
							enableCommand(false);
						}
						display();
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
			finally
			{
				if(isReadonly)
				{
					btnOK.Enabled = false;
				}
			}
		}

		public void CalculateOTAll()
		{
			try
			{
				fillBenefit();
				if(valid())
				{
					facadeEmployeeBenefit.CalculateBenefit();
					display();				
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
			finally
			{}
		}

		private void updateEvent()
		{
			try
			{
				fillBenefit();
				if(valid() && validUpdate() && facadeEmployeeBenefit.UpdateEmployeeBenefit())
				{
					Message(MessageList.Information.I0001);
//					display();
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
			finally
			{
			}
		}

		private void otEnter()
		{
			int row = fpsOvertime_Sheet1.ActiveRowIndex;
			try
			{
				if(fpsOvertime_Sheet1.ActiveColumnIndex == 8)
				{
					fillBenefit();
					facadeEmployeeBenefit.CalculateBenefit(fpsOvertime_Sheet1.ActiveRowIndex);
					display();
				}

				moveOnfpsOvertime(fpsOvertime_Sheet1.ActiveRowIndex, fpsOvertime_Sheet1.ActiveColumnIndex);
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
			finally
			{
			}
		}

		private void overnightEnter()
		{
			int row = fpsOvernightTrip_Sheet1.ActiveRowIndex;
			try
			{			
				if(fpsOvernightTrip_Sheet1.ActiveColumnIndex == 1)
				{
					fillBenefit();
					facadeEmployeeBenefit.CalculateBenefit();
					display();
					addRowOverNight();
					moveOnfpsOvernightTrip(row, fpsOvernightTrip_Sheet1.ActiveColumnIndex);
				}
				else
				{
					if(fpsOvernightTrip_Sheet1.RowCount==0)
					{
						addRowOverNight();
						fpsOvernightTrip_Sheet1.ActiveRowIndex = 0;
						fpsOvernightTrip_Sheet1.ActiveColumnIndex = 0;
					}
					else
					{
						moveOnfpsOvernightTrip(row, fpsOvernightTrip_Sheet1.ActiveColumnIndex);
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
			finally
			{
			}
		}

		private void oneDayTripEnter()
		{
			int rowFocus = -1;
			try
			{
				fillBenefit();
				facadeEmployeeBenefit.CalculateBenefit();
				display();
				
				for(int i=0; i<fpsOneDayTrip_Sheet1.RowCount; i++)
				{
					if(fpsOneDayTrip_Sheet1.Cells[i, 0].Text.Trim() == "")
					{
						rowFocus = i;
						break;
					}
				}

				fpsOneDayTrip.Focus();
				if(rowFocus<0)
				{
					addRowOneDayTrip();
					fpsOneDayTrip_Sheet1.ActiveRowIndex = fpsOneDayTrip_Sheet1.RowCount-1;
				}
				else
				{
					fpsOneDayTrip_Sheet1.ActiveRowIndex = rowFocus;
				}
//				moveOnfpsOneDayTrip(row, fpsOneDayTrip_Sheet1.ActiveColumnIndex);
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
			finally
			{
			}
		}

		private void reLoadWorkSchedule()
		{
			try
			{
				facadeEmployeeBenefit.FillWorkSchedule();
				display();
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
			finally
			{
			}		
		}
		public override void PrintForm()
		{
			frmListOfEmployeeBenefitforTimeCard formReport = new frmListOfEmployeeBenefitforTimeCard ();
			formReport.Text = "ใบลงเวลาสำหรับพนักงานบริการ";
			formReport.SelectedDate = dtpForMonth.Value;
			formReport.SelectedEmployeeNo = facadeEmployeeBenefit.Employee.EmployeeNo;
			formReport.SelectedReportChargeName = "rptTimeCardForChargebyEmployee.rpt";
			formReport.SelectedReportPaymentName = "rptTimeCardForPaymentbyEmployee.rpt";
			formReport.ShowDialog();
		}

		//============================== Public Method ==============================

		//==============================     event     ==============================
		private void frmEmployeeBenefit_Load(object sender, System.EventArgs e)
		{
			InitForm();
		}

		#region - form -
			private void dtpForMonth_ValueChanged(object sender, System.EventArgs e)
			{
				RefreshForm();
			}
			
			private void btnCalOT_Click(object sender, System.EventArgs e)
			{
				CalculateOTAll();
			}

			private void btnReLoad_Click(object sender, System.EventArgs e)
			{
				reLoadWorkSchedule();
			}

			private void btnOK_Click(object sender, System.EventArgs e)
			{
				CalculateOTAll();
				updateEvent();
			}

			private void btnCancel_Click(object sender, System.EventArgs e)
			{
				this.Close();
			}
		#endregion

		#region - OT -
			private void fpsOvertime_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
			{
				if(!e.ColumnHeader){}
			}

			private void fpsOvertime_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
			{
				if(e.KeyCode==Keys.Tab)
				{
					if(fpsOvertime_Sheet1.ActiveColumnIndex==0)
					{
						fpsOvertime_Sheet1.ActiveColumnIndex = 1;
					}
					else if(fpsOvertime_Sheet1.ActiveColumnIndex==4)
					{
						fpsOvertime_Sheet1.ActiveColumnIndex = 6;
					}
				}
				else
				{
					if(e.KeyCode == Keys.Enter)
					{
						otEnter();
					}				
				}
			}
		#endregion

		#region - One Day -
			private void mniAddOne_Click(object sender, System.EventArgs e)
			{
				addRowOneDayTrip();
				mniDeleteOne.Enabled = true;
			}

			private void mniDeleteOne_Click(object sender, System.EventArgs e)
			{
				fpsOneDayTrip.EditModePermanent = false;
				fpsOneDayTrip.EditMode = false;
				fpsOneDayTrip_Sheet1.RemoveRows(fpsOneDayTrip_Sheet1.ActiveRowIndex,1);
				if(fpsOneDayTrip_Sheet1.RowCount==0)
				{
					mniDeleteOne.Enabled = false;
				}
				else
				{
					mniDeleteOne.Enabled = true;
				}
				fpsOneDayTrip.EditModePermanent = true;
				fpsOneDayTrip.EditMode = true;
			}

			private void fpsOneDayTrip_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
			{
				if(!e.ColumnHeader){}
			}

			private void fpsOneDayTrip_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
			{
				if(e.KeyCode == Keys.Enter)
				{
					oneDayTripEnter();
				}
			}

			private void fpsOneDayTrip_ComboCloseUp(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
			{
				if(fpsOneDayTrip_Sheet1.ActiveColumnIndex == 2)
				{
					oneDayTripEnter();
				}
			}
		#endregion

		#region - Over Night -
		private void mniAdd_Click(object sender, System.EventArgs e)
		{
			addRowOverNight();
			mniDelete.Enabled = true;
		}

		private void mniDelete_Click(object sender, System.EventArgs e)
		{
			fpsOvernightTrip.EditModePermanent = false;
			fpsOvernightTrip.EditMode = false;
			fpsOvernightTrip_Sheet1.RemoveRows(fpsOvernightTrip_Sheet1.ActiveRowIndex,1);
			if(fpsOvernightTrip_Sheet1.RowCount==0)
			{
				mniDelete.Enabled = false;
			}
			else
			{
				mniDelete.Enabled = true;
			}
			fpsOvernightTrip.EditMode = true;
			fpsOvernightTrip.EditModePermanent = true;
		}

		private void fpsOvernightTrip_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader){}
		}

		private void tabBenefit_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				overnightEnter();
			}
		}
		#endregion

	}
}