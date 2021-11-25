using System;

using PTB.BTS.Common.Flow;

using DataAccess.VehicleDB;

namespace PTB.BTS.Vehicle.Flow
{
	public class ModelTypeFlow : MTBFlowBase
	{
		public ModelTypeFlow() : base()
		{
			dbMTB = new ModelTypeDB();
		}
	}
}

