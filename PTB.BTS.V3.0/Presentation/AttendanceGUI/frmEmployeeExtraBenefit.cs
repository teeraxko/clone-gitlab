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
	public class frmEmployeeExtraBenefit : frmAttendanceHeadBase
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
		private System.Windows.Forms.MenuItem mniAdd;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem mniEdit;
		private System.Windows.Forms.MenuItem mniDelete;
		private System.Windows.Forms.Label lblForYear;
		private System.Windows.Forms.DateTimePicker dtpForYear;
		private FarPoint.Win.Spread.FpSpread fpsExtraBenefit;
		private FarPoint.Win.Spread.SheetView fpsExtraBenefit_Sheet1;

		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
			FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
			this.mniAdd = new System.Windows.Forms.MenuItem();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mniEdit = new System.Windows.Forms.MenuItem();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			this.fpsExtraBenefit = new FarPoint.Win.Spread.FpSpread();
			this.fpsExtraBenefit_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.lblForYear = new System.Windows.Forms.Label();
			this.dtpForYear = new System.Windows.Forms.DateTimePicker();
			((System.ComponentModel.ISupportInitialize)(this.fpsExtraBenefit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsExtraBenefit_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// pctEmployee
			// 
			this.pctEmployee.Name = "pctEmployee";
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
			// fpsExtraBenefit
			// 
			this.fpsExtraBenefit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsExtraBenefit.ContextMenu = this.contextMenu1;
			this.fpsExtraBenefit.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsExtraBenefit.Location = new System.Drawing.Point(309, 184);
			this.fpsExtraBenefit.Name = "fpsExtraBenefit";
			this.fpsExtraBenefit.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																						 this.fpsExtraBenefit_Sheet1});
			this.fpsExtraBenefit.Size = new System.Drawing.Size(351, 233);
			this.fpsExtraBenefit.TabIndex = 29;
			this.fpsExtraBenefit.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsExtraBenefit_CellDoubleClick);
			// 
			// fpsExtraBenefit_Sheet1
			// 
			this.fpsExtraBenefit_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsExtraBenefit_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsExtraBenefit_Sheet1.ColumnCount = 3;
			this.fpsExtraBenefit_Sheet1.RowCount = 1;
			this.fpsExtraBenefit_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "เดือน";
			this.fpsExtraBenefit_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "จำนวนเงิน";
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsExtraBenefit_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsExtraBenefit_Sheet1.Columns.Get(0).Visible = false;
			this.fpsExtraBenefit_Sheet1.Columns.Get(1).AllowAutoSort = true;
			numberCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			numberCellType1.DecimalPlaces = 0;
			numberCellType1.DropDownButton = false;
			numberCellType1.MinimumValue = 0;
			numberCellType1.ReadOnly = true;
			this.fpsExtraBenefit_Sheet1.Columns.Get(1).CellType = numberCellType1;
			this.fpsExtraBenefit_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsExtraBenefit_Sheet1.Columns.Get(1).Label = "เดือน";
			this.fpsExtraBenefit_Sheet1.Columns.Get(1).Resizable = false;
			this.fpsExtraBenefit_Sheet1.Columns.Get(1).Width = 70F;
			this.fpsExtraBenefit_Sheet1.Columns.Get(2).AllowAutoSort = true;
			numberCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			numberCellType2.DecimalPlaces = 0;
			numberCellType2.DropDownButton = false;
			numberCellType2.MinimumValue = 0;
			numberCellType2.Separator = ",";
			numberCellType2.ShowSeparator = true;
			this.fpsExtraBenefit_Sheet1.Columns.Get(2).CellType = numberCellType2;
			this.fpsExtraBenefit_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
			this.fpsExtraBenefit_Sheet1.Columns.Get(2).Label = "จำนวนเงิน";
			this.fpsExtraBenefit_Sheet1.Columns.Get(2).Resizable = false;
			this.fpsExtraBenefit_Sheet1.Columns.Get(2).Width = 224F;
			this.fpsExtraBenefit_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
			this.fpsExtraBenefit_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsExtraBenefit_Sheet1.RowHeader.Rows.Default.Resizable = false;
			this.fpsExtraBenefit_Sheet1.Rows.Default.Resizable = false;
			this.fpsExtraBenefit_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsExtraBenefit_Sheet1.SheetName = "Sheet1";
			this.fpsExtraBenefit_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// lblForYear
			// 
			this.lblForYear.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblForYear.Location = new System.Drawing.Point(424, 144);
			this.lblForYear.Name = "lblForYear";
			this.lblForYear.Size = new System.Drawing.Size(48, 16);
			this.lblForYear.TabIndex = 37;
			this.lblForYear.Text = "สำหรับปี";
			// 
			// dtpForYear
			// 
			this.dtpForYear.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.dtpForYear.CustomFormat = "yyyy";
			this.dtpForYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpForYear.Location = new System.Drawing.Point(480, 144);
			this.dtpForYear.Name = "dtpForYear";
			this.dtpForYear.ShowUpDown = true;
			this.dtpForYear.Size = new System.Drawing.Size(64, 20);
			this.dtpForYear.TabIndex = 2;
			this.dtpForYear.ValueChanged += new System.EventHandler(this.dtpForYear_ValueChanged);
			// 
			// frmEmployeeExtraBenefit
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(968, 488);
			this.Controls.Add(this.lblForYear);
			this.Controls.Add(this.dtpForYear);
			this.Controls.Add(this.fpsExtraBenefit);
			this.Name = "frmEmployeeExtraBenefit";
            //this.Text = "frmEmployeeExtraBenefit";
			this.Load += new System.EventHandler(this.frmEmployeeExtraBenefit_Load);
			this.Controls.SetChildIndex(this.fpsExtraBenefit, 0);
			this.Controls.SetChildIndex(this.dtpForYear, 0);
			this.Controls.SetChildIndex(this.lblForYear, 0);
			((System.ComponentModel.ISupportInitialize)(this.fpsExtraBenefit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsExtraBenefit_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private bool isChange = true;
		private frmEmployeeExtraBenefitEntry frmEntry;
		#endregion

//		============================== Property ==============================		
		private EmployeeExtraBenefitFacade facadeEmployeeExtraBenefit;
		public EmployeeExtraBenefitFacade FacadeEmployeeExtraBenefit
		{
			get{return facadeEmployeeExtraBenefit;}
		}

		private int SelectedRow
		{
			get{return fpsExtraBenefit_Sheet1.ActiveRowIndex;}
		}

		private string SelectedKey
		{
			get{return fpsExtraBenefit_Sheet1.Cells[SelectedRow,0].Text;}
		}
	
		private ExtraBenefit selectedExtraBenefit
		{
			get{return facadeEmployeeExtraBenefit.ObjEmployeeExtraBenefit[SelectedKey];}
		}

//		============================== Constructor ==============================
		public frmEmployeeExtraBenefit() : base()
		{
			InitializeComponent();
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miEmployeeExtraBenefit");
            this.title = UserProfile.GetFormName("miAttendance", "miEmployeeExtraBenefit");

		}
        public override string FormID()
        {
            return UserProfile.GetFormID("miAttendance", "miEmployeeExtraBenefit");
        }

//		==============================Private method ==============================
		private void bindForm()
		{
			if (facadeEmployeeExtraBenefit.ObjEmployeeExtraBenefit != null)
			{
				int iRow = facadeEmployeeExtraBenefit.ObjEmployeeExtraBenefit.Count;
				fpsExtraBenefit_Sheet1.RowCount = iRow;
				for(int i=0; i<iRow; i++)
				{
					bindExtraBenefit(i, facadeEmployeeExtraBenefit.ObjEmployeeExtraBenefit[i]);
				}
				mdiParent.RefreshMasterCount();
			}
            fpsExtraBenefit_Sheet1.SetActiveCell(fpsExtraBenefit_Sheet1.RowCount, 0);
		}
		
		private void bindExtraBenefit(int row, ExtraBenefit value)
		{
			fpsExtraBenefit_Sheet1.Cells.Get(row,0).Text = GUIFunction.GetString(value.EntityKey);
			fpsExtraBenefit_Sheet1.Cells.Get(row,1).Text = GUIFunction.GetString(value.AYearMonth.Month);
			fpsExtraBenefit_Sheet1.Cells.Get(row,2).Text = GUIFunction.GetString(value.TotalAmount);
		}

		private void clearForm()
		{	
			visibleForm(false);
			fpsExtraBenefit_Sheet1.RowCount = 0;
			enableButton(false);
		}

//		==========================Public Method========================
		public bool AddRow(ExtraBenefit value)
		{
			if (facadeEmployeeExtraBenefit.InsertExtraBenefit(value))
			{
				fpsExtraBenefit_Sheet1.RowCount++;
				bindExtraBenefit(fpsExtraBenefit_Sheet1.RowCount-1, value);
                fpsExtraBenefit_Sheet1.SetActiveCell(fpsExtraBenefit_Sheet1.RowCount, 0);
				enableButton(true);
				mdiParent.RefreshMasterCount();
				return true;
			}				
			return false;
		}

		public bool UpdateRow(ExtraBenefit value)
		{
			if (facadeEmployeeExtraBenefit.UpdateExtraBenefit(value))
			{
				bindExtraBenefit(SelectedRow, value);				
				return true;
			}				
			return false;
		}

		private void DeleteRow()
		{
			if (facadeEmployeeExtraBenefit.DeleteExtraBenefit(selectedExtraBenefit))
			{
				if(fpsExtraBenefit_Sheet1.RowCount > 1)
				{
					fpsExtraBenefit.ActiveSheet.Rows.Remove(SelectedRow,1);
				}
				else
				{
					fpsExtraBenefit_Sheet1.RowCount = 0;
					enableButton(false);
				}	
			
				mdiParent.RefreshMasterCount();
			}
		}

		public override int MasterCount()
		{
			return facadeEmployeeExtraBenefit.ObjEmployeeExtraBenefit.Count;
		}

//		==============================Protected method ==============================
		protected override void enableButton(bool value)
		{
			base.enableButton(value);
			mniEdit.Enabled = false;
			mniDelete.Enabled = value;
		}

		protected override void visibleForm(bool value)
		{
			base.visibleForm(value);
			fpsExtraBenefit.Visible = value;
			lblForYear.Visible = value;
			dtpForYear.Visible = value;
		}
		
		protected override void addEvent()
		{
			try
			{
				frmEntry = new frmEmployeeExtraBenefitEntry(this);
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
				frmEntry = new frmEmployeeExtraBenefitEntry(this);
				frmEntry.InitEditAction(selectedExtraBenefit);
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
			facadeEmployeeAttendance = new EmployeeExtraBenefitFacade();
			facadeEmployeeExtraBenefit = (EmployeeExtraBenefitFacade)facadeEmployeeAttendance;
			isChange = false;
			dtpForYear.Value = new System.DateTime(DateTime.Today.Year, 1, 1, 0, 0, 0, 0);
			isChange = true;
			mdiParent.RefreshMasterCount();
		}

		public override void RefreshForm()
		{
			base.RefreshForm();

			try
			{
				if (facadeEmployeeExtraBenefit.DisplayEmployeeExtraBenefit(dtpForYear.Value))
				{	
					enableButton(true);
					visibleForm(true);
					bindForm();
				}
				else
				{
					visibleForm(true);
					fpsExtraBenefit_Sheet1.RowCount = 0;
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
		private void frmEmployeeExtraBenefit_Load(object sender, System.EventArgs e)
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
			if(isChange)
			{
				RefreshForm();
			}
		}

		private void fpsExtraBenefit_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader)
			{
				editEvent();
			}
		}
	}
}
