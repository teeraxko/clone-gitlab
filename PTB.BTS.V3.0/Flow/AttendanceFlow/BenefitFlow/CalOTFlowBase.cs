using System;

using Entity.AttendanceEntities;
using Entity.AttendanceEntities.BenefitEntities;
using Entity.CommonEntity;

using ictus.Common.Entity.General;
using ictus.PIS.PI.Entity;

using DataAccess.AttendanceDB;

using PTB.BTS.Common.Flow;

namespace PTB.BTS.Attendance.Benefit.Flow
{
	public abstract class CalOTFlowBase : FlowBase
	{
		private EmployeeWorkScheduleDB dbEmployeeWorkSchedule;

		//============================== Constructor ==============================
		protected CalOTFlowBase() : base()
		{
			dbEmployeeWorkSchedule = new EmployeeWorkScheduleDB();
		}

		//==============================  protected  ==============================
		protected decimal addTime(decimal value1, decimal value2)
		{
			decimal sumFloor = decimal.Floor(value1) + decimal.Floor(value2);
			decimal sumRemainder = decimal.Remainder(value1, 1) + decimal.Remainder(value2, 1);

				if(sumRemainder>=0.6m)
				{
					sumFloor++;
					sumRemainder = sumRemainder - 0.6m;
				}

			return sumFloor + sumRemainder;
		}

		protected decimal diffTime(decimal value1, decimal value2)
		{
			decimal diffFloor = decimal.Floor(value1) - decimal.Floor(value2);
			decimal diffRemainder = decimal.Remainder(value1, 1) - decimal.Remainder(value2, 1);

			if(diffRemainder<0m)
			{
				diffFloor--;
				diffRemainder = diffRemainder + 0.6m;
			}

			return diffFloor + diffRemainder;
		}

		protected decimal diffTime(DateTime form, DateTime to)
		{
			if(form==NullConstant.DATETIME || to==NullConstant.DATETIME)
			{
				return 0;
			}

			decimal otHour = 0;

			int diffHour = 0;
			int diffMinute = 0;

			diffMinute = to.Minute - form.Minute;
			diffHour = to.Hour - form.Hour;

			if(diffMinute<0)
			{
				diffHour -= 1;
				diffMinute += 60;
			}

			otHour = (decimal)diffHour + (decimal)diffMinute/100.0m;

			if(otHour<0)
			{//ข้ามวัน
				otHour += 24;
			}

			return otHour;
		}

		protected WorkInfo getNextWorkInfo(DateTime value, Employee employee)
		{
			WorkSchedule workSchedule = new WorkSchedule();
			workSchedule.WorkDate = value.AddDays(1);
			if(dbEmployeeWorkSchedule.FillWorkSchedule(ref workSchedule, employee))
			{
				return new WorkInfo(workSchedule);
			}
			else
			{
				return null;
			}
		}

		protected bool validateTime(DateTime start, DateTime end)
		{
			return (start != NullConstant.DATETIME && end != NullConstant.DATETIME && start != end);
		}

		protected DateTime getTime(DateTime value)
		{
			return new DateTime(NullConstant.TIME.Year, NullConstant.TIME.Month, NullConstant.TIME.Day, value.Hour, value.Minute, value.Second);
		}

		protected DateTime getTime(DateTime date, DateTime time)
		{
			return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
		}

		protected bool between(DateTime value, TimePeriod timePeriod)
		{
			return (timePeriod.From <= value && value <= timePeriod.To);
		}

		protected bool between(TimePeriod value, TimePeriod main)
		{
			return (between(value.From, main) && between(value.To, main));
		}

		protected bool notBetween(TimePeriod value, TimePeriod main)
		{
			return (value.To <= main.From || main.To <= value.From);
		}

