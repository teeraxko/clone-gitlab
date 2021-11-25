using System;

using Entity.CommonEntity;

using PTB.BTS.Common.Flow;

using ictus.Common.Entity;

namespace Facade.CommonFacade
{
	public class DistrictFacade : MTBFacadeBase
	{
//		============================== Constructor ==============================
		public DistrictFacade() : base()
		{
			flowMTB = new DistrictFlow();
			objList = new DistrictList();			
		}
	}
}
