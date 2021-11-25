using System;
using System.Collections.Generic;
using System.Text;

using PTB.BTS.BTS2BizPacFlow.ServiceStaffContractChargeFlow;
using PTB.BTS.BTS2BizPacEntity;

namespace PTB.BTS.BTS2BizPacFacade.ContractBPFacade
{
    public class OtherSSContractChargeBPFacade : BTS2BizPacConnectFacade
    {
        public OtherSSContractChargeBPFacade() : base()
        {
            flowBP = new ServiceStaffContractChargeBPFlow();
            listBP = new BTS2BizPacList();
        }
    }
}
