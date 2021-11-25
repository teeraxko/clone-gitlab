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
	public class TrAnnualLeaveSaleDB : DataAccessBase
	{
		#region - Constant -
		private const int EMPLOYEE_NO = 0;
		private const int REMAIN_DAYS = 1;
		private const int SELL_DAYS = 2;
		#endregion

		#region - Private -
		#endregion
		
//		============================== Constructor ==============================
		public TrAnnualLeaveSaleDB() : base()
		{
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return "SELECT Employee_No, Remain_Days, Sell_Days FROM Tr_Annual_Leave_Sale ";
		}

		private string getSQLInsert(AnnualLeaveSale value)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Tr_Annual_Leave_Sale (Company_Code, Employee_No, Remain_Days, Sell_Days, Process_Date, Process_User) ");
			stringBuilder.Append("VALUES (");

			//Company_Code
			stringBuilder.Append(GetDB(value.AEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			//Employee_No
			stringBuilder.Append(GetDB(value.AEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			//Remain_Days
			stringBuilder.Append(GetDB(value.RemainDays));
			stringBuilder.Append(", ");
			
			//Sell_Days
			stringBuilder.Append(GetDB(value.SellDays));
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
			return "DELETE FROM Tr_Annual_Leave_Sale ";
		}

		private string getOrderby()
		{
			return " ORDER BY Employee_No ";
		}
		#endregion

//		============================== Public Method ==============================
		public bool InsertTrAnnualLeaveSale(AnnualLeaveSaleList value)
		{
			StringBuilder stringBuilder = new StringBuilder();

			for(int i=0; i<value.Count; i++)
			{
				stringBuilder.Append(getSQLInsert(value[i]));		
			}
			return (tableAccess.ExecuteSQL(stringBuilder.ToString())>0);
		}

		public bool DeleteTrAnnualLeaveSale(Company value)
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
