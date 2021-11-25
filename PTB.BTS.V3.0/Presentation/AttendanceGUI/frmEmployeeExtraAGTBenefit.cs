using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using SystemFramework.AppMessage;
using SystemFramework.AppException;
using SystemFramework.AppConfig;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using Facade.CommonFacade;
using Facade.AttendanceFacade;

using Presentation.PiGUI;
using Presentation.CommonGUI;

namespace Presentation.AttendanceGUI
{
	public class frmEmployeeExtraAGTBenefit : ChildFormBase, IMDIChildForm
	{
        //This class not use : woranai 16/03/2007
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
		private System.Windows.Forms.GroupBox gpbEmployee;
		private System.Windows.Forms.Label lblAgeMonth;
		private System.Windows.Forms.TextBox txtAgeMonth;
		private System.Windows.Forms.Label lblAgeYear;
		private System.Windows.Forms.Label lblAge;
		private System.Windows.Forms.TextBox txtAgeYear;
		private System.Windows.Forms.Label lblPositionType;
		private System.Windows.Forms.TextBox txtPositionType;
		private System.Windows.Forms.Label lblPosition;
		private System.Windows.Forms.TextBox txtEmpPosition;
		private System.Windows.Forms.TextBox txtEmpNo;
		private System.Windows.Forms.TextBox txtEmpName;
		private System.Windows.Forms.Label lblSection;
		private System.Windows.Forms.TextBox txtEmpSection;
		private System.Windows.Forms.Label label4;
		protected System.Windows.Forms.PictureBox pctEmployee;
		private System.Windows.Forms.DateTimePicker dtpForMonth;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private FarPoint.Win.Spread.FpSpread fpsDeduction;
		private FarPoint.Win.Spread.SheetView fpsDeduction_Sheet1;
		private FarPoint.Win.Input.FpInteger fpiDaysDeduction;
		private System.Windows.Forms.Label lblForMonth;
		private FarPoint.Win.Input.FpInteger fpiBenfitAmount;
		private FarPoint.Win.Input.FpInteger fpiDeductionAmount;
		private FarPoint.Win.Input.FpInteger fpiNetAmount;
		private FarPoint.Win.Input.FpInteger fpiDeductAmountPerDay;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.GroupBox gpbAGTBenefit;

		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
			this.gpbEmployee = new System.Windows.Forms.GroupBox();
			this.lblAgeMonth = new System.Windows.Forms.Label();
			this.txtAgeMonth = new System.Windows.Forms.TextBox();
			this.lblAgeYear = new System.Windows.Forms.Label();
			this.lblAge = new System.Windows.Forms.Label();
			this.txtAgeYear = new System.Windows.Forms.TextBox();
			this.lblPositionType = new System.Windows.Forms.Label();
			this.txtPositionType = new System.Windows.Forms.TextBox();
			this.lblPosition = new System.Windows.Forms.Label();
			this.txtEmpPosition = new System.Windows.Forms.TextBox();
			this.txtEmpNo = new System.Windows.Forms.TextBox();
			this.txtEmpName = new System.Windows.Forms.TextBox();
			this.lblSection = new System.Windows.Forms.Label();
			this.txtEmpSection = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.pctEmployee = new System.Windows.Forms.PictureBox();
			this.dtpForMonth = new System.Windows.Forms.DateTimePicker();
			this.lblForMonth = new System.Windows.Forms.Label();
			this.fpsDeduction = new FarPoint.Win.Spread.FpSpread();
			this.fpsDeduction_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.gpbAGTBenefit = new System.Windows.Forms.GroupBox();
			this.fpiDeductAmountPerDay = new FarPoint.Win.Input.FpInteger();
			this.fpiNetAmount = new FarPoint.Win.Input.FpInteger();
			this.fpiDeductionAmount = new FarPoint.Win.Input.FpInteger();
			this.fpiBenfitAmount = new FarPoint.Win.Input.FpInteger();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.fpiDaysDeduction = new FarPoint.Win.Input.FpInteger();
			this.label8 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			this.gpbEmployee.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fpsDeduction)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsDeduction_Sheet1)).BeginInit();
			this.gpbAGTBenefit.SuspendLayout();
			this.SuspendLayout();
			// 
			// gpbEmployee
			// 
			this.gpbEmployee.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.gpbEmployee.Controls.Add(this.lblAgeMonth);
			this.gpbEmployee.Controls.Add(this.txtAgeMonth);
			this.gpbEmployee.Controls.Add(this.lblAgeYear);
			this.gpbEmployee.Controls.Add(this.lblAge);
			this.gpbEmployee.Controls.Add(this.txtAgeYear);
			this.gpbEmployee.Controls.Add(this.lblPositionType);
			this.gpbEmployee.Controls.Add(this.txtPositionType);
			this.gpbEmployee.Controls.Add(this.lblPosition);
			this.gpbEmployee.Controls.Add(this.txtEmpPosition);
			this.gpbEmployee.Controls.Add(this.txtEmpNo);
			this.gpbEmployee.Controls.Add(this.txtEmpName);
			this.gpbEmployee.Controls.Add(this.lblSection);
			this.gpbEmployee.Controls.Add(this.txtEmpSection);
			this.gpbEmployee.Controls.Add(this.label4);
			this.gpbEmployee.Controls.Add(this.pctEmployee);
			this.gpbEmployee.Location = new System.Drawing.Point(12, 8);
			this.gpbEmployee.Name = "gpbEmployee";
			this.gpbEmployee.Size = new System.Drawing.Size(968, 128);
			this.gpbEmployee.TabIndex = 1;
			this.gpbEmployee.TabStop = false;
			// 
			// lblAgeMonth
			// 
			this.lblAgeMonth.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblAgeMonth.Location = new System.Drawing.Point(793, 56);
			this.lblAgeMonth.Name = "lblAgeMonth";
			this.lblAgeMonth.Size = new System.Drawing.Size(32, 23);
			this.lblAgeMonth.TabIndex = 80;
			this.lblAgeMonth.Text = "เดือน";
			// 
			// txtAgeMonth
			// 
			this.txtAgeMonth.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtAgeMonth.Enabled = false;
			this.txtAgeMonth.Location = new System.Drawing.Point(761, 56);
			this.txtAgeMonth.Name = "txtAgeMonth";
			this.txtAgeMonth.Size = new System.Drawing.Size(32, 20);
			this.txtAgeMonth.TabIndex = 80;
			this.txtAgeMonth.Text = "";
			// 
			// lblAgeYear
			// 
			this.lblAgeYear.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblAgeYear.Location = new System.Drawing.Point(737, 56);
			this.lblAgeYear.Name = "lblAgeYear";
			this.lblAgeYear.Size = new System.Drawing.Size(16, 23);
			this.lblAgeYear.TabIndex = 80;
			this.lblAgeYear.Text = "ปี";
			// 
			// lblAge
			// 
			this.lblAge.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblAge.Location = new System.Drawing.Point(665, 56);
			this.lblAge.Name = "lblAge";
			this.lblAge.Size = new System.Drawing.Size(24, 23);
			this.lblAge.TabIndex = 80;
			this.lblAge.Text = "อายุ";
			// 
			// txtAgeYear
			// 
			this.txtAgeYear.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtAgeYear.Enabled = false;
			this.txtAgeYear.Location = new System.Drawing.Point(697, 56);
			this.txtAgeYear.Name = "txtAgeYear";
			this.txtAgeYear.Size = new System.Drawing.Size(32, 20);
			this.txtAgeYear.TabIndex = 80;
			this.txtAgeYear.Text = "";
			// 
			// lblPositionType
			// 
			this.lblPositionType.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblPositionType.Location = new System.Drawing.Point(441, 56);
			this.lblPositionType.Name = "lblPositionType";
			this.lblPositionType.Size = new System.Drawing.Size(80, 23);
			this.lblPositionType.TabIndex = 80;
			this.lblPositionType.Text = "ประเภทตำแหน่ง";
			// 
			// txtPositionType
			// 
			this.txtPositionType.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtPositionType.Enabled = false;
			this.txtPositionType.Location = new System.Drawing.Point(529, 56);
			this.txtPositionType.Name = "txtPositionType";
			this.txtPositionType.Size = new System.Drawing.Size(120, 20);
			this.txtPositionType.TabIndex = 80;
			this.txtPositionType.Text = "";
			// 
			// lblPosition
			// 
			this.lblPosition.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblPosition.Location = new System.Drawing.Point(25, 56);
			this.lblPosition.Name = "lblPosition";
			this.lblPosition.Size = new System.Drawing.Size(48, 23);
			this.lblPosition.TabIndex = 80;
			this.lblPosition.Text = "ตำแหน่ง";
			// 
			// txtEmpPosition
			// 
			this.txtEmpPosition.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtEmpPosition.Enabled = false;
			this.txtEmpPosition.Location = new System.Drawing.Point(81, 56);
			this.txtEmpPosition.Name = "txtEmpPosition";
			this.txtEmpPosition.Size = new System.Drawing.Size(336, 20);
			this.txtEmpPosition.TabIndex = 80;
			this.txtEmpPosition.Text = "";
			// 
			// txtEmpNo
			// 
			this.txtEmpNo.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtEmpNo.Location = new System.Drawing.Point(81, 24);
			this.txtEmpNo.MaxLength = 5;
			this.txtEmpNo.Name = "txtEmpNo";
			this.txtEmpNo.Size = new System.Drawing.Size(56, 20);
			this.txtEmpNo.TabIndex = 2;
			this.txtEmpNo.Text = "";
			this.txtEmpNo.TextChanged += new System.EventHandler(this.txtEmpNo_TextChanged);
			this.txtEmpNo.DoubleClick += new System.EventHandler(this.txtEmpNo_DoubleClick);
			// 
			// txtEmpName
			// 
			this.txtEmpName.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtEmpName.Enabled = false;
			this.txtEmpName.Location = new System.Drawing.Point(145, 24);
			this.txtEmpName.Name = "txtEmpName";
			this.txtEmpName.Size = new System.Drawing.Size(272, 20);
			this.txtEmpName.TabIndex = 80;
			this.txtEmpName.Text = "";
			// 
			// lblSection
			// 
			this.lblSection.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblSection.Location = new System.Drawing.Point(441, 24);
			this.lblSection.Name = "lblSection";
			this.lblSection.Size = new System.Drawing.Size(40, 23);
			this.lblSection.TabIndex = 80;
			this.lblSection.Text = "ส่วนงาน";
			// 
			// txtEmpSection
			// 
			this.txtEmpSection.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtEmpSection.Enabled = false;
			this.txtEmpSection.Location = new System.Drawing.Point(529, 24);
			this.txtEmpSection.Name = "txtEmpSection";
			this.txtEmpSection.Size = new System.Drawing.Size(304, 20);
			this.txtEmpSection.TabIndex = 80;
			this.txtEmpSection.Text = "";
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label4.Location = new System.Drawing.Point(25, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 23);
			this.label4.TabIndex = 0;
			this.label4.Text = "พนักงาน";
			// 
			// pctEmployee
			// 
			this.pctEmployee.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.pctEmployee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pctEmployee.Location = new System.Drawing.Point(857, 16);
			this.pctEmployee.Name = "pctEmployee";
			this.pctEmployee.Size = new System.Drawing.Size(88, 104);
			this.pctEmployee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pctEmployee.TabIndex = 7;
			this.pctEmployee.TabStop = false;
			// 
			// dtpForMonth
			// 
			this.dtpForMonth.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.dtpForMonth.CustomFormat = "MM/yyyy";
			this.dtpForMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpForMonth.Location = new System.Drawing.Point(492, 152);
			this.dtpForMonth.Name = "dtpForMonth";
			this.dtpForMonth.Size = new System.Drawing.Size(80, 20);
			this.dtpForMonth.TabIndex = 2;
			this.dtpForMonth.ValueChanged += new System.EventHandler(this.dtpForMonth_ValueChanged);
			// 
			// lblForMonth
			// 
			this.lblForMonth.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblForMonth.Location = new System.Drawing.Point(420, 152);
			this.lblForMonth.Name = "lblForMonth";
			this.lblForMonth.Size = new System.Drawing.Size(64, 16);
			this.lblForMonth.TabIndex = 80;
			this.lblForMonth.Text = "สำหรับเดือน";
			// 
			// fpsDeduction
			// 
			this.fpsDeduction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsDeduction.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsDeduction.Location = new System.Drawing.Point(135, 288);
			this.fpsDeduction.Name = "fpsDeduction";
			this.fpsDeduction.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																					  this.fpsDeduction_Sheet1});
			this.fpsDeduction.Size = new System.Drawing.Size(722, 160);
			this.fpsDeduction.TabIndex = 34;
			this.fpsDeduction.TabStop = false;
			// 
			// fpsDeduction_Sheet1
			// 
			this.fpsDeduction_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsDeduction_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsDeduction_Sheet1.ColumnCount = 4;
			this.fpsDeduction_Sheet1.RowCount = 1;
			this.fpsDeduction_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "วันที่";
			this.fpsDeduction_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "พนักงานแทน";
			this.fpsDeduction_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ส่วนงาน";
			this.fpsDeduction_Sheet1.ColumnHeader.Columns.Default.Resizable = false;
			this.fpsDeduction_Sheet1.ColumnHeader.Rows.Get(0).Height = 21F;
			this.fpsDeduction_Sheet1.Columns.Default.Resizable = false;
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsDeduction_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsDeduction_Sheet1.Columns.Get(0).Visible = false;
			this.fpsDeduction_Sheet1.Columns.Get(1).AllowAutoSort = true;
			numberCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			numberCellType1.DecimalPlaces = 0;
			numberCellType1.DropDownButton = false;
			numberCellType1.MinimumValue = 0;
			this.fpsDeduction_Sheet1.Columns.Get(1).CellType = numberCellType1;
			this.fpsDeduction_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsDeduction_Sheet1.Columns.Get(1).Label = "วันที่";
			this.fpsDeduction_Sheet1.Columns.Get(1).Width = 65F;
			this.fpsDeduction_Sheet1.Columns.Get(2).AllowAutoSort = true;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			this.fpsDeduction_Sheet1.Columns.Get(2).CellType = textCellType2;
			this.fpsDeduction_Sheet1.Columns.Get(2).Label = "พนักงานแทน";
			this.fpsDeduction_Sheet1.Columns.Get(2).Width = 250F;
			this.fpsDeduction_Sheet1.Columns.Get(3).AllowAutoSort = true;
			textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType3.DropDownButton = false;
			this.fpsDeduction_Sheet1.Columns.Get(3).CellType = textCellType3;
			this.fpsDeduction_Sheet1.Columns.Get(3).Label = "ส่วนงาน";
			this.fpsDeduction_Sheet1.Columns.Get(3).Width = 350F;
			this.fpsDeduction_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
			this.fpsDeduction_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsDeduction_Sheet1.RowHeader.Rows.Default.Resizable = false;
			this.fpsDeduction_Sheet1.Rows.Default.Resizable = false;
			this.fpsDeduction_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsDeduction_Sheet1.SheetName = "Sheet1";
			this.fpsDeduction_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// gpbAGTBenefit
			// 
			this.gpbAGTBenefit.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.gpbAGTBenefit.Controls.Add(this.fpiDeductAmountPerDay);
			this.gpbAGTBenefit.Controls.Add(this.fpiNetAmount);
			this.gpbAGTBenefit.Controls.Add(this.fpiDeductionAmount);
			this.gpbAGTBenefit.Controls.Add(this.fpiBenfitAmount);
			this.gpbAGTBenefit.Controls.Add(this.label10);
			this.gpbAGTBenefit.Controls.Add(this.label11);
			this.gpbAGTBenefit.Controls.Add(this.label9);
			this.gpbAGTBenefit.Controls.Add(this.fpiDaysDeduction);
			this.gpbAGTBenefit.Controls.Add(this.label8);
			this.gpbAGTBenefit.Controls.Add(this.label6);
			this.gpbAGTBenefit.Controls.Add(this.label7);
			this.gpbAGTBenefit.Controls.Add(this.label3);
			this.gpbAGTBenefit.Controls.Add(this.label5);
			this.gpbAGTBenefit.Controls.Add(this.label2);
			this.gpbAGTBenefit.Controls.Add(this.label1);
			this.gpbAGTBenefit.Location = new System.Drawing.Point(136, 184);
			this.gpbAGTBenefit.Name = "gpbAGTBenefit";
			this.gpbAGTBenefit.Size = new System.Drawing.Size(720, 88);
			this.gpbAGTBenefit.TabIndex = 35;
			this.gpbAGTBenefit.TabStop = false;
			// 
			// fpiDeductAmountPerDay
			// 
			this.fpiDeductAmountPerDay.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
			this.fpiDeductAmountPerDay.AllowClipboardKeys = true;
			this.fpiDeductAmountPerDay.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.fpiDeductAmountPerDay.Enabled = false;
			this.fpiDeductAmountPerDay.Location = new System.Drawing.Point(356, 24);
			this.fpiDeductAmountPerDay.MaxValue = 9999;
			this.fpiDeductAmountPerDay.MinValue = 0;
			this.fpiDeductAmountPerDay.Name = "fpiDeductAmountPerDay";
			this.fpiDeductAmountPerDay.Size = new System.Drawing.Size(80, 20);
			this.fpiDeductAmountPerDay.TabIndex = 18;
			this.fpiDeductAmountPerDay.Text = "";
			// 
			// fpiNetAmount
			// 
			this.fpiNetAmount.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
			this.fpiNetAmount.AllowClipboardKeys = true;
			this.fpiNetAmount.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.fpiNetAmount.Enabled = false;
			this.fpiNetAmount.Location = new System.Drawing.Point(356, 56);
			this.fpiNetAmount.MaxValue = 9999;
			this.fpiNetAmount.MinValue = 0;
			this.fpiNetAmount.Name = "fpiNetAmount";
			this.fpiNetAmount.Size = new System.Drawing.Size(80, 20);
			this.fpiNetAmount.TabIndex = 17;
			this.fpiNetAmount.Text = "";
			// 
			// fpiDeductionAmount
			// 
			this.fpiDeductionAmount.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
			this.fpiDeductionAmount.AllowClipboardKeys = true;
			this.fpiDeductionAmount.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.fpiDeductionAmount.Enabled = false;
			this.fpiDeductionAmount.Location = new System.Drawing.Point(124, 56);
			this.fpiDeductionAmount.MaxValue = 9999;
			this.fpiDeductionAmount.MinValue = 0;
			this.fpiDeductionAmount.Name = "fpiDeductionAmount";
			this.fpiDeductionAmount.Size = new System.Drawing.Size(80, 20);
			this.fpiDeductionAmount.TabIndex = 16;
			this.fpiDeductionAmount.Text = "";
			// 
			// fpiBenfitAmount
			// 
			this.fpiBenfitAmount.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
			this.fpiBenfitAmount.AllowClipboardKeys = true;
			this.fpiBenfitAmount.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.fpiBenfitAmount.Enabled = false;
			this.fpiBenfitAmount.Location = new System.Drawing.Point(124, 24);
			this.fpiBenfitAmount.MaxValue = 9999;
			this.fpiBenfitAmount.MinValue = 0;
			this.fpiBenfitAmount.Name = "fpiBenfitAmount";
			this.fpiBenfitAmount.Size = new System.Drawing.Size(80, 20);
			this.fpiBenfitAmount.TabIndex = 15;
			this.fpiBenfitAmount.Text = "";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(444, 56);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(32, 23);
			this.label10.TabIndex = 14;
			this.label10.Text = "บาท";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(284, 56);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(72, 23);
			this.label11.TabIndex = 12;
			this.label11.Text = "เงินคงเหลือ";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(644, 24);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(24, 23);
			this.label9.TabIndex = 11;
			this.label9.Text = "วัน";
			// 
			// fpiDaysDeduction
			// 
			this.fpiDaysDeduction.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
			this.fpiDaysDeduction.AllowClipboardKeys = true;
			this.fpiDaysDeduction.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.fpiDaysDeduction.Enabled = false;
			this.fpiDaysDeduction.Location = new System.Drawing.Point(596, 24);
			this.fpiDaysDeduction.MaxValue = 9999;
			this.fpiDaysDeduction.MinValue = 0;
			this.fpiDaysDeduction.Name = "fpiDaysDeduction";
			this.fpiDaysDeduction.Size = new System.Drawing.Size(40, 20);
			this.fpiDaysDeduction.TabIndex = 10;
			this.fpiDaysDeduction.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(500, 24);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(88, 23);
			this.label8.TabIndex = 9;
			this.label8.Text = "จำนวนวันที่ถูกหัก";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(212, 56);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(32, 23);
			this.label6.TabIndex = 8;
			this.label6.Text = "บาท";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(52, 56);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 23);
			this.label7.TabIndex = 6;
			this.label7.Text = "หักเงินทั้งสิ้น";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(444, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "บาท";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(284, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 23);
			this.label5.TabIndex = 3;
			this.label5.Text = "หักวันละ";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(212, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "บาท";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(52, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "เบี้ยขยัน";
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(503, 472);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 4;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdOK.Location = new System.Drawing.Point(415, 472);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 3;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// frmEmployeeExtraAGTBenefit
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(992, 517);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.gpbAGTBenefit);
			this.Controls.Add(this.fpsDeduction);
			this.Controls.Add(this.gpbEmployee);
			this.Controls.Add(this.dtpForMonth);
			this.Controls.Add(this.lblForMonth);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmEmployeeExtraAGTBenefit";
			this.Text = "frmEmployeeExtraAGTBenefit";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmEmployeeExtraAGTBenefit_Load);
			this.gpbEmployee.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fpsDeduction)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsDeduction_Sheet1)).EndInit();
			this.gpbAGTBenefit.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isTextChange = true;
		private frmMain mdiParent;
		private EmployeeExtraAGTBenefitFacade facadeEmployeeExtraAGTBenefit;
		#endregion

		private Employee objEmployee;
		private Employee ObjEmployee
		{
			set
			{
				isTextChange = false;
				objEmployee = value;
				txtEmpNo.Text = value.EmployeeNo;
				txtEmpName.Text = value.EmployeeName;
				txtEmpSection.Text = value.ASection.AFullName.English;
				txtEmpPosition.Text = value.APosition.AName.English;
				txtPositionType.Text = value.APosition.APositionType.ADescription.English;

				YearMonth yearMonth = facadeEmployeeExtraAGTBenefit.CalculateAge(value.BirthDate);
				txtAgeYear.Text = yearMonth.Year.ToString();
				txtAgeMonth.Text =	yearMonth.Month.ToString();
				isTextChange = true;
			}		
		}

		private ExtraAGTBenefit ObjExtraAGTBenefit
		{
			get{return facadeEmployeeExtraAGTBenefit.ObjExtraAGTBenefit;}
		}

