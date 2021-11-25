using System;

using Entity.CommonEntity;
using Entity.VehicleEntities;

using DataAccess.CommonDB;
using DataAccess.PiDB;

namespace DataAccess.VehicleDB
{
	public class KindOfVehicleDB : DualFieldCompanyDBBase
	{
		//		============================== Constructor ==============================
		public KindOfVehicleDB() : base()
		{
			tableName = "Kind_Of_Vehicle";
			codeColumnName = "Kind_Of_Vehicle";
			descColumnNameThai = "Thai_Description";
			descColumnNameEng = "English_Description";	
		}

		//		============================== Protected Method ==============================
        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new KindOfVehicle();
		}
	}
}
