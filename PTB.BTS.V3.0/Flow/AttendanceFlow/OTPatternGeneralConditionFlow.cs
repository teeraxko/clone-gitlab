using System;

using Entity.AttendanceEntities;
using ictus.PIS.PI.Entity;

using DataAccess.AttendanceDB;
using DataAccess.CommonDB;

using PTB.BTS.Common.Flow;

using ictus.Common.Entity;

namespace Flow.AttendanceFlow
{
	public class OTPatternGeneralConditionFlow : FlowBase
	{
		#region - Private -
		private OTPatternGeneralConditionDB dbOTPatternGeneralCondition;
		#endregion - Private -

//		============================== Constructor ==============================
		public OTPatternGeneralConditionFlow()
		{
			dbOTPatternGeneralCondition = new OTPatternGeneralConditionDB();
		}

//		============================== Public Method ==============================
		public bool FillOTPatternGeneralConditionList(ref OTPatternConditionList value)
		{
			return dbOTPatternGeneralCondition.FillOTPatternGeneralConditionList(ref value);
		}

		public bool InsertOTPatternGeneralCondition(OTPatternGeneralCondition value, Company aCompany)
		{
			return dbOTPatternGeneralCondition.InsertOTPatternGeneralCondition(value, aCompany);
		}

		public bool UpdateOTPatternGeneralCondition(OTPatternGeneralCondition value, Company aCompany)
		{
			return dbOTPatternGeneralCondition.UpdateOTPatternGeneralCondition(value, aCompany);	
		}
		
		public bool DeleteOTPatternGeneralCondition(OTPatternGeneralCondition value, Company aCompany)
		{
			return dbOTPatternGeneralCondition.DeleteOTPatternGeneralCondition(value, aCompany);		
		}
	}
}