//		============================== Constructor ==============================
		public frmEmployeeExtraAGTBenefit() : base()
		{
			InitializeComponent();
			facadeEmployeeExtraAGTBenefit = new EmployeeExtraAGTBenefitFacade();
		}

//		==============================Private method ==============================
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
			MainMenuNewStatus = true;
			MainMenuDeleteStatus = false;
			MainMenuRefreshStatus = true;
			MainMenuPrintStatus = false;
			mdiParent.EnableNewCommand(false);
			mdiParent.EnableDeleteCommand(false);
			mdiParent.EnableRefreshCommand(true);
			mdiParent.EnablePrintCommand(false);

			clearForm();
			visibleEmployee(true);
			ObjEmployee = value;
			txtEmpNo.Enabled = false;
			dtpForMonth.Value = new System.DateTime(DateTime.Today.Year, DateTime.Today.Month, 1, 0, 0, 0, 0);
				
			try
			{
				System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(ApplicationProfile.PHOTO_PATH);
				System.IO.FileInfo[] files = dirInfo.GetFiles(txtEmpNo.Text + ".*");
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

			RefreshForm();
		}

		private void bindExtraAGTBenefit()
		{
			fpiBenfitAmount.Value = Convert.ToInt32(ObjExtraAGTBenefit.TotalAmount);
			fpiDaysDeduction.Value = Convert.ToInt32(ObjExtraAGTBenefit.DaysDeduction);
			fpiDeductAmountPerDay.Value = Convert.ToInt32(ObjExtraAGTBenefit.DeductionAmountPerDay);
			fpiDeductionAmount.Value = Convert.ToInt32(ObjExtraAGTBenefit.DaysDeduction * ObjExtraAGTBenefit.DeductionAmountPerDay);
			fpiNetAmount.Value = Convert.ToInt32(ObjExtraAGTBenefit.TotalDeductionAmount);
		}

		private void bindExtraAGTBenefitDeduction()
		{
			if (facadeEmployeeExtraAGTBenefit.ObjEmployeeExtraAGTBenefitDeduction != null)
			{
				int iRow = facadeEmployeeExtraAGTBenefit.ObjEmployeeExtraAGTBenefitDeduction.Count;
				fpsDeduction_Sheet1.RowCount = iRow;
				for(int i=0; i<iRow; i++)
				{
					bindExtraAGTBenefitDeduction(i, facadeEmployeeExtraAGTBenefit.ObjEmployeeExtraAGTBenefitDeduction[i]);
				}				
			}			
		}
		
		private void bindExtraAGTBenefitDeduction(int row, ExtraAGTBenefitDeduction value)
		{
			fpsDeduction_Sheet1.Cells.Get(row,0).Text = GUIFunction.GetString(value.EntityKey);
			fpsDeduction_Sheet1.Cells.Get(row,1).Text = GUIFunction.GetString(value.BenefitDate.Day);

			if(value.AEmployee != null && value.AEmployee.EmployeeNo != "")
			{
				fpsDeduction_Sheet1.Cells.Get(row,2).Text = GUIFunction.GetString(value.AEmployee.EmployeeIDName);
				fpsDeduction_Sheet1.Cells.Get(row,3).Text = GUIFunction.GetString(value.AEmployee.ASection.AFullName.English);
			}
		}

		private void visibleForm(bool enable)
		{
			gpbAGTBenefit.Visible = enable;
			fpsDeduction.Visible = enable;
			cmdOK.Visible = enable;
			cmdCancel.Visible = enable;
		}
		
		private void visibleEmployee(bool enable)
		{
			txtEmpName.Visible = enable;
			txtEmpSection.Visible = enable;
			txtEmpPosition.Visible = enable;
			txtPositionType.Visible = enable;
			txtAgeYear.Visible = enable;
			txtAgeMonth.Visible = enable;
			dtpForMonth.Visible = enable;

			lblSection.Visible = enable;
			lblPosition.Visible = enable;
			lblPositionType.Visible = enable;
			lblAge.Visible = enable;
			lblAgeYear.Visible = enable;
			lblAgeMonth.Visible = enable;
			lblForMonth.Visible = enable;
		}

		private void clearInput()
		{
			isTextChange = false;
			txtEmpNo.Text = "";
			txtEmpName.Text = "";
			txtEmpSection.Text = "";
			txtEmpPosition.Text = "";
			txtPositionType.Text = "";
			txtAgeYear.Text = "";
			txtAgeMonth.Text = "";
			dtpForMonth.Value = DateTime.Today;		
			isTextChange = true;
		}

		private void clearAGTBenefit()
		{
			fpiBenfitAmount.Value = 0;
			fpiDaysDeduction.Value = 0;
			fpiDeductAmountPerDay.Value = 0;
			fpiDeductionAmount.Value = 0;
			fpiNetAmount.Value = 0;
		}

		private void clearForm()
		{	
			txtEmpNo.Enabled = true;
			clearInput();
			visibleForm(false);
			visibleEmployee(false);
			clearAGTBenefit();
			fpsDeduction_Sheet1.RowCount = 0;
		}

		public override int MasterCount()
		{
			return facadeEmployeeExtraAGTBenefit.ObjEmployeeExtraAGTBenefitDeduction.Count;
		}

