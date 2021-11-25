using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.CommonDB;
using Entity.VehicleEntities.Leasing;
using SystemFramework.AppConfig;

namespace DataAccess.VehicleDB
{
    public class TrInterestCostHeadDB : DataAccessBase
    {
        //============================== Private Method ==============================
        private string getSQLInsert(InterestCostList listCost)
        {
            StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Tr_Interest_Cost_Head (Total_Cost, Lease_Term, Residual_Value, Rate, PV_Residual_Value, PV_Annuity_Rental, Process_Date, Process_User) ");
            stringBuilder.Append(" VALUES ( ");

            //Total_Cost
            stringBuilder.Append(GetDB(listCost.TotalCost));
            stringBuilder.Append(", ");

            //Lease_Term			
            stringBuilder.Append(GetDB(listCost.LeaseTerm));
            stringBuilder.Append(", ");

            //Residual_Value
            stringBuilder.Append(GetDB(listCost.ResidualValue));
            stringBuilder.Append(", ");

            //Rate
            stringBuilder.Append(GetDB(listCost.Rate));
            stringBuilder.Append(", ");

            //PV_Residual_Value
            stringBuilder.Append(GetDB(listCost.PVofResidualValue));
            stringBuilder.Append(", ");

            //PV_Annuity_Rental
            stringBuilder.Append(GetDB(listCost.PVofAnnuity));
            stringBuilder.Append(", ");

            //Process_Date
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");

            //Process_User
            stringBuilder.Append(GetDB(UserProfile.UserID));
            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }

        //============================== Public Method ==============================
        public bool InsertInterestCostHead(InterestCostList listCost)
        {
            return (tableAccess.ExecuteSQL(getSQLInsert(listCost)) > 0);
        }

        public bool DeleteInterestCostHead()
        {
            return (tableAccess.ExecuteSQL(" DELETE FROM Tr_Interest_Cost_Head ") > 0);
        }
    }
}
