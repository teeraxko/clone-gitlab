using System;
using System.Text;

using DataAccess.VehicleDB;
using ictus.Common.Entity;
using System.Data.SqlClient;
using PTB.BTS.BTS2BizPacEntity;

namespace PTB.BTS.BTS2BizPacDB.BizPacImplementDB
{
    public class InsuranceTypeOneBPDB : InsuranceTypeOneDB, IBizPacConnectDB
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

        public bool FillIBPList(BTS2BizPacList listBP, Company company, SqlDataReader dataReader)
        {
            bool result = false;
            InsuranceTypeOneBP insuranceTypeOneBP;

            while (dataReader.Read())
            {
                result = true;
                insuranceTypeOneBP = new InsuranceTypeOneBP();
                fillInsuranceTypeOne(insuranceTypeOneBP, company, dataReader);
                listBP.Add(insuranceTypeOneBP);
            }
            insuranceTypeOneBP = null;
            return result;
        }

        public string GetSpecificSelectConditionBP
        {
            get { return " AND (Tax_Invoice_No <> '') "; }
            //get { return " AND (Tax_Invoice_No <> '') AND ((Start_Date <= GETDATE()) AND (End_Date >= GETDATE())) "; }
        }

        public string GetKeyConditionBP(IBTS2BizPacHeader condition)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (IsNotNULL(((InsuranceTypeOneBP)condition).PolicyNo))
            {
                stringBuilder.Append(" AND (Policy_No = ");
                stringBuilder.Append(GetDB(((InsuranceTypeOneBP)condition).PolicyNo));
                stringBuilder.Append(" ) ");
            }
            return stringBuilder.ToString();
        }

        public string GetBaseConditionBP(Company company)
        {
            return getBaseCondition(company);
        }

        #endregion

        #region IBizPacConnectDB Members


        public string GetOrderByBP
        {
            get { return getOrderBy(); }
        }

        #endregion
    }
}
