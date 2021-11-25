using System;
using System.Collections.Generic;
using System.Text;
using PTB.BTS.BTS2BizPacFlow.DriverContractChargeFlow;
using PTB.BTS.BTS2BizPacEntity;

namespace PTB.BTS.BTS2BizPacFacade.ContractBPFacade
{
    public class DriverContractChargeTRFacade : DriverContractChargeBPFacade
    {
        public DriverContractChargeTRFacade() : base()
        {
            flowBP = new DriverContractChargeTRFlow();
            listBP = new BTS2BizPacList();
        }
    }
}
