using System;
using System.Collections.Generic;
using System.Text;
using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.VehicleEntities.VehicleLeasing
{
    public class VehicleInterestCostList : EntityBase
    {
        public List<VehicleInterestCost> InterestCostList { get; set; }

        private decimal totalCost;
        public decimal TotalCost
        {
            get { return totalCost; }
            set { totalCost = value; }
        }

        private decimal percentResidualValue;
        public decimal PercentResidualValue
        {
            get { return percentResidualValue; }
            set
            {
                percentResidualValue = value;
            }
        }

        public decimal ResidualValue
        {
            get
            {
                return Math.Round(totalCost * percentResidualValue / 100m, 2);
            }
        }

        private decimal rate;
        public decimal Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        private decimal pvOfResidualValue;
        public decimal PVofResidualValue
        {
            get { return pvOfResidualValue; }
            set { pvOfResidualValue = value; }
        }

        public decimal PVofAnnuity
        {
            get
            {
                return decimal.Subtract(TotalCost, PVofResidualValue);
            }
        }

        private int leaseTerm;
        public int LeaseTerm
        {
            get { return leaseTerm; }
            set { leaseTerm = value; }
        }

        public override string EntityKey
        {
            get { throw new NotImplementedException(); }
        }
    }
}
