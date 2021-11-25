using System;
using System.Data.SqlClient;

using Entity.AttendanceEntities;
using Entity.CommonEntity;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;

using DataAccess.AttendanceDB;
using DataAccess.CommonDB;

using PTB.BTS.Common.Flow;

namespace Flow.AttendanceFlow
{
	public class EmployeePrivateLeaveFlow : FlowBase
	{
		#region - Private -
		private EmployeePrivateLeaveDB dbEmployeePrivateLeave;
		private LeaveReasonDB dbLeaveReason;
		private EmployeeTimeCardDB dbEmployeeTimeCard;
		private EmployeeLeaveFlow flowEmployeeLeave;
		#endregion - Private -

		//		============================== Constructor ==============================
		public EmployeePrivateLeaveFlow() : base()
		{
			dbEmployeePrivateLeave = new EmployeePrivateLeaveDB();
			dbLeaveReason = new LeaveReasonDB();
			dbEmployeeTimeCard = new EmployeeTimeCardDB();
			flowEmployeeLeave = new EmployeeLeaveFlow();
		}

		//		============================== Private Method ==============================
		public TimeCard GetLeaveTimecard(PrivateLeave value, Employee aEmployee)
		{	
			TimeCard timeCard = new TimeCard();
			GenerateEmployeeWorkScheduleFlow flowGenerateEmployeeWorkSchedule;
			GenerateEmployeeTimeCardFlow flowGenerateEmployeeTimeCard;
			EmployeeWorkSchedule employeeWorkSchedule;
			AttendanceStatus attendanceStatus;		
			WorkSchedule workSchedule;
			YearMonth yearMonth;

			timeCard = dbEmployeeTimeCard.GetTimeCard(value.LeaveDate, aEmployee);

			if(timeCard == null)
			{				
				flowGenerateEmployeeWorkSchedule = new GenerateEmployeeWorkScheduleFlow();
				flowGenerateEmployeeTimeCard = new GenerateEmployeeTimeCardFlow();
				employeeWorkSchedule = new EmployeeWorkSchedule(aEmployee);
				yearMonth = new YearMonth(value.LeaveDate);	
				workSchedule = new WorkSchedule();

				employeeWorkSchedule = flowGenerateEmployeeWorkSchedule.GenWorkSchedule(aEmployee, yearMonth);				
				timeCard = flowGenerateEmployeeTimeCard.GetTimeCard(employeeWorkSchedule[value.LeaveDate.ToShortDateString()]);
			}	

			attendanceStatus = new AttendanceStatus();
			attendanceStatus.Code = "P1";

			switch(value.PeriodStatus)
			{
				case LEAVE_PERIOD_TYPE.AM:
					timeCard.ABeforeBreakStatus = attendanceStatus;
					break;
				case LEAVE_PERIOD_TYPE.PM:
					timeCard.AAfterBreakStatus = attendanceStatus;
					break;
				case LEAVE_PERIOD_TYPE.ONE_DAY:
					timeCard.ABeforeBreakStatus = attendanceStatus;
					timeCard.AAfterBreakStatus = attendanceStatus;
					break;
			}

			flowGenerateEmployeeWorkSchedule = null;
			flowGenerateEmployeeTimeCard = null;
			employeeWorkSchedule = null;
			attendanceStatus = null;
			workSchedule = null;

			return timeCard;
		}

		//		============================== Public Method ==============================
		public PrivateLeave GetPrivateLeave(DateTime forDate, Employee aEmployee)
		{
			return dbEmployeePrivateLeave.GetPrivateLeave(forDate, aEmployee);
		}

		public bool FillEmployeePrivateLeave(ref EmployeePrivateLeave value)
		{
			return dbEmployeePrivateLeave.FillEmployeePrivateLeave(ref value);
		}

		public bool FillEmployeePrivateLeaveYear(ref EmployeePrivateLeave value)
		{
            //if (value.AYearMonth.Year == 2007)
            //{
            //    return dbEmployeePrivateLeave.FillEmployeePrivateLeaveYear(ref value, value.AYearMonth.Year);
            //}
            //else
            //{
                if (value.AYearMonth.Month >= 4)
                {
                    return dbEmployeePrivateLeave.FillEmployeePrivateLeaveYear(ref value, value.AYearMonth.Year);
                }
                else
                {
                    return dbEmployeePrivateLeave.FillEmployeePrivateLeaveYear(ref value, value.AYearMonth.Year - 1);
                }
            //}
		}

