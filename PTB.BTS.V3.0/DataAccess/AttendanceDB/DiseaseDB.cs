using System;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using DataAccess.CommonDB;

namespace DataAccess.AttendanceDB
{
	public class DiseaseDB : SingleFieldDBBase
	{
//		============================== Constructor ==============================
		public DiseaseDB() : base()
		{
			tableName = "Disease";
			descColumnName = "Disease_Name";
		}

//		============================== Protected Method ==============================
        protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new Disease();
		}
	}
}
