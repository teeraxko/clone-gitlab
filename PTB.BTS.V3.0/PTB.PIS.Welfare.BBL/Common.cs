using System;
using System.Collections.Generic;
using System.Text;
using ictus.Common.Entity;
using System.Globalization;
using System.IO;
using PTB.BTS.PI.Flow;

namespace PTB.PIS.Welfare.BBL {
    class Common {
        public static readonly Company CurrentCompany = new Company("12");
        public static string FileName(DateTime datetime) {
            return datetime.ToString("yyyyMMddHHmmss");
        }


        private static CompanyInfo _comp = null;
        public static CompanyInfo CompanyInfo {
            get {
                if (_comp == null) {
                    CompanyFlow companyFlow = new CompanyFlow();
                    _comp = new CompanyInfo("12");
                    companyFlow.FillCompany(ref _comp);
                }
                return _comp;
            }
        }

        public static DateTime EndMonthDate(DateTime date) {
            int year = date.Year;
            int month = date.Month;
            return Common.EndMonthDate(year, month);
        }

        public static DateTime EndMonthDate(int year, int month) {
            int endMonthDay = DateTime.DaysInMonth(year, month);
            return new DateTime(year, month, endMonthDay);
        }

        public static DateTimeFormatInfo MonthNameYearFormat() {
            DateTimeFormatInfo de = new CultureInfo("en-US", false).DateTimeFormat;
            de.ShortDatePattern = "MMMM yyyy";
            de.LongTimePattern = "";
            de.ShortTimePattern = "";
            return de;
        }

        public static void WriteFile(string fileName, List<string> lines) {
            try {
                using (StreamWriter sw = new StreamWriter(fileName)) {
                    foreach (string line in lines) {
                        sw.WriteLine(line);
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static string ConvertToBLLMoneyFormat(int length, decimal value) {
            string result = string.Empty;
            StringBuilder stringFormat = new StringBuilder();
            for (int i = 0; i < length - 2; i++) {
                stringFormat.Append('0');
            }
            stringFormat.Append(".00");
            result = value.ToString(stringFormat.ToString());
            result = result.Remove(length - 2, 1);
            return result;
        }

        public static string ConvertToBLLZeroFormat(int length, string value) {
            string result = string.Empty;
            result = value.PadLeft(length);
            result = result.Replace((char)32, '0');
            return result;
        }

        public static DateTimeFormatInfo EngDateFormat(string format) {
            DateTimeFormatInfo de = new CultureInfo("en-US", false).DateTimeFormat;
            de.ShortDatePattern = format;
            de.LongTimePattern = "";
            de.ShortTimePattern = "";
            return de;
        }


    }
}
