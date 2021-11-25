using System;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

namespace Entity.AttendanceEntities 
{
    public class TaxiFamilyCarConditionList : ictus.Common.Entity.CompanyStuffBase
	{
//		============================== Constructor ==============================
        public TaxiFamilyCarConditionList(ictus.Common.Entity.Company value)
            : base(value)
		{
			
		}
//		============================== Public Method ==============================
		public void Add(TaxiFamilyCarCondition value)
		{base.Add(value);}

		public void Remove(TaxiFamilyCarCondition value)
		{base.Remove(value);}

		public TaxiFamilyCarCondition this[int index]
		{
			get{return (TaxiFamilyCarCondition) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public TaxiFamilyCarCondition this[String key]  
		{
			get{return (TaxiFamilyCarCondition) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
