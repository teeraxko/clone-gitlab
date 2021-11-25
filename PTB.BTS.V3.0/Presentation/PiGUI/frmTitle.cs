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

using Facade.CommonFacade;
using Facade.PiFacade;

using Presentation.CommonGUI;

namespace Presentation.PiGUI
{
	public class frmTitle : ChildFormBase, IMDIChildForm
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
		private FarPoint.Win.Spread.SheetView fpsTitle_Sheet1;
		private FarPoint.Win.Spread.FpSpread fpsTitle;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem mniAdd;
		private System.Windows.Forms.MenuItem mniEdit;
		private System.Windows.Forms.MenuItem mniDelete;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
			this.fpsTitle_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.fpsTitle = new FarPoint.Win.Spread.FpSpread();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mniAdd = new System.Windows.Forms.MenuItem();
			this.mniEdit = new System.Windows.Forms.MenuItem();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdAdd = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.fpsTitle_Sheet1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsTitle)).BeginInit();
			this.SuspendLayout();
			// 
			// fpsTitle_Sheet1
			// 
			this.fpsTitle_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsTitle_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsTitle_Sheet1.ColumnCount = 4;
			this.fpsTitle_Sheet1.RowCount = 0;
			this.fpsTitle_Sheet1.ColumnHeader.Cells.Get(0, 0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.fpsTitle_Sheet1.ColumnHeader.Cells.Get(0, 0).ForeColor = System.Drawing.SystemColors.ControlText;
			this.fpsTitle_Sheet1.ColumnHeader.Cells.Get(0, 0).Locked = false;
			this.fpsTitle_Sheet1.ColumnHeader.Cells.Get(0, 0).Text = "รหัส";
			this.fpsTitle_Sheet1.ColumnHeader.Cells.Get(0, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
			this.fpsTitle_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "ชื่อภาษาไทย";
			this.fpsTitle_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "ชื่อย่อ";
			this.fpsTitle_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ชื่อภาษาอังกฤษ";
			this.fpsTitle_Sheet1.Columns.Get(0).AllowAutoSort = true;
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsTitle_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsTitle_Sheet1.Columns.Get(0).Label = "รหัส";
			this.fpsTitle_Sheet1.Columns.Get(0).Resizable = false;
			this.fpsTitle_Sheet1.Columns.Get(0).Width = 45F;
			this.fpsTitle_Sheet1.Columns.Get(1).AllowAutoSort = true;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			this.fpsTitle_Sheet1.Columns.Get(1).CellType = textCellType2;
			this.fpsTitle_Sheet1.Columns.Get(1).Label = "ชื่อภาษาไทย";
			this.fpsTitle_Sheet1.Columns.Get(1).Resizable = false;
			this.fpsTitle_Sheet1.Columns.Get(1).Width = 193F;
			this.fpsTitle_Sheet1.Columns.Get(2).AllowAutoSort = true;
			textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType3.DropDownButton = false;
			this.fpsTitle_Sheet1.Columns.Get(2).CellType = textCellType3;
			this.fpsTitle_Sheet1.Columns.Get(2).Label = "ชื่อย่อ";
			this.fpsTitle_Sheet1.Columns.Get(2).Resizable = false;
			this.fpsTitle_Sheet1.Columns.Get(2).Width = 51F;
			this.fpsTitle_Sheet1.Columns.Get(3).AllowAutoSort = true;
			textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType4.DropDownButton = false;
			this.fpsTitle_Sheet1.Columns.Get(3).CellType = textCellType4;
			this.fpsTitle_Sheet1.Columns.Get(3).Label = "ชื่อภาษาอังกฤษ";
			this.fpsTitle_Sheet1.Columns.Get(3).Resizable = false;
			this.fpsTitle_Sheet1.Columns.Get(3).Width = 208F;
			this.fpsTitle_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
			this.fpsTitle_Sheet1.RowHeader.Columns.Default.Resizable = true;
			this.fpsTitle_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
			this.fpsTitle_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsTitle_Sheet1.SheetName = "Sheet1";
			this.fpsTitle_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// fpsTitle
			// 
			this.fpsTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsTitle.ContextMenu = this.contextMenu1;
			this.fpsTitle.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsTitle.Location = new System.Drawing.Point(16, 16);
			this.fpsTitle.Name = "fpsTitle";
			this.fpsTitle.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																				  this.fpsTitle_Sheet1});
			this.fpsTitle.Size = new System.Drawing.Size(560, 320);
			this.fpsTitle.TabIndex = 6;
			this.fpsTitle.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsTitle_CellDoubleClick);
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
			// cmdDelete
			// 
			this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdDelete.Location = new System.Drawing.Point(339, 352);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.TabIndex = 12;
			this.cmdDelete.Text = "ลบ";
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			// 
			// cmdEdit
			// 
			this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdEdit.Location = new System.Drawing.Point(259, 352);
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.TabIndex = 11;
			this.cmdEdit.Text = "แก้ไข";
			this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
			// 
			// cmdAdd
			// 
			this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdAdd.Location = new System.Drawing.Point(179, 352);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.TabIndex = 10;
			this.cmdAdd.Text = "เพิ่ม";
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			// 
			// frmTitle
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(592, 398);
			this.Controls.Add(this.cmdDelete);
			this.Controls.Add(this.cmdEdit);
			this.Controls.Add(this.cmdAdd);
			this.Controls.Add(this.fpsTitle);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmTitle";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //this.Text = "ข้อมูลตำแหน่ง (Title)";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmTitle_Load);
			((System.ComponentModel.ISupportInitialize)(this.fpsTitle_Sheet1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsTitle)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private - 
		private bool isReadonly = true;
		private frmTitleEntry frmEntry;
		private frmMain mdiParent;

		private int SelectedRow
		{
			get
			{
				return fpsTitle_Sheet1.ActiveRowIndex;
			}
		}

		private string SelectedKey
		{
			get
			{
				return fpsTitle_Sheet1.Cells[SelectedRow,0].Text;
			}
		}

		private Title SelectedTitle
		{
			get
			{
				return facadeTitle.ObjTitleList[SelectedKey];
			}
		}
		#endregion

//		============================== Property ==============================
		private TitleFacade facadeTitle;	
		public TitleFacade FacadeTitle
		{
			get
			{
				return facadeTitle;
			}
		}
//		============================== Constructor ==============================
		public frmTitle() : base()
		{
			InitializeComponent();
			newObject();
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIPositionTitle");
            this.title = UserProfile.GetFormName("miPI", "miPIPositionTitle");

		}
        public override string FormID()
        {
            return UserProfile.GetFormID("miPI", "miPIPositionTitle");
        }

		private void newObject()
		{
			facadeTitle = new TitleFacade();
			frmEntry = new frmTitleEntry();
			frmEntry.parentForm = this;
		}

//		============================== private method ==============================
		private void bindTitle(int row, Title aTitle)
		{
			fpsTitle_Sheet1.Cells[row,0].Text = aTitle.EntityKey;
			fpsTitle_Sheet1.Cells[row,0].Text = GUIFunction.GetString(aTitle.Code);
			fpsTitle_Sheet1.Cells[row,1].Text = GUIFunction.GetString(aTitle.AName.Thai);
			fpsTitle_Sheet1.Cells[row,2].Text = GUIFunction.GetString(aTitle.AShortName.English);
			fpsTitle_Sheet1.Cells[row,3].Text = GUIFunction.GetString(aTitle.AName.English);
		}
		private void bindForm()
		{
			if (facadeTitle.ObjTitleList != null)
			{
				int iRow = facadeTitle.ObjTitleList.Count;
				fpsTitle_Sheet1.RowCount = iRow;

				for(int i=0; i<iRow; i++)
				{
					bindTitle(i,facadeTitle.ObjTitleList[i]);
				}
				
				if(iRow == 0)
				{
					enableButton(false);
				}
			}
            fpsTitle_Sheet1.SetActiveCell(fpsTitle_Sheet1.RowCount, 0);
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
			fpsTitle_Sheet1.RowCount = 0;
			enableButton(false);
		}
//		============================== public method ==============================
		public bool AddRow(Title aTitle)
		{
			if (facadeTitle.InsertTitle(aTitle))
			{
				fpsTitle_Sheet1.RowCount++;
				bindTitle(fpsTitle_Sheet1.RowCount-1,aTitle);
                fpsTitle_Sheet1.SetActiveCell(fpsTitle_Sheet1.RowCount, 0);
				enableButton(true);
				mdiParent.RefreshMasterCount();
				return true;
			}
			else
			{				
				return false;
			}
		}
		public bool UpdateRow(Title aTitle)
		{
			if (facadeTitle.UpdateTitle(aTitle))
			{
				bindTitle(SelectedRow, aTitle);				
				return true;
			}
			else
			{				
				return false;
			}
		}
		public void DeleteRow()
		{
			if (facadeTitle.DeleteTitle(SelectedTitle))
			{
				if(fpsTitle_Sheet1.RowCount > 1)
				{
					fpsTitle.ActiveSheet.Rows.Remove(SelectedRow,1);
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
			return facadeTitle.ObjTitleList.Count;
		}

//		============================== Base Event ==============================
		public void InitForm()
		{
			mdiParent.EnableNewCommand(false);
			mdiParent.EnableDeleteCommand(false);
			mdiParent.EnableRefreshCommand(true);
			mdiParent.EnablePrintCommand(false);
			MainMenuNewStatus = false;
			MainMenuDeleteStatus = false;
			MainMenuRefreshStatus = true;
			MainMenuPrintStatus = false;

			newObject();
			try
			{
				if (facadeTitle.DisplayTitle())
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
			Dispose(true);
		}
		private void AddEvent()
		{
			try
			{
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

		private void EditEvent()
		{
			try
			{
				frmEntry.InitEditAction(SelectedTitle);
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
		private void DeleteEvent()
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

		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
			AddEvent();
		}

		private void cmdEdit_Click(object sender, System.EventArgs e)
		{
			EditEvent();
		}

		private void cmdDelete_Click(object sender, System.EventArgs e)
		{
			DeleteEvent();
		}

		private void fpsTitle_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if (!e.ColumnHeader)
			{
				EditEvent();			
			}
		}

		private void frmTitle_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
		}

		private void mniAdd_Click(object sender, System.EventArgs e)
		{
			AddEvent();
		}

		private void mniEdit_Click(object sender, System.EventArgs e)
		{
			EditEvent();
		}

		private void mniDelete_Click(object sender, System.EventArgs e)
		{
			DeleteEvent();
		}
	}
}
