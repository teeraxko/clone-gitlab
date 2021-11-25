using System;

using Entity.CommonEntity;
using Entity.VehicleEntities;

using DataAccess.CommonDB;

namespace DataAccess.VehicleDB
{
	public class PoliceStationDB : SingleFieldDBBase
	{
		//		============================== Constructor ==============================
		public PoliceStationDB() : base()
		{
			tableName = "Police_Station";
			descColumnName = "Police_Station";
		}

		//		============================== Protected Method ==============================
        protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new PoliceStation();
		}
	}
}
