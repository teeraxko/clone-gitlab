using System;

using ictus.PIS.PI.Entity;

using PTB.BTS.PI.Flow;

using Facade.CommonFacade;

namespace Facade.PiFacade
{
	public class NationalityFacade : MTBFacadeBase
	{
		#region -Private-
		//private bool disposed = false;
		#endregion -Private-

		//		============================== Property =================================

		//		============================== Constructor ==============================
		public NationalityFacade(): base()
		{
			flowMTB = new NationalityFlow();
			objList = new NationalityList();
		}
	}
}
