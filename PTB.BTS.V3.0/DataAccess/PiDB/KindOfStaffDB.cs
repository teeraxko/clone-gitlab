using System;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

namespace DataAccess.PiDB
{
	public class KindOfStaffDB : DualFieldCompanyDBBase
	{
//		============================== Constructor ==============================
		public KindOfStaffDB() : base()
		{
			tableName = "Kind_Of_Staff";
			codeColumnName = "Kind_Of_Staff";
			descColumnNameThai = "Thai_Description";
			descColumnNameEng = "English_Description";	
		}

//		============================== Protected Method ==============================
        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new KindOfStaff();
		}
	}
}
