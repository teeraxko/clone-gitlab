using System;
using System.Text;

using DataAccess.CommonDB;
using DataAccess.ContractDB;
using DataAccess.AttendanceDB;

using PTB.BTS.Contract.Flow;

using Entity.CommonEntity;
using Entity.ContractEntities;
using Entity.AttendanceEntities;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;
using ictus.Common.Entity.Time;

using SystemFramework.AppException;

namespace Flow.AttendanceFlow
{
    public class GenerateEmployeeWorkScheduleFlow : GenerateWorkScheduleFlowBase
    {
        #region - Sub Class -
        class WorkScheduleInfo
        {
            public WorkingTimeCondition ObjWorkingTimeCondition;
            public WorkingTimeTable ObjWorkingTimeTable
            {
                get
                {
                    return ObjWorkingTimeCondition.AWorkingTimeTable;
                }
                set
                {
                    ObjWorkingTimeCondition = new WorkingTimeCondition();
                    ObjWorkingTimeCondition.AWorkingTimeTable = value;
                }
            }
            public HolidayCondition ObjHolidayCondition;
            public TraditionalHolidayList ObjTraditionalHoliday;
            private PositionType forPositionType;
            public PositionType ForPositionType
            {
                get
                {
                    return forPositionType;
                }
                set
                {
                    forPositionType = value;
                }
            }
            //				private ServiceStaffType forServiceStaffType;
            //				public ServiceStaffType ForServiceStaffType
            //				{
            //					get
            //					{
            //						return forServiceStaffType;
            //					}
            //				}
            //				private Customer forCustomer;
            //				public Customer ForCustomer
            //				{
            //					get
            //					{
            //						return forCustomer;
            //					}
            //				}
            //				private CustomerDepartment forCustomerDepartment;
            //				public CustomerDepartment ForCustomerDepartment
            //				{
            //					get
            //					{
            //						return forCustomerDepartment;
            //					}
            //				}

            public WorkScheduleInfo()
            {
                //					ObjWorkingTimeCondition = new WorkingTimeCondition();
                //					AHolidayCondition = new HolidayCondition();
                //					ATraditionalHoliday = new TraditionalHolidayList(company);
            }
        }

        class ConditionClass
        {
            public PositionType ObjPositionType;
            public ServiceStaffType ObjServiceStaffType;
            public Customer ObjCustomer;
            public CustomerDepartment ObjCustomerDepartment;

            public ConditionClass()
            { }
        }
        #endregion

        #region - Private -
        private WorkScheduleInfo defaultOfficeWorkScheduleInfo;
        private WorkScheduleInfo defaultServicestaffWorkScheduleInfo;

        private WorkingTimeConditionDB dbWorkingTimeCondition;
        private HolidayConditionDB dbHolidayCondition;
        private TraditionalHolidayDB dbTraditionalHoliday;
        private HolidayConditionSpecificDB dbHolidayConditionSpecific;
        private EmployeeWorkScheduleDB dbEmployeeWorkSchedule;
        private ServiceStaffAssignmentDB dbServiceStaffAssignment;
        private WorkingTimeConditionSpecificDB dbWorkingTimeConditionSpecific;
        #endregion

        #region - Property -
        #region - Dummy Property -
        private PositionType dummyOfficePositionType;
        private PositionType dummyServiceStaffPositionType;
        private ServiceStaffType dummyServiceStaffType;
        private Customer dummyCustomer;
        private CustomerDepartment dummyCustomerDepartment;
        #endregion
        #endregion

        //==============================  Constructor  ==============================
        public GenerateEmployeeWorkScheduleFlow()
            : base()
        {
            initDummy();
            dbWorkingTimeCondition = new WorkingTimeConditionDB();
            dbHolidayCondition = new HolidayConditionDB();
            dbTraditionalHoliday = new TraditionalHolidayDB();
            dbHolidayConditionSpecific = new HolidayConditionSpecificDB();
            dbEmployeeWorkSchedule = new EmployeeWorkScheduleDB();
            dbServiceStaffAssignment = new ServiceStaffAssignmentDB();
            dbWorkingTimeConditionSpecific = new WorkingTimeConditionSpecificDB();
        }

