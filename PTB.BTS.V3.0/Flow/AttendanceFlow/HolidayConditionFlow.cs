using System;

using Entity.AttendanceEntities;
using ictus.PIS.PI.Entity;

using DataAccess.AttendanceDB;
using DataAccess.CommonDB;

using PTB.BTS.Common.Flow;

using ictus.Common.Entity;

namespace Flow.AttendanceFlow
{
	public class HolidayConditionFlow : FlowBase
	{
		#region - Private -
		private HolidayConditionDB dbHolidayCondition;
		#endregion - Private -

//		============================== Constructor ==============================
		public HolidayConditionFlow() : base()
		{
			dbHolidayCondition = new HolidayConditionDB();
		}

//		============================== Public Method ==============================
		public bool FillHolidayConditionList(ref HolidayConditionList value)
		{
			return dbHolidayCondition.FillHolidayConditionList(ref value);
		}

		public bool InsertHolidayCondition(HolidayCondition value, Company aCompany)
		{
			return dbHolidayCondition.InsertHolidayCondition(value, aCompany);
		}

		public bool UpdateHolidayCondition(HolidayCondition value, Company aCompany)
		{
			return dbHolidayCondition.UpdateHolidayCondition(value, aCompany);	
		}
		
		public bool DeleteHolidayCondition(HolidayCondition value, Company aCompany)
		{
			return dbHolidayCondition.DeleteHolidayCondition(value, aCompany);		
		}
	}
}
