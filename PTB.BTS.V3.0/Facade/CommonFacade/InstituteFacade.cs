using System;

using Entity.CommonEntity;

using PTB.BTS.Common.Flow;

using ictus.Common.Entity;

namespace Facade.CommonFacade
{
	public class InstituteFacade : MTBFacadeBase
	{
		#region -Private-
		//private bool disposed = false;
		#endregion -Private-

		//		============================== Property =================================

		//		============================== Constructor ==============================
		public InstituteFacade(): base()
		{
			DummyCode = "ZZZ";
			flowMTB = new InstituteFlow();
			objList = new InstituteList();	
		}
	}
}