        #region - Private Method -
        #region - Init -
        private void initDummy()
        {
            dummyOfficePositionType = new PositionType();
            dummyOfficePositionType.Type = "O";
            dummyServiceStaffPositionType = new PositionType();
            dummyServiceStaffPositionType.Type = "S";
            dummyServiceStaffType = new ServiceStaffType();
            dummyServiceStaffType.Type = "ZZZ";
            dummyCustomer = new Customer(Customer.DUMMYCODE);
            dummyCustomerDepartment = new CustomerDepartment();
            dummyCustomerDepartment.Code = "ZZZ";
        }

        private void fillDefaultWorkScheduleInfo(WorkScheduleInfo value, YearMonth yearMonth, Company company)
        {
            WorkingTimeCondition workingTimeCondition = new WorkingTimeCondition();
            workingTimeCondition.APositionType = value.ForPositionType;
            workingTimeCondition.AServiceStaffType = dummyServiceStaffType;
            workingTimeCondition.ACustomerDepartment = dummyCustomerDepartment;
            workingTimeCondition.ACustomerDepartment.ACustomer = dummyCustomer;

            if (dbWorkingTimeCondition.FillWorkingTimeCondition(ref workingTimeCondition, company))
            {
                value.ObjWorkingTimeCondition = workingTimeCondition;
            }
            else
            {
                AppExceptionBase appExceptionBase = new AppExceptionBase("GenerateEmployeeWorkScheduleFlow");
                appExceptionBase.SetMessage("ไม่พบข้อมูล WorkingTimeCondition สำหรับ" + value.ForPositionType.Type);
                throw appExceptionBase;
            }

            HolidayCondition holidayCondition = new HolidayCondition();
            holidayCondition.APositionType = value.ForPositionType;
            holidayCondition.AServiceStaffType = dummyServiceStaffType;
            holidayCondition.ACustomerDepartment = dummyCustomerDepartment;
            holidayCondition.ACustomerDepartment.ACustomer = dummyCustomer;

            if (dbHolidayCondition.FillHolidayCondition(ref holidayCondition, company))
            {
                value.ObjHolidayCondition = holidayCondition;
            }
            else
            {
                AppExceptionBase appExceptionBase = new AppExceptionBase("GenerateEmployeeWorkScheduleFlow");
                appExceptionBase.SetMessage("ไม่พบข้อมูล HolidayCondition สำหรับ" + value.ForPositionType.Type);
                throw appExceptionBase;
            }

            TraditionalHolidayList traditionalHolidayList = new TraditionalHolidayList(company);
            if (holidayCondition.ATraditionalHolidayPattern.Code.Trim() != "")
            {
                traditionalHolidayList.ATraditionalHolidayPattern = holidayCondition.ATraditionalHolidayPattern;
                traditionalHolidayList.AYearMonth = yearMonth;
                dbTraditionalHoliday.FillTraditionalHolidayList(ref traditionalHolidayList);
            }
            value.ObjTraditionalHoliday = traditionalHolidayList;

            workingTimeCondition = null;
            holidayCondition = null;
            traditionalHolidayList = null;
        }

        private void initDefault(YearMonth yearMonth, Company company)
        {
            defaultOfficeWorkScheduleInfo = new WorkScheduleInfo();
            defaultOfficeWorkScheduleInfo.ForPositionType = dummyOfficePositionType;
            fillDefaultWorkScheduleInfo(defaultOfficeWorkScheduleInfo, yearMonth, company);

            defaultServicestaffWorkScheduleInfo = new WorkScheduleInfo();
            defaultServicestaffWorkScheduleInfo.ForPositionType = dummyServiceStaffPositionType;
            fillDefaultWorkScheduleInfo(defaultServicestaffWorkScheduleInfo, yearMonth, company);
        }
        #endregion

        #region - getWorkScheduleInfo -
        #region - getWorkScheduleInfo Detail -
        private ConditionClass decreaseCondition(ConditionClass condition)
        {
            if (condition.ObjCustomerDepartment.Code != dummyCustomerDepartment.Code)
            {
                condition.ObjCustomerDepartment = dummyCustomerDepartment;
                condition.ObjCustomerDepartment.ACustomer = condition.ObjCustomer;
                return condition;
            }
            if (condition.ObjCustomer.Code != dummyCustomer.Code)
            {
                condition.ObjCustomer = dummyCustomer;
                condition.ObjCustomerDepartment.ACustomer = dummyCustomer;
                return condition;
            }
            if (condition.ObjServiceStaffType.Type != dummyServiceStaffType.Type)
            {
                condition.ObjServiceStaffType = dummyServiceStaffType;
                return condition;
            }
            return condition;
        }


