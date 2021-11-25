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
	public class FormerEmployeeSpecialAllowanceDB : DataAccessBase
	{
		#region - Constant -
		private const int EMPLOYEE_NO = 0;
		private const int SPECIAL_ALLOWANCE_NAME = 1;
		private const int SPECIAL_ALLOWANCE_AMOUNT = 2;
		#endregion

		#region - Private -
		private SpecialAllowance objSpecialAllowance;
		private bool disposed = false;
		#endregion

		//		============================== Constructor ==============================
		public FormerEmployeeSpecialAllowanceDB() : base()
		{
		}

		//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT Employee_No, Special_Allowance_Name, Special_Allowance_Amount FROM Former_Employee_Special_Allowance ";
		}

		private string getSQLInsert(SpecialAllowance value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Former_Employee_Special_Allowance (Company_Code, Employee_No, Special_Allowance_Name, Special_Allowance_Amount, Process_Date, Process_User) ");
			stringBuilder.Append(" VALUES ( ");

			//Company_Code
			stringBuilder.Append(GetDB(aEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			//Employee_No
			stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			//Special_Allowance_Name
			stringBuilder.Append(GetDB(value.AName.Thai));
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
			StringBuilder stringBuilder = new StringBuilder("UPDATE Former_Employee_Special_Allowance SET ");
			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(aEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Employee_No = ");
			stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			stringBuilder.Append("Special_Allowance_Name = ");
			stringBuilder.Append(GetDB(value.AName.Thai));
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
			return " DELETE FROM Former_Employee_Special_Allowance ";
		}

		private string getKeyCondition(SpecialAllowance value)
		{
			StringBuilder stringBuilder = new StringBuilder();

			if(IsNotNULL(value.AName.Thai))
			{
				stringBuilder.Append(" AND (Special_Allowance_Name = ");
				stringBuilder.Append(GetDB(value.AName.Thai));
				stringBuilder.Append(")");			
			}

			return stringBuilder.ToString();
		}
		
		private string getOrderby()
		{
			return " ORDER BY Special_Allowance_Name ";
		}
		#endregion

		#region - Fill -
		private void fillFormerEmployeeSpecialAllowance(ref SpecialAllowance value, SqlDataReader dataReader)
		{
			value.AName.Thai = (string)dataReader[SPECIAL_ALLOWANCE_NAME];
			value.Amount = dataReader.GetDecimal(SPECIAL_ALLOWANCE_AMOUNT);
		}

		private bool fillFormerEmployeeSpecialAllowanceList(ref EmployeeSpecialAllowance value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objSpecialAllowance = new SpecialAllowance();
					fillFormerEmployeeSpecialAllowance(ref objSpecialAllowance, dataReader);
					value.Add(objSpecialAllowance);
				}
				objSpecialAllowance = null;
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

//		============================== internal Method ==============================
		#region - internal -
		internal bool MaintainFormerEmployeeSpecialAllowance(EmployeeSpecialAllowance value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for(int i=0; i<value.Count; i++)
			{
				stringBuilder.Append(getSQLDelete());
				stringBuilder.Append(getBaseCondition(value.Employee));
				stringBuilder.Append(getKeyCondition(value[i]));
			}

			for(int i=0; i<value.Count; i++)
			{
				stringBuilder.Append(getSQLInsert(value[i], value.Employee));		
			}

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}	
		}
//		internal bool DeleteFormerEmployeeSpecialAllowance(SpecialAllowance value, Employee aEmployee)
//		{
//			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
//			stringBuilder.Append(getBaseCondition(aEmployee));
//			stringBuilder.Append(getKeyCondition(value));
//
//			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
//			{return true;}
//			else
//			{return false;}
//		}
//		internal bool InsertFormerEmployeeSpecialAllowance(SpecialAllowance value, Employee aEmployee, SqlTransaction transaction)
//		{
//			if (tableAccess.ExecuteSQL(getSQLInsert(value, aEmployee), transaction)>0)
//			{return true;}
//			else
//			{return false;}	
//		}
//
//		internal bool UpdateFormerEmployeeSpecialAllowance(SpecialAllowance value, Employee aEmployee, SqlTransaction transaction)
//		{
//			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aEmployee));
//			stringBuilder.Append(getBaseCondition(aEmployee));
//			stringBuilder.Append(getKeyCondition(value));
//
//			if (tableAccess.ExecuteSQL(stringBuilder.ToString(), transaction)>0)
//			{return true;}
//			else
//			{return false;}
//		}
		#endregion
//		============================== Public Method ==============================
		public bool FillFormerEmployeeSpecialAllowanceList(ref EmployeeSpecialAllowance value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getOrderby());

			return fillFormerEmployeeSpecialAllowanceList(ref value, stringBuilder.ToString());
		}

		public bool InsertFormerEmployeeSpecialAllowance(SpecialAllowance value, Employee aEmployee)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aEmployee))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateFormerEmployeeSpecialAllowance(SpecialAllowance value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aEmployee));
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteFormerEmployeeSpecialAllowance(SpecialAllowance value, Employee aEmployee)
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
