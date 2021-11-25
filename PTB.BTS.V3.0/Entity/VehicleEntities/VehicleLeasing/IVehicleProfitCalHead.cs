using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.VehicleEntities.VehicleLeasing
{
    public interface IVehicleProfitCalHead
    {
        string Customer
        {
            get;
        }

        string VehicleModel
        {
            get;
        }

        decimal VehiclePrice
        {
            get;
        }

        decimal ResidualPercent
        {
            get;
        }

        decimal ResidualValue
        {
            get;
        }

        int LeaseTerm
        {
            get;
        }

        decimal RateOfReturnEstimate
        {
            get;
        }

        decimal RateOfReturnActual
        {
            get;
        }

        decimal PV
        {
            get;
        }

        decimal MonthlyPMT
        {
            get;
        }

        decimal MonthlyInsurancePremium
        {
            get;
        }

        decimal MonthlyVehicleTax
        {
            get;
        }

        decimal MonthlyMaintenance
        {
            get;
        }

        decimal MonthlyMaintenanceActual
        {
            get;
        }

        decimal MonthlyChargeActual
        {
            get;
        }

        decimal MonthlyCharge
        {
            get;
        }

        decimal CapitalInsurance
        {
            get;
        }

        decimal InsurancePremium
        {
            get;
        }

        decimal InterestRate
        {
            get;
        }

        decimal PVResidualValue
        {
            get;
        }

        decimal PVAnnuity
        {
            get;
        }

        int ForYear
        {
            get;
            set;
        }

        string LeasingNo
        {
            get;
            set;
        }

        decimal BodyPrice
        {
            get;
        }

        decimal ModifiedPrice
        {
            get;
        }   
    }
}