		protected TimePeriod getTimeFormBetweenTimePeriod(TimePeriod value, TimePeriod main)
		{
			TimePeriod timePeriod = new TimePeriod();
			if(between(value, main))
			{
				timePeriod.From = value.From;
				timePeriod.To = value.To;
			}
			else
			{
				if(between(main, value))
				{
					timePeriod.From = main.From;
					timePeriod.To = main.To;
				}
				else
				{
					if(notBetween(value, main))
					{
						timePeriod.From = NullConstant.DATETIME;
						timePeriod.To = NullConstant.DATETIME;
					}
					else
					{
						if(between(main.From, value))
						{
							timePeriod.From = main.From;
							timePeriod.To = value.To;
						}
						if(between(main.To, value))
						{
							timePeriod.From = value.From;
							timePeriod.To = main.To;
						}
					}
				}
			}
			return timePeriod;
		}

		protected void fillOvertimeHour(BenefitOTHour value, BenefitOTHour overtimeHour, WorkInfo workInfo)
		{
			TimePeriod mainTimePeriod = new TimePeriod();
			TimePeriod timePeriod = new TimePeriod();

			timePeriod.From = overtimeHour.BeforeTime.From;
			if(overtimeHour.BeforeTime.To == NullConstant.DATETIME)
			{
				timePeriod.To = overtimeHour.AfterTime.To;
			}
			else
			{
				timePeriod.To = overtimeHour.BeforeTime.To;
			}

			mainTimePeriod.From = overtimeHour.BenefitDate;
			mainTimePeriod.To = workInfo.WorkingTime.From;
			value.BeforeTime = getTimeFormBetweenTimePeriod(timePeriod, mainTimePeriod);

			mainTimePeriod.From = workInfo.WorkingTime.From;
			mainTimePeriod.To = workInfo.BreakTime.From;
			value.DuringTime1 = getTimeFormBetweenTimePeriod(timePeriod, mainTimePeriod);
			
			//เอาออกตอนเปลี่ยนเวลา
			if(workInfo.DayType == WORKINGDAY_TYPE.HOLIDAY)
			{
				DateTime start = new DateTime(value.BenefitDate.Year, value.BenefitDate.Month, value.BenefitDate.Day, 7, 35, 0);
				DateTime effect = new DateTime(value.BenefitDate.Year, value.BenefitDate.Month, value.BenefitDate.Day, 8, 0, 0);
				DateTime end = new DateTime(value.BenefitDate.Year, value.BenefitDate.Month, value.BenefitDate.Day, 17, 0, 0);
				if(workInfo.WorkingTime.From==start && workInfo.WorkingTime.To==end)
				{
					if(start<=value.DuringTime1.From && value.DuringTime1.From<=effect)
					{
						value.DuringTime1.From = effect;
					}
				}
			}

			if(workInfo.AssignServiceStaffType.APosition.PositionCode == "28")
			{
				if(workInfo.DayType == WORKINGDAY_TYPE.HOLIDAY && overtimeHour.BreakTime.From == NullConstant.DATETIME && overtimeHour.BreakTime.To == NullConstant.DATETIME)
				{
					mainTimePeriod.From = workInfo.BreakTime.From;
					mainTimePeriod.To = workInfo.BreakTime.To;
					value.BreakTime = getTimeFormBetweenTimePeriod(timePeriod, mainTimePeriod);
				}
				else
				{
					value.BreakTime.From = overtimeHour.BreakTime.From;
					value.BreakTime.To = overtimeHour.BreakTime.To;
				}
			}
			else
			{
				value.BreakTime.From = overtimeHour.BreakTime.From;
				value.BreakTime.To = overtimeHour.BreakTime.To;
			}
	
			mainTimePeriod.From = workInfo.BreakTime.To;
			mainTimePeriod.To = workInfo.WorkingTime.To;
			value.DuringTime2 = getTimeFormBetweenTimePeriod(timePeriod, mainTimePeriod);

			mainTimePeriod.From = workInfo.WorkingTime.To;
			mainTimePeriod.To = workInfo.WorkingTime.From.AddDays(1);

			if(overtimeHour.AfterTime.From == NullConstant.DATETIME)
			{
				timePeriod.From = overtimeHour.BeforeTime.From;
			}
			else
			{
				timePeriod.From = overtimeHour.AfterTime.From;
			}
			timePeriod.To = overtimeHour.AfterTime.To;
			value.AfterTime = getTimeFormBetweenTimePeriod(timePeriod, mainTimePeriod);

			mainTimePeriod = null;
			timePeriod = null;
		}
	}
}