using System;

using DataAccess.ContractDB;

using PTB.BTS.PI.Flow;

namespace PTB.BTS.Contract.Flow
{
	public class ContractStatusFlow : MTBCompanyFlowBase
	{
		#region -Private-
		private bool disposed = false;
		#endregion -Private-

		public ContractStatusFlow()
		{
			dbMTB = new ContractStatusDB();
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