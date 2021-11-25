using System;
using System.Collections.Generic;
using System.Text;
using ictus.Common.Entity;
using System.Globalization;

namespace PTB.BTS.BTS2SAP.Entity
{
    public static class BTS2SAPDateFormat
    {
        public static string FileNameDateFormat(DateTime datetime)
        {
            DateTimeFormatInfo de = new CultureInfo("en-US", false).DateTimeFormat;
            de.ShortDatePattern = "yyMMddHHmmss";
            de.LongTimePattern = "";
            de.ShortTimePattern = "";
            return datetime.ToString(de).Trim();
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

        public static DateTimeFormatInfo SAPCSVDateFormat()
        {
            DateTimeFormatInfo de = new CultureInfo("en-US", false).DateTimeFormat;
            de.ShortDatePattern = "ddMMyyyy";
            de.LongTimePattern = "";
            de.ShortTimePattern = "";
            return de;
        }

        public static CultureInfo SAPCSVCultureInfo()
        {
            return new CultureInfo("en-US", false);
        }
    }
}
