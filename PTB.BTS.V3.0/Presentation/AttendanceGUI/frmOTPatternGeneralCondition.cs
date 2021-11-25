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
	public class frmOTPatternGeneralCondition : ChildFormBase, IMDIChildForm
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
		private System.Windows.Forms.MenuItem mniEdit;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem mniDelete;
		private System.Windows.Forms.Button cmdDelete;
		private System.Windows.Forms.Button cmdEdit;
		private System.Windows.Forms.Button cmdAdd;
		private FarPoint.Win.Spread.SheetView fpOTGeneralCondition_Sheet1;
		private FarPoint.Win.Spread.FpSpread fpOTGeneralCondition;

		private System.ComponentModel.Container components = null;
		private void InitializeComponent()
		{
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType7 = new FarPoint.Win.Spread.CellType.TextCellType();
			this.mniAdd = new System.Windows.Forms.MenuItem();
			this.mniEdit = new System.Windows.Forms.MenuItem();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			this.fpOTGeneralCondition_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.fpOTGeneralCondition = new FarPoint.Win.Spread.FpSpread();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdAdd = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.fpOTGeneralCondition_Sheet1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpOTGeneralCondition)).BeginInit();
			this.SuspendLayout();
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
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.mniAdd,
																						 this.mniEdit,
																						 this.mniDelete});
			this.contextMenu1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			// 
			// mniDelete
			// 
			this.mniDelete.Index = 2;
			this.mniDelete.Text = "&ลบ                ";
			this.mniDelete.Click += new System.EventHandler(this.mniDelete_Click);
			// 
			// fpOTGeneralCondition_Sheet1
			// 
			this.fpOTGeneralCondition_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpOTGeneralCondition_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpOTGeneralCondition_Sheet1.ColumnCount = 7;
			this.fpOTGeneralCondition_Sheet1.RowCount = 1;
			this.fpOTGeneralCondition_Sheet1.ColumnHeader.Cells.Get(0, 1).RowSpan = 2;
			this.fpOTGeneralCondition_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "รูปแบบที่";
			this.fpOTGeneralCondition_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "รายละเอียด";
			this.fpOTGeneralCondition_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ประเภทตำแหน่ง";
			this.fpOTGeneralCondition_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "ประเภทพนักงานบริการ";
			this.fpOTGeneralCondition_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "ลูกค้า";
			this.fpOTGeneralCondition_Sheet1.ColumnHeader.Cells.Get(0, 6).Text = "แผนกลูกค้า";
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpOTGeneralCondition_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpOTGeneralCondition_Sheet1.Columns.Get(0).Visible = false;
			this.fpOTGeneralCondition_Sheet1.Columns.Get(0).Width = 79F;
			this.fpOTGeneralCondition_Sheet1.Columns.Get(1).AllowAutoSort = true;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			textCellType2.DropDownButton = false;
			textCellType2.ReadOnly = true;
			this.fpOTGeneralCondition_Sheet1.Columns.Get(1).CellType = textCellType2;
			this.fpOTGeneralCondition_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpOTGeneralCondition_Sheet1.Columns.Get(1).Label = "รูปแบบที่";
			this.fpOTGeneralCondition_Sheet1.Columns.Get(1).Width = 56F;
			this.fpOTGeneralCondition_Sheet1.Columns.Get(2).AllowAutoSort = true;
			textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType3.DropDownButton = false;
			textCellType3.ReadOnly = true;
			this.fpOTGeneralCondition_Sheet1.Columns.Get(2).CellType = textCellType3;
			this.fpOTGeneralCondition_Sheet1.Columns.Get(2).Label = "รายละเอียด";
			this.fpOTGeneralCondition_Sheet1.Columns.Get(2).Width = 200F;
			this.fpOTGeneralCondition_Sheet1.Columns.Get(3).AllowAutoSort = true;
			textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType4.DropDownButton = false;
			textCellType4.ReadOnly = true;
			this.fpOTGeneralCondition_Sheet1.Columns.Get(3).CellType = textCellType4;
			this.fpOTGeneralCondition_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpOTGeneralCondition_Sheet1.Columns.Get(3).Label = "ประเภทตำแหน่ง";
			this.fpOTGeneralCondition_Sheet1.Columns.Get(3).Width = 92F;
			this.fpOTGeneralCondition_Sheet1.Columns.Get(4).AllowAutoSort = true;
			textCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType5.DropDownButton = false;
			textCellType5.ReadOnly = true;
			this.fpOTGeneralCondition_Sheet1.Columns.Get(4).CellType = textCellType5;
			this.fpOTGeneralCondition_Sheet1.Columns.Get(4).Label = "ประเภทพนักงานบริการ";
			this.fpOTGeneralCondition_Sheet1.Columns.Get(4).Width = 269F;
			this.fpOTGeneralCondition_Sheet1.Columns.Get(5).AllowAutoSort = true;
			textCellType6.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType6.DropDownButton = false;
			textCellType6.ReadOnly = true;
			this.fpOTGeneralCondition_Sheet1.Columns.Get(5).CellType = textCellType6;
			this.fpOTGeneralCondition_Sheet1.Columns.Get(5).Label = "ลูกค้า";
			this.fpOTGeneralCondition_Sheet1.Columns.Get(5).Width = 260F;
			this.fpOTGeneralCondition_Sheet1.Columns.Get(6).AllowAutoSort = true;
			textCellType7.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType7.DropDownButton = false;
			textCellType7.ReadOnly = true;
			this.fpOTGeneralCondition_Sheet1.Columns.Get(6).CellType = textCellType7;
			this.fpOTGeneralCondition_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpOTGeneralCondition_Sheet1.Columns.Get(6).Label = "แผนกลูกค้า";
			this.fpOTGeneralCondition_Sheet1.Columns.Get(6).Width = 68F;
			this.fpOTGeneralCondition_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
			this.fpOTGeneralCondition_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpOTGeneralCondition_Sheet1.RowHeader.Rows.Default.Resizable = false;
			this.fpOTGeneralCondition_Sheet1.Rows.Default.Resizable = false;
			this.fpOTGeneralCondition_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpOTGeneralCondition_Sheet1.SheetName = "Sheet1";
			this.fpOTGeneralCondition_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// fpOTGeneralCondition
			// 
			this.fpOTGeneralCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpOTGeneralCondition.ContextMenu = this.contextMenu1;
			this.fpOTGeneralCondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.fpOTGeneralCondition.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpOTGeneralCondition.Location = new System.Drawing.Point(13, 16);
			this.fpOTGeneralCondition.Name = "fpOTGeneralCondition";
			this.fpOTGeneralCondition.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																							  this.fpOTGeneralCondition_Sheet1});
			this.fpOTGeneralCondition.Size = new System.Drawing.Size(1002, 392);
			this.fpOTGeneralCondition.TabIndex = 9;
			this.fpOTGeneralCondition.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpOTGeneralCondition_CellDoubleClick);
			// 
			// cmdDelete
			// 
			this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdDelete.Location = new System.Drawing.Point(576, 431);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.TabIndex = 8;
			this.cmdDelete.Text = "ลบ";
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			// 
			// cmdEdit
			// 
			this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdEdit.Location = new System.Drawing.Point(488, 431);
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.TabIndex = 7;
			this.cmdEdit.Text = "แก้ไข";
			this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
			// 
			// cmdAdd
			// 
			this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdAdd.Location = new System.Drawing.Point(400, 431);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.TabIndex = 6;
			this.cmdAdd.Text = "เพิ่ม";
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			// 
			// frmOTPatternGeneralCondition
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1028, 477);
			this.Controls.Add(this.cmdEdit);
			this.Controls.Add(this.cmdAdd);
			this.Controls.Add(this.fpOTGeneralCondition);
			this.Controls.Add(this.cmdDelete);
			this.Name = "frmOTPatternGeneralCondition";
            //this.Text = "กำหนดเงื่อนไขรูปแบบค่าล่วงเวลา";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmOTPatternGeneralCondition_Load);
			((System.ComponentModel.ISupportInitialize)(this.fpOTGeneralCondition_Sheet1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpOTGeneralCondition)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private frmOTPatternGeneralConditionEntry frmEntry;
		private frmMain mdiParent;
		#endregion

//		============================== Property ==============================		
		private OTPatternGeneralConditionFacade facadeOTPatternGeneralCondition;
		public OTPatternGeneralConditionFacade FacadeOTPatternGeneralCondition
		{
			get{return facadeOTPatternGeneralCondition;}
		}

		private int SelectedRow
		{
			get{return fpOTGeneralCondition_Sheet1.ActiveRowIndex;}
		}

		private string SelectedKey
		{
			get{return fpOTGeneralCondition_Sheet1.Cells[SelectedRow,0].Text;}
		}

		private OTPatternGeneralCondition SelectedOTPatternGeneralCondition
		{
			get{return (OTPatternGeneralCondition)facadeOTPatternGeneralCondition.ObjOTPatternConditionList[SelectedKey];}
		}

//		============================== Constructor ==============================
		public frmOTPatternGeneralCondition() : base()
		{
			InitializeComponent();
			newObject();
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miOTPatternGeneralCondition");
            this.title = UserProfile.GetFormName("miAttendance", "miOTPatternGeneralCondition");

		}
        public override string FormID()
        {
            return UserProfile.GetFormID("miAttendance", "miOTPatternGeneralCondition");
        }
//		==============================Private method ==============================
		private void newObject()
		{
			facadeOTPatternGeneralCondition = new OTPatternGeneralConditionFacade();
			frmEntry = new frmOTPatternGeneralConditionEntry(this);
		}

		private void bindOTPatternGeneralCondition(int row, OTPatternGeneralCondition value)
		{
			fpOTGeneralCondition_Sheet1.Cells[row,0].Text = value.EntityKey;
			fpOTGeneralCondition_Sheet1.Cells[row,1].Text = GUIFunction.GetString(value.AOTPattern.PatternId);
			fpOTGeneralCondition_Sheet1.Cells[row,2].Text = GUIFunction.GetString(value.AOTPattern.PatternName);
			fpOTGeneralCondition_Sheet1.Cells[row,3].Text = GUIFunction.GetString(value.APositionType.ADescription.Thai);
			fpOTGeneralCondition_Sheet1.Cells[row,4].Text = GUIFunction.GetString(value.AServiceStaffType.ADescription.English);
			fpOTGeneralCondition_Sheet1.Cells[row,5].Text = GUIFunction.GetString(value.ACustomerDepartment.ACustomer.AName.English);
			fpOTGeneralCondition_Sheet1.Cells[row,6].Text = GUIFunction.GetString(value.ACustomerDepartment.ShortName);
		}

		private void bindForm()
		{
			if (facadeOTPatternGeneralCondition.ObjOTPatternConditionList != null)
			{
				int iRow = facadeOTPatternGeneralCondition.ObjOTPatternConditionList.Count;
				fpOTGeneralCondition_Sheet1.RowCount = iRow;
				for(int i=0; i<iRow; i++)
				{
					bindOTPatternGeneralCondition(i, (OTPatternGeneralCondition)facadeOTPatternGeneralCondition.ObjOTPatternConditionList[i]);
				}		
				mdiParent.RefreshMasterCount();
			}
            fpOTGeneralCondition_Sheet1.SetActiveCell(fpOTGeneralCondition_Sheet1.RowCount, 0);
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
			fpOTGeneralCondition_Sheet1.RowCount = 0;
			enableButton(false);
		}		

//		============================== Public method ==============================
		public bool AddRow(OTPatternGeneralCondition value)
		{
			if (facadeOTPatternGeneralCondition.InsertOTPatternGeneralCondition(value))
			{
				fpOTGeneralCondition_Sheet1.RowCount++;
				bindOTPatternGeneralCondition(fpOTGeneralCondition_Sheet1.RowCount-1, value);
                fpOTGeneralCondition_Sheet1.SetActiveCell(fpOTGeneralCondition_Sheet1.RowCount, 0);
				enableButton(true);
				return true;
			}
			else
			{				
				return false;
			}
		}

		public bool UpdateRow(OTPatternGeneralCondition value)
		{
			if (facadeOTPatternGeneralCondition.UpdateOTPatternGeneralCondition(value))
			{
				bindOTPatternGeneralCondition(SelectedRow, value);				
				return true;
			}
			else
			{				
				return false;
			}
		}

		public void DeleteRow()
		{
			if (facadeOTPatternGeneralCondition.DeleteOTPatternGeneralCondition(SelectedOTPatternGeneralCondition))
			{
				if(fpOTGeneralCondition_Sheet1.RowCount > 1)
				{
					fpOTGeneralCondition.ActiveSheet.Rows.Remove(SelectedRow, 1);
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
			return facadeOTPatternGeneralCondition.ObjOTPatternConditionList.Count;
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
				if (facadeOTPatternGeneralCondition.DisplayOTPatternGeneralCondition())
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
				frmEntry = new frmOTPatternGeneralConditionEntry(this);
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
				frmEntry = new frmOTPatternGeneralConditionEntry(this);
				frmEntry.InitEditAction(SelectedOTPatternGeneralCondition);
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
		private void frmOTPatternGeneralCondition_Load(object sender, System.EventArgs e)
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
		
		private void fpOTGeneralCondition_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader)
			{
				editEvent();
			}
		}
	}
}
