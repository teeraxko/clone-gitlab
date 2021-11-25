using System;
using System.Collections;
using System.Data;

using Entity.ContractEntities;
using Entity.AttendanceEntities;
using Entity.CommonEntity;
using Entity.VehicleEntities;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;

using PTB.BTS.Contract.Flow;
using Flow.AttendanceFlow;
using PTB.BTS.Vehicle.Flow;

using Facade.CommonFacade;
using Facade.PiFacade;

using SystemFramework.AppException;

using FarPoint.Win.Spread.CellType;

namespace Facade.ContractFacade
{
	public class VDContractMatchFacade : CommonPIFacadeBase
	{
		#region Private Variable
		private VDContractMatchFlow flowVDContractMatch;
		private ContractFlow flowContract;
		private ServiceStaffContractFlow flowServiceStaffContractFlow;
		private ServiceStaffFlow flowServiceStaff;
		#endregion

        #region Property
        private ContractList objContractList;
		public ContractList ObjContractList
		{
			get{return objContractList;}
		}

		private EmployeeList objEmployeeList;
		public EmployeeList ObjEmployeeList
		{
			get{return objEmployeeList;}
		}

		private ServiceStaffContract objServiceStaffContract;
		public ServiceStaffContract ObjServiceStaffContract
		{
			get{return objServiceStaffContract;}
			set{objServiceStaffContract = value;}
		}

		public VehicleContract condition;
		public Customer ConditionCustomer
		{
			set{condition.ACustomerDepartment.ACustomer = value;}
		}
		public ContractType ConditionCONTRACT_TYPE
		{
			set{condition.AContractType = value;}
		}
		public ContractStatus ConditionContractStatus
		{
			set{condition.AContractStatus = value;}
			get{return condition.AContractStatus;}
		}

		private DocumentNo contractNo;
		public string ConditionYY
		{
			set{contractNo.Year = value;}
		}
		public string ConditionMM
		{
			set{contractNo.Month = value;}
		}
		public string ConditionXXX
		{
			set{contractNo.No = value;}
        }
        #endregion

		#region DataSource
		public ArrayList DataSourceCustomer
		{
			get
			{
				CustomerFlow flowCustomer = new CustomerFlow();
				CustomerList customerList = new CustomerList(GetCompany());
				flowCustomer.FillCustomer(ref customerList);
				flowCustomer = null;
				return customerList.GetArrayList();
			}
		}
		public string[] DataSourceContractTypeAvailable
		{
			get
			{
				ContractTypeFlow flowContractType = new ContractTypeFlow();
				ContractTypeList contractTypeList = new ContractTypeList(GetCompany());
				flowContractType.FillMTBList(contractTypeList);
				flowContractType = null;

				string [] aArray = new string[1];
				aArray[0] = contractTypeList["V"].AName.Thai;
				return aArray;	
			}
		}

		public ArrayList DataSourceContractAvailableStatus
		{
			get
			{
				ContractStatusFlow flowContractStatus = new ContractStatusFlow();
				ContractStatusList contractStatusList = new ContractStatusList(GetCompany());
				flowContractStatus.FillMTBList(contractStatusList);
				flowContractStatus = null;
				contractStatusList.Remove(0);
				return contractStatusList.GetArrayList();
			}
		}

		public ComboBoxCellType DataSourceEmployeeList(VehicleContract value)
		{
			EmployeeList listEmployee = new EmployeeList(GetCompany());

            //TODO : P'Ya
            listEmployee = flowVDContractMatch.GetAvailableDriverByPeriod(value);

			string[] items;
			string[] itemData;
			int iRow = listEmployee.Count + 1;

			items = new string[iRow];
			itemData = new string[iRow];

			for(int i=0; i<iRow; i++)
			{		
				if(i == 0)
				{
					items[i] = NullConstant.STRING;
				}
				else
				{
					items[i] = listEmployee[i-1].EmployeeNonePrefixName;
					objEmployeeList.Add(listEmployee[i-1].EmployeeNonePrefixName, listEmployee[i-1]);
				}				
			}

			ComboBoxCellType comboBox = new ComboBoxCellType();
			comboBox.Items = items;
			comboBox.ItemData = itemData;

			items = null;
			itemData = null;

			return comboBox;			
		}

		#endregion

        #region Constructor
        public VDContractMatchFacade()
            : base()
        {
            flowContract = new ContractFlow();
            flowServiceStaff = new ServiceStaffFlow();
            flowVDContractMatch = new VDContractMatchFlow();
            flowServiceStaffContractFlow = new ServiceStaffContractFlow();

            objEmployeeList = new EmployeeList(GetCompany());
            objServiceStaffContract = new ServiceStaffContract(GetCompany());

            condition = new VehicleContract(GetCompany());
            contractNo = new DocumentNo(DOCUMENT_TYPE.CONTRACT, NullConstant.STRING, NullConstant.STRING, NullConstant.STRING);

            objContractList = new ContractList(GetCompany());
            condition.ContractNo = contractNo;
        } 
        #endregion

        #region Public Method
        public bool DisplayVDContractMatch()
        {
            return flowVDContractMatch.FillVDContractMatch(ref objContractList, condition);
        }

        public bool DisplayServiceStaffContract()
        {
            return flowServiceStaffContractFlow.FillServiceStaffContract(ref objServiceStaffContract);
        }

        public bool FillVehicleAssignmentList(ref VehicleContract value)
        {
            return flowVDContractMatch.FillVehicleAssignmentList(ref value);
        }

        public bool FillVDContractMatch(ref VehicleContract value)
        {
            return flowVDContractMatch.FillVDContractMatch(ref value);
        }

        public ContractBase RetriveContract(DocumentNo value)
        {
            return flowContract.RetriveContract(value, GetCompany());
        }

        public bool ValidateDeleteVDContractMatch(VehicleContract value)
        {
            return flowVDContractMatch.ValidateDeleteVDContractMatch(value);
        }

        public bool ValidateVDContractMatch(ContractBase aContractBase, ServiceStaff aServiceStaff)
        {
            return flowVDContractMatch.ValidateVDContractMatch(aContractBase, aServiceStaff);
        }

        public ServiceStaff GetServiceStaff(string employeeNo)
        {
            return flowServiceStaff.GetServiceStaff(employeeNo, GetCompany());
        }

        public bool InsertVDContractMatch(VehicleContract value)
        {
            return flowVDContractMatch.InsertVDContractMatch(value);
        }

        public bool UpdateVDContractMatch(VehicleContract value)
        {
            return flowVDContractMatch.UpdateVDContractMatch(value);
        }

        public bool DeleteVDContractMatch(VehicleContract value)
        {
            return flowVDContractMatch.DeleteVDContractMatch(value);
        } 
        #endregion
	}
}
