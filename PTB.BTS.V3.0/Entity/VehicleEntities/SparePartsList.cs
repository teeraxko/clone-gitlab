using System;

using ictus.PIS.PI.Entity;

namespace Entity.VehicleEntities
{
    public class SparePartsList : ictus.Common.Entity.CompanyStuffBase
	{
//		============================== Constructor ==============================
        public SparePartsList(ictus.Common.Entity.Company value)
            : base(value)
		{}

//		============================== Public Method ==============================
		public void Add(SpareParts value)
		{base.Add(value);}

		public void Remove(SpareParts value)
		{base.Remove(value);}
	
		public SpareParts this[int index]
		{
			get
			{return (SpareParts) base.BaseGet(index);}
			set
			{base.BaseSet(index, value);}
		}

		public SpareParts this[String key]  
		{
			get
			{return (SpareParts) base.BaseGet(key);}
			set
			{base.BaseSet(key, value);}
		}
	}
}
