using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using ictus.PIS.PI.Entity;
using ictus.Common.Entity.Time;
using ictus.Common.Entity.General;

using Entity.CommonEntity;
using Entity.AttendanceEntities;

using DataAccess.CommonDB;
using DataAccess.AttendanceDB;

using SystemFramework.AppConfig;

using ictus.Common.Entity;

namespace DataAccess.AttendanceDB
{
	public class EmployeeOneDayTripBenefitDB : DataAccessBase
	{
		#region - Constant -
		private const int TO_LOCATION = 0;
		private const int BENEFIT_DATE = 1;
		private const int TIMES = 2;
		private const int BENEFIT_AMOUNT = 3;
		private const int BENEFITTOTAL_AMOUNT = 4;
		private const int PAYMENT_STATUS = 5;
		private const int PAYMENT_DATE = 6;
		#endregion

		#region - Private -
			private OneDayTripBenefit objOneDayTripBenefit;
			private bool disposed = false;
		#endregion

//		============================== Constructor ==============================
		public EmployeeOneDayTripBenefitDB() : base()
		{
		}

//		============================== Private Method ==============================
		#region - getSQL -
		private string getSQLSelect()
		{
			return "SELECT To_Location, Benefit_Date, Times, Benefit_Amount, Benefit_Total_Amount, Payment_Status, Payment_Date FROM Employee_One_Day_Trip_Benefit ";
		}
		
