using System;
using Entity.AttendanceEntities;
using Entity.ContractEntities;
using ictus.Common.Entity.Time;
using PTB.BTS.Attendance.BenefitChargeEntities;
using PTB.BTS.BTS2BizPacEntity;

namespace PTB.BTS.Attendance.BenefitChargeFlow
{
    public abstract class BenefitChargeBase : ServiceStaffChargeBase
    {
        #region Constructor
        public BenefitChargeBase(ServiceStaffChargeBase serviceStaffCharge)
        {
            this.serviceStaffCharge = serviceStaffCharge;
        } 
        #endregion

        #region Property
        public sealed override AssignmentList AssignmentList
        {
            get { return serviceStaffCharge.AssignmentList; }
            set { serviceStaffCharge.AssignmentList = value; }
        }

        protected ServiceStaffChargeBase serviceStaffCharge;
        public ServiceStaffChargeBase ServiceStaffCharge
        {
            get
            {
                return serviceStaffCharge;
            }
        }

        #endregion

        #region Protected Method
        /// <summary>
        /// Validate multiple department assignment
        /// </summary>
        /// <param name="benefitCharge"></param>
        /// <param name="forDate"></param>
        /// <returns>bool</returns>
        protected bool ValidateMultipleDepartment(IBenefitCharge benefitCharge, DateTime forDate)
        {
            if (benefitCharge is DriverContractChargeBP && AssignmentList.Contract.IsAssignCustomerDepartment)
            {
                return ((DriverContractChargeBP)benefitCharge).DepartmentAssignedPeriod.From.Date <= forDate.Date
                    && ((DriverContractChargeBP)benefitCharge).DepartmentAssignedPeriod.To.Date >= forDate.Date;
            }
            return true;
        }

        protected TimePeriod getTimePeriodInYearMonth(TimePeriod period, YearMonth yearMonth)
        {
            TimePeriod temp = new TimePeriod();
            temp.From = yearMonth.MinDateOfMonth;
            temp.To = yearMonth.MaxDateOfMonth;

            if (period.From >= yearMonth.MinDateOfMonth)
            {
                temp.From = period.From;
            }

            if (period.To <= yearMonth.MaxDateOfMonth)
            {
                temp.To = period.To;
            }

            return temp;
        }

        #endregion
    }
}
