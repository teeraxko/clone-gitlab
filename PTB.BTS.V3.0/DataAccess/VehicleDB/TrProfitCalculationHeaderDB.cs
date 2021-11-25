using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.CommonDB;
using Entity.VehicleEntities.ProfitCalculation;

namespace DataAccess.VehicleDB
{
    public class TrProfitCalculationHeaderDB : DataAccessBase
    {
        //============================== Private Method ==============================
        private string getSQLInsert(IProfitCalHeader profitCalHeader)
        {
            StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Tr_Profit_Calculation_Header (Customer, VehicleModel, VehiclePrice, ResidualPercent, ResidualValue, LeaseTerm, RateOfReturn, PV, Monthly_PMT, Monthly_Insurance_Premium, Monthly_VehicleTax, Monthly_Maintenance, Monthly_Actual_Charge, Monthly_Charge, Capital_Insurance, Insurance_Premium, Interest_Rate, PV_ResidualValue, PV_Annuity, For_Year) ");
            stringBuilder.Append(" VALUES ( ");

            //Customer
            stringBuilder.Append(GetDB(profitCalHeader.Customer));
            stringBuilder.Append(", ");

            //VehicleModel			
            stringBuilder.Append(GetDB(profitCalHeader.VehicleModel));
            stringBuilder.Append(", ");

            //VehiclePrice
            stringBuilder.Append(GetDB(profitCalHeader.VehiclePrice));
            stringBuilder.Append(", ");

            //ResidualPercent
            stringBuilder.Append(GetDB(profitCalHeader.ResidualPercent));
            stringBuilder.Append(", ");

            //ResidualValue
            stringBuilder.Append(GetDB(profitCalHeader.ResidualValue));
            stringBuilder.Append(", ");

            //LeaseTerm
            stringBuilder.Append(GetDB(profitCalHeader.LeaseTerm));
            stringBuilder.Append(", ");

            //RateOfReturn
            stringBuilder.Append(GetDB(profitCalHeader.RateOfReturn));
            stringBuilder.Append(", ");

            //PV
            stringBuilder.Append(GetDB(profitCalHeader.PV));
            stringBuilder.Append(", ");

            //Monthly_PMT
            stringBuilder.Append(GetDB(profitCalHeader.MonthlyPMT));
            stringBuilder.Append(", ");

            //Monthly_Insurance_Premium
            stringBuilder.Append(GetDB(profitCalHeader.MonthlyInsurancePremium));
            stringBuilder.Append(", ");

            //Monthly_VehicleTax
            stringBuilder.Append(GetDB(profitCalHeader.MonthlyVehicleTax));
            stringBuilder.Append(", ");

            //Monthly_Maintenance
            stringBuilder.Append(GetDB(profitCalHeader.MonthlyMaintenance));
            stringBuilder.Append(", ");

            //Monthly_Actual_Charge
            stringBuilder.Append(GetDB(profitCalHeader.MonthlyActualCharge));
            stringBuilder.Append(", ");

            //Monthly_Charge
            stringBuilder.Append(GetDB(profitCalHeader.MonthlyCharge));
            stringBuilder.Append(", ");

            //Capital_Insurance
            stringBuilder.Append(GetDB(profitCalHeader.CapitalInsurance));
            stringBuilder.Append(", ");

            //Insurance_Premium
            stringBuilder.Append(GetDB(profitCalHeader.InsurancePremium));
            stringBuilder.Append(", ");

            //Interest_Rate
            stringBuilder.Append(GetDB(profitCalHeader.InterestRate));
            stringBuilder.Append(", ");

            //PV_ResidualValue
            stringBuilder.Append(GetDB(profitCalHeader.PVResidualValue));
            stringBuilder.Append(", ");

            //PV_Annuity
            stringBuilder.Append(GetDB(profitCalHeader.PVAnnuity));
            stringBuilder.Append(", ");

            //For_Year
            stringBuilder.Append(GetDB(profitCalHeader.ForYear));
            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }

        //============================== Public Method ==============================
        public bool InsertProfitCalDetail(IProfitCalHeader calHeader)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(" DELETE FROM Tr_Profit_Calculation_Header; ");
            stringBuilder.Append(getSQLInsert(calHeader));

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }
    }
}
