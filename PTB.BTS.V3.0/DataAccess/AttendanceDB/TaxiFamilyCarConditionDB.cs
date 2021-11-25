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
	public class TaxiFamilyCarConditionDB : DataAccessBase
	{
		#region - Constant -
		private const int CUSTOMER_GROUP_CODE = 0;
		private const int UNTIL_TIME_IN = 1;
		private const int SINCE_TIME_OUT = 2;	
		private const int UNTIL_TIME_IN_FOR_CHARGE = 3;
		private const int SINCE_TIME_OUT_FOR_CHARGE = 4;
		#endregion

		#region - Private -
		private TaxiFamilyCarCondition objTaxiFamilyCarCondition; 
		private CustomerGroupDB dbCustomerGroup;
		private bool disposed  = false;
		#endregion
		
//		============================== Constructor ==============================
		public TaxiFamilyCarConditionDB()
		{
			dbCustomerGroup = new CustomerGroupDB();
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT Customer_Group_Code, Until_Time_In,  Since_Time_Out, Until_Time_In_For_Charge,  Since_Time_Out_For_Charge FROM Taxi_Family_Car_Condition ";
		}

		private string getSQLInsert(TaxiFamilyCarCondition value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Taxi_Family_Car_Condition (Company_Code, Customer_Group_Code, Until_Time_In,  Since_Time_Out, Until_Time_In_For_Charge,  Since_Time_Out_For_Charge, Process_Date, Process_User) ");
			stringBuilder.Append("VALUES (");

			//Company_Code
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			//Customer_Group_Code
			stringBuilder.Append(GetDB(value.ACustomerGroup.Code));
			stringBuilder.Append(", ");

			//Until_Time_In
			stringBuilder.Append(GetDB(value.UntilTimeIn));
			stringBuilder.Append(", ");

			//Since_Time_Out
			stringBuilder.Append(GetDB(value.SinceTimeOut));
			stringBuilder.Append(", ");

			//Until_Time_In_For_Charge
			stringBuilder.Append(GetDB(value.UntilTimeInForCharge));
			stringBuilder.Append(", ");

			//Since_Time_Out_For_Charge
			stringBuilder.Append(GetDB(value.SinceTimeOutForCharge));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(TaxiFamilyCarCondition value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Taxi_Family_Car_Condition SET ");

			stringBuilder.Append(" Company_Code = ");
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Customer_Group_Code = ");
			stringBuilder.Append(GetDB(value.ACustomerGroup.Code));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Until_Time_In = ");
			stringBuilder.Append(GetDB(value.UntilTimeIn));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Since_Time_Out = ");
			stringBuilder.Append(GetDB(value.SinceTimeOut));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Until_Time_In_For_Charge = ");
			stringBuilder.Append(GetDB(value.UntilTimeInForCharge));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Since_Time_Out_For_Charge = ");
			stringBuilder.Append(GetDB(value.SinceTimeOutForCharge));
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
			return " DELETE FROM Taxi_Family_Car_Condition ";
		}

		private string getKeyCondition(CustomerGroup value)
		{
			StringBuilder stringBuilder = new StringBuilder();

			if(IsNotNULL(value.Code))
			{
				stringBuilder.Append(" AND (Customer_Group_Code = ");
				stringBuilder.Append(GetDB(value.Code));
				stringBuilder.Append(")");
			}

			return stringBuilder.ToString();
		}

		private string getOrderby()
		{
			return " ORDER BY Customer_Group_Code ";
		}
		#endregion

		#region - fill -
		private void fillTaxiFamilyCarCondition(ref TaxiFamilyCarCondition value, Company aCompony, SqlDataReader dataReader)
		{
			value.ACustomerGroup = (CustomerGroup)dbCustomerGroup.GetDBDualField((string)dataReader[CUSTOMER_GROUP_CODE], aCompony);
			value.UntilTimeIn = dataReader.GetDateTime(UNTIL_TIME_IN);
			value.SinceTimeOut = dataReader.GetDateTime(SINCE_TIME_OUT);
			value.UntilTimeInForCharge = dataReader.GetDateTime(UNTIL_TIME_IN_FOR_CHARGE);
			value.SinceTimeOutForCharge = dataReader.GetDateTime(SINCE_TIME_OUT_FOR_CHARGE);
		}

		private bool fillTaxiFamilyCarConditionList(ref TaxiFamilyCarConditionList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while(dataReader.Read())
				{
					result = true;
					objTaxiFamilyCarCondition = new TaxiFamilyCarCondition();
					fillTaxiFamilyCarCondition(ref objTaxiFamilyCarCondition, value.Company, dataReader);
					value.Add(objTaxiFamilyCarCondition);
				}
				objTaxiFamilyCarCondition = null;
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

		private bool fillTaxiFamilyCarCondition(ref TaxiFamilyCarCondition value, string sql, Company company)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if(dataReader.Read())
				{
					fillTaxiFamilyCarCondition(ref value, company, dataReader);
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
		public bool FillTaxiFamilyCarCondition(ref TaxiFamilyCarCondition value, Company company)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(company));
			stringBuilder.Append(getKeyCondition(value.ACustomerGroup));
			stringBuilder.Append(getOrderby());

			return fillTaxiFamilyCarCondition(ref value, stringBuilder.ToString(), company);
		}

		public bool FillTaxiFamilyCarConditionList(ref TaxiFamilyCarConditionList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getOrderby());

			return fillTaxiFamilyCarConditionList(ref value, stringBuilder.ToString());
		}

		public bool FillTaxiFamilyCarConditionList(ref TaxiFamilyCarConditionList value, TaxiFamilyCarCondition aTaxiFamilyCarCondition)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getKeyCondition(aTaxiFamilyCarCondition.ACustomerGroup));
			stringBuilder.Append(getOrderby());

			return fillTaxiFamilyCarConditionList(ref value, stringBuilder.ToString());
		}

		public bool InsertTaxiFamilyCarCondition(TaxiFamilyCarCondition value, Company aCompany)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aCompany))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateTaxiFamilyCarCondition(TaxiFamilyCarCondition value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aCompany));
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value.ACustomerGroup));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteTaxiFamilyCarCondition(TaxiFamilyCarCondition value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value.ACustomerGroup));

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
