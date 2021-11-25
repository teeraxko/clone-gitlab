using System;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using ictus.Common.Entity.General;

namespace Flow.AttendanceFlow
{
	public class AttendanceCommonFlow
	{
		//==============================  Constructor  ==============================
		public AttendanceCommonFlow()
		{
		}

		#region - Private Method -
			private DateTime getCombineDateTime(DateTime date, DateTime time)
			{
				return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, 0, 0);
			}

			private TimePeriod getTimePeriod(DateTime timeForm, DateTime timeTo, DateTime forDate)
			{
				DateTime form = getCombineDateTime(forDate, timeForm);
				DateTime to = getCombineDateTime(forDate, timeTo);

				TimePeriod timePeriod = new TimePeriod();
				timePeriod.From = form;
				if(to <= form)
				{
					timePeriod.To = to.AddDays(1);
				}
				else
				{
					timePeriod.To = to;
				}
				return timePeriod;
			}

			private TimePeriod getBreakTimePeriod(DateTime startBreak, DateTime endBreak, DateTime startWork, DateTime endWork, DateTime forDate)
			{
				DateTime startTimeWork = getCombineDateTime(forDate, startWork);
				DateTime endTimeWork = getCombineDateTime(forDate, endWork);

				DateTime startTimeBreak = getCombineDateTime(forDate, startBreak);
				DateTime endTimeBreak = getCombineDateTime(forDate, endBreak);

				if(endTimeWork <= startTimeWork)
				{
					if(endTimeBreak<startTimeBreak)
					{
						return getTimePeriod(startTimeBreak, endTimeBreak, forDate);
					}

					if(endTimeBreak<=endTimeWork)
					{
						return getTimePeriod(startTimeBreak, endTimeBreak, forDate.AddDays(1));
					}
					else
					{
						return getTimePeriod(startTimeBreak, endTimeBreak, forDate);
					}
				}
				else
				{
					return getTimePeriod(startTimeBreak, endTimeBreak, forDate);
				}
			}
		#endregion

		//==============================  public Method   ==============================
		#region - Time Method -
		public TimePeriod GetTimePeriod(TimePeriod value, DateTime forDate)
		{
			return getTimePeriod(value.From, value.To, forDate);
		}

		public TimePeriod GetTimePeriod(TimePeriod value)
		{
			return getTimePeriod(value.From, value.To, NullConstant.TIME);
		}

		public TimePeriod GetTimePeriod(DateTime form, DateTime to, DateTime forDate)
		{
			return getTimePeriod(form, to, forDate);
		}

		public TimePeriod GetTimePeriod(DateTime form, DateTime to)
		{
			return getTimePeriod(form, to, NullConstant.TIME);
		}

		public DateTime GetTime(DateTime time)
		{
			return getCombineDateTime(NullConstant.TIME, time);
		}

		public TimePeriod GetTime(DateTime from, DateTime to)
		{
			TimePeriod timePeriod = new TimePeriod();
			timePeriod.From = getCombineDateTime(NullConstant.TIME, from);
			timePeriod.To = getCombineDateTime(NullConstant.TIME, to);
			return timePeriod;
		}
		#endregion

		#region - Break Time Method -
			public TimePeriod GetBreakTimePeriod(DateTime startBreak, DateTime endBreak, DateTime startWork, DateTime endWork, DateTime forDate)
			{
				return getBreakTimePeriod(startBreak, endBreak, startWork, endWork, forDate);
			}

			public TimePeriod GetBreakTimePeriod(DateTime startBreak, DateTime endBreak, DateTime startWork, DateTime endWork)
			{
				return getBreakTimePeriod(startBreak, endBreak, startWork, endWork, NullConstant.TIME);
			}

			public TimePeriod GetBreakTimePeriod(TimePeriod timePeriodBreak, TimePeriod timePeriodWork, DateTime forDate)
			{
				return getBreakTimePeriod(timePeriodBreak.From, timePeriodBreak.To, timePeriodWork.From, timePeriodWork.To, forDate);
			}

			public TimePeriod GetBreakTimePeriod(TimePeriod timePeriodBreak, TimePeriod timePeriodWork)
			{
				return getBreakTimePeriod(timePeriodBreak.From, timePeriodBreak.To, timePeriodWork.From, timePeriodWork.To, NullConstant.TIME);
			}
		#endregion

	}
}