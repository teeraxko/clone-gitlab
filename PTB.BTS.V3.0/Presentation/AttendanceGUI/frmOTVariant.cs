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
	public class frmOTVariant : ChildFormBase, IMDIChildForm 
	{
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
					frmEntry.Dispose();
					facadeOTVariant.DisplayOTVariant();

					frmEntry = null;
					facadeOTVariant = null;
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		/// 			
		private System.Windows.Forms.Button cmdAdd;
		private System.Windows.Forms.Button cmdEdit;
		private System.Windows.Forms.Button cmdDelete;
		private FarPoint.Win.Spread.FpSpread fpsOTVariant;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem mniAdd;
		private System.Windows.Forms.MenuItem mniEdit;
		private System.Windows.Forms.MenuItem mniDelete;
		private FarPoint.Win.Spread.SheetView fpsOTVariant_Sheet1;
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
			FarPoint.Win.Spread.CellType.TextCellType textCellType9 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType10 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType11 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType12 = new FarPoint.Win.Spread.CellType.TextCellType();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.fpsOTVariant = new FarPoint.Win.Spread.FpSpread();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mniAdd = new System.Windows.Forms.MenuItem();
			this.mniEdit = new System.Windows.Forms.MenuItem();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			this.fpsOTVariant_Sheet1 = new FarPoint.Win.Spread.SheetView();
			((System.ComponentModel.ISupportInitialize)(this.fpsOTVariant)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsOTVariant_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// cmdAdd
			// 
			this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.cmdAdd.Location = new System.Drawing.Point(332, 423);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.TabIndex = 1;
			this.cmdAdd.Text = "เพิ่ม";
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			// 
			// cmdEdit
			// 
			this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.cmdEdit.Location = new System.Drawing.Point(412, 423);
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.TabIndex = 2;
			this.cmdEdit.Text = "แก้ไข";
			this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
			// 
			// cmdDelete
			// 
			this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.cmdDelete.Location = new System.Drawing.Point(492, 423);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.TabIndex = 3;
			this.cmdDelete.Text = "ลบ";
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			// 
			// fpsOTVariant
			// 
			this.fpsOTVariant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsOTVariant.ContextMenu = this.contextMenu1;
			this.fpsOTVariant.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.fpsOTVariant.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsOTVariant.Location = new System.Drawing.Point(21, 24);
			this.fpsOTVariant.Name = "fpsOTVariant";
			this.fpsOTVariant.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																					  this.fpsOTVariant_Sheet1});
			this.fpsOTVariant.Size = new System.Drawing.Size(856, 376);
			this.fpsOTVariant.TabIndex = 1;
			this.fpsOTVariant.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsOTVariant_CellDoubleClick);
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
			// fpsOTVariant_Sheet1
			// 
			this.fpsOTVariant_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsOTVariant_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsOTVariant_Sheet1.ColumnCount = 12;
			this.fpsOTVariant_Sheet1.ColumnHeader.RowCount = 2;
			this.fpsOTVariant_Sheet1.RowCount = 1;
			this.fpsOTVariant_Sheet1.ColumnHeader.Cells.Get(0, 1).RowSpan = 2;
			this.fpsOTVariant_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "เวลาเข้า - ออก";
			this.fpsOTVariant_Sheet1.ColumnHeader.Cells.Get(0, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
			this.fpsOTVariant_Sheet1.ColumnHeader.Cells.Get(0, 2).RowSpan = 2;
			this.fpsOTVariant_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "ตั้งแต่";
			this.fpsOTVariant_Sheet1.ColumnHeader.Cells.Get(0, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
			this.fpsOTVariant_Sheet1.ColumnHeader.Cells.Get(0, 3).RowSpan = 2;
			this.fpsOTVariant_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "จนถึง";
			this.fpsOTVariant_Sheet1.ColumnHeader.Cells.Get(0, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
			this.fpsOTVariant_Sheet1.ColumnHeader.Cells.Get(0, 4).ColumnSpan = 3;
			this.fpsOTVariant_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "เวลาเทียบเท่า";
			this.fpsOTVariant_Sheet1.ColumnHeader.Cells.Get(0, 7).ColumnSpan = 3;
			this.fpsOTVariant_Sheet1.ColumnHeader.Cells.Get(0, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsOTVariant_Sheet1.ColumnHeader.Cells.Get(0, 7).Text = "เวลาเทียบเท่า (สำหรับลูกค้า)";
			this.fpsOTVariant_Sheet1.ColumnHeader.Cells.Get(0, 10).ColumnSpan = 2;
			this.fpsOTVariant_Sheet1.ColumnHeader.Cells.Get(0, 10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsOTVariant_Sheet1.ColumnHeader.Cells.Get(0, 10).Text = "อัตรา A,B,C";
			this.fpsOTVariant_Sheet1.ColumnHeader.Cells.Get(1, 4).Text = "TIS Group";
			this.fpsOTVariant_Sheet1.ColumnHeader.Cells.Get(1, 5).Text = "Melco Group";
			this.fpsOTVariant_Sheet1.ColumnHeader.Cells.Get(1, 6).Text = "Others";
			this.fpsOTVariant_Sheet1.ColumnHeader.Cells.Get(1, 7).Text = "TIS Group";
			this.fpsOTVariant_Sheet1.ColumnHeader.Cells.Get(1, 8).Text = "Melco Group";
			this.fpsOTVariant_Sheet1.ColumnHeader.Cells.Get(1, 9).Text = "Others";
			this.fpsOTVariant_Sheet1.ColumnHeader.Cells.Get(1, 10).Text = "วันทำงาน";
			this.fpsOTVariant_Sheet1.ColumnHeader.Cells.Get(1, 11).Text = "วันหยุด";
			this.fpsOTVariant_Sheet1.ColumnHeader.Columns.Default.Resizable = false;
			this.fpsOTVariant_Sheet1.Columns.Default.Resizable = false;
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsOTVariant_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsOTVariant_Sheet1.Columns.Get(0).Visible = false;
			this.fpsOTVariant_Sheet1.Columns.Get(0).Width = 35F;
			this.fpsOTVariant_Sheet1.Columns.Get(1).AllowAutoSort = true;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			textCellType2.ReadOnly = true;
			this.fpsOTVariant_Sheet1.Columns.Get(1).CellType = textCellType2;
			this.fpsOTVariant_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsOTVariant_Sheet1.Columns.Get(1).Width = 80F;
			this.fpsOTVariant_Sheet1.Columns.Get(2).AllowAutoSort = true;
			textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType3.DropDownButton = false;
			textCellType3.ReadOnly = true;
			this.fpsOTVariant_Sheet1.Columns.Get(2).CellType = textCellType3;
			this.fpsOTVariant_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsOTVariant_Sheet1.Columns.Get(3).AllowAutoSort = true;
			textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType4.DropDownButton = false;
			textCellType4.ReadOnly = true;
			this.fpsOTVariant_Sheet1.Columns.Get(3).CellType = textCellType4;
			this.fpsOTVariant_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsOTVariant_Sheet1.Columns.Get(4).AllowAutoSort = true;
			textCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType5.DropDownButton = false;
			this.fpsOTVariant_Sheet1.Columns.Get(4).CellType = textCellType5;
			this.fpsOTVariant_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsOTVariant_Sheet1.Columns.Get(4).Label = "TIS Group";
			this.fpsOTVariant_Sheet1.Columns.Get(4).Width = 80F;
			this.fpsOTVariant_Sheet1.Columns.Get(5).AllowAutoSort = true;
			textCellType6.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType6.DropDownButton = false;
			this.fpsOTVariant_Sheet1.Columns.Get(5).CellType = textCellType6;
			this.fpsOTVariant_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsOTVariant_Sheet1.Columns.Get(5).Label = "Melco Group";
			this.fpsOTVariant_Sheet1.Columns.Get(5).Width = 80F;
			this.fpsOTVariant_Sheet1.Columns.Get(6).AllowAutoSort = true;
			textCellType7.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType7.DropDownButton = false;
			this.fpsOTVariant_Sheet1.Columns.Get(6).CellType = textCellType7;
			this.fpsOTVariant_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsOTVariant_Sheet1.Columns.Get(6).Label = "Others";
			this.fpsOTVariant_Sheet1.Columns.Get(6).Width = 80F;
			this.fpsOTVariant_Sheet1.Columns.Get(7).AllowAutoSort = true;
			textCellType8.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType8.DropDownButton = false;
			textCellType8.ReadOnly = true;
			this.fpsOTVariant_Sheet1.Columns.Get(7).CellType = textCellType8;
			this.fpsOTVariant_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsOTVariant_Sheet1.Columns.Get(7).Label = "TIS Group";
			this.fpsOTVariant_Sheet1.Columns.Get(7).Width = 80F;
			this.fpsOTVariant_Sheet1.Columns.Get(8).AllowAutoSort = true;
			textCellType9.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType9.DropDownButton = false;
			textCellType9.ReadOnly = true;
			this.fpsOTVariant_Sheet1.Columns.Get(8).CellType = textCellType9;
			this.fpsOTVariant_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsOTVariant_Sheet1.Columns.Get(8).Label = "Melco Group";
			this.fpsOTVariant_Sheet1.Columns.Get(8).Width = 80F;
			this.fpsOTVariant_Sheet1.Columns.Get(9).AllowAutoSort = true;
			textCellType10.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType10.DropDownButton = false;
			textCellType10.ReadOnly = true;
			this.fpsOTVariant_Sheet1.Columns.Get(9).CellType = textCellType10;
			this.fpsOTVariant_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsOTVariant_Sheet1.Columns.Get(9).Label = "Others";
			this.fpsOTVariant_Sheet1.Columns.Get(9).Width = 80F;
			this.fpsOTVariant_Sheet1.Columns.Get(10).AllowAutoSort = true;
			textCellType11.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType11.DropDownButton = false;
			textCellType11.ReadOnly = true;
			this.fpsOTVariant_Sheet1.Columns.Get(10).CellType = textCellType11;
			this.fpsOTVariant_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsOTVariant_Sheet1.Columns.Get(10).Label = "วันทำงาน";
			this.fpsOTVariant_Sheet1.Columns.Get(11).AllowAutoSort = true;
			textCellType12.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType12.DropDownButton = false;
			textCellType12.ReadOnly = true;
			this.fpsOTVariant_Sheet1.Columns.Get(11).CellType = textCellType12;
			this.fpsOTVariant_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsOTVariant_Sheet1.Columns.Get(11).Label = "วันหยุด";
			this.fpsOTVariant_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
			this.fpsOTVariant_Sheet1.RowHeader.Columns.Default.Resizable = true;
			this.fpsOTVariant_Sheet1.RowHeader.Rows.Default.Resizable = false;
			this.fpsOTVariant_Sheet1.Rows.Default.Resizable = false;
			this.fpsOTVariant_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsOTVariant_Sheet1.SheetName = "Sheet1";
			this.fpsOTVariant_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// frmOTVariant
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(898, 463);
			this.Controls.Add(this.fpsOTVariant);
			this.Controls.Add(this.cmdDelete);
			this.Controls.Add(this.cmdEdit);
			this.Controls.Add(this.cmdAdd);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmOTVariant";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //this.Text = "กำหนดรูปแบบค่าล่วงเวลา (Family Car)";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmOTVariantTable_Load);
			((System.ComponentModel.ISupportInitialize)(this.fpsOTVariant)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsOTVariant_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private - 
		private bool isReadonly = true;
		private frmOTVariantEntry frmEntry;
		private frmMain mdiParent;		
		#endregion

//		============================== Property ==============================
		private OTVariantFacade facadeOTVariant;	
		public OTVariantFacade FacadeOTVariant
		{
			get{return facadeOTVariant;}
		}

		private int SelectedRow
		{
			get{return fpsOTVariant_Sheet1.ActiveRowIndex;}
		}

		private string SelectedKey
		{
			get{return fpsOTVariant_Sheet1.Cells[SelectedRow,0].Text;}
		}

		private OTVariant SelectedOTVariant
		{
			get{return facadeOTVariant.ObjOTVariantList[SelectedKey];}
		}

//		============================== Constructor ==============================
		public frmOTVariant(): base()
		{
			InitializeComponent();
			newObject();
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miOvertimeVariant");
            this.title = UserProfile.GetFormName("miAttendance", "miOvertimeVariant");

		}
        public override string FormID()
        {
            return UserProfile.GetFormID("miAttendance", "miOvertimeVariant");
        }

//		============================== private method ==============================
		private void newObject()
		{
			facadeOTVariant = new OTVariantFacade();
			frmEntry = new frmOTVariantEntry(this);
		}

		private void bindOTVariant(int row, OTVariant value)
		{
			fpsOTVariant_Sheet1.Cells[row,0].Text = GUIFunction.GetString(value.EntityKey);
			fpsOTVariant_Sheet1.Cells[row,1].Text = GUIFunction.GetString(value.InOutStatus);
			fpsOTVariant_Sheet1.Cells[row,2].Text = GUIFunction.GetString(value.APeriod.From.ToString("HH : mm"));
			fpsOTVariant_Sheet1.Cells[row,3].Text = GUIFunction.GetString(value.APeriod.To.ToString("HH : mm"));
			fpsOTVariant_Sheet1.Cells[row,4].Text = GUIFunction.GetString(value.EquivalentTimeGroupI.ToString("HH : mm")) ;
			fpsOTVariant_Sheet1.Cells[row,5].Text = GUIFunction.GetString(value.EquivalentTimeGroupII.ToString("HH : mm"));
			fpsOTVariant_Sheet1.Cells[row,6].Text = GUIFunction.GetString(value.EquivalentTimeGroupIII.ToString("HH : mm"));
			fpsOTVariant_Sheet1.Cells[row,7].Text = GUIFunction.GetString(value.ChargeEquivalentTimeGroupI.ToString("HH : mm")) ;
			fpsOTVariant_Sheet1.Cells[row,8].Text = GUIFunction.GetString(value.ChargeEquivalentTimeGroupII.ToString("HH : mm"));
			fpsOTVariant_Sheet1.Cells[row,9].Text = GUIFunction.GetString(value.ChargeEquivalentTimeGroupIII.ToString("HH : mm"));
			fpsOTVariant_Sheet1.Cells[row,10].Text = GUIFunction.GetString(value.OtRateWorkingDay);
			fpsOTVariant_Sheet1.Cells[row,11].Text = GUIFunction.GetString(value.OtRateHoliday);
		}

		private void bindForm()
		{
			if (facadeOTVariant.ObjOTVariantList != null)
			{
				int iRow = facadeOTVariant.ObjOTVariantList.Count;
				fpsOTVariant_Sheet1.RowCount = iRow;
				for(int i=0; i<iRow; i++)
				{
					bindOTVariant(i, facadeOTVariant.ObjOTVariantList[i]);
				}	
				mdiParent.RefreshMasterCount();
			}
            fpsOTVariant_Sheet1.SetActiveCell(fpsOTVariant_Sheet1.RowCount, 0);
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
			fpsOTVariant_Sheet1.RowCount = 0;
			enableButton(false);
		}

//		============================== public method ==============================
		public bool AddRow(OTVariant value)
		{
			if (facadeOTVariant.InsertOTVariant(value))
			{
				fpsOTVariant_Sheet1.RowCount++;
				bindOTVariant(fpsOTVariant_Sheet1.RowCount-1, value);
                fpsOTVariant_Sheet1.SetActiveCell(fpsOTVariant_Sheet1.RowCount, 0);
				enableButton(true);
				mdiParent.RefreshMasterCount();
				return true;
			}				
			return false;
		}

		public bool UpdateRow(OTVariant value)
		{
			if (facadeOTVariant.UpdateOTVariant(value))
			{
				bindOTVariant(SelectedRow, value);				
				return true;
			}				
			return false;
		}

		public void DeleteRow()
		{
			if (facadeOTVariant.DeleteOTVariant(SelectedOTVariant))
			{
				if(fpsOTVariant_Sheet1.RowCount > 1)
				{
					fpsOTVariant.ActiveSheet.Rows.Remove(SelectedRow,1);
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
			return facadeOTVariant.ObjOTVariantList.Count;
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
				if (facadeOTVariant.DisplayOTVariant())
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
				frmEntry = new frmOTVariantEntry(this);
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
				frmEntry = new frmOTVariantEntry(this);
				frmEntry.InitEditAction(SelectedOTVariant);
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
		private void frmOTVariantTable_Load(object sender, System.EventArgs e)
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

		private void fpsOTVariant_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader)
			{
				editEvent();
			}
		}
	}
}