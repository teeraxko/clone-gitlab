using System;

using Facade.PiFacade;
using ictus.Common.Entity;
using SystemFramework.AppException;

using PTB.BTS.Contract.Flow.ContractChargeRateFlow;
using PTB.BTS.ContractEntities.ContractChargeRate;
using Flow.ContractFlow.ContractChargeRateFlow;
using Entity.ContractEntities;
using PTB.BTS.Contract.Flow;

namespace Facade.ContractFacade.ContractChargeRateFacade
{
    public class ChargeRateByContractFacade : CommonPIFacadeBase
    {
        private ChargeRateByContractFlow flowChargeRateByContract;
        private ContractFlow flowContract;

        //============================== Property ==============================
        private ChargeRateByContractList objChargeRateByContractList;
        public ChargeRateByContractList ObjChargeRateByContractList
        {
            get { return objChargeRateByContractList; }
        }

        //============================== Constructor ==============================
        public ChargeRateByContractFacade()
            : base()
        {
            flowChargeRateByContract = new ChargeRateByContractFlow();
            flowContract = new ContractFlow();
            objChargeRateByContractList = new ChargeRateByContractList(GetCompany());
        }

        //============================== public method ==============================
        public bool DisplayChargeRateByContract()
        {
            objChargeRateByContractList.Clear();
            return flowChargeRateByContract.FillChargeRateByContractList(objChargeRateByContractList);
        }

        public ContractBase RetriveContract(DocumentNo value)
        {
            return flowContract.RetriveContract(value, GetCompany());
        }

        public ServiceStaffAssignment GetMainAssignmentInDate(ContractBase contract, DateTime date)
        {
            using (ServiceStaffAssignmentFlow flow = new ServiceStaffAssignmentFlow())
            {
                return flow.GetMainAssignmentInDate(contract, date, GetCompany());
            }
        }

        public bool InsertChargeRateByContract(ChargeRateByContract value)
        {
            if (objChargeRateByContractList.Contain(value))
            {
                throw new DuplicateException("ChargeRateByContractFacade");
            }
            else
            {
                if (flowChargeRateByContract.InsertChargeRateByContract(value, GetCompany()))
                {
                    objChargeRateByContractList.Add(value);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool UpdateChargeRateByContract(ChargeRateByContract value)
        {
            if (flowChargeRateByContract.UpdateChargeRateByContract(value, GetCompany()))
            {
                objChargeRateByContractList[value.EntityKey] = value;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteChargeRateByContract(ChargeRateByContract value)
        {
            if (flowChargeRateByContract.DeleteChargeRateByContract(value, GetCompany()))
            {
                objChargeRateByContractList.Remove(value);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
