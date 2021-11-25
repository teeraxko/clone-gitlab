using System;

using Entity.CommonEntity;
using ictus.PIS.PI.Entity;

namespace Entity.ContractEntities
{
    public class KindOfContractList : ictus.Common.Entity.CompanyStuffBase
	{
//		============================== Constructor ==============================
        public KindOfContractList(ictus.Common.Entity.Company value)
            : base(value)
		{}

//		============================== Public Method ==============================
		public void Add(KindOfContract value)
		{base.Add(value);}

		public void Remove(KindOfContract value)
		{base.Remove(value);}
	
		public KindOfContract this[int index]
		{
			get
			{return (KindOfContract) base.BaseGet(index);}
			set
			{base.BaseSet(index, value);}
		}

		public KindOfContract this[String key]  
		{
			get
			{return (KindOfContract) base.BaseGet(key);}
			set
			{base.BaseSet(key, value);}
		}
	}
}
