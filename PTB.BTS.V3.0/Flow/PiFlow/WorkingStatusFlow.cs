using System;

using DataAccess.PiDB;

using PTB.BTS.Common.Flow;

namespace PTB.BTS.PI.Flow
{
	public class WorkingStatusFlow  : MTBCompanyFlowBase
	{
		#region -Private-
		private bool disposed = false;
		#endregion -Private-

//		============================== Constructor ==============================
		public WorkingStatusFlow() : base()
		{
			dbMTB = new WorkingStatusDB();
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
