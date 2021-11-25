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
using ictus.PIS.PI.Entity;

using Facade.CommonFacade;
using Facade.AttendanceFacade;

using Presentation.CommonGUI;
using Presentation.PiGUI;

namespace Presentation.AttendanceGUI
{
	public class frmEmployeeTelephoneBenefit : frmAttendanceHeadBase
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

		private FarPoint.Win.Spread.SheetView fpsTelephoneBenefit_Sheet1;
		private FarPoint.Win.Spread.FpSpread fpsTelephoneBenefit;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem mniAdd;
		private System.Windows.Forms.MenuItem mniEdit;
		private System.Windows.Forms.MenuItem mniDelete;
		private System.Windows.Forms.DateTimePicker dtpForYear;
		private System.Windows.Forms.Label lblForYear;

		private System.ComponentModel.Container components = null;
		private void InitializeComponent()
		{
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
			FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
			this.fpsTelephoneBenefit_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.fpsTelephoneBenefit = new FarPoint.Win.Spread.FpSpread();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mniAdd = new System.Windows.Forms.MenuItem();
			this.mniEdit = new System.Windows.Forms.MenuItem();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			this.lblForYear = new System.Windows.Forms.Label();
			this.dtpForYear = new System.Windows.Forms.DateTimePicker();
			((System.ComponentModel.ISupportInitialize)(this.fpsTelephoneBenefit_Sheet1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsTelephoneBenefit)).BeginInit();
			this.SuspendLayout();
			// 
			// pctEmployee
			// 
			this.pctEmployee.Name = "pctEmployee";
			// 
			// fpsTelephoneBenefit_Sheet1
			// 
			this.fpsTelephoneBenefit_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsTelephoneBenefit_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsTelephoneBenefit_Sheet1.ColumnCount = 3;
			this.fpsTelephoneBenefit_Sheet1.RowCount = 1;
			this.fpsTelephoneBenefit_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "เดือน";
			this.fpsTelephoneBenefit_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "จำนวนเงิน";
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsTelephoneBenefit_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsTelephoneBenefit_Sheet1.Columns.Get(0).Visible = false;
			this.fpsTelephoneBenefit_Sheet1.Columns.Get(1).AllowAutoSort = true;
			numberCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			numberCellType1.DecimalPlaces = 0;
			numberCellType1.DropDownButton = false;
			numberCellType1.MinimumValue = 0;
			numberCellType1.ReadOnly = true;
			this.fpsTelephoneBenefit_Sheet1.Columns.Get(1).CellType = numberCellType1;
			this.fpsTelephoneBenefit_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsTelephoneBenefit_Sheet1.Columns.Get(1).Label = "เดือน";
			this.fpsTelephoneBenefit_Sheet1.Columns.Get(1).Width = 70F;
			this.fpsTelephoneBenefit_Sheet1.Columns.Get(2).AllowAutoSort = true;
			numberCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			numberCellType2.DecimalPlaces = 0;
			numberCellType2.DropDownButton = false;
			numberCellType2.MaximumValue = 999999;
			numberCellType2.MinimumValue = 0;
			numberCellType2.Separator = ",";
			numberCellType2.ShowSeparator = true;
			this.fpsTelephoneBenefit_Sheet1.Columns.Get(2).CellType = numberCellType2;
			this.fpsTelephoneBenefit_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
			this.fpsTelephoneBenefit_Sheet1.Columns.Get(2).Label = "จำนวนเงิน";
			this.fpsTelephoneBenefit_Sheet1.Columns.Get(2).Width = 195F;
			this.fpsTelephoneBenefit_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
			this.fpsTelephoneBenefit_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsTelephoneBenefit_Sheet1.RowHeader.Rows.Default.Resizable = false;
			this.fpsTelephoneBenefit_Sheet1.Rows.Default.Resizable = false;
			this.fpsTelephoneBenefit_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsTelephoneBenefit_Sheet1.SheetName = "Sheet1";
			this.fpsTelephoneBenefit_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// fpsTelephoneBenefit
			// 
			this.fpsTelephoneBenefit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsTelephoneBenefit.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsTelephoneBenefit.Location = new System.Drawing.Point(324, 180);
			this.fpsTelephoneBenefit.Name = "fpsTelephoneBenefit";
			this.fpsTelephoneBenefit.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																							 this.fpsTelephoneBenefit_Sheet1});
			this.fpsTelephoneBenefit.Size = new System.Drawing.Size(321, 233);
			this.fpsTelephoneBenefit.TabIndex = 16;
			this.fpsTelephoneBenefit.TabStop = false;
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
			this.mniEdit.Visible = false;
			this.mniEdit.Click += new System.EventHandler(this.mniEdit_Click);
			// 
			// mniDelete
			// 
			this.mniDelete.Index = 2;
			this.mniDelete.Text = "ลบ";
			this.mniDelete.Click += new System.EventHandler(this.mniDelete_Click);
			// 
			// lblForYear
			// 
			this.lblForYear.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblForYear.Location = new System.Drawing.Point(430, 144);
			this.lblForYear.Name = "lblForYear";
			this.lblForYear.Size = new System.Drawing.Size(48, 16);
			this.lblForYear.TabIndex = 20;
			this.lblForYear.Text = "สำหรับปี";
			// 
			// dtpForYear
			// 
			this.dtpForYear.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.dtpForYear.CustomFormat = "yyyy";
			this.dtpForYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpForYear.Location = new System.Drawing.Point(486, 144);
			this.dtpForYear.Name = "dtpForYear";
			this.dtpForYear.ShowUpDown = true;
			this.dtpForYear.Size = new System.Drawing.Size(54, 20);
			this.dtpForYear.TabIndex = 2;
			this.dtpForYear.ValueChanged += new System.EventHandler(this.dtpForYear_ValueChanged);
			// 
			// frmEmployeeTelephoneBenefit
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(968, 488);
			this.ContextMenu = this.contextMenu1;
			this.Controls.Add(this.fpsTelephoneBenefit);
			this.Controls.Add(this.lblForYear);
			this.Controls.Add(this.dtpForYear);
			this.Name = "frmEmployeeTelephoneBenefit";
            //this.Text = "frmEmployeeTelephoneBenefit";
			this.Load += new System.EventHandler(this.frmEmployeeTelephoneBenefit_Load);
			this.Controls.SetChildIndex(this.dtpForYear, 0);
			this.Controls.SetChildIndex(this.lblForYear, 0);
			this.Controls.SetChildIndex(this.fpsTelephoneBenefit, 0);
			((System.ComponentModel.ISupportInitialize)(this.fpsTelephoneBenefit_Sheet1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsTelephoneBenefit)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private bool isTextChange = true;
		private frmEmployeeTelephoneBenefitEntry frmEntry;
		#endregion

//		============================== Property ==============================		
		private EmployeeTelephoneBenefitFacade facadeEmployeeTelephoneBenefit;
		public EmployeeTelephoneBenefitFacade FacadeEmployeeTelephoneBenefit
		{
			get{return facadeEmployeeTelephoneBenefit;}
		}

		private int SelectedRow
		{
			get{return fpsTelephoneBenefit_Sheet1.ActiveRowIndex;}
		}

		private string SelectedKey
		{
			get{return fpsTelephoneBenefit_Sheet1.Cells[SelectedRow,0].Text;}
		}
	
		private TelephoneBenefit selectedTelephoneBenefit
		{
			get{return facadeEmployeeTelephoneBenefit.ObjEmployeeTelephoneBenefit[SelectedKey];}
		}

//		============================== Constructor ==============================
		public frmEmployeeTelephoneBenefit() : base()
		{
			InitializeComponent();
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miEmployeeTelephoneBenefit");
            this.title = UserProfile.GetFormName("miAttendance", "miEmployeeTelephoneBenefit");

		}
        public override string FormID()
        {
            return UserProfile.GetFormID("miAttendance", "miEmployeeTelephoneBenefit");
        }

//		==============================Private method ==============================
		private void bindForm()
		{
			if (facadeEmployeeTelephoneBenefit.ObjEmployeeTelephoneBenefit != null)
			{
				int iRow = facadeEmployeeTelephoneBenefit.ObjEmployeeTelephoneBenefit.Count;
				fpsTelephoneBenefit_Sheet1.RowCount = iRow;
				for(int i=0; i<iRow; i++)
				{
					bindTelephoneBenefit(i, facadeEmployeeTelephoneBenefit.ObjEmployeeTelephoneBenefit[i]);
				}	
				mdiParent.RefreshMasterCount();
			}
            fpsTelephoneBenefit_Sheet1.SetActiveCell(fpsTelephoneBenefit_Sheet1.RowCount, 0);
		}
		
		private void bindTelephoneBenefit(int row, TelephoneBenefit value)
		{
			fpsTelephoneBenefit_Sheet1.Cells.Get(row,0).Text = GUIFunction.GetString(value.EntityKey);
			fpsTelephoneBenefit_Sheet1.Cells.Get(row,1).Text = GUIFunction.GetString(value.AYearMonth.Month);
			fpsTelephoneBenefit_Sheet1.Cells.Get(row,2).Text = GUIFunction.GetString(value.TotalAmount);
		}

		private void clearForm()
		{	
			visibleForm(false);
			fpsTelephoneBenefit_Sheet1.RowCount = 0;
			enableButton(false);
		}

//		==========================Public Method========================
		public bool AddRow(TelephoneBenefit value)
		{
			if (facadeEmployeeTelephoneBenefit.InsertTelephoneBenefit(value))
			{
				fpsTelephoneBenefit_Sheet1.RowCount++;
				bindTelephoneBenefit(fpsTelephoneBenefit_Sheet1.RowCount-1, value);
                fpsTelephoneBenefit_Sheet1.SetActiveCell(fpsTelephoneBenefit_Sheet1.RowCount, 0);
				enableButton(true);
				mdiParent.RefreshMasterCount();
				return true;
			}				
			return false;
		}

		public bool UpdateRow(TelephoneBenefit value)
		{
			if (facadeEmployeeTelephoneBenefit.UpdateTelephoneBenefit(value))
			{
				bindTelephoneBenefit(SelectedRow, value);				
				return true;
			}				
			return false;
		}

		private void DeleteRow()
		{
			if (facadeEmployeeTelephoneBenefit.DeleteTelephoneBenefit(selectedTelephoneBenefit))
			{
				if(fpsTelephoneBenefit_Sheet1.RowCount > 1)
				{
					fpsTelephoneBenefit.ActiveSheet.Rows.Remove(SelectedRow,1);
				}
				else
				{
					fpsTelephoneBenefit_Sheet1.RowCount = 0;
					enableButton(false);
				}				
				mdiParent.RefreshMasterCount();
			}
		}

		public override int MasterCount()
		{
			return facadeEmployeeTelephoneBenefit.ObjEmployeeTelephoneBenefit.Count;
		}

//		==============================Protected method ==============================
		protected override void enableButton(bool value)
		{
			base.enableButton(value);
			base.enableEditButton(false);
			mniEdit.Enabled = value;
			mniDelete.Enabled = value;
		}

		protected override void visibleForm(bool value)
		{
			base.visibleForm(value);
			fpsTelephoneBenefit.Visible = value;
			lblForYear.Visible = value;
			dtpForYear.Visible = value;
		}

		protected override void addEvent()
		{
			try
			{
				frmEntry = new frmEmployeeTelephoneBenefitEntry(this);
				frmEntry.InitAddAction(dtpForYear.Value);
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
				frmEntry = new frmEmployeeTelephoneBenefitEntry(this);
				frmEntry.InitEditAction(selectedTelephoneBenefit);
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
			facadeEmployeeAttendance = new EmployeeTelephoneBenefitFacade();
			facadeEmployeeTelephoneBenefit = (EmployeeTelephoneBenefitFacade)facadeEmployeeAttendance;
			isTextChange = false;
			dtpForYear.Value = new System.DateTime(DateTime.Today.Year, 1, 1, 0, 0, 0, 0);
			isTextChange = true;
			mdiParent.RefreshMasterCount();
		}

		public override void RefreshForm()
		{
			base.RefreshForm();

			try
			{
				if (facadeEmployeeTelephoneBenefit.DisplayTelephoneBenefit(dtpForYear.Value))
				{	
					enableButton(true);
					visibleForm(true);
					bindForm();
				}
				else
				{
					visibleForm(true);
					fpsTelephoneBenefit_Sheet1.RowCount = 0;
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
		private void frmEmployeeTelephoneBenefit_Load(object sender, System.EventArgs e)
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

		private void dtpForYear_ValueChanged(object sender, System.EventArgs e)
		{
			if(isTextChange)
			{
				RefreshForm();
			}
		}
	}
}
