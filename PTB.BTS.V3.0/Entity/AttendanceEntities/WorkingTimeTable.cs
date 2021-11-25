using System;

using ictus.Common.Entity.General;using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.AttendanceEntities
{
	public class WorkingTimeTable : EntityBase, IKey
	{
//		============================== Property ==============================
		private string tableID = NullConstant.STRING;
		public string TableID
		{
			set{tableID = value;}
			get{return tableID;}
		}

		private string description = NullConstant.STRING;
		public string Description
		{
			set{description = value.Trim();}
			get{return description;}
		}

		private TimePeriod aWorkingTime;
		public TimePeriod AWorkingTime
		{
			set{aWorkingTime = value;}
			get{return aWorkingTime;}
		}

		private TimePeriod aBreakTime;
		public TimePeriod ABreakTime
		{
			set{aBreakTime = value;}
			get{return aBreakTime;}
		}

//		============================== Constructor ==============================
		public WorkingTimeTable(): base()
		{
			aWorkingTime = new TimePeriod();
			aBreakTime = new TimePeriod();
		}
	
//		============================== Public Method ==============================
		public override string EntityKey
		{
			get
			{return tableID;}
		}

		public override string  ToString()
		{
			return description;
		}
	}
}
