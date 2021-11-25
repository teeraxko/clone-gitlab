using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entity.CommonEntity;
using ictus.PIS.PI.Entity;
using Entity.AttendanceEntities;
using Entity.ContractEntities;

using DataAccess.CommonDB;
using DataAccess.PiDB;
using DataAccess.ContractDB;

using SystemFramework.AppConfig;

using ictus.Common.Entity;

namespace DataAccess.AttendanceDB
{	
	public class TaxiPositionCarConditionDB : DataAccessBase
	{
		#region - Constant -
		private const int CUSTOMER_CODE = 0;
		private const int UNTIL_TIME_IN = 1;
		private const int SINCE_TIME_OUT = 2;		
		#endregion

		#region - Private -
		private TaxiPositionCarCondition objTaxiPositionCarCondition; 
		private CustomerDB dbCustomer;
		private bool disposed  = false;
		#endregion

//		============================== Constructor ==============================
		public TaxiPositionCarConditionDB() : base()
		{			
			dbCustomer = new CustomerDB();
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT Customer_Code, Until_Time_In,  Since_Time_Out FROM Taxi_Position_Car_Condition ";
		}

		private string getSQLInsert(TaxiPositionCarCondition value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Taxi_Position_Car_Condition (Company_Code, Customer_Code, Until_Time_In,  Since_Time_Out, Process_Date, Process_User) ");
			stringBuilder.Append("VALUES (");

			//Company_Code
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			//Customer_Code
			stringBuilder.Append(GetDB(value.ACustomer.Code));
			stringBuilder.Append(", ");

			//Until_Time_In
			stringBuilder.Append(GetDB(value.UntilTimeIn));
			stringBuilder.Append(", ");

			//Since_Time_Out
			stringBuilder.Append(GetDB(value.SinceTimeOut));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(TaxiPositionCarCondition value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Taxi_Position_Car_Condition SET ");

			stringBuilder.Append(" Company_Code = ");
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Customer_Code = ");
			stringBuilder.Append(GetDB(value.ACustomer.Code));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Until_Time_In = ");
			stringBuilder.Append(GetDB(value.UntilTimeIn));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Since_Time_Out = ");
			stringBuilder.Append(GetDB(value.SinceTimeOut));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Process_Date = ");
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			stringBuilder.Append(" Process_User = ");
			stringBuilder.Append(GetDB(UserProfile.UserID));
			
			return stringBuilder.ToString();
		}	

		private string getSQLDelete()
		{
			return " DELETE FROM Taxi_Position_Car_Condition ";
		}

		private string getKeyCondition(Customer value)
		{
			StringBuilder stringBuilder = new StringBuilder();

			if(IsNotNULL(value.Code))
			{
				stringBuilder.Append(" AND (Customer_Code = ");
				stringBuilder.Append(GetDB(value.Code));
				stringBuilder.Append(")");
			}

			return stringBuilder.ToString();
		}

		private string getOrderby()
		{
			return " ORDER BY Customer_Code ";
		}
		#endregion

		#region - fill -
		private void fillTaxiPositionCarCondition(ref TaxiPositionCarCondition value, Company aCompany, SqlDataReader dataReader)
		{
			value.ACustomer = dbCustomer.GetDBCustomer((string)dataReader[CUSTOMER_CODE], aCompany);
			value.UntilTimeIn = dataReader.GetDateTime(UNTIL_TIME_IN);
			value.SinceTimeOut = dataReader.GetDateTime(SINCE_TIME_OUT);
		}

		private void fillTaxiPositionCarCondition(ref TaxiPositionCarCondition value, Customer customer, Company aCompany, SqlDataReader dataReader)
		{
			value.ACustomer = customer;
			value.UntilTimeIn = dataReader.GetDateTime(UNTIL_TIME_IN);
			value.SinceTimeOut = dataReader.GetDateTime(SINCE_TIME_OUT);
		}

		private bool fillTaxiPositionCarConditionList(ref TaxiPositionCarConditionList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objTaxiPositionCarCondition = new TaxiPositionCarCondition();
					fillTaxiPositionCarCondition(ref objTaxiPositionCarCondition, value.Company, dataReader);
					value.Add(objTaxiPositionCarCondition);
				}
				objTaxiPositionCarCondition = null;
			}
			catch(IndexOutOfRangeException ein)
			{
				throw ein;
			}
			finally
			{
				tableAccess.CloseDataReader();				
			}
			return result;
		}

		private bool fillTaxiPositionCarCondition(ref TaxiPositionCarCondition value, Company company, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{
					fillTaxiPositionCarCondition(ref value, company, dataReader);
					result = true;
				}
				else
				{
					result = false;
				}
			}
			catch (IndexOutOfRangeException ein)
			{
				throw ein;
			}
			finally
			{
				tableAccess.CloseDataReader();
			}			
			return result;				
		}

		private bool fillTaxiPositionCarCondition(ref TaxiPositionCarCondition value, Customer customer, Company company, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{
					fillTaxiPositionCarCondition(ref value, customer, company, dataReader);
					result = true;
				}
				else
				{
					result = false;
				}
			}
			catch (IndexOutOfRangeException ein)
			{
				throw ein;
			}
			finally
			{
				tableAccess.CloseDataReader();
			}			
			return result;				
		}
		#endregion

//		============================== Public Method ==============================
		public bool FillTaxiPositionCarCondition(ref TaxiPositionCarCondition value, Company company)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(company));
			stringBuilder.Append(getKeyCondition(value.ACustomer));
			stringBuilder.Append(getOrderby());

			return fillTaxiPositionCarCondition(ref value, value.ACustomer, company, stringBuilder.ToString());
		}

		public bool FillTaxiPositionCarConditionList(ref TaxiPositionCarConditionList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getOrderby());

			return fillTaxiPositionCarConditionList(ref value, stringBuilder.ToString());
		}

		public bool FillTaxiPositionCarConditionList(ref TaxiPositionCarConditionList value,TaxiPositionCarCondition aTaxiPositionCarCondition)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getKeyCondition(aTaxiPositionCarCondition.ACustomer));
			stringBuilder.Append(getOrderby());

			return fillTaxiPositionCarConditionList(ref value, stringBuilder.ToString());
		}

		public bool InsertTaxiPositionCarCondition(TaxiPositionCarCondition value, Company aCompany)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aCompany))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateTaxiPositionCarCondition(TaxiPositionCarCondition value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aCompany));
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value.ACustomer));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteTaxiPositionCarCondition(TaxiPositionCarCondition value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value.ACustomer));

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



	}
}
