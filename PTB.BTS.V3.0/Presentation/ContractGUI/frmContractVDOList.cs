using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

using Entity.ContractEntities;
using Entity.CommonEntity;
using Entity.AttendanceEntities;

using Facade.ContractFacade;
using Facade.CommonFacade;

using Presentation.CommonGUI;

using SystemFramework.AppException;
using SystemFramework.AppMessage;

namespace Presentation.ContractGUI
{
	public class frmContractVDOList : EntryFormBase
	{
		#region Windows Form Designer generated code
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
		private FarPoint.Win.Spread.FpSpread fpsContractList;
		private FarPoint.Win.Spread.SheetView fpsContractList_Sheet1;
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
			FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
			FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType1 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmContractVDOList));
			FarPoint.Win.Spread.CellType.DateTimeCellType dateTimeCellType2 = new FarPoint.Win.Spread.CellType.DateTimeCellType();
			FarPoint.Win.Spread.CellType.TextCellType textCellType7 = new FarPoint.Win.Spread.CellType.TextCellType();
			this.fpsContractList = new FarPoint.Win.Spread.FpSpread();
			this.fpsContractList_Sheet1 = new FarPoint.Win.Spread.SheetView();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.fpsContractList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsContractList_Sheet1)).BeginInit();
			this.SuspendLayout();
			// 
			// fpsContractList
			// 
			this.fpsContractList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.fpsContractList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
			this.fpsContractList.Location = new System.Drawing.Point(10, 8);
			this.fpsContractList.Name = "fpsContractList";
			this.fpsContractList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
																						 this.fpsContractList_Sheet1});
			this.fpsContractList.Size = new System.Drawing.Size(950, 344);
			this.fpsContractList.TabIndex = 0;
			this.fpsContractList.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.fpsContractList_CellDoubleClick);
			// 
			// fpsContractList_Sheet1
			// 
			this.fpsContractList_Sheet1.Reset();
			// Formulas and custom names must be loaded with R1C1 reference style
			this.fpsContractList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
			this.fpsContractList_Sheet1.ColumnCount = 9;
			this.fpsContractList_Sheet1.RowCount = 2;
			textCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType1.DropDownButton = false;
			this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 1).CellType = textCellType1;
			this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 1).Text = "สถานะสัญญา";
			this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 2).Text = "เลขที่สัญญา";
			this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ประเภทสัญญา";
			this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "ทะเบียนรถ";
			this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 5).Text = "ลูกค้า";
			this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 6).Text = "วันที่เริ่มต้นสัญญา";
			this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 7).Text = "วันที่สิ้นสุดสัญญา";
			this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 8).Text = "ชนิดสัญญา";
			this.fpsContractList_Sheet1.ColumnHeader.Columns.Default.Resizable = false;
			this.fpsContractList_Sheet1.Columns.Default.Resizable = false;
			textCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType2.DropDownButton = false;
			this.fpsContractList_Sheet1.Columns.Get(0).CellType = textCellType2;
			this.fpsContractList_Sheet1.Columns.Get(0).Visible = false;
			this.fpsContractList_Sheet1.Columns.Get(1).AllowAutoSort = true;
			this.fpsContractList_Sheet1.Columns.Get(1).Label = "สถานะสัญญา";
			this.fpsContractList_Sheet1.Columns.Get(1).Width = 73F;
			this.fpsContractList_Sheet1.Columns.Get(2).AllowAutoSort = true;
			textCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType3.DropDownButton = false;
			this.fpsContractList_Sheet1.Columns.Get(2).CellType = textCellType3;
			this.fpsContractList_Sheet1.Columns.Get(2).Label = "เลขที่สัญญา";
			this.fpsContractList_Sheet1.Columns.Get(2).Width = 90F;
			this.fpsContractList_Sheet1.Columns.Get(3).AllowAutoSort = true;
			textCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType4.DropDownButton = false;
			this.fpsContractList_Sheet1.Columns.Get(3).CellType = textCellType4;
			this.fpsContractList_Sheet1.Columns.Get(3).Label = "ประเภทสัญญา";
			this.fpsContractList_Sheet1.Columns.Get(3).Width = 150F;
			this.fpsContractList_Sheet1.Columns.Get(4).AllowAutoSort = true;
			textCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType5.DropDownButton = false;
			this.fpsContractList_Sheet1.Columns.Get(4).CellType = textCellType5;
			this.fpsContractList_Sheet1.Columns.Get(4).Label = "ทะเบียนรถ";
			this.fpsContractList_Sheet1.Columns.Get(4).Width = 160F;
			this.fpsContractList_Sheet1.Columns.Get(5).AllowAutoSort = true;
			textCellType6.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType6.DropDownButton = false;
			this.fpsContractList_Sheet1.Columns.Get(5).CellType = textCellType6;
			this.fpsContractList_Sheet1.Columns.Get(5).Label = "ลูกค้า";
			this.fpsContractList_Sheet1.Columns.Get(5).Width = 120F;
			this.fpsContractList_Sheet1.Columns.Get(6).AllowAutoSort = true;
			dateTimeCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			dateTimeCellType1.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
			dateTimeCellType1.DateDefault = new System.DateTime(2005, 10, 26, 15, 4, 9, 0);
			dateTimeCellType1.DropDownButton = false;
			dateTimeCellType1.TimeDefault = new System.DateTime(2005, 10, 26, 15, 4, 9, 0);
			this.fpsContractList_Sheet1.Columns.Get(6).CellType = dateTimeCellType1;
			this.fpsContractList_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsContractList_Sheet1.Columns.Get(6).Label = "วันที่เริ่มต้นสัญญา";
			this.fpsContractList_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
			this.fpsContractList_Sheet1.Columns.Get(6).Width = 90F;
			this.fpsContractList_Sheet1.Columns.Get(7).AllowAutoSort = true;
			dateTimeCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			dateTimeCellType2.Calendar = new System.Globalization.GregorianCalendar(System.Globalization.GregorianCalendarTypes.Localized);
			dateTimeCellType2.DateDefault = new System.DateTime(2005, 10, 26, 15, 4, 12, 0);
			dateTimeCellType2.DropDownButton = false;
			dateTimeCellType2.TimeDefault = new System.DateTime(2005, 10, 26, 15, 4, 12, 0);
			this.fpsContractList_Sheet1.Columns.Get(7).CellType = dateTimeCellType2;
			this.fpsContractList_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
			this.fpsContractList_Sheet1.Columns.Get(7).Label = "วันที่สิ้นสุดสัญญา";
			this.fpsContractList_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
			this.fpsContractList_Sheet1.Columns.Get(7).Width = 90F;
			this.fpsContractList_Sheet1.Columns.Get(8).AllowAutoSort = true;
			textCellType7.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
			textCellType7.DropDownButton = false;
			this.fpsContractList_Sheet1.Columns.Get(8).CellType = textCellType7;
			this.fpsContractList_Sheet1.Columns.Get(8).Label = "ชนิดสัญญา";
			this.fpsContractList_Sheet1.Columns.Get(8).Width = 120F;
			this.fpsContractList_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
			this.fpsContractList_Sheet1.RowHeader.Columns.Default.Resizable = false;
			this.fpsContractList_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
			this.fpsContractList_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
			this.fpsContractList_Sheet1.SheetName = "Sheet1";
			this.fpsContractList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.Location = new System.Drawing.Point(488, 368);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 6;
			this.cmdCancel.Text = "ยกเลิก";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cmdOK.Location = new System.Drawing.Point(408, 368);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 5;
			this.cmdOK.Text = "ตกลง";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// frmContractVDOList
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(970, 408);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.fpsContractList);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(222)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmContractVDOList";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "รายการเอกสารสัญญา";
			this.Load += new System.EventHandler(this.frmContractVDOList_Load);
			((System.ComponentModel.ISupportInitialize)(this.fpsContractList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fpsContractList_Sheet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region - Constant -
		enum ContractListType
		{
			VEHICLE,
			DRIVER_OTHER,
			AVAILABLE_STAFF,
			CONTRACT_VEHICLE,
			CONTRACT_DRIVER,
			CONTRACT_SERVICESTAFF,
            VEHICLE_PURCHASING,
			NOT_SPECIFIC
		}
		#endregion
				
		#region Private
		private int SelectedRow
		{
			get{return fpsContractList_Sheet1.ActiveRowIndex;}
		}

		private string SelectedKey
		{
			get{return fpsContractList_Sheet1.Cells[SelectedRow,0].Text;}
		}

		public ContractBase SelectedContract
		{
			get{return (ContractBase)facadeListContract.ObjContractList[SelectedKey];}
		}

		private bool selected;
		public bool Selected
		{
			get{return selected;}
		}

        private ContractListType contractListType = ContractListType.NOT_SPECIFIC;
        #endregion

        #region Property
        private ContractListFacade facadeListContract;
        public ContractListFacade FacadeListContract
        {
            get { return facadeListContract; }
        }

        public Customer ConditionCustomer
        {
            set { facadeListContract.ConditionContract.ACustomerDepartment.ACustomer = value; }
        }

        public ContractType ConditionCONTRACT_TYPE
        {
            set { facadeListContract.ConditionContract.AContractType = value; }
        }

        public ContractStatus ConditionContractStatus
        {
            set { facadeListContract.ConditionContract.AContractStatus = value; }
        }

        public string ConditionYY
        {
            set { facadeListContract.YY = value; }
        }

        public string ConditionMM
        {
            set { facadeListContract.MM = value; }
        }

        public string ConditionXXX
        {
            set { facadeListContract.XXX = value; }
        }

        //D21018-BTS Contract Modification
        private DocumentNo contractNo;
        public DocumentNo ContractNo
        {
            set { contractNo = value; }
        }

        //D21018-BTS Contract Modification
        private DOCUMENT_TYPE documentType;
        public DOCUMENT_TYPE DocumentType
        {
            get { return documentType; }
            set { documentType = value; }
        }

        public bool IsVehicleContract
        {
            set
            {
                if (value)
                    contractListType = ContractListType.VEHICLE;
            }
        }

        public bool IsDOContract
        {
            set
            {
                if (value)
                    contractListType = ContractListType.DRIVER_OTHER;
            }
        }

        public bool IsAvailableStaff
        {
            set
            {
                if (value)
                {
                    contractListType = ContractListType.AVAILABLE_STAFF;
                }
            }
        }

        public bool IsContractVehicleList
        {
            set
            {
                if (value)
                {
                    contractListType = ContractListType.CONTRACT_VEHICLE;
                }
            }
        }

        public bool IsContractDriverList
        {
            set
            {
                if (value)
                {
                    contractListType = ContractListType.CONTRACT_DRIVER;
                }
            }
        }

        public bool IsContractServiceStaffList
        {
            set
            {
                if (value)
                {
                    contractListType = ContractListType.CONTRACT_SERVICESTAFF;
                }
            }
        }

        public bool IsVehclePurchaing
        {
            set
            {
                if (value)
                {
                    contractListType = ContractListType.VEHICLE_PURCHASING;
                }
            }
        }

        public TimePeriod ConditionTimePeriodFrom
        {
            set { facadeListContract.ConditionContract.APeriod = value; }
        } 
        #endregion

        #region Constructor
        public frmContractVDOList()
            : base()
        {
            InitializeComponent();
            facadeListContract = new ContractListFacade();          
           
        } 
        #endregion

//		============================== private method ==============================
		private void bindContract(int row, VehicleContract objVehicleContract, VehicleRole objVehicleRole)
		{
			fpsContractList_Sheet1.Cells[row,0].Text = GUIFunction.GetString(objVehicleContract.EntityKey);
			fpsContractList_Sheet1.Cells[row,1].Text = GUIFunction.GetString(objVehicleContract.AContractStatus);
			fpsContractList_Sheet1.Cells[row,2].Text = GUIFunction.GetString(objVehicleContract.ContractNo.ToString());

            if (contractListType == ContractListType.VEHICLE_PURCHASING)
            {
                fpsContractList_Sheet1.Cells[row, 3].Text = facadeListContract.GetPurchaseNoByContract(objVehicleContract.ContractNo);         
            }
            else
            {
                fpsContractList_Sheet1.Cells[row, 3].Text = GUIFunction.GetString(objVehicleContract.AContractType);
            }

			if (objVehicleRole == null)
				fpsContractList_Sheet1.Cells[row,4].Text = "";
			else
				fpsContractList_Sheet1.Cells[row,4].Text = objVehicleRole.AVehicle.PlateNumber;					

			fpsContractList_Sheet1.Cells[row,5].Text = GUIFunction.GetString(objVehicleContract.ACustomerDepartment.ACustomer.ShortName);
			fpsContractList_Sheet1.Cells[row,6].Text = GUIFunction.GetString(objVehicleContract.APeriod.From.Date.ToShortDateString());
			fpsContractList_Sheet1.Cells[row,7].Text = GUIFunction.GetString(objVehicleContract.APeriod.To.Date.ToShortDateString());
			fpsContractList_Sheet1.Cells[row,8].Text = GUIFunction.GetString(objVehicleContract.AKindOfContract.AName.Thai);
		}

		private void bindContract(int row, ServiceStaffContract objServiceStaffContract, ServiceStaffRole objServiceStaffRole)
		{
			fpsContractList_Sheet1.Cells[row,0].Text = GUIFunction.GetString(objServiceStaffContract.EntityKey);
			fpsContractList_Sheet1.Cells[row,1].Text = GUIFunction.GetString(objServiceStaffContract.AContractStatus);
			fpsContractList_Sheet1.Cells[row,2].Text = GUIFunction.GetString(objServiceStaffContract.ContractNo.ToString());
            if (objServiceStaffRole == null)
            {
                fpsContractList_Sheet1.Cells[row, 3].Text = "";
                fpsContractList_Sheet1.Cells[row, 4].Text = "";
            }
            else
            {
                fpsContractList_Sheet1.Cells[row, 3].Text = objServiceStaffRole.AServiceStaffType.ADescription.Thai;
                fpsContractList_Sheet1.Cells[row, 4].Text = objServiceStaffRole.AServiceStaff.EmployeeName;
            }

			fpsContractList_Sheet1.Cells[row,5].Text = GUIFunction.GetString(objServiceStaffContract.ACustomerDepartment.ACustomer.ShortName);
			fpsContractList_Sheet1.Cells[row,6].Text = GUIFunction.GetString(objServiceStaffContract.APeriod.From.Date.ToShortDateString());
			fpsContractList_Sheet1.Cells[row,7].Text = GUIFunction.GetString(objServiceStaffContract.APeriod.To.Date.ToShortDateString());
			fpsContractList_Sheet1.Cells[row,8].Text = GUIFunction.GetString(objServiceStaffContract.AKindOfContract.AName.Thai);
		}


		private void bindForm()
		{
			if (facadeListContract.ObjContractList != null)
			{			
				int iRow = 0;
				int iCount = facadeListContract.ObjContractList.Count;

				if (contractListType.Equals(ContractListType.VEHICLE) || contractListType.Equals(ContractListType.CONTRACT_VEHICLE) || contractListType.Equals(ContractListType.VEHICLE_PURCHASING))
				{
					for (int i=0; i<iCount; i++)
					{
						int iListCount = ((VehicleContract)facadeListContract.ObjContractList[i]).AVehicleRoleList.Count;
						if (iListCount == 0)
							++iRow;
						else
							iRow = iRow + iListCount;
					}

					fpsContractList_Sheet1.RowCount = iRow;	
					iRow = 0;

					for(int i=0; i<iCount; i++)
					{
						VehicleContract vehicleContract = (VehicleContract)facadeListContract.ObjContractList[i];
						
						if (vehicleContract.AVehicleRoleList.Count == 0)
						{
							bindContract(iRow, vehicleContract, null);
							++iRow;
						}
						else
						{
							for (int j=0; j<vehicleContract.AVehicleRoleList.Count; j++)
							{
								bindContract(iRow, vehicleContract, vehicleContract.AVehicleRoleList[j]);	
								++iRow;
							}
						}
					}		
				}
				else
				{
					for (int i=0; i<iCount; i++)
					{
						int iListCount = ((ServiceStaffContract)facadeListContract.ObjContractList[i]).ALatestServiceStaffRoleList.Count;
						if (iListCount == 0)
							++iRow;
						else
							iRow = iRow + iListCount;
					}

					fpsContractList_Sheet1.RowCount = iRow;	
					iRow = 0;

					for(int i=0; i<iCount; i++)
					{
						ServiceStaffContract serviceStaffContract = (ServiceStaffContract)facadeListContract.ObjContractList[i];
						
						if (serviceStaffContract.ALatestServiceStaffRoleList.Count == 0)
						{
							bindContract(iRow, serviceStaffContract, null);
							++iRow;
						}
						else
						{
							for (int j=0; j<serviceStaffContract.ALatestServiceStaffRoleList.Count; j++)
							{
								bindContract(iRow, serviceStaffContract, serviceStaffContract.ALatestServiceStaffRoleList[j]);	
								++iRow;
							}
						}
					}		
				}						
			}
		}

		private void clearForm()
		{
			fpsContractList_Sheet1.RowCount = 0;
			cmdOK.Enabled = false;
		}

		private void bindData()
		{
			fpsContractList_Sheet1.RowCount = 0;
			if (facadeListContract.ObjContractList != null)
			{
				int iCount = facadeListContract.ObjContractList.Count;

				for(int i=0; i<iCount; i++)
				{
					if(facadeListContract.ObjContractList[i].AContractType.Code.Equals("V"))
					{
						VehicleContract vehicleContract = (VehicleContract)facadeListContract.ObjContractList[i];

						if (vehicleContract.AVehicleRoleList.Count == 0)
						{
							fpsContractList_Sheet1.AddRows(fpsContractList_Sheet1.Rows.Count, 1);
							bindContract(fpsContractList_Sheet1.Rows.Count-1, vehicleContract, null);
						}
						else
						{
							for (int j=0; j<vehicleContract.AVehicleRoleList.Count; j++)
							{
								fpsContractList_Sheet1.AddRows(fpsContractList_Sheet1.Rows.Count, 1);
								bindContract(fpsContractList_Sheet1.Rows.Count-1, vehicleContract, vehicleContract.AVehicleRoleList[j]);	
							}
						}
					}
					else
					{
						ServiceStaffContract serviceStaffContract = (ServiceStaffContract)facadeListContract.ObjContractList[i];

						if (serviceStaffContract.ALatestServiceStaffRoleList.Count == 0)
						{
							fpsContractList_Sheet1.AddRows(fpsContractList_Sheet1.Rows.Count, 1);
							bindContract(fpsContractList_Sheet1.Rows.Count-1, serviceStaffContract, null);
						}
						else
						{
							for (int j=0; j<serviceStaffContract.ALatestServiceStaffRoleList.Count; j++)
							{
								fpsContractList_Sheet1.AddRows(fpsContractList_Sheet1.Rows.Count, 1);
								bindContract(fpsContractList_Sheet1.Rows.Count-1, serviceStaffContract, serviceStaffContract.ALatestServiceStaffRoleList[j]);	
							}
						}
					}
				}
			}
		}

//		============================== Base Event ==============================
		public void InitForm()
		{
			try
			{
				switch(contractListType)
				{
					case ContractListType.VEHICLE :
					{
						this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "ทะเบียนรถ";
						if (facadeListContract.DisplayVehicleContract())
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
					case ContractListType.DRIVER_OTHER :
					{
                        this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ประเภท";
                        this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "พนักงาน";
						if (facadeListContract.DisplayDriverOtherContract())
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
					case ContractListType.AVAILABLE_STAFF :
					{
                        this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ประเภท";
                        this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "พนักงาน";
						if (facadeListContract.DisplayAvailableContract())
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
                    //case ContractListType.CONTRACT_VEHICLE :
                    //{
                    //    this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "ทะเบียนรถ";
                    //    if (facadeListContract.DisplayContract())
                    //    {
                    //        bindForm();
                    //    }
                    //    else
                    //    {
                    //        selected = false;
                    //        clearForm();
                    //    } 
                    //    break;
                    //}

                    case ContractListType.CONTRACT_VEHICLE:
                    {
                        //D21018-BTS Contract Modification
                        if (this.contractNo.DocumentType == DOCUMENT_TYPE.CONTRACT_RENEWAL)
                        {
                            this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "ทะเบียนรถ";
                            if (facadeListContract.DisplayVehicleContract(DOCUMENT_TYPE.CONTRACT_RENEWAL))
                            {
                                bindForm();
                            }
                            else
                            {
                                selected = false;
                                clearForm();
                            }
                        }
                        else if (this.contractNo.DocumentType == DOCUMENT_TYPE.CONTRACT_TEMPORARY)
                        {
                            this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "ทะเบียนรถ";
                            if (facadeListContract.DisplayVehicleContract(DOCUMENT_TYPE.CONTRACT_TEMPORARY))
                            {
                                bindForm();
                            }
                            else
                            {
                                selected = false;
                                clearForm();
                            }
                        }
                        else
                        {
                            this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "ทะเบียนรถ";
                            if (facadeListContract.DisplayContract())
                            {
                                bindForm();
                            }
                            else
                            {
                                selected = false;
                                clearForm();
                            }
                        }
                        break;
                    }
					case ContractListType.CONTRACT_DRIVER :
					{
                        this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ประเภท";
                        this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "พนักงาน";
						if (facadeListContract.DisplayContract())
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
					case ContractListType.CONTRACT_SERVICESTAFF :
					{
                        this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "ประเภท";
                        this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "พนักงาน";
						if (facadeListContract.DisplayContract())
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
                    case ContractListType.VEHICLE_PURCHASING:
                    {
                        this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "ทะเบียนรถ";
                        this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 3).Text = "เลขที่ใบสั่งซื้อ";
                        this.fpsContractList_Sheet1.Columns[3].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;

                        if (facadeListContract.DisplayContractVehiclePurchasing())
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
                        //this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "พนักงาน/ทะเบียนรถ";
                        //if (facadeListContract.DisplayContract())
                        //{
                        //    bindData();
                        //}
                        //else
                        //{
                        //    selected = false;
                        //    clearForm();
                        //}
                        //break;    
                        //D21018-BTS Contract Modification
                        this.fpsContractList_Sheet1.ColumnHeader.Cells.Get(0, 4).Text = "พนักงาน/ทะเบียนรถ";
                        if (this.DocumentType == DOCUMENT_TYPE.CONTRACT_RENEWAL || this.DocumentType == DOCUMENT_TYPE.CONTRACT_TEMPORARY || this.DocumentType == DOCUMENT_TYPE.CONTRACT_DRIVER)
                        {
                            if (facadeListContract.DisplayContract(this.DocumentType))
                            {
                                bindData();
                            }
                            else
                            {
                                selected = false;
                                clearForm();
                            }
                        }
                        else if (facadeListContract.DisplayContract())
                        {
                            bindData();
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
			{Message(sqlex);}
			catch(AppExceptionBase ex)
			{Message(ex);}
			catch(Exception ex)
			{Message(ex);}
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

		private void EditEvent()
		{
			selected = true;
			this.Hide();
		}
		
//		==============================Event ==============================
		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			selected = false;
			this.Hide();
		}

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			EditEvent();
		}

		private void frmContractVDOList_Load(object sender, System.EventArgs e)
		{
			InitForm();
		}

		private void fpsContractList_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
		{
			if(!e.ColumnHeader)
			{
				EditEvent();
			}
		}
	}
}
