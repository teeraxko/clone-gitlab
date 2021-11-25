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
	public class EmployeeSpecialAllowanceDB : DataAccessBase
	{
		#region - Constant -
		private const int EMPLOYEE_NO = 0;
		private const int SPECIAL_ALLOWANCE_CODE = 1;
		private const int SPECIAL_ALLOWANCE_AMOUNT = 2;
		#endregion

		#region - Private -
		private SpecialAllowance objSpecialAllowance;
		private SpecialAllowanceDB dbSpecialAllowance;
		private bool disposed = false;
		#endregion

//		============================== Constructor ==============================
		public EmployeeSpecialAllowanceDB() : base()
		{
			dbSpecialAllowance = new SpecialAllowanceDB();
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT Employee_No, Special_Allowance_Code, Special_Allowance_Amount FROM Employee_Special_Allowance ";
		}

		private string getSQLInsert(SpecialAllowance value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Employee_Special_Allowance (Company_Code, Employee_No, Special_Allowance_Code, Special_Allowance_Amount, Process_Date, Process_User) ");
			stringBuilder.Append(" VALUES ( ");

			//Company_Code
			stringBuilder.Append(GetDB(aEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			//Employee_No
			stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			//Special_Allowance_Code
			stringBuilder.Append(GetDB(value.Code));
			stringBuilder.Append(", ");
			
			//Special_Allowance_Amount
			stringBuilder.Append(GetDB(value.Amount));
			stringBuilder.Append(", ");
			
			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();	
		}

		private string getSQLUpdate(SpecialAllowance value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Employee_Special_Allowance SET ");
			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(aEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Employee_No = ");
			stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			stringBuilder.Append("Special_Allowance_Code = ");
			stringBuilder.Append(GetDB(value.Code));
			stringBuilder.Append(", ");
			
			stringBuilder.Append("Special_Allowance_Amount = ");
			stringBuilder.Append(GetDB(value.Amount));
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
			return " DELETE FROM Employee_Special_Allowance ";
		}

		private string getKeyCondition(SpecialAllowance value)
		{
			StringBuilder stringBuilder = new StringBuilder();

			if(IsNotNULL(value.Code))
			{
				stringBuilder.Append(" AND (Special_Allowance_Code = ");
				stringBuilder.Append(GetDB(value.Code));
				stringBuilder.Append(")");			
			}
			return stringBuilder.ToString();
		}
		
		private string getOrderby()
		{
			return " ORDER BY Special_Allowance_Code ";
		}
		#endregion

		#region - Fill -
        private void fillEmployeeSpecialAllowance(ref SpecialAllowance value, ictus.Common.Entity.Company aCompany, SqlDataReader dataReader)
		{
			value = dbSpecialAllowance.GetDBSpecialAllowance((string)dataReader[SPECIAL_ALLOWANCE_CODE], aCompany);
			value.Amount = dataReader.GetDecimal(SPECIAL_ALLOWANCE_AMOUNT);
		}

		private bool fillEmployeeSpecialAllowanceList(ref EmployeeSpecialAllowance value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objSpecialAllowance = new SpecialAllowance();
					fillEmployeeSpecialAllowance(ref objSpecialAllowance, value.Company, dataReader);
					value.Add(objSpecialAllowance);
				}
				objSpecialAllowance = null;
			}
			catch(IndexOutOfRangeException ein)
			{throw ein;}

			finally
			{tableAccess.CloseDataReader();}
			return result;		
		}
		#endregion

//		============================== internal Method ==============================
		#region - internal -
		internal bool MaintainEmployeeSpecialAllowance(EmployeeSpecialAllowance value)
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

		internal bool DeleteEmployeeSpecialAllowance(EmployeeSpecialAllowance value)
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
		public bool FillEmployeeSpecialAllowanceList(ref EmployeeSpecialAllowance value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getOrderby());

			return fillEmployeeSpecialAllowanceList(ref value, stringBuilder.ToString());
		}

		public bool InsertEmployeeSpecialAllowance(SpecialAllowance value, Employee aEmployee)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aEmployee))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateEmployeeSpecialAllowance(SpecialAllowance value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aEmployee));
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteEmployeeSpecialAllowance(SpecialAllowance value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(value));

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
