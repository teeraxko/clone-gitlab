using System;

using ictus.PIS.PI.Entity; 
using Entity.CommonEntity;

namespace Entity.VehicleEntities
{
    public class VehicleStatusList : ictus.Common.Entity.CompanyStuffBase
	{
//		============================== Constructor ==============================
        public VehicleStatusList(ictus.Common.Entity.Company value)
            : base(value)
		{
		}
//		============================== Public Method ==============================
		public void Add(VehicleStatus value)
		{base.Add(value);}

		public void Remove(VehicleStatus value)
		{base.Remove(value);}

		public VehicleStatus this[int index]
		{
			get{return (VehicleStatus) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}
		public VehicleStatus this[String key]  
		{
			get{return (VehicleStatus) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
