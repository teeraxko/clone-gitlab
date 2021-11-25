using System;
using System.Data;
using System.Collections;

using SystemFramework.AppException;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;

using Entity.CommonEntity;
using Entity.VehicleEntities;
using Entity.ContractEntities;
using Entity.AttendanceEntities;

using PTB.BTS.PI.Flow;
using PTB.BTS.Common.Flow;
using PTB.BTS.Vehicle.Flow;
using PTB.BTS.Contract.Flow;

using Facade.PiFacade;
using Facade.CommonFacade;

namespace Facade.ContractFacade
{
	public class ContractCancelFacade : CommonPIFacadeBase
	{
		#region - Private -
		private ContractFlow flowContract;
		private VehicleFlow flowVehicle;
		private VehicleAssignmentFlow flowVehicleAssignment;
		private AgeFlow flowAge;
		private bool disposed = false;
		#endregion

//		============================== Property ==============================


//		============================== Constructor ==============================
		public ContractCancelFacade() : base()
		{
			flowContract = new ContractFlow();
			flowVehicle = new VehicleFlow();
			flowVehicleAssignment = new VehicleAssignmentFlow();
			flowAge = new AgeFlow();
		}

//		============================ Public Method ============================
		#region - DataSource for ComboBox -
		public ArrayList DataSourceCustomerName
		{
			get
			{
				CustomerFlow flowCustomer = new CustomerFlow();
				CustomerList CustomerList = new CustomerList(GetCompany());
				flowCustomer.FillCustomer(ref CustomerList);
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
				flowKindOfContract.FillMTBList(kindOfContractList);
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

		public ArrayList DataSourceContractCancelReason
		{
			get
			{
				ContractCancelReasonFlow flowContractCancelReason = new ContractCancelReasonFlow();
				ContractCancelReasonList contractCancelReasonList = new ContractCancelReasonList();
				flowContractCancelReason.FillMTBList(contractCancelReasonList);
				return contractCancelReasonList.GetArrayList();			
			}
		}
		#endregion - DataSource for ComboBox -

		public DayMonthYearStructure CalAge(DateTime start, DateTime end)
		{
			return flowAge.DaysDiff(start, end.AddDays(1));
		}

		public ContractBase RetriveContract(DocumentNo value)
		{
			return flowContract.RetriveContract(value, GetCompany());
		}

		public bool UpdateContractCancel(ContractBase value)
		{  
			CommonFlow flowCommon = new CommonFlow();
			ContractStatus contractStatus = new ContractStatus();
			contractStatus.Code = "3";

			value.AContractStatus = contractStatus;
			if(flowContract.UpdateContractCancel(value, GetCompany()))
			{
				ContractCancelReasonFlow flowContractCancelReason = new ContractCancelReasonFlow();
				flowContractCancelReason.UpdateMTB(value.ACancelReason);
				return true;
			}
			return false;
		}

		public bool UpdateContractCancel(VehicleContract value)
		{
			CommonFlow flowCommon = new CommonFlow();
			ContractStatus contractStatus = new ContractStatus();
			contractStatus.Code = "3";

			value.AContractStatus = contractStatus;
			if(flowContract.UpdateContractCancel(value))
			{
				ContractCancelReasonFlow flowContractCancelReason = new ContractCancelReasonFlow();
				flowContractCancelReason.UpdateMTB(value.ACancelReason);
				return true;
			}
			return false;
		}
	
		public bool DeleteVehicleAssignment(VehicleAssignment value)
		{			
			return flowVehicleAssignment.DeleteVehicleAssignment(value,GetCompany());
		}

		#region IDisposable Members
		protected override void Dispose(bool disposing)
		{
			if(!this.disposed)
			{
				try
				{
					if(disposing)
					{
					}
					this.disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}
		#endregion

        public System.Collections.Generic.List<Entity.VehicleEntities.VehicleLeasing.VehiclePurchasingContract> GetPurchasingContractListByContract(DocumentNo contractNo)
        {
            using (Flow.VehicleFlow.VehicleLeasingFlow.VehiclePurchasingContractFlow flow = new Flow.VehicleFlow.VehicleLeasingFlow.VehiclePurchasingContractFlow())
            {
                return flow.GetPurchasingContractListByContract(contractNo);
            }
        }
    }
}
