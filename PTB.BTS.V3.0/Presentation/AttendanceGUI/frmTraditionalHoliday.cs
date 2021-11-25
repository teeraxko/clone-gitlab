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

using ictus.Common.Entity.Time;

namespace Presentation.AttendanceGUI
{
	public class frmTraditionalHoliday : ChildFormBase, IMDIChildForm	
	{
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
					frmEntry.Dispose();
					facadeTraditionalHoliday.Dispose();

					frmEntry = null;
					facadeTraditionalHoliday = null;
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem mniAdd;
		private System.Windows.Forms.MenuItem mniEdit;
		private System.Windows.Forms.MenuItem mniDelete;
		private System.Windows.Forms.Label label1;
		private FarPoint.Win.Spread.FpSpread fpsTraditionalHoliday;
		private FarPoint.Win.Spread.SheetView fpsTraditionalHoliday_Sheet1;
		private System.Windows.Forms.ComboBox cboPattern;
		private System.Windows.Forms.Button cmdEdit;
		private System.Windows.Forms.Button cmdAdd;
		private System.Windows.Forms.Button cmdDelete;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dtpForYear;
		private System.Windows.Forms.GroupBox gbpDetail;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmTraditionalHoliday));
			FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mniAdd = new System.Windows.Forms.MenuItem();
			this.mniEdit = new System.Windows.Forms.MenuItem();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			this.fpsTraditionalHoliday = new FarPoint.Win.Spread.FpSpread();
			this.fpsTraditionalHoliday_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.gbpDetail = new System.Windows.Forms.GroupBox();
			this.dtpForYear = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cboPattern = new System.Windows.Forms.ComboBox();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.cmdDelete = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.fpsTraditionalHoliday)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsTraditionalHoliday_Sheet1)).BeginInit();
			this.gbpDetail.SuspendLayout();
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
			// fpsTraditionalHoliday
			// 
			this.fpsTraditionalHoliday.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsTraditionalHoliday.ContextMenu = this.contextMenu1;
			this.fpsTraditionalHoliday.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.fpsTraditionalHoliday.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsTraditionalHoliday.Location = new System.Drawing.Point(15, 120);
			this.fpsTraditionalHoliday.Name = "fpsTraditionalHoliday";
			this.fpsTraditionalHoliday.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																							   this.fpsTraditionalHoliday_Sheet1});
			this.fpsTraditionalHoliday.Size = new System.Drawing.Size(404, 312);
			this.fpsTraditionalHoliday.TabIndex = 12;
			this.fpsTraditionalHoliday.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsTraditionalHoliday_CellDoubleClick);
			// 
			// fpsTraditionalHoliday_Sheet1
			// 
			this.fpsTraditionalHoliday_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsTraditionalHoliday_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsTraditionalHoliday_Sheet1.ColumnCount = 3;
			this.fpsTraditionalHoliday_Sheet1.RowCount = 1;
			this.fpsTraditionalHoliday_Sheet1.AutoCalculation = false;
			this.fpsTraditionalHoliday_Sheet1.ColumnHeader.Cells.Get(0, 1).Border = bevelBorder1;
			this.fpsTraditionalHoliday_Sheet1.ColumnHeader.Cells.Get(0, 1).RowSpan = 2;
			this.fpsTraditionalHoliday_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "วันที่";
			this.fpsTraditionalHoliday_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "รายละเอียด";
			this.fpsTraditionalHoliday_Sheet1.ColumnHeader.Columns.Default.Resizable = false;
			this.fpsTraditionalHoliday_Sheet1.ColumnHeader.Rows.Get(0).Height = 26F;
			this.fpsTraditionalHoliday_Sheet1.Columns.Default.Resizable = false;
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsTraditionalHoliday_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsTraditionalHoliday_Sheet1.Columns.Get(0).Visible = false;
			this.fpsTraditionalHoliday_Sheet1.Columns.Get(1).AllowAutoSort = true;
			dateTimeCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			dateTimeCellType1.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
			dateTimeCellType1.DateDefault = new System.DateTime(2005, 11, 22, 13, 40, 23, 0);
			dateTimeCellType1.DropDownButton = false;
			dateTimeCellType1.TimeDefault = new System.DateTime(2005, 11, 22, 13, 40, 23, 0);
			this.fpsTraditionalHoliday_Sheet1.Columns.Get(1).CellType = dateTimeCellType1;
			this.fpsTraditionalHoliday_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsTraditionalHoliday_Sheet1.Columns.Get(1).Label = "วันที่";
			this.fpsTraditionalHoliday_Sheet1.Columns.Get(1).Resizable = true;
			this.fpsTraditionalHoliday_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
			this.fpsTraditionalHoliday_Sheet1.Columns.Get(1).Width = 100F;
			this.fpsTraditionalHoliday_Sheet1.Columns.Get(2).AllowAutoSort = true;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			textCellType2.ReadOnly = true;
			this.fpsTraditionalHoliday_Sheet1.Columns.Get(2).CellType = textCellType2;
			this.fpsTraditionalHoliday_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
			this.fpsTraditionalHoliday_Sheet1.Columns.Get(2).Label = "รายละเอียด";
			this.fpsTraditionalHoliday_Sheet1.Columns.Get(2).Resizable = true;
			this.fpsTraditionalHoliday_Sheet1.Columns.Get(2).Width = 250F;
			this.fpsTraditionalHoliday_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
			this.fpsTraditionalHoliday_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsTraditionalHoliday_Sheet1.RowHeader.Columns.Get(0).Width = 32F;
			this.fpsTraditionalHoliday_Sheet1.RowHeader.Rows.Default.Resizable = false;
			this.fpsTraditionalHoliday_Sheet1.Rows.Default.Resizable = false;
			this.fpsTraditionalHoliday_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
			this.fpsTraditionalHoliday_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsTraditionalHoliday_Sheet1.SheetName = "Sheet1";
			this.fpsTraditionalHoliday_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// gbpDetail
			// 
			this.gbpDetail.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.gbpDetail.Controls.Add(this.dtpForYear);
			this.gbpDetail.Controls.Add(this.label2);
			this.gbpDetail.Controls.Add(this.label1);
			this.gbpDetail.Controls.Add(this.cboPattern);
			this.gbpDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.gbpDetail.Location = new System.Drawing.Point(13, 8);
			this.gbpDetail.Name = "gbpDetail";
			this.gbpDetail.Size = new System.Drawing.Size(408, 96);
			this.gbpDetail.TabIndex = 13;
			this.gbpDetail.TabStop = false;
			// 
			// dtpForYear
			// 
			this.dtpForYear.CustomFormat = "yyyy";
			this.dtpForYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpForYear.Location = new System.Drawing.Point(96, 24);
			this.dtpForYear.Name = "dtpForYear";
			this.dtpForYear.ShowUpDown = true;
			this.dtpForYear.Size = new System.Drawing.Size(56, 20);
			this.dtpForYear.TabIndex = 4;
			this.dtpForYear.Value = new System.DateTime(2005, 10, 31, 0, 0, 0, 0);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(32, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "สำหรับปี";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "รูปแบบ";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cboPattern
			// 
			this.cboPattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPattern.Location = new System.Drawing.Point(96, 56);
			this.cboPattern.Name = "cboPattern";
			this.cboPattern.Size = new System.Drawing.Size(256, 21);
			this.cboPattern.TabIndex = 1;
			this.cboPattern.SelectedValueChanged += new System.EventHandler(this.cboPattern_SelectedValueChanged);
			// 
			// cmdEdit
			// 
			this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdEdit.Location = new System.Drawing.Point(180, 456);
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.TabIndex = 15;
			this.cmdEdit.Text = "แก้ไข";
			this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
			// 
			// cmdAdd
			// 
			this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdAdd.Location = new System.Drawing.Point(100, 456);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.TabIndex = 14;
			this.cmdAdd.Text = "เพิ่ม";
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			// 
			// cmdDelete
			// 
			this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdDelete.Location = new System.Drawing.Point(260, 456);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.TabIndex = 16;
			this.cmdDelete.Text = "ลบ";
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			// 
			// frmTraditionalHoliday
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(434, 495);
			this.Controls.Add(this.cmdEdit);
			this.Controls.Add(this.cmdAdd);
			this.Controls.Add(this.cmdDelete);
			this.Controls.Add(this.gbpDetail);
			this.Controls.Add(this.fpsTraditionalHoliday);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmTraditionalHoliday";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //this.Text = "วันหยุดนักขัตฤกษ์";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmTraditionalHoliday_Load);
			((System.ComponentModel.ISupportInitialize)(this.fpsTraditionalHoliday)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsTraditionalHoliday_Sheet1)).EndInit();
			this.gbpDetail.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private bool isChange = true;
		private frmMain mdiParent;
		private frmTraditionalHolidayEntry frmEntry;
		private TraditionalHolidayPattern objTraditionalHolidayPattern;

		private int SelectedRow
		{
			get{return fpsTraditionalHoliday_Sheet1.ActiveRowIndex;}
		}

		private string SelectedKey
		{
			get{return fpsTraditionalHoliday_Sheet1.Cells[SelectedRow,0].Text;}
		}
	
		private TraditionalHoliday selectedTraditionalHoliday
		{
			get{return facadeTraditionalHoliday.ObjTraditionalHolidayList[SelectedKey];}
		}

		#endregion

