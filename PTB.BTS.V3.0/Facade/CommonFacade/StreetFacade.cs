using System;

using Entity.CommonEntity;

using PTB.BTS.Common.Flow;

using ictus.Common.Entity;

namespace Facade.CommonFacade
{
	public class StreetFacade : MTBFacadeBase
	{
		#region -Private-
		//private bool disposed = false;
		#endregion -Private-

//		============================== Constructor ==============================
		public StreetFacade(): base()
		{
			flowMTB = new StreetFlow();
			objList = new StreetList();	
		}
	}
}
