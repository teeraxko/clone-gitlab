using System;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using Flow.AttendanceFlow;
using PTB.BTS.Report.Flow;
using PTB.BTS.Attendance.OtherBenefit.Flow;

using Facade.PiFacade;

using ictus.Common.Entity.Time;

namespace Facade.AttendanceFacade
{
	public class PayrollBenefitFacade : CommonPIFacadeBase
	{
		#region - private -
		private bool disposed = false;
		private GenerateOtherBenefitFlow flowGenerateOtherBenefit;
		private TrPayrollBenefitFlow flowTrPayrollBenefit;
		private EmployeeExtraBenefitFlow flowEmployeeExtraBenefit;
		private OtherBenefitFlow flowOtherBenefit;
		private PayrollPaymentControlFlow flowPayrollPaymentControl;
		#endregion

		private TrPayrollBenefitList objTrPayrollBenefitList;
		public TrPayrollBenefitList ObjTrPayrollBenefitList
		{
			get{return objTrPayrollBenefitList;}
		}

//		============================== Constructor ==============================
		public PayrollBenefitFacade() : base()
		{
			flowGenerateOtherBenefit = new GenerateOtherBenefitFlow();
			flowTrPayrollBenefit = new TrPayrollBenefitFlow();
			flowEmployeeExtraBenefit = new EmployeeExtraBenefitFlow();
			flowOtherBenefit = new OtherBenefitFlow();
			flowPayrollPaymentControl = new PayrollPaymentControlFlow();
		}

//		==================================== Public Method ====================================
		public bool GenPayrollBenefitProcess(DateTime value)
		{
			return flowOtherBenefit.GenPayrollBenefitProcess(new YearMonth(value), GetCompany());
		}

		public bool GenPayrollBenefit(DateTime paymentDate)
		{
			return flowTrPayrollBenefit.GeneratePayrollBenefit(paymentDate);
		}

		public DateTime RetriveDate(DateTime value)
		{
			return flowGenerateOtherBenefit.RetriveDate(value, GetCompany(), -1);
		}

		public bool FillPayrollPaymentControl(ref PayrollPaymentControl value)
		{
			return flowPayrollPaymentControl.FillPayrollPaymentControl(ref value, GetCompany());
		}

		public bool FillTrPayrollBenefitList()
		{
			objTrPayrollBenefitList = new TrPayrollBenefitList(GetCompany());
			return flowTrPayrollBenefit.FillTrPayrollBenefitList(ref objTrPayrollBenefitList);
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
						flowTrPayrollBenefit.Dispose();
						flowEmployeeExtraBenefit.Dispose();
						flowPayrollPaymentControl.Dispose();
						objTrPayrollBenefitList.Dispose();

						flowGenerateOtherBenefit = null;
						flowTrPayrollBenefit = null;
						flowEmployeeExtraBenefit = null;
						flowPayrollPaymentControl = null;
						objTrPayrollBenefitList = null;
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
