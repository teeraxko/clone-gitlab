using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using SystemFramework.AppMessage;
using SystemFramework.AppException;
using SystemFramework.AppConfig;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using ictus.Common.Entity.Time;
using ictus.PIS.PI.Entity;

using Facade.CommonFacade;
using Facade.AttendanceFacade;

using Presentation.CommonGUI;
using Presentation.PiGUI;

namespace Presentation.AttendanceGUI
{
	public class frmEmployeeBenefitAdjustment : ChildFormBase, IMDIChildForm
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
        private System.Windows.Forms.DateTimePicker dtpForMonth;
        private FarPoint.Win.Spread.FpSpread fpsBenefitAdjustment;
        private FarPoint.Win.Spread.SheetView fpsBenefitAdjustment_Sheet1;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Label lblForMonth;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem mniAdd;
        private System.Windows.Forms.MenuItem mniEdit;
        private System.Windows.Forms.MenuItem mniDelete;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.GroupBox groupBox1;

        private System.ComponentModel.Container components = null;

        private void InitializeComponent()
        {
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType5 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType6 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType7 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType8 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType9 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType10 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType11 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType12 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType13 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.dtpForMonth = new System.Windows.Forms.DateTimePicker();
            this.lblForMonth = new System.Windows.Forms.Label();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.fpsBenefitAdjustment = new FarPoint.Win.Spread.FpSpread();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.mniAdd = new System.Windows.Forms.MenuItem();
            this.mniEdit = new System.Windows.Forms.MenuItem();
            this.mniDelete = new System.Windows.Forms.MenuItem();
            this.fpsBenefitAdjustment_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.fpsBenefitAdjustment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsBenefitAdjustment_Sheet1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpForMonth
            // 
            this.dtpForMonth.CustomFormat = "MM/yyyy";
            this.dtpForMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpForMonth.Location = new System.Drawing.Point(96, 22);
            this.dtpForMonth.Name = "dtpForMonth";
            this.dtpForMonth.Size = new System.Drawing.Size(80, 20);
            this.dtpForMonth.TabIndex = 1;
            this.dtpForMonth.ValueChanged += new System.EventHandler(this.dtpForMonth_ValueChanged);
            // 
            // lblForMonth
            // 
            this.lblForMonth.Location = new System.Drawing.Point(24, 24);
            this.lblForMonth.Name = "lblForMonth";
            this.lblForMonth.Size = new System.Drawing.Size(64, 16);
            this.lblForMonth.TabIndex = 99;
            this.lblForMonth.Text = "สำหรับเดือน";
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdAdd.Location = new System.Drawing.Point(389, 264);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.TabIndex = 2;
            this.cmdAdd.Text = "เพิ่ม";
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdEdit.Location = new System.Drawing.Point(477, 264);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.TabIndex = 3;
            this.cmdEdit.Text = "แก้ไข";
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // fpsBenefitAdjustment
            // 
            this.fpsBenefitAdjustment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.fpsBenefitAdjustment.ContextMenu = this.contextMenu1;
            this.fpsBenefitAdjustment.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.fpsBenefitAdjustment.Location = new System.Drawing.Point(16, 72);
            this.fpsBenefitAdjustment.Name = "fpsBenefitAdjustment";
            this.fpsBenefitAdjustment.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																							  this.fpsBenefitAdjustment_Sheet1});
            this.fpsBenefitAdjustment.Size = new System.Drawing.Size(996, 176);
            this.fpsBenefitAdjustment.TabIndex = 40;
            this.fpsBenefitAdjustment.TabStop = false;
            this.fpsBenefitAdjustment.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsBenefitAdjustment_CellDoubleClick);
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
            // fpsBenefitAdjustment_Sheet1
            // 
            this.fpsBenefitAdjustment_Sheet1.Reset();
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpsBenefitAdjustment_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpsBenefitAdjustment_Sheet1.ColumnCount = 16;
            this.fpsBenefitAdjustment_Sheet1.ColumnHeader.RowCount = 2;
            this.fpsBenefitAdjustment_Sheet1.RowCount = 1;
            this.fpsBenefitAdjustment_Sheet1.ColumnHeader.Cells.Get(0, 1).RowSpan = 2;
            this.fpsBenefitAdjustment_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "รหัส";
            this.fpsBenefitAdjustment_Sheet1.ColumnHeader.Cells.Get(0, 2).RowSpan = 2;
            this.fpsBenefitAdjustment_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "ชื่อ - สกุล";
            this.fpsBenefitAdjustment_Sheet1.ColumnHeader.Cells.Get(0, 3).ColumnSpan = 3;
            this.fpsBenefitAdjustment_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ค่าลวงเวลา";
            this.fpsBenefitAdjustment_Sheet1.ColumnHeader.Cells.Get(0, 6).RowSpan = 2;
            this.fpsBenefitAdjustment_Sheet1.ColumnHeader.Cells.Get(0, 6).Text = "ค่า Taxi";
            this.fpsBenefitAdjustment_Sheet1.ColumnHeader.Cells.Get(0, 7).RowSpan = 2;
            this.fpsBenefitAdjustment_Sheet1.ColumnHeader.Cells.Get(0, 7).Text = "เบี้ยขยัน";
            this.fpsBenefitAdjustment_Sheet1.ColumnHeader.Cells.Get(0, 8).ColumnSpan = 3;
            this.fpsBenefitAdjustment_Sheet1.ColumnHeader.Cells.Get(0, 8).Text = "ค่าเดินทาง";
            this.fpsBenefitAdjustment_Sheet1.ColumnHeader.Cells.Get(0, 11).RowSpan = 2;
            this.fpsBenefitAdjustment_Sheet1.ColumnHeader.Cells.Get(0, 11).Text = "ค่าอาหาร";
            this.fpsBenefitAdjustment_Sheet1.ColumnHeader.Cells.Get(0, 12).ColumnSpan = 2;
            this.fpsBenefitAdjustment_Sheet1.ColumnHeader.Cells.Get(0, 12).Text = "AGT";
            this.fpsBenefitAdjustment_Sheet1.ColumnHeader.Cells.Get(0, 13).Text = "เพิ่ม AGT";
            this.fpsBenefitAdjustment_Sheet1.ColumnHeader.Cells.Get(0, 14).RowSpan = 2;
            this.fpsBenefitAdjustment_Sheet1.ColumnHeader.Cells.Get(0, 14).Text = "ค่าโทรศัพท์";
            this.fpsBenefitAdjustment_Sheet1.ColumnHeader.Cells.Get(0, 15).RowSpan = 2;
            this.fpsBenefitAdjustment_Sheet1.ColumnHeader.Cells.Get(0, 15).Text = "ค่าอื่น ๆ";
            this.fpsBenefitAdjustment_Sheet1.ColumnHeader.Cells.Get(1, 3).Text = "A";
            this.fpsBenefitAdjustment_Sheet1.ColumnHeader.Cells.Get(1, 4).Text = "B";
            this.fpsBenefitAdjustment_Sheet1.ColumnHeader.Cells.Get(1, 5).Text = "C";
            this.fpsBenefitAdjustment_Sheet1.ColumnHeader.Cells.Get(1, 8).Text = "ใกล้";
            this.fpsBenefitAdjustment_Sheet1.ColumnHeader.Cells.Get(1, 9).Text = "ไกล";
            this.fpsBenefitAdjustment_Sheet1.ColumnHeader.Cells.Get(1, 10).Text = "ค้างคืน";
            this.fpsBenefitAdjustment_Sheet1.ColumnHeader.Cells.Get(1, 12).Text = "เพิ่ม";
            this.fpsBenefitAdjustment_Sheet1.ColumnHeader.Cells.Get(1, 13).Text = "เบี้ยขยัน ";
            textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType1.DropDownButton = false;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(0).Visible = false;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(1).AllowAutoSort = true;
            textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType2.DropDownButton = false;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(1).CellType = textCellType2;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(1).Resizable = false;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(2).AllowAutoSort = true;
            textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType3.DropDownButton = false;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(2).CellType = textCellType3;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(2).Resizable = false;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(2).Width = 230F;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(3).AllowAutoSort = true;
            numberCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            numberCellType1.DecimalPlaces = 2;
            numberCellType1.DecimalSeparator = ".";
            numberCellType1.DropDownButton = false;
            numberCellType1.MinimumValue = 0;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(3).CellType = numberCellType1;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(3).Label = "A";
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(3).Resizable = false;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(3).Width = 50F;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(4).AllowAutoSort = true;
            numberCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            numberCellType2.DecimalPlaces = 2;
            numberCellType2.DecimalSeparator = ".";
            numberCellType2.DropDownButton = false;
            numberCellType2.MinimumValue = 0;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(4).CellType = numberCellType2;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(4).Label = "B";
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(4).Resizable = false;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(4).Width = 50F;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(5).AllowAutoSort = true;
            numberCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            numberCellType3.DecimalPlaces = 2;
            numberCellType3.DecimalSeparator = ".";
            numberCellType3.DropDownButton = false;
            numberCellType3.MinimumValue = 0;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(5).CellType = numberCellType3;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(5).Label = "C";
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(5).Resizable = false;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(5).Width = 50F;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(6).AllowAutoSort = true;
            numberCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            numberCellType4.DecimalPlaces = 0;
            numberCellType4.DropDownButton = false;
            numberCellType4.MinimumValue = 0;
            numberCellType4.Separator = ",";
            numberCellType4.ShowSeparator = true;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(6).CellType = numberCellType4;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(6).Resizable = false;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(6).Width = 50F;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(7).AllowAutoSort = true;
            numberCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            numberCellType5.DecimalPlaces = 0;
            numberCellType5.DropDownButton = false;
            numberCellType5.MinimumValue = 0;
            numberCellType5.Separator = ",";
            numberCellType5.ShowSeparator = true;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(7).CellType = numberCellType5;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(7).Resizable = false;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(7).Width = 50F;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(8).AllowAutoSort = true;
            numberCellType6.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            numberCellType6.DecimalPlaces = 0;
            numberCellType6.DropDownButton = false;
            numberCellType6.MinimumValue = 0;
            numberCellType6.Separator = ",";
            numberCellType6.ShowSeparator = true;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(8).CellType = numberCellType6;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(8).Label = "ใกล้";
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(8).Resizable = false;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(8).Width = 50F;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(9).AllowAutoSort = true;
            numberCellType7.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            numberCellType7.DecimalPlaces = 0;
            numberCellType7.DropDownButton = false;
            numberCellType7.MinimumValue = 0;
            numberCellType7.Separator = ",";
            numberCellType7.ShowSeparator = true;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(9).CellType = numberCellType7;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(9).Label = "ไกล";
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(9).Resizable = false;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(9).Width = 50F;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(10).AllowAutoSort = true;
            numberCellType8.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            numberCellType8.DecimalPlaces = 0;
            numberCellType8.DropDownButton = false;
            numberCellType8.MinimumValue = 0;
            numberCellType8.Separator = ",";
            numberCellType8.ShowSeparator = true;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(10).CellType = numberCellType8;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(10).Label = "ค้างคืน";
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(10).Resizable = false;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(10).Width = 50F;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(11).AllowAutoSort = true;
            numberCellType9.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            numberCellType9.DecimalPlaces = 0;
            numberCellType9.DropDownButton = false;
            numberCellType9.MinimumValue = 0;
            numberCellType9.Separator = ",";
            numberCellType9.ShowSeparator = true;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(11).CellType = numberCellType9;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(11).Resizable = false;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(11).Width = 50F;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(12).AllowAutoSort = true;
            numberCellType10.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            numberCellType10.DecimalPlaces = 0;
            numberCellType10.DropDownButton = false;
            numberCellType10.MinimumValue = 0;
            numberCellType10.Separator = ",";
            numberCellType10.ShowSeparator = true;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(12).CellType = numberCellType10;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(12).Label = "เพิ่ม";
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(12).Resizable = false;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(12).Width = 50F;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(13).AllowAutoSort = true;
            numberCellType11.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            numberCellType11.DecimalPlaces = 0;
            numberCellType11.DropDownButton = false;
            numberCellType11.MinimumValue = 0;
            numberCellType11.Separator = ",";
            numberCellType11.ShowSeparator = true;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(13).CellType = numberCellType11;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(13).Label = "เบี้ยขยัน ";
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(13).Resizable = false;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(13).Width = 50F;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(14).AllowAutoSort = true;
            numberCellType12.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            numberCellType12.DecimalPlaces = 0;
            numberCellType12.DropDownButton = false;
            numberCellType12.MinimumValue = 0;
            numberCellType12.Separator = ",";
            numberCellType12.ShowSeparator = true;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(14).CellType = numberCellType12;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(14).Resizable = false;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(14).Width = 50F;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(15).AllowAutoSort = true;
            numberCellType13.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            numberCellType13.DecimalPlaces = 0;
            numberCellType13.DropDownButton = false;
            numberCellType13.MinimumValue = 0;
            numberCellType13.Separator = ",";
            numberCellType13.ShowSeparator = true;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(15).CellType = numberCellType13;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(15).Resizable = false;
            this.fpsBenefitAdjustment_Sheet1.Columns.Get(15).Width = 50F;
            this.fpsBenefitAdjustment_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
            this.fpsBenefitAdjustment_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpsBenefitAdjustment_Sheet1.RowHeader.Rows.Default.Resizable = false;
            this.fpsBenefitAdjustment_Sheet1.Rows.Default.Resizable = false;
            this.fpsBenefitAdjustment_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpsBenefitAdjustment_Sheet1.SheetName = "Sheet1";
            this.fpsBenefitAdjustment_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdDelete.Location = new System.Drawing.Point(565, 264);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.TabIndex = 4;
            this.cmdDelete.Text = "ลบ";
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.lblForMonth);
            this.groupBox1.Controls.Add(this.dtpForMonth);
            this.groupBox1.Location = new System.Drawing.Point(16, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 56);
            this.groupBox1.TabIndex = 100;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "เงื่อนไขการแสดงข้อมูล";
            // 
            // frmEmployeeBenefitAdjustment
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1028, 304);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.fpsBenefitAdjustment);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmEmployeeBenefitAdjustment";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmEmployeeBenefitAdjustment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fpsBenefitAdjustment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsBenefitAdjustment_Sheet1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

		#region - Private -
		private bool isReadonly = true;
		private bool isTextChange = true;
		private frmEmployeeBenefitAdjustmentEntry frmEntry;
		private frmMain mdiParent;
		#endregion

