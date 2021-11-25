using System;
using System.Collections.Generic;
using System.Text;
using Entity.ContractEntities;
using Facade.PiFacade;
using PTB.BTS.Contract.Flow;
using Entity.VehicleEntities;
using Flow.ContractFlow;

namespace Facade.ContractFacade
{
    public class RenewalNoticeFacade : CommonPIFacadeBase
    {

        /// <summary>
        /// Get Contract Data  by condition select
        /// </summary>
        /// <param name="condition"></param>
        /// <returns>ContractList</returns>

        public ContractList GetContractList(ContractBase condition)
        {
            ContractList contractList = new ContractList(GetCompany());
            ContractFlow flowContract = new ContractFlow();

            if (flowContract.FillContractExpireByYearMonthExistsPurchasing(contractList, condition))
            {
                return contractList;
            }
            else 
            {
                return null;
            }
        }

        public Vehicle GetVehicleByContract(DocumentNo documentNo)
        {
            using (VehicleContractFlow flow = new VehicleContractFlow())
            {
                VehicleContract vehicleContract = flow.GetVehicleContract(documentNo, GetCompany());

                if (vehicleContract != null && vehicleContract.AVehicleRoleList != null && vehicleContract.AVehicleRoleList.Count > 0)
                {
                    return vehicleContract.AVehicleRoleList[0].AVehicle;
                }
                else
                {
                    return null;
                }
            }
        }
       
    }
}
