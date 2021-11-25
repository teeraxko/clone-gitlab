using System;
using System.Collections.Generic;
using System.Text;
using Entity.VehicleEntities.VehicleLeasing;
using Entity.VehicleEntities;
using PTB.BTS.Common.Flow;
using Entity.ContractEntities;

namespace Flow.VehicleFlow.VehicleLeasingFlow
{
    public class VehicleSellingPlanFlow : PTB.BTS.Common.Flow.FlowBase
    {
        ////============================== Private Method ==============================
        private decimal CalculateBV(decimal price, DateTime regisDate, DateTime bvDate, ModelType modelType)
        {
            decimal lossPrice = decimal.Zero;
            TimeSpan diffDate = bvDate - regisDate;

            //Model type 4 = Bus
            if (modelType != null)
            {
                if (modelType.Code == "4" || price <= 1000000 || regisDate.Year >= 2004)
                {
                    lossPrice = ((price * decimal.Divide(20, 365) * diffDate.Days) / 100);
                    if (lossPrice >= price)
                    {
                        lossPrice = price - 1;
                    }
                }
                else
                {
                    lossPrice = (1000000 * decimal.Divide(20, 365) * diffDate.Days) / 100;
                    if (lossPrice >= 1000000)
                    {
                        lossPrice = 999999;
                    }
                }
            }
            else
            {
                lossPrice = (1000000 * decimal.Divide(20, 365) * diffDate.Days) / 100;
                if (lossPrice >= 1000000)
                {
                    lossPrice = 999999;
                }
            }

            return price - lossPrice;
        }

        ////============================== Public Method ==============================
        public List<VehicleInfo> GetVehicleInfoByVehicleSelling(VehicleSelling vehicleSelling, ictus.Common.Entity.Company company)
        {
            using (DataAccess.VehicleDB.VehicleLeasingDB.VehicleSellingPlanDB db = new DataAccess.VehicleDB.VehicleLeasingDB.VehicleSellingPlanDB())
            {
                return  db.GetVehicleInfoByVehicleSelling(vehicleSelling,company);
            }
        }

        public VehicleSelling FillVehicleSelling(int vehicleNo, ictus.Common.Entity.Company company)
        {
            using (DataAccess.VehicleDB.VehicleLeasingDB.VehicleSellingPlanDB db = new DataAccess.VehicleDB.VehicleLeasingDB.VehicleSellingPlanDB())
            {
                return db.FillVehicleSelling(vehicleNo, company);
            }
        }

        public decimal CalculateBV(VehicleInfo entity, DateTime bvDate, ictus.Common.Entity.Company company)
        {
            if ((bvDate != null) && (bvDate.Date >= entity.RegisterDate))
            {
                return CalculateBV(entity.VehicleAmount, entity.RegisterDate, bvDate, entity.AModel.AModelType);
            }
            else
            {
                return decimal.Zero;
            }
        }

        public bool InsertVehicleSelling(VehicleSelling vehicleSelling, ictus.Common.Entity.Company company)
        {
            using (DataAccess.VehicleDB.VehicleLeasingDB.VehicleSellingPlanDB db = new DataAccess.VehicleDB.VehicleLeasingDB.VehicleSellingPlanDB())
            {
                return db.InsertVehicleSelling(vehicleSelling, company);
            }
        }

        public bool DeleteVehicleSelling(VehicleSelling entity, ictus.Common.Entity.Company company)
        {
            using (DataAccess.VehicleDB.VehicleLeasingDB.VehicleSellingPlanDB db = new DataAccess.VehicleDB.VehicleLeasingDB.VehicleSellingPlanDB())
            {
                return db.DeleteVehicleSelling(entity, company);
            }
        }

        public bool UpdateVehicleSelling(VehicleSelling entity, ictus.Common.Entity.Company company)
        {
            using (DataAccess.VehicleDB.VehicleLeasingDB.VehicleSellingPlanDB db = new DataAccess.VehicleDB.VehicleLeasingDB.VehicleSellingPlanDB())
            {
                return db.UpdateVehicleSelling(entity, company);
            }
        }

        public Bidder GetBidderByBidderCode(string bidderCode, ictus.Common.Entity.Company company)
        {
            Bidder bidder = new Bidder();
            bidder.BidderCode = bidderCode;
            using (PTB.BTS.Vehicle.Flow.BidderFlow flow = new PTB.BTS.Vehicle.Flow.BidderFlow())
            {
                return flow.GetBidderByBidderCode(bidder, company);
            }
        }
    }
}
