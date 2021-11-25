using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using ictus.PIS.PI.Entity;
using Entity.CommonEntity;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

namespace DataAccess.PiDB
{
	public class FormerEmployeeSalaryDB : DataAccessBase
	{
		#region - Constant -
		private const int EMPLOYEE_NO = 0;
		private const int BASIC_SALARY = 1;
		private const int POSITION_ALLOWANCE = 2;
		private const int SPECIAL_ALLOWANCE = 3;
		private const int REGULAR = 4;
		private const int BANK_CODE = 5;
		private const int BANK_ACCOUNT_NO = 6;
		#endregion

		#region - Private -	
		private bool disposed = false;
		private Salary objSalary;
		private BankDB dbBank;
		#endregion

//		============================== Constructor ==============================
		public FormerEmployeeSalaryDB() : base()
		{
			dbBank = new BankDB();
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT Employee_No, Basic_Salary, Position_Allowance, Special_Allowance, Regular, Bank_Code, Bank_Account_No FROM Former_Employee_Salary ";
		}

		private string getSQLInsert(Salary value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Former_Employee_Salary (Company_Code, Employee_No, Basic_Salary, Position_Allowance, Special_Allowance, Regular, Bank_Code, Bank_Account_No, Process_Date, Process_User) ");
			stringBuilder.Append(" VALUES ( ");

			//Company_Code
			stringBuilder.Append(GetDB(aEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			//Employee_No
			stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			//Basic_Salary
			stringBuilder.Append(GetDB(value.Basic));
			stringBuilder.Append(", ");
			
			//Position_Allowance
			stringBuilder.Append(GetDB(value.PositionAllowance));
			stringBuilder.Append(", ");
			
			//Special_Allowance
			stringBuilder.Append(GetDB(value.SpecialAllowance));
			stringBuilder.Append(", ");
			
			//Regular
			stringBuilder.Append(GetDB(value.Regular));
			stringBuilder.Append(", ");
			
			//Bank_Code
			stringBuilder.Append(GetDB(value.ABankDeposit.ABank.Code));
			stringBuilder.Append(", ");
			
			//Bank_Account_No
			stringBuilder.Append(GetDB(value.ABankDeposit.AccountNo));
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();	
		}

		private string getSQLUpdate(Salary value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Former_Employee_Salary SET ");
			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(aEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Employee_No = ");
			stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			stringBuilder.Append("Basic_Salary = ");
			stringBuilder.Append(GetDB(value.Basic));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Position_Allowance = ");
			stringBuilder.Append(GetDB(value.PositionAllowance));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Special_Allowance = ");
			stringBuilder.Append(GetDB(value.SpecialAllowance));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Regular = ");
			stringBuilder.Append(GetDB(value.Regular));
			stringBuilder.Append(", ");

			stringBuilder.Append("Bank_Code = ");
			stringBuilder.Append(GetDB(value.ABankDeposit.ABank.Code));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Bank_Account_No = ");
			stringBuilder.Append(GetDB(value.ABankDeposit.AccountNo));
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
			return " DELETE FROM Former_Employee_Salary ";
		}

		private string getOrderby()
		{
			return " ORDER BY Employee_No";
		}
		#endregion

		#region - Fill -
		private void fillFormerEmployeeSalary(ref Salary value, SqlDataReader dataReader)
		{
			value.Basic = dataReader.GetDecimal(BASIC_SALARY);
			value.PositionAllowance = dataReader.GetDecimal(POSITION_ALLOWANCE);
			value.SpecialAllowance = dataReader.GetDecimal(SPECIAL_ALLOWANCE);
			value.Regular = dataReader.GetDecimal(REGULAR);
			value.ABankDeposit.ABank = (Bank)dbBank.GetMTB((string)dataReader[BANK_CODE]);
			value.ABankDeposit.AccountNo = (string)dataReader[BANK_ACCOUNT_NO];
		}

		private bool fillFormerEmployeeSalary(ref Salary value, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{
					fillFormerEmployeeSalary(ref value, dataReader);
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
//		#region - internal -
//		internal bool InsertFormerEmployeeSalary(Salary value, Employee aEmployee, SqlTransaction transaction)
//		{
//			if (tableAccess.ExecuteSQL(getSQLInsert(value, aEmployee), transaction)>0)
//			{return true;}
//			else
//			{return false;}	
//		}
//
//		internal bool UpdateFormerEmployeeSalary(Salary value, Employee aEmployee)
//		{
//			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aEmployee));
//			stringBuilder.Append(getBaseCondition(aEmployee));
//
//			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
//			{return true;}
//			else
//			{return false;}
//		}
//
//		internal bool DeleteFormerEmployeeSalary(Salary value, Employee aEmployee, SqlTransaction transaction)
//		{
//			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
//			stringBuilder.Append(getBaseCondition(aEmployee));
//
//			if (tableAccess.ExecuteSQL(stringBuilder.ToString(), transaction)>0)
//			{return true;}
//			else
//			{return false;}
//		}
//		#endregion
//		============================== Public Method ==============================
		public Salary GetFormerEmployeeSalary(Employee value)
		{
			objSalary = new Salary();	
		
			if(FillFormerEmployeeSalary(ref objSalary, value))
			{
				return objSalary;		
			}
			else
			{
				objSalary = null;
				return null;
			}
		}

		public bool FillFormerEmployeeSalary(ref Salary value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aEmployee));
			return fillFormerEmployeeSalary(ref value, stringBuilder.ToString());
		}

		public bool InsertFormerEmployeeSalary(Salary value, Employee aEmployee)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aEmployee))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateFormerEmployeeSalary(Salary value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aEmployee));
			stringBuilder.Append(getBaseCondition(aEmployee));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteFormerEmployeeSalary(Salary value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aEmployee));

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