//		============================== Property ==============================		
		private TraditionalHolidayFacade facadeTraditionalHoliday;
		public TraditionalHolidayFacade FacadeTraditionalHoliday
		{
			get{return facadeTraditionalHoliday;}
		}

//		============================== Constructor ==============================
		public frmTraditionalHoliday(): base()
		{
			InitializeComponent();
			newObject();
			isReadonly = UserProfile.IsReadOnly("miAttendance", "miTraditionalHoliday");
            this.title = UserProfile.GetFormName("miAttendance", "miTraditionalHoliday");

		}
        public override string FormID()
        {
            return UserProfile.GetFormID("miAttendance", "miTraditionalHoliday");
        }


//		==============================Private method ==============================		
		private void newObject()
		{
			facadeTraditionalHoliday = new TraditionalHolidayFacade();
			frmEntry = new frmTraditionalHolidayEntry(this);
		}

		private void bindForm()
		{
			if (facadeTraditionalHoliday.ObjTraditionalHolidayList != null)
			{
				int iRow = facadeTraditionalHoliday.ObjTraditionalHolidayList.Count;
				fpsTraditionalHoliday_Sheet1.RowCount = iRow;
				for(int i=0; i<iRow; i++)
				{
					bindTraditionalHoliday(i, facadeTraditionalHoliday.ObjTraditionalHolidayList[i]);
				}	
				mdiParent.RefreshMasterCount();
			}
            fpsTraditionalHoliday_Sheet1.SetActiveCell(fpsTraditionalHoliday_Sheet1.RowCount, 0);
		}
		
		private void bindTraditionalHoliday(int row,TraditionalHoliday value)
		{
			fpsTraditionalHoliday_Sheet1.Cells[row,0].Text = GUIFunction.GetString(value.EntityKey);
			fpsTraditionalHoliday_Sheet1.Cells[row,1].Text = GUIFunction.GetShortDateString(value.HolidayDate);
			fpsTraditionalHoliday_Sheet1.Cells[row,2].Text = GUIFunction.GetString(value.ADescription.Thai);
		}

		private void visibleForm(bool enable)
		{
			fpsTraditionalHoliday.Visible = enable;
			cmdAdd.Visible = enable;
			cmdEdit.Visible = enable;
			cmdDelete.Visible = enable;
		}
		
		private void enableAdd(bool enable)
		{
			cmdAdd.Enabled = enable;
			mniAdd.Enabled = enable;
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
			if (cboPattern.Items.Count>0)
			{
				cboPattern.SelectedIndex = -1;
				cboPattern.SelectedIndex = -1;
			}

			fpsTraditionalHoliday_Sheet1.RowCount = 0;
			dtpForYear.Value = DateTime.Today;
			gbpDetail.Enabled = true;
			enableButton(false);
			visibleForm(false);
		}

