using System;

using PTB.BTS.Common.Flow;

using DataAccess.PiDB;

namespace PTB.BTS.PI.Flow
{
	public class BankFlow : MTBFlowBase
	{
//		============================== Constructor ==============================
		public BankFlow() : base()
		{
			dbMTB = new BankDB();
		}
	}
}
