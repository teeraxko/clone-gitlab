using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

namespace DataAccess.PiDB
{
	public class EmployeeWorkBackgroundDB : DataAccessBase
	{
		#region - Constant -
		private const int EMPLOYEE_NO = 0;
		private const int FROM_YEAR = 1;
		private const int TO_YEAR = 2;
		private const int COMPANY_NAME = 3;
		private const int POSITION_NAME = 4;
		private const int LATEST_SALARY = 5;
		private const int RESIGN_REASON = 6;
		#endregion

		#region - Private -
		private WorkBackground objWorkBackground;
		private bool disposed = false;
		#endregion

//		============================== Constructor ==============================
		public EmployeeWorkBackgroundDB()
		{
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return "SELECT Employee_No, From_Year, To_Year, Company_Name, Position_Name, Latest_Salary, Resign_Reason FROM Employee_Work_Background ";
		}

		private string getSQLInsert(WorkBackground aWorkBackground, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Employee_Work_Background (Company_Code, Employee_No, From_Year, To_Year, Company_Name, Position_Name, Latest_Salary, Resign_Reason, Process_Date, Process_User) ");
			stringBuilder.Append(" VALUES ( ");

			//Company_Code
			stringBuilder.Append(GetDB(aEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			//Employee_No
			stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			//From_Year
			stringBuilder.Append(GetDB(aWorkBackground.FromYear));
			stringBuilder.Append(", ");
			
			//To_Year
			stringBuilder.Append(GetDB(aWorkBackground.ToYear));
			stringBuilder.Append(", ");
			
			//Company_Name
			stringBuilder.Append(GetDB(aWorkBackground.ACompany.Thai));
			stringBuilder.Append(", ");
			
			//Position_Name
			stringBuilder.Append(GetDB(aWorkBackground.PositionName));
			stringBuilder.Append(", ");

			//Latest_Salary
			stringBuilder.Append(GetDB(aWorkBackground.LatestSalary));
			stringBuilder.Append(", ");
			
			//Resign_Reason
			stringBuilder.Append(GetDB(aWorkBackground.ResignReason));
			stringBuilder.Append(", ");
			
			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(WorkBackground aWorkBackground, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Employee_Work_Background SET ");
			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(aEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Employee_No = ");
			stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			stringBuilder.Append("From_Year = ");
			stringBuilder.Append(GetDB(aWorkBackground.FromYear));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("To_Year = ");
			stringBuilder.Append(GetDB(aWorkBackground.ToYear));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Company_Name = ");
			stringBuilder.Append(GetDB(aWorkBackground.ACompany.English));
			stringBuilder.Append(", ");
			
			//Position_Name
			stringBuilder.Append("Position_Name = ");
			stringBuilder.Append(GetDB(aWorkBackground.PositionName));
			stringBuilder.Append(", ");

			stringBuilder.Append("Latest_Salary = ");
			stringBuilder.Append(GetDB(aWorkBackground.LatestSalary));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Resign_Reason = ");
			stringBuilder.Append(GetDB(aWorkBackground.ResignReason));
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
			return " DELETE FROM Employee_Work_Background ";
		}

		private string getKeyCondition(WorkBackground value)
		{
			StringBuilder stringBuilder = new StringBuilder();

			if(IsNotNULL(value.FromYear))
			{
				stringBuilder.Append(" AND (From_Year = ");
				stringBuilder.Append(GetDB(value.FromYear));
				stringBuilder.Append(")");			
			}

			if(IsNotNULL(value.ToYear))
			{
				stringBuilder.Append(" AND (To_Year = ");
				stringBuilder.Append(GetDB(value.ToYear));
				stringBuilder.Append(")");			
			}

			if(IsNotNULL(value.ACompany.English))
			{
				stringBuilder.Append(" AND (Company_Name = ");
				stringBuilder.Append(GetDB(value.ACompany.English));
				stringBuilder.Append(")");			
			}

			return stringBuilder.ToString();
		}
		
		private string getOrderby()
		{
			return " ORDER BY From_Year, To_Year, Company_Name ";
		}
		#endregion

		#region - Fill -
		private void fillEmployeeWorkBackground(ref WorkBackground value, SqlDataReader dataReader)
		{
			value.FromYear = dataReader.GetInt16(FROM_YEAR);
			value.ToYear = dataReader.GetInt16(TO_YEAR);
			value.ACompany.Thai = (string)dataReader[COMPANY_NAME];
			value.PositionName = (string)dataReader[POSITION_NAME];
			value.LatestSalary = dataReader.GetDecimal(LATEST_SALARY);
			value.ResignReason = (string)dataReader[RESIGN_REASON];
		}

		private bool fillEmployeeWorkBackgroundList(ref EmployeeWorkBackground value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objWorkBackground = new WorkBackground();
					fillEmployeeWorkBackground(ref objWorkBackground, dataReader);
					value.Add(objWorkBackground);
				}
				objWorkBackground = null;
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

		private bool fillEmployeeWorkBackground(ref WorkBackground value, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{
					fillEmployeeWorkBackground(ref value, dataReader);
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

//		============================== internal Method ==============================
		#region - internal -
		internal bool MaintainEmployeeWorkBackground(EmployeeWorkBackground value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(getSQLDelete());
			stringBuilder.Append(getBaseCondition(value.Employee));

			for(int i=0; i<value.Count; i++)
			{
				stringBuilder.Append(getSQLInsert(value[i], value.Employee));		
			}

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}	
		}

		internal bool DeleteEmployeeWorkBackground(EmployeeWorkBackground value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(value.Employee));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		#endregion
//		============================== Public Method ==============================
		public WorkBackground GetWorkBackground(string companyName, int fromYear, int toYear, Employee aEmployee)
		{
			objWorkBackground = new WorkBackground();
			objWorkBackground.ACompany.English = companyName;
			objWorkBackground.FromYear = fromYear;
			objWorkBackground.ToYear = toYear;

			if(FillEmployeeWorkBackground(ref objWorkBackground, aEmployee))
			{
				return objWorkBackground;		
			}
			else
			{
				objWorkBackground = null;
				return null;
			}
		}

		public bool FillEmployeeWorkBackground(ref WorkBackground aWorkBackground, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(aWorkBackground));
			return fillEmployeeWorkBackground(ref aWorkBackground, stringBuilder.ToString());
		}

		public bool FillEmployeeWorkBackgroundList (ref EmployeeWorkBackground value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getOrderby());

			return fillEmployeeWorkBackgroundList(ref value, stringBuilder.ToString());
		}

		public bool InsertEmployeeWorkBackground(WorkBackground aWorkBackground, Employee aEmployee)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(aWorkBackground, aEmployee))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateEmployeeWorkBackground(WorkBackground aWorkBackground, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(aWorkBackground, aEmployee));
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(aWorkBackground));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteEmployeeWorkBackground(WorkBackground aWorkBackground, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(aWorkBackground));

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
