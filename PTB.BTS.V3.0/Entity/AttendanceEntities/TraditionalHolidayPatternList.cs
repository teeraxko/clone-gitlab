using System;

using ictus.Common.Entity;
using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
    public class TraditionalHolidayPatternList : CompanyStuffBase
	{
//		============================== Constructor ==============================
        public TraditionalHolidayPatternList(ictus.Common.Entity.Company company)
            : base(company)
		{}

//		============================== Public Method ==============================
		public void Add(TraditionalHolidayPattern value)
		{base.Add(value);}

		public void Remove(TraditionalHolidayPattern value)
		{base.Remove(value);}

		public TraditionalHolidayPattern this[int index]
		{
			get{return (TraditionalHolidayPattern) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public TraditionalHolidayPattern this[String key]  
		{
			get{return (TraditionalHolidayPattern) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}