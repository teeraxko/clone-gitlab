using System;
using System.Collections.Generic;
using System.Text;
using PTB.BTS.BTS2BizPacFlow.VehicleContractChargeFlow;
using PTB.BTS.BTS2BizPacEntity;

namespace PTB.BTS.BTS2BizPacFacade.ContractBPFacade
{
    public class VehicleContractChargeTRFacade : VehicleContractChargeBPFacade
    {
        public VehicleContractChargeTRFacade() : base()
        {
            flowBP = new VehicleContractChargeTRFlow();
            listBP = new BTS2BizPacList();
        }
    }
}
