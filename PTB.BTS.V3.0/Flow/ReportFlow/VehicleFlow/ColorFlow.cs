using System;

using PTB.BTS.Common.Flow;

using DataAccess.VehicleDB;

namespace PTB.BTS.Vehicle.Flow
{
	public class ColorFlow : MTBFlowBase
	{
//  ================================Constructor=====================
		public ColorFlow() : base()
		{
			dbMTB = new ColorDB();
		}
	}
}
