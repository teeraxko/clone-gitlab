using System;

using Entity.CommonEntity;

using PTB.BTS.Common.Flow;

using ictus.Common.Entity;

namespace Facade.CommonFacade
{
	public class ProvinceFacade : MTBFacadeBase
	{
		#region -Private-
		//private bool disposed = false;
		#endregion -Private-

		//		============================== Property =================================

		//		============================== Constructor ==============================

		public ProvinceFacade(): base()
		{
			flowMTB = new ProvinceFlow();
			objList = new ProvinceList();	
		}
	}
}
