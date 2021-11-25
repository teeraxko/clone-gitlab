using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;
using Entity.ContractEntities;
using Entity.AttendanceEntities;

using Facade.CommonFacade;
using Facade.ContractFacade;

using Presentation.CommonGUI;

using SystemFramework.AppException;
using SystemFramework.AppMessage;

namespace Presentation.ContractGUI
{
	public class frmServiceStaffList : EntryFormBase
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
		private FarPoint.Win.Spread.FpSpread fpsEmp;
		private FarPoint.Win.Spread.SheetView fpsEmp_Sheet1;
		private System.Windows.Forms.MenuItem mniAdd;
		private System.Windows.Forms.MenuItem mniEdit;
		private System.Windows.Forms.MenuItem mniDelete;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdOK;
		private System.ComponentModel.Container components = null;



		private void InitializeComponent()
		{
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
			this.fpsEmp = new FarPoint.Win.Spread.FpSpread();
			this.fpsEmp_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.mniAdd = new System.Windows.Forms.MenuItem();
			this.mniEdit = new System.Windows.Forms.MenuItem();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.fpsEmp)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsEmp_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// fpsEmp
			// 
			this.fpsEmp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsEmp.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsEmp.Location = new System.Drawing.Point(20, 24);
			this.fpsEmp.Name = "fpsEmp";
			this.fpsEmp.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																				this.fpsEmp_Sheet1});
			this.fpsEmp.Size = new System.Drawing.Size(843, 280);
			this.fpsEmp.TabIndex = 0;
			this.fpsEmp.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsEmp_CellDoubleClick);
			// 
			// fpsEmp_Sheet1
			// 
			this.fpsEmp_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsEmp_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsEmp_Sheet1.ColumnCount = 5;
			this.fpsEmp_Sheet1.RowCount = 0;
			this.fpsEmp_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "ชื่อ - สกุล";
			this.fpsEmp_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "รหัส";
			this.fpsEmp_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ส่วนงาน";
			this.fpsEmp_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "ตำแหน่ง";
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsEmp_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsEmp_Sheet1.Columns.Get(0).Visible = false;
			this.fpsEmp_Sheet1.Columns.Get(1).AllowAutoSort = true;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			this.fpsEmp_Sheet1.Columns.Get(1).CellType = textCellType2;
			this.fpsEmp_Sheet1.Columns.Get(1).Label = "ชื่อ - สกุล";
			this.fpsEmp_Sheet1.Columns.Get(1).Resizable = false;
			this.fpsEmp_Sheet1.Columns.Get(1).Width = 227F;
			this.fpsEmp_Sheet1.Columns.Get(2).AllowAutoSort = true;
			textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType3.DropDownButton = false;
			this.fpsEmp_Sheet1.Columns.Get(2).CellType = textCellType3;
			this.fpsEmp_Sheet1.Columns.Get(2).Label = "รหัส";
			this.fpsEmp_Sheet1.Columns.Get(2).Resizable = false;
			this.fpsEmp_Sheet1.Columns.Get(2).Width = 55F;
			this.fpsEmp_Sheet1.Columns.Get(3).AllowAutoSort = true;
			textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType4.DropDownButton = false;
			this.fpsEmp_Sheet1.Columns.Get(3).CellType = textCellType4;
			this.fpsEmp_Sheet1.Columns.Get(3).Label = "ส่วนงาน";
			this.fpsEmp_Sheet1.Columns.Get(3).Resizable = false;
			this.fpsEmp_Sheet1.Columns.Get(3).Width = 250F;
			this.fpsEmp_Sheet1.Columns.Get(4).AllowAutoSort = true;
			textCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType5.DropDownButton = false;
			this.fpsEmp_Sheet1.Columns.Get(4).CellType = textCellType5;
			this.fpsEmp_Sheet1.Columns.Get(4).Label = "ตำแหน่ง";
			this.fpsEmp_Sheet1.Columns.Get(4).Locked = false;
			this.fpsEmp_Sheet1.Columns.Get(4).Resizable = false;
			this.fpsEmp_Sheet1.Columns.Get(4).Width = 250F;
			this.fpsEmp_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
			this.fpsEmp_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsEmp_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
			this.fpsEmp_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsEmp_Sheet1.SheetName = "Sheet1";
			this.fpsEmp_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// mniAdd
			// 
			this.mniAdd.Index = -1;
			this.mniAdd.Text = "เพิ่ม";
			// 
			// mniEdit
			// 
			this.mniEdit.Index = -1;
			this.mniEdit.Text = "แก้ไข";
			// 
			// mniDelete
			// 
			this.mniDelete.Index = -1;
			this.mniDelete.Text = "ลบ";
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdCancel.Location = new System.Drawing.Point(444, 320);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 15;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.cmdOK.Location = new System.Drawing.Point(364, 320);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 14;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// frmServiceStaffList
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(882, 360);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.fpsEmp);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmServiceStaffList";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "รายการพนักงานบริการ";
			this.Load += new System.EventHandler(this.frmServiceStaffList_Load);
			((System.ComponentModel.ISupportInitialize)(this.fpsEmp)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsEmp_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		enum ServiceStaffRoleType
		{
			OTHER,
			DRIVER,
			MACHANIC,
			MACHANICDRIVER,
			NOT_DRIVER,
			NOT_SPECIFIC		
		}
		#region - Private - 
		private int SelectedRow
		{
			get{return fpsEmp_Sheet1.ActiveRowIndex;}
		}

		private string SelectedKey
		{
			get{return fpsEmp_Sheet1.Cells[SelectedRow,0].Text;}
		}

		public ServiceStaff SelectedServiceStaff
		{
			get{return (ServiceStaff)facadeServiceStaffList.ObjEmployeeList[SelectedKey];}
		}

		private bool selected = false;
		public bool Selected
		{
			get{return selected;}
		}
		#endregion

//		============================== Property ==============================
		private ServiceStaffListFacade facadeServiceStaffList;	
		public ServiceStaffListFacade FacadeServiceStaffList
		{
			get{return facadeServiceStaffList;}
		}

		public POSITION_ROLE_TYPE ConditionPositionRole
		{
			get{return facadeServiceStaffList.ConditionServiceStaff.APosition.APositionRole;}
			set{facadeServiceStaffList.ConditionServiceStaff.APosition.APositionRole = value;}
		}

		public string ConditionEmployeeNo
		{
			set{facadeServiceStaffList.ConditionServiceStaff.EmployeeNo = value;}
		}

		public TimePeriod ConditionTimePeriod
		{
			set{facadeServiceStaffList.ConditionTimePeriod = value;}
		}

		private ServiceStaffRoleType serviceStaffRoleType = ServiceStaffRoleType.NOT_SPECIFIC;
		public bool IsDriver
		{
			set
			{
				if(value)
				{
					serviceStaffRoleType = ServiceStaffRoleType.DRIVER;
				}
			}
		}

		public bool IsMachanic
		{
			set
			{
				if(value)
				{
					serviceStaffRoleType = ServiceStaffRoleType.MACHANIC;
				}
			}
		}

		public bool IsOther
		{
			set
			{
				if(value)
				{
					serviceStaffRoleType = ServiceStaffRoleType.OTHER;
				}
			}
		}

		public bool IsNotDriver
		{
			set
			{
				if(value)
				{
					serviceStaffRoleType = ServiceStaffRoleType.NOT_DRIVER;
				}
			}
		}

		public bool IsMachanicDriver
		{
			set
			{
				if(value)
				{
					serviceStaffRoleType = ServiceStaffRoleType.MACHANICDRIVER;
				}
			}
		}

//		============================== Constructor ==============================
		public frmServiceStaffList(): base()
		{
			InitializeComponent();
			facadeServiceStaffList = new ServiceStaffListFacade();
		}

//		============================== private method ==============================
		private void bindEmployee(int row, Employee aEmployee)
		{
			fpsEmp_Sheet1.Cells[row,0].Text = GUIFunction.GetString(aEmployee.EntityKey);
			fpsEmp_Sheet1.Cells[row,1].Text = GUIFunction.GetString(aEmployee.EmployeeName);
			fpsEmp_Sheet1.Cells[row,2].Text = GUIFunction.GetString(aEmployee.EmployeeNo);
			fpsEmp_Sheet1.Cells[row,3].Text = GUIFunction.GetString(aEmployee.ASection.AFullName.Thai);
			fpsEmp_Sheet1.Cells[row,4].Text = GUIFunction.GetString(aEmployee.APosition.AName.Thai);
		}

		private void bindForm()
		{
			if (facadeServiceStaffList.ObjEmployeeList != null)
			{
				int iRow = facadeServiceStaffList.ObjEmployeeList.Count;
				fpsEmp_Sheet1.RowCount = iRow;
				for(int i=0; i<iRow; i++)
				{
					bindEmployee(i,facadeServiceStaffList.ObjEmployeeList[i]);
				}				
			}
		}

		private void enableButton(bool enable)
		{
			
		}

		private void clearForm()
		{
			fpsEmp_Sheet1.RowCount = 0;
			cmdOK.Enabled  = false;
			cmdCancel.Enabled = true;
		}

//		============================== Base Event ==============================
		public void InitForm()
		{
			try
			{
				switch(serviceStaffRoleType)
				{
					case ServiceStaffRoleType.DRIVER :
					{
						ConditionPositionRole = POSITION_ROLE_TYPE.DRIVER;
						if (facadeServiceStaffList.DisplayServiceStaffByRole())
						{
							bindForm();
						}
						else
						{
							selected = false;
							clearForm();
						}
						break;
					}
					case ServiceStaffRoleType.MACHANIC :
					{
						ConditionPositionRole = POSITION_ROLE_TYPE.MACHANIC;
						if (facadeServiceStaffList.DisplayServiceStaffByRole())
						{
							bindForm();
						}
						else
						{
							selected = false;
							clearForm();
						}
						break;
					}
					case ServiceStaffRoleType.OTHER :
					{
						ConditionPositionRole = POSITION_ROLE_TYPE.BLANK;
						if (facadeServiceStaffList.DisplayServiceStaffByRole())
						{
							bindForm();
						}
						else
						{
							selected = false;
							clearForm();
						}
						break;
					}
					case ServiceStaffRoleType.NOT_DRIVER :
					{
						if (facadeServiceStaffList.DisplayServiceStaffNotDriver())
						{
							bindForm();
						}
						else
						{
							selected = false;
							clearForm();
						}
						break;
					}
					case ServiceStaffRoleType.MACHANICDRIVER :
					{
						if (facadeServiceStaffList.DisplayServiceStaffMachanicDriver())
						{
							bindForm();
						}
						else
						{
							selected = false;
							clearForm();
						}
						break;
					}
					default :
					{
						if (facadeServiceStaffList.DisplayServiceStaff())
						{
							bindForm();
						}
						else
						{
							selected = false;
							clearForm();
						}
						break;
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

		private void AddEvent()
		{
		}

		private void EditEvent()
		{
			selected = true;
			this.Hide();
		}

//		==============================Event ==============================
		private void frmServiceStaffList_Load(object sender, System.EventArgs e)
		{
			selected = false;
			InitForm();
		}

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			EditEvent();
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			selected = false;
			this.Hide();
		}

		private void fpsEmp_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader)
			{
				EditEvent();
			}		
		}
	}
}
