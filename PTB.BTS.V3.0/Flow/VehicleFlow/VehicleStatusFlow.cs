using System;
using System.Collections;

using Entity.VehicleEntities;

using DataAccess.VehicleDB;

using PTB.BTS.PI.Flow;
using PTB.BTS.Common.Flow;

namespace PTB.BTS.Vehicle.Flow
{	
	public class VehicleStatusFlow  : MTBCompanyFlowBase
	{
		#region - Private -
		private bool disposed = false;
		#endregion - Private -
//  ================================Constructor=====================
		public VehicleStatusFlow() : base()
		{
			dbMTB = new VehicleStatusDB();
		}

		#region IDisposable Members
		protected override void Dispose(bool disposing)
		{
			if(!this.disposed)
			{
				try
				{
					if(disposing)
					{
						// Dispose object here.
					}
					this.disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}
		#endregion
	}
}
