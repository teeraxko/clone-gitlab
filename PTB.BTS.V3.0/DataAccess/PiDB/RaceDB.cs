using System;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

using DataAccess.CommonDB;

namespace DataAccess.PiDB
{
	public class RaceDB : SingleFieldDBBase
	{
		public RaceDB() : base()
		{
			tableName = "Race";
			descColumnName = "Race";
		}

//		============================== Protected Method ==============================
        protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new Race();
		}
	}
}
