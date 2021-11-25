using System;

using ictus.Common.Entity.General;
using Entity.CommonEntity;

namespace Entity.ContractEntities
{
	public class CustomerGroup : DualFieldBase
	{
//		============================== Constructor ==============================
		public CustomerGroup() : base()
		{
		}

		public CustomerGroup(string customerGroupCode) : base()
		{
			code = customerGroupCode;
		}
	}
}
