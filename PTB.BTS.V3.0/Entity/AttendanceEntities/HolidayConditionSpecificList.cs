using System;

using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
    public class HolidayConditionSpecificList : ictus.Common.Entity.CompanyStuffBase	
	{
//		============================== Constructor ==============================
        public HolidayConditionSpecificList(ictus.Common.Entity.Company value)
            : base(value)
		{}

//		============================== Public Method ==============================
		public void Add(HolidayConditionSpecific value)
		{base.Add(value);}

		public void Remove(HolidayConditionSpecific value)
		{base.Remove(value);}

		public HolidayConditionSpecific this[int index]
		{
			get{return (HolidayConditionSpecific) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public HolidayConditionSpecific this[String key]  
		{
			get{return (HolidayConditionSpecific) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
