using System;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

using DataAccess.CommonDB;

namespace DataAccess.PiDB
{
	public class ReligionDB : SingleFieldDBBase
	{
		public ReligionDB() : base()
		{
			tableName = "Religion";
			descColumnName = "Religion";
		}

//		============================== Protected Method ==============================
        protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new Religion();
		}
	}
}
