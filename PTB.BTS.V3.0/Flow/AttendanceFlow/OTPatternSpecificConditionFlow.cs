using System;

using Entity.AttendanceEntities;
using ictus.PIS.PI.Entity;

using DataAccess.AttendanceDB;
using DataAccess.CommonDB;

using PTB.BTS.Common.Flow;

using ictus.Common.Entity;

namespace Flow.AttendanceFlow
{
	public class OTPatternSpecificConditionFlow : FlowBase
	{
		#region - Private -
		private OTPatternSpecificConditionDB dbOTPatternSpeciticCondition;
		#endregion - Private -

//		============================== Constructor ==============================
		public OTPatternSpecificConditionFlow()
		{
			dbOTPatternSpeciticCondition = new OTPatternSpecificConditionDB();
		}

//		============================== Public Method ==============================
		public bool FillOTPatternSpecificConditionList(ref OTPatternConditionList value)
		{
			return dbOTPatternSpeciticCondition.FillOTPatternSpecificConditionList(ref value);
		}

		public bool InsertOTPatternSpecificCondition(OTPatternSpecificCondition value, Company aCompany)
		{
			return dbOTPatternSpeciticCondition.InsertOTPatternSpecificCondition(value, aCompany);
		}

		public bool UpdateOTPatternSpecificCondition(OTPatternSpecificCondition value, Company aCompany)
		{
			return dbOTPatternSpeciticCondition.UpdateOTPatternSpecificCondition(value, aCompany);	
		}
		
		public bool DeleteOTPatternSpecificCondition(OTPatternSpecificCondition value, Company aCompany)
		{
			return dbOTPatternSpeciticCondition.DeleteOTPatternSpecificCondition(value, aCompany);		
		}
	}
}