        private WorkingTimeCondition getWorkingTimeCondition(ConditionClass condition, Company company)
        {
            if (condition.ObjServiceStaffType.Type == dummyServiceStaffType.Type)
            {
                if (condition.ObjPositionType.Type == "O")
                {
                    return defaultOfficeWorkScheduleInfo.ObjWorkingTimeCondition;
                }
                else
                {
                    return defaultServicestaffWorkScheduleInfo.ObjWorkingTimeCondition;
                }
            }
            WorkingTimeCondition workingTimeCondition = new WorkingTimeCondition();
            workingTimeCondition.APositionType = condition.ObjPositionType;
            workingTimeCondition.AServiceStaffType = condition.ObjServiceStaffType;
            workingTimeCondition.ACustomerDepartment = condition.ObjCustomerDepartment;
            workingTimeCondition.ACustomerDepartment.ACustomer = condition.ObjCustomer;
            if (dbWorkingTimeCondition.FillWorkingTimeCondition(ref workingTimeCondition, company))
            {
                return workingTimeCondition;
            }
            else
            {
                workingTimeCondition = null;
                decreaseCondition(condition);
                return getWorkingTimeCondition(condition, company);
            }
        }

        private HolidayCondition getHolidayCondition(ConditionClass condition, Company company)
        {
            if (condition.ObjServiceStaffType.Type == dummyServiceStaffType.Type)
            {
                if (condition.ObjPositionType.Type == "O")
                {
                    return defaultOfficeWorkScheduleInfo.ObjHolidayCondition;
                }
                else
                {
                    return defaultServicestaffWorkScheduleInfo.ObjHolidayCondition;
                }
            }

            HolidayCondition holidayCondition = new HolidayCondition();
            holidayCondition.APositionType = condition.ObjPositionType;
            holidayCondition.AServiceStaffType = condition.ObjServiceStaffType;
            holidayCondition.ACustomerDepartment = condition.ObjCustomerDepartment;
            holidayCondition.ACustomerDepartment.ACustomer = condition.ObjCustomerDepartment.ACustomer;

            if (dbHolidayCondition.FillHolidayCondition(ref holidayCondition, company))
            {
                return holidayCondition;
            }
            else
            {
                holidayCondition = null;
                decreaseCondition(condition);
                return getHolidayCondition(condition, company);
            }
        }

        private TraditionalHolidayList getTraditionalHolidayList(TraditionalHolidayPattern pattern, YearMonth yearMonth, Company company)
        {
            TraditionalHolidayList traditionalHolidayList = new TraditionalHolidayList(company);
            if (pattern.Code.Trim() != "")
            {
                traditionalHolidayList.ATraditionalHolidayPattern = pattern;
                traditionalHolidayList.AYearMonth = yearMonth;
                dbTraditionalHoliday.FillTraditionalHolidayList(ref traditionalHolidayList);
            }
            return traditionalHolidayList;
        }
        #endregion

        private WorkScheduleInfo getWorkScheduleInfo(PositionType positionType, ServiceStaffType serviceStaffType, Customer customer, CustomerDepartment customerDepartment, Company company, YearMonth yearMonth)
        {
            ConditionClass condition = new ConditionClass();
            WorkScheduleInfo workScheduleInfo = new WorkScheduleInfo();

            condition.ObjCustomer = customer;
            condition.ObjCustomerDepartment = customerDepartment;
            condition.ObjCustomerDepartment.ACustomer = customer;
            condition.ObjPositionType = positionType;
            condition.ObjServiceStaffType = serviceStaffType;
            workScheduleInfo.ObjWorkingTimeCondition = getWorkingTimeCondition(condition, company);

            condition.ObjCustomer = customer;
            condition.ObjCustomerDepartment = customerDepartment;
            condition.ObjCustomerDepartment.ACustomer = customer;
            condition.ObjPositionType = positionType;
            condition.ObjServiceStaffType = serviceStaffType;
            workScheduleInfo.ObjHolidayCondition = getHolidayCondition(condition, company);
            workScheduleInfo.ObjTraditionalHoliday = getTraditionalHolidayList(workScheduleInfo.ObjHolidayCondition.ATraditionalHolidayPattern, yearMonth, company);

            condition = null;
            return workScheduleInfo;
        }
        #endregion

