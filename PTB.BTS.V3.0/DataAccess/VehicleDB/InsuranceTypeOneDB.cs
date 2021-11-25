using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entity.CommonEntity;
using Entity.VehicleEntities;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity;
using ictus.Common.Entity.General;
using Entity.AttendanceEntities;

namespace DataAccess.VehicleDB
{
    public class InsuranceTypeOneDB : DataAccessBase, DataAccess.CommonDB.ITableName
	{
		#region - Constant -
		private const int POLICY_NO = 0;
		private const int INSURANCE_COMPANY_CODE = 1;
		private const int START_DATE = 2;
		private const int END_DATE = 3;
		private const int INSURANCE_INCHARGE_NAME = 4;
		private const int INSURANCE_INCHARGE_TEL_NO = 5;
        private const int TAX_INVOICE_NO = 6;
        private const int TAX_INVOICE_DATE = 7;
        private const int TOTAL_PREMIUM_AMOUNT = 8;
        private const int VAT_AMOUNT = 9;
        private const int REVENUE_STAMP_FEE = 10;
		#endregion

		#region - Private -
		private InsuranceCompanyDB dbInsuranceCompany;
		private InsuranceTypeOne objInsuranceTypeOne;
		private bool disposed = false;
		#endregion

//		============================== Constructor ==============================
		public InsuranceTypeOneDB() : base()
		{
			dbInsuranceCompany = new InsuranceCompanyDB();
		}

//		============================== Private Method ==============================
		#region - getSQL -
		protected string getSQLSelect()
		{
            return " SELECT Policy_No, Insurance_Company_Code, Start_Date, End_Date, Insurance_Incharge_Name, Insurance_Incharge_Tel_No, Tax_Invoice_No, Tax_Invoice_Date, Total_Premium_Amount, VAT_Amount, Revenue_Stamp_Fee FROM Insurance_Type_One ";
		}

