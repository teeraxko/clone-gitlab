using System;

using Entity.CommonEntity;
using ictus.PIS.PI.Entity;

namespace Entity.ContractEntities
{
    public class ContractTypeList : ictus.Common.Entity.CompanyStuffBase
	{
//		============================== Constructor ==============================
        public ContractTypeList(ictus.Common.Entity.Company value)
            : base(value)
		{
		}

//		============================== Public Method ==============================
		public void Add(ContractType value)
		{
			base.Add(value);
		}

		public void Remove(ContractType value)
		{
			base.Remove(value);
		}

	
		public ContractType this[int index]
		{
			get
			{
				return (ContractType) base.BaseGet(index);
			}
			set
			{
				base.BaseSet(index, value);
			}
		}

		public ContractType this[String key]  
		{
			get
			{
				return (ContractType) base.BaseGet(key);
			}
			set
			{
				base.BaseSet(key, value);
			}
		}
	}
}
