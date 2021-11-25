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

namespace Presentation.ContractGUI
{
	public class frmCustomer : ChildFormBase, IMDIChildForm	
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
		private FarPoint.Win.Spread.FpSpread fpsCustomer;
		private FarPoint.Win.Spread.SheetView fpsCustomer_Sheet1;
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
			this.fpsCustomer = new FarPoint.Win.Spread.FpSpread();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mniAdd = new System.Windows.Forms.MenuItem();
			this.mniEdit = new System.Windows.Forms.MenuItem();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			this.fpsCustomer_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdDelete = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.fpsCustomer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsCustomer_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// fpsCustomer
			// 
			this.fpsCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsCustomer.ContextMenu = this.contextMenu1;
			this.fpsCustomer.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsCustomer.Location = new System.Drawing.Point(8, 24);
			this.fpsCustomer.Name = "fpsCustomer";
			this.fpsCustomer.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																					 this.fpsCustomer_Sheet1});
			this.fpsCustomer.Size = new System.Drawing.Size(1016, 464);
			this.fpsCustomer.TabIndex = 0;
			this.fpsCustomer.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsCustomer_CellDoubleClick);
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
			// fpsCustomer_Sheet1
			// 
			this.fpsCustomer_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsCustomer_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsCustomer_Sheet1.ColumnCount = 6;
			this.fpsCustomer_Sheet1.RowCount = 0;
			this.fpsCustomer_Sheet1.ColumnHeader.Cells.Get(0, 1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.fpsCustomer_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "รหัสลูกค้า";
            // 22/5/2019 Kriangkrai A. Add SAP Code
            this.fpsCustomer_Sheet1.ColumnHeader.Cells.Get(0, 2).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
            this.fpsCustomer_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "SAP Code";
            // End Edit
			this.fpsCustomer_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ชื่อย่อลูกค้า";
			this.fpsCustomer_Sheet1.ColumnHeader.Cells.Get(0, 4).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.fpsCustomer_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "ชื่อลูกค้า(ภาษาไทย)";
			this.fpsCustomer_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "ชื่อลูกค้า(ภาษาอังกฤษ)";
			this.fpsCustomer_Sheet1.ColumnHeader.Columns.Default.Resizable = false;
			this.fpsCustomer_Sheet1.Columns.Default.Resizable = false;
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsCustomer_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsCustomer_Sheet1.Columns.Get(0).Visible = false;
			this.fpsCustomer_Sheet1.Columns.Get(1).AllowAutoSort = true;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			this.fpsCustomer_Sheet1.Columns.Get(1).CellType = textCellType2;
			this.fpsCustomer_Sheet1.Columns.Get(1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.fpsCustomer_Sheet1.Columns.Get(1).Label = "รหัสลูกค้า";
			this.fpsCustomer_Sheet1.Columns.Get(1).Width = 61F;
			this.fpsCustomer_Sheet1.Columns.Get(2).AllowAutoSort = true;
            //
            textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            textCellType3.DropDownButton = false;
            this.fpsCustomer_Sheet1.Columns.Get(2).CellType = textCellType3;
            this.fpsCustomer_Sheet1.Columns.Get(2).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
            this.fpsCustomer_Sheet1.Columns.Get(2).Label = "SAP Code";
            this.fpsCustomer_Sheet1.Columns.Get(2).Width = 61F;
            this.fpsCustomer_Sheet1.Columns.Get(3).AllowAutoSort = true;
            //
			textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType4.DropDownButton = false;
			this.fpsCustomer_Sheet1.Columns.Get(3).CellType = textCellType4;
			this.fpsCustomer_Sheet1.Columns.Get(3).Label = "ชื่อย่อลูกค้า";
			this.fpsCustomer_Sheet1.Columns.Get(3).Width = 131F;
			this.fpsCustomer_Sheet1.Columns.Get(4).AllowAutoSort = true;
			textCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType5.DropDownButton = false;
			this.fpsCustomer_Sheet1.Columns.Get(4).CellType = textCellType5;
			this.fpsCustomer_Sheet1.Columns.Get(4).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.fpsCustomer_Sheet1.Columns.Get(4).Label = "ชื่อลูกค้า(ภาษาไทย)";
			this.fpsCustomer_Sheet1.Columns.Get(4).Width = 329F;
			this.fpsCustomer_Sheet1.Columns.Get(5).AllowAutoSort = true;
			textCellType6.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType6.DropDownButton = false;
			this.fpsCustomer_Sheet1.Columns.Get(5).CellType = textCellType6;
			this.fpsCustomer_Sheet1.Columns.Get(5).Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.fpsCustomer_Sheet1.Columns.Get(5).Label = "ชื่อลูกค้า(ภาษาอังกฤษ)";
			this.fpsCustomer_Sheet1.Columns.Get(5).Width = 446F;
			this.fpsCustomer_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
			this.fpsCustomer_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsCustomer_Sheet1.RowHeader.Rows.Default.Resizable = false;
			this.fpsCustomer_Sheet1.Rows.Default.Resizable = false;
			this.fpsCustomer_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
			this.fpsCustomer_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsCustomer_Sheet1.SheetName = "Sheet1";
			this.fpsCustomer_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// cmdAdd
			// 
			this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdAdd.Location = new System.Drawing.Point(398, 504);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.TabIndex = 1;
			this.cmdAdd.Text = "เพิ่ม";
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			// 
			// cmdEdit
			// 
			this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdEdit.Location = new System.Drawing.Point(478, 504);
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.TabIndex = 2;
			this.cmdEdit.Text = "แก้ไข";
			this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
			// 
			// cmdDelete
			// 
			this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdDelete.Location = new System.Drawing.Point(558, 504);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.TabIndex = 3;
			this.cmdDelete.Text = "ลบ";
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			// 
			// frmCustomer
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1030, 536);
			this.ContextMenu = this.contextMenu1;
			this.Controls.Add(this.cmdDelete);
			this.Controls.Add(this.cmdEdit);
			this.Controls.Add(this.cmdAdd);
			this.Controls.Add(this.fpsCustomer);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmCustomer";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //this.Text = "ข้อมูลลูกค้า";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmCustomer_Load);
			this.Closed += new System.EventHandler(this.frmCustomer_Closed);
			((System.ComponentModel.ISupportInitialize)(this.fpsCustomer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsCustomer_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		
		#region - Private -
		private bool isReadonly = true;
		private frmCustomerEntry frmEntry;
		private frmMain mdiParent;

		private int SelectedRow
		{
			get
			{return fpsCustomer_Sheet1.ActiveRowIndex;}
		}

		private string SelectedKey
		{
			get
			{
				return fpsCustomer_Sheet1.Cells[SelectedRow,0].Text;
			}
		}

		private Customer SelectedCustomer
		{
			get
			{
				return facadeCustomer.ObjCustomerList[SelectedKey];
			}
		}
		#endregion

		//		============================== Property ==============================
		private CustomerFacade facadeCustomer;
		public CustomerFacade FacadeCustomer
		{
			get
			{
				return facadeCustomer;
			}
		}

		//		============================== Constructor ==============================
		public frmCustomer(): base()
		{
			InitializeComponent();
			newObject();
			isReadonly = UserProfile.IsReadOnly("miContract", "miContractCustomerData");
            this.title = UserProfile.GetFormName("miContract", "miContractCustomerData");


			try
			{						
				frmEntry.ObjCustomerFacade = facadeCustomer;
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
            return UserProfile.GetFormID("miContract", "miContractCustomerData");
        }

		public void newObject()
		{
			facadeCustomer = new CustomerFacade();
  			frmEntry = new frmCustomerEntry(this);
		}
		
//		============================== Private Method ==============================
		private void bindCustomer(int i,Customer aCustomer)
		{
			fpsCustomer_Sheet1.Cells.Get(i,0).Text = GUIFunction.GetString(aCustomer.EntityKey);
			fpsCustomer_Sheet1.Cells.Get(i,1).Text = GUIFunction.GetString(aCustomer.Code);
            // 22/5/2019 Kriangkrai A. Add SAP Code
            fpsCustomer_Sheet1.Cells.Get(i,2).Text = GUIFunction.GetString(aCustomer.SAPCode);
            // End Edit
			fpsCustomer_Sheet1.Cells.Get(i,3).Text = GUIFunction.GetString(aCustomer.ShortName);
			fpsCustomer_Sheet1.Cells.Get(i,4).Text = GUIFunction.GetString(aCustomer.AName.Thai);
			fpsCustomer_Sheet1.Cells.Get(i,5).Text = GUIFunction.GetString(aCustomer.AName.English);
		}
		private void bindForm()
		{
			this.fpsCustomer_Sheet1.RowCount = facadeCustomer.ObjCustomerList.Count;
			if (facadeCustomer.ObjCustomerList != null)
			{
				for(int iRow=0; iRow < facadeCustomer.ObjCustomerList.Count; iRow++)
				{
					bindCustomer(iRow,facadeCustomer.ObjCustomerList[iRow]);
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
			fpsCustomer_Sheet1.RowCount = 0;
			enableButton(false);
		}

		public bool AddRow(Customer aCustomer)
		{
			if (facadeCustomer.InsertCustomer(aCustomer))
			{
				fpsCustomer_Sheet1.RowCount++;
				bindCustomer(fpsCustomer_Sheet1.RowCount-1,aCustomer);
				enableButton(true);
				mdiParent.RefreshMasterCount();
				return true;
			}
			else
			{				
				return false;
			}
		}
	
		public bool UpdateRow(Customer aCustomer)
		{
			if (facadeCustomer.UpdateCustomer(aCustomer))
			{
				bindCustomer(SelectedRow, aCustomer);				
				return true;
			}
			else
			{				
				return false;
			}
		}
		private void DeleteRow()
		{
			if (facadeCustomer.DeleteCustomer(SelectedCustomer))
			{
				if(fpsCustomer_Sheet1.RowCount > 1)
				{
					fpsCustomer_Sheet1.Rows.Remove(SelectedRow,1);
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
			return facadeCustomer.ObjCustomerList.Count;
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

			newObject();

			if (facadeCustomer.DisplayCustomer())
			{
				bindForm();	
				if(fpsCustomer_Sheet1.RowCount == 0)
				{
					enableButton(false);
				}
			}
			else
			{
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

		public void RefreshForm()
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

			if (facadeCustomer.DisplayCustomer())
			{
				bindForm();
				if(fpsCustomer_Sheet1.RowCount == 0)
				{
					enableButton(false);
				}
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
			frmListofCustomer objfrm = new frmListofCustomer();
			objfrm.MdiParent = this.mdiParent;
			objfrm.Show();
		}
		public void ExitForm()
		{
//			mdiParent.EnableNewCommand(false);
//			mdiParent.EnableDeleteCommand(false);
//			mdiParent.EnableRefreshCommand(false);
//			mdiParent.EnablePrintCommand(false);
//			mdiParent.EnableExitCommand(true);
			Dispose(true);
		}
		private void AddEvent()
		{
			try
			{
				frmEntry = new frmCustomerEntry(this);
				frmEntry.InitAddAction();
				frmEntry.CustomerCodeFocus();
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
				frmEntry = new frmCustomerEntry(this);
				frmEntry.InitEditAction(SelectedCustomer);
				frmEntry.CustomerGroupFocus();
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
		private void frmCustomer_Load(object sender, System.EventArgs e)
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
		private void fpsCustomer_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader)
			{
				EditEvent();
			}
		}
		private void frmCustomer_Closed(object sender, System.EventArgs e)
		{
			ExitForm();
		}
	}
}
