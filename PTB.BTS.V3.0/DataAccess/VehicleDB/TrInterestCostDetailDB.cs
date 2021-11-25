using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.CommonDB;
using Entity.VehicleEntities.Leasing;
using SystemFramework.AppConfig;

namespace DataAccess.VehicleDB
{
    public class TrInterestCostDetailDB : DataAccessBase
    {
        //============================== Private Method ==============================
        private string getSQLInsert(InterestCost interestCost)
        {
            StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Tr_Interest_Cost_Detail ([Year], [Month], Payment, Interest, Cost, Carrying, Process_Date, Process_User) ");
            stringBuilder.Append(" VALUES ( ");

            //[Year]
            stringBuilder.Append(GetDB(interestCost.Year));
            stringBuilder.Append(", ");

            //[Month]			
            stringBuilder.Append(GetDB(interestCost.Month));
            stringBuilder.Append(", ");

            //Payment
            stringBuilder.Append(GetDB(interestCost.Payment));
            stringBuilder.Append(", ");

            //Interest
            stringBuilder.Append(GetDB(interestCost.Interest));
            stringBuilder.Append(", ");

            //Cost
            stringBuilder.Append(GetDB(interestCost.Cost));
            stringBuilder.Append(", ");

            //Carrying
            stringBuilder.Append(GetDB(interestCost.CarryingValue));
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
        public bool InsertInterestCostDetail(InterestCostList listCost)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < listCost.Count; i++)
            {
                stringBuilder.Append(getSQLInsert(listCost[i]));
            }

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }

        public bool DeleteInterestCostDetail()
        {
            return (tableAccess.ExecuteSQL(" DELETE FROM Tr_Interest_Cost_Detail ") > 0);
        }
    }
}
