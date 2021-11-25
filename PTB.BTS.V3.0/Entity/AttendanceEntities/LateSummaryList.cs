using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;

namespace Entity.AttendanceEntities
{
    public class LateSummaryList : ictus.Common.Entity.CompanyStuffBase
	{
		private YearMonth aYearMonth;
		public YearMonth AYearMonth
		{
			get{return aYearMonth;}
			set{aYearMonth = value;}
		}

//		============================== Constructor ==============================
        public LateSummaryList(ictus.Common.Entity.Company value, YearMonth yearMonth)
            : base(value)
		{
			aYearMonth = yearMonth;
		}

//		============================== Public Method ==============================
		public void Add(LateSummary value)
		{base.Add(value);}

		public void Remove(LateSummary value)
		{base.Remove(value);}

		public LateSummary this[int index]
		{
			get{return (LateSummary) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}
		public LateSummary this[String key]  
		{
			get{return (LateSummary) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
