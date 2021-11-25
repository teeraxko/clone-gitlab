using System;

using ictus.PIS.PI.Entity;

namespace Entity.VehicleEntities
{
    public class GarageList : ictus.Common.Entity.CompanyStuffBase
	{
		//		============================== Constructor ==============================
        public GarageList(ictus.Common.Entity.Company company)
            : base(company)
		{}

		//		============================== Public Method ==============================
		public void Add(Garage value)
		{
			base.Add(value);
		}

		public void Remove(Garage value)  
		{
			base.Remove(value);
		}

		public Garage this[int index]
		{
			get
			{
				return (Garage) base.BaseGet(index);

			}
			set
			{
				base.BaseSet(index, value);
			}
		}

		public Garage this[String key]  
		{
			get
			{
				return (Garage) base.BaseGet(key);

			}
			set
			{
				base.BaseSet(key, value);
			}
		}
	}
}
