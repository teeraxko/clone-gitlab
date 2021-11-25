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
	public class EmployeeSpecialLeaveFlow : FlowBase
	{
		#region - Private -
		private EmployeeSpecialLeaveDB dbEmployeeSpecialLeave;
		private EmployeeTimeCardDB dbEmployeeTimeCard;
		private EmployeeLeaveFlow flowEmployeeLeave;
		#endregion - Private -

//		============================== Constructor ==============================
		public EmployeeSpecialLeaveFlow() : base()
		{
			dbEmployeeSpecialLeave = new EmployeeSpecialLeaveDB();
			dbEmployeeTimeCard = new EmployeeTimeCardDB();
			flowEmployeeLeave = new EmployeeLeaveFlow();
		}

//		============================== Private Method ==============================
		public TimeCard GetLeaveTimecard(SpecialLeave value, Employee aEmployee)
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
			attendanceStatus.Code = "S2";

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
		public SpecialLeave GetSpecialLeave(DateTime forDate, Employee aEmployee)
		{
			return dbEmployeeSpecialLeave.GetSpecialLeave(forDate, aEmployee);
		}

		public bool FillEmployeeSpecialLeave(ref EmployeeSpecialLeave value)
		{
			return dbEmployeeSpecialLeave.FillEmployeeSpecialLeave(ref value);
		}

		public bool FillEmployeeSpecialLeaveYear(ref EmployeeSpecialLeave value)
		{
			return dbEmployeeSpecialLeave.FillEmployeeSpecialLeaveYear(ref value);
		}

        public bool FillAllEmployeeSpecialLeaveYear(EmployeeSpecialLeave list)
        {
            return dbEmployeeSpecialLeave.FillAllEmployeeSpecialLeave(list);
        }

		public bool InsertSpecialLeave(SpecialLeave value, TimeCard aTimeCard, Employee aEmployee)
		{
			bool result = true;
			TableAccess tableAccess = new TableAccess();	
			
			try
			{
				tableAccess.OpenTransaction();
				dbEmployeeSpecialLeave.TableAccess = tableAccess;
				dbEmployeeTimeCard.TableAccess = tableAccess;

				result &= dbEmployeeSpecialLeave.InsertSpecialLeave(value, aEmployee);

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

		public bool UpdateSpecialLeave(SpecialLeave value, TimeCard aTimeCard, Employee aEmployee)
		{
			bool result = true;
			TableAccess tableAccess = new TableAccess();	
			
			try
			{
				tableAccess.OpenTransaction();
				dbEmployeeSpecialLeave.TableAccess = tableAccess;
				dbEmployeeTimeCard.TableAccess = tableAccess;

				result &= dbEmployeeSpecialLeave.UpdateSpecialLeave(value, aEmployee);

				flowEmployeeLeave.SetUpdateLeaveTimeCard(ref aTimeCard, value.PeriodStatus, "S2");

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
		
		public bool DeleteSpecialLeave(SpecialLeave value, Employee aEmployee)
		{
			bool result = true;
			TableAccess tableAccess = new TableAccess();	
			TimeCard timeCard;
			
			try
			{
				timeCard = new TimeCard();
				timeCard = flowEmployeeLeave.GetDeleteLeaveTimeCard(value.LeaveDate, value.PeriodStatus, aEmployee);

				tableAccess.OpenTransaction();
				dbEmployeeSpecialLeave.TableAccess = tableAccess;
				dbEmployeeTimeCard.TableAccess = tableAccess;

				result &= dbEmployeeSpecialLeave.DeleteSpecialLeave(value, aEmployee);				

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
