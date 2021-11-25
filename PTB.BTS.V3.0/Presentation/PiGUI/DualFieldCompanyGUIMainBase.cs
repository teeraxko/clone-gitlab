using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using Entity.CommonEntity;

using Facade.CommonFacade;
using Facade.PiFacade;

using Presentation.CommonGUI;

using SystemFramework.AppMessage;
using SystemFramework.AppException;

using ictus.Common.Entity.General;

namespace Presentation.PiGUI
{
	public class DualFieldCompanyGUIMainBase : ChildFormBase, IMDIChildForm
	{
		#region - Private - 
		protected bool isReadonly = false;
		protected DualFieldCompanyGUIEntryBase frmEntry;
		protected frmMain mdiParent;

		protected int SelectedRow
		{
			get
			{
				return fpsDualField_Sheet1.ActiveRowIndex;
			}
		}

		protected string SelectedKey
		{
			get
			{
				return fpsDualField_Sheet1.Cells[SelectedRow,0].Text;
			}
		}

		protected DualFieldBase SelectedDualField
		{
			get
			{
				return (DualFieldBase) facadeMTB.ObjList.BaseGet(SelectedKey);
			}
		}
		#endregion

		#region Windows Form Designer generated code
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem mniAdd;
		private System.Windows.Forms.MenuItem mniEdit;
		private System.Windows.Forms.MenuItem mniDelete;
		private System.Windows.Forms.Button cmdAdd;
		private System.Windows.Forms.Button cmdEdit;
		private System.Windows.Forms.Button cmdDelete;
		private FarPoint.Win.Spread.FpSpread fpsDualField;
		private FarPoint.Win.Spread.SheetView fpsDualField_Sheet1;
//		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mniAdd = new System.Windows.Forms.MenuItem();
			this.mniEdit = new System.Windows.Forms.MenuItem();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.fpsDualField = new FarPoint.Win.Spread.FpSpread();
			this.fpsDualField_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.cmdDelete = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.fpsDualField)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsDualField_Sheet1)).BeginInit();
			this.SuspendLayout();
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
			// cmdAdd
			// 
			this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdAdd.Location = new System.Drawing.Point(276, 200);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.Size = new System.Drawing.Size(72, 24);
			this.cmdAdd.TabIndex = 20;
			this.cmdAdd.Text = "เพิ่ม";
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			// 
			// cmdEdit
			// 
			this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdEdit.Location = new System.Drawing.Point(356, 200);
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.Size = new System.Drawing.Size(72, 24);
			this.cmdEdit.TabIndex = 21;
			this.cmdEdit.Text = "แก้ไข";
			this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
			// 
			// fpsDualField
			// 
			this.fpsDualField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsDualField.ContextMenu = this.contextMenu1;
			this.fpsDualField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.fpsDualField.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsDualField.Location = new System.Drawing.Point(11, 16);
			this.fpsDualField.Name = "fpsDualField";
			this.fpsDualField.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																					  this.fpsDualField_Sheet1});
			this.fpsDualField.Size = new System.Drawing.Size(756, 168);
			this.fpsDualField.TabIndex = 23;
			this.fpsDualField.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsDualField_CellDoubleClick);
			// 
			// fpsDualField_Sheet1
			// 
			this.fpsDualField_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsDualField_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsDualField_Sheet1.ColumnCount = 3;
			this.fpsDualField_Sheet1.RowCount = 0;
			this.fpsDualField_Sheet1.ColumnHeader.Columns.Default.Resizable = false;
			this.fpsDualField_Sheet1.Columns.Default.Resizable = false;
			this.fpsDualField_Sheet1.Columns.Get(0).AllowAutoSort = true;
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsDualField_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsDualField_Sheet1.Columns.Get(0).Width = 80F;
			this.fpsDualField_Sheet1.Columns.Get(1).AllowAutoSort = true;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			this.fpsDualField_Sheet1.Columns.Get(1).CellType = textCellType2;
			this.fpsDualField_Sheet1.Columns.Get(1).Width = 310F;
			this.fpsDualField_Sheet1.Columns.Get(2).AllowAutoSort = true;
			textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType3.DropDownButton = false;
			this.fpsDualField_Sheet1.Columns.Get(2).CellType = textCellType3;
			this.fpsDualField_Sheet1.Columns.Get(2).Width = 310F;
			this.fpsDualField_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
			this.fpsDualField_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsDualField_Sheet1.RowHeader.Rows.Default.Resizable = false;
			this.fpsDualField_Sheet1.Rows.Default.Resizable = false;
			this.fpsDualField_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
			this.fpsDualField_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsDualField_Sheet1.SheetName = "Sheet1";
			this.fpsDualField_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// cmdDelete
			// 
			this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdDelete.Location = new System.Drawing.Point(436, 200);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.Size = new System.Drawing.Size(72, 24);
			this.cmdDelete.TabIndex = 22;
			this.cmdDelete.Text = "ลบ";
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			// 
			// DualFieldCompanyGUIMainBase
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(778, 240);
			this.Controls.Add(this.fpsDualField);
			this.Controls.Add(this.cmdDelete);
			this.Controls.Add(this.cmdAdd);
			this.Controls.Add(this.cmdEdit);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "DualFieldCompanyGUIMainBase";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.DualFieldCompanyGUIMainBase_Load);
			((System.ComponentModel.ISupportInitialize)(this.fpsDualField)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsDualField_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

//		============================== Property ==============================
		protected MTBCompanyFacadeBase facadeMTB;	
		public MTBCompanyFacadeBase FacadeMTB
		{
			get
			{
				return facadeMTB;
			}
		}

		protected string columnCode
		{
			set
			{
				this.fpsDualField_Sheet1.Columns.Get(0).Label = value;
			}
		}

		protected string columnTHName
		{
			set
			{
				this.fpsDualField_Sheet1.Columns.Get(1).Label = value;
				
			}
		}
		protected string columnENName
		{
			set
			{
				this.fpsDualField_Sheet1.Columns.Get(2).Label = value;
				
			}
		}

//		============================== Constructor ==============================
		public DualFieldCompanyGUIMainBase() : base()
		{
			InitializeComponent();
		}

//		============================== Private Method ==============================
		private void bindDualField(int row, DualFieldBase value)
		{
			fpsDualField_Sheet1.Cells[row, 0].Text = GUIFunction.GetString(value.Code);	
			fpsDualField_Sheet1.Cells[row, 1].Text = GUIFunction.GetString(value.AName.Thai);	
			fpsDualField_Sheet1.Cells[row, 2].Text = GUIFunction.GetString(value.AName.English);			
		}

		private void bindForm()
		{
			if (facadeMTB.ObjList != null)
			{
				int iRow = facadeMTB.ObjList.Count;

				fpsDualField_Sheet1.RowCount = iRow;
				for(int i=0; i<iRow; i++)
				{
					bindDualField(i, (DualFieldBase)facadeMTB.ObjList.BaseGet(i));
				}				
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
			fpsDualField_Sheet1.RowCount = 0;
			enableButton(false);
		}

//		============================== Public Method ==============================
		public virtual bool AddRow(DualFieldBase aDualFieldBase)
		{
			if(facadeMTB.InsertMTB(aDualFieldBase))
			{
				fpsDualField_Sheet1.RowCount++;
				bindDualField(fpsDualField_Sheet1.RowCount-1,aDualFieldBase);
				enableButton(true);
				mdiParent.RefreshMasterCount();
				return true;
			}
			else
			{
				return false;
			}
			
		}

		public virtual bool UpdateRow(DualFieldBase aDualFieldBase)
		{			
			if (facadeMTB.UpdateMTB(aDualFieldBase))
			{
				bindDualField(SelectedRow, aDualFieldBase);				
				return true;
			}
			else
			{				
				return false;
			}
		}

		public void DeleteRow()
		{
			if (facadeMTB.DeleteMTB(SelectedDualField))
			{
				if(fpsDualField_Sheet1.RowCount > 1)
				{
					fpsDualField.ActiveSheet.Rows.Remove(SelectedRow,1);
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
			return facadeMTB.ObjList.Count;
		}

		//		============================== Base Event ==============================
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

			facadeMTB.ObjList.Clear();
			try
			{
				if (facadeMTB.DisplayMTB())
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

		public virtual void PrintForm()
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
				frmEntry.InitFocusCode();
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
				frmEntry.InitEditAction(SelectedDualField);
				frmEntry.InitFocusTHName();
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
		private void DualFieldCompanyGUIMainBase_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
		}

		private void fpsDualField_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader)
			{
				EditEvent();
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

	}
}
