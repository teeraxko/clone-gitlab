using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entity.CommonEntity;
using Entity.VehicleEntities;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;
using ictus.Common.Entity.General;

using DataAccess.PiDB;
using DataAccess.CommonDB;

using SystemFramework.AppConfig;

namespace DataAccess.VehicleDB
{
	public class DriverExcessDeductionDB : DataAccessBase
	{
		#region - Constant -
		private const int ACCIDENT_NO = 0;
		private const int EMPLOYEE_NO = 1;
		private const int FOR_YEAR = 2;
		private const int FOR_MONTH = 3;
		private const int DEDUCTION_AMOUNT = 4;
		private const int PAYMENT_STATUS = 5;
		private const int PAYMENT_DATE = 6;
		#endregion

		#region - Private -
			private EmployeeDB dbEmployee;
		#endregion

//		============================== Constructor ==============================
		public DriverExcessDeductionDB() : base()
		{
			dbEmployee = new EmployeeDB();
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT Accident_No, Employee_No, For_Year, For_Month, Deduction_Amount, Payment_Status, Payment_Date FROM Driver_Excess_Deduction ";
		}

		private string getSQLInsert(ExcessDeduction value, DriverExcessDeduction condition)
		{
			StringBuilder stringBuilder = new StringBuilder(" INSERT INTO Driver_Excess_Deduction (Company_Code, Accident_No, Employee_No, For_Year, For_Month, Deduction_Amount, Payment_Status, Payment_Date, Process_Date, Process_User) " );
			stringBuilder.Append(" VALUES ( ");

			//Company_Code
			stringBuilder.Append(GetDB(condition.Company.CompanyCode));
			stringBuilder.Append(", ");

			//Accident_No
			stringBuilder.Append(GetDB(condition.AAccident.RepairingNo));
			stringBuilder.Append(", ");
			
			//Employee_No
			stringBuilder.Append(GetDB(condition.ADriver.EmployeeNo));
			stringBuilder.Append(", ");
			
			//For_Year
			stringBuilder.Append(GetDB(value.AForMonth.Year));
			stringBuilder.Append(", ");

			//For_Month
			stringBuilder.Append(GetDB(value.AForMonth.Month));
			stringBuilder.Append(", ");

			//Deduction_Amount
			stringBuilder.Append(GetDB(value.Amount));
			stringBuilder.Append(", ");

			//Payment_Status
			stringBuilder.Append(GetDB(value.IsPaid));
			stringBuilder.Append(", ");

			//Payment_Date
			stringBuilder.Append(GetDB(value.PaymentDate));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(ExcessDeduction value, DriverExcessDeduction condition)
		{
			StringBuilder stringBuilder = new StringBuilder(" UPDATE Driver_Excess_Deduction SET ");

			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(condition.ADriver.Company.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Accident_No = ");
			stringBuilder.Append(GetDB(condition.AAccident.RepairingNo));
			stringBuilder.Append(", ");

			stringBuilder.Append("Employee_No = ");
			stringBuilder.Append(GetDB(condition.ADriver.EmployeeNo));
			stringBuilder.Append(", ");

			stringBuilder.Append("For_Year = ");
			stringBuilder.Append(GetDB(value.AForMonth.Year));
			stringBuilder.Append(", ");

			stringBuilder.Append("For_Month = ");
			stringBuilder.Append(GetDB(value.AForMonth.Month));
			stringBuilder.Append(", ");

			stringBuilder.Append("Deduction_Amount = ");
			stringBuilder.Append(GetDB(value.Amount));
			stringBuilder.Append(", ");

			stringBuilder.Append("Payment_Status = ");
			stringBuilder.Append(GetDB(value.IsPaid));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Payment_Date = ");
			stringBuilder.Append(GetDB(value.PaymentDate));
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
			return " DELETE FROM Driver_Excess_Deduction ";
		}

		private string getListCondition(DriverExcessDeduction value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (value.AAccident != null)
			{
				stringBuilder.Append(" AND (Accident_No = ");
				stringBuilder.Append(GetDB(value.AAccident.RepairingNo));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

		private string getKeyCondition(YearMonth aYearMonth)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (IsNotNULL(aYearMonth.Year))
			{
				stringBuilder.Append(" AND (For_Year = ");
				stringBuilder.Append(GetDB(aYearMonth.Year));
				stringBuilder.Append(")");
			}
			if (IsNotNULL(aYearMonth.Month))
			{
				stringBuilder.Append(" AND (For_Month = ");
				stringBuilder.Append(GetDB(aYearMonth.Month));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

		private string getOrderby()
		{
			return " ORDER BY For_Year, For_Month ";
		}
		#endregion

		#region - Fill -
		private void fillDriverExcessDeduction(ref ExcessDeduction value, SqlDataReader dataReader)
		{
			value.AForMonth = new YearMonth(dataReader.GetInt32(FOR_YEAR), dataReader.GetByte(FOR_MONTH));
			value.Amount = dataReader.GetDecimal(DEDUCTION_AMOUNT);
			value.IsPaid = GetBool((string)dataReader[PAYMENT_STATUS]);

			if (dataReader.IsDBNull(PAYMENT_DATE))
			{
				value.PaymentDate = NullConstant.DATETIME;
			}
			else
			{
				value.PaymentDate = dataReader.GetDateTime(PAYMENT_DATE);
			}
		}

		private bool fillDriverExcessDeduction(ref DriverExcessDeduction value, string sql)
		{
			bool result = false;
			ExcessDeduction excessDeduction;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					excessDeduction = new ExcessDeduction();
					fillDriverExcessDeduction(ref excessDeduction, dataReader);
					value.Add(excessDeduction);
				}
				excessDeduction = null;
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

		private bool fillDriverExcessDeduction(ref ExcessDeduction value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					fillDriverExcessDeduction(ref value, dataReader);
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
		#endregion

//		============================== Public Method ==============================
        public bool FillDriverExcessDeduction(ref ExcessDeduction value, ictus.Common.Entity.Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value.AForMonth));

			return fillDriverExcessDeduction(ref value, stringBuilder.ToString());
		}

		public bool FillDriverExcessDeduction(ref DriverExcessDeduction value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getListCondition(value));
			stringBuilder.Append(getOrderby());

			bool result = fillDriverExcessDeduction(ref value, stringBuilder.ToString());
			stringBuilder = null;
			return result;
		}

		public bool IsDuplicateWithOtherAccident(Employee employee, YearMonth yearMonth, string accidentNo)
		{
			StringBuilder stringBuilder = new StringBuilder("SELECT count(*) FROM Driver_Excess_Deduction ");
			stringBuilder.Append(getBaseCondition(employee.Company));
			stringBuilder.Append(" AND Employee_No = '" + employee.EmployeeNo + "'");
			stringBuilder.Append(getKeyCondition(yearMonth));
			stringBuilder.Append(" AND Accident_No <> '" + accidentNo + "' ");			
			Object obj = tableAccess.ExecuteScalar(stringBuilder.ToString());
			stringBuilder = null;

			int result = (int)obj;

			return (result>0);
		}

		public bool InsertDriverExcessDeduction(DriverExcessDeduction value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for(int i=0; i < value.Count; i++)
			{
				stringBuilder.Append(getSQLInsert(value[i], value));
			}

			bool result = (tableAccess.ExecuteSQL(stringBuilder.ToString())>0);
			stringBuilder = null;
			return result;
		}

		public bool DeleteDriverExcessDeduction(DriverExcessDeduction value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getListCondition(value));

			tableAccess.ExecuteSQL(stringBuilder.ToString());
			stringBuilder = null;
			return true;
		}

        public bool UpdateDriverExcessDeductionByYearMonth(YearMonth yearMonth, DateTime paymentDate, ictus.Common.Entity.Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(" UPDATE Driver_Excess_Deduction SET ");
			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Payment_Status = 'Y'");
			stringBuilder.Append(", ");

			stringBuilder.Append("Payment_Date = ");
			stringBuilder.Append(GetDB(paymentDate));
			stringBuilder.Append(", ");

			stringBuilder.Append("Process_Date = ");
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			stringBuilder.Append("Process_User = ");
			stringBuilder.Append(GetDB(UserProfile.UserID));

			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(yearMonth));
			stringBuilder.Append(" AND (Payment_Status = 'N') ");

			return tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0;
		}
	}
}
