using System;
using System.Collections.Generic;
using System.Text;
using PTB.BTS.Common.Flow;
using Entity.ContractEntities;
using DataAccess.ContractDB;
using ictus.Common.Entity;

namespace Flow.ContractFlow
{
    public class ContractChargeDetailFlow : FlowBase
    {
        //=========================== Constructor ===========================
        public ContractChargeDetailFlow() : base()
        {
        }

        //=========================== Public method ===========================
        public static bool FillContractChargeDetailNoneBPNoList(ContractChargeDetailList listCharge)
        {
            using (ContractChargeDetailDB dbChargeDetail = new ContractChargeDetailDB())
            {
                return dbChargeDetail.FillContractChargeDetailNoneBPNoList(listCharge);                
            }
        }
    }
}
