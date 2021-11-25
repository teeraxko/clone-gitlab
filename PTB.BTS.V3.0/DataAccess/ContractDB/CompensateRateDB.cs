using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.CommonDB;
using Entity.ContractEntities;
using System.Data.SqlClient;
using SystemFramework.AppConfig;

namespace DataAccess.ContractDB
{
    public class CompensateRateDB : DataAccessBase
    {
        //============================== Constructor ==============================
        public CompensateRateDB()
            : base()
        {}

        //============================== Public method ==============================
        public Compensate GetCompensate()
        {
            Compensate compensate = null;

            SqlDataReader dataReader = tableAccess.ExecuteDataReader(" SELECT Compensate_Rate FROM Compensate_Rate ");
            try
            {
                if (dataReader.Read())
                {
                    compensate = new Compensate();
                    compensate.CompensateRate = dataReader.GetDecimal(0);
                }
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }

            finally
            { tableAccess.CloseDataReader(); }

            return compensate;
        }

        public bool MaintainCompensate(Compensate compensate)
        {
            StringBuilder stringBuilder = new StringBuilder(" DELETE FROM Compensate_Rate ");
            stringBuilder.Append(" INSERT INTO Compensate_Rate (Compensate_Rate, Process_Date, Process_User) ");
            stringBuilder.Append(" VALUES ( ");

            //Compensate_Rate
            stringBuilder.Append(GetDB(compensate.CompensateRate));
            stringBuilder.Append(", ");

            //Process_Date
            stringBuilder.Append(GetDateDB());
            stringBuilder.Append(", ");

            //Process_User
            stringBuilder.Append(GetDB(UserProfile.UserID));
            stringBuilder.Append(")");

            return tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0;
        }
    }
}