        #region - genWorkSchedule method -
        private TimePeriod getCopyTimePeriod(TimePeriod from)
        {
            TimePeriod temp = new TimePeriod();
            TimeConstant timeConstant = new TimeConstant();
            temp.From = timeConstant.ChangeHourMinute(from.From);
            temp.To = timeConstant.ChangeHourMinute(from.To);
            return temp;
        }

        private WORKINGDAY_TYPE getTraditionalHolidayWorkingdayType(DateTime value, TraditionalHolidayList traditionalHolidayList)
        {
            if (traditionalHolidayList.Contain(value.ToShortDateString()))
            {
                return WORKINGDAY_TYPE.HOLIDAY;
            }
            else
            {
                return WORKINGDAY_TYPE.WORKINGDAY;
            }
        }

        private WORKINGDAY_TYPE getWorkingdayType(DateTime value, HolidayCondition holidayCondition, TraditionalHolidayList traditionalHolidayList)
        {
            switch (value.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    if (holidayCondition.SaturdayBreak)
                    {
                        return WORKINGDAY_TYPE.HOLIDAY;
                    }
                    else
                    {
                        return getTraditionalHolidayWorkingdayType(value, traditionalHolidayList);
                    }
                case DayOfWeek.Sunday:
                    if (holidayCondition.SundayBreak)
                    {
                        return WORKINGDAY_TYPE.HOLIDAY;
                    }
                    else
                    {
                        return getTraditionalHolidayWorkingdayType(value, traditionalHolidayList);
                    }
                default:
                    return getTraditionalHolidayWorkingdayType(value, traditionalHolidayList);
            }
        }
        #endregion

        private void genWorkSchedule(EmployeeWorkSchedule value, WorkScheduleInfo condition, YearMonth yearMonth)
        {
            int maxDaysOfMonth = yearMonth.DaysInMonth;
            WorkSchedule workSchedule;
            for (int i = 1; i <= maxDaysOfMonth; i++)
            {
                workSchedule = new WorkSchedule();
                workSchedule.WorkDate = value.ForYearMonth.GetDate(i);
                workSchedule.DayType = getWorkingdayType(workSchedule.WorkDate, condition.ObjHolidayCondition, condition.ObjTraditionalHoliday);
                workSchedule.AWorkingTime = getTimePeriod(condition.ObjWorkingTimeCondition.AWorkingTimeTable.AWorkingTime, workSchedule.WorkDate);
                workSchedule.ABreakTime = getBreakTimePeriod(condition.ObjWorkingTimeCondition.AWorkingTimeTable.ABreakTime, workSchedule.AWorkingTime, workSchedule.WorkDate);

                value.Add(workSchedule);
            }
            workSchedule = null;
        }

        private void genWorkSchedule(EmployeeWorkSchedule value, WorkScheduleInfo condition, int start, int end)
        {
            WorkSchedule workSchedule;
            for (int i = start; i <= end; i++)
            {
                workSchedule = value[i - 1];
                workSchedule.WorkDate = value.ForYearMonth.GetDate(i);
                workSchedule.DayType = getWorkingdayType(workSchedule.WorkDate, condition.ObjHolidayCondition, condition.ObjTraditionalHoliday);
                workSchedule.AWorkingTime = getTimePeriod(condition.ObjWorkingTimeCondition.AWorkingTimeTable.AWorkingTime, workSchedule.WorkDate);
                workSchedule.ABreakTime = getBreakTimePeriod(condition.ObjWorkingTimeCondition.AWorkingTimeTable.ABreakTime, workSchedule.AWorkingTime, workSchedule.WorkDate);
            }
            workSchedule = null;
        }

