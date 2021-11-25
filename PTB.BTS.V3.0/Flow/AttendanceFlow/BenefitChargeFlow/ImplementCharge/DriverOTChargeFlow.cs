using DataAccess.ContractDB;
using Entity.AttendanceEntities;
using Entity.ContractEntities;
using Flow.AttendanceFlow.CommonBenefitFlow;
using PTB.BTS.Attendance.BenefitChargeEntities;
using PTB.BTS.BTS2BizPacEntity;

namespace PTB.BTS.Attendance.BenefitChargeFlow
{
    public class DriverOTChargeFlow : OTChargeFlow
    {
        #region Private Variable
        private VDContractMatchDB dbVDContractMatch; 
        #endregion

        #region Constructor
        public DriverOTChargeFlow(ServiceStaffChargeBase serviceStaffCharge)
            : base(serviceStaffCharge)
        {
            dbVDContractMatch = new VDContractMatchDB();
        } 
        #endregion

        #region Protected Method
        protected override void getVehiclePlateNo(IBenefitCharge benefitCharge)
        {
            int vehicleNo = dbVDContractMatch.FillVDContractMatch(AssignmentList.Contract.ContractNo, AssignmentList.Company);
            if (vehicleNo != -1)
            {
                using (DataAccess.VehicleDB.VehicleDB dbVehicle = new DataAccess.VehicleDB.VehicleDB())
                {
                    ((DriverContractChargeBP)benefitCharge).VehiclePlateNo = dbVehicle.GetVehiclePlateNo(vehicleNo, AssignmentList.Company);
                }
            }
        }

        protected override void calOTBWorkSchedule(OvertimeHour overtimeHour)
        {
            if (overtimeHour.AOTRateForCharge.OtBHour <= minOTChargeList["'Y'"].MinOTHour)
            {
                holiday++;
            }
            else
            {
                otB = CommonAttendanceFlow.AddTime(otB, overtimeHour.AOTRateForCharge.OtBHour);
            }
        }

        protected override decimal MinHolidayCharge
        {
            get { return chargeRate.MinHolidayAmount; }
        } 
        #endregion
    }
}
