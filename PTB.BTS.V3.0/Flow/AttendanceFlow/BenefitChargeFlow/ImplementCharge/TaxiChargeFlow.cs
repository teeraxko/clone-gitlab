using System;
using PTB.BTS.Attendance.BenefitChargeEntities;
using DataAccess.AttendanceDB;
using Entity.ContractEntities;
using Entity.AttendanceEntities;

namespace PTB.BTS.Attendance.BenefitChargeFlow
{
    public class TaxiChargeFlow : BenefitChargeBase
    {
        private EmployeeTaxiBenefitDB dbEmployeeTaxiBenefit;

        //============================== Constructor ==============================
        public TaxiChargeFlow(ServiceStaffChargeBase serviceStaffCharge) : base(serviceStaffCharge)
        {
            dbEmployeeTaxiBenefit = new EmployeeTaxiBenefitDB();
        }

        //============================== Public method ==============================
        public override bool FillBenefit(IBenefitCharge benefitCharge)
        {
            bool result = serviceStaffCharge.FillBenefit(benefitCharge);

            if (result)
            {
                decimal taxiAmount = decimal.Zero;
                int taxi = 0;

                #region - TaxiBenefit -
                foreach (ServiceStaffAssignment staffAssign in AssignmentList)
                {
                    TaxiBenefit taxiBenefit;
                    TimePeriod timePeriod = getTimePeriodInYearMonth(staffAssign.APeriod, AssignmentList.YearMonth);

                    for (DateTime forDate = timePeriod.From; forDate <= timePeriod.To; forDate = forDate.AddDays(1))
                    {
                        taxiBenefit = new TaxiBenefit();
                        taxiBenefit.BenefitDate = forDate;

                        //For case multiple department assignment
                        if (ValidateMultipleDepartment(benefitCharge, forDate) &&
                            dbEmployeeTaxiBenefit.FillTaxiBenefit(taxiBenefit, staffAssign.AAssignedServiceStaff))
                        {
                            taxiAmount += taxiBenefit.BenefitAmountForCharge * taxiBenefit.TimesForCharge;
                            taxi += taxiBenefit.TimesForCharge;
                        }
                    }

                    timePeriod = null;
                    taxiBenefit = null;
                }
                #endregion

                #region - Calculate Charge -
                benefitCharge.TaxiAmount += taxiAmount;
                benefitCharge.Taxi += taxi;
                #endregion
            }

            return result;
        }
    }
}
