using System;

using Entity.CommonEntity;

using PTB.BTS.Common.Flow;

using ictus.Common.Entity;

namespace Facade.CommonFacade
{
	public class PrefixFacade : MTBFacadeBase
	{
		#region -Private-
		//private bool disposed = false;
		#endregion -Private-

		//		============================== Property =================================

		//		============================== Constructor ==============================

		public PrefixFacade(): base()
		{
			flowMTB = new PrefixFlow();
			objList = new PrefixList();	
		}
	}
}
