using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Entity.CommonEntity;

namespace DataAccess.CommonDB
{
	public class ProvinceDB : SingleFieldDBBase
	{
//		============================== Constructor ==============================
		public ProvinceDB() : base()
		{
			tableName = "Province";
			descColumnName = "Province";
		}

//		============================== Protected Method ==============================
		protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new Province();
		}
	}
}
