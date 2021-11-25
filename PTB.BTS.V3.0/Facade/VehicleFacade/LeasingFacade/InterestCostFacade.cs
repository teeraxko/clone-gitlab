using System;
using System.Collections.Generic;
using System.Text;
using Facade.PiFacade;
using Entity.VehicleEntities;
using PTB.BTS.Vehicle.Flow;
using Flow.VehicleFlow.LeasingFlow;

namespace Facade.VehicleFacade.LeasingFacade
{
    public class InterestCostFacade : CommonPIFacadeBase
    {
        //================================= Constructor ================================
        public InterestCostFacade()
            : base()
        {
        }

        //================================= Public method ================================
        public VehicleInfo GetVehicleInfo(string platePrefix, string plateNo)
        {
            bool result = false;
            VehicleInfo vehicleInfo = new VehicleInfo();
            vehicleInfo.PlatePrefix = platePrefix;
            vehicleInfo.PlateRunningNo = plateNo;

            using (VehicleFlow flowVehicle = new VehicleFlow())
            { 
                result = flowVehicle.FillVehicleInfo(ref vehicleInfo, GetCompany());
            }

            if (result)
            {
                return vehicleInfo;
            }
            else
            {
                vehicleInfo = null;
                return null;
            }
        }

        public bool PrintInterestCost(Entity.VehicleEntities.Leasing.InterestCostList listCost)
        {
            bool result = false;

            using (InterestCostFlow flowInterestCost = new InterestCostFlow())
            {
                result = flowInterestCost.PrintInterestCost(listCost);            
            }

            return result;
        }
    }
}
