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
	public class frmEmployeePrivateLeave : frmAttendanceHeadBase
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
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem mniAdd;
        private System.Windows.Forms.MenuItem mniEdit;
        private System.Windows.Forms.MenuItem mniDelete;
        private FarPoint.Win.Spread.FpSpread fpsPrivateLeave;
        private FarPoint.Win.Spread.SheetView fpsPrivateLeave_Sheet1;
        private System.Windows.Forms.Label lblForMonth;
        private Presentation.AttendanceGUI.UCTSummaryLeaveDays uctSummaryLeaveDays1;

        private System.ComponentModel.Container components = null;

        private void InitializeComponent()
        {
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmEmployeePrivateLeave));
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType2 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType3 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.lblForMonth = new System.Windows.Forms.Label();
            this.fpsPrivateLeave = new FarPoint.Win.Spread.FpSpread();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.mniAdd = new System.Windows.Forms.MenuItem();
            this.mniEdit = new System.Windows.Forms.MenuItem();
            this.mniDelete = new System.Windows.Forms.MenuItem();
            this.fpsPrivateLeave_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.dtpForMonth = new System.Windows.Forms.DateTimePicker();
            this.uctSummaryLeaveDays1 = new Presentation.AttendanceGUI.UCTSummaryLeaveDays();
            ((System.ComponentModel.ISupportInitialize)(this.fpsPrivateLeave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsPrivateLeave_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // pctEmployee
            // 
            this.pctEmployee.Name = "pctEmployee";
            // 
            // lblForMonth
            // 
            this.lblForMonth.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblForMonth.Location = new System.Drawing.Point(406, 136);
            this.lblForMonth.Name = "lblForMonth";
            this.lblForMonth.Size = new System.Drawing.Size(64, 16);
            this.lblForMonth.TabIndex = 50;
            this.lblForMonth.Text = "สำหรับเดือน";
            // 
            // fpsPrivateLeave
            // 
            this.fpsPrivateLeave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.fpsPrivateLeave.ContextMenu = this.contextMenu1;
            this.fpsPrivateLeave.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.fpsPrivateLeave.Location = new System.Drawing.Point(152, 272);
            this.fpsPrivateLeave.Name = "fpsPrivateLeave";
            this.fpsPrivateLeave.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																						 this.fpsPrivateLeave_Sheet1});
            this.fpsPrivateLeave.Size = new System.Drawing.Size(664, 160);
            this.fpsPrivateLeave.TabIndex = 51;
            this.fpsPrivateLeave.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsPrivateLeave_CellDoubleClick);
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
            // fpsPrivateLeave_Sheet1
            // 
            this.fpsPrivateLeave_Sheet1.Reset();
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpsPrivateLeave_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpsPrivateLeave_Sheet1.ColumnCount = 6;
            this.fpsPrivateLeave_Sheet1.ColumnHeader.RowCount = 2;
            this.fpsPrivateLeave_Sheet1.RowCount = 1;
            this.fpsPrivateLeave_Sheet1.ColumnHeader.Cells.Get(0, 1).RowSpan = 2;
            this.fpsPrivateLeave_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "วันที่";
            this.fpsPrivateLeave_Sheet1.ColumnHeader.Cells.Get(0, 2).ColumnSpan = 3;
            this.fpsPrivateLeave_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "ช่วงเวลา";
            this.fpsPrivateLeave_Sheet1.ColumnHeader.Cells.Get(0, 5).RowSpan = 2;
            this.fpsPrivateLeave_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "เหตุผลในการลา";
            this.fpsPrivateLeave_Sheet1.ColumnHeader.Cells.Get(1, 2).Text = "ครึ่งวันแรก";
            this.fpsPrivateLeave_Sheet1.ColumnHeader.Cells.Get(1, 3).Text = "ครึ่งวันหลัง";
            this.fpsPrivateLeave_Sheet1.ColumnHeader.Cells.Get(1, 4).Text = "ทั้งวัน";
            this.fpsPrivateLeave_Sheet1.ColumnHeader.Columns.Default.Resizable = false;
            this.fpsPrivateLeave_Sheet1.Columns.Default.Resizable = false;
            textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType1.DropDownButton = false;
            this.fpsPrivateLeave_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.fpsPrivateLeave_Sheet1.Columns.Get(0).Visible = false;
            this.fpsPrivateLeave_Sheet1.Columns.Get(1).AllowAutoSort = true;
            numberCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            numberCellType1.DecimalPlaces = 0;
            numberCellType1.DropDownButton = false;
            numberCellType1.MinimumValue = 0;
            this.fpsPrivateLeave_Sheet1.Columns.Get(1).CellType = numberCellType1;
            this.fpsPrivateLeave_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsPrivateLeave_Sheet1.Columns.Get(1).Width = 45F;
            this.fpsPrivateLeave_Sheet1.Columns.Get(2).AllowAutoSort = true;
            this.fpsPrivateLeave_Sheet1.Columns.Get(2).CellType = checkBoxCellType1;
            this.fpsPrivateLeave_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsPrivateLeave_Sheet1.Columns.Get(2).Label = "ครึ่งวันแรก";
            this.fpsPrivateLeave_Sheet1.Columns.Get(3).AllowAutoSort = true;
            this.fpsPrivateLeave_Sheet1.Columns.Get(3).CellType = checkBoxCellType2;
            this.fpsPrivateLeave_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsPrivateLeave_Sheet1.Columns.Get(3).Label = "ครึ่งวันหลัง";
            this.fpsPrivateLeave_Sheet1.Columns.Get(4).AllowAutoSort = true;
            this.fpsPrivateLeave_Sheet1.Columns.Get(4).CellType = checkBoxCellType3;
            this.fpsPrivateLeave_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsPrivateLeave_Sheet1.Columns.Get(4).Label = "ทั้งวัน";
            this.fpsPrivateLeave_Sheet1.Columns.Get(5).AllowAutoSort = true;
            textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType2.DropDownButton = false;
            this.fpsPrivateLeave_Sheet1.Columns.Get(5).CellType = textCellType2;
            this.fpsPrivateLeave_Sheet1.Columns.Get(5).Width = 380F;
            this.fpsPrivateLeave_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
            this.fpsPrivateLeave_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpsPrivateLeave_Sheet1.RowHeader.Rows.Default.Resizable = false;
            this.fpsPrivateLeave_Sheet1.Rows.Default.Resizable = false;
            this.fpsPrivateLeave_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpsPrivateLeave_Sheet1.SheetName = "Sheet1";
            this.fpsPrivateLeave_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // dtpForMonth
            // 
            this.dtpForMonth.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpForMonth.CustomFormat = "MM/yyyy";
            this.dtpForMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpForMonth.Location = new System.Drawing.Point(482, 134);
            this.dtpForMonth.Name = "dtpForMonth";
            this.dtpForMonth.Size = new System.Drawing.Size(80, 20);
            this.dtpForMonth.TabIndex = 49;
            this.dtpForMonth.ValueChanged += new System.EventHandler(this.dtpForMonth_ValueChanged);
            // 
            // uctSummaryLeaveDays1
            // 
            this.uctSummaryLeaveDays1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uctSummaryLeaveDays1.Location = new System.Drawing.Point(148, 160);
            this.uctSummaryLeaveDays1.Name = "uctSummaryLeaveDays1";
            this.uctSummaryLeaveDays1.Size = new System.Drawing.Size(672, 104);
            this.uctSummaryLeaveDays1.TabIndex = 60;
            // 
            // frmEmployeePrivateLeave
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(968, 488);
            this.Controls.Add(this.dtpForMonth);
            this.Controls.Add(this.lblForMonth);
            this.Controls.Add(this.fpsPrivateLeave);
            this.Controls.Add(this.uctSummaryLeaveDays1);
            this.Name = "frmEmployeePrivateLeave";
            this.Text = "ข้อมูลการลากิจ";
            this.Load += new System.EventHandler(this.frmEmployeePrivateLeave_Load);
            this.Controls.SetChildIndex(this.uctSummaryLeaveDays1, 0);
            this.Controls.SetChildIndex(this.fpsPrivateLeave, 0);
            this.Controls.SetChildIndex(this.lblForMonth, 0);
            this.Controls.SetChildIndex(this.dtpForMonth, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fpsPrivateLeave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsPrivateLeave_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

		#region - Private -
		private bool isReadonly = true;
		private bool isChange = true;
		private frmEmployeePrivateLeaveEntry frmEntry;
		#endregion

		//		============================== Property ==============================		
		private EmployeePrivateLeaveFacade facadeEmployeePrivateLeave;
		public EmployeePrivateLeaveFacade FacadeEmployeePrivateLeave
		{
			get{return facadeEmployeePrivateLeave;}
		}

		private int SelectedRow
		{
			get{return fpsPrivateLeave_Sheet1.ActiveRowIndex;}
		}

		private string SelectedKey
		{
			get{return fpsPrivateLeave_Sheet1.Cells[SelectedRow,0].Text;}
		}
	
		private PrivateLeave selectedPrivateLeave
		{
			get{return facadeEmployeePrivateLeave.ObjEmployeePrivateLeave[SelectedKey];}
		}

		//		==============================  Constructor  ==============================
		public frmEmployeePrivateLeave() : base()
		{
			InitializeComponent();
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miEmployeePrivateLeave");
            this.title = UserProfile.GetFormName("miAttendance", "miEmployeePrivateLeave");
		}
        public override string FormID()
        {
            return UserProfile.GetFormID("miAttendance", "miEmployeePrivateLeave");
        }

		//		==============================Private method ==============================
		private void bindForm()
		{
			if (facadeEmployeePrivateLeave.ObjEmployeePrivateLeave != null)
			{
				int iRow = facadeEmployeePrivateLeave.ObjEmployeePrivateLeave.Count;
				fpsPrivateLeave_Sheet1.RowCount = iRow;
				for(int i=0; i<iRow; i++)
				{
					bindPrivateLeave(i, facadeEmployeePrivateLeave.ObjEmployeePrivateLeave[i]);
				}

				mdiParent.RefreshMasterCount();
			}
            fpsPrivateLeave_Sheet1.SetActiveCell(fpsPrivateLeave_Sheet1.RowCount, 0);
		}
		
		private void bindPrivateLeave(int row, PrivateLeave value)
		{
			fpsPrivateLeave_Sheet1.Cells.Get(row,0).Text = GUIFunction.GetString(value.EntityKey);
			fpsPrivateLeave_Sheet1.Cells.Get(row,1).Text = GUIFunction.GetString(value.LeaveDate.Day);

			if(value.PeriodStatus == LEAVE_PERIOD_TYPE.AM)
			{fpsPrivateLeave_Sheet1.Cells.Get(row,2).Text = "True";}
			else
			{fpsPrivateLeave_Sheet1.Cells.Get(row,2).Text = "False";}

			if(value.PeriodStatus == LEAVE_PERIOD_TYPE.PM)
			{fpsPrivateLeave_Sheet1.Cells.Get(row,3).Text = "True";}
			else
			{fpsPrivateLeave_Sheet1.Cells.Get(row,3).Text = "False";}

			if(value.PeriodStatus == LEAVE_PERIOD_TYPE.ONE_DAY)
			{fpsPrivateLeave_Sheet1.Cells.Get(row,4).Text = "True";}
			else
			{fpsPrivateLeave_Sheet1.Cells.Get(row,4).Text = "False";}

			fpsPrivateLeave_Sheet1.Cells.Get(row,5).Text = GUIFunction.GetString(value.ALeaveReason.Name);
		}

		private void bindSummarizeLeave(EmployeePrivateLeave value)
		{
			uctSummaryLeaveDays1.Clear();

			float days;
			for(int i=0; i<value.Count; i++)
			{
				switch(value[i].PeriodStatus)
				{
					case LEAVE_PERIOD_TYPE.ONE_DAY :
					{
						days = 1;
						break;
					}
					case LEAVE_PERIOD_TYPE.AM :
					case LEAVE_PERIOD_TYPE.PM :
					{
						days = 0.5f;
						break;
					}
					default :
					{
						days = 0;
						break;
					}
				}

				uctSummaryLeaveDays1.Add(value[i].LeaveDate.Month, days);
			}

			uctSummaryLeaveDays1.ShowDayInMonth(dtpForMonth.Value);
		}

		private void clearSummarizeLeave()
		{
			uctSummaryLeaveDays1.Clear();
		}

		private void clearForm()
		{
			visibleForm(false);
			fpsPrivateLeave_Sheet1.RowCount = 0;
			enableButton(false);
			clearSummarizeLeave();
		}

		//		==========================Public Method========================
		public bool AddRow(PrivateLeave value)
		{
			if (facadeEmployeePrivateLeave.InsertPrivateLeave(value))
			{
				if(value.LeaveDate.Month == dtpForMonth.Value.Month && value.LeaveDate.Year == dtpForMonth.Value.Year)
				{
					fpsPrivateLeave_Sheet1.RowCount++;
					bindPrivateLeave(fpsPrivateLeave_Sheet1.RowCount-1, value);
				}		
		
				bindSummarizeLeave(facadeEmployeePrivateLeave.ObjPrivateLeaveYear);
                fpsPrivateLeave_Sheet1.SetActiveCell(fpsPrivateLeave_Sheet1.RowCount, 0);
				enableButton(true);
				mdiParent.RefreshMasterCount();
				return true;
			}				
			return false;
		}

		public bool UpdateRow(PrivateLeave value)
		{
			if (facadeEmployeePrivateLeave.UpdatePrivateLeave(value))
			{
				bindPrivateLeave(SelectedRow, value);
				bindSummarizeLeave(facadeEmployeePrivateLeave.ObjPrivateLeaveYear);
				return true;
			}				
			return false;
		}

		private void DeleteRow()
		{
			if (facadeEmployeePrivateLeave.DeletePrivateLeave(selectedPrivateLeave))
			{
				if(fpsPrivateLeave_Sheet1.RowCount > 1)
				{
					fpsPrivateLeave.ActiveSheet.Rows.Remove(SelectedRow,1);
				}
				else
				{
					fpsPrivateLeave_Sheet1.RowCount = 0;
					enableButton(false);
				}		
	
				bindSummarizeLeave(facadeEmployeePrivateLeave.ObjPrivateLeaveYear);
				mdiParent.RefreshMasterCount();
			}
		}

		public override int MasterCount()
		{
			return facadeEmployeePrivateLeave.ObjEmployeePrivateLeave.Count;
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
			fpsPrivateLeave.Visible = value;
			lblForMonth.Visible = value;
			dtpForMonth.Visible = value;
			uctSummaryLeaveDays1.Visible = value;
		}
		
		protected override void addEvent()
		{
			try
			{
				frmEntry = new frmEmployeePrivateLeaveEntry(this);
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
				frmEntry = new frmEmployeePrivateLeaveEntry(this);
				frmEntry.InitEditAction(selectedPrivateLeave);
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
			facadeEmployeeAttendance = new EmployeePrivateLeaveFacade();
			facadeEmployeePrivateLeave = (EmployeePrivateLeaveFacade)facadeEmployeeAttendance;
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
				if (facadeEmployeePrivateLeave.DisplayEmployeePrivateLeave(dtpForMonth.Value))
				{	
					enableButton(true);
					visibleForm(true);
					bindForm();
				}
				else
				{
					visibleForm(true);
					fpsPrivateLeave_Sheet1.RowCount = 0;
					enableButton(false);
				}
				
				bindSummarizeLeave(facadeEmployeePrivateLeave.ObjPrivateLeaveYear);
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
		private void frmEmployeePrivateLeave_Load(object sender, System.EventArgs e)
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

		private void fpsPrivateLeave_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader)
			{
				editEvent();
			}
		}
	}
}