using System;

using ictus.Common.Entity.Time;
using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
    public class SickLeaveSummaryList : ictus.Common.Entity.CompanyStuffBase
	{
		private YearMonth aYearMonth;
		public YearMonth AYearMonth
		{
			get{return aYearMonth;}
			set{aYearMonth = value;}
		}

//		============================== Constructor ==============================
        public SickLeaveSummaryList(ictus.Common.Entity.Company value, YearMonth yearMonth)
            : base(value)
		{
			aYearMonth = yearMonth;
		}

//		============================== Public Method ==============================
		public void Add(SickLeaveSummary value)
		{base.Add(value);}

		public void Remove(SickLeaveSummary value)
		{base.Remove(value);}

		public SickLeaveSummary this[int index]
		{
			get{return (SickLeaveSummary) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}
		public SickLeaveSummary this[String key]  
		{
			get{return (SickLeaveSummary) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
