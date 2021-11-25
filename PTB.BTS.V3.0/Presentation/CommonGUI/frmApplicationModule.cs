using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Data.SqlClient;

using SystemFramework.AppMessage;
using SystemFramework.AppException;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

namespace Presentation.CommonGUI
{
	public class frmApplicationModule : ChildFormBase, IMDIChildForm
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

		protected System.Windows.Forms.Button cmdOK;
		protected System.Windows.Forms.Button cmdCancel;
		private FarPoint.Win.Spread.FpSpread fpApplicationModule;
		private FarPoint.Win.Spread.SheetView fpApplicationModule_Sheet1;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem mniAdd;
		private System.Windows.Forms.MenuItem mniEdit;
		private System.Windows.Forms.MenuItem mniDelete;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmApplicationModule));
			this.fpApplicationModule = new FarPoint.Win.Spread.FpSpread();
			this.fpApplicationModule_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mniAdd = new System.Windows.Forms.MenuItem();
			this.mniEdit = new System.Windows.Forms.MenuItem();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			((System.ComponentModel.ISupportInitialize)(this.fpApplicationModule)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpApplicationModule_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// fpApplicationModule
			// 
			this.fpApplicationModule.ContextMenu = this.contextMenu1;
			this.fpApplicationModule.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpApplicationModule.Location = new System.Drawing.Point(27, 24);
			this.fpApplicationModule.Name = "fpApplicationModule";
			this.fpApplicationModule.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																							 this.fpApplicationModule_Sheet1});
			this.fpApplicationModule.Size = new System.Drawing.Size(501, 344);
			this.fpApplicationModule.TabIndex = 0;
			// 
			// fpApplicationModule_Sheet1
			// 
			this.fpApplicationModule_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpApplicationModule_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpApplicationModule_Sheet1.ColumnCount = 4;
			this.fpApplicationModule_Sheet1.RowCount = 1;
			this.fpApplicationModule_Sheet1.ColumnHeader.Cells.Get(0, 0).Text = "Key";
			this.fpApplicationModule_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "ModuleName";
			this.fpApplicationModule_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "ModuleDescription";
			this.fpApplicationModule_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "SystemStatus";
			this.fpApplicationModule_Sheet1.Columns.Get(0).Label = "Key";
			this.fpApplicationModule_Sheet1.Columns.Get(0).Visible = false;
			this.fpApplicationModule_Sheet1.Columns.Get(1).AllowAutoSort = true;
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpApplicationModule_Sheet1.Columns.Get(1).CellType = textCellType1;
			this.fpApplicationModule_Sheet1.Columns.Get(1).Label = "ModuleName";
			this.fpApplicationModule_Sheet1.Columns.Get(1).Resizable = false;
			this.fpApplicationModule_Sheet1.Columns.Get(1).Width = 120F;
			this.fpApplicationModule_Sheet1.Columns.Get(2).AllowAutoSort = true;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			this.fpApplicationModule_Sheet1.Columns.Get(2).CellType = textCellType2;
			this.fpApplicationModule_Sheet1.Columns.Get(2).Label = "ModuleDescription";
			this.fpApplicationModule_Sheet1.Columns.Get(2).Resizable = false;
			this.fpApplicationModule_Sheet1.Columns.Get(2).Width = 250F;
			this.fpApplicationModule_Sheet1.Columns.Get(3).AllowAutoSort = true;
			checkBoxCellType1.ThreeState = true;
			this.fpApplicationModule_Sheet1.Columns.Get(3).CellType = checkBoxCellType1;
			this.fpApplicationModule_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpApplicationModule_Sheet1.Columns.Get(3).Label = "SystemStatus";
			this.fpApplicationModule_Sheet1.Columns.Get(3).Resizable = false;
			this.fpApplicationModule_Sheet1.Columns.Get(3).Width = 76F;
			this.fpApplicationModule_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
			this.fpApplicationModule_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpApplicationModule_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
			this.fpApplicationModule_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpApplicationModule_Sheet1.SheetName = "Sheet1";
			this.fpApplicationModule_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// cmdOK
			// 
			this.cmdOK.Location = new System.Drawing.Point(200, 384);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 6;
			this.cmdOK.Text = "บันทึก";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(280, 384);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 5;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
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
			// frmApplicationModule
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(554, 423);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.fpApplicationModule);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmApplicationModule";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "frmApplicationModule";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			((System.ComponentModel.ISupportInitialize)(this.fpApplicationModule)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpApplicationModule_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private - 
		#endregion

//		============================== Property ==============================

//		============================== Constructor ==============================
		public frmApplicationModule()
		{
			InitializeComponent();
		}


//		============================== Private Method ==============================

//		============================== Public Method ==============================

//		============================== Base Event ==============================
		public void InitForm()
		{
			try
			{

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

		public void RefreshForm()
		{
		}

		public void PrintForm()
		{
		}

		public void ExitForm()
		{
		}

//		============================== event ==============================
		private void mniAdd_Click(object sender, System.EventArgs e)
		{
		
		}

		private void mniEdit_Click(object sender, System.EventArgs e)
		{
		
		}

		private void mniDelete_Click(object sender, System.EventArgs e)
		{
		
		}

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
		
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
