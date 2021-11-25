using PTB.BTS.Attendance.BenefitChargeFlow;
using PTB.BTS.BTS2BizPacEntity;

namespace PTB.BTS.BTS2BizPacFlow.DriverContractChargeFlow
{
    public class DriverSummaryIncomeFlow : DriverContractChargeTRFlow
    {
        #region Constructor
        public DriverSummaryIncomeFlow()
            : base()
        { } 
        #endregion

        #region Protected Method
        protected override void fillCharge(DriverContractChargeBP driverContractChargeBP)
        {
            BenefitChargeFlow.DriverChargeSummary(driverContractChargeBP);
        } 
        #endregion
    }
}
