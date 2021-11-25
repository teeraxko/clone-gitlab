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
	public class frmOTPattern : ChildFormBase, IMDIChildForm
	{		
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
					frmEntry.Dispose();
					facadeOTPattern.Dispose();

					frmEntry = null;
					facadeOTPattern  =null;
				}
			}
			base.Dispose( disposing );
		}
		
		#region Windows Form Designer generated code
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.Button cmdEdit;
		private System.Windows.Forms.Button cmdDelete;
		private System.Windows.Forms.Button cmdAdd;
		private System.Windows.Forms.MenuItem mniAdd;
		private System.Windows.Forms.MenuItem mniDelete;
		private System.Windows.Forms.MenuItem mniEdit;
		private FarPoint.Win.Spread.FpSpread fpsOTPattern;
		private FarPoint.Win.Spread.SheetView fpsOTPattern_Sheet1;
		private System.ComponentModel.IContainer components = null;
		private void InitializeComponent()
		{
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmOTPattern));
			FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType2 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
			FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType3 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType7 = new FarPoint.Win.Spread.CellType.TextCellType();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mniAdd = new System.Windows.Forms.MenuItem();
			this.mniEdit = new System.Windows.Forms.MenuItem();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.fpsOTPattern = new FarPoint.Win.Spread.FpSpread();
			this.fpsOTPattern_Sheet1 = new FarPoint.Win.Spread.SheetView();
			((System.ComponentModel.ISupportInitialize)(this.fpsOTPattern)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsOTPattern_Sheet1)).BeginInit();
			this.SuspendLayout();
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
			// cmdAdd
			// 
			this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdAdd.Location = new System.Drawing.Point(395, 479);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.TabIndex = 1;
			this.cmdAdd.Text = "เพิ่ม";
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			// 
			// cmdEdit
			// 
			this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdEdit.Location = new System.Drawing.Point(475, 479);
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.TabIndex = 2;
			this.cmdEdit.Text = "แก้ไข";
			this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
			// 
			// cmdDelete
			// 
			this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdDelete.Location = new System.Drawing.Point(555, 479);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.TabIndex = 3;
			this.cmdDelete.Text = "ลบ";
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			// 
			// fpsOTPattern
			// 
			this.fpsOTPattern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsOTPattern.ContextMenu = this.contextMenu1;
			this.fpsOTPattern.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.fpsOTPattern.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsOTPattern.Location = new System.Drawing.Point(12, 16);
			this.fpsOTPattern.Name = "fpsOTPattern";
			this.fpsOTPattern.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																					  this.fpsOTPattern_Sheet1});
			this.fpsOTPattern.Size = new System.Drawing.Size(1001, 447);
			this.fpsOTPattern.TabIndex = 5;
			this.fpsOTPattern.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsOTPattern_CellDoubleClick);
			// 
			// fpsOTPattern_Sheet1
			// 
			this.fpsOTPattern_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsOTPattern_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsOTPattern_Sheet1.ColumnCount = 10;
			this.fpsOTPattern_Sheet1.RowCount = 1;
			this.fpsOTPattern_Sheet1.ColumnHeader.Cells.Get(0, 1).RowSpan = 2;
			this.fpsOTPattern_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "รูปแบบที่";
			this.fpsOTPattern_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "รายละเอียด";
			this.fpsOTPattern_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "วันทำงาน / วันหยุด";
			this.fpsOTPattern_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "ช่วงเวลา";
			this.fpsOTPattern_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "กำหนดชั่วโมงคงที่";
			this.fpsOTPattern_Sheet1.ColumnHeader.Cells.Get(0, 6).Text = "กำหนดชั่วโมงสูงสุด";
			this.fpsOTPattern_Sheet1.ColumnHeader.Cells.Get(0, 7).Text = "กำหนดชั่วโมงต่ำสุด";
			this.fpsOTPattern_Sheet1.ColumnHeader.Cells.Get(0, 8).Text = "นาทีเพิ่มหลังเลิกงาน";
			this.fpsOTPattern_Sheet1.ColumnHeader.Cells.Get(0, 9).Text = "อัตราค่าล่วงเวลา";
			this.fpsOTPattern_Sheet1.ColumnHeader.Rows.Get(0).Height = 40F;
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsOTPattern_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsOTPattern_Sheet1.Columns.Get(0).Visible = false;
			this.fpsOTPattern_Sheet1.Columns.Get(0).Width = 36F;
			this.fpsOTPattern_Sheet1.Columns.Get(1).AllowAutoSort = true;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			textCellType2.DropDownButton = false;
			textCellType2.ReadOnly = true;
			this.fpsOTPattern_Sheet1.Columns.Get(1).CellType = textCellType2;
			this.fpsOTPattern_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsOTPattern_Sheet1.Columns.Get(1).Label = "รูปแบบที่";
			this.fpsOTPattern_Sheet1.Columns.Get(1).Resizable = false;
			this.fpsOTPattern_Sheet1.Columns.Get(2).AllowAutoSort = true;
			textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType3.DropDownButton = false;
			textCellType3.ReadOnly = true;
			this.fpsOTPattern_Sheet1.Columns.Get(2).CellType = textCellType3;
			this.fpsOTPattern_Sheet1.Columns.Get(2).Label = "รายละเอียด";
			this.fpsOTPattern_Sheet1.Columns.Get(2).Resizable = false;
			this.fpsOTPattern_Sheet1.Columns.Get(2).Width = 330F;
			this.fpsOTPattern_Sheet1.Columns.Get(3).AllowAutoSort = true;
			textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType4.DropDownButton = false;
			textCellType4.ReadOnly = true;
			this.fpsOTPattern_Sheet1.Columns.Get(3).CellType = textCellType4;
			this.fpsOTPattern_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsOTPattern_Sheet1.Columns.Get(3).Label = "วันทำงาน / วันหยุด";
			this.fpsOTPattern_Sheet1.Columns.Get(3).Resizable = false;
			this.fpsOTPattern_Sheet1.Columns.Get(3).Width = 107F;
			this.fpsOTPattern_Sheet1.Columns.Get(4).AllowAutoSort = true;
			textCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType5.DropDownButton = false;
			textCellType5.ReadOnly = true;
			this.fpsOTPattern_Sheet1.Columns.Get(4).CellType = textCellType5;
			this.fpsOTPattern_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
			this.fpsOTPattern_Sheet1.Columns.Get(4).Label = "ช่วงเวลา";
			this.fpsOTPattern_Sheet1.Columns.Get(4).Resizable = false;
			this.fpsOTPattern_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
			this.fpsOTPattern_Sheet1.Columns.Get(4).Width = 107F;
			this.fpsOTPattern_Sheet1.Columns.Get(5).AllowAutoSort = true;
			this.fpsOTPattern_Sheet1.Columns.Get(5).CellType = checkBoxCellType1;
			this.fpsOTPattern_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsOTPattern_Sheet1.Columns.Get(5).Label = "กำหนดชั่วโมงคงที่";
			this.fpsOTPattern_Sheet1.Columns.Get(5).Resizable = false;
			this.fpsOTPattern_Sheet1.Columns.Get(5).Width = 68F;
			this.fpsOTPattern_Sheet1.Columns.Get(6).AllowAutoSort = true;
			this.fpsOTPattern_Sheet1.Columns.Get(6).CellType = checkBoxCellType2;
			this.fpsOTPattern_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsOTPattern_Sheet1.Columns.Get(6).Label = "กำหนดชั่วโมงสูงสุด";
			this.fpsOTPattern_Sheet1.Columns.Get(6).Resizable = false;
			this.fpsOTPattern_Sheet1.Columns.Get(6).Width = 68F;
			this.fpsOTPattern_Sheet1.Columns.Get(7).AllowAutoSort = true;
			this.fpsOTPattern_Sheet1.Columns.Get(7).CellType = checkBoxCellType3;
			this.fpsOTPattern_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsOTPattern_Sheet1.Columns.Get(7).Label = "กำหนดชั่วโมงต่ำสุด";
			this.fpsOTPattern_Sheet1.Columns.Get(7).Resizable = false;
			this.fpsOTPattern_Sheet1.Columns.Get(7).Width = 68F;
			this.fpsOTPattern_Sheet1.Columns.Get(8).AllowAutoSort = true;
			textCellType6.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType6.DropDownButton = false;
			textCellType6.ReadOnly = true;
			this.fpsOTPattern_Sheet1.Columns.Get(8).CellType = textCellType6;
			this.fpsOTPattern_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsOTPattern_Sheet1.Columns.Get(8).Label = "นาทีเพิ่มหลังเลิกงาน";
			this.fpsOTPattern_Sheet1.Columns.Get(8).Resizable = false;
			this.fpsOTPattern_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
			this.fpsOTPattern_Sheet1.Columns.Get(8).Width = 68F;
			this.fpsOTPattern_Sheet1.Columns.Get(9).AllowAutoSort = true;
			textCellType7.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType7.DropDownButton = false;
			this.fpsOTPattern_Sheet1.Columns.Get(9).CellType = textCellType7;
			this.fpsOTPattern_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsOTPattern_Sheet1.Columns.Get(9).Label = "อัตราค่าล่วงเวลา";
			this.fpsOTPattern_Sheet1.Columns.Get(9).Resizable = false;
			this.fpsOTPattern_Sheet1.Columns.Get(9).Width = 68F;
			this.fpsOTPattern_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
			this.fpsOTPattern_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsOTPattern_Sheet1.RowHeader.Rows.Default.Resizable = false;
			this.fpsOTPattern_Sheet1.Rows.Default.Resizable = false;
			this.fpsOTPattern_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
			this.fpsOTPattern_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsOTPattern_Sheet1.SheetName = "Sheet1";
			this.fpsOTPattern_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// frmOTPattern
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1024, 525);
			this.Controls.Add(this.fpsOTPattern);
			this.Controls.Add(this.cmdDelete);
			this.Controls.Add(this.cmdEdit);
			this.Controls.Add(this.cmdAdd);
			this.Name = "frmOTPattern";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //this.Text = "กำหนดรูปแบบค่าล่วงเวลา";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmOTPattern_Load);
			((System.ComponentModel.ISupportInitialize)(this.fpsOTPattern)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsOTPattern_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private frmOTPatternEntry frmEntry;
		private frmMain mdiParent;
		#endregion

//		============================== Property ==============================
		private OTPatternFacade facadeOTPattern;
		public OTPatternFacade FacadeOTPattern
		{
			get{return facadeOTPattern;}
		}

		private int SelectedRow
		{
			get{return fpsOTPattern_Sheet1.ActiveRowIndex;}
		}

		private string SelectedKey
		{
			get{return fpsOTPattern_Sheet1.Cells[SelectedRow,0].Text;}
		}

		private OTPattern SelectedOTPattern
		{
			get{return facadeOTPattern.ObjOTPatternList[SelectedKey];}
		}

//		============================== Constructor ==============================
		public frmOTPattern(): base()
		{
			InitializeComponent();		
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miOTPattern");
            this.title = UserProfile.GetFormName("miAttendance", "miOTPattern");

		}
        public override string FormID()
        {
            return UserProfile.GetFormID("miAttendance", "miOTPattern");
        }

//		==============================Private method ==============================
		private void newObject()
		{
			facadeOTPattern = new OTPatternFacade();
			frmEntry = new frmOTPatternEntry(this);
		}

		private void bindOTPattern(int i, OTPattern value)
		{
			fpsOTPattern_Sheet1.Cells.Get(i,0).Text = GUIFunction.GetString(value.EntityKey);
			fpsOTPattern_Sheet1.Cells.Get(i,1).Text = GUIFunction.GetString(value.PatternId);
			fpsOTPattern_Sheet1.Cells.Get(i,2).Text = GUIFunction.GetString(value.PatternName);
			fpsOTPattern_Sheet1.Cells.Get(i,3).Text = GUIFunction.GetString(value.DayType);
			fpsOTPattern_Sheet1.Cells.Get(i,4).Text = GUIFunction.GetString(value.OTPeriod); 

			if(value.IsFixedHour)
			{
				fpsOTPattern_Sheet1.Cells.Get(i,5).Text = "True";
			}
			else
			{
				fpsOTPattern_Sheet1.Cells.Get(i,5).Text = "False";
			}
			if(value.IsMaxHourLimit)
			{
				fpsOTPattern_Sheet1.Cells.Get(i,6).Text = "True";
			}
			else
			{
				fpsOTPattern_Sheet1.Cells.Get(i,6).Text = "False";
			}
			
			if(value.IsMinHourLimit)
			{
				fpsOTPattern_Sheet1.Cells.Get(i,7).Text = "True";
			}
			else
			{
				fpsOTPattern_Sheet1.Cells.Get(i,7).Text = "False";
			}

			if(value.AdditionalMinute == 0)
			{	
				fpsOTPattern_Sheet1.Cells.Get(i,8).Text = "";
			}
			else
			{
				fpsOTPattern_Sheet1.Cells.Get(i,8).Text = GUIFunction.GetString(value.AdditionalMinute); 
			}
			
			fpsOTPattern_Sheet1.Cells.Get(i,9).Text = GUIFunction.GetString(value.OTRate); 	
		}
		
		private void bindForm()
		{
			if(facadeOTPattern.ObjOTPatternList != null)
			{
				int iRow = facadeOTPattern.ObjOTPatternList.Count;
				fpsOTPattern_Sheet1.RowCount = iRow;

				for(int i=0; i<iRow; i++)
				{
					bindOTPattern(i, facadeOTPattern.ObjOTPatternList[i]);
				}	
				mdiParent.RefreshMasterCount();
			}
            fpsOTPattern_Sheet1.SetActiveCell(fpsOTPattern_Sheet1.RowCount, 0);
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
			fpsOTPattern_Sheet1.RowCount = 0;
			enableButton(false);
		}
//		============================== Private method ==============================
		public bool AddRow(OTPattern value)
		{
			if (facadeOTPattern.InsertOTPattern(value))
			{
				fpsOTPattern_Sheet1.RowCount++;
				bindOTPattern(fpsOTPattern_Sheet1.RowCount-1, value);
                fpsOTPattern_Sheet1.SetActiveCell(fpsOTPattern_Sheet1.RowCount, 0);
				enableButton(true);
				mdiParent.RefreshMasterCount();
				return true;
			}
			else
			{				
				return false;
			}
		}

		public bool UpdateRow(OTPattern value)
		{
			if (facadeOTPattern.UpdateOTPattern(value))
			{
				bindOTPattern(SelectedRow, value);				
				return true;
			}
			else
			{				
				return false;
			}
		}

		private void DeleteRow()
		{
			if (facadeOTPattern.DeleteOTPattern(SelectedOTPattern))
			{
				if(fpsOTPattern_Sheet1.RowCount > 1)
				{
					fpsOTPattern.ActiveSheet.Rows.Remove(SelectedRow,1);
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
			return facadeOTPattern.ObjOTPatternList.Count;
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
				if (facadeOTPattern.DisplayOTPattern())
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
				frmEntry = new frmOTPatternEntry(this);
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
				frmEntry = new frmOTPatternEntry(this);
				frmEntry.InitEditAction(SelectedOTPattern);
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
		private void frmOTPattern_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
		}
		
		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
			addEvent();
		}

		private void cmdDelete_Click(object sender, System.EventArgs e)
		{
		    deleteEvent();	
		}

		private void cmdEdit_Click(object sender, System.EventArgs e)
		{
		    editEvent();	
		}

		private void mniAdd_Click(object sender, System.EventArgs e)
		{
			addEvent();
		}

		private void mniDelete_Click(object sender, System.EventArgs e)
		{
	   	    deleteEvent();	
		}

		private void mniEdit_Click(object sender, System.EventArgs e)
		{
			editEvent();
		}

		private void fpsOTPattern_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader)
			{
				editEvent();
			}
		}		
	}
}
