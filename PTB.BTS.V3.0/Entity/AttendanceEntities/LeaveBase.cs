using System;

using ictus.Common.Entity.General;using ictus.Framework.ASC.Entity.DNF20;
using Entity.CommonEntity;

namespace Entity.AttendanceEntities
{
	public class LeaveBase : EntityBase, IKey
	{
//		============================== Property ==============================
		protected DateTime leaveDate = NullConstant.DATETIME;
		public DateTime LeaveDate
		{
			get{return leaveDate;}
			set{leaveDate = value;}
		}

		protected LEAVE_PERIOD_TYPE periodStatus = LEAVE_PERIOD_TYPE.NULL;
		public LEAVE_PERIOD_TYPE PeriodStatus
		{
			get{return periodStatus;}
			set{periodStatus = value;}
		}

//		============================== Constructor ==============================
		protected LeaveBase() : base()
		{
		}

		protected LeaveBase(DateTime leaveDate) : base()
		{
			this.leaveDate = leaveDate;
		}

//		============================== Public Method ==============================
		public override string EntityKey
		{
			get{return leaveDate.ToShortDateString();}
		}
	}
}
