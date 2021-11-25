using System;
using System.Collections;
using System.Data;
using SystemFramework.AppException;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;
using Entity.AttendanceEntities;

using Flow.AttendanceFlow;
using PTB.BTS.PI.Flow;

using Facade.PiFacade;

namespace Facade.AttendanceFacade
{
	public class HolidayConditionSpecificFacade : CommonPIFacadeBase
	{
		#region - Private -
		private HolidayConditionSpecificFlow flowHolidayConditionSpecific;
		#endregion

		#region - DataSource -
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
		private HolidayConditionSpecificList objHolidayConditionSpecificList;
		public HolidayConditionSpecificList ObjHolidayConditionSpecificList
		{
			get{return objHolidayConditionSpecificList;}
		}

//		============================== Constructor ==============================
		public HolidayConditionSpecificFacade()
		{
			flowHolidayConditionSpecific = new HolidayConditionSpecificFlow();
		}

//		============================== Public Method ==============================
		public bool DisplayHolidayConditionSpecific()
		{	
			objHolidayConditionSpecificList = new HolidayConditionSpecificList(GetCompany());
			return flowHolidayConditionSpecific.FillHolidayConditionSpecificList(ref objHolidayConditionSpecificList);
		}

		public bool InsertHolidayConditionSpecific(HolidayConditionSpecific value)
		{
			if (objHolidayConditionSpecificList.Contain(value))
			{
				throw new DuplicateException("HolidayConditionSpecificFacade");
			}
			else
			{
				if(flowHolidayConditionSpecific.InsertHolidayConditionSpecific(value, objHolidayConditionSpecificList.Company))
				{
					objHolidayConditionSpecificList.Add(value);
					return true;
				}
				else
				{return false;}
			}
		}

		public bool UpdateHolidayConditionSpecific(HolidayConditionSpecific value)
		{
			if (flowHolidayConditionSpecific.UpdateHolidayConditionSpecific(value, objHolidayConditionSpecificList.Company))
			{
				objHolidayConditionSpecificList[value.EntityKey] = value;
				return true;
			}
			return false;
		}
		
		public bool DeleteHolidayConditionSpecific(HolidayConditionSpecific value)
		{
			if(flowHolidayConditionSpecific.DeleteHolidayConditionSpecific(value, objHolidayConditionSpecificList.Company))
			{
				objHolidayConditionSpecificList.Remove(value);
				return true;
			}
			return false;
		}		
	}
}
