using System;
using System.Data;

using ictus.PIS.PI.Entity;

using PTB.BTS.PI.Flow;
using PTB.BTS.Contract.Flow;

using Facade.PiFacade;
using Facade.CommonFacade;

using SystemFramework.AppException;

namespace Facade.PiFacade
{
	public class EmpListPIFacadecs : CommonPIFacadeBase
	{

		#region - Private -
		private EmployeeFlow flowEmployee;
		private ServiceStaffFlow flowServiceStaff;

		#endregion

		//		============================== Property ==============================
		private EmployeeList objEmployeeList;
		public EmployeeList ObjEmployeeList
		{
			get
			{
				return objEmployeeList;
			}
		}

		private Employee conditionEmployee;
		public Employee ConditionEmployee
		{
			set
			{
				conditionEmployee = value;
			}
			get
			{
				return conditionEmployee;
			}
		}

		
		//		============================== Constructor ==============================
		public EmpListPIFacadecs()
		{
			flowEmployee = new EmployeeFlow();
			flowServiceStaff = new ServiceStaffFlow();
			conditionEmployee = new Employee(GetCompany());
			conditionEmployee.APosition = new Position();
		}

//		============================== Public Method ==============================
		public bool DisplayEmployee()
		{
			objEmployeeList = new EmployeeList(GetCompany());
			return flowEmployee.FillAllEmployeeList(ref objEmployeeList, conditionEmployee);
		}

		public bool DisplayServiceStaff()
		{
			objEmployeeList = new EmployeeList(GetCompany());
			return flowServiceStaff.FillAvailableStaffList(ref objEmployeeList);
		}
	}
}
