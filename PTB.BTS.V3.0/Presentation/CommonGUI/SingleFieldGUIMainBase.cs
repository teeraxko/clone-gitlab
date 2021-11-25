using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using Entity.CommonEntity;

using Facade.CommonFacade;

using SystemFramework.AppMessage;
using SystemFramework.AppException;

using ictus.Common.Entity.General;

namespace Presentation.CommonGUI
{
	public class SingleFieldGUIMainBase : ChildFormBase, IMDIChildForm
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
		private System.Windows.Forms.MenuItem mniDelete;
		private System.Windows.Forms.Button cmdDelete;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem mniAdd;
		private System.Windows.Forms.MenuItem mniEdit;
		private System.Windows.Forms.Button cmdEdit;
		private System.Windows.Forms.Button cmdAdd;
		protected FarPoint.Win.Spread.FpSpread fpsSingleField;
		protected FarPoint.Win.Spread.SheetView fpsSingleField_Sheet1;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.fpsSingleField = new FarPoint.Win.Spread.FpSpread();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mniAdd = new System.Windows.Forms.MenuItem();
			this.mniEdit = new System.Windows.Forms.MenuItem();
			this.fpsSingleField_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdAdd = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.fpsSingleField)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsSingleField_Sheet1)).BeginInit();
			this.SuspendLayout();
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
			this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdDelete.Location = new System.Drawing.Point(284, 248);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.TabIndex = 18;
			this.cmdDelete.Text = "ลบ";
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			// 
			// fpsSingleField
			// 
			this.fpsSingleField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsSingleField.ContextMenu = this.contextMenu1;
			this.fpsSingleField.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.fpsSingleField.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsSingleField.Location = new System.Drawing.Point(35, 16);
			this.fpsSingleField.Name = "fpsSingleField";
			this.fpsSingleField.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																						this.fpsSingleField_Sheet1});
			this.fpsSingleField.Size = new System.Drawing.Size(413, 216);
			this.fpsSingleField.TabIndex = 19;
			this.fpsSingleField.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsSingleField_CellDoubleClick);
            this.fpsSingleField.ClipboardOptions = FarPoint.Win.Spread.ClipboardOptions.AllHeaders;
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
			// fpsSingleField_Sheet1
			// 
			this.fpsSingleField_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsSingleField_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsSingleField_Sheet1.ColumnCount = 1;
			this.fpsSingleField_Sheet1.RowCount = 0;
			this.fpsSingleField_Sheet1.Columns.Get(0).AllowAutoSort = true;
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsSingleField_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsSingleField_Sheet1.Columns.Get(0).Resizable = false;
			this.fpsSingleField_Sheet1.Columns.Get(0).Width = 356F;
			this.fpsSingleField_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.Normal;
			this.fpsSingleField_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsSingleField_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.MultiRange;
			this.fpsSingleField_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsSingleField_Sheet1.SheetName = "Sheet1";
			this.fpsSingleField_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// cmdEdit
			// 
			this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdEdit.Location = new System.Drawing.Point(204, 248);
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.TabIndex = 17;
			this.cmdEdit.Text = "แก้ไข";
			this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
			// 
			// cmdAdd
			// 
			this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdAdd.Location = new System.Drawing.Point(124, 248);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.TabIndex = 16;
			this.cmdAdd.Text = "เพิ่ม";
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			// 
			// SingleFieldGUIMainBase
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(482, 286);
			this.Controls.Add(this.cmdEdit);
			this.Controls.Add(this.cmdAdd);
			this.Controls.Add(this.cmdDelete);
			this.Controls.Add(this.fpsSingleField);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "SingleFieldGUIMainBase";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.SingleFieldGUIBase_Load);
			((System.ComponentModel.ISupportInitialize)(this.fpsSingleField)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsSingleField_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private - 
			protected bool isReadonly = false;
			protected SingleFieldGUIEntryBase frmEntry;
			protected MTBFacadeBase facadeMTB;
			protected frmMain mdiParent;

			public MTBFacadeBase FacadeMTB
			{
				get
				{
					return facadeMTB;
				}
			}

			protected string columnName
			{
				set
				{
					this.fpsSingleField_Sheet1.Columns.Get(0).Label = value;
				}
			}

			protected int SelectedRow
			{
				get
				{
					return fpsSingleField_Sheet1.ActiveRowIndex;
				}
			}

			protected string SelectedKey
			{
				get
				{
					return fpsSingleField_Sheet1.Cells[SelectedRow,0].Text;
				}
			}

			private SingleFieldBase SelectedSingleField
			{
				get
				{
					return (SingleFieldBase) facadeMTB.ObjList.BaseGet(SelectedKey.Trim());
				}
			}
		#endregion

//		============================== Property ==============================


//		============================== Constructor ==============================
		public SingleFieldGUIMainBase() : base()
		{
			InitializeComponent();
		}

//		============================== Private Method ==============================
        private void bindSingle(int row, ictus.Common.Entity.General.SingleFieldBase value)
		{
			fpsSingleField_Sheet1.Cells[row, 0].Text = GUIFunction.GetString(value.Name);
		}
		
		private void bindForm()
		{
			if (facadeMTB.ObjList != null)
			{
				int iRow = facadeMTB.ObjList.Count;

				fpsSingleField_Sheet1.RowCount = iRow;
				for(int i=0; i<iRow; i++)
				{
					bindSingle(i, (SingleFieldBase)facadeMTB.ObjList.BaseGet(i));
				}
			}
            fpsSingleField_Sheet1.SetActiveCell(fpsSingleField_Sheet1.RowCount, 0);
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
			fpsSingleField_Sheet1.RowCount = 0;
			enableButton(false);
		}
//		============================== Public Method ==============================
        public bool AddRow(ictus.Common.Entity.General.SingleFieldBase aSingleFieldBase)
		{
			if (facadeMTB.InsertMTB(aSingleFieldBase))
			{
				fpsSingleField_Sheet1.RowCount++;
				bindSingle(fpsSingleField_Sheet1.RowCount-1,aSingleFieldBase);
                fpsSingleField_Sheet1.SetActiveCell(fpsSingleField_Sheet1.RowCount, 0);
				enableButton(true);
				return true;
			}
			else
			{				
				return false;
			}
		}

        public bool UpdateRow(ictus.Common.Entity.General.SingleFieldBase aSingleFieldBase)
		{
			if(facadeMTB.ObjList.Contain(aSingleFieldBase))
			{
				if (facadeMTB.UpdateMTB(aSingleFieldBase))
				{
					bindSingle(SelectedRow, aSingleFieldBase);				
					return true;
				}
				else
				{				
					return false;
				}	
			}
			else
			{
				if (facadeMTB.UpdateMTB(aSingleFieldBase,SelectedSingleField))
				{
					bindSingle(SelectedRow, aSingleFieldBase);				
					return true;
				}
				else
				{				
					return false;
				}			
			}
		}

		public void DeleteRow()
		{
			if (facadeMTB.DeleteMTB(SelectedSingleField))
			{
				if(fpsSingleField_Sheet1.RowCount > 1)
				{
					fpsSingleField.ActiveSheet.Rows.Remove(SelectedRow,1);
				}
				else
				{
					clearForm();
				}				
			}
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
			clearMainMenuStatus();
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
			finally
			{
				frmEntry.SetFocus();
			}
		}

		private void EditEvent()
		{
			try
			{
				frmEntry.InitEditAction(SelectedSingleField);
				frmEntry.ShowDialog();
				frmEntry.SetFocus();
			
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

        public override int MasterCount()
        {
            return facadeMTB.ObjList.Count;
        }

//		============================== event ==============================

		private void SingleFieldGUIBase_Load(object sender, System.EventArgs e)
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


		private void fpsSingleField_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader)
			{
				EditEvent();
			}
		}		
	}
}
