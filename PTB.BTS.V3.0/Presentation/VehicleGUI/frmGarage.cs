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
	public class frmGarage : ChildFormBase, IMDIChildForm
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
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem mniAdd;
        private System.Windows.Forms.MenuItem mniEdit;
        private System.Windows.Forms.MenuItem mniDelete;
        private FarPoint.Win.Spread.FpSpread fpsGarage;
        private FarPoint.Win.Spread.SheetView fpsGarage_Sheet1;

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
            FarPoint.Win.Spread.CellType.TextCellType textCellType8 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.fpsGarage = new FarPoint.Win.Spread.FpSpread();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.mniAdd = new System.Windows.Forms.MenuItem();
            this.mniEdit = new System.Windows.Forms.MenuItem();
            this.mniDelete = new System.Windows.Forms.MenuItem();
            this.fpsGarage_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fpsGarage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsGarage_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // fpsGarage
            // 
            this.fpsGarage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.fpsGarage.ContextMenu = this.contextMenu1;
            this.fpsGarage.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.fpsGarage.Location = new System.Drawing.Point(8, 24);
            this.fpsGarage.Name = "fpsGarage";
            this.fpsGarage.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																				   this.fpsGarage_Sheet1});
            this.fpsGarage.Size = new System.Drawing.Size(968, 368);
            this.fpsGarage.TabIndex = 5;
            this.fpsGarage.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsGarage_CellDoubleClick);
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
            // fpsGarage_Sheet1
            // 
            this.fpsGarage_Sheet1.Reset();
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpsGarage_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpsGarage_Sheet1.ColumnCount = 8;
            this.fpsGarage_Sheet1.ColumnHeader.RowCount = 2;
            this.fpsGarage_Sheet1.RowCount = 0;
            this.fpsGarage_Sheet1.ColumnHeader.Cells.Get(0, 1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
            this.fpsGarage_Sheet1.ColumnHeader.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsGarage_Sheet1.ColumnHeader.Cells.Get(0, 1).RowSpan = 2;
            this.fpsGarage_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "รหัสศูนย์บริการ";
            this.fpsGarage_Sheet1.ColumnHeader.Cells.Get(0, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpsGarage_Sheet1.ColumnHeader.Cells.Get(0, 2).RowSpan = 2;
            this.fpsGarage_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "ชื่อย่อ ศูนย์บริการ";
            this.fpsGarage_Sheet1.ColumnHeader.Cells.Get(0, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpsGarage_Sheet1.ColumnHeader.Cells.Get(0, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsGarage_Sheet1.ColumnHeader.Cells.Get(0, 3).RowSpan = 2;
            this.fpsGarage_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ชื่อศูนย์บริการ(ภาษาไทย)";
            this.fpsGarage_Sheet1.ColumnHeader.Cells.Get(0, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpsGarage_Sheet1.ColumnHeader.Cells.Get(0, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsGarage_Sheet1.ColumnHeader.Cells.Get(0, 4).RowSpan = 2;
            this.fpsGarage_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "รหัสผู้จำหน่าย(BizPac)";
            this.fpsGarage_Sheet1.ColumnHeader.Cells.Get(0, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            // 22/5/2019 Kriangkrai A. Add SAP Code
            this.fpsGarage_Sheet1.ColumnHeader.Cells.Get(0, 5).RowSpan = 2;
            this.fpsGarage_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "SAP Code";
            this.fpsGarage_Sheet1.ColumnHeader.Cells.Get(0, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            // End Edit
            this.fpsGarage_Sheet1.ColumnHeader.Cells.Get(0, 6).RowSpan = 2;
            this.fpsGarage_Sheet1.ColumnHeader.Cells.Get(0, 6).Text = "รหัสค่าใช้จ่าย (BizPac)";
            this.fpsGarage_Sheet1.ColumnHeader.Cells.Get(0, 7).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
            this.fpsGarage_Sheet1.ColumnHeader.Cells.Get(0, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsGarage_Sheet1.ColumnHeader.Cells.Get(0, 7).RowSpan = 2;
            this.fpsGarage_Sheet1.ColumnHeader.Cells.Get(0, 7).Text = "ชื่อค่าใช้จ่าย (BizPac)";
            this.fpsGarage_Sheet1.ColumnHeader.Cells.Get(0, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.fpsGarage_Sheet1.ColumnHeader.Columns.Default.Resizable = false;
            this.fpsGarage_Sheet1.Columns.Default.Resizable = false;
            textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType1.DropDownButton = false;
            this.fpsGarage_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.fpsGarage_Sheet1.Columns.Get(0).Visible = false;
            this.fpsGarage_Sheet1.Columns.Get(1).AllowAutoSort = true;
            textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType2.DropDownButton = false;
            this.fpsGarage_Sheet1.Columns.Get(1).CellType = textCellType2;
            this.fpsGarage_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsGarage_Sheet1.Columns.Get(1).Width = 80F;
            this.fpsGarage_Sheet1.Columns.Get(2).AllowAutoSort = true;
            textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType3.DropDownButton = false;
            this.fpsGarage_Sheet1.Columns.Get(2).CellType = textCellType3;
            this.fpsGarage_Sheet1.Columns.Get(2).Width = 100F;
            this.fpsGarage_Sheet1.Columns.Get(3).AllowAutoSort = true;
            textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType4.DropDownButton = false;
            this.fpsGarage_Sheet1.Columns.Get(3).CellType = textCellType4;
            this.fpsGarage_Sheet1.Columns.Get(3).Width = 300F;
            this.fpsGarage_Sheet1.Columns.Get(4).AllowAutoSort = true;
            // 22/5/2019 Kriangkrai A. Add SAP Code
            textCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType5.DropDownButton = false;
            this.fpsGarage_Sheet1.Columns.Get(4).CellType = textCellType5;
            this.fpsGarage_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsGarage_Sheet1.Columns.Get(4).Width = 80F;
            this.fpsGarage_Sheet1.Columns.Get(5).AllowAutoSort = true;
            // End Edit
            textCellType6.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType6.DropDownButton = false;
            this.fpsGarage_Sheet1.Columns.Get(5).CellType = textCellType6;
            this.fpsGarage_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsGarage_Sheet1.Columns.Get(5).Width = 80F;
            this.fpsGarage_Sheet1.Columns.Get(6).AllowAutoSort = true;
            textCellType7.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType7.DropDownButton = false;
            this.fpsGarage_Sheet1.Columns.Get(6).CellType = textCellType7;
            this.fpsGarage_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsGarage_Sheet1.Columns.Get(6).Width = 80F;
            this.fpsGarage_Sheet1.Columns.Get(7).AllowAutoSort = true;
            textCellType8.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType8.DropDownButton = false;
            this.fpsGarage_Sheet1.Columns.Get(7).CellType = textCellType8;
            this.fpsGarage_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsGarage_Sheet1.Columns.Get(7).Width = 190F;
            this.fpsGarage_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpsGarage_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpsGarage_Sheet1.RowHeader.Rows.Default.Resizable = false;
            this.fpsGarage_Sheet1.Rows.Default.Resizable = false;
            this.fpsGarage_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.fpsGarage_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpsGarage_Sheet1.SheetName = "Sheet1";
            this.fpsGarage_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdDelete.Location = new System.Drawing.Point(535, 408);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(73, 24);
            this.cmdDelete.TabIndex = 8;
            this.cmdDelete.Text = "ลบ";
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdEdit.Location = new System.Drawing.Point(455, 408);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(73, 24);
            this.cmdEdit.TabIndex = 7;
            this.cmdEdit.Text = "แก้ไข";
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdAdd.Location = new System.Drawing.Point(375, 408);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(73, 24);
            this.cmdAdd.TabIndex = 6;
            this.cmdAdd.Text = "เพิ่ม";
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // frmGarage
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(984, 446);
            this.ContextMenu = this.contextMenu1;
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.fpsGarage);
            this.Name = "frmGarage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmGarage_Load);
            this.Closed += new System.EventHandler(this.frmGarage_Closed);
            ((System.ComponentModel.ISupportInitialize)(this.fpsGarage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsGarage_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

		#region - Private -
		private bool isReadonly = true;
		private frmGarageEntry frmEntry;
		private frmMain mdiParent;

		private int SelectedRow
		{
			get{return fpsGarage_Sheet1.ActiveRowIndex;}
		}

		private string SelectedKey
		{
			get{return fpsGarage_Sheet1.Cells[SelectedRow,0].Text;}
		}

		private Garage SelectedGarage
		{
			get{return facadeGarage.ObjGarageList[SelectedKey];}
		}
		#endregion

		//		============================= Constructor ================================
		public frmGarage() : base()
		{
			InitializeComponent();
			newObject();
			isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleMaintenanceGarage");
            this.title = UserProfile.GetFormName("miVehicle", "miVehicleMaintenanceGarage");

			try
			{						
				frmEntry.ObjGarageFacade = facadeGarage;
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
            return UserProfile.GetFormID("miVehicle", "miVehicleMaintenanceGarage");
        }

		public void newObject()
		{
			facadeGarage = new GarageFacade();
			frmEntry = new frmGarageEntry(this);
		}
		
		//		================================ Property ================================
		private GarageFacade facadeGarage;
		public GarageFacade FacadeGarage
		{
			get
			{
				return facadeGarage;
			}
		}

		//		============================ Private Method ==============================
		private void bindGarage(int i,Garage aGarage)
		{
			fpsGarage_Sheet1.Cells.Get(i, 0).Text = GUIFunction.GetString(aGarage.EntityKey);
			fpsGarage_Sheet1.Cells.Get(i, 1).Text = GUIFunction.GetString(aGarage.Code);
			fpsGarage_Sheet1.Cells.Get(i, 2).Text = GUIFunction.GetString(aGarage.ShortName);
			fpsGarage_Sheet1.Cells.Get(i, 3).Text = GUIFunction.GetString(aGarage.AName.Thai);
            fpsGarage_Sheet1.Cells.Get(i, 4).Text = GUIFunction.GetString(aGarage.BizPacVendorCode);
            // 22/5/2019 Kriangkrai A. Add SAP Code
            fpsGarage_Sheet1.Cells.Get(i, 5).Text = GUIFunction.GetString(aGarage.SAPCode);
            // End Edit
            fpsGarage_Sheet1.Cells.Get(i, 6).Text = GUIFunction.GetString(aGarage.BizPacExpenseCode);
            fpsGarage_Sheet1.Cells.Get(i, 7).Text = GUIFunction.GetString(aGarage.BizPacExpenseName);
		}

		private void bindForm()
		{
			this.fpsGarage_Sheet1.RowCount = facadeGarage.ObjGarageList.Count;
			if (facadeGarage.ObjGarageList != null)
			{
				for(int iRow=0; iRow < facadeGarage.ObjGarageList.Count; iRow++)
				{
					bindGarage(iRow,facadeGarage.ObjGarageList[iRow]);
				}				
			}
            fpsGarage_Sheet1.SetActiveCell(fpsGarage_Sheet1.RowCount, 0);
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
			fpsGarage_Sheet1.RowCount = 0;
			enableButton(false);
		}	
		//		============================= Public Method ==============================
		public bool AddRow(Garage aGarage)
		{
			if (facadeGarage.InsertGarage(aGarage))
			{
				fpsGarage_Sheet1.RowCount++;
				bindGarage(fpsGarage_Sheet1.RowCount-1,aGarage);
                fpsGarage_Sheet1.SetActiveCell(fpsGarage_Sheet1.RowCount, 0);
				enableButton(true);
				mdiParent.RefreshMasterCount();
				return true;
			}
			else
			{				
				return false;
			}
		}
		public bool UpdateRow(Garage aGarage)
		{
			if (facadeGarage.UpdateGarage(aGarage))
			{
				bindGarage(SelectedRow, aGarage);				
				return true;
			}
			else
			{				
				return false;
			}
		}
		private void DeleteRow()
		{
			if (facadeGarage.DeleteGarage(SelectedGarage))
			{
				if(fpsGarage_Sheet1.RowCount > 1)
				{
					fpsGarage_Sheet1.Rows.Remove(SelectedRow,1);
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
			return facadeGarage.ObjGarageList.Count;
		}
		//		=============================== Base Event ===============================
		public void InitForm()
		{	
			mdiParent.EnableNewCommand(false);
			mdiParent.EnableDeleteCommand(false);
			mdiParent.EnableRefreshCommand(true);
			mdiParent.EnablePrintCommand(true);
			MainMenuNewStatus = false;
			MainMenuDeleteStatus = false;
			MainMenuRefreshStatus = true;
			MainMenuPrintStatus = true;
			newObject();
			RefreshForm();
		}

		public void RefreshForm()
		{
			if (facadeGarage.DisplayGarage())
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
			frmListofGarage objform = new frmListofGarage();
			objform.Show();
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
		private void AddEvent()
		{
			try
			{
				frmEntry = new frmGarageEntry(this);
				frmEntry.InitAddAction();
				frmEntry.GarageCodeFocus();
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
				frmEntry = new frmGarageEntry(this);
				frmEntry.InitEditAction(SelectedGarage);
				frmEntry.GarageShortNameFocus();
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
		
		//		================================= Event ==================================
		private void frmGarage_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();		
		}
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
		private void fpsGarage_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if (!e.ColumnHeader)
			{
				EditEvent();
			}
		}
		private void frmGarage_Closed(object sender, System.EventArgs e)
		{
			ExitForm();
		}
	}
}
