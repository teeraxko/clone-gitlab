using System;

using ictus.PIS.PI.Entity;

namespace Entity.VehicleEntities
{
    public class VehicleTaxList : ictus.Common.Entity.CompanyStuffBase
	{
//		============================== Constructor =============================
        public VehicleTaxList(ictus.Common.Entity.Company value)
            : base(value)
		{
		}

//		============================== Public Method ==============================
		public void Add(VehicleTax value)
		{base.Add(value);}

		public void Remove(VehicleTax value)  
		{base.Remove(value);}

		public VehicleTax this[int index]
		{
			get{return (VehicleTax) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public VehicleTax this[String key]  
		{
			get{return (VehicleTax) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
