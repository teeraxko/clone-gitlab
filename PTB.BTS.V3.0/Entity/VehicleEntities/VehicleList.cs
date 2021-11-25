using System;

using ictus.PIS.PI.Entity;

namespace Entity.VehicleEntities
{
    public class VehicleList : ictus.Common.Entity.CompanyStuffBase
	{
		//============================== Constructor ==============================
        public VehicleList(ictus.Common.Entity.Company value)
            : base(value)
		{}

		//============================== Public Method ==============================
		public void Add(Vehicle value)
		{base.Add(value);}

		public void Remove(Vehicle value)  
		{base.Remove(value);}

		public Vehicle this[int index]
		{
			get
			{return (Vehicle) base.BaseGet(index);}
			set
			{base.BaseSet(index, value);}
		}

		public Vehicle this[String key]  
		{
			get
			{return (Vehicle) base.BaseGet(key);}
			set
			{base.BaseSet(key, value);}
		}
	}
}
