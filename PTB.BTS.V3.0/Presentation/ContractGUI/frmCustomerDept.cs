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
using Entity.AttendanceEntities;
using ictus.PIS.PI.Entity;
using Entity.ContractEntities;

using Facade.CommonFacade;
using Facade.AttendanceFacade;
using Facade.ContractFacade;

using Presentation.CommonGUI;
namespace Presentation.ContractGUI
{
	public class frmCustomerDept : ChildFormBase, IMDIChildForm
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
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button cmdShow;
		private System.Windows.Forms.Button cmdAdd;
		private System.Windows.Forms.Button cmdEdit;
		private System.Windows.Forms.Button cmdDelete;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem mniAdd;
		private System.Windows.Forms.MenuItem mniEdit;
		private System.Windows.Forms.MenuItem mniDelete;
		private FarPoint.Win.Spread.FpSpread fpsCustomerDept;
		private FarPoint.Win.Spread.SheetView fpsCustomerDept_Sheet1;
		private System.Windows.Forms.ComboBox txtCustomerName;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
			this.fpsCustomerDept = new FarPoint.Win.Spread.FpSpread();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mniAdd = new System.Windows.Forms.MenuItem();
			this.mniEdit = new System.Windows.Forms.MenuItem();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			this.fpsCustomerDept_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cmdShow = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtCustomerName = new System.Windows.Forms.ComboBox();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdDelete = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.fpsCustomerDept)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsCustomerDept_Sheet1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// fpsCustomerDept
			// 
			this.fpsCustomerDept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsCustomerDept.ContextMenu = this.contextMenu1;
			this.fpsCustomerDept.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsCustomerDept.Location = new System.Drawing.Point(29, 96);
			this.fpsCustomerDept.Name = "fpsCustomerDept";
			this.fpsCustomerDept.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																						 this.fpsCustomerDept_Sheet1});
			this.fpsCustomerDept.Size = new System.Drawing.Size(832, 290);
			this.fpsCustomerDept.TabIndex = 0;
			this.fpsCustomerDept.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsCustomerDept_CellDoubleClick);
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
			// fpsCustomerDept_Sheet1
			// 
			this.fpsCustomerDept_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsCustomerDept_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsCustomerDept_Sheet1.ColumnCount = 5;
			this.fpsCustomerDept_Sheet1.ColumnHeader.RowCount = 2;
			this.fpsCustomerDept_Sheet1.RowCount = 0;
			this.fpsCustomerDept_Sheet1.ColumnHeader.Cells.Get(0, 1).RowSpan = 2;
			this.fpsCustomerDept_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "รหัสฝ่าย";
			this.fpsCustomerDept_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "ชื่อย่อฝ่าย";
			this.fpsCustomerDept_Sheet1.ColumnHeader.Cells.Get(0, 3).RowSpan = 2;
			this.fpsCustomerDept_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ชื่อฝ่าย (ภาษาไทย)";
			this.fpsCustomerDept_Sheet1.ColumnHeader.Cells.Get(0, 4).RowSpan = 2;
			this.fpsCustomerDept_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "ชื่อฝ่าย (ภาษาอังกฤษ)";
			this.fpsCustomerDept_Sheet1.ColumnHeader.Cells.Get(1, 2).Text = "ชื่อย่อฝ่าย";
			this.fpsCustomerDept_Sheet1.ColumnHeader.Rows.Get(1).Height = 0F;
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsCustomerDept_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsCustomerDept_Sheet1.Columns.Get(0).Visible = false;
			this.fpsCustomerDept_Sheet1.Columns.Get(1).AllowAutoSort = true;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			this.fpsCustomerDept_Sheet1.Columns.Get(1).CellType = textCellType2;
			this.fpsCustomerDept_Sheet1.Columns.Get(1).Resizable = false;
			this.fpsCustomerDept_Sheet1.Columns.Get(1).Width = 90F;
			this.fpsCustomerDept_Sheet1.Columns.Get(2).AllowAutoSort = true;
			this.fpsCustomerDept_Sheet1.Columns.Get(2).Label = "ชื่อย่อฝ่าย";
			this.fpsCustomerDept_Sheet1.Columns.Get(2).Width = 180F;
			this.fpsCustomerDept_Sheet1.Columns.Get(3).AllowAutoSort = true;
			textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType3.DropDownButton = false;
			this.fpsCustomerDept_Sheet1.Columns.Get(3).CellType = textCellType3;
			this.fpsCustomerDept_Sheet1.Columns.Get(3).Resizable = false;
			this.fpsCustomerDept_Sheet1.Columns.Get(3).Width = 250F;
			this.fpsCustomerDept_Sheet1.Columns.Get(4).AllowAutoSort = true;
			textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType4.DropDownButton = false;
			this.fpsCustomerDept_Sheet1.Columns.Get(4).CellType = textCellType4;
			this.fpsCustomerDept_Sheet1.Columns.Get(4).Resizable = false;
			this.fpsCustomerDept_Sheet1.Columns.Get(4).Width = 250F;
			this.fpsCustomerDept_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
			this.fpsCustomerDept_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsCustomerDept_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
			this.fpsCustomerDept_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsCustomerDept_Sheet1.SheetName = "Sheet1";
			this.fpsCustomerDept_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.cmdShow);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtCustomerName);
			this.groupBox1.Location = new System.Drawing.Point(24, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(840, 64);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// cmdShow
			// 
			this.cmdShow.Location = new System.Drawing.Point(376, 24);
			this.cmdShow.Name = "cmdShow";
			this.cmdShow.TabIndex = 3;
			this.cmdShow.Text = "แสดงข้อมูล";
			this.cmdShow.Click += new System.EventHandler(this.cmdShow_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "ลูกค้า";
			// 
			// txtCustomerName
			// 
			this.txtCustomerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.txtCustomerName.Location = new System.Drawing.Point(64, 24);
			this.txtCustomerName.Name = "txtCustomerName";
			this.txtCustomerName.Size = new System.Drawing.Size(272, 21);
			this.txtCustomerName.TabIndex = 5;
			// 
			// cmdAdd
			// 
			this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdAdd.Location = new System.Drawing.Point(330, 400);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.TabIndex = 2;
			this.cmdAdd.Text = "เพิ่ม";
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			// 
			// cmdEdit
			// 
			this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdEdit.Location = new System.Drawing.Point(410, 400);
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.TabIndex = 3;
			this.cmdEdit.Text = "แก้ไข";
			this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
			// 
			// cmdDelete
			// 
			this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdDelete.Location = new System.Drawing.Point(490, 400);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.TabIndex = 4;
			this.cmdDelete.Text = "ลบ";
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			// 
			// frmCustomerDept
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(890, 440);
			this.Controls.Add(this.cmdDelete);
			this.Controls.Add(this.cmdEdit);
			this.Controls.Add(this.cmdAdd);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.fpsCustomerDept);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmCustomerDept";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //this.Text = "ข้อมูลฝ่ายลูกค้า";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmCustomerDept_Load);
			((System.ComponentModel.ISupportInitialize)(this.fpsCustomerDept)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsCustomerDept_Sheet1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private frmCustomerDeptEntry frmEntry;
		private frmMain mdiParent;
		private int SelectedRow
		{
			get
			{
				return fpsCustomerDept_Sheet1.ActiveRowIndex;
			}
		}

		private string SelectedKey
		{
			get
			{
				return fpsCustomerDept_Sheet1.Cells[SelectedRow,0].Text;
			}
		}

		private CustomerDepartment SelectedCustomerDept
		{
			get
			{
				return facadeCustomerDept.ObjCustomerDepartmentList[SelectedKey];
			}
		}
		#endregion
		
//		============================== Property ==============================
		private CustomerDeptFacade facadeCustomerDept;
		public CustomerDeptFacade FacadeCustomerDept
		{
			get
			{
				return facadeCustomerDept;
			}
		}		
		
		public Customer Customer
		{
			get
			{
				return facadeCustomerDept.ObjCustomerDepartmentList.ACustomer;
			}
		}

//		============================== Constructor ==============================
		public frmCustomerDept():base()
		{
			InitializeComponent();
			newObject();
			isReadonly = UserProfile.IsReadOnly("miContract", "miContractCustomerDepartment");
            this.title = UserProfile.GetFormName("miContract", "miContractCustomerDepartment");


			try
			{						
				txtCustomerName.DataSource = facadeCustomerDept.DataSourceCustomer;
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
            return UserProfile.GetFormID("miContract", "miContractCustomerDepartment");
        }
		private void newObject()
		{
			facadeCustomerDept = new CustomerDeptFacade();
			frmEntry = new frmCustomerDeptEntry(this);
		}
//		==============================Private method ==============================
		private void bindCustomerDept(int row,CustomerDepartment aCustomerDepartment)
		{
			fpsCustomerDept_Sheet1.Cells[row,0].Text = aCustomerDepartment.EntityKey;
			fpsCustomerDept_Sheet1.Cells[row,1].Text = GUIFunction.GetString(aCustomerDepartment.Code);
			fpsCustomerDept_Sheet1.Cells[row,2].Text = aCustomerDepartment.ShortName;
			fpsCustomerDept_Sheet1.Cells[row,3].Text = aCustomerDepartment.AName.Thai;
			fpsCustomerDept_Sheet1.Cells[row,4].Text = aCustomerDepartment.AName.English;
		}

		private void bindForm()
		{
			txtCustomerName.Text = Customer.AName.Thai;

			int DepartmentCount = facadeCustomerDept.ObjCustomerDepartmentList.Count;
			if (DepartmentCount>0)
			{
				fpsCustomerDept_Sheet1.RowCount = DepartmentCount;
				for(int i=0; i<DepartmentCount; i++)
				{
					bindCustomerDept(i,facadeCustomerDept.ObjCustomerDepartmentList[i]);
				}
                fpsCustomerDept_Sheet1.SetActiveCell(fpsCustomerDept_Sheet1.RowCount, 0);
			}
			else
			{
				clearForm();			
			}
			mdiParent.RefreshMasterCount();
		}

		private void enableButton1(bool enable)
		{
			mniEdit.Enabled = enable;
			cmdEdit.Enabled = enable;
			mniDelete.Enabled = enable;
			cmdDelete.Enabled = enable;
		}

		private void enableButton2(bool enable)
		{
			cmdAdd.Enabled = enable;
			mniAdd.Enabled = enable;
		}

		private void enableButtonAll(bool enable)
		{
			enableButton1(enable);
			enableButton2(enable);
		}

		private void enableCase(bool enable)
		{
			txtCustomerName.Enabled = enable;
			cmdShow.Enabled = enable;
		}

		private void showCase()
		{						
			fpsCustomerDept.Show();		
			cmdAdd.Show();
			cmdEdit.Show();
			cmdDelete.Show();
		}

		private void hideCase()
		{				
			fpsCustomerDept.Hide();		
			cmdAdd.Hide();
			cmdEdit.Hide();
			cmdDelete.Hide();
			txtCustomerName.Text = "";
		}

		private void clearForm()
		{	
			fpsCustomerDept_Sheet1.RowCount = 0;
			enableButton1(false);			
		}

//		==========================Public Method========================
		public bool AddRow(CustomerDepartment aCustomerDepartment)
		{
			if (facadeCustomerDept.InsertCustomerDepartment(aCustomerDepartment))
			{
				fpsCustomerDept_Sheet1.RowCount++;
				bindCustomerDept(fpsCustomerDept_Sheet1.RowCount-1,aCustomerDepartment);
                fpsCustomerDept_Sheet1.SetActiveCell(fpsCustomerDept_Sheet1.RowCount, 0);
				enableButton1(true);
				mdiParent.RefreshMasterCount();
				return true;
			}
			else
			{				
				return false;
			}
		}

		public bool UpdateRow(CustomerDepartment aCustomerDepartment)
		{
			if (facadeCustomerDept.UpdateCustomerDepartment(aCustomerDepartment))
			{
				bindCustomerDept(SelectedRow, aCustomerDepartment);				
				return true;
			}
			else
			{				
				return false;
			}
		}

		private void DeleteRow()
		{
			if (facadeCustomerDept.DeleteCustomerDepartment(SelectedCustomerDept))
			{
				if(fpsCustomerDept_Sheet1.RowCount > 1)
				{
					fpsCustomerDept.ActiveSheet.Rows.Remove(SelectedRow,1);
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
			return facadeCustomerDept.ObjCustomerDepartmentList.Count;
		}

//		============================== Base Event ==============================
		public void InitForm()
		{
			clearMainMenuStatus();

			mdiParent.EnableNewCommand(false);
			mdiParent.EnableDeleteCommand(false);
			mdiParent.EnableRefreshCommand(false);
			mdiParent.EnablePrintCommand(false);
			mdiParent.EnableExitCommand(true);

			newObject();
			clearForm();
			enableCase(true);
			hideCase();
			enableButtonAll(false);
			txtCustomerName.Focus();
			mdiParent.RefreshMasterCount();
		}

		public void RefreshForm()
		{
			try
			{
				MainMenuNewStatus = true;
				MainMenuDeleteStatus = false;
				MainMenuRefreshStatus = true;
				MainMenuPrintStatus = true;

				mdiParent.EnableNewCommand(true);
				mdiParent.EnableDeleteCommand(false);
				mdiParent.EnableRefreshCommand(true);
				mdiParent.EnablePrintCommand(true);
				mdiParent.EnableExitCommand(true);
				Customer cboItem = (Customer)txtCustomerName.SelectedItem;
				if (facadeCustomerDept.DisplayCustomerDepartment(cboItem.Code))
				{				
					enableButtonAll(true);
					txtCustomerName.Text = Customer.AName.Thai;
				}
				else
				{
					clearForm();
					enableButton2(true);
				}
				enableCase(false);
				showCase();
				bindForm();
			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(AppExceptionBase ex)
			{
				Message(ex);

				hideCase();
				enableCase(true);
			}
			catch(Exception ex)
			{
				Message(ex);
			}
			finally
			{
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
			frmListofCustomerDepartment objform = new frmListofCustomerDepartment();
			objform.Show();
		}

		public void ExitForm()
		{
			Dispose(true);
		}

		private void AddEvent()
		{
			try
			{
				frmEntry = new frmCustomerDeptEntry(this);
				frmEntry.InitAddAction();
				frmEntry.CustomerDeptCodeFocus();
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
			finally
			{
			}
		}

		private void EditEvent()
		{
			try
			{
				frmEntry = new frmCustomerDeptEntry(this);
				frmEntry.InitEditAction(SelectedCustomerDept);
				frmEntry.CustomerDeptShortNameFocus();
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
			finally
			{
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
			finally
			{
			}
		}
//		============================== event ==============================
		private void cmdShow_Click(object sender, System.EventArgs e)
		{
			if (txtCustomerName.Text == "")
			{
				Message(MessageList.Error.E0005, "ลูกค้า");
				txtCustomerName.Focus();	

			}
			else
			{
				RefreshForm();			
			}		
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

		private void fpsCustomerDept_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader)
			{
				EditEvent();		
			}
		}

		private void frmCustomerDept_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
		}
	}
}
