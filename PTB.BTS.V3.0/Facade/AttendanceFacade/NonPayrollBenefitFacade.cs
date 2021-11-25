using System;

using Entity.CommonEntity;

using Flow.AttendanceFlow;
using PTB.BTS.Report.Flow;
using PTB.BTS.Attendance.OtherBenefit.Flow;

using Facade.PiFacade;

using ictus.Common.Entity.Time;

namespace Facade.AttendanceFacade
{
	public class NonPayrollBenefitFacade: CommonPIFacadeBase
	{
		#region - private -
		private bool disposed = false;
		private GenerateOtherBenefitFlow flowGenerateOtherBenefit;
		private TrNonPayrollBenefitFlow flowTrNonPayrollBenefit;
		private TelephoneBenefitFlow flowTelephoneBenefit;
		#endregion

//		============================== Constructor ==============================
		public NonPayrollBenefitFacade():base()
		{
			flowGenerateOtherBenefit = new GenerateOtherBenefitFlow();
			flowTrNonPayrollBenefit = new TrNonPayrollBenefitFlow();
			flowTelephoneBenefit = new TelephoneBenefitFlow();
		}

//		==================================== Public Method ====================================
		public bool GenNonPayrollBenefitProcess(DateTime value)
		{
			return flowTelephoneBenefit.GenTelephoneBenefit(new YearMonth(value), GetCompany());
		}

		public bool GenNonPayrollBenefit(DateTime yearMonth, DateTime dateTime)
		{
			return flowTrNonPayrollBenefit.GenerateNonPayrollBenefit(yearMonth, dateTime);
		}

		public DateTime RetriveDate(DateTime value)
		{
			return flowGenerateOtherBenefit.RetriveDate(value, GetCompany(), -1);
		}

		#region IDisposable Members
		protected override void Dispose(bool disposing)
		{
			if(!this.disposed)
			{
				try
				{
					if(disposing)
					{
						flowGenerateOtherBenefit.Dispose();
						flowTrNonPayrollBenefit.Dispose();
						flowTelephoneBenefit.Dispose();

						flowGenerateOtherBenefit = null;
						flowTrNonPayrollBenefit = null;
						flowTelephoneBenefit = null;
					}
					this.disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}
		#endregion
	}
}
