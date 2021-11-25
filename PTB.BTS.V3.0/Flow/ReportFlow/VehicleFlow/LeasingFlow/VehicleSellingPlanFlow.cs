using System;
using System.Collections.Generic;
using System.Text;
using Entity.VehicleEntities.Leasing;
using Entity.VehicleEntities;
using PTB.BTS.Common.Flow;
using Entity.ContractEntities;

namespace Flow.VehicleFlow.LeasingFlow
{
    public class VehicleSellingPlanFlow : PTB.BTS.Common.Flow.FlowBase
    {
        //============================== Private Method ==============================
        private decimal CalculateBV(decimal price, DateTime regisDate, DateTime bvDate, ModelType modelType)
        {
            decimal lossPrice = decimal.Zero;
            TimeSpan diffDate = bvDate - regisDate;

            //Model type 4 = Bus
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

            return price - lossPrice;
        }

        //============================== Public Method ==============================
        public bool FillList(VehicleSellingPlanList list)
        {
            bool resultSell = false;
            bool resultAssing = false;
            AgeFlow flowAge = new AgeFlow();

            using (DataAccess.VehicleDB.VehicleSellingPlanDB db = new DataAccess.VehicleDB.VehicleSellingPlanDB())
            {
                resultSell = db.FillList(list);

                if (resultSell)
                {
                    foreach (VehicleSellingPlan entity in list)
                    {
                        entity.VehicleYear = flowAge.CalculateAge(entity.VehicleInfo.RegisterDate).Year;
                    }
                }
            }

            VehicleAssignmentList assingList = new VehicleAssignmentList(list.Company);
            using (DataAccess.ContractDB.VehicleAssignmentDB db = new DataAccess.ContractDB.VehicleAssignmentDB())
            {
                resultAssing = db.FillSpecificVehicleAssignmentSellingPlan(assingList, list.EstimateYearMonth);
            }

            if (resultAssing)
            {
                VehicleSellingPlan vehicleSell;
                foreach (VehicleAssignment vehicleAssignment in assingList)
                {
                    string status = vehicleAssignment.AAssignedVehicle.AVehicleStatus.Code;
                    if (status == "1" || status == "2" || status == "3")
                    {
                        vehicleSell = new VehicleSellingPlan();
                        using (DataAccess.VehicleDB.VehicleDB db = new DataAccess.VehicleDB.VehicleDB())
                        {
                            vehicleSell.VehicleInfo = db.GetVehicleInfo(vehicleAssignment.AAssignedVehicle.VehicleNo, list.Company);
                        }
                        vehicleSell.VehicleYear = flowAge.CalculateAge(vehicleAssignment.AAssignedVehicle.RegisterDate).Year;

                        list.Add(vehicleSell);
                    }
                }
                vehicleSell = null;
            }


            return resultSell | resultAssing;
        }

        public bool CalculateBV(VehicleSellingPlan entity, ictus.Common.Entity.Time.YearMonth yearMonth, ictus.Common.Entity.Company company)
        {
            if (entity.BVDate.HasValue && entity.BVDate.Value >= entity.VehicleInfo.RegisterDate)
            {
                entity.BV = CalculateBV(entity.VehicleInfo.VehicleAmount, entity.VehicleInfo.RegisterDate, entity.BVDate.Value, entity.VehicleInfo.AModel.AModelType);
            }
            else
            {
                entity.BV = decimal.Zero;
            }
            

            using (DataAccess.VehicleDB.VehicleSellingPlanDB db = new DataAccess.VehicleDB.VehicleSellingPlanDB())
            {
                return db.Maintenance(entity, yearMonth, company);
            }
        }

        public void Delete(VehicleSellingPlan entity, ictus.Common.Entity.Time.YearMonth yearMonth, ictus.Common.Entity.Company company)
        {
            using (DataAccess.VehicleDB.VehicleSellingPlanDB db = new DataAccess.VehicleDB.VehicleSellingPlanDB())
            {
                db.Delete(entity, yearMonth, company);
            }
        }
    }
}
