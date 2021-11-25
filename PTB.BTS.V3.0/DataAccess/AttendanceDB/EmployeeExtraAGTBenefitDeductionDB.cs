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
using DataAccess.ContractDB;

using SystemFramework.AppConfig;

using ictus.Common.Entity;

namespace DataAccess.AttendanceDB
{
	public class EmployeeExtraAGTBenefitDeductionDB : DataAccessBase
	{

		#region - Constant -
		private const int EMPLOYEE_NO = 0;
		private const int BENEFIT_YEAR = 1;
		private const int BENEFIT_MONTH = 2;		
		private const int BENEFIT_DATE = 3;	
		private const int SUBSTITUTE_EMPLOYEE_NO = 4;
		private const int BENEFIT_AMOUNT = 5;
		#endregion

		#region - Private -
		private ExtraAGTBenefitDeduction objExtraAGTBenefitDeduction; 
		private EmployeeDB dbEmployee;
		private bool disposed  = false;
		#endregion

//		============================== Constructor ==============================
		public EmployeeExtraAGTBenefitDeductionDB()
		{
			dbEmployee = new EmployeeDB();
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT Employee_No, Benefit_Year, Benefit_Month, Benefit_Date, Substitute_Employee_No, Benefit_Amount FROM Employee_Extra_AGT_Benefit_Deduction ";
		}

		private string getSQLInsert(ExtraAGTBenefitDeduction value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Employee_Extra_AGT_Benefit_Deduction (Company_Code, Employee_No, Benefit_Year, Benefit_Month, Benefit_Date, Substitute_Employee_No, Benefit_Amount, Process_Date, Process_User) ");
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

			//Benefit_Date
			stringBuilder.Append(GetDB(value.BenefitDate));
			stringBuilder.Append(", ");

			//Substitute_Employee_No
			if(value.AEmployee != null && IsNotNULL(value.AEmployee.EmployeeNo))
			{
				stringBuilder.Append(GetDB(value.AEmployee.EmployeeNo));
			}
			else
			{
				stringBuilder.Append(" NULL ");
			}
			stringBuilder.Append(", ");

			//Benefit_Amount
			stringBuilder.Append(GetDB(value.TotalAmount));
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
			return " DELETE FROM Employee_Extra_AGT_Benefit_Deduction ";
		}

		private string getKeyCondition(ExtraAGTBenefitDeduction value)
		{
			StringBuilder stringBuilder = new StringBuilder();

			if(IsNotNULL(value.AYearMonth.Year))
			{
				stringBuilder.Append(" AND (Benefit_Year = ");
				stringBuilder.Append(GetDB(value.AYearMonth.Year));
				stringBuilder.Append(")");
			}

			if(IsNotNULL(value.AYearMonth.Month))
			{
				stringBuilder.Append(" AND (Benefit_Month = ");
				stringBuilder.Append(GetDB(value.AYearMonth.Month));
				stringBuilder.Append(")");
			}
			if(IsNotNULL(value.BenefitDate))
			{
				stringBuilder.Append(" AND (Benefit_Date = ");
				stringBuilder.Append(GetDB(value.BenefitDate));
				stringBuilder.Append(")");
			}

			return stringBuilder.ToString();
		}

		private string getOrderby()
		{
			return " ORDER BY Employee_No, Benefit_Year, Benefit_Month, Benefit_Date ";
		}
		#endregion

		#region - fill -
		private void fillExtraAGTBenefitDeduction(ref ExtraAGTBenefitDeduction value, Company aCompany, SqlDataReader dataReader)
		{
			YearMonth yearMonth = new YearMonth(dataReader.GetInt16(BENEFIT_YEAR), dataReader.GetByte(BENEFIT_MONTH));
			value.AYearMonth = yearMonth;
			value.BenefitDate = dataReader.GetDateTime(BENEFIT_DATE);
			if (dataReader.IsDBNull(SUBSTITUTE_EMPLOYEE_NO))
			{
				value.AEmployee = null;
			}
			else
			{
				value.AEmployee = dbEmployee.GetFormerlyEmployee((string)dataReader[SUBSTITUTE_EMPLOYEE_NO], aCompany);
			}
			value.TotalAmount = dataReader.GetDecimal(BENEFIT_AMOUNT);
		}

		private bool fillEmployeeExtraAGTBenefitDeduction(ref EmployeeExtraAGTBenefitDeduction value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objExtraAGTBenefitDeduction = new ExtraAGTBenefitDeduction();
					fillExtraAGTBenefitDeduction(ref objExtraAGTBenefitDeduction, value.Company, dataReader);
					value.Add(objExtraAGTBenefitDeduction);
				}
				objExtraAGTBenefitDeduction = null;
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
		public bool FillEmployeeExtraAGTBenefitDeduction(ref EmployeeExtraAGTBenefitDeduction value, ExtraAGTBenefitDeduction aExtraAGTBenefitDeduction)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getKeyCondition(aExtraAGTBenefitDeduction));
			stringBuilder.Append(getOrderby());

			return fillEmployeeExtraAGTBenefitDeduction(ref value, stringBuilder.ToString());
		}

		public bool InsertExtraAGTBenefitDeduction(ExtraAGTBenefitDeduction value, Employee aEmployee)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aEmployee))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool DeleteExtraAGTBenefitDeduction(ExtraAGTBenefitDeduction value, Employee aEmployee)
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
