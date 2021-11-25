using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using SystemFramework.AppConfig;
using SystemFramework.AppMessage;
using SystemFramework.AppException;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;
using Entity.AttendanceEntities;

using Facade.CommonFacade;
using Facade.AttendanceFacade;

using Presentation.PiGUI;
using Presentation.CommonGUI;

namespace Presentation.AttendanceGUI
{
	public class frmEmployeeWorkAttendance : frmAttendanceHeadBase
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

        private System.Windows.Forms.Label lblHolidayDay;
        private System.Windows.Forms.Label lblHolidayCount;
        private System.Windows.Forms.DateTimePicker dtpForMonth;
        private System.Windows.Forms.Label lblForMonth;
        private FarPoint.Win.Spread.FpSpread fpsEmployeeWorkAttendance;
        private FarPoint.Win.Spread.SheetView fpsEmployeeWorkAttendance_Sheet1;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem mniAdd;
        private System.Windows.Forms.MenuItem mniEdit;
        private System.Windows.Forms.MenuItem mniDelete;
        private System.Windows.Forms.Label lblLateDay;
        private System.Windows.Forms.Label lblLateCount;
        private TextBox txtLate;
        private TextBox txtHoliday;
        private TextBox txtForget;
        private Label lblForgetDay;
        private Label lblForget;

        private System.ComponentModel.Container components = null;

