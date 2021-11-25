using System;
using System.Data;

using Entity.ContractEntities;
using ictus.PIS.PI.Entity;
using Entity.CommonEntity;
using Entity.AttendanceEntities;

using PTB.BTS.Contract.Flow;

using Facade.ContractFacade;
using Facade.PiFacade;
using Facade.CommonFacade;

using SystemFramework.AppException;

namespace Facade.ContractFacade
{
	public class ServiceStaffListFacade :  CommonPIFacadeBase
	{
		#region - Private -
		private ServiceStaffFlow flowServiceStaff;
		#endregion

//		============================== Property ==============================
		private EmployeeList objEmployeeList;
		public EmployeeList ObjEmployeeList
		{
			get{return objEmployeeList;}
		}

		private Employee conditionServiceStaff;
		public Employee ConditionServiceStaff
		{
			set{conditionServiceStaff= value;}
			get{return conditionServiceStaff;}
		}

		private TimePeriod conditionTimePeriod;
		public TimePeriod ConditionTimePeriod
		{
			set{conditionTimePeriod= value;}
			get{return conditionTimePeriod;}
		}
		
//		============================== Constructor ==============================
		public ServiceStaffListFacade()
		{
			flowServiceStaff = new ServiceStaffFlow();
			conditionServiceStaff = new Employee(GetCompany());
			conditionTimePeriod = new TimePeriod();
		}
		
//		============================== Public Method ==============================
		public bool DisplayServiceStaff()
		{
			objEmployeeList = new EmployeeList(GetCompany());
			if(flowServiceStaff.FillAvailableStaffList(ref objEmployeeList))
			{
				return flowServiceStaff.FillEmployeeServiceStaff(ref objEmployeeList);
			}
			return false;
		}

		public bool DisplayServiceStaffByRole()
		{
			objEmployeeList = new EmployeeList(GetCompany());
			if(flowServiceStaff.FillServiceStaffByRole(ref objEmployeeList, conditionServiceStaff, conditionTimePeriod))
			{
				return flowServiceStaff.FillEmployeeServiceStaff(ref objEmployeeList);
			}
			return false;
		}

		public bool DisplayServiceStaffNotDriver()
		{
			bool result;
			objEmployeeList = new EmployeeList(GetCompany());
			Position position = new Position();
			position.APositionRole = POSITION_ROLE_TYPE.MACHANIC;
			conditionServiceStaff.APosition = position;

			result = flowServiceStaff.FillServiceStaffByRole(ref objEmployeeList, conditionServiceStaff, conditionTimePeriod);

			position.APositionRole = POSITION_ROLE_TYPE.BLANK;
			conditionServiceStaff.APosition = position;

			result |= flowServiceStaff.FillServiceStaffByRole(ref objEmployeeList, conditionServiceStaff, conditionTimePeriod);
			position = null;

			if(result)
			{
				result = flowServiceStaff.FillEmployeeServiceStaff(ref objEmployeeList);
			}
			return result;
		}

		public bool DisplayServiceStaffMachanicDriver()
		{
			bool result;
			objEmployeeList = new EmployeeList(GetCompany());
			Position position = new Position();
			position.APositionRole = POSITION_ROLE_TYPE.DRIVER;
			conditionServiceStaff.APosition = position;

			result = flowServiceStaff.FillServiceStaffByRole(ref objEmployeeList, conditionServiceStaff, conditionTimePeriod);

			position.APositionRole = POSITION_ROLE_TYPE.MACHANIC;
			conditionServiceStaff.APosition = position;

			result |= flowServiceStaff.FillServiceStaffByRole(ref objEmployeeList, conditionServiceStaff, conditionTimePeriod);
			position = null;

			if(result)
			{
				result = flowServiceStaff.FillEmployeeServiceStaff(ref objEmployeeList);
			}
			return result;
		}
	}
}
