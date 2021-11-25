using System;
using System.Collections.Generic;
using System.Text;
using PTB.BTS.Attendance.BenefitChargeFlow;
using PTB.BTS.Attendance.BenefitChargeEntities;
using DataAccess.ContractDB.ContractChargeRateDB;
using PTB.BTS.ContractEntities.ContractChargeRate;

namespace PTB.BTS.Attendance.BenefitChargeFlow
{
    public class SpecialChargeSummaryFlow : BenefitChargeBase
    {          
        CustomerSpecialChargeDB dbCustomerSpecialCharge;

        //============================== Constructor ==============================
        public SpecialChargeSummaryFlow(ServiceStaffChargeBase serviceStaffCharge)
            : base(serviceStaffCharge)
        {
            dbCustomerSpecialCharge = new CustomerSpecialChargeDB();
        }

        //============================== Public method ==============================
        public override bool FillBenefit(IBenefitCharge benefitCharge)
        {
            bool result = serviceStaffCharge.FillBenefit(benefitCharge);

            if (result)
            {
                bool status = false;

                CustomerSpecialCharge specialCharge = new CustomerSpecialCharge();
                specialCharge.Contract = AssignmentList.Contract;
                specialCharge.YearMonth = AssignmentList.YearMonth;

                //For assign department more than one
                if (AssignmentList.Contract.IsAssignCustomerDepartment)
                {
                    status = dbCustomerSpecialCharge.FillCustomerSpecialCharge(specialCharge, AssignmentList.Company, AssignmentList.Contract.ACustomerDepartment);                
                }
                else
                {
                    status = dbCustomerSpecialCharge.FillCustomerSpecialCharge(specialCharge, AssignmentList.Company);
                }

                if (status)
                {
                    benefitCharge.SpecialAmount = specialCharge.SpecialAmount;
                    benefitCharge.TelephoneAmount = specialCharge.TelephoneAmount;

                    if (specialCharge.SpecialAmount != decimal.Zero)
                    {
                        benefitCharge.Line = 2;
                    }
                }

                specialCharge = null;
            }
            #region - Calculate Charge -

            #endregion

            return result;
        }
    }
}
