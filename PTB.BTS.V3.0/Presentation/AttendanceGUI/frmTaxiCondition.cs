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
	public class frmTaxiCondition : ChildFormBase, IMDIChildForm 
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
		private FarPoint.Win.Spread.FpSpread fpsTaxi;
		private FarPoint.Win.Spread.SheetView fpsTaxi_Sheet1;
		private System.Windows.Forms.Button cmdEdit;
		private System.Windows.Forms.Button cmdAdd;
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
			FarPoint.Win.Spread.CellType.TextCellType textCellType7 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType8 = new FarPoint.Win.Spread.CellType.TextCellType();
			this.fpsTaxi = new FarPoint.Win.Spread.FpSpread();
			this.fpsTaxi_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mniAdd = new System.Windows.Forms.MenuItem();
			this.mniEdit = new System.Windows.Forms.MenuItem();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			((System.ComponentModel.ISupportInitialize)(this.fpsTaxi)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsTaxi_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// fpsTaxi
			// 
			this.fpsTaxi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsTaxi.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsTaxi.Location = new System.Drawing.Point(25, 24);
			this.fpsTaxi.Name = "fpsTaxi";
			this.fpsTaxi.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																				 this.fpsTaxi_Sheet1});
			this.fpsTaxi.Size = new System.Drawing.Size(840, 330);
			this.fpsTaxi.TabIndex = 0;
			this.fpsTaxi.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsTaxi_CellDoubleClick);
			// 
			// fpsTaxi_Sheet1
			// 
			this.fpsTaxi_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsTaxi_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsTaxi_Sheet1.ColumnCount = 8;
			this.fpsTaxi_Sheet1.ColumnHeader.RowCount = 2;
			this.fpsTaxi_Sheet1.RowCount = 1;
			this.fpsTaxi_Sheet1.ColumnHeader.Cells.Get(0, 1).RowSpan = 2;
			this.fpsTaxi_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "ประเภทรถ";
			this.fpsTaxi_Sheet1.ColumnHeader.Cells.Get(0, 2).RowSpan = 2;
			this.fpsTaxi_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "กลุ่มลูกค้า";
			this.fpsTaxi_Sheet1.ColumnHeader.Cells.Get(0, 3).RowSpan = 2;
			this.fpsTaxi_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ลูกค้า";
			this.fpsTaxi_Sheet1.ColumnHeader.Cells.Get(0, 4).RowSpan = 2;
			this.fpsTaxi_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "เข้าก่อนเวลา";
			this.fpsTaxi_Sheet1.ColumnHeader.Cells.Get(0, 5).RowSpan = 2;
			this.fpsTaxi_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "เลิกหลังเวลา";
			this.fpsTaxi_Sheet1.ColumnHeader.Cells.Get(0, 6).RowSpan = 2;
			this.fpsTaxi_Sheet1.ColumnHeader.Cells.Get(0, 6).Text = "เข้าก่อนเวลา (สำหรับลูกค้า)";
			this.fpsTaxi_Sheet1.ColumnHeader.Cells.Get(0, 7).RowSpan = 2;
			this.fpsTaxi_Sheet1.ColumnHeader.Cells.Get(0, 7).Text = "เลิกหลังเวลา (สำหรับลูกค้า)";
			this.fpsTaxi_Sheet1.ColumnHeader.Cells.Get(1, 6).Text = "(สำหรับลูกค้า)";
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsTaxi_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsTaxi_Sheet1.Columns.Get(0).Visible = false;
			this.fpsTaxi_Sheet1.Columns.Get(1).AllowAutoSort = true;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			this.fpsTaxi_Sheet1.Columns.Get(1).CellType = textCellType2;
			this.fpsTaxi_Sheet1.Columns.Get(1).Resizable = false;
			this.fpsTaxi_Sheet1.Columns.Get(1).Width = 110F;
			this.fpsTaxi_Sheet1.Columns.Get(2).AllowAutoSort = true;
			textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType3.DropDownButton = false;
			this.fpsTaxi_Sheet1.Columns.Get(2).CellType = textCellType3;
			this.fpsTaxi_Sheet1.Columns.Get(2).Resizable = false;
			this.fpsTaxi_Sheet1.Columns.Get(2).Width = 82F;
			this.fpsTaxi_Sheet1.Columns.Get(3).AllowAutoSort = true;
			textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType4.DropDownButton = false;
			this.fpsTaxi_Sheet1.Columns.Get(3).CellType = textCellType4;
			this.fpsTaxi_Sheet1.Columns.Get(3).Resizable = false;
			this.fpsTaxi_Sheet1.Columns.Get(3).Width = 270F;
			this.fpsTaxi_Sheet1.Columns.Get(4).AllowAutoSort = true;
			textCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType5.DropDownButton = false;
			this.fpsTaxi_Sheet1.Columns.Get(4).CellType = textCellType5;
			this.fpsTaxi_Sheet1.Columns.Get(4).Resizable = false;
			this.fpsTaxi_Sheet1.Columns.Get(4).Width = 80F;
			this.fpsTaxi_Sheet1.Columns.Get(5).AllowAutoSort = true;
			textCellType6.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType6.DropDownButton = false;
			this.fpsTaxi_Sheet1.Columns.Get(5).CellType = textCellType6;
			this.fpsTaxi_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsTaxi_Sheet1.Columns.Get(5).Resizable = false;
			this.fpsTaxi_Sheet1.Columns.Get(5).Width = 80F;
			this.fpsTaxi_Sheet1.Columns.Get(6).AllowAutoSort = true;
			textCellType7.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType7.DropDownButton = false;
			this.fpsTaxi_Sheet1.Columns.Get(6).CellType = textCellType7;
			this.fpsTaxi_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsTaxi_Sheet1.Columns.Get(6).Label = "(สำหรับลูกค้า)";
			this.fpsTaxi_Sheet1.Columns.Get(6).Resizable = false;
			this.fpsTaxi_Sheet1.Columns.Get(6).Width = 80F;
			this.fpsTaxi_Sheet1.Columns.Get(7).AllowAutoSort = true;
			textCellType8.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType8.DropDownButton = false;
			this.fpsTaxi_Sheet1.Columns.Get(7).CellType = textCellType8;
			this.fpsTaxi_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsTaxi_Sheet1.Columns.Get(7).Resizable = false;
			this.fpsTaxi_Sheet1.Columns.Get(7).Width = 80F;
			this.fpsTaxi_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
			this.fpsTaxi_Sheet1.RowHeader.Columns.Default.Resizable = true;
			this.fpsTaxi_Sheet1.RowHeader.Rows.Default.Resizable = false;
			this.fpsTaxi_Sheet1.Rows.Default.Resizable = false;
			this.fpsTaxi_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsTaxi_Sheet1.SheetName = "Sheet1";
			this.fpsTaxi_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// cmdEdit
			// 
			this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdEdit.Location = new System.Drawing.Point(408, 377);
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.TabIndex = 2;
			this.cmdEdit.Text = "แก้ไข";
			this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
			// 
			// cmdAdd
			// 
			this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdAdd.Location = new System.Drawing.Point(328, 377);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.TabIndex = 1;
			this.cmdAdd.Text = "เพิ่ม";
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			// 
			// cmdDelete
			// 
			this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdDelete.Location = new System.Drawing.Point(488, 377);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.TabIndex = 3;
			this.cmdDelete.Text = "ลบ";
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
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
			// frmTaxiCondition
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(890, 423);
			this.ContextMenu = this.contextMenu1;
			this.Controls.Add(this.cmdEdit);
			this.Controls.Add(this.cmdAdd);
			this.Controls.Add(this.cmdDelete);
			this.Controls.Add(this.fpsTaxi);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmTaxiCondition";
            //this.Text = "กำหนดเงื่อนไขค่า Taxi";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmTaxiCondition_Load);
			((System.ComponentModel.ISupportInitialize)(this.fpsTaxi)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsTaxi_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private - 
		private bool isReadonly = true;
		private frmTaxiConditionEntry frmEntry;
		private frmMain mdiParent;		
		#endregion
//
//		============================== Property ==============================
		private TaxiConditionFacade facadeTaxiCondition;
		public TaxiConditionFacade FacadeTaxiCondition
		{
			get{return facadeTaxiCondition;}
		}

		private int SelectedRow
		{
			get{return fpsTaxi_Sheet1.ActiveRowIndex;}
		}

		private string SelectedKey
		{
			get{return fpsTaxi_Sheet1.Cells[SelectedRow,0].Text;}
		}

		private TaxiFamilyCarCondition SelectedFamilyCarCondition
		{
			get{return facadeTaxiCondition.ObjTaxiFamilyCarConditionList[SelectedKey];}
		}

		private TaxiPositionCarCondition SelectedPositionCarCondition
		{
			get{return facadeTaxiCondition.ObjTaxiPositionCarConditionList[SelectedKey];}
		}

//		============================== Constructor ==============================
		public frmTaxiCondition() : base()
		{
			InitializeComponent();
			newObject();
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miTaxiCondition");
            this.title = UserProfile.GetFormName("miAttendance", "miTaxiCondition");

		}
        public override string FormID()
        {
            return UserProfile.GetFormID("miAttendance", "miTaxiCondition");
        }
//		============================== private method ==============================
		private void newObject()
		{
			facadeTaxiCondition = new TaxiConditionFacade();
			frmEntry = new frmTaxiConditionEntry(this);
		}

		private void bindTaxiFamilyCar(int row, TaxiFamilyCarCondition value)
		{
			fpsTaxi_Sheet1.Cells[row,0].Text = GUIFunction.GetString(value.EntityKey);
			fpsTaxi_Sheet1.Cells[row,1].Text = "Family Car";
			fpsTaxi_Sheet1.Cells[row,2].Text = GUIFunction.GetString(value.ACustomerGroup.AName.English);
			fpsTaxi_Sheet1.Cells[row,3].Text = "";
			fpsTaxi_Sheet1.Cells[row,4].Text = GUIFunction.GetString(value.UntilTimeIn.ToString("HH : mm"));
			fpsTaxi_Sheet1.Cells[row,5].Text = GUIFunction.GetString(value.SinceTimeOut.ToString("HH : mm"));
			fpsTaxi_Sheet1.Cells[row,6].Text = GUIFunction.GetString(value.UntilTimeInForCharge.ToString("HH : mm"));
			fpsTaxi_Sheet1.Cells[row,7].Text = GUIFunction.GetString(value.SinceTimeOutForCharge.ToString("HH : mm"));
		}

		private void bindTaxiPositionCar(int row, TaxiPositionCarCondition value)
		{
			fpsTaxi_Sheet1.Cells[row,0].Text = GUIFunction.GetString(value.EntityKey);
			fpsTaxi_Sheet1.Cells[row,1].Text = "Position Car";
			fpsTaxi_Sheet1.Cells[row,2].Text = GUIFunction.GetString(value.ACustomer.ACustomerGroup.AName.English);
			fpsTaxi_Sheet1.Cells[row,3].Text = GUIFunction.GetString(value.ACustomer.AName.English);
			fpsTaxi_Sheet1.Cells[row,4].Text = GUIFunction.GetString(value.UntilTimeIn.ToString("HH : mm"));
			fpsTaxi_Sheet1.Cells[row,5].Text = GUIFunction.GetString(value.SinceTimeOut.ToString("HH : mm"));
		}

		private void bindForm()
		{
			if (facadeTaxiCondition.ObjTaxiFamilyCarConditionList != null | facadeTaxiCondition.ObjTaxiPositionCarConditionList != null)
			{
				int iFamily = facadeTaxiCondition.ObjTaxiFamilyCarConditionList.Count;
				int iPosition = facadeTaxiCondition.ObjTaxiPositionCarConditionList.Count;
				fpsTaxi_Sheet1.RowCount = iFamily + iPosition;

				for(int i=0; i<iFamily; i++)
				{
					bindTaxiFamilyCar(i, facadeTaxiCondition.ObjTaxiFamilyCarConditionList[i]);
				}	
			
				for(int i=0; i<iPosition; i++)
				{
					bindTaxiPositionCar(i+iFamily, facadeTaxiCondition.ObjTaxiPositionCarConditionList[i]);
				}
				mdiParent.RefreshMasterCount();
			}
            fpsTaxi_Sheet1.SetActiveCell(fpsTaxi_Sheet1.RowCount, 0);
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
			fpsTaxi_Sheet1.RowCount = 0;
			enableButton(false);
		}

//		============================== public method ==============================
		#region - FamilyCar -
		public bool AddRow(TaxiFamilyCarCondition value)
		{
			if (facadeTaxiCondition.InsertTaxi(value))
			{
				fpsTaxi_Sheet1.RowCount++;
				bindTaxiFamilyCar(fpsTaxi_Sheet1.RowCount-1, value);
                fpsTaxi_Sheet1.SetActiveCell(fpsTaxi_Sheet1.RowCount, 0);
				enableButton(true);
				mdiParent.RefreshMasterCount();
				return true;
			}			
			return false;
		}

		public bool UpdateRow(TaxiFamilyCarCondition value)
		{
			if (facadeTaxiCondition.UpdateTaxi(value))
			{
				bindTaxiFamilyCar(SelectedRow, value);				
				return true;
			}				
			return false;
		}

		private void DeleteFamilyRow()
		{
			if (facadeTaxiCondition.DeleteTaxi(SelectedFamilyCarCondition))
			{
				if(fpsTaxi_Sheet1.RowCount > 1)
				{
					fpsTaxi.ActiveSheet.Rows.Remove(SelectedRow,1);
				}
				else
				{
					clearForm();
				}
				mdiParent.RefreshMasterCount();
			}			
		}
		#endregion

		#region - PositionCar -
		public bool AddRow(TaxiPositionCarCondition value)
		{
			if (facadeTaxiCondition.InsertTaxi(value))
			{
				fpsTaxi_Sheet1.RowCount++;
				bindTaxiPositionCar(fpsTaxi_Sheet1.RowCount-1, value);
                fpsTaxi_Sheet1.SetActiveCell(fpsTaxi_Sheet1.RowCount, 0);
				enableButton(true);
				mdiParent.RefreshMasterCount();
				return true;
			}
			return false;
		}

		public bool UpdateRow(TaxiPositionCarCondition value)
		{
			if (facadeTaxiCondition.UpdateTaxi(value))
			{
				bindTaxiPositionCar(SelectedRow, value);				
				return true;
			}				
			return false;
		}

		private void DeletePositionRow()
		{
			if (facadeTaxiCondition.DeleteTaxi(SelectedPositionCarCondition))
			{
				if(fpsTaxi_Sheet1.RowCount > 1)
				{
					fpsTaxi.ActiveSheet.Rows.Remove(SelectedRow,1);
				}
				else
				{
					clearForm();
				}
				mdiParent.RefreshMasterCount();
			}			
		}
		#endregion

		public override int MasterCount()
		{
			return facadeTaxiCondition.ObjTaxiFamilyCarConditionList.Count + facadeTaxiCondition.ObjTaxiPositionCarConditionList.Count;
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
				if (facadeTaxiCondition.DisPlayTaxiFamilyCar() | facadeTaxiCondition.DisplayTaxiPositionCar())
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
				frmEntry = new frmTaxiConditionEntry(this);
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
				frmEntry = new frmTaxiConditionEntry(this);

				if(fpsTaxi_Sheet1.Cells[SelectedRow,1].Text == "Position Car")
				{
					frmEntry.InitEditAction(SelectedPositionCarCondition);
				}
				else
				{
					frmEntry.InitEditAction(SelectedFamilyCarCondition);
				}	
			
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
					if(fpsTaxi_Sheet1.Cells[SelectedRow,1].Text == "Position Car")
					{
						DeletePositionRow();
					}
					else
					{
						DeleteFamilyRow();
					}
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
		private void frmTaxiCondition_Load(object sender, System.EventArgs e)
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

		private void fpsTaxi_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader)
			{
				editEvent();
			}
		}
	}
}
