using Entity.ContractEntities;
using PTB.BTS.Attendance.BenefitChargeEntities;

namespace PTB.BTS.Attendance.BenefitChargeFlow
{
    public abstract class ServiceStaffChargeBase
    {
        public abstract AssignmentList AssignmentList { get; set; }
        public abstract bool FillBenefit(IBenefitCharge benefitCharge);
    }
}
