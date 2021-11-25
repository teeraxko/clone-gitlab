using System;

using Entity.VehicleEntities;

using PTB.BTS.Vehicle.Flow;

using Facade.CommonFacade;

namespace Facade.VehicleFacade
{	
	public class GasolineTypeFacade : MTBFacadeBase
	{
		#region -Private-
		private bool disposed = false;
		#endregion -Private-

		//		============================== Property =================================

		//		============================== Constructor ==============================
		public GasolineTypeFacade() : base()
		{
			flowMTB = new GasolineTypeFlow();
			objList = new GasolineTypeList();
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
