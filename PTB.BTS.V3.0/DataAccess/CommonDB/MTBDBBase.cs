using System;

using Entity.CommonEntity;

using DataAccess.CommonDB;

namespace DataAccess.CommonDB
{
	public abstract class MTBDBBase : DataAccessBase
	{
		protected MTBDBBase() : base()
		{
		}

		public abstract object GetMTB(string code);

		public abstract bool FillMTB(object value);

		public abstract bool FillMTBList(ictus.Common.Entity.General.ListBase value);

		public abstract bool InsertMTB(object value);

		public abstract bool UpdateMTB(object value);

		public abstract bool DeleteMTB(object value);

	}
}
