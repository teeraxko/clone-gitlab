using System;
using System.Collections.Generic;
using System.Text;
using PTB.BTS.BTS2BizPacFlow.ServiceStaffContractChargeFlow;
using PTB.BTS.BTS2BizPacEntity;

namespace PTB.BTS.BTS2BizPacFacade.ContractBPFacade
{
    public class OtherSSSummaryIncomeFacade : OtherSSContractChargeTRFacade
    {
        public OtherSSSummaryIncomeFacade() : base()
        {
            flowBP = new ServiceStaffContractChargeTRFlow();
            listBP = new BTS2BizPacList();
        }
    }
}
