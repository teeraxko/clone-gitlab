using System;

using Entity.ContractEntities;

using PTB.BTS.Contract.Flow;

using Facade.PiFacade;

namespace Facade.ContractFacade
{	
	public class ContractStatusFacade : MTBCompanyFacadeBase
	{
		#region - Private -
		private bool disposed = false;
		#endregion - Private -

//		============================== Constructor ==============================
		public ContractStatusFacade()
		{
			flowMTB = new ContractStatusFlow();
			objList = new ContractStatusList(GetCompany());
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