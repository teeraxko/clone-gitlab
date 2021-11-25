using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

namespace Entity.VehicleEntities
{
    public class CompulsoryInsuranceList : CompanyStuffBase
	{
		//============================== Constructor ==============================
        public CompulsoryInsuranceList(Company value)
            : base(value)
		{
		}

		//============================== Public Method ==============================
		public void Add(CompulsoryInsurance value)
		{base.Add(value.EntityKey.Trim(), value);
		}

		public void Remove(CompulsoryInsurance value)  
		{base.Remove(value);}

		public CompulsoryInsurance this[int index]
		{
			get
			{return (CompulsoryInsurance) base.BaseGet(index);}
			set
			{base.BaseSet(index, value);}
		}

		public CompulsoryInsurance this[String key]  
		{
			get
			{return (CompulsoryInsurance) base.BaseGet(key);}
			set
			{base.BaseSet(key, value);}
		}
	}
}
