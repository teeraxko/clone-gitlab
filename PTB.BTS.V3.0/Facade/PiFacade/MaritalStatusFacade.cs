using System;

using ictus.PIS.PI.Entity;

using PTB.BTS.PI.Flow;

using Facade.CommonFacade;

namespace Facade.PiFacade
{
	public class MaritalStatusFacade : MTBFacadeBase
	{
		#region -Private-
		//private bool disposed = false;
		#endregion -Private-

		//		============================== Property =================================

		//		============================== Constructor ==============================
		public MaritalStatusFacade(): base()
		{
			flowMTB = new MaritalStatusFlow();
			objList = new MaritalStatusList();
		}
	}
}
