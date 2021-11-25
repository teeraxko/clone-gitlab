using System;
using ictus.Common.Entity.General;
using ictus.Framework.ASC.Entity.DNF20;

namespace Entity.VehicleEntities.Leasing
{
    public class ProfitAndLost : EntityBase, IProfitAndLost
    {
        //============================== Input ==============================
        private Vehicle vehicle;
        public Vehicle Vehicle
        {
            get { return vehicle; }
            set { vehicle = value; }
        }

        private decimal rate;
        public decimal Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        private decimal pmt;
        public decimal Pmt
        {
            get { return pmt; }
            set { pmt = value; }
        }

        private decimal fv;
        public decimal FV
        {
            get { return fv; }
            set { fv = value; }
        }
        //============================== Result ==============================
        private decimal rental;
        public decimal Rental
        {
            get { return rental; }
            set { rental = value; }
        }

        private decimal contract;
        public decimal Contract
        {
            get { return contract; }
            set { contract = value; }
        }

        private decimal rentalAge;
        public decimal RentalAge
        {
            get { return rentalAge; }
            set { rentalAge = value; }
        }

        public decimal Remain
        {
            get
            {
                if ((Contract - RentalAge) > 0)
                {
                    return Contract - RentalAge;
                }
                else
                {
                    return decimal.Zero;
                }
            }
        }

        private decimal remainingCostPV;
        public decimal RemainingCostPV
        {
            get { return remainingCostPV; }
            set { remainingCostPV = value; }
        }

        private decimal residualValuePV;
        public decimal ResidualValuePV
        {
            get { return residualValuePV; }
            set { residualValuePV = value; }
        }

        private decimal sale;
        public decimal Sale
        {
            get { return sale; }
            set { sale = value; }
        }

        private decimal compensate;
        public decimal Compensate
        {
            get { return compensate; }
            set { compensate = value; }
        }

        private decimal price;
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        private decimal bv;
        public decimal BV
        {
            get { return bv; }
            set { bv = value; }
        }

        #region IKey Members
        public override string EntityKey
        {
            get { return Vehicle.EntityKey; }
        }
        #endregion

        #region IProfitAndLost Members
        Vehicle IProfitAndLost.Vehicle
        {
            get { return vehicle; }
        }

        decimal IProfitAndLost.Rental
        {
            get { return rental; }
        }

        decimal IProfitAndLost.Contract
        {
            get { return contract; }
        }

        decimal IProfitAndLost.RentalAge
        {
            get { return rentalAge; }
        }

        decimal IProfitAndLost.Remain
        {
            get { return Remain; }
        }

        decimal IProfitAndLost.RemainingCostPV
        {
            get { return remainingCostPV; }
        }

        decimal IProfitAndLost.ResidualValuePV
        {
            get { return ResidualValuePV; }
        }

        decimal IProfitAndLost.Sale
        {
            get { return sale; }
        }

        decimal IProfitAndLost.Compensate
        {
            get { return compensate; }
        }

        decimal IProfitAndLost.Price
        {
            get { return price; }
        }

        decimal IProfitAndLost.BV
        {
            get { return bv; }
        }
        #endregion
    }
}
