using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;

namespace Entity.AttendanceEntities
{
    public class LeaveSummaryListBase : ictus.Common.Entity.CompanyStuffBase
	{
		protected YearMonth aYearMonth;
		public YearMonth AYearMonth
		{
			get{return aYearMonth;}
			set{aYearMonth = value;}
		}

//		============================== Constructor ==============================
        public LeaveSummaryListBase(ictus.Common.Entity.Company value, YearMonth yearMonth)
            : base(value)
		{
			aYearMonth = yearMonth;
		}

//		============================== Public Method ==============================
		public void Add(LeaveSummaryBase value)
		{base.Add(value);}

		public void Remove(LeaveSummaryBase value)
		{base.Remove(value);}

		public LeaveSummaryBase this[int index]
		{
			get{return (LeaveSummaryBase) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}
		public LeaveSummaryBase this[String key]  
		{
			get{return (LeaveSummaryBase) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
