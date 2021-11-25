using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using SystemFramework.AppConfig;
using SystemFramework.AppMessage;
using SystemFramework.AppException;

using Entity.CommonEntity;
using ictus.PIS.PI.Entity;
using Entity.AttendanceEntities;

using Facade.CommonFacade;
using Facade.AttendanceFacade;

using Presentation.CommonGUI;

namespace Presentation.AttendanceGUI
{
	public class frmWorkingTimeConditionSpecific  : ChildFormBase, IMDIChildForm	
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
		private FarPoint.Win.Spread.FpSpread fpsWorkingTimeConditionSpecific;
		private FarPoint.Win.Spread.SheetView fpsWorkingTimeConditionSpecific_Sheet1;

		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
			this.fpsWorkingTimeConditionSpecific = new FarPoint.Win.Spread.FpSpread();
			this.fpsWorkingTimeConditionSpecific_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mniAdd = new System.Windows.Forms.MenuItem();
			this.mniEdit = new System.Windows.Forms.MenuItem();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			((System.ComponentModel.ISupportInitialize)(this.fpsWorkingTimeConditionSpecific)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsWorkingTimeConditionSpecific_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// fpsWorkingTimeConditionSpecific
			// 
			this.fpsWorkingTimeConditionSpecific.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsWorkingTimeConditionSpecific.ContextMenu = this.contextMenu1;
			this.fpsWorkingTimeConditionSpecific.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsWorkingTimeConditionSpecific.Location = new System.Drawing.Point(23, 21);
			this.fpsWorkingTimeConditionSpecific.Name = "fpsWorkingTimeConditionSpecific";
			this.fpsWorkingTimeConditionSpecific.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																										 this.fpsWorkingTimeConditionSpecific_Sheet1});
			this.fpsWorkingTimeConditionSpecific.Size = new System.Drawing.Size(915, 376);
			this.fpsWorkingTimeConditionSpecific.TabIndex = 7;
			this.fpsWorkingTimeConditionSpecific.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsWorkingTimeConditionSpecific_CellDoubleClick);
			// 
			// fpsWorkingTimeConditionSpecific_Sheet1
			// 
			this.fpsWorkingTimeConditionSpecific_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsWorkingTimeConditionSpecific_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsWorkingTimeConditionSpecific_Sheet1.ColumnCount = 5;
			this.fpsWorkingTimeConditionSpecific_Sheet1.ColumnHeader.RowCount = 2;
			this.fpsWorkingTimeConditionSpecific_Sheet1.RowCount = 1;
			this.fpsWorkingTimeConditionSpecific_Sheet1.ColumnHeader.Cells.Get(0, 1).RowSpan = 3;
			this.fpsWorkingTimeConditionSpecific_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "ชื่อ - สกุล";
			this.fpsWorkingTimeConditionSpecific_Sheet1.ColumnHeader.Cells.Get(0, 2).RowSpan = 2;
			this.fpsWorkingTimeConditionSpecific_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "รหัส";
			this.fpsWorkingTimeConditionSpecific_Sheet1.ColumnHeader.Cells.Get(0, 3).RowSpan = 2;
			this.fpsWorkingTimeConditionSpecific_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ส่วนงาน";
			this.fpsWorkingTimeConditionSpecific_Sheet1.ColumnHeader.Cells.Get(0, 4).RowSpan = 2;
			this.fpsWorkingTimeConditionSpecific_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "รูปแบบเวลาทำงาน";
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsWorkingTimeConditionSpecific_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsWorkingTimeConditionSpecific_Sheet1.Columns.Get(0).Visible = false;
			this.fpsWorkingTimeConditionSpecific_Sheet1.Columns.Get(1).AllowAutoSort = true;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			this.fpsWorkingTimeConditionSpecific_Sheet1.Columns.Get(1).CellType = textCellType2;
			this.fpsWorkingTimeConditionSpecific_Sheet1.Columns.Get(1).Resizable = false;
			this.fpsWorkingTimeConditionSpecific_Sheet1.Columns.Get(1).Width = 180F;
			this.fpsWorkingTimeConditionSpecific_Sheet1.Columns.Get(2).AllowAutoSort = true;
			textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType3.DropDownButton = false;
			this.fpsWorkingTimeConditionSpecific_Sheet1.Columns.Get(2).CellType = textCellType3;
			this.fpsWorkingTimeConditionSpecific_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsWorkingTimeConditionSpecific_Sheet1.Columns.Get(2).Resizable = false;
			this.fpsWorkingTimeConditionSpecific_Sheet1.Columns.Get(2).Width = 57F;
			this.fpsWorkingTimeConditionSpecific_Sheet1.Columns.Get(3).AllowAutoSort = true;
			textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType4.DropDownButton = false;
			this.fpsWorkingTimeConditionSpecific_Sheet1.Columns.Get(3).CellType = textCellType4;
			this.fpsWorkingTimeConditionSpecific_Sheet1.Columns.Get(3).Resizable = false;
			this.fpsWorkingTimeConditionSpecific_Sheet1.Columns.Get(3).Width = 232F;
			this.fpsWorkingTimeConditionSpecific_Sheet1.Columns.Get(4).AllowAutoSort = true;
			textCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType5.DropDownButton = false;
			this.fpsWorkingTimeConditionSpecific_Sheet1.Columns.Get(4).CellType = textCellType5;
			this.fpsWorkingTimeConditionSpecific_Sheet1.Columns.Get(4).Resizable = false;
			this.fpsWorkingTimeConditionSpecific_Sheet1.Columns.Get(4).Width = 390F;
			this.fpsWorkingTimeConditionSpecific_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
			this.fpsWorkingTimeConditionSpecific_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsWorkingTimeConditionSpecific_Sheet1.RowHeader.Rows.Default.Resizable = false;
			this.fpsWorkingTimeConditionSpecific_Sheet1.Rows.Default.Resizable = false;
			this.fpsWorkingTimeConditionSpecific_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
			this.fpsWorkingTimeConditionSpecific_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsWorkingTimeConditionSpecific_Sheet1.SheetName = "Sheet1";
			this.fpsWorkingTimeConditionSpecific_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// cmdDelete
			// 
			this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdDelete.Location = new System.Drawing.Point(532, 424);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.TabIndex = 11;
			this.cmdDelete.Text = "ลบ";
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			// 
			// cmdEdit
			// 
			this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdEdit.Location = new System.Drawing.Point(444, 424);
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.TabIndex = 10;
			this.cmdEdit.Text = "แก้ไข";
			this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
			// 
			// cmdAdd
			// 
			this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdAdd.Location = new System.Drawing.Point(354, 424);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.TabIndex = 9;
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
			this.mniAdd.Text = "&เพิ่ม           ";
			this.mniAdd.Click += new System.EventHandler(this.mniAdd_Click);
			// 
			// mniEdit
			// 
			this.mniEdit.Index = 1;
			this.mniEdit.Text = "&แก้ไข         ";
			this.mniEdit.Click += new System.EventHandler(this.mniEdit_Click);
			// 
			// mniDelete
			// 
			this.mniDelete.Index = 2;
			this.mniDelete.Text = "&ลบ       ";
			this.mniDelete.Click += new System.EventHandler(this.mniDelete_Click);
			// 
			// frmWorkingTimeConditionSpecific
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(960, 469);
			this.Controls.Add(this.cmdDelete);
			this.Controls.Add(this.cmdEdit);
			this.Controls.Add(this.cmdAdd);
			this.Controls.Add(this.fpsWorkingTimeConditionSpecific);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmWorkingTimeConditionSpecific";
			this.Text = "frmWorkingTimeConditionSpecific";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmWorkingTimeConditionSpecific_Load);
			((System.ComponentModel.ISupportInitialize)(this.fpsWorkingTimeConditionSpecific)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsWorkingTimeConditionSpecific_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private frmWorkingTimeConditionSpecificEntry frmEntry;
		private frmMain mdiParent;
		#endregion
		
//		============================== Property ==============================
		private WorkingTimeConditionSpecificFacade facadeWorkingTimeConditionSpecific;	
		public WorkingTimeConditionSpecificFacade FacadeWorkingTimeConditionSpecific
		{
			get{return facadeWorkingTimeConditionSpecific;}
		}

		private int SelectedRow
		{
			get{return fpsWorkingTimeConditionSpecific_Sheet1.ActiveRowIndex;}
		}

		private string SelectedKey
		{
			get{return fpsWorkingTimeConditionSpecific_Sheet1.Cells[SelectedRow,0].Text;}
		}

		private WorkingTimeConditionSpecific selectedWorkingTimeConditionSpecific
		{
			get{return facadeWorkingTimeConditionSpecific.ObjWorkingTimeConditionSpecificList[SelectedKey];}
		}

//		============================== Constructor ==============================
		public frmWorkingTimeConditionSpecific() : base()
		{
			InitializeComponent();
			newObject();
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miWorkingTimeConditionSpecific");
            this.title = UserProfile.GetFormName("miAttendance", "miWorkingTimeConditionSpecific");

		}
        public override string FormID()
        {
            return UserProfile.GetFormID("miAttendance", "miWorkingTimeCondition");
        }

//		==============================Private method ==============================
		private void newObject()
		{
			facadeWorkingTimeConditionSpecific = new WorkingTimeConditionSpecificFacade();
			frmEntry = new frmWorkingTimeConditionSpecificEntry(this);
		}

		private void bindForm()
		{	
			if (facadeWorkingTimeConditionSpecific.ObjWorkingTimeConditionSpecificList != null)
			{
				int iRow = facadeWorkingTimeConditionSpecific.ObjWorkingTimeConditionSpecificList.Count;
				fpsWorkingTimeConditionSpecific_Sheet1.RowCount = iRow;
				for(int i=0; i<iRow; i++)
				{
					bindWorkingTimeConditionSpecific(i, facadeWorkingTimeConditionSpecific.ObjWorkingTimeConditionSpecificList[i]);
				}				
			}
            fpsWorkingTimeConditionSpecific_Sheet1.SetActiveCell(fpsWorkingTimeConditionSpecific_Sheet1.RowCount, 0);
		}
		
		private void bindWorkingTimeConditionSpecific(int row, WorkingTimeConditionSpecific value)
		{
			fpsWorkingTimeConditionSpecific_Sheet1.Cells[row,0].Text = GUIFunction.GetString(value.EntityKey);
			fpsWorkingTimeConditionSpecific_Sheet1.Cells[row,1].Text = GUIFunction.GetString(value.AEmployee.EmployeeName);
			fpsWorkingTimeConditionSpecific_Sheet1.Cells[row,2].Text = GUIFunction.GetString(value.AEmployee.EmployeeNo);
			fpsWorkingTimeConditionSpecific_Sheet1.Cells[row,3].Text = GUIFunction.GetString(value.AEmployee.ASection.AFullName.English);
			fpsWorkingTimeConditionSpecific_Sheet1.Cells[row,4].Text = GUIFunction.GetString(value.AWorkingTimeTable.Description);		
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
			fpsWorkingTimeConditionSpecific_Sheet1.RowCount = 0;
			enableButton(false);
		}
	   
//      ============================== Public Method  ============================
		public bool AddRow(WorkingTimeConditionSpecific value)
		{
			if (facadeWorkingTimeConditionSpecific.InsertWorkingTimeConditionSpecific(value))
			{
				fpsWorkingTimeConditionSpecific_Sheet1.RowCount++;
				bindWorkingTimeConditionSpecific(fpsWorkingTimeConditionSpecific_Sheet1.RowCount-1, value);
                fpsWorkingTimeConditionSpecific_Sheet1.SetActiveCell(fpsWorkingTimeConditionSpecific_Sheet1.RowCount, 0);
				enableButton(true);
				return true;
			}
			return false;
		}

		public bool UpdateRow(WorkingTimeConditionSpecific value)
		{
			if (facadeWorkingTimeConditionSpecific.UpdateWorkingTimeConditionSpecific(value))
			{
				bindWorkingTimeConditionSpecific(SelectedRow, value);				
				return true;
			}			
			return false;
		}

		private void DeleteRow()
		{
			if (facadeWorkingTimeConditionSpecific.DeleteWorkingTimeConditionSpecific(selectedWorkingTimeConditionSpecific))
			{
				if(fpsWorkingTimeConditionSpecific_Sheet1.RowCount > 1)
				{
					fpsWorkingTimeConditionSpecific.ActiveSheet.Rows.Remove(SelectedRow,1);
				}
				else
				{clearForm();}				
			}
		}

//      ============================== Base Event ==============================
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
				if (facadeWorkingTimeConditionSpecific.DisplayWorkingTimeConditionSpecific())
				{
					bindForm();
				}
				else
				{
					clearForm();
				}
			}
			catch(SqlException sqlex)
			{Message(sqlex);}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(Exception ex)
			{Message(ex);}	
		
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
			clearMainMenuStatus();
			Dispose(true);
		}

		private void addEvent()
		{
			try
			{
				frmEntry = new frmWorkingTimeConditionSpecificEntry(this);
				frmEntry.InitAddAction();
				frmEntry.ShowDialog();			
			}
			catch(SqlException sqlex)
			{Message(sqlex);}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(Exception ex)
			{Message(ex);}
		}

		private void editEvent()
		{
			try
			{
				frmEntry = new frmWorkingTimeConditionSpecificEntry(this);
				frmEntry.InitEditAction(selectedWorkingTimeConditionSpecific);
				frmEntry.ShowDialog();			
			}
			catch(SqlException sqlex)
			{Message(sqlex);}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(Exception ex)
			{Message(ex);}
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
			{Message(sqlex);}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(Exception ex)
			{Message(ex);}		
		}

//		============================== Event ==============================
		private void frmWorkingTimeConditionSpecific_Load(object sender, System.EventArgs e)
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
		private void cmdShow_Click(object sender, System.EventArgs e)
		{
			RefreshForm();
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

		private void fpsWorkingTimeConditionSpecific_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader)
			{
				editEvent();
			}
		}
	}
}
