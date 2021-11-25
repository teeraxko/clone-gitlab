using System;
using System.Collections.Generic;
using System.Text;
using Facade.PiFacade;
using PTB.BTS.Contract.Flow;
using Flow.ContractFlow;

namespace PTB.BTS.Contract.Facade
{
    public class VehicleChargeDiffFacade : CommonPIFacadeBase
    {
        //============================== Constructor ==============================
        public VehicleChargeDiffFacade()
            : base()
        {}

        //============================== Public method ==============================
        public bool GenerateChargeDiff(DateTime date)
        {
            bool result = false;

            using (VehicleChargeDiffFlow flowVehicleChargeDiff = new VehicleChargeDiffFlow())
            {
                result = flowVehicleChargeDiff.GenerateChargeDiff(date, GetCompany());
            }
            return result;
        }
    }
}
