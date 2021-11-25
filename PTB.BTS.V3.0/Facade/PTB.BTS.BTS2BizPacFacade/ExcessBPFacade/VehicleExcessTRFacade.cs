using System;
using System.Collections.Generic;
using System.Text;
using PTB.BTS.BTS2BizPacFlow.VehicleExcessFlow;
using PTB.BTS.BTS2BizPacEntity;

namespace PTB.BTS.BTS2BizPacFacade.ExcessBPFacade
{
    public class VehicleExcessTRFacade : VehicleExcessBPFacade
    {
        public VehicleExcessTRFacade() : base()
        {
            flowBP = new VehicleExcessTRFlow();
            listBP = new BTS2BizPacList();
        }
    }
}
