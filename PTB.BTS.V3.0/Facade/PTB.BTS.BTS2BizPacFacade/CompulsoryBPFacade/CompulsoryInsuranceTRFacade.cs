using System;
using System.Collections.Generic;
using System.Text;
using PTB.BTS.BTS2BizPacFacade.CompulsoryBPFacade;
using PTB.BTS.BTS2BizPacEntity;
using PTB.BTS.BTS2BizPacFlow.CompulsoryFlow;

namespace PTB.BTS.BTS2BizPacFacade.CompulsoryBPFacade
{
    public class CompulsoryInsuranceTRFacade : CompulsoryInsuranceBPFacade
    {
        public CompulsoryInsuranceTRFacade() : base()
        {
            flowBP = new CompulsoryInsuranceTRFlow();
            listBP = new BTS2BizPacList();
        }
    }
}
