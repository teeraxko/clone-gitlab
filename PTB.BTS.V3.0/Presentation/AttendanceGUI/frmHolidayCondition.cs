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
	public class frmHolidayCondition : ChildFormBase, IMDIChildForm
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
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem mniAdd;
		private System.Windows.Forms.MenuItem mniEdit;
		private System.Windows.Forms.MenuItem mniDelete;
		private System.Windows.Forms.Button cmdAdd;
		private System.Windows.Forms.Button cmdEdit;
		private System.Windows.Forms.Button cmdDelete;
		private FarPoint.Win.Spread.FpSpread fpsHolidayCondition;
		private FarPoint.Win.Spread.SheetView fpsHolidayCondition_Sheet1;
				
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmHolidayCondition));
			FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType2 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
			this.fpsHolidayCondition = new FarPoint.Win.Spread.FpSpread();
			this.fpsHolidayCondition_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mniAdd = new System.Windows.Forms.MenuItem();
			this.mniEdit = new System.Windows.Forms.MenuItem();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdDelete = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.fpsHolidayCondition)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsHolidayCondition_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// fpsHolidayCondition
			// 
			this.fpsHolidayCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsHolidayCondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.fpsHolidayCondition.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsHolidayCondition.Location = new System.Drawing.Point(4, 24);
			this.fpsHolidayCondition.Name = "fpsHolidayCondition";
			this.fpsHolidayCondition.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																							 this.fpsHolidayCondition_Sheet1});
			this.fpsHolidayCondition.Size = new System.Drawing.Size(1022, 344);
			this.fpsHolidayCondition.TabIndex = 0;
			this.fpsHolidayCondition.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsHolidayCondition_CellDoubleClick);
			// 
			// fpsHolidayCondition_Sheet1
			// 
			this.fpsHolidayCondition_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsHolidayCondition_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsHolidayCondition_Sheet1.ColumnCount = 8;
			this.fpsHolidayCondition_Sheet1.ColumnHeader.RowCount = 2;
			this.fpsHolidayCondition_Sheet1.RowCount = 1;
			this.fpsHolidayCondition_Sheet1.ColumnHeader.Cells.Get(0, 0).RowSpan = 2;
			this.fpsHolidayCondition_Sheet1.ColumnHeader.Cells.Get(0, 1).RowSpan = 2;
			this.fpsHolidayCondition_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "ประเภทตำแหน่ง";
			this.fpsHolidayCondition_Sheet1.ColumnHeader.Cells.Get(0, 2).RowSpan = 2;
			this.fpsHolidayCondition_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "ประเภทพนักงาน";
			this.fpsHolidayCondition_Sheet1.ColumnHeader.Cells.Get(0, 3).RowSpan = 2;
			this.fpsHolidayCondition_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ลูกค้า";
			this.fpsHolidayCondition_Sheet1.ColumnHeader.Cells.Get(0, 4).RowSpan = 2;
			this.fpsHolidayCondition_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "แผนก";
			this.fpsHolidayCondition_Sheet1.ColumnHeader.Cells.Get(0, 5).ColumnSpan = 3;
			this.fpsHolidayCondition_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "กำหนดวันหยุด";
			this.fpsHolidayCondition_Sheet1.ColumnHeader.Cells.Get(0, 7).Text = "วันหยุดนักขัตฤกษ์แบบที่";
			this.fpsHolidayCondition_Sheet1.ColumnHeader.Cells.Get(1, 5).Text = "วันเสาร์";
			this.fpsHolidayCondition_Sheet1.ColumnHeader.Cells.Get(1, 6).Text = "วันอาทิตย์";
			this.fpsHolidayCondition_Sheet1.ColumnHeader.Cells.Get(1, 7).Text = "วันหยุดนักขัตฤกษ์";
			this.fpsHolidayCondition_Sheet1.ColumnHeader.Rows.Get(0).Height = 22F;
			this.fpsHolidayCondition_Sheet1.ColumnHeader.Rows.Get(1).Height = 22F;
			this.fpsHolidayCondition_Sheet1.Columns.Get(0).Visible = false;
			this.fpsHolidayCondition_Sheet1.Columns.Get(0).Width = 25F;
			this.fpsHolidayCondition_Sheet1.Columns.Get(1).AllowAutoSort = true;
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsHolidayCondition_Sheet1.Columns.Get(1).CellType = textCellType1;
			this.fpsHolidayCondition_Sheet1.Columns.Get(1).Locked = false;
			this.fpsHolidayCondition_Sheet1.Columns.Get(1).Resizable = false;
			this.fpsHolidayCondition_Sheet1.Columns.Get(1).Width = 95F;
			this.fpsHolidayCondition_Sheet1.Columns.Get(2).AllowAutoSort = true;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			this.fpsHolidayCondition_Sheet1.Columns.Get(2).CellType = textCellType2;
			this.fpsHolidayCondition_Sheet1.Columns.Get(2).Resizable = false;
			this.fpsHolidayCondition_Sheet1.Columns.Get(2).Width = 220F;
			this.fpsHolidayCondition_Sheet1.Columns.Get(3).AllowAutoSort = true;
			textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType3.DropDownButton = false;
			this.fpsHolidayCondition_Sheet1.Columns.Get(3).CellType = textCellType3;
			this.fpsHolidayCondition_Sheet1.Columns.Get(3).Resizable = false;
			this.fpsHolidayCondition_Sheet1.Columns.Get(3).Width = 310F;
			this.fpsHolidayCondition_Sheet1.Columns.Get(4).AllowAutoSort = true;
			textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType4.DropDownButton = false;
			this.fpsHolidayCondition_Sheet1.Columns.Get(4).CellType = textCellType4;
			this.fpsHolidayCondition_Sheet1.Columns.Get(4).Resizable = false;
			this.fpsHolidayCondition_Sheet1.Columns.Get(5).AllowAutoSort = true;
			this.fpsHolidayCondition_Sheet1.Columns.Get(5).CellType = checkBoxCellType1;
			this.fpsHolidayCondition_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsHolidayCondition_Sheet1.Columns.Get(5).Label = "วันเสาร์";
			this.fpsHolidayCondition_Sheet1.Columns.Get(5).Resizable = false;
			this.fpsHolidayCondition_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
			this.fpsHolidayCondition_Sheet1.Columns.Get(5).Width = 50F;
			this.fpsHolidayCondition_Sheet1.Columns.Get(6).AllowAutoSort = true;
			this.fpsHolidayCondition_Sheet1.Columns.Get(6).CellType = checkBoxCellType2;
			this.fpsHolidayCondition_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsHolidayCondition_Sheet1.Columns.Get(6).Label = "วันอาทิตย์";
			this.fpsHolidayCondition_Sheet1.Columns.Get(6).Resizable = false;
			this.fpsHolidayCondition_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
			this.fpsHolidayCondition_Sheet1.Columns.Get(6).Width = 50F;
			this.fpsHolidayCondition_Sheet1.Columns.Get(7).AllowAutoSort = true;
			textCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType5.DropDownButton = false;
			textCellType5.ReadOnly = true;
			textCellType5.Static = true;
			this.fpsHolidayCondition_Sheet1.Columns.Get(7).CellType = textCellType5;
			this.fpsHolidayCondition_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
			this.fpsHolidayCondition_Sheet1.Columns.Get(7).Label = "วันหยุดนักขัตฤกษ์";
			this.fpsHolidayCondition_Sheet1.Columns.Get(7).Locked = true;
			this.fpsHolidayCondition_Sheet1.Columns.Get(7).Resizable = false;
			this.fpsHolidayCondition_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
			this.fpsHolidayCondition_Sheet1.Columns.Get(7).Width = 190F;
			this.fpsHolidayCondition_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
			this.fpsHolidayCondition_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsHolidayCondition_Sheet1.RowHeader.Columns.Get(0).Width = 25F;
			this.fpsHolidayCondition_Sheet1.RowHeader.Rows.Default.Resizable = false;
			this.fpsHolidayCondition_Sheet1.Rows.Default.Resizable = false;
			this.fpsHolidayCondition_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
			this.fpsHolidayCondition_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsHolidayCondition_Sheet1.SheetName = "Sheet1";
			this.fpsHolidayCondition_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
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
			// cmdAdd
			// 
			this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdAdd.Location = new System.Drawing.Point(399, 384);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.Size = new System.Drawing.Size(72, 24);
			this.cmdAdd.TabIndex = 1;
			this.cmdAdd.Text = "เพิ่ม";
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			// 
			// cmdEdit
			// 
			this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdEdit.Location = new System.Drawing.Point(479, 384);
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.Size = new System.Drawing.Size(72, 24);
			this.cmdEdit.TabIndex = 2;
			this.cmdEdit.Text = "แก้ไข";
			this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
			// 
			// cmdDelete
			// 
			this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdDelete.Location = new System.Drawing.Point(559, 384);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.Size = new System.Drawing.Size(72, 24);
			this.cmdDelete.TabIndex = 3;
			this.cmdDelete.Text = "ลบ";
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			// 
			// frmHolidayCondition
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1030, 424);
			this.ContextMenu = this.contextMenu1;
			this.Controls.Add(this.cmdDelete);
			this.Controls.Add(this.cmdEdit);
			this.Controls.Add(this.cmdAdd);
			this.Controls.Add(this.fpsHolidayCondition);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmHolidayCondition";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmHolidayCondition_Load);
			((System.ComponentModel.ISupportInitialize)(this.fpsHolidayCondition)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsHolidayCondition_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private frmHolidayConditionEntry frmEntry;
		private frmMain mdiParent;
		#endregion

//		============================== Property ==============================		
		private HolidayConditionFacade facadeHolidayCondition;
		public HolidayConditionFacade FacadeHolidayCondition
		{
			get{return facadeHolidayCondition;}
		}

		private int SelectedRow
		{
			get{return fpsHolidayCondition_Sheet1.ActiveRowIndex;}
		}

		private string SelectedKey
		{
			get{return fpsHolidayCondition_Sheet1.Cells[SelectedRow,0].Text;}
		}

		private HolidayCondition SelectedHolidayCondition
		{
			get{return facadeHolidayCondition.ObjHolidayConditionList[SelectedKey];}
		}

//		============================== Constructor ==============================
		public frmHolidayCondition() : base()
		{
			InitializeComponent();
			newObject();
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miHolidayCondition");
            this.title = UserProfile.GetFormName("miAttendance", "miHolidayCondition");
		}
        public override string FormID()
        {
            return UserProfile.GetFormID("miAttendance", "miHolidayCondition");
        }
//		==============================Private method ==============================
		private void newObject()
		{
			facadeHolidayCondition = new HolidayConditionFacade();
			frmEntry = new frmHolidayConditionEntry(this);
		}

		private void bindHolidayCondition(int row, HolidayCondition value)
		{
			fpsHolidayCondition_Sheet1.Cells[row,0].Text = value.EntityKey;
			fpsHolidayCondition_Sheet1.Cells[row,1].Text = GUIFunction.GetString(value.APositionType.ADescription.Thai);
			fpsHolidayCondition_Sheet1.Cells[row,2].Text = GUIFunction.GetString(value.AServiceStaffType.ADescription.English);
			fpsHolidayCondition_Sheet1.Cells[row,3].Text = GUIFunction.GetString(value.ACustomerDepartment.ACustomer.AName.English);
			fpsHolidayCondition_Sheet1.Cells[row,4].Text = GUIFunction.GetString(value.ACustomerDepartment.ShortName);

			if(value.SaturdayBreak)
			{
				fpsHolidayCondition_Sheet1.Cells[row,5].Text = "True";
			}
			else
			{
				fpsHolidayCondition_Sheet1.Cells[row,5].Text = "False";
			}

			if(value.SundayBreak)
			{
				fpsHolidayCondition_Sheet1.Cells[row,6].Text= "True";
			}
			else
			{
				fpsHolidayCondition_Sheet1.Cells[row,6].Text = "False";
			}

			if(value.ATraditionalHolidayPattern != null)
			{
				fpsHolidayCondition_Sheet1.Cells[row,7].Text = GUIFunction.GetString(value.ATraditionalHolidayPattern.AName.Thai);
			}
		}

		private void bindForm()
		{
			HolidayCondition holidayCondition;
			fpsHolidayCondition_Sheet1.RowCount = 0;

			if (facadeHolidayCondition.ObjHolidayConditionList != null)
			{
				for(int i=0; i<facadeHolidayCondition.ObjHolidayConditionList.Count; i++)
				{
					holidayCondition = new HolidayCondition();
					holidayCondition = facadeHolidayCondition.ObjHolidayConditionList[i];
					if(holidayCondition.AServiceStaffType.Type != "" && holidayCondition.ACustomerDepartment.Code != "" && holidayCondition.ACustomerDepartment.ACustomer.Code != "")
					{
						fpsHolidayCondition_Sheet1.RowCount++;
						bindHolidayCondition(fpsHolidayCondition_Sheet1.RowCount-1, holidayCondition);
					}
				}	
				mdiParent.RefreshMasterCount();
			}
            fpsHolidayCondition_Sheet1.SetActiveCell(fpsHolidayCondition_Sheet1.RowCount, 0);
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
			fpsHolidayCondition_Sheet1.RowCount = 0;
			enableButton(false);
		}	
	
		private bool validateForm(HolidayCondition value)
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

//		============================== Public method ==============================
		public bool AddRow(HolidayCondition value)
		{
			if (facadeHolidayCondition.InsertHolidayCondition(value))
			{
				fpsHolidayCondition_Sheet1.RowCount++;
				bindHolidayCondition(fpsHolidayCondition_Sheet1.RowCount-1, value);
                fpsHolidayCondition_Sheet1.SetActiveCell(fpsHolidayCondition_Sheet1.RowCount, 0);
				enableButton(true);
				mdiParent.RefreshMasterCount();
				return true;
			}
			else
			{				
				return false;
			}
		}

		public bool UpdateRow(HolidayCondition value)
		{
			if (facadeHolidayCondition.UpdateHolidayCondition(value))
			{
				bindHolidayCondition(SelectedRow, value);				
				return true;
			}
			else
			{				
				return false;
			}
		}

		public void DeleteRow()
		{
			if (facadeHolidayCondition.DeleteHolidayCondition(SelectedHolidayCondition))
			{
				if(fpsHolidayCondition_Sheet1.RowCount > 1)
				{
					fpsHolidayCondition.ActiveSheet.Rows.Remove(SelectedRow, 1);
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
            return facadeHolidayCondition.ObjHolidayConditionList.Count;
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
				if (facadeHolidayCondition.DisplayHolidayCondition())
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
				frmEntry = new frmHolidayConditionEntry(this);
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
				frmEntry = new frmHolidayConditionEntry(this);
				frmEntry.InitEditAction(SelectedHolidayCondition);
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
					if(validateForm(SelectedHolidayCondition))
					{
						DeleteRow();
					}
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
		private void frmHolidayCondition_Load(object sender, System.EventArgs e)
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
		
		private void fpsHolidayCondition_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader)
			{
				editEvent();
			}
		}
    }
}
