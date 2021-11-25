using System;
using System.Collections.Generic;
using System.Text;
using PTB.BTS.BTS2BizPacFlow.VehicleContractChargeFlow;
using PTB.BTS.BTS2BizPacEntity;

namespace PTB.BTS.BTS2BizPacFacade.ContractBPFacade
{
    public class VehicleSummaryIncomeFacade : VehicleContractChargeTRFacade
    {
        public VehicleSummaryIncomeFacade() : base()
        {
            flowBP = new VehicleContractChargeTRFlow();
            listBP = new BTS2BizPacList();
        }
    }
}
