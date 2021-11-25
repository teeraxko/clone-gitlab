using System;
using System.Data;
using System.Collections;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;

using Entity.CommonEntity;
using Entity.ContractEntities;
using Entity.VehicleEntities;

using PTB.BTS.Contract.Flow;
using PTB.BTS.Vehicle.Flow;

using Facade.CommonFacade;
using Facade.PiFacade;

using SystemFramework.AppException;

using FarPoint.Win.Spread.CellType;

namespace Facade.ContractFacade
{
	public class ServiceStaffMatchToContractFacade : CommonPIFacadeBase
	{
		#region - Private -
		private ContractFlow flowContract;
		private ServiceStaffFlow flowServiceStaff;
		private ServiceStaffContractFlow flowServiceStaffContract;
		private ServiceStaffAssignmentFlow flowServiceStaffAssignment;
		#endregion - Private -

		#region - DataSource -
		public ArrayList DataSourceCustomerName
		{
			get
			{
				CustomerFlow flowCustomer = new CustomerFlow();
				CustomerList CustomerList = new CustomerList(GetCompany());
				flowCustomer.FillCustomer(ref CustomerList);
				flowCustomer = null;
				return CustomerList.GetArrayList();	
			}
		}
		
		public ArrayList DataSourceContractType
		{
			get
			{
				ContractTypeFlow flowContractType = new ContractTypeFlow();
				ContractTypeList contractTypeList = new ContractTypeList(GetCompany());
				flowContractType.FillMTBList(contractTypeList);
				flowContractType = null;
				ContractType contractType = new ContractType();
				contractType.Code = "V";
				contractTypeList.Remove(contractType);
				return contractTypeList.GetArrayList();
			}
		}

		public ArrayList DataSourceContractStatus
		{
			get
			{
				ContractStatusFlow flowContractStatus = new ContractStatusFlow();
				ContractStatusList contractStatusList = new ContractStatusList(GetCompany());
				flowContractStatus.FillMTBList(contractStatusList);
				flowContractStatus = null;
				return contractStatusList.GetArrayList();	
			}
		}

		public ArrayList DataSourceKindOfContract
		{
			get
			{
				KindOfContractFlow flowKindOfContract = new KindOfContractFlow();
				KindOfContractList kindOfContractList = new KindOfContractList(GetCompany());
				flowKindOfContract.FillMTBData(kindOfContractList);
				flowKindOfContract = null;
				return kindOfContractList.GetArrayList();			
			}
		}

		public ArrayList DataSourceCustomerDept(Customer value)
		{
			CustomerDepartmentFlow flowCustomerDept = new CustomerDepartmentFlow();
			CustomerDepartmentList CustomerDeptList = new CustomerDepartmentList(GetCompany());
			CustomerDeptList.ACustomer = value;
			flowCustomerDept.FillCustomerDepartmentList(ref CustomerDeptList);
			flowCustomerDept = null;
			return CustomerDeptList.GetArrayList();			
		}

