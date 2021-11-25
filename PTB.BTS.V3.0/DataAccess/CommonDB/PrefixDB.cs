using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Entity.CommonEntity;

namespace DataAccess.CommonDB
{
	public class PrefixDB : SingleFieldDBBase
	{
//		============================== Constructor ==============================
		public PrefixDB() : base()
		{
			tableName = "Prefix";
			descColumnName = "Prefix";
		}

//		============================== Protected Method ==============================
        protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new Prefix();
		}
	}
}
