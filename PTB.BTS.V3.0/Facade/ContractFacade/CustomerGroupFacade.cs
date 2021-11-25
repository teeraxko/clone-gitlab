using System;

using Entity.ContractEntities;

using PTB.BTS.Contract.Flow;

using Facade.PiFacade;
using Facade.CommonFacade;

namespace Facade.ContractFacade
{
	public class CustomerGroupFacade : MTBCompanyFacadeBase
	{
		#region -Private-
		private bool disposed = false;
		#endregion -Private-

		//		============================== Property =================================

		//		============================== Constructor ==============================
		public CustomerGroupFacade(): base()
		{
			DummyCode = "ZZ";
			flowMTB = new CustomerGroupFlow();
			objList = new CustomerGroupList(GetCompany());
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