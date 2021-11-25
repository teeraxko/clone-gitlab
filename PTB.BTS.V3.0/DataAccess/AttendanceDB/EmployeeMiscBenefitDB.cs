using System;
using System.Text;
using System.Data.SqlClient;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;
using ictus.Common.Entity.Time;

using DataAccess.CommonDB;

using SystemFramework.AppConfig;

namespace DataAccess.AttendanceDB
{
	public class EmployeeMiscBenefitDB : EmployeeMiscDBBase
	{
		#region - Constant -	
		private const int BENEFIT_YEAR = 1;
		private const int BENEFIT_MONTH = 2;
		private const int PAYMENT_STATUS = 5;
		private const int PAYMENT_DATE = 6;
		#endregion

//		============================== Constructor ==============================
		public EmployeeMiscBenefitDB() : base()
		{	
		}

//		============================== Private Method ==============================
		#region - getSQL -
			protected override string getSQLSelect()
			{
				return " SELECT Employee_No, Benefit_Year, Benefit_Month, Benefit_Description, Benefit_Amount, Payment_Status, Payment_Date FROM Employee_Misc_Benefit ";
			}

			protected override string getSQLInsert(MiscBenefit value, Employee aEmployee)
			{
				StringBuilder stringBuilder = new StringBuilder("INSERT INTO Employee_Misc_Benefit (Company_Code, Employee_No, Benefit_Year, Benefit_Month, Benefit_Description, Benefit_Amount, Payment_Status, Payment_Date, Process_Date, Process_User) VALUES (");

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

				//Benefit_Description
				stringBuilder.Append(GetDB(value.Description));
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

			protected override string getSQLUpdate(MiscBenefit value, Employee aEmployee)
			{
				StringBuilder stringBuilder = new StringBuilder("UPDATE Employee_Misc_Benefit SET ");

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

				stringBuilder.Append(" Benefit_Description = ");
				stringBuilder.Append(GetDB(value.Description));
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

			protected override string getSQLDelete()
			{
				return " DELETE FROM Employee_Misc_Benefit ";
			}

			protected override string getKeyCondition(MiscBenefit value)
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
				if(IsNotNULL(value.Description))
				{
					stringBuilder.Append(" AND (Benefit_Description = ");
					stringBuilder.Append(GetDB(value.Description));
					stringBuilder.Append(")");
				}
				return stringBuilder.ToString();
			}

			protected override string getOrderby()
			{
				return " ORDER BY Employee_No, Benefit_Description ";
			}
		#endregion
		
		#region - fill -
			protected override void fillMiscellaneousBenefit(ref MiscBenefit value, SqlDataReader dataReader)
			{
				base.fillMiscellaneousBenefit(ref value, dataReader);

				value.AYearMonth = new YearMonth(dataReader.GetInt16(BENEFIT_YEAR), dataReader.GetByte(BENEFIT_MONTH));
				if (dataReader.IsDBNull(PAYMENT_DATE))
				{
					value.ABenefitPayment.PaymentDate = NullConstant.DATETIME;
				}
				else
				{
					value.ABenefitPayment.PaymentDate = dataReader.GetDateTime(PAYMENT_DATE);
				}

				if(dataReader.IsDBNull(PAYMENT_STATUS))
				{
					value.ABenefitPayment.PaymentStatus = PAYMENT_STATUS_TYPE.NULL;
				}
				else
				{
					value.ABenefitPayment.PaymentStatus = CTFunction.GetPaymentStatusType((string)dataReader[PAYMENT_STATUS]);
				}
			}
		#endregion

//		============================== Public Method ==============================

	}
}























//using System;
//using System.Text;
//using System.Data;
//using System.Data.SqlClient;
//
//using Entity.CommonEntity;
//using ictus.PIS.PI.Entity;
//using Entity.AttendanceEntities;
//
//using DataAccess.CommonDB;
//using DataAccess.PiDB;
//using DataAccess.ContractDB;
//
//using SystemFramework.AppConfig;
//
//namespace DataAccess.AttendanceDB
//{
//	public class EmployeeMiscBenefitDB : DataAccessBase
//	{
//		#region - Constant -
//		private const int EMPLOYEE_NO = 0;
//		private const int BENEFIT_YEAR = 1;
//		private const int BENEFIT_MONTH = 2;
//		private const int BENEFIT_DESCTIPTION = 3;
//		private const int BENEFIT_AMOUNT = 4;		
//		private const int PAYMENT_STATUS = 5;
//		private const int PAYMENT_DATE = 6;
//		#endregion
//
//		#region - Private -
//		private MiscBenefit objMiscBenefit;
//		private bool disposed  = false;
//		#endregion
//
////		============================== Constructor ==============================
//		public EmployeeMiscBenefitDB() : base()
//		{	
//		}
//
//		protected string tableName = "Employee_Misc_Benefit";
//
////		============================== Private Method ==============================
//		#region - getSQL -
//		private string getSQLSelect()
//		{
//			return " SELECT Employee_No, Benefit_Year, Benefit_Month, Benefit_Description, Benefit_Amount, Payment_Status, Payment_Date FROM  " + tableName  + " ";
//		}
//
//		private string getSQLInsert(MiscBenefit value, Employee aEmployee)
//		{
//			StringBuilder stringBuilder = new StringBuilder("INSERT INTO ");
//			stringBuilder.Append(tableName);
//			stringBuilder.Append(" (Company_Code, Employee_No, Benefit_Year, Benefit_Month, Benefit_Description, Benefit_Amount, Payment_Status, Payment_Date, Process_Date, Process_User) ");
//			stringBuilder.Append("VALUES (");
//
//			//Company_Code
//			stringBuilder.Append(GetDB(aEmployee.Company.CompanyCode));
//			stringBuilder.Append(", ");
//
//			//Employee_No
//			stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
//			stringBuilder.Append(", ");
//
//			//Benefit_Year
//			stringBuilder.Append(GetDB(value.AYearMonth.Year));
//			stringBuilder.Append(", ");
//
//			//Benefit_Month
//			stringBuilder.Append(GetDB(value.AYearMonth.Month));
//			stringBuilder.Append(", ");
//
//			//Benefit_Description
//			stringBuilder.Append(GetDB(value.Description));
//			stringBuilder.Append(", ");
//
//			//Benefit_Amount
//			stringBuilder.Append(GetDB(value.TotalAmount));
//			stringBuilder.Append(", ");
//
//			//Payment_Status
//			stringBuilder.Append(GetDB(value.ABenefitPayment.PaymentStatus));
//			stringBuilder.Append(", ");
//
//			//Payment_Date
//			if(IsNotNULL(value.ABenefitPayment.PaymentDate))
//			{
//				stringBuilder.Append(GetDB(value.ABenefitPayment.PaymentDate));
//			}
//			else
//			{
//				stringBuilder.Append(GetDB(NullConstant.DATETIME));
//			}
//			stringBuilder.Append(", ");
//
//			//Process_Date
//			stringBuilder.Append(GetDateDB());
//			stringBuilder.Append(", ");
//
//			//Process_User
//			stringBuilder.Append(GetDB(UserProfile.UserID));
//			stringBuilder.Append(")");
//
//			return stringBuilder.ToString();
//		}
//
//		private string getSQLUpdate(MiscBenefit value, Employee aEmployee)
//		{
//			StringBuilder stringBuilder = new StringBuilder("UPDATE ");
//			stringBuilder.Append(tableName);
//			stringBuilder.Append(" SET ");
//
//			stringBuilder.Append(" Company_Code = ");
//			stringBuilder.Append(GetDB(aEmployee.Company.CompanyCode));
//			stringBuilder.Append(", ");
//
//			stringBuilder.Append(" Employee_No = ");
//			stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
//			stringBuilder.Append(", ");
//
//			stringBuilder.Append(" Benefit_Year = ");
//			stringBuilder.Append(GetDB(value.AYearMonth.Year));
//			stringBuilder.Append(", ");
//
//			stringBuilder.Append(" Benefit_Month = ");
//			stringBuilder.Append(GetDB(value.AYearMonth.Month));
//			stringBuilder.Append(", ");
//
//			stringBuilder.Append(" Benefit_Description = ");
//			stringBuilder.Append(GetDB(value.Description));
//			stringBuilder.Append(", ");
//
//			stringBuilder.Append(" Benefit_Amount = ");
//			stringBuilder.Append(GetDB(value.TotalAmount));
//			stringBuilder.Append(", ");
//
//			stringBuilder.Append(" Payment_Status = ");
//			stringBuilder.Append(GetDB(value.ABenefitPayment.PaymentStatus));
//			stringBuilder.Append(", ");
//
//			stringBuilder.Append(" Payment_Date = ");
//			if(IsNotNULL(value.ABenefitPayment.PaymentDate))
//			{
//				stringBuilder.Append(GetDB(value.ABenefitPayment.PaymentDate));
//			}
//			else
//			{
//				stringBuilder.Append(GetDB(NullConstant.DATETIME));
//			}
//			stringBuilder.Append(", ");
//
//			stringBuilder.Append(" Process_Date = ");
//			stringBuilder.Append(GetDateDB());
//			stringBuilder.Append(", ");
//
//			stringBuilder.Append(" Process_User = ");
//			stringBuilder.Append(GetDB(UserProfile.UserID));
//			
//			return stringBuilder.ToString();
//		}	
//
//		private string getSQLDelete()
//		{
//			return " DELETE FROM " + tableName + " ";
//		}
//
//		private string getKeyCondition(MiscBenefit value)
//		{
//			StringBuilder stringBuilder = new StringBuilder();
//			if(IsNotNULL(value.AYearMonth.Year))
//			{
//				stringBuilder.Append(" AND (Benefit_Year = ");
//				stringBuilder.Append(GetDB(value.AYearMonth.Year));
//				stringBuilder.Append(")");
//			}
//			if(IsNotNULL(value.AYearMonth.Month))
//			{
//				stringBuilder.Append(" AND (Benefit_Month = ");
//				stringBuilder.Append(GetDB(value.AYearMonth.Month));
//				stringBuilder.Append(")");
//			}
//			if(IsNotNULL(value.Description))
//			{
//				stringBuilder.Append(" AND (Benefit_Description = ");
//				stringBuilder.Append(GetDB(value.Description));
//				stringBuilder.Append(")");
//			}
//			return stringBuilder.ToString();
//		}
//
//		private string getOrderby()
//		{
//			return " ORDER BY Employee_No, Benefit_Year, Benefit_Month, Benefit_Description ";
//		}
//		#endregion
//
//		#region - fill -
//		private void fillMiscellaneousBenefit(ref MiscBenefit value, SqlDataReader dataReader)
//		{		
//			YearMonth yearMonth = new YearMonth(dataReader.GetInt16(BENEFIT_YEAR), dataReader.GetByte(BENEFIT_MONTH));
//			value.AYearMonth = yearMonth;
//			value.TotalAmount = dataReader.GetDecimal(BENEFIT_AMOUNT);
//			value.Description = (string)dataReader[BENEFIT_DESCTIPTION];
//
//			if (dataReader.IsDBNull(PAYMENT_DATE))
//			{
//				value.ABenefitPayment.PaymentDate = NullConstant.DATETIME;
//			}
//			else
//			{
//				value.ABenefitPayment.PaymentDate = dataReader.GetDateTime(PAYMENT_DATE);
//			}
//
//			if(dataReader.IsDBNull(PAYMENT_STATUS))
//			{
//				value.ABenefitPayment.PaymentStatus = PAYMENT_STATUS_TYPE.NULL;
//			}
//			else
//			{
//				value.ABenefitPayment.PaymentStatus = CTFunction.GetPaymentStatusType((string)dataReader[PAYMENT_STATUS]);
//			}
//		}
//
//		private bool fillMiscellaneousBenefitList(ref EmployeeMiscBenefit value, string sql)
//		{
//			bool result = false;
//			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
//			try
//			{
//				while (dataReader.Read())
//				{
//					result = true;
//					objMiscBenefit = new MiscBenefit();
//					fillMiscellaneousBenefit(ref objMiscBenefit, dataReader);
//					value.Add(objMiscBenefit);
//				}
//				objMiscBenefit = null;
//			}
//			catch(IndexOutOfRangeException ein)
//			{
//				throw ein;
//			}
//			finally
//			{
//				tableAccess.CloseDataReader();				
//			}
//			return result;
//		}
//
//		#endregion
//
////		============================== Public Method ==============================
//		public bool FillMiscellaneousBenefitList(ref EmployeeMiscBenefit value, MiscBenefit aMiscBenefit)
//		{
//			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
//			stringBuilder.Append(getBaseCondition(value.Employee));
//			stringBuilder.Append(getKeyCondition(aMiscBenefit));
//			stringBuilder.Append(getOrderby());
//
//			return fillMiscellaneousBenefitList(ref value, stringBuilder.ToString());
//		}
//
//		public bool InsertMiscellaneousBenefit(MiscBenefit value, Employee aEmployee)
//		{
//			if (tableAccess.ExecuteSQL(getSQLInsert(value, aEmployee))>0)
//			{return true;}
//			else
//			{return false;}	
//		}
//
//		public bool UpdateMiscellaneousBenefit(MiscBenefit value, Employee aEmployee)
//		{
//			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aEmployee));
//			stringBuilder.Append(getBaseCondition(aEmployee));
//			stringBuilder.Append(getKeyCondition(value));
//
//			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
//			{return true;}
//			else
//			{return false;}
//		}
//
//		public bool DeleteMiscellaneousBenefit(MiscBenefit value, Employee aEmployee)
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
//
//		#region IDisposable Members
//		protected override void Dispose(bool disposing)
//		{
//			if(!this.disposed)
//			{
//				try
//				{
//					if(disposing)
//					{
//					}
//					this.disposed = true;
//				}
//				finally
//				{
//					base.Dispose(disposing);
//				}
//			}
//		}
//		#endregion
//
//	}
//}

