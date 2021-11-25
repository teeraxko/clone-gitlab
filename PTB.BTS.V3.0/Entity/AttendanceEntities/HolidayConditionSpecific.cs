using System;

using ictus.Common.Entity.General;using ictus.Framework.ASC.Entity.DNF20;
using ictus.PIS.PI.Entity;

namespace Entity.AttendanceEntities
{
	public class HolidayConditionSpecific : EntityBase, IKey
	{
//		============================== Property ==============================
		private Employee aEmployee;
		public Employee AEmployee
		{
			get{return aEmployee;}
			set{aEmployee = value;}
		}

		private bool saturdayBreak;
		public bool SaturdayBreak
		{
			set{saturdayBreak = value;}
			get{return saturdayBreak;}
		}

		private bool sundayBreak;
		public bool SundayBreak
		{
			set{sundayBreak = value;}
			get{return sundayBreak;}
		}

		private TraditionalHolidayPattern aTraditionalHolidayPattern;
		public TraditionalHolidayPattern ATraditionalHolidayPattern
		{
			set{aTraditionalHolidayPattern = value;}
			get{return aTraditionalHolidayPattern;}
		}

//		============================== Constructor ==============================
		public HolidayConditionSpecific() : base()
		{
		}

//		============================== Public Method ==============================
		public override string EntityKey
		{
			get{return aEmployee.EntityKey;}
		}
	}
}
