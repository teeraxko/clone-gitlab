using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;
using ictus.Common.Entity.General;
using ictus.Common.Entity;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using DataAccess.PiDB;
using DataAccess.CommonDB;

using SystemFramework.AppConfig;

namespace DataAccess.AttendanceDB
{
	public class PayrollPaymentControlDB : DataAccessBase
	{
		#region - Constant -
		private const int FOR_YEAR = 0;
		private const int FOR_MONTH = 1;
		private const int PAYMENT_DATE = 2;
		private const int PAYMENT_STATUS = 3;
		#endregion

		#region - Private -
		private PayrollPaymentControl objPayrollPaymentControl;
		private bool disposed  = false;
		#endregion

//		============================== Constructor ==============================
		public PayrollPaymentControlDB() : base()
		{
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT  For_Year, For_Month, Payment_Date, Payment_Status FROM Payroll_Payment_Control ";
		}

		private string getSQLInsert(PayrollPaymentControl value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Payroll_Payment_Control (Company_Code, For_Year, For_Month, Payment_Date, Payment_Status, Process_Date, Process_User) ");
			stringBuilder.Append("VALUES (");

			//Company_Code
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			//For_Year
			stringBuilder.Append(GetDB(value.AYearMonth.Year));
			stringBuilder.Append(", ");

			//For_Month
			stringBuilder.Append(GetDB(value.AYearMonth.Month));
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

		private string getSQLUpdate(PayrollPaymentControl value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Payroll_Payment_Control SET ");

			stringBuilder.Append(" Company_Code = ");
			stringBuilder.Append(GetDB(aCompany.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append(" For_Year = ");
			stringBuilder.Append(GetDB(value.AYearMonth.Year));
			stringBuilder.Append(", ");

			stringBuilder.Append(" For_Month = ");
			stringBuilder.Append(GetDB(value.AYearMonth.Month));
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
			return " DELETE FROM Payroll_Payment_Control ";
		}

		private string getKeyCondition(YearMonth value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if(IsNotNULL(value.Year))
			{
				stringBuilder.Append(" AND (For_Year = ");
				stringBuilder.Append(GetDB(value.Year));
				stringBuilder.Append(")");
			}
			if(IsNotNULL(value.Month))
			{
				stringBuilder.Append(" AND (For_Month = ");
				stringBuilder.Append(GetDB(value.Month));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

		private string getEntityCondition(BenefitPayment value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if(IsNotNULL(value.PaymentDate))
			{
				stringBuilder.Append(" AND (Payment_Date = ");
				stringBuilder.Append(GetDB(value.PaymentDate));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

		private string getOrderby()
		{
			return " ORDER BY For_Year, For_Month ";
		}
		#endregion

		#region - fill -
		private void fillPayrollPaymentControl(ref PayrollPaymentControl value, SqlDataReader dataReader)
		{		
			YearMonth yearMonth = new YearMonth(dataReader.GetInt16(FOR_YEAR), dataReader.GetByte(FOR_MONTH));
			value.AYearMonth = yearMonth;

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

		private bool fillPayrollPaymentControlList(ref PayrollPaymentControlList value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objPayrollPaymentControl = new PayrollPaymentControl();
					fillPayrollPaymentControl(ref objPayrollPaymentControl, dataReader);
					value.Add(objPayrollPaymentControl);
				}
				objPayrollPaymentControl = null;
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

		private bool fillPayrollPaymentControl(ref PayrollPaymentControl value, string sql)
		{
			bool result;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				if (dataReader.Read())
				{					
					fillPayrollPaymentControl(ref value, dataReader);
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
		public bool FillPayrollPaymentControlList(ref PayrollPaymentControlList value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(getKeyCondition(value.AYearMonth));
			stringBuilder.Append(getOrderby());

			return fillPayrollPaymentControlList(ref value, stringBuilder.ToString());
		}

		public bool FillPayrollPaymentControl(ref PayrollPaymentControl value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value.AYearMonth));

			return fillPayrollPaymentControl(ref value, stringBuilder.ToString());
		}

		public bool FillPayrollPaymentControlByDateList(ref PayrollPaymentControlList value, DateTime dateTime)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Company));
			stringBuilder.Append(" AND (Payment_Date <= ");
			stringBuilder.Append(GetDB(dateTime));
			stringBuilder.Append(" ) AND (Payment_Status = 'N') ");
			stringBuilder.Append(getOrderby());

			return fillPayrollPaymentControlList(ref value, stringBuilder.ToString());
		}

		public bool InsertPayrollPaymentControl(PayrollPaymentControl value, Company aCompany)
		{
			return (tableAccess.ExecuteSQL(getSQLInsert(value, aCompany))>0);
		}

		public bool UpdatePayrollPaymentControl(PayrollPaymentControl value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aCompany));
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value.AYearMonth));
			
			return (tableAccess.ExecuteSQL(stringBuilder.ToString())>0);
		}

		public bool DeletePayrollPaymentControl(PayrollPaymentControl value, Company aCompany)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aCompany));
			stringBuilder.Append(getKeyCondition(value.AYearMonth));

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
