using System;

namespace Entity.VehicleEntities
{
    public class VendorList : ictus.Common.Entity.CompanyStuffBase
	{
//		============================== Constructor ==============================
        public VendorList(ictus.Common.Entity.Company company)
            : base(company)
		{}

//		============================== Public Method ==============================
		public void Add(Vendor value)
		{
			base.Add(value);
		}

		public void Remove(Vendor value)  
		{
			base.Remove(value);
		}

		public Vendor this[int index]
		{
			get
			{
				return (Vendor) base.BaseGet(index);

			}
			set
			{
				base.BaseSet(index, value);
			}
		}

		public Vendor this[String key]  
		{
			get
			{
				return (Vendor) base.BaseGet(key);

			}
			set
			{
				base.BaseSet(key, value);
			}
		}
	}
}
