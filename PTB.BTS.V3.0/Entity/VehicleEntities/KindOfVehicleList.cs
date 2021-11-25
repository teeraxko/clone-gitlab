using System;

using ictus.PIS.PI.Entity; 
using Entity.CommonEntity;

namespace Entity.VehicleEntities
{
    public class KindOfVehicleList : ictus.Common.Entity.CompanyStuffBase
	{
//		============================== Constructor ==============================
        public KindOfVehicleList(ictus.Common.Entity.Company value)
            : base(value)
		{
		}

//		============================== Public Method ==============================
		public void Add(KindOfVehicle value)
		{
			base.Add(value);
		}

		public void Remove(KindOfVehicle value)
		{
			base.Remove(value);
		}
		public KindOfVehicle this[int index]
		{
			get
			{
				return (KindOfVehicle) base.BaseGet(index);
			}
			set
			{
				base.BaseSet(index, value);
			}
		}
		public KindOfVehicle this[String key]  
		{
			get
			{
				return (KindOfVehicle) base.BaseGet(key);
			}
			set
			{
				base.BaseSet(key, value);
			}
		}
	}
}
