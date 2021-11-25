using System;

using Entity.AttendanceEntities;
using Entity.AttendanceEntities.BenefitEntities;
using Entity.CommonEntity;
using Entity.ContractEntities;

using ictus.Common.Entity;
using ictus.Common.Entity.General;
using ictus.PIS.PI.Entity;

using DataAccess.AttendanceDB;
using DataAccess.ContractDB;

using PTB.BTS.Attendance.Benefit.Flow;
using PTB.BTS.Common.Flow;
using PTB.BTS.Contract.Flow;
using Flow.AttendanceFlow;
using SystemFramework.AppException;

namespace PTB.BTS.Attendance.Benefit.Flow
{
    public class OTBenefitFlow : CalOTFlowBase
    {
        #region Private Variable
        private CalOTByPatternFlow flowCalOTByPattern;
        private CalOTByVarientFlow flowCalOTByVarient;
        private CalOTByVarientForChargeFlow flowCalOTByVarientForCharge;

        private EmployeeOvertimeHourDB dbEmployeeOvertimeHour;
        #endregion

        #region Constructor
        public OTBenefitFlow()
            : base()
        {
            flowCalOTByPattern = new CalOTByPatternFlow();
            flowCalOTByVarient = new CalOTByVarientFlow();

            flowCalOTByVarientForCharge = new CalOTByVarientForChargeFlow();

            dbEmployeeOvertimeHour = new EmployeeOvertimeHourDB();
        }
        #endregion

        #region Private Method

        /// <summary>
        /// To calculate OT of staff and separate staff who is family driver, office driver or other staff
        /// </summary>
        /// <param name="value"></param>
        /// <param name="employeeBenefit"></param>
        private void calculateOT(DateTime value, EmployeeBenefit employeeBenefit)
        {
            this.calculateOTRate(value, employeeBenefit);
            this.calculateOTRateForCharge(value, employeeBenefit);
        }

        /// <summary>
        /// Calculate OT For Charge
        /// </summary>
        /// <param name="value"></param>
        /// <param name="workInfo"></param>
        /// <param name="nextWorkInfo"></param>
        /// <param name="employee"></param>
        private void calculateOTFamilyCarDriverForCharge(BenefitOTHour benefit, WorkInfo workInfo, WorkInfo nextWorkInfo, Employee employee)
        {
            OTRate temp = benefit.OTRate;
            benefit.OTRate = benefit.OTRateForCharge;

            flowCalOTByVarientForCharge.CalculateOT(benefit, workInfo, nextWorkInfo, employee);
            benefit.OTRateForCharge = benefit.OTRate;
            benefit.OTRate = temp;
            temp = null;
        }

        /// <summary>
        /// To calculate OT of employee.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="employeeBenefit"></param>
        private void calculateOTRate(DateTime value, EmployeeBenefit employeeBenefit)
        {
            if (employeeBenefit.WorkInfoList[value].AssignServiceStaffType.Type == ServiceStaffType.TypeCode.FAMILY_CAR_DRIVER)
            {
                flowCalOTByVarient.CalculateOT(employeeBenefit.BenefitOTHourList[value], employeeBenefit.WorkInfoList[value], employeeBenefit.WorkInfoList[value.AddDays(1)], employeeBenefit.Employee);
            }
            else
            {
                flowCalOTByPattern.CalculateOT(employeeBenefit.BenefitOTHourList[value], employeeBenefit.WorkInfoList[value], employeeBenefit.WorkInfoList[value.AddDays(1)], employeeBenefit.Employee);
            }
        }

        /// <summary>
        /// To calculate to charge with customer.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="employeeBenefit"></param>
        private void calculateOTRateForCharge(DateTime value, EmployeeBenefit employeeBenefit)
        {
            bool isNormalRate = false;
            BenefitOTHour currentBenefit = employeeBenefit.BenefitOTHourList[value];
            WorkInfo currentWorkInfo = employeeBenefit.WorkInfoList[value];
            WorkInfo nextWorkInfo = employeeBenefit.WorkInfoList[value.AddDays(1)];


            if ((currentWorkInfo.AssignServiceStaffType.Type != ServiceStaffType.TypeCode.FAMILY_CAR_DRIVER) && (employeeBenefit.Employee.APosition.APositionRole != POSITION_ROLE_TYPE.MACHANIC))
            {
                isNormalRate = true;
            }

            if (isNormalRate)
            {
                employeeBenefit.BenefitOTHourList[value].OTRateForCharge = currentBenefit.OTRate;
            }
            else
            {
                OTRate temp = currentBenefit.OTRate;
                currentBenefit.OTRate = currentBenefit.OTRateForCharge;

                if (currentWorkInfo.AssignServiceStaffType.Type == ServiceStaffType.TypeCode.FAMILY_CAR_DRIVER)
                {
                    switch (employeeBenefit.Employee.APosition.APositionRole)
                    {
                        case POSITION_ROLE_TYPE.DRIVER:
                            flowCalOTByVarientForCharge.CalculateOT(currentBenefit, currentWorkInfo, nextWorkInfo, employeeBenefit.Employee);
                            break;

                        case POSITION_ROLE_TYPE.MACHANIC:
                            this.calculateOTFamilyCarMachanicDriverForCharge(currentBenefit, currentWorkInfo, nextWorkInfo, employeeBenefit.Employee);
                            break;
                    }
                }
                else if (currentWorkInfo.AssignServiceStaffType.Type == ServiceStaffType.TypeCode.DRIVER)
                {
                    switch (employeeBenefit.Employee.APosition.APositionRole)
                    {
                        case POSITION_ROLE_TYPE.MACHANIC:
                            this.calculateOTMachanicDriverForCharge(currentBenefit, currentWorkInfo, nextWorkInfo, employeeBenefit.Employee);
                            break;
                    }
                }

                currentBenefit.OTRateForCharge = currentBenefit.OTRate;
                currentBenefit.OTRate = temp;
                temp = null;
            }
        }

