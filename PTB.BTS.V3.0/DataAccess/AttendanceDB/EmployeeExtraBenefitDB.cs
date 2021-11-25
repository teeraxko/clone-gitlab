using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entity.AttendanceEntities;
using Entity.CommonEntity;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;

using DataAccess.CommonDB;
using DataAccess.PiDB;
using DataAccess.ContractDB;

using SystemFramework.AppConfig;

using ictus.Common.Entity;

namespace DataAccess.AttendanceDB
{
	public class EmployeeExtraBenefitDB : DataAccessBase
	{
		#region - Constant -
		private const int EMPLOYEE_NO = 0;
		private const int BENEFIT_YEAR = 1;
		private const int BENEFIT_MONTH = 2;
		private const int BENEFIT_STATUS = 3;
		private const int BENEFIT_AMOUNT = 4;	
		private const int REMARK = 5;
		#endregion

		#region - Private -
		private ExtraBenefit objExtraBenefit; 
		private bool disposed  = false;
		#endregion

//		============================== Constructor ==============================
		public EmployeeExtraBenefitDB(): base()
		{}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT Employee_No, Benefit_Year, Benefit_Month, Benefit_Status, Benefit_Amount, Remark FROM Employee_Extra_Benefit ";
		}

		private string getSQLInsert(ExtraBenefit value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Employee_Extra_Benefit (Company_Code, Employee_No, Benefit_Year, Benefit_Month, Benefit_Status, Benefit_Amount, Remark, Process_Date, Process_User) ");
			stringBuilder.Append("VALUES (");

			//Company_Code
			stringBuilder.Append(GetDB(aEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			//Employee_No
			stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			//Benefit_Year
			stringBuilder.Append(GetDB(value.AYearMonth.Year));
			stringBuilder.Append(", ");

			//Benefit_Month
			stringBuilder.Append(GetDB(value.AYearMonth.Month));
			stringBuilder.Append(", ");

			//Benefit_Status
			stringBuilder.Append(GetDB(value.ABenefitPayment.PaymentStatus));
			stringBuilder.Append(", ");

			//Benefit_Amount
			stringBuilder.Append(GetDB(value.TotalAmount));
			stringBuilder.Append(", ");		
	
			//Remark
			stringBuilder.Append(GetDB(value.Remark));
			stringBuilder.Append(", ");	

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(ExtraBenefit value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Employee_Extra_Benefit SET ");

			stringBuilder.Append(" Company_Code = ");
			stringBuilder.Append(GetDB(aEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Employee_No = ");
			stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Benefit_Year = ");
			stringBuilder.Append(GetDB(value.AYearMonth.Year));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Benefit_Month = ");
			stringBuilder.Append(GetDB(value.AYearMonth.Month));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Benefit_Status = ");
			stringBuilder.Append(GetDB(value.ABenefitPayment.PaymentStatus));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Benefit_Amount = ");
			stringBuilder.Append(GetDB(value.TotalAmount));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Remark = ");
			stringBuilder.Append(GetDB(value.Remark));
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
			return " DELETE FROM Employee_Extra_Benefit ";
		}

		private string getKeyCondition(YearMonth yearMonth)
		{
			StringBuilder stringBuilder = new StringBuilder();

			if(IsNotNULL(yearMonth.Year))
			{
				stringBuilder.Append(" AND (Benefit_Year = ");
				stringBuilder.Append(GetDB(yearMonth.Year));
				stringBuilder.Append(")");
			}

			if(IsNotNULL(yearMonth.Month))
			{
				stringBuilder.Append(" AND (Benefit_Month = ");
				stringBuilder.Append(GetDB(yearMonth.Month));
				stringBuilder.Append(")");
			}

			return stringBuilder.ToString();
		}


		private string getOrderby()
		{
			return " ORDER BY Employee_No, Benefit_Year, Benefit_Month ";
		}
		#endregion

		#region - fill -
		private void fillExtraBenefit(ref ExtraBenefit value, SqlDataReader dataReader)
		{
			YearMonth yearMonth = new YearMonth(dataReader.GetInt16(BENEFIT_YEAR), dataReader.GetByte(BENEFIT_MONTH));
			value.AYearMonth = yearMonth;
			value.ABenefitPayment.PaymentStatus = CTFunction.GetPaymentStatusType((string)dataReader[BENEFIT_STATUS]);
			value.TotalAmount = dataReader.GetDecimal(BENEFIT_AMOUNT);
			value.Remark = (string)dataReader[REMARK];
		}

		private bool fillEmployeeExtraBenefit(ref EmployeeExtraBenefit value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objExtraBenefit = new ExtraBenefit();
					fillExtraBenefit(ref objExtraBenefit, dataReader);
					value.Add(objExtraBenefit);
				}
				objExtraBenefit = null;
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

		private bool fillEmployeeExtraBenefitList(ref EmployeeExtraBenefitList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			EmployeeExtraBenefit employeeExtraBenefit;

			EmployeeList employeeList = new EmployeeList(value.Company);
			EmployeeDB dbEmployee = new EmployeeDB();
			dbEmployee.FillAllEmployeeList(employeeList);

			try
			{
				while (dataReader.Read())
				{
					result = true;
					employeeExtraBenefit = new EmployeeExtraBenefit(employeeList[(string)dataReader[EMPLOYEE_NO]]);
					objExtraBenefit = new ExtraBenefit();
					fillExtraBenefit(ref objExtraBenefit, dataReader);
					employeeExtraBenefit.Add(objExtraBenefit);
					value.Add(employeeExtraBenefit);
				}
			}
			catch(IndexOutOfRangeException ein)
			{
				throw ein;
			}
			finally
			{
				tableAccess.CloseDataReader();
				dataReader = null;
				objExtraBenefit = null;
				employeeExtraBenefit = null;
				dbEmployee = null;
				employeeList = null;
			}
			return result;
		}

		#endregion

//		============================== Public Method ==============================
		public bool FillEmployeeExtraBenefit(ref EmployeeExtraBenefit value, ExtraBenefit aExtraBenefit)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getKeyCondition(aExtraBenefit.AYearMonth));
			stringBuilder.Append(getOrderby());

			return fillEmployeeExtraBenefit(ref value, stringBuilder.ToString());
		}

		public bool FillEmployeeExtraBenefitList(ref EmployeeExtraBenefitList value, YearMonth yearMonth)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getKeyCondition(yearMonth));
			stringBuilder.Append(getOrderby());

			return fillEmployeeExtraBenefitList(ref value, stringBuilder.ToString());
		}

		public bool InsertExtraBenefit(ExtraBenefit value, Employee aEmployee)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aEmployee))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateExtraBenefit(ExtraBenefit value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aEmployee));
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(value.AYearMonth));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteExtraBenefit(ExtraBenefit value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(value.AYearMonth));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteExtraBenefit(YearMonth yearMonth, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(yearMonth));

			return (tableAccess.ExecuteSQL(stringBuilder.ToString())>0);
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
