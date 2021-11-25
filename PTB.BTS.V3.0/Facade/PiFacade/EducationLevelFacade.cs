using System;

using Entity.CommonEntity;

using PTB.BTS.PI.Flow;

using Facade.CommonFacade;

using ictus.Common.Entity;

namespace Facade.PiFacade
{
	public class EducationLevelFacade : MTBFacadeBase
	{
		#region -Private-
		//private bool disposed = false;
		#endregion -Private-

		//		============================== Property =================================

		//		============================== Constructor ==============================
		public EducationLevelFacade(): base()
		{
			DummyCode = "ZZ";
			flowMTB = new EducationLevelFlow();
			objList = new EducationLevelList();
		}
	}
}