//		============================== Base Event ==============================
		public void InitForm()
		{
			facadeEmployeeExtraAGTBenefit = new EmployeeExtraAGTBenefitFacade();
			clearForm();
		}

		public void RefreshForm()
		{
			try
			{
				DateTime forDate = dtpForMonth.Value;
				visibleForm(true);

				if(facadeEmployeeExtraAGTBenefit.DisplayEmployeeExtraAGTBenefit(objEmployee, forDate))
				{
					bindExtraAGTBenefit();

					if(facadeEmployeeExtraAGTBenefit.DisplayEmployeeExtraAGTBenefitDeduction(objEmployee, forDate))
					{
						bindExtraAGTBenefitDeduction();
					}
					else
					{
						fpsDeduction_Sheet1.RowCount = 0;
					}
				
				}
				else
				{
					clearAGTBenefit();
					fpsDeduction_Sheet1.RowCount = 0;
				}
				mdiParent.RefreshMasterCount();
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

		public void PrintForm()
		{
		}

		public void ExitForm()
		{
			Dispose(true);
		}

//		============================== event ==============================
		private void frmEmployeeExtraAGTBenefit_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
		}

		private void txtEmpNo_TextChanged(object sender, System.EventArgs e)
		{
			if(isTextChange)
			{
				if(txtEmpNo.Text.Length == 5)
				{
					try
					{
						Employee employee = facadeEmployeeExtraAGTBenefit.GetEmployee(txtEmpNo.Text);
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

		private void txtEmpNo_DoubleClick(object sender, System.EventArgs e)
		{
			formEmployeeList();
		}

		private void dtpForMonth_ValueChanged(object sender, System.EventArgs e)
		{
			if(isTextChange)
			{
				RefreshForm();
			}
		}

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			clearMainMenuStatus();
			this.Hide();
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			clearMainMenuStatus();
			this.Close();
		}
	}
}
