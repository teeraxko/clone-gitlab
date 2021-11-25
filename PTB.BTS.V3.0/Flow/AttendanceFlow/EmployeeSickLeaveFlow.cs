using System;
using System.Data.SqlClient;

using Entity.AttendanceEntities;
using Entity.CommonEntity;

using ictus.Common.Entity.Time;
using ictus.PIS.PI.Entity;

using DataAccess.AttendanceDB;
using DataAccess.CommonDB;

using PTB.BTS.Common.Flow;

namespace Flow.AttendanceFlow
{
	public class EmployeeSickLeaveFlow : FlowBase
	{
		#region - Private -
		private EmployeeSickLeaveDB dbEmployeeSickLeave;
		private DiseaseDB dbDisease;
		private EmployeeTimeCardDB dbEmployeeTimeCard;
		private EmployeeLeaveFlow flowEmployeeLeave;
		#endregion - Private -

		//		============================== Constructor ==============================
		public EmployeeSickLeaveFlow() : base()
		{
			dbEmployeeSickLeave = new EmployeeSickLeaveDB();
			dbDisease = new DiseaseDB();
			dbEmployeeTimeCard = new EmployeeTimeCardDB();
			flowEmployeeLeave = new EmployeeLeaveFlow();
		}

		//		============================== Private Method ==============================
		public TimeCard GetLeaveTimecard(SickLeave value, Employee aEmployee)
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
			attendanceStatus.Code = "S1";

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
		public SickLeave GetSickLeave(DateTime forDate, Employee aEmployee)
		{
			return dbEmployeeSickLeave.GetSickLeave(forDate, aEmployee);
		}

		public bool FillEmployeeSickLeave(ref EmployeeSickLeave value)
		{
			return dbEmployeeSickLeave.FillEmployeeSickLeave(ref value);
		}

		public bool FillEmployeeSickLeaveYear(ref EmployeeSickLeave value)
		{
            //if (value.AYearMonth.Year == 2007)
            //{
            //    return dbEmployeeSickLeave.FillEmployeeSickLeaveYear(ref value, value.AYearMonth.Year);
            //}
            //else
            //{
                if (value.AYearMonth.Month >= 4)
                {
                    return dbEmployeeSickLeave.FillEmployeeSickLeaveYear(ref value, value.AYearMonth.Year);
                }
                else
                {
                    return dbEmployeeSickLeave.FillEmployeeSickLeaveYear(ref value, value.AYearMonth.Year - 1);
                }
            //}			
		}

		public bool InsertSickLeave(SickLeave value, TimeCard aTimeCard, Employee aEmployee)
		{
			bool result = true;
			TableAccess tableAccess = new TableAccess();	
			
			try
			{
				tableAccess.OpenTransaction();
				dbEmployeeSickLeave.TableAccess = tableAccess;
				dbDisease.TableAccess = tableAccess;
				dbEmployeeTimeCard.TableAccess = tableAccess;

				result &= dbDisease.UpdateMTB(value.ADisease);
				result &= dbEmployeeSickLeave.InsertSickLeave(value, aEmployee);				

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

		public bool UpdateSickLeave(SickLeave value, TimeCard aTimeCard, Employee aEmployee)
		{
			bool result = true;
			TableAccess tableAccess = new TableAccess();
			
			try
			{
				tableAccess.OpenTransaction();
				dbEmployeeSickLeave.TableAccess = tableAccess;
				dbDisease.TableAccess = tableAccess;
				dbEmployeeTimeCard.TableAccess = tableAccess;

				result &= dbDisease.UpdateMTB(value.ADisease);
				result &= dbEmployeeSickLeave.UpdateSickLeave(value, aEmployee);	
			
				flowEmployeeLeave.SetUpdateLeaveTimeCard(ref aTimeCard, value.PeriodStatus, "S1");

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
		
		public bool DeleteSickLeave(SickLeave value, Employee aEmployee)
		{
			bool result = true;
			TableAccess tableAccess = new TableAccess();	
			TimeCard timeCard;
			
			try
			{
				timeCard = new TimeCard();
				timeCard = flowEmployeeLeave.GetDeleteLeaveTimeCard(value.LeaveDate, value.PeriodStatus, aEmployee);

				tableAccess.OpenTransaction();
				dbEmployeeSickLeave.TableAccess = tableAccess;
				dbEmployeeTimeCard.TableAccess = tableAccess;

				result &= dbEmployeeSickLeave.DeleteSickLeave(value, aEmployee);				

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