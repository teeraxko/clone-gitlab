using System;
using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.VehicleEntities.Leasing
{
    public class InterestCost : EntityBase, IKey
    {
        private int year;
        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        private int month;
        public int Month
        {
            get { return month; }
            set { month = value; }
        }

        private decimal payment;
        public decimal Payment
        {
            get { return payment; }
            set { payment = value; }
        }

        private decimal interest;
        public decimal Interest
        {
            get { return Math.Round(interest,2); }
            set { interest = value; }
        }

        public decimal Cost
        {
            get { return payment - interest; }
        }

        private decimal carryingValue;
        public decimal CarryingValue
        {
            get { return carryingValue; }
            set { carryingValue = value; }
        }

        public override string EntityKey
        {
            get { return year.ToString() + month.ToString(); }
        }
    }
}
