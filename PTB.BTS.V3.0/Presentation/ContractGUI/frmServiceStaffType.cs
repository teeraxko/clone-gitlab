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
using Entity.ContractEntities;

using Facade.CommonFacade;
using Facade.ContractFacade;

using Presentation.CommonGUI;

using ictus.PIS.PI.Entity;

namespace Presentation.ContractGUI
{
	public class frmServiceStaffType : ChildFormBase, IMDIChildForm
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
        private FarPoint.Win.Spread.FpSpread fpsServiceStaffType;
        private FarPoint.Win.Spread.SheetView fpsServiceStaffType_Sheet1;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.Button cmdAdd;
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
            FarPoint.Win.Spread.CellType.TextCellType textCellType7 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.fpsServiceStaffType = new FarPoint.Win.Spread.FpSpread();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.mniAdd = new System.Windows.Forms.MenuItem();
            this.mniEdit = new System.Windows.Forms.MenuItem();
            this.mniDelete = new System.Windows.Forms.MenuItem();
            this.fpsServiceStaffType_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fpsServiceStaffType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsServiceStaffType_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // fpsServiceStaffType
            // 
            this.fpsServiceStaffType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.fpsServiceStaffType.ContextMenu = this.contextMenu1;
            this.fpsServiceStaffType.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.fpsServiceStaffType.Location = new System.Drawing.Point(6, 8);
            this.fpsServiceStaffType.Name = "fpsServiceStaffType";
            this.fpsServiceStaffType.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																							 this.fpsServiceStaffType_Sheet1});
            this.fpsServiceStaffType.Size = new System.Drawing.Size(983, 176);
            this.fpsServiceStaffType.TabIndex = 0;
            this.fpsServiceStaffType.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsServiceStaffType_CellDoubleClick);
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
            // fpsServiceStaffType_Sheet1
            // 
            this.fpsServiceStaffType_Sheet1.Reset();
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpsServiceStaffType_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpsServiceStaffType_Sheet1.ColumnCount = 7;
            this.fpsServiceStaffType_Sheet1.RowCount = 0;
            this.fpsServiceStaffType_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "ตำแหน่ง";
            this.fpsServiceStaffType_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "รหัสประเภทของพนักงาน(Service Staff)";
            this.fpsServiceStaffType_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "คำอธิบาย (ภาษาไทย)";
            this.fpsServiceStaffType_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "คำอธิบาย(ภาษาอังกฤษ)";
            this.fpsServiceStaffType_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "Income Code";
            this.fpsServiceStaffType_Sheet1.ColumnHeader.Cells.Get(0, 6).Text = "Income Name";
            this.fpsServiceStaffType_Sheet1.ColumnHeader.Rows.Get(0).Height = 30F;
            textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType1.DropDownButton = false;
            this.fpsServiceStaffType_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.fpsServiceStaffType_Sheet1.Columns.Get(0).Visible = false;
            this.fpsServiceStaffType_Sheet1.Columns.Get(1).AllowAutoSort = true;
            textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType2.DropDownButton = false;
            this.fpsServiceStaffType_Sheet1.Columns.Get(1).CellType = textCellType2;
            this.fpsServiceStaffType_Sheet1.Columns.Get(1).Label = "ตำแหน่ง";
            this.fpsServiceStaffType_Sheet1.Columns.Get(1).Resizable = false;
            this.fpsServiceStaffType_Sheet1.Columns.Get(1).Width = 200F;
            this.fpsServiceStaffType_Sheet1.Columns.Get(2).AllowAutoSort = true;
            textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType3.DropDownButton = false;
            this.fpsServiceStaffType_Sheet1.Columns.Get(2).CellType = textCellType3;
            this.fpsServiceStaffType_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpsServiceStaffType_Sheet1.Columns.Get(2).Label = "รหัสประเภทของพนักงาน(Service Staff)";
            this.fpsServiceStaffType_Sheet1.Columns.Get(2).Resizable = false;
            this.fpsServiceStaffType_Sheet1.Columns.Get(2).Width = 112F;
            this.fpsServiceStaffType_Sheet1.Columns.Get(3).AllowAutoSort = true;
            textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType4.DropDownButton = false;
            this.fpsServiceStaffType_Sheet1.Columns.Get(3).CellType = textCellType4;
            this.fpsServiceStaffType_Sheet1.Columns.Get(3).Label = "คำอธิบาย (ภาษาไทย)";
            this.fpsServiceStaffType_Sheet1.Columns.Get(3).Resizable = false;
            this.fpsServiceStaffType_Sheet1.Columns.Get(3).Width = 200F;
            this.fpsServiceStaffType_Sheet1.Columns.Get(4).AllowAutoSort = true;
            textCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType5.DropDownButton = false;
            this.fpsServiceStaffType_Sheet1.Columns.Get(4).CellType = textCellType5;
            this.fpsServiceStaffType_Sheet1.Columns.Get(4).Label = "คำอธิบาย(ภาษาอังกฤษ)";
            this.fpsServiceStaffType_Sheet1.Columns.Get(4).Width = 200F;
            this.fpsServiceStaffType_Sheet1.Columns.Get(5).AllowAutoSort = true;
            textCellType6.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType6.DropDownButton = false;
            this.fpsServiceStaffType_Sheet1.Columns.Get(5).CellType = textCellType6;
            this.fpsServiceStaffType_Sheet1.Columns.Get(5).Label = "Income Code";
            this.fpsServiceStaffType_Sheet1.Columns.Get(6).AllowAutoSort = true;
            textCellType7.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType7.DropDownButton = false;
            this.fpsServiceStaffType_Sheet1.Columns.Get(6).CellType = textCellType7;
            this.fpsServiceStaffType_Sheet1.Columns.Get(6).Label = "Income Name";
            this.fpsServiceStaffType_Sheet1.Columns.Get(6).Width = 150F;
            this.fpsServiceStaffType_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.fpsServiceStaffType_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpsServiceStaffType_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.fpsServiceStaffType_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.fpsServiceStaffType_Sheet1.SheetName = "Sheet1";
            this.fpsServiceStaffType_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
            this.cmdDelete.Location = new System.Drawing.Point(540, 202);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.TabIndex = 6;
            this.cmdDelete.Text = "ลบ";
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
            this.cmdEdit.Location = new System.Drawing.Point(460, 202);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.TabIndex = 5;
            this.cmdEdit.Text = "แก้ไข";
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
            this.cmdAdd.Location = new System.Drawing.Point(380, 202);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.TabIndex = 4;
            this.cmdAdd.Text = "เพิ่ม";
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // frmServiceStaffType
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(994, 240);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.fpsServiceStaffType);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmServiceStaffType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmServiceStaffType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fpsServiceStaffType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsServiceStaffType_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

		#region - Private - 
		private bool isReadonly	= true;
		private frmServiceStaffTypeEntry frmEntry;
		private frmMain mdiParent;
		private int SelectedRow
		{
			get
			{
				return fpsServiceStaffType_Sheet1.ActiveRowIndex;
			}
		}

		private string SelectedKey
		{
			get
			{
				return fpsServiceStaffType_Sheet1.Cells[SelectedRow,0].Text;
			}
		}

		private ServiceStaffType SelectedServiceStaffType
		{
			get
			{
				return facadeServiceStaffType.ObjServiceStaffTypeList[SelectedKey];
			}
		}
		#endregion

		//		============================== Property ==============================
		private ServiceStaffTypeFacade facadeServiceStaffType;	
		public ServiceStaffTypeFacade FacadeServiceStaffType
		{
			get
			{
				return facadeServiceStaffType;
			}
		}
		
