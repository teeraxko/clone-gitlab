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

using Facade.CommonFacade;
using Facade.AttendanceFacade;

using Presentation.CommonGUI;

namespace Presentation.AttendanceGUI
{
	public class frmHolidayConditionSpecific : ChildFormBase, IMDIChildForm
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
		private System.Windows.Forms.Button cmdDelete;
		private System.Windows.Forms.Button cmdEdit;
		private System.Windows.Forms.Button cmdAdd;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem mniAdd;
		private System.Windows.Forms.MenuItem mniEdit;
		private System.Windows.Forms.MenuItem mniDelete;
		private FarPoint.Win.Spread.FpSpread fpsHolidayConditionSpecific;
		private FarPoint.Win.Spread.SheetView fpsHolidayConditionSpecific_Sheet1;

		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmHolidayConditionSpecific));
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType2 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
			FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType3 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
			this.fpsHolidayConditionSpecific = new FarPoint.Win.Spread.FpSpread();
			this.fpsHolidayConditionSpecific_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mniAdd = new System.Windows.Forms.MenuItem();
			this.mniEdit = new System.Windows.Forms.MenuItem();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			((System.ComponentModel.ISupportInitialize)(this.fpsHolidayConditionSpecific)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsHolidayConditionSpecific_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// fpsHolidayConditionSpecific
			// 
			this.fpsHolidayConditionSpecific.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsHolidayConditionSpecific.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsHolidayConditionSpecific.Location = new System.Drawing.Point(13, 8);
			this.fpsHolidayConditionSpecific.Name = "fpsHolidayConditionSpecific";
			this.fpsHolidayConditionSpecific.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																									 this.fpsHolidayConditionSpecific_Sheet1});
			this.fpsHolidayConditionSpecific.Size = new System.Drawing.Size(918, 376);
			this.fpsHolidayConditionSpecific.TabIndex = 0;
			this.fpsHolidayConditionSpecific.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsHolidayConditionSpecific_CellDoubleClick);
			// 
			// fpsHolidayConditionSpecific_Sheet1
			// 
			this.fpsHolidayConditionSpecific_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsHolidayConditionSpecific_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsHolidayConditionSpecific_Sheet1.ColumnCount = 7;
			this.fpsHolidayConditionSpecific_Sheet1.ColumnHeader.RowCount = 2;
			this.fpsHolidayConditionSpecific_Sheet1.RowCount = 1;
			this.fpsHolidayConditionSpecific_Sheet1.Cells.Get(0, 4).CellType = checkBoxCellType1;
			this.fpsHolidayConditionSpecific_Sheet1.ColumnHeader.Cells.Get(0, 1).RowSpan = 3;
			this.fpsHolidayConditionSpecific_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "ชื่อ - สกุล";
			this.fpsHolidayConditionSpecific_Sheet1.ColumnHeader.Cells.Get(0, 2).RowSpan = 2;
			this.fpsHolidayConditionSpecific_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "รหัส";
			this.fpsHolidayConditionSpecific_Sheet1.ColumnHeader.Cells.Get(0, 3).RowSpan = 2;
			this.fpsHolidayConditionSpecific_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ส่วนงาน";
			this.fpsHolidayConditionSpecific_Sheet1.ColumnHeader.Cells.Get(0, 4).ColumnSpan = 3;
			this.fpsHolidayConditionSpecific_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "กำหนดวันหยุด";
			this.fpsHolidayConditionSpecific_Sheet1.ColumnHeader.Cells.Get(1, 4).Text = "วันเสาร์";
			this.fpsHolidayConditionSpecific_Sheet1.ColumnHeader.Cells.Get(1, 5).Text = "วันอาทิตย์";
			this.fpsHolidayConditionSpecific_Sheet1.ColumnHeader.Cells.Get(1, 6).Text = "วันหยุดนักขัตฤกษ์";
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsHolidayConditionSpecific_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsHolidayConditionSpecific_Sheet1.Columns.Get(0).Visible = false;
			this.fpsHolidayConditionSpecific_Sheet1.Columns.Get(1).AllowAutoSort = true;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			this.fpsHolidayConditionSpecific_Sheet1.Columns.Get(1).CellType = textCellType2;
			this.fpsHolidayConditionSpecific_Sheet1.Columns.Get(1).Resizable = false;
			this.fpsHolidayConditionSpecific_Sheet1.Columns.Get(1).Width = 200F;
			this.fpsHolidayConditionSpecific_Sheet1.Columns.Get(2).AllowAutoSort = true;
			textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType3.DropDownButton = false;
			this.fpsHolidayConditionSpecific_Sheet1.Columns.Get(2).CellType = textCellType3;
			this.fpsHolidayConditionSpecific_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsHolidayConditionSpecific_Sheet1.Columns.Get(2).Resizable = false;
			this.fpsHolidayConditionSpecific_Sheet1.Columns.Get(2).Width = 57F;
			this.fpsHolidayConditionSpecific_Sheet1.Columns.Get(3).AllowAutoSort = true;
			textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType4.DropDownButton = false;
			this.fpsHolidayConditionSpecific_Sheet1.Columns.Get(3).CellType = textCellType4;
			this.fpsHolidayConditionSpecific_Sheet1.Columns.Get(3).Resizable = false;
			this.fpsHolidayConditionSpecific_Sheet1.Columns.Get(3).Width = 232F;
			this.fpsHolidayConditionSpecific_Sheet1.Columns.Get(4).CellType = checkBoxCellType2;
			this.fpsHolidayConditionSpecific_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsHolidayConditionSpecific_Sheet1.Columns.Get(4).Label = "วันเสาร์";
			this.fpsHolidayConditionSpecific_Sheet1.Columns.Get(4).Resizable = false;
			this.fpsHolidayConditionSpecific_Sheet1.Columns.Get(4).Width = 63F;
			this.fpsHolidayConditionSpecific_Sheet1.Columns.Get(5).CellType = checkBoxCellType3;
			this.fpsHolidayConditionSpecific_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsHolidayConditionSpecific_Sheet1.Columns.Get(5).Label = "วันอาทิตย์";
			this.fpsHolidayConditionSpecific_Sheet1.Columns.Get(5).Resizable = false;
			this.fpsHolidayConditionSpecific_Sheet1.Columns.Get(5).Width = 59F;
			textCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType5.DropDownButton = false;
			this.fpsHolidayConditionSpecific_Sheet1.Columns.Get(6).CellType = textCellType5;
			this.fpsHolidayConditionSpecific_Sheet1.Columns.Get(6).Label = "วันหยุดนักขัตฤกษ์";
			this.fpsHolidayConditionSpecific_Sheet1.Columns.Get(6).Resizable = false;
			this.fpsHolidayConditionSpecific_Sheet1.Columns.Get(6).Width = 250F;
			this.fpsHolidayConditionSpecific_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
			this.fpsHolidayConditionSpecific_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsHolidayConditionSpecific_Sheet1.RowHeader.Rows.Default.Resizable = false;
			this.fpsHolidayConditionSpecific_Sheet1.Rows.Default.Resizable = false;
			this.fpsHolidayConditionSpecific_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
			this.fpsHolidayConditionSpecific_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsHolidayConditionSpecific_Sheet1.SheetName = "Sheet1";
			this.fpsHolidayConditionSpecific_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// cmdDelete
			// 
			this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdDelete.Location = new System.Drawing.Point(528, 400);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.Size = new System.Drawing.Size(72, 24);
			this.cmdDelete.TabIndex = 6;
			this.cmdDelete.Text = "ลบ";
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			// 
			// cmdEdit
			// 
			this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdEdit.Location = new System.Drawing.Point(448, 400);
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.Size = new System.Drawing.Size(72, 24);
			this.cmdEdit.TabIndex = 5;
			this.cmdEdit.Text = "แก้ไข";
			this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
			// 
			// cmdAdd
			// 
			this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdAdd.Location = new System.Drawing.Point(368, 400);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.Size = new System.Drawing.Size(72, 24);
			this.cmdAdd.TabIndex = 4;
			this.cmdAdd.Text = "เพิ่ม";
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
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
			// frmHolidayConditionSpecific
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(944, 437);
			this.ContextMenu = this.contextMenu1;
			this.Controls.Add(this.cmdDelete);
			this.Controls.Add(this.cmdEdit);
			this.Controls.Add(this.cmdAdd);
			this.Controls.Add(this.fpsHolidayConditionSpecific);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmHolidayConditionSpecific";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "กำหนดเงื่อนไขวันหยุดตามพนักงาน";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmHolidayConditionSpecific_Load);
			((System.ComponentModel.ISupportInitialize)(this.fpsHolidayConditionSpecific)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsHolidayConditionSpecific_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private frmHolidayConditionSpecificEntry frmEntry;
		private frmMain mdiParent;
		#endregion

//		============================== Property ==============================		
		private HolidayConditionSpecificFacade facadeHolidayConditionSpecific;
		public HolidayConditionSpecificFacade FacadeHolidayConditionSpecific
		{
			get{return facadeHolidayConditionSpecific;}
		}

		private int SelectedRow
		{
			get{return fpsHolidayConditionSpecific_Sheet1.ActiveRowIndex;}
		}

		private string SelectedKey
		{
			get{return fpsHolidayConditionSpecific_Sheet1.Cells[SelectedRow,0].Text;}
		}

		private HolidayConditionSpecific SelectedHolidayConditionSpecific
		{
			get{return facadeHolidayConditionSpecific.ObjHolidayConditionSpecificList[SelectedKey];}
		}

//		============================== Constructor ==============================
		public frmHolidayConditionSpecific()
		{
			InitializeComponent();
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miHolidayConditionSpecific");
            this.title = UserProfile.GetFormName("miAttendance", "miHolidayConditionSpecific");

		}
        public override string FormID()
        {
            return UserProfile.GetFormID("miAttendance", "miHolidayConditionSpecific");
        }
//		==============================Private method ==============================
		private void newObject()
		{
			facadeHolidayConditionSpecific = new HolidayConditionSpecificFacade();
			frmEntry = new frmHolidayConditionSpecificEntry(this);
		}

		private void bindHolidayConditionSpecific(int row, HolidayConditionSpecific value)
		{
			fpsHolidayConditionSpecific_Sheet1.Cells[row,0].Text = value.EntityKey;
			fpsHolidayConditionSpecific_Sheet1.Cells[row,1].Text = GUIFunction.GetString(value.AEmployee.EmployeeName);
			fpsHolidayConditionSpecific_Sheet1.Cells[row,2].Text = GUIFunction.GetString(value.AEmployee.EmployeeNo);
			fpsHolidayConditionSpecific_Sheet1.Cells[row,3].Text = GUIFunction.GetString(value.AEmployee.ASection.AFullName.Thai);

			if(value.SaturdayBreak)
			{
				fpsHolidayConditionSpecific_Sheet1.Cells[row,4].Text = "True";
			}
			else
			{
				fpsHolidayConditionSpecific_Sheet1.Cells[row,4].Text = "False";
			}

			if(value.SundayBreak)
			{
				fpsHolidayConditionSpecific_Sheet1.Cells[row,5].Text= "True";
			}
			else
			{
				fpsHolidayConditionSpecific_Sheet1.Cells[row,5].Text = "False";
			}

			if(value.ATraditionalHolidayPattern != null)
			{
				fpsHolidayConditionSpecific_Sheet1.Cells[row,6].Text = GUIFunction.GetString(value.ATraditionalHolidayPattern.AName.Thai);
			}
		}

		private void bindForm()
		{
			if (facadeHolidayConditionSpecific.ObjHolidayConditionSpecificList != null)
			{
				int iRow = facadeHolidayConditionSpecific.ObjHolidayConditionSpecificList.Count;
				fpsHolidayConditionSpecific_Sheet1.RowCount = iRow;
				for(int i=0; i<iRow; i++)
				{
					bindHolidayConditionSpecific(i, facadeHolidayConditionSpecific.ObjHolidayConditionSpecificList[i]);
				}		
				mdiParent.RefreshMasterCount();
			}
            fpsHolidayConditionSpecific_Sheet1.SetActiveCell(fpsHolidayConditionSpecific_Sheet1.RowCount, 0);
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
			fpsHolidayConditionSpecific_Sheet1.RowCount = 0;
			enableButton(false);
		}		

//		============================== Public method ==============================
		public bool AddRow(HolidayConditionSpecific value)
		{
			if (facadeHolidayConditionSpecific.InsertHolidayConditionSpecific(value))
			{
				fpsHolidayConditionSpecific_Sheet1.RowCount++;
				bindHolidayConditionSpecific(fpsHolidayConditionSpecific_Sheet1.RowCount-1, value);
                fpsHolidayConditionSpecific_Sheet1.SetActiveCell(fpsHolidayConditionSpecific_Sheet1.RowCount, 0);
				enableButton(true);
				mdiParent.RefreshMasterCount();
				return true;
			}
			else
			{				
				return false;
			}
		}

		public bool UpdateRow(HolidayConditionSpecific value)
		{
			if (facadeHolidayConditionSpecific.UpdateHolidayConditionSpecific(value))
			{
				bindHolidayConditionSpecific(SelectedRow, value);				
				return true;
			}
			else
			{				
				return false;
			}
		}

		public void DeleteRow()
		{
			if (facadeHolidayConditionSpecific.DeleteHolidayConditionSpecific(SelectedHolidayConditionSpecific))
			{
				if(fpsHolidayConditionSpecific_Sheet1.RowCount > 1)
				{
					fpsHolidayConditionSpecific.ActiveSheet.Rows.Remove(SelectedRow, 1);
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
			return facadeHolidayConditionSpecific.ObjHolidayConditionSpecificList.Count;
		}

//		============================== Base Event ==============================
		public void InitForm()
		{
			newObject();

			MainMenuNewStatus = false;
			MainMenuDeleteStatus = false;
			MainMenuRefreshStatus = true;
			MainMenuPrintStatus = true;
			mdiParent.EnableNewCommand(false);
			mdiParent.EnableDeleteCommand(false);
			mdiParent.EnableRefreshCommand(true);
			mdiParent.EnablePrintCommand(true);

			try
			{
				if (facadeHolidayConditionSpecific.DisplayHolidayConditionSpecific())
				{
					bindForm();
				}
				else
				{
					clearForm();
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

		public void RefreshForm()
		{
			InitForm();
		}

		public void PrintForm()
		{
		}

		public void ExitForm()
		{
			mdiParent.EnableNewCommand(false);
			mdiParent.EnableDeleteCommand(false);
			mdiParent.EnableRefreshCommand(false);
			mdiParent.EnablePrintCommand(false);
			mdiParent.EnableExitCommand(true);

			Dispose(true);
		}
		
		private void addEvent()
		{
			try
			{
				frmEntry = new frmHolidayConditionSpecificEntry(this);
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
				frmEntry = new frmHolidayConditionSpecificEntry(this);
				frmEntry.InitEditAction(SelectedHolidayConditionSpecific);
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
		private void frmHolidayConditionSpecific_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
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

		private void fpsHolidayConditionSpecific_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader)
			{
				editEvent();
			}
		}
	}
}
