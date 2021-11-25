using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Entity.AttendanceEntities;

using DataAccess.AttendanceDB;

using PTB.BTS.Common.Flow;

namespace Flow.AttendanceFlow
{
	public class TaxiFamilyCarConditionFlow : FlowBase
	{
		#region - Private -
		private TaxiFamilyCarConditionDB dbTaxiFamilyCarCondition;
		#endregion
		
//		================================Constructor=====================
		public TaxiFamilyCarConditionFlow() : base()
		{
			dbTaxiFamilyCarCondition = new TaxiFamilyCarConditionDB();
		}

//		================================public Method=====================
		public bool FillTaxiFamilyCarConditionList(ref TaxiFamilyCarConditionList value)
		{
			return dbTaxiFamilyCarCondition.FillTaxiFamilyCarConditionList(ref value);
		}

		public bool InsertTaxiFamilyCarCondition(TaxiFamilyCarCondition value, Company aCompany)
		{
			return dbTaxiFamilyCarCondition.InsertTaxiFamilyCarCondition(value, aCompany);
		}

		public bool UpdateTaxiFamilyCarCondition(TaxiFamilyCarCondition value, Company aCompany)
		{
			return dbTaxiFamilyCarCondition.UpdateTaxiFamilyCarCondition(value, aCompany);
		}

		public bool DeleteTaxiFamilyCarCondition(TaxiFamilyCarCondition value, Company aCompany)
		{
			return dbTaxiFamilyCarCondition.DeleteTaxiFamilyCarCondition(value, aCompany);
		}
	}
}
