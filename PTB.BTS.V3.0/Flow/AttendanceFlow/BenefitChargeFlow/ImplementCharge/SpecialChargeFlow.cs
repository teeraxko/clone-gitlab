using DataAccess.ContractDB.ContractChargeRateDB;
using PTB.BTS.Attendance.BenefitChargeEntities;
using PTB.BTS.ContractEntities.ContractChargeRate;

namespace PTB.BTS.Attendance.BenefitChargeFlow
{
    public class SpecialChargeFlow : BenefitChargeBase
    {
        CustomerSpecialChargeConditionDB dbCustomerSpecialChargeCondition;

        //============================== Constructor ==============================
        public SpecialChargeFlow(ServiceStaffChargeBase serviceStaffCharge)
            : base(serviceStaffCharge)
        {
            dbCustomerSpecialChargeCondition = new CustomerSpecialChargeConditionDB();
        }

        //============================== Public method ==============================
        public override bool FillBenefit(IBenefitCharge benefitCharge)
        {
            bool result = serviceStaffCharge.FillBenefit(benefitCharge);

            if (result)
            {
                bool status = false;

                CustomerSpecialChargeCondition specialCharge = new CustomerSpecialChargeCondition();
                specialCharge.Contract = AssignmentList.Contract;

                //For assign department more than one
                if (AssignmentList.Contract.IsAssignCustomerDepartment)
                {
                    status = dbCustomerSpecialChargeCondition.FillCustomerSpecialChargeCondition(specialCharge, AssignmentList.Company, AssignmentList.Contract.ACustomerDepartment);
                }
                else
                {
                    status = dbCustomerSpecialChargeCondition.FillCustomerSpecialChargeCondition(specialCharge, AssignmentList.Company);
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

            return result;
        }
    }
}
