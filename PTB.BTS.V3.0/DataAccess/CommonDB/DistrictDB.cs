using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Entity.CommonEntity;

namespace DataAccess.CommonDB
{
	public class DistrictDB : SingleFieldDBBase
	{
//		============================== Constructor ==============================
		public DistrictDB() : base()
		{
			tableName = "District";
			descColumnName = "District";
		}

//		============================== Protected Method ==============================
        protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new District();
		}
	}
}
