using System;
using System.Text;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Entity.CommonEntity;

namespace DataAccess.CommonDB
{
	public class FacultyDB : DualFieldDBBase
	{
//		============================== Constructor ==============================
		public FacultyDB() : base()
		{
			tableName = "Faculty";
			codeColumnName = "Faculty_Code";
			descColumnNameThai = "Faculty_Thai_Name";
			descColumnNameEng = "Faculty_English_Name";	
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
			return new Faculty();
		}

	}
}
