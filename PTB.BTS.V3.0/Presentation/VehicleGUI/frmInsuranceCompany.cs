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
	public class frmInsuranceCompany : ChildFormBase, IMDIChildForm
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
		private System.Windows.Forms.MenuItem mniEdit;
		private System.Windows.Forms.MenuItem mniDelete;
		private System.Windows.Forms.Button cmdEdit;
		private System.Windows.Forms.MenuItem mniAdd;
		private System.Windows.Forms.Button cmdAdd;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private FarPoint.Win.Spread.SheetView fpsInsuranceCompany_Sheet1;
		private FarPoint.Win.Spread.FpSpread fpsInsuranceCompany;

		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.mniEdit = new System.Windows.Forms.MenuItem();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.fpsInsuranceCompany_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.mniAdd = new System.Windows.Forms.MenuItem();
			this.fpsInsuranceCompany = new FarPoint.Win.Spread.FpSpread();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.cmdAdd = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.fpsInsuranceCompany_Sheet1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsInsuranceCompany)).BeginInit();
			this.SuspendLayout();
			// 
			// cmdDelete
			// 
			this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdDelete.Location = new System.Drawing.Point(407, 432);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.TabIndex = 7;
			this.cmdDelete.Text = "ลบ";
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			// 
			// mniEdit
			// 
			this.mniEdit.Index = 1;
			this.mniEdit.Text = "แก้ไข           ";
			this.mniEdit.Click += new System.EventHandler(this.mniEdit_Click);
			// 
			// mniDelete
			// 
			this.mniDelete.Index = 2;
			this.mniDelete.Text = "ลบ";
			this.mniDelete.Click += new System.EventHandler(this.mniDelete_Click);
			// 
			// cmdEdit
			// 
			this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdEdit.Location = new System.Drawing.Point(327, 432);
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.TabIndex = 6;
			this.cmdEdit.Text = "แก้ไข";
			this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
			// 
			// fpsInsuranceCompany_Sheet1
			// 
			this.fpsInsuranceCompany_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsInsuranceCompany_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsInsuranceCompany_Sheet1.ColumnCount = 4;
			this.fpsInsuranceCompany_Sheet1.RowCount = 0;
			this.fpsInsuranceCompany_Sheet1.ColumnHeader.Cells.Get(0, 1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.fpsInsuranceCompany_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "รหัสบริษัทประกันภัย";
			this.fpsInsuranceCompany_Sheet1.ColumnHeader.Cells.Get(0, 2).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.fpsInsuranceCompany_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "ชื่อบริษัทประกันภัย(ภาษาไทย)";
			this.fpsInsuranceCompany_Sheet1.ColumnHeader.Cells.Get(0, 3).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.fpsInsuranceCompany_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ชื่อบริษัทประกันภัย(ภาษาอังกฤษ)";
			this.fpsInsuranceCompany_Sheet1.ColumnHeader.Columns.Default.Resizable = false;
			this.fpsInsuranceCompany_Sheet1.Columns.Default.Resizable = false;
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsInsuranceCompany_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsInsuranceCompany_Sheet1.Columns.Get(0).Visible = false;
			this.fpsInsuranceCompany_Sheet1.Columns.Get(1).AllowAutoSort = true;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			this.fpsInsuranceCompany_Sheet1.Columns.Get(1).CellType = textCellType2;
			this.fpsInsuranceCompany_Sheet1.Columns.Get(1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.fpsInsuranceCompany_Sheet1.Columns.Get(1).Label = "รหัสบริษัทประกันภัย";
			this.fpsInsuranceCompany_Sheet1.Columns.Get(1).Width = 120F;
			this.fpsInsuranceCompany_Sheet1.Columns.Get(2).AllowAutoSort = true;
			textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType3.DropDownButton = false;
			this.fpsInsuranceCompany_Sheet1.Columns.Get(2).CellType = textCellType3;
			this.fpsInsuranceCompany_Sheet1.Columns.Get(2).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.fpsInsuranceCompany_Sheet1.Columns.Get(2).Label = "ชื่อบริษัทประกันภัย(ภาษาไทย)";
			this.fpsInsuranceCompany_Sheet1.Columns.Get(2).Width = 250F;
			this.fpsInsuranceCompany_Sheet1.Columns.Get(3).AllowAutoSort = true;
			textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType4.DropDownButton = false;
			this.fpsInsuranceCompany_Sheet1.Columns.Get(3).CellType = textCellType4;
			this.fpsInsuranceCompany_Sheet1.Columns.Get(3).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.fpsInsuranceCompany_Sheet1.Columns.Get(3).Label = "ชื่อบริษัทประกันภัย(ภาษาอังกฤษ)";
			this.fpsInsuranceCompany_Sheet1.Columns.Get(3).Width = 250F;
			this.fpsInsuranceCompany_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
			this.fpsInsuranceCompany_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsInsuranceCompany_Sheet1.RowHeader.Rows.Default.Resizable = false;
			this.fpsInsuranceCompany_Sheet1.Rows.Default.Resizable = false;
			this.fpsInsuranceCompany_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
			this.fpsInsuranceCompany_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsInsuranceCompany_Sheet1.SheetName = "Sheet1";
			this.fpsInsuranceCompany_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// mniAdd
			// 
			this.mniAdd.Index = 0;
			this.mniAdd.Text = "เพิ่ม";
			this.mniAdd.Click += new System.EventHandler(this.mniAdd_Click);
			// 
			// fpsInsuranceCompany
			// 
			this.fpsInsuranceCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsInsuranceCompany.ContextMenu = this.contextMenu1;
			this.fpsInsuranceCompany.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsInsuranceCompany.Location = new System.Drawing.Point(25, 24);
			this.fpsInsuranceCompany.Name = "fpsInsuranceCompany";
			this.fpsInsuranceCompany.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																							 this.fpsInsuranceCompany_Sheet1});
			this.fpsInsuranceCompany.Size = new System.Drawing.Size(678, 392);
			this.fpsInsuranceCompany.TabIndex = 4;
			this.fpsInsuranceCompany.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsInsuranceCompany_CellDoubleClick);
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.mniAdd,
																						 this.mniEdit,
																						 this.mniDelete});
			// 
			// cmdAdd
			// 
			this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdAdd.Location = new System.Drawing.Point(247, 432);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.TabIndex = 5;
			this.cmdAdd.Text = "เพิ่ม";
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			// 
			// frmInsuranceCompany
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(728, 462);
			this.Controls.Add(this.fpsInsuranceCompany);
			this.Controls.Add(this.cmdAdd);
			this.Controls.Add(this.cmdDelete);
			this.Controls.Add(this.cmdEdit);
			this.Name = "frmInsuranceCompany";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //this.Text = "ข้อมูลบริษัทประกันภัย";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmInsuranceCompany_Load);
			this.Closed += new System.EventHandler(this.frmInsuranceCompany_Closed);
			((System.ComponentModel.ISupportInitialize)(this.fpsInsuranceCompany_Sheet1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsInsuranceCompany)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private frmInsuranceCompanyEntry frmEntry;
		private frmMain mdiParent;

		private int SelectedRow
		{
			get{return fpsInsuranceCompany_Sheet1.ActiveRowIndex;}
		}

		private string SelectedKey
		{
			get{return fpsInsuranceCompany_Sheet1.Cells[SelectedRow,0].Text;}
		}

		private InsuranceCompany SelectedInsuranceCompany
		{
			get{return facadeInsuranceCompany.ObjInsuranceCompanyList[SelectedKey];}
		}
		#endregion

		//		============================== Property ==============================
		private InsuranceCompanyFacade facadeInsuranceCompany;
		public InsuranceCompanyFacade FacadeInsuranceCompany
		{
			get
			{
				return facadeInsuranceCompany;
			}
		}

		//		============================== Constructor ==============================
		public frmInsuranceCompany(): base()
		{
			InitializeComponent();
			newObject();
			isReadonly = UserProfile.IsReadOnly("miVehicle", "miVehicleDocumentInsurance");
            this.title = UserProfile.GetFormName("miVehicle", "miVehicleDocumentInsurance");

			try
			{						
				frmEntry.ObjInsuranceCompanyFacade = facadeInsuranceCompany;
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
            return UserProfile.GetFormID("miVehicle", "miVehicleDocumentInsurance");
        }

		public void newObject()
		{
			facadeInsuranceCompany = new InsuranceCompanyFacade();
			frmEntry = new frmInsuranceCompanyEntry(this);
		}

		//		============================== Private Method ==============================
		private void bindInsuranceCompany(int i,InsuranceCompany aInsuranceCompany)
		{
			fpsInsuranceCompany_Sheet1.Cells.Get(i,0).Text = GUIFunction.GetString(aInsuranceCompany.EntityKey);
			fpsInsuranceCompany_Sheet1.Cells.Get(i,1).Text = GUIFunction.GetString(aInsuranceCompany.Code);
			fpsInsuranceCompany_Sheet1.Cells.Get(i,2).Text = GUIFunction.GetString(aInsuranceCompany.AName.Thai);
			fpsInsuranceCompany_Sheet1.Cells.Get(i,3).Text = GUIFunction.GetString(aInsuranceCompany.AName.English);
		}
		private void bindForm()
		{
			this.fpsInsuranceCompany_Sheet1.RowCount = facadeInsuranceCompany.ObjInsuranceCompanyList.Count;
			if (facadeInsuranceCompany.ObjInsuranceCompanyList != null)
			{
				for(int iRow=0; iRow < facadeInsuranceCompany.ObjInsuranceCompanyList.Count; iRow++)
				{
					bindInsuranceCompany(iRow,facadeInsuranceCompany.ObjInsuranceCompanyList[iRow]);
				}				
			}
            fpsInsuranceCompany_Sheet1.SetActiveCell(fpsInsuranceCompany_Sheet1.RowCount, 0);
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
			fpsInsuranceCompany_Sheet1.RowCount = 0;
			enableButton(false);
		}

		//		============================= Public Method ==============================
		public bool AddRow(InsuranceCompany aInsuranceCompany)
		{
			if (facadeInsuranceCompany.InsertInsuranceCompany(aInsuranceCompany))
			{
				fpsInsuranceCompany_Sheet1.RowCount++;
				bindInsuranceCompany(fpsInsuranceCompany_Sheet1.RowCount-1,aInsuranceCompany);
                fpsInsuranceCompany_Sheet1.SetActiveCell(fpsInsuranceCompany_Sheet1.RowCount, 0);
				enableButton(true);
				mdiParent.RefreshMasterCount();
				return true;
			}
			else
			{				
				return false;
			}
		}
		public bool UpdateRow(InsuranceCompany aInsuranceCompany)
		{
			if (facadeInsuranceCompany.UpdateInsuranceCompany(aInsuranceCompany))
			{
				bindInsuranceCompany(SelectedRow, aInsuranceCompany);				
				return true;
			}
			else
			{				
				return false;
			}
		}
		private void DeleteRow()
		{
			if (facadeInsuranceCompany.DeleteInsuranceCompany(SelectedInsuranceCompany))
			{
				if(fpsInsuranceCompany_Sheet1.RowCount > 1)
				{
					fpsInsuranceCompany_Sheet1.Rows.Remove(SelectedRow,1);
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
			return facadeInsuranceCompany.ObjInsuranceCompanyList.Count;
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
			if (facadeInsuranceCompany.DisplayInsuranceCompany())
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
				frmEntry = new frmInsuranceCompanyEntry(this);
				frmEntry.InitAddAction();
				frmEntry.InsuranceCompanyCodeFocus();
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
				frmEntry = new frmInsuranceCompanyEntry(this);
				frmEntry.InitEditAction(SelectedInsuranceCompany);
				frmEntry.InsuranceCompanyTHNameFocus();
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

		//		============================== Event ===============================
		private void frmInsuranceCompany_Load(object sender, System.EventArgs e)
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
		private void fpsInsuranceCompany_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader)
			{
				EditEvent();
			}
		}
		private void frmInsuranceCompany_Closed(object sender, System.EventArgs e)
		{
			ExitForm();
		}	
	}
}
