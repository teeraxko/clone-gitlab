using System;

using Entity.CommonEntity;

using PTB.BTS.Vehicle.Flow;

using Facade.CommonFacade;

using ictus.Common.Entity;

namespace Facade.VehicleFacade
{
	public class PaymentTypeFacade : MTBFacadeBase
	{
		#region -Private-
		private bool disposed = false;
		#endregion -Private-

		//		============================== Property =================================

		//		============================== Constructor ==============================

		public PaymentTypeFacade() : base()
		{
			flowMTB = new PaymentTypeFlow();
			objList = new PaymentTypeList();
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
