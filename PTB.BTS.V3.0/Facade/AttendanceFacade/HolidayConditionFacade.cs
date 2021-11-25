using System;
using System.Collections;
using System.Data;
using SystemFramework.AppException;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;
using Entity.AttendanceEntities;
using Entity.ContractEntities;

using Flow.AttendanceFlow;
using PTB.BTS.PI.Flow;
using PTB.BTS.Contract.Flow;

using Facade.PiFacade;

namespace Facade.AttendanceFacade
{
	public class HolidayConditionFacade : CommonPIFacadeBase
	{		
		#region - Private -
		private HolidayConditionFlow flowHolidayCondition;
		private PositionTypeFlow flowPositionType;
		#endregion

		#region - DataSource -
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

		public ArrayList DataSourceCustomerDept(Customer value)
		{
			CustomerDepartmentFlow flowCustomerDept = new CustomerDepartmentFlow();
			CustomerDepartmentList customerDeptList = new CustomerDepartmentList(GetCompany());
			customerDeptList.ACustomer = value;
			flowCustomerDept.FillCustomerDepartmentList(ref customerDeptList);
			flowCustomerDept = null;
			return customerDeptList.GetArrayList();			
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

		public ArrayList DataSourceTraditionalHolidayPattern
		{
			get
			{
				TraditionalHolidayPatternFlow flowTraditionalHolidayPattern = new TraditionalHolidayPatternFlow();
				TraditionalHolidayPatternList traditionalHolidayPatternList = new TraditionalHolidayPatternList(GetCompany());
				flowTraditionalHolidayPattern.FillMTBData(traditionalHolidayPatternList);
				TraditionalHolidayPattern pattern = new TraditionalHolidayPattern();
				traditionalHolidayPatternList.Add(pattern);
				return traditionalHolidayPatternList.GetArrayList();		
			}
		}
		#endregion

//		============================== Property ==============================
		private HolidayConditionList objHolidayConditionList;
		public HolidayConditionList ObjHolidayConditionList
		{
			get{return objHolidayConditionList;}
		}

//		============================== Constructor ==============================
		public HolidayConditionFacade() : base()
		{
			flowHolidayCondition = new HolidayConditionFlow();
		}

//		============================== Public Method ==============================
		public bool DisplayHolidayCondition()
		{	
			objHolidayConditionList = new HolidayConditionList(GetCompany());
		    return flowHolidayCondition.FillHolidayConditionList(ref objHolidayConditionList);
		}

		public PositionType GetPositionType(string positionType)
		{
			flowPositionType = new PositionTypeFlow();
			return flowPositionType.GetPositionType(positionType, GetCompany());
		}

		public bool InsertHolidayCondition(HolidayCondition value)
		{
			if (objHolidayConditionList.Contain(value))
			{
				throw new DuplicateException("HolidayConditionFacade");
			}
			else
			{
				if(flowHolidayCondition.InsertHolidayCondition(value, objHolidayConditionList.Company))
				{
					objHolidayConditionList.Add(value);
					return true;
				}
				else
				{return false;}
			}
		}

		public bool UpdateHolidayCondition(HolidayCondition value)
		{
			if (flowHolidayCondition.UpdateHolidayCondition(value, objHolidayConditionList.Company))
			{
				objHolidayConditionList[value.EntityKey] = value;
				return true;
			}
			return false;
		}
		
		public bool DeleteHolidayCondition(HolidayCondition value)
		{
			if(flowHolidayCondition.DeleteHolidayCondition(value, objHolidayConditionList.Company))
			{
				objHolidayConditionList.Remove(value);
				return true;
			}
			return false;
		}		
	}
}
