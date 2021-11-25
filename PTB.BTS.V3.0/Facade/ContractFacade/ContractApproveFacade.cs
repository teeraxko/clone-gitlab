using System;
using System.Data;
using System.Collections;

using SystemFramework.AppException;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;
using Entity.VehicleEntities;
using Entity.ContractEntities;
using Entity.AttendanceEntities;

using PTB.BTS.PI.Flow;
using PTB.BTS.Common.Flow;
using PTB.BTS.Contract.Flow;
using PTB.BTS.Vehicle.Flow;

using Facade.PiFacade;
using Facade.CommonFacade;

using ictus.Common.Entity.Time;

namespace Facade.ContractFacade
{
	public class ContractApproveFacade : CommonPIFacadeBase
	{
		#region - Private -
		private ContractFlow flowContract;
		private VehicleFlow flowVehicle;
		private VehicleAssignmentFlow flowVehicleAssignment;
		private AgeFlow flowAge;
		private bool disposed = false;
		#endregion

//		============================== Constructor ==============================
		public ContractApproveFacade() : base()
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
	    #endregion - DataSource for ComboBox -
		public DayMonthYearStructure CalAge(DateTime start, DateTime end)
		{
			return flowAge.DaysDiff(start, end.AddDays(1));
		}

		public ContractBase RetriveContract(DocumentNo value)
		{
			return flowContract.RetriveContract(value, GetCompany());
		}

        public bool FillExcludeAvailableVehicleSpareAssignment(ref VehicleAssignment value)
		{
			return flowVehicleAssignment.FillExcludeAvailableVehicleSpareAssignment(ref value, GetCompany());
		}

		public Vehicle GetVehicleGeneral(int vehicleNo)
		{
			return flowVehicle.GetVehicleGeneral(vehicleNo, GetCompany());		
		}

		public bool UpdateContract(ContractBase value)
		{  
			CommonFlow flowCommon = new CommonFlow();
			value.CancelDate = flowCommon.GetNullDate();	

			return flowContract.UpdateContractApproveCancel(value, GetCompany());
		}

		public bool UpdateContractApprove(VehicleContract value)
		{	
			CommonFlow flowCommon = new CommonFlow();
			value.CancelDate = flowCommon.GetNullDate();

			return flowContract.UpdateContractApprove(value);
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
	}
}

