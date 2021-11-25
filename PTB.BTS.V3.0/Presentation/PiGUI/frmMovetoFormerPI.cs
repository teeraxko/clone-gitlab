using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using SystemFramework.AppConfig;
using SystemFramework.AppMessage;
using SystemFramework.AppException;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

using Facade.PiFacade;
using Facade.CommonFacade;

using Presentation.CommonGUI;

namespace Presentation.PiGUI
{
	public class frmMovetoFormerPI  : ChildFormBase, IMDIChildForm	
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
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdOK;
		private FarPoint.Win.Spread.FpSpread fpsMovetoFormerPI;
		private FarPoint.Win.Spread.SheetView fpsMovetoFormerPI_Sheet1;
	
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMovetoFormerPI));
			FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType7 = new FarPoint.Win.Spread.CellType.TextCellType();
			this.fpsMovetoFormerPI = new FarPoint.Win.Spread.FpSpread();
			this.fpsMovetoFormerPI_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.fpsMovetoFormerPI)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsMovetoFormerPI_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// fpsMovetoFormerPI
			// 
			this.fpsMovetoFormerPI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsMovetoFormerPI.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsMovetoFormerPI.Location = new System.Drawing.Point(24, 16);
			this.fpsMovetoFormerPI.Name = "fpsMovetoFormerPI";
			this.fpsMovetoFormerPI.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																						   this.fpsMovetoFormerPI_Sheet1});
			this.fpsMovetoFormerPI.Size = new System.Drawing.Size(816, 432);
			this.fpsMovetoFormerPI.TabIndex = 0;
			// 
			// fpsMovetoFormerPI_Sheet1
			// 
			this.fpsMovetoFormerPI_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsMovetoFormerPI_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsMovetoFormerPI_Sheet1.ColumnCount = 8;
			this.fpsMovetoFormerPI_Sheet1.RowCount = 1;
			this.fpsMovetoFormerPI_Sheet1.Cells.Get(0, 1).Value = false;
			this.fpsMovetoFormerPI_Sheet1.ColumnHeader.Cells.Get(0, 1).ColumnSpan = 2;
			this.fpsMovetoFormerPI_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "ชื่อ - สกุล";
			this.fpsMovetoFormerPI_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "รหัส";
			this.fpsMovetoFormerPI_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "ส่วนงาน";
			this.fpsMovetoFormerPI_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "ตำแหน่ง";
			this.fpsMovetoFormerPI_Sheet1.ColumnHeader.Cells.Get(0, 6).Text = "สถานภาพการทำงาน";
			this.fpsMovetoFormerPI_Sheet1.ColumnHeader.Cells.Get(0, 7).Text = "วันที่มีผลบังคับใช้";
			this.fpsMovetoFormerPI_Sheet1.ColumnHeader.Columns.Default.Resizable = false;
			this.fpsMovetoFormerPI_Sheet1.ColumnHeader.Rows.Get(0).Height = 33F;
			this.fpsMovetoFormerPI_Sheet1.Columns.Default.Resizable = false;
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsMovetoFormerPI_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsMovetoFormerPI_Sheet1.Columns.Get(0).Visible = false;
			this.fpsMovetoFormerPI_Sheet1.Columns.Get(1).AllowAutoSort = true;
			this.fpsMovetoFormerPI_Sheet1.Columns.Get(1).CellType = checkBoxCellType1;
			this.fpsMovetoFormerPI_Sheet1.Columns.Get(1).Label = "ชื่อ - สกุล";
			this.fpsMovetoFormerPI_Sheet1.Columns.Get(1).Width = 19F;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			textCellType2.ReadOnly = true;
			this.fpsMovetoFormerPI_Sheet1.Columns.Get(2).CellType = textCellType2;
			this.fpsMovetoFormerPI_Sheet1.Columns.Get(2).Locked = true;
			this.fpsMovetoFormerPI_Sheet1.Columns.Get(2).Width = 167F;
			this.fpsMovetoFormerPI_Sheet1.Columns.Get(3).AllowAutoSort = true;
			textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType3.DropDownButton = false;
			this.fpsMovetoFormerPI_Sheet1.Columns.Get(3).CellType = textCellType3;
			this.fpsMovetoFormerPI_Sheet1.Columns.Get(3).Label = "รหัส";
			this.fpsMovetoFormerPI_Sheet1.Columns.Get(3).Resizable = true;
			this.fpsMovetoFormerPI_Sheet1.Columns.Get(4).AllowAutoSort = true;
			textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType4.DropDownButton = false;
			textCellType4.MaxLength = 50;
			textCellType4.ReadOnly = true;
			this.fpsMovetoFormerPI_Sheet1.Columns.Get(4).CellType = textCellType4;
			this.fpsMovetoFormerPI_Sheet1.Columns.Get(4).Label = "ส่วนงาน";
			this.fpsMovetoFormerPI_Sheet1.Columns.Get(4).Locked = true;
			this.fpsMovetoFormerPI_Sheet1.Columns.Get(4).Width = 152F;
			this.fpsMovetoFormerPI_Sheet1.Columns.Get(5).AllowAutoSort = true;
			textCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType5.DropDownButton = false;
			textCellType5.MaxLength = 50;
			textCellType5.ReadOnly = true;
			this.fpsMovetoFormerPI_Sheet1.Columns.Get(5).CellType = textCellType5;
			this.fpsMovetoFormerPI_Sheet1.Columns.Get(5).Label = "ตำแหน่ง";
			this.fpsMovetoFormerPI_Sheet1.Columns.Get(5).Locked = true;
			this.fpsMovetoFormerPI_Sheet1.Columns.Get(5).Width = 143F;
			this.fpsMovetoFormerPI_Sheet1.Columns.Get(6).AllowAutoSort = true;
			textCellType6.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType6.DropDownButton = false;
			textCellType6.MaxLength = 50;
			textCellType6.ReadOnly = true;
			this.fpsMovetoFormerPI_Sheet1.Columns.Get(6).CellType = textCellType6;
			this.fpsMovetoFormerPI_Sheet1.Columns.Get(6).Label = "สถานภาพการทำงาน";
			this.fpsMovetoFormerPI_Sheet1.Columns.Get(6).Locked = true;
			this.fpsMovetoFormerPI_Sheet1.Columns.Get(6).Width = 104F;
			this.fpsMovetoFormerPI_Sheet1.Columns.Get(7).AllowAutoSort = true;
			textCellType7.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType7.DropDownButton = false;
			textCellType7.ReadOnly = true;
			this.fpsMovetoFormerPI_Sheet1.Columns.Get(7).CellType = textCellType7;
			this.fpsMovetoFormerPI_Sheet1.Columns.Get(7).Label = "วันที่มีผลบังคับใช้";
			this.fpsMovetoFormerPI_Sheet1.Columns.Get(7).Locked = true;
			this.fpsMovetoFormerPI_Sheet1.Columns.Get(7).Width = 97F;
			this.fpsMovetoFormerPI_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsMovetoFormerPI_Sheet1.RowHeader.Rows.Default.Resizable = false;
			this.fpsMovetoFormerPI_Sheet1.Rows.Default.Resizable = false;
			this.fpsMovetoFormerPI_Sheet1.SheetName = "Sheet1";
			this.fpsMovetoFormerPI_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdCancel.Location = new System.Drawing.Point(448, 488);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 17;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdOK.Location = new System.Drawing.Point(368, 488);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new System.Drawing.Size(72, 23);
			this.cmdOK.TabIndex = 16;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// frmMovetoFormerPI
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(864, 526);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.fpsMovetoFormerPI);
			this.Name = "frmMovetoFormerPI";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //this.Text = "frmMovetoFormerPI";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmMovetoFormerPI_Load);
			this.Closed += new System.EventHandler(this.frmMovetoFormerPI_Closed);
			((System.ComponentModel.ISupportInitialize)(this.fpsMovetoFormerPI)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsMovetoFormerPI_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private EmployeeList objMoveEmployeeList;
		private MovetoFormerPIFacade facadeMovetoFormerPI;
		private frmMain mdiParent;

		#endregion - Private -

//		============================== Constructor ==============================
		public frmMovetoFormerPI() : base()
		{
			InitializeComponent();
			isReadonly = UserProfile.IsReadOnly("miPI", "miPIEmployeeMoveToFormerPI");
            this.title = UserProfile.GetFormName("miPI", "miPIEmployeeMoveToFormerPI");

		}
        public override string FormID()
        {
            return UserProfile.GetFormID("miPI", "miPIEmployeeMoveToFormerPI");
        }
//		============================== Private Method ==============================
		private void newObject()
		{
			facadeMovetoFormerPI = new MovetoFormerPIFacade();
			objMoveEmployeeList = new EmployeeList(facadeMovetoFormerPI.GetCompany());
		}

		private void bindMovetoFormerPI(int i, Employee aEmployee)
		{
			fpsMovetoFormerPI_Sheet1.Cells[i,0].Text = aEmployee.EntityKey;
			fpsMovetoFormerPI_Sheet1.Cells[i,1].Text = "False";
			fpsMovetoFormerPI_Sheet1.Cells[i,2].Text = aEmployee.EmployeeName;
			fpsMovetoFormerPI_Sheet1.Cells[i,3].Text = aEmployee.EmployeeNo;
			fpsMovetoFormerPI_Sheet1.Cells[i,4].Text = GUIFunction.GetString(aEmployee.ASection.AFullName.Thai);
			fpsMovetoFormerPI_Sheet1.Cells[i,5].Text = GUIFunction.GetString(aEmployee.APosition.AName.Thai);
			fpsMovetoFormerPI_Sheet1.Cells[i,6].Text = GUIFunction.GetString(aEmployee.AWorkingStatus.AName.Thai);
			fpsMovetoFormerPI_Sheet1.Cells[i,7].Text = GUIFunction.GetString(aEmployee.TerminationDate.Date.ToShortDateString());
		}
		private void bindForm()
		{
			if (facadeMovetoFormerPI.ObjEmployeeList != null)
			{
				int iRow = facadeMovetoFormerPI.ObjEmployeeList.Count;
				fpsMovetoFormerPI_Sheet1.RowCount = iRow;
				for(int i=0; i<iRow; i++)
				{
					bindMovetoFormerPI(i,facadeMovetoFormerPI.ObjEmployeeList[i]);
				}
				mdiParent.RefreshMasterCount();

			}
		}
		private void MoveEmployee()
		{
			try
			{
				for(int iRow=0; iRow < this.fpsMovetoFormerPI_Sheet1.RowCount; iRow++)
				{
					if(fpsMovetoFormerPI_Sheet1.Cells[iRow,1].Text == "True")
					{
						objMoveEmployeeList.Add(facadeMovetoFormerPI.ObjEmployeeList[fpsMovetoFormerPI_Sheet1.Cells[iRow,3].Text]);
					}
				}
				if(facadeMovetoFormerPI.MoveEmployee(objMoveEmployeeList))
				{
					objMoveEmployeeList.Clear();
					clearForm();
					if (facadeMovetoFormerPI.DisplayEmployeeNotAvailable())
					{
						bindForm();
					}
					else
					{
						clearForm();
					}
				}
			}
			catch(SqlException sqlex)
			{Message(sqlex);}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(Exception ex)
			{Message(ex);}	
		}
//		============================== Public ==============================
		public override int MasterCount()
		{
			return facadeMovetoFormerPI.ObjEmployeeList.Count;
		}
//		============================== Private ==============================
		private void clearForm()
		{
			fpsMovetoFormerPI_Sheet1.RowCount = 0;
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

			try
			{
				if (facadeMovetoFormerPI.DisplayEmployeeNotAvailable())
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
				cmdOK.Enabled = false;
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
			Dispose(true);
		}

		//		============================== Event ==============================
		private void cmdOK_Click(object sender, System.EventArgs e)
		{			
		    MoveEmployee();
		}
		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			ExitForm();
			this.Hide();
		}
		private void frmMovetoFormerPI_Load(object sender, System.EventArgs e)
		{
			mdiParent = (frmMain)this.MdiParent;
			InitForm();
		}

		private void frmMovetoFormerPI_Closed(object sender, System.EventArgs e)
		{
			ExitForm();
		}
	}
}
