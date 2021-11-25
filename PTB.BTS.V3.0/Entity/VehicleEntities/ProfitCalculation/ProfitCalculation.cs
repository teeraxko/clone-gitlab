using System;
using Entity.VehicleEntities.Leasing;

namespace Entity.VehicleEntities.ProfitCalculation
{
    public class ProfitCal : IProfitCalHeader
    {
        private string customer;
        public string Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        private string vehicle;
        public string Vehicle
        {
            get { return vehicle; }
            set { vehicle = value; }
        }

        private decimal vehiclePrice;
        public decimal VehiclePrice
        {
            get { return vehiclePrice; }
            set { vehiclePrice = value; }
        }

        private int leaseTerm;
        public int LeaseTerm
        {
            get { return leaseTerm; }
            set { leaseTerm = value; }
        }

        private decimal depreciation;
        public decimal Depreciation
        {
            get { return depreciation; }
            set { depreciation = value; }
        }

        private VehicleCost vehicleCost;
        public VehicleCost VehicleCost
        {
            get { return vehicleCost; }
            set { vehicleCost = value; }
        }

        private LeasingCalculation leasingCalculation;
        public LeasingCalculation LeasingCalculation
        {
            get { return leasingCalculation; }
            set { leasingCalculation = value; }
        }

        private InterestCostList interestCostList;
        public InterestCostList InterestCostList
        {
            get { return interestCostList; }
            set { interestCostList = value; }
        }

        private ProfitCalDetailList profitCalDetailList;
        public ProfitCalDetailList ProfitCalDetailList
        {
            get { return profitCalDetailList; }
            set { profitCalDetailList = value; }
        }

        #region IProfitCalHeader Members
        public string VehicleModel
        {
            get { return vehicle; }
        }

        public decimal ResidualPercent
        {
            get { return leasingCalculation.PercentOfResidual; }
        }

        public decimal ResidualValue
        {
            get { return leasingCalculation.ResidualValue; }
        }

        public decimal RateOfReturn
        {
            get { return leasingCalculation.RateOfReturn; }
        }

        public decimal PV
        {
            get { return leasingCalculation.PV; }
        }

        public decimal MonthlyPMT
        {
            get { return leasingCalculation.PMT; }
        }

        public decimal MonthlyInsurancePremium
        {
            get { return leasingCalculation.InsuranceCharge; }
        }

        public decimal MonthlyVehicleTax
        {
            get { return leasingCalculation.RegisterCharge; }
        }

        public decimal MonthlyMaintenance
        {
            get { return leasingCalculation.MaintenanceCharge; }
        }

        public decimal MonthlyActualCharge
        {
            get { return leasingCalculation.MonthlyCharge; }
        }

        public decimal MonthlyCharge
        {
            get { return leasingCalculation.MonthlyRoundCharge; }
        }

        public decimal CapitalInsurance
        {
            get { return vehicleCost.CapitalInsurance; }
        }

        public decimal InsurancePremium
        {
            get { return vehicleCost.InsurancePremium; }
        }

        public decimal InterestRate
        {
            get { return interestCostList.Rate; }
        }

        public decimal PVResidualValue
        {
            get { return interestCostList.PVofResidualValue; }
        }

        public decimal PVAnnuity
        {
            get { return interestCostList.PVofAnnuity; }
        }

        private int forYear;
        public int ForYear
        {
            get { return forYear; }
            set { forYear = value; }
        }

        #endregion
    }
}
