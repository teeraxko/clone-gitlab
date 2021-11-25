using System;
using System.Data;

using ictus.PIS.PI.Entity;
using Entity.AttendanceEntities;

using PTB.BTS.PI.Flow;
using Flow.AttendanceFlow;

using Facade.PiFacade;
using Facade.CommonFacade;

using SystemFramework.AppException;

namespace Facade.AttendanceFacade
{
	public class OtherBenefitRateFacade : CommonPIFacadeBase
	{
		#region - Private -
		private OtherBenefitRateFlow flowOtherBenefitRate;
		#endregion

//		============================== Constructor ==============================
		public OtherBenefitRateFacade() : base()
		{
			flowOtherBenefitRate = new OtherBenefitRateFlow();
		}

//		============================== Public Method ==============================
		public OtherBenefitRate GetOtherBenefitRate()
		{
			return flowOtherBenefitRate.GetOtherBenefitRate(GetCompany());
		}

		public bool InsertOtherBenefitRate(OtherBenefitRate value)
		{
			return flowOtherBenefitRate.InsertOtherBenefitRate(value, GetCompany());
		}

		public bool UpdateOtherBenefitRate(OtherBenefitRate value)
		{
			return flowOtherBenefitRate.UpdateOtherBenefitRate(value, GetCompany());
		}
	}
}
