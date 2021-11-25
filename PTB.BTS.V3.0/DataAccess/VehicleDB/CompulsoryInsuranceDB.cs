using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;

using Entity.CommonEntity;
using Entity.VehicleEntities;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

using ictus.Common.Entity;
using ictus.Common.Entity.General;

namespace DataAccess.VehicleDB
{
    public class CompulsoryInsuranceDB : DataAccessBase, DataAccess.CommonDB.ITableName
	{
		#region - Constant -
		private const int POLICY_NO = 0;
		private const int VEHICLE_NO = 1;
		private const int START_DATE = 2;
		private const int END_DATE = 3;
		private const int INSURANCE_COMPANY_CODE = 4;
		private const int PREMIUM_AMOUNT = 5;
		private const int VAT_AMOUNT = 6;
		private const int REVENUE_STAMP_FEE = 7;
        private const int TAX_INVOICE_NO = 8;
        private const int TAX_INVOICE_DATE = 9;
		#endregion

		#region - Private -
		private CompulsoryInsurance objCompulsoryInsurance;
		private InsuranceCompanyDB dbInsuranceCompany;
		private VehicleDB dbVehicle;
		private bool disposed = false;
		#endregion

//		============================== Constructor ==============================
		public CompulsoryInsuranceDB() : base()
		{
			dbVehicle = new VehicleDB();
			dbInsuranceCompany = new InsuranceCompanyDB();
		}

//		============================== Private Method ==============================
		#region - getSQL -
		protected string getSQLSelect()
		{
			return " SELECT Policy_No, Vehicle_No, Start_Date, End_Date, Insurance_Company_Code, Premium_Amount, VAT_Amount, Revenue_Stamp_Fee, Tax_Invoice_No, Tax_Invoice_Date FROM Compulsory_Insurance ";
		}

