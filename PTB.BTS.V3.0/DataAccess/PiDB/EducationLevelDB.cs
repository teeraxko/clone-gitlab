using System;
using System.Text;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Entity.CommonEntity;

using DataAccess.CommonDB;

namespace DataAccess.PiDB
{
	public class EducationLevelDB : DualFieldDBBase
	{
//		============================== Constructor ==============================
		public EducationLevelDB() : base()
		{
			tableName = "Education_Level";
			codeColumnName = "Education_Level_Code";
			descColumnNameThai = "Education_Level_Thai_Name";
			descColumnNameEng = "Education_Level_English_Name";	
		}

//		============================== Protected Method ==============================
		protected override string getOrderby()
		{
			StringBuilder stringBuilder = new StringBuilder(" ORDER BY ");
			stringBuilder.Append(descColumnNameThai);
			return stringBuilder.ToString();
		}
		protected override  ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new EducationLevel();
		}
	}
}
