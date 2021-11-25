using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using Entity.CommonEntity;
using Entity.VehicleEntities;
using Entity.ContractEntities;

using Facade.CommonFacade;
using Facade.VehicleFacade;

using Presentation.CommonGUI;

using SystemFramework.AppException;
using SystemFramework.AppMessage;
using SystemFramework.AppConfig;

using ictus.Common.Entity.Time;

namespace Presentation.VehicleGUI
{
	public class frmCompulsoryInsuranceByMonth : ChildFormBase, IMDIChildForm
	{
        #region Windows Form Designer generated code
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpYearMonth;
        private FarPoint.Win.Spread.FpSpread fpsfrmCompulsoryInsuranceByMonth;
        private FarPoint.Win.Spread.SheetView fpsfrmCompulsoryInsuranceByMonth_Sheet1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCompulsory;
        private System.ComponentModel.Container components = null;

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
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmCompulsoryInsuranceByMonth));
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType2 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType7 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType8 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType9 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType10 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType3 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType11 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType12 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType13 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpYearMonth = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.fpsfrmCompulsoryInsuranceByMonth = new FarPoint.Win.Spread.FpSpread();
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCompulsory = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpsfrmCompulsoryInsuranceByMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsfrmCompulsoryInsuranceByMonth_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.dtpYearMonth);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(952, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "เรียกดูข้อมูลพ.ร.บ.ที่จะหมดอายุ";
            // 
            // dtpYearMonth
            // 
            this.dtpYearMonth.CustomFormat = "MM/yyyy";
            this.dtpYearMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpYearMonth.Location = new System.Drawing.Point(128, 24);
            this.dtpYearMonth.Name = "dtpYearMonth";
            this.dtpYearMonth.Size = new System.Drawing.Size(72, 20);
            this.dtpYearMonth.TabIndex = 1;
            this.dtpYearMonth.Value = new System.DateTime(2005, 8, 1, 0, 0, 0, 0);
            this.dtpYearMonth.ValueChanged += new System.EventHandler(this.dtpYearMonth_ValueChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "เดือน/ปีที่จะหมดอายุ";
            // 
            // fpsfrmCompulsoryInsuranceByMonth
            // 
            this.fpsfrmCompulsoryInsuranceByMonth.AllowDragFill = true;
            this.fpsfrmCompulsoryInsuranceByMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.fpsfrmCompulsoryInsuranceByMonth.EditModePermanent = true;
            this.fpsfrmCompulsoryInsuranceByMonth.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.fpsfrmCompulsoryInsuranceByMonth.Location = new System.Drawing.Point(8, 72);
            this.fpsfrmCompulsoryInsuranceByMonth.Name = "fpsfrmCompulsoryInsuranceByMonth";
            this.fpsfrmCompulsoryInsuranceByMonth.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.fpsfrmCompulsoryInsuranceByMonth.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																										  this.fpsfrmCompulsoryInsuranceByMonth_Sheet1});
            this.fpsfrmCompulsoryInsuranceByMonth.Size = new System.Drawing.Size(952, 240);
            this.fpsfrmCompulsoryInsuranceByMonth.TabIndex = 1;
            this.fpsfrmCompulsoryInsuranceByMonth.TabStop = false;
            this.fpsfrmCompulsoryInsuranceByMonth.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fpsfrmCompulsoryInsuranceByMonth_KeyUp);
            this.fpsfrmCompulsoryInsuranceByMonth.LeaveCell += new FarPoint.Win.Spread.LeaveCellEventHandler(this.fpsfrmCompulsoryInsuranceByMonth_LeaveCell);
            // 
            // fpsfrmCompulsoryInsuranceByMonth_Sheet1
            // 
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Reset();
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.ColumnCount = 10;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.ColumnHeader.RowCount = 2;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.RowCount = 1;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.ColumnHeader.Cells.Get(0, 1).RowSpan = 2;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "กำหนดชำระปีนี้";
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.ColumnHeader.Cells.Get(0, 2).RowSpan = 2;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "กำหนดชำระปีหน้า";

            //User request to chage text format : Woranai 2009-07-20
            //this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.ColumnHeader.Cells.Get(0, 3).ColumnSpan = 3;

            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.ColumnHeader.Cells.Get(0, 3).RowSpan = 2;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "เลข พ.ร.บ. ใหม่";

            //User request to chage text format : Woranai 2009-07-20
            //textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            //textCellType1.DropDownButton = false;
            //this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.ColumnHeader.Cells.Get(0, 5).CellType = textCellType1;

            textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType2.DropDownButton = false;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.ColumnHeader.Cells.Get(0, 4).CellType = textCellType2;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.ColumnHeader.Cells.Get(0, 4).RowSpan = 2;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "เลขที่ใบกำกับภาษี";
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.ColumnHeader.Cells.Get(0, 5).RowSpan = 2;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "วันที่ใบกำกับภาษี";
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.ColumnHeader.Cells.Get(0, 6).RowSpan = 2;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.ColumnHeader.Cells.Get(0, 6).Text = "ทะเบียนรถ";
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.ColumnHeader.Cells.Get(0, 7).RowSpan = 2;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.ColumnHeader.Cells.Get(0, 7).Text = "ยี่ห้อรถ";
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.ColumnHeader.Cells.Get(0, 8).RowSpan = 2;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.ColumnHeader.Cells.Get(0, 8).Text = "ลูกค้า";
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.ColumnHeader.Cells.Get(0, 9).Text = "ค่าพ.ร.บ.";
            textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType3.DropDownButton = false;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.ColumnHeader.Cells.Get(1, 3).CellType = textCellType3;

            //User request to chage text format : Woranai 2009-07-20
            //textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            //textCellType4.DropDownButton = false;
            //this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.ColumnHeader.Cells.Get(1, 4).CellType = textCellType4;
            //textCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            //textCellType5.DropDownButton = false;
            //this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.ColumnHeader.Cells.Get(1, 5).CellType = textCellType5;

            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.ColumnHeader.Cells.Get(1, 7).Text = "H";
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.ColumnHeader.Cells.Get(1, 8).Text = "ลูกค้า";
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.ColumnHeader.Cells.Get(1, 9).Text = "(Total Premium)";
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.ColumnHeader.Columns.Default.Resizable = false;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Default.Resizable = false;
            textCellType6.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType6.DropDownButton = false;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(0).CellType = textCellType6;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(0).Visible = false;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(1).AllowAutoSort = true;
            dateTimeCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            dateTimeCellType1.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
            dateTimeCellType1.DateDefault = new System.DateTime(2005, 10, 19, 9, 39, 1, 0);
            dateTimeCellType1.DropDownButton = false;
            dateTimeCellType1.TimeDefault = new System.DateTime(2005, 10, 19, 9, 39, 1, 0);
            dateTimeCellType1.UserDefinedFormat = "dd/MM/yyyy";
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(1).CellType = dateTimeCellType1;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(1).Locked = false;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(1).Width = 85F;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(2).AllowAutoSort = true;
            dateTimeCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            dateTimeCellType2.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
            dateTimeCellType2.DateDefault = new System.DateTime(2005, 10, 19, 9, 39, 31, 0);
            dateTimeCellType2.DropDownButton = false;
            dateTimeCellType2.TimeDefault = new System.DateTime(2005, 10, 19, 9, 39, 31, 0);
            dateTimeCellType2.UserDefinedFormat = "dd/MM/yyyy";
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(2).CellType = dateTimeCellType2;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(2).Locked = false;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(2).Width = 85F;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(3).AllowAutoSort = true;
            textCellType7.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType7.DropDownButton = false;
            textCellType7.MaxLength = 25;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(3).CellType = textCellType7;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(3).Width = 160F;

            //User request to chage text format : Woranai 2009-07-20
            //this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(4).AllowAutoSort = true;
            //textCellType8.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            //textCellType8.DropDownButton = false;
            //textCellType8.MaxLength = 6;
            //this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(4).CellType = textCellType8;
            //this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            //this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(4).Width = 50F;
            //this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(5).AllowAutoSort = true;
            //textCellType9.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            //textCellType9.DropDownButton = false;
            //textCellType9.MaxLength = 2;
            //this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(5).CellType = textCellType9;
            //this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            //this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(5).Locked = false;
            //this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            //this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(5).Width = 30F;

            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(4).AllowAutoSort = true;
            textCellType10.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType10.DropDownButton = false;
            textCellType10.MaxLength = 20;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(4).CellType = textCellType10;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(4).Width = 140F;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(5).AllowAutoSort = true;
            dateTimeCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            dateTimeCellType3.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
            dateTimeCellType3.DateDefault = new System.DateTime(2006, 9, 14, 17, 11, 58, 0);
            dateTimeCellType3.DropDownButton = false;
            dateTimeCellType3.TimeDefault = new System.DateTime(2006, 9, 14, 17, 11, 58, 0);
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(5).CellType = dateTimeCellType3;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(5).Width = 100F;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(6).AllowAutoSort = true;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(6).BackColor = System.Drawing.Color.MistyRose;
            textCellType11.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType11.DropDownButton = false;
            textCellType11.ReadOnly = true;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(6).CellType = textCellType11;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(6).Locked = true;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(6).Width = 70F;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(7).AllowAutoSort = true;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(7).BackColor = System.Drawing.Color.MistyRose;
            textCellType12.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType12.DropDownButton = false;
            textCellType12.ReadOnly = true;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(7).CellType = textCellType12;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(7).Label = "H";
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(7).Locked = true;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(7).Width = 70F;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(8).AllowAutoSort = true;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(8).BackColor = System.Drawing.Color.MistyRose;
            textCellType13.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType13.DropDownButton = false;
            textCellType13.ReadOnly = true;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(8).CellType = textCellType13;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(8).Label = "ลูกค้า";
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(8).Locked = true;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(8).Width = 95F;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(9).AllowAutoSort = true;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(9).BackColor = System.Drawing.Color.MistyRose;
            numberCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            numberCellType1.DecimalPlaces = 2;
            numberCellType1.DecimalSeparator = ".";
            numberCellType1.DropDownButton = false;
            numberCellType1.ReadOnly = true;
            numberCellType1.Separator = ",";
            numberCellType1.ShowSeparator = true;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(9).CellType = numberCellType1;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(9).Label = "(Total Premium)";
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(9).Locked = true;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.Columns.Get(9).Width = 90F;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.SheetName = "Sheet1";
            this.fpsfrmCompulsoryInsuranceByMonth_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.Location = new System.Drawing.Point(487, 328);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCompulsory
            // 
            this.btnCompulsory.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCompulsory.Enabled = false;
            this.btnCompulsory.Location = new System.Drawing.Point(407, 328);
            this.btnCompulsory.Name = "btnCompulsory";
            this.btnCompulsory.TabIndex = 9;
            this.btnCompulsory.Text = "ต่อ พ.ร.บ.";
            this.btnCompulsory.Click += new System.EventHandler(this.btnCompulsory_Click);
            // 
            // frmCompulsoryInsuranceByMonth
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(968, 366);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCompulsory);
            this.Controls.Add(this.fpsfrmCompulsoryInsuranceByMonth);
            this.Name = "frmCompulsoryInsuranceByMonth";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCompulsoryInsuranceByMonth_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpsfrmCompulsoryInsuranceByMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsfrmCompulsoryInsuranceByMonth_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

		#region Private Variable
        private YearMonth selectYearMonth;
        private bool isReadonly = true;
		private CompulsoryInsuranceByMonthFacade facadeCompulsoryInsuranceByMonth;
		private frmMain mdiParent;
        private CompulsoryDocNoBase compulsoryBase;

        private int SelectedRow
        {
            get { return fpsfrmCompulsoryInsuranceByMonth_Sheet1.ActiveRowIndex; }
        }
		#endregion

        #region Contructor
		public frmCompulsoryInsuranceByMonth() : base()
		{
			InitializeComponent();
			facadeCompulsoryInsuranceByMonth = new CompulsoryInsuranceByMonthFacade();
            compulsoryBase = ObjectCreater.CreateCompulsoryDocNo();
			isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleDocumentCompulsoryMonth");
            this.title = UserProfile.GetFormName("miVehicle", "miVehicleDocumentCompulsoryMonth");

		}
	    #endregion        

        #region Private Method
        private string getCompulsoryNo(int row)
        {
            //return compulsoryBase.GetCompulsoryNo(fpsfrmCompulsoryInsuranceByMonth_Sheet1.Cells[row, 3].Text, fpsfrmCompulsoryInsuranceByMonth_Sheet1.Cells[row, 4].Text, fpsfrmCompulsoryInsuranceByMonth_Sheet1.Cells[row, 5].Text);
            return fpsfrmCompulsoryInsuranceByMonth_Sheet1.Cells[row, 3].Text.Trim();
        }

        //User request to chage text format : Woranai 2009-07-20
        //private string getTaxInvoiceNo(int row)
        //{
        //    return compulsoryBase.GetTaxInvoiceNo(fpsfrmCompulsoryInsuranceByMonth_Sheet1.Cells[row, 3].Text, fpsfrmCompulsoryInsuranceByMonth_Sheet1.Cells[row, 4].Text, fpsfrmCompulsoryInsuranceByMonth_Sheet1.Cells[row, 5].Text);
        //}

        private bool equalsYearMonth(DateTime dateTime1, DateTime dateTime2)
        {
            return ((dateTime1.Year == dateTime2.Year) && (dateTime1.Month == dateTime1.Month));
        }

        private void bindCompulsoryInsurance(int row, CompulsoryInsurance value)
        {
            fpsfrmCompulsoryInsuranceByMonth_Sheet1.Cells[row, 0].Text = value.EntityKey;
            fpsfrmCompulsoryInsuranceByMonth_Sheet1.Cells[row, 1].Text = GUIFunction.GetShortDateString(value.APeriod.To);
            fpsfrmCompulsoryInsuranceByMonth_Sheet1.Cells[row, 2].Text = GUIFunction.GetShortDateString(value.APeriod.To.AddYears(1));
            fpsfrmCompulsoryInsuranceByMonth_Sheet1.Cells[row, 3].Text = string.Empty;
            //fpsfrmCompulsoryInsuranceByMonth_Sheet1.Cells[row, 3].Text = compulsoryBase.DefaultFullPrefix;
            //fpsfrmCompulsoryInsuranceByMonth_Sheet1.Cells[row, 4].Text = "";
            //fpsfrmCompulsoryInsuranceByMonth_Sheet1.Cells[row, 5].Text = compulsoryBase.DefaultEndorsement;

            fpsfrmCompulsoryInsuranceByMonth_Sheet1.Cells[row, 4].Text = string.Empty;
            fpsfrmCompulsoryInsuranceByMonth_Sheet1.Cells[row, 5].Text = GUIFunction.GetShortDateString(value.APeriod.To);
            fpsfrmCompulsoryInsuranceByMonth_Sheet1.Cells[row, 6].Text = value.AVehicle.PlateNumber;
            fpsfrmCompulsoryInsuranceByMonth_Sheet1.Cells[row, 7].Text = value.AVehicle.AModel.ABrand.AName.English;

            if (value.AVehicle != null && value.AVehicle.AKindOfVehicle.Code != "Z")
            {
                ContractBase contractBase = facadeCompulsoryInsuranceByMonth.GetCurrentVehicleContract(value.AVehicle);
                if (contractBase != null)
                {
                    fpsfrmCompulsoryInsuranceByMonth_Sheet1.Cells[row, 8].Text = contractBase.ACustomer.ShortName;
                }
            }

            fpsfrmCompulsoryInsuranceByMonth_Sheet1.Cells[row, 9].Text = value.CompulsoryInsuranceAmount.ToString();
        }

        private void bindPage()
        {
            if (facadeCompulsoryInsuranceByMonth.CompulsoryInsuranceList.Count == 0)
            {
                btnCompulsory.Enabled = false;
            }
            else
            {
                btnCompulsory.Enabled = true;
                fpsfrmCompulsoryInsuranceByMonth_Sheet1.ActiveColumnIndex = 3;
            }
            fpsfrmCompulsoryInsuranceByMonth_Sheet1.RowCount = facadeCompulsoryInsuranceByMonth.CompulsoryInsuranceList.Count;
            for (int i = 0; i < facadeCompulsoryInsuranceByMonth.CompulsoryInsuranceList.Count; i++)
            {
                bindCompulsoryInsurance(i, facadeCompulsoryInsuranceByMonth.CompulsoryInsuranceList[i]);
            }
            mdiParent.RefreshMasterCount();

        }

        private bool validateAdd()
        {
            ArrayList tempList = new ArrayList();
            string newPolicyNo;
            for (int i = 0; i < fpsfrmCompulsoryInsuranceByMonth_Sheet1.RowCount; i++)
            {
                if (DateTime.Parse(fpsfrmCompulsoryInsuranceByMonth_Sheet1.Cells[i, 1].Text) >= DateTime.Parse(fpsfrmCompulsoryInsuranceByMonth_Sheet1.Cells[i, 2].Text))
                {
                    Message(MessageList.Error.E0001, "กำหนดชำระปีนี้", "กำหนดชำระปีหน้า");
                    return false;
                }

                newPolicyNo = getCompulsoryNo(i);
                if (fpsfrmCompulsoryInsuranceByMonth_Sheet1.Cells[i, 3].Text.Trim() == "")
                {
                    Message(MessageList.Error.E0002, "เลข พ.ร.บ. ใหม่");
                    return false;
                }
                if (fpsfrmCompulsoryInsuranceByMonth_Sheet1.Cells[i, 4].Text.Trim() == "")
                {
                    Message(MessageList.Error.E0002, "เลขที่ใบกำกับภาษี");
                    return false;
                }
                if (tempList.Contains(newPolicyNo))
                {
                    Message(MessageList.Error.E0032, newPolicyNo);
                    return false;
                }
                else
                {
                    tempList.Add(newPolicyNo);
                }

                if (facadeCompulsoryInsuranceByMonth.CheckPolicyNo(newPolicyNo))
                {
                    Message(MessageList.Error.E0033, newPolicyNo);
                    return false;
                }
            }
            return true;
        }

        private bool addForm()
        {
            CompulsoryInsurance compulsoryInsurance;
            string key;
            string newPolicyNo;
            for (int i = 0; i < fpsfrmCompulsoryInsuranceByMonth_Sheet1.RowCount; i++)
            {
                key = fpsfrmCompulsoryInsuranceByMonth_Sheet1.Cells[i, 0].Text.Trim();
                newPolicyNo = getCompulsoryNo(i);
                compulsoryInsurance = facadeCompulsoryInsuranceByMonth.CompulsoryInsuranceList[key];
                compulsoryInsurance.PolicyNo = newPolicyNo;
                compulsoryInsurance.APeriod.From = DateTime.Parse(fpsfrmCompulsoryInsuranceByMonth_Sheet1.Cells[i, 1].Text);
                compulsoryInsurance.APeriod.To = DateTime.Parse(fpsfrmCompulsoryInsuranceByMonth_Sheet1.Cells[i, 2].Text);
                compulsoryInsurance.TaxInvoiceNo = fpsfrmCompulsoryInsuranceByMonth_Sheet1.Cells[i, 4].Text;
                compulsoryInsurance.TaxInvoiceDate = DateTime.Parse(fpsfrmCompulsoryInsuranceByMonth_Sheet1.Cells[i, 5].Text);

                if (facadeCompulsoryInsuranceByMonth.InsertCompulsoryInsurance(compulsoryInsurance))
                {
                    facadeCompulsoryInsuranceByMonth.CompulsoryInsuranceList[i] = compulsoryInsurance;
                    mdiParent.RefreshMasterCount();
                }
                else
                {
                    return false;
                }
            }
            return true;
        } 
        #endregion

        #region Public Method

        public override string FormID()
        {
            return UserProfile.GetFormID("miVehicle", "miVehicleDocumentCompulsoryMonth");
        }

        public override int MasterCount()
        {
            return facadeCompulsoryInsuranceByMonth.CompulsoryInsuranceList.Count;
        }

        public void InitForm()
        {
            dtpYearMonth.Value = new System.DateTime(DateTime.Today.Year, DateTime.Today.Month, 1, 0, 0, 0, 0);
            selectYearMonth = new YearMonth(DateTime.Today.Year, DateTime.Today.Month);
            RefreshForm();
        }

        public void RefreshForm()
        {
            try
            {
                if (facadeCompulsoryInsuranceByMonth.DisplayCompulsoryInsurance(dtpYearMonth.Value))
                {
                    MainMenuPrintStatus = true;
                    mdiParent.EnablePrintCommand(true);
                }
                else
                {
                    MainMenuPrintStatus = false;
                    mdiParent.EnablePrintCommand(false);
                }
                bindPage();
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
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
                btnCompulsory.Enabled = false;
            }
        }

        public void PrintForm()
        {
            try
            {
                if (facadeCompulsoryInsuranceByMonth.PrintCompulsoryInsuranceByMonth())
                {
                    rpttestExpired formReport = new rpttestExpired();
                    formReport.Text = "รายงานรถครบกำหนดชำระ พรบ.";
                    formReport.SelectedDate = dtpYearMonth.Value;
                    formReport.SelectedReportName = "rptExpiredCompulsoryInsurance.rpt";
                    formReport.Show();
                }
                else
                {
                    errorMessage(MessageList.GetMessage(MessageList.Error.E0027));
                }
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
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

        public void ExitForm()
        {
            this.Close();
        }

        public void AddForm()
        {
            try
            {
                if (validateAdd())
                {
                    addForm();
                    RefreshForm();
                }
            }
            catch (SqlException sqlex)
            {
                Message(sqlex);
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
        #endregion

        #region Form Event
        private void frmCompulsoryInsuranceByMonth_Load(object sender, System.EventArgs e)
        {
            mdiParent = (frmMain)this.MdiParent;
            InitForm();
        }

        private void btnCompulsory_Click(object sender, System.EventArgs e)
        {
            AddForm();
        }

        private void dtpYearMonth_ValueChanged(object sender, System.EventArgs e)
        {
            if (!selectYearMonth.Equals(dtpYearMonth.Value))
            {
                selectYearMonth = new YearMonth(dtpYearMonth.Value);
                RefreshForm();
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            MainMenuPrintStatus = false;
            mdiParent.EnablePrintCommand(false);
            this.Close();
        }

        private void fpsfrmCompulsoryInsuranceByMonth_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //User request to chage text format : Woranai 2009-07-20
            //if (e.KeyCode == Keys.Enter)
            //{
            //    if (fpsfrmCompulsoryInsuranceByMonth_Sheet1.Cells[SelectedRow, 4].Text.Trim() != "")
            //    {
            //        fpsfrmCompulsoryInsuranceByMonth_Sheet1.Cells[SelectedRow, 6].Text = getTaxInvoiceNo(SelectedRow);
            //    }
            //    if (fpsfrmCompulsoryInsuranceByMonth_Sheet1.ActiveColumnIndex == 4)
            //    {
            //        fpsfrmCompulsoryInsuranceByMonth_Sheet1.ActiveColumnIndex = 7;
            //    }
            //    else if (fpsfrmCompulsoryInsuranceByMonth_Sheet1.ActiveColumnIndex == 7)
            //    {
            //        fpsfrmCompulsoryInsuranceByMonth_Sheet1.ActiveColumnIndex = 4;
            //        fpsfrmCompulsoryInsuranceByMonth_Sheet1.ActiveRowIndex++;
            //    }
            //}
        }

        private void fpsfrmCompulsoryInsuranceByMonth_LeaveCell(object sender, FarPoint.Win.Spread.LeaveCellEventArgs e)
        {
            //User request to chage text format : Woranai 2009-07-20
            //if ((e.Column == 4 && fpsfrmCompulsoryInsuranceByMonth_Sheet1.Cells[e.Row, 3].Text.Trim() != "")
            //    || (e.Column == 3 && fpsfrmCompulsoryInsuranceByMonth_Sheet1.Cells[e.Row, 4].Text.Trim() != "")
            //    || (e.Column == 5 && fpsfrmCompulsoryInsuranceByMonth_Sheet1.Cells[e.Row, 5].Text.Trim() != ""))
            //{
            //    fpsfrmCompulsoryInsuranceByMonth_Sheet1.Cells[e.Row, 6].Text = getTaxInvoiceNo(e.Row);
            //}
        } 
        #endregion
	}
}