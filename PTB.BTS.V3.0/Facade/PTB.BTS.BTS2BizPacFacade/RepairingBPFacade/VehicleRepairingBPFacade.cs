using System;
using System.Collections.Generic;
using System.Text;

using Facade.PiFacade;

using PTB.BTS.BTS2BizPacEntity;
using PTB.BTS.BTS2BizPacFlow.VehicleRepairingFlow;

namespace PTB.BTS.BTS2BizPacFacade.RepairingBPFacade
{
    public class VehicleRepairingBPFacade : BTS2BizPacConnectFacade
    {
        public VehicleRepairingBPFacade() : base()
        {
            flowBP = new VehicleRepairingBPFlow();
            listBP = new BTS2BizPacList();
        }
    }
}
