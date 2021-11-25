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
using Entity.AttendanceEntities;

using Facade.CommonFacade;
using Facade.AttendanceFacade;

using Presentation.CommonGUI;

namespace Presentation.AttendanceGUI
{
	public class frmWorkingTimeCondition  : ChildFormBase, IMDIChildForm	
	{
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
					frmEntry.Dispose();
					facadeWorkingTimeCondition.Dispose();

					frmEntry = null;
					facadeWorkingTimeCondition = null;
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		private FarPoint.Win.Spread.FpSpread fpsWorkingTimeCondition;
		private FarPoint.Win.Spread.SheetView fpsWorkingTimeCondition_Sheet1;
		private System.Windows.Forms.Button cmdAdd;
		private System.Windows.Forms.Button cmdEdit;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem mniAdd;
		private System.Windows.Forms.MenuItem mniEdit;
		private System.Windows.Forms.MenuItem mniDelete;
		private System.Windows.Forms.Button cmdDelete;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
			this.fpsWorkingTimeCondition = new FarPoint.Win.Spread.FpSpread();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mniAdd = new System.Windows.Forms.MenuItem();
			this.mniEdit = new System.Windows.Forms.MenuItem();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			this.fpsWorkingTimeCondition_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdDelete = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.fpsWorkingTimeCondition)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsWorkingTimeCondition_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// fpsWorkingTimeCondition
			// 
			this.fpsWorkingTimeCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsWorkingTimeCondition.ContextMenu = this.contextMenu1;
			this.fpsWorkingTimeCondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.fpsWorkingTimeCondition.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsWorkingTimeCondition.Location = new System.Drawing.Point(14, 24);
			this.fpsWorkingTimeCondition.Name = "fpsWorkingTimeCondition";
			this.fpsWorkingTimeCondition.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																								 this.fpsWorkingTimeCondition_Sheet1});
			this.fpsWorkingTimeCondition.Size = new System.Drawing.Size(1002, 384);
			this.fpsWorkingTimeCondition.TabIndex = 10;
			this.fpsWorkingTimeCondition.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsWorkingTimeCondition_CellDoubleClick);
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
			// fpsWorkingTimeCondition_Sheet1
			// 
			this.fpsWorkingTimeCondition_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsWorkingTimeCondition_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsWorkingTimeCondition_Sheet1.ColumnCount = 7;
			this.fpsWorkingTimeCondition_Sheet1.RowCount = 1;
			this.fpsWorkingTimeCondition_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "บริการ/สำนักงาน";
			this.fpsWorkingTimeCondition_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "ประเภทพนักงานบริการ";
			this.fpsWorkingTimeCondition_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ลูกค้า";
			this.fpsWorkingTimeCondition_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "แผนก";
			this.fpsWorkingTimeCondition_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "รูปแบบที่";
			this.fpsWorkingTimeCondition_Sheet1.ColumnHeader.Cells.Get(0, 6).Text = "รายละเอียด";
			this.fpsWorkingTimeCondition_Sheet1.ColumnHeader.Rows.Get(0).Height = 25F;
			this.fpsWorkingTimeCondition_Sheet1.Columns.Get(0).Visible = false;
			this.fpsWorkingTimeCondition_Sheet1.Columns.Get(0).Width = 54F;
			this.fpsWorkingTimeCondition_Sheet1.Columns.Get(1).AllowAutoSort = true;
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			textCellType1.ReadOnly = true;
			this.fpsWorkingTimeCondition_Sheet1.Columns.Get(1).CellType = textCellType1;
			this.fpsWorkingTimeCondition_Sheet1.Columns.Get(1).Label = "บริการ/สำนักงาน";
			this.fpsWorkingTimeCondition_Sheet1.Columns.Get(1).Resizable = false;
			this.fpsWorkingTimeCondition_Sheet1.Columns.Get(1).Width = 92F;
			this.fpsWorkingTimeCondition_Sheet1.Columns.Get(2).AllowAutoSort = true;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			textCellType2.ReadOnly = true;
			this.fpsWorkingTimeCondition_Sheet1.Columns.Get(2).CellType = textCellType2;
			this.fpsWorkingTimeCondition_Sheet1.Columns.Get(2).Label = "ประเภทพนักงานบริการ";
			this.fpsWorkingTimeCondition_Sheet1.Columns.Get(2).Resizable = false;
			this.fpsWorkingTimeCondition_Sheet1.Columns.Get(2).Width = 230F;
			this.fpsWorkingTimeCondition_Sheet1.Columns.Get(3).AllowAutoSort = true;
			textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType3.DropDownButton = false;
			textCellType3.ReadOnly = true;
			this.fpsWorkingTimeCondition_Sheet1.Columns.Get(3).CellType = textCellType3;
			this.fpsWorkingTimeCondition_Sheet1.Columns.Get(3).Label = "ลูกค้า";
			this.fpsWorkingTimeCondition_Sheet1.Columns.Get(3).Resizable = false;
			this.fpsWorkingTimeCondition_Sheet1.Columns.Get(3).Width = 280F;
			this.fpsWorkingTimeCondition_Sheet1.Columns.Get(4).AllowAutoSort = true;
			textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType4.DropDownButton = false;
			this.fpsWorkingTimeCondition_Sheet1.Columns.Get(4).CellType = textCellType4;
			this.fpsWorkingTimeCondition_Sheet1.Columns.Get(4).Label = "แผนก";
			this.fpsWorkingTimeCondition_Sheet1.Columns.Get(4).Width = 66F;
			this.fpsWorkingTimeCondition_Sheet1.Columns.Get(5).AllowAutoSort = true;
			textCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType5.DropDownButton = false;
			this.fpsWorkingTimeCondition_Sheet1.Columns.Get(5).CellType = textCellType5;
			this.fpsWorkingTimeCondition_Sheet1.Columns.Get(5).Label = "รูปแบบที่";
			this.fpsWorkingTimeCondition_Sheet1.Columns.Get(5).Width = 66F;
			this.fpsWorkingTimeCondition_Sheet1.Columns.Get(6).AllowAutoSort = true;
			textCellType6.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType6.DropDownButton = false;
			this.fpsWorkingTimeCondition_Sheet1.Columns.Get(6).CellType = textCellType6;
			this.fpsWorkingTimeCondition_Sheet1.Columns.Get(6).Label = "รายละเอียด";
			this.fpsWorkingTimeCondition_Sheet1.Columns.Get(6).Width = 225F;
			this.fpsWorkingTimeCondition_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
			this.fpsWorkingTimeCondition_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsWorkingTimeCondition_Sheet1.RowHeader.Columns.Get(0).Width = 21F;
			this.fpsWorkingTimeCondition_Sheet1.RowHeader.Rows.Default.Resizable = false;
			this.fpsWorkingTimeCondition_Sheet1.Rows.Default.Resizable = false;
			this.fpsWorkingTimeCondition_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
			this.fpsWorkingTimeCondition_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsWorkingTimeCondition_Sheet1.SheetName = "Sheet1";
			this.fpsWorkingTimeCondition_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// cmdAdd
			// 
			this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdAdd.Location = new System.Drawing.Point(389, 432);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.TabIndex = 6;
			this.cmdAdd.Text = "เพิ่ม";
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			// 
			// cmdEdit
			// 
			this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdEdit.Location = new System.Drawing.Point(479, 432);
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.TabIndex = 7;
			this.cmdEdit.Text = "แก้ไข";
			this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
			// 
			// cmdDelete
			// 
			this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdDelete.Location = new System.Drawing.Point(567, 432);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.TabIndex = 8;
			this.cmdDelete.Text = "ลบ";
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			// 
			// frmWorkingTimeCondition
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1030, 479);
			this.Controls.Add(this.cmdDelete);
			this.Controls.Add(this.cmdEdit);
			this.Controls.Add(this.cmdAdd);
			this.Controls.Add(this.fpsWorkingTimeCondition);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmWorkingTimeCondition";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "กำหนดเงื่อนไขเวลาทำงาน";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmWorkingTimeCondition_Load);
			((System.ComponentModel.ISupportInitialize)(this.fpsWorkingTimeCondition)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsWorkingTimeCondition_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion			

	    #region - Private -
		private bool isReadonly = true;
		private frmWorkingTimeConditionEntry frmEntry;
		private frmMain mdiParent;
		#endregion
		
//		============================== Property ==============================
		private WorkingTimeConditionFacade facadeWorkingTimeCondition;	
		public WorkingTimeConditionFacade FacadeWorkingTimeCondition
		{
			get{return facadeWorkingTimeCondition;}
		}

		private int SelectedRow
		{
			get{return fpsWorkingTimeCondition_Sheet1.ActiveRowIndex;}
		}

		private string SelectedKey
		{
			get{return fpsWorkingTimeCondition_Sheet1.Cells[SelectedRow,0].Text;}
		}

		private WorkingTimeCondition selectedWorkingTimeCondition
		{
			get{return facadeWorkingTimeCondition.ObjWorkingTimeConditionList[SelectedKey];}
		}

//		============================== Constructor ==============================
		public frmWorkingTimeCondition() : base()
		{		
			InitializeComponent();			
			newObject();
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miWorkingTimeCondition");
            this.title = UserProfile.GetFormName("miAttendance", "miWorkingTimeCondition");
		}
        public override string FormID()
        {
            return UserProfile.GetFormID("miAttendance", "miWorkingTimeCondition");
        }

//		==============================Private method ==============================
		private void newObject()
		{
			facadeWorkingTimeCondition = new WorkingTimeConditionFacade();
			frmEntry = new frmWorkingTimeConditionEntry(this);
		}

		private void bindForm()
		{	
			if (facadeWorkingTimeCondition.ObjWorkingTimeConditionList != null)
			{
				int iRow = facadeWorkingTimeCondition.ObjWorkingTimeConditionList.Count;
				fpsWorkingTimeCondition_Sheet1.RowCount = iRow;
				for(int i=0; i<iRow; i++)
				{
					bindWorkingTimeCondition(i, facadeWorkingTimeCondition.ObjWorkingTimeConditionList[i]);
				}	
				mdiParent.RefreshMasterCount();
			}
            fpsWorkingTimeCondition_Sheet1.SetActiveCell(fpsWorkingTimeCondition_Sheet1.RowCount, 0);
		}
		
		private void bindWorkingTimeCondition(int row, WorkingTimeCondition value)
		{
			fpsWorkingTimeCondition_Sheet1.Cells[row,0].Text = GUIFunction.GetString(value.EntityKey);
			fpsWorkingTimeCondition_Sheet1.Cells[row,1].Text = GUIFunction.GetString(value.APositionType.ADescription.Thai);
            if (value.AServiceStaffType.Type.Equals("ZZZ") && value.ACustomerDepartment.Code.Equals("ZZZ") && value.ACustomerDepartment.ACustomer.Code.Equals(Entity.ContractEntities.Customer.DUMMYCODE))
			{
				fpsWorkingTimeCondition_Sheet1.Cells[row,2].Text = "< ZZZ >";				
			}
			else
			{
				fpsWorkingTimeCondition_Sheet1.Cells[row,2].Text = GUIFunction.GetString(value.AServiceStaffType.ADescription.English);				
			}
			fpsWorkingTimeCondition_Sheet1.Cells[row,3].Text = GUIFunction.GetString(value.ACustomerDepartment.ACustomer.AName.English);
			fpsWorkingTimeCondition_Sheet1.Cells[row,4].Text = GUIFunction.GetString(value.ACustomerDepartment.ShortName);
			fpsWorkingTimeCondition_Sheet1.Cells[row,5].Text = GUIFunction.GetString(value.AWorkingTimeTable.TableID);
			fpsWorkingTimeCondition_Sheet1.Cells[row,6].Text = GUIFunction.GetString(value.AWorkingTimeTable.Description);
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
			fpsWorkingTimeCondition_Sheet1.RowCount = 0;
			enableButton(false);
		}

		private bool validateForm(WorkingTimeCondition value)
		{
			if(value.APositionType.Type == "S" && value.AServiceStaffType.Type == "ZZZ")
			{
				Message(MessageList.Error.E0014, "ลบรายการนี้ได้" );
				return false;
			}
			if(value.APositionType.Type == "O")
			{
				Message(MessageList.Error.E0014, "ลบรายการนี้ได้" );
				return false;			 
			}
			return true;
		}
	   
//      ============================== Public Method  ============================
		public bool AddRow(WorkingTimeCondition value)
		{
			if (facadeWorkingTimeCondition.InsertWorkingTimeCondition(value))
			{
				fpsWorkingTimeCondition_Sheet1.RowCount++;
				bindWorkingTimeCondition(fpsWorkingTimeCondition_Sheet1.RowCount-1, value);
                fpsWorkingTimeCondition_Sheet1.SetActiveCell(fpsWorkingTimeCondition_Sheet1.RowCount, 0);
				enableButton(true);
				mdiParent.RefreshMasterCount();
				return true;
			}
			return false;
		}

		public bool UpdateRow(WorkingTimeCondition value)
		{
			if (facadeWorkingTimeCondition.UpdateWorkingTimeCondition(value))
			{
				bindWorkingTimeCondition(SelectedRow, value);				
				return true;
			}			
			return false;
		}

		private void DeleteRow()
		{
			if (facadeWorkingTimeCondition.DeleteWorkingTimeCondition(selectedWorkingTimeCondition))
			{
				if(fpsWorkingTimeCondition_Sheet1.RowCount > 1)
				{
					fpsWorkingTimeCondition.ActiveSheet.Rows.Remove(SelectedRow,1);
				}
				else
				{clearForm();}		
				mdiParent.RefreshMasterCount();
			}
		}

		public override int MasterCount()
		{
			return facadeWorkingTimeCondition.ObjWorkingTimeConditionList.Count;
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
				if (facadeWorkingTimeCondition.DisplayWorkingTimeCondition())
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
				frmEntry = new frmWorkingTimeConditionEntry(this);
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
				frmEntry = new frmWorkingTimeConditionEntry(this);
				frmEntry.InitEditAction(selectedWorkingTimeCondition);
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
					if(validateForm(selectedWorkingTimeCondition))
					{
						DeleteRow();
					}
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
		private void frmWorkingTimeCondition_Load(object sender, System.EventArgs e)
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

		private void fpsWorkingTimeCondition_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader)
			{
				editEvent();
			}
		}
	}
}
