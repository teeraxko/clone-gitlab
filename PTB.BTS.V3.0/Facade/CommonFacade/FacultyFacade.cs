using System;

using Entity.CommonEntity;

using PTB.BTS.Common.Flow;

using ictus.Common.Entity;

namespace Facade.CommonFacade
{
	
	public class FacultyFacade : MTBFacadeBase
	{
		#region -Private-
		//private bool disposed = false;
		#endregion -Private-

		//		============================== Property =================================

		//		============================== Constructor ==============================
		public FacultyFacade(): base()
		{
			DummyCode = "ZZZ";
			flowMTB = new FacultyFlow();
			objList = new FacultyList();	
		}
	}
}
