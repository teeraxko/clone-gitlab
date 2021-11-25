using System;

using Entity.CommonEntity;
using Entity.VehicleEntities;

using DataAccess.CommonDB;

namespace DataAccess.VehicleDB
{
	public class ModelTypeDB : DualFieldDBBase
	{
//		============================== Constructor ==============================
		public ModelTypeDB() : base()
		{
			tableName = "Model_Type";
			codeColumnName = "Model_Type";
			descColumnNameThai = "Thai_Description";
			descColumnNameEng = "English_Description";
		}

//		============================== Protected Method ==============================
        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new ModelType();
		}
	}
}
