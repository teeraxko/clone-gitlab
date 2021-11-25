using System;

using Entity.CommonEntity;
using ictus.PIS.PI.Entity;

namespace Entity.VehicleEntities
{
    public class InsuranceCompanyList : ictus.Common.Entity.CompanyStuffBase
	{
        public InsuranceCompanyList(ictus.Common.Entity.Company value)
            : base(value)
		{
		}

		//============================== Public Method ==============================
		public void Add(InsuranceCompany value)
		{
			base.Add(value);
		}

		public void Remove(InsuranceCompany value)
		{
			base.Remove(value);
		}

		public InsuranceCompany this[int index]
		{
			get
			{
				return (InsuranceCompany) base.BaseGet(index);
			}
			set
			{
				base.BaseSet(index, value);
			}
		}

		public InsuranceCompany this[String key]
		{
			get
			{
				return (InsuranceCompany) base.BaseGet(key);
			}
			set
			{
				base.BaseSet(key, value);
			}
		}
	}
}