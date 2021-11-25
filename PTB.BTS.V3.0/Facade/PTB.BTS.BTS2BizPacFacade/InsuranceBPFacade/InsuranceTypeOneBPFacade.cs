using System;
using System.Collections.Generic;
using System.Text;

using Facade.PiFacade;

using PTB.BTS.BTS2BizPacFlow.BizPacImplementFlow;
using PTB.BTS.BTS2BizPacEntity;

namespace PTB.BTS.BTS2BizPacFacade.InsuranceBPFacade
{
    public class InsuranceTypeOneBPFacade : BTS2BizPacConnectFacade
    {
        public InsuranceTypeOneBPFacade() : base()
        {
            flowBP = new InsuranceTypeOneBPFlow();
            listBP = new BTS2BizPacList();
        }
    }
}
