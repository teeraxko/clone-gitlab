using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;
using ictus.Common.Entity.General;

using DataAccess.CommonDB;
using DataAccess.PiDB;
using DataAccess.ContractDB;

using SystemFramework.AppConfig;

namespace DataAccess.AttendanceDB
{
	public class EmployeeExtraAGTBenefitDB : DataAccessBase
	{
		#region - Constant -
		private const int EMPLOYEE_NO = 0;
		private const int BENEFIT_YEAR = 1;
		private const int BENEFIT_MONTH = 2;
		private const int BENEFIT_AMOUNT = 3;	
		private const int DAYS_DEDUCTION = 4;
		private const int DEDUCTION_AMOUNT_PER_DAY = 5;
		private const int BENEFIT_NET_AMOUNT = 6;
		private const int PAYMENT_STATUS = 7;
		private const int PAYMENT_DATE = 8;
		#endregion

		#region - Private -
		private ExtraAGTBenefit objExtraAGTBenefit; 
		private bool disposed  = false;
		#endregion

//		============================== Constructor ==============================
		public EmployeeExtraAGTBenefitDB(): base()
		{}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT Employee_No, Benefit_Year, Benefit_Month, Benefit_Amount,  Days_Deduction,  Deduction_Amount_Per_Day,  Benefit_Net_Amount,  Payment_Status, Payment_Date FROM Employee_Extra_AGT_Benefit ";
		}

		private string getSQLInsert(ExtraAGTBenefit value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Employee_Extra_AGT_Benefit (Company_Code, Employee_No, Benefit_Year, Benefit_Month, Benefit_Amount,  Days_Deduction,  Deduction_Amount_Per_Day,  Benefit_Net_Amount, Payment_Status, Payment_Date, Process_Date, Process_User) ");
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

			//Benefit_Amount
			stringBuilder.Append(GetDB(value.TotalAmount));
			stringBuilder.Append(", ");

			//Days_Deduction
			stringBuilder.Append(GetDB(value.DaysDeduction));
			stringBuilder.Append(", ");

			//Deduction_Amount_Per_Day
			stringBuilder.Append(GetDB(value.DeductionAmountPerDay));
			stringBuilder.Append(", ");

			//Benefit_Net_Amount
			stringBuilder.Append(GetDB(value.TotalDeductionAmount));
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

		private string getSQLUpdate(ExtraAGTBenefit value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Employee_Extra_AGT_Benefit SET ");

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

			stringBuilder.Append(" Benefit_Amount = ");
			stringBuilder.Append(GetDB(value.TotalAmount));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Days_Deduction = ");
			stringBuilder.Append(GetDB(value.DaysDeduction));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Deduction_Amount_Per_Day = ");
			stringBuilder.Append(GetDB(value.DeductionAmountPerDay));
			stringBuilder.Append(", ");

			stringBuilder.Append(" Benefit_Net_Amount = ");
			stringBuilder.Append(GetDB(value.TotalDeductionAmount));
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
			return " DELETE FROM Employee_Extra_AGT_Benefit ";
		}

		private string getKeyCondition(ExtraAGTBenefit value)
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

			return stringBuilder.ToString();
		}

		private string getOrderby()
		{
			return " ORDER BY Employee_No, Benefit_Year, Benefit_Month ";
		}
		#endregion

		#region - fill -
		private void fillExtraAGTBenefit(ref ExtraAGTBenefit value, SqlDataReader dataReader)
		{
			YearMonth yearMonth = new YearMonth(dataReader.GetInt16(BENEFIT_YEAR), dataReader.GetByte(BENEFIT_MONTH));
			value.AYearMonth = yearMonth;
			value.TotalAmount = dataReader.GetDecimal(BENEFIT_AMOUNT);
			value.DaysDeduction = dataReader.GetByte(DAYS_DEDUCTION);
			value.DeductionAmountPerDay = dataReader.GetDecimal(DEDUCTION_AMOUNT_PER_DAY);
			value.TotalDeductionAmount = dataReader.GetDecimal(BENEFIT_NET_AMOUNT);

			if (dataReader.IsDBNull(PAYMENT_DATE))
			{
				value.ABenefitPayment.PaymentDate = NullConstant.DATETIME;
			}
			else
			{
				value.ABenefitPayment.PaymentDate = dataReader.GetDateTime(PAYMENT_DATE);
			}

			value.ABenefitPayment.PaymentStatus = CTFunction.GetPaymentStatusType((string)dataReader[PAYMENT_STATUS]);
		}

		private bool fillEmployeeExtraAGTBenefit(ref EmployeeExtraAGTBenefit value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objExtraAGTBenefit = new ExtraAGTBenefit();
					fillExtraAGTBenefit(ref objExtraAGTBenefit, dataReader);
					value.Add(objExtraAGTBenefit);
				}
				objExtraAGTBenefit = null;
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

		private bool fillExtraAGTBenefit(ref ExtraAGTBenefit value, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{					
					fillExtraAGTBenefit(ref value, dataReader);
					result = true;
				}
				else
				{
					result = false;
				}
			}
			catch (IndexOutOfRangeException ein)
			{throw ein;}

			finally
			{tableAccess.CloseDataReader();}
			return result;
		}


		#endregion

//		============================== Public Method ==============================
		public ExtraAGTBenefit GetExtraAGTBenefit(YearMonth aYearMonth, Employee aEmployee)
		{
			objExtraAGTBenefit = new ExtraAGTBenefit();
			objExtraAGTBenefit.AYearMonth = aYearMonth;
			if(FillExtraAGTBenefit(ref objExtraAGTBenefit, aEmployee))
			{
				return objExtraAGTBenefit;
			}
			else
			{
				objExtraAGTBenefit = null;
				return null;
			}
		}

		public bool FillEmployeeExtraAGTBenefit(ref EmployeeExtraAGTBenefit value, ExtraAGTBenefit aExtraAGTBenefit)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getKeyCondition(aExtraAGTBenefit));
			stringBuilder.Append(getOrderby());

			return fillEmployeeExtraAGTBenefit(ref value, stringBuilder.ToString());
		}

		public bool FillExtraAGTBenefit(ref ExtraAGTBenefit value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(value));

			return fillExtraAGTBenefit(ref value, stringBuilder.ToString());
		}

		public bool InsertExtraAGTBenefit(ExtraAGTBenefit value, Employee aEmployee)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aEmployee))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateExtraAGTBenefit(ExtraAGTBenefit value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aEmployee));
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteExtraAGTBenefit(ExtraAGTBenefit value, Employee aEmployee)
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
