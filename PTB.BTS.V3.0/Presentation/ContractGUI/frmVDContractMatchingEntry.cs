using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Entity.CommonEntity;
using Entity.VehicleEntities;
using Entity.ContractEntities;

using Facade.ContractFacade;
using Facade.CommonFacade;

using Presentation.CommonGUI;
using Presentation.VehicleGUI;

using SystemFramework.AppException;
using SystemFramework.AppMessage;
using SystemFramework.AppConfig;

namespace Presentation.ContractGUI
{
	public class frmVDContractMatchingEntry : EntryFormBase
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
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private FarPoint.Win.Spread.FpSpread fpsVehicleContractEntry;
		private FarPoint.Win.Spread.SheetView fpsVehicleContractEntry_Sheet1;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.TextBox txtDocumentType;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtDriverXXX;
		private System.Windows.Forms.TextBox txtDriverMM;
		private System.Windows.Forms.TextBox txtDriverYY;
		private System.Windows.Forms.TextBox txtVehicleXXX;
		private System.Windows.Forms.TextBox txtVehicleMM;
		private System.Windows.Forms.TextBox txtVehicleYY;
		private System.ComponentModel.Container components = null;

		private void InitializeComponent()
		{
			FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtDriverXXX = new System.Windows.Forms.TextBox();
			this.txtDriverMM = new System.Windows.Forms.TextBox();
			this.txtDriverYY = new System.Windows.Forms.TextBox();
			this.txtVehicleXXX = new System.Windows.Forms.TextBox();
			this.txtVehicleMM = new System.Windows.Forms.TextBox();
			this.txtVehicleYY = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtDocumentType = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.fpsVehicleContractEntry = new FarPoint.Win.Spread.FpSpread();
			this.fpsVehicleContractEntry_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fpsVehicleContractEntry)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsVehicleContractEntry_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtDriverXXX);
			this.groupBox1.Controls.Add(this.txtDriverMM);
			this.groupBox1.Controls.Add(this.txtDriverYY);
			this.groupBox1.Controls.Add(this.txtVehicleXXX);
			this.groupBox1.Controls.Add(this.txtVehicleMM);
			this.groupBox1.Controls.Add(this.txtVehicleYY);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtDocumentType);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.label25);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(51, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(516, 88);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "เลขที่สัญญา";
			// 
			// txtDriverXXX
			// 
			this.txtDriverXXX.Location = new System.Drawing.Point(352, 56);
			this.txtDriverXXX.MaxLength = 3;
			this.txtDriverXXX.Name = "txtDriverXXX";
			this.txtDriverXXX.Size = new System.Drawing.Size(40, 20);
			this.txtDriverXXX.TabIndex = 1;
			this.txtDriverXXX.Text = "";
			this.txtDriverXXX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtDriverXXX.DoubleClick += new System.EventHandler(this.txtDriverXXX_DoubleClick);
			// 
			// txtDriverMM
			// 
			this.txtDriverMM.Location = new System.Drawing.Point(320, 56);
			this.txtDriverMM.MaxLength = 2;
			this.txtDriverMM.Name = "txtDriverMM";
			this.txtDriverMM.Size = new System.Drawing.Size(32, 20);
			this.txtDriverMM.TabIndex = 3;
			this.txtDriverMM.Text = "";
			this.txtDriverMM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtDriverMM.TextChanged += new System.EventHandler(this.txtDriverMM_TextChanged);
			// 
			// txtDriverYY
			// 
			this.txtDriverYY.Location = new System.Drawing.Point(288, 56);
			this.txtDriverYY.MaxLength = 2;
			this.txtDriverYY.Name = "txtDriverYY";
			this.txtDriverYY.Size = new System.Drawing.Size(32, 20);
			this.txtDriverYY.TabIndex = 2;
			this.txtDriverYY.Text = "";
			this.txtDriverYY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtDriverYY.TextChanged += new System.EventHandler(this.txtDriverYY_TextChanged);
			// 
			// txtVehicleXXX
			// 
			this.txtVehicleXXX.Location = new System.Drawing.Point(352, 24);
			this.txtVehicleXXX.MaxLength = 3;
			this.txtVehicleXXX.Name = "txtVehicleXXX";
			this.txtVehicleXXX.Size = new System.Drawing.Size(40, 20);
			this.txtVehicleXXX.TabIndex = 118;
			this.txtVehicleXXX.Text = "";
			this.txtVehicleXXX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtVehicleMM
			// 
			this.txtVehicleMM.Location = new System.Drawing.Point(320, 24);
			this.txtVehicleMM.MaxLength = 2;
			this.txtVehicleMM.Name = "txtVehicleMM";
			this.txtVehicleMM.Size = new System.Drawing.Size(32, 20);
			this.txtVehicleMM.TabIndex = 117;
			this.txtVehicleMM.Text = "";
			this.txtVehicleMM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtVehicleYY
			// 
			this.txtVehicleYY.Location = new System.Drawing.Point(288, 24);
			this.txtVehicleYY.MaxLength = 2;
			this.txtVehicleYY.Name = "txtVehicleYY";
			this.txtVehicleYY.Size = new System.Drawing.Size(32, 20);
			this.txtVehicleYY.TabIndex = 116;
			this.txtVehicleYY.Text = "";
			this.txtVehicleYY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBox1
			// 
			this.textBox1.Enabled = false;
			this.textBox1.Location = new System.Drawing.Point(256, 56);
			this.textBox1.MaxLength = 1;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(24, 20);
			this.textBox1.TabIndex = 110;
			this.textBox1.Text = "D";
			this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label3.Location = new System.Drawing.Point(280, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(8, 23);
			this.label3.TabIndex = 115;
			this.label3.Text = "-";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label4.Location = new System.Drawing.Point(216, 56);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 23);
			this.label4.TabIndex = 114;
			this.label4.Text = "PTB -";
			// 
			// txtDocumentType
			// 
			this.txtDocumentType.Enabled = false;
			this.txtDocumentType.Location = new System.Drawing.Point(256, 24);
			this.txtDocumentType.MaxLength = 1;
			this.txtDocumentType.Name = "txtDocumentType";
			this.txtDocumentType.Size = new System.Drawing.Size(24, 20);
			this.txtDocumentType.TabIndex = 104;
			this.txtDocumentType.Text = "C";
			this.txtDocumentType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label12
			// 
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label12.Location = new System.Drawing.Point(280, 24);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(8, 23);
			this.label12.TabIndex = 109;
			this.label12.Text = "-";
			// 
			// label25
			// 
			this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.label25.Location = new System.Drawing.Point(216, 24);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(40, 23);
			this.label25.TabIndex = 108;
			this.label25.Text = "PTB -";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(184, 23);
			this.label2.TabIndex = 101;
			this.label2.Text = "เลขที่สัญญาสำหรับพนักงานขับรถ";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 23);
			this.label1.TabIndex = 102;
			this.label1.Text = "เลขที่สัญญาสำหรับรถ";
			// 
			// fpsVehicleContractEntry
			// 
			this.fpsVehicleContractEntry.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsVehicleContractEntry.Location = new System.Drawing.Point(50, 104);
			this.fpsVehicleContractEntry.Name = "fpsVehicleContractEntry";
			this.fpsVehicleContractEntry.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																								 this.fpsVehicleContractEntry_Sheet1});
			this.fpsVehicleContractEntry.Size = new System.Drawing.Size(517, 296);
			this.fpsVehicleContractEntry.TabIndex = 50;
			this.fpsVehicleContractEntry.TabStop = false;
			// 
			// fpsVehicleContractEntry_Sheet1
			// 
			this.fpsVehicleContractEntry_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsVehicleContractEntry_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsVehicleContractEntry_Sheet1.ColumnCount = 4;
			this.fpsVehicleContractEntry_Sheet1.RowCount = 1;
			this.fpsVehicleContractEntry_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "ทะเบียนรถ";
			this.fpsVehicleContractEntry_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "ชื่อพนักงานขับรถ";
			this.fpsVehicleContractEntry_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ชื่อนายจ้าง";
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsVehicleContractEntry_Sheet1.Columns.Get(0).CellType = textCellType1;
			this.fpsVehicleContractEntry_Sheet1.Columns.Get(0).Visible = false;
			this.fpsVehicleContractEntry_Sheet1.Columns.Get(1).AllowAutoSort = true;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			textCellType2.ReadOnly = true;
			this.fpsVehicleContractEntry_Sheet1.Columns.Get(1).CellType = textCellType2;
			this.fpsVehicleContractEntry_Sheet1.Columns.Get(1).Label = "ทะเบียนรถ";
			this.fpsVehicleContractEntry_Sheet1.Columns.Get(1).Locked = false;
			this.fpsVehicleContractEntry_Sheet1.Columns.Get(1).Resizable = false;
			this.fpsVehicleContractEntry_Sheet1.Columns.Get(1).Width = 98F;
			this.fpsVehicleContractEntry_Sheet1.Columns.Get(2).AllowAutoSort = true;
			comboBoxCellType1.Editable = true;
			this.fpsVehicleContractEntry_Sheet1.Columns.Get(2).CellType = comboBoxCellType1;
			this.fpsVehicleContractEntry_Sheet1.Columns.Get(2).Label = "ชื่อพนักงานขับรถ";
			this.fpsVehicleContractEntry_Sheet1.Columns.Get(2).Locked = false;
			this.fpsVehicleContractEntry_Sheet1.Columns.Get(2).Resizable = false;
			this.fpsVehicleContractEntry_Sheet1.Columns.Get(2).Width = 180F;
			this.fpsVehicleContractEntry_Sheet1.Columns.Get(3).AllowAutoSort = true;
			textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType3.DropDownButton = false;
			this.fpsVehicleContractEntry_Sheet1.Columns.Get(3).CellType = textCellType3;
			this.fpsVehicleContractEntry_Sheet1.Columns.Get(3).Label = "ชื่อนายจ้าง";
			this.fpsVehicleContractEntry_Sheet1.Columns.Get(3).Locked = false;
			this.fpsVehicleContractEntry_Sheet1.Columns.Get(3).Resizable = false;
			this.fpsVehicleContractEntry_Sheet1.Columns.Get(3).Width = 180F;
			this.fpsVehicleContractEntry_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsVehicleContractEntry_Sheet1.Rows.Get(0).Height = 18F;
			this.fpsVehicleContractEntry_Sheet1.SheetName = "Sheet1";
			this.fpsVehicleContractEntry_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// cmdOK
			// 
			this.cmdOK.Location = new System.Drawing.Point(230, 416);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 4;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(310, 416);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 5;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// frmVDContractMatchingEntry
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(616, 454);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.fpsVehicleContractEntry);
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmVDContractMatchingEntry";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "frmVDContractMatchingEntry";
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fpsVehicleContractEntry)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsVehicleContractEntry_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region - Private -
		private bool isReadonly = true;
		private bool isEventTextChanged = true;
		private frmVDContractMatch parentForm;
		private VehicleContract objVehicleContract;
		private DriverContract objDriverContract;
		#endregion

