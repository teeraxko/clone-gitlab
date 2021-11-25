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
	public class EmployeeSalaryDB : DataAccessBase
	{
		#region - Constant -
		private const int EMPLOYEE_NO = 0;
		private const int BASIC_SALARY = 1;
		private const int POSITION_ALLOWANCE = 2;
		private const int SPECIAL_ALLOWANCE = 3;
		private const int REGULAR = 4;
		private const int BANK_CODE = 5;
		private const int BANK_ACCOUNT_NO = 6;
        private const int LSP_AMOUNT = 7;
        private const int MATCHING_FUND = 8;
        private const int EARNING = 9;
        private const int DIFF_RETIRING_ALLOWANCE = 10;
		#endregion

		#region - Private -	
		private bool disposed = false;
		private Salary objSalary;
		private BankDB dbBank;
		#endregion

        #region Constructor
        public EmployeeSalaryDB()
            : base()
        {
            dbBank = new BankDB();
        } 
        #endregion

        #region Private Method
        #region - getSQL -
        private string getSQLSelect()
        {
            return " SELECT Employee_No, Basic_Salary, Position_Allowance, Special_Allowance, Regular, Bank_Code, Bank_Account_No, LSP_Amount, Matching_Fund, Earning, Diff_Retiring_Allowance FROM Employee_Salary ";
        }

        private string getSQLInsert(Salary value, Employee aEmployee)
        {
            StringBuilder stringBuilder = new StringBuilder("INSERT INTO Employee_Salary (Company_Code, Employee_No, Basic_Salary, Position_Allowance, Special_Allowance, Regular, Bank_Code, Bank_Account_No, Process_Date, Process_User, LSP_Amount, Matching_Fund, Earning, Diff_Retiring_Allowance) ");
            stringBuilder.Append("VALUES (");

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
            stringBuilder.Append(", ");

            //LSP_Amount
            stringBuilder.Append(GetDB(value.LSPAmount));
            stringBuilder.Append(", ");

            //Matching_Fund
            stringBuilder.Append(GetDB(value.MatchingFund));
            stringBuilder.Append(", ");
            
            //Earning
            stringBuilder.Append(GetDB(value.Earning));
            stringBuilder.Append(", ");

            //Diff_Retiring_Allowance
            stringBuilder.Append(GetDB(value.DiffRetiringAllowance));
            stringBuilder.Append(")");

            return stringBuilder.ToString();
        }

        private string getSQLUpdate(Salary value, Employee aEmployee)
        {
            StringBuilder stringBuilder = new StringBuilder("UPDATE Employee_Salary SET ");
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
            stringBuilder.Append(", ");

            stringBuilder.Append("LSP_Amount = ");
            stringBuilder.Append(GetDB(value.LSPAmount));
            stringBuilder.Append(", ");

            stringBuilder.Append("Matching_Fund = ");
            stringBuilder.Append(GetDB(value.MatchingFund));
            stringBuilder.Append(", ");
            
            stringBuilder.Append("Earning = ");
            stringBuilder.Append(GetDB(value.Earning));
            stringBuilder.Append(", ");
            
            stringBuilder.Append("Diff_Retiring_Allowance = ");
            stringBuilder.Append(GetDB(value.DiffRetiringAllowance));

            return stringBuilder.ToString();
        }

        private string getSQLDelete()
        {
            return " DELETE FROM Employee_Salary ";
        }

        private string getOrderby()
        {
            return " ORDER BY Employee_No";
        }
        #endregion

        #region - Fill -
        private void fillSalary(ref Salary value, SqlDataReader dataReader)
        {
            value.Basic = dataReader.GetDecimal(BASIC_SALARY);
            value.PositionAllowance = dataReader.GetDecimal(POSITION_ALLOWANCE);
            value.SpecialAllowance = dataReader.GetDecimal(SPECIAL_ALLOWANCE);
            value.Regular = dataReader.GetDecimal(REGULAR);
            value.ABankDeposit.ABank = (Bank)dbBank.GetMTB((string)dataReader[BANK_CODE]);
            value.ABankDeposit.AccountNo = (string)dataReader[BANK_ACCOUNT_NO];
            value.LSPAmount = dataReader.GetDecimal(LSP_AMOUNT);
            value.MatchingFund = dataReader.GetDecimal(MATCHING_FUND);
            value.Earning = dataReader.GetDecimal(EARNING);
            value.DiffRetiringAllowance = dataReader.GetDecimal(DIFF_RETIRING_ALLOWANCE);
        }

        private bool fillSalary(ref Salary value, string sql)
        {
            bool result;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                if (dataReader.Read())
                {
                    fillSalary(ref value, dataReader);
                    result = true;
                }
                else
                { result = false; }
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }

            finally
            { tableAccess.CloseDataReader(); }
            return result;
        }
        #endregion 
        #endregion

		#region - internal -
		internal bool MaintainEmployeeSalary(Salary value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aEmployee));

			stringBuilder.Append(getSQLInsert(value, aEmployee));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}	
		}
		#endregion

        #region Public Method
        public Salary GetSalary(Employee value)
        {
            objSalary = new Salary();

            if (FillEmployeeSalary(ref objSalary, value))
            {
                return objSalary;
            }
            else
            {
                objSalary = null;
                return null;
            }
        }

        public bool FillEmployeeSalary(ref Salary value, Employee aEmployee)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(aEmployee));
            return fillSalary(ref value, stringBuilder.ToString());
        }

        public bool InsertEmployeeSalary(Salary value, Employee aEmployee)
        {
            if (tableAccess.ExecuteSQL(getSQLInsert(value, aEmployee)) > 0)
            { return true; }
            else
            { return false; }
        }

        public bool UpdateEmployeeSalary(Salary value, Employee aEmployee)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aEmployee));
            stringBuilder.Append(getBaseCondition(aEmployee));

            if (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0)
            { return true; }
            else
            { return false; }
        }

        public bool DeleteEmployeeSalary(Salary value, Employee aEmployee)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
            stringBuilder.Append(getBaseCondition(aEmployee));

            if (tableAccess.ExecuteSQL(stringBuilder.ToString()) > 0)
            { return true; }
            else
            { return false; }
        }

        public bool ImportEmployeeSalary(string employeeNo, decimal newSalary)
        {
            string stringCommand = "UPDATE Employee_Salary SET Basic_Salary = @BasicSalary, Process_Date = GETDATE(), Process_User = @ProcessUser WHERE Employee_No = @EmployeeNo";

            SqlCommand command = new SqlCommand(stringCommand);
            command.Parameters.Add(new SqlParameter("@BasicSalary", newSalary));
            command.Parameters.Add(new SqlParameter("@EmployeeNo", employeeNo));
            command.Parameters.Add(new SqlParameter("@ProcessUser", UserProfile.UserID));

            return tableAccess.ExecuteSQL(command) > 0;
        }
        #endregion

		#region IDisposable Members
		protected override void Dispose(bool disposing)
		{
			if(!this.disposed)
			{
				try
				{
					if(disposing)
					{}
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
