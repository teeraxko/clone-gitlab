using System;

using Entity.CommonEntity;

namespace Entity.AttendanceEntities
{
	public class PrivateLeave : LeaveBase
	{
//		============================== Property ==============================
		private LeaveReason aLeaveReason;
		public LeaveReason ALeaveReason
		{
			get{return aLeaveReason;}
			set{aLeaveReason = value;}
		}

//		============================== Constructor ==============================
		public PrivateLeave() : base()
		{
			aLeaveReason = new LeaveReason();
		}

//		============================== Public Method ==============================
		public override string EntityKey
		{
			get{return leaveDate.ToShortDateString();}
		}
	}
}
