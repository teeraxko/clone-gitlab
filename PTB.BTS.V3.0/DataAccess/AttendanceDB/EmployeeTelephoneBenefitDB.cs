using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.General;
using ictus.Common.Entity.Time;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using DataAccess.CommonDB;
using DataAccess.PiDB;
using DataAccess.ContractDB;

using SystemFramework.AppConfig;

namespace DataAccess.AttendanceDB
{
	public class EmployeeTelephoneBenefitDB : DataAccessBase
	{
		#region - Constant -
		private const int EMPLOYEE_NO = 0;
		private const int BENEFIT_YEAR = 1;
		private const int BENEFIT_MONTH = 2;
		private const int BENEFIT_AMOUNT = 3;		
		private const int PAYMENT_STATUS = 4;
		private const int PAYMENT_DATE = 5;
		#endregion

		#region - Private -
		private TelephoneBenefit objTelephoneBenefit; 
		private bool disposed  = false;
		#endregion

//		============================== Constructor ==============================
		public EmployeeTelephoneBenefitDB() : base()
		{
			
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return " SELECT Employee_No, Benefit_Year, Benefit_Month, Benefit_Amount, Payment_Status, Payment_Date FROM Employee_Telephone_Benefit ";
		}

		private string getSQLInsert(TelephoneBenefit value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Employee_Telephone_Benefit (Company_Code, Employee_No, Benefit_Year, Benefit_Month, Benefit_Amount, Payment_Status, Payment_Date, Process_Date, Process_User) ");
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

		private string getSQLUpdate(TelephoneBenefit value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Employee_Telephone_Benefit SET ");

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

			stringBuilder.Append(" Payment_Status = ");
			if(IsNotNULL(value.ABenefitPayment.PaymentStatus))
			{
				stringBuilder.Append(GetDB(value.ABenefitPayment.PaymentStatus));
				
			}
			else
			{
				stringBuilder.Append("NULL");
			}
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
			return " DELETE FROM Employee_Telephone_Benefit ";
		}

		private string getKeyCondition(TelephoneBenefit value)
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
		private void fillTelephoneBenefit(ref TelephoneBenefit value, SqlDataReader dataReader)
		{
			YearMonth yearMonth = new YearMonth(dataReader.GetInt16(BENEFIT_YEAR), dataReader.GetByte(BENEFIT_MONTH));
			value.AYearMonth = yearMonth;
			value.TotalAmount = dataReader.GetDecimal(BENEFIT_AMOUNT);
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

		private bool fillTelephoneBenefitList(ref EmployeeTelephoneBenefit value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objTelephoneBenefit = new TelephoneBenefit();
					fillTelephoneBenefit(ref objTelephoneBenefit, dataReader);
					value.Add(objTelephoneBenefit);
				}
				objTelephoneBenefit = null;
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

        private bool fillTelephoneBenefit(TelephoneBenefit value, string sql)
        {
            bool result;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                if (dataReader.Read())
                {
                    fillTelephoneBenefit(ref value, dataReader);
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (IndexOutOfRangeException ein)
            { throw ein; }
            finally
            { tableAccess.CloseDataReader(); }
            return result;
        }

		#endregion

//		============================== Public Method ==============================
        public bool FillTelephoneBenefit(TelephoneBenefit value, Employee employee)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(employee));
            stringBuilder.Append(getKeyCondition(value));

            return fillTelephoneBenefit(value, stringBuilder.ToString());
        }

		public bool FillTelephoneBenefitList(ref EmployeeTelephoneBenefit value, TelephoneBenefit aTelephoneBenefit)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getKeyCondition(aTelephoneBenefit));
			stringBuilder.Append(getOrderby());

			return fillTelephoneBenefitList(ref value, stringBuilder.ToString());
		}

		public bool InsertTelephoneBenefit(TelephoneBenefit value, Employee aEmployee)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aEmployee))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool UpdateTelephoneBenefit(TelephoneBenefit value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aEmployee));
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteTelephoneBenefit(TelephoneBenefit value, Employee aEmployee)
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