//		============================== Constructor ==============================
		public frmServiceStaffType(): base()
		{
			InitializeComponent();
			isReadonly = UserProfile.IsReadOnly("miContract", "miContractSettingServiceStaffType");
            this.title = UserProfile.GetFormName("miContract", "miContractSettingServiceStaffType");

		}
        public override string FormID()
        {
            return UserProfile.GetFormID("miContract", "miContractSettingServiceStaffType");
        }
//		============================== private method ==============================
		private void bindServiceStaffType(int row, ServiceStaffType aServiceStaffType)
		{
			fpsServiceStaffType_Sheet1.Cells[row,0].Text = GUIFunction.GetString(aServiceStaffType.EntityKey);
			fpsServiceStaffType_Sheet1.Cells[row,1].Text = GUIFunction.GetString(aServiceStaffType.APosition.AName.Thai);
			fpsServiceStaffType_Sheet1.Cells[row,2].Text = GUIFunction.GetString(aServiceStaffType.Type);
			fpsServiceStaffType_Sheet1.Cells[row,3].Text = GUIFunction.GetString(aServiceStaffType.ADescription.Thai);
			fpsServiceStaffType_Sheet1.Cells[row,4].Text = GUIFunction.GetString(aServiceStaffType.ADescription.English);
            fpsServiceStaffType_Sheet1.Cells[row, 5].Text = GUIFunction.GetString(aServiceStaffType.BizPacIncomeCode);
            fpsServiceStaffType_Sheet1.Cells[row, 6].Text = GUIFunction.GetString(aServiceStaffType.BizPacIncomeName);

		}

		private void bindForm()
		{
			if (facadeServiceStaffType.ObjServiceStaffTypeList != null)
			{
				int iRow = facadeServiceStaffType.ObjServiceStaffTypeList.Count;
				fpsServiceStaffType_Sheet1.RowCount = iRow;
				for(int i=0; i<iRow; i++)
				{
					bindServiceStaffType(i,facadeServiceStaffType.ObjServiceStaffTypeList[i]);
				}	
				mdiParent.RefreshMasterCount();
                fpsServiceStaffType_Sheet1.SetActiveCell(fpsServiceStaffType_Sheet1.RowCount, 0);
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
			fpsServiceStaffType_Sheet1.RowCount = 0;
			enableButton(false);
		}
		private bool Validate2()
		{
			ServiceStaffType serviceStaffType = SelectedServiceStaffType;
			if(serviceStaffType.APosition.APositionRole == POSITION_ROLE_TYPE.DRIVER) 
			{
				Message(MessageList.Error.E0040 );
				return false;
			}
			else
			{
				return true;
			}
		}
//		============================== public method ==============================
		public bool AddRow(ServiceStaffType aServiceStaffType)
		{
			if (facadeServiceStaffType.InsertServiceStaffType(aServiceStaffType))
			{
				fpsServiceStaffType_Sheet1.RowCount++;
				bindServiceStaffType(fpsServiceStaffType_Sheet1.RowCount-1,aServiceStaffType);
                fpsServiceStaffType_Sheet1.SetActiveCell(fpsServiceStaffType_Sheet1.RowCount, 0);
				enableButton(true);
				mdiParent.RefreshMasterCount();
				return true;
			}
			else
			{				
				return false;
			}
		}
//
		public bool UpdateRow(ServiceStaffType aServiceStaffType)
		{
			if (facadeServiceStaffType.UpdateServiceStaffType(aServiceStaffType))
			{
				bindServiceStaffType(SelectedRow, aServiceStaffType);				
				return true;
			}
			else
			{				
				return false;
			}
		}

		public void DeleteRow()
		{
			if(Validate2())
			{
				if (facadeServiceStaffType.DeleteServiceStaffType(SelectedServiceStaffType))
				{
					if(fpsServiceStaffType_Sheet1.RowCount > 1)
					{
						fpsServiceStaffType.ActiveSheet.Rows.Remove(SelectedRow,1);
					}
					else
					{
						clearForm();			
					}
					mdiParent.RefreshMasterCount();
				}
			}
		}

		public override int MasterCount()
		{
			return facadeServiceStaffType.ObjServiceStaffTypeList.Count;
		}

//		============================== Base Event ==============================
		public void InitForm()
		{
			MainMenuNewStatus = false;
			MainMenuDeleteStatus = false;
			MainMenuRefreshStatus = true;
			MainMenuPrintStatus = true;

			mdiParent.EnableNewCommand(false);
			mdiParent.EnableDeleteCommand(false);
			mdiParent.EnableRefreshCommand(true);
			mdiParent.EnablePrintCommand(true);
			mdiParent.EnableExitCommand(true);
			try
			{
				facadeServiceStaffType = new ServiceStaffTypeFacade();
				frmEntry = new frmServiceStaffTypeEntry(this);

				if (facadeServiceStaffType.DisplayServiceStaffType())
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
			try
			{
				if (facadeServiceStaffType.DisplayServiceStaffType())
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
            frmListofServiceStaff objfrm = new frmListofServiceStaff();
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
				frmEntry = new frmServiceStaffTypeEntry(this);
				frmEntry.InitAddAction();
				frmEntry.PositionName();
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
				frmEntry = new frmServiceStaffTypeEntry(this);
				frmEntry.InitEditAction(SelectedServiceStaffType);
				frmEntry.ServiceStaffCode();
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
		private void frmServiceStaffType_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
		}

		private void cmdDelete_Click(object sender, System.EventArgs e)
		{
			DeleteEvent();
		}

		private void cmdEdit_Click(object sender, System.EventArgs e)
		{
			EditEvent();
		}

		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
			AddEvent();
		}

		private void fpsServiceStaffType_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader)
			{
				EditEvent();
			}
		}

		private void mniEdit_Click(object sender, System.EventArgs e)
		{
			EditEvent();
		}

		private void mniDelete_Click(object sender, System.EventArgs e)
		{
			DeleteEvent();
		}

		private void mniAdd_Click(object sender, System.EventArgs e)
		{
			AddEvent();
		}
	}
}
