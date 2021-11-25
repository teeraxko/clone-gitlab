using System;

using ictus.PIS.PI.Entity;

using PTB.BTS.PI.Flow;

using Facade.CommonFacade;

namespace Facade.PiFacade
{
	public class BankFacade : MTBFacadeBase
	{
//		============================== Constructor ==============================
		public BankFacade() : base()
		{
			DummyCode = "ZZZ";
			flowMTB = new BankFlow();
			objList = new BankList();
		}
	}
}
