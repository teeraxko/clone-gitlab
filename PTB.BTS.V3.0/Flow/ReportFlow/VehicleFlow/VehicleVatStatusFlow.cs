using System;

using DataAccess.VehicleDB;

using PTB.BTS.PI.Flow;
using PTB.BTS.Common.Flow;

namespace PTB.BTS.Vehicle.Flow
{	
	public class VehicleVatStatusFlow  : MTBCompanyFlowBase
	{
		#region -Private-
		private bool disposed = false;
		#endregion -Private-

		public VehicleVatStatusFlow() : base()
		{
			dbMTB = new VehicleVatStatusDB();
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