//		============================== Property ==============================		
		private EmployeeBenefitAdjustmentFacade facadeEmployeeBenefitAdjustment;
		public EmployeeBenefitAdjustmentFacade FacadeEmployeeBenefitAdjustment
		{
			get{return facadeEmployeeBenefitAdjustment;}
		}

		private int SelectedRow
		{
			get{return fpsBenefitAdjustment_Sheet1.ActiveRowIndex;}
		}

		private string SelectedKey
		{
			get{return fpsBenefitAdjustment_Sheet1.Cells[SelectedRow,0].Text;}
		}
	
		private BenefitAdjustment selectedBenefitAdjustment
		{
			get{return facadeEmployeeBenefitAdjustment.ObjEmployeeBenefitAdjustment[SelectedKey];}
		}

//		============================== Constructor ==============================
		public frmEmployeeBenefitAdjustment() : base()
		{
			InitializeComponent();
			newObject();
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miBenefitAdjustment");
            this.title = UserProfile.GetFormName("miAttendance", "miBenefitAdjustment");

		}
        public override string FormID()
        {
            return UserProfile.GetFormID("miAttendance", "miBenefitAdjustment");
        }

//		==============================Private method ==============================
		private void newObject()
		{
			facadeEmployeeBenefitAdjustment = new EmployeeBenefitAdjustmentFacade();
			frmEntry = new frmEmployeeBenefitAdjustmentEntry(this);		
		}

		private void bindForm()
		{
			if (facadeEmployeeBenefitAdjustment.ObjEmployeeBenefitAdjustment != null)
			{
				int iRow = facadeEmployeeBenefitAdjustment.ObjEmployeeBenefitAdjustment.Count;
				fpsBenefitAdjustment_Sheet1.RowCount = iRow;
				for(int i=0; i<iRow; i++)
				{
					bindBenefitAdjustment(i, facadeEmployeeBenefitAdjustment.ObjEmployeeBenefitAdjustment[i]);
				}				
			}
            fpsBenefitAdjustment_Sheet1.SetActiveCell(fpsBenefitAdjustment_Sheet1.RowCount, 0);
		}
		
		private void bindBenefitAdjustment(int row, BenefitAdjustment value)
		{
            fpsBenefitAdjustment_Sheet1.Cells.Get(row, 0).Text = value.EntityKey;
            fpsBenefitAdjustment_Sheet1.Cells.Get(row, 1).Text = value.AEmployee.EmployeeNo.ToString();
            fpsBenefitAdjustment_Sheet1.Cells.Get(row, 2).Text = value.AEmployee.EmployeeName.ToString();
            fpsBenefitAdjustment_Sheet1.Cells.Get(row, 3).Text = value.OTAHour.ToString();
            fpsBenefitAdjustment_Sheet1.Cells.Get(row, 4).Text = value.OTBHour.ToString();
            fpsBenefitAdjustment_Sheet1.Cells.Get(row, 5).Text = value.OTCHour.ToString();
            fpsBenefitAdjustment_Sheet1.Cells.Get(row, 6).Text = value.TaxiAmount.ToString();
            fpsBenefitAdjustment_Sheet1.Cells.Get(row, 7).Text = value.ExtraAmount.ToString();
            fpsBenefitAdjustment_Sheet1.Cells.Get(row, 8).Text = value.OneDayTripNearAmount.ToString();
            fpsBenefitAdjustment_Sheet1.Cells.Get(row, 9).Text = value.OneDayTripFarAmount.ToString();
            fpsBenefitAdjustment_Sheet1.Cells.Get(row, 10).Text = value.OvernightTripAmount.ToString();
            fpsBenefitAdjustment_Sheet1.Cells.Get(row, 11).Text = value.FoodAmount.ToString();
            fpsBenefitAdjustment_Sheet1.Cells.Get(row, 12).Text = value.AddAGTAmount.ToString();
            fpsBenefitAdjustment_Sheet1.Cells.Get(row, 13).Text = value.ExtraAGTAmount.ToString();
            fpsBenefitAdjustment_Sheet1.Cells.Get(row, 14).Text = value.TelephoneAmount.ToString();
            fpsBenefitAdjustment_Sheet1.Cells.Get(row, 15).Text = value.MiscAmount.ToString();


            //fpsBenefitAdjustment_Sheet1.Cells.Get(row, 20).Text = value.MiscAmountForCharge.ToString();
            //fpsBenefitAdjustment_Sheet1.Cells.Get(row, 7).Text = value.TaxiAmountForCharge.ToString();
            //fpsBenefitAdjustment_Sheet1.Cells.Get(row, 10).Text = value.OneDayTripNearAmountForCharge.ToString();
            //fpsBenefitAdjustment_Sheet1.Cells.Get(row, 12).Text = value.OneDayTripFarAmountForCharge.ToString();
            //fpsBenefitAdjustment_Sheet1.Cells.Get(row, 14).Text = value.OvernightTripAmountForCharge.ToString();
        }

		private void enableButton(bool enable)
		{
			mniEdit.Enabled = enable;
			cmdEdit.Enabled = enable;
			mniDelete.Enabled = enable;
			cmdDelete.Enabled = enable;
		}

		private void clearForm()
		{
			fpsBenefitAdjustment_Sheet1.RowCount = 0;
			enableButton(false);
		}

