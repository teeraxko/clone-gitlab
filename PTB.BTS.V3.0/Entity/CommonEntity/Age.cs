using System;

namespace Entity.CommonEntity
{
    public class Age
    {
        public Age(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }

        protected int day;
        public int Day
        {
            get { return day; }
            set { day = value; }
        }

        protected int month;
        public int Month
        {
            get { return month; }
            set { month = value; }
        }

        protected int year;
        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public static DateTime MedicalAidDate = new DateTime(2008, 8, 1);
    }
}
