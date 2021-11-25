using System;
using System.Collections.Generic;
using System.Text;
using ictus.Common.Entity;

namespace Entity.VehicleEntities.Leasing
{
    public class VehicleSellingPlanList : CompanyStuffBase
    {
        private ictus.Common.Entity.Time.YearMonth _estimateYearMonth = new ictus.Common.Entity.Time.YearMonth();
        public ictus.Common.Entity.Time.YearMonth EstimateYearMonth
        {
            get { return _estimateYearMonth; }
            set { _estimateYearMonth = value; }
        }

        //============================== Constructor ==============================
        public VehicleSellingPlanList(Company aCompany)
            : base(aCompany)
        {}

        //============================== Public Method ==============================
        public void Add(VehicleSellingPlan entity) { base.Add(entity); }

        public void Remove(VehicleSellingPlan entity) { base.Remove(entity); }

        public VehicleSellingPlan this[int index]
        {
            get { return ((VehicleSellingPlan)base.BaseGet(index)); }
            set { base.BaseSet(index, value); }
        }

        public VehicleSellingPlan this[String key]
        {
            get { return ((VehicleSellingPlan)base.BaseGet(key)); }
            set { base.BaseSet(key, value); }
        }
    }
}
