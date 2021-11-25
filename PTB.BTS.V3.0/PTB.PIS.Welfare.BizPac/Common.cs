using System;
using System.Collections.Generic;
using System.Text;
using ictus.Common.Entity;
using System.Globalization;
using PTB.BTS.Contract.Flow;

namespace PTB.PIS.Welfare.BizPac
{
    class Common
    {
        public static readonly Company CurrentCompany = new Company("12");
        public static string FileName(DateTime datetime)
        {
            DateTimeFormatInfo de = new CultureInfo("en-US", false).DateTimeFormat;
            de.ShortDatePattern = "yyMMddHHmmss";
            de.LongTimePattern = "";
            de.ShortTimePattern = "";
            return datetime.ToString(de).Trim();
        }

        public static string GetNewConnectRefNo()
        {
            DocumentNoFlow documentNoFlow = new DocumentNoFlow();
            return documentNoFlow.GetBizPacRefNo();
        }

        public static DateTime EndMonthDate(DateTime date)
        {
            int year = date.Year;
            int month = date.Month;
            return Common.EndMonthDate(year, month);
        }

        public static DateTime EndMonthDate(int year, int month)
        {
            int endMonthDay = DateTime.DaysInMonth(year, month);
            return new DateTime(year, month, endMonthDay);
        }

        public static DateTimeFormatInfo MonthNameYearFormat()
        {
            DateTimeFormatInfo de = new CultureInfo("en-US", false).DateTimeFormat;
            de.ShortDatePattern = "MMMM yyyy";
            de.LongTimePattern = "";
            de.ShortTimePattern = "";
            return de;
        }

        public static DateTimeFormatInfo EngDateFormat(string format)
        {
            DateTimeFormatInfo de = new CultureInfo("en-US", false).DateTimeFormat;
            de.ShortDatePattern = format;
            de.LongTimePattern = "";
            de.ShortTimePattern = "";
            return de;
        }

        public static DateTimeFormatInfo ShortMonthNameYearFormat()
        {
            DateTimeFormatInfo de = new CultureInfo("en-US", false).DateTimeFormat;
            de.ShortDatePattern = "MMM yyyy";
            de.LongTimePattern = "";
            de.ShortTimePattern = "";
            return de;
        }
    }
}