		private string getSQLInsert(OneDayTripBenefit value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("INSERT INTO Employee_One_Day_Trip_Benefit (Company_Code, Employee_No, To_Location, Benefit_Date, Times, Benefit_Amount, Benefit_Total_Amount, Payment_Status, Payment_Date, Process_Date, Process_User) ");
			stringBuilder.Append("VALUES (");

			//Company_Code
			stringBuilder.Append(GetDB(aEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			//Employee_No
			stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			//To_Location
			stringBuilder.Append(GetDB(value.AOneDayTrip.ATripLocation.Name));
			stringBuilder.Append(", ");

			//Benefit_Date
			stringBuilder.Append(GetDB(value.BenefitDate));
			stringBuilder.Append(", ");

			//Times
			stringBuilder.Append(GetDB(value.Times));
			stringBuilder.Append(", ");

			//Benefit_Amount
			stringBuilder.Append(GetDB(value.BenefitAmount));
			stringBuilder.Append(", ");

			//Benefit_Total_Amount
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

		private string getSQLUpdate(OneDayTripBenefit value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder("UPDATE Employee_One_Day_Trip_Benefit SET ");
			
			stringBuilder.Append("Company_Code = ");
			stringBuilder.Append(GetDB(aEmployee.Company.CompanyCode));
			stringBuilder.Append(", ");

			stringBuilder.Append("Employee_No = ");
			stringBuilder.Append(GetDB(aEmployee.EmployeeNo));
			stringBuilder.Append(", ");

			stringBuilder.Append("To_Location = ");
			stringBuilder.Append(GetDB(value.AOneDayTrip.ATripLocation.Name));
			stringBuilder.Append(", ");

			stringBuilder.Append("Benefit_Date = ");
			stringBuilder.Append(GetDB(value.BenefitDate));
			stringBuilder.Append(", ");

			stringBuilder.Append("Times = ");
			stringBuilder.Append(GetDB(value.Times));
			stringBuilder.Append(", ");

			stringBuilder.Append("Benefit_Amount = ");
			stringBuilder.Append(GetDB(value.BenefitAmount));
			stringBuilder.Append(", ");

			stringBuilder.Append("Benefit_Total_Amount = ");
			stringBuilder.Append(GetDB(value.TotalAmount));
			stringBuilder.Append(", ");

			stringBuilder.Append("Payment_Status = ");
			stringBuilder.Append(GetDB(value.ABenefitPayment.PaymentStatus));
			stringBuilder.Append(", ");

			stringBuilder.Append("Payment_Date = ");
			if(IsNotNULL(value.ABenefitPayment.PaymentDate))
			{
				stringBuilder.Append(GetDB(value.ABenefitPayment.PaymentDate));
			}
			else
			{
				stringBuilder.Append(GetDB(NullConstant.DATETIME));
			}
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
			return "DELETE FROM Employee_One_Day_Trip_Benefit ";
		}

		private string getListCondition(YearMonth aYearMonth)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (IsNotNULL(aYearMonth))
			{
				stringBuilder.Append(" AND ");
				stringBuilder.Append(SqlFunction.GetYearMonthCondition("Benefit_Date", aYearMonth));
			}
			return stringBuilder.ToString();
		}

		private string getKeyCondition(OneDayTripBenefit value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (IsNotNULL(value.AOneDayTrip.ATripLocation.Name))
			{
				stringBuilder.Append(" AND (To_Location = ");
				stringBuilder.Append(GetDB(value.AOneDayTrip.ATripLocation.Name));
				stringBuilder.Append(")");
			}
			if (IsNotNULL(value.BenefitDate))
			{
				stringBuilder.Append(" AND (Benefit_Date = ");
				stringBuilder.Append(GetDB(value.BenefitDate));
				stringBuilder.Append(")");
			}
			return stringBuilder.ToString();
		}

        private string getKeyCondition(DateTime value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (IsNotNULL(value))
            {
                stringBuilder.Append(" AND (Benefit_Date = ");
                stringBuilder.Append(GetDB(value));
                stringBuilder.Append(")");
            }
            return stringBuilder.ToString();
        }

		private string getOrderby()
		{
			return " ORDER BY Benefit_Date, To_Location";
		}
		#endregion

		#region - Fill -
		private void fillOneDayTripBenefit(ref OneDayTripBenefit value, SqlDataReader dataReader)
		{
			value.AOneDayTrip.ATripLocation.Name = (string)dataReader[TO_LOCATION];
			value.BenefitDate = dataReader.GetDateTime(BENEFIT_DATE);
			value.Times = dataReader.GetByte(TIMES);
			value.BenefitAmount = dataReader.GetDecimal(BENEFIT_AMOUNT);
			value.TotalAmount = dataReader.GetDecimal(BENEFITTOTAL_AMOUNT);
			value.ABenefitPayment.PaymentStatus = CTFunction.GetPaymentStatusType((string)dataReader[PAYMENT_STATUS]);
			if(dataReader.IsDBNull(PAYMENT_DATE))
			{
				value.ABenefitPayment.PaymentDate = NullConstant.DATETIME;
			}
			else
			{
				value.ABenefitPayment.PaymentDate = dataReader.GetDateTime(PAYMENT_DATE);
			}		
		}
		
		private bool fillOneDayTripBenefitList(ref EmployeeOneDayTripBenefit value, string sql)
		{
			bool result = false;
			SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
			try
			{
				while (dataReader.Read())
				{
					result = true;
					objOneDayTripBenefit = new OneDayTripBenefit();
					fillOneDayTripBenefit(ref objOneDayTripBenefit, dataReader);
					value.Add(objOneDayTripBenefit);
				}
			}
			catch (IndexOutOfRangeException ein)
			{
				throw ein;
			}
			finally
			{
				tableAccess.CloseDataReader();
			}			
			return result;				
		}

        private bool fillOneDayTripBenefit(OneDayTripBenefit value, string sql)
        {
            bool result;
            SqlDataReader dataReader = tableAccess.ExecuteDataReader(sql);
            try
            {
                if (dataReader.Read())
                {
                    fillOneDayTripBenefit(ref value, dataReader);
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (IndexOutOfRangeException ein)
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
		public bool FillOneDayTripBenefitList(ref EmployeeOneDayTripBenefit value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getListCondition(value.ForYearMonth));
			stringBuilder.Append(getOrderby());

			return fillOneDayTripBenefitList(ref value, stringBuilder.ToString());
		}

        public bool FillOneDayTripBenefit(OneDayTripBenefit value, Employee employee, DateTime forDate)
        {
            StringBuilder stringBuilder = new StringBuilder(getSQLSelect());
            stringBuilder.Append(getBaseCondition(employee));
            stringBuilder.Append(getKeyCondition(forDate));

            return fillOneDayTripBenefit(value, stringBuilder.ToString());
        }

		public bool InsertOneDayTripBenefit(OneDayTripBenefit value, Employee aEmployee)
		{
			if (tableAccess.ExecuteSQL(getSQLInsert(value, aEmployee))>0)
			{return true;}
			else
			{return false;}	
		}

		public bool InsertOneDayTripBenefit(EmployeeOneDayTripBenefit value)
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

		public bool UpdateOneDayTripBenefit(OneDayTripBenefit value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLUpdate(value, aEmployee));
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteOneDayTripBenefit(EmployeeOneDayTripBenefit value)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getListCondition(value.ForYearMonth));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool DeleteOneDayTripBenefit(OneDayTripBenefit value, Employee aEmployee)
		{
			StringBuilder stringBuilder = new StringBuilder(getSQLDelete());
			stringBuilder.Append(getBaseCondition(aEmployee));
			stringBuilder.Append(getKeyCondition(value));

			if (tableAccess.ExecuteSQL(stringBuilder.ToString())>0)
			{return true;}
			else
			{return false;}
		}

		public bool UpdateEmployeeOneDayTripBenefit(EmployeeOneDayTripBenefit value)
		{
			StringBuilder stringBuilder = new StringBuilder("BEGIN ");

			stringBuilder.Append(getSQLDelete());
			stringBuilder.Append(getBaseCondition(value.Employee));
			stringBuilder.Append(getListCondition(value.ForYearMonth));
			stringBuilder.Append("; ");

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

		#region IDisposable Members
		protected override void Dispose(bool disposing)
		{
			if(!this.disposed)
			{
				try
				{
					if(disposing)
					{
						objOneDayTripBenefit = null;
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
