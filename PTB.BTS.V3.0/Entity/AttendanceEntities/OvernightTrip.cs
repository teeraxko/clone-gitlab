using System;

using ictus.Common.Entity.General;

namespace Entity.AttendanceEntities
{
	public class OvernightTrip : TripBase,IKey
	{
//		============================== Constructor ==============================
		public OvernightTrip() : base()
		{
		}

//		============================== Private Method ==============================
		private bool validLocationName(OvernightTrip value)
		{
			return (this.aTripLocation.Name == value.aTripLocation.Name);
		}

		private bool validFromDate(OvernightTrip value)
		{
			return (this.aPeriod.From == value.aPeriod.From);
		}

		private bool validToDate(OvernightTrip value)
		{
			return (this.aPeriod.To == value.aPeriod.To);
		}
//		============================== Public Method ==============================
		public new string EntityKey
		{
			get
			{
				return this.aPeriod.From.ToShortDateString() + this.aPeriod.To.ToShortDateString() + aTripLocation.EntityKey;
			}
		}

		public bool Equals(OvernightTrip value)
		{
			return (validLocationName(value) && validFromDate(value) && validToDate(value));
		}

	}
}
