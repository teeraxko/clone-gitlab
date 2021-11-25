using System;

using DataAccess.AttendanceDB;

using PTB.BTS.Common.Flow;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;

using Entity.ContractEntities;
using Entity.AttendanceEntities;
using Entity.CommonEntity;

namespace Flow.AttendanceFlow
{
	public class EmployeeLeaveFlow : FlowBase
	{
		#region - Private -	
		private GenerateEmployeeWorkScheduleFlow flowGenerateEmployeeWorkSchedule;
		private EmployeeTimeCardDB dbEmployeeTimeCard;
		private EmployeeWorkScheduleDB dbEmployeeWorkSchedule;
		#endregion
//		=========================== Constructor ================
		public EmployeeLeaveFlow() : base()
		{
			flowGenerateEmployeeWorkSchedule = new GenerateEmployeeWorkScheduleFlow();
			dbEmployeeTimeCard = new EmployeeTimeCardDB();
			dbEmployeeWorkSchedule = new EmployeeWorkScheduleDB();
		}

//		===========================Public Method ================
		public WorkSchedule GetLeaveWorkSchedule(DateTime forDate, Employee aEmployee)
		{
			WorkSchedule workSchedule = new WorkSchedule();
			
			EmployeeWorkSchedule employeeWorkSchedule;
			YearMonth yearMonth;

			workSchedule = dbEmployeeWorkSchedule.GetWorkSchedule(aEmployee, forDate);

			if(workSchedule == null)
			{				
				employeeWorkSchedule = new EmployeeWorkSchedule(aEmployee);
				yearMonth = new YearMonth(forDate);	

				employeeWorkSchedule = flowGenerateEmployeeWorkSchedule.GenWorkSchedule(aEmployee, yearMonth);				
				workSchedule = employeeWorkSchedule[forDate.ToShortDateString()];
			}
			employeeWorkSchedule = null;

			return workSchedule;
		}

		public bool GetCheckEmployeeWorkSchedule(TimePeriod timePeriod, Employee aEmployee)
		{
			bool result = false;
			YearMonth yearMonth;
			WorkSchedule workSchedule;
			EmployeeWorkSchedule employeeWorkSchedule;

			for(DateTime dateMonth = timePeriod.From; dateMonth <= timePeriod.To; dateMonth = dateMonth.AddMonths(1))
			{
				yearMonth = new YearMonth(dateMonth);
				employeeWorkSchedule = new EmployeeWorkSchedule(aEmployee, yearMonth);

				if(!dbEmployeeWorkSchedule.FillWorkScheduleList(ref employeeWorkSchedule))
				{
					employeeWorkSchedule = flowGenerateEmployeeWorkSchedule.GenWorkSchedule(aEmployee, yearMonth);	
				}				

				for(DateTime dateDay = timePeriod.From; dateDay <= timePeriod.To; dateDay = dateDay.AddDays(1))
				{
					if(dateDay.Month == employeeWorkSchedule.ForYearMonth.Month && dateDay.Year == employeeWorkSchedule.ForYearMonth.Year)
					{
						workSchedule = new WorkSchedule();
						workSchedule = employeeWorkSchedule[dateDay.ToShortDateString()];
						if(workSchedule.DayType == WORKINGDAY_TYPE.HOLIDAY)
						{
							result |= true;
						}
					}
				
				}				
			}
			workSchedule = null;
			employeeWorkSchedule = null;

			return result;
		}

		public void SetUpdateLeaveTimeCard(ref TimeCard value, LEAVE_PERIOD_TYPE periodStatus, string status)
		{
			AttendanceStatus attendanceStatus = new AttendanceStatus();
			string afterBreak, beforeBreak;

			attendanceStatus.Code = "";
			afterBreak = value.AAfterBreakStatus.Code.Trim();
			beforeBreak = value.ABeforeBreakStatus.Code.Trim();

			switch(periodStatus)
			{
				case LEAVE_PERIOD_TYPE.AM:
					if(afterBreak == status)
					{
						value.AAfterBreakStatus = attendanceStatus;
					}
					break;
				case LEAVE_PERIOD_TYPE.PM:
					if(beforeBreak == status)
					{
						value.ABeforeBreakStatus = attendanceStatus;
					}
					break;
			}		
		}

		public TimeCard GetDeleteLeaveTimeCard(DateTime forDate, LEAVE_PERIOD_TYPE periodStatus, Employee aEmployee)
		{
			TimeCard objTimeCard = new TimeCard();
			AttendanceStatus attendanceStatus;
			objTimeCard = dbEmployeeTimeCard.GetTimeCard(forDate, aEmployee);

			if(objTimeCard != null)
			{
				attendanceStatus = new AttendanceStatus();
				attendanceStatus.Code = "";

				if(periodStatus == LEAVE_PERIOD_TYPE.AM)
				{
					objTimeCard.ABeforeBreakStatus = attendanceStatus;
				}
				else if(periodStatus == LEAVE_PERIOD_TYPE.PM)
				{
					objTimeCard.AAfterBreakStatus = attendanceStatus;
				}
				else
				{
					objTimeCard.AAfterBreakStatus = attendanceStatus;
					objTimeCard.ABeforeBreakStatus = attendanceStatus;
				}
				return objTimeCard;	
			}	
			else
			{
				return null;
			}
		}
	}
}
