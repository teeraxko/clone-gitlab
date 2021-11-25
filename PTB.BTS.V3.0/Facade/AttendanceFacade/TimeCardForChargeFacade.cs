using System;

using PTB.BTS.Report.Flow;

using Facade.PiFacade;

namespace Facade.AttendanceFacade
{
	public class TimeCardForChargeFacade : CommonPIFacadeBase
	{
        #region Private Variable
        private TimeCardForChargeFlow flowTimeCardForChargeFlow;
        private bool disposed = false; 
        #endregion

        #region Constructor
        public TimeCardForChargeFacade()
            : base()
        {
            flowTimeCardForChargeFlow = new TimeCardForChargeFlow();
        } 
        #endregion

        #region Public Method
        public bool GenerateTimeCardCharge(DateTime value)
        {
            return flowTimeCardForChargeFlow.GenerateTimeCardCharge(value);
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
                        flowTimeCardForChargeFlow.Dispose();
                        flowTimeCardForChargeFlow = null;
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
