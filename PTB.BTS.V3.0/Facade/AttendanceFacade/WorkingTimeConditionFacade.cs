using System;
using System.Collections;
using SystemFramework.AppException;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;
using Entity.ContractEntities;
using Entity.AttendanceEntities;

using PTB.BTS.PI.Flow;
using Flow.AttendanceFlow;
using PTB.BTS.Contract.Flow;

using Facade.PiFacade;
using Facade.CommonFacade;

namespace Facade.AttendanceFacade
{
	public class WorkingTimeConditionFacade : CommonPIFacadeBase
	{
		#region - Private -
		private WorkingTimeConditionFlow flowWorkingTimeCondition;
		private PositionTypeFlow flowPositionType;
		private bool disposed = false;
		#endregion

//		============================== Property ==============================
		private WorkingTimeConditionList objWorkingTimeConditionList;
		public WorkingTimeConditionList ObjWorkingTimeConditionList
		{
			get{return objWorkingTimeConditionList;}
			set{objWorkingTimeConditionList = value;}
		}

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

		public ArrayList DataSourceCustomerDept(Customer value)
		{
			CustomerDepartmentFlow flowCustomerDept = new CustomerDepartmentFlow();
			CustomerDepartmentList CustomerDeptList = new CustomerDepartmentList(GetCompany());
			CustomerDeptList.ACustomer = value;
			flowCustomerDept.FillCustomerDepartmentList(ref CustomerDeptList);
			flowCustomerDept = null;
			return CustomerDeptList.GetArrayList();			
		}

		public ArrayList DataSourceServiceStaffType
		{
			get
			{
				ServiceStaffTypeFlow flowServiceStaffType = new ServiceStaffTypeFlow();
				ServiceStaffTypeList serviceStaffTypeList = new ServiceStaffTypeList(GetCompany());
				flowServiceStaffType.FillServiceStaffTypeList(ref serviceStaffTypeList);
				flowServiceStaffType = null;
				return serviceStaffTypeList.GetArrayList();
			}		
		}

		public ArrayList DataSourceWorkingTimeCondition
		{
			get
			{
				WorkingTimeTableFlow flowWorkingTimeTable = new WorkingTimeTableFlow();
				WorkingTimeTableList workingTimeTableList = new WorkingTimeTableList(GetCompany());
				flowWorkingTimeTable.FillWorkingTimeTableList(ref workingTimeTableList);
				flowWorkingTimeTable = null;
				return workingTimeTableList.GetArrayList();			
			}
		}
		
//		============================== Constructor ==============================
		public WorkingTimeConditionFacade()
		{
			flowWorkingTimeCondition = new WorkingTimeConditionFlow();
			flowPositionType = new PositionTypeFlow();
		}

//		============================== Public Method ==============================
		public bool DisplayWorkingTimeCondition()
		{
			objWorkingTimeConditionList = new WorkingTimeConditionList(GetCompany());
			return flowWorkingTimeCondition.FillWorkingTimeConditionList(ref objWorkingTimeConditionList);		
		}

		public PositionType GetPositionType(string positionType)
		{
			flowPositionType = new PositionTypeFlow();
			return flowPositionType.GetPositionType(positionType, GetCompany());
		}

		public bool InsertWorkingTimeCondition(WorkingTimeCondition value)
		{	
			if (objWorkingTimeConditionList.Contain(value))
			{
				throw new DuplicateException("WorkingTimeConditionFacade");
			}
			else
			{
				if(flowWorkingTimeCondition.InsertWorkingTimeCondition(value, objWorkingTimeConditionList.Company))
				{
					objWorkingTimeConditionList.Add(value);
					return true;
				}
				else
				{return false;}
			}		
		}

		public bool UpdateWorkingTimeCondition(WorkingTimeCondition value)
		{
			if(flowWorkingTimeCondition.UpdateWorkingTimeCondition(value, objWorkingTimeConditionList.Company))
			{
				objWorkingTimeConditionList[value.EntityKey] = value;
				return true;
			}
			return false;
		}

		public bool DeleteWorkingTimeCondition(WorkingTimeCondition value)
		{
			if(flowWorkingTimeCondition.DeleteWorkingTimeCondition(value, objWorkingTimeConditionList.Company))
			{
				objWorkingTimeConditionList.Remove(value);
				return true;
			}
			return false;
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
						flowWorkingTimeCondition.Dispose();
						objWorkingTimeConditionList.Dispose();

						flowWorkingTimeCondition = null;
						objWorkingTimeConditionList = null;
						
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