//		============================== Property ==============================
        //D21018 จับคู่สัญญารถยนต์กับสัญญาพนักงานขับรถ ส่ง document type ตามประเภทสัญญา
        private DocumentNo getVehicleContractNo()
		{
			//return new DocumentNo(DOCUMENT_TYPE.CONTRACT, txtVehicleYY.Text, txtVehicleMM.Text, txtVehicleXXX.Text);
            return new DocumentNo(objVehicleContract.ContractNo.DocumentType, txtVehicleYY.Text, txtVehicleMM.Text, txtVehicleXXX.Text);            
		}

        //D21018 จับคู่สัญญารถยนต์กับสัญญาพนักงานขับรถ เปลี่ยน document type จาก contract เป็น contract driver
		private DocumentNo getDriverContractNo()
		{
			//return new DocumentNo(DOCUMENT_TYPE.CONTRACT, txtDriverYY.Text, txtDriverMM.Text, txtDriverXXX.Text);
            return new DocumentNo(DOCUMENT_TYPE.CONTRACT_DRIVER, txtDriverYY.Text, txtDriverMM.Text, txtDriverXXX.Text);
		}

//		============================== Constructor ==============================
		public frmVDContractMatchingEntry(frmVDContractMatch parentForm): base()
		{
			InitializeComponent();
			this.parentForm = parentForm;
			objDriverContract = new DriverContract(parentForm.FacadeVDContractMatch.GetCompany()); 
			objVehicleContract = new VehicleContract(parentForm.FacadeVDContractMatch.GetCompany());
			isReadonly = UserProfile.IsReadOnly("miContract", "miContractDocumentVDContractMatching");
		}
			
