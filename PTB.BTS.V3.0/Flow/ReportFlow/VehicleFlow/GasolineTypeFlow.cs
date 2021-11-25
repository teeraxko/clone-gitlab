using System;

using PTB.BTS.Common.Flow;

using DataAccess.VehicleDB;

namespace PTB.BTS.Vehicle.Flow
{	
	public class GasolineTypeFlow : MTBFlowBase
	{
		public GasolineTypeFlow() : base()
		{
			dbMTB = new GasolineTypeDB();
		}
	}
}
