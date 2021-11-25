using System;

using ictus.Common.Entity.Time;
using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
    public class PrivateLeaveSummaryList : ictus.Common.Entity.CompanyStuffBase
	{
		private YearMonth aYearMonth;
		public YearMonth AYearMonth
		{
			get{return aYearMonth;}
			set{aYearMonth = value;}
		}

//		============================== Constructor ==============================
        public PrivateLeaveSummaryList(ictus.Common.Entity.Company value, YearMonth yearMonth)
            : base(value)
		{
			aYearMonth = yearMonth;
		}

//		============================== Public Method ==============================
		public void Add(PrivateLeaveSummary value)
		{base.Add(value);}

		public void Remove(PrivateLeaveSummary value)
		{base.Remove(value);}

		public PrivateLeaveSummary this[int index]
		{
			get{return (PrivateLeaveSummary) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}
		public PrivateLeaveSummary this[String key]  
		{
			get{return (PrivateLeaveSummary) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
