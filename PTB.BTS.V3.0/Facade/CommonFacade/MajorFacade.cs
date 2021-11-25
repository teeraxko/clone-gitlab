using System;

using Entity.CommonEntity;

using PTB.BTS.Common.Flow;

using ictus.Common.Entity;

namespace Facade.CommonFacade
{
	public class MajorFacade : MTBFacadeBase
	{
		#region -Private-
		//private bool disposed = false;
		#endregion -Private-

		//		============================== Property =================================

		//		============================== Constructor ==============================
		public MajorFacade(): base()
		{
			DummyCode = "ZZZ";
			flowMTB = new MajorFlow();
			objList = new MajorList();	
		}
	}
}
