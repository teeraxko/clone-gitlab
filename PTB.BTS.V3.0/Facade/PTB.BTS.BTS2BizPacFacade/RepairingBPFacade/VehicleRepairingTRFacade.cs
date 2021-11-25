using System;
using System.Collections.Generic;
using System.Text;
using PTB.BTS.BTS2BizPacFlow.VehicleRepairingFlow;
using PTB.BTS.BTS2BizPacEntity;

namespace PTB.BTS.BTS2BizPacFacade.RepairingBPFacade
{
    public class VehicleRepairingTRFacade : VehicleRepairingBPFacade
    {
        public VehicleRepairingTRFacade() : base()
        {
            flowBP = new VehicleRepairingTRFlow();
            listBP = new BTS2BizPacList();
        }
    }

}
