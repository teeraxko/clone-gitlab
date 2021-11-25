using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using DataAccess.CommonDB;
using DataAccess.PiDB;
using DataAccess.ContractDB;

using SystemFramework.AppConfig;

using ictus.Common.Entity.General;
using ictus.PIS.PI.Entity;

namespace DataAccess.AttendanceDB
{
	public class EmployeeFoodBenefitDB : DataAccessBase
	{
		#region - Constant -
		private const int EMPLOYEE_NO = 0;
		private const int BENEFIT_DATE = 1;
		private const int BENEFIT_AMOUNT = 2;		
		private const int PAYMENT_STATUS = 3;
		private const int PAYMENT_DATE = 4;
		#endregion

		#region - Private -
		private FoodBenefit objFoodBenefit; 
		private bool disposed  = false;
		#endregion

//		============================== Constructor ==============================
		public EmployeeFoodBenefitDB(): base()
		{}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT Employee_No, Benefit_Date,  Benefit_Amount, Payment_Status, Payment_Date FROM Employee_Food_Benefit ";
		}

		private string getSQLInsert(FoodBenefit value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Employee_Food_Benefit (Company_Code, Employee_No, Benefit_Date,  Benefit_Amount, Payment_Status, Payment_Date, Process_Date, Process_User) ");
			stringBuilder.Append("VALUES (");

			//Company_Code
			stringBuilder.Append(GetDB(aEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			//Employee_No
			stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			//Benefit_Date
			stringBuilder.Append(GetDB(value.BenefitDate));
			stringBuilder.Append(", ");
		

			//Benefit_Amount
			stringBuilder.Append(GetDB(value.TotalAmount));
			stringBuilder.Append(", ");

			//Payment_Status
			stringBuilder.Append(GetDB(value.ABenefitPayment.PaymentStatus));
			stringBuilder.Append(", ");

			//Payment_Date
			if(IsNotNULL(value.ABenefitPayment.PaymentDate))
			{
				stringBuilder.Append(GetDB(value.ABenefitPayment.PaymentDate));
			}
			else
			{
				stringBuilder.Append(GetDB(NullConstant.DATETIME));
			}
			stringBuilder.Append(", ");

			//Process_Date
			stringBuilder.Append(GetDateDB());
			stringBuilder.Append(", ");

			//Process_User
			stringBuilder.Append(GetDB(UserProfile.UserID));
			stringBuilder.Append(")");

			return stringBuilder.ToString();
		}

		private string getSQLUpdate(FoodBenefit value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Employee_Food_Benefit SET ");

			stringBuilder.Append(" Company_Code = ");
			stringBuilder.Append(GetDB(aEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Employee_No = ");
			stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Benefit_Date = ");
			stringBuilder.Append(GetDB(value.BenefitDate));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Benefit_Amount = ");
			stringBuilder.Append(GetDB(value.TotalAmount));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Payment_Status = ");
			stringBuilder.Append(GetDB(value.ABenefitPayment.PaymentStatus));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Payment_Date = ");
			if(IsNotNULL(value.ABenefitPayment.PaymentDate))
			{
				stringBuilder.Append(GetDB(value.ABenefitPayment.PaymentDate));
			}
			else
			{
				stringBuilder.Append(GetDB(NullConstant.DATETIME));
			}
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
			return " DELETE FROM Employee_Food_Benefit ";
		}

		private string getKeyCondition(FoodBenefit value)
		{
			StringBuilder stringBuilder = new StringBuilder();

			if(IsNotNULL(value.BenefitDate))
			{
				stringBuilder.Append(" AND (Benefit_Date = ");
				stringBuilder.Append(GetDB(value.BenefitDate));
				stringBuilder.Append(")");
			}

			return stringBuilder.ToString();
		}

		private string getListCondition(EmployeeFoodBenefit value)
		{
			return " AND " +  SqlFunction.GetYearMonthCondition("Benefit_Date", value.AYearMonth);
		}

		private string getOrderby()
		{
			return " ORDER BY Employee_No, Benefit_Date ";
		}
		#endregion

		#region - fill -
		private void fillFoodBenefit(ref FoodBenefit value, SqlDataReader dataReader)
		{
			value.BenefitDate = dataReader.GetDateTime(BENEFIT_DATE);
			value.TotalAmount = dataReader.GetDecimal(BENEFIT_AMOUNT);
			value.ABenefitPayment.PaymentStatus = CTFunction.GetPaymentStatusType((string)dataReader[PAYMENT_STATUS]);
			
			if (dataReader.IsDBNull(PAYMENT_DATE))
			{
				value.ABenefitPayment.PaymentDate = NullConstant.DATETIME;
			}
			else
			{
				value.ABenefitPayment.PaymentDate = dataReader.GetDateTime(PAYMENT_DATE);
			}
		}

		private bool fillFoodBenefitList(ref EmployeeFoodBenefit value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objFoodBenefit = new FoodBenefit();
					fillFoodBenefit(ref objFoodBenefit, dataReader);
					value.Add(objFoodBenefit);
				}
				objFoodBenefit = null;
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
		public bool FillFoodBenefitList(ref EmployeeFoodBenefit value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getListCondition(value));
			stringBuilder.Append(getOrderby());

			return fillFoodBenefitList(ref value, stringBuilder.ToString());
		}

		public bool FillFoodBenefitList(ref EmployeeFoodBenefit value, FoodBenefit aFoodBenefit)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getKeyCondition(aFoodBenefit));
			stringBuilder.Append(getOrderby());

			return fillFoodBenefitList(ref value, stringBuilder.ToString());
		}


		public bool InsertFoodBenefit(FoodBenefit value, Employee aEmployee)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aEmployee))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateFoodBenefit(FoodBenefit value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aEmployee));
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteFoodBenefit(FoodBenefit value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool InsertEmployeeFoodBenefit(EmployeeFoodBenefit value)
		{
			StringBuilder stringBuilder = new StringBuilder("BEGIN ");
			for(int i=0; i<value.Count; i++)
			{				
				stringBuilder.Append(getSQLInsert(value[i], value.Employee));
				stringBuilder.Append(";");
			}
			stringBuilder.Append(" END;");
	
			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateEmployeeFoodBenefit(EmployeeFoodBenefit value)
		{
			StringBuilder stringBuilder = new StringBuilder("BEGIN ");

			stringBuilder.Append(getSQLDelete());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getListCondition(value));

			for(int i=0; i<value.Count; i++)
			{				
				stringBuilder.Append(getSQLInsert(value[i], value.Employee));
				stringBuilder.Append(";");
			}
			stringBuilder.Append(" END;");
	
			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0 || value.Count==0)
			{return true;}
			else
			{return false;}	
		}

		public bool DeleteEmployeeFoodBenefit(EmployeeFoodBenefit value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getListCondition(value));

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