//		============================== Public method ==============================
		public bool AddRow(TraditionalHoliday value)
		{
			if (facadeTraditionalHoliday.InsertTraditionalHoliday(value))
			{
				fpsTraditionalHoliday_Sheet1.RowCount++;
				bindTraditionalHoliday(fpsTraditionalHoliday_Sheet1.RowCount-1, value);
                fpsTraditionalHoliday_Sheet1.SetActiveCell(fpsTraditionalHoliday_Sheet1.RowCount, 0);
				enableButton(true);
				mdiParent.RefreshMasterCount();
				return true;
			}
			else
			{return false;}
		}

		public bool UpdateRow(TraditionalHoliday value)
		{
			if (facadeTraditionalHoliday.UpdateTraditionalHoliday(value))
			{
				bindTraditionalHoliday(SelectedRow, value);				
				return true;
			}
			else
			{return false;}
		}

		private void DeleteRow()
		{
			if (facadeTraditionalHoliday.DeleteTraditionalHoliday(selectedTraditionalHoliday))
			{
				if(fpsTraditionalHoliday_Sheet1.RowCount > 1)
				{
					fpsTraditionalHoliday.ActiveSheet.Rows.Remove(SelectedRow,1);
				}
				else
				{
					enableButton(false);
					fpsTraditionalHoliday_Sheet1.RowCount = 0;
				}		
				mdiParent.RefreshMasterCount();
			}
		}

		public override int MasterCount()
		{
			return facadeTraditionalHoliday.ObjTraditionalHolidayList.Count;
		}

