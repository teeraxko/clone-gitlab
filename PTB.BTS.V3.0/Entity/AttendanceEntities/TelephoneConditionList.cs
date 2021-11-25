using System;

using ictus.Common.Entity;
using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
    public class TelephoneConditionList : CompanyStuffBase
	{
//		============================== Constructor ==============================
        public TelephoneConditionList(ictus.Common.Entity.Company value)
            : base(value)
		{}

//		============================== Public Method ==============================
		public void Add(TelephoneCondition value)
		{base.Add(value);}

		public void Remove(TelephoneCondition value)
		{base.Remove(value);}

		public TelephoneCondition this[int index]
		{
			get{return (TelephoneCondition) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public TelephoneCondition this[String key]  
		{
			get{return (TelephoneCondition) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
