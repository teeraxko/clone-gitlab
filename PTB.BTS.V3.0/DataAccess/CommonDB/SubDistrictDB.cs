using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Entity.CommonEntity;

namespace DataAccess.CommonDB
{
	public class SubDistrictDB : SingleFieldDBBase
	{
//		============================== Constructor ==============================
		public SubDistrictDB() : base()
		{
			tableName = "Sub_District";
			descColumnName = "Sub_District";
		}

//		============================== Protected Method ==============================
        protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new SubDistrict();
		}
	}
}
