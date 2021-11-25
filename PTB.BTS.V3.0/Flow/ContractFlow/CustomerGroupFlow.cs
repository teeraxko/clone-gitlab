using System;

using DataAccess.ContractDB;

using PTB.BTS.PI.Flow;
using PTB.BTS.Common.Flow;

namespace PTB.BTS.Contract.Flow
{	
	public class CustomerGroupFlow : MTBCompanyFlowBase
	{
		#region -Private-
		private bool disposed = false;
		#endregion -Private-

		public CustomerGroupFlow() : base()
		{
			dbMTB = new CustomerGroupDB();
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
