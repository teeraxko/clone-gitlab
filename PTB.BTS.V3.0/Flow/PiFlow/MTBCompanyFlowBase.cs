using System;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using DataAccess.PiDB;

using PTB.BTS.Common.Flow;

namespace PTB.BTS.PI.Flow
{
	public abstract class MTBCompanyFlowBase : MTBFlowBase
	{
		private DualFieldCompanyDBBase dbDualFieldCompany
		{
			get
			{
				return (DualFieldCompanyDBBase)dbMTB;
			}
		}

		protected MTBCompanyFlowBase() : base()
		{
		}

		public  bool FillMTBData(CompanyStuffBase value)
		{
			return dbDualFieldCompany.FillMTBData(value);
		}

		public bool InsertMTB(Object value, Company aCompany)
		{
			return dbDualFieldCompany.InsertMTB(value, aCompany);
		}

		public bool UpdateMTB(Object value, Company aCompany)
		{
			return dbDualFieldCompany.UpdateMTB(value, aCompany);
		}

		public bool DeleteMTB(Object value, Company aCompany)
		{
			return dbDualFieldCompany.DeleteMTB(value, aCompany);
		}
	}
}
