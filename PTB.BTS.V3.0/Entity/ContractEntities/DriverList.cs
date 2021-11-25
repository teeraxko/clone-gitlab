using System;

using Entity.CommonEntity;
using ictus.PIS.PI.Entity;
namespace Entity.ContractEntities
{
    public class DriverList : ictus.Common.Entity.CompanyStuffBase
	{
//		============================== Constructor ==============================
        public DriverList(ictus.Common.Entity.Company aCompany)
            : base(aCompany)
		{
		}
//		============================== Public Method ==============================
		public void Add(Driver aDriver)
		{
			base.Add(aDriver);
		}

		public void Remove(Driver aDriver)
		{
			base.Remove(aDriver);
		}

	
		public Driver this[int index]
		{
			get
			{
				return((Driver) base.BaseGet(index));
			}
			set
			{
				base.BaseSet(index, value);
			}
		}

		public Driver this[String key]  
		{
			get
			{
				return((Driver)base.BaseGet(key));
			}
			set
			{
				base.BaseSet(key, value);
			}
		}

	}
}
