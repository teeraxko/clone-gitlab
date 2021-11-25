using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.CommonDB;
using Entity.VehicleEntities.Leasing;

namespace DataAccess.VehicleDB
{
    public class TrProfitAndLostDB : DataAccessBase
    {
        //============================== Private Method ==============================
        private string getSQLInsert(IProfitAndLost profitAndLost)
        {
            StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Tr_Profit_And_Lost (Plate_No, Rental, Contract, Rental_Age, Remain, RemainingCostPV, ResidualValuePV, Sale, Compensate, Price, BV, Process_Date, Process_User) ");
            stringBuilder.Append(" VALUES ( ");

            //Plate_No
            stringBuilder.Append(GetDB(profitAndLost.Vehicle.PlateNumber));
            stringBuilder.Append(", ");

            //Rental			
            stringBuilder.Append(GetDB(profitAndLost.Rental));
            stringBuilder.Append(", ");

            //Contract
            stringBuilder.Append(GetDB(profitAndLost.Contract));
            stringBuilder.Append(", ");

            //Rental_Age
            stringBuilder.Append(GetDB(profitAndLost.RentalAge));
            stringBuilder.Append(", ");

            //Remain
            stringBuilder.Append(GetDB(profitAndLost.Remain));
            stringBuilder.Append(", ");

            //RemainingCostPV
            stringBuilder.Append(GetDB(profitAndLost.RemainingCostPV));
            stringBuilder.Append(", ");

            //ResidualValuePV
            stringBuilder.Append(GetDB(profitAndLost.ResidualValuePV));
            stringBuilder.Append(", ");

            //Sale
            stringBuilder.Append(GetDB(profitAndLost.Sale));
            stringBuilder.Append(", ");

            //Compensate
            stringBuilder.Append(GetDB(profitAndLost.Compensate));
            stringBuilder.Append(", ");

            //Price
            stringBuilder.Append(GetDB(profitAndLost.Price));
            stringBuilder.Append(", ");

            //BV
            stringBuilder.Append(GetDB(profitAndLost.BV));
            stringBuilder.Append(", ");

            //Process_Date
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");

            //Process_User
            stringBuilder.Append(GetDB(SystemFramework.AppConfig.UserProfile.UserID));
            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }

        //============================== Public Method ==============================
        public bool InsertProfitAndLost(ProfitAndLostList listPL)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < listPL.Count; i++)
            {
                stringBuilder.Append(getSQLInsert(listPL[i]));
            }

            return (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0);
        }

        public bool DeleteProfitAndLost()
        {
            return (tableAccess.ExecuteSQL(" DELETE FROM Tr_Profit_And_Lost ") > 0);
        }
    }
}
