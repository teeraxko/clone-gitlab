using System;
using System.Collections.Generic;
using System.Text;
using Entity.VehicleEntities.Leasing;

namespace Facade.VehicleFacade.LeasingFacade
{
    public class VehicleSellingPlanFacade : Facade.PiFacade.CommonPIFacadeBase
    {
        private VehicleSellingPlanList _list;
        public VehicleSellingPlanList List
        {
            get { return _list; }
        }

        //============================== Public Method ==============================
        public bool FillList(ictus.Common.Entity.Time.YearMonth yearMonth)
        {
            _list = new VehicleSellingPlanList(GetCompany());
            _list.EstimateYearMonth = yearMonth;

            using (Flow.VehicleFlow.LeasingFlow.VehicleSellingPlanFlow flow = new Flow.VehicleFlow.LeasingFlow.VehicleSellingPlanFlow())
            {
                return flow.FillList(_list);   
            }
        }

        public bool CalculateBV(VehicleSellingPlan entity, ictus.Common.Entity.Time.YearMonth yearMonth)
        {
            using (Flow.VehicleFlow.LeasingFlow.VehicleSellingPlanFlow flow = new Flow.VehicleFlow.LeasingFlow.VehicleSellingPlanFlow())
            {
                return flow.CalculateBV(entity, yearMonth, GetCompany());
            }
        }

        public void Delete(VehicleSellingPlan entity, ictus.Common.Entity.Time.YearMonth yearMonth)
        {
            using (Flow.VehicleFlow.LeasingFlow.VehicleSellingPlanFlow flow = new Flow.VehicleFlow.LeasingFlow.VehicleSellingPlanFlow())
            {
                flow.Delete(entity, yearMonth, GetCompany());
            }
        }
    }
}
