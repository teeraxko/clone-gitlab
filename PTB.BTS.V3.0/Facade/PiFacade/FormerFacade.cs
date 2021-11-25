using System;

using PTB.BTS.PI.Flow;

namespace Facade.PiFacade
{
	public class FormerFacade : PIFacade
	{
//		============================== Constructor ==============================
		public FormerFacade() : base()
		{
		}

//		============================== base method ==============================
		protected override void BaseNew()
		{
			flowPI = new FormerFlow(GetCompany());
		}
	}
}
