using System;

using ictus.Common.Entity.General;

namespace Entity.ContractEntities
{
	public struct ContractCondition : IKey
	{
		public ContractStatus ContractStatus;

		public ContractType ContractType;

		#region IKey Members
			public string EntityKey
			{
				get
				{
					return ContractType.ToString();
				}
			}
		#endregion
	}
}
