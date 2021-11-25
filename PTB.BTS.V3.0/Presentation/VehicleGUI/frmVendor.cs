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
using Entity.VehicleEntities;

using Facade.CommonFacade;
using Facade.VehicleFacade;

using Presentation.CommonGUI;

namespace Presentation.VehicleGUI
{
	public class frmVendor : ChildFormBase, IMDIChildForm
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
		private FarPoint.Win.Spread.FpSpread fpsVendor;
		private FarPoint.Win.Spread.SheetView fpsVendor_Sheet1;
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
			this.cmdAdd = new System.Windows.Forms.Button();
			this.fpsVendor = new FarPoint.Win.Spread.FpSpread();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mniAdd = new System.Windows.Forms.MenuItem();
			this.mniEdit = new System.Windows.Forms.MenuItem();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			this.fpsVendor_Sheet1 = new FarPoint.Win.Spread.SheetView();
			((System.ComponentModel.ISupportInitialize)(this.fpsVendor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsVendor_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// cmdDelete
			// 
			this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdDelete.Location = new System.Drawing.Point(518, 400);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.TabIndex = 7;
			this.cmdDelete.Text = "ลบ";
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			// 
			// cmdEdit
			// 
			this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdEdit.Location = new System.Drawing.Point(438, 400);
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.TabIndex = 6;
			this.cmdEdit.Text = "แก้ไข";
			this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
			// 
			// cmdAdd
			// 
			this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdAdd.Location = new System.Drawing.Point(358, 400);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.TabIndex = 5;
			this.cmdAdd.Text = "เพิ่ม";
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			// 
			// fpsVendor
			// 
			this.fpsVendor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsVendor.ContextMenu = this.contextMenu1;
			this.fpsVendor.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsVendor.Location = new System.Drawing.Point(19, 24);
			this.fpsVendor.Name = "fpsVendor";
			this.fpsVendor.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																				   this.fpsVendor_Sheet1});
			this.fpsVendor.Size = new System.Drawing.Size(912, 360);
			this.fpsVendor.TabIndex = 4;
			this.fpsVendor.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsVendor_CellDoubleClick);
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
			// fpsVendor_Sheet1
			// 
			this.fpsVendor_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsVendor_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsVendor_Sheet1.ColumnCount = 5;
			this.fpsVendor_Sheet1.RowCount = 0;
			this.fpsVendor_Sheet1.ColumnHeader.Cells.Get(0, 1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.fpsVendor_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "รหัสผู้จำหน่าย";
			this.fpsVendor_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "ชื่อย่อผู้จำหน่าย";
			this.fpsVendor_Sheet1.ColumnHeader.Cells.Get(0, 3).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.fpsVendor_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ชื่อผู้จำหน่าย (ภาษาไทย)";
			this.fpsVendor_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "ชื่อผู้จำหน่าย (ภาษาอังกฤษ)";
			this.fpsVendor_Sheet1.ColumnHeader.Columns.Default.Resizable = false;
			this.fpsVendor_Sheet1.Columns.Default.Resizable = false;
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsVendor_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsVendor_Sheet1.Columns.Get(0).Visible = false;
			this.fpsVendor_Sheet1.Columns.Get(1).AllowAutoSort = true;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			this.fpsVendor_Sheet1.Columns.Get(1).CellType = textCellType2;
			this.fpsVendor_Sheet1.Columns.Get(1).Label = "รหัสผู้จำหน่าย";
			this.fpsVendor_Sheet1.Columns.Get(1).Width = 103F;
			this.fpsVendor_Sheet1.Columns.Get(2).AllowAutoSort = true;
			textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType3.DropDownButton = false;
			this.fpsVendor_Sheet1.Columns.Get(2).CellType = textCellType3;
			this.fpsVendor_Sheet1.Columns.Get(2).Label = "ชื่อย่อผู้จำหน่าย";
			this.fpsVendor_Sheet1.Columns.Get(2).Width = 180F;
			this.fpsVendor_Sheet1.Columns.Get(3).AllowAutoSort = true;
			textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType4.DropDownButton = false;
			this.fpsVendor_Sheet1.Columns.Get(3).CellType = textCellType4;
			this.fpsVendor_Sheet1.Columns.Get(3).Label = "ชื่อผู้จำหน่าย (ภาษาไทย)";
			this.fpsVendor_Sheet1.Columns.Get(3).Width = 320F;
			this.fpsVendor_Sheet1.Columns.Get(4).AllowAutoSort = true;
			textCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType5.DropDownButton = false;
			this.fpsVendor_Sheet1.Columns.Get(4).CellType = textCellType5;
			this.fpsVendor_Sheet1.Columns.Get(4).Label = "ชื่อผู้จำหน่าย (ภาษาอังกฤษ)";
			this.fpsVendor_Sheet1.Columns.Get(4).Width = 250F;
			this.fpsVendor_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
			this.fpsVendor_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsVendor_Sheet1.RowHeader.Rows.Default.Resizable = false;
			this.fpsVendor_Sheet1.Rows.Default.Resizable = false;
			this.fpsVendor_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
			this.fpsVendor_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsVendor_Sheet1.SheetName = "Sheet1";
			this.fpsVendor_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// frmVendor
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(950, 436);
			this.Controls.Add(this.cmdEdit);
			this.Controls.Add(this.cmdAdd);
			this.Controls.Add(this.fpsVendor);
			this.Controls.Add(this.cmdDelete);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Name = "frmVendor";
            //this.Text = "ข้อมูลผู้จำหน่าย";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmVendor_Load);
			this.Closed += new System.EventHandler(this.frmVendor_Closed);
			((System.ComponentModel.ISupportInitialize)(this.fpsVendor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsVendor_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		
		#region - Private -
		private bool isReadonly = true;
		private frmVendorEntry frmEntry;
		private frmMain mdiParent;
		private int SelectedRow
		{
			get{return fpsVendor_Sheet1.ActiveRowIndex;}
		}

		private string SelectedKey
		{
			get{return fpsVendor_Sheet1.Cells[SelectedRow,0].Text;}
		}

		private Vendor SelectedVendor
		{
			get{return facadeVendor.ObjVendorList[SelectedKey];}
		}
		#endregion

		//		============================== Property ==============================
		private VendorFacade facadeVendor;
		public VendorFacade FacadeVendor
		{
			get{return facadeVendor;}
		}

		//		============================== Constructor ==============================
		public frmVendor(): base()
		{
			InitializeComponent();
			newObject();
			isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleVehicleVendor");
            this.title = UserProfile.GetFormName("miVehicle", "miVehicleVehicleVendor");


			try
			{						
				frmEntry.ObjVendorFacade = facadeVendor;
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
            return UserProfile.GetFormID("miVehicle", "miVehicleVehicleVendor");
        }
		public void newObject()
		{
			facadeVendor = new VendorFacade();
  			frmEntry = new frmVendorEntry(this);
		}
		
		//		============================== Private Method ==============================
		private void bindVendor(int i,Vendor aVendor)
		{
			fpsVendor_Sheet1.Cells.Get(i,0).Text = GUIFunction.GetString(aVendor.EntityKey);
			fpsVendor_Sheet1.Cells.Get(i,1).Text = GUIFunction.GetString(aVendor.Code);
			fpsVendor_Sheet1.Cells.Get(i,2).Text = GUIFunction.GetString(aVendor.ShortName);
			fpsVendor_Sheet1.Cells.Get(i,3).Text = GUIFunction.GetString(aVendor.ADescription.Thai);
			fpsVendor_Sheet1.Cells.Get(i,4).Text = GUIFunction.GetString(aVendor.ADescription.English);
		}
		private void bindForm()
		{
			this.fpsVendor_Sheet1.RowCount = facadeVendor.ObjVendorList.Count;
			if (facadeVendor.ObjVendorList != null)
			{
				for(int iRow=0; iRow < facadeVendor.ObjVendorList.Count; iRow++)
				{
					bindVendor(iRow,facadeVendor.ObjVendorList[iRow]);
				}		
		
				mdiParent.RefreshMasterCount();
			}
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
			fpsVendor_Sheet1.RowCount = 0;
			enableButton(false);
		}

		//		==============================Public method ==============================
		public override int MasterCount()
		{
			return facadeVendor.ObjVendorList.Count;
		}

		//		============================= Public Method ==============================
		public bool AddRow(Vendor aVendor)
		{
			if (facadeVendor.InsertVendor(aVendor))
			{
				fpsVendor_Sheet1.RowCount++;
				bindVendor(fpsVendor_Sheet1.RowCount-1,aVendor);
				enableButton(true);
				mdiParent.RefreshMasterCount();
				return true;
			}
			else
			{				
				return false;
			}
		}
		public bool UpdateRow(Vendor aVendor)
		{
			if (facadeVendor.UpdateVendor(aVendor))
			{
				bindVendor(SelectedRow, aVendor);				
				return true;
			}
			else
			{				
				return false;
			}
		}
		private void DeleteRow()
		{
			if (facadeVendor.DeleteVendor(SelectedVendor))
			{
				if(fpsVendor_Sheet1.RowCount > 1)
				{
					fpsVendor_Sheet1.Rows.Remove(SelectedRow,1);
				}
				else
				{
					clearForm();
				}
				mdiParent.RefreshMasterCount();
			}
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
			if (facadeVendor.DisplayVendor())
			{
				bindForm();
			}
			else
			{
				enableButton(false);
				clearForm();
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

		}

		public void ExitForm()
		{
			Dispose(true);
		}

		private void AddEvent()
		{
			try
			{
				frmEntry = new frmVendorEntry(this);
				frmEntry.InitAddAction();
				frmEntry.VendorCodeFocus();
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
				frmEntry = new frmVendorEntry(this);
				frmEntry.InitEditAction(SelectedVendor);
				frmEntry.VendorShortNameFocus();
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
		private void frmVendor_Load(object sender, System.EventArgs e)
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
		private void fpsVendor_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if (!e.ColumnHeader)
			{
				EditEvent();
			}
		}
		private void frmVendor_Closed(object sender, System.EventArgs e)
		{
			ExitForm();
		}
	}
}
