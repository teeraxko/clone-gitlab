using System;

using Entity.VehicleEntities;

using PTB.BTS.Vehicle.Flow;

using Facade.PiFacade;
using Facade.CommonFacade;

namespace Facade.VehicleFacade
{
	public class VehicleStatusFacade  : MTBCompanyFacadeBase
	{
		#region -Private -
		private bool disposed = false;
		#endregion -Private -

		//		============================== Property =================================

		//		============================== Constructor ==============================

		public VehicleStatusFacade()
		{
			flowMTB = new VehicleStatusFlow();
			objList = new VehicleStatusList(GetCompany());
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
