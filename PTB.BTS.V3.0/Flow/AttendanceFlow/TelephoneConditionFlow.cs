using System;

using Entity.AttendanceEntities;
using ictus.PIS.PI.Entity;

using DataAccess.AttendanceDB;
using DataAccess.CommonDB;

using PTB.BTS.Common.Flow;

namespace Flow.AttendanceFlow
{
	public class TelephoneConditionFlow : FlowBase
	{
		#region - Private -
		private TelephoneConditionDB dbTelephoneCondition;
		#endregion - Private -

//		============================== Constructor ==============================
		public TelephoneConditionFlow() : base()
		{
			dbTelephoneCondition = new TelephoneConditionDB();
		}

//		============================== Public Method ==============================
		public bool FillTelephoneConditionList(ref TelephoneConditionList value)
		{
			return dbTelephoneCondition.FillTelephoneConditionList(ref value);
		}

		public bool InsertTelephoneCondition(TelephoneCondition value)
		{
			return dbTelephoneCondition.InsertTelephoneCondition(value);
		}

		public bool UpdateTelephoneCondition(TelephoneCondition value)
		{
			return dbTelephoneCondition.UpdateTelephoneCondition(value);	
		}
		
		public bool DeleteTelephoneCondition(TelephoneCondition value)
		{
			return dbTelephoneCondition.DeleteTelephoneCondition(value);		
		}
	}
}
