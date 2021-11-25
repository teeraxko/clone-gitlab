using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using Entity.CommonEntity;
using Entity.VehicleEntities;

using Facade.VehicleFacade;
using Facade.CommonFacade;

using Presentation.CommonGUI;

using SystemFramework.AppMessage;
using SystemFramework.AppException;
using SystemFramework.AppConfig;

using ictus.Common.Entity.Time;

namespace Presentation.VehicleGUI
{
	public class frmCompulsoryInsuranceByPlate : ChildFormBase, IMDIChildForm
	{
        #region Windows Form Designer generated code
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
        private System.Windows.Forms.GroupBox groupBox1;
        private FarPoint.Win.Input.FpInteger fpiNoOfSeat;
        private FarPoint.Win.Input.FpInteger fpiCC;
        private FarPoint.Win.Input.FpInteger fpiAgeYear;
        private FarPoint.Win.Input.FpInteger fpiAgeMonth;
        private System.Windows.Forms.TextBox txtColorName;
        private System.Windows.Forms.TextBox txtModelTypeName;
        private System.Windows.Forms.TextBox txtModelName;
        private System.Windows.Forms.TextBox txtBrandName;
        private System.Windows.Forms.TextBox txtPlatePrefix;
        private FarPoint.Win.Input.FpInteger fpiPlateRunningNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdEdit;
        private FarPoint.Win.Spread.SheetView fpsCompulsoryByPlate_Sheet1;
        private System.Windows.Forms.Button cmdAdd;
        private FarPoint.Win.Spread.FpSpread fpsCompulsoryByPlate;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem mniAdd;
        private System.Windows.Forms.MenuItem mniEdit;
        private System.Windows.Forms.MenuItem mniDelete;
        private System.Windows.Forms.Label lblPlateNo;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblPlatePrefix;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private FarPoint.Win.Input.FpInteger fpiAgeCarYear;
        private FarPoint.Win.Input.FpInteger fpiAgeCarMonth;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtChassisNo;
        private System.ComponentModel.Container components = null;
        private void InitializeComponent()
        {
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmCompulsoryInsuranceByPlate));
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType2 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.fpsCompulsoryByPlate_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.fpsCompulsoryByPlate = new FarPoint.Win.Spread.FpSpread();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.mniAdd = new System.Windows.Forms.MenuItem();
            this.mniEdit = new System.Windows.Forms.MenuItem();
            this.mniDelete = new System.Windows.Forms.MenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fpiAgeCarYear = new FarPoint.Win.Input.FpInteger();
            this.fpiAgeCarMonth = new FarPoint.Win.Input.FpInteger();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblPlateNo = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblPlatePrefix = new System.Windows.Forms.Label();
            this.fpiNoOfSeat = new FarPoint.Win.Input.FpInteger();
            this.fpiCC = new FarPoint.Win.Input.FpInteger();
            this.fpiAgeYear = new FarPoint.Win.Input.FpInteger();
            this.fpiAgeMonth = new FarPoint.Win.Input.FpInteger();
            this.txtColorName = new System.Windows.Forms.TextBox();
            this.txtModelTypeName = new System.Windows.Forms.TextBox();
            this.txtModelName = new System.Windows.Forms.TextBox();
            this.txtBrandName = new System.Windows.Forms.TextBox();
            this.txtPlatePrefix = new System.Windows.Forms.TextBox();
            this.fpiPlateRunningNo = new FarPoint.Win.Input.FpInteger();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtChassisNo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.fpsCompulsoryByPlate_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsCompulsoryByPlate)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdDelete.Location = new System.Drawing.Point(485, 370);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.TabIndex = 16;
            this.cmdDelete.Text = "ลบ";
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdEdit.Location = new System.Drawing.Point(405, 370);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.TabIndex = 15;
            this.cmdEdit.Text = "แก้ไข";
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // fpsCompulsoryByPlate_Sheet1
            // 
            this.fpsCompulsoryByPlate_Sheet1.Reset();
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpsCompulsoryByPlate_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpsCompulsoryByPlate_Sheet1.ColumnCount = 7;
            this.fpsCompulsoryByPlate_Sheet1.ColumnHeader.RowCount = 2;
            this.fpsCompulsoryByPlate_Sheet1.RowCount = 1;
            this.fpsCompulsoryByPlate_Sheet1.ColumnHeader.Cells.Get(0, 0).RowSpan = 2;
            this.fpsCompulsoryByPlate_Sheet1.ColumnHeader.Cells.Get(0, 0).Text = "เลข พ.ร.บ.";
            this.fpsCompulsoryByPlate_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "ค่า พ.ร.บ.";
            this.fpsCompulsoryByPlate_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "ค่าธรรมเนียมอากร";
            this.fpsCompulsoryByPlate_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ภาษี";
            this.fpsCompulsoryByPlate_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "รวมเป็นเงิน";
            this.fpsCompulsoryByPlate_Sheet1.ColumnHeader.Cells.Get(0, 5).RowSpan = 2;
            this.fpsCompulsoryByPlate_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "วันที่เริ่มต้น";
            this.fpsCompulsoryByPlate_Sheet1.ColumnHeader.Cells.Get(0, 6).RowSpan = 2;
            this.fpsCompulsoryByPlate_Sheet1.ColumnHeader.Cells.Get(0, 6).Text = "วันที่สิ้นสุด";
            this.fpsCompulsoryByPlate_Sheet1.ColumnHeader.Cells.Get(1, 1).Text = "(Net Premium)";
            this.fpsCompulsoryByPlate_Sheet1.ColumnHeader.Cells.Get(1, 2).Text = "(Duty Stamp)";
            this.fpsCompulsoryByPlate_Sheet1.ColumnHeader.Cells.Get(1, 3).Text = "(VAT)";
            this.fpsCompulsoryByPlate_Sheet1.ColumnHeader.Cells.Get(1, 4).Text = "(Total Premium)";
            this.fpsCompulsoryByPlate_Sheet1.Columns.Get(0).AllowAutoSort = true;
            textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType1.DropDownButton = false;
            this.fpsCompulsoryByPlate_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.fpsCompulsoryByPlate_Sheet1.Columns.Get(0).Resizable = false;
            this.fpsCompulsoryByPlate_Sheet1.Columns.Get(0).Width = 122F;
            this.fpsCompulsoryByPlate_Sheet1.Columns.Get(1).AllowAutoSort = true;
            numberCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            numberCellType1.DecimalPlaces = 2;
            numberCellType1.DecimalSeparator = ".";
            numberCellType1.DropDownButton = false;
            numberCellType1.MaximumValue = 99999.99;
            numberCellType1.MinimumValue = 0;
            numberCellType1.Separator = ",";
            numberCellType1.ShowSeparator = true;
            this.fpsCompulsoryByPlate_Sheet1.Columns.Get(1).CellType = numberCellType1;
            this.fpsCompulsoryByPlate_Sheet1.Columns.Get(1).Label = "(Net Premium)";
            this.fpsCompulsoryByPlate_Sheet1.Columns.Get(1).Resizable = false;
            this.fpsCompulsoryByPlate_Sheet1.Columns.Get(1).Width = 117F;
            this.fpsCompulsoryByPlate_Sheet1.Columns.Get(2).AllowAutoSort = true;
            numberCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            numberCellType2.DecimalPlaces = 2;
            numberCellType2.DecimalSeparator = ".";
            numberCellType2.DropDownButton = false;
            numberCellType2.MaximumValue = 99999.99;
            numberCellType2.MinimumValue = 0;
            numberCellType2.Separator = ",";
            numberCellType2.ShowSeparator = true;
            this.fpsCompulsoryByPlate_Sheet1.Columns.Get(2).CellType = numberCellType2;
            this.fpsCompulsoryByPlate_Sheet1.Columns.Get(2).Label = "(Duty Stamp)";
            this.fpsCompulsoryByPlate_Sheet1.Columns.Get(2).Resizable = false;
            this.fpsCompulsoryByPlate_Sheet1.Columns.Get(2).Width = 102F;
            this.fpsCompulsoryByPlate_Sheet1.Columns.Get(3).AllowAutoSort = true;
            numberCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            numberCellType3.DecimalPlaces = 2;
            numberCellType3.DecimalSeparator = ".";
            numberCellType3.DropDownButton = false;
            numberCellType3.Separator = ",";
            numberCellType3.ShowSeparator = true;
            this.fpsCompulsoryByPlate_Sheet1.Columns.Get(3).CellType = numberCellType3;
            this.fpsCompulsoryByPlate_Sheet1.Columns.Get(3).Label = "(VAT)";
            this.fpsCompulsoryByPlate_Sheet1.Columns.Get(3).Resizable = false;
            this.fpsCompulsoryByPlate_Sheet1.Columns.Get(3).Width = 106F;
            this.fpsCompulsoryByPlate_Sheet1.Columns.Get(4).AllowAutoSort = true;
            numberCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            numberCellType4.DecimalPlaces = 2;
            numberCellType4.DecimalSeparator = ".";
            numberCellType4.DropDownButton = false;
            numberCellType4.Separator = ",";
            numberCellType4.ShowSeparator = true;
            this.fpsCompulsoryByPlate_Sheet1.Columns.Get(4).CellType = numberCellType4;
            this.fpsCompulsoryByPlate_Sheet1.Columns.Get(4).Label = "(Total Premium)";
            this.fpsCompulsoryByPlate_Sheet1.Columns.Get(4).Resizable = false;
            this.fpsCompulsoryByPlate_Sheet1.Columns.Get(4).Width = 120F;
            this.fpsCompulsoryByPlate_Sheet1.Columns.Get(5).AllowAutoSort = true;
            dateTimeCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            dateTimeCellType1.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
            dateTimeCellType1.DateDefault = new System.DateTime(2005, 10, 19, 9, 47, 11, 0);
            dateTimeCellType1.DropDownButton = false;
            dateTimeCellType1.TimeDefault = new System.DateTime(2005, 10, 19, 9, 47, 11, 0);
            dateTimeCellType1.UserDefinedFormat = "dd/MM/yyyy";
            this.fpsCompulsoryByPlate_Sheet1.Columns.Get(5).CellType = dateTimeCellType1;
            this.fpsCompulsoryByPlate_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsCompulsoryByPlate_Sheet1.Columns.Get(5).Resizable = false;
            this.fpsCompulsoryByPlate_Sheet1.Columns.Get(5).Width = 115F;
            this.fpsCompulsoryByPlate_Sheet1.Columns.Get(6).AllowAutoSort = true;
            dateTimeCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            dateTimeCellType2.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
            dateTimeCellType2.DateDefault = new System.DateTime(2005, 10, 19, 9, 47, 23, 0);
            dateTimeCellType2.DropDownButton = false;
            dateTimeCellType2.TimeDefault = new System.DateTime(2005, 10, 19, 9, 47, 23, 0);
            dateTimeCellType2.UserDefinedFormat = "dd/MM/yyyy";
            this.fpsCompulsoryByPlate_Sheet1.Columns.Get(6).CellType = dateTimeCellType2;
            this.fpsCompulsoryByPlate_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsCompulsoryByPlate_Sheet1.Columns.Get(6).Resizable = false;
            this.fpsCompulsoryByPlate_Sheet1.Columns.Get(6).Width = 115F;
            this.fpsCompulsoryByPlate_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
            this.fpsCompulsoryByPlate_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpsCompulsoryByPlate_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpsCompulsoryByPlate_Sheet1.SheetName = "Sheet1";
            this.fpsCompulsoryByPlate_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdAdd.Location = new System.Drawing.Point(325, 370);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.TabIndex = 14;
            this.cmdAdd.Text = "เพิ่ม";
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // fpsCompulsoryByPlate
            // 
            this.fpsCompulsoryByPlate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.fpsCompulsoryByPlate.ContextMenu = this.contextMenu1;
            this.fpsCompulsoryByPlate.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.fpsCompulsoryByPlate.Location = new System.Drawing.Point(15, 208);
            this.fpsCompulsoryByPlate.Name = "fpsCompulsoryByPlate";
            this.fpsCompulsoryByPlate.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																							  this.fpsCompulsoryByPlate_Sheet1});
            this.fpsCompulsoryByPlate.Size = new System.Drawing.Size(857, 144);
            this.fpsCompulsoryByPlate.TabIndex = 13;
            this.fpsCompulsoryByPlate.Visible = false;
            this.fpsCompulsoryByPlate.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsCompulsoryByPlate_CellDoubleClick);
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
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtChassisNo);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.fpiAgeCarYear);
            this.groupBox1.Controls.Add(this.fpiAgeCarMonth);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.lblPlateNo);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.lblPlatePrefix);
            this.groupBox1.Controls.Add(this.fpiNoOfSeat);
            this.groupBox1.Controls.Add(this.fpiCC);
            this.groupBox1.Controls.Add(this.fpiAgeYear);
            this.groupBox1.Controls.Add(this.fpiAgeMonth);
            this.groupBox1.Controls.Add(this.txtColorName);
            this.groupBox1.Controls.Add(this.txtModelTypeName);
            this.groupBox1.Controls.Add(this.txtModelName);
            this.groupBox1.Controls.Add(this.txtBrandName);
            this.groupBox1.Controls.Add(this.txtPlatePrefix);
            this.groupBox1.Controls.Add(this.fpiPlateRunningNo);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(856, 184);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "เรียกดูข้อมูล พ.ร.บ.";
            // 
            // fpiAgeCarYear
            // 
            this.fpiAgeCarYear.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
            this.fpiAgeCarYear.AllowClipboardKeys = true;
            this.fpiAgeCarYear.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiAgeCarYear.Enabled = false;
            this.fpiAgeCarYear.Location = new System.Drawing.Point(564, 120);
            this.fpiAgeCarYear.MaxValue = 100;
            this.fpiAgeCarYear.MinValue = 0;
            this.fpiAgeCarYear.Name = "fpiAgeCarYear";
            this.fpiAgeCarYear.Size = new System.Drawing.Size(40, 20);
            this.fpiAgeCarYear.TabIndex = 120;
            this.fpiAgeCarYear.Text = "";
            this.fpiAgeCarYear.UserEntry = FarPoint.Win.Input.UserEntry.FreeFormat;
            // 
            // fpiAgeCarMonth
            // 
            this.fpiAgeCarMonth.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
            this.fpiAgeCarMonth.AllowClipboardKeys = true;
            this.fpiAgeCarMonth.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiAgeCarMonth.Enabled = false;
            this.fpiAgeCarMonth.Location = new System.Drawing.Point(636, 120);
            this.fpiAgeCarMonth.MaxValue = 12;
            this.fpiAgeCarMonth.MinValue = 0;
            this.fpiAgeCarMonth.Name = "fpiAgeCarMonth";
            this.fpiAgeCarMonth.Size = new System.Drawing.Size(40, 20);
            this.fpiAgeCarMonth.TabIndex = 119;
            this.fpiAgeCarMonth.Text = "";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(684, 120);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 23);
            this.label12.TabIndex = 118;
            this.label12.Text = "เดือน";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(612, 120);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(16, 23);
            this.label13.TabIndex = 117;
            this.label13.Text = "ปี";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(452, 120);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(104, 23);
            this.label14.TabIndex = 116;
            this.label14.Text = "อายุรถยนต์";
            // 
            // lblPlateNo
            // 
            this.lblPlateNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
            this.lblPlateNo.Location = new System.Drawing.Point(324, 22);
            this.lblPlateNo.Name = "lblPlateNo";
            this.lblPlateNo.Size = new System.Drawing.Size(72, 24);
            this.lblPlateNo.TabIndex = 115;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
            this.label23.Location = new System.Drawing.Point(300, 22);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(8, 24);
            this.label23.TabIndex = 114;
            this.label23.Text = "-";
            // 
            // lblPlatePrefix
            // 
            this.lblPlatePrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
            this.lblPlatePrefix.Location = new System.Drawing.Point(268, 22);
            this.lblPlatePrefix.Name = "lblPlatePrefix";
            this.lblPlatePrefix.Size = new System.Drawing.Size(40, 24);
            this.lblPlatePrefix.TabIndex = 113;
            // 
            // fpiNoOfSeat
            // 
            this.fpiNoOfSeat.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
            this.fpiNoOfSeat.AllowClipboardKeys = true;
            this.fpiNoOfSeat.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiNoOfSeat.Enabled = false;
            this.fpiNoOfSeat.Location = new System.Drawing.Point(564, 56);
            this.fpiNoOfSeat.MaxValue = 999;
            this.fpiNoOfSeat.MinValue = 0;
            this.fpiNoOfSeat.Name = "fpiNoOfSeat";
            this.fpiNoOfSeat.Size = new System.Drawing.Size(72, 20);
            this.fpiNoOfSeat.TabIndex = 110;
            this.fpiNoOfSeat.Text = "";
            // 
            // fpiCC
            // 
            this.fpiCC.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
            this.fpiCC.AllowClipboardKeys = true;
            this.fpiCC.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiCC.Enabled = false;
            this.fpiCC.Location = new System.Drawing.Point(716, 56);
            this.fpiCC.MaxValue = 9999;
            this.fpiCC.MinValue = 0;
            this.fpiCC.Name = "fpiCC";
            this.fpiCC.Size = new System.Drawing.Size(88, 20);
            this.fpiCC.TabIndex = 109;
            this.fpiCC.Text = "";
            // 
            // fpiAgeYear
            // 
            this.fpiAgeYear.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
            this.fpiAgeYear.AllowClipboardKeys = true;
            this.fpiAgeYear.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiAgeYear.Enabled = false;
            this.fpiAgeYear.Location = new System.Drawing.Point(564, 88);
            this.fpiAgeYear.MaxValue = 100;
            this.fpiAgeYear.MinValue = 0;
            this.fpiAgeYear.Name = "fpiAgeYear";
            this.fpiAgeYear.Size = new System.Drawing.Size(40, 20);
            this.fpiAgeYear.TabIndex = 107;
            this.fpiAgeYear.Text = "";
            this.fpiAgeYear.UserEntry = FarPoint.Win.Input.UserEntry.FreeFormat;
            // 
            // fpiAgeMonth
            // 
            this.fpiAgeMonth.AlignHorz = FarPoint.Win.Input.HorizontalAlignment.Center;
            this.fpiAgeMonth.AllowClipboardKeys = true;
            this.fpiAgeMonth.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiAgeMonth.Enabled = false;
            this.fpiAgeMonth.Location = new System.Drawing.Point(636, 88);
            this.fpiAgeMonth.MaxValue = 12;
            this.fpiAgeMonth.MinValue = 0;
            this.fpiAgeMonth.Name = "fpiAgeMonth";
            this.fpiAgeMonth.Size = new System.Drawing.Size(40, 20);
            this.fpiAgeMonth.TabIndex = 106;
            this.fpiAgeMonth.Text = "";
            // 
            // txtColorName
            // 
            this.txtColorName.Enabled = false;
            this.txtColorName.Location = new System.Drawing.Point(564, 24);
            this.txtColorName.MaxLength = 50;
            this.txtColorName.Name = "txtColorName";
            this.txtColorName.Size = new System.Drawing.Size(240, 20);
            this.txtColorName.TabIndex = 101;
            this.txtColorName.Text = "";
            // 
            // txtModelTypeName
            // 
            this.txtModelTypeName.Enabled = false;
            this.txtModelTypeName.Location = new System.Drawing.Point(124, 120);
            this.txtModelTypeName.MaxLength = 50;
            this.txtModelTypeName.Name = "txtModelTypeName";
            this.txtModelTypeName.Size = new System.Drawing.Size(312, 20);
            this.txtModelTypeName.TabIndex = 99;
            this.txtModelTypeName.Text = "";
            // 
            // txtModelName
            // 
            this.txtModelName.Enabled = false;
            this.txtModelName.Location = new System.Drawing.Point(124, 88);
            this.txtModelName.MaxLength = 50;
            this.txtModelName.Name = "txtModelName";
            this.txtModelName.Size = new System.Drawing.Size(312, 20);
            this.txtModelName.TabIndex = 97;
            this.txtModelName.Text = "";
            // 
            // txtBrandName
            // 
            this.txtBrandName.Enabled = false;
            this.txtBrandName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBrandName.Location = new System.Drawing.Point(124, 56);
            this.txtBrandName.MaxLength = 50;
            this.txtBrandName.Name = "txtBrandName";
            this.txtBrandName.Size = new System.Drawing.Size(312, 20);
            this.txtBrandName.TabIndex = 95;
            this.txtBrandName.Text = "";
            // 
            // txtPlatePrefix
            // 
            this.txtPlatePrefix.Location = new System.Drawing.Point(124, 24);
            this.txtPlatePrefix.MaxLength = 3;
            this.txtPlatePrefix.Name = "txtPlatePrefix";
            this.txtPlatePrefix.Size = new System.Drawing.Size(40, 20);
            this.txtPlatePrefix.TabIndex = 91;
            this.txtPlatePrefix.Text = "";
            this.txtPlatePrefix.TextChanged += new System.EventHandler(this.txtPlatePrefix_TextChanged);
            // 
            // fpiPlateRunningNo
            // 
            this.fpiPlateRunningNo.AllowClipboardKeys = true;
            this.fpiPlateRunningNo.AllowNull = true;
            this.fpiPlateRunningNo.ButtonMarginColor = System.Drawing.SystemColors.Control;
            this.fpiPlateRunningNo.Location = new System.Drawing.Point(188, 24);
            this.fpiPlateRunningNo.MaxValue = 9999;
            this.fpiPlateRunningNo.MinValue = 0;
            this.fpiPlateRunningNo.Name = "fpiPlateRunningNo";
            this.fpiPlateRunningNo.NullColor = System.Drawing.Color.Transparent;
            this.fpiPlateRunningNo.Size = new System.Drawing.Size(48, 20);
            this.fpiPlateRunningNo.TabIndex = 92;
            this.fpiPlateRunningNo.Text = "";
            this.fpiPlateRunningNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpiPlateRunningNo_KeyDown);
            this.fpiPlateRunningNo.DoubleClick += new System.EventHandler(this.fpiPlateRunningNo_DoubleClick);
            this.fpiPlateRunningNo.TextChanged += new System.EventHandler(this.fpiPlateRunningNo_TextChanged);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(676, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 23);
            this.label11.TabIndex = 108;
            this.label11.Text = "ซีซี.";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(684, 88);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 23);
            this.label10.TabIndex = 105;
            this.label10.Text = "เดือน";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(612, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 23);
            this.label9.TabIndex = 104;
            this.label9.Text = "ปี";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(452, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 23);
            this.label8.TabIndex = 103;
            this.label8.Text = "ระยะเวลาที่ครอบครอง";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(452, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 23);
            this.label7.TabIndex = 102;
            this.label7.Text = "จำนวนที่นั่ง";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(452, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 23);
            this.label6.TabIndex = 100;
            this.label6.Text = "สีรถ";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(52, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 23);
            this.label5.TabIndex = 98;
            this.label5.Text = "ประเภทรุ่นรถ";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(52, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 23);
            this.label4.TabIndex = 96;
            this.label4.Text = "รุ่นรถ";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(52, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 23);
            this.label3.TabIndex = 94;
            this.label3.Text = "ยี่ห้อรถ";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
            this.label2.Location = new System.Drawing.Point(172, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(8, 16);
            this.label2.TabIndex = 93;
            this.label2.Text = "-";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
            this.label1.Location = new System.Drawing.Point(52, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 90;
            this.label1.Text = "ทะเบียนรถ";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(52, 152);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 23);
            this.label15.TabIndex = 121;
            this.label15.Text = "Chassis No.";
            // 
            // txtChassisNo
            // 
            this.txtChassisNo.Enabled = false;
            this.txtChassisNo.Location = new System.Drawing.Point(124, 152);
            this.txtChassisNo.MaxLength = 50;
            this.txtChassisNo.Name = "txtChassisNo";
            this.txtChassisNo.Size = new System.Drawing.Size(312, 20);
            this.txtChassisNo.TabIndex = 122;
            this.txtChassisNo.Text = "";
            // 
            // frmCompulsoryInsuranceByPlate
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(882, 408);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.fpsCompulsoryByPlate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdDelete);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmCompulsoryInsuranceByPlate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCompulsoryInsuranceByPlate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fpsCompulsoryByPlate_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsCompulsoryByPlate)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

		private bool isReadonly = true;
        private FrmVehicleList objfrmVehicleList;
		private frmCompulsoryInsuranceEntry frmEntry;
		public CompulsoryInsuranceByPlateFacade facadeCompulsoryInsuranceByPlate;
		private frmMain mdiParent;

		//============================== Property ==============================
		private Vehicle oVehicle;
		private Vehicle OVehicle
		{
			set
			{
				txtPlatePrefix.Text = value.PlatePrefix;
				fpiPlateRunningNo.Text = value.PlateRunningNo;
				txtBrandName.Text = value.AModel.ABrand.AName.English;
				txtColorName.Text = value.AColor.AName.English;
				txtModelName.Text = value.AModel.AName.English;
				fpiNoOfSeat.Value = value.AModel.NoOfSeat;
				fpiCC.Value = value.AModel.EngineCC;
				txtModelTypeName.Text = value.AModel.AModelType.AName.Thai;
                txtChassisNo.Text = value.ChassisNo;

				YearMonth yearMonth1 = facadeCompulsoryInsuranceByPlate.CalculateAge(value.BuyDate);
				fpiAgeYear.Value = yearMonth1.Year;
				fpiAgeMonth.Value = yearMonth1.Month;

				YearMonth yearMonth2 = facadeCompulsoryInsuranceByPlate.CalculateAge(value.RegisterDate);
				fpiAgeCarYear.Value = yearMonth2.Year;
				fpiAgeCarMonth.Value = yearMonth2.Month;

				oVehicle = value;
			}
		}

		//============================== Constructor ==============================
		public frmCompulsoryInsuranceByPlate()
		{
			InitializeComponent();
			newObject();
			isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleDocumentCompulsoryPlate");
            this.title = UserProfile.GetFormName("miVehicle", "miVehicleDocumentCompulsoryPlate");

        }
        public override string FormID()
        {
            return UserProfile.GetFormID("miVehicle", "miVehicleDocumentCompulsoryPlate");
        }
		public void newObject()
		{
			facadeCompulsoryInsuranceByPlate = new CompulsoryInsuranceByPlateFacade();
			frmEntry = new frmCompulsoryInsuranceEntry(this);
		}
		//============================== Private Method ==============================
		private int SelectedRow
		{
			get
			{
				return fpsCompulsoryByPlate_Sheet1.ActiveRowIndex;
			}
		}

		private string SelectedKey
		{
			get
			{
				return fpsCompulsoryByPlate_Sheet1.Cells[SelectedRow,0].Text;
			}
		}

		private CompulsoryInsurance SelectedCompulsoryInsurance
		{
			get
			{
				return facadeCompulsoryInsuranceByPlate.CompulsoryInsuranceList[SelectedKey];
			}
		}

		private void enableVehicle(bool enabled)
		{
			txtBrandName.Enabled = enabled;
			txtColorName.Enabled = enabled;
			txtModelName.Enabled = enabled;
			fpiNoOfSeat.Enabled = enabled;
			fpiCC.Enabled = enabled;
			txtModelTypeName.Enabled = enabled;
            txtChassisNo.Enabled = enabled;
			fpiAgeYear.Enabled = enabled;
			fpiAgeMonth.Enabled = enabled;
		}

		private void clearVehicle()
		{
			txtBrandName.Text = "";
			txtColorName.Text = "";
			txtModelName.Text = "";
			txtModelTypeName.Text = "";
            txtChassisNo.Text = "";

			fpiNoOfSeat.Value = 0;
			fpiCC.Value = 0;
			fpiAgeYear.Value = 0;
			fpiAgeMonth.Value = 0;
		}

		private bool validateVehiclePlate()
		{
			if(txtPlatePrefix.Text == "")
			{
				Message(MessageList.Error.E0002, "ทะเบียนรถ");
				txtPlatePrefix.Focus();
				return false;
			}
			else if(fpiPlateRunningNo.Text == "")
			{
				Message(MessageList.Error.E0002, "ทะเบียนรถ");
				fpiPlateRunningNo.Focus();
				return false;
			}
			else
			{
				return true;
			}
		}

		private void bindCompulsoryInsurance(int row, CompulsoryInsurance value)
		{
			fpsCompulsoryByPlate_Sheet1.Cells[row,0].Text = GUIFunction.GetString(value.PolicyNo);
			fpsCompulsoryByPlate_Sheet1.Cells[row,1].Text = GUIFunction.GetString(value.PremiumAmount);
			fpsCompulsoryByPlate_Sheet1.Cells[row,2].Text = GUIFunction.GetString(value.RevenueStampFee);
			fpsCompulsoryByPlate_Sheet1.Cells[row,3].Text = GUIFunction.GetString(value.VatAmount) ;
			fpsCompulsoryByPlate_Sheet1.Cells[row,4].Text = GUIFunction.GetString(value.CompulsoryInsuranceAmount);
			fpsCompulsoryByPlate_Sheet1.Cells[row,5].Text = GUIFunction.GetString(value.APeriod.From.ToShortDateString());
			fpsCompulsoryByPlate_Sheet1.Cells[row,6].Text = GUIFunction.GetString(value.APeriod.To.ToShortDateString());
		}

		private void bindForm()
		{
			if(facadeCompulsoryInsuranceByPlate.CompulsoryInsuranceList.Count > 0)
			{
				fpsCompulsoryByPlate_Sheet1.RowCount = facadeCompulsoryInsuranceByPlate.CompulsoryInsuranceList.Count;
				for(int i=0; i<facadeCompulsoryInsuranceByPlate.CompulsoryInsuranceList.Count; i++)
				{
					bindCompulsoryInsurance(i, facadeCompulsoryInsuranceByPlate.CompulsoryInsuranceList[i]);
				}	
				mdiParent.RefreshMasterCount();
				enableButton(true);
			}
			else
			{
				fpsCompulsoryByPlate_Sheet1.RowCount = 0;
				enableButton(false);
			}
		}

		private Vehicle getVehicle()
		{
			return facadeCompulsoryInsuranceByPlate.GetVehicle(txtPlatePrefix.Text, fpiPlateRunningNo.Text);
		}

		private void visibleButton(bool visible)
		{
			cmdAdd.Visible = visible;
			cmdEdit.Visible = visible;
			cmdDelete.Visible = visible;
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
			fpsCompulsoryByPlate_Sheet1.RowCount = 0;
			enableButton(false);
		}

		private void clearAll()
		{
			clearVehicle();
			clearForm();
			fpsCompulsoryByPlate.Visible = false;
			visibleButton(false);
			enableButton(false);
		}

		//============================== Public Method ==============================
		public bool AddRow(CompulsoryInsurance value)
		{
			if (facadeCompulsoryInsuranceByPlate.InsertCompulsoryInsurance(value))
			{
				if(fpsCompulsoryByPlate_Sheet1.RowCount == 0)
				{
					fpsCompulsoryByPlate.Visible = true;
				}
				fpsCompulsoryByPlate_Sheet1.RowCount++;
				bindCompulsoryInsurance(fpsCompulsoryByPlate_Sheet1.RowCount-1, value);
				enableButton(true);
				mdiParent.RefreshMasterCount();
				return true;
			}
			else
			{				
				return false;
			}
		}

		public bool UpdateRow(CompulsoryInsurance value)
		{
			if (facadeCompulsoryInsuranceByPlate.UpdateCompulsoryInsurance(value))
			{
				bindCompulsoryInsurance(SelectedRow, value);				
				return true;
			}
			else
			{				
				return false;
			}
		}

		public void DeleteRow()
		{
			if (facadeCompulsoryInsuranceByPlate.DeleteCompulsoryInsurance(SelectedCompulsoryInsurance))
			{
				if(fpsCompulsoryByPlate_Sheet1.RowCount > 1)
				{
					fpsCompulsoryByPlate_Sheet1.Rows.Remove(SelectedRow, 1);
				}
				else
				{
					clearForm();
				}
				mdiParent.RefreshMasterCount();
			}
		}
		public override int MasterCount()
		{
			return facadeCompulsoryInsuranceByPlate.CompulsoryInsuranceList.Count;
		}

		//============================== Base Event ==============================
		public void InitForm()
		{	
			txtPlatePrefix.Text = "";
			fpiPlateRunningNo.Text = "";
			txtPlatePrefix.Enabled = true;
			fpiPlateRunningNo.Enabled = true;
			clearAll();
			newObject();
			mdiParent.RefreshMasterCount();
		}

		public void RefreshForm()
		{
			try
			{
				if(validateVehiclePlate())
				{
					Vehicle vehicle = getVehicle();				
					if(vehicle!=null)
					{
						OVehicle = vehicle;
						visibleButton(true);						
						if(facadeCompulsoryInsuranceByPlate.DisplayCompulsoryInsurance(oVehicle))
						{							
							bindForm();
						}
						else
						{
							fpsCompulsoryByPlate_Sheet1.RowCount = 0;
							enableButton(false);
						}
						fpsCompulsoryByPlate.Visible = true;
						txtPlatePrefix.Enabled = false;
						fpiPlateRunningNo.Enabled = false;
						MainMenuNewStatus = true;
						MainMenuRefreshStatus = true;
						mdiParent.EnableNewCommand(true);
						mdiParent.EnableRefreshCommand(true);
					}
					else
					{
						Message(MessageList.Error.E0004, "ทะเบียนรถ");
						fpiPlateRunningNo.Focus();
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

			if(isReadonly)
			{
				cmdAdd.Enabled = false;
				mniAdd.Enabled = false;
				cmdDelete.Enabled = false;
				mniDelete.Enabled = false;
			}
		}

		public void PrintForm()
		{}

		public void ExitForm()
		{
			this.Close();
		}

		private void AddEvent()
		{
			try
			{
				frmEntry.InitAddAction(oVehicle);
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

		private void EditEvent()
		{
			try
			{
				frmEntry.InitEditAction(SelectedCompulsoryInsurance);
				frmEntry.Vehicle = oVehicle;
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

		private void DeleteEvent()
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

		private void callList()
		{
			try
			{
                objfrmVehicleList = new FrmVehicleList();
				objfrmVehicleList.ConditionPlatePrefix = txtPlatePrefix.Text;
				objfrmVehicleList.ConditionPlateRunningNo = fpiPlateRunningNo.Text;
				objfrmVehicleList.ShowDialog();
				if(objfrmVehicleList.Selected)
				{
					txtPlatePrefix.Text = objfrmVehicleList.SelectedVehicle.PlatePrefix;
					fpiPlateRunningNo.Text = objfrmVehicleList.SelectedVehicle.PlateRunningNo;
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

		//============================== event ==============================
		private void frmCompulsoryInsuranceByPlate_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
		}
		
		private void fpiPlateRunningNo_DoubleClick(object sender, System.EventArgs e)
		{
			callList();
		}

		private void fpiPlateRunningNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				RefreshForm();
			}
		}

		private void fpiPlateRunningNo_TextChanged(object sender, System.EventArgs e)
		{
			lblPlateNo.Text = fpiPlateRunningNo.Text;
			if(fpiPlateRunningNo.Text.Length == 4)
			{
				RefreshForm();
			}
		}

		private void txtPlatePrefix_TextChanged(object sender, System.EventArgs e)
		{
			lblPlatePrefix.Text = txtPlatePrefix.Text;
            if (txtPlatePrefix.Text.Length == txtPlatePrefix.MaxLength)
			{
				fpiPlateRunningNo.Focus();
			}
		}

		private void fpsCompulsoryByPlate_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader)
			{
				EditEvent();
			}
		}

		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
			AddEvent();
		}

		private void cmdEdit_Click(object sender, System.EventArgs e)
		{
			EditEvent();
		}

		private void cmdDelete_Click(object sender, System.EventArgs e)
		{
			DeleteEvent();
		}

		private void mniAdd_Click(object sender, System.EventArgs e)
		{
			AddEvent();
		}

		private void mniEdit_Click(object sender, System.EventArgs e)
		{
			EditEvent();
		}

		private void mniDelete_Click(object sender, System.EventArgs e)
		{
			DeleteEvent();
		}
	}
}