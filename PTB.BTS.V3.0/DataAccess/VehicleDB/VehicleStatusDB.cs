using System;

using Entity.CommonEntity;
using Entity.VehicleEntities;

using DataAccess.CommonDB;
using DataAccess.PiDB;

namespace DataAccess.VehicleDB
{
	public class VehicleStatusDB : DualFieldCompanyDBBase
	{
		//		============================== Constructor ==============================
		public VehicleStatusDB() : base()
		{
			tableName = "Vehicle_Status";
			codeColumnName = "Vehicle_Status";
			descColumnNameThai = "Thai_Description";
			descColumnNameEng = "English_Description";	
		}

		//		============================== Protected Method ==============================
        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new VehicleStatus();
		}
	}
}
