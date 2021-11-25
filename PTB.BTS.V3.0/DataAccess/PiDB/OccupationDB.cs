using System;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

using DataAccess.CommonDB;

namespace DataAccess.PiDB
{
	public class OccupationDB : SingleFieldDBBase
	{
		public OccupationDB() : base()
		{
			tableName = "Occupation";
			descColumnName = "Occupation";
		}

//		============================== Protected Method ==============================
        protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new Occupation();
		}
	}
}
