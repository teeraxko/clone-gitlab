using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;
using Entity.AttendanceEntities;

using DataAccess.CommonDB;
using DataAccess.PiDB;

using SystemFramework.AppConfig;

using ictus.Common.Entity;

namespace DataAccess.AttendanceDB
{
	public class TelephoneConditionDB : DataAccessBase
	{
		#region - Constant -
		private const int EMPLOYEE_NO = 0;
		private const int TELEPHONE_RATE = 1;
		#endregion

		#region - Private -
		private TelephoneCondition objTelephoneCondition;
		private EmployeeDB dbEmployee;
		#endregion
		
//		============================== Constructor ==============================
		public TelephoneConditionDB() : base()
		{
			dbEmployee = new EmployeeDB();
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return "SELECT Employee_No, Telephone_Rate FROM Telephone_Condition ";
		}

		private string getSQLInsert(TelephoneCondition value)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Telephone_Condition (Company_Code, Employee_No, Telephone_Rate, Process_Date, Process_User) ");
			stringBuilder.Append("VALUES (");

			//Company_Code
			stringBuilder.Append(GetDB(value.AEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			//Employee_No
			stringBuilder.Append(GetDB(value.AEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			//Telephone_Rate
			stringBuilder.Append(GetDB(value.TelephoneRate));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(TelephoneCondition value)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Telephone_Condition SET ");

			stringBuilder.Append(" Company_Code = ");
			stringBuilder.Append(GetDB(value.AEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Employee_No = ");
			stringBuilder.Append(GetDB(value.AEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Telephone_Rate = ");
			stringBuilder.Append(GetDB(value.TelephoneRate));
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
			return "DELETE FROM Telephone_Condition ";
		}

		private string getOrderby()
		{
			return " ORDER BY Employee_No ";
		}
		#endregion

		#region - fill -
		private void fillTelephoneCondition(ref TelephoneCondition value, Company aCompany, SqlDataReader dataReader)
		{
			value.AEmployee = dbEmployee.GetFormerlyEmployee((string)dataReader[EMPLOYEE_NO], aCompany);
			value.TelephoneRate = dataReader.GetInt16(TELEPHONE_RATE);
		}

		private bool fillTelephoneConditionList(ref TelephoneConditionList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objTelephoneCondition = new TelephoneCondition();
					fillTelephoneCondition(ref objTelephoneCondition, value.Company, dataReader);
					value.Add(objTelephoneCondition);
				}
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

		private bool fillTelephoneCondition(ref TelephoneCondition value, Company aCompany, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{					
					fillTelephoneCondition(ref value, aCompany, dataReader);
					result = true;
				}
				else
				{
					result = false;
				}
			}
			catch (IndexOutOfRangeException ein)
			{throw ein;}

			finally
			{tableAccess.CloseDataReader();}
			return result;
		}

		#endregion

//		============================== Public Method ==============================
		public bool FillTelephoneConditionList(ref TelephoneConditionList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getOrderby());

			return fillTelephoneConditionList(ref value, stringBuilder.ToString());
		}

		public bool InsertTelephoneCondition(TelephoneCondition value)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateTelephoneCondition(TelephoneCondition value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value));
			stringBuilder.Append(getBaseCondition(value.AEmployee));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteTelephoneCondition(TelephoneCondition value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(value.AEmployee));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

	}
}