		public ArrayList DataSourceServiceStaffType(Position value)
		{
			ServiceStaffTypeFlow flowServiceStaffType = new ServiceStaffTypeFlow();
			ServiceStaffType serviceStaffType = new ServiceStaffType();
			ServiceStaffTypeList serviceStaffTypeList = new ServiceStaffTypeList(GetCompany());

			serviceStaffType.APosition = value;
			flowServiceStaffType.FillServiceStaffTypeList(ref serviceStaffTypeList, serviceStaffType);
			serviceStaffType = null;
			flowServiceStaffType = null;
			return serviceStaffTypeList.GetArrayList();
		}
		#endregion

//		============================== Property ==============================
		private ContractBase conditionContract;
		public ContractBase ConditionContract
		{
			get{return conditionContract;}
			set{conditionContract = value;}
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

		private ContractList objContractList;
		public ContractList ObjContractList
		{
			get{return objContractList;}
		}

//		============================== Constructor ==============================
		public ServiceStaffMatchToContractFacade()
		{	
			conditionContract = new ContractBase();
			objContractList = new ContractList(GetCompany());

			flowContract = new ContractFlow();
			flowServiceStaff = new ServiceStaffFlow();
			flowServiceStaffContract = new ServiceStaffContractFlow();
			flowServiceStaffAssignment = new ServiceStaffAssignmentFlow();
			
			contractNo = new DocumentNo(DOCUMENT_TYPE.CONTRACT, NullConstant.STRING, NullConstant.STRING, NullConstant.STRING);
			conditionContract.ContractNo = contractNo;
		}

//		============================== Public Method ==============================
		public bool DisplayDriverOtherContract()
		{
			bool result;

			objContractList = new ContractList(GetCompany());

			if(conditionContract.AContractType == null)
			{
				ContractType contractType = new ContractType();
				contractType.Code = "D";
				conditionContract.AContractType = contractType;
				result = flowContract.FillContractList(ref objContractList, conditionContract);

				contractType.Code = "O";
				conditionContract.AContractType = contractType;
				result |= flowContract.FillContractList(ref objContractList, conditionContract);
				contractType = null;

				return result;
			}
			else
			{
				result = flowContract.FillContractList(ref objContractList, conditionContract);
				return result;
			}
		}

		public ContractBase RetriveContract(DocumentNo value)
		{
			ContractBase contractBase = new ContractBase();
			contractBase = flowContract.RetriveContract(value, GetCompany());	
			if(contractBase != null)
			{				
				objContractList = new ContractList(GetCompany());
				objContractList.Add(contractBase);
				return  contractBase;
			}
			else
			{
				contractBase = null;
				return null;
			}
		}
		
		public bool FillServiceStaffAssignment(ref ServiceStaffAssignment value)
		{
			return flowServiceStaffAssignment.FillServiceStaffAssignment(ref value, GetCompany());
		}

		public ServiceStaff GetAllServiceStaff(string employeeNo)
		{
			return flowServiceStaff.GetCompleteServiceStaff(employeeNo, GetCompany()); 	 		
		}

		public bool FillNotAvailableServiceStaffAssignment(ServiceStaffAssignment value)
		{
			return flowServiceStaffAssignment.FillNotAvailableServiceStaffAssignment(ref value, GetCompany());
		}

		public bool FillVDcontract(ServiceStaffContract value)
		{
			bool result = false;
			VDContractMatchFlow flowVDContractMatchFlow = new VDContractMatchFlow();
			VehicleContract vehicleContract = new VehicleContract(GetCompany());
			vehicleContract.ADriverContract = (DriverContract)value;
			result = flowVDContractMatchFlow.FillVDContractMatch(ref vehicleContract);

			flowVDContractMatchFlow = null;
			vehicleContract = null;
			return result;
		}

		public bool InsertServiceStaffMatchToContract(ServiceStaffContract aServiceStaffContract, ServiceStaffAssignment aServiceStaffAssignment, ServiceStaff aServiceStaff)
		{
			return flowServiceStaffContract.InsertServiceStaffContract(aServiceStaffContract, aServiceStaffAssignment, aServiceStaff);
		}

		public bool UpdateServiceStaffMatchToContract(ServiceStaffContract aServiceStaffContract, ServiceStaffAssignment aServiceStaffAssignment, ServiceStaff aServiceStaff)
		{
			return flowServiceStaffContract.UpdateServiceStaffContract(aServiceStaffContract, aServiceStaffAssignment, aServiceStaff);
		} 

		public bool DeleteServiceStaffMatchToContract(ServiceStaffContract aServiceStaffContract, ServiceStaffRole aServiceStaffRole, ServiceStaffAssignment aServiceStaffAssignment)
		{
			return flowServiceStaffContract.DeleteServiceStaffContract(aServiceStaffContract, aServiceStaffAssignment, aServiceStaffRole.AServiceStaff);
		} 
	}
}
