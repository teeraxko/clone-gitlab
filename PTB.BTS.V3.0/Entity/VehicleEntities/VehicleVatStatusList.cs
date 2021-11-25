using System;

using ictus.PIS.PI.Entity; 
using Entity.CommonEntity;

namespace Entity.VehicleEntities
{
    public class VehicleVatStatusList : ictus.Common.Entity.CompanyStuffBase
	{
//		============================== Constructor ==============================
        public VehicleVatStatusList(ictus.Common.Entity.Company value)
            : base(value)
		{
		}

//		============================== Public Method ==============================
		public void Add(VehicleVatStatus value)
		{base.Add(value);}

		public void Remove(VehicleVatStatus value)
		{base.Remove(value);}

		public VehicleVatStatus this[int index]
		{
			get{return (VehicleVatStatus) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}
		public VehicleVatStatus this[String key]  
		{
			get{return (VehicleVatStatus) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
