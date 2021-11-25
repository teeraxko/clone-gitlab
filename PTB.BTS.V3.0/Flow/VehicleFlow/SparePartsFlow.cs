using System;

using DataAccess.VehicleDB;

using PTB.BTS.PI.Flow;

namespace PTB.BTS.Vehicle.Flow
{	
	public class SparePartsFlow : MTBCompanyFlowBase
	{
		#region -Private-
		private bool disposed = false;
		#endregion -Private-

		public SparePartsFlow() : base()
		{
			dbMTB = new SparePartsDB();
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