using System;

using Entity.VehicleEntities;

using PTB.BTS.Vehicle.Flow;

using Facade.CommonFacade;

namespace Facade.VehicleFacade
{
	public class BrandFacade : MTBFacadeBase
	{
		#region -Private-
		private bool disposed = false;
		#endregion -Private-

		//		============================== Property =================================



		//		============================== Constructor ==============================
		public BrandFacade() : base()
		{
			flowMTB = new BrandFlow();
			objList = new BrandList();
		}
		//		============================== Private Method ===========================

		//		============================== Public Method ============================

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
