using System;

using ictus.PIS.PI.Entity;

using PTB.BTS.PI.Flow;

using Facade.CommonFacade;

namespace Facade.PiFacade
{
	
	public class BloodGroupFacade : MTBFacadeBase
	{
		//		============================== Property =================================

		//		============================== Constructor ==============================
		public BloodGroupFacade(): base()
		{
			flowMTB = new BloodGroupFlow();
			objList = new BloodGroupList();
		}
	}
}
