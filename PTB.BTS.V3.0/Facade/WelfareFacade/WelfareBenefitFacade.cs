using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facade.CommonFacade;
using Facade.PiFacade;
using Flow.AttendanceFlow;

namespace Facade.WelfareFacade
{
    public class WelfareBenefitFacade : CommonPIFacadeBase
    {
        private bool disposed = false;
        private GenerateOtherBenefitFlow flowOtherBenefit;

        public WelfareBenefitFacade()
            : base()
        {
            flowOtherBenefit = new GenerateOtherBenefitFlow();
        }

        public bool GenWelfarePayrollBenefit(DateTime forMonth, DateTime validDate, DateTime paymentDate)
        {
            using (Flow.WelfareFlow.TrWelfareBenefitFlow flow = new Flow.WelfareFlow.TrWelfareBenefitFlow())
            {
                return flow.GenerateWelfarePayrollBenefit(forMonth, validDate, paymentDate);
            }
        }

        public DateTime RetriveDate(DateTime value)
        {
            return flowOtherBenefit.RetriveDate(value, GetCompany(), -1);
        }

        #region IDisposable Members
        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                try
                {
                    if (disposing)
                    {
                        flowOtherBenefit.Dispose();

                        flowOtherBenefit = null;
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
