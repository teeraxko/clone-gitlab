using System;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

using DataAccess.CommonDB;

namespace DataAccess.PiDB
{
	public class MaritalStatusDB : DualFieldDBBase
	{
//		============================== Constructor ==============================
		public MaritalStatusDB() : base()
		{
			tableName = "Marital_Status";
			codeColumnName = "Marital_Status";
			descColumnNameThai = "Thai_Description";
			descColumnNameEng = "English_Description";	
		}

//		============================== Protected Method ==============================
        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new MaritalStatus();
		}
	}
}
