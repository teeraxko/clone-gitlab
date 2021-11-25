using System;
using System.Collections.Generic;
using System.Text;

using Facade.PiFacade;

using PTB.BTS.BTS2BizPacFlow.BizPacImplementFlow;
using PTB.BTS.BTS2BizPacEntity;
using PTB.BTS.BTS2BizPacFlow.VehicleExcessFlow;

namespace PTB.BTS.BTS2BizPacFacade.ExcessBPFacade
{
    public class VehicleExcessBPFacade : BTS2BizPacConnectFacade
    {
        public VehicleExcessBPFacade() : base()
        {
            flowBP = new VehicleExcessBPFlow();
            listBP = new BTS2BizPacList();
        }
    }
}
