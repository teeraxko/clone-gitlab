using System;

using ictus.PIS.PI.Entity;

using PTB.BTS.PI.Flow;

using Facade.CommonFacade;

namespace Facade.PiFacade
{
	
	public class ReligionFacade : MTBFacadeBase
	{
		#region -Private-
		//private bool disposed = false;
		#endregion -Private-

		//		============================== Property =================================

		//		============================== Constructor ==============================

		public ReligionFacade(): base()
		{
			flowMTB = new ReligionFlow();
			objList = new ReligionList();
		}
	}
}
