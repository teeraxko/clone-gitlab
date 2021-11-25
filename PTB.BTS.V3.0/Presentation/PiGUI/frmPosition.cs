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

using Facade.PiFacade;
using Facade.CommonFacade;

using Presentation.CommonGUI;

namespace Presentation.PiGUI
{
	public class frmPosition : ChildFormBase, IMDIChildForm	
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
		private FarPoint.Win.Spread.SheetView fpsPosition_Sheet1;
		private System.Windows.Forms.Button cmdAdd;
		private FarPoint.Win.Spread.FpSpread fpsPosition;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
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
			FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.fpsPosition_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.fpsPosition = new FarPoint.Win.Spread.FpSpread();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mniAdd = new System.Windows.Forms.MenuItem();
			this.mniEdit = new System.Windows.Forms.MenuItem();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			((System.ComponentModel.ISupportInitialize)(this.fpsPosition_Sheet1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsPosition)).BeginInit();
			this.SuspendLayout();
			// 
			// cmdDelete
			// 
			this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdDelete.Location = new System.Drawing.Point(532, 320);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.Size = new System.Drawing.Size(72, 24);
			this.cmdDelete.TabIndex = 9;
			this.cmdDelete.Text = "ลบ";
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			// 
			// cmdEdit
			// 
			this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdEdit.Location = new System.Drawing.Point(459, 320);
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.Size = new System.Drawing.Size(72, 24);
			this.cmdEdit.TabIndex = 8;
			this.cmdEdit.Text = "แก้ไข";
			this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
			// 
			// fpsPosition_Sheet1
			// 
			this.fpsPosition_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsPosition_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsPosition_Sheet1.ColumnCount = 5;
			this.fpsPosition_Sheet1.RowCount = 1;
			this.fpsPosition_Sheet1.ColumnHeader.Cells.Get(0, 1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.fpsPosition_Sheet1.ColumnHeader.Cells.Get(0, 1).ForeColor = System.Drawing.SystemColors.ControlText;
			this.fpsPosition_Sheet1.ColumnHeader.Cells.Get(0, 1).Locked = false;
			this.fpsPosition_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "รหัส";
			this.fpsPosition_Sheet1.ColumnHeader.Cells.Get(0, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
			this.fpsPosition_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "ชื่อภาษาไทย";
			this.fpsPosition_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ชื่อย่อ";
			this.fpsPosition_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "ชื่อภาษาอังกฤษ";
			this.fpsPosition_Sheet1.ColumnHeader.Columns.Default.Resizable = false;
			this.fpsPosition_Sheet1.Columns.Default.Resizable = false;
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsPosition_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsPosition_Sheet1.Columns.Get(0).Visible = false;
			this.fpsPosition_Sheet1.Columns.Get(1).AllowAutoSort = true;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			this.fpsPosition_Sheet1.Columns.Get(1).CellType = textCellType2;
			this.fpsPosition_Sheet1.Columns.Get(1).Label = "รหัส";
			this.fpsPosition_Sheet1.Columns.Get(1).Width = 44F;
			this.fpsPosition_Sheet1.Columns.Get(2).AllowAutoSort = true;
			textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType3.DropDownButton = false;
			this.fpsPosition_Sheet1.Columns.Get(2).CellType = textCellType3;
			this.fpsPosition_Sheet1.Columns.Get(2).Label = "ชื่อภาษาไทย";
			this.fpsPosition_Sheet1.Columns.Get(2).Width = 372F;
			this.fpsPosition_Sheet1.Columns.Get(3).AllowAutoSort = true;
			textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType4.DropDownButton = false;
			this.fpsPosition_Sheet1.Columns.Get(3).CellType = textCellType4;
			this.fpsPosition_Sheet1.Columns.Get(3).Label = "ชื่อย่อ";
			this.fpsPosition_Sheet1.Columns.Get(3).Width = 100F;
			this.fpsPosition_Sheet1.Columns.Get(4).AllowAutoSort = true;
			textCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType5.DropDownButton = false;
			this.fpsPosition_Sheet1.Columns.Get(4).CellType = textCellType5;
			this.fpsPosition_Sheet1.Columns.Get(4).Label = "ชื่อภาษาอังกฤษ";
			this.fpsPosition_Sheet1.Columns.Get(4).Width = 372F;
			this.fpsPosition_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
			this.fpsPosition_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsPosition_Sheet1.RowHeader.Rows.Default.Resizable = false;
			this.fpsPosition_Sheet1.Rows.Default.Resizable = false;
			this.fpsPosition_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
			this.fpsPosition_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsPosition_Sheet1.SheetName = "Sheet1";
			this.fpsPosition_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// cmdAdd
			// 
			this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdAdd.Location = new System.Drawing.Point(387, 320);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.Size = new System.Drawing.Size(72, 24);
			this.cmdAdd.TabIndex = 7;
			this.cmdAdd.Text = "เพิ่ม";
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			// 
			// fpsPosition
			// 
			this.fpsPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsPosition.ContextMenu = this.contextMenu1;
			this.fpsPosition.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsPosition.Location = new System.Drawing.Point(19, 16);
			this.fpsPosition.Name = "fpsPosition";
			this.fpsPosition.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																					 this.fpsPosition_Sheet1});
			this.fpsPosition.Size = new System.Drawing.Size(952, 280);
			this.fpsPosition.TabIndex = 6;
			this.fpsPosition.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsPosition_CellDoubleClick);
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
			this.mniDelete.Text = "&ลบ";
			this.mniDelete.Click += new System.EventHandler(this.mniDelete_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = -1;
			this.menuItem1.Text = "";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = -1;
			this.menuItem2.Text = "";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = -1;
			this.menuItem3.Text = "";
			// 
			// frmPosition
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(990, 367);
			this.Controls.Add(this.cmdDelete);
			this.Controls.Add(this.cmdEdit);
			this.Controls.Add(this.cmdAdd);
			this.Controls.Add(this.fpsPosition);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmPosition";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //this.Text = "ข้อมูลตำแหน่ง (Position)";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmPosition_Load);
			this.Closed += new System.EventHandler(this.frmPosition_Closed);
			((System.ComponentModel.ISupportInitialize)(this.fpsPosition_Sheet1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsPosition)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
	
		#region - Private -
		private bool isReadonly = true;
		private frmPositionEntry frmEntry;
		private frmMain mdiParent;

		private int SelectedRow
		{
			get{return fpsPosition_Sheet1.ActiveRowIndex;}
		}

		private string SelectedKey
		{
			get{return fpsPosition_Sheet1.Cells[SelectedRow,0].Text;}
		}

		private Position SelectedPosition
		{
			get{return facadePosition.ObjPositionList[SelectedKey];}
		}
		#endregion

//		============================== Property ==============================
		private PositionFacade facadePosition;
		public PositionFacade FacadePosition
		{
			get{return facadePosition;}
		}

//		============================== Constructor ==============================
		public frmPosition(): base()
		{
			InitializeComponent();
			newObject();
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIPositionPosition");
            this.title = UserProfile.GetFormName("miPI", "miPIPositionPosition");


			try
			{						
				frmEntry.ObjPositionFacade = facadePosition;
			}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(Exception ex)
			{Message(ex);}
			finally
			{}				
		}
        public override string FormID()
        {
            return UserProfile.GetFormID("miPI", "miPIPositionPosition");
        }

		public void newObject()
		{
			facadePosition = new PositionFacade();
  			frmEntry = new frmPositionEntry(this);
		}
		
//		============================== Private Method ==============================
		private void bindPosition(int i, Position value)
		{
			fpsPosition_Sheet1.Cells.Get(i,0).Text = GUIFunction.GetString(value.EntityKey);
			fpsPosition_Sheet1.Cells.Get(i,1).Text = GUIFunction.GetString(value.PositionCode);
			fpsPosition_Sheet1.Cells.Get(i,2).Text = GUIFunction.GetString(value.AName.Thai);
			fpsPosition_Sheet1.Cells.Get(i,3).Text = GUIFunction.GetString(value.AShortName.English);
			fpsPosition_Sheet1.Cells.Get(i,4).Text = GUIFunction.GetString(value.AName.English);
		}

		private void bindForm()
		{
			fpsPosition_Sheet1.RowCount = facadePosition.ObjPositionList.Count;

			if (facadePosition.ObjPositionList != null)
			{
				int iRow = facadePosition.ObjPositionList.Count;
				for(int i=0; i<iRow ; i++)
				{
					bindPosition(i, facadePosition.ObjPositionList[i]);
				}				
			}
            fpsPosition_Sheet1.SetActiveCell(fpsPosition_Sheet1.RowCount, 0);
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
			fpsPosition_Sheet1.RowCount = 0;
			enableButton(false);
		}

		public bool AddRow(Position value)
		{
			if (facadePosition.InsertPosition(value))
			{
				fpsPosition_Sheet1.RowCount++;
				bindPosition(fpsPosition_Sheet1.RowCount-1, value);
                fpsPosition_Sheet1.SetActiveCell(fpsPosition_Sheet1.RowCount, 0);
				enableButton(true);
				mdiParent.RefreshMasterCount();
				return true;
			}
			else
			{				
				return false;
			}
		}

		public bool UpdateRow(Position value)
		{
			if (facadePosition.UpdatePosition(value))
			{
				bindPosition(SelectedRow, value);				
				return true;
			}
			else
			{				
				return false;
			}
		}

		private void DeleteRow()
		{
			if (facadePosition.DeletePosition(SelectedPosition))
			{
				if(fpsPosition_Sheet1.RowCount > 1)
				{
					fpsPosition_Sheet1.Rows.Remove(SelectedRow,1);
				}
				else
				{
					clearForm();
				}
				mdiParent.RefreshMasterCount();
			}
			else
			{
				Message(MessageList.Error.E0014,"ลบข้อมูลได้");
			}
		}
		//		============================== Public ==============================
		public override int MasterCount()
		{
			return facadePosition.ObjPositionList.Count;
		}

//		============================== Base Event ==============================
		public void InitForm()
		{
			newObject();
			mdiParent.EnableNewCommand(false);
			mdiParent.EnableDeleteCommand(false);
			mdiParent.EnableRefreshCommand(true);
			mdiParent.EnablePrintCommand(true);
			MainMenuNewStatus = false;
			MainMenuDeleteStatus = false;
			MainMenuRefreshStatus = true;
			MainMenuPrintStatus = true;

			RefreshForm();
		}

		public void RefreshForm()
		{
			try
			{
				if (facadePosition.DisplayPosition())
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

		public void PrintForm()
		{
			frmListofPosition objfrm = new frmListofPosition();
			objfrm.Show();
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
			{Message(sqlex);}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(Exception ex)
			{Message(ex);}		
		}

		private void EditEvent()
		{
			try
			{
				frmEntry.InitEditAction(SelectedPosition);			
				frmEntry.ShowDialog();				
			}
			catch(SqlException sqlex)
			{Message(sqlex);}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(Exception ex)
			{Message(ex);}		
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
			{Message(sqlex);}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(Exception ex)
			{Message(ex);}		
		}

//		============================== Event ==============================
		private void frmPosition_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
		}

		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
			AddEvent();
		}

		private void cmdDelete_Click(object sender, System.EventArgs e)
		{
			DeleteEvent();	
		}

		private void cmdEdit_Click(object sender, System.EventArgs e)
		{
			EditEvent();	
		}

		private void mniAdd_Click(object sender, System.EventArgs e)
		{
			AddEvent();
		}

		private void mniDelete_Click(object sender, System.EventArgs e)
		{
			DeleteEvent();	
		}

		private void mniEdit_Click(object sender, System.EventArgs e)
		{
			EditEvent();
		}

		private void fpsPosition_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader)
			{
				EditEvent();
			}
		}

		private void frmPosition_Closed(object sender, System.EventArgs e)
		{
			ExitForm();
		}
	}
}
