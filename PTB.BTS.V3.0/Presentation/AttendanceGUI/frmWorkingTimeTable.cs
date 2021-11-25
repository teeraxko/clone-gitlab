using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using Facade.CommonFacade;
using Facade.AttendanceFacade;

using Presentation.CommonGUI;

using SystemFramework.AppConfig;
using SystemFramework.AppMessage;
using SystemFramework.AppException;

namespace Presentation.AttendanceGUI
{
	public class frmWorkingTimeTable : ChildFormBase, IMDIChildForm
	{
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
					frmEntry.Dispose();
					facadeWorkingTimeTable.Dispose();

					frmEntry = null;
					facadeWorkingTimeTable = null;
				}
			}
			base.Dispose( disposing );
		}
	
		#region Windows Form Designer generated code
		private System.ComponentModel.Container components = null;
		private FarPoint.Win.Spread.FpSpread fpsWorkingTimeTable;
		private FarPoint.Win.Spread.SheetView fpsWorkingTimeTable_Sheet1;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem mniAdd;
		private System.Windows.Forms.MenuItem mniEdit;
		private System.Windows.Forms.Button cmdEdit;
		private System.Windows.Forms.Button cmdAdd;
		private System.Windows.Forms.Button cmdDelete;
		private System.Windows.Forms.MenuItem mniDelete;


		private void InitializeComponent()
		{
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType7 = new FarPoint.Win.Spread.CellType.TextCellType();
			this.fpsWorkingTimeTable = new FarPoint.Win.Spread.FpSpread();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mniAdd = new System.Windows.Forms.MenuItem();
			this.mniEdit = new System.Windows.Forms.MenuItem();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			this.fpsWorkingTimeTable_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.cmdDelete = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.fpsWorkingTimeTable)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsWorkingTimeTable_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// fpsWorkingTimeTable
			// 
			this.fpsWorkingTimeTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsWorkingTimeTable.ContextMenu = this.contextMenu1;
			this.fpsWorkingTimeTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.fpsWorkingTimeTable.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsWorkingTimeTable.Location = new System.Drawing.Point(12, 24);
			this.fpsWorkingTimeTable.Name = "fpsWorkingTimeTable";
			this.fpsWorkingTimeTable.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																							 this.fpsWorkingTimeTable_Sheet1});
			this.fpsWorkingTimeTable.Size = new System.Drawing.Size(667, 312);
			this.fpsWorkingTimeTable.TabIndex = 15;
			this.fpsWorkingTimeTable.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsWorkingTimeTable_CellDoubleClick);
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
			// fpsWorkingTimeTable_Sheet1
			// 
			this.fpsWorkingTimeTable_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsWorkingTimeTable_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsWorkingTimeTable_Sheet1.ColumnCount = 7;
			this.fpsWorkingTimeTable_Sheet1.ColumnHeader.RowCount = 2;
			this.fpsWorkingTimeTable_Sheet1.RowCount = 1;
			this.fpsWorkingTimeTable_Sheet1.ColumnHeader.Cells.Get(0, 1).RowSpan = 2;
			this.fpsWorkingTimeTable_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "รูปแบบที่";
			this.fpsWorkingTimeTable_Sheet1.ColumnHeader.Cells.Get(0, 2).RowSpan = 2;
			this.fpsWorkingTimeTable_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "รายละเอียด";
			this.fpsWorkingTimeTable_Sheet1.ColumnHeader.Cells.Get(0, 3).ColumnSpan = 2;
			this.fpsWorkingTimeTable_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "เวลาทำงาน";
			this.fpsWorkingTimeTable_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "เวลาทำงาน";
			this.fpsWorkingTimeTable_Sheet1.ColumnHeader.Cells.Get(0, 5).ColumnSpan = 2;
			this.fpsWorkingTimeTable_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "เวลาพัก";
			this.fpsWorkingTimeTable_Sheet1.ColumnHeader.Cells.Get(1, 3).Text = "เริ่ม";
			this.fpsWorkingTimeTable_Sheet1.ColumnHeader.Cells.Get(1, 4).Text = "สิ้นสุด";
			this.fpsWorkingTimeTable_Sheet1.ColumnHeader.Cells.Get(1, 5).Text = "เริ่ม";
			this.fpsWorkingTimeTable_Sheet1.ColumnHeader.Cells.Get(1, 6).Text = "สิ้นสุด";
			this.fpsWorkingTimeTable_Sheet1.ColumnHeader.Columns.Default.Resizable = false;
			this.fpsWorkingTimeTable_Sheet1.ColumnHeader.Columns.Default.Visible = true;
			this.fpsWorkingTimeTable_Sheet1.Columns.Default.Resizable = false;
			this.fpsWorkingTimeTable_Sheet1.Columns.Default.Visible = true;
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsWorkingTimeTable_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsWorkingTimeTable_Sheet1.Columns.Get(0).Visible = false;
			this.fpsWorkingTimeTable_Sheet1.Columns.Get(1).AllowAutoSort = true;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			textCellType2.MaxLength = 3;
			textCellType2.ReadOnly = true;
			this.fpsWorkingTimeTable_Sheet1.Columns.Get(1).CellType = textCellType2;
			this.fpsWorkingTimeTable_Sheet1.Columns.Get(1).Width = 52F;
			this.fpsWorkingTimeTable_Sheet1.Columns.Get(2).AllowAutoSort = true;
			textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType3.DropDownButton = false;
			textCellType3.ReadOnly = true;
			this.fpsWorkingTimeTable_Sheet1.Columns.Get(2).CellType = textCellType3;
			this.fpsWorkingTimeTable_Sheet1.Columns.Get(2).Width = 300F;
			this.fpsWorkingTimeTable_Sheet1.Columns.Get(3).AllowAutoSort = true;
			textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType4.DropDownButton = false;
			textCellType4.ReadOnly = true;
			this.fpsWorkingTimeTable_Sheet1.Columns.Get(3).CellType = textCellType4;
			this.fpsWorkingTimeTable_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsWorkingTimeTable_Sheet1.Columns.Get(3).Label = "เริ่ม";
			this.fpsWorkingTimeTable_Sheet1.Columns.Get(3).Locked = false;
			this.fpsWorkingTimeTable_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
			this.fpsWorkingTimeTable_Sheet1.Columns.Get(3).Width = 61F;
			this.fpsWorkingTimeTable_Sheet1.Columns.Get(4).AllowAutoSort = true;
			textCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType5.DropDownButton = false;
			textCellType5.ReadOnly = true;
			this.fpsWorkingTimeTable_Sheet1.Columns.Get(4).CellType = textCellType5;
			this.fpsWorkingTimeTable_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsWorkingTimeTable_Sheet1.Columns.Get(4).Label = "สิ้นสุด";
			this.fpsWorkingTimeTable_Sheet1.Columns.Get(4).Locked = false;
			this.fpsWorkingTimeTable_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
			this.fpsWorkingTimeTable_Sheet1.Columns.Get(4).Width = 64F;
			this.fpsWorkingTimeTable_Sheet1.Columns.Get(5).AllowAutoSort = true;
			textCellType6.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType6.DropDownButton = false;
			textCellType6.ReadOnly = true;
			this.fpsWorkingTimeTable_Sheet1.Columns.Get(5).CellType = textCellType6;
			this.fpsWorkingTimeTable_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsWorkingTimeTable_Sheet1.Columns.Get(5).Label = "เริ่ม";
			this.fpsWorkingTimeTable_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
			this.fpsWorkingTimeTable_Sheet1.Columns.Get(5).Width = 68F;
			this.fpsWorkingTimeTable_Sheet1.Columns.Get(6).AllowAutoSort = true;
			textCellType7.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType7.DropDownButton = false;
			textCellType7.ReadOnly = true;
			this.fpsWorkingTimeTable_Sheet1.Columns.Get(6).CellType = textCellType7;
			this.fpsWorkingTimeTable_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsWorkingTimeTable_Sheet1.Columns.Get(6).Label = "สิ้นสุด";
			this.fpsWorkingTimeTable_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
			this.fpsWorkingTimeTable_Sheet1.Columns.Get(6).Width = 65F;
			this.fpsWorkingTimeTable_Sheet1.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.LightGray, System.Drawing.SystemColors.ActiveCaption, System.Drawing.SystemColors.ControlDark);
			this.fpsWorkingTimeTable_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
			this.fpsWorkingTimeTable_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsWorkingTimeTable_Sheet1.RowHeader.Rows.Default.Resizable = false;
			this.fpsWorkingTimeTable_Sheet1.Rows.Default.Resizable = false;
			this.fpsWorkingTimeTable_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
			this.fpsWorkingTimeTable_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsWorkingTimeTable_Sheet1.SheetName = "Sheet1";
			this.fpsWorkingTimeTable_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// cmdEdit
			// 
			this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdEdit.Location = new System.Drawing.Point(308, 352);
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.TabIndex = 18;
			this.cmdEdit.Text = "แก้ไข";
			this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
			// 
			// cmdAdd
			// 
			this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdAdd.Location = new System.Drawing.Point(228, 352);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.TabIndex = 17;
			this.cmdAdd.Text = "เพิ่ม";
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			// 
			// cmdDelete
			// 
			this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdDelete.Location = new System.Drawing.Point(388, 352);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.TabIndex = 19;
			this.cmdDelete.Text = "ลบ";
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			// 
			// frmWorkingTimeTable
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(690, 392);
			this.Controls.Add(this.cmdEdit);
			this.Controls.Add(this.cmdAdd);
			this.Controls.Add(this.cmdDelete);
			this.Controls.Add(this.fpsWorkingTimeTable);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmWorkingTimeTable";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //this.Text = "กำหนดรูปแบบเวลาทำงาน";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmWorkingTimeTable_Load);
			((System.ComponentModel.ISupportInitialize)(this.fpsWorkingTimeTable)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsWorkingTimeTable_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private frmWorkingTimeTableEntry frmEntry;
		private frmMain mdiParent;
		#endregion
		
//		============================== Property ==============================
		private WorkingTimeTableFacade facadeWorkingTimeTable;	
		public WorkingTimeTableFacade FacadeWorkingTimeTable
		{
			get{return facadeWorkingTimeTable;}
		}

		private int SelectedRow
		{
			get{return fpsWorkingTimeTable_Sheet1.ActiveRowIndex;}
		}

		private string SelectedKey
		{
			get{return fpsWorkingTimeTable_Sheet1.Cells[SelectedRow,0].Text;}
		}

		private WorkingTimeTable SelectedWorkingTimeTable
		{
			get{return facadeWorkingTimeTable.ObjWorkingTimeTableList[SelectedKey];}
		}

//		============================== Constructor ==============================
		public frmWorkingTimeTable() : base()
		{
			InitializeComponent();
			newOject();
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miWorkingTimeTable");
            this.title = UserProfile.GetFormName("miAttendance", "miWorkingTimeTable");

		}
        public override string FormID()
        {
            return UserProfile.GetFormID("miAttendance", "miWorkingTimeTable");
        }
//		==============================Private method ==============================
		private void newOject()
		{
			facadeWorkingTimeTable = new WorkingTimeTableFacade();
			frmEntry = new frmWorkingTimeTableEntry(this);
		}

		private void bindWorkingTimeTable(int row, WorkingTimeTable value)
		{
			fpsWorkingTimeTable_Sheet1.Cells[row,0].Text = GUIFunction.GetString(value.EntityKey);
			fpsWorkingTimeTable_Sheet1.Cells[row,1].Text = GUIFunction.GetString(value.TableID);
			fpsWorkingTimeTable_Sheet1.Cells[row,2].Text = GUIFunction.GetString(value.Description);
			fpsWorkingTimeTable_Sheet1.Cells[row,3].Text = GUIFunction.GetString(value.AWorkingTime.From.ToString("HH : mm"));
			fpsWorkingTimeTable_Sheet1.Cells[row,4].Text = GUIFunction.GetString(value.AWorkingTime.To.ToString("HH : mm"));
			fpsWorkingTimeTable_Sheet1.Cells[row,5].Text = GUIFunction.GetString(value.ABreakTime.From.ToString("HH : mm"));
			fpsWorkingTimeTable_Sheet1.Cells[row,6].Text = GUIFunction.GetString(value.ABreakTime.To.ToString("HH : mm"));
		}

		private void bindForm()
		{
			if (facadeWorkingTimeTable.ObjWorkingTimeTableList != null)
			{
				int iRow = facadeWorkingTimeTable.ObjWorkingTimeTableList.Count;
				fpsWorkingTimeTable_Sheet1.RowCount = iRow;
				for(int i=0; i<iRow; i++)
				{
					bindWorkingTimeTable(i, facadeWorkingTimeTable.ObjWorkingTimeTableList[i]);
				}	
				mdiParent.RefreshMasterCount();
			}
            fpsWorkingTimeTable_Sheet1.SetActiveCell(fpsWorkingTimeTable_Sheet1.RowCount, 0);
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
			fpsWorkingTimeTable_Sheet1.RowCount = 0;
			enableButton(false);
		}

//		==============================Public method ==============================
		public override int MasterCount()
		{
			return facadeWorkingTimeTable.ObjWorkingTimeTableList.Count;
		}
		
//		============================== Base Event ==============================
		public bool AddRow(WorkingTimeTable value)
		{
			if (facadeWorkingTimeTable.InsertWorkingTimeTable(value))
			{
				fpsWorkingTimeTable_Sheet1.RowCount++;
				bindWorkingTimeTable(fpsWorkingTimeTable_Sheet1.RowCount-1, value);
                fpsWorkingTimeTable_Sheet1.SetActiveCell(fpsWorkingTimeTable_Sheet1.RowCount, 0);
				enableButton(true);
				mdiParent.RefreshMasterCount();
				return true;
			}
			else
			{				
				return false;
			}
		}

		public bool UpdateRow(WorkingTimeTable value)
		{
			if (facadeWorkingTimeTable.UpdateWorkingTimeTable(value))
			{
				bindWorkingTimeTable(SelectedRow, value);				
				return true;
			}
			else
			{				
				return false;
			}
		}

		private void DeleteRow()
		{
			if (facadeWorkingTimeTable.DeleteWorkingTimeTable(SelectedWorkingTimeTable))
			{
				if(fpsWorkingTimeTable_Sheet1.RowCount > 1)
				{
					fpsWorkingTimeTable.ActiveSheet.Rows.Remove(SelectedRow,1);
				}
				else
				{
					clearForm();
				}

				mdiParent.RefreshMasterCount();
			}			
		}

		public void InitForm()
		{
			newOject();

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
				if (facadeWorkingTimeTable.DisplayWorkingTimeTable())
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
				frmEntry = new frmWorkingTimeTableEntry(this);
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
				frmEntry = new frmWorkingTimeTableEntry(this);
				frmEntry.InitEditAction(SelectedWorkingTimeTable);
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

//		============================== event ==============================
		private void frmWorkingTimeTable_Load(object sender, System.EventArgs e)
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

		private void fpsWorkingTimeTable_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader)
			{
				editEvent();
			}
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
	}
}