//		==========================Public Method========================
		public bool AddRow(BenefitAdjustment value)
		{
			value.AYearMonth = new YearMonth(dtpForMonth.Value);
			if (facadeEmployeeBenefitAdjustment.InsertBenefitAdjustment(value))
			{
				fpsBenefitAdjustment_Sheet1.RowCount++;
				bindBenefitAdjustment(fpsBenefitAdjustment_Sheet1.RowCount-1, value);
                fpsBenefitAdjustment_Sheet1.SetActiveCell(fpsBenefitAdjustment_Sheet1.RowCount, 0);
				enableButton(true);
				mdiParent.RefreshMasterCount();
				return true;
			}				
			return false;
		}

		public bool UpdateRow(BenefitAdjustment value)
		{
			value.AYearMonth = new YearMonth(dtpForMonth.Value);
			if (facadeEmployeeBenefitAdjustment.UpdateBenefitAdjustment(value))
			{
				bindBenefitAdjustment(SelectedRow, value);				
				return true;
			}				
			return false;
		}

		private void DeleteRow()
		{
			if (facadeEmployeeBenefitAdjustment.DeleteBenefitAdjustment(selectedBenefitAdjustment))
			{
				if(fpsBenefitAdjustment_Sheet1.RowCount > 1)
				{
					fpsBenefitAdjustment.ActiveSheet.Rows.Remove(SelectedRow,1);
				}
				else
				{
					fpsBenefitAdjustment_Sheet1.RowCount = 0;
					enableButton(false);
				}			
	
				mdiParent.RefreshMasterCount();
			}
		}

		public override int MasterCount()
		{
			return facadeEmployeeBenefitAdjustment.ObjEmployeeBenefitAdjustment.Count;
		}

