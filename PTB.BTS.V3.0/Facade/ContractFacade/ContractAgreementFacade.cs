using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity.ContractEntities;
using Flow.ContractFlow.ContractChargeRateFlow;
using PTB.BTS.ContractEntities.ContractChargeRate;
using Flow.AttendanceFlow;
using Entity.AttendanceEntities;
using PTB.BTS.Contract.Flow;

namespace Facade.ContractFacade
{
    public class ContractAgreementFacade : Facade.PiFacade.CommonPIFacadeBase
    {
        public bool FillChargeRateByServiceStaffType(ChargeRateByServiceStaffType condition)
        {
            using (ChargeRateByServiceStaffTypeFlow flow = new ChargeRateByServiceStaffTypeFlow())
            {
                return flow.FillChargeRateByServiceStaffType(condition, GetCompany());
            }
        }

        public bool FillWorkingTimeCondition(WorkingTimeCondition condition)
        {
            using (WorkingTimeConditionFlow flow = new WorkingTimeConditionFlow())
            {
                return flow.FillWorkingTimeCondition(condition, GetCompany());
            }
        }

        public int CheckDriverOnly(ContractBase driverContract)
        {
            using (VDContractMatchFlow flow = new VDContractMatchFlow())
            {
                return flow.CheckDriverOnly(driverContract.ContractNo, GetCompany());
            }
        }
    }
}
