using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Entity.CommonEntity;

namespace DataAccess.CommonDB
{
	public class StreetDB : SingleFieldDBBase
	{
//		============================== Constructor ==============================
		public StreetDB() : base()
		{
			tableName = "Street";
			descColumnName = "Street_Name";
		}

//		============================== Protected Method ==============================
        protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new Street();
		}
	}
}
