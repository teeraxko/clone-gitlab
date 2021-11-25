using System;
using System.Collections.Generic;
using System.Text;
using Facade.PiFacade;
using Entity.VehicleEntities;
using PTB.BTS.Vehicle.Flow;
using Flow.VehicleFlow.LeasingFlow;
using System.Collections;
using Entity.ContractEntities;
using PTB.BTS.Contract.Flow;
using ictus.Common.Entity.Time;
using Entity.CommonEntity;
using PTB.BTS.Common.Flow;

namespace Facade.VehicleFacade.LeasingFacade
{
    public class ProfitAndLostFacade : CommonPIFacadeBase
    {
        //============================== Constructor ==============================
        public ProfitAndLostFacade()
            : base()
        {
        }

        //============================== Public Method ==============================
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

        public VehicleAssignment GetCurrentAssignment(int vehicleNo)
        {
            using (VehicleAssignmentFlow flowAssign = new VehicleAssignmentFlow())
            {
                return flowAssign.GetCurrentVehicleAssignment(vehicleNo, GetCompany());
            }
        }

        public Age CalculateAge(DateTime fromDate, DateTime toDate)
        {
            using (AgeFlow flowAge = new AgeFlow())
            {
                return flowAge.CalculateFineAge(fromDate, toDate);
            }
        }

        public bool PrintProfitAndLost(Entity.VehicleEntities.Leasing.ProfitAndLostList listPL)
        {
            using (ProfitAndLostFlow flowPL = new ProfitAndLostFlow())
            {
                return flowPL.PrintProfitAndLost(listPL);
            }
        }
    }
}
