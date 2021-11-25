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

using Presentation.CommonGUI;
using Presentation.PiGUI;

namespace Presentation.AttendanceGUI
{
	public class frmEmployeeFoodBenefit : frmAttendanceHeadBase
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

		private System.Windows.Forms.MenuItem mniEdit;
		private System.Windows.Forms.MenuItem mniAdd;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem mniDelete;
		private FarPoint.Win.Spread.SheetView fpsFoodBenefit_Sheet1;
		private FarPoint.Win.Spread.FpSpread fpsFoodBenefit;
		private System.Windows.Forms.DateTimePicker dtpForMonth;
		private System.Windows.Forms.Label lblForMonth;

		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
			FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
			this.mniEdit = new System.Windows.Forms.MenuItem();
			this.dtpForMonth = new System.Windows.Forms.DateTimePicker();
			this.mniAdd = new System.Windows.Forms.MenuItem();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			this.fpsFoodBenefit_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.fpsFoodBenefit = new FarPoint.Win.Spread.FpSpread();
			this.lblForMonth = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.fpsFoodBenefit_Sheet1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsFoodBenefit)).BeginInit();
			this.SuspendLayout();
			// 
			// pctEmployee
			// 
			this.pctEmployee.Name = "pctEmployee";
			// 
			// mniEdit
			// 
			this.mniEdit.Index = 1;
			this.mniEdit.Text = "แก้ไข";
			this.mniEdit.Visible = false;
			this.mniEdit.Click += new System.EventHandler(this.mniEdit_Click);
			// 
			// dtpForMonth
			// 
			this.dtpForMonth.CustomFormat = "MM/yyyy";
			this.dtpForMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpForMonth.Location = new System.Drawing.Point(488, 152);
			this.dtpForMonth.Name = "dtpForMonth";
			this.dtpForMonth.Size = new System.Drawing.Size(80, 20);
			this.dtpForMonth.TabIndex = 2;
			this.dtpForMonth.ValueChanged += new System.EventHandler(this.dtpForMonth_ValueChanged);
			// 
			// mniAdd
			// 
			this.mniAdd.Index = 0;
			this.mniAdd.Text = "เพิ่ม";
			this.mniAdd.Click += new System.EventHandler(this.mniAdd_Click);
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.mniAdd,
																						 this.mniEdit,
																						 this.mniDelete});
			// 
			// mniDelete
			// 
			this.mniDelete.Index = 2;
			this.mniDelete.Text = "ลบ";
			this.mniDelete.Click += new System.EventHandler(this.mniDelete_Click);
			// 
			// fpsFoodBenefit_Sheet1
			// 
			this.fpsFoodBenefit_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsFoodBenefit_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsFoodBenefit_Sheet1.ColumnCount = 3;
			this.fpsFoodBenefit_Sheet1.RowCount = 1;
			this.fpsFoodBenefit_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "วันที่";
			this.fpsFoodBenefit_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "จำนวนเงิน";
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsFoodBenefit_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsFoodBenefit_Sheet1.Columns.Get(0).Visible = false;
			this.fpsFoodBenefit_Sheet1.Columns.Get(1).AllowAutoSort = true;
			numberCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			numberCellType1.DecimalPlaces = 0;
			numberCellType1.DropDownButton = false;
			numberCellType1.MinimumValue = 0;
			numberCellType1.ReadOnly = true;
			this.fpsFoodBenefit_Sheet1.Columns.Get(1).CellType = numberCellType1;
			this.fpsFoodBenefit_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsFoodBenefit_Sheet1.Columns.Get(1).Label = "วันที่";
			this.fpsFoodBenefit_Sheet1.Columns.Get(1).Width = 84F;
			this.fpsFoodBenefit_Sheet1.Columns.Get(2).AllowAutoSort = true;
			numberCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			numberCellType2.DecimalPlaces = 0;
			numberCellType2.DropDownButton = false;
			numberCellType2.MinimumValue = 0;
			numberCellType2.Separator = ",";
			numberCellType2.ShowSeparator = true;
			this.fpsFoodBenefit_Sheet1.Columns.Get(2).CellType = numberCellType2;
			this.fpsFoodBenefit_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
			this.fpsFoodBenefit_Sheet1.Columns.Get(2).Label = "จำนวนเงิน";
			this.fpsFoodBenefit_Sheet1.Columns.Get(2).Width = 195F;
			this.fpsFoodBenefit_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
			this.fpsFoodBenefit_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsFoodBenefit_Sheet1.RowHeader.Rows.Default.Resizable = false;
			this.fpsFoodBenefit_Sheet1.Rows.Default.Resizable = false;
			this.fpsFoodBenefit_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsFoodBenefit_Sheet1.SheetName = "Sheet1";
			this.fpsFoodBenefit_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// fpsFoodBenefit
			// 
			this.fpsFoodBenefit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsFoodBenefit.ContextMenu = this.contextMenu1;
			this.fpsFoodBenefit.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsFoodBenefit.Location = new System.Drawing.Point(316, 184);
			this.fpsFoodBenefit.Name = "fpsFoodBenefit";
			this.fpsFoodBenefit.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																						this.fpsFoodBenefit_Sheet1});
			this.fpsFoodBenefit.Size = new System.Drawing.Size(336, 233);
			this.fpsFoodBenefit.TabIndex = 22;
			this.fpsFoodBenefit.TabStop = false;
			// 
			// lblForMonth
			// 
			this.lblForMonth.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblForMonth.Location = new System.Drawing.Point(404, 152);
			this.lblForMonth.Name = "lblForMonth";
			this.lblForMonth.Size = new System.Drawing.Size(64, 16);
			this.lblForMonth.TabIndex = 26;
			this.lblForMonth.Text = "สำหรับเดือน";
			// 
			// frmEmployeeFoodBenefit
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(968, 488);
			this.Controls.Add(this.dtpForMonth);
			this.Controls.Add(this.fpsFoodBenefit);
			this.Controls.Add(this.lblForMonth);
			this.Name = "frmEmployeeFoodBenefit";
            //this.Text = "frmEmployeeFoodBenefit";
			this.Load += new System.EventHandler(this.frmEmployeeFoodBenefit_Load);
			this.Controls.SetChildIndex(this.lblForMonth, 0);
			this.Controls.SetChildIndex(this.fpsFoodBenefit, 0);
			this.Controls.SetChildIndex(this.dtpForMonth, 0);
			((System.ComponentModel.ISupportInitialize)(this.fpsFoodBenefit_Sheet1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsFoodBenefit)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private bool isChange = true;
		private frmEmployeeFoodBenefitEntry frmEntry;
		#endregion

//		============================== Property ==============================		
		private EmployeeFoodBenefitFacade facadeEmployeeFoodBenefit;
		public EmployeeFoodBenefitFacade FacadeEmployeeFoodBenefit
		{
			get{return facadeEmployeeFoodBenefit;}
		}

		private int SelectedRow
		{
			get{return fpsFoodBenefit_Sheet1.ActiveRowIndex;}
		}

		private string SelectedKey
		{
			get{return fpsFoodBenefit_Sheet1.Cells[SelectedRow,0].Text;}
		}
	
		private FoodBenefit selectedFoodBenefit
		{
			get{return facadeEmployeeFoodBenefit.ObjEmployeeFoodBenefit[SelectedKey];}
		}


//		============================== Constructor ==============================
		public frmEmployeeFoodBenefit() : base()
		{
			InitializeComponent();
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miEmployeeFoodBenefit");
            this.title = UserProfile.GetFormName("miAttendance", "miEmployeeFoodBenefit");

		}
        public override string FormID()
        {
            return UserProfile.GetFormID("miAttendance", "miEmployeeFoodBenefit");
        }

//		==============================Private method ==============================
		private void bindForm()
		{
			if (facadeEmployeeFoodBenefit.ObjEmployeeFoodBenefit != null)
			{
				int iRow = facadeEmployeeFoodBenefit.ObjEmployeeFoodBenefit.Count;
				fpsFoodBenefit_Sheet1.RowCount = iRow;
				for(int i=0; i<iRow; i++)
				{
					bindFoodBenefit(i, facadeEmployeeFoodBenefit.ObjEmployeeFoodBenefit[i]);
				}		
				mdiParent.RefreshMasterCount();
			}
            fpsFoodBenefit_Sheet1.SetActiveCell(fpsFoodBenefit_Sheet1.RowCount, 0);
		}
		
		private void bindFoodBenefit(int row, FoodBenefit value)
		{
			fpsFoodBenefit_Sheet1.Cells.Get(row,0).Text = GUIFunction.GetString(value.EntityKey);
			fpsFoodBenefit_Sheet1.Cells.Get(row,1).Text = GUIFunction.GetString(value.BenefitDate.Day);
			fpsFoodBenefit_Sheet1.Cells.Get(row,2).Text = GUIFunction.GetString(value.TotalAmount);
		}

		private void clearForm()
		{	
			visibleForm(false);
			fpsFoodBenefit_Sheet1.RowCount = 0;
			enableButton(false);
		}

//		==========================Public Method========================
		public bool AddRow(FoodBenefit value)
		{
			if (facadeEmployeeFoodBenefit.InsertFoodBenefit(value))
			{
				fpsFoodBenefit_Sheet1.RowCount++;
				bindFoodBenefit(fpsFoodBenefit_Sheet1.RowCount-1, value);
                fpsFoodBenefit_Sheet1.SetActiveCell(fpsFoodBenefit_Sheet1.RowCount, 0);
				enableButton(true);
				mdiParent.RefreshMasterCount();
				return true;
			}				
			return false;
		}

		public bool UpdateRow(FoodBenefit value)
		{
			if (facadeEmployeeFoodBenefit.UpdateFoodBenefit(value))
			{
				bindFoodBenefit(SelectedRow, value);				
				return true;
			}				
			return false;
		}

		private void DeleteRow()
		{
			if (facadeEmployeeFoodBenefit.DeleteFoodBenefit(selectedFoodBenefit))
			{
				if(fpsFoodBenefit_Sheet1.RowCount > 1)
				{
					fpsFoodBenefit.ActiveSheet.Rows.Remove(SelectedRow,1);
				}
				else
				{
					fpsFoodBenefit_Sheet1.RowCount = 0;
					enableButton(false);
				}				

				mdiParent.RefreshMasterCount();
			}
		}

		public override int MasterCount()
		{
			return facadeEmployeeFoodBenefit.ObjEmployeeFoodBenefit.Count;
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
			fpsFoodBenefit.Visible = value;
			lblForMonth.Visible = value;
			dtpForMonth.Visible = value;
		}

		protected override void addEvent()
		{
			try
			{
				frmEntry = new frmEmployeeFoodBenefitEntry(this);
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
				frmEntry = new frmEmployeeFoodBenefitEntry(this);
				frmEntry.InitEditAction(selectedFoodBenefit);
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
			facadeEmployeeAttendance = new EmployeeFoodBenefitFacade();
			facadeEmployeeFoodBenefit = (EmployeeFoodBenefitFacade)facadeEmployeeAttendance;
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
				if (facadeEmployeeFoodBenefit.DisplayEmployeeFoodBenefit(dtpForMonth.Value))
				{	
					enableButton(true);
					visibleForm(true);
					bindForm();
				}
				else
				{
					visibleForm(true);
					fpsFoodBenefit_Sheet1.RowCount = 0;
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
		private void frmEmployeeFoodBenefit_Load(object sender, System.EventArgs e)
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

		private void dtpForMonth_ValueChanged(object sender, System.EventArgs e)
		{
			if(isChange)
			{
				RefreshForm();
			}
		}
	}
}
