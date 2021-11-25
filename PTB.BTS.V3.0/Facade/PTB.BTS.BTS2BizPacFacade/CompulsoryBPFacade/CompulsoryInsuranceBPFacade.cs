using System;
using System.Collections.Generic;
using System.Text;

using Facade.PiFacade;

using PTB.BTS.BTS2BizPacFlow.CompulsoryFlow;
using PTB.BTS.BTS2BizPacEntity;

namespace PTB.BTS.BTS2BizPacFacade.CompulsoryBPFacade
{
    public class CompulsoryInsuranceBPFacade : BTS2BizPacConnectFacade
    {
        public CompulsoryInsuranceBPFacade() : base()
        {
            flowBP = new CompulsoryInsuranceBPFlow();
            listBP = new BTS2BizPacList();
        }
    }
}
