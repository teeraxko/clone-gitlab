using System;

using DataAccess.ContractDB;

using PTB.BTS.PI.Flow;

namespace PTB.BTS.Contract.Flow
{
	public class ContractTypeFlow : MTBCompanyFlowBase
	{
		#region -Private-
		private bool disposed = false;
		#endregion -Private-

		public ContractTypeFlow()
		{
			dbMTB = new ContractTypeDB();
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
