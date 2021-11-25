using System;
using System.Collections.Generic;
using System.Text;
using PTB.BTS.BTS2BizPacFlow.DriverContractChargeFlow;
using PTB.BTS.BTS2BizPacEntity;

namespace PTB.BTS.BTS2BizPacFacade.ContractBPFacade
{
    public class DriverSummaryIncomeFacade : DriverContractChargeTRFacade
    {
        public DriverSummaryIncomeFacade() : base()
        {
            flowBP = new DriverSummaryIncomeFlow();
            listBP = new BTS2BizPacList();
        }
    }
}
