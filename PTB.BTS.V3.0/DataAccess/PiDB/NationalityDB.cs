using System;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

using DataAccess.CommonDB;

namespace DataAccess.PiDB
{
	public class NationalityDB : SingleFieldDBBase
	{
//		============================== Constructor ==============================
		public NationalityDB() : base()
		{
			tableName = "Nationality";
			descColumnName = "Nationality";
		}

//		============================== Protected Method ==============================
        protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new Nationality();
		}
	}
}