        /// <summary>
        /// To calculate OT for charge of machanic employee and family car driver
        /// </summary>
        /// <param name="value"></param>
        /// <param name="workInfo"></param>
        /// <param name="nextWorkInfo"></param>
        /// <param name="employee"></param>
        private void calculateOTFamilyCarMachanicDriverForCharge(BenefitOTHour benefit, WorkInfo workInfo, WorkInfo nextWorkInfo, Employee employee)
        {
            OTRate tempOTRate = benefit.OTRate;
            benefit.OTRate = benefit.OTRateForCharge;

            WorkInfo mainWorkInfo = this.findWorkInfoOfMainStaff(employee, benefit.BenefitDate);

            using (CalOTByVarientForChargeFlow calOTByVarient = new CalOTByVarientForChargeFlow())
            {
                calOTByVarient.CalculateOT(benefit, mainWorkInfo, new WorkInfo(mainWorkInfo.BenefitDate.AddDays(1)), employee);
            }

            benefit.OTRateForCharge = benefit.OTRate;
            benefit.OTRate = tempOTRate;

            tempOTRate = null;
        }

        /// <summary>
        /// To calculate OT for charge of machanic employee and none family car driver
        /// </summary>
        /// <param name="value"></param>
        /// <param name="workInfo"></param>
        /// <param name="nextWorkInfo"></param>
        /// <param name="employee"></param>
        private void calculateOTMachanicDriverForCharge(BenefitOTHour benefit, WorkInfo workInfo, WorkInfo nextWorkInfo, Employee employee)
        {
            OTRate tempOTRate = benefit.OTRate;
            benefit.OTRate = benefit.OTRateForCharge;
            benefit.OTRate.OtAHour = decimal.Zero;
            benefit.OTRate.OtBHour = decimal.Zero;
            benefit.OTRate.OtCHour = decimal.Zero;

            WorkInfo mainWorkInfo = this.findWorkInfoOfMainStaff(employee, benefit.BenefitDate);

            using (CalOTByPatternFlow calOTByPattern = new CalOTByPatternFlow())
            {
                calOTByPattern.CalculateOT(benefit, mainWorkInfo, new WorkInfo(mainWorkInfo.BenefitDate.AddDays(1)), employee);
            }

            benefit.OTRateForCharge = benefit.OTRate;
            benefit.OTRate = tempOTRate;

            tempOTRate = null;
        }

        /// <summary>
        /// Get workinfo for mechanic driver
        /// </summary>
        /// <param name="assignedEmployee"></param>
        /// <param name="scheduleDate"></param>
        /// <returns>WorkInfo</returns>
        private WorkInfo findWorkInfoOfMainStaff(Employee assignedEmployee, DateTime scheduleDate)
        {
            ServiceStaffAssignment staffAssign = null;
            WorkSchedule workSchedule = null;
            ServiceStaff serviceStaff = null;

            using (ServiceStaffAssignmentDB dbServiceStaffAssignment = new ServiceStaffAssignmentDB())
            {
                staffAssign = dbServiceStaffAssignment.GetStaffAssignByDate(assignedEmployee, scheduleDate);
            }

            using (EmployeeWorkScheduleDB dbEmployeeWorkSchedule = new EmployeeWorkScheduleDB())
            {
                //Check case mechanic is main
                if (staffAssign.AAssignedServiceStaff.EmployeeNo == staffAssign.AMainServiceStaff.EmployeeNo &&
                    staffAssign.AssignmentRole == ASSIGNMENT_ROLE_TYPE.MAIN)
                {
                    workSchedule = getWorkScheduleForMechanic(assignedEmployee, scheduleDate);

                    using (ServiceStaffFlow flow = new ServiceStaffFlow())
                    {
                        serviceStaff = flow.GetServiceStaffMainByPeriod(assignedEmployee.EmployeeNo, new TimePeriod(scheduleDate.Date, scheduleDate.Date), assignedEmployee.Company);
                    }
                }
                else
                {
                    workSchedule = dbEmployeeWorkSchedule.GetWorkSchedule(staffAssign.AMainServiceStaff, scheduleDate);
                    serviceStaff = staffAssign.AMainServiceStaff;
                }
            }

            WorkInfo workInfo = new WorkInfo(workSchedule);
            workInfo.AssignCustomer = staffAssign.AContract.ACustomer;
            workInfo.AssignServiceStaffType = serviceStaff.AServiceStaffType;

            return workInfo;
        }

