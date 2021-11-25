using System;

using ictus.PIS.PI.Entity;

using PTB.BTS.PI.Flow;

using Facade.PiFacade;
using Facade.CommonFacade;

namespace Facade.PiFacade
{
	public class PositionGroupFacade : MTBCompanyFacadeBase
	{
		#region -Private-
		private bool disposed = false;
		#endregion -Private-

		//		============================== Property =================================

		//		============================== Constructor ==============================
		public PositionGroupFacade(): base()
		{
			flowMTB = new PositionGroupFlow();
			objList = new PositionGroupList(GetCompany());
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
