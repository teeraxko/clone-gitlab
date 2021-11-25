using System;
using System.Collections.Generic;
using System.Text;
using Entity.VehicleEntities;
using Entity.VehicleEntities.VehicleLeasing;
using System.Collections;

namespace Facade.VehicleFacade.VehicleLeasingFacade
{
    public class VehicleSellingPlanFacade : Facade.PiFacade.CommonPIFacadeBase
    {
        ////============================== Public Method ==============================
        public List<Bidder> DataSourceBidder
        {
            get
            {
                using (PTB.BTS.Vehicle.Flow.BidderFlow flowBidder = new PTB.BTS.Vehicle.Flow.BidderFlow())
                {
                    return flowBidder.GetAllBidder();
                }
            }
        }

        public List<VehicleInfo> GetVehicleInfoByVehicleSelling(DateTime sellingDate)
        {
            VehicleSelling vehicleSelling =new VehicleSelling();
            vehicleSelling.SellingDate = sellingDate;
            using (Flow.VehicleFlow.VehicleLeasingFlow.VehicleSellingPlanFlow flow = new Flow.VehicleFlow.VehicleLeasingFlow.VehicleSellingPlanFlow())
            {
                return flow.GetVehicleInfoByVehicleSelling(vehicleSelling,GetCompany());
            }
        }

        public VehicleSelling FillVehicleSelling(int vehicleNo)
        {
            using (Flow.VehicleFlow.VehicleLeasingFlow.VehicleSellingPlanFlow flow = new Flow.VehicleFlow.VehicleLeasingFlow.VehicleSellingPlanFlow())
            {
                return flow.FillVehicleSelling(vehicleNo, GetCompany());
            }
        }

        /// <summary>
        /// Calculate BV by bvDate
        /// by Aof 20/11/08
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="bvDate"></param>
        /// <returns></returns>
        public decimal CalculateBV(VehicleInfo entity, DateTime bvDate)
        {
            using (Flow.VehicleFlow.VehicleLeasingFlow.VehicleSellingPlanFlow flow = new Flow.VehicleFlow.VehicleLeasingFlow.VehicleSellingPlanFlow())
            {
                return flow.CalculateBV(entity,bvDate, GetCompany());
            }
        }

        public bool InsertVehicleSelling(VehicleSelling vehicleSelling)
        {
            using (Flow.VehicleFlow.VehicleLeasingFlow.VehicleSellingPlanFlow flow = new Flow.VehicleFlow.VehicleLeasingFlow.VehicleSellingPlanFlow())
            {
                return flow.InsertVehicleSelling(vehicleSelling, GetCompany());
            }
        }

        public bool DeleteVehicleSelling(VehicleSelling entity)
        {
            using (Flow.VehicleFlow.VehicleLeasingFlow.VehicleSellingPlanFlow flow = new Flow.VehicleFlow.VehicleLeasingFlow.VehicleSellingPlanFlow())
            {
                return flow.DeleteVehicleSelling(entity, GetCompany());
            }
        }

        public bool UpdateVehicleSelling(VehicleSelling entity)
        {
            using (Flow.VehicleFlow.VehicleLeasingFlow.VehicleSellingPlanFlow flow = new Flow.VehicleFlow.VehicleLeasingFlow.VehicleSellingPlanFlow())
            {
                return flow.UpdateVehicleSelling(entity, GetCompany());
            }
        }

        public Bidder GetBidderByBidderCode(string bidderCode)
        {
            using (Flow.VehicleFlow.VehicleLeasingFlow.VehicleSellingPlanFlow flow = new Flow.VehicleFlow.VehicleLeasingFlow.VehicleSellingPlanFlow())
            {
                return flow.GetBidderByBidderCode(bidderCode, GetCompany());
            }
        }
    }
}