        private WorkScheduleInfo getHolidayConditionSpecific(WorkScheduleInfo value, Employee employee, YearMonth yearMonth)
        {
            HolidayConditionSpecific holidayConditionSpcific = dbHolidayConditionSpecific.GetHolidayConditionSpecific(employee);
            if (holidayConditionSpcific == null)
            {
                return value;
            }
            else
            {
                WorkScheduleInfo workScheduleInfo = new WorkScheduleInfo();
                workScheduleInfo.ObjWorkingTimeCondition = value.ObjWorkingTimeCondition;

                workScheduleInfo.ObjHolidayCondition = new HolidayCondition();
                workScheduleInfo.ObjHolidayCondition.ATraditionalHolidayPattern = holidayConditionSpcific.ATraditionalHolidayPattern;
                workScheduleInfo.ObjHolidayCondition.SaturdayBreak = holidayConditionSpcific.SaturdayBreak;
                workScheduleInfo.ObjHolidayCondition.SundayBreak = holidayConditionSpcific.SundayBreak;

                TraditionalHolidayList traditionalHolidayList = new TraditionalHolidayList(employee.Company);
                if (holidayConditionSpcific.ATraditionalHolidayPattern.Code.Trim() != "")
                {
                    traditionalHolidayList.ATraditionalHolidayPattern = workScheduleInfo.ObjHolidayCondition.ATraditionalHolidayPattern;
                    traditionalHolidayList.AYearMonth = yearMonth;
                    dbTraditionalHoliday.FillTraditionalHolidayList(ref traditionalHolidayList);
                }
                workScheduleInfo.ObjTraditionalHoliday = traditionalHolidayList;

                return workScheduleInfo;
            }
        }

        private bool fillWorkScheduleInfo(WorkScheduleInfo value, Employee employee)
        {
            bool result;

            WorkingTimeConditionSpecific workingTimeConditionSpecific = new WorkingTimeConditionSpecific();
            workingTimeConditionSpecific.AEmployee = employee;
            if (dbWorkingTimeConditionSpecific.FillWorkingTimeConditionSpecific(ref workingTimeConditionSpecific))
            {
                value.ForPositionType = employee.APosition.APositionType;
                value.ObjWorkingTimeTable = workingTimeConditionSpecific.AWorkingTimeTable;
                result = true;
            }
            else
            {
                result = false;
            }

            workingTimeConditionSpecific = null;
            return result;
        }

        private bool fillWorkScheduleInfo(WorkScheduleInfo value, ServiceStaff serviceStaff)
        {
            bool result;

            WorkingTimeConditionSpecific workingTimeConditionSpecific = new WorkingTimeConditionSpecific();
            workingTimeConditionSpecific.AEmployee = serviceStaff;
            if (dbWorkingTimeConditionSpecific.FillWorkingTimeConditionSpecific(ref workingTimeConditionSpecific))
            {
                value.ForPositionType = serviceStaff.AServiceStaffType.APosition.APositionType;
                value.ObjWorkingTimeTable = workingTimeConditionSpecific.AWorkingTimeTable;
                result = true;
            }
            else
            {
                result = false;
            }

            workingTimeConditionSpecific = null;
            return result;
        }

        private void genOfficeWorkSchedule(EmployeeWorkSchedule value)
        {
            WorkScheduleInfo workScheduleInfo = new WorkScheduleInfo();
            if (fillWorkScheduleInfo(workScheduleInfo, value.Employee))
            {
                workScheduleInfo.ObjHolidayCondition = defaultOfficeWorkScheduleInfo.ObjHolidayCondition;
                workScheduleInfo.ObjTraditionalHoliday = defaultOfficeWorkScheduleInfo.ObjTraditionalHoliday;
            }
            else
            {
                workScheduleInfo = defaultOfficeWorkScheduleInfo;
            }
            workScheduleInfo = getHolidayConditionSpecific(workScheduleInfo, value.Employee, value.ForYearMonth);
            genWorkSchedule(value, workScheduleInfo, value.ForYearMonth);
            workScheduleInfo = null;
        }

