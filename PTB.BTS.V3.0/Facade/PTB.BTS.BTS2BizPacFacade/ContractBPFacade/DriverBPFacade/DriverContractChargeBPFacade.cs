using System;
using System.Collections.Generic;
using System.Text;

using PTB.BTS.BTS2BizPacFlow.DriverContractChargeFlow;
using PTB.BTS.BTS2BizPacEntity;

namespace PTB.BTS.BTS2BizPacFacade.ContractBPFacade
{
    public class DriverContractChargeBPFacade : BTS2BizPacConnectFacade
    {
        public DriverContractChargeBPFacade()
            : base()
        {
            flowBP = new DriverContractChargeBPFlow();
            listBP = new BTS2BizPacList();
        }
    }
}
