using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.CommonDB;
using Entity.VehicleEntities.ProfitCalculation;
using Entity.VehicleEntities.VehicleLeasing;

namespace DataAccess.VehicleDB.VehicleLeasingDB
{
    public class VehicleTrProfitCalculationHeadDB : DataAccessBase
    {
        //============================== Private Method ==============================
        private string getSQLInsert(IVehicleProfitCalHead profitCalHeader)
        {
            StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Tr_Profit_Calculation_Head (Customer, VehicleModel, Body_Price, Modified_Price, Percent_Residual, Residual_Value, Lease_Term, Rate_Of_Return, PV, Monthly_PMT, Monthly_Insurance_Premium, Monthly_VehicleTax, Monthly_Maintenance, Monthly_Charge_Actual, Monthly_Charge, Capital_Insurance, Insurance_Premium, Interest_Rate, PV_Residual_Value, PV_Annuity, For_Year ,Leasing_No) ");
            stringBuilder.Append(" VALUES ( ");

            //Customer
            stringBuilder.Append(GetDB(profitCalHeader.Customer));
            stringBuilder.Append(", ");

            //VehicleModel			
            stringBuilder.Append(GetDB(profitCalHeader.VehicleModel));
            stringBuilder.Append(", ");

            //Body_Price
            stringBuilder.Append(GetDB(profitCalHeader.BodyPrice));
            stringBuilder.Append(", ");

            //Modified_Price
            stringBuilder.Append(GetDB(profitCalHeader.ModifiedPrice));
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
            stringBuilder.Append(GetDB(profitCalHeader.RateOfReturnEstimate));
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
            stringBuilder.Append(GetDB(profitCalHeader.MonthlyChargeActual));
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
            stringBuilder.Append(", ");

            //For_Year

            if (profitCalHeader.LeasingNo != null) {

            stringBuilder.Append(GetDB(profitCalHeader.LeasingNo));

            }else{

            stringBuilder.Append("Null");
            
            }


            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }

        //============================== Public Method ==============================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="calHeader"></param>
        /// <param name="hasContract">true if it had issued contract, so report will show Rate of Retern Actaul else show Rate of Return Estimate</param>
        /// <returns></returns>
        public bool InsertProfitCalDetail(IVehicleProfitCalHead calHeader)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(" DELETE FROM Tr_Profit_Calculation_Head; ");
            stringBuilder.Append(getSQLInsert(calHeader));

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }
    }
}
