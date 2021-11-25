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
using ictus.PIS.PI.Entity;

using Facade.CommonFacade;
using Facade.PiFacade;

using Presentation.CommonGUI;

namespace Presentation.PiGUI
{
	public class frmSection : ChildFormBase, IMDIChildForm
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
		private FarPoint.Win.Spread.FpSpread fpsSection;
		private FarPoint.Win.Spread.SheetView fpsSection_Sheet1;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem mniAdd;
		private System.Windows.Forms.MenuItem mniEdit;
		private System.Windows.Forms.MenuItem mniDelete;
		private System.Windows.Forms.Button cmdDelete;
		private System.Windows.Forms.Button cmdEdit;
		private System.Windows.Forms.Button cmdAdd;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
			this.fpsSection = new FarPoint.Win.Spread.FpSpread();
			this.fpsSection_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mniAdd = new System.Windows.Forms.MenuItem();
			this.mniEdit = new System.Windows.Forms.MenuItem();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdAdd = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.fpsSection)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsSection_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// fpsSection
			// 
			this.fpsSection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.fpsSection.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsSection.Location = new System.Drawing.Point(15, 24);
			this.fpsSection.Name = "fpsSection";
			this.fpsSection.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																					this.fpsSection_Sheet1});
			this.fpsSection.Size = new System.Drawing.Size(1000, 296);
			this.fpsSection.TabIndex = 0;
			this.fpsSection.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsSection_CellDoubleClick);
			// 
			// fpsSection_Sheet1
			// 
			this.fpsSection_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsSection_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsSection_Sheet1.ColumnCount = 6;
			this.fpsSection_Sheet1.RowCount = 0;
			this.fpsSection_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "รหัส";
			this.fpsSection_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "ชื่อภาษาไทย";
			this.fpsSection_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ชื่อย่อ";
			this.fpsSection_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "ชื่อภาษาอังกฤษ";
			this.fpsSection_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "ฝ่ายต้นสังกัด";
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsSection_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsSection_Sheet1.Columns.Get(0).Visible = false;
			this.fpsSection_Sheet1.Columns.Get(1).AllowAutoSort = true;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			this.fpsSection_Sheet1.Columns.Get(1).CellType = textCellType2;
			this.fpsSection_Sheet1.Columns.Get(1).Label = "รหัส";
			this.fpsSection_Sheet1.Columns.Get(1).Resizable = false;
			this.fpsSection_Sheet1.Columns.Get(1).Width = 48F;
			this.fpsSection_Sheet1.Columns.Get(2).AllowAutoSort = true;
			textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType3.DropDownButton = false;
			this.fpsSection_Sheet1.Columns.Get(2).CellType = textCellType3;
			this.fpsSection_Sheet1.Columns.Get(2).Label = "ชื่อภาษาไทย";
			this.fpsSection_Sheet1.Columns.Get(2).Resizable = false;
			this.fpsSection_Sheet1.Columns.Get(2).Width = 329F;
			this.fpsSection_Sheet1.Columns.Get(3).AllowAutoSort = true;
			textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType4.DropDownButton = false;
			this.fpsSection_Sheet1.Columns.Get(3).CellType = textCellType4;
			this.fpsSection_Sheet1.Columns.Get(3).Label = "ชื่อย่อ";
			this.fpsSection_Sheet1.Columns.Get(3).Resizable = false;
			this.fpsSection_Sheet1.Columns.Get(3).Width = 111F;
			this.fpsSection_Sheet1.Columns.Get(4).AllowAutoSort = true;
			textCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType5.DropDownButton = false;
			this.fpsSection_Sheet1.Columns.Get(4).CellType = textCellType5;
			this.fpsSection_Sheet1.Columns.Get(4).Label = "ชื่อภาษาอังกฤษ";
			this.fpsSection_Sheet1.Columns.Get(4).Resizable = false;
			this.fpsSection_Sheet1.Columns.Get(4).Width = 290F;
			this.fpsSection_Sheet1.Columns.Get(5).AllowAutoSort = true;
			textCellType6.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType6.DropDownButton = false;
			this.fpsSection_Sheet1.Columns.Get(5).CellType = textCellType6;
			this.fpsSection_Sheet1.Columns.Get(5).Label = "ฝ่ายต้นสังกัด";
			this.fpsSection_Sheet1.Columns.Get(5).Resizable = false;
			this.fpsSection_Sheet1.Columns.Get(5).Width = 156F;
			this.fpsSection_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
			this.fpsSection_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsSection_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
			this.fpsSection_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsSection_Sheet1.SheetName = "Sheet1";
			this.fpsSection_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
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
			// cmdDelete
			// 
			this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdDelete.Location = new System.Drawing.Point(558, 336);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.TabIndex = 6;
			this.cmdDelete.Text = "ลบ";
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			// 
			// cmdEdit
			// 
			this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdEdit.Location = new System.Drawing.Point(478, 336);
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.TabIndex = 5;
			this.cmdEdit.Text = "แก้ไข";
			this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
			// 
			// cmdAdd
			// 
			this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdAdd.Location = new System.Drawing.Point(398, 336);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.TabIndex = 4;
			this.cmdAdd.Text = "เพิ่ม";
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			// 
			// frmSection
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1030, 376);
			this.ContextMenu = this.contextMenu1;
			this.Controls.Add(this.cmdDelete);
			this.Controls.Add(this.cmdEdit);
			this.Controls.Add(this.cmdAdd);
			this.Controls.Add(this.fpsSection);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmSection";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //this.Text = "ข้อมูลส่วนงาน";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmSection_Load);
			((System.ComponentModel.ISupportInitialize)(this.fpsSection)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsSection_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private - 
		private bool isReadonly = true;
		private frmSectionEntry frmEntry;
		private frmMain mdiParent;
		private int SelectedRow
		{
			get
			{
				return fpsSection_Sheet1.ActiveRowIndex;
			}
		}

		private string SelectedKey
		{
			get
			{
				return fpsSection_Sheet1.Cells[SelectedRow,0].Text;
			}
		}

		private Section SelectedSection
		{
			get
			{
				return facadeSection.ObjSectionList[SelectedKey];
			}
		}
		#endregion

		//		============================== Property ==============================
		private SectionFacade facadeSection;	
		public SectionFacade FacadeSection
		{
			get
			{
				return facadeSection;
			}
		}
		//		============================== Constructor ==============================
		public frmSection(): base()
		{
			InitializeComponent();
			newObject();
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIMapSection");
            this.title = UserProfile.GetFormName("miPI", "miPIMapSection");

		}
        public override string FormID()
        {
            return UserProfile.GetFormID("miPI", "miPIMapSection");
        }

		private void newObject()
		{
			facadeSection = new SectionFacade();
			frmEntry = new frmSectionEntry(this);
		}

		//		============================== private method ==============================
		private void bindSection(int row, Section aSection)
		{
			fpsSection_Sheet1.Cells[row,0].Text = aSection.EntityKey;
			fpsSection_Sheet1.Cells[row,1].Text = GUIFunction.GetString(aSection.Code);
			fpsSection_Sheet1.Cells[row,2].Text = GUIFunction.GetString(aSection.AFullName.Thai);
			fpsSection_Sheet1.Cells[row,3].Text = GUIFunction.GetString(aSection.AShortName.English);
			fpsSection_Sheet1.Cells[row,4].Text = GUIFunction.GetString(aSection.AFullName.English);
			fpsSection_Sheet1.Cells[row,5].Text = GUIFunction.GetString(aSection.ADepartment.AFullName.English);
		}
		private void bindForm()
		{
			if (facadeSection.ObjSectionList != null)
			{
				int iRow = facadeSection.ObjSectionList.Count;
				fpsSection_Sheet1.RowCount = iRow;
				for(int i=0; i<iRow; i++)
				{
					bindSection(i,facadeSection.ObjSectionList[i]);
				}				
			}
            fpsSection_Sheet1.SetActiveCell(fpsSection_Sheet1.RowCount, 0);
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
			fpsSection_Sheet1.RowCount = 0;
			enableButton(false);
		}
		//		============================== public method ==============================
		public bool AddRow(Section aSection)
		{
			if (facadeSection.InsertSection(aSection))
			{
				fpsSection_Sheet1.RowCount++;
				bindSection(fpsSection_Sheet1.RowCount-1,aSection);
                fpsSection_Sheet1.SetActiveCell(fpsSection_Sheet1.RowCount, 0);
				enableButton(true);
				mdiParent.RefreshMasterCount();
				return true;
			}
			else
			{				
				return false;
			}
		}
		public bool UpdateRow(Section aSection)
		{
			if (facadeSection.UpdateSection(aSection))
			{
				bindSection(SelectedRow, aSection);				
				return true;
			}
			else
			{				
				return false;
			}
		}
		public void DeleteRow()
		{
			if (facadeSection.DeleteSection(SelectedSection))
			{
				if(fpsSection_Sheet1.RowCount > 1)
				{
					fpsSection.ActiveSheet.Rows.Remove(SelectedRow,1);
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
			return facadeSection.ObjSectionList.Count;
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

			try
			{
				if (facadeSection.DisplaySection())
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
			frmListofSection objfrm = new frmListofSection();
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
				frmEntry = new frmSectionEntry(this);
				frmEntry.InitAddAction();
				frmEntry.InitCombo();
				frmEntry.SectionCodeFocus();
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
				frmEntry = new frmSectionEntry(this);
				frmEntry.InitEditAction(SelectedSection);
				frmEntry.EngShortNameFocus();
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

		private void fpsSection_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader)
			{
				EditEvent();
			}
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

		private void frmSection_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
		}
	}
}
