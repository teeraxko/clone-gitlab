using System;

using ictus.PIS.PI.Entity;

namespace Entity.VehicleEntities
{
	public class DailyProcessControlList : ictus.Common.Entity.CompanyStuffBase
	{
//		============================== Constructor ==============================
        public DailyProcessControlList(ictus.Common.Entity.Company value)
            : base(value)
		{
		}

//		============================== Public Method ==============================
		public void Add(DailyProcessControl value)
		{base.Add(value);}

		public void Remove(DailyProcessControl value)
		{base.Remove(value);}

		public DailyProcessControl this[int index]
		{
			get{return (DailyProcessControl) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public DailyProcessControl this[String key]  
		{
			get{return (DailyProcessControl) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
