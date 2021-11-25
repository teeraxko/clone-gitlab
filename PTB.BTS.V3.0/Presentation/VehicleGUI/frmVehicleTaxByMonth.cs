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
using Entity.VehicleEntities;
using Entity.ContractEntities;

using Facade.CommonFacade;
using Facade.VehicleFacade;

using Presentation.CommonGUI;

using ictus.Common.Entity.Time;

namespace Presentation.VehicleGUI
{	
	public class frmVehicleTaxByMonth : ChildFormBase, IMDIChildForm
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
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdUpdateTax;
		private FarPoint.Win.Spread.SheetView fpsVehicleTax_Sheet1;
		private FarPoint.Win.Spread.FpSpread fpsVehicleTax;
		private System.Windows.Forms.Label label2;
		private FarPoint.Win.Input.FpDouble fpDouble1;
		private System.Windows.Forms.DateTimePicker dtpExpireDate;
	
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmVehicleTaxByMonth));
			FarPoint.Win.Spread.CellType.TextCellType textCellType7 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
			FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType2 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType8 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdUpdateTax = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.dtpExpireDate = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.fpsVehicleTax_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.fpsVehicleTax = new FarPoint.Win.Spread.FpSpread();
			this.label2 = new System.Windows.Forms.Label();
			this.fpDouble1 = new FarPoint.Win.Input.FpDouble();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fpsVehicleTax_Sheet1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsVehicleTax)).BeginInit();
			this.SuspendLayout();
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(534, 458);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 15;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdUpdateTax
			// 
			this.cmdUpdateTax.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdUpdateTax.Location = new System.Drawing.Point(422, 458);
			this.cmdUpdateTax.Name = "cmdUpdateTax";
			this.cmdUpdateTax.Size = new System.Drawing.Size(104, 23);
			this.cmdUpdateTax.TabIndex = 14;
			this.cmdUpdateTax.Text = "ปรับปรุงภาษีรถ";
			this.cmdUpdateTax.Click += new System.EventHandler(this.cmdUpdateTax_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.dtpExpireDate);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(21, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(988, 64);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "เรียกดูข้อมูลภาษีรถยนต์ที่จะหมดอายุ";
			// 
			// dtpExpireDate
			// 
			this.dtpExpireDate.CustomFormat = "MM/yyyy";
			this.dtpExpireDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpExpireDate.Location = new System.Drawing.Point(128, 24);
			this.dtpExpireDate.Name = "dtpExpireDate";
			this.dtpExpireDate.Size = new System.Drawing.Size(104, 20);
			this.dtpExpireDate.TabIndex = 1;
			this.dtpExpireDate.Value = new System.DateTime(2005, 10, 31, 0, 0, 0, 0);
			this.dtpExpireDate.ValueChanged += new System.EventHandler(this.dtpExpireDate_ValueChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "เดือน/ปีที่จะหมดอายุ";
			// 
			// fpsVehicleTax_Sheet1
			// 
			this.fpsVehicleTax_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsVehicleTax_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsVehicleTax_Sheet1.ColumnCount = 12;
			this.fpsVehicleTax_Sheet1.RowCount = 1;
			this.fpsVehicleTax_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "ทะเบียนรถ";
			this.fpsVehicleTax_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "ยี่ห้อ";
			this.fpsVehicleTax_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "รุ่น";
			this.fpsVehicleTax_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "ซีซี.";
			this.fpsVehicleTax_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "ลูกค้า";
			this.fpsVehicleTax_Sheet1.ColumnHeader.Cells.Get(0, 6).Text = "กำหนดชำระปีที่แล้ว";
			this.fpsVehicleTax_Sheet1.ColumnHeader.Cells.Get(0, 7).Text = "ปีที่";
			this.fpsVehicleTax_Sheet1.ColumnHeader.Cells.Get(0, 8).Text = "ภาษีรถยนต์";
			this.fpsVehicleTax_Sheet1.ColumnHeader.Cells.Get(0, 9).Text = "กำหนดชำระปีนี้";
			this.fpsVehicleTax_Sheet1.ColumnHeader.Cells.Get(0, 10).Text = "ขึ้นปีที่";
			this.fpsVehicleTax_Sheet1.ColumnHeader.Cells.Get(0, 11).Text = "ภาษีรถยนต์";
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsVehicleTax_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsVehicleTax_Sheet1.Columns.Get(0).Visible = false;
			this.fpsVehicleTax_Sheet1.Columns.Get(1).AllowAutoSort = true;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			this.fpsVehicleTax_Sheet1.Columns.Get(1).CellType = textCellType2;
			this.fpsVehicleTax_Sheet1.Columns.Get(1).Label = "ทะเบียนรถ";
			this.fpsVehicleTax_Sheet1.Columns.Get(1).Resizable = false;
			this.fpsVehicleTax_Sheet1.Columns.Get(1).Width = 65F;
			this.fpsVehicleTax_Sheet1.Columns.Get(2).AllowAutoSort = true;
			textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType3.DropDownButton = false;
			this.fpsVehicleTax_Sheet1.Columns.Get(2).CellType = textCellType3;
			this.fpsVehicleTax_Sheet1.Columns.Get(2).Label = "ยี่ห้อ";
			this.fpsVehicleTax_Sheet1.Columns.Get(2).Resizable = false;
			this.fpsVehicleTax_Sheet1.Columns.Get(2).Width = 75F;
			this.fpsVehicleTax_Sheet1.Columns.Get(3).AllowAutoSort = true;
			textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType4.DropDownButton = false;
			this.fpsVehicleTax_Sheet1.Columns.Get(3).CellType = textCellType4;
			this.fpsVehicleTax_Sheet1.Columns.Get(3).Label = "รุ่น";
			this.fpsVehicleTax_Sheet1.Columns.Get(3).Resizable = false;
			this.fpsVehicleTax_Sheet1.Columns.Get(3).Width = 180F;
			this.fpsVehicleTax_Sheet1.Columns.Get(4).AllowAutoSort = true;
			textCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType5.DropDownButton = false;
			this.fpsVehicleTax_Sheet1.Columns.Get(4).CellType = textCellType5;
			this.fpsVehicleTax_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsVehicleTax_Sheet1.Columns.Get(4).Label = "ซีซี.";
			this.fpsVehicleTax_Sheet1.Columns.Get(4).Resizable = false;
			this.fpsVehicleTax_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
			this.fpsVehicleTax_Sheet1.Columns.Get(4).Width = 53F;
			this.fpsVehicleTax_Sheet1.Columns.Get(5).AllowAutoSort = true;
			textCellType6.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType6.DropDownButton = false;
			this.fpsVehicleTax_Sheet1.Columns.Get(5).CellType = textCellType6;
			this.fpsVehicleTax_Sheet1.Columns.Get(5).Label = "ลูกค้า";
			this.fpsVehicleTax_Sheet1.Columns.Get(5).Resizable = false;
			this.fpsVehicleTax_Sheet1.Columns.Get(5).Width = 120F;
			this.fpsVehicleTax_Sheet1.Columns.Get(6).AllowAutoSort = true;
			dateTimeCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			dateTimeCellType1.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
			dateTimeCellType1.DateDefault = new System.DateTime(2005, 10, 19, 9, 50, 2, 0);
			dateTimeCellType1.DropDownButton = false;
			dateTimeCellType1.TimeDefault = new System.DateTime(2005, 10, 19, 9, 50, 2, 0);
			dateTimeCellType1.UserDefinedFormat = "dd/MM/yyyy";
			this.fpsVehicleTax_Sheet1.Columns.Get(6).CellType = dateTimeCellType1;
			this.fpsVehicleTax_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsVehicleTax_Sheet1.Columns.Get(6).Label = "กำหนดชำระปีที่แล้ว";
			this.fpsVehicleTax_Sheet1.Columns.Get(6).Locked = false;
			this.fpsVehicleTax_Sheet1.Columns.Get(6).Resizable = false;
			this.fpsVehicleTax_Sheet1.Columns.Get(6).Width = 90F;
			this.fpsVehicleTax_Sheet1.Columns.Get(7).AllowAutoSort = true;
			textCellType7.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType7.DropDownButton = false;
			this.fpsVehicleTax_Sheet1.Columns.Get(7).CellType = textCellType7;
			this.fpsVehicleTax_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsVehicleTax_Sheet1.Columns.Get(7).Label = "ปีที่";
			this.fpsVehicleTax_Sheet1.Columns.Get(7).Resizable = false;
			this.fpsVehicleTax_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
			this.fpsVehicleTax_Sheet1.Columns.Get(7).Width = 45F;
			this.fpsVehicleTax_Sheet1.Columns.Get(8).AllowAutoSort = true;
			numberCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			numberCellType1.DecimalPlaces = 2;
			numberCellType1.DropDownButton = false;
			numberCellType1.MinimumValue = 0;
			numberCellType1.ShowSeparator = true;
			this.fpsVehicleTax_Sheet1.Columns.Get(8).CellType = numberCellType1;
			this.fpsVehicleTax_Sheet1.Columns.Get(8).Label = "ภาษีรถยนต์";
			this.fpsVehicleTax_Sheet1.Columns.Get(8).Resizable = false;
			this.fpsVehicleTax_Sheet1.Columns.Get(8).Width = 90F;
			this.fpsVehicleTax_Sheet1.Columns.Get(9).AllowAutoSort = true;
			dateTimeCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			dateTimeCellType2.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
			dateTimeCellType2.DateDefault = new System.DateTime(2005, 10, 19, 9, 50, 11, 0);
			dateTimeCellType2.DropDownButton = false;
			dateTimeCellType2.TimeDefault = new System.DateTime(2005, 10, 19, 9, 50, 11, 0);
			dateTimeCellType2.UserDefinedFormat = "dd/MM/yyyy";
			this.fpsVehicleTax_Sheet1.Columns.Get(9).CellType = dateTimeCellType2;
			this.fpsVehicleTax_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsVehicleTax_Sheet1.Columns.Get(9).Label = "กำหนดชำระปีนี้";
			this.fpsVehicleTax_Sheet1.Columns.Get(9).Locked = false;
			this.fpsVehicleTax_Sheet1.Columns.Get(9).Resizable = false;
			this.fpsVehicleTax_Sheet1.Columns.Get(9).Width = 90F;
			this.fpsVehicleTax_Sheet1.Columns.Get(10).AllowAutoSort = true;
			textCellType8.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType8.DropDownButton = false;
			this.fpsVehicleTax_Sheet1.Columns.Get(10).CellType = textCellType8;
			this.fpsVehicleTax_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsVehicleTax_Sheet1.Columns.Get(10).Label = "ขึ้นปีที่";
			this.fpsVehicleTax_Sheet1.Columns.Get(10).Locked = false;
			this.fpsVehicleTax_Sheet1.Columns.Get(10).Resizable = false;
			this.fpsVehicleTax_Sheet1.Columns.Get(10).Width = 45F;
			this.fpsVehicleTax_Sheet1.Columns.Get(11).AllowAutoSort = true;
			numberCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			numberCellType2.DecimalPlaces = 2;
			numberCellType2.DecimalSeparator = ".";
			numberCellType2.DropDownButton = false;
			numberCellType2.MaximumValue = 99999.99;
			numberCellType2.MinimumValue = 0;
			numberCellType2.Separator = ",";
			numberCellType2.ShowSeparator = true;
			this.fpsVehicleTax_Sheet1.Columns.Get(11).CellType = numberCellType2;
			this.fpsVehicleTax_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
			this.fpsVehicleTax_Sheet1.Columns.Get(11).Label = "ภาษีรถยนต์";
			this.fpsVehicleTax_Sheet1.Columns.Get(11).Locked = false;
			this.fpsVehicleTax_Sheet1.Columns.Get(11).Resizable = false;
			this.fpsVehicleTax_Sheet1.Columns.Get(11).Width = 90F;
			this.fpsVehicleTax_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
			this.fpsVehicleTax_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsVehicleTax_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsVehicleTax_Sheet1.SheetName = "Sheet1";
			this.fpsVehicleTax_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// fpsVehicleTax
			// 
			this.fpsVehicleTax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsVehicleTax.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsVehicleTax.Location = new System.Drawing.Point(16, 104);
			this.fpsVehicleTax.Name = "fpsVehicleTax";
			this.fpsVehicleTax.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																					   this.fpsVehicleTax_Sheet1});
			this.fpsVehicleTax.Size = new System.Drawing.Size(999, 312);
			this.fpsVehicleTax.TabIndex = 13;
			this.fpsVehicleTax.TabStop = false;
			this.fpsVehicleTax.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsVehicleTax_CellDoubleClick);
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.label2.Location = new System.Drawing.Point(840, 432);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 23);
			this.label2.TabIndex = 16;
			this.label2.Text = "รวมเป็นเงิน";
			// 
			// fpDouble1
			// 
			this.fpDouble1.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Right;
			this.fpDouble1.AllowClipboardKeys = true;
			this.fpDouble1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.fpDouble1.ButtonMarginColor = System.Drawing.SystemColors.Control;
			this.fpDouble1.DecimalPlaces = 2;
			this.fpDouble1.Enabled = false;
			this.fpDouble1.FixedPoint = true;
			this.fpDouble1.Location = new System.Drawing.Point(904, 432);
			this.fpDouble1.Name = "fpDouble1";
			this.fpDouble1.Size = new System.Drawing.Size(96, 20);
			this.fpDouble1.TabIndex = 17;
			this.fpDouble1.Text = "";
			this.fpDouble1.UseSeparator = true;
			// 
			// frmVehicleTaxByMonth
			// 
			this.AcceptButton = this.cmdUpdateTax;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(1030, 504);
			this.Controls.Add(this.fpDouble1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cmdUpdateTax);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.fpsVehicleTax);
			this.Controls.Add(this.cmdCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmVehicleTaxByMonth";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //this.Text = "ต่อภาษีรถยนต์ตามเดือน/ปีที่หมดอายุ";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmVehicleTaxByMonth_Load);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fpsVehicleTax_Sheet1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsVehicleTax)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private YearMonth selectYearMonth;
		private VehicleTaxByMonthFacade facadeVehicleTaxByMonth;
		private frmMain mdiParent;
		#endregion -Private -

//		================================= Constructor ================================
		public frmVehicleTaxByMonth() : base()
		{	
			InitializeComponent();
			facadeVehicleTaxByMonth = new VehicleTaxByMonthFacade();
			isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleDocumentVehicleTaxMonth");
            this.title = UserProfile.GetFormName("miVehicle", "miVehicleDocumentVehicleTaxMonth");

		}
        public override string FormID()
        {
            return UserProfile.GetFormID("miVehicle", "miVehicleDocumentVehicleTaxMonth");
        }

//		=============================== Private Method ================================
		private void bindVehicleTax(int row, VehicleTax latestTax, VehicleTax currentTax)
		{
			fpsVehicleTax_Sheet1.Cells[row,0].Text = GUIFunction.GetString(latestTax.EntityKey);
			fpsVehicleTax_Sheet1.Cells[row,1].Text = GUIFunction.GetString(latestTax.AVehicle.PlateNumber);
			fpsVehicleTax_Sheet1.Cells[row,2].Text = GUIFunction.GetString(latestTax.AVehicle.AModel.ABrand.AName.English);
			fpsVehicleTax_Sheet1.Cells[row,3].Text = GUIFunction.GetString(latestTax.AVehicle.AModel.AName.English);
			fpsVehicleTax_Sheet1.Cells[row,4].Text = GUIFunction.GetString(latestTax.AVehicle.AModel.EngineCC);

			if(latestTax.AVehicle.AKindOfVehicle.Code != "Z")
			{
				ContractBase contractBase = facadeVehicleTaxByMonth.GetCurrentVehicleContract(latestTax.AVehicle);
				if(contractBase != null)
				{
					fpsVehicleTax_Sheet1.Cells[row,5].Text = GUIFunction.GetString(contractBase.ACustomer.ShortName);
				}
			}
			
			fpsVehicleTax_Sheet1.Cells[row,6].Text = GUIFunction.GetShortDateString(latestTax.APeriod.From);
			fpsVehicleTax_Sheet1.Cells[row,7].Text = GUIFunction.GetString(latestTax.TaxYear - 1);
			fpsVehicleTax_Sheet1.Cells[row,8].Text = GUIFunction.GetString(latestTax.TaxAmount);
			fpsVehicleTax_Sheet1.Cells[row,9].Text = GUIFunction.GetShortDateString(latestTax.APeriod.To);
			fpsVehicleTax_Sheet1.Cells[row,10].Text = GUIFunction.GetString(latestTax.TaxYear);

			fpsVehicleTax_Sheet1.Cells[row,11].Text = GUIFunction.GetString(currentTax.TaxAmount);
		}

		private void bindForm()
		{
			if(facadeVehicleTaxByMonth.LatestVehicleTaxList.Count == 0)
			{
				cmdUpdateTax.Enabled = false;
			}
			else
			{
				cmdUpdateTax.Enabled = true;
			}


			if (facadeVehicleTaxByMonth.LatestVehicleTaxList != null)
			{
				int iRow = facadeVehicleTaxByMonth.LatestVehicleTaxList.Count;
				fpsVehicleTax_Sheet1.RowCount = iRow;
				decimal vatTotal = 0;
				for(int i=0; i<iRow; i++)
				{
					bindVehicleTax(i, facadeVehicleTaxByMonth.LatestVehicleTaxList[i], facadeVehicleTaxByMonth.CurrentVehicleTaxList[i]);
					vatTotal += facadeVehicleTaxByMonth.CurrentVehicleTaxList[i].TaxAmount;
				}		
		
				fpDouble1.Value = vatTotal;

				mdiParent.RefreshMasterCount();
			}
		}

		private void clearForm()
		{
			
		}

		private bool addForm()
		{
			VehicleTax currentVehicleTax;
			string key;

			for(int i=0; i<fpsVehicleTax_Sheet1.RowCount; i++)
			{
				key = fpsVehicleTax_Sheet1.Cells[i,0].Text.Trim();

				currentVehicleTax = facadeVehicleTaxByMonth.CurrentVehicleTaxList[key];
				currentVehicleTax.APeriod.From = DateTime.Parse(fpsVehicleTax_Sheet1.Cells[i,9].Text);
				currentVehicleTax.APeriod.To = DateTime.Parse(fpsVehicleTax_Sheet1.Cells[i,9].Text).AddYears(1);
				currentVehicleTax.TaxAmount = Convert.ToDecimal(fpsVehicleTax_Sheet1.Cells[i,11].Text);

				if(facadeVehicleTaxByMonth.InsertVehicleTaxByMonth(currentVehicleTax))
				{
					facadeVehicleTaxByMonth.CurrentVehicleTaxList[key] = currentVehicleTax;
				}
				else
				{
					return false;
				}
			}
			return true;
		}
//		================================= Public Method ==================================

		public override int MasterCount()
		{
			return facadeVehicleTaxByMonth.LatestVehicleTaxList.Count;
		}
//		================================= Base Event ==================================
		public void AddForm()
		{
			try
			{
				if(addForm())
				{
					RefreshForm();
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

		public void InitForm()
		{
			dtpExpireDate.Value = new System.DateTime(DateTime.Today.Year, DateTime.Today.Month, 1, 0, 0, 0, 0);
			selectYearMonth = new YearMonth(DateTime.Today.Year, DateTime.Today.Month);
			RefreshForm();			
		}

		public void RefreshForm()
		{
			dtpExpireDate.Focus();
			fpsVehicleTax.Enabled = true;
			cmdCancel.Enabled = true;

			mdiParent.EnablePrintCommand(false);
			MainMenuPrintStatus = false;

			try
			{
				if(facadeVehicleTaxByMonth.DisplayLatestVehicleTaxList(dtpExpireDate.Value))
				{
					if(facadeVehicleTaxByMonth.DisplayCurrentVehicleTaxByMonth(dtpExpireDate.Value))
					{
						mdiParent.EnablePrintCommand(true);
						MainMenuPrintStatus = true;
					}
				}
				bindForm();	
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
				cmdUpdateTax.Enabled = false;
			}
		}

		public void PrintForm()
		{
			try
			{
				if(facadeVehicleTaxByMonth.PrintVehicleTaxByMonth())
				{
					rpttestExpired formReport = new rpttestExpired();
					formReport.Text = "รายงานรถครบกำหนดชำระภาษี";
					formReport.SelectedDate = dtpExpireDate.Value;
					formReport.SelectedReportName = "rptExpiredVehicleTax.rpt";
					formReport.ShowDialog();
				}
				else
				{
					errorMessage(MessageList.GetMessage(MessageList.Error.E0027));
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

		public void ExitForm()
		{
			this.Close();
		}

//		==================================== Event ====================================
		private void cmdUpdateTax_Click(object sender, System.EventArgs e)
		{
			if (Message(MessageList.Question.Q0005)== DialogResult.Yes)
			{
				AddForm();
			}
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			mdiParent.EnablePrintCommand(false);
			MainMenuPrintStatus = false;
			this.Close();
		}

		private void dtpExpireDate_ValueChanged(object sender, System.EventArgs e)
		{
			if(!selectYearMonth.Equals(dtpExpireDate.Value))
			{
				selectYearMonth = new YearMonth(dtpExpireDate.Value);
				RefreshForm();
			}
		}

		private void frmVehicleTaxByMonth_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
		}

		private void fpsVehicleTax_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader)
			{
			}
		}
	}
}
