using System;

namespace Entity.AttendanceEntities
{
    public class WorkingTimeConditionSpecificList : ictus.Common.Entity.CompanyStuffBase
	{
//		============================== Constructor ==============================
        public WorkingTimeConditionSpecificList(ictus.Common.Entity.Company value)
            : base(value)
		{}

//		============================== Public Method ==============================
		public void Add(WorkingTimeConditionSpecific value)
		{base.Add(value);}

		public void Remove(WorkingTimeConditionSpecific value)
		{base.Remove(value);}

		public WorkingTimeConditionSpecific this[int index]
		{
			get{return (WorkingTimeConditionSpecific) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public WorkingTimeConditionSpecific this[String key]  
		{
			get{return (WorkingTimeConditionSpecific) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
