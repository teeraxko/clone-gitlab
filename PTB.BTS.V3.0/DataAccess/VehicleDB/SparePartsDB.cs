using System;
using System.Text;

using Entity.CommonEntity;
using Entity.VehicleEntities;

using DataAccess.CommonDB;
using DataAccess.PiDB;

namespace DataAccess.VehicleDB
{
	public class SparePartsDB : DualFieldCompanyDBBase
	{
//		============================== Constructor ==============================
		public SparePartsDB() : base()
		{
			tableName = "Spare_Parts";
			 codeColumnName = "Spare_Parts_Code";
			descColumnNameThai = "Thai_Name";
			descColumnNameEng = "English_Name";	
		}

		protected override string getOrderby()
		{
			StringBuilder stringBuilder = new StringBuilder(" ORDER BY ");
			stringBuilder.Append(descColumnNameThai);
			return stringBuilder.ToString();
		}

//		============================== Protected Method ==============================
        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new SpareParts();
		}
	}
}
