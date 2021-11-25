using System;

using Entity.CommonEntity;

namespace Entity.AttendanceEntities
{
	public class SickLeave : LeaveBase
	{
//		============================== Property ==============================
		private Disease aDisease;
		public Disease ADisease
		{
			get{return aDisease;}
			set{aDisease = value;}
		}

//		============================== Constructor ==============================
		public SickLeave(): base()
		{
			aDisease = new Disease();			
		}

//		============================== Public Method ==============================
		public override string EntityKey
		{
			get{return base.EntityKey;}
		}
	}
}
