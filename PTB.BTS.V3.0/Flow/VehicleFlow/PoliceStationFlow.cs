using System;

using PTB.BTS.Common.Flow;

using DataAccess.VehicleDB;

namespace PTB.BTS.Vehicle.Flow
{
	public class PoliceStationFlow : MTBFlowBase
	{
		public PoliceStationFlow() : base()
		{
			dbMTB = new PoliceStationDB();
		}
	}
}
