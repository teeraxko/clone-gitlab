using System;
using System.Collections.Generic;
using System.Text;
using PTB.BTS.BTS2BizPacFacade.InsuranceBPFacade;
using PTB.BTS.BTS2BizPacFlow.BizPacImplementFlow;
using PTB.BTS.BTS2BizPacEntity;

namespace PTB.BTS.BTS2BizPacFacade.InsuranceBPFacade
{
    public class InsuranceTypeOneTRFacade : InsuranceTypeOneBPFacade
    {
        public InsuranceTypeOneTRFacade() : base()
        {
            flowBP = new InsuranceTypeOneTRFlow();
            listBP = new BTS2BizPacList();
        }
    }
}
