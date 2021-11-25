using System;
using System.Collections.Generic;
using System.Text;

using PTB.BTS.BTS2BizPacFlow.VehicleContractChargeFlow;
using PTB.BTS.BTS2BizPacEntity;

namespace PTB.BTS.BTS2BizPacFacade.ContractBPFacade
{
    public class VehicleContractChargeBPFacade : BTS2BizPacConnectFacade
    {
        public VehicleContractChargeBPFacade()
            : base()
        {
            flowBP = new VehicleContractChargeBPFlow();
            listBP = new BTS2BizPacList();
        }
    }
}
