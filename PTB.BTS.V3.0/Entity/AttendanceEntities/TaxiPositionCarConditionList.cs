using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

namespace Entity.AttendanceEntities
{
    public class TaxiPositionCarConditionList : CompanyStuffBase
	{
//		============================== Constructor ==============================
        public TaxiPositionCarConditionList(ictus.Common.Entity.Company value)
            : base(value)
		{
			
		}
//		============================== Public Method ==============================
		public void Add(TaxiPositionCarCondition value)
		{base.Add(value);}

		public void Remove(TaxiPositionCarCondition value)
		{base.Remove(value);}

		public TaxiPositionCarCondition this[int index]
		{
			get{return (TaxiPositionCarCondition) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public TaxiPositionCarCondition this[String key]  
		{
			get{return (TaxiPositionCarCondition) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
