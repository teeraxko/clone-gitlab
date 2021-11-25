using System;

using Entity.AttendanceEntities;

using DataAccess.AttendanceDB;

namespace DataAccess.AttendanceDB
{
	public class TrPrivateLeaveSummaryDB : LeaveSummaryDBBase
	{
//		============================== Constructor ==============================
		public TrPrivateLeaveSummaryDB() : base()
		{
			tableName = "Tr_Private_Leave_Summary";
			viewName = "VEmployeePrivateLeaveSummary";
		}

//		============================== Protected Method ==============================
		protected override LeaveSummaryBase getNew()
		{
			return new PrivateLeaveSummary();
		}
	}
}
