using System;
using ictus.Common.Entity.General;

namespace Entity.VehicleEntities.Leasing
{
    public class InterestCostList : ListBase
    {
        public InterestCostList()
        {
        }

        //============================== Public Method ==============================
        public void Add(InterestCost value)
        { base.Add(value); }

        public void Remove(InterestCost value)
        { base.Remove(value); }

        public InterestCost this[int index]
        {
            get
            { return (InterestCost)base.BaseGet(index); }
            set
            { base.BaseSet(index, value); }
        }

        public InterestCost this[String key]
        {
            get
            { return (InterestCost)base.BaseGet(key); }
            set
            { base.BaseSet(key, value); }
        }

        private decimal totalCost;
        public decimal TotalCost
        {
            get
            {
                return totalCost;
            }
            set
            {
                totalCost = value;
            }
        }

        private decimal percentResidualValue;
        public decimal PercentResidualValue
        {
            get
            {
                return percentResidualValue;
            }
            set
            {
                percentResidualValue = value;
            }
        }

        public decimal ResidualValue
        {
            get
            {
                return Math .Round(totalCost * percentResidualValue / 100m,2);
            }
        }

        private decimal rate;
        public decimal Rate
        {
            get
            {
                return rate;
            }
            set
            {
                rate = value;
            }
        }

        private decimal pvOfResidualValue;
        public decimal PVofResidualValue
        {
            get
            {
                return pvOfResidualValue;
            }
            set
            {
                pvOfResidualValue = value;
            }
        }

        public decimal PVofAnnuity
        {
            get
            {
                return totalCost - pvOfResidualValue;
            }
        }

        private int leaseTerm;
        public int LeaseTerm
        {
            get
            {
                return leaseTerm;
            }
            set
            {
                leaseTerm = value;
            }
        }
    }
}