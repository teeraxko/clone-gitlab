using System;
using System.Collections.Generic;
using System.Text;
using Entity.ContractEntities;

namespace Entity.VehicleEntities.VehicleLeasing
{
    public class VehicleCalculation : IVehicleProfitCalHead
    {
        public Guid CalculationNo { get; set; }

        public Customer Customer { get; set; }

        public VehicleQuotation Quotation { get; set; }

        public Model Model { get; set; }

        //Delete color from calculation : woranai 2009/02/18
        //public Color Color { get; set; }

        public decimal BodyCost { get; set; }

        public decimal ModifyCost { get; set; }

        public VehicleLeasingCalculation LeasingCalculation { get; set; }

        public decimal Depreciation { get; set; }

        public DateTime IssueDate { get; set; }

        public VehicleInterestCostList VehicleInterestCostList { get; set; }

        public List<VehicleProfitCalDetail> VehicleProfitCalDetailList { get; set; }

        //Todsporn Modified 25/2/2020 PO. Discount 
        //add leasing No.

        public string LeasingNo { get; set; }

        public decimal DiscountTotal { get; set; }

        public decimal DiscountAmount { get; set; }

        #region IVehicleProfitCalHead Members

        string IVehicleProfitCalHead.Customer
        {
            get { return Customer.ShortName+" - "+Customer.AName.English; }
        }

        public string VehicleModel
        {
            get 
            {
                return string.Concat(Model.ABrand.AName.English, Model.AName.English);
            }
        }

        public decimal VehiclePrice
        {
            get 
            {
                return BodyCost;
            }
        }

        public decimal ResidualPercent
        {
            get
            {
                return LeasingCalculation.PercentResidual;
            }
        }

        public decimal ResidualValue
        {
            get
            {
                return LeasingCalculation.ResidualValue;
            }
            set
            {
                LeasingCalculation.ResidualValue = value;
            }
        }

        public int LeaseTerm
        {
            get
            {
                return LeasingCalculation.LeaseTerm;
            }
        }

        public decimal RateOfReturnEstimate
        {
            get
            {
                return LeasingCalculation.RateOfReturnEstimate;
            }
        }

        public decimal RateOfReturnActual
        {
            get
            {
                return LeasingCalculation.RateOfReturnActual;
            }
        }

        public decimal PV
        {
            get
            {
                return LeasingCalculation.PV;
            }
        }

        public decimal MonthlyPMT
        {
            get
            {
                return LeasingCalculation.PMT;
            }
        }

        public decimal MonthlyInsurancePremium
        {
            get
            {
                return decimal.Divide(LeasingCalculation.InsurancePremium, 12);
            }
        }

        public decimal MonthlyVehicleTax
        {
            get
            {
                return decimal.Divide(LeasingCalculation.TaxRegister,12);
            }
        }

        public decimal MonthlyMaintenance
        {
            get
            {
                return LeasingCalculation.Maintenance;
            }
        }

        public decimal MonthlyMaintenanceActual
        {
            get 
            {
                return LeasingCalculation.MaintenanceActual;
            }
        }

        public decimal MonthlyChargeActual
        {
            get
            {
                return LeasingCalculation.MonthlyChargeActual;
            }
        }

        public decimal MonthlyCharge
        {
            get
            {
                return LeasingCalculation.MonthlyCharge;
            }
        }

        public decimal CapitalInsurance
        {
            get
            {
                return LeasingCalculation.CapitalInsurance;
            }
        }

        public decimal InsurancePremium
        {
            get
            {
                return LeasingCalculation.InsurancePremium;
            }
        }

        public decimal InterestRate
        {
            get
            {
                return LeasingCalculation.InterestRate;
            }
        }

        public decimal PVResidualValue
        {
            get
            {
                return decimal.Subtract(BodyCost,LeasingCalculation.PV);
            }
        }

        public decimal PVAnnuity
        {
            get
            {
                return VehicleInterestCostList.PVofAnnuity;
            }
        }

        public int ForYear
        {
            get;
            set;
        }

        public decimal BodyPrice
        {
            get 
            {
                return BodyCost;
            }
        }

        public decimal ModifiedPrice
        {
            get
            {
                return ModifyCost;
            }
        }
        #endregion


        public decimal RealResidualValue
        {
            get
            {
                return decimal.Multiply(VehiclePrice, ResidualPercent) / 100;
            }
        }
    }
}