//		============================== Base Event ==============================
		public void InitForm()
		{
			newObject();
			dtpForMonth.Value = new System.DateTime(DateTime.Today.Year, DateTime.Today.Month, 1, 0, 0, 0, 0);

			MainMenuNewStatus = false;
			MainMenuDeleteStatus = false;
			MainMenuRefreshStatus = true;
			MainMenuPrintStatus = true;
			mdiParent.EnableNewCommand(false);
			mdiParent.EnableDeleteCommand(false);
			mdiParent.EnableRefreshCommand(true);
			mdiParent.EnablePrintCommand(true);
			RefreshForm();
		}

		public void RefreshForm()
		{
			try
			{
				if (facadeEmployeeBenefitAdjustment.DisplayEmployeeBenefitAdjustment(dtpForMonth.Value))
				{	
					enableButton(true);
					bindForm();
					MainMenuPrintStatus = true;
					mdiParent.EnablePrintCommand(true);
				}
				else
				{
					fpsBenefitAdjustment_Sheet1.RowCount = 0;
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
				cmdAdd.Enabled = false;
				mniAdd.Enabled = false;
				cmdDelete.Enabled = false;
				mniDelete.Enabled = false;
			}
		}

		public void PrintForm()
		{
			frmListofEmployeeBenefitAdjustment formReport = new frmListofEmployeeBenefitAdjustment ();
			formReport.Text = "รายงานเงินขาดเงินเกินตามพนักงานประจำเดือน";
			formReport.SelectedDate = dtpForMonth.Value;
			formReport.ShowDialog();
		}

		public void ExitForm()
		{
			Dispose(true);
		}

		private void addEvent()
		{
			try
			{
				frmEntry = new frmEmployeeBenefitAdjustmentEntry(this);
				frmEntry.InitAddAction();
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

		private void editEvent()
		{
			try
			{
				frmEntry = new frmEmployeeBenefitAdjustmentEntry(this);
				frmEntry.InitEditAction(selectedBenefitAdjustment);
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
	
		private void deleteEvent()
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

//		============================== event ==============================
		private void frmEmployeeBenefitAdjustment_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
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

		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
			addEvent();
		}

		private void cmdEdit_Click(object sender, System.EventArgs e)
		{
			editEvent();
		}

		private void cmdDelete_Click(object sender, System.EventArgs e)
		{
			deleteEvent();
		}

		private void dtpForMonth_ValueChanged(object sender, System.EventArgs e)
		{
			if(isTextChange)
			{
				RefreshForm();
			}
		}

		private void fpsBenefitAdjustment_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader)
			{
				editEvent();
			}
		}
	}
}
