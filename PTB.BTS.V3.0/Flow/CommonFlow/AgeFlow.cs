using System;

using Entity.CommonEntity;

using ictus.Common.Entity.Time;
using ictus.Common.Entity.General;

namespace PTB.BTS.Common.Flow
{
	public class AgeFlow : FlowBase
	{
        #region Private Method
        private DateTime currentDate = DateTime.Today; 
        #endregion

        #region Constructor
        public AgeFlow()
            : base()
        { } 
        #endregion

        #region Public Method
        public YearMonth CalculateAge(DateTime birthDate)
        {
            if (birthDate.Date == NullConstant.DATETIME)
            {
                return new YearMonth(0, 0);
            }
            else
            {
                int diffyear = currentDate.Year - birthDate.Year;
                int diffmonth = currentDate.Month - birthDate.Month;
                int diffday = currentDate.Day - birthDate.Day;

                if (diffday < 0)
                {
                    diffmonth = diffmonth - 1;
                }
                if (diffmonth < 0)
                {
                    diffyear = diffyear - 1;
                    diffmonth = diffmonth + 12;
                }

                return new YearMonth(diffyear, diffmonth);
            }
        }

        public Age CalculateFineAge(DateTime start, DateTime end)
        {
            int diffyear = end.Year - start.Year;
            int diffmonth = end.Month - start.Month;
            int diffday = end.Day - start.Day;

            if (diffday < 0)
            {
                diffmonth = diffmonth - 1;
                diffday = diffday + DateTime.DaysInMonth(start.Year, start.Month);
            }
            if (diffmonth < 0)
            {
                diffyear = diffyear - 1;
                diffmonth = diffmonth + 12;
            }

            return new Age(diffday, diffmonth, diffyear);
        }

        public DayMonthYearStructure DaysDiff(DateTime start, DateTime end)
        {
            int diffyear = end.Year - start.Year;
            int diffmonth = end.Month - start.Month;
            int diffday = end.Day - start.Day;

            if (diffday < 0)
            {
                diffmonth = diffmonth - 1;
                diffday = diffday + DateTime.DaysInMonth(start.Year, start.Month);
            }
            if (diffmonth < 0)
            {
                diffyear = diffyear - 1;
                diffmonth = diffmonth + 12;
            }

            return new DayMonthYearStructure(diffday, diffmonth, diffyear);

        }

        public DayMonthYearStructure DaysDiff(DateTime value)
        {
            return DaysDiff(value, DateTime.Today);
        } 
        #endregion
	}
}
