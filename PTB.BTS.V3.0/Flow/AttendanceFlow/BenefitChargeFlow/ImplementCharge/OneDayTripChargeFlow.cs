using System;
using DataAccess.AttendanceDB;
using Entity.AttendanceEntities;
using Entity.ContractEntities;
using PTB.BTS.Attendance.BenefitChargeEntities;

namespace PTB.BTS.Attendance.BenefitChargeFlow
{
    public class OneDayTripChargeFlow : BenefitChargeBase
    {
        #region Private Variable
        private EmployeeOneDayTripBenefitDB dbEmployeeOneDayTripBenefit;
        private static OtherBenefitRate otherBenefitRate;

        #endregion

        #region Constructor
        public OneDayTripChargeFlow(ServiceStaffChargeBase serviceStaffCharge)
            : base(serviceStaffCharge)
        {
            dbEmployeeOneDayTripBenefit = new EmployeeOneDayTripBenefitDB();
        } 
        #endregion

        #region Public Method
        public override bool FillBenefit(IBenefitCharge benefitCharge)
        {
            bool result = serviceStaffCharge.FillBenefit(benefitCharge);

            if (result)
            {
                #region - Get OtherBenefitRate -
                if (otherBenefitRate == null)
                {
                    using (OtherBenefitRateDB dbOtherBenefitRate = new OtherBenefitRateDB())
                    {
                        otherBenefitRate = new OtherBenefitRate();
                        dbOtherBenefitRate.FillOtherBenefitRate(ref otherBenefitRate, AssignmentList.Company);
                    }
                }
                #endregion

                int tripFar = 0;
                decimal tripFarAmount = decimal.Zero;

                #region - OneDayTripBenefit -
                foreach (ServiceStaffAssignment staffAssign in AssignmentList)
                {
                    OneDayTripBenefit oneDayTripBenefit;

                    TimePeriod timePeriod = getTimePeriodInYearMonth(staffAssign.APeriod, AssignmentList.YearMonth);

                    for (DateTime forDate = timePeriod.From; forDate <= timePeriod.To; forDate = forDate.AddDays(1))
                    {
                        oneDayTripBenefit = new OneDayTripBenefit();

                        //For case multiple department assignment
                        if (ValidateMultipleDepartment(benefitCharge, forDate) &&
                            dbEmployeeOneDayTripBenefit.FillOneDayTripBenefit(oneDayTripBenefit, staffAssign.AAssignedServiceStaff, forDate))
                        {
                            result = true;

//                            if (oneDayTripBenefit.BenefitAmount == benefitCharge.ChargeRate.OneDayTripRateFar)
//                            {
                                tripFar += oneDayTripBenefit.Times;
//                            }
                        }
                    }
                    timePeriod = null;
                    oneDayTripBenefit = null;
                }
                #endregion

                #region - Calculate Charge -
                benefitCharge.TripFar = tripFar;
                benefitCharge.TripFarAmount = tripFar * benefitCharge.ChargeRate.OneDayTripRateFar;
                #endregion
            }

            return result;
        } 
        #endregion
    }
}
