using System;

using Entity.AttendanceEntities;

using ictus.Common.Entity;
using ictus.PIS.PI.Entity;

using DataAccess.AttendanceDB;
using DataAccess.CommonDB;

using PTB.BTS.Common.Flow;

namespace Flow.AttendanceFlow
{
	public class HolidayConditionSpecificFlow : FlowBase
	{
		#region - Private -
		private HolidayConditionSpecificDB dbHolidayConditionSpecific;
		#endregion - Private -

//		============================== Constructor ==============================
		public HolidayConditionSpecificFlow() : base()
		{
			dbHolidayConditionSpecific = new HolidayConditionSpecificDB();
		}

//		============================== Public Method ==============================
		public bool FillHolidayConditionSpecificList(ref HolidayConditionSpecificList value)
		{
			return dbHolidayConditionSpecific.FillHolidayConditionSpecificList(ref value);
		}

		public bool InsertHolidayConditionSpecific(HolidayConditionSpecific value, Company aCompany)
		{
			return dbHolidayConditionSpecific.InsertHolidayConditionSpecific(value, aCompany);
		}

		public bool UpdateHolidayConditionSpecific(HolidayConditionSpecific value, Company aCompany)
		{
			return dbHolidayConditionSpecific.UpdateHolidayConditionSpecific(value, aCompany);	
		}
		
		public bool DeleteHolidayConditionSpecific(HolidayConditionSpecific value, Company aCompany)
		{
			return dbHolidayConditionSpecific.DeleteHolidayConditionSpecific(value, aCompany);		
		}
	}
}
