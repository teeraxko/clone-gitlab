using System;

using Entity.CommonEntity;

using DataAccess.CommonDB;

namespace PTB.BTS.Common.Flow
{
	public abstract class MTBFlowBase : FlowBase
	{
		protected MTBDBBase dbMTB;

		protected MTBFlowBase() : base()
		{
		}

		public bool FillMTBList(ictus.Common.Entity.General.ListBase value)
		{
			return dbMTB.FillMTBList(value);
		}

		public bool FillMTB(object value)
		{
			return dbMTB.FillMTB(value);
		}

		public bool InsertMTB(object value)
		{
			return dbMTB.InsertMTB(value);
		}

		public bool UpdateMTB(object value)
		{
			return dbMTB.UpdateMTB(value);
		}

		public bool DeleteMTB(object value)
		{
			return dbMTB.DeleteMTB(value);
		}
	}
}