using System;

namespace PTB.BTS.Common.Flow
{
	public abstract class FlowBase : IDisposable
	{
		#region - Private - 
			private bool disposed = false;
		#endregion

//		============================== Property ==============================

//		============================== Constructor ==============================
		protected FlowBase()
		{
		}

		#region IDisposable Members
			public void Dispose()
			{
				Dispose(true);
				GC.SuppressFinalize(this);
			}

			protected virtual void Dispose(bool disposing)
			{
				if(!this.disposed)
				{
					if(disposing)
					{
					}
				}
				disposed = true;
			}

			~FlowBase()
			{
				Dispose(false);
			}
		#endregion
	}
}
