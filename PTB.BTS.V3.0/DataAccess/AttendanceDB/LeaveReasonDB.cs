using System;

using DataAccess.CommonDB;
using Entity.AttendanceEntities;

using Entity.CommonEntity;

namespace DataAccess.AttendanceDB
{
	public class LeaveReasonDB : SingleFieldDBBase
	{
//		============================== Constructor ==============================
		public LeaveReasonDB() : base()
		{
			tableName = "Leave_Reason";
			descColumnName = "Leave_Reason";
		}

//		============================== Protected Method ==============================
        protected override ictus.Common.Entity.General.SingleFieldBase getNew()
		{
			return new LeaveReason();
		}
	}
}