		private string getSQLInsert(InsuranceTypeOne value, Company aCompany)
		{
            StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Insurance_Type_One (Company_Code, Policy_No, Insurance_Company_Code, Start_Date, End_Date, Insurance_Incharge_Name, Insurance_Incharge_Tel_No, Tax_Invoice_No, Tax_Invoice_Date, Total_Premium_Amount, VAT_Amount, Revenue_Stamp_Fee, Process_Date, Process_User) ");
			stringBuilder.Append(" VALUES ( ");

			//Company_Code
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			//Policy_No
			stringBuilder.Append(GetDB(value.PolicyNo));
			stringBuilder.Append(", ");
			
			//Insurance_Company_Code
			stringBuilder.Append(GetDB(value.AInsuranceCompany.Code));
			stringBuilder.Append(", ");

			//Start_Date
			stringBuilder.Append(GetDB(value.APeriod.From));
			stringBuilder.Append(", ");

			//End_Date
			stringBuilder.Append(GetDB(value.APeriod.To));
			stringBuilder.Append(", ");

			//Insurance_Incharge_Name
			stringBuilder.Append(GetDB(value.InsuranceInchargeName));
			stringBuilder.Append(", ");

			//Insurance_Incharge_Tel_No
			stringBuilder.Append(GetDB(value.InsuranceInchargeTelNo));
			stringBuilder.Append(", ");

            //Tax_Invoice_No
            stringBuilder.Append(GetDB(value.TaxInvoiceNo));
            stringBuilder.Append(", ");

            //Tax_Invoice_Date
            stringBuilder.Append(GetDB(value.TaxInvoiceDate));
            stringBuilder.Append(", ");

            //Total_Premium_Amount
            stringBuilder.Append(GetDB(value.PremiumAmount));
            stringBuilder.Append(", ");

            //VAT_Amount
            stringBuilder.Append(GetDB(value.VatAmount));
            stringBuilder.Append(", ");

            //Revenue_Stamp_Fee
            stringBuilder.Append(GetDB(value.RevenueStampFee));
            stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(InsuranceTypeOne value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Insurance_Type_One SET ");
			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Policy_No = ");
			stringBuilder.Append(GetDB(value.PolicyNo));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Insurance_Company_Code = ");
			stringBuilder.Append(GetDB(value.AInsuranceCompany.Code));
			stringBuilder.Append(", ");

			stringBuilder.Append("Start_Date = ");
			stringBuilder.Append(GetDB(value.APeriod.From));
			stringBuilder.Append(", ");

			stringBuilder.Append("End_Date = ");
			stringBuilder.Append(GetDB(value.APeriod.To));
			stringBuilder.Append(", ");

			stringBuilder.Append("Insurance_Incharge_Name = ");
			stringBuilder.Append(GetDB(value.InsuranceInchargeName));
			stringBuilder.Append(", ");

			stringBuilder.Append("Insurance_Incharge_Tel_No = ");
			stringBuilder.Append(GetDB(value.InsuranceInchargeTelNo));
			stringBuilder.Append(", ");

            stringBuilder.Append("Tax_Invoice_No = ");
            stringBuilder.Append(GetDB(value.TaxInvoiceNo));
            stringBuilder.Append(", ");

            stringBuilder.Append("Tax_Invoice_Date = ");
            stringBuilder.Append(GetDB(value.TaxInvoiceDate));
            stringBuilder.Append(", ");

            stringBuilder.Append("Total_Premium_Amount = ");
            stringBuilder.Append(GetDB(value.PremiumAmount));
            stringBuilder.Append(", ");

            stringBuilder.Append("VAT_Amount = ");
            stringBuilder.Append(GetDB(value.VatAmount));
            stringBuilder.Append(", ");

            stringBuilder.Append("Revenue_Stamp_Fee = ");
            stringBuilder.Append(GetDB(value.RevenueStampFee));
            stringBuilder.Append(", ");

			stringBuilder.Append("Process_Date = ");
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			stringBuilder.Append("Process_User = ");
			stringBuilder.Append(GetDB(UserProfile.UserID));
		
			return stringBuilder.ToString();
		}

		private string getSQLDelete()
		{
			return " DELETE FROM Insurance_Type_One ";
		}

		protected sealed override string getBaseCondition(Company value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (IsNotNULL(value.CompanyCode))
			{
				stringBuilder.Append(" WHERE (Insurance_Type_One.Company_Code = ");
				stringBuilder.Append(GetDB(value.CompanyCode));
				stringBuilder.Append(")");
			}			
			return stringBuilder.ToString();
		}

		private string getKeyCondition(InsuranceTypeOne value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (IsNotNULL(value.PolicyNo))
			{
				stringBuilder.Append(" AND (Policy_No = ");
				stringBuilder.Append(GetDB(value.PolicyNo));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

        private string getEntityCondition(DateTime fromDate)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (IsNotNULL(fromDate))
            {
                stringBuilder.Append(" AND (YEAR(Start_Date) = ");
                stringBuilder.Append(GetDB(fromDate.Year));
                stringBuilder.Append(") AND (MONTH(Start_Date) = ");
                stringBuilder.Append(GetDB(fromDate.Month));
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();
        }


        protected string getOrderBy()
        {
            return " ORDER BY Policy_No";
        }

		#endregion

		#region - Fill -
        protected virtual InsuranceTypeOne getNewInsuranceTypeOne(Company aCompany)
        {
            return new InsuranceTypeOne(aCompany);
        }

        protected void fillInsuranceTypeOne(InsuranceTypeOne value, Company aCompany, SqlDataReader dataReader)
		{
			value.PolicyNo = (string)dataReader[POLICY_NO];
			value.AInsuranceCompany = dbInsuranceCompany.GetDBInsuranceCompany((string)dataReader[INSURANCE_COMPANY_CODE], aCompany);
			value.APeriod.From = dataReader.GetDateTime(START_DATE);
			value.APeriod.To = dataReader.GetDateTime(END_DATE);
			value.InsuranceInchargeName = (string)dataReader[INSURANCE_INCHARGE_NAME];
			value.InsuranceInchargeTelNo = (string)dataReader[INSURANCE_INCHARGE_TEL_NO];
            value.TaxInvoiceNo = (string)dataReader[TAX_INVOICE_NO];

            if (dataReader.IsDBNull(TAX_INVOICE_DATE))
            {
                value.TaxInvoiceDate = NullConstant.DATETIME;
            }
            else
            {
                value.TaxInvoiceDate = dataReader.GetDateTime(TAX_INVOICE_DATE);            
            }

            value.PremiumAmount = dataReader.GetDecimal(TOTAL_PREMIUM_AMOUNT);
            value.VatAmount = dataReader.GetDecimal(VAT_AMOUNT);
            value.RevenueStampFee = dataReader.GetDecimal(REVENUE_STAMP_FEE);
		}

		private bool fillInsuranceTypeOne(ref InsuranceTypeOne value, Company aCompany, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{
					fillInsuranceTypeOne(value, aCompany, dataReader);
					result = true;
				}
				else
				{result = false;}
			}
			catch (IndexOutOfRangeException ein)
			{throw ein;}

			finally
			{tableAccess.CloseDataReader();}			
			return result;				
		}

		private bool fillInsuranceTypeOneList(ref InsuranceTypeOneList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
                    objInsuranceTypeOne = getNewInsuranceTypeOne(value.Company);
					fillInsuranceTypeOne(objInsuranceTypeOne, value.Company, dataReader);
					value.Add(objInsuranceTypeOne);
				}
				objInsuranceTypeOne = null;
			}
			catch(IndexOutOfRangeException ein)
			{throw ein;}

			finally
			{tableAccess.CloseDataReader();}
			return result;		
		}
		#endregion

//		============================== Public Method ==============================
		public InsuranceTypeOne GetInsuranceTypeOne(string policyNo, Company aCompany)
		{
            objInsuranceTypeOne = getNewInsuranceTypeOne(aCompany);
			objInsuranceTypeOne.AVehicleInsuranceList = new VehicleInsuranceList(aCompany);
			objInsuranceTypeOne.PolicyNo = policyNo;

			if(FillInsuranceTypeOne(ref objInsuranceTypeOne))
			{
				return objInsuranceTypeOne;
			}
			else 
			{
				objInsuranceTypeOne = null;
				return null;
			}
		}


