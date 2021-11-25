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

using Facade.CommonFacade;
using Facade.AttendanceFacade;

using Presentation.CommonGUI;

namespace Presentation.AttendanceGUI
{
	public class frmTelephoneCondition : ChildFormBase, IMDIChildForm
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
		private FarPoint.Win.Spread.FpSpread fpsTelephone;
		private FarPoint.Win.Spread.SheetView fpsTelephone_Sheet1;
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
			FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
			this.fpsTelephone = new FarPoint.Win.Spread.FpSpread();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mniAdd = new System.Windows.Forms.MenuItem();
			this.mniEdit = new System.Windows.Forms.MenuItem();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			this.fpsTelephone_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdAdd = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.fpsTelephone)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsTelephone_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// fpsTelephone
			// 
			this.fpsTelephone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsTelephone.ContextMenu = this.contextMenu1;
			this.fpsTelephone.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsTelephone.Location = new System.Drawing.Point(23, 24);
			this.fpsTelephone.Name = "fpsTelephone";
			this.fpsTelephone.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																					  this.fpsTelephone_Sheet1});
			this.fpsTelephone.Size = new System.Drawing.Size(786, 392);
			this.fpsTelephone.TabIndex = 0;
			this.fpsTelephone.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsTelephone_CellDoubleClick);
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
			this.mniAdd.Text = "‡æ‘Ë¡";
			this.mniAdd.Click += new System.EventHandler(this.mniAdd_Click);
			// 
			// mniEdit
			// 
			this.mniEdit.Index = 1;
			this.mniEdit.Text = "·°È‰¢";
			this.mniEdit.Click += new System.EventHandler(this.mniEdit_Click);
			// 
			// mniDelete
			// 
			this.mniDelete.Index = 2;
			this.mniDelete.Text = "≈∫";
			this.mniDelete.Click += new System.EventHandler(this.mniDelete_Click);
			// 
			// fpsTelephone_Sheet1
			// 
			this.fpsTelephone_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsTelephone_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsTelephone_Sheet1.ColumnCount = 5;
			this.fpsTelephone_Sheet1.RowCount = 1;
			this.fpsTelephone_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "™◊ËÕ -  °ÿ≈";
			this.fpsTelephone_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "√À— ";
			this.fpsTelephone_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = " Ë«πß“π";
			this.fpsTelephone_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "§Ë“‚∑√»—æ∑Ï";
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsTelephone_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsTelephone_Sheet1.Columns.Get(0).Visible = false;
			this.fpsTelephone_Sheet1.Columns.Get(1).AllowAutoSort = true;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			textCellType2.ReadOnly = true;
			textCellType2.Static = true;
			this.fpsTelephone_Sheet1.Columns.Get(1).CellType = textCellType2;
			this.fpsTelephone_Sheet1.Columns.Get(1).Label = "™◊ËÕ -  °ÿ≈";
			this.fpsTelephone_Sheet1.Columns.Get(1).Locked = true;
			this.fpsTelephone_Sheet1.Columns.Get(1).Resizable = false;
			this.fpsTelephone_Sheet1.Columns.Get(1).Width = 250F;
			this.fpsTelephone_Sheet1.Columns.Get(2).AllowAutoSort = true;
			textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType3.DropDownButton = false;
			textCellType3.ReadOnly = true;
			textCellType3.Static = true;
			this.fpsTelephone_Sheet1.Columns.Get(2).CellType = textCellType3;
			this.fpsTelephone_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsTelephone_Sheet1.Columns.Get(2).Label = "√À— ";
			this.fpsTelephone_Sheet1.Columns.Get(2).Locked = true;
			this.fpsTelephone_Sheet1.Columns.Get(2).Resizable = false;
			this.fpsTelephone_Sheet1.Columns.Get(2).Width = 80F;
			this.fpsTelephone_Sheet1.Columns.Get(3).AllowAutoSort = true;
			textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType4.DropDownButton = false;
			this.fpsTelephone_Sheet1.Columns.Get(3).CellType = textCellType4;
			this.fpsTelephone_Sheet1.Columns.Get(3).Label = " Ë«πß“π";
			this.fpsTelephone_Sheet1.Columns.Get(3).Resizable = false;
			this.fpsTelephone_Sheet1.Columns.Get(3).Width = 281F;
			this.fpsTelephone_Sheet1.Columns.Get(4).AllowAutoSort = true;
			numberCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			numberCellType1.DecimalPlaces = 0;
			numberCellType1.DropDownButton = false;
			numberCellType1.MaximumValue = 9999.99;
			numberCellType1.MinimumValue = 0;
			numberCellType1.Separator = ",";
			numberCellType1.ShowSeparator = true;
			this.fpsTelephone_Sheet1.Columns.Get(4).CellType = numberCellType1;
			this.fpsTelephone_Sheet1.Columns.Get(4).Label = "§Ë“‚∑√»—æ∑Ï";
			this.fpsTelephone_Sheet1.Columns.Get(4).Locked = true;
			this.fpsTelephone_Sheet1.Columns.Get(4).Resizable = false;
			this.fpsTelephone_Sheet1.Columns.Get(4).Width = 120F;
			this.fpsTelephone_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
			this.fpsTelephone_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsTelephone_Sheet1.RowHeader.Rows.Default.Resizable = false;
			this.fpsTelephone_Sheet1.Rows.Default.Resizable = false;
			this.fpsTelephone_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsTelephone_Sheet1.SheetName = "Sheet1";
			this.fpsTelephone_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// cmdDelete
			// 
			this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.cmdDelete.Location = new System.Drawing.Point(459, 440);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.TabIndex = 3;
			this.cmdDelete.Text = "≈∫";
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			// 
			// cmdEdit
			// 
			this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.cmdEdit.Location = new System.Drawing.Point(379, 440);
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.TabIndex = 2;
			this.cmdEdit.Text = "·°È‰¢";
			this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
			// 
			// cmdAdd
			// 
			this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.cmdAdd.Location = new System.Drawing.Point(299, 440);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.TabIndex = 1;
			this.cmdAdd.Text = "‡æ‘Ë¡";
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			// 
			// frmTelephoneCondition
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(832, 477);
			this.Controls.Add(this.cmdDelete);
			this.Controls.Add(this.cmdEdit);
			this.Controls.Add(this.cmdAdd);
			this.Controls.Add(this.fpsTelephone);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmTelephoneCondition";
            //this.Text = "°”Àπ¥‡ß◊ËÕπ‰¢§Ë“‚∑√»—æ∑Ï";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmTelephoneCondition_Load);
			((System.ComponentModel.ISupportInitialize)(this.fpsTelephone)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsTelephone_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private frmTelephoneConditionEntry frmEntry;
		private frmMain mdiParent;
		#endregion

//		============================== Property ==============================		
		private TelephoneConditionFacade facadeTelephoneCondition;
		public TelephoneConditionFacade FacadeTelephoneCondition
		{
			get{return facadeTelephoneCondition;}
		}

		private int SelectedRow
		{
			get{return fpsTelephone_Sheet1.ActiveRowIndex;}
		}

		private string SelectedKey
		{
			get{return fpsTelephone_Sheet1.Cells[SelectedRow,0].Text;}
		}

		private TelephoneCondition SelectedTelephoneCondition
		{
			get{return facadeTelephoneCondition.ObjTelephoneConditionList[SelectedKey];}
		}

//		============================== Constructor ==============================
		public frmTelephoneCondition() : base()
		{
			InitializeComponent();
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miTelephoneCondition");
            this.title = UserProfile.GetFormName("miAttendance", "miTelephoneCondition");

		}
        public override string FormID()
        {
            return UserProfile.GetFormID("miAttendance", "miTelephoneCondition");
        }

//		==============================Private method ==============================
		private void newObject()
		{
			facadeTelephoneCondition = new TelephoneConditionFacade();
			frmEntry = new frmTelephoneConditionEntry(this);
		}

		private void bindTelephoneCondition(int row, TelephoneCondition value)
		{
			fpsTelephone_Sheet1.Cells[row,0].Text = value.EntityKey;
			fpsTelephone_Sheet1.Cells[row,1].Text = GUIFunction.GetString(value.AEmployee.EmployeeName);
			fpsTelephone_Sheet1.Cells[row,2].Text = GUIFunction.GetString(value.AEmployee.EmployeeNo);
			fpsTelephone_Sheet1.Cells[row,3].Text = GUIFunction.GetString(value.AEmployee.ASection.AFullName.English);
			fpsTelephone_Sheet1.Cells[row,4].Text = GUIFunction.GetString(value.TelephoneRate);
		}

		private void bindForm()
		{
			if (facadeTelephoneCondition.ObjTelephoneConditionList != null)
			{
				int iRow = facadeTelephoneCondition.ObjTelephoneConditionList.Count;
				fpsTelephone_Sheet1.RowCount = iRow;
				for(int i=0; i<iRow; i++)
				{
					bindTelephoneCondition(i, facadeTelephoneCondition.ObjTelephoneConditionList[i]);
				}	
				mdiParent.RefreshMasterCount();
			}
            fpsTelephone_Sheet1.SetActiveCell(fpsTelephone_Sheet1.RowCount, 0);
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
			fpsTelephone_Sheet1.RowCount = 0;
			enableButton(false);
		}	

//		============================== Public method ==============================
		public bool AddRow(TelephoneCondition value)
		{
			if (facadeTelephoneCondition.InsertTelephoneCondition(value))
			{
				fpsTelephone_Sheet1.RowCount++;
				bindTelephoneCondition(fpsTelephone_Sheet1.RowCount-1, value);
                fpsTelephone_Sheet1.SetActiveCell(fpsTelephone_Sheet1.RowCount, 0);
				enableButton(true);
				mdiParent.RefreshMasterCount();
				return true;
			}
			else
			{				
				return false;
			}
		}

		public bool UpdateRow(TelephoneCondition value)
		{
			if (facadeTelephoneCondition.UpdateTelephoneCondition(value))
			{
				bindTelephoneCondition(SelectedRow, value);				
				return true;
			}
			else
			{				
				return false;
			}
		}

		public void DeleteRow()
		{
			if (facadeTelephoneCondition.DeleteTelephoneCondition(SelectedTelephoneCondition))
			{
				if(fpsTelephone_Sheet1.RowCount > 1)
				{
					fpsTelephone.ActiveSheet.Rows.Remove(SelectedRow, 1);
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
			return facadeTelephoneCondition.ObjTelephoneConditionList.Count;
		}

//		============================== Base Event ==============================
		public void InitForm()
		{
			newObject();
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
				if (facadeTelephoneCondition.DisplayTelephoneCondition())
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

		public void PrintForm()
		{
		}

		public void ExitForm()
		{
			clearMainMenuStatus();
			Dispose(true);
		}
		
		private void addEvent()
		{
			try
			{
				frmEntry = new frmTelephoneConditionEntry(this);
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
		}

		private void editEvent()
		{
			try
			{
				frmEntry = new frmTelephoneConditionEntry(this);
				frmEntry.InitEditAction(SelectedTelephoneCondition);
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
	
		private void deleteEvent()
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
		private void frmTelephoneCondition_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
		}

		private void cmdAdd_Click(object sender, System.EventArgs e)
		{
			addEvent();
		}

		private void cmdEdit_Click(object sender, System.EventArgs e)
		{
			editEvent();
		}

		private void cmdDelete_Click(object sender, System.EventArgs e)
		{
			deleteEvent();
		}

		private void mniAdd_Click(object sender, System.EventArgs e)
		{
			addEvent();
		}

		private void mniEdit_Click(object sender, System.EventArgs e)
		{
			editEvent();
		}

		private void mniDelete_Click(object sender, System.EventArgs e)
		{
			deleteEvent();
		}

		private void fpsTelephone_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader)
			{
				editEvent();
			}
		}
	}
}
