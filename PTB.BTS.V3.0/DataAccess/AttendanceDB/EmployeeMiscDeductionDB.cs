using System;
using System.Text;
using System.Data.SqlClient;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

namespace DataAccess.AttendanceDB
{
	public class EmployeeMiscDeductionDB : EmployeeMiscDBBase
	{
		private const int BENEFIT_YEAR = 1;
		private const int BENEFIT_MONTH = 2;

		//==============================   Constructor  ==============================
		public EmployeeMiscDeductionDB() : base()
		{
		}

		//============================== Private Method ==============================
		#region - getSQL -
		protected override string getSQLSelect()
		{
			return " SELECT Employee_No, For_Year, For_Month, Deduction_Description, Deduction_Amount FROM Employee_Misc_Deduction ";
		}

		protected override string getSQLInsert(MiscBenefit value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Employee_Misc_Deduction (Company_Code, Employee_No, For_Year, For_Month, Deduction_Description, Deduction_Amount, Process_Date, Process_User) VALUES (");

			//Company_Code
			stringBuilder.Append(GetDB(aEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			//Employee_No
			stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			//For_Year
			stringBuilder.Append(GetDB(value.AYearMonth.Year));
			stringBuilder.Append(", ");

			//For_Month
			stringBuilder.Append(GetDB(value.AYearMonth.Month));
			stringBuilder.Append(", ");

			//Deduction_Description
			stringBuilder.Append(GetDB(value.Description));
			stringBuilder.Append(", ");

			//Deduction_Amount
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

		protected override string getSQLUpdate(MiscBenefit value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Employee_Misc_Deduction SET ");

			stringBuilder.Append(" Company_Code = ");
			stringBuilder.Append(GetDB(aEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Employee_No = ");
			stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			stringBuilder.Append(" For_Year = ");
			stringBuilder.Append(GetDB(value.AYearMonth.Year));
			stringBuilder.Append(", ");

			stringBuilder.Append(" For_Month = ");
			stringBuilder.Append(GetDB(value.AYearMonth.Month));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Deduction_Description = ");
			stringBuilder.Append(GetDB(value.Description));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Deduction_Amount = ");
			stringBuilder.Append(GetDB(value.TotalAmount));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Process_Date = ");
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			stringBuilder.Append(" Process_User = ");
			stringBuilder.Append(GetDB(UserProfile.UserID));
				
			return stringBuilder.ToString();
		}

		protected override string getSQLDelete()
		{
			return " DELETE FROM Employee_Misc_Deduction ";
		}

		protected override string getKeyCondition(MiscBenefit value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if(IsNotNULL(value.AYearMonth.Year))
			{
				stringBuilder.Append(" AND (For_Year = ");
				stringBuilder.Append(GetDB(value.AYearMonth.Year));
				stringBuilder.Append(")");
			}
			if(IsNotNULL(value.AYearMonth.Month))
			{
				stringBuilder.Append(" AND (For_Month = ");
				stringBuilder.Append(GetDB(value.AYearMonth.Month));
				stringBuilder.Append(")");
			}
			if(IsNotNULL(value.Description))
			{
				stringBuilder.Append(" AND (Deduction_Description = ");
				stringBuilder.Append(GetDB(value.Description));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

		protected override string getOrderby()
		{
			return " ORDER BY Employee_No, Deduction_Description ";
		}
		#endregion

		#region - fill -
		protected override void fillMiscellaneousBenefit(ref MiscBenefit value, SqlDataReader dataReader)
		{
			base.fillMiscellaneousBenefit(ref value, dataReader);

			value.AYearMonth = new YearMonth(dataReader.GetInt32(BENEFIT_YEAR), dataReader.GetByte(BENEFIT_MONTH));
		}
		#endregion
	}
}