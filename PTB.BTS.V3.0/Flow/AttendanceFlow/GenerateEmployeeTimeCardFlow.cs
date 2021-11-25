using System;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;
using ictus.Common.Entity.Time;

using DataAccess.CommonDB;
using DataAccess.AttendanceDB;

using SystemFramework.AppException;

namespace Flow.AttendanceFlow
{
	public class GenerateEmployeeTimeCardFlow : GenerateWorkScheduleFlowBase
	{
		#region - Private -
			private EmployeeTimeCardDB dbEmployeeTimeCard;
			private EmployeeWorkScheduleDB dbEmployeeWorkSchedule;

			private EmployeeTimeCard employeeTimeCard;
			private EmployeeWorkSchedule employeeWorkSchedule;
		#endregion

		//==============================  Constructor  ==============================
		public GenerateEmployeeTimeCardFlow() : base()
		{
			dbEmployeeTimeCard = new EmployeeTimeCardDB();
			dbEmployeeWorkSchedule = new EmployeeWorkScheduleDB();
		}
		
		#region - Private Method -
			private EmployeeWorkSchedule getEmployeeWorkSchedule(Employee value, YearMonth yearMonth)
			{
				employeeWorkSchedule = new EmployeeWorkSchedule(value, yearMonth);
				if(!dbEmployeeWorkSchedule.FillWorkScheduleList(ref employeeWorkSchedule))
				{
					employeeWorkSchedule = null;
					AppExceptionBase appExceptionBase = new AppExceptionBase("GenerateWorkScheduleFlowBase");
					appExceptionBase.SetMessage("ไม่พบ WorkSchedule สำหรับ พนักงาน รหัส : " + value.EmployeeNo.ToString());
					throw appExceptionBase;
				}
				return employeeWorkSchedule;
			}

			private TimeCard getTimeCard(WorkSchedule value)
			{
				TimeCard timeCard = new TimeCard();
				timeCard.CardDate = value.WorkDate;
				timeCard.DayType = value.DayType;
				timeCard.ATimePeriod = getTimePeriod(value.AWorkingTime, value.WorkDate);
				timeCard.ABeforeBreakStatus = new AttendanceStatus();
				timeCard.AAfterBreakStatus = new AttendanceStatus();
				if(value.DayType==WORKINGDAY_TYPE.WORKINGDAY)
				{
					timeCard.ABeforeBreakStatus.Code = "WK";
					timeCard.AAfterBreakStatus.Code = "WK";			
				}
				else
				{
					timeCard.ABeforeBreakStatus.Code = "H1";
					timeCard.AAfterBreakStatus.Code = "H1";	
				}			
				return timeCard;
			}

			private EmployeeTimeCard getEmployeeTimeCard(EmployeeWorkSchedule value)
			{
				employeeTimeCard = new EmployeeTimeCard(value.Employee, value.ForYearMonth);
				for(int i=0; i<value.Count; i++)
				{
					employeeTimeCard.Add(getTimeCard(value[i]));
				}
				return employeeTimeCard;
			}

			private bool insertEmployeeTimeCard(EmployeeTimeCardList value, TableAccess tableAccess)
			{
				bool result = true;
				dbEmployeeTimeCard.TableAccess = tableAccess;
				for(int i=0; i<value.Count; i++)
				{
					dbEmployeeTimeCard.DeleteTimeCard(value[i].Employee, value[i].AYearMonth);
					if(!dbEmployeeTimeCard.InsertTimeCard(value[i]))
					{
						result = false;
						break;
					}
				}
				return result;
			}

			private bool checkForSomeStatus(TimeCard value, string status)
			{
				if(value.ABeforeBreakStatus.Code==status || value.AAfterBreakStatus.Code==status)
				{
					return true;
				}
				else
				{
					return false;
				}		
			}

