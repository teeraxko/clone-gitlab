using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using DataAccess.CommonDB;
using DataAccess.VehicleDB;
using DataAccess.ContractDB;
using DataAccess.VehicleDB.VehicleLeasingDB;

using Entity.VehicleEntities;
using Entity.ContractEntities;
using Entity.VehicleEntities.VehicleLeasing;

using Flow.VehicleFlow;
using Flow.VehicleFlow.LeasingFlow;

using ictus.Framework.ASC.VBFuntion;
using ictus.PIS.PI.Entity;
using ictus.Common.Entity;

using PTB.BTS.Common.Flow;

namespace Flow.VehicleFlow.VehicleLeasingFlow
{
    public class VehiclePurchasingContractFlow : FlowBase
    {
        #region Constructor
        public VehiclePurchasingContractFlow()
            : base()
        {

        }
        #endregion

        #region Public Method
        public List<VehiclePurchasingContract> GetPurchasingContractListByVehicleSelling(VehiclePurchasing vehiclePurchasing)
        {
            using (VehiclePurchaseContractDB database = new VehiclePurchaseContractDB())
            {
                return database.GetPurchasingContractListByVehicleSelling(vehiclePurchasing);
            }
        }

        public List<VehiclePurchasingContract> GetPurchasingContractListByPurchase(VehiclePurchasing vehiclePurchasing, Company company)
        {
            using (VehiclePurchaseContractDB database = new VehiclePurchaseContractDB())
            {
                return database.GetPurchasingContractListByPurchasing(vehiclePurchasing, company);
            }
        }

        public List<VehiclePurchasingContract> GetPurchasingContractListByContract(DocumentNo contractNo)
        {
            using (VehiclePurchaseContractDB database = new VehiclePurchaseContractDB())
            {
                return database.GetPurchasingContractListByContract(contractNo);
            }
        }

        public List<VehiclePurchasingContract> GetPurchasingContractByContractStatus(VehiclePurchasing vehclePurchasing, ContractStatus contractStauts)
        {
            using (VehiclePurchaseContractDB database = new VehiclePurchaseContractDB())
            {
                return database.GetPurchasingContractByContractStatus(vehclePurchasing, contractStauts);
            }
        }
        #endregion
    } 
}
