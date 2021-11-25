using System;

using ictus.PIS.PI.Entity;

using PTB.BTS.PI.Flow;

using Facade.CommonFacade;

namespace Facade.PiFacade
{
	public class KindOfStaffFacade : MTBCompanyFacadeBase
	{
		#region -Private-
		//private bool disposed = false;
		#endregion -Private-

		//		============================== Property =================================

		//		============================== Constructor ==============================
		public KindOfStaffFacade(): base()
		{
			flowMTB = new KindOfStaffFlow();
			objList = new KindOfStaffList(GetCompany());
		}
	}
}
