using System;

using Entity.AttendanceEntities;

using ictus.Common.Entity;
using ictus.PIS.PI.Entity;

using DataAccess.AttendanceDB;

using PTB.BTS.Common.Flow;

namespace Flow.AttendanceFlow
{
	public class OtherBenefitRateFlow : FlowBase
	{
		private OtherBenefitRateDB dbOtherBenefitRate;

//		================================Constructor=====================
		public OtherBenefitRateFlow() : base()
		{
			dbOtherBenefitRate = new OtherBenefitRateDB();
		}

//		================================public Method=====================
		public OtherBenefitRate GetOtherBenefitRate(Company value)
		{
			return dbOtherBenefitRate.GetOtherBenefitRate(value);
		}

		public bool FillOtherBenefitRate(ref OtherBenefitRate value, Company aCompany)
		{
			return dbOtherBenefitRate.FillOtherBenefitRate(ref value, aCompany);
		}

		public bool InsertOtherBenefitRate(OtherBenefitRate value, Company aCompany)
		{
			return dbOtherBenefitRate.InsertOtherBenefitRate(value, aCompany);
		}

		public bool UpdateOtherBenefitRate(OtherBenefitRate value, Company aCompany)
		{
			return dbOtherBenefitRate.UpdateOtherBenefitRate(value, aCompany);
		}
	}
}
