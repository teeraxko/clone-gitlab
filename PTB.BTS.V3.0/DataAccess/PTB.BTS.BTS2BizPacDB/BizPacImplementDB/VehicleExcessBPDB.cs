using System;
using System.Data.SqlClient;
using System.Text;

using DataAccess.VehicleDB;
using PTB.BTS.BTS2BizPacEntity;
using ictus.Common.Entity;

namespace PTB.BTS.BTS2BizPacDB.BizPacImplementDB
{
    public class VehicleExcessBPDB : VehicleAccidentDB, IBizPacConnectDB
    {
        #region IBizPacConnectDB Members

        public string RefNoFieldName
        {
            get { return "Pay_To_Insurance_BizPac_Reference_No"; }
        }

        public string RefDateFiledName
        {
            get { return "Pay_To_Insurance_BizPac_Connection_Date"; }
        }

        public string GetSQLSelectBP
        {
            get { return getSQLSelect(); }
        }

        public bool FillIBPList(BTS2BizPacList listBP, Company company, SqlDataReader dataReader)
        {
            bool result = false;
            ExcessBP excessBP;

            while (dataReader.Read())
            {
                result = true;
                excessBP = new ExcessBP();
                fillVehicleAccident(excessBP, company, dataReader);
                listBP.Add(excessBP);
            }
            excessBP = null;
            return result;
        }

        public string GetSpecificSelectConditionBP
        {
            get{return " AND (Excess_Status = 'Y') AND (Insurance_Claim_No <> '') ";}
        }

        public string GetKeyConditionBP(IBTS2BizPacHeader condition)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (condition != null && IsNotNULL(((ExcessBP)condition).RepairingNo))
            {
                stringBuilder.Append(" AND (Accident_No = ");
                stringBuilder.Append(GetDB(((ExcessBP)condition).RepairingNo));
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();
        }

        public string GetBaseConditionBP(Company company)
        {
            return getBaseCondition(company);
        }

        public string GetOrderByBP
        {
            get { return getOrderby(); }
        }

        #endregion
    }
}
