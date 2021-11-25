using System;

using Entity.CommonEntity;
using Entity.VehicleEntities;

using DataAccess.CommonDB;

namespace DataAccess.VehicleDB
{
	public class PlaceDB : SingleFieldDBBase
	{
		//		============================== Constructor ==============================
		public PlaceDB() : base()
		{
			tableName = "Place";
			descColumnName = "Place";
		}

		//		============================== Protected Method ==============================
        protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new Place();
		}
	}
}
