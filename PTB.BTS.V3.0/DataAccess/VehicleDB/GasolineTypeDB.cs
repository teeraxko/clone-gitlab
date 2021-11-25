using System;

using Entity.CommonEntity;
using Entity.VehicleEntities;

using DataAccess.CommonDB;

namespace DataAccess.VehicleDB
{
	public class GasolineTypeDB : DualFieldDBBase
	{
		//		============================== Constructor ==============================
		public GasolineTypeDB() : base()
		{
			tableName = "Gasoline_Type";
			codeColumnName = "Gasoline_Type";
			descColumnNameThai = "Thai_Description";
			descColumnNameEng = "English_Description";	
		}

		//		============================== Protected Method ==============================
        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new GasolineType();
		}
	}
}
