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
	public class frmEmployeeMiscBenefit : frmAttendanceHeadBase
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
		private FarPoint.Win.Spread.FpSpread fpsMiscBenefit;
		private FarPoint.Win.Spread.SheetView fpsMiscBenefit_Sheet1;
		private System.Windows.Forms.DateTimePicker dtpForDate;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem mniAdd;
		private System.Windows.Forms.MenuItem mniEdit;
		private System.Windows.Forms.MenuItem mniDelete;
		private System.Windows.Forms.Label lblForDate;

		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
			this.fpsMiscBenefit = new FarPoint.Win.Spread.FpSpread();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mniAdd = new System.Windows.Forms.MenuItem();
			this.mniEdit = new System.Windows.Forms.MenuItem();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			this.fpsMiscBenefit_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.lblForDate = new System.Windows.Forms.Label();
			this.dtpForDate = new System.Windows.Forms.DateTimePicker();
			((System.ComponentModel.ISupportInitialize)(this.fpsMiscBenefit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsMiscBenefit_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// pctEmployee
			// 
			this.pctEmployee.Name = "pctEmployee";
			// 
			// fpsMiscBenefit
			// 
			this.fpsMiscBenefit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsMiscBenefit.ContextMenu = this.contextMenu1;
			this.fpsMiscBenefit.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsMiscBenefit.Location = new System.Drawing.Point(251, 176);
			this.fpsMiscBenefit.Name = "fpsMiscBenefit";
			this.fpsMiscBenefit.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																						this.fpsMiscBenefit_Sheet1});
			this.fpsMiscBenefit.Size = new System.Drawing.Size(467, 233);
			this.fpsMiscBenefit.TabIndex = 0;
			this.fpsMiscBenefit.TabStop = false;
			this.fpsMiscBenefit.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsMiscBenefit_CellDoubleClick);
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
			// fpsMiscBenefit_Sheet1
			// 
			this.fpsMiscBenefit_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsMiscBenefit_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsMiscBenefit_Sheet1.ColumnCount = 3;
			this.fpsMiscBenefit_Sheet1.RowCount = 1;
			this.fpsMiscBenefit_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "รายละเอียด";
			this.fpsMiscBenefit_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "จำนวนเงิน";
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsMiscBenefit_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsMiscBenefit_Sheet1.Columns.Get(0).Visible = false;
			this.fpsMiscBenefit_Sheet1.Columns.Get(1).AllowAutoSort = true;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			this.fpsMiscBenefit_Sheet1.Columns.Get(1).CellType = textCellType2;
			this.fpsMiscBenefit_Sheet1.Columns.Get(1).Label = "รายละเอียด";
			this.fpsMiscBenefit_Sheet1.Columns.Get(1).Resizable = false;
			this.fpsMiscBenefit_Sheet1.Columns.Get(1).Width = 321F;
			this.fpsMiscBenefit_Sheet1.Columns.Get(2).AllowAutoSort = true;
			numberCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			numberCellType1.DecimalPlaces = 2;
			numberCellType1.DropDownButton = false;
			numberCellType1.MaximumValue = 999999.99;
			numberCellType1.MinimumValue = 0;
			numberCellType1.Separator = ",";
			numberCellType1.ShowSeparator = true;
			this.fpsMiscBenefit_Sheet1.Columns.Get(2).CellType = numberCellType1;
			this.fpsMiscBenefit_Sheet1.Columns.Get(2).Label = "จำนวนเงิน";
			this.fpsMiscBenefit_Sheet1.Columns.Get(2).Resizable = false;
			this.fpsMiscBenefit_Sheet1.Columns.Get(2).Width = 90F;
			this.fpsMiscBenefit_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
			this.fpsMiscBenefit_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsMiscBenefit_Sheet1.RowHeader.Rows.Default.Resizable = false;
			this.fpsMiscBenefit_Sheet1.Rows.Default.Resizable = false;
			this.fpsMiscBenefit_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsMiscBenefit_Sheet1.SheetName = "Sheet1";
			this.fpsMiscBenefit_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// lblForDate
			// 
			this.lblForDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblForDate.Location = new System.Drawing.Point(408, 144);
			this.lblForDate.Name = "lblForDate";
			this.lblForDate.Size = new System.Drawing.Size(64, 23);
			this.lblForDate.TabIndex = 19;
			this.lblForDate.Text = "สำหรับเดือน";
			// 
			// dtpForDate
			// 
			this.dtpForDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.dtpForDate.CustomFormat = "MM/yyyy";
			this.dtpForDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpForDate.Location = new System.Drawing.Point(484, 144);
			this.dtpForDate.Name = "dtpForDate";
			this.dtpForDate.Size = new System.Drawing.Size(80, 20);
			this.dtpForDate.TabIndex = 2;
			this.dtpForDate.ValueChanged += new System.EventHandler(this.dtpForDate_ValueChanged);
			// 
			// frmEmployeeMiscBenefit
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(968, 488);
			this.Controls.Add(this.dtpForDate);
			this.Controls.Add(this.lblForDate);
			this.Controls.Add(this.fpsMiscBenefit);
			this.Name = "frmEmployeeMiscBenefit";
			this.Load += new System.EventHandler(this.frmEmployeeMiscBenefit_Load);
			this.Controls.SetChildIndex(this.fpsMiscBenefit, 0);
			this.Controls.SetChildIndex(this.lblForDate, 0);
			this.Controls.SetChildIndex(this.dtpForDate, 0);
			((System.ComponentModel.ISupportInitialize)(this.fpsMiscBenefit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsMiscBenefit_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		protected bool isReadonly = true;
		private bool isTextChange = true;
		protected frmEmployeeMiscBenfitEntry frmEntry;
		#endregion

//		============================== Property ==============================		
		protected EmployeeMiscBenefitFacade facadeEmployeeMiscBenefit;
		public EmployeeMiscBenefitFacade FacadeEmployeeMiscBenefit
		{
			get{return facadeEmployeeMiscBenefit;}
		}

		private int SelectedRow
		{
			get{return fpsMiscBenefit_Sheet1.ActiveRowIndex;}
		}

		private string SelectedKey
		{
			get{return fpsMiscBenefit_Sheet1.Cells[SelectedRow,0].Text;}
		}
	
		private MiscBenefit selectedMiscBenefit
		{
			get{return facadeEmployeeMiscBenefit.ObjEmployeeMiscBenefit[SelectedKey];}
		}

//		============================== Constructor ==============================
		public frmEmployeeMiscBenefit() : base()
		{
			InitializeComponent();
            //this.Text = "รายการรายได้อื่นๆ ตามพนักงาน";
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miEmployeeMiscBenefit");
            this.title = UserProfile.GetFormName("miAttendance", "miEmployeeMiscBenefit");

		}

        public override string FormID()
        {
            return UserProfile.GetFormID("miAttendance", "miEmployeeMiscBenefit");
        }

//		==============================Private method ==============================
		private void bindForm()
		{
			if (facadeEmployeeMiscBenefit.ObjEmployeeMiscBenefit != null)
			{
				int iRow = facadeEmployeeMiscBenefit.ObjEmployeeMiscBenefit.Count;
				fpsMiscBenefit_Sheet1.RowCount = iRow;
				for(int i=0; i<iRow; i++)
				{
					bindMiscBenefit(i, facadeEmployeeMiscBenefit.ObjEmployeeMiscBenefit[i]);
				}				
			}
            fpsMiscBenefit_Sheet1.SetActiveCell(fpsMiscBenefit_Sheet1.RowCount, 0);
		}
		
		private void bindMiscBenefit(int row, MiscBenefit value)
		{
			fpsMiscBenefit_Sheet1.Cells.Get(row,0).Text = GUIFunction.GetString(value.EntityKey);
			fpsMiscBenefit_Sheet1.Cells.Get(row,1).Text = GUIFunction.GetString(value.Description);
			fpsMiscBenefit_Sheet1.Cells.Get(row,2).Text = value.TotalAmount.ToString("0.00");
		}

		private void clearForm()
		{	
			visibleForm(false);
			fpsMiscBenefit_Sheet1.RowCount = 0;
			enableButton(false);
		}

//		==========================Public Method========================
		public bool AddRow(MiscBenefit value)
		{
			value.AYearMonth = new YearMonth(dtpForDate.Value);
			if (facadeEmployeeMiscBenefit.InsertMiscellaneousBenefit(value))
			{
				fpsMiscBenefit_Sheet1.RowCount++;
				bindMiscBenefit(fpsMiscBenefit_Sheet1.RowCount-1, value);
                fpsMiscBenefit_Sheet1.SetActiveCell(fpsMiscBenefit_Sheet1.RowCount, 0);
				enableButton(true);
				mdiParent.RefreshMasterCount();
				return true;
			}				
			return false;
		}

		public bool UpdateRow(MiscBenefit value)
		{
			value.AYearMonth = new YearMonth(dtpForDate.Value);
			if (facadeEmployeeMiscBenefit.UpdateMiscellaneousBenefit(value))
			{
				bindMiscBenefit(SelectedRow, value);				
				return true;
			}				
			return false;
		}

		private void DeleteRow()
		{
			if (facadeEmployeeMiscBenefit.DeleteMiscellaneousBenefit(selectedMiscBenefit))
			{
				if(fpsMiscBenefit_Sheet1.RowCount > 1)
				{
					fpsMiscBenefit.ActiveSheet.Rows.Remove(SelectedRow,1);
				}
				else
				{
					fpsMiscBenefit_Sheet1.RowCount = 0;
					enableButton(false);
				}			
				mdiParent.RefreshMasterCount();
			}
		}

		public override int MasterCount()
		{
			return facadeEmployeeMiscBenefit.ObjEmployeeMiscBenefit.Count;
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
			fpsMiscBenefit.Visible = value;
			lblForDate.Visible = value;
			dtpForDate.Visible = value;
		}

		protected override void addEvent()
		{
			try
			{
				frmEntry = new frmEmployeeMiscBenfitEntry(this);
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

		protected override void editEvent()
		{
			try
			{
				frmEntry = new frmEmployeeMiscBenfitEntry(this);
				frmEntry.InitEditAction(selectedMiscBenefit);
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
		protected virtual void newLayer()
		{
			facadeEmployeeAttendance = new EmployeeMiscBenefitFacade();
			facadeEmployeeMiscBenefit = (EmployeeMiscBenefitFacade)facadeEmployeeAttendance;
		}

		public override void InitForm()
		{
			base.InitForm();
			newLayer();
			isTextChange = false;
			dtpForDate.Value = new System.DateTime(DateTime.Today.Year, DateTime.Today.Month, 1, 0, 0, 0, 0);
			isTextChange = true;
		}

		public override void RefreshForm()
		{
			base.RefreshForm();

			try
			{
				if (facadeEmployeeMiscBenefit.DisplayMiscellaneousBenefit(dtpForDate.Value))
				{	
					enableButton(true);
					visibleForm(true);
					bindForm();
				}
				else
				{
					visibleForm(true);
					fpsMiscBenefit_Sheet1.RowCount = 0;
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
		private void frmEmployeeMiscBenefit_Load(object sender, System.EventArgs e)
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

		private void fpsMiscBenefit_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader)
			{
				editEvent();
			}
		}

		private void dtpForDate_ValueChanged(object sender, System.EventArgs e)
		{
			if(isTextChange)
			{
				RefreshForm();
			}
		}
	}
}
