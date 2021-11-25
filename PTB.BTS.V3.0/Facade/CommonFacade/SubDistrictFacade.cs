using System;

using Entity.CommonEntity;

using PTB.BTS.Common.Flow;

using ictus.Common.Entity;

namespace Facade.CommonFacade
{
	public class SubDistrictFacade : MTBFacadeBase
	{
		#region -Private-
		//private bool disposed = false;
		#endregion -Private-

//		============================== Property =================================

//		============================== Constructor ==============================
		public SubDistrictFacade(): base()
		{
			flowMTB = new SubDistrictFlow();
			objList = new SubDistrictList();	
	
		}
	}
}
