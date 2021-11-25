using System;
using ictus.Common.Entity.Time;
using ictus.Common.Entity.General;
using Entity.CommonEntity;
using System.Globalization;

namespace PTB.BTS.BTS2BizPacEntity
{
    public static class BTS2BizPacCommon
    {
        public static string StringMonthYear
        {
            //Napat C. change way to get month year from "MMMM yyyy"
            get { return DateTime.Today.ToString("MMM yyyy", new CultureInfo("en-GB")); }
        }

        public static string StringBackMonthYear
        {
            get 
            {
                //Napat C. change way to get month year from "MMMM yyyy"
                return DateTime.Today.AddMonths(-1).ToString("MMM yyyy", new CultureInfo("en-GB")); 
            }
        }

        public static string StringBackDate
        {
            get
            {
                YearMonth yearMonth = new YearMonth(DateTime.Today.AddMonths(-1));
                return yearMonth.MaxDateOfMonth.ToString("MMMM yyyy", new CultureInfo("en-GB"));
            }
        }

        public static string GetStringMonthYear(DateTime date)
        {
            return date.ToString("MMM yyyy", new CultureInfo("en-GB"));
        }

        private static DateTime fiscalYearEndDate = NullConstant.DATETIME;

        public static decimal ShareExpendForCurrent(DateTime start, DateTime end, DateTime calPoint, decimal amount)
        {
            return amount - Math.Round(ShareExpendForAdvance(start, end, calPoint, amount), 2);
        }

        public static int ShareDayForCurrent(DateTime start, DateTime end, FiscalYear fiscalYear)
        {
            if(fiscalYearEndDate == NullConstant.DATETIME)
            {
                fiscalYearEndDate = fiscalYear.EndDate;
            }

            TimeSpan totalTime = fiscalYearEndDate - start;
            return totalTime.Days;
        }

        public static decimal ShareExpendForAdvance(DateTime start, DateTime end, DateTime calPoint, decimal amount)
        {
            TimeSpan totalTime = end - start;
            TimeSpan advanceTime = end - calPoint;

            return Math.Round((amount / totalTime.Days),2) * advanceTime.Days;
        }

        public static int ShareDayForAdvance(DateTime start, DateTime end, FiscalYear fiscalYear)
        {
            if (fiscalYearEndDate == NullConstant.DATETIME)
            {
                fiscalYearEndDate = fiscalYear.EndDate;
            }

            TimeSpan totalTime = end - fiscalYearEndDate;

            if (totalTime.Days > 0)
            {
                return totalTime.Days;
            }
            else 
            {
                return 0;
            }
        }

        public static decimal ShareExpendForAdvanceForMonth(DateTime start, DateTime end, YearMonth forMonth, decimal amount)
        {
            TimeSpan totalTime = end - start;

            return Math.Round((amount / totalTime.Days), 2) * forMonth.DaysInMonth;
        }
    }
}
