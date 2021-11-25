using System;

using ictus.PIS.PI.Entity;

namespace Facade.CommonFacade
{
	public class FacadeBase : IDisposable
	{
		#region - Private - 
			private bool disposed = false;
		#endregion

//		============================== Property ==============================

//		============================== Constructor ==============================
		protected FacadeBase() : base()
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
                    this.OnDisposeObject();
				}
			}
			disposed = true;
		}

		~FacadeBase()
		{
			Dispose(false);
		}
	    #endregion

        #region Virtual Members

        /// <summary>
        /// Virtual method to do something on dispose object
        /// </summary>
        protected virtual void OnDisposeObject(){ }

        #endregion
    }
}
