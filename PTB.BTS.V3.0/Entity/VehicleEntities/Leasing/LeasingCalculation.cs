using System;

namespace Entity.VehicleEntities.Leasing
{
    public class LeasingCalculation
    {
        //============================== Constructor ==============================
        public LeasingCalculation()
        {
        }

        //============================== Property ==============================
        private decimal percentOfResidual = decimal.Zero;
        public decimal PercentOfResidual
        {
            get { return percentOfResidual; }
            set { percentOfResidual = value; }
        }

        private decimal residualValue = decimal.Zero;
        public decimal ResidualValue
        {
            get { return residualValue; }
            set { residualValue = value; }
        }

        private decimal rateOfReturn = decimal.Zero;
        public decimal RateOfReturn
        {
            get { return rateOfReturn; }
            set { rateOfReturn = value; }
        }

        private decimal pv = decimal.Zero;
        public decimal PV
        {
            get { return pv; }
            set { pv = value; }
        }

        private decimal pmt = decimal.Zero;
        public decimal PMT
        {
            get { return pmt; }
            set { pmt = value; }
        }

        private decimal insuranceCharge = decimal.Zero;
        public decimal InsuranceCharge
        {
            get { return insuranceCharge; }
            set { insuranceCharge = value; }
        }

        private decimal registerCharge = decimal.Zero;
        public decimal RegisterCharge
        {
            get {  return registerCharge; }
            set { registerCharge = value; }
        }

        private decimal maintenanceCharge = decimal.Zero;
        public decimal MaintenanceCharge
        {
            get { return maintenanceCharge; }
            set { maintenanceCharge = value; }
        }

        public decimal MonthlyCharge
        {
            get { return PMT + insuranceCharge + registerCharge + maintenanceCharge; }
        }

        private decimal monthlyRoundCharge = decimal.Zero;
        public decimal MonthlyRoundCharge
        {
            get { return monthlyRoundCharge; }
            set { monthlyRoundCharge = value; }
        }
    }
}
