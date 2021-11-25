using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.VehicleEntities.VehicleLeasing
{
    public class VehicleLeasingCalculation
    {
        //============================== Property ==============================
        private decimal percentResidual = decimal.Zero;
        public decimal PercentResidual
        {
            get { return percentResidual; }
            set { percentResidual = value; }
        }

        private decimal residualValue = decimal.Zero;
        public decimal ResidualValue
        {
            get { return residualValue; }
            set { residualValue = value; }
        }

        private int leaseTerm = 0;
        public int LeaseTerm
        {
            get { return leaseTerm; }
            set { leaseTerm = value; }
        }

        private decimal rateOfReturnEstimate = decimal.Zero;
        public decimal RateOfReturnEstimate
        {
            get { return rateOfReturnEstimate; }
            set { rateOfReturnEstimate = value; }
        }

        private decimal rateOfReturnActual = decimal.Zero;
        public decimal RateOfReturnActual
        {
            get { return rateOfReturnActual; }
            set { rateOfReturnActual = value; }
        }

        private decimal interestRate = decimal.Zero;
        public decimal InterestRate
        {
            get { return interestRate; }
            set { interestRate = value; }
        }

        private decimal capitalInsurance = decimal.Zero;
        public decimal CapitalInsurance
        {
            get { return capitalInsurance; }
            set { capitalInsurance = value; }
        }
        
        private decimal insurancePremium = decimal.Zero;
        public decimal InsurancePremium
        {
            get { return insurancePremium; }
            set { insurancePremium = value; }
        }

        private decimal taxRegister = decimal.Zero;
        public decimal TaxRegister
        {
            get { return taxRegister; }
            set { taxRegister = value; }
        }

        private decimal maintenance = decimal.Zero;
        public decimal Maintenance
        {
            get { return maintenance; }
            set { maintenance = value; }
        }

        private decimal maintenanceActual = decimal.Zero;
        public decimal MaintenanceActual
        {
            get { return maintenanceActual; }
            set { maintenanceActual = value; }
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

        private decimal monthlyChargeActual = decimal.Zero;
        public decimal MonthlyChargeActual
        {
            //get { return PMT + InsurancePremium/12 + TaxRegister/12 + Maintenance; } 
  
            get { return monthlyChargeActual; }
            set { monthlyChargeActual = value; }
        }

        private decimal monthlyCharge = decimal.Zero;
        public decimal MonthlyCharge
        {
            get { return monthlyCharge; }
            set { monthlyCharge = value; }
        }

        //Todsporn Modified 25/2/2020 PO. Discount

        private decimal discountAmount = decimal.Zero;
        public decimal DiscountAmount
        {
            get { return discountAmount; }
            set { discountAmount = value; }
        }

        private decimal discountTotal = decimal.Zero;
        public decimal DiscountTotal
        {
            get { return discountTotal; }
            set { discountTotal = value; }
        }
    }
}
