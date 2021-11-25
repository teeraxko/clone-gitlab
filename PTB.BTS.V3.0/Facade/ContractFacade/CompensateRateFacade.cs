using System;
using System.Collections.Generic;
using System.Text;
using Facade.CommonFacade;
using Flow.ContractFlow;
using Entity.ContractEntities;

namespace Facade.ContractFacade
{
    public class CompensateRateFacade : FacadeBase
    {
        private CompensateRateFlow flowCompensateRate;

        //============================== Constructor ==============================
        public CompensateRateFacade()
            : base()
        {
            flowCompensateRate = new CompensateRateFlow();
        }

        //============================== Public method ==============================
        public Compensate GetCompensate()
        {
            return flowCompensateRate.GetCompensate();
        }

        public bool MaintainCompensate(Compensate compensate)
        {
            return flowCompensateRate.MaintainCompensate(compensate);
        }
    }
}
