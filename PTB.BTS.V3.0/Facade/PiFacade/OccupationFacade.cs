using System;

using ictus.PIS.PI.Entity;

using PTB.BTS.PI.Flow;

using Facade.CommonFacade;

namespace Facade.PiFacade
{
	public class OccupationFacade : MTBFacadeBase
	{	
		#region -Private-
		//private bool disposed = false;
		#endregion -Private-

		//		============================== Property =================================

		//		============================== Constructor ==============================

		public OccupationFacade(): base()
		{
			flowMTB = new OccupationFlow();
			objList = new OccupationList();
		}
	}
}
