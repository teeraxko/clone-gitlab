using System;

using PTB.BTS.Common.Flow;

using DataAccess.VehicleDB;

namespace PTB.BTS.Vehicle.Flow
{
	public class PlaceFlow : MTBFlowBase
	{
		public PlaceFlow() : base()
		{
			dbMTB = new PlaceDB();
		}
	}
}
