using System;

using Entity.ContractEntities;

using PTB.BTS.Contract.Flow;

using Facade.PiFacade;

namespace Facade.ContractFacade
{
	
	public class KindOfContractFacade : MTBCompanyFacadeBase
	{
		#region -Private -
		private bool disposed = false;
		#endregion -Private -
		//		============================== Property =================================



		//		============================== Constructor ==============================
		public KindOfContractFacade()
		{
			flowMTB = new KindOfContractFlow();
			objList = new KindOfContractList(GetCompany());
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