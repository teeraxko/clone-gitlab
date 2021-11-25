using System;
using System.Data;

using ictus.PIS.PI.Entity;

using DataAccess.PiDB;

using PTB.BTS.Common.Flow;
using ictus.Common.Entity;
namespace PTB.BTS.PI.Flow
{

	public class SpecialAllowanceFlow : FlowBase
	{
		#region Private
		private SpecialAllowanceDB dbSpecialAllowance;
		#endregion

        //================================ Constructor ================================
		public SpecialAllowanceFlow(): base()
		{
			dbSpecialAllowance = new SpecialAllowanceDB();
		}

        //================================ Public Method ================================
		public bool FillSpecialAllowance(SpecialAllowanceList value)
		{
			return dbSpecialAllowance.FillSpecialAllowanceList(value);
		}

        public bool InsertSpecialAllowance(SpecialAllowance value, Company company)
        {
            return dbSpecialAllowance.InsertSpecialAllowance(value, company);
        }

        public bool UpdateSpecialAllowance(SpecialAllowance value, Company company)
        {
            return dbSpecialAllowance.UpdateSpecialAllowance(value, company);
        }

        public bool DeleteSpecialAllowance(SpecialAllowance value, Company company)
        {
            return dbSpecialAllowance.DeleteSpecialAllowance(value, company);
        }
	}
}
