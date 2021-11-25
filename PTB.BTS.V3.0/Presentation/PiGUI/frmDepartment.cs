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
	public class frmDepartment : ChildFormBase, IMDIChildForm
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
		private FarPoint.Win.Spread.FpSpread fpsDepartment;
		private FarPoint.Win.Spread.SheetView fpsDepartment_Sheet1;
		private System.Windows.Forms.Button cmdAdd;
		private System.Windows.Forms.Button cmdEdit;
		private System.Windows.Forms.Button cmdDelete;
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
			FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
			this.fpsDepartment = new FarPoint.Win.Spread.FpSpread();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mniAdd = new System.Windows.Forms.MenuItem();
			this.mniEdit = new System.Windows.Forms.MenuItem();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			this.fpsDepartment_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdDelete = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.fpsDepartment)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsDepartment_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// fpsDepartment
			// 
			this.fpsDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsDepartment.ContextMenu = this.contextMenu1;
			this.fpsDepartment.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsDepartment.Location = new System.Drawing.Point(24, 16);
			this.fpsDepartment.Name = "fpsDepartment";
			this.fpsDepartment.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.None;
			this.fpsDepartment.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																					   this.fpsDepartment_Sheet1});
			this.fpsDepartment.Size = new System.Drawing.Size(960, 384);
			this.fpsDepartment.TabIndex = 0;
			this.fpsDepartment.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsDepartment_CellDoubleClick);
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
			// fpsDepartment_Sheet1
			// 
			this.fpsDepartment_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsDepartment_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsDepartment_Sheet1.ColumnCount = 5;
			this.fpsDepartment_Sheet1.RowCount = 1;
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsDepartment_Sheet1.Cells.Get(0, 1).CellType = textCellType1;
			this.fpsDepartment_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "รหัส";
			this.fpsDepartment_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "ชื่อภาษาไทย";
			this.fpsDepartment_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ชื่อย่อ";
			this.fpsDepartment_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "ชื่อภาษาอังกฤษ";
			this.fpsDepartment_Sheet1.ColumnHeader.Columns.Default.Resizable = false;
			this.fpsDepartment_Sheet1.Columns.Default.Resizable = false;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			this.fpsDepartment_Sheet1.Columns.Get(0).CellType = textCellType2;
			this.fpsDepartment_Sheet1.Columns.Get(0).Visible = false;
			this.fpsDepartment_Sheet1.Columns.Get(1).AllowAutoSort = true;
			textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType3.DropDownButton = false;
			this.fpsDepartment_Sheet1.Columns.Get(1).CellType = textCellType3;
			this.fpsDepartment_Sheet1.Columns.Get(1).Label = "รหัส";
			this.fpsDepartment_Sheet1.Columns.Get(1).Width = 49F;
			this.fpsDepartment_Sheet1.Columns.Get(2).AllowAutoSort = true;
			textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType4.DropDownButton = false;
			this.fpsDepartment_Sheet1.Columns.Get(2).CellType = textCellType4;
			this.fpsDepartment_Sheet1.Columns.Get(2).Label = "ชื่อภาษาไทย";
			this.fpsDepartment_Sheet1.Columns.Get(2).Width = 372F;
			this.fpsDepartment_Sheet1.Columns.Get(3).AllowAutoSort = true;
			textCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType5.DropDownButton = false;
			this.fpsDepartment_Sheet1.Columns.Get(3).CellType = textCellType5;
			this.fpsDepartment_Sheet1.Columns.Get(3).Label = "ชื่อย่อ";
			this.fpsDepartment_Sheet1.Columns.Get(3).Width = 103F;
			this.fpsDepartment_Sheet1.Columns.Get(4).AllowAutoSort = true;
			textCellType6.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType6.DropDownButton = false;
			this.fpsDepartment_Sheet1.Columns.Get(4).CellType = textCellType6;
			this.fpsDepartment_Sheet1.Columns.Get(4).Label = "ชื่อภาษาอังกฤษ";
			this.fpsDepartment_Sheet1.Columns.Get(4).Width = 372F;
			this.fpsDepartment_Sheet1.LockBackColor = System.Drawing.Color.White;
			this.fpsDepartment_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
			this.fpsDepartment_Sheet1.RestrictRows = true;
			this.fpsDepartment_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsDepartment_Sheet1.RowHeader.Rows.Default.Resizable = false;
			this.fpsDepartment_Sheet1.Rows.Default.Resizable = false;
			this.fpsDepartment_Sheet1.SelectionBackColor = System.Drawing.Color.White;
			this.fpsDepartment_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
			this.fpsDepartment_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsDepartment_Sheet1.SheetName = "Sheet1";
			this.fpsDepartment_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// cmdAdd
			// 
			this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdAdd.Location = new System.Drawing.Point(404, 440);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.TabIndex = 3;
			this.cmdAdd.Text = "&เพิ่ม";
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			// 
			// cmdEdit
			// 
			this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdEdit.Location = new System.Drawing.Point(492, 440);
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.TabIndex = 4;
			this.cmdEdit.Text = "&แก้ไข";
			this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
			// 
			// cmdDelete
			// 
			this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdDelete.Location = new System.Drawing.Point(580, 440);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.TabIndex = 5;
			this.cmdDelete.Text = "&ลบ";
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			// 
			// frmDepartment
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1008, 486);
			this.Controls.Add(this.cmdDelete);
			this.Controls.Add(this.cmdEdit);
			this.Controls.Add(this.cmdAdd);
			this.Controls.Add(this.fpsDepartment);
			this.Name = "frmDepartment";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //this.Text = "ข้อมูลฝ่าย";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmDepartment_Load);
			((System.ComponentModel.ISupportInitialize)(this.fpsDepartment)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsDepartment_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
	
		#region - Private -
		private bool isReadonly = true;
		private frmDepartmentEntry frmEntry;
		private frmMain mdiParent;

		private int SelectedRow
		{
			get{return fpsDepartment_Sheet1.ActiveRowIndex;}
		}

		private string SelectedKey
		{
			get{return fpsDepartment_Sheet1.Cells[SelectedRow,0].Text;}
		}

		private Department SelectedDepartment
		{
			get{return facadeDepartment.ObjDepartmentList[SelectedKey];}
		}
		#endregion

		//		============================== Property ==============================
		private DepartmentFacade facadeDepartment;
		public DepartmentFacade FacadeDepartment
		{
			get{return facadeDepartment;}
		}

		//		============================== Constructor ==============================
		public frmDepartment(): base()
		{
			InitializeComponent();
			newObject();
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMapDepartment");
            this.title = UserProfile.GetFormName("miPI", "miPIMapDepartment");


			try
			{						
				frmEntry.ObjDepartmentFacade = facadeDepartment;	
			}
			catch(AppExceptionBase ex)
			{
				Message(ex);
			}
			catch(Exception ex)
			{
				Message(ex);
			}
			finally
			{
			}				
		}
        public override string FormID()
        {
            return UserProfile.GetFormID("miPI", "miPIMapDepartment");
        }

		public void newObject()
		{
			facadeDepartment = new DepartmentFacade();
  			frmEntry = new frmDepartmentEntry(this);
		}
		//		============================== Private Method ==============================

		private void bindDepartment(int i,Department aDepartment)
		{
			fpsDepartment_Sheet1.Cells.Get(i,0).Text = GUIFunction.GetString(aDepartment.EntityKey);
			fpsDepartment_Sheet1.Cells.Get(i,1).Text = 	GUIFunction.GetString(aDepartment.Code);
			fpsDepartment_Sheet1.Cells.Get(i,2).Text = 	GUIFunction.GetString(aDepartment.AFullName.Thai);
			fpsDepartment_Sheet1.Cells.Get(i,3).Text = 	GUIFunction.GetString(aDepartment.AShortName.English);
			fpsDepartment_Sheet1.Cells.Get(i,4).Text = 	GUIFunction.GetString(aDepartment.AFullName.English);
		}
		private void bindForm()
		{
			this.fpsDepartment_Sheet1.RowCount = facadeDepartment.ObjDepartmentList.Count;
			if (facadeDepartment.ObjDepartmentList != null)
			{
				for(int iRow=0; iRow < facadeDepartment.ObjDepartmentList.Count; iRow++)
				{
					bindDepartment(iRow,facadeDepartment.ObjDepartmentList[iRow]);
				}				
			}
            fpsDepartment_Sheet1.SetActiveCell(fpsDepartment_Sheet1.RowCount, 0);
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
			fpsDepartment_Sheet1.RowCount = 0;
			enableButton(false);
		}

		public bool AddRow(Department aDepartment)
		{
			if (facadeDepartment.InsertDepartment(aDepartment))
			{
				fpsDepartment_Sheet1.RowCount++;
				bindDepartment(fpsDepartment_Sheet1.RowCount-1,aDepartment);
                fpsDepartment_Sheet1.SetActiveCell(fpsDepartment_Sheet1.RowCount, 0);
				enableButton(true);
				mdiParent.RefreshMasterCount();
				return true;
			}
			else
			{				
				return false;
			}
		}
		public bool UpdateRow(Department aDepartment)
		{
			if (facadeDepartment.UpdateDepartment(aDepartment))
			{
				bindDepartment(SelectedRow, aDepartment);				
				return true;
			}
			else
			{				
				return false;
			}
		}
		private void DeleteRow()
		{
			if (facadeDepartment.DeleteDepartment(SelectedDepartment))
			{
				if(fpsDepartment_Sheet1.RowCount > 1)
				{
					fpsDepartment_Sheet1.Rows.Remove(SelectedRow,1);
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
			return facadeDepartment.ObjDepartmentList.Count;
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
				if (facadeDepartment.DisplayDepartment())
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
			frmListofDepartment objfrm = new frmListofDepartment();
			objfrm.Show();
		}
		public void ExitForm()
		{
			this.Hide();
			Dispose(true);
		}
		private void AddEvent()
		{
			try
			{
				frmEntry = new frmDepartmentEntry(this);
				frmEntry.InitAddAction();
				frmEntry.DeptCode();
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
				frmEntry = new frmDepartmentEntry(this);
				frmEntry.InitEditAction(SelectedDepartment);
				frmEntry.EngShortFocus();
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

		//		============================== Event ==============================
		private void frmDepartment_Load(object sender, System.EventArgs e)
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

		private void fpsDepartment_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader)
			{
				EditEvent();
			}
		}
	}
}
