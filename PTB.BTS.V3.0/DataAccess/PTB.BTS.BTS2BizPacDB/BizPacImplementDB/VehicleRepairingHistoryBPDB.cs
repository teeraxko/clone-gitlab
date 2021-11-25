using System;
using System.Data.SqlClient;
using System.Text;

using Entity.VehicleEntities;
using DataAccess.CommonDB;
using PTB.BTS.BTS2BizPacEntity;
using ictus.Common.Entity;
using DataAccess.VehicleDB;

namespace PTB.BTS.BTS2BizPacDB.BizPacImplementDB
{
    public class VehicleRepairingHistoryBPDB : VehicleRepairingHistoryDB, IBizPacConnectDB
    {
        #region IBizPacConnectDB Members
        public string RefNoFieldName
        {
            get { return "BizPac_Reference_No"; }
        }

        public string RefDateFiledName
        {
            get { return "BizPac_Connection_Date"; }
        }

        public string GetSQLSelectBP
        {
            get { return getSQLSelect(); }
        }
        
        public string GetSpecificSelectConditionBP
        {
            get { return " AND (Total_Amount > 0) "; }
        }

        public bool FillIBPList(BTS2BizPacList listBP, Company company, SqlDataReader dataReader)
        {
            bool result = false;
            RepairingBP repairingBP;

            while (dataReader.Read())
            {
                result = true;
                repairingBP = new RepairingBP();
                fillVehicleRepairingHistory(repairingBP, company, dataReader);
                listBP.Add(repairingBP);
            }
            repairingBP = null;
            return result;
        }

        public string GetKeyConditionBP(IBTS2BizPacHeader condition)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (condition != null && (((RepairingBP)condition).RepairingNo != ""))
            {
                stringBuilder.Append(" AND (Repairing_No = ");
                stringBuilder.Append(GetDB(((RepairingBP)condition).RepairingNo));
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
            get { return " ORDER BY Repairing_No "; }
        }

        #endregion
    }
}
