using System;

using ictus.Common.Entity.Time;
using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;

namespace Entity.AttendanceEntities
{
    public class TraditionalHolidayList : ictus.Common.Entity.CompanyStuffBase
	{
//		============================== Property ==============================
		private TraditionalHolidayPattern aTraditionalHolidayPattern;
		public TraditionalHolidayPattern ATraditionalHolidayPattern
		{
			set{aTraditionalHolidayPattern = value;}
			get{return aTraditionalHolidayPattern;}
		}

		private YearMonth aYearMonth = NullConstant.YEARMONTH;
		public YearMonth AYearMonth
		{
			set{aYearMonth = value;}
			get{return aYearMonth;}
		}

//		============================== Constructor ==============================
        public TraditionalHolidayList(ictus.Common.Entity.Company company)
            : base(company)
		{
			aTraditionalHolidayPattern = new TraditionalHolidayPattern();
		}

//		============================== Public Method ==============================
		public void Add(TraditionalHoliday value)
		{base.Add(value);}

		public void Remove(TraditionalHoliday value)
		{base.Remove(value);}

		public TraditionalHoliday this[int index]
		{
			get{return (TraditionalHoliday) base.BaseGet(index);}
			set{base.BaseSet(index, value);}}

		public TraditionalHoliday this[String key]  
		{
			get{return (TraditionalHoliday) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
