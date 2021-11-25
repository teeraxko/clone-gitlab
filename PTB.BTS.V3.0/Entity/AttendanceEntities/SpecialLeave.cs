using System;

using Entity.CommonEntity;

namespace Entity.AttendanceEntities
{
	public class SpecialLeave : LeaveBase
	{
//		============================== Property ==============================
		private KindOfSpecialLeave aKindOfSpecialLeave;
		public KindOfSpecialLeave AKindOfSpecialLeave
		{
			get{return aKindOfSpecialLeave;}
			set{aKindOfSpecialLeave = value;}
		}

//		============================== Constructor ==============================
		public SpecialLeave() : base()
		{
			aKindOfSpecialLeave = new KindOfSpecialLeave();
		}

//		============================== Public Method ==============================
		public override string EntityKey
		{
			get{return base.EntityKey;}
		}
	}
}