		public bool InsertPrivateLeave(PrivateLeave value, TimeCard aTimeCard, Employee aEmployee)
		{
			bool result = true;
			TableAccess tableAccess = new TableAccess();	
			
			try
			{
				tableAccess.OpenTransaction();
				dbEmployeePrivateLeave.TableAccess = tableAccess;
				dbLeaveReason.TableAccess = tableAccess;
				dbEmployeeTimeCard.TableAccess = tableAccess;

				result &= dbLeaveReason.UpdateMTB(value.ALeaveReason);
				result &= dbEmployeePrivateLeave.InsertPrivateLeave(value, aEmployee);				

				dbEmployeeTimeCard.DeleteTimeCard(aTimeCard, aEmployee);
				result &= dbEmployeeTimeCard.InsertTimeCard(aTimeCard, aEmployee);					

				if(result)
				{
					tableAccess.Transaction.Commit();
				}
				else
				{
					tableAccess.Transaction.Rollback();
				}
			}
			catch(SqlException ex)
			{
				tableAccess.Transaction.Rollback();
				throw ex;
			}
            catch (Exception ex)
            {
                tableAccess.Transaction.Rollback();
                throw ex;
            }
			finally
			{
				tableAccess.CloseConnection();
			}

			return result;
		}

		public bool UpdatePrivateLeave(PrivateLeave value, TimeCard aTimeCard, Employee aEmployee)
		{
			bool result = true;
			TableAccess tableAccess = new TableAccess();
			
			try
			{
				tableAccess.OpenTransaction();
				dbEmployeePrivateLeave.TableAccess = tableAccess;
				dbLeaveReason.TableAccess = tableAccess;
				dbEmployeeTimeCard.TableAccess = tableAccess;

				result &= dbLeaveReason.UpdateMTB(value.ALeaveReason);
				result &= dbEmployeePrivateLeave.UpdatePrivateLeave(value, aEmployee);

				flowEmployeeLeave.SetUpdateLeaveTimeCard(ref aTimeCard, value.PeriodStatus, "P1");

				dbEmployeeTimeCard.DeleteTimeCard(aTimeCard, aEmployee);
				result &= dbEmployeeTimeCard.InsertTimeCard(aTimeCard, aEmployee);
								
				if(result)
				{
					tableAccess.Transaction.Commit();
				}
				else
				{
					tableAccess.Transaction.Rollback();
				}
			}
			catch(SqlException ex)
			{
				tableAccess.Transaction.Rollback();
				throw ex;
			}
            catch (Exception ex)
            {
                tableAccess.Transaction.Rollback();
                throw ex;
            }
			finally
			{
				tableAccess.CloseConnection();
			}

			return result;
		}
		
		public bool DeletePrivateLeave(PrivateLeave value, Employee aEmployee)
		{
			bool result = true;
			TableAccess tableAccess = new TableAccess();	
			TimeCard timeCard;
			
			try
			{
				timeCard = new TimeCard();
				timeCard = flowEmployeeLeave.GetDeleteLeaveTimeCard(value.LeaveDate, value.PeriodStatus, aEmployee);

				tableAccess.OpenTransaction();
				dbEmployeePrivateLeave.TableAccess = tableAccess;
				dbEmployeeTimeCard.TableAccess = tableAccess;

				result &= dbEmployeePrivateLeave.DeletePrivateLeave(value, aEmployee);				

				if(timeCard != null)
				{
					result &= dbEmployeeTimeCard.UpdateTimeCard(timeCard, aEmployee);
				}		

				if(result)
				{
					tableAccess.Transaction.Commit();
				}
				else
				{
					tableAccess.Transaction.Rollback();
				}
			}
			catch(SqlException ex)
			{
				tableAccess.Transaction.Rollback();
				throw ex;
			}
            catch (Exception ex)
            {
                tableAccess.Transaction.Rollback();
                throw ex;
            }
			finally
			{
				tableAccess.CloseConnection();
			}

			return result;

		}
	}
}