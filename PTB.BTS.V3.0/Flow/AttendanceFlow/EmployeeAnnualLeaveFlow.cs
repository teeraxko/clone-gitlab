using System;

using Entity.AttendanceEntities;
using Entity.CommonEntity;

using ictus.Common.Entity.Time;
using ictus.PIS.PI.Entity;

using DataAccess.AttendanceDB;

using PTB.BTS.Common.Flow;

using SystemFramework.AppException;
using System.Data.SqlClient;

namespace Flow.AttendanceFlow
{
    public class EmployeeAnnualLeaveFlow : FlowBase
    {
        #region - Private -
        private AnnualLeaveControlDB dbAnnualLeaveControl;
        private EmployeeAnnualLeaveHeadDB dbEmployeeAnnualLeaveHead;
        private EmployeeAnnualLeaveDetailDB dbEmployeeAnnualLeaveDetail;
        private EmployeeWorkScheduleDB dbEmployeeWorkSchedule;
        private EmployeeTimeCardDB dbEmployeeTimeCard;
        #endregion

        //==============================  Constructor  ==============================
        public EmployeeAnnualLeaveFlow()
            : base()
        {
            dbAnnualLeaveControl = new AnnualLeaveControlDB();
            dbEmployeeAnnualLeaveHead = new EmployeeAnnualLeaveHeadDB();
            dbEmployeeAnnualLeaveDetail = new EmployeeAnnualLeaveDetailDB();
            dbEmployeeWorkSchedule = new EmployeeWorkScheduleDB();
            dbEmployeeTimeCard = new EmployeeTimeCardDB();
        }

        #region - Private Method -
        #region - Other -
        private AnnualLeaveYear getAnnualLeaveYear(int forYear, Employee employee)
        {
            AnnualLeaveControl annualLeaveControl = new AnnualLeaveControl(forYear);
            AnnualLeaveHead annualLeaveHead = new AnnualLeaveHead(employee, forYear);
            AnnualLeaveYear annualLeaveYear = new AnnualLeaveYear(annualLeaveControl, annualLeaveHead);
            annualLeaveHead.UseDays = 0;

            dbEmployeeAnnualLeaveDetail.FillEmployeeAnnualLeaveDetail(ref annualLeaveYear);

            if (!dbAnnualLeaveControl.FillAnnualLeaveControl(ref annualLeaveControl, employee.Company))
            {
                annualLeaveControl = null;
                return null;
            }

            if (!dbEmployeeAnnualLeaveHead.FillAnnualLeaveHead(ref annualLeaveHead))
            {
                annualLeaveHead = null;
                return null;
            }

            annualLeaveControl = null;
            annualLeaveHead = null;

            return annualLeaveYear;
        }
        #endregion