//		============================== Base Event ==============================
		public void InitForm()
		{	
			try
			{		
				newObject();	
				isChange = false;
				cboPattern.DataSource = facadeTraditionalHoliday.DataSourceTraditionalHolidayPattern;
				isChange = true;
				clearForm();

				clearMainMenuStatus();
				mdiParent.RefreshMasterCount();
			}
			catch(SqlException sqlex)
			{Message(sqlex);}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(Exception ex)
			{Message(ex);}

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
				MainMenuNewStatus = true;
				MainMenuDeleteStatus = false;
				MainMenuRefreshStatus = true;
				MainMenuPrintStatus = false;
				mdiParent.EnableNewCommand(true);
				mdiParent.EnableDeleteCommand(false);
				mdiParent.EnableRefreshCommand(true);
				mdiParent.EnablePrintCommand(false);

				visibleForm(true);
				gbpDetail.Enabled = false;

				YearMonth yearMonth = new YearMonth(dtpForYear.Value);
				objTraditionalHolidayPattern = new TraditionalHolidayPattern();
				
				
				objTraditionalHolidayPattern = (TraditionalHolidayPattern)cboPattern.SelectedItem;
				if(facadeTraditionalHoliday.DisplayTraditionalHoliday(objTraditionalHolidayPattern, yearMonth))
				{
					enableButton(true);
					bindForm();
				}
				else
				{
					fpsTraditionalHoliday_Sheet1.RowCount = 0;
					enableButton(false);
				}	
				mdiParent.RefreshMasterCount();
			}
			catch(SqlException sqlex)
			{Message(sqlex);}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(Exception ex)
			{Message(ex);}
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
				frmEntry = new frmTraditionalHolidayEntry(this);
				frmEntry.InitAddAction(objTraditionalHolidayPattern, dtpForYear.Value);
				frmEntry.ShowDialog();
			}
			catch(SqlException sqlex)
			{Message(sqlex);}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(Exception ex)
			{Message(ex);}		
		}

		private void editEvent()
		{
			try
			{
				frmEntry = new frmTraditionalHolidayEntry(this);
				frmEntry.InitEditAction(objTraditionalHolidayPattern, selectedTraditionalHoliday);
				frmEntry.ShowDialog();				
			}
			catch(SqlException sqlex)
			{Message(sqlex);}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(Exception ex)
			{Message(ex);}		
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
			{Message(sqlex);}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(Exception ex)
			{Message(ex);}				
		}
		
//		============================== event ==============================
		private void frmTraditionalHoliday_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
		}
		
		private void cboPattern_SelectedValueChanged(object sender, System.EventArgs e)
		{
			if(isChange)
			{
				if(cboPattern.Items.Count != 0 && cboPattern.Text != "")
				{
					RefreshForm();
				}
			}
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

		private void fpsTraditionalHoliday_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader)
			{
				editEvent();
			}
		}
	}
}
