using System;

using ictus.Common.Entity.General;using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.AttendanceEntities
{
	public abstract class TripBase : EntityBase, IKey
	{
//		============================== Property ==============================
		protected TripLocation aTripLocation;
		public TripLocation ATripLocation
		{
			get
			{return aTripLocation;}
			set
			{aTripLocation = value;}
		}

		protected TimePeriod aPeriod;
		public TimePeriod APeriod
		{
			get
			{return aPeriod;}
			set
			{aPeriod = value;}
		}

//		============================== Constructor ==============================
		protected TripBase(): base()
		{
			aTripLocation = new TripLocation();
			aPeriod = new TimePeriod();
		}

//		============================== Public Method ==============================
		public override string EntityKey
		{
			get
			{
				return aTripLocation.EntityKey + aPeriod.From.ToShortDateString() + aPeriod.To.ToShortDateString();
			}
		}
	}
}
