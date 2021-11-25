using System;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

using DataAccess.CommonDB;

namespace DataAccess.PiDB
{
	public class BloodGroupDB : SingleFieldDBBase
	{
		public BloodGroupDB() : base()
		{
			tableName = "Blood_Group";
			descColumnName = "Blood_Group";
		}

//		============================== Protected Method ==============================
        protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new BloodGroup();
		}
	}
}
