using System;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using DataAccess.CommonDB;
using DataAccess.PiDB;

namespace DataAccess.AttendanceDB
{
	public class TraditionalHolidayPatternDB : DualFieldCompanyDBBase
	{
//		============================== Constructor ==============================
		public TraditionalHolidayPatternDB(): base()
		{
			tableName = "Traditional_Holiday_Pattern";
			codeColumnName = "Pattern_Code";
			descColumnNameEng = "English_Description";
			descColumnNameThai = "Thai_Description";
		}

        protected override ictus.Common.Entity.General.DualFieldBase getNew()
		{
			return new TraditionalHolidayPattern();
		}
	}
}