        private void InitializeComponent()
        {
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType7 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType8 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.fpsEmployeeWorkAttendance = new FarPoint.Win.Spread.FpSpread();
            this.fpsEmployeeWorkAttendance_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.lblHolidayDay = new System.Windows.Forms.Label();
            this.lblHolidayCount = new System.Windows.Forms.Label();
            this.dtpForMonth = new System.Windows.Forms.DateTimePicker();
            this.lblForMonth = new System.Windows.Forms.Label();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.mniAdd = new System.Windows.Forms.MenuItem();
            this.mniEdit = new System.Windows.Forms.MenuItem();
            this.mniDelete = new System.Windows.Forms.MenuItem();
            this.lblLateDay = new System.Windows.Forms.Label();
            this.lblLateCount = new System.Windows.Forms.Label();
            this.txtLate = new System.Windows.Forms.TextBox();
            this.txtHoliday = new System.Windows.Forms.TextBox();
            this.txtForget = new System.Windows.Forms.TextBox();
            this.lblForgetDay = new System.Windows.Forms.Label();
            this.lblForget = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pctEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsEmployeeWorkAttendance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsEmployeeWorkAttendance_Sheet1)).BeginInit();
            this.SuspendLayout();
            //
            // pctEmployee
            // 
            this.pctEmployee.Name = "pctEmployee";
            // 
            // lblHolidayDay
            // 
            this.lblHolidayDay.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblHolidayDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblHolidayDay.Location = new System.Drawing.Point(281, 400);
            this.lblHolidayDay.Name = "lblHolidayDay";
            this.lblHolidayDay.Size = new System.Drawing.Size(24, 16);
            this.lblHolidayDay.TabIndex = 28;
            this.lblHolidayDay.Text = "วัน";
            // 
            // lblHolidayCount
            // 
            this.lblHolidayCount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblHolidayCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblHolidayCount.Location = new System.Drawing.Point(160, 400);
            this.lblHolidayCount.Name = "lblHolidayCount";
            this.lblHolidayCount.Size = new System.Drawing.Size(72, 16);
            this.lblHolidayCount.TabIndex = 27;
            this.lblHolidayCount.Text = "รวมวันหยุด =";
            // 
            // dtpForMonth
            // 
            this.dtpForMonth.CustomFormat = "MM/yyyy";
            this.dtpForMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dtpForMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpForMonth.Location = new System.Drawing.Point(476, 144);
            this.dtpForMonth.Name = "dtpForMonth";
            this.dtpForMonth.Size = new System.Drawing.Size(88, 20);
            this.dtpForMonth.TabIndex = 24;
            this.dtpForMonth.Value = new System.DateTime(2548, 8, 1, 0, 0, 0, 0);
            this.dtpForMonth.ValueChanged += new System.EventHandler(this.dtpForMonth_ValueChanged);
            // 
            // lblForMonth
            // 
            this.lblForMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblForMonth.Location = new System.Drawing.Point(404, 144);
            this.lblForMonth.Name = "lblForMonth";
            this.lblForMonth.Size = new System.Drawing.Size(68, 16);
            this.lblForMonth.TabIndex = 25;
            this.lblForMonth.Text = "สำหรับเดือน";
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mniAdd,
            this.mniEdit,
            this.mniDelete});
            // 
            // mniAdd
            // 
            this.mniAdd.Index = 0;
            this.mniAdd.Text = "เพิ่ม";
            this.mniAdd.Click += new System.EventHandler(this.mniAdd_Click);
            // 
            // mniEdit
            // 
            this.mniEdit.Index = 1;
            this.mniEdit.Text = "แก้ไข";
            this.mniEdit.Click += new System.EventHandler(this.mniEdit_Click);
            // 
            // mniDelete
            // 
            this.mniDelete.Index = 2;
            this.mniDelete.Text = "ลบ";
            this.mniDelete.Click += new System.EventHandler(this.mniDelete_Click);
            // 
            // lblLateDay
            // 
            this.lblLateDay.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblLateDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblLateDay.Location = new System.Drawing.Point(441, 400);
            this.lblLateDay.Name = "lblLateDay";
            this.lblLateDay.Size = new System.Drawing.Size(24, 16);
            this.lblLateDay.TabIndex = 31;
            this.lblLateDay.Text = "วัน";
            // 
            // lblLateCount
            // 
            this.lblLateCount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblLateCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblLateCount.Location = new System.Drawing.Point(329, 400);
            this.lblLateCount.Name = "lblLateCount";
            this.lblLateCount.Size = new System.Drawing.Size(72, 16);
            this.lblLateCount.TabIndex = 30;
            this.lblLateCount.Text = "รวมวันสาย =";
            // 
            // txtLate
            // 
            this.txtLate.Location = new System.Drawing.Point(400, 398);
            this.txtLate.Name = "txtLate";
            this.txtLate.ReadOnly = true;
            this.txtLate.Size = new System.Drawing.Size(34, 20);
            this.txtLate.TabIndex = 33;
            this.txtLate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            // 
            // txtHoliday
            // 
            this.txtHoliday.Location = new System.Drawing.Point(240, 398);
            this.txtHoliday.Name = "txtHoliday";
            this.txtHoliday.ReadOnly = true;
            this.txtHoliday.Size = new System.Drawing.Size(34, 20);
            this.txtHoliday.TabIndex = 34;
            this.txtHoliday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHoliday.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            // 
            // txtForget
            // 
            this.txtForget.Location = new System.Drawing.Point(567, 398);
            this.txtForget.Name = "txtForget";
            this.txtForget.ReadOnly = true;
            this.txtForget.Size = new System.Drawing.Size(34, 20);
            this.txtForget.TabIndex = 37;
            this.txtForget.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtForget.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            // 
            // lblForgetDay
            // 
            this.lblForgetDay.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblForgetDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblForgetDay.Location = new System.Drawing.Point(610, 400);
            this.lblForgetDay.Name = "lblForgetDay";
            this.lblForgetDay.Size = new System.Drawing.Size(24, 16);
            this.lblForgetDay.TabIndex = 36;
            this.lblForgetDay.Text = "วัน";
            // 
            // lblForget
            // 
            this.lblForget.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblForget.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblForget.Location = new System.Drawing.Point(480, 400);
            this.lblForget.Name = "lblForget";
            this.lblForget.Size = new System.Drawing.Size(80, 16);
            this.lblForget.TabIndex = 35;
            this.lblForget.Text = "รวมลืมตอกบัตร =";
            // 
            // fpsEmployeeWorkAttendance
            // 
            this.fpsEmployeeWorkAttendance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.fpsEmployeeWorkAttendance.ContextMenu = this.contextMenu1;
            this.fpsEmployeeWorkAttendance.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.fpsEmployeeWorkAttendance.Location = new System.Drawing.Point(171, 176);
            this.fpsEmployeeWorkAttendance.Name = "fpsEmployeeWorkAttendance";
            this.fpsEmployeeWorkAttendance.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																								   this.fpsEmployeeWorkAttendance_Sheet1});
            this.fpsEmployeeWorkAttendance.Size = new System.Drawing.Size(627, 211);
            this.fpsEmployeeWorkAttendance.TabIndex = 26;
            this.fpsEmployeeWorkAttendance.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsEmployeeWorkAttendance_CellDoubleClick);
            // 
            // fpsEmployeeWorkAttendance_Sheet1
            // 
            this.fpsEmployeeWorkAttendance_Sheet1.Reset();
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpsEmployeeWorkAttendance_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpsEmployeeWorkAttendance_Sheet1.ColumnCount = 9;
            this.fpsEmployeeWorkAttendance_Sheet1.ColumnHeader.RowCount = 3;
            this.fpsEmployeeWorkAttendance_Sheet1.RowCount = 1;
            this.fpsEmployeeWorkAttendance_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "วันที่";
            this.fpsEmployeeWorkAttendance_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "       ประเภท        (วันทำงาน / วันหยุด)";
            this.fpsEmployeeWorkAttendance_Sheet1.ColumnHeader.Cells.Get(0, 3).ColumnSpan = 2;
            this.fpsEmployeeWorkAttendance_Sheet1.ColumnHeader.Cells.Get(0, 3).RowSpan = 2;
            this.fpsEmployeeWorkAttendance_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "เวลาปฏิบัติงาน";
            this.fpsEmployeeWorkAttendance_Sheet1.ColumnHeader.Cells.Get(0, 5).ColumnSpan = 2;
            this.fpsEmployeeWorkAttendance_Sheet1.ColumnHeader.Cells.Get(0, 5).RowSpan = 2;
            this.fpsEmployeeWorkAttendance_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "เวลาพัก";
            this.fpsEmployeeWorkAttendance_Sheet1.ColumnHeader.Cells.Get(0, 7).ColumnSpan = 2;
            this.fpsEmployeeWorkAttendance_Sheet1.ColumnHeader.Cells.Get(0, 7).RowSpan = 2;
            this.fpsEmployeeWorkAttendance_Sheet1.ColumnHeader.Cells.Get(0, 7).Text = "สถานะปฏิบัติงาน";
            this.fpsEmployeeWorkAttendance_Sheet1.ColumnHeader.Cells.Get(1, 1).RowSpan = 2;
            this.fpsEmployeeWorkAttendance_Sheet1.ColumnHeader.Cells.Get(1, 1).Text = "วันที่";
            this.fpsEmployeeWorkAttendance_Sheet1.ColumnHeader.Cells.Get(1, 2).RowSpan = 2;
            this.fpsEmployeeWorkAttendance_Sheet1.ColumnHeader.Cells.Get(1, 2).Text = "       ประเภท        (วันทำงาน / วันหยุด)";
            this.fpsEmployeeWorkAttendance_Sheet1.ColumnHeader.Cells.Get(1, 3).Text = "ระหว่างเวลา Work During Hours";
            this.fpsEmployeeWorkAttendance_Sheet1.ColumnHeader.Cells.Get(2, 3).Text = "เวลาเข้า";
            this.fpsEmployeeWorkAttendance_Sheet1.ColumnHeader.Cells.Get(2, 4).Text = "เวลาออก";
            this.fpsEmployeeWorkAttendance_Sheet1.ColumnHeader.Cells.Get(2, 5).Text = "เริ่ม";
            this.fpsEmployeeWorkAttendance_Sheet1.ColumnHeader.Cells.Get(2, 6).Text = "สิ้นสุด";
            this.fpsEmployeeWorkAttendance_Sheet1.ColumnHeader.Cells.Get(2, 7).Text = "ครึ่งวันแรก";
            this.fpsEmployeeWorkAttendance_Sheet1.ColumnHeader.Cells.Get(2, 8).Text = "ครึ่งวันหลัง";
            this.fpsEmployeeWorkAttendance_Sheet1.ColumnHeader.Rows.Get(0).Height = 0F;
            this.fpsEmployeeWorkAttendance_Sheet1.ColumnHeader.Rows.Get(1).Height = 25F;
            this.fpsEmployeeWorkAttendance_Sheet1.ColumnHeader.Rows.Get(2).Height = 25F;
            textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType1.DropDownButton = false;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(0).Visible = false;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(1).AllowAutoSort = true;
            numberCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            numberCellType1.DecimalPlaces = 0;
            numberCellType1.DropDownButton = false;
            numberCellType1.MinimumValue = 0;
            numberCellType1.ReadOnly = true;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(1).CellType = numberCellType1;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(1).Resizable = false;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(1).Width = 50F;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(2).AllowAutoSort = true;
            textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType2.DropDownButton = false;
            textCellType2.ReadOnly = true;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(2).CellType = textCellType2;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(2).Resizable = false;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(2).Width = 100F;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(3).AllowAutoSort = true;
            textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType3.DropDownButton = false;
            textCellType3.ReadOnly = true;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(3).CellType = textCellType3;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(3).Label = "เวลาเข้า";
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(3).Resizable = false;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(3).Width = 70F;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(4).AllowAutoSort = true;
            textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType4.DropDownButton = false;
            textCellType4.ReadOnly = true;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(4).CellType = textCellType4;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(4).Label = "เวลาออก";
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(4).Resizable = false;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(4).Width = 70F;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(5).AllowAutoSort = true;
            textCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType5.DropDownButton = false;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(5).CellType = textCellType5;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(5).Label = "เริ่ม";
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(5).Resizable = false;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(5).Width = 70F;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(6).AllowAutoSort = true;
            textCellType6.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType6.DropDownButton = false;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(6).CellType = textCellType6;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(6).Label = "สิ้นสุด";
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(6).Resizable = false;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(6).Width = 70F;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(7).AllowAutoSort = true;
            textCellType7.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType7.DropDownButton = false;
            textCellType7.ReadOnly = true;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(7).CellType = textCellType7;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(7).Label = "ครึ่งวันแรก";
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(7).Resizable = false;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(7).Width = 70F;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(8).AllowAutoSort = true;
            textCellType8.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType8.DropDownButton = false;
            textCellType8.ReadOnly = true;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(8).CellType = textCellType8;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(8).Label = "ครึ่งวันหลัง";
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(8).Resizable = false;
            this.fpsEmployeeWorkAttendance_Sheet1.Columns.Get(8).Width = 70F;
            this.fpsEmployeeWorkAttendance_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
            this.fpsEmployeeWorkAttendance_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.fpsEmployeeWorkAttendance_Sheet1.RowHeader.Rows.Default.Resizable = false;
            this.fpsEmployeeWorkAttendance_Sheet1.Rows.Default.Resizable = false;
            this.fpsEmployeeWorkAttendance_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpsEmployeeWorkAttendance_Sheet1.SheetName = "Sheet1";
            this.fpsEmployeeWorkAttendance_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmEmployeeWorkAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(968, 488);
            this.Controls.Add(this.txtForget);
            this.Controls.Add(this.lblForgetDay);
            this.Controls.Add(this.lblForget);
            this.Controls.Add(this.txtHoliday);
            this.Controls.Add(this.txtLate);
            this.Controls.Add(this.lblLateDay);
            this.Controls.Add(this.lblLateCount);
            this.Controls.Add(this.lblHolidayDay);
            this.Controls.Add(this.lblHolidayCount);
            this.Controls.Add(this.dtpForMonth);
            this.Controls.Add(this.lblForMonth);
            this.Controls.Add(this.fpsEmployeeWorkAttendance);
            this.Controls.SetChildIndex(this.fpsEmployeeWorkAttendance, 0);
            this.Name = "frmEmployeeWorkAttendance";
            this.Text = "frmEmployeeWorkAttendance";
            this.Load += new System.EventHandler(this.frmEmployeeWorkAttendance_Load);
            this.Controls.SetChildIndex(this.lblForMonth, 0);
            this.Controls.SetChildIndex(this.dtpForMonth, 0);
            this.Controls.SetChildIndex(this.lblHolidayCount, 0);
            this.Controls.SetChildIndex(this.lblHolidayDay, 0);
            this.Controls.SetChildIndex(this.lblLateCount, 0);
            this.Controls.SetChildIndex(this.lblLateDay, 0);
            this.Controls.SetChildIndex(this.txtLate, 0);
            this.Controls.SetChildIndex(this.txtHoliday, 0);
            this.Controls.SetChildIndex(this.lblForget, 0);
            this.Controls.SetChildIndex(this.lblForgetDay, 0);
            this.Controls.SetChildIndex(this.txtForget, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pctEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsEmployeeWorkAttendance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsEmployeeWorkAttendance_Sheet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

		#region - Private -
		private bool isReadonly = true;
		private bool isChange = true;
		private frmEmployeeWorkAttendanceEntry frmEntry;
		#endregion

//		============================== Property ==============================		
		private EmployeeWorkAttendanceFacade facadeEmployeeWorkAttendance;
		public EmployeeWorkAttendanceFacade FacadeEmployeeWorkAttendance
		{
			get{return facadeEmployeeWorkAttendance;}
		}

		private int SelectedRow
		{
            get{return fpsEmployeeWorkAttendance_Sheet1.ActiveRowIndex;}
		}

		private string SelectedKey
		{
            get { return fpsEmployeeWorkAttendance_Sheet1.Cells[SelectedRow, 0].Text; }
		}
	
		private WorkSchedule selectedWorkSchedule
		{
			get{return facadeEmployeeWorkAttendance.ObjEmployeeWorkSchedule[SelectedKey];}
		}

		private TimeCard selectTimeCard
		{
			get{return facadeEmployeeWorkAttendance.ObjEmployeeTimeCard[SelectedKey];}
		}

//		==============================  Constructor  ==============================		
		public frmEmployeeWorkAttendance() : base()
		{
			InitializeComponent();
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miEmployeeWorkSchedule");
            this.title = UserProfile.GetFormName("miAttendance", "miEmployeeWorkSchedule");

		}
        public override string FormID()
        {
            return UserProfile.GetFormID("miAttendance", "miEmployeeWorkSchedule");
        }
//		==============================Private method ==============================
		private void bindForm()
		{
			if (facadeEmployeeWorkAttendance.ObjEmployeeWorkSchedule.Count > 0 && facadeEmployeeWorkAttendance.ObjEmployeeTimeCard.Count >0)
			{
                int iCountHoliday = 0;
				int iRow = facadeEmployeeWorkAttendance.ObjEmployeeWorkSchedule.Count;
                fpsEmployeeWorkAttendance_Sheet1.RowCount = iRow;

				for(int i=0; i<iRow; i++)
				{
					bindWorkAttendance(i, facadeEmployeeWorkAttendance.ObjEmployeeWorkSchedule[i], facadeEmployeeWorkAttendance.ObjEmployeeTimeCard[i]);

					if(facadeEmployeeWorkAttendance.ObjEmployeeWorkSchedule[i].DayType == WORKINGDAY_TYPE.HOLIDAY)
					{
                        iCountHoliday++;
					}                    
				}

                CountLate();
                txtHoliday.Text = iCountHoliday.ToString();
				mdiParent.RefreshMasterCount();
			}
            fpsEmployeeWorkAttendance_Sheet1.SetActiveCell(fpsEmployeeWorkAttendance_Sheet1.RowCount, 0);
		}
		
		private void bindWorkAttendance(int row, WorkSchedule aWorkSchedule, TimeCard aTimeCard)
		{
            fpsEmployeeWorkAttendance_Sheet1.Cells[row, 0].Text = aWorkSchedule.EntityKey;
            fpsEmployeeWorkAttendance_Sheet1.Cells[row, 1].Text = GUIFunction.GetString(aWorkSchedule.WorkDate.Day);

            if (aWorkSchedule.DayType == WORKINGDAY_TYPE.WORKINGDAY)
            {
                fpsEmployeeWorkAttendance_Sheet1.Cells[row, 2].Text = "";
            }
            else
            {
                fpsEmployeeWorkAttendance_Sheet1.Cells[row, 2].Text = GUIFunction.GetString(aWorkSchedule.DayType);
            }
            fpsEmployeeWorkAttendance_Sheet1.Cells[row, 3].Text = aWorkSchedule.AWorkingTime.From.ToString("HH : mm");
            fpsEmployeeWorkAttendance_Sheet1.Cells[row, 4].Text = aWorkSchedule.AWorkingTime.To.ToString("HH : mm");
            fpsEmployeeWorkAttendance_Sheet1.Cells[row, 5].Text = aWorkSchedule.ABreakTime.From.ToString("HH : mm");
            fpsEmployeeWorkAttendance_Sheet1.Cells[row, 6].Text = aWorkSchedule.ABreakTime.To.ToString("HH : mm");
            fpsEmployeeWorkAttendance_Sheet1.Cells[row, 7].Text = aTimeCard.ABeforeBreakStatus.AName.Thai;
            fpsEmployeeWorkAttendance_Sheet1.Cells[row, 8].Text = aTimeCard.AAfterBreakStatus.AName.Thai;
		}

		private void clearForm()
		{
			visibleForm(false);
            fpsEmployeeWorkAttendance_Sheet1.RowCount = 0;
			enableButton(false);
		}

		private bool validateWorkingStatus(TimeCard value)
		{
			string statusBefore = value.ABeforeBreakStatus.Code;
			string statusAfter = value.AAfterBreakStatus.Code;

			if	(statusBefore.Equals("A1") || statusBefore.Equals("B1") || statusBefore.Equals("P1") ||
				statusBefore.Equals("S1") || statusBefore.Equals("S2") || statusBefore.Equals("T1"))
			{
				Message(MessageList.Error.E0014, "ลบรายการที่มีสถานะปฏิบัติการนี้ได้");
				return false;
			}
			if	(statusAfter.Equals("A1") || statusAfter.Equals("B1") || statusAfter.Equals("P1") ||
				statusAfter.Equals("S1") || statusAfter.Equals("S2") || statusAfter.Equals("T1"))
			{
				Message(MessageList.Error.E0013, "ลบรายการที่มีสถานะปฏิบัติการนี้ได้");
				return false;
			}
			return true;
		}

        private void CountLate()
        {
            int iCountLate = 0, countForget = 0;

            foreach (TimeCard entity in FacadeEmployeeWorkAttendance.ObjEmployeeTimeCard)
            {
                if (entity.ABeforeBreakStatus.Code == "L1")
                {
                    iCountLate++;
                }

                if (entity.ABeforeBreakStatus.Code == "F1")
                {
                    countForget++;
                }

                if (entity.AAfterBreakStatus.Code == "F1")
                {
                    countForget++;
                }
            }

            txtLate.Text = iCountLate.ToString();
            txtForget.Text = countForget.ToString();
        }

//		==========================Public Method========================
		public bool AddRow(WorkSchedule aWorkSchedule, TimeCard aTimeCard)
		{
			if (facadeEmployeeWorkAttendance.InsertEmployeeWorkAttendance(aWorkSchedule, aTimeCard))
			{
                fpsEmployeeWorkAttendance_Sheet1.RowCount++;
                bindWorkAttendance(fpsEmployeeWorkAttendance_Sheet1.RowCount - 1, aWorkSchedule, aTimeCard);
                fpsEmployeeWorkAttendance_Sheet1.SetActiveCell(fpsEmployeeWorkAttendance_Sheet1.RowCount, 0);
                enableButton(true);
                mdiParent.RefreshMasterCount();
                CountLate();
                return true;
			}				
			return false;
		}

		public bool UpdateRow(WorkSchedule aWorkSchedule, TimeCard aTimeCard)
		{
			if (facadeEmployeeWorkAttendance.UpdateEmployeeWorkAttendance(aWorkSchedule, aTimeCard))
			{
				bindWorkAttendance(SelectedRow, aWorkSchedule, aTimeCard);
                CountLate();
                return true;
			}				
			return false;
		}

		private void DeleteRow()
		{

			if (validateWorkingStatus(selectTimeCard))
			{
				if (facadeEmployeeWorkAttendance.DeleteEmployeeWorkAttendance(selectedWorkSchedule, selectTimeCard))
				{
                    if (fpsEmployeeWorkAttendance_Sheet1.RowCount > 1)
                    {
                        fpsEmployeeWorkAttendance.ActiveSheet.Rows.Remove(SelectedRow, 1);
                    }
                    else
                    {
                        fpsEmployeeWorkAttendance_Sheet1.RowCount = 0;
                        enableButton(false);
                    }
                    mdiParent.RefreshMasterCount();
                    CountLate();
                }
			}
		}

		public override int MasterCount()
		{
			return facadeEmployeeWorkAttendance.ObjEmployeeWorkSchedule.Count;
		}

//		==============================Protected method ==============================
		protected override void enableButton(bool value)
		{
			base.enableButton(value);
			mniEdit.Enabled = value;
			mniDelete.Enabled = value;
		}

		protected override void visibleForm(bool value)
		{
			base.visibleForm(value);
            fpsEmployeeWorkAttendance.Visible = value;
			lblForMonth.Visible = value;
			dtpForMonth.Visible = value;
            txtHoliday.Visible = value;
            txtLate.Visible = value;
			lblHolidayCount.Visible = value;
			lblHolidayDay.Visible = value;
            lblLateCount.Visible = value;
            lblLateDay.Visible = value;
            lblForget.Visible = value;
            txtForget.Visible = value;
            lblForgetDay.Visible = value;
		}
		
		protected override void addEvent()
		{
			try
			{
				frmEntry = new frmEmployeeWorkAttendanceEntry(this);
				frmEntry.InitAddAction(dtpForMonth.Value);
				frmEntry.ShowDialog();
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

		protected override void editEvent()
		{
			try
			{
				frmEntry = new frmEmployeeWorkAttendanceEntry(this);
				frmEntry.InitEditAction(selectedWorkSchedule, selectTimeCard);
				frmEntry.ShowDialog();				
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
	
		protected override void deleteEvent()
		{
			try
			{
				if (Message(MessageList.Question.Q0001) == DialogResult.Yes)
				{
					DeleteRow();
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

//		============================== Base Event ==============================
		public override void InitForm()
		{
			base.InitForm();
			facadeEmployeeAttendance = new EmployeeWorkAttendanceFacade();
			facadeEmployeeWorkAttendance = (EmployeeWorkAttendanceFacade)facadeEmployeeAttendance;
			isChange = false;
			dtpForMonth.Value = new System.DateTime(DateTime.Today.Year, DateTime.Today.Month, 1, 0, 0, 0, 0);
			isChange = true;
			mdiParent.RefreshMasterCount();
		}

		public override void RefreshForm()
		{
			base.RefreshForm();

			try
			{
				if (facadeEmployeeWorkAttendance.DisplayEmployeeWorkAttendance(dtpForMonth.Value))
				{	
					enableButton(true);
					visibleForm(true);
					bindForm();
				}
				else
				{
					visibleForm(true);
                    fpsEmployeeWorkAttendance_Sheet1.RowCount = 0;
					enableButton(false);
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

			if(isReadonly)
			{
				base.setPermission(false);
				mniAdd.Enabled = false;
				mniDelete.Enabled = false;
			}
		}


//		============================== event ==============================
		private void frmEmployeeWorkAttendance_Load(object sender, System.EventArgs e)
		{
			InitForm();
		}

		private void mniAdd_Click(object sender, System.EventArgs e)
		{
			addEvent();
		}

		private void mniEdit_Click(object sender, System.EventArgs e)
		{
			editEvent();		
		}

		private void mniDelete_Click(object sender, System.EventArgs e)
		{
			deleteEvent();		
		}

        private void fpsEmployeeWorkAttendance_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (!e.ColumnHeader)
            {
                editEvent();
            }
        }

		private void dtpForMonth_ValueChanged(object sender, System.EventArgs e)
		{
			if(isChange)
			{
				RefreshForm();
			}
		}
	}
}
