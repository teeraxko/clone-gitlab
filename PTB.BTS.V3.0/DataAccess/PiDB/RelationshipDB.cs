using System;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

using DataAccess.CommonDB;

namespace DataAccess.PiDB
{
	public class RelationshipDB : SingleFieldDBBase
	{
		public RelationshipDB() : base()
		{
			tableName = "Relationship";
			descColumnName = "Relationship";
		}

//		============================== Protected Method ==============================
        protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new Relationship();
		}
	}
}
