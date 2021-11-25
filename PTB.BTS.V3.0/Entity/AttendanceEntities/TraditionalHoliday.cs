using System;

using ictus.Common.Entity;
using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.AttendanceEntities
{
	public class TraditionalHoliday : EntityBase, IKey
	{
//		============================== Property ==============================
		private DateTime holidayDate = NullConstant.DATETIME;
		public DateTime	HolidayDate
		{
			set{holidayDate = value;}
			get{return holidayDate;}
		}

		private Description aDescription;
		public Description ADescription
		{
			set{aDescription = value;}
			get{return aDescription;}
		}

		private TraditionalHolidayPattern aTraditionalHolidayPattern;
		public TraditionalHolidayPattern ATraditionalHolidayPattern
		{
			set{aTraditionalHolidayPattern = value;}
			get{return aTraditionalHolidayPattern;}
		}

//		============================== Constructor ==============================
		public TraditionalHoliday():base()
		{
			aDescription = new Description();
		}

//		============================== Public Method ==============================
		public override string EntityKey
		{
			get
			{
				return holidayDate.ToShortDateString();
			}
		}
	}
}
