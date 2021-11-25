using Entity.ContractEntities;
using Flow.AttendanceFlow.CommonBenefitFlow;
using ictus.Common.Entity;
using PTB.BTS.Attendance.BenefitChargeEntities;
using PTB.BTS.BTS2BizPacEntity;

namespace PTB.BTS.Attendance.BenefitChargeFlow
{
    public static class BenefitChargeFlow
    {
        private static ServiceStaffChargeBase driverBenefitCharge;
        private static ServiceStaffChargeBase otherBenefitCharge;
        private static ServiceStaffChargeBase driverSummaryBenefitCharge;

        public static void DriverCharge(DriverContractChargeBP driverContractChargeBP)
        {
            if (driverBenefitCharge == null)
            {
                driverBenefitCharge = new AssignmentChargeFlow(driverContractChargeBP, driverContractChargeBP.YearMonth, new Company("12"));
                driverBenefitCharge = new DriverOTChargeFlow(driverBenefitCharge);
                driverBenefitCharge = new TaxiChargeFlow(driverBenefitCharge);
                driverBenefitCharge = new OneDayTripChargeFlow(driverBenefitCharge);
                driverBenefitCharge = new OverNightTripChargeFlow(driverBenefitCharge);
                driverBenefitCharge = new DriverCustomerAdjustmentChargeFlow(driverBenefitCharge);
                driverBenefitCharge = new DeductChargeFlow(driverBenefitCharge);
                driverBenefitCharge = new SpecialChargeFlow(driverBenefitCharge);
            }

            driverBenefitCharge.AssignmentList = new AssignmentList(driverContractChargeBP, driverContractChargeBP.YearMonth, new Company("12"));

            driverBenefitCharge.FillBenefit((IBenefitCharge)driverContractChargeBP);
        }

        public static void OtherServiceStaffCharge(ServiceStaffContractChargeBP serviceStaffContractChargeBP)
        {
            if (otherBenefitCharge == null)
            {
                otherBenefitCharge = new AssignmentChargeFlow(serviceStaffContractChargeBP, serviceStaffContractChargeBP.YearMonth, new Company("12"));
                otherBenefitCharge = new CustomerAdjustmentChargeFlow(otherBenefitCharge);
                otherBenefitCharge = new SpecialChargeFlow(otherBenefitCharge);
            }

            otherBenefitCharge.AssignmentList = new AssignmentList(serviceStaffContractChargeBP, serviceStaffContractChargeBP.YearMonth, new Company("12"));
            otherBenefitCharge.FillBenefit((IBenefitCharge)serviceStaffContractChargeBP);

            serviceStaffContractChargeBP.OTAHourAdjust = CommonAttendanceFlow.HalfRound(serviceStaffContractChargeBP.OTAHourAdjust);
            serviceStaffContractChargeBP.OTBHourAdjust = CommonAttendanceFlow.HalfRound(serviceStaffContractChargeBP.OTBHourAdjust);
            serviceStaffContractChargeBP.OTCHourAdjust = CommonAttendanceFlow.HalfRound(serviceStaffContractChargeBP.OTCHourAdjust);
        }

        public static void DriverChargeSummary(DriverContractChargeBP driverContractChargeBP)
        {
            if (driverSummaryBenefitCharge == null)
            {
                driverSummaryBenefitCharge = new AssignmentChargeFlow(driverContractChargeBP, driverContractChargeBP.YearMonth, new Company("12"));
                driverSummaryBenefitCharge = new DriverOTChargeFlow(driverSummaryBenefitCharge);
                driverSummaryBenefitCharge = new TaxiChargeFlow(driverSummaryBenefitCharge);
                driverSummaryBenefitCharge = new OneDayTripChargeFlow(driverSummaryBenefitCharge);
                driverSummaryBenefitCharge = new OverNightTripChargeFlow(driverSummaryBenefitCharge);
                driverSummaryBenefitCharge = new DriverCustomerAdjustmentChargeFlow(driverSummaryBenefitCharge);
                driverSummaryBenefitCharge = new DeductChargeFlow(driverSummaryBenefitCharge);
                //Found problem when staff was assigned more than 1 contract in month, anyway source code is change to common rule before.
                driverSummaryBenefitCharge = new SpecialChargeFlow(driverSummaryBenefitCharge);
            }

            driverSummaryBenefitCharge.AssignmentList = new AssignmentList(driverContractChargeBP, driverContractChargeBP.YearMonth, new Company("12"));

            driverSummaryBenefitCharge.FillBenefit((IBenefitCharge)driverContractChargeBP);
        }
    }
}
