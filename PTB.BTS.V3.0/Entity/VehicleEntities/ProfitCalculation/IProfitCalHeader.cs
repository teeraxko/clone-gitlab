using System;
using System.Collections.Generic;
using System.Text;
using Entity.ContractEntities;

namespace Entity.VehicleEntities.ProfitCalculation
{
    public interface IProfitCalHeader
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

        decimal RateOfReturn
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

        decimal MonthlyActualCharge
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
        }
    }
}
