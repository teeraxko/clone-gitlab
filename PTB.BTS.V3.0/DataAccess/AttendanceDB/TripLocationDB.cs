using System;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using DataAccess.CommonDB;

namespace DataAccess.AttendanceDB
{
	public class TripLocationDB : SingleFieldDBBase
	{
//		============================== Constructor ==============================
		public TripLocationDB() : base()
		{
			tableName = "Province";
			descColumnName = "Province";
		}

//		============================== Protected Method ==============================
        protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new TripLocation();
		}
	}
}
