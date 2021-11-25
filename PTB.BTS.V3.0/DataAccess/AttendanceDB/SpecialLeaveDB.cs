using System;

using Entity.AttendanceEntities;
using Entity.CommonEntity;

using DataAccess.CommonDB;
using DataAccess.PiDB;

namespace DataAccess.AttendanceDB
{
	public class SpecialLeaveDB : DualFieldCompanyDBBase
	{
//		============================== Constructor ==============================
		public SpecialLeaveDB() : base()
		{
			tableName = "Special_Leave";
			codeColumnName = "Special_Leave_Code";
			descColumnNameEng = "English_Description";
			descColumnNameThai = "Thai_Description";
		}

        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new KindOfSpecialLeave();
		}
	}
}
