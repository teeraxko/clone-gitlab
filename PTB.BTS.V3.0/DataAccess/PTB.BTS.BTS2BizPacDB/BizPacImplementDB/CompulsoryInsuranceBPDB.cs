using System;
using DataAccess.VehicleDB;
using PTB.BTS.BTS2BizPacEntity;
using ictus.Common.Entity;
using System.Data.SqlClient;
using System.Text;
using ictus.Common.Entity.Time;

namespace PTB.BTS.BTS2BizPacDB.BizPacImplementDB
{
    public class CompulsoryInsuranceBPDB : CompulsoryInsuranceDB, IBizPacConnectDB
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
            CompulsoryInsuranceBP compulsoryInsuranceBP;

            while (dataReader.Read())
            {
                result = true;
                compulsoryInsuranceBP = new CompulsoryInsuranceBP();
                fillCompulsoryInsurance(compulsoryInsuranceBP, company, dataReader);
                listBP.Add(compulsoryInsuranceBP);
            }
            compulsoryInsuranceBP = null;
            return result;
        }

        public string GetSpecificSelectConditionBP
        {
            get { return " AND (Tax_Invoice_No <> '') AND (Tax_Invoice_Date <= " + GetDB((new YearMonth(DateTime.Today)).MaxDateOfMonth) + ") "; }
        }

        public string GetKeyConditionBP(IBTS2BizPacHeader condition)
        {
			StringBuilder stringBuilder = new StringBuilder();
			if (condition != null && IsNotNULL(((CompulsoryInsuranceBP)condition).PolicyNo))
			{
				stringBuilder.Append(" AND (Policy_No = ");
                stringBuilder.Append(GetDB(((CompulsoryInsuranceBP)condition).PolicyNo));
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