        #region - Create AnnualLeave -
        #region - Normal -
        private bool editAnnualLeaveDay(AnnualLeaveDay leaveDay, AnnualLeaveYear annualLeaveYear, AnnualLeaveHead annualLeaveHead)
        {
            string key = leaveDay.LeaveDate.ToShortDateString();

            switch (leaveDay.PeriodStatus)
            {
                case LEAVE_PERIOD_TYPE.AM:
                    {
                        if (annualLeaveYear[key].PeriodStatus == LEAVE_PERIOD_TYPE.PM)
                        {
                            leaveDay.PeriodStatus = LEAVE_PERIOD_TYPE.ONE_DAY;
                            annualLeaveHead.UseDays += 0.5m;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case LEAVE_PERIOD_TYPE.PM:
                    {
                        if (annualLeaveYear[key].PeriodStatus == LEAVE_PERIOD_TYPE.AM)
                        {
                            leaveDay.PeriodStatus = LEAVE_PERIOD_TYPE.ONE_DAY;
                            annualLeaveHead.UseDays += 0.5m;
                            annualLeaveYear[key] = leaveDay;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case LEAVE_PERIOD_TYPE.ONE_DAY:
                    {
                        LEAVE_PERIOD_TYPE periodStatusType = annualLeaveYear[key].PeriodStatus;
                        if (periodStatusType == LEAVE_PERIOD_TYPE.PM || periodStatusType == LEAVE_PERIOD_TYPE.AM)
                        {
                            annualLeaveYear[key] = leaveDay;
                            annualLeaveHead.UseDays -= 0.5m;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                default:
                    {
                        return false;
                    }
            }
        }

        private bool createAnnualLeave(AnnualLeaveDay leaveDay, AnnualLeaveYear annualLeaveYear, AnnualLeaveHead annualLeaveHead)
        {
            if (annualLeaveYear.Available(leaveDay) && annualLeaveHead.Remain(leaveDay))
            {
                if (annualLeaveYear.Contain(leaveDay.LeaveDate.ToShortDateString()))
                {
                    return editAnnualLeaveDay(leaveDay, annualLeaveYear, annualLeaveHead);
                }
                else
                {
                    annualLeaveYear.Add(leaveDay);
                    annualLeaveHead.UseDays += leaveDay.DaysUsed;
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region - Mix -
        private bool createAnnualLeaveMix(AnnualLeaveDay leaveDay, AnnualLeave annualLeave)
        {
            leaveDay.LeaveYearStatus = LEAVE_YEAR_STATUS_TYPE.PREVIOUS;
            if (createAnnualLeave(leaveDay, annualLeave.CurrentAnnualLeave, annualLeave.PreviousAnnualLeave.LeaveHead))
            {
                return true;
            }
            else
            {
                if (leaveDay.PeriodStatus == LEAVE_PERIOD_TYPE.ONE_DAY && annualLeave.PreviousAnnualLeave != null && annualLeave.PreviousAnnualLeave.LeaveHead.RemainDays > 0)
                {
                    AnnualLeaveDay amAnnualLeaveDay = leaveDay.Clone();
                    amAnnualLeaveDay.PeriodStatus = LEAVE_PERIOD_TYPE.AM;

                    AnnualLeaveDay pmAnnualLeaveDay = leaveDay.Clone();
                    pmAnnualLeaveDay.PeriodStatus = LEAVE_PERIOD_TYPE.PM;

                    leaveDay.LeaveYearStatus = LEAVE_YEAR_STATUS_TYPE.MIX;

                    if (annualLeave.CurrentAnnualLeave.Available(leaveDay) && annualLeave.PreviousAnnualLeave.Remain(amAnnualLeaveDay) && annualLeave.CurrentAnnualLeave.Remain(pmAnnualLeaveDay))
                    {
                        if (annualLeave.CurrentAnnualLeave.Contain(leaveDay.LeaveDate.ToShortDateString()))
                        {
                            return false;
                        }
                        else
                        {
                            annualLeave.CurrentAnnualLeave.Add(leaveDay);
                            annualLeave.PreviousAnnualLeave.LeaveHead.UseDays += 0.5m;
                            annualLeave.CurrentAnnualLeave.LeaveHead.UseDays += 0.5m;
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    leaveDay.LeaveYearStatus = LEAVE_YEAR_STATUS_TYPE.CURRENT;
                    return createAnnualLeave(leaveDay, annualLeave.CurrentAnnualLeave, annualLeave.CurrentAnnualLeave.LeaveHead);
                }
            }
        }
        #endregion

        private bool createAnnualLeave(AnnualLeaveDay leaveDay, AnnualLeave annualLeave)
        {
            switch (leaveDay.LeaveYearStatus)
            {
                case LEAVE_YEAR_STATUS_TYPE.CURRENT:
                    {
                        if (leaveDay.LeaveDate.Date >= annualLeave.CurrentAnnualLeave.LeaveControl.ValidPeriod.From.Date)
                        {
                            return createAnnualLeave(leaveDay, annualLeave.CurrentAnnualLeave, annualLeave.CurrentAnnualLeave.LeaveHead);
                        }
                        else
                        {
                            return createAnnualLeave(leaveDay, annualLeave.PreviousAnnualLeave, annualLeave.CurrentAnnualLeave.LeaveHead);
                        }
                    }
                case LEAVE_YEAR_STATUS_TYPE.PREVIOUS:
                    {
                        if (leaveDay.LeaveDate.Date > annualLeave.CurrentAnnualLeave.LeaveControl.ValidPeriod.From.Date)
                        {
                            return createAnnualLeave(leaveDay, annualLeave.CurrentAnnualLeave, annualLeave.PreviousAnnualLeave.LeaveHead);
                        }
                        else
                        {
                            return createAnnualLeave(leaveDay, annualLeave.PreviousAnnualLeave, annualLeave.PreviousAnnualLeave.LeaveHead);
                        }
                    }
                default:
                    {
                        return createAnnualLeaveMix(leaveDay, annualLeave);
                    }
            }
        }

        private bool createAnnualLeave(AnnualLeaveDayList value, AnnualLeave annualLeave)
        {
            for (int i = 0; i < value.Count; i++)
            {
                if (!createAnnualLeave(value[i], annualLeave))
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region - DB -
        private bool insertAnnualLeave(AnnualLeave value, AnnualLeaveDayList annualLeaveDayList, EmployeeTimeCard employeeTimeCard)
        {
            bool result = true;
            EmployeeAnnualLeaveHeadDB tdbEmployeeAnnualLeaveHead = new EmployeeAnnualLeaveHeadDB();
            EmployeeAnnualLeaveDetailDB tdbEmployeeAnnualLeaveDetail = new EmployeeAnnualLeaveDetailDB();
            LeaveReasonDB dbLeaveReason = new LeaveReasonDB();
            EmployeeTimeCardDB tdbEmployeeTimeCard = new EmployeeTimeCardDB();

            tdbEmployeeAnnualLeaveDetail.TableAccess = tdbEmployeeAnnualLeaveHead.TableAccess;
            dbLeaveReason.TableAccess = tdbEmployeeAnnualLeaveHead.TableAccess;
            tdbEmployeeTimeCard.TableAccess = tdbEmployeeAnnualLeaveHead.TableAccess;
            try
            {
                tdbEmployeeAnnualLeaveHead.TableAccess.OpenTransaction();

                result = result && tdbEmployeeAnnualLeaveDetail.InsertAnnualLeave(annualLeaveDayList);
                result = result && tdbEmployeeAnnualLeaveHead.UpdateEmployeeAnnualLeaveHead(value.CurrentAnnualLeave.LeaveHead);
                if (result && value.PreviousAnnualLeave != null)
                {
                    result = tdbEmployeeAnnualLeaveHead.UpdateEmployeeAnnualLeaveHead(value.PreviousAnnualLeave.LeaveHead);
                }

                result = result && dbLeaveReason.UpdateMTB(annualLeaveDayList[0].Reason);
                result = result && tdbEmployeeTimeCard.UpdateEmployeeTimeCard(employeeTimeCard);

                if (result)
                {
                    tdbEmployeeAnnualLeaveHead.TableAccess.Transaction.Commit();
                }
                else
                {
                    tdbEmployeeAnnualLeaveHead.TableAccess.Transaction.Rollback();
                }
            }
            catch (SqlException ex)
            {
                tdbEmployeeAnnualLeaveHead.TableAccess.Transaction.Rollback();
                throw ex;
            }
            catch (Exception ex)
            {
                tdbEmployeeAnnualLeaveHead.TableAccess.Transaction.Rollback();
                throw ex;
            }
            finally
            {
                tdbEmployeeAnnualLeaveHead.TableAccess.CloseConnection();
                tdbEmployeeAnnualLeaveHead = null;
                tdbEmployeeAnnualLeaveDetail = null;
                tdbEmployeeTimeCard = null;
            }

            return result;
        }

        private bool updateAnnualLeave(AnnualLeave value, AnnualLeaveDay annualLeaveDay, TimeCard timeCard)
        {
            bool result = true;
            EmployeeAnnualLeaveHeadDB tdbEmployeeAnnualLeaveHead = new EmployeeAnnualLeaveHeadDB();
            EmployeeAnnualLeaveDetailDB tdbEmployeeAnnualLeaveDetail = new EmployeeAnnualLeaveDetailDB();
            LeaveReasonDB dbLeaveReason = new LeaveReasonDB();
            EmployeeTimeCardDB tdbEmployeeTimeCard = new EmployeeTimeCardDB();

            tdbEmployeeAnnualLeaveDetail.TableAccess = tdbEmployeeAnnualLeaveHead.TableAccess;
            dbLeaveReason.TableAccess = tdbEmployeeAnnualLeaveHead.TableAccess;
            tdbEmployeeTimeCard.TableAccess = tdbEmployeeAnnualLeaveHead.TableAccess;
            try
            {
                tdbEmployeeAnnualLeaveHead.TableAccess.OpenTransaction();

                result = result && tdbEmployeeAnnualLeaveDetail.UpdateAnnualLeave(annualLeaveDay, value.Employee);
                result = result && tdbEmployeeAnnualLeaveHead.UpdateEmployeeAnnualLeaveHead(value.CurrentAnnualLeave.LeaveHead);
                if (result && value.PreviousAnnualLeave != null)
                {
                    result = tdbEmployeeAnnualLeaveHead.UpdateEmployeeAnnualLeaveHead(value.PreviousAnnualLeave.LeaveHead);
                }
                result = result && dbLeaveReason.UpdateMTB(annualLeaveDay.Reason);
                result = result && tdbEmployeeTimeCard.UpdateTimeCard(timeCard, value.Employee);

                if (result)
                {
                    tdbEmployeeAnnualLeaveHead.TableAccess.Transaction.Commit();
                }
                else
                {
                    tdbEmployeeAnnualLeaveHead.TableAccess.Transaction.Rollback();
                }
            }
            catch (SqlException ex)
            {
                tdbEmployeeAnnualLeaveHead.TableAccess.Transaction.Rollback();
                throw ex;
            }
            catch (Exception ex)
            {
                tdbEmployeeAnnualLeaveHead.TableAccess.Transaction.Rollback();
                throw ex;
            }
            finally
            {
                tdbEmployeeAnnualLeaveHead.TableAccess.CloseConnection();
                tdbEmployeeAnnualLeaveHead = null;
                tdbEmployeeAnnualLeaveDetail = null;
                tdbEmployeeTimeCard = null;
            }

            return result;
        }

        private bool deleteAnnualLeave(AnnualLeave value, AnnualLeaveDay annualLeaveDay, TimeCard timeCard)
        {
            bool result = true;
            EmployeeAnnualLeaveHeadDB tdbEmployeeAnnualLeaveHead = new EmployeeAnnualLeaveHeadDB();
            EmployeeAnnualLeaveDetailDB tdbEmployeeAnnualLeaveDetail = new EmployeeAnnualLeaveDetailDB();
            EmployeeTimeCardDB tdbEmployeeTimeCard = new EmployeeTimeCardDB();

            tdbEmployeeAnnualLeaveDetail.TableAccess = tdbEmployeeAnnualLeaveHead.TableAccess;
            tdbEmployeeTimeCard.TableAccess = tdbEmployeeAnnualLeaveHead.TableAccess;
            try
            {
                tdbEmployeeAnnualLeaveHead.TableAccess.OpenTransaction();

                result = result && tdbEmployeeAnnualLeaveDetail.DeleteAnnualLeave(annualLeaveDay, value.Employee);
                result = result && tdbEmployeeAnnualLeaveHead.UpdateEmployeeAnnualLeaveHead(value.CurrentAnnualLeave.LeaveHead);
                if (result && value.PreviousAnnualLeave != null)
                {
                    result = tdbEmployeeAnnualLeaveHead.UpdateEmployeeAnnualLeaveHead(value.PreviousAnnualLeave.LeaveHead);
                }
                result = result && tdbEmployeeTimeCard.UpdateTimeCard(timeCard, value.Employee);

                if (result)
                {
                    tdbEmployeeAnnualLeaveHead.TableAccess.Transaction.Commit();
                }
                else
                {
                    tdbEmployeeAnnualLeaveHead.TableAccess.Transaction.Rollback();
                }
            }
            catch (SqlException ex)
            {
                tdbEmployeeAnnualLeaveHead.TableAccess.Transaction.Rollback();
                throw ex;
            }
            catch (Exception ex)
            {
                tdbEmployeeAnnualLeaveHead.TableAccess.Transaction.Rollback();
                throw ex;
            }
            finally
            {
                tdbEmployeeAnnualLeaveHead.TableAccess.CloseConnection();
                tdbEmployeeAnnualLeaveHead = null;
                tdbEmployeeAnnualLeaveDetail = null;
                tdbEmployeeTimeCard = null;
            }

            return result;
        }
        #endregion
        #endregion

        private bool isLeave(AttendanceStatus value)
        {
            return value.Code == "S1" || value.Code == "S2" || value.Code == "P1";
        }

        private AnnualLeaveDay removeAnnualLeaveDay(string key, AnnualLeave annualLeave)
        {
            AnnualLeaveDay annualLeaveDay;
            if (annualLeave.CurrentAnnualLeave.Contain(key))
            {
                annualLeaveDay = annualLeave.CurrentAnnualLeave[key];
                annualLeave.CurrentAnnualLeave.Remove(key);
            }
            else
            {
                annualLeaveDay = annualLeave.PreviousAnnualLeave[key];
                annualLeave.PreviousAnnualLeave.Remove(key);
            }

            switch (annualLeaveDay.LeaveYearStatus)
            {
                case LEAVE_YEAR_STATUS_TYPE.CURRENT:
                    {
                        annualLeave.CurrentAnnualLeave.LeaveHead.UseDays -= annualLeaveDay.DaysUsed;
                        break;
                    }
                case LEAVE_YEAR_STATUS_TYPE.PREVIOUS:
                    {
                        annualLeave.PreviousAnnualLeave.LeaveHead.UseDays -= annualLeaveDay.DaysUsed;
                        break;
                    }
                default:
                    {
                        annualLeave.CurrentAnnualLeave.LeaveHead.UseDays -= 0.5m;
                        annualLeave.PreviousAnnualLeave.LeaveHead.UseDays -= 0.5m;
                        break;
                    }
            }
            return annualLeaveDay;
        }

        //============================== Public Method ==============================
        public bool IsHoliday(Employee employee, DateTime leaveDate)
        {
            EmployeeWorkSchedule employeeWorkSchedule = new EmployeeWorkSchedule(employee, leaveDate);
            if (dbEmployeeWorkSchedule.FillWorkScheduleList(ref employeeWorkSchedule))
            {
                if (employeeWorkSchedule[leaveDate.ToShortDateString()].DayType == WORKINGDAY_TYPE.HOLIDAY)
                {
                    employeeWorkSchedule = null;
                    return true;
                }
            }
            employeeWorkSchedule = null;
            return false;
        }

        public bool IsLeave(Employee employee, DateTime leaveDate, LEAVE_PERIOD_TYPE period)
        {
            TimeCard timeCard = dbEmployeeTimeCard.GetTimeCard(leaveDate, employee);
            if (timeCard == null)
            {
                throw new NotFoundException("ตารางเวลาทำงานของพนักงาน", "Employee AnnualLeaveFlow");
            }
            else
            {
                switch (period)
                {
                    case LEAVE_PERIOD_TYPE.AM:
                        {
                            if (isLeave(timeCard.ABeforeBreakStatus))
                            {
                                timeCard = null;
                                return true;
                            }
                            break;
                        }
                    case LEAVE_PERIOD_TYPE.PM:
                        {
                            if (isLeave(timeCard.AAfterBreakStatus))
                            {
                                timeCard = null;
                                return true;
                            }
                            break;
                        }
                    default:
                        {
                            if (isLeave(timeCard.ABeforeBreakStatus) || isLeave(timeCard.AAfterBreakStatus))
                            {
                                timeCard = null;
                                return true;
                            }
                            break;
                        }
                }
            }

            timeCard = null;
            return false;
        }

        public bool FillEmployeeAnnualLeave(AnnualLeave value, YearMonth yearMonth, Employee employee)
        {
            int forYear = yearMonth.Year;

            if (yearMonth.Year >= 2008 && yearMonth.Month <= 3)
            {
                forYear = yearMonth.Year - 1;
            }

            #region Comment code : woranai
            //AnnualLeaveControl annualControl = null;

            //annualControl = dbAnnualLeaveControl.GetAnnualLeaveControl(yearMonth.Year, employee.Company);

            //if (annualControl != null)
            //{
            //    if (annualControl.ValidPeriod.From.Date > yearMonth.MaxDateOfMonth.Date)
            //    {
            //        forYear = yearMonth.Year - 1;
            //    }
            //    else
            //    {
            //        forYear = yearMonth.Year;
            //    }
            //}
            //else
            //{
            //    annualControl = dbAnnualLeaveControl.GetAnnualLeaveControl(yearMonth.Year - 1, employee.Company);

            //    if (annualControl != null)
            //    {
            //        if (annualControl.ValidPeriod.From.AddYears(1).Date > yearMonth.MaxDateOfMonth)
            //        {
            //            forYear = yearMonth.Year - 1;
            //        }
            //        else
            //        {
            //            return false;
            //        }
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}

            //annualControl = null; 
            #endregion

            value.CurrentAnnualLeave = getAnnualLeaveYear(forYear, employee);
            if (value.CurrentAnnualLeave == null)
            {
                return false;
            }

            value.PreviousAnnualLeave = getAnnualLeaveYear(forYear - 1, employee);

            if (value.PreviousAnnualLeave != null)
            {
                AnnualLeaveControl annualLeaveControl = value.PreviousAnnualLeave.LeaveControl;
                if (annualLeaveControl.ValidPeriod.To < yearMonth.MinDateOfMonth)
                {
                    value.PreviousAnnualLeave = null;                
                }

                //Validate carry over annual leave for driver : woranai 2008/04/22
                if (employee.APosition.APositionRole == POSITION_ROLE_TYPE.DRIVER && value.CurrentAnnualLeave.LeaveControl.ValidPeriod.From <= yearMonth.MinDateOfMonth)
                {
                    value.PreviousAnnualLeave = null;                
                }

                annualLeaveControl = null;
            }

            return value.Existing;
        }

        private TimeCard getLeaveTimeCard(AnnualLeaveDay value, TimeCard timeCard)
        {
            switch (value.PeriodStatus)
            {
                case LEAVE_PERIOD_TYPE.AM:
                    {
                        timeCard.ABeforeBreakStatus.Code = "A1";
                        break;
                    }
                case LEAVE_PERIOD_TYPE.PM:
                    {
                        timeCard.AAfterBreakStatus.Code = "A1";
                        break;
                    }
                default:
                    {
                        timeCard.ABeforeBreakStatus.Code = "A1";
                        timeCard.AAfterBreakStatus.Code = "A1";
                        break;
                    }
            }
            return timeCard;
        }

        private TimeCard getTimeCard(Employee employee, AnnualLeaveDay value)
        {
            GenerateEmployeeTimeCardFlow flowGenerateEmployeeTimeCard = new GenerateEmployeeTimeCardFlow();
            return flowGenerateEmployeeTimeCard.GetTimeCard(employee, value.LeaveDate);
        }

        private EmployeeTimeCard getEmployeeTimeCard(Employee employee, AnnualLeaveDayList value)
        {
            EmployeeTimeCard employeeTimeCard = new EmployeeTimeCard(employee);
            for (int i = 0; i < value.Count; i++)
            {
                employeeTimeCard.Add(getLeaveTimeCard(value[i], getTimeCard(employee, value[i])));
            }
            return employeeTimeCard;
        }

        public bool InsertAnnualLeave(AnnualLeaveDayList value, AnnualLeave annualLeave, YearMonth yearMonth)
        {
            bool result = true;

            result = result && createAnnualLeave(value, annualLeave);
            EmployeeTimeCard employeeTimeCard = getEmployeeTimeCard(annualLeave.Employee, value);
            if (employeeTimeCard.Count == 0)
            {
                result = false;
            }
            else
            {
                result = result && insertAnnualLeave(annualLeave, value, employeeTimeCard);
            }
            FillEmployeeAnnualLeave(annualLeave, yearMonth, annualLeave.Employee);

            return result;
        }

        public bool UpdateAnnualLeave(AnnualLeaveDay value, AnnualLeave annualLeave, YearMonth yearMonth)
        {
            bool result = true;

            TimeCard timeCard = getTimeCard(annualLeave.Employee, value);
            switch (value.PeriodStatus)
            {
                case LEAVE_PERIOD_TYPE.AM:
                    {
                        if (timeCard.AAfterBreakStatus.Code == "A1")
                        {
                            timeCard.AAfterBreakStatus.Code = "";
                        }
                        break;
                    }
                case LEAVE_PERIOD_TYPE.PM:
                    {
                        if (timeCard.ABeforeBreakStatus.Code == "A1")
                        {
                            timeCard.ABeforeBreakStatus.Code = "";
                        }
                        break;
                    }
            }

            timeCard = getLeaveTimeCard(value, timeCard);

            AnnualLeaveDay oldAnnualLeaveDay = removeAnnualLeaveDay(value.LeaveDate.ToShortDateString(), annualLeave);

            result = result && createAnnualLeave(value, annualLeave);
            result = result && updateAnnualLeave(annualLeave, value, timeCard);

            FillEmployeeAnnualLeave(annualLeave, yearMonth, annualLeave.Employee);

            return result;
        }

        public bool DeleteAnnualLeave(AnnualLeaveDay value, AnnualLeave annualLeave, YearMonth yearMonth)
        {
            bool result = true;

            TimeCard timeCard = getTimeCard(annualLeave.Employee, value);
            switch (value.PeriodStatus)
            {
                case LEAVE_PERIOD_TYPE.AM:
                    {
                        if (timeCard.ABeforeBreakStatus.Code == "A1")
                        {
                            timeCard.ABeforeBreakStatus.Code = "";
                        }
                        break;
                    }
                case LEAVE_PERIOD_TYPE.PM:
                    {
                        if (timeCard.AAfterBreakStatus.Code == "A1")
                        {
                            timeCard.AAfterBreakStatus.Code = "";
                        }
                        break;
                    }
                default:
                    {
                        if (timeCard.ABeforeBreakStatus.Code == "A1")
                        {
                            timeCard.ABeforeBreakStatus.Code = "";
                        }
                        if (timeCard.AAfterBreakStatus.Code == "A1")
                        {
                            timeCard.AAfterBreakStatus.Code = "";
                        }
                        break;
                    }
            }

            removeAnnualLeaveDay(value.LeaveDate.ToShortDateString(), annualLeave);
            result = result && deleteAnnualLeave(annualLeave, value, timeCard);

            FillEmployeeAnnualLeave(annualLeave, yearMonth, annualLeave.Employee);

            return result;
        }
    }
}