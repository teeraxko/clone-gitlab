using System;
using System.Text;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Entity.CommonEntity;

namespace DataAccess.CommonDB
{
	public class InstituteDB : DualFieldDBBase
	{
//		============================== Constructor ==============================
		public InstituteDB() : base()
		{
			tableName = "Institute";
			codeColumnName = "Institute_Code";
			descColumnNameThai = "Institute_Thai_Name";
			descColumnNameEng = "Institute_English_Name";	
		}

//		============================== Protected Method ==============================
		protected override string getOrderby()
		{
			StringBuilder stringBuilder = new StringBuilder(" ORDER BY ");
			stringBuilder.Append(descColumnNameThai);
			return stringBuilder.ToString();
		}

        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new Institute();
		}
	}
}
