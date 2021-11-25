using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;
using Entity.AttendanceEntities;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

using ictus.Common.Entity;

namespace DataAccess.AttendanceDB
{
	public class TrNewAnnualLeaveDaysDB : DataAccessBase
	{
		#region - Constant -
		private const int EMPLOYEE_NO = 0;
		private const int LAST_YEAR_TOTAL_DAYS = 1;
		private const int THIS_YEAR_TOTAL_DAYS = 2;
		#endregion

		#region - Private -

		#endregion
		
//		============================== Constructor ==============================
		public TrNewAnnualLeaveDaysDB() : base()
		{
		}

//		=============================== Private Method===================
		#region - getSQL -
		private string getSQLInsert(AnnualLeaveDualHead value)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Tr_New_Annual_Leave_Days (Company_Code, Employee_No, Last_Year_Total_Days, This_Year_Total_Days, Process_Date, Process_User) ");
			stringBuilder.Append(" VALUES ( ");

			//Company_Code
			stringBuilder.Append(GetDB(value.Employee.Company.CompanyCode));
			stringBuilder.Append(", ");

			//Employee_No			
			stringBuilder.Append(GetDB(value.Employee.EmployeeNo));
			stringBuilder.Append(", ");

			//Last_Year_Total_Days
			stringBuilder.Append(GetDB(value.Previous.TotalDays));
			stringBuilder.Append(", ");

			//This_Year_Total_Days
			stringBuilder.Append(GetDB(value.Current.TotalDays));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");
			return stringBuilder.ToString();
		}

		private string getSQLDelete()
		{
			return " DELETE FROM Tr_New_Annual_Leave_Days ";
		}
		#endregion

//		============================== Public Method ==============================
		public bool InsertTrNewAnnualLeaveDays(AnnualLeaveDualHeadList value)
		{
			StringBuilder stringBuilder = new StringBuilder();

			for(int i=0; i<value.Count; i++)
			{
				stringBuilder.Append(getSQLInsert(value[i]));
			}
			return (tableAccess.ExecuteSQL(stringBuilder.ToString())>0);
		}

		public bool DeleteTrNewAnnualLeaveDays(Company value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(value));

			return (tableAccess.ExecuteSQL(stringBuilder.ToString())>0);
		}
	}
}
