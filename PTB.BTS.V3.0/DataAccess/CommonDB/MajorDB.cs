using System;
using System.Text;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Entity.CommonEntity;

namespace DataAccess.CommonDB
{
	public class MajorDB : DualFieldDBBase
	{
//		============================== Constructor ==============================
		public MajorDB() : base()
		{
			tableName = "Major";
			codeColumnName = "Major_Code";
			descColumnNameThai = "Major_Thai_Name";
			descColumnNameEng = "Major_English_Name";	
		}

//		============================== Protected Method ==============================
		protected override string getOrderby()
		{
			StringBuilder stringBuilder = new StringBuilder(" ORDER BY ");
			stringBuilder.Append(descColumnNameEng);
			return stringBuilder.ToString();
		}

        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new Major();
		}
	}
}
