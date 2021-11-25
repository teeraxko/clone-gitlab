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
	public class frmEmployeeSpecialLeave : frmAttendanceHeadBase
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

        private FarPoint.Win.Spread.FpSpread fpsSpecialLeave;
        private FarPoint.Win.Spread.SheetView fpsSpecialLeave_Sheet1;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem mniAdd;
        private System.Windows.Forms.MenuItem mniEdit;
        private System.Windows.Forms.MenuItem mniDelete;
        private System.ComponentModel.Container components = null;

        private void InitializeComponent()
        {
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmEmployeeSpecialLeave));
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType2 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType3 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.fpsSpecialLeave = new FarPoint.Win.Spread.FpSpread();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.mniAdd = new System.Windows.Forms.MenuItem();
            this.mniEdit = new System.Windows.Forms.MenuItem();
            this.mniDelete = new System.Windows.Forms.MenuItem();
            this.fpsSpecialLeave_Sheet1 = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.fpsSpecialLeave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsSpecialLeave_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // pctEmployee
            // 
            this.pctEmployee.Name = "pctEmployee";
            // 
            // fpsSpecialLeave
            // 
            this.fpsSpecialLeave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.fpsSpecialLeave.ContextMenu = this.contextMenu1;
            this.fpsSpecialLeave.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.fpsSpecialLeave.Location = new System.Drawing.Point(124, 136);
            this.fpsSpecialLeave.Name = "fpsSpecialLeave";
            this.fpsSpecialLeave.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																						 this.fpsSpecialLeave_Sheet1});
            this.fpsSpecialLeave.Size = new System.Drawing.Size(720, 288);
            this.fpsSpecialLeave.TabIndex = 57;
            this.fpsSpecialLeave.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsSpecialLeave_CellDoubleClick);
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
            // fpsSpecialLeave_Sheet1
            // 
            this.fpsSpecialLeave_Sheet1.Reset();
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpsSpecialLeave_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpsSpecialLeave_Sheet1.ColumnCount = 6;
            this.fpsSpecialLeave_Sheet1.ColumnHeader.RowCount = 2;
            this.fpsSpecialLeave_Sheet1.RowCount = 1;
            this.fpsSpecialLeave_Sheet1.ColumnHeader.Cells.Get(0, 1).RowSpan = 2;
            this.fpsSpecialLeave_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "วันที่";
            this.fpsSpecialLeave_Sheet1.ColumnHeader.Cells.Get(0, 2).ColumnSpan = 3;
            this.fpsSpecialLeave_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "ช่วงเวลา";
            this.fpsSpecialLeave_Sheet1.ColumnHeader.Cells.Get(0, 5).RowSpan = 2;
            this.fpsSpecialLeave_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "รายละเอียดการลากิจพิเศษ";
            this.fpsSpecialLeave_Sheet1.ColumnHeader.Cells.Get(1, 2).Text = "ครึ่งวันแรก";
            this.fpsSpecialLeave_Sheet1.ColumnHeader.Cells.Get(1, 3).Text = "ครึ่งวันหลัง";
            this.fpsSpecialLeave_Sheet1.ColumnHeader.Cells.Get(1, 4).Text = "ทั้งวัน";
            this.fpsSpecialLeave_Sheet1.ColumnHeader.Columns.Default.Resizable = false;
            this.fpsSpecialLeave_Sheet1.Columns.Default.Resizable = false;
            textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType1.DropDownButton = false;
            this.fpsSpecialLeave_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.fpsSpecialLeave_Sheet1.Columns.Get(0).Visible = false;
            this.fpsSpecialLeave_Sheet1.Columns.Get(1).AllowAutoSort = true;
            dateTimeCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            dateTimeCellType1.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
            dateTimeCellType1.DateDefault = new System.DateTime(2007, 9, 4, 15, 25, 16, 0);
            dateTimeCellType1.DropDownButton = false;
            dateTimeCellType1.ReadOnly = true;
            dateTimeCellType1.TimeDefault = new System.DateTime(2007, 9, 4, 15, 25, 16, 0);
            dateTimeCellType1.UserDefinedFormat = "dd/MM/yyyy";
            this.fpsSpecialLeave_Sheet1.Columns.Get(1).CellType = dateTimeCellType1;
            this.fpsSpecialLeave_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsSpecialLeave_Sheet1.Columns.Get(1).Width = 80F;
            this.fpsSpecialLeave_Sheet1.Columns.Get(2).AllowAutoSort = true;
            this.fpsSpecialLeave_Sheet1.Columns.Get(2).CellType = checkBoxCellType1;
            this.fpsSpecialLeave_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsSpecialLeave_Sheet1.Columns.Get(2).Label = "ครึ่งวันแรก";
            this.fpsSpecialLeave_Sheet1.Columns.Get(3).AllowAutoSort = true;
            this.fpsSpecialLeave_Sheet1.Columns.Get(3).CellType = checkBoxCellType2;
            this.fpsSpecialLeave_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsSpecialLeave_Sheet1.Columns.Get(3).Label = "ครึ่งวันหลัง";
            this.fpsSpecialLeave_Sheet1.Columns.Get(4).AllowAutoSort = true;
            this.fpsSpecialLeave_Sheet1.Columns.Get(4).CellType = checkBoxCellType3;
            this.fpsSpecialLeave_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsSpecialLeave_Sheet1.Columns.Get(4).Label = "ทั้งวัน";
            this.fpsSpecialLeave_Sheet1.Columns.Get(5).AllowAutoSort = true;
            textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType2.DropDownButton = false;
            this.fpsSpecialLeave_Sheet1.Columns.Get(5).CellType = textCellType2;
            this.fpsSpecialLeave_Sheet1.Columns.Get(5).Width = 400F;
            this.fpsSpecialLeave_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
            this.fpsSpecialLeave_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpsSpecialLeave_Sheet1.RowHeader.Rows.Default.Resizable = false;
            this.fpsSpecialLeave_Sheet1.Rows.Default.Resizable = false;
            this.fpsSpecialLeave_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpsSpecialLeave_Sheet1.SheetName = "Sheet1";
            this.fpsSpecialLeave_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmEmployeeSpecialLeave
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(968, 488);
            this.Controls.Add(this.fpsSpecialLeave);
            this.Name = "frmEmployeeSpecialLeave";
            this.Text = "ข้อมูลการลากิจพิเศษ";
            this.Load += new System.EventHandler(this.frmEmployeeSpecialLeave_Load);
            this.Controls.SetChildIndex(this.fpsSpecialLeave, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fpsSpecialLeave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsSpecialLeave_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

		#region - Private -
		private bool isReadonly = true;
		private frmEmployeeSpecialLeaveEntry frmEntry;
		#endregion

		//		============================== Property ==============================		
		private EmployeeSpecialLeaveFacade facadeEmployeeSpecialLeave;
		public EmployeeSpecialLeaveFacade FacadeEmployeeSpecialLeave
		{
			get{return facadeEmployeeSpecialLeave;}
		}

		private int SelectedRow
		{
			get{return fpsSpecialLeave_Sheet1.ActiveRowIndex;}
		}

		private string SelectedKey
		{
			get{return fpsSpecialLeave_Sheet1.Cells[SelectedRow,0].Text;}
		}
	
		private SpecialLeave selectedSpecialLeave
		{
			get{return facadeEmployeeSpecialLeave.ObjEmployeeSpecialLeave[SelectedKey];}
		}

		//		==============================  Constructor  ==============================
		public frmEmployeeSpecialLeave() : base()
		{ 
			InitializeComponent();
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miEmployeeSpecialLeave");
            this.title = UserProfile.GetFormName("miAttendance", "miEmployeeSpecialLeave");
		}
        public override string FormID()
        {
            return UserProfile.GetFormID("miAttendance", "miEmployeeSpecialLeave");
        }

		//		==============================Private method ==============================
		private void bindForm()
		{
			if (facadeEmployeeSpecialLeave.ObjEmployeeSpecialLeave != null)
			{
				int iRow = facadeEmployeeSpecialLeave.ObjEmployeeSpecialLeave.Count;
				fpsSpecialLeave_Sheet1.RowCount = iRow;
				for(int i=0; i<iRow; i++)
				{
					bindSpecialLeave(i, facadeEmployeeSpecialLeave.ObjEmployeeSpecialLeave[i]);
				}
	
				mdiParent.RefreshMasterCount();
			}
            fpsSpecialLeave_Sheet1.SetActiveCell(fpsSpecialLeave_Sheet1.RowCount, 0);
		}
		
		private void bindSpecialLeave(int row, SpecialLeave value)
		{
			fpsSpecialLeave_Sheet1.Cells.Get(row,0).Text = GUIFunction.GetString(value.EntityKey);
			fpsSpecialLeave_Sheet1.Cells.Get(row,1).Value = value.LeaveDate;

			if(value.PeriodStatus == LEAVE_PERIOD_TYPE.AM)
			{fpsSpecialLeave_Sheet1.Cells.Get(row,2).Text = "True";}
			else
			{fpsSpecialLeave_Sheet1.Cells.Get(row,2).Text = "False";}

			if(value.PeriodStatus == LEAVE_PERIOD_TYPE.PM)
			{fpsSpecialLeave_Sheet1.Cells.Get(row,3).Text = "True";}
			else
			{fpsSpecialLeave_Sheet1.Cells.Get(row,3).Text = "False";}

			if(value.PeriodStatus == LEAVE_PERIOD_TYPE.ONE_DAY)
			{fpsSpecialLeave_Sheet1.Cells.Get(row,4).Text = "True";}
			else
			{fpsSpecialLeave_Sheet1.Cells.Get(row,4).Text = "False";}

			fpsSpecialLeave_Sheet1.Cells.Get(row,5).Text = GUIFunction.GetString(value.AKindOfSpecialLeave.AName.Thai);
		}

		private void clearForm()
		{
			visibleForm(false);
			fpsSpecialLeave_Sheet1.RowCount = 0;
			enableButton(false);
			clearSummarizeLeave();
		}

		private void bindSummarizeLeave(EmployeeSpecialLeave value)
		{
            //if (value.Count.Equals(0))
            //{
            //    clearSummarizeLeave();				
            //}
            //else
            //{
            //    fpdJan.Value = value.CountByMonth(1, dtpForMonth.Value.Year);
            //    fpdFeb.Value = value.CountByMonth(2, dtpForMonth.Value.Year);
            //    fpdMar.Value = value.CountByMonth(3, dtpForMonth.Value.Year);
            //    fpdApr.Value = value.CountByMonth(4, dtpForMonth.Value.Year);
            //    fpdMay.Value = value.CountByMonth(5, dtpForMonth.Value.Year);
            //    fpdJun.Value = value.CountByMonth(6, dtpForMonth.Value.Year);
            //    fpdJul.Value = value.CountByMonth(7, dtpForMonth.Value.Year);
            //    fpdAug.Value = value.CountByMonth(8, dtpForMonth.Value.Year);
            //    fpdSep.Value = value.CountByMonth(9, dtpForMonth.Value.Year);
            //    fpdOct.Value = value.CountByMonth(10, dtpForMonth.Value.Year);
            //    fpdNov.Value = value.CountByMonth(11, dtpForMonth.Value.Year);
            //    fpdDec.Value = value.CountByMonth(12, dtpForMonth.Value.Year);	
            //    fpdTotal.Value =	(double)fpdJan.Value + (double)fpdFeb.Value + (double)fpdMar.Value + (double)fpdApr.Value + 
            //                        (double)fpdMay.Value + (double)fpdJun.Value + (double)fpdJul.Value + (double)fpdAug.Value + 
            //                        (double)fpdSep.Value + (double)fpdOct.Value + (double)fpdNov.Value + (double)fpdDec.Value;
            //}
		}

		private void clearSummarizeLeave()
		{
            //fpdJan.Value = 0;
            //fpdFeb.Value = 0;
            //fpdMar.Value = 0;
            //fpdApr.Value = 0;
            //fpdMay.Value = 0;
            //fpdJun.Value = 0;
            //fpdJul.Value = 0;
            //fpdAug.Value = 0;
            //fpdSep.Value = 0;
            //fpdOct.Value = 0;
            //fpdNov.Value = 0;
            //fpdDec.Value = 0;
            //fpdTotal.Value = 0;
		}

//		==========================Public Method========================
		public bool AddRow(SpecialLeave value)
		{
			if (facadeEmployeeSpecialLeave.InsertSpecialLeave(value))
			{
				fpsSpecialLeave_Sheet1.RowCount++;
				bindSpecialLeave(fpsSpecialLeave_Sheet1.RowCount-1, value);
				bindSummarizeLeave(facadeEmployeeSpecialLeave.ObjSpecialLeaveYear);
                fpsSpecialLeave_Sheet1.SetActiveCell(fpsSpecialLeave_Sheet1.RowCount, 0);
				enableButton(true);
				mdiParent.RefreshMasterCount();
				return true;
			}				
			return false;
		}

		public bool UpdateRow(SpecialLeave value)
		{
			if (facadeEmployeeSpecialLeave.UpdateSpecialLeave(value))
			{
				bindSpecialLeave(SelectedRow, value);	
				bindSummarizeLeave(facadeEmployeeSpecialLeave.ObjSpecialLeaveYear);
				return true;
			}				
			return false;
		}

		private void DeleteRow()
		{
			if (facadeEmployeeSpecialLeave.DeleteSpecialLeave(selectedSpecialLeave))
			{
				if(fpsSpecialLeave_Sheet1.RowCount > 1)
				{
					fpsSpecialLeave.ActiveSheet.Rows.Remove(SelectedRow,1);
				}
				else
				{
					fpsSpecialLeave_Sheet1.RowCount = 0;
					enableButton(false);
				}	
				bindSummarizeLeave(facadeEmployeeSpecialLeave.ObjSpecialLeaveYear);
				mdiParent.RefreshMasterCount();
			}
		}
		
		public override int MasterCount()
		{
			return facadeEmployeeSpecialLeave.ObjEmployeeSpecialLeave.Count;
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
			fpsSpecialLeave.Visible = value;
		}
		
		protected override void addEvent()
		{
			try
			{
				frmEntry = new frmEmployeeSpecialLeaveEntry(this);
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
				frmEntry = new frmEmployeeSpecialLeaveEntry(this);
				frmEntry.InitEditAction(selectedSpecialLeave);
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
			facadeEmployeeAttendance = new EmployeeSpecialLeaveFacade();
			facadeEmployeeSpecialLeave = (EmployeeSpecialLeaveFacade)facadeEmployeeAttendance;
			mdiParent.RefreshMasterCount();
		}

		public override void RefreshForm()
		{
			base.RefreshForm();

			try
			{
                if (facadeEmployeeSpecialLeave.DisplayAllEmployeeSpecialLeave())
				{	
					enableButton(true);
					visibleForm(true);
					bindForm();
				}
				else
				{
					visibleForm(true);
					fpsSpecialLeave_Sheet1.RowCount = 0;
					enableButton(false);
				}

				bindSummarizeLeave(facadeEmployeeSpecialLeave.ObjSpecialLeaveYear);
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
		private void frmEmployeeSpecialLeave_Load(object sender, System.EventArgs e)
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
        
		private void fpsSpecialLeave_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader)
			{
				editEvent();
			}
		}
	}
}