		public bool FillLatestInsuranceTypeOne(ref InsuranceTypeOne value)
		{
			StringBuilder stringBuilder = new StringBuilder("SELECT Insurance_Type_One.Policy_No, Insurance_Type_One.Insurance_Company_Code, Insurance_Type_One.Start_Date, Insurance_Type_One.End_Date, Insurance_Type_One.Insurance_Incharge_Name, Insurance_Type_One.Insurance_Incharge_Tel_No ");

			return fillInsuranceTypeOne(ref value, value.AVehicleInsuranceList.Company, stringBuilder.ToString());
		}

		public bool FillInsuranceTypeOne(ref InsuranceTypeOne value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.AVehicleInsuranceList.Company));
			stringBuilder.Append(getKeyCondition(value));

			return fillInsuranceTypeOne(ref value, value.AVehicleInsuranceList.Company, stringBuilder.ToString());
		}

		public bool FillExpireInsuranceTypeOneList(ref InsuranceTypeOneList value, DateTime expireDate)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(" AND End_Date <= ");
			stringBuilder.Append(GetDB(expireDate));

			return fillInsuranceTypeOneList(ref value, stringBuilder.ToString());
		}

		public bool FillInsuranceTypeOneList(ref InsuranceTypeOneList value, InsuranceTypeOne aInsuranceTypeOne)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getKeyCondition(aInsuranceTypeOne));
            stringBuilder.Append(getOrderBy());

			return fillInsuranceTypeOneList(ref value, stringBuilder.ToString());
		}

        public bool FillInsuranceTypeOneList(ref InsuranceTypeOneList value, string endDate, string companyInsuranceCode)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.Company));

            if (endDate != "")
            {
                stringBuilder.Append(" AND (YEAR(End_Date) = ");
                stringBuilder.Append(GetDB(endDate));
                stringBuilder.Append(")");
            }
            if (companyInsuranceCode != "")
            {
                stringBuilder.Append(" AND (Insurance_Company_Code = ");
                stringBuilder.Append(GetDB(companyInsuranceCode));
                stringBuilder.Append(")");
            }
            stringBuilder.Append(getOrderBy());

            return fillInsuranceTypeOneList(ref value, stringBuilder.ToString());
        }

        public bool FillInsuranceTypeOneByFromDateList(InsuranceTypeOneList value, DateTime fromDate)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getEntityCondition(fromDate));
            stringBuilder.Append(getOrderBy());

            return fillInsuranceTypeOneList(ref value, stringBuilder.ToString());
        }

		public bool InsertInsuranceTypeOne(InsuranceTypeOne value, Company aCompany)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aCompany))>0)
			{return true;}
			else
			{return false;}	
		}

        public bool UpdateInsuranceTypeOne(InsuranceTypeOne value, Company aCompany)
		{
            StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aCompany));
            stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

        public bool DeleteInsuranceTypeOne(InsuranceTypeOne value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
            stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}
		#region IDisposable Members
		protected override void Dispose(bool disposing)
		{
			if(!this.disposed)
			{
				try
				{
					if(disposing)
					{
					}
					this.disposed = true;
				}
				finally
				{
					base.Dispose(disposing);
				}
			}
		}
		#endregion

        #region ITableName Members

        public string TableName
        {
            get { return "Insurance_Type_One"; }
        }

        #endregion
    }
}
