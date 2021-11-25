using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using SystemFramework.AppMessage;
using SystemFramework.AppException;
using SystemFramework.AppConfig;

using Entity.CommonEntity;

using Facade.CommonFacade;

using Presentation.CommonGUI;

namespace Presentation.CommonGUI
{
	public class frmApplicationUserProfile : ChildFormBase, IMDIChildForm
	{
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
					facadeApplicationUserProfile.DisplayApplicationUserProfile();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		private FarPoint.Win.Spread.FpSpread fpApplicationUserProfile;
		private FarPoint.Win.Spread.SheetView fpApplicationUserProfile_Sheet1;
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
			this.fpApplicationUserProfile = new FarPoint.Win.Spread.FpSpread();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mniAdd = new System.Windows.Forms.MenuItem();
			this.mniEdit = new System.Windows.Forms.MenuItem();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			this.fpApplicationUserProfile_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdAdd = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.fpApplicationUserProfile)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpApplicationUserProfile_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// fpApplicationUserProfile
			// 
			this.fpApplicationUserProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpApplicationUserProfile.ContextMenu = this.contextMenu1;
			this.fpApplicationUserProfile.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpApplicationUserProfile.Location = new System.Drawing.Point(24, 24);
			this.fpApplicationUserProfile.Name = "fpApplicationUserProfile";
			this.fpApplicationUserProfile.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																								  this.fpApplicationUserProfile_Sheet1});
			this.fpApplicationUserProfile.Size = new System.Drawing.Size(385, 344);
			this.fpApplicationUserProfile.TabIndex = 7;
			this.fpApplicationUserProfile.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpApplicationUserProfile_CellDoubleClick);
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
			// fpApplicationUserProfile_Sheet1
			// 
			this.fpApplicationUserProfile_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpApplicationUserProfile_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpApplicationUserProfile_Sheet1.ColumnCount = 2;
			this.fpApplicationUserProfile_Sheet1.RowCount = 0;
			this.fpApplicationUserProfile_Sheet1.ColumnHeader.Cells.Get(0, 0).Text = "ชื่อผู้ใช้";
			this.fpApplicationUserProfile_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "กลุ่มผู้ใช้";
			this.fpApplicationUserProfile_Sheet1.Columns.Get(0).AllowAutoSort = true;
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			textCellType1.ReadOnly = true;
			this.fpApplicationUserProfile_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpApplicationUserProfile_Sheet1.Columns.Get(0).Label = "ชื่อผู้ใช้";
			this.fpApplicationUserProfile_Sheet1.Columns.Get(0).Resizable = false;
			this.fpApplicationUserProfile_Sheet1.Columns.Get(0).Width = 180F;
			this.fpApplicationUserProfile_Sheet1.Columns.Get(1).AllowAutoSort = true;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			textCellType2.ReadOnly = true;
			this.fpApplicationUserProfile_Sheet1.Columns.Get(1).CellType = textCellType2;
			this.fpApplicationUserProfile_Sheet1.Columns.Get(1).Label = "กลุ่มผู้ใช้";
			this.fpApplicationUserProfile_Sheet1.Columns.Get(1).Resizable = false;
			this.fpApplicationUserProfile_Sheet1.Columns.Get(1).Width = 150F;
			this.fpApplicationUserProfile_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
			this.fpApplicationUserProfile_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpApplicationUserProfile_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
			this.fpApplicationUserProfile_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpApplicationUserProfile_Sheet1.SheetName = "Sheet1";
			this.fpApplicationUserProfile_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// cmdDelete
			// 
			this.cmdDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdDelete.Location = new System.Drawing.Point(261, 384);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.TabIndex = 10;
			this.cmdDelete.Text = "ลบ";
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			// 
			// cmdEdit
			// 
			this.cmdEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdEdit.Location = new System.Drawing.Point(181, 384);
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.TabIndex = 9;
			this.cmdEdit.Text = "แก้ไข";
			this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
			// 
			// cmdAdd
			// 
			this.cmdAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdAdd.Location = new System.Drawing.Point(99, 384);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.TabIndex = 8;
			this.cmdAdd.Text = "เพิ่ม";
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			// 
			// frmApplicationUserProfile
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(434, 423);
			this.Controls.Add(this.cmdDelete);
			this.Controls.Add(this.cmdEdit);
			this.Controls.Add(this.cmdAdd);
			this.Controls.Add(this.fpApplicationUserProfile);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmApplicationUserProfile";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "ผู้ใช้ระบบ";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmApplicationUserProfile_Load);
			((System.ComponentModel.ISupportInitialize)(this.fpApplicationUserProfile)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpApplicationUserProfile_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private - 
		private frmApplicationUserProfileEntry frmEntry;

		private int SelectedRow
		{
			get{return fpApplicationUserProfile_Sheet1.ActiveRowIndex;}
		}

		private string SelectedKey
		{
			get{return fpApplicationUserProfile_Sheet1.Cells[SelectedRow,0].Text;}
		}

		private ApplicationUserProfile SelectedApplicationUserProfile
		{
			get{return facadeApplicationUserProfile.ObjApplicationUserProfileList[SelectedKey];}
		}
		#endregion

//		============================== Property ==============================
		private ApplicationUserProfileFacade facadeApplicationUserProfile;	
		public ApplicationUserProfileFacade FacadeApplicationUserProfile
		{
			get{return facadeApplicationUserProfile;}
		}

//		============================== Constructor ==============================
		public frmApplicationUserProfile(): base()
		{
			InitializeComponent();
			InitForm();
		}

//		============================== Private Method ==============================
		private void bindApplicationUserProfile(int row, ApplicationUserProfile value)
		{
			fpApplicationUserProfile_Sheet1.Cells[row,0].Text = GUIFunction.GetString(value.UserName);
			fpApplicationUserProfile_Sheet1.Cells[row,1].Text = GUIFunction.GetString(value.UserRoleString);
		}

		private void bindForm()
		{
			if (facadeApplicationUserProfile.ObjApplicationUserProfileList != null)
			{
				int iRow = facadeApplicationUserProfile.ObjApplicationUserProfileList.Count;
				fpApplicationUserProfile_Sheet1.RowCount = iRow;
				for(int i=0; i<iRow; i++)
				{
					bindApplicationUserProfile(i, facadeApplicationUserProfile.ObjApplicationUserProfileList[i]);
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
			fpApplicationUserProfile_Sheet1.RowCount = 0;
			enableButton(false);
		}

//		============================== Public Method ==============================
		public bool AddRow(ApplicationUserProfile value)
		{
			if (facadeApplicationUserProfile.InsertApplicationUserProfile(value))
			{
				fpApplicationUserProfile_Sheet1.RowCount++;
				bindApplicationUserProfile(fpApplicationUserProfile_Sheet1.RowCount-1, value);
				enableButton(true);
				return true;
			}
			else
			{return false;}
		}

		public bool UpdateRow(ApplicationUserProfile value)
		{
			if (facadeApplicationUserProfile.UpdateApplicationUserProfile(value))
			{
				bindApplicationUserProfile(SelectedRow, value);				
				return true;
			}
			else
			{return false;}
		}

		public void DeleteRow()
		{
			if (facadeApplicationUserProfile.DeleteApplicationUserProfile(SelectedApplicationUserProfile))
			{
				if(fpApplicationUserProfile_Sheet1.RowCount > 1)
				{
					fpApplicationUserProfile.ActiveSheet.Rows.Remove(SelectedRow,1);
				}
				else
				{clearForm();}				
			}
		}
//		============================== Base Event ==============================
		public void InitForm()
		{
			facadeApplicationUserProfile = new ApplicationUserProfileFacade();
			frmEntry = new frmApplicationUserProfileEntry(this);
		}

		public void RefreshForm()
		{
			try
			{
				if (facadeApplicationUserProfile.DisplayApplicationUserProfile())
				{bindForm();}
				else
				{clearForm();}
			}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(Exception ex)
			{Message(ex);}
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
				frmEntry.InitAddAction();
				frmEntry.ShowDialog();
			}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(Exception ex)
			{Message(ex);}		
		}

		private void EditEvent()
		{
			try
			{
				frmEntry.InitEditAction(SelectedApplicationUserProfile);
				frmEntry.ShowDialog();				
			}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(Exception ex)
			{Message(ex);}		
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
			catch(AppExceptionBase ex)
			{
				Message(ex);
			}
			catch(SqlException sqlex)
			{
				Message(sqlex);
			}
			catch(Exception ex)
			{
				Message(ex);
			}		
		}
//		============================== event ==============================
		private void frmApplicationUserProfile_Load(object sender, System.EventArgs e)
		{
			RefreshForm();
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

		private void fpApplicationUserProfile_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
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
	}
}
