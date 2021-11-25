using System;

using ictus.Common.Entity.Time;
using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
    public class AnnualLeaveSummaryList : ictus.Common.Entity.CompanyStuffBase
	{
		private YearMonth aYearMonth;
		public YearMonth AYearMonth
		{
			get{return aYearMonth;}
			set{aYearMonth = value;}
		}

//		============================== Constructor ==============================
        public AnnualLeaveSummaryList(ictus.Common.Entity.Company value, YearMonth yearMonth)
            : base(value)
		{
			aYearMonth = yearMonth;
		}

//		============================== Public Method ==============================
		public void Add(AnnualLeaveSummary value)
		{base.Add(value);}

		public void Remove(AnnualLeaveSummary value)
		{base.Remove(value);}

		public AnnualLeaveSummary this[int index]
		{
			get{return (AnnualLeaveSummary) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}
		public AnnualLeaveSummary this[String key]  
		{
			get{return (AnnualLeaveSummary) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
