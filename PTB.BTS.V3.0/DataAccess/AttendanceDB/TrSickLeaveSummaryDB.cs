using System;

using Entity.AttendanceEntities;

using DataAccess.AttendanceDB;

namespace DataAccess.AttendanceDB
{
	public class TrSickLeaveSummaryDB : LeaveSummaryDBBase
	{
//		============================== Constructor ==============================
		public TrSickLeaveSummaryDB() : base()
		{
			tableName = "Tr_Sick_Leave_Summary";
			viewName = "VEmployeeSickLeaveSummary";
		}

//		============================== Protected Method ==============================
		protected override LeaveSummaryBase getNew()
		{
			return new SickLeaveSummary();
		}
	}
}
