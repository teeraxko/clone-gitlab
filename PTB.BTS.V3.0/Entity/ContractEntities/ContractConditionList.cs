using System;

using Entity.CommonEntity;

namespace Entity.ContractEntities
{
	public class ContractConditionList : ictus.Common.Entity.General.ListBase
	{
		public ContractConditionList()
		{
		}

		public void Add(ContractCondition value)
		{base.Add(value);}

		public void Remove(ContractCondition value)
		{base.Remove(value);}
	
		public ContractCondition this[int index]
		{
			get{return (ContractCondition) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public ContractCondition this[String key]  
		{
			get{return (ContractCondition)base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}
