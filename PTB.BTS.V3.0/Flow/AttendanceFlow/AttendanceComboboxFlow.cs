using System;
using System.Collections;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using Entity.ContractEntities;
using Entity.AttendanceEntities;

using DataAccess.AttendanceDB;
using DataAccess.ContractDB;
using DataAccess.PiDB;

using PTB.BTS.Common.Flow;

namespace Flow.AttendanceFlow
{
	public class AttendanceComboboxFlow : FlowBase
	{
//		============================== Constructor ==============================
		public AttendanceComboboxFlow():base()
		{}

//		============================== Public Method ==============================
		public TripLocationList GetLocation(Company aCompany)
		{
			TripLocationDB dbTripLocation = new TripLocationDB();
			TripLocationList tripLocationList = new TripLocationList();

			return tripLocationList;
		}

		public bool InsertLocation(ref TripLocationList aTripLocationList, TripLocation aTripLocation)
		{
			TripLocationDB dbTripLocation = new TripLocationDB();

			if (dbTripLocation.InsertMTB(aTripLocation))
			{
				aTripLocationList.Add(aTripLocation);
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