        private void genServiceStaffWorkSchedule(EmployeeWorkSchedule value)
        {
            ServiceStaffDB dbServiceStaff = new ServiceStaffDB();
            ServiceStaff serviceStaff = (ServiceStaff)dbServiceStaff.GetAllStaff(value.Employee.EmployeeNo, value.Company);

            serviceStaff.AServiceStaffType.Type = value.Employee.APosition.PositionCode + "Z";
            WorkScheduleInfo workScheduleInfo = getWorkScheduleInfo(serviceStaff.APosition.APositionType, serviceStaff.AServiceStaffType, dummyCustomer, dummyCustomerDepartment, value.Company, value.ForYearMonth);
            workScheduleInfo = getHolidayConditionSpecific(workScheduleInfo, value.Employee, value.ForYearMonth);
            genWorkSchedule(value, workScheduleInfo, value.ForYearMonth);

            if (fillWorkScheduleInfo(workScheduleInfo, value.Employee))
            {
                int start = 1;
                int end = value.ForYearMonth.DaysInMonth;
                genWorkSchedule(value, workScheduleInfo, start, end);
            }
            else
            {
                ServiceStaffAssignmentList serviceStaffAssignmentList = new ServiceStaffAssignmentList(serviceStaff, serviceStaff.Company);
                ServiceStaffAssignment serviceStaffAssignment;
                if (dbServiceStaffAssignment.FillServiceStaffAssignmentInYearmonth(ref serviceStaffAssignmentList, value.ForYearMonth))
                {
                    ServiceStaffContractDB dbServiceStaffContract = new ServiceStaffContractDB();
                    for (int i = 0; i < serviceStaffAssignmentList.Count; i++)
                    {
                        serviceStaffAssignment = serviceStaffAssignmentList[i];
                        ServiceStaffType serviceStaffType = dbServiceStaffContract.GetServiceStaffType(serviceStaffAssignment.AContract, serviceStaffAssignmentList.Company);

                        ConditionClass condition = new ConditionClass();
                        condition.ObjCustomer = new Customer(serviceStaffAssignment.AContract.ACustomer.Code);
                        condition.ObjCustomerDepartment = new CustomerDepartment();
                        condition.ObjCustomerDepartment.Code = serviceStaffAssignment.AContract.ACustomerDepartment.Code;
                        condition.ObjCustomerDepartment.ACustomer = condition.ObjCustomer;
                        condition.ObjPositionType = new PositionType();
                        condition.ObjPositionType.Type = serviceStaff.APosition.APositionType.Type;
                        condition.ObjServiceStaffType = serviceStaffType;

                        workScheduleInfo.ObjWorkingTimeCondition = getWorkingTimeCondition(condition, value.Employee.Company);

                        condition.ObjCustomer = new Customer(serviceStaffAssignment.AContract.ACustomer.Code);
                        condition.ObjCustomerDepartment = new CustomerDepartment();
                        condition.ObjCustomerDepartment.Code = serviceStaffAssignment.AContract.ACustomerDepartment.Code;
                        condition.ObjCustomerDepartment.ACustomer = condition.ObjCustomer;
                        condition.ObjPositionType = new PositionType();
                        condition.ObjPositionType.Type = serviceStaff.APosition.APositionType.Type;
                        condition.ObjServiceStaffType = serviceStaffType;

                        ConditionClass assignmentCondition = new ConditionClass();
                        assignmentCondition.ObjPositionType = serviceStaff.APosition.APositionType;
                        assignmentCondition.ObjServiceStaffType = serviceStaffType;
                        assignmentCondition.ObjCustomer = serviceStaffAssignment.AContract.ACustomer;
                        assignmentCondition.ObjCustomerDepartment = serviceStaffAssignment.AContract.ACustomerDepartment;

                        workScheduleInfo = getWorkScheduleInfo(assignmentCondition.ObjPositionType, serviceStaffType, assignmentCondition.ObjCustomer, assignmentCondition.ObjCustomerDepartment, value.Company, value.ForYearMonth);
                        workScheduleInfo = getHolidayConditionSpecific(workScheduleInfo, value.Employee, value.ForYearMonth);

                        int start = 1;
                        if (value.ForYearMonth.GetDate(start) < serviceStaffAssignmentList[i].APeriod.From)
                        {
                            start = serviceStaffAssignmentList[i].APeriod.From.Day;
                        }

                        int end = value.ForYearMonth.DaysInMonth;
                        if (value.ForYearMonth.GetDate(end) > serviceStaffAssignmentList[i].APeriod.To)
                        {
                            end = serviceStaffAssignmentList[i].APeriod.To.Day;
                        }
                        genWorkSchedule(value, workScheduleInfo, start, end);
                    }
                }
                serviceStaffAssignmentList = null;
            }
            workScheduleInfo = null;
            serviceStaff = null;
        }

