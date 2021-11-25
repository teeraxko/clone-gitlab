using System;
using DataAccess.AttendanceDB;
using Entity.AttendanceEntities;
using Entity.ContractEntities;
using PTB.BTS.Attendance.BenefitChargeEntities;

namespace PTB.BTS.Attendance.BenefitChargeFlow
{
    public class OverNightTripChargeFlow : BenefitChargeBase
    {
        #region Private Variable
        EmployeeOvernightTripBenefitDB dbEmployeeOvernightTripBenefit; 
        #endregion

        #region Constructor
        public OverNightTripChargeFlow(ServiceStaffChargeBase serviceStaffCharge) :
            base(serviceStaffCharge)
        {
            dbEmployeeOvernightTripBenefit = new EmployeeOvernightTripBenefitDB();
        } 
        #endregion

        #region Public Method
        public override bool FillBenefit(IBenefitCharge benefitCharge)
        {
            bool result = serviceStaffCharge.FillBenefit(benefitCharge);

            if (result)
            {
                int nightTrip = 0;
                decimal nightTipAmount = decimal.Zero;

                #region - OvernightTrip -
                EmployeeOvernightTripBenefit employeeOvernightTripBenefit;

                foreach (ServiceStaffAssignment staffAssign in AssignmentList)
                {
                    employeeOvernightTripBenefit = new EmployeeOvernightTripBenefit(AssignmentList.YearMonth, staffAssign.AAssignedServiceStaff);

                    if (dbEmployeeOvernightTripBenefit.FillEmployeeOvernightTripBenefit(employeeOvernightTripBenefit))
                    {
                        TimePeriod timePeriod = getTimePeriodInYearMonth(staffAssign.APeriod, AssignmentList.YearMonth);

                        for (DateTime forDate = timePeriod.From; forDate <= timePeriod.To; forDate = forDate.AddDays(1))
                        {
                            //For case multiple department assignment
                            if (ValidateMultipleDepartment(benefitCharge, forDate) &&
                                employeeOvernightTripBenefit.Contain(forDate.ToShortDateString()))
                            {
                                nightTrip++;
                                nightTipAmount += employeeOvernightTripBenefit[forDate.ToShortDateString()].TotalAmount;
                            }
                        }

                        timePeriod = null;
                    }
                }
                #endregion

                #region - Calculate Charge -
                benefitCharge.NightTrip += nightTrip;
                benefitCharge.NightTripAmount = nightTrip * benefitCharge.ChargeRate.OvernightTripRate;
                #endregion
            }

            return result;
        } 
        #endregion
    }
}
