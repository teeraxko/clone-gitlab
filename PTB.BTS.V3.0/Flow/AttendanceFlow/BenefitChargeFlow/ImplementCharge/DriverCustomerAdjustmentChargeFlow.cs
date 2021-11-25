using ictus.Common.Entity.Time;

namespace PTB.BTS.Attendance.BenefitChargeFlow
{
    public class DriverCustomerAdjustmentChargeFlow : CustomerAdjustmentChargeFlow
    {
        #region Constructor
        public DriverCustomerAdjustmentChargeFlow(ServiceStaffChargeBase serviceStaffCharge)
            : base(serviceStaffCharge)
        {
        } 
        #endregion

        #region Public Method
        /// <summary>
        /// For driver customer adjustment on month in advanced
        /// </summary>
        public override YearMonth GetYearMonth
        {
            get { return new YearMonth(AssignmentList.YearMonth.MinDateOfMonth.AddMonths(1)); }
        }

        public override decimal GetDeductAmount(decimal deductAmount)
        {
            return deductAmount;
        } 
        #endregion
    }
}