//		============================== private method ==============================
		private void setVehicleContract(Company value)
		{
			VehicleRole vehicleRole = new VehicleRole();
			Hirer hirer;
			Driver driver;
			ServiceStaff serviceStaff = new ServiceStaff(value);
			VehicleRoleList vehicleRoleList = new VehicleRoleList(value);

			int iRow = fpsVehicleContractEntry_Sheet1.RowCount;
			string temp, employeeNo;

			if(objDriverContract != null)
			{
				objVehicleContract.ADriverContract = objDriverContract;
			}

			for(int i=0; i<iRow; i++)
			{
				if(fpsVehicleContractEntry_Sheet1.Cells[i,2].Text != "")
				{
					driver = new Driver(value);

					temp = fpsVehicleContractEntry_Sheet1.Cells[i,2].Text;
					employeeNo = parentForm.FacadeVDContractMatch.ObjEmployeeList[temp].EmployeeNo;
					serviceStaff = parentForm.FacadeVDContractMatch.GetServiceStaff(employeeNo);	
					driver.EmployeeNo = employeeNo;
					driver.APosition = serviceStaff.APosition;
					objVehicleContract.AVehicleRoleList[i].ADriver = driver;
				}
				hirer = new Hirer();
				hirer.Name = fpsVehicleContractEntry_Sheet1.Cells[i,3].Text;
				objVehicleContract.AVehicleRoleList[i].AHirer = hirer;
			}					

			driver = null;
			hirer = null;			
		}

		private void setHirer()
		{
			int iRow = fpsVehicleContractEntry_Sheet1.RowCount;
			string vehicleKey;

			Hirer hirer;

			for(int i=0; i<iRow; i++)
			{
				hirer = new Hirer();
				vehicleKey = fpsVehicleContractEntry_Sheet1.Cells[i,0].Text;
				hirer.Name = fpsVehicleContractEntry_Sheet1.Cells[i,3].Text;
				objVehicleContract.AVehicleRoleList[vehicleKey].AHirer = hirer;
			}
		}


		private void InitVehicleContract(VehicleContract value)
		{	
			objVehicleContract = value;

			VehicleContract vehicleContract = new VehicleContract(value.AVehicleRoleList.Company);
			vehicleContract = objVehicleContract;

			if(parentForm.FacadeVDContractMatch.FillVehicleAssignmentList(ref vehicleContract))
			{
				objVehicleContract = vehicleContract;
			}

			txtVehicleYY.Text = value.ContractNo.Year.ToString();
			txtVehicleMM.Text = value.ContractNo.Month.ToString();
			txtVehicleXXX.Text = value.ContractNo.No.ToString();

            //D21018 จับคู่สัญญารถยนต์กับสัญญาพนักงานขับรถ - Set prefix
            txtDocumentType.Text = value.AContractTypeAbbreviation;

		}

		private void InitServiceStaffContract(DriverContract value)
		{	
			if(value != null)
			{
				isEventTextChanged = false;
				objDriverContract = value;
				txtDriverYY.Text = value.ContractNo.Year.ToString();
				txtDriverMM.Text = value.ContractNo.Month.ToString();
				txtDriverXXX.Text = value.ContractNo.No.ToString(); 
				isEventTextChanged = true;
			}
		}

		private void bindVDContractMatch(int row, VehicleRole value, VehicleRoleList aVehicleRoleList)
		{
			fpsVehicleContractEntry_Sheet1.Cells.Get(row,0).Text = GUIFunction.GetString(value.EntityKey);
			fpsVehicleContractEntry_Sheet1.Cells.Get(row,1).Text = GUIFunction.GetString(value.AVehicle.PlateNumber);
			fpsVehicleContractEntry_Sheet1.Cells.Get(row,3).Text = GUIFunction.GetString(value.AHirer.Name);

			Driver driver = new Driver(aVehicleRoleList.Company);
			driver = aVehicleRoleList[value.AVehicle.VehicleNo.ToString()].ADriver;
			if(driver != null && driver.EmployeeName != "")
			{
				fpsVehicleContractEntry_Sheet1.Cells.Get(row,2).Text = GUIFunction.GetString(driver.EmployeeName + " (" + driver.EmployeeNo + ")");
			}
		}

		private void bindForm(VehicleContract value)
		{
			if(value != null)
			{				
				int iRow = value.AVehicleRoleList.Count;
				fpsVehicleContractEntry_Sheet1.RowCount = iRow;

				for(int i=0; i<iRow; i++)
				{
					bindVDContractMatch(i, value.AVehicleRoleList[i] , value.AVehicleRoleList);
				}			
			}
		}

		private void setDatasourceEmployeeList()
		{
			fpsVehicleContractEntry_Sheet1.Columns[2].CellType = parentForm.FacadeVDContractMatch.DataSourceEmployeeList((VehicleContract)parentForm.FacadeVDContractMatch.RetriveContract(getVehicleContractNo()));
		}

		private void setTextBoxEmployeeList()
		{
			FarPoint.Win.Spread.CellType.TextCellType textCellType = new FarPoint.Win.Spread.CellType.TextCellType();
			textCellType.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType.DropDownButton = false;
			textCellType.ReadOnly = true;
			this.fpsVehicleContractEntry_Sheet1.Columns.Get(2).CellType = textCellType;
		}

		private void enableKeyField(bool enable)
		{
			txtDriverYY.Enabled = enable;
			txtDriverMM.Enabled = enable;
			txtDriverXXX.Enabled = enable;
			fpsVehicleContractEntry_Sheet1.Columns.Get(2).Locked = !enable;
		}
		
		private void enableContractStatusConditionForm(VehicleContract value)
		{
			if(value.AContractStatus.Code == "2")
			{
				this.fpsVehicleContractEntry_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.Normal;
				fpsVehicleContractEntry.Enabled = true;
				cmdOK.Enabled = true;
				cmdCancel.Enabled = true;
			}
			else
			{
				this.fpsVehicleContractEntry_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
				cmdOK.Enabled = false;
				cmdCancel.Enabled = true;
				enableKeyField(false);
			}
		}

		private void clearForm()
		{
			txtVehicleYY.Enabled = false;
			txtVehicleMM.Enabled = false;
			txtVehicleXXX.Enabled = false;

			txtDriverYY.Text = "";
			txtDriverMM.Text = "";
			txtDriverXXX.Text = "";
			txtDriverXXX.Focus();

			fpsVehicleContractEntry_Sheet1.RowCount = 0;
		}

		#region - Validate -
		

		private bool validateForm()
		{
			ContractBase contractBase = new ContractBase();
			contractBase = parentForm.FacadeVDContractMatch.RetriveContract(getDriverContractNo());

			if(validateInputContract_1(contractBase))
			{
				if((txtDriverYY.Text == "") && (txtDriverMM.Text == "") && (txtDriverXXX.Text == ""))
				{
					return true;				
				}
				else
				{
					return	validateAvailableEmployee_7() &&
							validateDuplicateDriver_8() &&
							validateNumberOfDriver_9(contractBase);
				}
			}
			return false;

//			return	validateInputContract_1() &&
//					validateServiceStaffContract_2(contractBase) &&					 					
//					validateDupVDMatching_4() && 
//					validateDateFromTo_5() && 
//					validateServiceStaffContractStatus_6(contractBase) &&	
//					validateAvailableEmployee_7() &&
//					validateDuplicateDriver_8() &&
//					validateNumberOfDriver_9(contractBase);					
		}

		private bool validateInputContract_1(ContractBase value)
		{
			int iRow = fpsVehicleContractEntry_Sheet1.RowCount;
			bool result = false;

			for(int i=0; i<iRow; i++)
			{
				if(fpsVehicleContractEntry_Sheet1.Cells[i,2].Text != "")
				{
					result = true;
				}
			}


			if((txtDriverYY.Text == "") && (txtDriverMM.Text == "") && (txtDriverXXX.Text == "")) 
			{
				if(!result)
				{
					return true;
				}
				else
				{
					Message(MessageList.Error.E0002, "เลขที่สัญญาสำหรับพนักงานขับรถ" );
					if(txtDriverYY.Text == "")
					{
						txtDriverYY.Focus();
					}
					else if(txtDriverMM.Text == "")
					{
						txtDriverMM.Focus();
					}
					else
					{
						txtDriverXXX.Focus();
					}					
					return false;
				}				
			}
			else if((txtDriverYY.Text != "") && (txtDriverMM.Text != "") && (txtDriverXXX.Text != "")) 
			{
				if(validateServiceStaffContract_2(value) && validateDupVDMatching_4() && validateDataInServiceStaffContract_4() && validateDateFromTo_5() && validateServiceStaffContractStatus_6(value))
				{
					if(result)
					{
						return true;
					}
					else
					{
						Message(MessageList.Error.E0005, "พนักงานขับรถ");
						return false;
					}
				}
				return false;
			}
			else
			{
				Message(MessageList.Error.E0002, "เลขที่สัญญาสำหรับพนักงานขับรถ" );
				if(txtDriverYY.Text == "")
				{
					txtDriverYY.Focus();
				}
				else if(txtDriverMM.Text == "")
				{
					txtDriverMM.Focus();
				}
				else
				{
					txtDriverXXX.Focus();
				}					
				return false;
			}		
		}
		
		private bool validateServiceStaffContract_2(ContractBase value)
		{
			if(value == null) 
			{
				Message(MessageList.Error.E0004, "เลขที่สัญญาสำหรับพนักงานขับรถ" );
				txtDriverYY.Focus();
				return false;				
			}
			else
			{
				if(value.AContractType.Code != "D")
				{
					Message(MessageList.Error.E0004, "เลขที่สัญญาสำหรับพนักงานขับรถ" );
					txtDriverYY.Focus();
					return false;				
				}
				else
				{
					InitServiceStaffContract((DriverContract)value);
					return true;
				}
			}			
		}

		private bool validateDupVDMatching_4()
		{
			VehicleContract vehicleContract = new VehicleContract(parentForm.FacadeVDContractMatch.GetCompany());
			DriverContract driverContract = new DriverContract(parentForm.FacadeVDContractMatch.GetCompany());

			driverContract.ContractNo = getDriverContractNo();

			vehicleContract.ADriverContract = driverContract;
			driverContract = null;

			if(parentForm.FacadeVDContractMatch.FillVDContractMatch(ref vehicleContract))
			{
				Message(MessageList.Error.E0005, "เลขที่สัญญาสำหรับพนักงานขับรถที่ยังไม่ถูกจับคู่" );
				txtDriverYY.Focus();
				return false;			
			}
			return true;
		}

		private bool validateDataInServiceStaffContract_4()
		{
			parentForm.FacadeVDContractMatch.ObjServiceStaffContract = objDriverContract;

			if(parentForm.FacadeVDContractMatch.DisplayServiceStaffContract())
			{
				Message(MessageList.Error.E0005, "เลขที่สัญญาสำหรับพนักงานขับรถที่ยังไม่ถูกระบุพนักงานในสัญญา" );
				txtDriverYY.Focus();
				return false;			
			}
			return true;
		}

		private bool validateDateFromTo_5()
		{
			if(objVehicleContract.APeriod.From != objDriverContract.APeriod.From || objVehicleContract.APeriod.To != objDriverContract.APeriod.To || objVehicleContract.ACustomerDepartment.ACustomer.Code != objDriverContract.ACustomerDepartment.ACustomer.Code)
			{
				Message(MessageList.Error.E0005, "สัญญาสำหรับพนักงานขับรถที่มีระยะเวลาและชื่อลูกค้าตรงกับสัญญาสำหรับรถ" );
				txtDriverYY.Focus();
				return false;				
			}
			return true;
		}

		private bool validateServiceStaffContractStatus_6(ContractBase value)
		{
			if(value.AContractStatus.Code != "2")
			{
				Message(MessageList.Error.E0016);
				txtDriverYY.Focus();
				return false;				
			}
			return true;
		}

		private bool validateAvailableEmployee_7()
		{
			ContractBase contractBase = new ContractBase();
			contractBase = parentForm.FacadeVDContractMatch.RetriveContract(getDriverContractNo());

			int iRow = fpsVehicleContractEntry_Sheet1.RowCount;
			string temp;
			Employee employee;

			for(int i=0; i<iRow; i++)
			{
				temp = fpsVehicleContractEntry_Sheet1.Cells[i,2].Text;

				if(temp != "")
				{
					employee = parentForm.FacadeVDContractMatch.ObjEmployeeList[temp];
					ServiceStaff serviceStaff = new ServiceStaff(employee);
					if(!parentForm.FacadeVDContractMatch.ValidateVDContractMatch(contractBase, serviceStaff))
					{
						Message(MessageList.Error.E0013, "จับคู่พนักงานขับรถ "+ employee.EmployeeName +" ได้","พนักงานคนนี้ถูกใช้งานในช่วงเวลาดังกล่าว" );
						return false;
					}
				}
			}
			return true;
		}		
		
		private bool validateDuplicateDriver_8()
		{
			bool result = true;
			string temp;
			CommonCollection tempList = new CommonCollection();
	
			for(int i=0; i<fpsVehicleContractEntry_Sheet1.RowCount; i++)
			{
				temp = fpsVehicleContractEntry_Sheet1.Cells[i, 2].Text;
				if(temp!="")
				{
					if(tempList.Contain(temp))
					{
						Message(MessageList.Error.E0014,"ระบุพนักงานขับรถซ้ำกันได้");
						result = false;
					}
					else
					{
						tempList.Add(temp, temp);
					}				
				}
			}
			return result;
		}

		private bool validateNumberOfDriver_9(ContractBase value)
		{
			int rowCount = 0;
			for(int i=0; i<fpsVehicleContractEntry_Sheet1.RowCount; i++)
			{
				if(fpsVehicleContractEntry_Sheet1.Cells[i,2].Text != "")
				{
					rowCount += 1;
				}
			}

			if(value.UnitHire != rowCount) 
			{
				Message(MessageList.Error.E0021, "จำนวนพนักงานขับรถ","จำนวนพนักงานในสัญญา" );
				return false;
			}
			return true;
		}
		# endregion - Validate -
	
		private void formContractList()
		{
			ContractType contractType = new ContractType(); 
			ContractStatus contractStatus = new ContractStatus();
			ContractBase contractBase = new ContractBase();
			frmContractVDOList dialogContractList = new frmContractVDOList();

			dialogContractList.ConditionCustomer = objVehicleContract.ACustomerDepartment.ACustomer;
			dialogContractList.ConditionTimePeriodFrom = objVehicleContract.APeriod;

			contractType.Code = "D";
			dialogContractList.ConditionCONTRACT_TYPE = contractType;

            //D21018 จับคู่สัญญารถยนต์กับสัญญาพนักงานขับรถ - กำหนด Document Type ของ FORM เป็น Driver
            dialogContractList.DocumentType = DOCUMENT_TYPE.CONTRACT_DRIVER; 

			contractStatus.Code = "2";
			dialogContractList.ConditionContractStatus = contractStatus;

			dialogContractList.IsAvailableStaff = true;

			if(txtDriverYY.Text != "")
			{dialogContractList.ConditionYY  = txtDriverYY.Text;}
			if(txtDriverMM.Text != "")
			{dialogContractList.ConditionMM = txtDriverMM.Text;}
			if(txtDriverXXX.Text != "")
			{dialogContractList.ConditionXXX = txtDriverXXX.Text;}

			dialogContractList.ShowDialog();	

			if(dialogContractList.Selected)
			{
				InitServiceStaffContract((DriverContract)dialogContractList.SelectedContract);
			}
		}

