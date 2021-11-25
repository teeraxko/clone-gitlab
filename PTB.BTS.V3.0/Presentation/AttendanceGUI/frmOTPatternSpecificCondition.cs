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
	public class frmOTPatternSpecificCondition : ChildFormBase, IMDIChildForm
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

		private FarPoint.Win.Spread.FpSpread fpsOTSpecificCondition;
		private FarPoint.Win.Spread.SheetView fpsOTSpecificCondition_Sheet1;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem mniAdd;
		private System.Windows.Forms.MenuItem mniEdit;
		private System.Windows.Forms.MenuItem mniDelete;
		private System.Windows.Forms.Button cmdEdit;
		private System.Windows.Forms.Button cmdAdd;
		private System.Windows.Forms.Button cmdDelete;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
			this.fpsOTSpecificCondition = new FarPoint.Win.Spread.FpSpread();
			this.fpsOTSpecificCondition_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mniAdd = new System.Windows.Forms.MenuItem();
			this.mniEdit = new System.Windows.Forms.MenuItem();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.cmdDelete = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.fpsOTSpecificCondition)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsOTSpecificCondition_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// fpsOTSpecificCondition
			// 
			this.fpsOTSpecificCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsOTSpecificCondition.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsOTSpecificCondition.Location = new System.Drawing.Point(17, 16);
			this.fpsOTSpecificCondition.Name = "fpsOTSpecificCondition";
			this.fpsOTSpecificCondition.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																								this.fpsOTSpecificCondition_Sheet1});
			this.fpsOTSpecificCondition.Size = new System.Drawing.Size(775, 408);
			this.fpsOTSpecificCondition.TabIndex = 5;
			this.fpsOTSpecificCondition.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsOTSpecificCondition_CellDoubleClick);
			// 
			// fpsOTSpecificCondition_Sheet1
			// 
			this.fpsOTSpecificCondition_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsOTSpecificCondition_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsOTSpecificCondition_Sheet1.ColumnCount = 5;
			this.fpsOTSpecificCondition_Sheet1.RowCount = 1;
			this.fpsOTSpecificCondition_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "รูปแบบที่";
			this.fpsOTSpecificCondition_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "รายละเอียด";
			this.fpsOTSpecificCondition_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "รหัส";
			this.fpsOTSpecificCondition_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "ชื่อ";
			this.fpsOTSpecificCondition_Sheet1.ColumnHeader.Rows.Get(0).Height = 23F;
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsOTSpecificCondition_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsOTSpecificCondition_Sheet1.Columns.Get(0).Visible = false;
			this.fpsOTSpecificCondition_Sheet1.Columns.Get(1).AllowAutoSort = true;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			this.fpsOTSpecificCondition_Sheet1.Columns.Get(1).CellType = textCellType2;
			this.fpsOTSpecificCondition_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsOTSpecificCondition_Sheet1.Columns.Get(1).Label = "รูปแบบที่";
			this.fpsOTSpecificCondition_Sheet1.Columns.Get(1).Resizable = false;
			this.fpsOTSpecificCondition_Sheet1.Columns.Get(1).Width = 78F;
			this.fpsOTSpecificCondition_Sheet1.Columns.Get(2).AllowAutoSort = true;
			textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType3.DropDownButton = false;
			this.fpsOTSpecificCondition_Sheet1.Columns.Get(2).CellType = textCellType3;
			this.fpsOTSpecificCondition_Sheet1.Columns.Get(2).Label = "รายละเอียด";
			this.fpsOTSpecificCondition_Sheet1.Columns.Get(2).Resizable = false;
			this.fpsOTSpecificCondition_Sheet1.Columns.Get(2).Width = 280F;
			this.fpsOTSpecificCondition_Sheet1.Columns.Get(3).AllowAutoSort = true;
			textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType4.DropDownButton = false;
			this.fpsOTSpecificCondition_Sheet1.Columns.Get(3).CellType = textCellType4;
			this.fpsOTSpecificCondition_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsOTSpecificCondition_Sheet1.Columns.Get(3).Label = "รหัส";
			this.fpsOTSpecificCondition_Sheet1.Columns.Get(3).Resizable = false;
			this.fpsOTSpecificCondition_Sheet1.Columns.Get(3).Width = 90F;
			this.fpsOTSpecificCondition_Sheet1.Columns.Get(4).AllowAutoSort = true;
			textCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType5.DropDownButton = false;
			this.fpsOTSpecificCondition_Sheet1.Columns.Get(4).CellType = textCellType5;
			this.fpsOTSpecificCondition_Sheet1.Columns.Get(4).Label = "ชื่อ";
			this.fpsOTSpecificCondition_Sheet1.Columns.Get(4).Resizable = false;
			this.fpsOTSpecificCondition_Sheet1.Columns.Get(4).Width = 270F;
			this.fpsOTSpecificCondition_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
			this.fpsOTSpecificCondition_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsOTSpecificCondition_Sheet1.RowHeader.Rows.Default.Resizable = false;
			this.fpsOTSpecificCondition_Sheet1.Rows.Default.Resizable = false;
			this.fpsOTSpecificCondition_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
			this.fpsOTSpecificCondition_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsOTSpecificCondition_Sheet1.SheetName = "Sheet1";
			this.fpsOTSpecificCondition_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.mniAdd,
																						 this.mniEdit,
																						 this.mniDelete});
			this.contextMenu1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			// 
			// mniAdd
			// 
			this.mniAdd.Index = 0;
			this.mniAdd.Text = "&เพิ่ม";
			this.mniAdd.Click += new System.EventHandler(this.mniAdd_Click);
			// 
			// mniEdit
			// 
			this.mniEdit.Index = 1;
			this.mniEdit.Text = "&แก้ไข";
			this.mniEdit.Click += new System.EventHandler(this.mniEdit_Click);
			// 
			// mniDelete
			// 
			this.mniDelete.Index = 2;
			this.mniDelete.Text = "&ลบ                ";
			this.mniDelete.Click += new System.EventHandler(this.mniDelete_Click);
			// 
			// cmdEdit
			// 
			this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdEdit.Location = new System.Drawing.Point(367, 448);
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.TabIndex = 10;
			this.cmdEdit.Text = "แก้ไข";
			this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
			// 
			// cmdAdd
			// 
			this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdAdd.Location = new System.Drawing.Point(279, 448);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.TabIndex = 9;
			this.cmdAdd.Text = "เพิ่ม";
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			// 
			// cmdDelete
			// 
			this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdDelete.Location = new System.Drawing.Point(455, 448);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.TabIndex = 11;
			this.cmdDelete.Text = "ลบ";
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			// 
			// frmOTPatternSpecificCondition
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(808, 493);
			this.ContextMenu = this.contextMenu1;
			this.Controls.Add(this.cmdEdit);
			this.Controls.Add(this.cmdAdd);
			this.Controls.Add(this.cmdDelete);
			this.Controls.Add(this.fpsOTSpecificCondition);
			this.Name = "frmOTPatternSpecificCondition";
            //this.Text = "กำหนดเงื่อนไขรูปแบบค่าล่วงเวลาตามพนักงาน";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmOTPatternSpecificCondition_Load);
			((System.ComponentModel.ISupportInitialize)(this.fpsOTSpecificCondition)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsOTSpecificCondition_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private frmOTPatternSpecificConditionEntry frmEntry;
		private frmMain mdiParent;
		#endregion

//		============================== Property ==============================		
		private OTPatternSpecificConditionFacade facadeOTPatternSpecificCondition;
		public OTPatternSpecificConditionFacade FacadeOTPatternSpecificCondition
		{
			get{return facadeOTPatternSpecificCondition;}
		}

		private int SelectedRow
		{
			get{return fpsOTSpecificCondition_Sheet1.ActiveRowIndex;}
		}

		private string SelectedKey
		{
			get{return fpsOTSpecificCondition_Sheet1.Cells[SelectedRow,0].Text;}
		}

		private OTPatternSpecificCondition SelectedOTPatternSpecificCondition
		{
			get{return (OTPatternSpecificCondition)facadeOTPatternSpecificCondition.ObjOTPatternConditionList[SelectedKey];}
		}

//		============================== Constructor ==============================
		public frmOTPatternSpecificCondition() : base()
		{
			InitializeComponent();
			newObject();
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miOTPatternSpecificCondition");
            this.title = UserProfile.GetFormName("miAttendance", "miOTPatternSpecificCondition");

		}
        public override string FormID()
        {
            return UserProfile.GetFormID("miAttendance", "miOTPatternSpecificCondition");
        }
		
//		==============================Private method ==============================
		private void newObject()
		{
			facadeOTPatternSpecificCondition = new OTPatternSpecificConditionFacade();
			frmEntry = new frmOTPatternSpecificConditionEntry(this);
		}

		private void bindOTPatternSpecificCondition(int row, OTPatternSpecificCondition value)
		{
			fpsOTSpecificCondition_Sheet1.Cells[row,0].Text = value.EntityKey;
			fpsOTSpecificCondition_Sheet1.Cells[row,1].Text = GUIFunction.GetString(value.AOTPattern.PatternId);
			fpsOTSpecificCondition_Sheet1.Cells[row,2].Text = GUIFunction.GetString(value.AOTPattern.PatternName);
			fpsOTSpecificCondition_Sheet1.Cells[row,3].Text = GUIFunction.GetString(value.AEmployee.EmployeeNo);
			fpsOTSpecificCondition_Sheet1.Cells[row,4].Text = GUIFunction.GetString(value.AEmployee.EmployeeName);
		}

		private void bindForm()
		{
			if (facadeOTPatternSpecificCondition.ObjOTPatternConditionList != null)
			{
				int iRow = facadeOTPatternSpecificCondition.ObjOTPatternConditionList.Count;
				fpsOTSpecificCondition_Sheet1.RowCount = iRow;
				for(int i=0; i<iRow; i++)
				{
					bindOTPatternSpecificCondition(i, (OTPatternSpecificCondition)facadeOTPatternSpecificCondition.ObjOTPatternConditionList[i]);
				}			
				mdiParent.RefreshMasterCount();
			}
            fpsOTSpecificCondition_Sheet1.SetActiveCell(fpsOTSpecificCondition_Sheet1.RowCount, 0);
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
			fpsOTSpecificCondition_Sheet1.RowCount = 0;
			enableButton(false);
		}		

//		============================== Public method ==============================
		public bool AddRow(OTPatternSpecificCondition value)
		{
			if (facadeOTPatternSpecificCondition.InsertOTPatternSpecificCondition(value))
			{
				fpsOTSpecificCondition_Sheet1.RowCount++;
				bindOTPatternSpecificCondition(fpsOTSpecificCondition_Sheet1.RowCount-1, value);
                fpsOTSpecificCondition_Sheet1.SetActiveCell(fpsOTSpecificCondition_Sheet1.RowCount, 0);
				enableButton(true);
				mdiParent.RefreshMasterCount();
				return true;
			}
			else
			{				
				return false;
			}
		}

		public bool UpdateRow(OTPatternSpecificCondition value)
		{
			if (facadeOTPatternSpecificCondition.UpdateOTPatternSpecificCondition(value))
			{
				bindOTPatternSpecificCondition(SelectedRow, value);				
				return true;
			}
			else
			{				
				return false;
			}
		}

		public void DeleteRow()
		{
			if (facadeOTPatternSpecificCondition.DeleteOTPatternSpecificCondition(SelectedOTPatternSpecificCondition))
			{
				if(fpsOTSpecificCondition_Sheet1.RowCount > 1)
				{
					fpsOTSpecificCondition.ActiveSheet.Rows.Remove(SelectedRow, 1);
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
			return facadeOTPatternSpecificCondition.ObjOTPatternConditionList.Count;
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
				if (facadeOTPatternSpecificCondition.DisplayOTPatternSpecificCondition())
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
			clearMainMenuStatus();
			Dispose(true);
		}
		
		private void addEvent()
		{
			try
			{
				frmEntry = new frmOTPatternSpecificConditionEntry(this);
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
				frmEntry = new frmOTPatternSpecificConditionEntry(this);
				frmEntry.InitEditAction(SelectedOTPatternSpecificCondition);
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
		private void frmOTPatternSpecificCondition_Load(object sender, System.EventArgs e)
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

		private void fpsOTSpecificCondition_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader)
			{
				editEvent();
			}
		}
	}
}
