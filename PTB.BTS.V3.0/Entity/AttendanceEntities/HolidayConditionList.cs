using System;

using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
    public class HolidayConditionList : ictus.Common.Entity.CompanyStuffBase	
	{
//		============================== Constructor ==============================
        public HolidayConditionList(ictus.Common.Entity.Company company)
            : base(company)
		{}

//		============================== Public Method ==============================
		public void Add(HolidayCondition value)
		{base.Add(value);}

		public void Remove(HolidayCondition value)
		{base.Remove(value);}

		public HolidayCondition this[int index]
		{
			get{return (HolidayCondition) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public HolidayCondition this[String key]  
		{
			get{return (HolidayCondition) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