		private string getSQLInsert(CompulsoryInsurance value, Company aCompany)
		{
            StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Compulsory_Insurance (Company_Code, Policy_No, Vehicle_No, Start_Date, End_Date, Insurance_Company_Code, Premium_Amount, VAT_Amount, Revenue_Stamp_Fee, Tax_Invoice_No, Tax_Invoice_Date, Process_Date, Process_User) ");
			stringBuilder.Append(" VALUES ( ");

			//Company_Code			
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");
			
			//Policy_No
			stringBuilder.Append(GetDB(value.PolicyNo));
			stringBuilder.Append(", ");
			
			//Vehicle_No
			stringBuilder.Append(GetDB(value.AVehicle.VehicleNo));
			stringBuilder.Append(", ");

			//Start_Date
			stringBuilder.Append(GetDB(value.APeriod.From));
			stringBuilder.Append(", ");
			
			//End_Date
			stringBuilder.Append(GetDB(value.APeriod.To));
			stringBuilder.Append(", ");
			
			//Insurance_Company_Code
			stringBuilder.Append(GetDB(value.AInsuranceCompany.Code));
			stringBuilder.Append(", ");
			
			//Premium_Amount
			stringBuilder.Append(GetDB(value.PremiumAmount));
			stringBuilder.Append(", ");
			
			//VAT_Amount
			stringBuilder.Append(GetDB(value.VatAmount));
			stringBuilder.Append(", ");
			
			//Revenue_Stamp_Fee
			stringBuilder.Append(GetDB(value.RevenueStampFee));
			stringBuilder.Append(", ");

            //Tax_Invoice_No
            stringBuilder.Append(GetDB(value.TaxInvoiceNo));
            stringBuilder.Append(", ");

            //Tax_Invoice_Date
            stringBuilder.Append(GetDB(value.TaxInvoiceDate));
            stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(CompulsoryInsurance value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(" UPDATE Compulsory_Insurance SET ");

			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Policy_No = ");
			stringBuilder.Append(GetDB(value.PolicyNo));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Vehicle_No = ");
			stringBuilder.Append(GetDB(value.AVehicle.VehicleNo));
			stringBuilder.Append(", ");

			stringBuilder.Append("Start_Date = ");
			stringBuilder.Append(GetDB(value.APeriod.From));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("End_Date = ");
			stringBuilder.Append(GetDB(value.APeriod.To));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Insurance_Company_Code = ");
			stringBuilder.Append(GetDB(value.AInsuranceCompany.Code));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Premium_Amount = ");
			stringBuilder.Append(GetDB(value.PremiumAmount));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("VAT_Amount = ");
			stringBuilder.Append(GetDB(value.VatAmount));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Revenue_Stamp_Fee = ");
			stringBuilder.Append(GetDB(value.RevenueStampFee));
			stringBuilder.Append(", ");

            stringBuilder.Append("Tax_Invoice_No = ");
            stringBuilder.Append(GetDB(value.TaxInvoiceNo));
            stringBuilder.Append(", ");

            stringBuilder.Append("Tax_Invoice_Date = ");
            stringBuilder.Append(GetDB(value.TaxInvoiceDate));
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
			return " DELETE FROM Compulsory_Insurance ";
		}

		private string getKeyCondition(CompulsoryInsurance value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (IsNotNULL(value.PolicyNo))
			{
				stringBuilder.Append(" AND (Policy_No = ");
				stringBuilder.Append(GetDB(value.PolicyNo));
				stringBuilder.Append(")");
			}
			if (value.AVehicle!= null && IsNotNULL(value.AVehicle.VehicleNo))
			{
				stringBuilder.Append(" AND (Vehicle_No = ");
				stringBuilder.Append(GetDB(value.AVehicle.VehicleNo));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

        private string getEntityEndDateCondition(YearMonth value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" AND (YEAR(End_Date) = ");
			stringBuilder.Append(GetDB(value.Year));
			stringBuilder.Append(")");				
			stringBuilder.Append(" AND (MONTH(End_Date) = ");
			stringBuilder.Append(GetDB(value.Month));
			stringBuilder.Append(")");					

			return stringBuilder.ToString();
		}

        private string getEntityStartDateCondition(YearMonth value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(" AND (YEAR(Start_Date) = ");
            stringBuilder.Append(GetDB(value.Year));
            stringBuilder.Append(")");
            stringBuilder.Append(" AND (MONTH(Start_Date) = ");
            stringBuilder.Append(GetDB(value.Month));
            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }

		private string getCurrentCompulsoryInsuranceCondition(CompulsoryInsurance value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if ((value.AVehicle != null)&&(IsNotNULL(value.AVehicle.VehicleNo)))
			{
				stringBuilder.Append(" AND (End_Date = (SELECT MAX(End_Date) FROM Compulsory_Insurance WHERE Vehicle_No = ");
				stringBuilder.Append(GetDB(value.AVehicle.VehicleNo));
				stringBuilder.Append(" )) ");
			}
			return stringBuilder.ToString();
		}

		private string getLatestCondition(Vehicle value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (IsNotNULL(value.VehicleNo))
			{
				stringBuilder.Append(" AND (Vehicle_No = ");
				stringBuilder.Append(GetDB(value.VehicleNo));
				stringBuilder.Append(" ) AND (End_Date = (SELECT MAX(End_Date) FROM Compulsory_Insurance ");
				stringBuilder.Append(" GROUP BY Vehicle_No HAVING (Vehicle_No = ");
				stringBuilder.Append(GetDB(value.VehicleNo));
				stringBuilder.Append(" ))) ");
			}

			return stringBuilder.ToString();
		}

		protected string getOrderby()
		{
			return " ORDER BY Policy_No ";
		}
		#endregion

		#region - Fill -
        protected virtual CompulsoryInsurance getNewCompulsoryInsurance()
        {
            return new CompulsoryInsurance();
        }

        protected void fillCompulsoryInsurance(CompulsoryInsurance value, Company aCompany, SqlDataReader dataReader)
		{
			value.PolicyNo = (string)dataReader[POLICY_NO];
			value.AVehicle = dbVehicle.GetDBVehicleGeneral(dataReader.GetInt32(VEHICLE_NO), aCompany);
			value.APeriod.From = dataReader.GetDateTime(START_DATE);
			value.APeriod.To = dataReader.GetDateTime(END_DATE);
			value.AInsuranceCompany = dbInsuranceCompany.GetDBInsuranceCompany((string)dataReader[INSURANCE_COMPANY_CODE], aCompany);
			value.PremiumAmount = dataReader.GetDecimal(PREMIUM_AMOUNT);
			value.VatAmount = dataReader.GetDecimal(VAT_AMOUNT);
			value.RevenueStampFee = dataReader.GetDecimal(REVENUE_STAMP_FEE);
            value.TaxInvoiceNo = (string)dataReader[TAX_INVOICE_NO];

            if (dataReader.IsDBNull(TAX_INVOICE_DATE))
            {
                value.TaxInvoiceDate = NullConstant.DATETIME;
            }
            else
            {
                value.TaxInvoiceDate = dataReader.GetDateTime(TAX_INVOICE_DATE);
            }
		}

		private bool fillCompulsoryInsurance(ref CompulsoryInsurance value, Company aCompany,  string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{
					fillCompulsoryInsurance(value, aCompany, dataReader);
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

		private bool fillCompulsoryInsurance(ref CompulsoryInsuranceList value, string sql)
		{
			bool result = false;
			CompulsoryInsurance compulsoryInsurance;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
                    compulsoryInsurance = getNewCompulsoryInsurance();
					fillCompulsoryInsurance(compulsoryInsurance, value.Company, dataReader);
					value.Add(compulsoryInsurance);
				}
			}
			catch(IndexOutOfRangeException ein)
			{throw ein;}
			finally
			{tableAccess.CloseDataReader();}
			return result;			
		}
		#endregion

//		============================== Public Method ==============================
		public CompulsoryInsurance GetCompulsoryInsurance(string policyNo, Company aCompany)
		{
            objCompulsoryInsurance = getNewCompulsoryInsurance();
			objCompulsoryInsurance.PolicyNo = policyNo;
			if(FillCompulsoryInsurance(ref objCompulsoryInsurance, aCompany))
			{
				return objCompulsoryInsurance;
			}
			else
			{
				objCompulsoryInsurance = null;
				return null;
			}
		}

		public CompulsoryInsurance GetLatestCompulsoryInsurance(Vehicle aVehicle, Company aCompany)
		{
            objCompulsoryInsurance = getNewCompulsoryInsurance();

			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getLatestCondition(aVehicle));

			if(fillCompulsoryInsurance(ref objCompulsoryInsurance, aCompany, stringBuilder.ToString()))			
			{
				return objCompulsoryInsurance;
			}
			else
			{
				objCompulsoryInsurance = null;
				return null;
			}
		}

		public bool FillCompulsoryInsurance(ref CompulsoryInsurance value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			return fillCompulsoryInsurance(ref value, aCompany, stringBuilder.ToString());
		}

		public bool FillLatestCompulsoryInsuranceList(ref CompulsoryInsuranceList value, YearMonth condition)
		{
            StringBuilder stringBuilder = new StringBuilder("SELECT Compulsory_Insurance.Policy_No, Compulsory_Insurance.Vehicle_No, Compulsory_Insurance.Start_Date, Compulsory_Insurance.End_Date, Compulsory_Insurance.Insurance_Company_Code, Compulsory_Insurance.Premium_Amount, Compulsory_Insurance.VAT_Amount, Compulsory_Insurance.Revenue_Stamp_Fee, Compulsory_Insurance.Tax_Invoice_No, Compulsory_Insurance.Tax_Invoice_Date ");
			stringBuilder.Append(" FROM Compulsory_Insurance INNER JOIN ");
			stringBuilder.Append(" (SELECT Vehicle_No, MAX(End_Date) AS Max_End_Date ");
			stringBuilder.Append("  FROM Compulsory_Insurance ");
			stringBuilder.Append(" GROUP BY Vehicle_No) Max_Compulsory_Insurance ON Compulsory_Insurance.Vehicle_No = Max_Compulsory_Insurance.Vehicle_No AND ");
			stringBuilder.Append(" Compulsory_Insurance.End_Date = Max_Compulsory_Insurance.Max_End_Date ");
			stringBuilder.Append(" WHERE (YEAR(Compulsory_Insurance.End_Date) = " + condition.Year.ToString() + ") AND (MONTH(Compulsory_Insurance.End_Date) = " + condition.Month.ToString() + ") ");
			
			return fillCompulsoryInsurance(ref value, stringBuilder.ToString());
		}

		public bool FillCurrentCompulsoryInsurance(ref CompulsoryInsurance value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));
			stringBuilder.Append(getCurrentCompulsoryInsuranceCondition(value));

