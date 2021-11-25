using System;

using Entity.AttendanceEntities;

using DataAccess.AttendanceDB;

namespace DataAccess.AttendanceDB
{
	public class TrAnnualLeaveSummaryDB : LeaveSummaryDBBase
	{
//		============================== Constructor ==============================
		public TrAnnualLeaveSummaryDB() : base()
		{
			tableName = "Tr_Annual_Leave_Summary";
			viewName = "VEmployeeAnnualLeaveSummary";
		}

//		============================== Protected Method ==============================
		protected override LeaveSummaryBase getNew()
		{
			return new AnnualLeaveSummary();
		}
	}
}