//		============================== public method ==============================
		public void InitAddAction(VehicleContract value)
		{
			baseADD();
			clearForm();
			InitVehicleContract(value);
		   	setDatasourceEmployeeList();
			bindForm(value);			
			enableKeyField(true);
			enableContractStatusConditionForm(value);
			this.Text = "จับคู่รถและพนักงานขับรถ";
			DriverFocus();
		}

		public void InitEditAction(VehicleContract value)
		{
			baseEDIT();
			clearForm();
			InitVehicleContract(value);
			InitServiceStaffContract(value.ADriverContract);
			setTextBoxEmployeeList();
			bindForm(value);
			enableKeyField(false);
			enableContractStatusConditionForm(value);
			this.Text = "แก้ไขการจับคู่รถและพนักงานขับรถ";

			if(isReadonly)
			{
				cmdOK.Enabled = false;
			}
		}
		public void DriverFocus()
		{
			txtDriverXXX.Focus();
		}
		
//		============================== Base event ==============================
		private void AddEvent()
		{
			try
			{
				if(validateForm())
				{
					setVehicleContract(parentForm.FacadeVDContractMatch.GetCompany());
					if (parentForm.AddRow(objVehicleContract))
					{
						this.Hide();
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
		private void EditEvent()
		{
			try
			{
				setHirer();
				if (parentForm.UpdateRow(objVehicleContract))
				{
					this.Hide();
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
		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			switch (action)
			{					
				case ActionType.ADD :
					AddEvent();
					break;
				case ActionType.EDIT :
					EditEvent();
					break;
			}
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.Hide();
		}
		
		private void txtDriverXXX_DoubleClick(object sender, System.EventArgs e)
		{
			formContractList();
		}

		private void txtDriverMM_TextChanged(object sender, System.EventArgs e)
		{
			if(isEventTextChanged)
			{
				if(txtDriverMM.Text.Length == 2)
				{txtDriverXXX.Focus();}
			}
		}

		private void txtDriverYY_TextChanged(object sender, System.EventArgs e)
		{
			if(isEventTextChanged)
			{
				if(txtDriverYY.Text.Length == 2)
				{txtDriverMM.Focus();}
			}
		}

		#region - old data -
//		private void txtDriverXXX_TextChanged(object sender, System.EventArgs e)
//		{
//			if(isEventTextChanged)
//			{
//				if(txtDriverXXX.Text.Length == 3)
//				{
//					InitServiceStaffContract((DriverContract)parentForm.FacadeVDContractMatch.RetriveContract(getDriverContractNo()));
//				}
//			}
//		}

//		private void txtDriverXXX_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
//		{
//			if(e.KeyCode == System.Windows.Forms.Keys.Enter)
//			{formContractList();}
//		}
		#endregion
	}
}
