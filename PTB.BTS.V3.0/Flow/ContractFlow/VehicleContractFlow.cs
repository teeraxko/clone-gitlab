using System;
using System.Collections.Generic;
using System.Text;
using PTB.BTS.Common.Flow;
using Entity.ContractEntities;
using DataAccess.ContractDB;
using ictus.Common.Entity;

namespace Flow.ContractFlow
{
    public class VehicleContractFlow : FlowBase
    {
        public VehicleContract GetVehicleContract(DocumentNo contractNo, Company company)
        {
            using (VehicleContractDB dbVehicleContract = new VehicleContractDB())
            {
                return dbVehicleContract.GetVehicleContract(contractNo, company);
            }
        }
    }
}