			private bool mustKeepStatus(AttendanceStatus value)
			{
				if((value.Code=="A1") || (value.Code=="S1") || (value.Code=="S2") || (value.Code=="P1"))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		#endregion

		//============================== Public Method ==============================
		public EmployeeTimeCard GetEmployeeTimeCard(EmployeeWorkSchedule value)
		{
			return getEmployeeTimeCard(value);
		}

		public TimeCard GetTimeCard(WorkSchedule value)
		{
			return getTimeCard(value);
		}

		public TimeCard GetTimeCard(Employee employee, DateTime value)
		{
			TimeCard timeCard = new TimeCard();
			timeCard.CardDate = value;
			if(!dbEmployeeTimeCard.FillTimeCard(ref timeCard, employee))
			{
				GenerateEmployeeWorkScheduleFlow flowGenerateEmployeeWorkSchedule = new GenerateEmployeeWorkScheduleFlow();
				EmployeeWorkSchedule employeeWorkSchedule = flowGenerateEmployeeWorkSchedule.GenWorkSchedule(employee, new YearMonth(value));
				timeCard = getTimeCard(employeeWorkSchedule[value.ToShortDateString()]);

			}
			return timeCard;
		}

		public override bool InsertWorkSchedule(CompanyStuffBase value, TableAccess tableAccess)
		{
			return insertEmployeeTimeCard((EmployeeTimeCardList)value, tableAccess);
		}

		public override CompanyStuffBase CreateWorkSchedule(EmployeeList value, YearMonth yearMonth)
		{
			EmployeeWorkSchedule employeeWorkSchedule;
			EmployeeTimeCard employeeTimeCard;
			EmployeeTimeCard employeeTimeCardData;
			TimeCard timeCard;

			EmployeeTimeCardList employeeTimeCardList = new EmployeeTimeCardList(value.Company);

			for(int i=0; i<value.Count; i++)
			{
				employeeWorkSchedule = getEmployeeWorkSchedule(value[i], yearMonth);
				employeeTimeCard = getEmployeeTimeCard(employeeWorkSchedule);

				employeeTimeCardData = new EmployeeTimeCard(value[i], yearMonth);
				employeeTimeCardData.AYearMonth = yearMonth;
				if(dbEmployeeTimeCard.FillTimeCardList(ref employeeTimeCardData))
				{
					for(int j=0; j<employeeTimeCardData.Count; j++)
					{
						timeCard = employeeTimeCardData[j];
						if(mustKeepStatus(timeCard.AAfterBreakStatus))
						{
							employeeTimeCard[timeCard.CardDate.ToShortDateString()].AAfterBreakStatus = timeCard.AAfterBreakStatus;
						}
						if(mustKeepStatus(timeCard.ABeforeBreakStatus))
						{
							employeeTimeCard[timeCard.CardDate.ToShortDateString()].ABeforeBreakStatus = timeCard.ABeforeBreakStatus;
						}
					}
				}

				employeeTimeCardList.Add(employeeTimeCard);
			}

			employeeWorkSchedule = null;
			employeeTimeCard = null;
			timeCard = null;

			return employeeTimeCardList;
		}

		public CompanyStuffBase CreateWorkSchedule(EmployeeWorkScheduleList value, YearMonth yearMonth)
		{
			EmployeeWorkSchedule employeeWorkSchedule;
			EmployeeTimeCard employeeTimeCard;
			EmployeeTimeCard employeeTimeCardData;
			TimeCard timeCard;

			EmployeeTimeCardList employeeTimeCardList = new EmployeeTimeCardList(value.Company);

			for(int i=0; i<value.Count; i++)
			{
				employeeWorkSchedule = value[i];
				employeeTimeCard = getEmployeeTimeCard(employeeWorkSchedule);

				employeeTimeCardData = new EmployeeTimeCard(value[i].Employee, yearMonth);
				employeeTimeCardData.AYearMonth = yearMonth;
				if(dbEmployeeTimeCard.FillTimeCardList(ref employeeTimeCardData))
				{
					for(int j=0; j<employeeTimeCardData.Count; j++)
					{
						timeCard = employeeTimeCardData[j];
						if(mustKeepStatus(timeCard.AAfterBreakStatus))
						{
							employeeTimeCard[timeCard.CardDate.ToShortDateString()].AAfterBreakStatus = timeCard.AAfterBreakStatus;
						}
						if(mustKeepStatus(timeCard.ABeforeBreakStatus))
						{
							employeeTimeCard[timeCard.CardDate.ToShortDateString()].ABeforeBreakStatus = timeCard.ABeforeBreakStatus;
						}					
					}
				}

				employeeTimeCardList.Add(employeeTimeCard);
			}

			employeeWorkSchedule = null;
			employeeTimeCard = null;
			timeCard = null;

			return employeeTimeCardList;
		}
	}
}