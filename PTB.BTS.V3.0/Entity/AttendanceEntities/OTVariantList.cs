using System;

using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
    public class OTVariantList : ictus.Common.Entity.CompanyStuffBase	
	{
//		============================== Constructor ==============================
        public OTVariantList(ictus.Common.Entity.Company company)
            : base(company)
		{}

//		============================== Public Method ==============================
		public void Add(OTVariant value)
		{
			base.Add(value);
		}

		public void Remove(OTVariant value)  
		{
			base.Remove(value);
		}

		public OTVariant this[int index]
		{
			get
			{
				return (OTVariant) base.BaseGet(index);
			}
			set
			{
				base.BaseSet(index, value);
			}
		}

		public OTVariant this[String key]  
		{
			get
			{
				return (OTVariant) base.BaseGet(key);
			}
			set
			{
				base.BaseSet(key, value);
			}
		}
	}
}