        private void genServiceStaffWorkSchedule(EmployeeWorkSchedule empWorkSchedule, ServiceStaff serviceStaff)
        {
            ServiceStaffType tempServiceStaffType = new ServiceStaffType(serviceStaff.AServiceStaffType.APosition.PositionCode + "Z");

            WorkScheduleInfo workScheduleInfo = getWorkScheduleInfo(serviceStaff.AServiceStaffType.APosition.APositionType, tempServiceStaffType, dummyCustomer, dummyCustomerDepartment, empWorkSchedule.Company, empWorkSchedule.ForYearMonth);
            workScheduleInfo = getHolidayConditionSpecific(workScheduleInfo, empWorkSchedule.Employee, empWorkSchedule.ForYearMonth);
            genWorkSchedule(empWorkSchedule, workScheduleInfo, empWorkSchedule.ForYearMonth);

            if (fillWorkScheduleInfo(workScheduleInfo, serviceStaff))
            {
                int start = 1;
                int end = empWorkSchedule.ForYearMonth.DaysInMonth;
                genWorkSchedule(empWorkSchedule, workScheduleInfo, start, end);
            }
            else
            {
                ServiceStaffAssignmentList serviceStaffAssignmentList = new ServiceStaffAssignmentList(serviceStaff, serviceStaff.Company);
                ServiceStaffAssignment serviceStaffAssignment;
                if (dbServiceStaffAssignment.FillServiceStaffAssignmentInYearmonth(ref serviceStaffAssignmentList, empWorkSchedule.ForYearMonth))
                {
                    ServiceStaffContractDB dbServiceStaffContract = new ServiceStaffContractDB();
                    for (int i = 0; i < serviceStaffAssignmentList.Count; i++)
                    {
                        serviceStaffAssignment = serviceStaffAssignmentList[i];
                        ServiceStaffType serviceStaffType = dbServiceStaffContract.GetServiceStaffType(serviceStaffAssignment.AContract, serviceStaffAssignmentList.Company);

                        ConditionClass condition = new ConditionClass();
                        condition.ObjCustomer = new Customer(serviceStaffAssignment.AContract.ACustomer.Code);
                        condition.ObjCustomerDepartment = new CustomerDepartment();
                        condition.ObjCustomerDepartment.Code = serviceStaffAssignment.AContract.ACustomerDepartment.Code;
                        condition.ObjCustomerDepartment.ACustomer = condition.ObjCustomer;
                        condition.ObjPositionType = new PositionType();
                        condition.ObjPositionType.Type = serviceStaff.APosition.APositionType.Type;
                        condition.ObjServiceStaffType = serviceStaffType;

                        workScheduleInfo.ObjWorkingTimeCondition = getWorkingTimeCondition(condition, empWorkSchedule.Employee.Company);

                        condition.ObjCustomer = new Customer(serviceStaffAssignment.AContract.ACustomer.Code);
                        condition.ObjCustomerDepartment = new CustomerDepartment();
                        condition.ObjCustomerDepartment.Code = serviceStaffAssignment.AContract.ACustomerDepartment.Code;
                        condition.ObjCustomerDepartment.ACustomer = condition.ObjCustomer;
                        condition.ObjPositionType = new PositionType();
                        condition.ObjPositionType.Type = serviceStaff.APosition.APositionType.Type;
                        condition.ObjServiceStaffType = serviceStaffType;

                        ConditionClass assignmentCondition = new ConditionClass();
                        assignmentCondition.ObjPositionType = serviceStaff.APosition.APositionType;
                        assignmentCondition.ObjServiceStaffType = serviceStaffType;
                        assignmentCondition.ObjCustomer = serviceStaffAssignment.AContract.ACustomer;
                        assignmentCondition.ObjCustomerDepartment = serviceStaffAssignment.AContract.ACustomerDepartment;

                        workScheduleInfo = getWorkScheduleInfo(assignmentCondition.ObjPositionType, serviceStaffType, assignmentCondition.ObjCustomer, assignmentCondition.ObjCustomerDepartment, empWorkSchedule.Company, empWorkSchedule.ForYearMonth);
                        workScheduleInfo = getHolidayConditionSpecific(workScheduleInfo, empWorkSchedule.Employee, empWorkSchedule.ForYearMonth);

                        int start = 1;
                        if (empWorkSchedule.ForYearMonth.GetDate(start) < serviceStaffAssignmentList[i].APeriod.From)
                        {
                            start = serviceStaffAssignmentList[i].APeriod.From.Day;
                        }

                        int end = empWorkSchedule.ForYearMonth.DaysInMonth;
                        if (empWorkSchedule.ForYearMonth.GetDate(end) > serviceStaffAssignmentList[i].APeriod.To)
                        {
                            end = serviceStaffAssignmentList[i].APeriod.To.Day;
                        }
                        genWorkSchedule(empWorkSchedule, workScheduleInfo, start, end);
                    }
                }
                serviceStaffAssignmentList = null;
            }
            workScheduleInfo = null;
            serviceStaff = null;
        }

