using System;

using ictus.Common.Entity.General;

namespace Entity.AttendanceEntities
{
	public class TripLocationList : ListBase
	{
		//============================== Constructor ==============================
		public TripLocationList() : base()
		{
		}

		public void Add(TripLocation value)
		{base.Add(value);}

		public void Remove(TripLocation value)
		{base.Remove(value);}
  
		public TripLocation this[int index]
		{
			get{return (TripLocation) base.BaseGet(index);}
			set{base.BaseSet(index, value);}
		}

		public TripLocation this[String key]  
		{
			get{return (TripLocation) base.BaseGet(key);}
			set{base.BaseSet(key, value);}
		}
	}
}