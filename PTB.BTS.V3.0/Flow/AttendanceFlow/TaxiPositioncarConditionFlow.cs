using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Entity.AttendanceEntities;

using DataAccess.AttendanceDB;

using PTB.BTS.Common.Flow;

namespace Flow.AttendanceFlow
{
	public class TaxiPositionCarConditionFlow : FlowBase
	{
		#region - Private -
		private TaxiPositionCarConditionDB dbTaxiPositioncarCondition;
		#endregion
		
//		================================Constructor=====================£
		public TaxiPositionCarConditionFlow() : base()
		{
			dbTaxiPositioncarCondition = new TaxiPositionCarConditionDB();
		}

//		================================public Method=====================
		public bool FillTaxiPositionCarConditionList(ref TaxiPositionCarConditionList value)
		{
			return dbTaxiPositioncarCondition.FillTaxiPositionCarConditionList(ref value);
		}

		public bool InsertTaxiPositionCarCondition(TaxiPositionCarCondition value, Company aCompany)
		{
			return dbTaxiPositioncarCondition.InsertTaxiPositionCarCondition(value, aCompany);
		}

		public bool UpdateTaxiPositionCarCondition(TaxiPositionCarCondition value, Company aCompany)
		{
			return dbTaxiPositioncarCondition.UpdateTaxiPositionCarCondition(value, aCompany);
		}

		public bool DeleteTaxiPositionCarCondition(TaxiPositionCarCondition value, Company aCompany)
		{
			return dbTaxiPositioncarCondition.DeleteTaxiPositionCarCondition(value, aCompany);
		}
	}
}
