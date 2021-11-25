using System;

using Entity.CommonEntity;
using Entity.VehicleEntities;

using DataAccess.CommonDB;
using DataAccess.PiDB;

namespace DataAccess.VehicleDB
{
	public class VehicleVatStatusDB : DualFieldCompanyDBBase
	{
//		============================== Constructor ==============================
		public VehicleVatStatusDB() : base()
		{
			tableName = "Vehicle_VAT_Status";
			codeColumnName = "Vehicle_VAT_Status";
			descColumnNameThai = "Thai_Description";
			descColumnNameEng = "English_Description";	
		}

//		============================== Protected Method ==============================
        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new VehicleVatStatus();
		}
	}
}
