using System;

using PTB.BTS.Common.Flow;

using DataAccess.VehicleDB;
using Entity.VehicleEntities;

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

