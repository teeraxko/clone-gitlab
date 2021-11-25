using System;

using Entity.ContractEntities;

using PTB.BTS.Contract.Flow;

using Facade.CommonFacade;

namespace Facade.ContractFacade
{
	public class ContractCancelReasonFacade : MTBFacadeBase
	{
		public ContractCancelReasonFacade(): base()
		{
			flowMTB = new ContractCancelReasonFlow();
			objList = new ContractCancelReasonList();
		}
	}
}
