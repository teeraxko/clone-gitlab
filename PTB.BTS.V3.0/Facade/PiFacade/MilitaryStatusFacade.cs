using System;

using ictus.PIS.PI.Entity;

using PTB.BTS.PI.Flow;

using Facade.CommonFacade;

namespace Facade.PiFacade
{
	public class MilitaryStatusFacade : MTBFacadeBase
	{
		#region -Private-
		//private bool disposed = false;
		#endregion -Private-

		//		============================== Property =================================

		//		============================== Constructor ==============================
		public MilitaryStatusFacade(): base()
		{
			DummyCode = "Z";
			flowMTB = new MilitaryStatusFlow();
			objList = new MilitaryStatusList();
		}
	}
}