        private bool insertWorkSchedule(EmployeeWorkScheduleList value, TableAccess tableAccess)
        {
            bool result = true;
            dbEmployeeWorkSchedule.TableAccess = tableAccess;
            for (int i = 0; i < value.Count; i++)
            {
                dbEmployeeWorkSchedule.DeleteWorkSchedule(value[i].Employee, value[i].ForYearMonth);
                if (!dbEmployeeWorkSchedule.InsertWorkSchedule(value[i]))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
        #endregion

        #region Public Method
        public EmployeeWorkSchedule GenWorkSchedule(Employee value, YearMonth forYearMonth)
        {
            initDefault(forYearMonth, value.Company);

            EmployeeWorkSchedule employeeWorkSchedule = new EmployeeWorkSchedule(value, forYearMonth);
            if (value.APosition.APositionType.Type == "O")
            {
                genOfficeWorkSchedule(employeeWorkSchedule);
            }
            else
            {
                genServiceStaffWorkSchedule(employeeWorkSchedule);
            }

            return employeeWorkSchedule;
        }

        public EmployeeWorkSchedule GenWorkSchedule(ServiceStaff serviceStaff, YearMonth forYearMonth)
        {
            initDefault(forYearMonth, serviceStaff.Company);

            EmployeeWorkSchedule employeeWorkSchedule = new EmployeeWorkSchedule(serviceStaff, forYearMonth);

            if (serviceStaff.AServiceStaffType.APosition.APositionType.Type == "O")
            {
                genOfficeWorkSchedule(employeeWorkSchedule);
            }
            else
            {
                genServiceStaffWorkSchedule(employeeWorkSchedule, serviceStaff);
            }

            return employeeWorkSchedule;
        }

        public bool CheckHoliday(Employee employee, DateTime date)
        {
            EmployeeWorkSchedule employeeWorkSchedule = GenWorkSchedule(employee, new YearMonth(date));
            if (employeeWorkSchedule.Contain(date.ToShortDateString()))
            {
                if (employeeWorkSchedule[date.ToShortDateString()].DayType == WORKINGDAY_TYPE.HOLIDAY)
                {
                    employeeWorkSchedule = null;
                    return true;
                }
            }
            employeeWorkSchedule = null;
            return false;
        }

        public override bool InsertWorkSchedule(CompanyStuffBase value, TableAccess tableAccess)
        {
            return insertWorkSchedule((EmployeeWorkScheduleList)value, tableAccess);
        }

        public override CompanyStuffBase CreateWorkSchedule(EmployeeList value, YearMonth yearMonth)
        {
            initDefault(yearMonth, value.Company);

            EmployeeWorkScheduleList employeeWorkScheduleList = new EmployeeWorkScheduleList(value.Company);
            EmployeeWorkSchedule employeeWorkSchedule;
            for (int i = 0; i < value.Count; i++)
            {
                employeeWorkSchedule = new EmployeeWorkSchedule(value[i], yearMonth);
                if (value[i].APosition.APositionType.Type == "O")
                {
                    genOfficeWorkSchedule(employeeWorkSchedule);
                }
                else
                {
                    genServiceStaffWorkSchedule(employeeWorkSchedule);
                }
                employeeWorkScheduleList.Add(employeeWorkSchedule);
            }

            employeeWorkSchedule = null;

            return employeeWorkScheduleList;
        }
        #endregion
    }
}