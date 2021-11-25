using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using DataAccess.PiDB;

namespace PTB.BTS.PI.Flow
{
	public class FormerFlow : PIFlow
	{
		public FormerFlow(Company value) : base(value)
		{
		}

		protected override void BaseNew(Company value)
		{
			dbTransaction = new FormerTransactionDB(value);
		}

		public override bool Delete()
		{
			return false;
		}
	}
}