			return fillCompulsoryInsurance(ref value, aCompany, stringBuilder.ToString());
		}

		public bool FillCompulsoryInsuranceList(ref CompulsoryInsuranceList value, YearMonth condition)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getEntityEndDateCondition(condition));
			
			return fillCompulsoryInsurance(ref value, stringBuilder.ToString());
		}

		public bool FillCompulsoryInsuranceList(ref CompulsoryInsuranceList value, CompulsoryInsurance condition)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getKeyCondition(condition));
			
			return fillCompulsoryInsurance(ref value, stringBuilder.ToString());
		}

        public bool FillCompulsoryInsuranceByFromDateList(CompulsoryInsuranceList value, DateTime fromDate)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(value.Company));
            stringBuilder.Append(getEntityStartDateCondition(new YearMonth(fromDate)));

            return fillCompulsoryInsurance(ref value, stringBuilder.ToString());
        }

		public bool InsertCompulsoryInsurance(CompulsoryInsurance value, Company aCompany)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aCompany))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateCompulsoryInsurance(CompulsoryInsurance value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aCompany));
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteCompulsoryInsurance(CompulsoryInsurance value, Company aCompany)
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
                        dbInsuranceCompany.Dispose();
                        dbVehicle.Dispose();

                        dbInsuranceCompany = null;
                        dbVehicle = null;
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
            get { return "Compulsory_Insurance"; }
        }

        #endregion
    }
}
