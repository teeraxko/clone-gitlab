using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.CommonDB;
using Entity.VehicleEntities.ProfitCalculation;

namespace DataAccess.VehicleDB
{
    public class TrProfitCalculationDetailDB : DataAccessBase
    {
        //============================== Private Method ==============================
        private string getSQLInsert(ProfitCalDetail profitCalDetail)
        {
            StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Tr_Profit_Calculation_Detail (Group_Code, Line, Item, Year1, Year2, Year3, Year4, Year5) ");
            stringBuilder.Append(" VALUES ( ");

            //Group_Code
            stringBuilder.Append(GetDB(profitCalDetail.GroupCode));
            stringBuilder.Append(", ");

            //Line			
            stringBuilder.Append(GetDB(profitCalDetail.Line));
            stringBuilder.Append(", ");

            //Item
            stringBuilder.Append(GetDB(profitCalDetail.Item));
            stringBuilder.Append(", ");

            //Year1
            stringBuilder.Append(GetDB(profitCalDetail.Year1));
            stringBuilder.Append(", ");

            //Year2
            stringBuilder.Append(GetDB(profitCalDetail.Year2));
            stringBuilder.Append(", ");

            //Year3
            stringBuilder.Append(GetDB(profitCalDetail.Year3));
            stringBuilder.Append(", ");

            //Year4
            stringBuilder.Append(GetDB(profitCalDetail.Year4));
            stringBuilder.Append(", ");

            //Year5
            stringBuilder.Append(GetDB(profitCalDetail.Year5));
            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }

        //============================== Public Method ==============================
        public bool InsertProfitCalDetail(ProfitCalDetailList listCal)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(" DELETE FROM Tr_Profit_Calculation_Detail; ");

            for (int i = 0; i < listCal.Count; i++)
            {
                stringBuilder.Append(getSQLInsert(listCal[i]));
            }

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }
    }
}
