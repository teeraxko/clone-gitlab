using System;
using System.Data.SqlClient;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;

using Entity.CommonEntity;

using Facade.AttendanceFacade;

using Presentation.CommonGUI;
using Presentation.PiGUI;

using SystemFramework.AppException;
using SystemFramework.AppMessage;
using SystemFramework.AppConfig;

namespace Presentation.AttendanceGUI
{
	public class frmEmployeeAttendanceBase : Presentation.CommonGUI.ChildFormBase, IMDIChildForm
	{
		#region Designer generated code

		private System.Windows.Forms.TextBox txbAgeMonth;
		private System.Windows.Forms.Label lblYear;
		private System.Windows.Forms.Label lblAge;
		private System.Windows.Forms.TextBox txbAgeYear;
		private System.Windows.Forms.Label lblServiceStaffType;
		private System.Windows.Forms.Label lblPosition;
		private System.Windows.Forms.TextBox txbEmployeePosition;
		private System.Windows.Forms.TextBox txbEmployeeNo;
		private System.Windows.Forms.TextBox txbEmployeeName;
		private System.Windows.Forms.Label lblSection;
		private System.Windows.Forms.TextBox txtEmpSection;
		private System.Windows.Forms.PictureBox pctEmployee;
		private System.Windows.Forms.GroupBox grbEmployee;
		private System.Windows.Forms.Label lblEmployee;
		private System.Windows.Forms.TextBox txbPositionType;
		private System.Windows.Forms.Label lblAgeMonth;
		private System.Windows.Forms.TabPage tabPage3;
		private FarPoint.Win.Spread.SheetView fpsOvertime_Sheet1;
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
			FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmEmployeeAttendanceBase));
			FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType2 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
			FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType3 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
			FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType4 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
			this.lblAgeMonth = new System.Windows.Forms.Label();
			this.txbAgeMonth = new System.Windows.Forms.TextBox();
			this.lblYear = new System.Windows.Forms.Label();
			this.lblAge = new System.Windows.Forms.Label();
			this.txbAgeYear = new System.Windows.Forms.TextBox();
			this.lblServiceStaffType = new System.Windows.Forms.Label();
			this.txbPositionType = new System.Windows.Forms.TextBox();
			this.lblPosition = new System.Windows.Forms.Label();
			this.txbEmployeePosition = new System.Windows.Forms.TextBox();
			this.txbEmployeeNo = new System.Windows.Forms.TextBox();
			this.txbEmployeeName = new System.Windows.Forms.TextBox();
			this.lblSection = new System.Windows.Forms.Label();
			this.txtEmpSection = new System.Windows.Forms.TextBox();
			this.pctEmployee = new System.Windows.Forms.PictureBox();
			this.grbEmployee = new System.Windows.Forms.GroupBox();
			this.lblEmployee = new System.Windows.Forms.Label();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.fpsOvertime_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.grbEmployee.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fpsOvertime_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// lblAgeMonth
			// 
			this.lblAgeMonth.AutoSize = true;
			this.lblAgeMonth.Location = new System.Drawing.Point(792, 58);
			this.lblAgeMonth.Name = "lblAgeMonth";
			this.lblAgeMonth.Size = new System.Drawing.Size(29, 17);
			this.lblAgeMonth.TabIndex = 14;
			this.lblAgeMonth.Text = "เดือน";
			this.lblAgeMonth.Visible = false;
			// 
			// txbAgeMonth
			// 
			this.txbAgeMonth.Enabled = false;
			this.txbAgeMonth.Location = new System.Drawing.Point(760, 56);
			this.txbAgeMonth.Name = "txbAgeMonth";
			this.txbAgeMonth.Size = new System.Drawing.Size(32, 21);
			this.txbAgeMonth.TabIndex = 13;
			this.txbAgeMonth.Text = "";
			this.txbAgeMonth.Visible = false;
			// 
			// lblYear
			// 
			this.lblYear.AutoSize = true;
			this.lblYear.Location = new System.Drawing.Point(736, 58);
			this.lblYear.Name = "lblYear";
			this.lblYear.Size = new System.Drawing.Size(12, 17);
			this.lblYear.TabIndex = 12;
			this.lblYear.Text = "ปี";
			this.lblYear.Visible = false;
			// 
			// lblAge
			// 
			this.lblAge.AutoSize = true;
			this.lblAge.Location = new System.Drawing.Point(672, 58);
			this.lblAge.Name = "lblAge";
			this.lblAge.Size = new System.Drawing.Size(22, 17);
			this.lblAge.TabIndex = 10;
			this.lblAge.Text = "อายุ";
			this.lblAge.Visible = false;
			// 
			// txbAgeYear
			// 
			this.txbAgeYear.Enabled = false;
			this.txbAgeYear.Location = new System.Drawing.Point(704, 56);
			this.txbAgeYear.Name = "txbAgeYear";
			this.txbAgeYear.Size = new System.Drawing.Size(32, 21);
			this.txbAgeYear.TabIndex = 11;
			this.txbAgeYear.Text = "";
			this.txbAgeYear.Visible = false;
			// 
			// lblServiceStaffType
			// 
			this.lblServiceStaffType.AutoSize = true;
			this.lblServiceStaffType.Location = new System.Drawing.Point(432, 58);
			this.lblServiceStaffType.Name = "lblServiceStaffType";
			this.lblServiceStaffType.Size = new System.Drawing.Size(81, 17);
			this.lblServiceStaffType.TabIndex = 8;
			this.lblServiceStaffType.Text = "ประเภทตำแหน่ง";
			this.lblServiceStaffType.Visible = false;
			// 
			// txbPositionType
			// 
			this.txbPositionType.Enabled = false;
			this.txbPositionType.Location = new System.Drawing.Point(528, 56);
			this.txbPositionType.Name = "txbPositionType";
			this.txbPositionType.Size = new System.Drawing.Size(120, 21);
			this.txbPositionType.TabIndex = 9;
			this.txbPositionType.Text = "";
			this.txbPositionType.Visible = false;
			// 
			// lblPosition
			// 
			this.lblPosition.AutoSize = true;
			this.lblPosition.Location = new System.Drawing.Point(16, 58);
			this.lblPosition.Name = "lblPosition";
			this.lblPosition.Size = new System.Drawing.Size(44, 17);
			this.lblPosition.TabIndex = 6;
			this.lblPosition.Text = "ตำแหน่ง";
			this.lblPosition.Visible = false;
			// 
			// txbEmployeePosition
			// 
			this.txbEmployeePosition.Enabled = false;
			this.txbEmployeePosition.Location = new System.Drawing.Point(64, 56);
			this.txbEmployeePosition.Name = "txbEmployeePosition";
			this.txbEmployeePosition.Size = new System.Drawing.Size(336, 21);
			this.txbEmployeePosition.TabIndex = 7;
			this.txbEmployeePosition.Text = "";
			this.txbEmployeePosition.Visible = false;
			// 
			// txbEmployeeNo
			// 
			this.txbEmployeeNo.Location = new System.Drawing.Point(64, 24);
			this.txbEmployeeNo.MaxLength = 5;
			this.txbEmployeeNo.Name = "txbEmployeeNo";
			this.txbEmployeeNo.Size = new System.Drawing.Size(56, 21);
			this.txbEmployeeNo.TabIndex = 2;
			this.txbEmployeeNo.Text = "";
			this.txbEmployeeNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbEmployeeNo_KeyDown);
			this.txbEmployeeNo.TextChanged += new System.EventHandler(this.txbEmployeeNo_TextChanged);
			this.txbEmployeeNo.DoubleClick += new System.EventHandler(this.txbEmployeeNo_DoubleClick);
			// 
			// txbEmployeeName
			// 
			this.txbEmployeeName.Enabled = false;
			this.txbEmployeeName.Location = new System.Drawing.Point(128, 24);
			this.txbEmployeeName.Name = "txbEmployeeName";
			this.txbEmployeeName.Size = new System.Drawing.Size(272, 21);
			this.txbEmployeeName.TabIndex = 3;
			this.txbEmployeeName.Text = "";
			this.txbEmployeeName.Visible = false;
			// 
			// lblSection
			// 
			this.lblSection.AutoSize = true;
			this.lblSection.Location = new System.Drawing.Point(432, 26);
			this.lblSection.Name = "lblSection";
			this.lblSection.Size = new System.Drawing.Size(43, 17);
			this.lblSection.TabIndex = 4;
			this.lblSection.Text = "ส่วนงาน";
			this.lblSection.Visible = false;
			// 
			// txtEmpSection
			// 
			this.txtEmpSection.Enabled = false;
			this.txtEmpSection.Location = new System.Drawing.Point(528, 24);
			this.txtEmpSection.Name = "txtEmpSection";
			this.txtEmpSection.Size = new System.Drawing.Size(296, 21);
			this.txtEmpSection.TabIndex = 5;
			this.txtEmpSection.Text = "";
			this.txtEmpSection.Visible = false;
			// 
			// pctEmployee
			// 
			this.pctEmployee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pctEmployee.Location = new System.Drawing.Point(840, 16);
			this.pctEmployee.Name = "pctEmployee";
			this.pctEmployee.Size = new System.Drawing.Size(88, 104);
			this.pctEmployee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pctEmployee.TabIndex = 7;
			this.pctEmployee.TabStop = false;
			this.pctEmployee.Visible = false;
			// 
			// grbEmployee
			// 
			this.grbEmployee.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.grbEmployee.Controls.Add(this.txbEmployeeNo);
			this.grbEmployee.Controls.Add(this.txbEmployeeName);
			this.grbEmployee.Controls.Add(this.txbEmployeePosition);
			this.grbEmployee.Controls.Add(this.txtEmpSection);
			this.grbEmployee.Controls.Add(this.txbPositionType);
			this.grbEmployee.Controls.Add(this.txbAgeYear);
			this.grbEmployee.Controls.Add(this.txbAgeMonth);
			this.grbEmployee.Controls.Add(this.lblEmployee);
			this.grbEmployee.Controls.Add(this.lblPosition);
			this.grbEmployee.Controls.Add(this.lblSection);
			this.grbEmployee.Controls.Add(this.lblAge);
			this.grbEmployee.Controls.Add(this.lblYear);
			this.grbEmployee.Controls.Add(this.lblAgeMonth);
			this.grbEmployee.Controls.Add(this.pctEmployee);
			this.grbEmployee.Controls.Add(this.lblServiceStaffType);
			this.grbEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.grbEmployee.Location = new System.Drawing.Point(16, 8);
			this.grbEmployee.Name = "grbEmployee";
			this.grbEmployee.Size = new System.Drawing.Size(944, 128);
			this.grbEmployee.TabIndex = 20;
			this.grbEmployee.TabStop = false;
			// 
			// lblEmployee
			// 
			this.lblEmployee.AutoSize = true;
			this.lblEmployee.Location = new System.Drawing.Point(16, 26);
			this.lblEmployee.Name = "lblEmployee";
			this.lblEmployee.Size = new System.Drawing.Size(45, 17);
			this.lblEmployee.TabIndex = 1;
			this.lblEmployee.Text = "พนักงาน";
			// 
			// tabPage3
			// 
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(984, 478);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = " ค่าเดินทาง ไป - กลับ";
			// 
			// fpsOvertime_Sheet1
			// 
			this.fpsOvertime_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsOvertime_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsOvertime_Sheet1.ColumnCount = 13;
			this.fpsOvertime_Sheet1.ColumnHeader.RowCount = 3;
			this.fpsOvertime_Sheet1.RowCount = 1;
			this.fpsOvertime_Sheet1.Cells.Get(0, 0).BackColor = System.Drawing.Color.PapayaWhip;
			this.fpsOvertime_Sheet1.Cells.Get(0, 2).BackColor = System.Drawing.Color.PapayaWhip;
			this.fpsOvertime_Sheet1.Cells.Get(0, 3).BackColor = System.Drawing.Color.PapayaWhip;
			this.fpsOvertime_Sheet1.Cells.Get(0, 7).BackColor = System.Drawing.Color.PapayaWhip;
			this.fpsOvertime_Sheet1.Cells.Get(0, 8).BackColor = System.Drawing.Color.PapayaWhip;
			this.fpsOvertime_Sheet1.Cells.Get(0, 9).BackColor = System.Drawing.Color.PapayaWhip;
			this.fpsOvertime_Sheet1.Cells.Get(0, 10).BackColor = System.Drawing.Color.PapayaWhip;
			this.fpsOvertime_Sheet1.Cells.Get(0, 11).BackColor = System.Drawing.Color.PapayaWhip;
			this.fpsOvertime_Sheet1.Cells.Get(0, 12).BackColor = System.Drawing.Color.PapayaWhip;
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(0, 0).RowSpan = 3;
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(0, 0).Text = "วันที่";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(0, 1).ColumnSpan = 6;
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "เวลาปฏิบัติหน้าที่  Working Time";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(0, 7).ColumnSpan = 3;
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(0, 7).Text = "ล่วงเวลา Overtime Rate";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(0, 10).RowSpan = 3;
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(0, 10).Text = "ค่าแท็กซี่ Taxi Charge (Times)";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(0, 11).RowSpan = 3;
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(0, 11).Text = "ค่าแท็กซี่ Taxi Charge (Amount)";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(0, 12).RowSpan = 3;
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(0, 12).Text = "ค่าอาหาร Food Charge (Amount)";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(1, 1).RowSpan = 2;
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(1, 1).Text = "ก่อนเวลา Before Hours";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(1, 2).ColumnSpan = 2;
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(1, 2).Text = "ระหว่างเวลา Work During Hours";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(1, 4).ColumnSpan = 2;
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(1, 4).Text = "เวลาพัก Lunch Time";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(1, 6).RowSpan = 2;
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(1, 6).Text = "หลังเวลา Work After Hours";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(1, 7).RowSpan = 2;
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(1, 7).Text = "A";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(1, 8).RowSpan = 2;
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(1, 8).Text = "B";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(1, 9).RowSpan = 2;
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(1, 9).Text = "C";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(2, 2).Text = "From";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(2, 3).Text = "To";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(2, 4).Text = "From";
			this.fpsOvertime_Sheet1.ColumnHeader.Cells.Get(2, 5).Text = "To";
			this.fpsOvertime_Sheet1.Columns.Get(0).BackColor = System.Drawing.Color.MistyRose;
			this.fpsOvertime_Sheet1.Columns.Get(0).Width = 68F;
			dateTimeCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			dateTimeCellType1.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
			dateTimeCellType1.DateDefault = new System.DateTime(2005, 11, 22, 14, 12, 23, 0);
			dateTimeCellType1.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.TimeOnly;
			dateTimeCellType1.DropDownButton = false;
			dateTimeCellType1.MaximumTime = System.TimeSpan.Parse("23:59:59");
			dateTimeCellType1.TimeDefault = new System.DateTime(2005, 11, 22, 14, 12, 23, 0);
			this.fpsOvertime_Sheet1.Columns.Get(1).CellType = dateTimeCellType1;
			this.fpsOvertime_Sheet1.Columns.Get(1).Width = 64F;
			this.fpsOvertime_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.fpsOvertime_Sheet1.Columns.Get(2).Label = "From";
			this.fpsOvertime_Sheet1.Columns.Get(2).Locked = false;
			this.fpsOvertime_Sheet1.Columns.Get(2).Width = 75F;
			this.fpsOvertime_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.fpsOvertime_Sheet1.Columns.Get(3).Label = "To";
			this.fpsOvertime_Sheet1.Columns.Get(3).Width = 92F;
			dateTimeCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			dateTimeCellType2.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
			dateTimeCellType2.DateDefault = new System.DateTime(2005, 11, 22, 14, 12, 39, 0);
			dateTimeCellType2.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.TimeOnly;
			dateTimeCellType2.DropDownButton = false;
			dateTimeCellType2.TimeDefault = new System.DateTime(2005, 11, 22, 14, 12, 39, 0);
			this.fpsOvertime_Sheet1.Columns.Get(4).CellType = dateTimeCellType2;
			this.fpsOvertime_Sheet1.Columns.Get(4).Label = "From";
			this.fpsOvertime_Sheet1.Columns.Get(4).Locked = false;
			this.fpsOvertime_Sheet1.Columns.Get(4).Width = 62F;
			dateTimeCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			dateTimeCellType3.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
			dateTimeCellType3.DateDefault = new System.DateTime(2005, 11, 22, 14, 12, 39, 0);
			dateTimeCellType3.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.TimeOnly;
			dateTimeCellType3.DropDownButton = false;
			dateTimeCellType3.TimeDefault = new System.DateTime(2005, 11, 22, 14, 12, 39, 0);
			this.fpsOvertime_Sheet1.Columns.Get(5).CellType = dateTimeCellType3;
			this.fpsOvertime_Sheet1.Columns.Get(5).Label = "To";
			this.fpsOvertime_Sheet1.Columns.Get(5).Width = 58F;
			dateTimeCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			dateTimeCellType4.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
			dateTimeCellType4.DateDefault = new System.DateTime(2005, 11, 22, 14, 12, 39, 0);
			dateTimeCellType4.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.TimeOnly;
			dateTimeCellType4.DropDownButton = false;
			dateTimeCellType4.TimeDefault = new System.DateTime(2005, 11, 22, 14, 12, 39, 0);
			this.fpsOvertime_Sheet1.Columns.Get(6).CellType = dateTimeCellType4;
			this.fpsOvertime_Sheet1.Columns.Get(6).Width = 68F;
			this.fpsOvertime_Sheet1.Columns.Get(7).BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.fpsOvertime_Sheet1.Columns.Get(7).Width = 46F;
			this.fpsOvertime_Sheet1.Columns.Get(8).BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.fpsOvertime_Sheet1.Columns.Get(8).Width = 47F;
			this.fpsOvertime_Sheet1.Columns.Get(9).BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.fpsOvertime_Sheet1.Columns.Get(9).Width = 46F;
			this.fpsOvertime_Sheet1.Columns.Get(10).BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.fpsOvertime_Sheet1.Columns.Get(10).Width = 70F;
			this.fpsOvertime_Sheet1.Columns.Get(11).Width = 71F;
			this.fpsOvertime_Sheet1.Columns.Get(12).Width = 76F;
			this.fpsOvertime_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsOvertime_Sheet1.SheetName = "Sheet1";
			this.fpsOvertime_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// frmEmployeeAttendanceBase
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(976, 465);
			this.Controls.Add(this.grbEmployee);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.Name = "frmEmployeeAttendanceBase";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmEmployeeAttendanceBase_Load);
			this.grbEmployee.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fpsOvertime_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
			private frmMain formMDIParent;
			private frmEmplist formEmplist;
			protected EmployeeAttendanceFacadeBase facadeEmployeeAttendance;
		#endregion

		#region - Property -
		#endregion

		//==============================  Constructor  ==============================
		public frmEmployeeAttendanceBase() : base()
		{
			InitializeComponent();
		}

		#region - Private Method -
			private void NullException(Exception ex)
			{
				ex = null;
			}

			private void bindEmployee()
			{
				txbEmployeeName.Text = "";
				txtEmpSection.Text = "";
				txbEmployeePosition.Text = "";
				txbPositionType.Text = "";

				txbAgeYear.Text = "";
				txbAgeMonth.Text = "";
				pctEmployee.Text = "";
			}

			private void bindEmployee(Employee value)
			{
				txbEmployeeName.Text = value.EmployeeName;
				txtEmpSection.Text = value.ASection.AFullName.English;
				txbEmployeePosition.Text = value.APosition.AName.English;
				txbPositionType.Text = value.APosition.APositionType.ADescription.English;

				YearMonth age = facadeEmployeeAttendance.CalculateAge(value.BirthDate);

				txbAgeYear.Text = age.Year.ToString();
				txbAgeMonth.Text = age.Month.ToString();
				
//				try
//				{
//					pctEmployee.Image = System.Drawing.Image.FromFile(ApplicationProfile.PHOTO_PATH + facadePI.Employee.EmployeeNo + ".jpg");
//				}
//				catch
//				{
//					pctEmployee.Image = null;
//				}

				try
				{
					System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(ApplicationProfile.PHOTO_PATH);
					System.IO.FileInfo[] files = dirInfo.GetFiles(facadeEmployeeAttendance.Employee.EmployeeNo + ".*");
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
			}

			private void visibleDetailEmployee(bool value)
			{
				txbEmployeeNo.Enabled = !value;
				txbEmployeeName.Visible = value;
				lblSection.Visible = value;
				txtEmpSection.Visible = value;
				lblPosition.Visible = value;
				txbEmployeePosition.Visible = value;
				lblServiceStaffType.Visible = value;
				txbPositionType.Visible = value;
				lblAge.Visible = value;
				txbAgeYear.Visible = value;
				lblYear.Visible = value;
				txbAgeMonth.Visible = value;
				lblAgeMonth.Visible = value;
				pctEmployee.Visible = value;

				MainMenuNewStatus = value;
				MainMenuRefreshStatus = value;
				formMDIParent.EnableNewCommand(value);
				formMDIParent.EnableRefreshCommand(value);
			}

			protected virtual void visibleButton(bool value)
			{
			}

			protected virtual void visibleForm(bool value)
			{
				visibleButton(value);
			}
		#endregion

		//==============================  Base Event   ==============================
		#region - Menu Method -
			public virtual void InitForm()
			{
				formMDIParent = (frmMain)this.MdiParent;
				formEmplist = new frmEmplist();
				visibleDetailEmployee(false);
				visibleForm(false);
				bindEmployee();
				txbEmployeeNo.Text = "";
				txbEmployeeNo.Focus();
			}

			public virtual void RefreshForm()
			{
//				try
//				{
//
//				}
//				catch(SqlException ex)
//				{
//					Message(ex);
//				}
//				catch(AppExceptionBase ex)
//				{
//					Message(ex);
//				}
//				catch(Exception ex)
//				{
//					Message(ex);
//				}
//				finally
//				{}
			}

			public virtual void PrintForm()
			{}

			public virtual void ExitForm()
			{
				formEmplist = null;
				facadeEmployeeAttendance = null;
				this.Close();
			}

		#endregion

		private void displayEmployee()
		{
			try
			{
				if(facadeEmployeeAttendance.DisplayEmployee(txbEmployeeNo.Text.Trim()))
				{
					visibleDetailEmployee(true);
					visibleForm(true);
					bindEmployee(facadeEmployeeAttendance.Employee);
					RefreshForm();
				}
				else
				{
					visibleDetailEmployee(false);
					visibleForm(false);
					bindEmployee();
				}
			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(EmpNotFoundException ex)
			{
				NullException(ex);
				Message(MessageList.Error.E0004, "รหัสพนักงาน");
				setSelected(txbEmployeeNo);
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

		private void callEmpList()
		{
			try
			{
				formEmplist.ShowDialog();
				if(formEmplist.Selected)
				{
					txbEmployeeNo.Text = formEmplist.SelectedEmployee.EmployeeNo;
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

		//============================== Public Method ==============================

		//==============================     event     ==============================
		private void frmEmployeeAttendanceBase_Load(object sender, System.EventArgs e)
		{
		}

		private void txbEmployeeNo_TextChanged(object sender, System.EventArgs e)
		{
			if(txbEmployeeNo.Text.Trim().Length == txbEmployeeNo.MaxLength)
			{
				displayEmployee();
			}
		}

		private void txbEmployeeNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				if(txbEmployeeNo.Text.Trim() == "")
				{
					Message(MessageList.Error.E0002, "รหัสพนักงาน");
					setSelected(txbEmployeeNo);
				}
				else
				{
					displayEmployee();
				}
			}
		}

		private void txbEmployeeNo_DoubleClick(object sender, System.EventArgs e)
		{
			callEmpList();
		}
	}
}