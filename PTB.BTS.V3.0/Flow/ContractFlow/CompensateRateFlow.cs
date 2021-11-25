using System;
using System.Collections.Generic;
using System.Text;
using PTB.BTS.Common.Flow;
using DataAccess.ContractDB;
using Entity.ContractEntities;

namespace Flow.ContractFlow
{
    public class CompensateRateFlow : FlowBase
    {
        CompensateRateDB dbCompensateRate;

        //============================== Constructor ==============================
        public CompensateRateFlow()
            : base()
        {
            dbCompensateRate = new CompensateRateDB();
        }

        //============================== Public Method ============================
        public Compensate GetCompensate()
        {
            return dbCompensateRate.GetCompensate();
        }

        public bool MaintainCompensate(Compensate compensate)
        {
            return dbCompensateRate.MaintainCompensate(compensate);
        }
    }
}
