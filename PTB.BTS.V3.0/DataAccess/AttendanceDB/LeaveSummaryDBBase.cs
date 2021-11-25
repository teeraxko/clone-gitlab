using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using DataAccess.CommonDB;
using DataAccess.PiDB;

using SystemFramework.AppConfig;

using ictus.Common.Entity;

namespace DataAccess.AttendanceDB
{
	public abstract class LeaveSummaryDBBase : DataAccessBase
	{
		#region - Constant -
		private const int EMPLOYEE_NO = 0;
		private const int FOR_YEAR = 1;
		private const int FOR_MONTH = 2;
		private const int COUNT_AS_YEAR = 3;
		private const int TOTAL_LEAVE_DAYS_BY_MONTH = 4;
		private const int TOTAL_LEAVE_DAYS_UP_TO_THIS_MONTH = 5;

		#endregion

		#region - Private -
		protected string tableName;
		protected string viewName;
		protected abstract LeaveSummaryBase getNew();

		protected LeaveSummaryBase objLeaveSummaryBase;
		protected EmployeeDB dbEmployee;
		#endregion
		
//		============================== Constructor ==============================
		protected LeaveSummaryDBBase() : base()
		{
			dbEmployee = new EmployeeDB();
		}

//		============================== Private Method ==============================
		#region - getSQL -
		protected string getSQLSelect()
		{
			StringBuilder stringBuilder = new StringBuilder(" SELECT Employee_No, For_Year, For_Month, Count_As_Year, Total_Leave_Days_By_Month, Total_Leave_Days_Up_To_This_Month ");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append(tableName);

			return stringBuilder.ToString();
		}

		protected string getSQLSelectView()
		{
			StringBuilder stringBuilder = new StringBuilder(" SELECT Employee_No, For_Year, For_Month, Count_As_Year, Total_Leave_Days_By_Month, Total_Leave_Days_Up_To_This_Month ");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append(viewName);

			return stringBuilder.ToString();
		}

		protected string getSQLInsert(LeaveSummaryBase value)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO ");
			stringBuilder.Append(tableName);
			stringBuilder.Append(" (Company_Code, Employee_No, For_Year, For_Month, Count_As_Year, Total_Leave_Days_By_Month, Total_Leave_Days_Up_To_This_Month, Process_Date, Process_User) ");
			stringBuilder.Append("VALUES (");

			//Company_Code
			stringBuilder.Append(GetDB(value.AEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			//Employee_No
			stringBuilder.Append(GetDB(value.AEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			//For_Year
			stringBuilder.Append(GetDB(value.AYearMonth.Year));
			stringBuilder.Append(", ");

			//For_Month
			stringBuilder.Append(GetDB(value.AYearMonth.Month));
			stringBuilder.Append(", ");

			//Count_As_Year
			stringBuilder.Append(GetDB(value.CountAsYear));
			stringBuilder.Append(", ");

			//Total_Leave_Days_By_Month
			stringBuilder.Append(GetDB(value.TotalLeaveDaysByMonth));
			stringBuilder.Append(", ");

			//Total_Leave_Days_Up_To_This_Month
			stringBuilder.Append(GetDB(value.TotalLeaveDaysUpToThisMonth));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		protected string getSQLUpdate(LeaveSummaryBase value)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE ");
			stringBuilder.Append(tableName);
			stringBuilder.Append(" SET ");

			stringBuilder.Append(" Company_Code = ");
			stringBuilder.Append(GetDB(value.AEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Employee_No = ");
			stringBuilder.Append(GetDB(value.AEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			stringBuilder.Append(" For_Year = ");
			stringBuilder.Append(GetDB(value.AYearMonth.Year));
			stringBuilder.Append(", ");

			stringBuilder.Append(" For_Month = ");
			stringBuilder.Append(GetDB(value.AYearMonth.Month));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Count_As_Year = ");
			stringBuilder.Append(GetDB(value.CountAsYear));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Total_Leave_Days_By_Month = ");
			stringBuilder.Append(GetDB(value.TotalLeaveDaysByMonth));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Total_Leave_Days_Up_To_This_Month = ");
			stringBuilder.Append(GetDB(value.TotalLeaveDaysUpToThisMonth));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Process_Date = ");
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			stringBuilder.Append(" Process_User = ");
			stringBuilder.Append(GetDB(UserProfile.UserID));
			
			return stringBuilder.ToString();
		}	

		protected string getSQLDelete()
		{
			StringBuilder stringBuilder = new StringBuilder(" DELETE FROM ");
			stringBuilder.Append(tableName);
			return stringBuilder.ToString();
		}

		protected string getListCondition(YearMonth value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if(IsNotNULL(value.Year))
			{
				stringBuilder.Append(" AND (For_Year = ");
				stringBuilder.Append(GetDB(value.Year));
				stringBuilder.Append(")");
			}
			if(IsNotNULL(value.Month))
			{
				stringBuilder.Append(" AND (For_Month = ");
				stringBuilder.Append(GetDB(value.Month));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

		protected string getOrderby()
		{
			return " ORDER BY Employee_No, For_Year, For_Month ";
		}
		#endregion

		#region - Fill -
		private void fillLeaveSummaryBase(ref LeaveSummaryBase value, Company aCompany, SqlDataReader dataReader)
		{
			value.AEmployee = dbEmployee.GetFormerlyEmployee((string)dataReader[EMPLOYEE_NO], aCompany);

			YearMonth yearMonth = new YearMonth(dataReader.GetInt16(FOR_YEAR), dataReader.GetByte(FOR_MONTH));
			value.AYearMonth = yearMonth;

			value.CountAsYear = Convert.ToInt16(dataReader.GetValue(COUNT_AS_YEAR));
			value.TotalLeaveDaysByMonth = dataReader.GetDecimal(TOTAL_LEAVE_DAYS_BY_MONTH);
			value.TotalLeaveDaysUpToThisMonth = dataReader.GetDecimal(TOTAL_LEAVE_DAYS_UP_TO_THIS_MONTH);
		}

		protected bool fillLeaveSummaryListBase(ictus.Common.Entity.General.ListBase value, Company aCompany, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objLeaveSummaryBase = getNew();
					fillLeaveSummaryBase(ref objLeaveSummaryBase, aCompany, dataReader);
					value.Add(objLeaveSummaryBase);
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

		protected bool fillLeaveSummaryBase(ref LeaveSummaryBase value, Company aCompany, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{					
					fillLeaveSummaryBase(ref value, aCompany, dataReader);
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
		public bool FillLeaveSummaryListBase(CompanyStuffBase value, YearMonth yearMonth)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getListCondition(yearMonth));
			stringBuilder.Append(getOrderby());

			return fillLeaveSummaryListBase(value, value.Company, stringBuilder.ToString());
		}

		public bool FillViewLeaveSummaryListBase(CompanyStuffBase value, YearMonth yearMonth)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelectView());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getListCondition(yearMonth));
			stringBuilder.Append(getOrderby());

			return fillLeaveSummaryListBase(value, value.Company, stringBuilder.ToString());
		}

		public bool InsertLeaveSummaryBase(LeaveSummaryBase value)
		{
			return (tableAccess.ExecuteSQL(getSQLInsert(value))>0);
		}

		public bool DeleteLeaveSummaryBase(Company value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}
	}
}
