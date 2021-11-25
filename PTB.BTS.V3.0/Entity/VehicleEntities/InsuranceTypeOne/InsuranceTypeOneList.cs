using System;

using ictus.Common.Entity;
using ictus.PIS.PI.Entity;

namespace Entity.VehicleEntities
{
    public class InsuranceTypeOneList : CompanyStuffBase
	{
        public InsuranceTypeOneList(ictus.Common.Entity.Company value)
            : base(value)
		{
		}

		//============================== Public Method ==============================
		public void Add(InsuranceTypeOne value)
		{
			base.Add(value);
		}

		public void Remove(InsuranceTypeOne value)
		{
			base.Remove(value);
		}

		public InsuranceTypeOne this[int index]
		{
			get
			{
				return (InsuranceTypeOne) base.BaseGet(index);
			}
			set
			{
				base.BaseSet(index, value);
			}
		}

		public InsuranceTypeOne this[String key]
		{
			get
			{
				return (InsuranceTypeOne) base.BaseGet(key);
			}
			set
			{
				base.BaseSet(key, value);
			}
		}
	}
}
