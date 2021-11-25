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
	public class TrLateSummaryDB : DataAccessBase
	{
		#region - Constant -
		private const int EMPLOYEE_NO = 0;
		private const int FOR_YEAR = 1;
		private const int FOR_MONTH = 2;
		private const int COUNT_AS_YEAR = 3;
		private const int TOTAL_LATE_TIMES_BY_MONTH  = 4;
		private const int TOTAL_LATE_TIMES_UP_TO_THIS_MONTH = 5;

		#endregion

		#region - Private -
		private LateSummary objLateSummary;
		private EmployeeDB dbEmployee;
		#endregion
		
//		============================== Constructor ==============================
		public TrLateSummaryDB() : base()
		{
			dbEmployee = new EmployeeDB();
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT Employee_No, For_Year, For_Month, Count_As_Year, Total_Late_Times_By_Month, Total_Late_Times_Up_To_This_Month FROM Tr_Late_Summary ";
		}

		private string getSQLSelectView()
		{
			return " SELECT Employee_No, For_Year, For_Month, Count_As_Year, Total_Late_Times_By_Month, Total_Late_Times_Up_To_This_Month FROM VEmployeeLateSummary ";
		}

		private string getSQLInsert(LateSummary value)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Tr_Late_Summary (Company_Code, Employee_No, For_Year, For_Month, Count_As_Year, Total_Late_Times_By_Month, Total_Late_Times_Up_To_This_Month, Process_Date, Process_User) ");
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

			//Total_Late_Times_By_Month
			stringBuilder.Append(GetDB(value.TotalLateTimesByMonth));
			stringBuilder.Append(", ");

			//Total_Late_Times_Up_To_This_Month
			stringBuilder.Append(GetDB(value.TotalLateTimesUpToThisMonth));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(LateSummary value)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Tr_Late_Summary SET ");

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

			stringBuilder.Append(" Total_Late_Times_By_Month = ");
			stringBuilder.Append(GetDB(value.TotalLateTimesByMonth));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Total_Late_Times_Up_To_This_Month = ");
			stringBuilder.Append(GetDB(value.TotalLateTimesUpToThisMonth));
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
			return " DELETE FROM Tr_Late_Summary ";
		}

		private string getListCondition(YearMonth value)
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
		private void fillLateSummary(ref LateSummary value, Company aCompany, SqlDataReader dataReader)
		{
			value.AEmployee = dbEmployee.GetFormerlyEmployee((string)dataReader[EMPLOYEE_NO], aCompany);

			YearMonth yearMonth = new YearMonth(dataReader.GetInt16(FOR_YEAR), dataReader.GetByte(FOR_MONTH));
			value.AYearMonth = yearMonth;

			value.CountAsYear = Convert.ToInt16(dataReader.GetValue(COUNT_AS_YEAR));
			value.TotalLateTimesByMonth = dataReader.GetInt32(TOTAL_LATE_TIMES_BY_MONTH);
			value.TotalLateTimesUpToThisMonth = dataReader.GetInt32(TOTAL_LATE_TIMES_UP_TO_THIS_MONTH);
		}

		private bool fillLateSummaryList(ref LateSummaryList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objLateSummary = new LateSummary();
					fillLateSummary(ref objLateSummary, value.Company, dataReader);
					value.Add(objLateSummary);
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

		protected bool fillLateSummary(ref LateSummary value, Company aCompany, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{					
					fillLateSummary(ref value, aCompany, dataReader);
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
		public bool FillLateSummaryList(ref LateSummaryList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getListCondition(value.AYearMonth));
			stringBuilder.Append(getOrderby());

			return fillLateSummaryList(ref value, stringBuilder.ToString());
		}

		public bool FillViewLateSummaryList(ref LateSummaryList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelectView());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getListCondition(value.AYearMonth));
			stringBuilder.Append(getOrderby());

			return fillLateSummaryList(ref value, stringBuilder.ToString());
		}

		public bool InsertLateSummary(LateSummaryList value)
		{
			StringBuilder stringBuilder = new StringBuilder();

			for(int i=0; i<value.Count; i++)
			{
				stringBuilder.Append(getSQLInsert(value[i]));		
			}

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}	
		}

		public bool DeleteLateSummary(Company value)
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
