using System;

using PTB.BTS.Common.Flow;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using DataAccess.PiDB;

namespace PTB.BTS.PI.Flow
{
	public class CompanyFlow : FlowBase 
	{
		#region - Private -
		private CompanyDB dbCompany;
		private bool disposed = false;
		#endregion

//	============================== Constructor ==============================
		public CompanyFlow(): base()
		{
			dbCompany = new CompanyDB();	
		}
 
//  ================================public Method=====================
		public bool FillCompany(ref Company value)
		{
			return dbCompany.FillCompany(ref value);
		}

        public bool FillCompany(ref CompanyInfo value)
        {
            return dbCompany.FillCompany(ref value);
        }

		public bool InsertCompany(CompanyInfo value)
		{
			return dbCompany.InsertCompany(value);
		}

        public bool UpdateCompany(CompanyInfo value)
		{
			return dbCompany.UpdateCompany(value);
		}

		#region IDisposable Members
		protected override void Dispose(bool disposing)
		{
			if(!this.disposed)
			{
				try
				{
					if(disposing)
					{
						
					}
					this.disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}
		#endregion

	}
}
