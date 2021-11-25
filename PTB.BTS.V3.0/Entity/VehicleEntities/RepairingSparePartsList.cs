using System;

using ictus.PIS.PI.Entity;

namespace Entity.VehicleEntities
{
    public class RepairingSparePartsList : ictus.Common.Entity.CompanyStuffBase
	{
//		============================== Constructor ==============================
        public RepairingSparePartsList(ictus.Common.Entity.Company value)
            : base(value)
		{}

//		============================== Public Method ==============================
		public void Add(RepairingSpareParts value)
		{base.Add(value);}

		public void Remove(RepairingSpareParts value)
		{base.Remove(value);}
	
		public RepairingSpareParts this[int index]
		{
			get
			{return (RepairingSpareParts) base.BaseGet(index);}
			set
			{base.BaseSet(index, value);}
		}

		public RepairingSpareParts this[String key]  
		{
			get
			{return (RepairingSpareParts) base.BaseGet(key);}
			set
			{base.BaseSet(key, value);}
		}
	}
}
