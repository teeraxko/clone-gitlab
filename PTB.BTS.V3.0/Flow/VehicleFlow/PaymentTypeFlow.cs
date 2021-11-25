using System;

using PTB.BTS.Common.Flow;

using DataAccess.VehicleDB;

namespace PTB.BTS.Vehicle.Flow
{
	public class PaymentTypeFlow : MTBFlowBase
	{
		public PaymentTypeFlow() : base()
		{
			dbMTB = new PaymentTypeDB();
		}
	}
}
