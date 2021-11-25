using System;

using PTB.BTS.Report.Flow;

using Facade.PiFacade;

namespace Facade.AttendanceFacade
{
	public class TimeCardForPaymentFacade : CommonPIFacadeBase
	{
        #region Private Variable
        private TimeCardForPaymentFlow flowTimeCardForPaymentFlow;
		private bool disposed = false; 
        #endregion

        #region Constructor
        public TimeCardForPaymentFacade()
            : base()
        {
            flowTimeCardForPaymentFlow = new TimeCardForPaymentFlow();
        }

        #endregion

        #region Public Method
        public bool GenerateTimeCardPayment(DateTime value)
        {
            return flowTimeCardForPaymentFlow.GenerateTimeCardPayment(value);
        } 
        #endregion

        #region IDisposable Members
        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                try
                {
                    if (disposing)
                    {
                        flowTimeCardForPaymentFlow.Dispose();
                        flowTimeCardForPaymentFlow = null;
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