        private WorkSchedule getWorkScheduleForMechanic(Employee mechanic, DateTime forDate)
        {
            WorkSchedule workschedule = null;
            ServiceStaff serviceStaff = null;

            using (ServiceStaffFlow flow = new ServiceStaffFlow())
            {
                serviceStaff = flow.GetServiceStaffMainByPeriod(mechanic.EmployeeNo, new TimePeriod(forDate.Date, forDate.Date), mechanic.Company);
            }

            using (GenerateEmployeeWorkScheduleFlow flow = new GenerateEmployeeWorkScheduleFlow())
            {
                EmployeeWorkSchedule employeeWorkSchedule = flow.GenWorkSchedule(serviceStaff, new ictus.Common.Entity.Time.YearMonth(forDate));
                workschedule = employeeWorkSchedule[forDate.ToShortDateString()];

                if (workschedule == null)
                {
                    AppExceptionBase appExceptionBase = new AppExceptionBase("OTBenefitFlow");
                    appExceptionBase.SetMessage("ไม่พบข้อมูล Working Schedule สำหรับ " + mechanic.EmployeeIDName);
                    throw appExceptionBase;
                }
            }

            return workschedule;
        }
        #endregion

        #region Public Method

        public void FillOTHourList(EmployeeBenefit value)
        {
            dbEmployeeOvertimeHour.FillBenefitOTHourList(value.BenefitOTHourList);
            CalculateTotalOT(value);
        }

        public void CalculateOT(BenefitOTHour value, EmployeeBenefit employeeBenefit)
        {
            value.OTRate.OtAHour = 0;
            value.OTRate.OtBHour = 0;
            value.OTRate.OtCHour = 0;
            if (value.ValidOTHour)
            {
                calculateOT(value.BenefitDate, employeeBenefit);
            }
            CalculateTotalOT(employeeBenefit);
        }

        public void CalculateOT(EmployeeBenefit value)
        {
            for (int i = 0; i < value.BenefitOTHourList.Count; i++)
            {
                value.BenefitOTHourList[i].OTRate.OtAHour = 0;
                value.BenefitOTHourList[i].OTRate.OtBHour = 0;
                value.BenefitOTHourList[i].OTRate.OtCHour = 0;
                if (value.BenefitOTHourList[i].ValidOTHour)
                {
                    calculateOT(value.BenefitOTHourList[i].BenefitDate, value);
                }
            }

            CalculateTotalOT(value);
        }

        public void CalculateTotalOT(EmployeeBenefit value)
        {
            value.BenefitOTHourList.TotalOTRate.OtAHour = 0;
            value.BenefitOTHourList.TotalOTRate.OtBHour = 0;
            value.BenefitOTHourList.TotalOTRate.OtCHour = 0;
            for (int i = 0; i < value.BenefitOTHourList.Count; i++)
            {
                if (value.BenefitOTHourList[i].BeforeTime.From != NullConstant.DATETIME && value.BenefitOTHourList[i].AfterTime.To != NullConstant.DATETIME)
                {
                    if (value.BenefitOTHourList[i].OTRate.OtAHour != NullConstant.DECIMAL)
                    {
                        value.BenefitOTHourList.TotalOTRate.OtAHour = addTime(value.BenefitOTHourList.TotalOTRate.OtAHour, value.BenefitOTHourList[i].OTRate.OtAHour);
                    }
                    if (value.BenefitOTHourList[i].OTRate.OtBHour != NullConstant.DECIMAL)
                    {
                        value.BenefitOTHourList.TotalOTRate.OtBHour = addTime(value.BenefitOTHourList.TotalOTRate.OtBHour, value.BenefitOTHourList[i].OTRate.OtBHour);
                    }
                    if (value.BenefitOTHourList[i].OTRate.OtCHour != NullConstant.DECIMAL)
                    {
                        value.BenefitOTHourList.TotalOTRate.OtCHour = addTime(value.BenefitOTHourList.TotalOTRate.OtCHour, value.BenefitOTHourList[i].OTRate.OtCHour);
                    }
                }
            }
        }
        #endregion
    }
}