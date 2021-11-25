using System;
using System.Collections.Generic;
using System.Text;
using PTB.BTS.BTS2BizPacFlow.ServiceStaffContractChargeFlow;
using PTB.BTS.BTS2BizPacEntity;

namespace PTB.BTS.BTS2BizPacFacade.ContractBPFacade
{
    public class OtherSSContractChargeTRFacade : OtherSSContractChargeBPFacade
    {
        public OtherSSContractChargeTRFacade() : base()
        {
            flowBP = new ServiceStaffContractChargeTRFlow();
            listBP = new BTS2BizPacList();
        }
    }
}
