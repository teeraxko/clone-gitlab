using System;

using Entity.CommonEntity;
using Entity.VehicleEntities;

using DataAccess.CommonDB;

namespace DataAccess.VehicleDB
{
	public class BrandDB : DualFieldDBBase
	{
		//		============================== Constructor ==============================
		public BrandDB() : base()
		{
			tableName = "Brand";
			codeColumnName = "Brand_Code";
			descColumnNameThai = "Brand_Thai_Name";
			descColumnNameEng = "Brand_English_Name";	
		}

		//		============================== Protected Method ==============================
        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new Brand();
		}
	}
}
